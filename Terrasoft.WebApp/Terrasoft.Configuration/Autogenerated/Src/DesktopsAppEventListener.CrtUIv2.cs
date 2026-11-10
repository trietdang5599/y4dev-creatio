 namespace Terrasoft.Configuration.DesktopAppEventListener
{
	using Terrasoft.Common;
	using Terrasoft.Configuration.DesktopUtilities;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: DesktopAppEventListener

	public class DesktopAppEventListener : AppEventListenerBase
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

		private IDesktopUtilities _desktopUtilities;
		private IDesktopUtilities DesktopUtilities =>
			_desktopUtilities ?? (_desktopUtilities = ClassFactory.Get<IDesktopUtilities>(
				new ConstructorArgument("userConnection", UserConnection))
		);

		#endregion

		#region Methods: Private

		private void OnClientUnitSchemaChanged(object sender, SchemaManagerItemAfterSaveEventArgs eventArgs) {
			var managerItem = eventArgs.Item as ISchemaManagerItem<ClientUnitSchema>;
			if (DesktopUtilities.GetIsDesktopSchema(managerItem)) {
				DesktopUtilities.UpdateDesktop(managerItem);
			}
		}

		private void OnClientUnitSchemaRemoved(object sender, SchemaManagerItemAfterRemoveEventArgs eventArgs) {
			var managerItem = eventArgs.Item as ISchemaManagerItem<ClientUnitSchema>;
			if (DesktopUtilities.GetIsDesktopSchema(managerItem)) {
				DesktopUtilities.DeleteDesktop(managerItem);
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

		/// <summary>
		/// Application start handler.
		/// </summary>
		/// <param name="context">Application context.</param>
		public override void OnAppStart(AppEventContext context) {
			_appEventContext = context;
			DesktopUtilities.SyncDesktops();
			SubscribeOnManagerEvents();
		}

		/// <summary>
		/// Application end handler.
		/// </summary>
		/// <param name="context">Application context.</param>
		public override void OnAppEnd(AppEventContext context) {
			_appEventContext = context;
			UnsubscribeOnManagerEvents();
		}

		#endregion

	}

	#endregion

}

