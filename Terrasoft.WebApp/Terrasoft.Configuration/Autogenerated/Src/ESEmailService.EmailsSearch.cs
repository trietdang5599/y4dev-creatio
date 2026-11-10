namespace Terrasoft.Configuration.EmailsSearch
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Core.Factories;

	#region Class: ESEmailService

	///<summary>Represent class for deduplication service.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ESEmailService
	{

		#region Constants: Private

		private readonly ILog _log = LogManager.GetLogger("EmailsSearch");

		#endregion

		#region Properties: Protected

		private IESEmailManager _esEmailManager;
		protected IESEmailManager ESEmailManager {
			get {
				if (_esEmailManager == null) {
					_esEmailManager = ClassFactory.Get<IESEmailManager>();
				}
				return _esEmailManager;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Web-method provide result of search for similar records.
		/// </summary>
		/// <param name="request">Request data.</param>
		/// <returns>Results record found on request.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SearchEmails(List<string> request) {
			try {
				var emails = ESEmailManager.SearchEmails(request);
				var result = JsonConvert.SerializeObject(emails);
				return result;
			} catch (Exception exp) {
				_log.Error(string.Format("{0}\r\n{1}", exp.Message, exp.StackTrace));
				throw;
			}
		}

		/// <summary>
		/// Web-method provide result of search for similar records.
		/// </summary>
		/// <param name="query">Request data.</param>
		/// <param name="rowCount">Rows to search number.</param>
		/// <param name="rowsOffset">Rows to skip number.</param>
		/// <returns>Results record found on request.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "SearchEmailsResult")]
		public string SearchEmailsPage(List<string> query, int rowCount, int rowsOffset) {
			try {
				var emails = ESEmailManager.SearchEmails(query, rowCount, rowsOffset);
				var result = JsonConvert.SerializeObject(emails);
				return result;
			} catch (Exception exp) {
				_log.Error(string.Format("{0}\r\n{1}", exp.Message, exp.StackTrace));
				throw;
			}
		}

		#endregion

	}

	#endregion

}
