namespace Terrasoft.Configuration.Url
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Http.Abstractions;

	/// <summary>
	/// Represents navigation service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class NavigationService : BaseService
	{


		#region Properties: Private

		private IHttpContextAccessor _httpContextAccessor;

		private IHttpContextAccessor ServiceHttpContextAccessor => _httpContextAccessor ??
			(_httpContextAccessor = ClassFactory.Get<IHttpContextAccessor>());

		private IOpenLinkUrlGenerator _openLinkUrlGenerator;

		private IOpenLinkUrlGenerator OpenLinkUrlGenerator =>
			_openLinkUrlGenerator ?? (_openLinkUrlGenerator = ClassFactory.Get<IOpenLinkUrlGenerator>());

		private ILog _log;
		private ILog Log => _log ?? (_log = LogManager.GetLogger(typeof(NavigationService)));


		#endregion

		#region Properties: Public

		private HttpRequest _request;
		/// <summary>
		/// Returns <see cref="HttpRequest"/> instance.
		/// </summary>
		public HttpRequest Request {
			get => _request ?? (_request = HttpContext.Current.Request);
			set => _request = value;
		}

		#endregion

		#region Methods: Private

		private static void RedirectToUrl(HttpResponse response, string url) {
			response.Redirect(url, false);
		}

		private static void SetResponseHeader(HttpResponse response) {
			response.AddHeader("Connection", "close");
		}

		private static void SetRequestHeaders(HttpRequest request) {
			request.Headers["Redirect-Terrasoft"] = "true";
		}

		/// <summary>
		/// Creates <see cref="IUrlGenerator"/> implementation instance.
		/// </summary>
		/// <returns><see cref="IUrlGenerator"/> implementation instance.</returns>
		private IUrlGenerator GetUrlGenerator() {
			return ClassFactory.Get<IUrlGenerator>(new ConstructorArgument("uc", UserConnection));
		}

		/// <summary>
		/// Returns <see cref="HttpResponse"/> instance.
		/// </summary>
		/// <returns><see cref="HttpResponse"/> instance.</returns>
		private HttpResponse GetResponse() {
			return ServiceHttpContextAccessor.GetInstance().Response;
		}

		private string GenerateOpenLink(string schemaName, string recordIdValue) {
			Guid.TryParse(recordIdValue, out Guid recordId);
			try {
				return OpenLinkUrlGenerator.GetUrl(new OpenUrlConfig {
					SchemaName = schemaName,
					RecordId = recordId
				});
			} catch (Exception ex) {
				Log.Error(ex);
				IUrlGenerator urlGenerator = GetUrlGenerator();
				return urlGenerator.GetDefaultUrl();
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets navigation url.
		/// <param name="schemaName">Object schema name.</param>
		/// <param name="recordId">Object identifier.</param>
		/// </summary>
		/// <returns>Navigation url.</returns>
		protected string GetUrl(string schemaName, string recordId) {
			if (!UserConnection.GetIsFeatureEnabled("DisableProcessCrtNavigationModuleLink")) {
				return GenerateOpenLink(schemaName, recordId);
			}
			IUrlGenerator urlGenerator = GetUrlGenerator();
			string url = Guid.TryParse(recordId, out Guid id)
				? urlGenerator.GetUrl(schemaName, id)
				: urlGenerator.GetDefaultUrl();
			return url;
		}

		#endregion

		#region Constructors: Public

		public NavigationService(UserConnection userConnection) : base(userConnection) {
		}

		public NavigationService() : base() {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Redirects browser page to new url.
		/// </summary>
		/// <param name="schemaName">Object schema name.</param>
		/// <param name="recordId">Object identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Redirect?schemaName={schemaName}&recordId={recordId}",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void Redirect(string schemaName, string recordId) {
			SetRequestHeaders(Request);
			HttpResponse response = GetResponse();
			SetResponseHeader(response);
			string url = GetUrl(schemaName, recordId);
			RedirectToUrl(response, url);
		}

		#endregion

	}
}

