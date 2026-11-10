namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using Common;
	using Core;
	using Core.Configuration;
	using Core.Scheduler;
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelMessaging.Telegram;
	using OmnichannelMessaging.WhatsApp;
	using OmnichannelMessaging.Sms;
	using OmnichannelProviders;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.Interfaces;
	using OmnichannelProviders.MessageWorkers;
	using OmnichannelProviders.ProfileDataProviders;
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Web.Common;

	#region Class : OmnichannelMessagingAppEventListener
	/// <summary>
	/// Class, that run all what OmnichannelMessaging need on app start.
	/// </summary>
	public class OmnichannelMessagingAppEventListener : AppEventListenerBase
	{

		#region Constants : Private

		/// <summary>
		/// Execute every minute.
		/// </summary>
		private const int DefaultExecutionPeriod = 1;
		private const string JobGroupName = "OmnichannelMessagingGroup";
		private const int FacebookActualizePeriod = 60 * 24 * 10;
		private const int RunAndCheckTelegramPeriod = 5;
		private const int OperatorTemplateUsageCleanupPeriod = 60 * 24;

		#endregion

		#region Fields: Private 
		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		private ILog Log {
			get
			{
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessaging"));
			}
		}
		#endregion

		#region Fields : Protected

		protected UserConnection UserConnection {
			get;
			private set;
		}

		protected static IIncomingMessageNotifier Notifier;

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Gets user connection from application event context.
		/// </summary>
		/// <param name="context">Application event context.</param>
		/// <returns>User connection.</returns>
		protected UserConnection GetUserConnection(AppEventContext context) {
			var appConnection = context.Application["AppConnection"] as AppConnection;
			if (appConnection == null) {
				throw new ArgumentNullOrEmptyException("AppConnection");
			}
			return appConnection.SystemUserConnection;
		}

		protected void CreateNotifiers() {
			Notifier = ClassFactory.Get<IIncomingMessageNotifier>();
			Log.Info("OmnichannelMessagingAppEventListener: Notifiers were created");
		}

		/// <summary>
		/// Schedules a minutely job.
		/// </summary>
		/// <typeparam name="TJob">Job type.</typeparam>
		/// <param name="periodInMinutes">Period in minutes.</param>
		protected virtual void ScheduleJob<TJob>(int periodInMinutes)
			where TJob : IJobExecutor {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			string className = typeof(TJob).AssemblyQualifiedName;
			try {
				if (!AppScheduler.DoesJobExist(className, JobGroupName)) {
					AppScheduler.ScheduleMinutelyJob<TJob>(JobGroupName, UserConnection.Workspace.Name,
						currentUser.Name, periodInMinutes, null, true);
				}
			} catch (Exception ex) {
				Log.ErrorFormat("Error while scheduling job {0}", ex, className);
			}
		}

		/// <summary>
		/// Sets up omnichannel jobs.
		/// </summary>
		protected virtual void SetupOmnichannelMessagingJobs() {
			ScheduleJob<OmnichannelChatCloser>(DefaultExecutionPeriod);
			ScheduleJob<OmnichannelChatForFreeDistributorJob>(DefaultExecutionPeriod);
			ScheduleJob<FacebookActualizeJob>(FacebookActualizePeriod);
			ScheduleJob<RunTelegramChannelsJob>(RunAndCheckTelegramPeriod);
			ScheduleJob<OperatorTemplateUsageCleanupJob>(OperatorTemplateUsageCleanupPeriod);
			if (UserConnection.GetIsFeatureEnabled("OperatorStatusAutoUpdateEnabled")) {
				ScheduleJob<ChatOperatorLastActivityJob>(DefaultExecutionPeriod);
			}
			Log.Info("OmnichannelMessagingAppEventListener: OmnichannelMessaging Jobs were ran");
		}

		protected virtual void BindRegistrationWorker() {
			ClassFactory.Bind<IMessengerRegistrationWorker, FacebookRegistrationWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IMessengerRegistrationWorker, WhatsAppRegistrationWorker>(ChannelType.WhatsApp.ToString());
			ClassFactory.Bind<IMessengerRegistrationWorker, WhatsAppRegistrationWorker>(ChannelType.SmsTwilio.ToString());
		}

		protected virtual void BindProfileDataProvider() {
			ClassFactory.Bind<IProfileDataProvider, FacebookProfileDataProvider>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IProfileDataProvider, TelegramProfileDataProvider>(ChannelType.Telegram.ToString());
		}

		protected virtual void BindAttachmentLoadWorker() {
			ClassFactory.Bind<IAttachmentsLoadWorker, FacebookAttachmentLoadWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IAttachmentsLoadWorker, TelegramAttachmentLoadWorker>(ChannelType.Telegram.ToString());
			ClassFactory.Bind<IAttachmentsLoadWorker, WhatsAppAttachmentLoadWorker>(ChannelType.WhatsApp.ToString());
		}

		protected virtual void BindOutcomeMessageWorker() {
			ClassFactory.Bind<IOutcomeMessageWorker, FacebookMessageWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IOutcomeMessageWorker, TelegramOutcomeMessageWorker>(ChannelType.Telegram.ToString());
			ClassFactory.Bind<IOutcomeMessageWorker, WhatsAppOutcomeWorker>(ChannelType.WhatsApp.ToString());
			ClassFactory.Bind<IOutcomeMessageWorker, SmsOutcomeWorker>(ChannelType.SmsTwilio.ToString());
		}

		protected virtual void BindIncomeMessageWorker() {
			ClassFactory.Bind<IIncomeMessageWorker, FacebookIncomeMessageWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IIncomeMessageWorker, TelegramIncomeMessageWorker>(ChannelType.Telegram.ToString());
		}

		protected virtual void BindContactIdentityGenerator() {
			ClassFactory.Bind<IGenerateContactIdentity, SmsContactIdentityGenerator>(ChannelType.SmsTwilio.ToString());
		}

		protected void BindInterfaces() {
			BindRegistrationWorker();
			BindProfileDataProvider();
			BindAttachmentLoadWorker();
			BindOutcomeMessageWorker();
			BindIncomeMessageWorker();
			BindContactIdentityGenerator();
			ClassFactory.Bind<ILanguageIterator, ChatLanguageIterator>("OmniChat");
			ClassFactory.Bind<IOperatorRoutingRule, ForEveryoneOperatorRoutingRule>(
				OmnichannelMessagingConsts.QueueOperatorRoutingRuleForEveryone);
			ClassFactory.Bind<IOperatorRoutingRule, ForFreeOperatorRoutingRule>(
				OmnichannelMessagingConsts.QueueOperatorRoutingRuleForFree);
			Log.Info("OmnichannelMessagingAppEventListener: Interfaces were bound");
		}

		/// <summary>
		/// Clears chat operators repository <see cref="ICacheStore"/> instance.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		protected void ClearOperatorsCache(UserConnection uc) {
			new ChatOperatorCache(uc).ClearCache();
			new ChatOperatorTransferStore(uc).ClearCache();
			Log.Debug("OmnichannelMessagingAppEventListener: Operator cache was cleared");
		}

		#endregion

		#region Methods : Private

		private void StartTelegramChannel() {
			TelegramClientFactory.Instance.Initialize(UserConnection, new TelegramMessageReceiver(UserConnection));
			Log.Info("OmnichannelMessagingAppEventListener: TelegramClientFactory was initialized");
			new RunTelegramChannelsJob().Execute(UserConnection, null);
			Log.Info("OmnichannelMessagingAppEventListener: TelegramChannelsJob was ran");
		}

		private void InitializeOmnichannels() {
			LoggerWrapper.Logger = LogManager.GetLogger("OmnichannelMessagingLib");
			ClearOperatorsCache(UserConnection);
			StartTelegramChannel();
			SetupOmnichannelMessagingJobs();
			CreateNotifiers();
			BindInterfaces();
		}

		private void StartOmnichannelsAfterWorkspaceChanged(object sender, EventArgs eventArgs) {
			Log.Debug("OmnichannelMessagingAppEventListener: StartOmnichannelsAfterWorkspaceChanged executed");
			var entity = sender as Entity;
			if (entity != null) {
				UserConnection = entity.UserConnection;
				ClearTelegramChannelsList(UserConnection);
				InitializeOmnichannels();
			} else {
				Log.Error("OmnichannelMessagingAppEventListener: UserConnection is null StartOmnichannelsAfterWorkspaceChanged");
			}
		}

		private void ClearTelegramChannelsList(UserConnection userConnection) {
			var cacheList = userConnection.ApplicationCache[RunTelegramChannelsJob.CacheChannelsName] as List<string>;
			if (cacheList != null) {
				userConnection.ApplicationCache.Remove(RunTelegramChannelsJob.CacheChannelsName);
			}
		}

		private void ReDistributeAllQueues(UserConnection userConnection) {
			try {
				var queueRepository = new ChatQueueRepository(userConnection);
				var queueIds = queueRepository.GetActiveQueueIds();
				var distributor = new ChatQueueDistributor(userConnection);
				foreach (var queueId in queueIds) {
					distributor.Distribute(queueId);
				}
				Log.Info("OmnichannelMessagingAppEventListener: All queues were redistributed");
			} catch (Exception ex) {
				Log.Error("OmnichannelMessagingAppEventListener: An error occured while redistributing queues", ex);
			}
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Handles application start.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppStart(AppEventContext context) {
			Log.Info("OmnichannelMessagingAppEventListener: OnAppStart executed");
			base.OnAppStart(context);
			UserConnection = GetUserConnection(context);
			InitializeOmnichannels();
			UserConnection.Workspace.WorkspaceAssemblyChanged += StartOmnichannelsAfterWorkspaceChanged;
			ReDistributeAllQueues(UserConnection);
		}

		/// <summary>
		/// Handles application end.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppEnd(AppEventContext context) {
			var userConnection = GetUserConnection(context);
			ClearTelegramChannelsList(userConnection);
			base.OnAppEnd(context);
		}

		#endregion

	}

	#endregion

}
