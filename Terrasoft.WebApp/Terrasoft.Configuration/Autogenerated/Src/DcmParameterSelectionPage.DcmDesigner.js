define("DcmParameterSelectionPage", ["DcmParameterSelectionPageResources"],
        function() {

		return {
			methods: {
				/**
				 * @inheritdoc Terrasoft.MappingPageTabUtilities#getAllTabsConfig
				 * @overridden
				 */
				getAllTabsConfig: function() {
					var mappingType = this.get("MappingType");
					var tabsConfig = this.mixins.mappingPageTabUtilities.getAllTabsConfig();
					if (mappingType && mappingType === Terrasoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS) {
						return this.getElementParametersTabConfig(tabsConfig);
					}
					return this.getTabsConfig(tabsConfig);
				},

				/**
				 * Extracts and returns element parameters property with changed module name from all tabs config.
				 * @private
				 * @return {Object} Element parameters tab config.
				 */
				getElementParametersTabConfig: function(tabsConfig) {
					var config = {};
					var elementParametersProperty =
						tabsConfig[Terrasoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS];
					elementParametersProperty.ModuleName = "DcmElementParametersMappingModule";
					config[Terrasoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS] = elementParametersProperty;
					return config;
				},

				/**
				 * Returns tabs config for Dcm designer mapping window.
				 * @private
				 * @return {Object} Dcm designer tabs config.
				 */
				getTabsConfig: function(tabsConfig) {
					delete tabsConfig[Terrasoft.MappingEnums.MappingType.PROCESS_PARAMETERS];
					return tabsConfig;
				},

				/**
				 * @inheritdoc Terrasoft.ProcessMappingPage#isSingleTab
				 * @overridden
				 */
				isSingleTab: function() {
					return true;
				}
			}
		};

	});
