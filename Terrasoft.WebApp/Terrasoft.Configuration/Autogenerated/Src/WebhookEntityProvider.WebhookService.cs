namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: WebhookEntityProvider

	/// <inheritdoc cref="IWebhookEntityProvider"/>
	[DefaultBinding(typeof(IWebhookEntityProvider))]
	public class WebhookEntityProvider : IWebhookEntityProvider
	{

		#region Fields: Private

		private IFieldMapperChain _fieldMapperChain;

		#endregion

		#region Fields: Protected

		/// <summary>
		/// The user connection.
		/// </summary>
		protected readonly UserConnection UserConnection;

		/// <summary>
		/// Webhook log writer
		/// </summary>
		protected readonly WebhookLogWriter WebhookLogWriter;

		#endregion

		private static readonly Lazy<IEnumerable<ICustomTypeWebhookHandler>> _customTypeHandler =
			new Lazy<IEnumerable<ICustomTypeWebhookHandler>>(() => ClassFactory.GetAll<ICustomTypeWebhookHandler>());

		private static readonly Lazy<IEnumerable<ICustomWebhookDefaultValueProvider>> _customDefaultValueProviders =
			new Lazy<IEnumerable<ICustomWebhookDefaultValueProvider>>(() => ClassFactory.GetAll<ICustomWebhookDefaultValueProvider>());

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="WebhookEntityProvider"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public WebhookEntityProvider(UserConnection userConnection) {
			UserConnection = userConnection;
			WebhookLogWriter = new WebhookLogWriter(UserConnection);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the field mapper chain.
		/// </summary>
		public IFieldMapperChain FieldMapperChain {
			get {
				if (_fieldMapperChain == null) {
					return _fieldMapperChain = new FieldMapperChain();
				}
				return _fieldMapperChain;
			}
			set => _fieldMapperChain = value;
		}

		/// <summary>
		/// List of entities the provider works with.
		/// </summary>
		public IEnumerable<string> EntityNames => Array.Empty<string>();

		#endregion

		#region Methods: Private

		private string GetColumnName(EntitySchemaColumn column) {
			return column.IsLookupType ? $"{column.Name}Id" : column.Name;
		}

		private IEnumerable<EntitySchemaColumn> GetMatchedColumns(EntitySchemaColumnCollection entityColumns,
			Dictionary<string, string> webhookColumns, Dictionary<string, string> webhookLookupColumns) {
			var result = new List<EntitySchemaColumn>(webhookColumns.Count);
			foreach (EntitySchemaColumn entityColumn in entityColumns) {
				if (entityColumn.IsLookupType) {
					if (webhookLookupColumns.ContainsKey(entityColumn.Name.ToLower())) {
						result.Add(entityColumn);
					}
					continue;
				}
				if (webhookColumns.ContainsKey(entityColumn.Name.ToLower())) {
					result.Add(entityColumn);
				}
			}
			return result;
		}

		private IEnumerable<EntitySchemaColumn> GetMatchedColumns(EntitySchemaColumnCollection entityColumns,
			IEnumerable<WebhookColumnMap> mappedFields) {
			var result = new List<EntitySchemaColumn>(mappedFields.Count());
			IEnumerable<EntitySchemaColumn> matchedColumns = entityColumns.Where(entityColumn =>
				mappedFields.Any(mappedField => string.Equals(entityColumn.Name,
					mappedField.EntityColumnName, StringComparison.InvariantCultureIgnoreCase)));
			result.AddRange(matchedColumns);
			return result;
		}

		private void SetColumnValue(WebhookDescription webhookObj, Entity entity, EntitySchema entitySchema,
			string jObjColumnName, EntitySchemaColumn column) {
			JToken jTokenValue = webhookObj.RequestBody[jObjColumnName];
			try {
				object fieldValue = GetFieldValue(jTokenValue.Value<string>(), column.DataValueType.ValueType,
					webhookObj.SourceWebhook.WebhookSource);
				entity.SetColumnValue(GetColumnName(column), fieldValue);
			} catch (Exception exception) {
				WebhookLogWriter.LogWebhookError(webhookObj.SourceWebhook.UId,
					"An error occurred while setting the column value. " +
					$"ColumnName:{column.Name}. EntityName:{entitySchema.Name}. Exception:{exception.Message}");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets the field value.
		/// </summary>
		/// <param name="fieldValueStr">The field value string.</param>
		/// <param name="type">The type.</param>
		/// <param name="sourceWebhook">Webhook source</param>
		protected object GetFieldValue(string fieldValueStr, Type type, string sourceWebhook) {
			ICustomTypeWebhookHandler typedHandler = _customTypeHandler.Value.FirstOrDefault(x =>
				x.ProviderName == sourceWebhook && x.Type == type);
			ICustomTypeWebhookHandler defaultHandler = _customTypeHandler.Value.FirstOrDefault(x =>
				string.IsNullOrEmpty(x.ProviderName) && x.Type == type);
			ICustomTypeWebhookHandler handler = typedHandler ?? defaultHandler;
			if (handler != null) {
				return handler.Handle(fieldValueStr);
			}
			return Convert.ChangeType(fieldValueStr, type);
		}

		/// <summary>
		/// Sets the entity fields.
		/// </summary>
		/// <param name="webhookObj">The webhook object.</param>
		/// <param name="entity">The entity.</param>
		/// <param name="entitySchema">The entity schema.</param>
		[Obsolete("8.0.8 | Method is deprecated. Use SetEntityFieldsWithChain instead.")]
		protected virtual void SetEntityFields(WebhookDescription webhookObj, Entity entity,
			EntitySchema entitySchema) {
			var objectColumns = new Dictionary<string, string>();
			var webhookLookupColumns = new Dictionary<string, string>();
			foreach (KeyValuePair<string, JToken> keyValuePair in webhookObj.RequestBody) {
				string columnNameToLower = keyValuePair.Key.ToLower();
				if (columnNameToLower.EndsWith("id")) {
					webhookLookupColumns.Add(columnNameToLower.Substring(0, columnNameToLower.Length - 2),
						keyValuePair.Key);
				}
				objectColumns.Add(columnNameToLower, keyValuePair.Key);
			}
			entity.SetDefColumnValues();
			foreach (EntitySchemaColumn column in GetMatchedColumns(entitySchema.Columns, objectColumns,
						webhookLookupColumns)) {
				string jObjColumnName = column.IsLookupType ? webhookLookupColumns[column.Name.ToLower()]
					: objectColumns[column.Name.ToLower()];
				SetColumnValue(webhookObj, entity, entitySchema, jObjColumnName, column);
			}
		}

		/// <summary>
		/// Fills the default colunm values of the created entity.
		/// </summary>
		/// <param name="entity">The created entity instance.</param>
		/// <param name="webhookSource">Code of the webhook source.</param>
		/// <param name="webhookFieldValues">Webhook field source values.</param>
		protected virtual void SetEntityDefaultFields(Entity entity, string webhookSource, IDictionary<string, object> webhookFieldValues) {
			entity.SetDefColumnValues();
			var defaultValueProviders =
				_customDefaultValueProviders.Value.Where(x =>
					x.WebhookSource == webhookSource);
			if (!defaultValueProviders.Any()) {
				return;
			}
			foreach (var provider in defaultValueProviders) {
				provider.SetDefaultValues(entity, webhookFieldValues);
			}
		}

		/// <summary>
		/// Sets the entity fields.
		/// </summary>
		/// <param name="webhookObj">The webhook object.</param>
		/// <param name="entity">The entity.</param>
		/// <param name="entitySchema">The entity schema.</param>
		protected virtual void SetEntityFieldsWithChain(WebhookDescription webhookObj, Entity entity,
			EntitySchema entitySchema) {
			var webhookFieldValues = new Dictionary<string, object>();
			foreach (KeyValuePair<string, JToken> keyValuePair in webhookObj.RequestBody) {
				webhookFieldValues.Add(keyValuePair.Key, keyValuePair.Value);
			}
			var mappedFields = FieldMapperChain.GetMappedFields(webhookFieldValues.Keys,
				webhookObj.SourceWebhook.WebhookSource, webhookObj.GetEntityType());
			SetEntityDefaultFields(entity, webhookObj.SourceWebhook.WebhookSource, webhookFieldValues);
			foreach (var column in GetMatchedColumns(entitySchema.Columns, mappedFields)) {
				var jObjColumnName = mappedFields.First(x =>
					string.Equals(x.EntityColumnName, column.Name, StringComparison.InvariantCultureIgnoreCase)).WebhookColumnName;
				SetColumnValue(webhookObj, entity, entitySchema, jObjColumnName, column);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IWebhookEntityProvider"/>
		public Entity GetEntity(WebhookDescription webhook) {
			string entityType = webhook.GetEntityType();
			EntitySchema entityTemplate = UserConnection.EntitySchemaManager.GetInstanceByName(entityType);
			Entity webhookEntity = entityTemplate.CreateEntity(UserConnection);
			SetEntityFieldsWithChain(webhook, webhookEntity, entityTemplate);
			return webhookEntity;
		}

		#endregion

	}

	#endregion

}

