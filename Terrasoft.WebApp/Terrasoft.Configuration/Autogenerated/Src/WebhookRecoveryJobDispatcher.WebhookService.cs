namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using global::Common.Logging;
	using Quartz;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Scheduler;
	using Terrasoft.Web.Common;
	using SysSettingsCore = Terrasoft.Core.Configuration.SysSettings;

	#region Class: WebhookCleanerJobDispatcher

	/// <summary>
	/// Provides methods to schedule job and repair broken webhooks.
	/// </summary>
	public class WebhookRecoveryJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{

		#region Fields: Private

		private readonly Guid NewWebhookStatusId = Guid.Parse(WebhookServiceConstants.NewWebhookStatus);

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

		private EntityCollection GetWebhookStatusesToRecover() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WebhookStatus");
			IEntitySchemaQueryFilterItem filter =
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "DisasterRecoveryAfter", 0);
			esq.Filters.Add(filter);
			esq.AddColumn("DisasterRecoveryAfter");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq.GetEntityCollection(UserConnection);
		}

		private void UpdateStuckedWebhooks(Guid statusId, int recoverAfterMinutes) {
			if (recoverAfterMinutes <= 0) {
				return;
			}
			DateTime checkTime = DateTime.UtcNow.AddMinutes(-recoverAfterMinutes);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Webhook");
			IEntitySchemaQueryFilterItem dateFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "ModifiedOn", checkTime);
			IEntitySchemaQueryFilterItem statusFiler =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", statusId);
			esq.Filters.Add(dateFilter);
			esq.Filters.Add(statusFiler);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("ModifiedOn");
			esq.AddColumn("Status");
			esq.GetEntityCollection(UserConnection)
				.ToList()
				.ForEach(entity => {
					entity.SetColumnValue("StatusId", NewWebhookStatusId);
					entity.Save();
				});
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
			int periodInMinutes = (int)SysSettingsCore.GetValue(UserConnection, "WebhookRecoveryJobInterval");
			bool isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<WebhookRecoveryJobDispatcher>(JobGroupName, UserConnection.Workspace.Name,
				currentUser.Name, periodInMinutes, null, isSystemUser, misfirePolicy);
		}

		/// <summary>
		/// Provides logic to be executed in job thread.
		/// </summary>
		protected override void InternalExecute() {
			EntityCollection statusesToClean = GetWebhookStatusesToRecover();
			foreach (Entity entity in statusesToClean) {
				var statusId = entity.PrimaryColumnValue;
				var recoverAfterMinutes = entity.GetTypedColumnValue<int>("DisasterRecoveryAfter");
				UpdateStuckedWebhooks(statusId, recoverAfterMinutes);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules minutely job for recovering stucked webhooks and tries to reschedule broken triggers.
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
