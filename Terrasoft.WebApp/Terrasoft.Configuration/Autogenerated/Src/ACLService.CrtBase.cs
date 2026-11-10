 namespace Terrasoft.Configuration 
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Common;
	using Terrasoft.Core.DB;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using System.Collections.Generic;
	using System.Web.SessionState;
	using Terrasoft.Core.Store;

	#region Class: ACLService

	/// <summary>
	/// Provides web-service for work with ACL settings.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ACLService : BaseService, IReadOnlySessionState 
	{
		#region Consts: Public

		public static string CacheKey = "AccessControlWhitelist_Cache";

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns pages from white list.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "GetWhitelist", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetWhitelist() {
			var cache = UserConnection.ApplicationCache;
			var cachedList = cache.GetValue<List<string>>(CacheKey);
			if (cachedList != null) {
				return cachedList;
			}
			var select = new Select(UserConnection)
				.Column("ssi", "Name").As("Name")
				.From("AccessControlWhitelist", "acwl")
				.Join(JoinType.LeftOuter, "VwSysSchemaInfo").As("ssi")
					.On("ssi", "Id").IsEqual("acwl", "PageId")
				as Select;
			select.SpecifyNoLockHints();
			var list = select.ExecuteEnumerable(reader => reader.GetColumnValue<string>("Name"));
			cache.SetOrRemoveValue(CacheKey, list);
			return list;
		}

		#endregion

	}

	#endregion

}
