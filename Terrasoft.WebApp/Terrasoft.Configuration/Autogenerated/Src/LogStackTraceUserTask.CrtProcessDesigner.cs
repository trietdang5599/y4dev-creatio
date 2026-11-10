namespace Terrasoft.Core.Process.Configuration
{
	using System.Diagnostics;
	using global::Common.Logging;
	using Terrasoft.Core.Process;

	#region Class: LogStackTraceUserTask

	/// <summary>
	/// Represents a user task that logs stack traces.
	/// </summary>
	public partial class LogStackTraceUserTask
	{

		#region Fields: Private

		private ILog _logger;

		#endregion

		#region Methods: Private

		private void SetupLogger() {
			_logger = LogManager.GetLogger("Process");
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			SetupLogger();
			string processName = context.Process.Name;
			var stackTrace = new StackTrace(false);
			string message = stackTrace.ToString();
			Sys_StackTrace = message;
			_logger.Warn($"[{processName}.{Name}]: " + message);
			return true;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc/>
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		/// <inheritdoc/>
		public override string GetExecutionData() {
			return string.Empty;
		}

		/// <inheritdoc/>
		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}
