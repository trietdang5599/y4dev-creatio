namespace Terrasoft.Core.Process
{

	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Quartz;
	using Quartz.Impl.Triggers;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.Scheduler;

	#region Class: ScheduleLicensesRedistributionMethodsWrapper

	/// <exclude/>
	public class ScheduleLicensesRedistributionMethodsWrapper : ProcessModel
	{

		public ScheduleLicensesRedistributionMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var redistributeLicencesForSpecificRole = Get<bool>("RedistributeLicencesForSpecificRole");
			var redistributeManuallyAssignedLicences = Get<bool>("RedistributeManuallyAssignedLicences");
			var roleId = Get<Guid>("RoleId");
			LoggingInputParameters(redistributeLicencesForSpecificRole, redistributeManuallyAssignedLicences, roleId);
			var jobName = GetJobName();
			var jobGroupName = GetJobGroupName();
			var processName = GetProcessName();
			var parameters = GetParameters(redistributeLicencesForSpecificRole, redistributeManuallyAssignedLicences, roleId);
			var delayInterval = GetDelayInterval();
			var startTime = DateTime.UtcNow.AddSeconds(delayInterval);
			ScheduleJob(jobName, jobGroupName, processName, parameters, startTime);
			return true;
		}

			public virtual int GetDelayInterval() {
				var defDelayInterval = 60;
				if (SysSettings.TryGetValue(UserConnection, "StartProcessRedistributeLicensesDelayInterval", out var delayInterval)) {
					return (int)delayInterval;
				}
				return defDelayInterval;
			}
			
			public virtual void LoggingInputParameters(bool redistributeLicencesForSpecificRole,
				bool redistributeManuallyAssignedLicences, Guid roleId) {
				var log = LogManager.GetLogger("ScheduleLicensesRedistribution");
				log.InfoFormat("RedistributeLicencesForSpecificRole: {0}", redistributeLicencesForSpecificRole);
				log.InfoFormat("RedistributeManuallyAssignedLicences: {0}", redistributeManuallyAssignedLicences);
				log.InfoFormat("RoleId: {0}", roleId);
			}
			
			public virtual string GetJobName() {
				var roleId = Get<Guid>("RoleId");
				return roleId.ToString();
			}
			
			public virtual string GetJobGroupName() {
				return "RedistributeLicenses";
			}
			
			public virtual string GetProcessName() {
				return "RedistributeLicenses";
			}
			
			public virtual Dictionary<string, object> GetParameters(bool redistributeLicencesForSpecificRole,
				bool redistributeManuallyAssignedLicences, Guid roleId) {
				return new Dictionary<string, object> {
					{ "RedistributeLicencesForSpecificRole", redistributeLicencesForSpecificRole },
					{ "RedistributeManuallyAssignedLicences", redistributeManuallyAssignedLicences },
					{ "RoleId", roleId }
				};
			}
			
			public virtual void ScheduleJob(string jobName, string jobGroupName, string processName,
				Dictionary<string, object> parameters, DateTime startTime) {
				if (AppScheduler.DoesJobExist(jobName, jobGroupName)) {
					AppScheduler.RemoveJob(jobName, jobGroupName);
				}
				IJobDetail job = AppScheduler.CreateProcessJob(jobName, jobGroupName, processName,
					UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, parameters);
				SimpleTriggerImpl trigger = new SimpleTriggerImpl(jobName, jobGroupName, startTime, null, 0, TimeSpan.Zero);
				AppScheduler.Instance.ScheduleJob(job, trigger);
			}

		#endregion

	}

	#endregion

}

