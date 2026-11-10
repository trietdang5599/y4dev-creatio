namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;

	public class DisplayUnprocessedWebhooks : FeatureMetadata
	{
		public DisplayUnprocessedWebhooks() {
			IsEnabled = true;
			Description = "Allows to display unprocessed webhooks in 'Webhooks' section.";
		}
	}
}
