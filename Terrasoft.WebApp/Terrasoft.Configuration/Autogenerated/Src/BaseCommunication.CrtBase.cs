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


	#region Class: BaseCommunication_CrtBaseEventsProcess

	public partial class BaseCommunication_CrtBaseEventsProcess<TEntity>
	{

		#region Properties: Protected

		protected Guid OldTypeId { get; set; }
		protected Guid TypeId { get => Entity.GetTypedColumnValue<Guid>("CommunicationTypeId"); }
		protected bool TypeChanged { get; set; }
		protected bool IsNonActual { get => Entity.GetTypedColumnValue<bool>("NonActual"); }
		protected bool OldIsPrimary { get; set; }
		protected bool IsPrimary {
			get{
				return Entity.GetTypedColumnValue<bool>("Primary");
			}
			set {
				Entity.SetColumnValue("Primary", value);
			}
		}
		protected bool IsBecameNotPrimary { get; set; }

		#endregion

		#region Properties: Public

		public CommunicationSynchronizer CommunicationSynchronizer { get; set; }

		#endregion

		#region Methods: Protected

		protected virtual void InitializeParameters() {
			OldIsPrimary = Entity.GetTypedOldColumnValue<bool>("Primary");
			OldTypeId = Entity.GetTypedOldColumnValue<Guid>("CommunicationTypeId");
			TypeChanged = !OldTypeId.Equals(Guid.Empty) && OldTypeId != TypeId;
		}

		protected virtual void DefineCommunicationPrimaryState() {
			var synchronizer = GetCommunicationSynchronizer();
			var actualCommunication = synchronizer.FindActualCommunicationByType(TypeId);
			if (actualCommunication == null) {
				if (GetIsNew() || TypeChanged) {
					IsPrimary = true;
				}
				return;
			}
			var actualCommunicationId = actualCommunication.GetTypedColumnValue<Guid>("Id");
			var actualCommunicationNumber = actualCommunication.GetTypedColumnValue<string>("Number");
			var isActualCommunicationPrimary = actualCommunication.GetTypedColumnValue<bool>("Primary");
			var id = Entity.GetTypedColumnValue<Guid>("Id");
			var number = Entity.GetTypedColumnValue<string>("Number");
			var isReplacingCommunication = number == actualCommunicationNumber;
			IsBecameNotPrimary = id == actualCommunicationId && OldIsPrimary && !IsPrimary;
			if (id != actualCommunicationId && isActualCommunicationPrimary) {
				if (isReplacingCommunication) {
					IsPrimary = true;
				} else if (TypeChanged && IsPrimary) {
					IsPrimary = false;
				}
				if (!OldIsPrimary && IsPrimary && !isReplacingCommunication) {
					synchronizer.ActualizePrimaryState(TypeId);
				}
			}
		}

		#endregion

		#region Methods: Public

		public virtual bool GetIsCommonBehaviorEnabled() {
			return UserConnection.GetIsFeatureEnabled("CommonCommunicationsBehavior");
		}

		public virtual string GetParentEntityColumnName() {
			return Entity.SchemaName.Replace("Communication", "");
		}

		public virtual Dictionary<Guid, Dictionary<string, string>> GetColumnNamesMap() {
			return new Dictionary<Guid, Dictionary<string, string>>();
		}

		public virtual CommunicationSynchronizer GetCommunicationSynchronizer() {
			var columnNamesMap = GetColumnNamesMap();
			CommunicationSynchronizer = CommunicationSynchronizer ?? ClassFactory.Get<CommunicationSynchronizer>(
				new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("entity", Entity),
				new ConstructorArgument("columnNamesMap", columnNamesMap),
				new ConstructorArgument("linkedColumnName", GetParentEntityColumnName()));
			return CommunicationSynchronizer;
		}

		public virtual bool GetIsNew() {
			string oldNumber = Entity.GetTypedOldColumnValue<string>("Number");
			string newNumber = Entity.GetTypedColumnValue<string>("Number");
			return (string.IsNullOrEmpty(oldNumber) && !newNumber.Equals(oldNumber));
		}

		public virtual Entity GetCommunicationParentEntity(string schemaName, Guid id) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var entity = schema.CreateEntity(UserConnection);
			entity.FetchFromDB(id);
			return entity;
		}

		public virtual bool GetCanEditColumn(string schemaName, string columnName) {
			EntitySchemaColumnRightLevel rightLevel = UserConnection.DBSecurityEngine
					.GetEntitySchemaColumnRightLevel(schemaName, columnName, SchemaOperationRightLevels.CanEdit);
			return (rightLevel & EntitySchemaColumnRightLevel.CanEdit) == EntitySchemaColumnRightLevel.CanEdit;
		}

		public virtual void UpdateCommunicationParentEntity(string schemaName, Guid parentEntityId, string typedColumnName) {
			var parentEntity = GetCommunicationParentEntity(schemaName, parentEntityId);
			if (parentEntity == null) {
				return;
			}
			bool isCanEdit = GetCanEditColumn(schemaName, typedColumnName);
			if (isCanEdit) {
				var number = Entity.GetTypedColumnValue<string>("Number");
				SetCommunicationParentEntityColumns(parentEntity);
			}
			parentEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
			parentEntity.CreateUpdate().Execute();
			TrackingChangedColumns(parentEntity);
		}

		public virtual void SetCommunicationParentEntityColumns(Entity parentEntity) {
		}

		public virtual void TrackingChangedColumns(Entity parentEntity) {
			var schemaName = parentEntity.Schema.Name;
			var parentSchema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			parentEntity.TrackChangeInDB(parentSchema);
		}

		public virtual void OnCommunicationSaving() {
			InitializeParameters();
			if (IsNonActual) {
				IsPrimary = false;
				return;
			}
			Entity.SetColumnValue("NonActualReasonId", null);
			Entity.SetColumnValue("DateSetNonActual", null);
			DefineCommunicationPrimaryState();
		}

		public virtual void OnCommunicationSaved() {
			var synchronizer = GetCommunicationSynchronizer();
			if (TypeChanged && OldIsPrimary) {
				synchronizer.SetNewOrEmptyCommunicationValue(OldTypeId);
			}
			if (IsNonActual && OldIsPrimary) {
				synchronizer.SetNewOrEmptyCommunicationValue(TypeId);
			} else if (IsBecameNotPrimary) {
				synchronizer.ClearParentEntityColumn(TypeId);
			}
			if (IsPrimary) {
				synchronizer.SynchronizeCommunicationWithEntity();
			}
		}

		public virtual bool CheckDuplicateCommunication() {
			if (!GetIsCommonBehaviorEnabled()) {
				return false;
			}
			var synchronizer = GetCommunicationSynchronizer();
			return synchronizer.CheckDuplicateCommunication();
		}

		public virtual void RemoveDuplicates() {
			if (GetIsCommonBehaviorEnabled()) {
				return;
			}
			var synchronizer = GetCommunicationSynchronizer();
			synchronizer.RemoveCommunicationDuplicates();
		}

		public virtual void OnCommunicationDeleted() {
			var synchronizer = GetCommunicationSynchronizer();
			if (IsPrimary) {
				synchronizer.SetNewOrEmptyCommunicationValue(TypeId);
			}
		}

		#endregion

	}

	#endregion

}

