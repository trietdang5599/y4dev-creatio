define("TimelineSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OrderDirectionCaption: "Date",
		EmptyInfoTitle: "There are no records in history.",
		EmptyInfoDescription: "Unfortunately, there is no history of work on this record in Creatio.",
		EmptyFilterTitle: "There are no records matching the filter criteria in history.",
		EmptyFilterDescription: "Clear the filter or change its conditions."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		OrderDirectionDescIcon: {
			source: 3,
			params: {
				schemaName: "TimelineSchema",
				resourceItemName: "OrderDirectionDescIcon",
				hash: "15d9b96d6eaa3c810de24a9f53861694",
				resourceItemExtension: ".svg"
			}
		},
		OrderDirectionAscIcon: {
			source: 3,
			params: {
				schemaName: "TimelineSchema",
				resourceItemName: "OrderDirectionAscIcon",
				hash: "ce0d4bd2e6d7cb7dbc0c3a984ed86197",
				resourceItemExtension: ".svg"
			}
		},
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "TimelineSchema",
				resourceItemName: "DefaultIcon",
				hash: "58c935fb0f9bff590454c247ae7006e8",
				resourceItemExtension: ".svg"
			}
		},
		EmptyFilterImage: {
			source: 3,
			params: {
				schemaName: "TimelineSchema",
				resourceItemName: "EmptyFilterImage",
				hash: "3248a9cf95a581e7e6ae5aeb707b65fc",
				resourceItemExtension: ".png"
			}
		},
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "TimelineSchema",
				resourceItemName: "EmptyInfoImage",
				hash: "0d2fe46bac31005b30ea5fb6de3b4984",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});