/**
 */
Ext.define("Terrasoft.Designers.PackageDependenciesDiagramViewModelNew", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModelNew",
	alternateClassName: "Terrasoft.PackageDependenciesDiagramViewModelNew",

	mixins: {
		packageDependenciesDiagramMixin: "Terrasoft.PackageDependenciesDiagramMixin"
	},

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		this.mixins.customEvent.init();
		this.set("DiagramConfig", this.getDiagramConfig());
		this.mixins.packageDependenciesDiagramMixin.init.apply(this, arguments);
	}

	//endregion

});
