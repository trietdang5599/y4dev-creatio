define("MLTextSimilarityModelPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ListPredictResultSchemaCaption: "Object",
		ListPredictResultObjectCaption: "Similar object",
		ListPredictResultSubjectCaption: "Similar to (Subject)",
		ResultSavingGroupCaption: "Setting up saving prediction results",
		ListPredictResultDateCaption: "Prediction date",
		ListPredictResultModelCaption: "ML model",
		ListPredictResultValueCaption: "Score",
		SimilarObjectSchemaCaption: "Search for similar to (Subject)",
		SimilarObjectSelectionColumnsGroupCaption: "Search similar values by these columns",
		SimilarObjectColumnSelectionTipText: "Creatio will use these columns of the prediction subject as the criteria when searching for records with similarities",
		TrainingFilterDataInfoButtonText: "The dataset for the training of the \u201Csimilar object\u201D search model. When the training is complete, the model will search for data with similarities only among the entities that are included in this dataset",
		SubjectObjectSchemasTipContent: "Creatio will search the data of the \u201CObject\u201D entity to generate a list of records that have similarities with the record from the \u201CSubject\u201D entity",
		PredictionSchemaCaption: "Search for similar to (Subject)",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		AddRootSchemaLinkedColumnCaption: "Linked column",
		AddRootSchemaMenuItemCaption: "Object\u0027s columns",
		AdvancedModelParametersGroupCaption: "Advanced model parameters",
		AdvancedModelSettingsTabCaption: "Advanced settings",
		AdvancedQuerySettingsGroupCaption: "Advanced tools to add columns",
		AdvancedQuerySettingsGroupInfoButtonContent: "Optional select query for columns to be included in prediction calculation. \u003Ca target=\u0022_blank\u0022 rel=\u0022noopener noreferrer\u0022 href=\u0022https://academy.creatio.com/docs/node/1387\u0022\u003ERead more...\u003C/a\u003E",
		AdvancedSettingsGroupCaption: "Advanced settings",
		AutomaticRetrainToggleEditCaption: "Update model automatically",
		BatchPredictionFilterLabelCaption: "Update all records that match condition",
		BatchPredictionSettingsGroupCaption: "Setting up background update of prediction results",
		BatchPredictionStartMethodToggleEditCaption: "Perform background update of prediction results daily during the maintenance window",
		BeginProcessButtonMenuItemCaption: "Start process",
		BusinessProcessAcademyCaption: "How to use machine learning models",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ChangeQueueItemDateButtonCaption: "Postpone till",
		ChooseObjectStepCaption: "STEP 1. Choose entity for prediction",
		ChooseObjectStepTipCaption: "Prediction will be performed for this object",
		ClassificationAcademyCaption: "How to create a lookup value prediction model",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		EditRightsCaption: "Set up access rights",
		ESNTabCaption: "Feed",
		FAQContainerCaption: "Frequently asked questions",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		FilterForTrainingGroupCaption: "Which records should be included in the training dataset?",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		LowerMetricTip: "Enter lower limit beyond which the model is deemed unuseful.",
		MLServiceAcademyCaption: "Machine learning service",
		ModelSettingsTabCaption: "Parameters",
		MultipleQueueItemsFoundError: "More than one queue element connected to the process. Process Id: {0}",
		NewRecordPageCaptionSuffix: ": New record",
		NoData: "No data available",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		NotesTabCaption: "Attachments and notes",
		NoTrainingData: "Train the model to get parameters weight information",
		OpenChangeLogMenuCaption: "View change log",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		ParametersAutofittingTipContent: "We automatically fit parameters for the training model with the highest quality. For the more accurate parameter fitting, you can set the list of the possible parameters",
		PedictionEnabledTip: "Enable/disable model prediction. To set up repeat model retraining use the field [Retrain after, days].",
		PostponeQueueItemButtonCaption: "Re-queue",
		PostponeQueueItemError: "Unable to re-queue item. Error message: {0}",
		PredictedResultColumnGroupCaption: "What column to use for saving prediction result?",
		PredictedResultColumnGroupInfoButtonContent: "Select column where to save the result",
		PredictionSettingsStepCaption: "STEP 3. Set up prediction",
		PredictionSettingsStepTipCaption: "Visit our Academy to learn more about \u003Ca href=\u0022https://academy.creatio.com/docs/node/1387\u0022\u003Eselect expression for prediction\u003C/a\u003E",
		PredictionTabCaption: "Prediction",
		PredictiveAnalysisAcademyCaption: "Predictive analysis",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QueueItemIsEmptyError: "Page is not connected to the agent desktop queue element. Action cancelled.",
		QueueItemPostponeFailedMessage: "Unable to re-queue item",
		QueueItemPostponeSucceedMessage: "Successfully re-queued",
		QuickAddButtonHint: "Add related activity",
		RecommendationAcademyCaption: "How to create recommendation system model",
		RegressionAcademyCaption: "How to create a numeric value prediction model",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		RetrainLabelCaption: "Retrain after, days",
		RetrainTip: "Enter number of days the model will be automatically retrained. If you need to disable model retraining, set the value to 0.",
		RootEntityCaption: "Search for similar among (Object)",
		RootSchemaNotSet: "Object not selected",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		SavePageConfirmation: "All changes will be saved. Continue?",
		ScoringAcademyCaption: "How to add predictive score to records",
		StatsTabCaption: "Usage statistics",
		SubscribeCaption: "Follow the feed",
		SubscribedInformationDialog: "You are now following feed: {0}",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		TagButtonHint: "Tags",
		TargetColumnGroup_Filters_Caption: "What records to be considered as successful?",
		TargetColumnGroupCaption: "What value should be predicted?",
		TargetColumnGroupInfoButton_Filters_Content: "Filter which defines records with a successful scoring result in training dataset",
		TargetColumnGroupInfoButtonContent: "Training dataset column that contains the predicted value (result)",
		TimelineTabCaption: "Timeline",
		TopFeaturesCaption: "Top model parameters trained on {0}",
		TrainingQueryFieldsGroupCaption: "Which columns does the predicted value depend on?",
		TrainingQueryFieldsGroupInfoButtonContent: "Creatio will use these columns of the prediction object while searching for records with similarities",
		TrainingSettingsGroupCaption: "Automatic model training settings",
		TrainingSettingsInfoButtonCaption: "Set model update parameters. Prediction quality may degrade over time.",
		TrainingStatusNotificationTitle: "Training finished",
		TrainingTabCaption: "Training",
		TrainModelActionCaption: "Train model",
		TrainModelActionFailedMessage: "Action has failed. You can find more details in the application log",
		TrainModelActionSucceedMessage: "Action has succeeded. Current session state: {0}",
		TrainModelActionTimedOutMessage: "Training schedule takes some time, try again in few minutes",
		TrainModelActionWrongConfigMessage: "Configuration error. Check values of system setting \u0022Cloud service API key\u0022 and filled [Service endpoint Url] in [ML problem type] lookup",
		TrainModelButtonCaption_Finished: "Retrain model",
		TrainModelButtonCaption_InProgress: "Training",
		TrainModelButtonCaption_NotStarted: "Train model",
		UnsubscribeCaption: "Unfollow the feed",
		UnsubscribedInformationDialog: "You have stopped following feed: {0}",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		FAQIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "FAQIcon",
				hash: "1875f36f0da7a2086f1ac06444c432be",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		ClearIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "ClearIcon",
				hash: "eea0fb9df467079344db40e55b70b743",
				resourceItemExtension: ".png"
			}
		},
		ClearIconHover: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "ClearIconHover",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		AddColumnMenuIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "AddColumnMenuIcon",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		MLIcon: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "MLIcon",
				hash: "863f66ffaff7bc0ceaa6aadc9c2491ae",
				resourceItemExtension: ".png"
			}
		},
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "EmptyInfoImage",
				hash: "0d2fe46bac31005b30ea5fb6de3b4984",
				resourceItemExtension: ".png"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		},
		ConsultationBanner: {
			source: 3,
			params: {
				schemaName: "MLTextSimilarityModelPage",
				resourceItemName: "ConsultationBanner",
				hash: "1c6e32c94691eed051d92f765b0fad0c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});