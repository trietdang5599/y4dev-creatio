namespace Terrasoft.Configuration.UserDefaultPageService
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Addons;
	using Terrasoft.Core.Addons.Interfaces;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.RelatedPages;
	using Terrasoft.Web.Common;

	#region Class: AppContentItemUsers

	[DataContract]
	public class AppContentItemUsers
	{

		[DataMember(Name = "appContentItemId")]
		public Guid AppContentItemId;

		[DataMember(Name = "userIds")]
		public Guid[] UserIds;

	}

	#endregion

	#region Class: UserDefaultPageSelector

	/// <summary>
	/// Provides API to get pages with users roles.
	/// </summary>
	public class UserDefaultPageSelector
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private IAddonSchemaManager _addonSchemaManager;

		private IAddonSchemaManager AddonSchemaManager {
			get {
				return _addonSchemaManager ?? (_addonSchemaManager = (IAddonSchemaManager)_userConnection.FindSchemaManager("AddonSchemaManager"));
			}
		}

		#endregion

		#region Constructors: Public

		public UserDefaultPageSelector(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public UserDefaultPageSelector(UserConnection userConnection, IAddonSchemaManager addonSchemaManager) : this(userConnection) {
			this._addonSchemaManager = addonSchemaManager;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<(Guid entitySchemaUId, Guid sectionSchemaUId)> GetEntitiesForSections(IEnumerable<Guid> sectionSchemaUId) {
			Select sectionsByPagesSelect = new Select(_userConnection)
				.Column("SM", "Id")
				.Column("SM", "SectionSchemaUId")
				.Column("SME", "SysEntitySchemaUId")
				.From("SysModule").As("SM").InnerJoin("SysModuleEntity").As("SME").On("SM", "SysModuleEntityId").IsEqual("SME", "Id")
				.Where("SM", "SectionSchemaUId").In(Column.Parameters(sectionSchemaUId)) as Select;
			return sectionsByPagesSelect.ExecuteEnumerable(r => (
				entitySchemaUId: r.GetColumnValue<Guid>("SysEntitySchemaUId"),
				sectionSchemaUId: r.GetColumnValue<Guid>("SectionSchemaUId")
			));
		}

		private IEnumerable<(Guid id, Guid cardSchemaUId)> GetPagesByApplicationSections(IEnumerable<Guid> aplicationSectionIds) {
			Select sectionsByPagesSelect = new Select(_userConnection)
				.Column("SM", "Id")
				.Column("SME", "SysEntitySchemaUId")
				.From("SysModule").As("SM").InnerJoin("SysModuleEntity").As("SME").On("SM", "SysModuleEntityId").IsEqual("SME", "Id")
				.Where("SM", "Id").In(Column.Parameters(aplicationSectionIds)) as Select;
			var sectionEntities = sectionsByPagesSelect.ExecuteEnumerable(r => (
				id: r.GetColumnValue<Guid>("Id"),
				sysEntitySchemaUId: r.GetColumnValue<Guid>("SysEntitySchemaUId")
			));
			List<(Guid id, Guid cardSchemaUId)> result = new List<(Guid id, Guid cardSchemaUId)>();
			sectionEntities.ForEach(sectionEntity => {
				var pages = GetRelatedPageAddons().Where(rp => rp.TargetSchemaUId == sectionEntity.sysEntitySchemaUId)
					.SelectMany(addon => ((RelatedPages)addon.AddonConfig).Pages);
				pages.ForEach(page => {
					result.Add((sectionEntity.id, page.PageSchemaUId));
				});
			});
			return result;
		}

		private IEnumerable<AddonSchema> GetRelatedPageAddons() {
			AddonSchema[] addons = AddonSchemaManager.FindAddons(_userConnection.EntitySchemaManager.Name);
			return addons.Where(x => x.AddonName.Equals("RelatedPage"));
		}

		#endregion

		#region Methods: Protected

		protected virtual IEnumerable<RelatedPage> GetRelatedPagesAddons(Guid[] relatedPagesUIds) {
			return GetRelatedPageAddons().SelectMany(x => ((RelatedPages)x.AddonConfig).Pages)
				.Where(page => relatedPagesUIds.Contains(page.PageSchemaUId));
		}

		protected virtual ICollection<RelatedPage> GetRelatedPagesByEntity(Guid entityUId) {
			return GetRelatedPageAddons()
				.Where(a => a.TargetSchemaUId.Equals(entityUId))
				.SelectMany(a => ((RelatedPages)a?.AddonConfig).Pages)
				.ToList();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets users for pages with specified schemaUIds.
		/// </summary>
		/// <param name="schemaUIds">UIds of page schemas to fetch users.</param>
		/// <returns>Collection of pages and users where key is a page UId and value is an array of page users' Id's</returns>
		public Dictionary<Guid, List<Guid>> GetPageUsers(Guid[] schemaUIds) {
			Dictionary<Guid, List<Guid>> result = new Dictionary<Guid, List<Guid>>();
			GetRelatedPagesAddons(schemaUIds).ForEach(p => {
				if (p.Role != null) {
					if (result.ContainsKey(p.PageSchemaUId)) {
						result[p.PageSchemaUId].Add((Guid)p.Role);
					} else {
						result.Add(p.PageSchemaUId, new List<Guid>() { (Guid)p.Role });
					}
				}
			});
			GetEntitiesForSections(schemaUIds)
				.ForEach(record => {
					var pagesByEntity = GetRelatedPagesByEntity(record.entitySchemaUId);
					if (pagesByEntity != null) {
						var pagesRoles = pagesByEntity.Where(p => p.Role != null).Select(p => (Guid)p.Role).Distinct().ToList();
						if (pagesRoles.Any()) { 
							result.Add(record.sectionSchemaUId, pagesRoles);
						};
					}
				});
			return result;
		}

		/// <summary>
		/// Gets users for application sections with specified section UIds.
		/// </summary>
		/// <param name="applicationSectionIds">Ids of application sections page schemas to fetch users.</param>
		/// <returns>Collection of pages and users where key is a page UId and value is an array of page users' Id's</returns>
		public Dictionary<Guid, List<Guid>> GetApplicationSectionUsers(Guid[] applicationSectionIds) {
			Dictionary<Guid, List<Guid>> result = new Dictionary<Guid, List<Guid>>();
			var sectionsCardSchemas = GetPagesByApplicationSections(applicationSectionIds);
			var pages = GetRelatedPagesAddons(sectionsCardSchemas.Select(sc => sc.cardSchemaUId).ToArray());
			sectionsCardSchemas.Select(scs => scs.cardSchemaUId).Distinct().ForEach(cardSchema => {
				var cardUsers = pages.Where(p => p.PageSchemaUId == cardSchema && p.Role != null)
					.Select(p => (Guid)p.Role);
				if (cardUsers.Any()) {
					sectionsCardSchemas.Where(scs => scs.cardSchemaUId == cardSchema)
						.Select(scs => scs.id).ForEach(appSectionId => {
							result[appSectionId] = (result.ContainsKey(appSectionId) ? result[appSectionId] : new List<Guid>());
							result[appSectionId].AddRange(cardUsers);
						});
				}

			});
			return result;
		}

		#endregion
	}

	#endregion

	#region Class: UserDefaultPageService

	/// <summary>
	/// Service for getting info about entity pages by users.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class UserDefaultPageService : BaseService
	{

		#region Constructors: Public

		public UserDefaultPageService() { }

		public UserDefaultPageService(IAddonSchemaManager addonSchemaManager) {
			_userDefaultPageSelector = new UserDefaultPageSelector(UserConnection, addonSchemaManager);
		}

		#endregion

		#region Fields: Private

		private UserDefaultPageSelector _userDefaultPageSelector;
		public UserDefaultPageSelector UserDefaultPageSelector {
			get {
				return _userDefaultPageSelector ?? (_userDefaultPageSelector = new UserDefaultPageSelector(UserConnection));
			}
		}

		private static readonly ILog _log = LogManager.GetLogger("Error");

		#endregion

		#region Methods: Private

		private AppContentItemUsers[] ToObjectUsers(Dictionary<Guid, List<Guid>> objectsWithUsers) {
			return objectsWithUsers.Select(ou => new AppContentItemUsers() {
				AppContentItemId = ou.Key,
				UserIds = ou.Value.ToArray()
			}).ToArray();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets users for pages with specified schemaUIds.
		/// </summary>
		/// <param name="schemaUIds">UIds of page schemas to fetch users.</param>
		/// <returns>Collection of pages and users where key is a page UId and value is an array of page users' Id's</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public AppContentItemUsers[] GetPageUsers(Guid[] schemaUIds) {
			Dictionary<Guid, List<Guid>> result = new Dictionary<Guid, List<Guid>>();
			try {
				result = UserDefaultPageSelector.GetPageUsers(schemaUIds);
			} catch (Exception ex) {
				_log.Error(ex.Message);
			}
			return ToObjectUsers(result);
		}

		/// <summary>
		/// Gets users for application sections with specified section UIds.
		/// </summary>
		/// <param name="applicationSectionIds">Ids of application sections page schemas to fetch users.</param>
		/// <returns>Collection of pages and users where key is a page UId and value is an array of page users' Id's</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public AppContentItemUsers[] GetApplicationSectionUsers(Guid[] applicationSectionIds) {
			Dictionary<Guid, List<Guid>> result = new Dictionary<Guid, List<Guid>>();
			try {
				result = UserDefaultPageSelector.GetApplicationSectionUsers(applicationSectionIds);
			} catch (Exception ex) {
				_log.Error(ex.Message);
			}
			return ToObjectUsers(result);
		}

		#endregion
	
	}

	#endregion

}
