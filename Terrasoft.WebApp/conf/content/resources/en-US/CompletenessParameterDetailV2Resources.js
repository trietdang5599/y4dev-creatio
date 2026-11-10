define("CompletenessParameterDetailV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		TotalCaption: "Total:",
		PercentageCaption: "{0}%",
		DetailName: "Detail \u0022{0}\u0022",
		AttributeColumnCaption: "Attribute",
		PercentageMoreThenHundredMessage: "The value cannot be greater than 100",
		PercentageMoreLessZeroMessage: "The value cannot be less than 0",
		PercentageMoreLessValidMessage: "Specify value from 1 to {0}",
		TotalPercentageMoreThenHundredMessage: "Unable to add the new record: the lookup data population percentage is 100%.",
		TypedDetailName: "Detail \u0022{0}\u0022 - {1}",
		ActionsButtonCaption: "Actions",
		AddButtonCaption: "New",
		Caption: "Attributes",
		CopyMenuCaption: "Copy",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected record?",
		DeleteMenuCaption: "Delete",
		DetailWizardMenuCaption: "Detail setup",
		EditMenuCaption: "Edit",
		ExportListToExcelFileButtonCaption: "Export to Excel",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		LoadMoreButtonCaption: "Show more",
		MasterRecordIdErrorMessage: "MasterRecordId parameter is not initialized in {0} detail, with hash {1}",
		MultiDeleteConfirmationMessage: "Are you sure that you want to delete the selected records?",
		MultiModeMenuCaption: "Select multiple records",
		OpenObjectChangeLogSettingsCaption: "Change log setup",
		OpenRecordChangeLogCaption: "View change log",
		OperationAccessDenied: "Current user does not have sufficient permissions to run \u0022{0}\u0022",
		ProcessButtonHint: "Run process by record",
		QuickFilterCaption: "Apply filter",
		RecordRightsSetupMenuItemCaption: "Set up access rights",
		RelationshipButtonHint: "By the child connections",
		RemoveQuickFilterCaption: "Hide filter",
		SchemaLocalizableString1: "",
		SetupGridMenuCaption: "Columns setup",
		SetupTotalMenuCaption: "Summaries setup",
		SingleModeMenuCaption: "Cancel multiple selection",
		SortMenuCaption: "Sort by",
		ToolsButtonHint: "Actions",
		ViewButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		LoadMoreIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "LoadMoreIcon",
				hash: "d757aaf069c75446184760d4935622e9",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "AddButtonImage",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "ToolsButtonImage",
				hash: "48d545549ca4ddb13d7a7bb58f60ed5e",
				resourceItemExtension: ".svg"
			}
		},
		RelationshipButtonImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "RelationshipButtonImage",
				hash: "0c19637a3f87200944f7330b499d7c8c",
				resourceItemExtension: ".png"
			}
		},
		RemoveIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "RemoveIcon",
				hash: "bd597784a7b16552632811674f869a11",
				resourceItemExtension: ".png"
			}
		},
		SaveIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "SaveIcon",
				hash: "575a68319ee12f0eeea80d5e96d20b8c",
				resourceItemExtension: ".png"
			}
		},
		CancelIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "CancelIcon",
				hash: "4d7e95ef8492814296ac405a885ad87f",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		ExportToExcelBtnImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "ExportToExcelBtnImage",
				hash: "1883b16fe86f1acadfc158894338fc09",
				resourceItemExtension: ".svg"
			}
		},
		ImageFilter: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "ImageFilter",
				hash: "ef37ab38ddacefd3ba86c6bbcf4e7501",
				resourceItemExtension: ".svg"
			}
		},
		SortIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "SortIcon",
				hash: "f5e0b50ec74a47fb66f7d7d403b760c3",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "GridSettingsIcon",
				hash: "3f4eb707ce7f259fce295490879a8f9b",
				resourceItemExtension: ".svg"
			}
		},
		FilterIcon20: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "FilterIcon20",
				hash: "124f910abe91ebe4045613a9c5b379d1",
				resourceItemExtension: ".svg"
			}
		},
		ObjectChangeLogSettingsBtnImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "ObjectChangeLogSettingsBtnImage",
				hash: "f0169f1a725a65ec76c564d5e9705277",
				resourceItemExtension: ".svg"
			}
		},
		OpenRecordChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "CompletenessParameterDetailV2",
				resourceItemName: "OpenRecordChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});