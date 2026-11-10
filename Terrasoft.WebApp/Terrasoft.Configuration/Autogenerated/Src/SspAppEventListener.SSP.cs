namespace Terrasoft.Configuration
{
	using Common;
	using Core;
	using Core.Configuration;
	using Core.Scheduler;
	using Web.Common;

	#region Class : SspAppEventListener

	/// <summary>
	/// A class that setup`s portal features on app start.
	/// </summary>
	public class SspAppEventListener : AppEventListenerBase
	{

		#region Constants : Private

		/// <summary>
		/// Daily execution period.
		/// </summary>
		private const int RegistrationTimeoutExecutionPeriod = 24 * 60;
		private const string RegistrationJobGroupName = "RegistrationTimeoutGroup";

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
			if (!AppScheduler.DoesJobExist(className, RegistrationJobGroupName)) {
				AppScheduler.ScheduleMinutelyJob<TJob>(RegistrationJobGroupName, UserConnection.Workspace.Name,
					currentUser.Name, periodInMinutes, null, true);
			}
		}

		/// <summary>
		/// Sets up jobs.
		/// </summary>
		protected virtual void SetupJobs() {
			ScheduleJob<RegistrationTimeoutJob>(RegistrationTimeoutExecutionPeriod);
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
