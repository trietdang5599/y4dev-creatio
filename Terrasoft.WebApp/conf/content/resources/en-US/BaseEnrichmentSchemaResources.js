define("BaseEnrichmentSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MaskLoadingCaption: "Data search is in process. It can take several seconds.",
		CloseButtonCaption: "Close",
		SaveButtonCaption: "Save",
		SaveButtonHint: "Add all selected data to the account profile",
		RefreshButtonHint: "Search new data for enrichment",
		InternalServiceError: "Could not connect to Creatio Enrichment service. Internal error.\nPlease contact Creatio support.",
		AuthServiceError: "Could not connect to Creatio Enrichment service. Authentication error.\nPlease contact Creatio support."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "BaseEnrichmentSchema",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		},
		RefreshIcon: {
			source: 3,
			params: {
				schemaName: "BaseEnrichmentSchema",
				resourceItemName: "RefreshIcon",
				hash: "b6db25ca695ff69f5e479a3e2c967918",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});