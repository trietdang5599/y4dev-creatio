define("SectionActionsDashboard", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		methods: {
			/**
			 * Init approval dashboard.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initApprovalActionsDashboard: function(callback, scope) {
				this.callParent([function() {
					const approvalSchemaName = this.get("ApprovalSchemaName") || ConfigurationConstants.SysApproval.SchemaName;
					const approvalReferenceColumnName = this.get("ApprovalReferenceColumnName") || ConfigurationConstants.SysApproval.MasterColumnName;
					this.set("ApprovalSchemaName", approvalSchemaName);
					this.set("ApprovalReferenceColumnName", approvalReferenceColumnName);
					this.Ext.callback(callback, scope, []);
				}, this]);
			}	
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
