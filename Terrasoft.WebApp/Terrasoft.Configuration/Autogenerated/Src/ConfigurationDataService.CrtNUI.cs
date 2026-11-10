namespace Terrasoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using System.Linq;
	using Terrasoft.Core.RelatedPages;
	using System.Web.SessionState;

	#region Class: PageActionsDto

	[DataContract]
	public class PageActionsDto
	{

		#region Constructors: Public

		public PageActionsDto() { }

		public PageActionsDto(PageActions pageActions) {
			Add = pageActions.Add;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "add")]
		public bool Add {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: PageStructureDto

	[DataContract]
	public class PageStructureDto
	{

		#region Constructors: Public

		public PageStructureDto() { }

		public PageStructureDto(PageStructure pageStructure) {
			CaptionLcz = pageStructure.CaptionLcz;
			Caption = pageStructure.Caption;
			Name = pageStructure.Name;
			TypeId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.UId);
			ModuleEditId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.ModuleEditId);
			CardSchemaName = pageStructure.CardSchema;
			CardSchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.CardSchemaUId);
			UId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.UId);
			CardSchemaType = pageStructure.ClientUnitSchemaType;
			HasAddMiniPage = pageStructure.HasAddMiniPage;
			MiniPageSchemaName = ConfigurationDataDtoUtils.GetTypedValue<string>(pageStructure.MiniPageSchema);
			MiniPageModes = ConfigurationDataDtoUtils.GetTypedValue<string>(pageStructure.MiniPageModes);
			SchemaGroup = ConfigurationDataDtoUtils.GetTypedValue<string>(pageStructure.SchemaGroup);
			Actions = new PageActionsDto(pageStructure.Actions);
			IsDefault = pageStructure.IsDefault;
			CardModuleName = pageStructure.CardModuleName;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "schemaGroup", EmitDefaultValue = false)]
		public string SchemaGroup { get; set; }

		[DataMember(Name = "captionLcz", EmitDefaultValue = false)]
		public string CaptionLcz { get; set; }

		[DataMember(Name = "cardSchemaName")]
		public string CardSchemaName { get; set; }

		[DataMember(Name = "cardModuleName", EmitDefaultValue = false)]
		public string CardModuleName { get; set; }

		[DataMember(Name = "cardSchemaUId")]
		public Guid CardSchemaUId { get; set; }
		
		[DataMember(Name = "UId")]
		public Guid UId { get; set; }

		[DataMember(Name = "cardSchemaType")]
		public ClientUnitSchemaType CardSchemaType { get; set; }

		[DataMember(Name = "hasAddMiniPage", EmitDefaultValue = false)]
		public bool HasAddMiniPage { get; set; }

		[DataMember(Name = "miniPageSchemaName", EmitDefaultValue = false)]
		public string MiniPageSchemaName { get; set; }

		[DataMember(Name = "miniPageModes", EmitDefaultValue = false)]
		public string MiniPageModes { get; set; }

		[DataMember(Name = "moduleEditId")]
		public Guid ModuleEditId { get; set; }

		[DataMember(Name = "typeId", EmitDefaultValue = false)]
		public Guid TypeId { get; set; }

		[DataMember(Name = "actions")]
		public PageActionsDto Actions { get; set; }

		[DataMember(Name = "isDefault")]
		public bool IsDefault { get; set; }

		#endregion

	}

	#endregion

	#region Class: ModuleStructureDto

	[DataContract]
	public class ModuleStructureDto
	{

		#region Constructors: Public

		public ModuleStructureDto() { }

		public ModuleStructureDto(ModuleStructure moduleStructure) {
			TypeColumnName = ConfigurationDataDtoUtils.GetTypedValue<string>(moduleStructure.Attribute);
			CardModule = moduleStructure.CardModule;
			CardSchema = moduleStructure.CardSchema;
			EntitySchemaName = moduleStructure.EntitySchemaName;
			EntitySchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.EntitySchemaUId);
			Hide = ConfigurationDataDtoUtils.GetTypedValue<bool>(moduleStructure.Hide);
			ImageId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.ImageId);
			LogoId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.LogoId);
			MiniPageSchema = moduleStructure.MiniPageSchema;
			ModuleCaption = moduleStructure.ModuleCaption;
			ModuleHeader = moduleStructure.ModuleHeader;
			ModuleId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.ModuleId);
			PagesStructure = moduleStructure.PagesStructure?
				.Select(ps => new PageStructureDto(ps))
				.ToList();
			Position = null;
			SectionModule = moduleStructure.SectionModule;
			SectionSchema = moduleStructure.SectionSchema;
			VisaSchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.VisaSchemaUId);
			VisaSchemaName = moduleStructure.VisaSchemaName;
			Workplace = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.Workplace);
			Section8X = moduleStructure.Section8X;
			Primary = moduleStructure.Primary;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "cardModule")]
		public string CardModule {
			get;
			set;
		}

		[DataMember(Name = "cardSchema")]
		public string CardSchema {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaUId")]
		public Guid EntitySchemaUId {
			get;
			set;
		}

		[DataMember(Name = "hide")]
		public bool Hide {
			get;
			set;
		}

		[DataMember(Name = "imageId")]
		public Guid ImageId {
			get;
			set;
		}

		[DataMember(Name = "logoId")]
		public Guid LogoId {
			get;
			set;
		}

		[DataMember(Name = "miniPageSchema")]
		public string MiniPageSchema {
			get;
			set;
		}

		[DataMember(Name = "moduleCaption")]
		public string ModuleCaption {
			get;
			set;
		}

		[DataMember(Name = "moduleHeader")]
		public string ModuleHeader {
			get;
			set;
		}

		[DataMember(Name = "moduleId")]
		public Guid ModuleId {
			get;
			set;
		}

		[DataMember(Name = "pages", EmitDefaultValue = false)]
		public List<PageStructureDto> PagesStructure {
			get;
			set;
		}

		[DataMember(Name = "position", EmitDefaultValue = false)]
		public int? Position {
			get;
			set;
		}

		[DataMember(Name = "sectionModule")]
		public string SectionModule {
			get;
			set;
		}

		[DataMember(Name = "sectionSchema")]
		public string SectionSchema {
			get;
			set;
		}

		[DataMember(Name = "typeColumnName", EmitDefaultValue = false)]
		public string TypeColumnName {
			get;
			set;
		}

		[DataMember(Name = "visaSchemaUId", EmitDefaultValue = false)]
		public Guid VisaSchemaUId {
			get;
			set;
		}

		[DataMember(Name = "visaSchemaName", EmitDefaultValue = false)]
		public string VisaSchemaName {
			get;
			set;
		}

		[DataMember(Name = "workplace", EmitDefaultValue = false)]
		public Guid Workplace {
			get;
			set;
		}

		[DataMember(Name = "keyInGlobalModuleStructure", EmitDefaultValue = false)]
		public string KeyInGlobalModuleStructure {
			get;
			set;
		}

		[DataMember(Name = "primary")]
		public bool Primary {
			get;
			set;
		}

		[DataMember(Name = "section8X")]
		public bool Section8X {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: EntityStructureDto

	[DataContract]
	public class EntityStructureDto
	{

		#region Constructors: Public

		public EntityStructureDto() {
			PagesStructure = new List<PageStructureDto>();
		}

		public EntityStructureDto(EntityStructure entityStructure) {
			EntitySchemaName = entityStructure.EntityName;
			EntitySchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(entityStructure.EntitySchemaUId);
			SearchRowSchema = entityStructure.SearchRowSchema;
			TypeColumnName = entityStructure.Attribute;
			Page8X = entityStructure.Page8X;
			Primary = entityStructure.Primary;
			CardModuleName = entityStructure.CardModuleName;
			PagesStructure = entityStructure.PagesStructure?
				.Select(ps => new PageStructureDto(ps))
				.ToList();
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaUId")]
		public Guid EntitySchemaUId {
			get;
			set;
		}

		[DataMember(Name = "pages")]
		public List<PageStructureDto> PagesStructure {
			get;
			set;
		}

		[DataMember(Name = "searchRowSchema", EmitDefaultValue = false)]
		public string SearchRowSchema {
			get;
			set;
		}

		[DataMember(Name = "typeColumnName", EmitDefaultValue = false)]
		public string TypeColumnName {
			get;
			set;
		}

		[DataMember(Name = "page8X")]
		public bool Page8X { get; set; }

		[DataMember(Name = "cardModuleName")]
		public string CardModuleName {
			get;
			set;
		}
		
		[DataMember(Name = "primary")]
		public bool Primary { get; set; }
		
		[DataMember(Name = "keyInGlobalEntityStructure")]
		public string KeyInGlobalEntityStructure { get; set; }

		#endregion

	}

	#endregion

	#region Class: RootSchemaDescriptorsDto

	[DataContract]
	public class RootSchemaDescriptorsDto
	{

		#region Properties: Public

		[DataMember(Name = "schemaName")]
		public string SchemaName {
			get;
			set;
		}

		[DataMember(Name = "path")]
		public string Path {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataDto

	[DataContract]
	public class ConfigurationDataDto
	{
		#region Constructors: Public

		public ConfigurationDataDto() { }

		public ConfigurationDataDto(ConfigurationData configurationData, bool useFullEntitiesStructure = false) {
			ModulesStructure = configurationData.ModulesStructure?
				.Select(ms => new ModuleStructureDto(ms.Value) {
					KeyInGlobalModuleStructure = ms.Key
				})
				.ToList();
			if (configurationData.EntitiesStructure != null) {
				EntitiesStructure = new List<EntityStructureDto>();
				foreach (KeyValuePair<Guid, EntityStructure> entityStructure in configurationData.EntitiesStructure) {
					EntityStructure structure = entityStructure.Value;
					EntitiesStructure.Add(new EntityStructureDto(structure) {
						KeyInGlobalEntityStructure = structure.EntityName
					});
					if (useFullEntitiesStructure && structure is OverridingEntityStructure overridingStructure) {
						EntitiesStructure.Add(new EntityStructureDto(overridingStructure.OverridenEntityStructure) {
							KeyInGlobalEntityStructure = overridingStructure.OverridenEntityStructure.EntitySchemaUId
						});
					}
				}
			}
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "modulesStructure")]
		public List<ModuleStructureDto> ModulesStructure {
			get;
			set;
		}


		[DataMember(Name = "entitiesStructure")]
		public List<EntityStructureDto> EntitiesStructure {
			get;
			set;
		}

		#endregion

	}

	#endregion
	
	#region Class: EntityUIdInfo

	[DataContract]
	public class EntityUIdInfo
	{

		#region Constructors: Public

		public EntityUIdInfo(string entitySchemaName, Guid entitySchemaUId)
		{
			EntitySchemaName = entitySchemaName;
			EntitySchemaUId = entitySchemaUId;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaUId")]
		public Guid EntitySchemaUId {
			get;
			set;
		}

		#endregion

	}

	#endregion
	
	#region Class: EntityUIdsDto

	[DataContract]
	public class EntityUIdsDto
	{
		#region Constructors: Public

		public EntityUIdsDto() { }

		public EntityUIdsDto(List<EntityUIdInfo>  entityUIds)
		{
			EntityUIds = entityUIds;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "entityUIds")]
		public List<EntityUIdInfo>  EntityUIds {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataDtoUtils

	public class ConfigurationDataDtoUtils
	{

		#region Methods: Protected

		protected static bool GetBooleanValue(object value) {
			if (value == null) {
				return false;
			}
			if (value is string && (value as string).IsNullOrEmpty()) {
				return false;
			}
			return Convert.ToBoolean(value);
		}

		protected static Guid GetGuidValue(object value) {
			if (value == null) {
				return Guid.Empty;
			}
			if (value is string) {
				return (value as string).IsNullOrEmpty() ? Guid.Empty : new Guid((string)value);
			}
			if (value is Guid) {
				return (Guid)value;
			}
			throw new Exception();
		}

		protected static string GetStringValue(object value) {
			if (value == null) {
				return null;
			}
			if (value is string) {
				return (value as string).IsNullOrEmpty() ? null : (string)value;
			}
			return Convert.ToString(value);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Prepares and returns value by type.
		/// </summary>
		/// <typeparam name="T">Type of return value.</typeparam>
		/// <param name="value">Value.</param>
		/// <returns>Typed value.</returns>
		public static T GetTypedValue<T>(object value) {
			if (typeof(T) == typeof(string)) {
				return (T)(object)GetStringValue(value);
			}
			if (typeof(T) == typeof(Guid)) {
				return (T)(object)GetGuidValue(value);
			}
			if (typeof(T) == typeof(bool)) {
				return (T)(object)GetBooleanValue(value);
			}
			throw new Exception();
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataResponse

	[DataContract]
	public class ConfigurationDataResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public ConfigurationDataResponse() : base() { }

		public ConfigurationDataResponse(Exception e) : base(e) { }

		public ConfigurationDataResponse(ConfigurationDataDto data) : base() {
			Data = data;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "data")]
		public ConfigurationDataDto Data {
			get; set;
		}

		#endregion

	}

	#endregion
	
	#region Class: EntityUIdsResponse

	[DataContract]
	public class EntityUIdsResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public EntityUIdsResponse() : base() { }

		public EntityUIdsResponse(Exception e) : base(e) { }

		public EntityUIdsResponse(EntityUIdsDto data) : base() {
			Data = data;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "data")]
		public EntityUIdsDto Data {
			get; set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ConfigurationDataService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private ConfigurationSectionHelper _configurationSectionHelper;

		#endregion

		#region Constructors: Public

		public ConfigurationDataService() : base() { }

		public ConfigurationDataService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Properties: Private

		private ConfigurationSectionHelper ConfigurationSectionHelper =>
				_configurationSectionHelper ?? (_configurationSectionHelper = ClassFactory.Get<ConfigurationSectionHelper>(
					new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationDataResponse GetData(bool forceGet = false) {
			try {
				var data = ConfigurationSectionHelper.GetConfigurationData(UserConnection, forceGet);
				return new ConfigurationDataResponse(new ConfigurationDataDto(data, true));
			}
			catch (Exception e) {
				return new ConfigurationDataResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationDataResponse GetEntityData(IEnumerable<string> entityNames) {
			try {
				var data = ConfigurationSectionHelper.GetConfigurationData(UserConnection, entityNames);
				return new ConfigurationDataResponse(new ConfigurationDataDto(data));
			}
			catch (Exception e) {
				return new ConfigurationDataResponse(e);
			}
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public EntityUIdsResponse GetEntityUIds(IEnumerable<string> entityNames) {
			try {
				var data = ConfigurationSectionHelper.GetEntityUIds(UserConnection, entityNames);
				return new EntityUIdsResponse(new EntityUIdsDto(data));
			}
			catch (Exception e) {
				return new EntityUIdsResponse(e);
			}
		}

		#endregion

	}

	#endregion

}

