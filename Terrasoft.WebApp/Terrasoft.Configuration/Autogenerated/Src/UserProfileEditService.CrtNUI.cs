namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;

	#region Class: UserProfileEditService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class UserProfileEditService : BaseService
	{

		#region Fields: Private

		/// <summary>
		/// A dictionary of modified columns in the "VwSysAdminUnit" schema object.
		/// The key is the column name, and the value is the column value.
		/// </summary>
		private Dictionary<string, object> changedValues;
		private static readonly HashSet<string> allowedKeys = new HashSet<string> {
			"Id",
			"SysCulture",
			"DateTimeFormat",
			"TimeZone"
		};
		
		#endregion

		#region Methods: Private

		private void ValidateModifiedColumns(Dictionary<string, object> allValues) {
			var disallowedKeys = new List<string>();
			foreach (var key in allValues.Keys) {
				if (!allowedKeys.Contains(key)) {
					disallowedKeys.Add(key);
				}
			}
			if (disallowedKeys.Count > 0) {
				throw new Exception($"Not allowed to be modified: {string.Join(", ", disallowedKeys)}");
			}
		}

		private void SaveUser() {
			object primaryColumnValue = UserConnection.CurrentUser.Id;
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity entity = entitySchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			entity.FetchFromDB(primaryColumnValue);
			foreach (KeyValuePair<string, object> item in changedValues) {
				EntitySchemaColumn column = entitySchema.Columns.GetByName(item.Key);
				object columnValue = DataTypeUtilities.ValueAsType(item.Value, column.ValueType);
				if (column.ColumnValueName != entitySchema.PrimaryColumn.ColumnValueName) {
					entity.SetColumnValue(column, columnValue);
				}
			}
			entity.Save(false);
		}
		
		#endregion

		#region Methods: Public
		
		/// <summary>
		/// Saves changes to the SysAdminUnit object of the current user.
		/// </summary>
		/// <param name="jsonObject">Serialized list of modified columns of the "VwSysAdminUnit" schema.</param>
		/// <returns>The exception message if an error was handled; otherwise, an empty string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateUserProfile(string jsonObject) {
			try {
				var allValues = Json.Deserialize<Dictionary<string, object>>(jsonObject);
				if (GlobalAppSettings.EnableUserProfileColumnRestrictions) {
					ValidateModifiedColumns(allValues);
				}
				changedValues = allValues;
				SaveUser();
				return string.Empty;
			} catch (Exception e) {
				return e.Message;
			}
		}
		
		#endregion
	}

	#endregion
}

