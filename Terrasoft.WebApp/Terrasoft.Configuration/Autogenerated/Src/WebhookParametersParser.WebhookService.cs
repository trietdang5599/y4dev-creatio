namespace Terrasoft.Configuration
{
	using System.Collections.Specialized;
	using System.IO;
	using System.Text;
	using System.Web;
	using Terrasoft.Common;
	using Terrasoft.Web.Http.Abstractions;
	using HttpRequest = Terrasoft.Web.Http.Abstractions.HttpRequest;

	/// <summary>
	/// Parser for webhook body
	/// </summary>
	public class WebhookParametersParser
	{

		#region Methods: Public

		/// <summary>
		/// Parse webhook parameters
		/// </summary>
		/// <param name="stream">webhook body as stream</param>
		/// <param name="request">webhook body as FormCollection from http  context</param>
		/// <returns>Parameters collection</returns>
		public NameValueCollection ParseWebhookParameters(Stream stream, HttpRequest request) {
#if NETFRAMEWORK
			return ParseQueryParameters(stream);
#else
			return ParseRequestParametersFromForm(request.Form);
#endif
		}

		/// <summary>
		/// Parse webhook parameters (.Net Core) 
		/// </summary>
		/// <param name="request">webhook body as FormCollection from http  context</param>
		/// <returns>Parameters collection</returns>
		public NameValueCollection ParseRequestParametersFromForm(FormCollection form) {
			var nameValueCollection = new NameValueCollection();
			nameValueCollection.Add("data", form["data"]);
			nameValueCollection.Add("ApiKey", form["ApiKey"]);
			nameValueCollection.Add("ContentType", form["ContentType"]);
			nameValueCollection.Add("Headers", form["Headers"]);
			nameValueCollection.Add("QueryParameters", form["QueryParameters"]);
			nameValueCollection.Add("SourceUrl", form["SourceUrl"]);
			nameValueCollection.Add("WebhookSource", form["WebhookSource"]);
			return nameValueCollection;
		}

		/// <summary>
		/// Parse webhook parameters (.Net Framework)
		/// </summary>
		/// <param name="stream">webhook body as stream</param>
		/// <returns>Parameters collection</returns>
		public NameValueCollection ParseQueryParameters(Stream stream) {
			var content = stream.GetContent();
			var queryParameters = HttpUtility.ParseQueryString(content, Encoding.UTF8);
			return queryParameters;
		}

		#endregion

	}
}

