namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GeneratedWebFormService;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: LeadSourceHelper

	/// <summary>
	/// Helps to define source and channel.
	/// </summary>
	[DefaultBinding(typeof(ITouchSourceProps))]
	[DefaultBinding(typeof(ITouchSource))]
	public class LeadSourceHelper : ITouchSource, ITouchSourceProps
	{

        #region Constructors: Public

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadSourceHelper"/> class.
        /// </summary>
        /// <param name="userConnection">The user connection.</param>
        /// <param name="pageUrl">The BPM href.</param>
        /// <param name="referrerUrl">The BPM reference.</param>
        public LeadSourceHelper(UserConnection userConnection, string pageUrl, string referrerUrl) {
			UserConnection = userConnection;
			_pageUrl = pageUrl;
			_referrerUrl = referrerUrl;
			InitBpmHrefParameters();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadSourceHelper"/> class.
        /// </summary>
        /// <param name="userConnection">The user connection.</param>
        public LeadSourceHelper(UserConnection userConnection) {
			UserConnection = userConnection;
			InitBpmHrefParameters();
		}

		#endregion

		#region Properties: Private

		private string _pageUrl;
		private string _referrerUrl;

		private EntityCollection _leadMedium = null;

		private EntityCollection LeadMedium {
			get {
				if (_leadMedium != null) {
					return _leadMedium;
				}
				_leadMedium = GetEntityCollection("LeadMedium");
				return _leadMedium;
			}
		}

		private EntityCollection _leadMediumCode = null;

		private EntityCollection LeadMediumCode {
			get {
				if (_leadMediumCode != null) {
					return _leadMediumCode;
				}
				_leadMediumCode = GetEntityCollection("LeadMediumCode");
				return _leadMediumCode;
			}
		}

		private EntityCollection _leadSource = null;

		private EntityCollection LeadSource {
			get {
				if (_leadSource != null) {
					return _leadSource;
				}
				_leadSource = GetEntityCollection("LeadSource");
				return _leadSource;
			}
		}

		private EntityCollection _leadSourceCode = null;

		private EntityCollection LeadSourceCode {
			get {
				if (_leadSourceCode != null) {
					return _leadSourceCode;
				}
				_leadSourceCode = GetEntityCollection("LeadSourceCode");
				return _leadSourceCode;
			}
		}

		private EntityCollection _leadSourceUrl = null;

		private EntityCollection LeadSourceUrl {
			get {
				if (_leadSourceUrl != null) {
					return _leadSourceUrl;
				}
				_leadSourceUrl = GetEntityCollection("LeadSourceUrl");
				return _leadSourceUrl;
			}
		}

		private NameValueCollection bpmHrefParameters = null;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Referrer url parameters.
		/// </summary>
		public NameValueCollection BpmHrefParameters {
			get => bpmHrefParameters;
			private set => bpmHrefParameters = value;
		}

		/// <summary>
		/// Channel unique identifier.
		/// </summary>
		public Guid ResultLeadMediumId { get; private set; }

		/// <summary>
		/// Source unique identifier.
		/// </summary>
		public Guid ResultLeadSourceId { get; private set; }

		#endregion

		#region Methods: Private

		private void InitBpmHrefParameters() {
			string query = Uri.TryCreate(_pageUrl, UriKind.Absolute, out Uri uri) 
				? uri.Query 
				: string.Empty;
			bpmHrefParameters = HttpUtility.ParseQueryString(query);
		}

		private EntityCollection GetEntityCollection(string entityname) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entityname);
			esq.AddAllSchemaColumns();
			return esq.GetEntityCollection(UserConnection);
		}

		private void GetMediumSourceByUtm() {
			string utmMediumValue = bpmHrefParameters["utm_medium"];
			string utmSourceValue = bpmHrefParameters["utm_source"];
			string utmCampaignValue = bpmHrefParameters["utm_campaign"];
			GetMediumSourceByUtm(utmMediumValue, utmSourceValue, utmCampaignValue);
		}

		private void GetMediumSourceByUtm(string utmMedium, string utmSource, string utmCampaign) {
			Guid leadMediumId = Guid.Empty;
			Guid leadSourceId = Guid.Empty;
			if (!string.IsNullOrWhiteSpace(utmMedium)) {
				var leadMediumEntity = LeadMediumCode.Find("Code", utmMedium);
				if (leadMediumEntity != null) {
					leadMediumId = leadMediumEntity.GetTypedColumnValue<Guid>("LeadMediumId");
				}
			}
			if (!string.IsNullOrWhiteSpace(utmSource) || !string.IsNullOrWhiteSpace(utmCampaign)) {
				var searchValue = !string.IsNullOrWhiteSpace(utmSource) ? utmSource : utmCampaign;
				var LeadSourceCodeEntity = LeadSourceCode.Find("Code", searchValue);
				if (LeadSourceCodeEntity != null) {
					leadSourceId = LeadSourceCodeEntity.GetTypedColumnValue<Guid>("LeadSourceId");
					if (leadMediumId == Guid.Empty) {
						var leadSourceEntity = LeadSource.Find("Id", leadSourceId);
						if (leadSourceEntity != null) {
							leadMediumId = leadSourceEntity.GetTypedColumnValue<Guid>("LeadMediumId");
						}
					}
				}
			}
			ResultLeadMediumId = leadMediumId;
			ResultLeadSourceId = leadSourceId;
		}

		private void GetMediumSourceBySearchAd() {
			string gclid = bpmHrefParameters["gclid"];
			if (!string.IsNullOrEmpty(gclid)) {
				ResultLeadMediumId = LeadMediumConsts.LeadMediumSearchAdId;
				ResultLeadSourceId = LeadSourceConsts.LeadSourceGoogleAdWordsId;
			}
		}

		private void GetMediumSourceByRef(string referrerUrl) {
			if (string.IsNullOrWhiteSpace(referrerUrl)) {
				return;
			}
			Entity leadSourceUrlEntity = null;
			Entity subDomainLeadSourceUrlEntity = null;
			Uri.TryCreate(referrerUrl, UriKind.Absolute, out var uri);
			if (uri != null) {
				referrerUrl = uri.Host;
			}
			foreach (Entity item in LeadSourceUrl) {
				string urlLookupValue = item.GetTypedColumnValue<string>("URL");
				string dotUrlLookupValue = string.Format(".{0}", urlLookupValue);
				if (referrerUrl.Equals(urlLookupValue, StringComparison.OrdinalIgnoreCase)) {
					leadSourceUrlEntity = item;
				}
				if (referrerUrl.EndsWith(dotUrlLookupValue, StringComparison.OrdinalIgnoreCase)) {
					subDomainLeadSourceUrlEntity = item;
				}
			}
			leadSourceUrlEntity = leadSourceUrlEntity ?? subDomainLeadSourceUrlEntity;
			if (leadSourceUrlEntity == null) {
				if (ResultLeadMediumId == Guid.Empty) {
					ResultLeadMediumId = LeadMediumConsts.LeadMediumReferrerTrafficId;
				}
				ResultLeadSourceId = LeadSourceConsts.LeadSourceOtherId;
				return;
			}
			ResultLeadSourceId = leadSourceUrlEntity.GetTypedColumnValue<Guid>("LeadSourceId");
			var leadSourceEntity = LeadSource.Find("Id", leadSourceUrlEntity.GetTypedColumnValue<Guid>("LeadSourceId"));
			if (leadSourceEntity != null) {
				ResultLeadSourceId = leadSourceEntity.GetTypedColumnValue<Guid>("Id");
				if (ResultLeadMediumId == Guid.Empty) {
					ResultLeadMediumId = leadSourceEntity.GetTypedColumnValue<Guid>("LeadMediumId");
				}
			}
		}

		private void GetMediumSourceByRef() {
			GetMediumSourceByRef(_referrerUrl);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns collection of parameters by form data specified.
		/// </summary>
		/// <param name="formData">The form data.</param>
		/// <returns><see cref="Dictionary{string, string}"/> of parameters.</returns>
		protected virtual Dictionary<string, string> GetParamsByFormData(FormData formData) {
			formData.CheckArgumentNull("formData");
			var bpmHref = formData.formFieldsData?.SingleOrDefault(x => x.name == "BpmHref")?.value ?? "";
			var bpmRef = formData.formFieldsData?.SingleOrDefault(x => x.name == "BpmRef")?.value ?? "";
			return new Dictionary<string, string> {
				{ "bpmRef", bpmRef },
				{ "bpmHref", bpmHref }
			};
		}

		/// <summary>
		/// Resets helper search state and clears result values to empty.
		/// </summary>
		protected void ClearResults() {
			ResultLeadMediumId = Guid.Empty;
			ResultLeadSourceId = Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines channel and source.
		/// </summary>
		public void ComputeMediumAndSource() {
			ClearResults();
			if (string.IsNullOrEmpty(_pageUrl) && string.IsNullOrEmpty(_referrerUrl)) {
				return;
			}
			GetMediumSourceByUtm();
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId != Guid.Empty) {
				return;
			}
			GetMediumSourceBySearchAd();
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId != Guid.Empty) {
				return;
			}
			if (ResultLeadMediumId != Guid.Empty && ResultLeadSourceId == Guid.Empty) {
				ResultLeadSourceId = LeadSourceConsts.LeadSourceOtherId;
				return;
			}
			if (ResultLeadMediumId == Guid.Empty && ResultLeadSourceId == Guid.Empty && string.IsNullOrEmpty(_referrerUrl)) {
				ResultLeadMediumId = LeadMediumConsts.LeadMediumDirectTrafficId;
				return;
			}
			GetMediumSourceByRef();
		}

		/// <summary>
		/// Defines channel and source by parameters specified.
		/// </summary>
		/// <param name="parameters"><see cref="Dictionary{string, string}"/> of parameters available.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		public virtual (Guid Medium, Guid Source) ComputeMediumAndSource(Dictionary<string, string> parameters) {
			string bpmRef = string.Empty;
			string bpmHref;
			ClearResults();
			if (parameters.ContainsKey("bpmRef")) {
				bpmRef = parameters["bpmRef"];
				this._referrerUrl = bpmRef;
			}
			if (parameters.ContainsKey("bpmHref")) {
				bpmHref = parameters["bpmHref"];
				this._pageUrl = bpmHref;
				InitBpmHrefParameters();
				ComputeMediumAndSource();
				return (ResultLeadMediumId, ResultLeadSourceId);
			}
			var utmMedium = parameters.ContainsKey("utm_medium") ? parameters["utm_medium"] : string.Empty;
			var utmSource = parameters.ContainsKey("utm_source") ? parameters["utm_source"] : string.Empty;
			var utmCampaign = parameters.ContainsKey("utm_campaign") ? parameters["utm_campaign"] : string.Empty;
			GetMediumSourceByUtm(utmMedium, utmSource, utmCampaign);
			if (ResultLeadMediumId.IsNotEmpty() && ResultLeadSourceId.IsNotEmpty()) {
				return (ResultLeadMediumId, ResultLeadSourceId);
			}
			GetMediumSourceByRef(bpmRef);
			return (ResultLeadMediumId, ResultLeadSourceId);
		}

		/// <summary>
		/// Defines channel and source by form data specified.
		/// </summary>
		/// <param name="formData">Form data instance.</param>
		/// <returns>Tuple of result channel and source values.</returns>
		public virtual (Guid Medium, Guid Source) ComputeMediumAndSource(FormData formData) {
			var parameters = GetParamsByFormData(formData);
			return ComputeMediumAndSource(parameters);
		}

		#endregion
	}

	#endregion

}
