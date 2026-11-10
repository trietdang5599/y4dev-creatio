define("SysFileSearchRowSchema", [], function() {
	return {
		attributes: {},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseSearchRowSchema#init
			 * @overridden
			 */
			init: function(callback, scope) {
				const parentColumnName = this.getParentEntityColumnName();
				this.columns[parentColumnName] = { referenceSchemaName: parentColumnName };
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.FileSearchRowSchema#getParentEntityColumnName
			 * @overridden
			 */
			getParentEntityColumnName: function() {
				return this.get("RecordSchemaName");
			},
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});