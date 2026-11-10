namespace Terrasoft.Configuration.OAuth20
{
    using Creatio.FeatureToggling;

    #region Class: OAuth20Integration

    internal class OAuth20Integration : FeatureMetadata
    {

        #region Constructors: Public

        public OAuth20Integration() {
            IsEnabled = true;
        }

        #endregion

    }

    #endregion

    #region Class: OAuthClientAppInstallStatus

    /// <summary>
    /// Gates the OAuthClientApp install/not-installed lifecycle (ENG-78572).
    /// OFF (default): today's behavior is preserved — every record is registered in the Identity
    /// Service on insert and the listener install guards have no observable effect.
    /// ON: records can be created in the "Not installed" state without any Identity Service call and
    /// later promoted via the documented Not installed -> Installed transition.
    /// </summary>
    internal class OAuthClientAppInstallStatus : FeatureMetadata
    {

        #region Constructors: Public

        public OAuthClientAppInstallStatus() {
            IsEnabled = true;
        }

        #endregion

    }

    #endregion

    #region Class: OAuthClientAppAllowCreateNotInstalled

    /// <summary>
    /// Widens <see cref="OAuthClientAppInstallStatus"/> (ENG-78572): allows creating integrations
    /// directly in the "Not installed" state from the UI / AddClient service.
    /// Has NO effect on its own — it only takes effect when <see cref="OAuthClientAppInstallStatus"/>
    /// is also enabled (it extends that feature, it cannot work without it).
    /// OFF (default): integrations are always created Installed; existing Not installed records can still
    /// be viewed and installed when <see cref="OAuthClientAppInstallStatus"/> is on.
    /// </summary>
    internal class OAuthClientAppAllowCreateNotInstalled : FeatureMetadata
    {

        #region Constructors: Public

        public OAuthClientAppAllowCreateNotInstalled() {
            IsEnabled = false;
        }

        #endregion

    }

    #endregion

}
