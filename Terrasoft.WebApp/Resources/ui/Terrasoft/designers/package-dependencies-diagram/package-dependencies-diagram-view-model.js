/**
 */
Ext.define("Terrasoft.Designers.PackageDependenciesDiagramViewModel", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModel",
	alternateClassName: "Terrasoft.PackageDependenciesDiagramViewModel",

	mixins: {
		packageDependenciesDiagramMixin: "Terrasoft.PackageDependenciesDiagramMixin"
	},

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		this.mixins.packageDependenciesDiagramMixin.init.apply(this, arguments);
	}

	//endregion

});
