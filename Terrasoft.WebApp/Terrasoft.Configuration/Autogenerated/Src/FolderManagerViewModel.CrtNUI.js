define("FolderManagerViewModel", ["FolderManagerViewModelConfigGenerator"],
	function() {
		return {
			generate: function(parentSandbox, config) {
				var generator = Ext.create("Terrasoft.FolderManagerViewModelConfigGenerator");
				return generator.generate(parentSandbox, config);
			},
			getFolderViewModelConfig: function() {
				return {};
			}
		};
	});
