namespace Terrasoft.Configuration.Section
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Configuration.PageEntity;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	/// <summary>
	/// Provides API operations with sections.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SectionService: BaseService, IReadOnlySessionState
	{

		#region Class: NotAdministrationEntitiesResponse

		/// <summary>
		/// Represents response with not administrated entities.
		/// </summary>
		[DataContract]
		public class NotAdministrationEntitiesResponse : ConfigurationServiceResponse 
		{
			/// <summary>
			/// Collection of entities which not administrated by records.
			/// </summary>
			[DataMember(Name = "byRecords")]
			public IEnumerable<string> ByRecords { get; set; }

			/// <summary>
			/// Collection of entities which not administrated by operations.
			/// </summary>
			[DataMember(Name = "byOperations")]
			public IEnumerable<string> ByOperations { get; set; }
		}

		#endregion

		#region Properties: Public

		private IPageEntityManager _pageEntityManager;

		/// <summary>
		/// Pages manager.
		/// </summary>
		public IPageEntityManager PageEntityManager {
			get => _pageEntityManager ?? 
				(_pageEntityManager = ClassFactory.Get<IPageEntityManager>(new ConstructorArgument("uc", UserConnection)));
			set => _pageEntityManager = value;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates <see cref="ISectionManager"/> implementation instance.
		/// </summary>
		/// <param name="type">Section manager type.</param>
		/// <returns><see cref="ISectionManager"/> implementation instance.</returns>
		private ISectionManager GetSectionManager(string type) {
			return ClassFactory.Get<ISectionManager>(new ConstructorArgument("uc", UserConnection),
				new ConstructorArgument("sectionType", type));
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetGeneralAndSspSections(Guid sectionId) {
			var manager = GetSectionManager("General");
			var result = new List<string>();
			try {
				var sections = manager.GetSameEntitySections(sectionId);
				result.AddRangeIfNotExists(sections.Select(s => s.ToString()));
			}
			catch (Exception) {
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetSectionsAvaliableForWorkplace(Guid workplaceId) {
			var manager = GetSectionManager("General");
			var result = manager.GetAvailableWorkplaceSections(workplaceId);
			return result.Select(s => s.ToString());
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetSectionsWithoutSspView() {
			var manager = GetSectionManager("SSP");
			var result = manager.GetByType(SectionType.General);
			return result.Select(s => s.ToString());
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<Guid> GetUsedEntityIds(Guid sectionId) {
			var manager = GetSectionManager("SSP");
			return manager.GetRelatedEntityIds(sectionId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSectionTypes() {
			var dictionary = new Dictionary<string, int>();
			foreach (SectionType sectionType in (SectionType[])Enum.GetValues(typeof(SectionType))) {
				dictionary.Add(sectionType.ToString().ToUpper(), (int)sectionType);
			}
			return JsonConvert.SerializeObject(dictionary);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetEntitiesWithAdministrationErrors(Guid sectionId) {
			var manager = GetSectionManager("SSP");
			return manager.GetSectionNonAdministratedByRecordsEntityCaptions(sectionId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public NotAdministrationEntitiesResponse GetNotAdministratedEntitiesByPage(Guid pageSchemaUId) {
			var response = new NotAdministrationEntitiesResponse {
				ByRecords = new List<string>(),
				ByOperations = new List<string>()
			};
			var sectionManager = GetSectionManager("External");
			try {
				var page = PageEntityManager.GetPage(pageSchemaUId);
				if (page == null) {
					return response;
				}
				var notAdministrated = sectionManager.GetEntitiesCaptionsNotAdministratedByRights(page.SysEntitySchemaUId);
				response.ByRecords = notAdministrated.byRecords;
				response.ByOperations = notAdministrated.byOperations;
			}
			catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public NotAdministrationEntitiesResponse GetNotAdministratedEntitiesByEntity(string entitySchemaName) {
			var response = new NotAdministrationEntitiesResponse {
				ByRecords = new List<string>(),
				ByOperations = new List<string>()
			};
			var sectionManager = GetSectionManager("External");
			try {
				var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName);
				if (entitySchema == null) {
					throw new ItemNotFoundException($"Entity by name {entitySchemaName} not found.");
				}
				var notAdministrated = sectionManager.GetEntitiesCaptionsNotAdministratedByRights(entitySchema.UId);
				response.ByRecords = notAdministrated.byRecords;
				response.ByOperations = notAdministrated.byOperations;
			} catch	(Exception ex) { 
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Sets <see cref="EntitySchema.AdministratedByRecords"/>,<see cref="EntitySchema.AdministratedByOperations"/> properties,
		/// Fills <see cref="SysSSPEntitySchemaAccessList"/> table for <paramref name="pageSchemaUId"/>
		/// <see cref="EntitySchema"/> and related schemas.
		/// </summary>
		/// <param name="pageSchemaUId">Page schema UId.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SetConnectedEntitiesRightsByPage(Guid pageSchemaUId) {
			try {
				var sectionManager = GetSectionManager("External");
				var page = PageEntityManager.GetPage(pageSchemaUId);
				if (page == null) {
					throw new ItemNotFoundException($"Page by Uid {pageSchemaUId} not found.");
				}
				sectionManager.SetConnectedEntitiesRights(page.SysEntitySchemaUId);
			}
			catch (Exception ex) {
				return new ConfigurationServiceResponse(ex);
			}
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Sets <see cref="EntitySchema.AdministratedByRecords"/>,<see cref="EntitySchema.AdministratedByOperations"/> properties,
		/// Fills <see cref="SysSSPEntitySchemaAccessList"/> table for <paramref name="entitySchemaUId"/>
		/// <see cref="EntitySchema"/> and related schemas.
		/// </summary>
		/// <param name="entitySchemaUId">Entity schema UId.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SetConnectedEntitiesAdministratedByEntity(string entitySchemaName) {
			try {
				var sectionManager = GetSectionManager("External");
				var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName);
				if (entitySchema == null) {
					throw new ItemNotFoundException($"Entity by name {entitySchemaName} not found.");
				}
				sectionManager.SetConnectedEntitiesRights(entitySchema.UId);
			} catch	(Exception ex) { 
				return new ConfigurationServiceResponse(ex);
			}
			return new ConfigurationServiceResponse();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "IsErrorOccurred")]
		public bool SetSectionSchemasAdministratedByRecords(Guid sectionId) {
			bool isErrorOccurred = false;
			try {
				var manager = GetSectionManager("SSP");
				manager.SetSectionSchemasAdministratedByRecords(sectionId);
			} catch {
				isErrorOccurred = true;
			}
			return isErrorOccurred;
		}

		/// <summary>
		/// Sets <see cref="EntitySchema.AdministratedByRecords"/>,<see cref="EntitySchema.AdministratedByOperations"/> properties,
		/// Fills <see cref="SysSSPEntitySchemaAccessList"/> table for <paramref name="sectionId"/>
		/// <see cref="EntitySchema"/> and related schemas.
		/// </summary>
		/// <param name="sectionId"Section Id.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "IsErrorOccurred")]
		public bool SetConnectedEntitiesAdministratedBySection(Guid sectionId) {
			bool isErrorOccurred = false;
			try {
				var manager = GetSectionManager("External");
				manager.SetConnectedEntitiesRightsBySection(sectionId);
			} catch {
				isErrorOccurred = true;
			}
			return isErrorOccurred;
		}

		#endregion

	}
}
