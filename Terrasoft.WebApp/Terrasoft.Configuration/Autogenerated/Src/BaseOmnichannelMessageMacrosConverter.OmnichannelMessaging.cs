namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;


	#region Class: MessageMacrosTempale
	/// <summary>
	/// Represents a message macros template containing a template and associated tokens.
	/// </summary>
	[DataContract]
	public class MessageMacrosTempale
	{
		[DataMember(Name = "template")]
		public string Template {
			get; set;
		}

		[DataMember(Name = "tokens")]
		public string Tokens {
			get; set;
		}
	}

	#endregion

	#region Class: MessageMetadata

	/// <summary>
	/// Represents metadata for a message.
	/// </summary>
	[Serializable]
	[DataContract]
	public class MessageMetadata
	{
		[DataMember(Name = "key")]
		public string Key {
			get; set;
		}

		[DataMember(Name = "type")]
		public string Type {
			get; set;
		}

		[DataMember(Name = "value")]
		public object Value {
			get; set;
		}
	}

	#endregion

	#region Interface: IOmnichannelMessageMacrosConverter

	public interface IOmnichannelMessageMacrosConverter
	{
		/// <summary>
		/// Converts metadata to given macros format.
		/// </summary>
		/// <param name="macrosId">Identifier of macros</param>
		/// <param name="metadata">Message metadata.</param>
		/// <returns>Converted metadata template</returns>
		MessageMacrosTempale Convert(Guid macrosId, string metadata);
	}

	#endregion

	#region Class: BaseOmnichannelMessageMacrosConverter

	[DefaultBinding(typeof(IOmnichannelMessageMacrosConverter), Name = "BaseOmnichannelMessageMacrosConverter")]
	public class BaseOmnichannelMessageMacrosConverter : IOmnichannelMessageMacrosConverter
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private OmnichannelMessageMacrosStore _store;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseOmnichannelMessageMacrosConverter"/> class with parameters.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public BaseOmnichannelMessageMacrosConverter(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public
		public OmnichannelMessageMacrosStore Store {
			get
			{
				return _store ?? (_store = new OmnichannelMessageMacrosStore(_userConnection));
			}
			set
			{
				_store = value;
			}
		}

		#endregion

		#region Methods: Private

		private MessageMacrosTempale FillMetadata(string metadata, OmnichannelMessageMacros macros) {
			var tokens = new List<MessageMetadata>();
			var deserializedList = JsonConvert.DeserializeObject<List<MessageMetadata>>(metadata);
			foreach (var item in deserializedList) {
				switch (item.Type) {
					case "lookup" when item.Value is JObject objValue:
						ProcessLookupType(item, objValue);
						break;
					case "datetime":
						ProcessDateTimeType(item);
						break;
				}
				tokens.Add(item);
			}

			return new MessageMacrosTempale { Template = macros.Macros, Tokens = JsonConvert.SerializeObject(tokens) };
		}

		private void ProcessLookupType(MessageMetadata item, JObject objValue) {
			var valueDict = objValue.ToObject<Dictionary<string, object>>();
			string schemaName = valueDict["entitySchemaName"].ToString();
			Guid recordId = Guid.Parse(valueDict["primaryColumnValue"].ToString());
			string displayValue = GetLookupPrimaryColumnValue(schemaName, recordId);
			item.Value = new {
				entitySchemaName = schemaName,
				primaryColumnValue = recordId,
				caption = displayValue
			};
		}

		private void ProcessDateTimeType(MessageMetadata item) {
			DateTime dateTime = DateTime.Parse(item.Value.ToString());
			item.Value = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, _userConnection.CurrentUser.TimeZone);
		}

		#endregion

		#region Methods: Protected

		protected virtual string GetLookupPrimaryColumnValue(string entityName, Guid entityId) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName(entityName);
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, entityName);
			esq.RowCount = 1;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.UseAdminRights = false;
			esq.AddColumn(schema.GetPrimaryDisplayColumnName());
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", entityId));
			return esq.GetEntityCollection(_userConnection)
				.FirstOrDefault()?.GetTypedColumnValue<string>(schema.GetPrimaryDisplayColumnName());
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Converts metadata to given macros format.
		/// </summary>
		/// <param name="macrosId">Identifier of macros</param>
		/// <param name="metadata">Message metadata.</param>
		/// <returns>Converted metadata template</returns>
		public MessageMacrosTempale Convert(Guid macrosId, string metadata) {
			OmnichannelMessageMacros macros = Store.GetById(macrosId);
			return macros == null ? null : FillMetadata(metadata, macros);
		}

		#endregion

	}

	#endregion
}

