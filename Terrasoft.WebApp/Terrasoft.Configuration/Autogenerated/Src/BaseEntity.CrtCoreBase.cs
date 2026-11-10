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

	#region Class: BaseEntity_CrtCoreBaseEventsProcess

	public partial class BaseEntity_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Private

		private string SerializeListeners<T>(Collection<T> collection) {
			return string.Join(",", collection.Select(x => x.ToString()));
		}

		private void LogListeners<T>(Collection<T> newListeners, object oldListeners) {
			if (newListeners == null || !(oldListeners is Collection<T> oldListenersCollection) ||
					newListeners.Count == oldListenersCollection.Count) {
				return;
			}
			Log.WarnFormat("Listeners rewrite detected, some process may not be triggered. " +
				"Old: {old}, New: {new}. StackTrace: {stackTrace}",
				SerializeListeners(oldListenersCollection),
				SerializeListeners(newListeners), 
				Environment.StackTrace);
		}

		#endregion

		#region Methods: Public

		public virtual void TryProcessComplete(EntityChangeType changeType) {
			var processEngine = UserConnection.ProcessEngine;
			var processListeners = processEngine.GetProcessListeners(UserConnection, Entity, changeType);
			var processSchemaListeners = processEngine.GetProcessSchemaListeners(Entity, changeType);
			LogListeners(processListeners, ProcessListeners);
			LogListeners(processSchemaListeners, ProcessSchemaListeners);
			ProcessListeners = processListeners;
			ProcessSchemaListeners = processSchemaListeners;
		}

		public virtual bool IsConditionDataMatch(string conditionData) {
			if (string.IsNullOrEmpty(conditionData)) {
				return true;
			}
			var esq = new EntitySchemaQuery(Entity.Schema);
			IEntitySchemaQueryFilterItem filterCollection = null;
			try {
				var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
				var processDataContractFilterConverter = ClassFactory
					.Get<IProcessDataContractFilterConverter>(userConnectionArgument);
				filterCollection = processDataContractFilterConverter.ConvertToEntitySchemaQueryFilterItem(esq, conditionData);
			} catch {
				var oldConditionData = ConditionData.Deserialize(conditionData);
				bool oldConditionCompleted = oldConditionData == null || oldConditionData.Count == 0;
				if (!oldConditionCompleted) {
					foreach (var condition in oldConditionData) {
						oldConditionCompleted = Entity.GetColumnValue(Entity.Schema.Columns.GetByUId(condition.Key)).Equals(condition.Value);
						if (oldConditionCompleted) {
							break;
						}
					}
				}
				return oldConditionCompleted;
			}
			if (filterCollection != null) {
				esq.AddColumn(Entity.Schema.PrimaryColumn.Name);
				esq.Filters.Add(filterCollection);
				var entity = esq.GetEntity(UserConnection, Entity.PrimaryColumnValue);
				return entity != null;
			}
			return true;
		}

		public virtual bool IsChangedColumnsMatch(string changedColumns) {
			if (string.IsNullOrEmpty(changedColumns)) {
				return true;
			}
			var changedColumnsMetaPaths = JsonConvert.DeserializeObject<Collection<string>>(changedColumns);
			foreach(var columnMetaPath in changedColumnsMetaPaths){
				var changedColumn = Entity.Schema.GetSchemaColumnByMetaPath(columnMetaPath);
				foreach (var columnValue in Entity.GetChangedColumnValues()) {
					if (Guid.Equals(columnValue.Column.UId, changedColumn.UId)) {
						return true;
					}
				}
			}
			return false;
		}

		public virtual void ProcessCompleteExecuting() {
			var processEngine = UserConnection.ProcessEngine;
			var processListeners = (Collection<ProcessListener>)ProcessListeners;
			var processSchemaListeners = (Collection<ProcessSchemaListener>)ProcessSchemaListeners;
			processEngine.ActualizeProcessSchemaListeners(Entity, processSchemaListeners);
			Collection<ProcessDescriptor> processDescriptors;
			bool nextPrcElReady = false;
			IList<ProcessListener> clonedProcessListeners = null;
			if (processListeners != null && processListeners.Count > 0) {
				clonedProcessListeners = new List<ProcessListener>(processListeners);
				processDescriptors = processEngine.ContinueExecuting(UserConnection, Entity, processListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReady = nextPrcElReady || processDescriptor.IsNextElementReady;
				}
				processListeners.Clear();
			}
			if (CanUseDcm) {
				processEngine.RunDcmProcesses(Entity, clonedProcessListeners);
			}
			bool nextPrcElReadyBySignal = false;
			if (processSchemaListeners != null && processSchemaListeners.Count > 0) {
				processDescriptors = processEngine.RunProcesses(UserConnection, Entity, processSchemaListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReadyBySignal = nextPrcElReadyBySignal || processDescriptor.IsNextElementReady;
				}
				processSchemaListeners.Clear();
			}
			if (!nextPrcElReady) {
				nextPrcElReady = nextPrcElReadyBySignal;
			}
			NextProcessElementReady = NextProcessElementReady || nextPrcElReady;
		}

		public virtual bool GetNextPrcElReadyPropertyValue(Entity entity) {
			if (entity != null && entity.Process != null) {
				object nextPrcElReady;
				if (entity.Process.TryGetPropertyValue("NextProcessElementReady", out nextPrcElReady)) {
					return (bool)nextPrcElReady;
				}
			}
			return false;
		}

		public virtual void LocalMessageExecuting(EntityChangeType changeType) {
			return;
		}

		public virtual void InitDcmOnEntityChanging() {
			if (!CanInitDcmForEntity()) {
				return;
			}
			var dcmEntityUtilities = GetDcmEntityUtilities();
			CanUseDcm = dcmEntityUtilities.GetCanEntityUseDcm(Entity.Schema.UId, Entity.GetChangedColumnValues());
			CancelNotEnabledDcmProcess();
		}

		public virtual void CancelNotEnabledDcmProcess() {
			if (CanUseDcm) {
				UserConnection.IProcessEngine.CancelNotEnabledDcmProcess(Entity.Schema.UId, Entity.PrimaryColumnValue);
			}
		}

		public virtual DcmEntityUtilities GetDcmEntityUtilities() {
			if (DcmEntityUtil == null) {
				DcmEntityUtil = new DcmEntityUtilities(UserConnection);
			}
			return (DcmEntityUtilities)DcmEntityUtil;
		}

		public virtual bool CanInitDcmForEntity() {
			var schema = Entity.Schema;
			return schema != null &&
				schema.Name != "AdminUnitFeatureState" &&
				schema.Name != "Feature";
		}

		public virtual void IndexEntity(IndexingOperationType indexingOperationType, Guid primaryColumnValue) {
		}

		#endregion

	}

	#endregion

}
