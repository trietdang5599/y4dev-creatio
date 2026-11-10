namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;

	public class SysAdminUnitFeatures
	{
		public class ShowContactInAdminUnit : FeatureMetadata
		{

			#region Constructors: Public

			public ShowContactInAdminUnit() {
				IsEnabled = true;
				Description = "Enables display of contact selection on the user page";
			}

			#endregion

		}
	}
} 

