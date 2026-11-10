define("DuplicatesRuleSectionV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AccountsDuplicatesSearchCaption: "Show duplicate accounts",
		ActionsButtonCaption: "Actions",
		AddChartButtonCaption: "New chart",
		AddDynamicFolderButtonCaption: "Dynamic",
		AddFolderButtonCaption: "New folder",
		AddQuickFilter: "Add filter",
		AddRecordButtonCaption: "New",
		AddStaticFolderButtonCaption: "Static",
		AnalyticsDataViewCaption: "Open dashboards",
		BackButtonHint: "Show vertical view",
		BeginProcessButtonMenuItemCaption: "Start process",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ChartListHeaderCaption: "Charts",
		CloseButtonCaption: "Close",
		CombinedModeTagsButtonHint: "Tags",
		ContactsDuplicatesSearchCaption: "Show duplicate contacts",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DashboardsDataViewHint: "Dashboards",
		DeleteChart: "Are you sure that you want to delete the selected items?",
		DeleteChartButtonCaption: "Delete",
		DeleteConfirmationMessage: "Business processes may be using this rule. Delete the rule now?",
		DeleteRecordButtonCaption: "Delete",
		DiscardChangesButtonCaption: "Cancel",
		DuplicatesActionCaptionPattern: "Show duplicate \u0027{0}\u0027",
		EditChartButtonCaption: "Edit",
		EditRightsCaption: "Set up access rights",
		EmptyDynamicGroupDescription: "Clear the filter or change its conditions.",
		EmptyDynamicGroupRecommendation: "",
		EmptyDynamicGroupTitle: "There are no records matching the group settings.",
		EmptyFilterDescription: "Clear the filter or change its conditions.",
		EmptyFilterRecommendation: "",
		EmptyFilterTitle: "There are no records matching the filter criteria.",
		EmptyGroupDescription: "Add records to the group.",
		EmptyGroupRecommendation: "Learn more about this feature from the {0}Academy{1}.",
		EmptyGroupTitle: "The selected static folder is empty.",
		EmptyInfoDescription: "Add a new record to make it look prettier.",
		EmptyInfoRecommendation: "Learn more about this section from the {0}Academy{1}.",
		EmptyInfoTitle: "This section has no records.",
		ExcludeFromFolderButtonCaption: "Exclude from folder",
		ExportListToExcelFileButtonCaption: "Export to Excel",
		ExportListToFileButtonCaption: "Export list to file",
		FiltersCaption: "Filter",
		FindDuplicatesButtonCaption: "Find duplicates",
		GridDataViewCaption: "Open records list",
		GroupMenuItemCaption: "Group",
		HideLeftPanelButtonCaption: "Hide section panel",
		HideVerticalViewButtonHint: "Hide vertical view",
		IncludeInFolderButtonCaption: "Add to folder",
		ListDataViewHint: "List",
		MoveDownMenuItemCaption: "Down",
		MoveUpMenuItemCaption: "Up",
		MultiDeleteConfirmationMessage: "Are you sure that you want to delete the selected records?",
		MultiTagButtonCaption: "Add tag",
		NotPossibleDeleteRuleCaption: "You are attempting to delete deduplication rules for searching contacts and accounts that are similar to leads. These rules cannot be deleted. You can deactivate these rules by clearing the [Active] checkbox.",
		OpenAnalyticsViewButtonCaption: "Analytics",
		OpenChangeLogMenuCaption: "View change log",
		OpenGridSettingsCaption: "Select fields to display",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new section wizard",
		OpenObjectChangeLogSettingsCaption: "Change log setup",
		OpenPageDesignerButtonCaption: "Open page designer",
		OpenSectionDesignerButtonCaption: "Open section wizard",
		OpenSummarySettingsModuleButtonCaption: "Set up summaries",
		OperationAccessDenied: "Current user does not have sufficient permissions to run \u0022{0}\u0022",
		PrintButtonCaption: "Print",
		PrintFormButtonCaption: "Printables",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QueryOptimizationFailedRecommendation: "Please try changing the filter parameters or contact technical support.",
		QueryOptimizationFailedTitle: "Unfortunately, your filter could not be processed within the time allotted.",
		QuickAddButtonHint: "Add related activity",
		ReExecuteMessage: "We are doing our best to optimize your filter. This will not take long.",
		ReportListHeaderCaption: "Reports",
		ReportsButtonCaption: "Reports",
		RunProsessButtonCaption: "Run process",
		SaveRecordButtonCaption: "Save",
		ScheduleCaption: "Setup automatic duplicates search",
		ScrollTopCaption: "Up",
		SectionQuickFilterButtonCaption: "Quick filter",
		SelectAllButtonCaption: "Select all",
		SelectedFolderButtonCaption: "Folders",
		SelectMultipleRecordsButtonCaption: "Select multiple records",
		SelectOneRecordButtonCaption: "Cancel multiple selection",
		ShowAllFoldersButtonCaption: "Show all folders",
		ShowRightPanelButtonCaption: "Show notification panel",
		SortButtonCaption: "Sort by",
		SortMenuCaption: "Sort by",
		SubscribeCaption: "Follow the feed",
		UnGroupMenuItemCaption: "Ungroup",
		UnselectAllButtonCaption: "Deselect all",
		UnsubscribeCaption: "Unfollow the feed",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		GridDataViewIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "GridDataViewIcon",
				hash: "12f77829d9767e323f3647457abf613a",
				resourceItemExtension: ".svg"
			}
		},
		AnalyticsDataViewIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "AnalyticsDataViewIcon",
				hash: "58d3027ef6c189ae1dd2c620dd8fd5aa",
				resourceItemExtension: ".svg"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		SettingsButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "SettingsButtonImage",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		scrollTopImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "scrollTopImage",
				hash: "52622a79696db738ae72bc9dfa12145c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "EmptyInfoImage",
				hash: "0d2fe46bac31005b30ea5fb6de3b4984",
				resourceItemExtension: ".png"
			}
		},
		EmptyFilterImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "EmptyFilterImage",
				hash: "3248a9cf95a581e7e6ae5aeb707b65fc",
				resourceItemExtension: ".png"
			}
		},
		EmptyGroupImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "EmptyGroupImage",
				hash: "16c045758fe4edc986284cfacdb02e15",
				resourceItemExtension: ".png"
			}
		},
		EmptyDynamicGroupImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "EmptyDynamicGroupImage",
				hash: "1f97569ae955297876975bfff3677890",
				resourceItemExtension: ".png"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		ToggleSectionButton: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "ToggleSectionButton",
				hash: "7e47411934e85e6cf9834ebc72cff3e6",
				resourceItemExtension: ".svg"
			}
		},
		ExportToExcelBtnImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "ExportToExcelBtnImage",
				hash: "1883b16fe86f1acadfc158894338fc09",
				resourceItemExtension: ".svg"
			}
		},
		SortIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "SortIcon",
				hash: "c0d8dfe7b1416f4c916f1d82523355ae",
				resourceItemExtension: ".svg"
			}
		},
		SummariesIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "SummariesIcon",
				hash: "f1f5f60ee306afca15aa461aac0fdad8",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		DataLoadFailedImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "DataLoadFailedImage",
				hash: "addbd12b1b53bcb56b1580c71598f4e6",
				resourceItemExtension: ".svg"
			}
		},
		AddTagsButtonImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "AddTagsButtonImage",
				hash: "c4683cf6e3fd3e28b391ff180a9c9c3d",
				resourceItemExtension: ".svg"
			}
		},
		ShowDuplicatesBtnImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "ShowDuplicatesBtnImage",
				hash: "fa120a8db42142879bc508b69c6a5993",
				resourceItemExtension: ".svg"
			}
		},
		ObjectChangeLogSettingsBtnImage: {
			source: 3,
			params: {
				schemaName: "DuplicatesRuleSectionV2",
				resourceItemName: "ObjectChangeLogSettingsBtnImage",
				hash: "f0169f1a725a65ec76c564d5e9705277",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});