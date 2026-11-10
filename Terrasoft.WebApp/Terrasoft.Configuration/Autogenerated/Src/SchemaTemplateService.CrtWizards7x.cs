namespace Terrasoft.Configuration.InterfaceDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Core.ServiceModelContract.Designers;
	using Terrasoft.Web.Common;
	using Terrasoft.Nui.ServiceModel.Extensions;

	#region Class: SchemaTemplateService

	/// <summary>
	/// Provides methods schema templates.
	/// </summary>
	[ServiceContract(Name = "schema.template.api")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SchemaTemplateService : BaseService
	{
		#region Constants: Private

		private static readonly Guid _baseSidebarTemplateUId = new Guid("b11e72c4-3787-407e-9415-9d499413d5b8");
		private static readonly Guid _listPageV2TemplateUId = new Guid("3334b6c0-c8ab-4b59-a367-0c9182102552");
		private static readonly Guid _listPageV3TemplateUId = new Guid("b7b898d0-8c77-4953-c097-23fa6800da02");
		private static readonly Guid _blankMobileTemplateUId = new Guid("478ab83b-527b-4830-b2b8-2206bb9bf283");
		private static readonly Guid _mobileListTemplateUId = new Guid("011e7dda-a763-4535-9b9a-e09eddd047be");
		private static readonly Guid _mobilePageTemplateUId = new Guid("a6a776d7-4415-4726-bf63-a1f19edef6e7");
		private static readonly Guid _mobilePageWithTabsTemplateUId = new Guid("019c694a-1a3b-4812-b2e5-219b326061ae");

		// Dictionary: SysSchema.UId, SysImage.Id
		//Also don't forget to update the icons here ApplicationPageQueryExecutor
		private static readonly Dictionary<Guid, Guid> _schemaTemplatesInfo = new Dictionary<Guid, Guid> {
			{new Guid("7ed23be6-71df-4ad3-b56a-caa77b9881ce"), new Guid("b61606bf-c802-1e81-ea59-842e9be3f452")}, // PageWithTabsAndProgressBarTemplate (Tabbed Page with Progress Bar)
			{new Guid("3b2e117f-8c6b-4ca5-80a2-7ebb497cddf9"), new Guid("bb9cbd6d-3b98-4002-a41f-7b70fc9762e5")}, // PageWithTabsTemplate (Tabbed page with left area)
			{new Guid("5f8dd430-acf2-4e1a-80c8-77cf57e245ce"), new Guid("bdb1be8f-c4e3-41e0-a44b-bd8947a08b7c")}, // PageWithRightAreaAndTabsTemplate (Tabbed page with right area)
			{new Guid("27e1b215-163a-4b82-b0a6-9872a8dde6e4"), new Guid("78b0d4c5-891d-49a3-a364-0afc10f2a93a")}, // PageWithTopAreaAndTabsTemplate (Tabbed page with area on top)
			{new Guid("ecdcc8ff-272c-4957-9381-7d74ce17e140"), new Guid("461bc8f5-b353-3632-9c0d-c5f1bae967ac")}, // BaseMiniPageTemplate (Mini page)
			{new Guid("97e48060-149c-408f-9f17-8ba82c400249"), new Guid("4839a18f-637a-4189-be5c-85f20a65cfe9")}, // PageWithAreaFreedomTemplate (Grid page)
			{new Guid("0c5cfb7a-1ed9-41b8-905e-9a38c6915550"), new Guid("318d1004-01dc-4bfa-912d-6cf85f73535b")}, // BaseHomePage (Dashboards)
			{_baseSidebarTemplateUId, new Guid("f2770b0b-adaf-4e34-89dd-d3abd50e4bbc")}, // BaseSidebarTemplate (Sidebar page)
			{_listPageV2TemplateUId, new Guid("54590275-d5f0-401e-9e33-d2fbbc496100")}, // ListPageV2Template (List page)
			{_listPageV3TemplateUId, new Guid("54590275-d5f0-401e-9e33-d2fbbc496100")}, // ListPageV3Template (List page)
			{new Guid("f691e828-0b36-42a7-898f-c337e9af67d0"), new Guid("f9813cc3-2843-4819-982b-61c9f9ec1da9")}, // BlankPageTemplate (Blank page)
			{_mobilePageWithTabsTemplateUId, new Guid("2a89050a-cb76-4ec1-8e58-6c3e2a349cb5")}, // MobilePageWithTabsFreedomTemplate (Tabbed record page mobile)
			{_mobilePageTemplateUId, new Guid("7eec4a70-4111-19a9-e353-626c779a41df")}, // BaseMobilePageTemplate (Mobile record page)
			{_mobileListTemplateUId, new Guid("66facfc5-cbca-4106-a7af-956984964db7")}, // BaseMobileListTemplate (List page mobile)
			{_blankMobileTemplateUId, new Guid("d09bfa76-b8bd-4266-96df-f634693b9648")}, // BlankMobilePageTemplate (Blank mobile page)
		};

		#endregion

		#region Methods: Private

		private Dictionary<Guid, Guid> GetSchemaTemplatesInfo() {
			bool showSidebar = UserConnection.GetIsFeatureEnabled("ShowSidebarTemplate");
			bool useListPageV3 = UserConnection.GetIsFeatureEnabled("UseListPageV3Template") &&
				UserConnection.GetIsFeatureEnabled("FreedomUIDashboardsEnabled");
			bool useMobilePageDesigner = UserConnection.GetIsFeatureEnabled("UseMobilePageDesigner");
			return _schemaTemplatesInfo
				.Where(t =>
					(t.Key != _baseSidebarTemplateUId || showSidebar) &&
					(t.Key != _listPageV2TemplateUId || !useListPageV3) &&
					(t.Key != _listPageV3TemplateUId || useListPageV3) &&
					(useMobilePageDesigner || (t.Key != _blankMobileTemplateUId && t.Key != _mobileListTemplateUId && t.Key != _mobilePageTemplateUId && t.Key != _mobilePageWithTabsTemplateUId))
				)
				.ToDictionary(x => x.Key, x => x.Value);
		}

		private TemplateSchema ConvertToParentItemDto(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			return new TemplateSchema {
				UId = managerItem.UId,
				Name = managerItem.Name,
				Title = managerItem.Caption,
				GroupName = managerItem.GetGroupName(),
				ImageId = GetSchemaTemplatesInfo()[managerItem.UId],
			};
		}

		private IEnumerable<ISchemaManagerItem<ClientUnitSchema>> GetSchemaTemplates() {
			return GetSchemaTemplatesInfo().Select((info) => GetManagerItem(info.Key)).Where(item => item != null).ToArray();
		}

		private ClientUnitSchemaType GetSchemaType(ISchemaManagerItem<ClientUnitSchema> schema) {
			var schemaExtraProperties = schema.ExtraProperties;
			ClientUnitSchemaType schemaType;
			if (schemaExtraProperties?.Count == 0) {
				schemaType = schema.Instance.SchemaType;
			} else {
				ExtraProperty schemaTypeExtraProperty = schemaExtraProperties?.GetByName("SchemaType");
				if (!Enum.TryParse(schemaTypeExtraProperty?.Value?.ToString(),
					out ClientUnitSchemaType extraPropertySchemaType)) {
					if (schema.Instance != null) {
						extraPropertySchemaType = schema.Instance.SchemaType;
					}
				}
				schemaType = extraPropertySchemaType;
			}
			return schemaType;
		}

		private ISchemaManagerItem<ClientUnitSchema> GetManagerItem(Guid UId) {
			return UserConnection.ClientUnitSchemaManager.FindItemByUId(UId);
		}

		private IEnumerable<TemplateSchema> GetTemplateSchemas(ClientUnitSchemaType schemaType) {
			var templates = GetSchemaTemplates();
			if (schemaType != ClientUnitSchemaType.None) {
				templates = templates.Where(item => GetSchemaType(item) == schemaType);
			}
			return templates
				.Select(ConvertToParentItemDto)
				.Distinct()
				.ToArray();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/templates", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public TemplatesResponse GetTemplates() {
			return GetTemplatesBySchemaType();
		}

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/templates?schemaType={schemaType}", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public TemplatesResponse GetTemplatesBySchemaType(ClientUnitSchemaType schemaType = ClientUnitSchemaType.None) {
			var response = new TemplatesResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				response.Items = GetTemplateSchemas(schemaType);
				return response;
			} catch (SecurityException exception) {
				var exceptionResponse = new TemplatesResponse(exception);
				throw new WebFaultException<TemplatesResponse>(exceptionResponse, HttpStatusCode.Forbidden);
			} catch (Exception exception) {
				var exceptionResponse = new TemplatesResponse(exception);
				throw new WebFaultException<TemplatesResponse>(exceptionResponse, HttpStatusCode.InternalServerError);
			}
		}

		#endregion

	}

	#endregion

	#region Classes

	[DataContract]
	public class TemplateSchema : ParentItemDto
	{

		#region Properties: Public

		[DataMember(Name = "groupName")]
		public string GroupName { get; set; }

		[DataMember(Name = "imageId")]
		public Guid ImageId { get; set; }

		#endregion

	}

	[DataContract]
	public class TemplatesResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public TemplatesResponse() { }

		public TemplatesResponse(Exception e)
			: base(e) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "items")]
		public IEnumerable<TemplateSchema> Items { get; set; }

		#endregion

	}

	#endregion

}

