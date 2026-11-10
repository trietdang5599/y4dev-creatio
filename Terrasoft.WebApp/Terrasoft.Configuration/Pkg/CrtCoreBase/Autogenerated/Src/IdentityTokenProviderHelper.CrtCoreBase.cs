 namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.OAuthIntegration;

	public static class IdentityTokenProviderHelper
	{
		public static IIdentityTokenProvider GetInstance() {
			var accessor = ClassFactory.Get<IIdentityProviderAccessor>();
			return accessor.GetTokenProvider(new IdentityProviderResolutionRequest() );
		}

		public static IIdentityTokenProvider GetInstance(string serviceCode) {
			var accessor = ClassFactory.Get<IIdentityProviderAccessor>();
			return accessor.GetTokenProvider(new IdentityProviderResolutionRequest {
						ServiceCode = serviceCode
					});
		}

		public static IIdentityTokenProvider GetInstanceByName(string identityProviderName) {
			var accessor = ClassFactory.Get<IIdentityProviderAccessor>();
			return accessor.GetTokenProvider(new IdentityProviderResolutionRequest {
						ProviderName = identityProviderName
					});
		}
	}
}

