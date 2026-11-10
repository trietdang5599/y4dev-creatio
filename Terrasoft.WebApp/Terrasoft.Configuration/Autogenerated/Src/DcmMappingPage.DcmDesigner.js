/**
 * Parent: ProcessMappingPage
 */
define("DcmMappingPage", ["terrasoft", "DcmMappingPageResources"], function() {

	return {
		methods: {
			/**
			 * @inheritdoc Terrasoft.MappingPageTabUtilities#getAllTabsConfig
			 * @overridden
			 */
			getAllTabsConfig: function() {
				var tabsConfig = this.mixins.mappingPageTabUtilities.getAllTabsConfig();
				var mappingTypeEnum = Terrasoft.MappingEnums.MappingType;
				delete tabsConfig[mappingTypeEnum.PROCESS_PARAMETERS];
				return tabsConfig;
			}
		}
	};

});
