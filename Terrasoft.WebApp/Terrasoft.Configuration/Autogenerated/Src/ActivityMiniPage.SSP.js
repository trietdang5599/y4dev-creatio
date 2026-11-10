define("ActivityMiniPage", [], function() {
	return {
		entitySchemaName: "Activity",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {
			/**
			 * Returns sign of visibility.
			 * @return {Boolean} True if is not SSP user.
			 */
			getOpenCurrentEntityPageVisible: function() {
				return !this.Terrasoft.isCurrentUserSsp();
			},

			/**
			 * @inheritDoc Terrasoft.EntityConnectionLinksUtilities#loadEntityConnectionsByESQ
			 * @override
			 */
			loadEntityConnectionsByESQ: function (esq) {
				if (this.Terrasoft.isCurrentUserSsp()) {
					this._removeUnnecessaryFiltersFromQuery(esq);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc Terrasoft.EntityConnectionLinksUtilities#addEntityConnectionsColumns
			 * @override
			 */
			addEntityConnectionsColumns: function(esq) {
				this.callParent(arguments);
				if (this.Terrasoft.isCurrentUserSsp()) {
					esq.columns.removeByKey("SysSchemaName");
					esq.addParameterColumn(this.entitySchemaName, this.Terrasoft.DataValueType.TEXT, "SysSchemaName");
				}
			},

			/**
			 * @inheritDoc Terrasoft.EntityConnectionLinksUtilities#processEntityConnectionsResponse
			 * @override
			 */
			processEntityConnectionsResponse: function(collection) {
				if (this.Terrasoft.isCurrentUserSsp()) {
					const filtered = collection.filterByFn(function(entityConnection) {
						const schemaName = entityConnection.$ReferenceSchema && entityConnection.$ReferenceSchema.name;
						return schemaName && this.isNotEmpty(this.getEntityStructure(schemaName));
					}, this);
					collection.reloadAll(filtered);
				}
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_removeUnnecessaryFiltersFromQuery: function(esq) {
				esq.filters.removeByKey("EntitySchema");
				esq.filters.removeByKey("SysWorkspace");
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "OpenCurrentEntityPage",
				"values": {
					"visible": {
						"bindTo": "getOpenCurrentEntityPageVisible"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
