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

	#region Class: WebhookLogsCleanerJobDispatcher

	/// <summary>
	/// Provides methods to get broken bulk emails and cleanup its status.
	/// </summary>
	public class WebhookLogsCleanerJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{

		#region Constants: Private

		/// <summary>
		/// Log cleaner job timer interval.
		/// </summary>
		private int _logJobIntervalMinutes = 1440;

		#endregion

		#region Methods: Private

		private void DeleteWebhookLogByExpirationPeriod() {
			int logExpirationDays = (int)SysSettingsCore.GetValue(UserConnection, "WebhookLogsExpirationPeriod");
			if (logExpirationDays <= 0) {
				return;
			}
			DateTime checkTime = DateTime.UtcNow.AddDays(-logExpirationDays);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WebhookLog");
			IEntitySchemaQueryFilterItem filter =
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "CreatedOn", checkTime);
			esq.Filters.Add(filter);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("CreatedOn");
			esq.GetEntityCollection(UserConnection)
				.ToList()
				.ForEach(entity => entity.Delete());
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns specific instance of <see cref="ILog"/>.
		/// </summary>
		/// <returns>Logger instance.</returns>
		protected override ILog GetLogger() {
			return LogManager.GetLogger(JobGroupName);
		}

		/// <summary>
		/// Returns specific instance of <see cref="IScheduler"/>.
		/// </summary>
		/// <returns>Instance of Scheduler.</returns>
		protected override IScheduler GetScheduler() => LogCleanerScheduler;

		/// <summary>
		/// Schedules job.
		/// </summary>
		/// <param name="workspaceName">Name of current workspace.</param>
		/// <param name="userName">Current user name.</param>
		protected override void ScheduleJob(string workspaceName, string userName) {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			bool isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<WebhookLogsCleanerJobDispatcher>(JobGroupName, UserConnection.Workspace.Name,
				currentUser.Name, _logJobIntervalMinutes, null, isSystemUser, misfirePolicy);
		}

		/// <summary>
		/// Provides logic to be executed in job thread.
		/// </summary>
		protected override void InternalExecute() {
			DeleteWebhookLogByExpirationPeriod();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Name of job group.
		/// </summary>
		public override string JobGroupName => "Webhooks";

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name <see cref="WebhooksQuartzScheduler"/> or default.
		/// </summary>
		public IScheduler LogCleanerScheduler => DefaultScheduler.FindScheduler("WebhooksQuartzScheduler")
			?? DefaultScheduler.Instance;

		/// <summary>
		/// Schedules minutely job for webhook logs cleaning and tries to reschedule broken triggers.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			GetUserConnection(context);
			TryRescheduleJob();
		}

		public void OnAppEnd(AppEventContext context) { }

		public void OnSessionStart(AppEventContext context) { }

		public void OnSessionEnd(AppEventContext context) { }

		#endregion


	}

	#endregion

}
