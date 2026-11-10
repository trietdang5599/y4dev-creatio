define("ProcessElementParametersMappingModule", ["BaseProcessParametersEditModule"], function() {

	Ext.define("Terrasoft.configuration.ProcessElementParametersMappingModule", {
		alternateClassName: "Terrasoft.ProcessElementParametersMappingModule",
		extend: "Terrasoft.BaseProcessParametersEditModule",

		_compositeObjectMappingTypes: [
			Terrasoft.MappingEnums.MappingType.COMPOSITE_OBJECT_CONFIGURATION
		],

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			const mappingType = this.initialConfig.parameters.viewModelConfig.MappingType;
			this.schemaName = this._compositeObjectMappingTypes.includes(mappingType)
				? "CompositeObjectConfigurationPage"
				: "ProcessElementParametersMappingPage";
		},

		/**
		 * @inheritdoc Terrasoft.BaseProcessParametersEditModule#initParametersInfo
		 * @overridden
		 */
		initParametersInfo: function() {
			this.parametersInfo = {};
		}
	});
	return Terrasoft.ProcessElementParametersMappingModule;
});
