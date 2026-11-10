namespace Terrasoft.Core.Process
{

	using Creatio.FeatureToggling;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ReindexUsersInGlobalSearchMethodsWrapper

	/// <exclude/>
	public class ReindexUsersInGlobalSearchMethodsWrapper : ProcessModel
	{

		public ReindexUsersInGlobalSearchMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
			AddScriptTaskMethod("ScriptTask3Execute", ScriptTask3Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var modifiedBefore = Get<DateTime>("ModifiedBefore");
			if (modifiedBefore == DateTime.MinValue || Features.GetIsDisabled("GlobalSearch_V2") || Features.GetIsDisabled("ESMention")) {
				return true;
			}
			var batchsize = Get<int>("BatchSize");
			var contactSchema = UserConnection.EntitySchemaManager.FindInstanceByName("Contact");
			var select = GetContactsBatchSelect(batchsize, modifiedBefore);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var contactId = dataReader.GetColumnValue<Guid>("Id");
						UpdateContact(contactId, contactSchema);
					}
				}
			}
			return true;
		}

		private bool ScriptTask3Execute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageUsers");
			var countSelect = GetContactsCountSelect();
			Set("allContactsCount", countSelect.ExecuteScalar<int>());
			return true;
		}

			protected void UpdateContact(Guid contactId, EntitySchema contactSchema) {
				var contactEntity = contactSchema.CreateEntity(UserConnection);
				contactEntity.UseAdminRights = false;
				if (contactEntity.FetchFromDB(contactId, false)) {
					contactEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
					contactEntity.Save();
				}
			}
			
			protected Select AddUserFiltersToContactsSelect(Select select) {
				return select.Where().Exists(
						new Select(UserConnection)
							.Column("Id")
							.From("SysAdminUnit")
							.Where("SysAdminUnit", "ContactId").IsEqual("Contact", "Id")
							.And("SysAdminUnit", "Active").IsEqual(Column.Const(true))
					) as Select;
			}
			
			protected Select GetContactsBatchSelect(int batchsize, DateTime modifiedBefore) {
					var userTimeZone = UserConnection.CurrentUser.TimeZone;
					var modifiedBeforeUtc = TimeZoneInfo.ConvertTimeToUtc(modifiedBefore, userTimeZone);
				var select = new Select(UserConnection)
					.Top(batchsize)
					.Column("Contact", "Id")
					.From("Contact");
				return AddUserFiltersToContactsSelect(select)
					.And("Contact", "ModifiedOn").IsLess(Column.Parameter(modifiedBeforeUtc)) as Select;
			}
			
			protected Select GetContactsCountSelect() {
				var select = new Select(UserConnection)
					.Column(Func.Count("Contact", "Id"))
					.From("Contact");
				return AddUserFiltersToContactsSelect(select);
			}

		#endregion

	}

	#endregion

}

