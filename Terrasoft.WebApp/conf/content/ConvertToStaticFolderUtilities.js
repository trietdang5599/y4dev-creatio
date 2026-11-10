Terrasoft.configuration.Structures["ConvertToStaticFolderUtilities"] = {innerHierarchyStack: ["ConvertToStaticFolderUtilities"]};
 define("ConvertToStaticFolderUtilities", ["ServiceHelper", "ConvertToStaticFolderUtilitiesResources"], 
		function(ServiceHelper, resources) {
	Ext.define("Terrasoft.configuration.ConvertToStaticFolderUtilities", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.ConvertToStaticFolderUtilities",

		//region Methods: Public

		/**
		 * Convert static folder to dynamic.
		 * @param {Object} serviceData Parameters for convert folder.
		 * @param {String} serviceData.newFolderId New static folder Id.
		 * @param {String} serviceData.parentFolderId Search folder Id.
		 * @param {String} serviceData.entitySchemaName Entity schema name.
		 * @param {Object} scope Scope of invoke.
		 */
		callConvertToStaticFolderService: function(serviceData, scope) {
			ServiceHelper.callService({
				serviceName: "FolderManagerService",
				methodName: "ConvertToStaticFolder",
				callback: function() {
					scope.showInformationDialog(resources.localizableStrings.ConvertToStaticFolderMsg);
				},
				scope: scope,
				data: serviceData
			}, scope);
		}	

		//endregion
	});

	return Ext.create("Terrasoft.ConvertToStaticFolderUtilities");
});


