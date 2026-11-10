namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: OperatorTemplateUsageCleanupJob

	/// <summary>
	/// Scheduled job to cleanup old operator template usage records.
	/// </summary>
	public class OperatorTemplateUsageCleanupJob : IJobExecutor
	{
		#region Constants: Private

		private const string UsagePeriodSettingCode = "OperatorTemplateUsagePeriodDays";
		private const int DefaultUsagePeriodDays = 60;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes the cleanup job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Job parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			int periodDays = Core.Configuration.SysSettings.GetValue(
				userConnection, UsagePeriodSettingCode, DefaultUsagePeriodDays);
			
			var cutoffDate = DateTime.UtcNow.AddDays(-periodDays);
			
			var deleteQuery = new Delete(userConnection)
				.From("OperatorTemplateUsage")
				.Where("ModifiedOn").IsLess(Column.Parameter(cutoffDate));
			
			deleteQuery.Execute();
		}

		#endregion
	}

	#endregion
}

