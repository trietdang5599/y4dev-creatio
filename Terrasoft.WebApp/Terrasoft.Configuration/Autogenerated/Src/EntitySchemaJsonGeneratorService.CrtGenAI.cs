namespace Terrasoft.Configuration.OpenAI
{
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;

	#region Class: EntitySchemaJsonGeneratorService

	/// <summary>
	/// Web service for generating JSON schema metadata for all entity schemas in a specific application context.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EntitySchemaJsonGeneratorService : BaseService
	{

		#region Constans: Private

		private const string IntegerAlias = "Integer";

		#endregion

		#region Methods: Private

		/// <summary>
		/// Determine the data type of a given column in an entity schema.
		/// </summary>
		/// <param name="column">Entity schema column.</param>
		/// <returns>The data type of a given column.</returns>
		private object DetermineColumnType(SchemaProperty column) {
			object type;
			if (column.DataValueType.IsLookup) {
				type = new {
					referenceSchema = column.ReferenceSchema.Name
				};
			} else if (column.DataValueType.ValueType == typeof(int)) {
				type = IntegerAlias;
			} else {
				type = column.DataValueType.ValueType.Name;
			}
			return type;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generate a JSON containing the definition of all entity schemas in a specific application context.
		/// </summary>
		/// <returns>The JSON with the definition of all entity schemas.</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetEntitySchemaDefinitions() {
			var schemasDict = new Dictionary<string, Dictionary<string, object>>();
			IEnumerable<EntitySchema> schemaManagerItems = UserConnection.EntitySchemaManager.GetItems()
				.Where(x => x.Instance != null)
				.Select(x => x.Instance);
			foreach (EntitySchema item in schemaManagerItems) {
				EntitySchemaColumnCollection columns = item.Columns;
				var columnsDict = new Dictionary<string, object>();
				foreach (EntitySchemaColumn column in columns) {
					if (column.DataValueType.IsLookup && column.ReferenceSchema == null) {
						continue;
					}
					columnsDict[column.Name] = DetermineColumnType(column);
				}
				schemasDict[item.Name] = columnsDict;
			}
			string result = JsonConvert.SerializeObject(schemasDict);
			return result;
		}

		#endregion

	}

	#endregion

}

