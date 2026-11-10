namespace Terrasoft.Configuration.GlobalSearch
{
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Scheduler;

	#region Class: LogstashConfigsJob

	public class LogstashConfigsJob : IJobExecutor
	{

		#region Fields: Private

		/// <summary>
		/// Log manager.
		/// </summary>
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Method: Public

		/// <summary>
		/// Returns instance of the config indexing sender.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>Instance of the of the config indexing sender.</returns>
		public virtual IndexingConfigSender GetIndexingConfigSender(UserConnection userConnection) {
			return ClassFactory.Get<IndexingConfigSender>(new ConstructorArgument("userConnection", userConnection));
		}

		/// <summary>
		/// Sends indexing configs.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="parameters">Execution parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_log.Info("Global search config job started");
			var isEnabled = userConnection.GetIsFeatureEnabled("GlobalSearch_V2");
			_log.InfoFormat("GlobalSearch_V2 feature is {0}", isEnabled);
			if (isEnabled) {
				var indexingConfigSender = GetIndexingConfigSender(userConnection);
				indexingConfigSender.Send();
			}
		}

		#endregion
	}

	#endregion
}


