namespace Terrasoft.Configuration.SearchFilterQuery
{
	using System;
	using Terrasoft.Configuration;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using System.Collections.Generic;
	using System.Web.SessionState;

	#region Class: SearchFilterQueryAnalyzerService

	/// <summary>
	/// Service for analyze difficulty query for current user.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SearchFilterQueryAnalyzerService: BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private ISearchFilterQueryAnalyzer _searchFilterQueryAnalyzer;

		#endregion

		#region Constructors: Public

		public SearchFilterQueryAnalyzerService() : base() { }

		public SearchFilterQueryAnalyzerService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Properties: Private

		private ISearchFilterQueryAnalyzer SearchFilterQueryAnalyzer =>
			_searchFilterQueryAnalyzer ?? (_searchFilterQueryAnalyzer = ClassFactory.Get<ISearchFilterQueryAnalyzer>(
					new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns true if query with current params is difficult for current user.
		/// </summary>
		/// <param name="schemaName">Entity schema name.</param>
		/// <param name="columns">Columns array.</param>
		/// <returns>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public SearchFilterQueryAnalyzerServiceResponse Analyze(string schemaName, IEnumerable<string> columns) {
			try {
				bool result = SearchFilterQueryAnalyzer.GetIsNeedOptimization(schemaName, columns);
				return new SearchFilterQueryAnalyzerServiceResponse(result);
			} catch (Exception e) {
				return new SearchFilterQueryAnalyzerServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: SearchFilterQueryAnalyzerServiceResponse

	/// <summary>
	/// Class of response query analyzer service.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ConfigurationServiceResponse" />
	[DataContract]
	public class SearchFilterQueryAnalyzerServiceResponse: ConfigurationServiceResponse
	{

		#region Constructors: Public

		public SearchFilterQueryAnalyzerServiceResponse() : base() { }

		public SearchFilterQueryAnalyzerServiceResponse(Exception e) : base(e) {
			this.IsNeedOptimization = true;
		}

		public SearchFilterQueryAnalyzerServiceResponse(bool result) : base() {
			this.IsNeedOptimization = result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets if need optimization query parameters.
		/// </summary>
		[DataMember(Name = "isNeedOptimization")]
		public bool IsNeedOptimization {
			get; private set;
		}

		#endregion

	}

	#endregion
}
