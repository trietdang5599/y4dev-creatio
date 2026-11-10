namespace Terrasoft.Configuration.GlobalSearch
{
	using Creatio.FeatureToggling;

	#region Class: GlobalSearchFeatures

	public class GlobalSearchFeatures
	{

		#region Class: UseOAuth

		public class UseOAuth : FeatureMetadata
		{

			#region Constructors: Public

			public UseOAuth() {
				IsEnabled = true;
				Description = "Use OAuth authentication for Global Search service";
			}

			#endregion

		}

		#endregion

		#region Class: Highlight

		public class EnableHighlight : FeatureMetadata
		{

			#region Constructors: Public

			public EnableHighlight() {
				IsEnabled = true;
				Description = "Enable highlight in search results";
			}

			#endregion

		}

		#endregion

	}

	#endregion

}

