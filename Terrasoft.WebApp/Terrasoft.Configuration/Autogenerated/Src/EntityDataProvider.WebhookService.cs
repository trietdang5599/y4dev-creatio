namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;
	using EntityCollection = Terrasoft.Core.Entities.EntityCollection;

	#region Class: EntityModel

	/// <summary>
	/// Represents the model of entity schema.
	/// </summary>
	[DataContract]
	public class EntityModel
	{

		#region Properties: Public

		[DataMember(Name = "fields")]
		public IEnumerable<EntityField> Fields { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		#endregion

	}

	#endregion

	#region Class: EntityField

	/// <summary>
	/// Represents the entity schema model field.
	/// </summary>
	[DataContract]
	public class EntityField
	{

		#region Properties: Public

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "required")]
		public bool IsRequired { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "net_type")]
		public string Type { get; set; }

		#endregion

	}

	#endregion

	#region Class: AvailableEntities

	/// <summary>
	/// Represents the collection of entities that can be stored in webhook.
	/// </summary>
	[DataContract]
	public class AvailableEntities
	{

		#region Properties: Public

		[DataMember(Name = "entities")]
		public IEnumerable<AvailableEntity> Entities { get; set; }

		#endregion

	}

	#endregion

	#region Class: AvailableEntity

	/// <summary>
	/// Represents the entity that can be stored in webhook.
	/// </summary>
	[DataContract]
	public class AvailableEntity
	{

		#region Properties: Public

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "formId")]
		public Guid FormId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		#endregion

	}
	#endregion

	#region Class: EntityDataProvider

	/// <summary>
	/// Service to get info about entities in Creatio.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EntityDataProvider : BaseService
	{

		#region Fields: Private

		private readonly Type[] _availableTypes = {
			typeof(int), typeof(string), typeof(DateTime), typeof(bool), typeof(Guid), typeof(decimal)
		};

		private readonly ILog _logger = LogManager.GetLogger("Webhooks");

		#endregion

		#region Methods: Private

		private EntityCollection GetAvailableEntities() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WebhookEntity");
			esq.AddColumn("Name");
			return esq.GetEntityCollection(UserConnection);
		}

		private AvailableEntity GetAvailableEntity(string entityName) {
			try {
				EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
				var availableEntity = new AvailableEntity {
					Caption = entitySchema.Caption.Value,
					Name = entitySchema.Name,
					FormId = entitySchema.UId
				};
				return availableEntity;
			} catch (Exception e) {
				_logger.Warn($"EntityDataProvider_GetEntityDescription: Provided entity - {entityName} doesn't exist.",
					e);
				return null;
			}
		}

		private string GetLookupColumnExternalName(EntitySchemaColumn column) {
			return string.Concat(column.Name, "Id");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Api method to return available entities in webhooks.
		/// </summary>
		/// <returns>Instance of <see cref="AvailableEntities"/>>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetEntities", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AvailableEntities GetEntities() {
			EntityCollection lookupEntities = GetAvailableEntities();
			var availableEntityList = new List<AvailableEntity>();
			foreach (Entity entity in lookupEntities) {
				var entityName = entity.GetColumnValue("Name").ToString();
				AvailableEntity availableEntity = GetAvailableEntity(entityName);
				if (availableEntity != null) {
					availableEntityList.Add(availableEntity);
				}
			}
			return new AvailableEntities {
				Entities = availableEntityList
			};
		}

		/// <summary>
		/// Api method to return the entity field description.
		/// </summary>
		/// <param name="entityName">The entity schema name.</param>
		/// <param name="apiKey">The api key to the webhook service.</param>
		/// <returns>Instance of <see cref="AvailableEntities"/>>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetEntityDescription",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public EntityModel GetEntityDescription(string entityName, string apiKey) {
			EntityCollection availableEntities = GetAvailableEntities();
			if (availableEntities.All(x => x.SchemaName.EqualsIgnoreCase(entityName))) {
				_logger.Warn($"EntityDataProvider_GetEntityDescription: Provided entity - {entityName} doesn't exist." +
					$"ApiKey: {apiKey} ");
				return null;
			}
			try {
				EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
				var entityFields = new List<EntityField>();
				IEnumerable<EntitySchemaColumn> entitySchemaColumns =
					entitySchema.Columns.Where(x => _availableTypes.Contains(x.DataValueType.ValueType));
				entityFields.AddRange(entitySchemaColumns.Select(column => new EntityField {
					Type = column.DataValueType.ValueType.FullName,
					Name = column.IsLookupType ? GetLookupColumnExternalName(column) : column.Name,
					IsRequired = column.RequirementType != EntitySchemaColumnRequirementType.None,
					Caption = column.Caption.Value
				}));
				return new EntityModel {
					Name = entityName,
					Fields = entityFields
				};
			} catch (Exception e) {
				_logger.Error(
					"EntityDataProvider_GetEntityDescription: The error occured when manipulating entity " +
					$"schema columns. ApiKey: {apiKey}", e);
				return null;
			}
		}

		#endregion

	}

	#endregion

}

