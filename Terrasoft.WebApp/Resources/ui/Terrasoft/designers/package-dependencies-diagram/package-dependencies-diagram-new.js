/**
 * A class diagram of package dependencies.
 */
Ext.define("Terrasoft.Designers.PackageDependenciesDiagramNew", {
	extend: "Terrasoft.ProcessSchemaDesignerLogNew",
	alternateClassName: "Terrasoft.PackageDependenciesDiagramNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.PackageDependenciesDiagramViewModelNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLog#getDiagramConfig
	 * @override
	 */
	getDiagramConfig: function() {
		const baseConfig = this.callParent(arguments);
		return {
			...baseConfig,
			classes: {
				...baseConfig.classes,
				wrapClassName: [...baseConfig.classes.wrapClassName, "package-dependencies-diagram"]
			},
			straightConnection: true
		};
	}

});
