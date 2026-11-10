namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl.Triggers;
	using Terrasoft.Core;
	using global::Common.Logging;
	using Terrasoft.Core.Factories;

	#region Class: WebhookJobDispatcher

	[DefaultBinding(typeof(IWebhookJobDispatcher))]
	public class WebhookJobDispatcher : IWebhookJobDispatcher
	{

		#region Fields: Private

		private const string _webhookSchedulerName = "WebhookQuartzScheduler";

		private const string _webhookSchedulerJobGroupName = "WebhookToEntity";

		private const string _webhookSchedulerJobName = "ScheduledWebhookToEntityJob_{0}";

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger(nameof(WebhookJobDispatcher)));

		private UserConnection UserConnection { get; }

		private string WebhookSchedulerProcessName { get; }

		private IAppSchedulerWraper _appSchedulerWrapper;
		private IAppSchedulerWraper AppSchedulerWrapper => _appSchedulerWrapper
			?? (_appSchedulerWrapper = ClassFactory.Get<IAppSchedulerWraper>());

		private IScheduler _webhookScheduler;
		private IScheduler WebhookScheduler => _webhookScheduler ?? (_webhookScheduler = GetWebhookScheduler());

		#endregion

		#region Constructors: Public

		public WebhookJobDispatcher(UserConnection userConnection) {
			UserConnection = userConnection;
			WebhookSchedulerProcessName = Core.Configuration.SysSettings.GetValue(userConnection, "WebhookToEntityProcessName", string.Empty);
		}

		public WebhookJobDispatcher(UserConnection userConnection, IAppSchedulerWraper schedulerWrapper)
				: this(userConnection) {
			_appSchedulerWrapper = schedulerWrapper;
		}

		#endregion

		#region Methods: Private

		private IScheduler GetWebhookScheduler() {
			return AppSchedulerWrapper.FindScheduler(_webhookSchedulerName) ?? AppSchedulerWrapper.Instance;
		}

		private string GetWebhookToEntityJobName(Guid batchId) {
			return string.Format(_webhookSchedulerJobName, batchId);
		}

		#endregion

		#region Methods: Public

		public virtual void ScheduleJob(Guid batchId) {
			var jobName = GetWebhookToEntityJobName(batchId);
			var jobParameters = new Dictionary<string, object> {
				["BatchId"] = batchId
			};
			try {
				var jobDetail = AppSchedulerWrapper.CreateProcessJob(
					jobName,
					_webhookSchedulerJobGroupName,
					WebhookSchedulerProcessName,
					UserConnection.Workspace.Name,
					UserConnection.CurrentUser.Name,
					jobParameters,
					true
				);
				var trigger = new SimpleTriggerImpl(jobName, _webhookSchedulerJobGroupName);
				WebhookScheduler.ScheduleJob(jobDetail, trigger);
			} catch (Exception ex) {
				Logger.Error($"Error scheduling webhook to entity job for batch {batchId}", ex);
			}
		}

		public virtual void ScheduleJobs(List<Guid> batchIds) {
			batchIds.ForEach(ScheduleJob);
		}

		#endregion

	}

	#endregion

}

