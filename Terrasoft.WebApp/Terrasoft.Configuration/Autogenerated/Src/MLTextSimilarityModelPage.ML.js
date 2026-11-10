define("MLTextSimilarityModelPage", ["MLConfigurationConsts",
		"MLListPredictionMixin"], function(MLConfigurationConsts) {
	return {
		entitySchemaName: "MLModel",
		mixins: {
			MLListPredictionMixin: "Terrasoft.MLListPredictionMixin"
		},
		attributes: {
			/**
			 * Lookup selection column for ListPredictResultSchemaUId.
			 */
			"PredictionSchema": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Lookup selection column for ListPredictResultSchemaUId.
			 */
			"ListPredictResultSchema": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Virtual column for ListPredictResultSchemaUId.
			 */
			"ListPredictResultSchemaUId": {
				"dependencies": [
					{
						"columns": ["ListPredictResultSchema"],
						"methodName": "onListPredictionResultSchemaChanged"
					}
				]
			},

			/**
			 * Lookup selection column for ListPredictResultSubjectColumn.
			 */
			"ListPredictResultSubjectColumnLookup": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.ListPredictResultSubjectСaption"}
			},

			/**
			 * Virtual column for ListPredictResultSubjectColumn.
			 */
			"ListPredictResultSubjectColumn": {
				"dependencies": [
					{
						"columns": ["ListPredictResultSubjectColumnLookup"],
						"methodName": "onListPredictionResultColumnLookupAttributeChange"
					}
				]
			},

			/**
			 * Lookup selection column ListPredictResultItemColumn.
			 */
			"ListPredictResultObjectColumnLookup": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.ListPredictResultObjectСaption"}
			},

			/**
			 * Virtual column for ListPredictResultItemColumn.
			 */
			"ListPredictResultObjectColumn": {
				"dependencies": [
					{
						"columns": ["ListPredictResultObjectColumnLookup"],
						"methodName": "onListPredictionResultColumnLookupAttributeChange"
					}
				]
			},

			/**
			 * Lookup selection column for ListPredictResultValueColumn.
			 */
			"ListPredictResultValueColumnLookup": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Virtual column for ListPredictResultValueColumn.
			 */
			"ListPredictResultValueColumn": {
				"dependencies": [
					{
						"columns": ["ListPredictResultValueColumnLookup"],
						"methodName": "onListPredictionResultColumnLookupAttributeChange"
					}
				]
			},

			/**
			 * Lookup selection column for ListPredictResultModelColumn.
			 */
			"ListPredictResultModelColumnLookup": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Virtual column for ListPredictResultModelColumn.
			 */
			"ListPredictResultModelColumn": {
				"dependencies": [
					{
						"columns": ["ListPredictResultModelColumnLookup"],
						"methodName": "onListPredictionResultColumnLookupAttributeChange"
					}
				]
			},

			/**
			 * Lookup selection column for ListPredictResultTimestampColumn.
			 */
			"ListPredictResultDateColumnLookup": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Virtual column for ListPredictResultTimestampColumn
			 */
			"ListPredictResultTimestampColumn": {
				"dependencies": [
					{
						"columns": ["ListPredictResultDateColumnLookup"],
						"methodName": "onListPredictionResultColumnLookupAttributeChange"
					}
				]
			},

			/**
			 * Indicates load state of list prediction result schema.
			 */
			"ListPredictResultSchemaInitialized": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Search config for list predict subject column autocompletion.
			 */
			"ListPredictSubjectColumnSearchConfig": {
				"dataValueType": Terrasoft.DataValueType.OBJECT,
				"value": {
					"schemaAttribute": "RootSchema"
				}
			},

			/**
			 * Search config for list predict object column autocompletion.
			 */
			"ListPredictObjectColumnSearchConfig": {
				"dataValueType": Terrasoft.DataValueType.OBJECT,
				"value": {
					"schemaAttribute": "PredictionSchema"
				}
			}
		},
		methods: {

			_loadPredictionColumnsSelectionModule: function() {
				this.sandbox.loadModule("MLColumnSelectionModule", {
					"id": "PredictionColumnSelectionModule",
					"renderTo": "PredictionColumnSelectionModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"rootSchema": "PredictionSchema",
						"columnType": MLConfigurationConsts.MLModelColumnTypes.Prediction
					}
				});
			},

			getTrainColumnsSelectionModuleConfig: function() {
				const parentConfig = this.callParent(arguments);
				parentConfig.instanceConfig.columnType = MLConfigurationConsts.MLModelColumnTypes.Training
				return parentConfig;
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.set("PredictionColumnCollection", this.Ext.create("Terrasoft.BaseViewModelCollection"));
				this.initializeSchemaColumns("PredictionSchemaColumns", "PredictionSchema",
					"PredictionSchemaColumnsList", function() {
						this._loadPredictionColumnsSelectionModule();
						this.initializeListPredictionResultSchemaColumns(function() {
							this._initializeListPredictionResultColumns();
						}, this);
					}, this);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getSelectionModuleInfoCollection: function(attributeName) {
				if (attributeName === "PredictionSchema") {
					return this.$PredictionColumnCollection;
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			initializeAdditionalSchemas: function() {
				this.initializeSchema("PredictionSchema");
				this.initializeListPredictionResultSchema();
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getColumnSelectionModuleLocalizableStrings: function(attributeName) {
				if (attributeName === "PredictionSchema") {
					return {
						title: this.get("Resources.Strings.SimilarObjectSelectionColumnsGroupCaption"),
						helpText: this.get("Resources.Strings.SimilarObjectColumnSelectionTipText")
					};
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			columnDataValueTypeFilter: function(dataValueType) {
				return Terrasoft.isTextDataValueType(dataValueType);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getRootSchemaHint: function() {
				return this.get("Resources.Strings.SubjectObjectSchemasTipContent");
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getColumnSelectionModulesSandboxTags: function() {
				const parentModules = this.callParent(arguments);
				parentModules.push("PredictionColumnSelectionModule");
				return parentModules;
			},

			/**
			 * Reloads prediction columns selection module on card rerender. 
			 */
			updatePredictionQueryColumnSelectionModule: function () {
				this._updateColumnSelectionModule(this._loadPredictionColumnsSelectionModule);
			}
		},
		diff: [
			{
				"name": "MetricIndicator",
				"operation": "remove"
			},
			{
				"name": "MLExplanationContainer",
				"operation": "remove"
			},
			{
				"name": "TargetColumnGroup",
				"operation": "remove"
			},
			{
				"name": "PredictedResultColumnGroup",
				"operation": "remove"
			},
			{
				"operation": "remove",
				"name": "TrainingQueryColumnSelectionModule"
			},
			{
				"operation": "merge",
				"name": "RootSchema",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.RootEntityCaption"
					}
				}
			},
			{
				"name": "TrainingFilterDataInfoButton",
				"parentName": "FilterForTrainingGroup",
				"operation": "insert",
				"index": 1,
				"propertyName": "tools",
				"values": {
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "Resources.Strings.TrainingFilterDataInfoButtonText"},
					"behaviour": {
						"displayEvent": Terrasoft.TipDisplayEvent.HOVER
					},
					"controlConfig": {
						"classes": {
							"wrapperClass": "ml-model-page-info-button-control-group"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "TrainingQueryColumnSelectionModule",
				"parentName": "ModelSettingsTab",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE,
					"afterrerender": {
						"bindTo": "updateTrainingQueryColumnSelectionModule"
					}
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "PredictionColumnSelectionModule",
				"parentName": "ModelSettingsTab",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE,
					"afterrerender": {
						"bindTo": "updatePredictionQueryColumnSelectionModule"
					}
				},
				"index": 2
			},
			{
				"name": "PredictionSchema",
				"parentName": "ProfileContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.PredictionSchemaCaption"},
					"bindTo": "PredictionSchema",
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareRootSchemaList"
						}
					},
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 24
					},
					"tip": {
						"content": {"bindTo": "getRootSchemaHint"}
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"enabled": {"bindTo": "isAddMode"}
				}
			},
			{
				"name": "TextSimilarityResultSavingGroup",
				"parentName": "ModelSettingsTab",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ResultSavingGroupCaption"
					},
					"tools": [],
					"items": [],
					"controlConfig": {}
				},
				"index": 3
			},
			{
				"name": "TextSimilarityResultSavingGridLayout",
				"parentName": "TextSimilarityResultSavingGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"name": "ListPredictResultSchema",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 12
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareRootSchemaList"
						}
					},
					"bindTo": "ListPredictResultSchema",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultSchemaCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM
				}
			},
			{
				"name": "ListPredictResultSubjectColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 12
					},
					"bindTo": "ListPredictResultSubjectColumnLookup",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultSubjectCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareListPredictionSchemaColumnLookupList"
						}
					},
					"isRequired": {
						"bindTo": "ListPredictResultSchema",
						"bindConfig": {
							"converter": "setListPredictionResultSubjectColumnRequired"
						}
					}
				}
			},
			{
				"name": "ListPredictResultObjectColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 12
					},
					"bindTo": "ListPredictResultObjectColumnLookup",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultObjectCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareListPredictionSchemaColumnLookupList"
						}
					},
					"isRequired": {
						"bindTo": "ListPredictResultSchema",
						"bindConfig": {
							"converter": "setListPredictionResultObjectColumnRequired"
						}
					}
				}
			},
			{
				"name": "ListPredictResultValueColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 12
					},
					"bindTo": "ListPredictResultValueColumnLookup",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultValueCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareListPredictionSchemaColumnLookupList"
						}
					}
				}
			},
			{
				"name": "ListPredictResultModelColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 12
					},
					"bindTo": "ListPredictResultModelColumnLookup",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultModelCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareListPredictionSchemaColumnLookupList"
						}
					}
				}
			},
			{
				"name": "ListPredictResultDateColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 12
					},
					"bindTo": "ListPredictResultDateColumnLookup",
					"caption": {
						"bindTo": "Resources.Strings.ListPredictResultDateCaption"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareListPredictionSchemaColumnLookupList"
						}
					}
				}
			},
			{
				"name": "LowerScoreThreshold",
				"parentName": "AdvancedModelParametersGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"bindTo": "LowerScoreThreshold"
				}
			}
		]
	};
});
