namespace Terrasoft.Configuration
{

	using System;
	using Terrasoft.Core.Entities;

	#region Class: SysApproval_ApprovalEventsProcess

	public partial class SysApproval_ApprovalEventsProcess<TEntity>
	{

		#region Methods: Public

		/// <summary>
		/// Return referenced entity.
		/// </summary>
		/// <returns>A <see cref="Entity"/></returns>
 		public override Entity GetFetchedReferenceEntity() {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(Entity.GetTypedColumnValue<string>("ReferenceSchemaName"));
			Entity entity = schema.CreateEntity(UserConnection);
			if (schema.PrimaryDisplayColumn == null) {
				entity.FetchPrimaryColumnFromDB(Entity.GetTypedColumnValue<Guid>("EntityId"));
			} else {
				entity.FetchPrimaryInfoFromDB("Id", Entity.GetTypedColumnValue<Guid>("EntityId"));
			}
			return entity;
		}

		#endregion

	}

	#endregion

}

