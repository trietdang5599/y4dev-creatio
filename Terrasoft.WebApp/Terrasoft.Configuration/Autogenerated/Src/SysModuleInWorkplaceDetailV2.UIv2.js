define("SysModuleInWorkplaceDetailV2", [], function() {
	return {
		properties: {
			/**
			 * @inheritdoc SysModuleInWorkplaceDetailV2#hiddenModuleCodes
			 * @override
			 */
			hiddenModuleCodes: ["SysAdminOperation", "SysAdminUnit", "FuncRoles", "VwSysDcmLib", "OAuth20App"],

			/**
			 * @inheritdoc SysModuleInWorkplaceDetailV2#sspHiddenModuleCodes
			 * @override
			 */
			sspHiddenModuleCodes: ["Contact", "Account", "Activity"]
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
