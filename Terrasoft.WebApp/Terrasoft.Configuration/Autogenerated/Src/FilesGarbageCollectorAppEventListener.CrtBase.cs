 namespace Terrasoft.Configuration
{
	using Common;
	using Core;
	using Core.Configuration;
	using Terrasoft.Core.Scheduler;
	using Web.Common;
	using CoreSysSettings = Core.Configuration.SysSettings;

	#region Class : FilesGarbageCollectorAppEventListener

	/// <summary>
	/// A class that setup`s files garbage collector on app start.
	/// </summary>
	public class FilesGarbageCollectorAppEventListener : AppEventListenerBase
	{

		#region Constants : Private
		
		/// <summary>
		/// Job group name.
		/// </summary>
		private const string JobGroupName = "FilesGroup";

		#endregion

		#region Fields : Private

		protected UserConnection UserConnection	{
			get;
			private set;
		}

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Gets user connection from application event context.
		/// </summary>
		/// <param name="context">Application event context.</param>
		/// <returns>User connection.</returns>
		protected UserConnection GetUserConnection(AppEventContext context)	{
			var appConnection = context.Application["AppConnection"] as AppConnection;
			if (appConnection == null) {
				throw new ArgumentNullOrEmptyException("AppConnection");
			}
			return appConnection.SystemUserConnection;
		}

		/// <summary>
		/// Schedules a minutely job.
		/// </summary>
		/// <typeparam name="TJob">Job type.</typeparam>
		/// <param name="periodInMinutes">Period in minutes.</param>
		protected virtual void ScheduleJob<TJob>(int periodInMinutes) where TJob : IJobExecutor	{
			SysUserInfo currentUser = UserConnection.CurrentUser;
			string className = typeof(TJob).AssemblyQualifiedName;
			if (UserConnection.GetIsFeatureEnabled("DisableDeleteLinkedFiles")) {
				AppScheduler.RemoveJob(className, JobGroupName);
			} else {
				if (!AppScheduler.DoesJobExist(className, JobGroupName)) {
					var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
					AppScheduler.ScheduleMinutelyJob<TJob>(JobGroupName, UserConnection.Workspace.Name,
						currentUser.Name, periodInMinutes, null, true, misfirePolicy);
				}
			}
		}

		/// <summary>
		/// Sets up jobs.
		/// </summary>
		protected virtual void SetupJobs() {
			var registrationTimeoutExecutionPeriod = CoreSysSettings.GetValue(UserConnection, "FilesGarbageCollectorFrequency", 60);
			ScheduleJob<FilesGarbageCollectorJob>(registrationTimeoutExecutionPeriod);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Handles application start.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			UserConnection = GetUserConnection(context);
			SetupJobs();
		}

		#endregion

	}

	#endregion

} 
