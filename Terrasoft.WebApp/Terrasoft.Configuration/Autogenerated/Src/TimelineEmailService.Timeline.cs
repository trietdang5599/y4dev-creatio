namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using System.Collections.Generic;
	using System.Runtime.Serialization;


	#region Class : TimelineQuote

	/// <summary>
	///Represents a Dto for TimelineQuote.
	/// </summary>
	[DataContract]
	public class TimelineQuote 
	{

		#region Properties: Public

		/// <summary>
		/// Content of Quote.
		/// </summary>
		[DataMember(Name = "content")]
		public string Content {
			get; set;
		}

		#endregion

	}

	/// <summary>
	///Represents a Dto for list of TimelineQuote.
	/// </summary>
	[DataContract]
	public class TimelineQuoteList : ConfigurationServiceResponse
	{

		/// <summary>
		/// List of quotes.
		/// </summary>
		[DataMember(Name = "timelineQuotes")]
		public List<TimelineQuote> TimelineQuotes {
			get; set;
		} = new List<TimelineQuote>();

		/// <summary>
		/// Is it the last quote from the given email.
		/// </summary>
		[DataMember(Name = "isLastQuote")]
		public bool IsLastQuote { get; set; } = false;
	}

	#endregion

	#region Class: TimelineEmailService

	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TimelineEmailService : BaseService
	{

		/// <summary>
		/// Loads given number of email quotes.
		/// </summary>
		/// <param name="emailId">Identifier of email.</param>
		/// <param name="quoteNumber">Number of quotes</param>
		/// <returns>List of quotes.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TimelineQuoteList GetQuotesList(Guid emailId, int quoteNumber) {
			var response = new TimelineQuoteList();
			try {
				response = new TimelineQuotationManager(UserConnection).GetQuotesList(emailId, quoteNumber);
			} catch (Exception ex) {
				response.Success = false;
				response.Exception = ex;
			}
			return response;
		}

	}

	#endregion

}

