namespace Terrasoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Class: SingleIndexingSectionListBuilder
	
	public class SingleIndexingSectionListBuilder : IndexingSectionListBuilder
	{
		
		#region Constructors: Public
		
		/// <inheritdoc/>
		public SingleIndexingSectionListBuilder(UserConnection userConnection) : base(userConnection) {}
		
		#endregion
		
		#region Methods: Protected
		
		/// <inheritdoc/>
		protected override IndexingEntityConfig GetIndexingEntity(KeyValuePair<string, EntitySchemaQuery> entityQuery) {
			var indexingEntity = base.GetIndexingEntity(entityQuery);
			indexingEntity.IsSingle = true;
			return indexingEntity;
		}
		
		/// <inheritdoc/>
		protected override EntitySchemaQuery GetSelectForIndexation(EntitySchema entitySchema) {
			var esq = GetDefEsq(entitySchema);
			return esq;
		}
		
		/// <inheritdoc/>
		protected override void ApplyPrimaryColumnRule(EntitySchemaQueryColumn primaryEsqColumn,
			EntitySchemaQuery esq, string primaryEsqColumnAlias) {
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryEsqColumnAlias, 
				Guid.Empty, Guid.Empty);
			esq.Filters.Add(filter);
		}
		
		/// <inheritdoc/>
		protected override string GetSqlText(EntitySchemaQuery esq) {
			string sqlText = base.GetSqlText(esq);
			string inFilter = $"'{{{Guid.Empty}}}', '{{{Guid.Empty}}}'";
			return sqlText.Replace(inFilter, _idListMacro);
		}
				
		/// <inheritdoc/>
		protected override int GetDefEsqRowCount() {
			return -1;
		}

		#endregion
	}
	
	#endregion
	
}

