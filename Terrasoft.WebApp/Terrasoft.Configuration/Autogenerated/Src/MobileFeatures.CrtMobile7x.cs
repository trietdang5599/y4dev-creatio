namespace Terrasoft.Configuration.Mobile
{
	using Creatio.FeatureToggling;

	public static class MobileFeatures
	{
		public class SyncAllEntitySchemas : FeatureMetadata
		{
			public SyncAllEntitySchemas() {
				IsEnabled = true;
				Description = "Sync metadata for all entities. If disabled, only entities from the Mobile Manifest will be imported";
			}
		}
	}
}


