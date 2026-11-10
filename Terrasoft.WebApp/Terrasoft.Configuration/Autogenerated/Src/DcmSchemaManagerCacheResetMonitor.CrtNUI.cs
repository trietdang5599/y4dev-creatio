namespace Terrasoft.Configuration.DcmSchemaManagerCacheResetMonitor
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.Factories;

	#region Class: DcmSchemaManagerCacheResetMonitor

	[DefaultBinding(typeof(IConfSchemaManagerChangeItemMonitor), Name = "DcmSchemaManagerCacheResetMonitor")]
	public class DcmSchemaManagerCacheResetMonitor : IConfSchemaManagerChangeItemMonitor {

		#region Fields: Private

		private const string ManagerName = "DcmSchemaManager";
		private IClientCacheStore _clientCacheStore;

		#endregion

		#region Properties: Private

		private IClientCacheStore ClientCacheStore => _clientCacheStore
			?? (_clientCacheStore = ClassFactory.Get<IClientCacheStore>());

		#endregion

		#region Methods: Private

		private void UpdateCacheHash() {
			ClientCacheStore.SetHashValue(Constants.RuntimeSchemaCacheableHashCacheKey,
				Guid.NewGuid().ToString("N"));
		}

		#endregion

		#region Methods: Public

		public void OnChanged(string managerName, EventArgs eventArgs) {
			if (ManagerName == managerName) {
				UpdateCacheHash();
			}
		}

		public void OnRemoved(string managerName, EventArgs eventArgs) {
			if (ManagerName == managerName) {
				UpdateCacheHash();
			}
		}

		#endregion
	}

	#endregion

}
