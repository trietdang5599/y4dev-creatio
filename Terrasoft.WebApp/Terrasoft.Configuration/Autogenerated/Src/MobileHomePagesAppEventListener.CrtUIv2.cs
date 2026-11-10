namespace Terrasoft.Configuration.MobileHomePagesAppEventListener
{
	using Terrasoft.Common;
	using Terrasoft.Configuration.MobileHomePageUtilities;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: MobileHomePagesAppEventListener

	public class MobileHomePagesAppEventListener : AppEventListenerBase
	{

		#region Fields: Private

		private AppEventContext _appEventContext;

		#endregion

		#region Properties: Private

		private UserConnection _userConnection;
		private UserConnection UserConnection => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);

		private AppConnection _appConnection;
		private AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					_appEventContext.CheckArgumentNull("AppEventContext");
					_appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
		}

		private IMobileHomePageUtilities _mobileHomePageUtilities;
		private IMobileHomePageUtilities MobileHomePageUtilities =>
			_mobileHomePageUtilities ?? (_mobileHomePageUtilities = ClassFactory.Get<IMobileHomePageUtilities>(
				new ConstructorArgument("userConnection", UserConnection))
		);

		#endregion

		#region Methods: Private

		private void OnClientUnitSchemaChanged(object sender, SchemaManagerItemAfterSaveEventArgs eventArgs) {
			var managerItem = eventArgs.Item as ISchemaManagerItem<ClientUnitSchema>;
			if (MobileHomePageUtilities.GetIsMobileHomePageSchema(managerItem)) {
				MobileHomePageUtilities.UpdateMobileHomePage(managerItem);
			}
		}

		private void OnClientUnitSchemaRemoved(object sender, SchemaManagerItemAfterRemoveEventArgs eventArgs) {
			var managerItem = eventArgs.Item as ISchemaManagerItem<ClientUnitSchema>;
			if (MobileHomePageUtilities.GetIsMobileHomePageSchema(managerItem)) {
				MobileHomePageUtilities.DeleteMobileHomePage(managerItem);
			}
		}

		private void SubscribeOnManagerEvents() {
			UserConnection.ClientUnitSchemaManager.ItemSaved += OnClientUnitSchemaChanged;
			UserConnection.ClientUnitSchemaManager.ItemRemoved += OnClientUnitSchemaRemoved;
		}

		private void UnsubscribeOnManagerEvents() {
			UserConnection.ClientUnitSchemaManager.ItemSaved -= OnClientUnitSchemaChanged;
			UserConnection.ClientUnitSchemaManager.ItemRemoved -= OnClientUnitSchemaRemoved;
		}

		#endregion

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			_appEventContext = context;
			MobileHomePageUtilities.SyncMobileHomePages();
			SubscribeOnManagerEvents();
		}

		public override void OnAppEnd(AppEventContext context) {
			_appEventContext = context;
			UnsubscribeOnManagerEvents();
		}

		#endregion

	}

	#endregion
}

