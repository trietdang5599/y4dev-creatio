Ext.define("Terrasoft.Designers.ProcessSchemaDesignerLogNew", {
	extend: "Terrasoft.ProcessSchemaDesignerLog",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerLogNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#schemaDiagramClassName
	 * @override
	 */
	schemaDiagramClassName: "Terrasoft.ProcessDiagramComponent",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.ProcessSchemaDesignerLogViewModelNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#getDiagramConfig
	 * @override
	 */
	getDiagramConfig: function() {
		const baseConfig = this.callParent(arguments);
		const config = {
			...baseConfig,
			diagramConfig: {
				bindTo: "DiagramConfig"
			}
		};
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#onAfterDesignerRender
	 * @override
	 */
	onAfterDesignerRender: function() {
		this.callParent(arguments);
		this.diagram.initDiagram();
	}

});
