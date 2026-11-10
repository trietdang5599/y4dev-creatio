  namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;

	public class BulkEmailUX : FeatureMetadata
	{
		public BulkEmailUX() {
			IsEnabled = true;
			Description = "Enables the BulkEmail settings UX";
		}
	}
}
