define("PrintableProcessModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NextByProcessConfirm: "Carry on the business process?",
		PrintButtonCaption: "Print",
		NextButtonCaption: "Continue",
		DefHeaderCaption: "Print page"
	};
	var parametersLocalizableStrings = {
		PrintableId: "Printable Id",
		PrintablePackageId: "Id of printables package",
		PrintedRecordId: "Record Id",
		PrintableDescription: "Description"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});