define("MiniPageDesignerViewModelGenerator", ["ViewModelSchemaDesignerViewModelGenerator"], function() {

	/**
	 * Mini page designer view model generator.
	 */
	Ext.define("Terrasoft.configuration.MiniPageDesignerViewModelGenerator", {
		extend: "Terrasoft.configuration.ViewModelSchemaDesignerViewModelGenerator",
		alternateClassName: "Terrasoft.MiniPageDesignerViewModelGenerator"
	});

	return Terrasoft.MiniPageDesignerViewModelGenerator;
});
