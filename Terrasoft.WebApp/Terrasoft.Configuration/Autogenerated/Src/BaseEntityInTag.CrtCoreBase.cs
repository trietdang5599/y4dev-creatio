namespace Terrasoft.Configuration
{

	using System;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: BaseEntityInTag_CrtBaseEventsProcess

	public partial class BaseEntityInTag_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Private

		private bool IsEntityInTagExist(Guid tagId, Guid entityId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, Entity.SchemaName);
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.RowCount = 1;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Tag", tagId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Entity", entityId));
			return esq.GetEntityCollection(UserConnection).Count() > 0;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Checks if is duplicate tag. If yes then throw <exception cref="DublicateDataException">exception</exception>.
		/// </summary>
		public void CheckDuplicationEntityInTag() {
			Guid tagId = Entity.GetTypedColumnValue<Guid>("TagId");
			Guid entityId = Entity.GetTypedColumnValue<Guid>("EntityId");
			if (IsEntityInTagExist(tagId, entityId)) {
				throw new DublicateDataException(Entity.SchemaName);
			}
		}

		#endregion

	}

	#endregion

}

