define("AccessRightsDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DeleteButton: "Delete",
		OperationTypeCaption: "Operation",
		SysAdminUnitCaption: "User/role"
	};
	var parametersLocalizableStrings = {
		RecordId: "RecordId",
		RightsSchemaName: "Schema Name",
		AccessRightsType: "AccessRightsType",
		AccessRightsValue: "Access Rights Value",
		ShowExpands: "ShowExpands"
	};
	var propertiesLocalizableStrings = {
		Caption: "Access Rights detail"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});