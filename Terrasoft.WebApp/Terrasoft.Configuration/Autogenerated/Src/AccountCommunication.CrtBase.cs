namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: AccountCommunication_CrtBaseEventsProcess

	public partial class AccountCommunication_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override Dictionary<Guid, Dictionary<string, string>> GetColumnNamesMap() {
			return new Dictionary<Guid, Dictionary<string, string>> {
				{ new Guid(CommunicationTypeConsts.WebId), new Dictionary<string, string> {
					{ "Number", "Web" }
				}},
				{ new Guid(CommunicationTypeConsts.MainPhoneId), new Dictionary<string, string> {
					{ "Number", "Phone" }
				}},
				{ new Guid(CommunicationTypeConsts.AdditionalPhoneId), new Dictionary<string, string> {
					{ "Number", "AdditionalPhone" }
				}},
				{ new Guid(CommunicationTypeConsts.FaxId), new Dictionary<string, string> {
					{ "Number", "Fax" }
				}}
			};
		}

		public virtual void OnAccountCommunicationSaved() {
			if (GetIsCommonBehaviorEnabled()) {
				base.OnCommunicationSaved();
			} else {
				var typeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
				var typedColumnName = GetColumnNameByCommunicationType(typeId);
				var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
				UpdateCommunicationParentEntity("Account", accountId, typedColumnName);
			}
		}

		public virtual void OnAccountCommunicationDeleted() {
			if (GetIsCommonBehaviorEnabled()) {
				base.OnCommunicationDeleted();
			} else {
				var accountESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Account");
				var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
				var number = Entity.GetTypedColumnValue<string>("Number");
				var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
				bool isPrimary = Entity.GetTypedColumnValue<bool>("Primary");
				var columnName = GetColumnNameByCommunicationType(communicationTypeId);
				bool isCanEdit = GetCanEditColumn("Account", columnName);
				if (!string.IsNullOrEmpty(columnName) && isPrimary) {
					accountESQ.AddAllSchemaColumns();
					var accountEntity = accountESQ.GetEntity(UserConnection, accountId);
					if (isCanEdit && accountEntity != null) {
						var value = accountEntity.GetTypedColumnValue<string>(columnName);
						if (value == number) {
							accountEntity.SetColumnValue(columnName, string.Empty);
							accountEntity.Save();
						}
					}
				}
			}
		}

		public virtual void OnAccountCommunicationSaving() {
			if (GetIsCommonBehaviorEnabled()) {
				base.OnCommunicationSaving();
			} else {
				IsNew = GetIsNew();
				if (IsNew) {
					ActualizePrimaryState();
					Entity.SetColumnValue("Primary", true);
				} else {
					ClearOldCommunication();
				}
			}
		}

		public virtual string GetColumnNameByCommunicationType(Guid communicationType) {
			string columnName = string.Empty;
			var columnsMap = GetColumnNamesMap();
			if (columnsMap.ContainsKey(communicationType)) {
				columnName = columnsMap[communicationType]["Number"];
			}
			return columnName;
		}

		public virtual void ClearOldCommunication() {
			var oldCommunicationTypeId = Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId");
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			if (!oldCommunicationTypeId.Equals(Guid.Empty) && !oldCommunicationTypeId.Equals(communicationTypeId)) {
				ActualizePrimaryState();
				Entity.SetColumnValue("Primary", true);
				var columnName = GetColumnNameByCommunicationType(oldCommunicationTypeId);
				bool isCanEdit = GetCanEditColumn("Account", columnName);
				if (isCanEdit && !string.IsNullOrEmpty(columnName)) {
					var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
					var update = new Update(UserConnection, "Account")
						.Set(columnName, Column.Parameter(string.Empty))
						.Where("Id").IsEqual(Column.Parameter(accountId));
					update.Execute();
				}
			}
		}

		public virtual void ActualizePrimaryState() {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
			var update = new Update(UserConnection, "AccountCommunication")
				.Set("Primary", Column.Parameter(false))
			.Where("AccountId").IsEqual(Column.Parameter(accountId))
			.And("CommunicationTypeId").IsEqual(Column.Parameter(communicationTypeId)) as Update;
			update.Execute();
		}

		public override Entity GetCommunicationParentEntity(string schemaName, Guid id) {
			var accountESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			accountESQ.AddAllSchemaColumns();
			return accountESQ.GetEntity(UserConnection, id);
		}

		public override void SetCommunicationParentEntityColumns(Entity parentEntity) {
			var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
			var typeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			var columnName = GetColumnNameByCommunicationType(typeId);
			if (string.IsNullOrEmpty(columnName)) {
				return;
			}
			var number = Entity.GetTypedColumnValue<string>("Number");
			parentEntity.SetColumnValue(columnName, number);
		}

		#endregion

	}

	#endregion

}

