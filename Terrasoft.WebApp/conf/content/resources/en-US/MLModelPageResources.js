define("MLModelPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		TrainModelActionCaption: "Train model",
		TrainModelActionSucceedMessage: "Action has succeeded. Current session state: {0}",
		TrainModelActionFailedMessage: "Action has failed. You can find more details in the application log",
		ModelSettingsTabCaption: "Parameters",
		TrainingTabCaption: "Training",
		StatsTabCaption: "Usage statistics",
		NotesTabCaption: "Attachments and notes",
		ChooseObjectStepCaption: "STEP 1. Choose entity for prediction",
		AdvancedQuerySettingsGroupCaption: "Advanced tools to add columns",
		TrainingSettingsGroupCaption: "Automatic model training settings",
		ChooseObjectStepTipCaption: "Prediction will be performed for this object",
		AdvancedQuerySettingsGroupInfoButtonContent: "Optional select query for columns to be included in prediction calculation. \u003Ca target=\u0022_blank\u0022 rel=\u0022noopener noreferrer\u0022 href=\u0022https://academy.creatio.com/docs/node/1387\u0022\u003ERead more...\u003C/a\u003E",
		TrainingSettingsInfoButtonCaption: "Set model update parameters. Prediction quality may degrade over time.",
		RootEntityCaption: "Entity",
		FAQContainerCaption: "Frequently asked questions",
		RetrainLabelCaption: "Retrain after, days",
		TrainModelActionTimedOutMessage: "Training schedule takes some time, try again in few minutes",
		PedictionEnabledTip: "Enable/disable model prediction. To set up repeat model retraining use the field [Retrain after, days].",
		RetrainTip: "Enter number of days the model will be automatically retrained. If you need to disable model retraining, set the value to 0.",
		LowerMetricTip: "Enter lower limit beyond which the model is deemed unuseful.",
		TrainModelActionWrongConfigMessage: "Configuration error. Check values of system setting \u0022Cloud service API key\u0022 and filled [Service endpoint Url] in [ML problem type] lookup",
		PredictionSettingsStepCaption: "STEP 3. Set up prediction",
		PredictionSettingsStepTipCaption: "Visit our Academy to learn more about \u003Ca href=\u0022https://academy.creatio.com/docs/node/1387\u0022\u003Eselect expression for prediction\u003C/a\u003E",
		AddRootSchemaMenuItemCaption: "Object\u0027s columns",
		TrainingQueryFieldsGroupCaption: "Which columns does the predicted value depend on?",
		TrainingQueryFieldsGroupInfoButtonContent: "Creatio will determine the patterns between the values of these columns and the predicted value. These patterns will be used in prediction",
		TargetColumnGroupCaption: "What value should be predicted?",
		TargetColumnGroupInfoButtonContent: "Training dataset column that contains the predicted value (result)",
		FilterForTrainingGroupCaption: "Which records should be included in the training dataset?",
		PredictedResultColumnGroupCaption: "What column to use for saving prediction result?",
		PredictedResultColumnGroupInfoButtonContent: "Select column where to save the result",
		BatchPredictionSettingsGroupCaption: "Setting up background update of prediction results",
		TargetColumnGroup_Filters_Caption: "What records to be considered as successful?",
		TargetColumnGroupInfoButton_Filters_Content: "Filter which defines records with a successful scoring result in training dataset",
		NoData: "No data available",
		RootSchemaNotSet: "Object not selected",
		BatchPredictionStartMethodToggleEditCaption: "Perform background update of prediction results daily during the maintenance window",
		PredictionTabCaption: "Prediction",
		SavePageConfirmation: "All changes will be saved. Continue?",
		TrainModelButtonCaption_Finished: "Retrain model",
		TrainModelButtonCaption_InProgress: "Training",
		TrainModelButtonCaption_NotStarted: "Train model",
		TrainingStatusNotificationTitle: "Training finished",
		BatchPredictionFilterLabelCaption: "Update all records that match condition",
		AutomaticRetrainToggleEditCaption: "Update model automatically",
		AddRootSchemaLinkedColumnCaption: "Linked column",
		TopFeaturesCaption: "Top model parameters trained on {0}",
		NoTrainingData: "Train the model to get parameters weight information",
		PredictiveAnalysisAcademyCaption: "Predictive analysis",
		ClassificationAcademyCaption: "How to create a lookup value prediction model",
		ScoringAcademyCaption: "How to add predictive score to records",
		RegressionAcademyCaption: "How to create a numeric value prediction model",
		RecommendationAcademyCaption: "How to create recommendation system model",
		BusinessProcessAcademyCaption: "How to use machine learning models",
		MLServiceAcademyCaption: "Machine learning service",
		AdvancedSettingsGroupCaption: "Advanced settings",
		AdvancedModelParametersGroupCaption: "Advanced model parameters",
		ParametersAutofittingTipContent: "We automatically fit parameters for the training model with the highest quality. For the more accurate parameter fitting, you can set the list of the possible parameters",
		AdvancedModelSettingsTabCaption: "Advanced settings",
		PredictiveAnalysisAcademyUrl: "https://academy.creatio.com/node/620681/takecourse",
		ConsultationBannerButtonCaption: "Request consultation",
		ConsultationBannerText: "Receive comprehensive assistance from Creatio experts",
		ConsultationBannerTitle: "Request consultation",
		TrainModelButtonCaption_DataTransferring: "Data transferring",
		TrainErrorTextTitle: "Errors found in the analysis of the training set",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		EditRightsCaption: "Set up access rights",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		NewRecordPageCaptionSuffix: ": New record",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenChangeLogMenuCaption: "View change log",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		TagButtonHint: "Tags",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		FAQIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "FAQIcon",
				hash: "1875f36f0da7a2086f1ac06444c432be",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		ClearIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "ClearIcon",
				hash: "eea0fb9df467079344db40e55b70b743",
				resourceItemExtension: ".png"
			}
		},
		ClearIconHover: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "ClearIconHover",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		AddColumnMenuIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "AddColumnMenuIcon",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		MLIcon: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "MLIcon",
				hash: "863f66ffaff7bc0ceaa6aadc9c2491ae",
				resourceItemExtension: ".png"
			}
		},
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "EmptyInfoImage",
				hash: "0d2fe46bac31005b30ea5fb6de3b4984",
				resourceItemExtension: ".png"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		},
		ConsultationBanner: {
			source: 3,
			params: {
				schemaName: "MLModelPage",
				resourceItemName: "ConsultationBanner",
				hash: "1c6e32c94691eed051d92f765b0fad0c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});