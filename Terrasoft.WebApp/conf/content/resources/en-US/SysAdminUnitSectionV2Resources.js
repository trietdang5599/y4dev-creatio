define("SysAdminUnitSectionV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SyncronizeWithLDAPButtonCaption: "Synchronize with LDAP",
		SyncProcessIsInBackground: "Users import process started in the background mode",
		RunLDAPSuccessMessage: "The LDAP synchronization process will start in a minute. You will receive a notification upon completion.",
		LicOperationAccessDeniedMessage: "LDAP synchronization failed. This feature is not available for your Creatio subscription plan. Upgrade your subscription to Enterprise",
		EditionsComparePageButtonCaption: "Compare all plans",
		ActionButtonCaption: "New",
		ActionButtonHint: "Actions",
		ActionsButtonCaption: "Actions",
		ActualizeOrgStructureButtonCaption: "Update roles",
		AddChartButtonCaption: "New chart",
		AddCommandButtonCaption: "Team",
		AddDepartmentButtonCaption: "Division",
		AddDynamicFolderButtonCaption: "Dynamic",
		AddFolderButtonCaption: "New folder",
		AddFuncRoleButtonCaption: "Functional role",
		AddOrganisationButtonCaption: "Organization",
		AddQuickFilter: "Add filter",
		AddRecordButtonCaption: "New",
		AddStaticFolderButtonCaption: "Static",
		AddUserButtonCaption: "User",
		AnalyticsDataViewCaption: "Open dashboards",
		BackButtonHint: "Show vertical view",
		BeginProcessButtonMenuItemCaption: "Start process",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ChangeButtonCaption: "Edit",
		ChartListHeaderCaption: "Charts",
		CloseButtonCaption: "Close",
		CombinedModeTagsButtonHint: "Tags",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DashboardsDataViewHint: "Dashboards",
		DeleteChart: "Are you sure that you want to delete the selected items?",
		DeleteChartButtonCaption: "Delete",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected record?",
		DeleteRecordButtonCaption: "Delete",
		DiscardChangesButtonCaption: "Cancel",
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
		ErrorActionMessage: "Error while performing action.",
		ExcludeFromFolderButtonCaption: "Exclude from folder",
		ExportListToExcelFileButtonCaption: "Export to Excel",
		ExportListToFileButtonCaption: "Export list to file",
		FiltersCaption: "Filter",
		FindDuplicatesButtonCaption: "Find duplicates",
		FunctionalRolesDataViewHint: "Functional roles",
		FunctionalRolesHeader: "Functional roles",
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
		OrganizationalRolesHeader: "Organizational roles",
		OrganizationalStructureDataViewHint: "Organizational roles",
		PrintButtonCaption: "Print",
		PrintFormButtonCaption: "Printables",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QueryOptimizationFailedRecommendation: "Please try changing the filter parameters or contact technical support.",
		QueryOptimizationFailedTitle: "Unfortunately, your filter could not be processed within the time allotted.",
		QuickAddButtonHint: "Add related activity",
		ReExecuteMessage: "We are doing our best to optimize your filter. This will not take long.",
		RemoveButtonCaption: "Delete",
		ReportListHeaderCaption: "Reports",
		ReportsButtonCaption: "Reports",
		RunProsessButtonCaption: "Run process",
		SaveRecordButtonCaption: "Save",
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
		SuccessActionMessage: "Action completed successfully.",
		SyncProcessFail: "Unable to run LDAP synchronization process. Error: {0}",
		UnGroupMenuItemCaption: "Ungroup",
		UnselectAllButtonCaption: "Deselect all",
		UsersDataViewHint: "Users",
		UsersHeader: "Users",
		ViewOptionsButtonCaption: "View",
		RedistributionProcessStartedMessage: "Creatio started license redistribution based on the current settings. You will receive a notification in the communication panel once the process is completed",
		KeepButtonText: "Keep",
		RemoveButtonText: "Remove",
		RemoveManuallyIssuedLicensesQuestion: "Do you want to remove manually distributed licenses during synchronization or keep them issued? ",
		RedistributeLicensesCaption: "Redistribute licenses for the role",
		RedistributeLicencesForAllRolesCaption: "Redistribute licenses for all roles",
		DuplicatesActionCaptionPattern: "Show duplicate \u0027{0}\u0027",
		SubscribeCaption: "Follow the feed",
		UnsubscribeCaption: "Unfollow the feed"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "ToolsButtonImage",
				hash: "ab08a8639d9061e25c46ab0eb562e671",
				resourceItemExtension: ".png"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		OrgRolesIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "OrgRolesIcon",
				hash: "2ba79b15d0a54a4526738a718465d6a2",
				resourceItemExtension: ".png"
			}
		},
		FuncRolesIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "FuncRolesIcon",
				hash: "e2835bf55cbd649828fd49f99ab5ec77",
				resourceItemExtension: ".png"
			}
		},
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		},
		UsersDataViewIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "UsersDataViewIcon",
				hash: "a387913d7c07d9cff466ed28963894f1",
				resourceItemExtension: ".png"
			}
		},
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		ToggleSectionButton: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "ToggleSectionButton",
				hash: "7e47411934e85e6cf9834ebc72cff3e6",
				resourceItemExtension: ".svg"
			}
		},
		ExportToExcelBtnImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "ExportToExcelBtnImage",
				hash: "1883b16fe86f1acadfc158894338fc09",
				resourceItemExtension: ".svg"
			}
		},
		SortIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "SortIcon",
				hash: "c0d8dfe7b1416f4c916f1d82523355ae",
				resourceItemExtension: ".svg"
			}
		},
		SummariesIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "SummariesIcon",
				hash: "f1f5f60ee306afca15aa461aac0fdad8",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		DataLoadFailedImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "DataLoadFailedImage",
				hash: "addbd12b1b53bcb56b1580c71598f4e6",
				resourceItemExtension: ".svg"
			}
		},
		AddTagsButtonImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "AddTagsButtonImage",
				hash: "c4683cf6e3fd3e28b391ff180a9c9c3d",
				resourceItemExtension: ".svg"
			}
		},
		ObjectChangeLogSettingsBtnImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "ObjectChangeLogSettingsBtnImage",
				hash: "f0169f1a725a65ec76c564d5e9705277",
				resourceItemExtension: ".svg"
			}
		},
		ShowDuplicatesBtnImage: {
			source: 3,
			params: {
				schemaName: "SysAdminUnitSectionV2",
				resourceItemName: "ShowDuplicatesBtnImage",
				hash: "fa120a8db42142879bc508b69c6a5993",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});