Terrasoft.configuration.Structures["FolderManagerView"] = {innerHierarchyStack: ["FolderManagerView"]};
define("FolderManagerView", ["FolderManagerViewConfigGenerator"], function() {
	return {
		generate: function() {
			var folderManagerViewConfigGenerator = Ext.create("Terrasoft.FolderManagerViewConfigGenerator");
			return folderManagerViewConfigGenerator.generate();
		}
	};
});


