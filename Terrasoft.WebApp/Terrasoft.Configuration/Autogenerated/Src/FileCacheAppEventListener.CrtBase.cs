namespace Terrasoft.Configuration.FileService
{
    using Terrasoft.Common;
    using Terrasoft.Configuration.FileCacheManager;
    using Terrasoft.Core;
    using Terrasoft.Core.Factories;
    using Terrasoft.Web.Common;

    #region Class: FileCacheAppEventListener

	/// <summary>
	///     File cache app event listener
	/// </summary>
	public class FileCacheAppEventListener : AppEventListenerBase
    {

        #region Fields: Private

        private AppConnection _appConnection;

        private AppEventContext _appEventContext;
        private UserConnection _userConnection;

        #endregion

        #region Properties: Private

        private UserConnection UserConnection {
            get => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
            set => _userConnection = value;
        }

        private AppConnection AppConnection {
            get {
                if (_appConnection == null) {
                    _appEventContext.CheckArgumentNull("AppEventContext");
                    _appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
                }
                return _appConnection;
            }
            set => _appConnection = value;
        }

        #endregion

        #region Methods: Public

		/// <summary>
		///     Application start handler.
		/// </summary>
		/// <param name="context">Application context.</param>
		public override void OnAppStart(AppEventContext context) {
            _appEventContext = context;
            if (UserConnection.GetIsFeatureEnabled("UseFileCache")) {
                IFileCacheManager instance = FileCacheManager.Create(UserConnection);
                ClassFactory.RebindWithFactoryMethod(() => instance);
            }
        }

        #endregion

    }

    #endregion

}

