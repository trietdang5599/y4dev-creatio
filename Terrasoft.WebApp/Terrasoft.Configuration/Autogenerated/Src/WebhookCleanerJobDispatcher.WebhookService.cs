namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Quartz;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Scheduler;
	using Terrasoft.Web.Common;
	using SysSettingsCore = Terrasoft.Core.Configuration.SysSettings;

	#region Class: WebhookCleanerJobDispatcher

	/// <summary>
	/// Provides methods to schedule job and cleanup old webhooks.
	/// </summary>
	public class WebhookCleanerJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{
		private class CleanupResults
		{
			public int DeletedCount { get; set; }
			public int FailedCount { get; set; }
			public int BatchesCount { get; set; }
		}
		
		#region Constants: Private

		private const int BatchSize = 1000;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name "WebhooksQuartzScheduler" or default.
		/// </summary>
		public IScheduler WebhooksScheduler => DefaultScheduler.FindScheduler("WebhooksQuartzScheduler")
			?? DefaultScheduler.Instance;

		/// <summary>
		/// Name of job group.
		/// </summary>
		public override string JobGroupName => "Webhooks";

		#endregion

		#region Methods: Private

		private EntityCollection GetWebhookStatusesToClean() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WebhookStatus");
			IEntitySchemaQueryFilterItem filter =
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "DeleteAfterDays", 0);
			esq.Filters.Add(filter);
			esq.AddColumn("DeleteAfterDays");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq.GetEntityCollection(UserConnection);
		}

		private CleanupResults RemoveWebhooks(Guid statusId, int deleteAfterDays) {
			if (deleteAfterDays <= 0) {
				return new CleanupResults();
			}
			DateTime checkTime = DateTime.UtcNow.AddDays(-deleteAfterDays);
			var totalDeleted = 0;
			var totalFailed = 0;
			var batchesCount = 0;

			while (true) {
				var ids = GetWebhookIdsToDelete(statusId, checkTime, BatchSize, totalFailed);
				if (ids.Count == 0) {
					break;
				}

				if (TryBatchDelete(ids)) {
					totalDeleted += ids.Count;
				} else {
					var (deleted, failedIds) = DeleteOneByOne(ids);
					totalDeleted += deleted;
					totalFailed += failedIds.Count;
				}
				batchesCount++;
			}

			return new CleanupResults() {
				DeletedCount = totalDeleted,
				FailedCount = totalFailed,
				BatchesCount = batchesCount
			};
		}

		private List<Guid> GetWebhookIdsToDelete(Guid statusId, DateTime checkTime, int batchSize, int offset) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Webhook");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "ModifiedOn", checkTime));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", statusId));
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.PrimaryQueryColumn.OrderByAsc();
			esq.RowCount = batchSize;
			esq.SkipRowCount = offset;
			return esq.GetEntityCollection(UserConnection)
				.Select(e => e.PrimaryColumnValue)
				.ToList();
		}

		private bool TryBatchDelete(List<Guid> ids) {
			try {
				var delete = new Delete(UserConnection)
					.From("Webhook")
					.Where("Id").In(Column.Parameters(ids));
				delete.Execute();
				return true;
			} catch (Exception ex) {
				Logger.Debug($"Batch delete failed for {ids.Count} webhooks, falling back to one-by-one: {ex.Message}");
				return false;
			}
		}

		private (int deleted, List<Guid> failed) DeleteOneByOne(List<Guid> ids) {
			int deletedCount = 0;
			var failedIds = new List<Guid>();

			foreach (var id in ids) {
				try {
					var delete = new Delete(UserConnection)
						.From("Webhook")
						.Where("Id").IsEqual(Column.Parameter(id));
					delete.Execute();
					deletedCount++;
				} catch (Exception ex) {
					Logger.Debug($"Failed to delete webhook {id}: {ex.Message}");
					failedIds.Add(id);
				}
			}

			return (deletedCount, failedIds);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override ILog GetLogger() => LogManager.GetLogger("Webhooks");

		/// <inheritdoc/>
		protected override IScheduler GetScheduler() => WebhooksScheduler;

		/// <summary>
		/// Schedules job.
		/// </summary>
		/// <param name="workspaceName">Name of current workspace.</param>
		/// <param name="userName">Current user name.</param>
		protected override void ScheduleJob(string workspaceName, string userName) {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			Logger.Info($"Scheduling WebhookCleanerJobDispatcher for user {currentUser.Name}");
			int periodInMinutes = (int)SysSettingsCore.GetValue(UserConnection, "WebhookCleanerJobInterval");
			bool isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<WebhookCleanerJobDispatcher>(JobGroupName, UserConnection.Workspace.Name,
				currentUser.Name, periodInMinutes, null, isSystemUser, misfirePolicy);
		}

		/// <summary>
		/// Provides logic to be executed in job thread.
		/// </summary>
		protected override void InternalExecute() {
			EntityCollection statusesToClean = GetWebhookStatusesToClean();
			foreach (Entity entity in statusesToClean) {
				var statusId = entity.PrimaryColumnValue;
				var deleteAfterDays = entity.GetTypedColumnValue<int>("DeleteAfterDays");
				var results = RemoveWebhooks(statusId, deleteAfterDays);
				
				if (results.DeletedCount > 0 || results.FailedCount > 0) {
					Logger.Info($"Webhook cleanup completed for status {statusId}: deleted {results.DeletedCount}, failed {results.FailedCount}, in {results.BatchesCount} batch(es)");
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules minutely job for old webhooks cleaning and tries to reschedule broken triggers.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			GetUserConnection(context);
			TryRescheduleJob();
		}

		public void OnAppEnd(AppEventContext context) { }

		public void OnSessionStart(AppEventContext context)  { }

		public void OnSessionEnd(AppEventContext context)  { }

		#endregion

	}

	#endregion

}
