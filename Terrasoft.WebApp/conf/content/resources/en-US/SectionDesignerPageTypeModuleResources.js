define("SectionDesignerPageTypeModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		RecordTypePlaceholder: "Record type",
		AddButtonCaption: "New",
		RecordsTypeCaption: "Record types",
		TypeColumnCaption: "Field contains information about the record type",
		DuplicatedTypeNames: "Duplicated record type",
		OnChangeTypeColumnMessage: "All changes will be lost. Continue?",
		CanNotDeleteMessage: "Existing item cannot be deleted",
		EmptyPagesError: "Page types must be specified",
		UpCaption: "Up",
		DownCaption: "Down",
		SaveCaption: "Save",
		CancelCaption: "Cancel",
		AddNewMenuItemCaption: "New record",
		CanNotAddNewMessage: "New records can be added to the \u0022{0}\u0022 object only from lookup",
		ExistingRecordsSeparatorCaption: "Existing records"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ItemEditApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "SectionDesignerPageTypeModule",
				resourceItemName: "ItemEditApplyButtonImage",
				hash: "88768289520a58c95c434b7c53ee902c",
				resourceItemExtension: ".png"
			}
		},
		ItemEditCancelButtonImage: {
			source: 3,
			params: {
				schemaName: "SectionDesignerPageTypeModule",
				resourceItemName: "ItemEditCancelButtonImage",
				hash: "6b52043212121498b71de79e64530a21",
				resourceItemExtension: ".png"
			}
		},
		ItemDeleteButtonImage: {
			source: 3,
			params: {
				schemaName: "SectionDesignerPageTypeModule",
				resourceItemName: "ItemDeleteButtonImage",
				hash: "a1a526065b7bb9a46be1b04979c230b0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});