(function(global) {
	var define = global.define;
	if (define) {
		define(function() {
			if (Terrasoft?.preLoadedFeatures?.LoadTsDiagram ? Terrasoft?.preLoadedFeatures?.LoadTsDiagram.state : false) {
				require.config({
					paths: {
						"ts-common-all": Terrasoft.getFileContentUrl("TsDiagram", "src/js/ts-common-all.js"),
						"ts-diagram": Terrasoft.getFileContentUrl("TsDiagram", "src/js/ts-diagram.js"),
						"ts-diagram-css": Terrasoft.getFileContentUrl("TsDiagram", "src/css/ts-diagram.css")
					},
					deps: [
						"css!ts-diagram-css"
					]
				});
			}
		});
	}
})(window);