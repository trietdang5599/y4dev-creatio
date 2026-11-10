define("UserManagementModule", ["ext-base", "terrasoft", "sandbox"],
		function(Ext, Terrasoft, sandbox) {

	var defaultRegistrationModuleName = "Registration";
	var getRegistrationModuleName = function() {
		return Ext.String.trim(window.portalRegistrationModuleName || "") || defaultRegistrationModuleName;
	};

	var loadRegistrationModule = function(renderTo) {
		sandbox.loadModule(getRegistrationModuleName(), {
			renderTo: renderTo,
			id: sandbox.id + "-Registration",
			keepAlive: true
		});
	};

	var render = function(renderTo) {
		switch (Terrasoft.action) {
			case "register":
				loadRegistrationModule(renderTo);
				break;
			case "remindPassword":
				sandbox.loadModule("RemindPassword", {
					renderTo: renderTo,
					id: sandbox.id + "-RemindPassword",
					keepAlive: true
				});
				break;
		}
	};

	return {
		render: render,
		renderTo: Ext.getBody()
	};
});

