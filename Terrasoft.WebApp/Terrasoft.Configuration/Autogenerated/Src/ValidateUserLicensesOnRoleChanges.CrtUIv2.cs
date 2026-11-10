namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;

	#region Class: ValidateUserLicensesOnRoleChanges

	public class ValidateUserLicensesOnRoleChanges : FeatureMetadata
	{
		public ValidateUserLicensesOnRoleChanges() {
			IsEnabled = true;
			Description = "Validate user licenses on role changes";
		}
	}

	#endregion

}
