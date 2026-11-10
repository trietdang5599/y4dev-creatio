namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Text;
	using global::Common.Logging;
	using Terrasoft.Configuration.OAuth20;
	using Terrasoft.Core.Factories;
	using Terrasoft.OAuthIntegration.HealthCheck;
	using Terrasoft.Core.Process;

	#region Class: OAuthResourceMaintenanceUserTask

	/// <exclude/>
	public partial class OAuthResourceMaintenanceUserTask
	{

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("OAuth20");

		#endregion

		#region Methods: Private

		private static bool NeedRegisterOAuthResource(OAuthHealthCheckStatus status) {
			return status.HasProblem && status.IsSystemSettingsFilledIn
				&& status.IsIdentityServiceAvailable && status.IsAccessTokenRetrievableForSystemActions 
				&& !status.IsDefaultResourceRegistered;
		}

		private void RegisterOAuthResource() {
			var healthCheckService = ClassFactory.Get<IOAuthHealthCheckService>();
			OAuthHealthCheckStatus status = healthCheckService.GetHealthStatus();
			LogOAuthHealthCheckStatus(status);
			if (!NeedRegisterOAuthResource(status)) {
				return;
			}
			var service = new OAuthConfigService(UserConnection);
			AddResourceResponse result = service.AddDefaultResource();
			ValidateResult(result);
		}

		private void LogOAuthHealthCheckStatus(OAuthHealthCheckStatus status) {
			if (status.HasProblem) {
				_log.Info($"OAuth HealthCheck status is: {status.Message}");
			} else {
				_log.Debug($"OAuth HealthCheck status is: {status.Message}");
			}
		}

		private void ValidateResult(AddResourceResponse result) {
			if (result.Success) {
				return;
			}
			var errorMessage = new StringBuilder();
			errorMessage.AppendLine(result.ResponseStatus.ErrorCode);
			errorMessage.AppendLine(result.ResponseStatus.Message);
			errorMessage.AppendLine(result.ResponseStatus.StackTrace);
			_log.Error(errorMessage.ToString());
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			try {
				RegisterOAuthResource();
				ExecutionStatus = true;
			} catch (Exception ex) {
				_log.Error(ex);
				ExecutionStatus = false;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override string GetExecutionData() {
			return string.Empty;
		}

		#endregion

	}

	#endregion

}