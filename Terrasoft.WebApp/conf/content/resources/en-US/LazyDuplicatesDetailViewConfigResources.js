define("LazyDuplicatesDetailViewConfigResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MaxDuplicatesPerRecordErrorMsqTpl: "More than {0} takes were found for this record. To submit other duplicates, please process those already found.",
		LoadAllGroupHintText: "The button will active after the list of all duplicates is displayed."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});