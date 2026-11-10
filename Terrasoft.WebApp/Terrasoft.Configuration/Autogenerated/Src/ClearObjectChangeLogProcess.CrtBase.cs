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
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.UserLevel;
	using Terrasoft.Core.UserLevel.Feature;

	#region Class: ClearObjectChangeLogProcessMethodsWrapper

	/// <exclude/>
	public class ClearObjectChangeLogProcessMethodsWrapper : ProcessModel
	{

		public ClearObjectChangeLogProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ClearChangeLogScriptTaskExecute", ClearChangeLogScriptTaskExecute);
		}

		#region Methods: Private

		private bool ClearChangeLogScriptTaskExecute(ProcessExecutingContext context) {
			var entitySchemaUId = this.Get<Guid>("EntitySchemaUId");
			var fromDate= this.Get<DateTime>("FromDate");
			var endDate = this.Get<DateTime>("EndDate");
			var changeLogCleaner = new ChangeLogCleaner(this.Get<UserConnection>("UserConnection"));
			changeLogCleaner.ChunkSize = this.Get<int>("ChunkSize");
			changeLogCleaner.ChunkProcessingDelay = this.Get<int>("ChunkProcessingDelay");
			changeLogCleaner.MaxDegreeOfParallelism = this.Get<int>("MaxDegreeOfParallelism");
			Guid[] schemaUIds;
			string message = string.Empty;
			if (entitySchemaUId == Guid.Empty) {
				schemaUIds = GetTrackedSchemas();
				message = string.Format(this.Get<string>("SuccessMessageForObjects"));
			} else {
				schemaUIds = new Guid[] { entitySchemaUId };
				var entitySchemaManager = this.Get<UserConnection>("UserConnection").EntitySchemaManager;
				var loggedObject = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
				message = string.Format(this.Get<string>("SuccessMessageForOneObject"), loggedObject.Name);
			}
			DateTime? startPeriod = fromDate == default(DateTime) ? (DateTime?)null : fromDate;
			DateTime? endPeriod = endDate == default(DateTime) ? (DateTime?)null : endDate;
			try {
				schemaUIds.ForEach(sUId => changeLogCleaner.Clear(sUId, startPeriod, endPeriod));
				SendReminding(message);
			} catch (Exception e) {
				SendReminding(this.Get<string>("ErrorMessage"));
				throw;
			}
			return true;
		}

			private Guid[] GetTrackedSchemas() {
				if (Features.GetIsEnabled<UseUserLevelEntitySchema>()) {
					var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "VwWorkspaceObjects") {
						UseAdminRights = false
					};
					esq.AddColumn("UId");
					esq.AddColumn("IsTrackChangesInDB");
					EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
					var ulsEntitySchemaPropertyProvider = ClassFactory.Get<IUserLevelEntitySchemaPropertyProvider>();
					IDictionary<Guid, bool> parentsUIdToIsTrackChangesInDbMap = ulsEntitySchemaPropertyProvider
						.GetParentsUIdToPropertyValueInDbMap("IsTrackChangesInDB");
					return entityCollection.Select(workspaceObject => {
						Guid schemaUId = workspaceObject.GetTypedColumnValue<Guid>("UId");
						bool isTrackChangesInDb = parentsUIdToIsTrackChangesInDbMap
								.TryGetValue(schemaUId, out bool ulsIsTrackChangesInDb)
							? ulsIsTrackChangesInDb
							: workspaceObject.GetTypedColumnValue<bool>("IsTrackChangesInDB");
						return (schemaUId, isTrackChangesInDb);
					}).Where(x => x.isTrackChangesInDb).Select(x => x.schemaUId).ToArray();
				} else {
					var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "VwLogObjects") {
						UseAdminRights = false
					};
					EntitySchemaQueryColumn schemaUIdColumn = esq.AddColumn("UId");
					esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
						"SysWorkspace", UserConnection.Workspace.Id));
					EntityCollection entities = esq.GetEntityCollection(UserConnection);
					return entities.Select(e =>e.GetTypedColumnValue<Guid>(schemaUIdColumn.Name)).ToArray();
				}
			}
					
			public virtual void SendReminding(string message) {
				RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ClearObjectChangeLogProcess", message);
			}

		#endregion

	}

	#endregion

}

