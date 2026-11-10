define("MainHeader8xSchema", [], function () {
	return {
		methods: {},
		diff: [{
			"operation": "remove",
			"name": "RightButtonsContainer"
		}, {
			"operation": "remove",
			"name": "CommandLineContainer"
		}, {
			"operation": "remove",
			"name": "RightLogoContainer"
		}, {
			"operation": "merge",
			"name": "MainHeaderContainer",
			"values": {
				"wrapClass": ["main-header", "angular-shell"]
			}
		}]
	};
});
