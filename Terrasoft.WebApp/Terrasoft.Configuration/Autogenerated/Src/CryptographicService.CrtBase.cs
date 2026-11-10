namespace Terrasoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Web.Common;
	using Terrasoft.Core.Encryption;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CryptographicService : BaseService {
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

		/// <summary>
		/// ############# ######## ###### ## ######### DES.
		/// </summary>
		/// <param name="password">###### ### ##########.</param>
		/// <returns>######, ############## ############### ######.</returns>
		public string GetConvertedPasswordValue(string password) {
			if (string.IsNullOrEmpty(password)) {
				return string.Empty;
			}
			var provider = CryptoProviderFactory.GetEncryptProvider();
			var result = provider.Encrypt(password);
			return result;
		}
	}
}

