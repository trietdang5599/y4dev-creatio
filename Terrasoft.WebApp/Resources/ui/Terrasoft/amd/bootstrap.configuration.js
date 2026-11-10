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
			"configuration-bootstraps": Terrasoft.coreModulesPath + "Terrasoft/amd/configuration-bootstraps"
		},
		shim: {
			"ext-base": {
				exports: "Ext"
			}
		}
	});
}
requirejs.config({
	paths: {
		"two-fa": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/amd/two-factor/two-fa-app",
		"two-fa-styles": Terrasoft.workspaceBaseUrl + "/core/hash/Terrasoft/amd/two-factor/styles"
	}
});
require(["configuration-loader"], function(configurationLoader) {
		configurationLoader.load("ViewModuleWrapper", () => {
			if (Terrasoft.isAngularHost) {
				const event = new Event('7xLoaded');
				document.dispatchEvent(event);
			}
		});
});
