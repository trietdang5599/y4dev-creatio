(function() {
	if (typeof Ext !== "undefined") {
		define("ext-base", [], function() {
			return Ext;
		});
		define("core-modules", [], function() {
			return false;
		});
	} else {
		requirejs.config({
			paths: {
				"ext-base": "../../ExtJs/extjs-base-debug",
				"login-view-utils": Terrasoft.workspaceBaseUrl + '/core/hash/Terrasoft/amd/login-view-utils',
				"login-model-utils": Terrasoft.workspaceBaseUrl + '/core/hash/Terrasoft/amd/login-model-utils',
				"open-id-start-sso-client-provider":
					Terrasoft.workspaceBaseUrl +
					'/core/hash/Terrasoft/utils/sso/providers/open-id-start-sso-client-provider'
			},
			shim: {
				"ext-base": {
					exports: "Ext"
				}
			}
		});
	}

	require(["core-modules", "core-base"], function(coreModules, core) {
		const configurationModulesConfig = {};
		const requireBaseUrl = Terrasoft.loaderBaseUrl;
		core.init(coreModules, configurationModulesConfig, requireBaseUrl);
		Terrasoft.configuration = Terrasoft.configuration || {};
		Terrasoft.configuration.RootSchemaDescriptors = {
			openIdLoginModule: {
				"path": Terrasoft.loginModulePath,
				"less": ["openIdLoginModule"]
			}
		};
		core.setModuleDescriptors(Terrasoft.configuration.RootSchemaDescriptors);
		core.loadModule("openIdLoginModule");
	});
})();
