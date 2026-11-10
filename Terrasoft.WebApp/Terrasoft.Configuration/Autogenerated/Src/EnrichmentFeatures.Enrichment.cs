namespace Terrasoft.Configuration.Enrichment
{
	using Creatio.FeatureToggling;

	public class EnrichmentFeatures
	{
		public class UseOAuth : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Use OAuth authentication for accessing Enrichment service.
			/// </summary>
			public UseOAuth() {
				IsEnabled = true;
				Description = "Use OAuth authentication for Enrichment service";
			}

			#endregion

		}

	}
} 

