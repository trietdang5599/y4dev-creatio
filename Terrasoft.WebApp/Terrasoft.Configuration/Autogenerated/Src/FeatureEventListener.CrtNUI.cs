 namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: FeatureEventListener

	[EntityEventListener(SchemaName = "Feature")]
	public class FeatureEventListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const string ViewModuleScriptOptimizationFeatureName = "UseGenerateViewModuleScriptOptimization";

		#endregion

		#region Methods: Private

		private void OnFeatureChanged(object source) {
			var featureEntity = (Entity)source;
			var featureName = featureEntity.GetTypedColumnValue<string>("Code");
			if (featureName == ViewModuleScriptOptimizationFeatureName) {
				ClearViewModelScriptCache(featureEntity.UserConnection);
			}
		}

		private void ClearViewModelScriptCache(UserConnection userConnection) {
			ConfigurationSectionHelper.ClearCache(userConnection);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			OnFeatureChanged(sender);
		}

		/// <inheritdoc />
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			OnFeatureChanged(sender);
		}

		/// <inheritdoc />
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			OnFeatureChanged(sender);
		}

		#endregion

	}

	#endregion

}

