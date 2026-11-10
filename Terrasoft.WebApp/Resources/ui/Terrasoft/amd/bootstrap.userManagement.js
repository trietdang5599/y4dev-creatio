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
require(["configuration-loader"], function(configurationLoader) {
	if (Terrasoft.useActionOnUserManagementBootstrap) {
		var script = document.querySelector("script[data-loadbootstrap]");
		var action = script.getAttribute("data-action");
		Terrasoft.action = action;
	}
	configurationLoader.load("UserManagementModule");
});