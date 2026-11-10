namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: TagAccessGranteeListener

	/// <summary>
	/// Listener for 'TagAccessGrantee' entity events.
	/// </summary>
	[EntityEventListener(SchemaName = "TagAccessGrantee")]
	public class TagAccessGranteeListener : BaseEntityEventListener
	{

		#region Consts: Private 

		private readonly string SetTagsRightsProcessName = "SetTagsRightsByAccessToTagGranteeProcess";
		private readonly string SetRightsToAccessToTagProcessName = "SetRightsToAccessToTagProcess";
		private readonly string DeleteTagsRightsProcessName = "DeleteTagsRightsByTagAccessGranteeProcess";
		private readonly string DeleteTagsAccessRightsProcessName = "DeleteAccessToTagRightsProcess";

		#endregion

		#region Fields: Private

		private readonly List<string> RequiredColumnNamesToUpdateRights = new List<string> {
			"TagAccessId",
			"SysAdminUnitId",
			"CanRead",
			"CanEdit",
			"CanDelete"
		};

		private readonly List<string> RequiredColumnNamesToUpdateTagAccessRights = new List<string> {
			"TagAccessId",
			"SysAdminUnitId",
			"CanRead",
			"CanCreate"
		};

		#endregion

		#region Methods: Private

		private void CheckTagAccessGranteeExists(Entity entity) {
			if (!IsTagAccessGranteeExists(entity)) {
				return;
			}
			var errorMessage = new LocalizableString(entity.UserConnection.Workspace.ResourceStorage,
								"TagAccessGranteeListener", "LocalizableStrings.DuplicateRowError.Value");
			throw new Exception(errorMessage);
		}

		private bool IsTagAccessGranteeExists(Entity entity) {
			var tagAccessId = entity.GetTypedColumnValue<Guid>("TagAccessId");
			var sysAdminUnitId = entity.GetTypedColumnValue<Guid>("SysAdminUnitId");
			var esq = new EntitySchemaQuery(entity.UserConnection.EntitySchemaManager, "TagAccessGrantee");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.RowCount = 1;
			esq.UseAdminRights = false;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"TagAccess", tagAccessId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysAdminUnit", sysAdminUnitId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual,
				"Id", entity.PrimaryColumnValue));
			var result = esq.GetEntityCollection(entity.UserConnection);
			return result.Any();
		}

		private void DeleteRights(Entity entity) {
			RunDeleteRightsProcess(entity, DeleteTagsAccessRightsProcessName);
			RunDeleteRightsProcess(entity, DeleteTagsRightsProcessName);
		}

		private void RunDeleteRightsProcess(Entity entity, string processName) {
			var tagAccessId = entity.GetTypedColumnValue<Guid>("TagAccessId");
			var sysAdminUnitId = entity.GetTypedColumnValue<Guid>("SysAdminUnitId");
			var parameters = new Dictionary<string, object> {
				{ "TagAccessId",  tagAccessId },
				{ "SysAdminUnitId", sysAdminUnitId }
			};
			entity.UserConnection.RunProcess(processName, parameters);
		}

		private void ChangeRightsIfNeed(Entity entity) {
			ChangeTagRightsIfNeed(entity);
			ChangeAccessRightsIfNeed(entity);
		}

		private void ChangeTagRightsIfNeed(Entity entity) {
			if (!IsNeedUpdateTagRights(entity)) {
				return;
			}
			RunChangeRightsProcess(entity, SetTagsRightsProcessName);
		}

		private bool IsNeedUpdateTagRights(Entity entity) {
			return entity.GetChangedColumnValues().Any(column => 
				RequiredColumnNamesToUpdateRights.Contains(column.Name));
		}

		private void ChangeAccessRightsIfNeed(Entity entity) {
			if (!IsNeedUpdateTagAccessRights(entity)) {
				return;
			}
			RunChangeRightsProcess(entity, SetRightsToAccessToTagProcessName);
		}

		private bool IsNeedUpdateTagAccessRights(Entity entity) {
			return entity.GetChangedColumnValues().Any(column =>
				RequiredColumnNamesToUpdateTagAccessRights.Contains(column.Name));
		}

		private void RunChangeRightsProcess(Entity entity, string processName) {
			var prevTagAccessId = entity.GetTypedOldColumnValue<Guid>("TagAccessId");
			var prevSysAdminUnitId = entity.GetTypedOldColumnValue<Guid>("SysAdminUnitId");
			var tagAccessGranteeId = entity.PrimaryColumnValue;
			var parameters = new Dictionary<string, object> {
				{ "PreviosTagAccessId",  prevTagAccessId },
				{ "PreviosSysAdminUnitId", prevSysAdminUnitId },
				{ "TagAccessGranteeId",  tagAccessGranteeId }
			};
			entity.UserConnection.RunProcess(processName, parameters);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			CheckTagAccessGranteeExists(entity);
			base.OnInserting(sender, e);
		}

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			CheckTagAccessGranteeExists(entity);
			base.OnUpdating(sender, e);
		}

		/// <summary>
		/// Handles entity Updated event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			var entity = (Entity)sender;
			ChangeRightsIfNeed(entity);
			base.OnUpdated(sender, e);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			var entity = (Entity)sender;
			DeleteRights(entity);
			base.OnDeleted(sender, e);
		}

		#endregion

	}

	#endregion
}
