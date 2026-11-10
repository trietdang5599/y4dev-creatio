Ext.define("Terrasoft.Designers.DcmSchemaDesignerLogNew", {
	extend: "Terrasoft.ProcessSchemaDesignerLogNew",
	alternateClassName: "Terrasoft.DcmSchemaDesignerLogNew",

	/**
	 * @override
	 * @protected
	 */
	getDiagramConfig: function() {
		const baseConfig = this.callParent(arguments);
		return {
			...baseConfig,
			readOnly: false
		};
	}
});
