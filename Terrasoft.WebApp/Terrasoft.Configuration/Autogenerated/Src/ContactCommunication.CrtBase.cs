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

	#region Class: ContactCommunication_CrtBaseEventsProcess

	public partial class ContactCommunication_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override Dictionary<Guid, Dictionary<string, string>> GetColumnNamesMap() {
			return new Dictionary<Guid, Dictionary<string, string>> {
				{ new Guid(CommunicationTypeConsts.EmailId), new Dictionary<string, string> {
					{ "Number", "Email" }
				}},
				{ new Guid(CommunicationTypeConsts.WorkPhoneId), new Dictionary<string, string> {
					{ "Number", "Phone" }
				}},
				{ new Guid(CommunicationTypeConsts.MobilePhoneId), new Dictionary<string, string> {
					{ "Number", "MobilePhone" }
				}},
				{ new Guid(CommunicationTypeConsts.HomePhoneId), new Dictionary<string, string> {
					{ "Number", "HomePhone" }
				}},
				{ new Guid(CommunicationTypeConsts.SkypeId), new Dictionary<string, string> {
					{ "Number", "Skype" }
				}},
				{ new Guid(CommunicationTypeConsts.FacebookId), new Dictionary<string, string> {
					{ "Number", "Facebook" },
					{ "SocialMediaId", "FacebookId" }
				}},
				{ new Guid(CommunicationTypeConsts.LinkedInId), new Dictionary<string, string> {
					{ "Number", "LinkedIn" },
					{ "SocialMediaId", "LinkedInId" }
				}},
				{ new Guid(CommunicationTypeConsts.TwitterId), new Dictionary<string, string> {
					{ "Number", "Twitter" },
					{ "SocialMediaId", "TwitterId" }
				}}
			};
		}

		public virtual void SetNewContactCommunication() {
			if (GetIsCommonBehaviorEnabled()) {
				base.OnCommunicationSaved();
			} else {
				var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
				Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
				string typedColumnName = columnNames["TypeColumnName"];
				var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				UpdateCommunicationParentEntity("Contact", contactId, typedColumnName);
			}
		}

		public virtual void ClearOldContactCommunication() {
			var oldCommunicationTypeId = Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId");
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			if (!oldCommunicationTypeId.Equals(Guid.Empty) && !oldCommunicationTypeId.Equals(communicationTypeId)) {
				ActualizePrimaryState();
				Entity.SetColumnValue("IsCreatedBySynchronization", true);
				var columnName = string.Empty;
				Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(oldCommunicationTypeId);
				var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				string typedColumnName = columnNames["TypeColumnName"];
				string newCommunicationValue = Entity.GetTypedColumnValue<string>("Number");
				bool isCanEdit = GetCanEditColumn("Contact", typedColumnName);
				if (isCanEdit && !string.IsNullOrEmpty(typedColumnName)) {
					var update = new Update(UserConnection, "Contact")
					.Set(typedColumnName, Column.Parameter(string.Empty))
					.Where("Id").IsEqual(Column.Parameter(contactId))
					.And(typedColumnName).IsEqual(Column.Parameter(newCommunicationValue));
					update.Execute();
				}
			}
		}

		public virtual void OnContactCommunicationDeleted() {
			if (GetIsCommonBehaviorEnabled()) {
				base.OnCommunicationDeleted();
			} else {
				Guid contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				string number = Entity.GetTypedColumnValue<string>("Number");
				Guid communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
				bool isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
				Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
				var contactEntity = contactSchema.CreateEntity(UserConnection);
				string typedColumnName = columnNames["TypeColumnName"];
				string socialColumnName = columnNames["SocialColumnName"];
				bool isCanEdit = GetCanEditColumn("Contact", typedColumnName);
				if (contactEntity.FetchFromDB(contactId) && isPrimary) {
					if (isCanEdit && !string.IsNullOrEmpty(typedColumnName)) {
						string value = contactEntity.GetTypedColumnValue<string>(typedColumnName);
						if (value == number) {
							contactEntity.SetColumnValue(typedColumnName, string.Empty);
							if (!string.IsNullOrEmpty(socialColumnName)) {
								contactEntity.SetColumnValue(socialColumnName, string.Empty);
							}
						}
					}
					contactEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
					contactEntity.Save();
				}
			}
		}

		public virtual Dictionary<string, string> GetColumnNameByCommunicationType(Guid communicationType) {
			var values = new Dictionary<string, string>();
			values.Add("TypeColumnName", string.Empty);
			values.Add("SocialColumnName", string.Empty);
			var columnsMap = GetColumnNamesMap();
			if (columnsMap.ContainsKey(communicationType)) {
				var columns = columnsMap[communicationType];
				values["TypeColumnName"] = columns["Number"];
				if (columns.ContainsKey("SocialMediaId")) {
					values["SocialColumnName"] = columns["SocialMediaId"];
				}
			}
			return values;
		}

		public virtual void ActualizeExternalCommunicationType() {
			if (Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId") != Entity.GetTypedColumnValue<Guid>("CommunicationTypeId")) {
				Entity.SetColumnValue("ExternalCommunicationType", string.Empty);
			}
		}

		public virtual void OnContactCommunicationSaving() {
			var isNew = GetIsNew();
			var isCommonBehaviorEnabled = GetIsCommonBehaviorEnabled();
			if (isCommonBehaviorEnabled) {
				base.OnCommunicationSaving();
			} else {
				if (isNew) {
					ActualizePrimaryState();
					Entity.SetColumnValue("IsCreatedBySynchronization", true);
				} else {
					ClearOldContactCommunication();
				}
			}
			var isPrimaryChanged = Entity.GetChangedColumnValues()
				.Any(column => column.Name == "Primary");
			var isCreatedBySynchronizationChanged = Entity.GetChangedColumnValues()
				.Any(column => column.Name == "IsCreatedBySynchronization");
			if ((isNew && isCommonBehaviorEnabled) || (!isNew && isPrimaryChanged)) {
				var isPrimary = Entity.GetTypedColumnValue<bool>("Primary");
				Entity.SetColumnValue("IsCreatedBySynchronization", isPrimary);
			} else if ((isNew && !isCommonBehaviorEnabled) || (!isNew && isCreatedBySynchronizationChanged)) {
				var isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
				Entity.SetColumnValue("Primary", isPrimary);
			}
		}

		public virtual void ActualizePrimaryState() {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			
			var update = new Update(UserConnection, "ContactCommunication")
				.Set("IsCreatedBySynchronization", Column.Parameter(false))
			.Where("ContactId").IsEqual(Column.Parameter(contactId))
			.And("CommunicationTypeId").IsEqual(Column.Parameter(communicationTypeId)) as Update;
			update.Execute();
		}

		public override void SetCommunicationParentEntityColumns(Entity parentEntity) {
			var communicationTypeId = Entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			Dictionary<string, string> columnNames = GetColumnNameByCommunicationType(communicationTypeId);
			string typedColumnName = columnNames["TypeColumnName"];
			string socialColumnName = columnNames["SocialColumnName"];
			var socialColumnValue = Entity.GetTypedColumnValue<string>("SocialMediaId");
			var isPrimary = Entity.GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			if (string.IsNullOrEmpty(typedColumnName) || !isPrimary) {
				return;
			}
			var number = Entity.GetTypedColumnValue<string>("Number");
			parentEntity.SetColumnValue(typedColumnName, number);
			if (!string.IsNullOrEmpty(socialColumnName)) {
				parentEntity.SetColumnValue(socialColumnName, socialColumnValue);
			}
		}

		#endregion

	}

	#endregion

}

