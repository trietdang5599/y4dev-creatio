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
			"user-agent-parser": Terrasoft.workspaceBaseUrl + "/core/hash/user-agent-parser/user-agent-parser.min",
			"user-agent": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/utils/user-agent",
			"login-view-utils": Terrasoft.workspaceBaseUrl + '/core/hash/Terrasoft/amd/login-view-utils',
			"login-model-utils": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/amd/login-model-utils",
			"two-fa": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/amd/two-factor/two-fa-app",
			"two-fa-styles": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/amd/two-factor/styles"
		},
		shim: {
			"ext-base": {
				exports: "Ext"
			}
		}
	});
}

require(["core-modules", "core-base"], function(coreModules, core) {
	var configurationModulesConfig = {};
	var requireBaseUrl = Terrasoft.loaderBaseUrl;
	core.setScope("login");
	core.init(coreModules, configurationModulesConfig, requireBaseUrl);
	Terrasoft.configuration = Terrasoft.configuration || {};
	Terrasoft.configuration.RootSchemaDescriptors = {
		sspLoginModule: {
			"path": Terrasoft.loginModulePath,
			"less": ["sspLoginModule"]
		}
	};
	core.setModuleDescriptors(Terrasoft.configuration.RootSchemaDescriptors);
	core.loadModule("sspLoginModule");
});
