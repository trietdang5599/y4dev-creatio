Terrasoft.configuration.Structures["MLModelMiniPage"] = {innerHierarchyStack: ["MLModelMiniPageML", "MLModelMiniPage"], structureParent: "BaseMiniPage"};
define('MLModelMiniPageMLStructure', ['MLModelMiniPageMLResources'], function(resources) {return {schemaUId:'2742e982-30df-4cda-b07b-31ba9967525f',schemaCaption: "ML model", parentSchemaName: "BaseMiniPage", packageName: "MLSequencePrediction", schemaName:'MLModelMiniPageML',parentSchemaUId:'8e06a577-08e4-424e-bd89-798a34e1b928',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MLModelMiniPageStructure', ['MLModelMiniPageResources'], function(resources) {return {schemaUId:'a42c6e94-71c6-44f3-a516-b5ece9954698',schemaCaption: "ML model", parentSchemaName: "MLModelMiniPageML", packageName: "MLSequencePrediction", schemaName:'MLModelMiniPage',parentSchemaUId:'2742e982-30df-4cda-b07b-31ba9967525f',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MLModelMiniPageML",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MLModelMiniPageMLResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MLModelMiniPageML", ["MLConfigurationConsts", "MLModelPageResources", "MLTextSimilarityModelPageResources",
		"MLRecommendationModelPageResources", "RootSchemaLookupMixin"],
	function(MLConfigurationConsts, modelPageResources, textSimilarityModelPageResources,
			 recommendationModelPageResources) {
		return {
			entitySchemaName: "MLModel",
			mixins: {
				RootSchemaLookupMixin: "Terrasoft.RootSchemaLookupMixin"
			},
			attributes: {
				"MiniPageModes": {
					"value": [this.Terrasoft.ConfigurationEnums.CardOperation.ADD]
				},

				/**
				 * Root schema lookup value.
				 */
				"RootSchema": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Uid of the root schema.
				 */
				"RootSchemaUId": {
					"dependencies": [
						{
							"columns": ["RootSchema"],
							"methodName": "onRootSchemaChanged"
						}
					]
				},

				/**
				 * Virtual column for CFUserColumnPath lookup.
				 */
				"CFUserColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for CFItemColumnPath lookup.
				 */
				"CFItemColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for CFInteractionValueColumnPath lookup.
				 */
				"CFInteractionValueColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Dependencies config for actualizing CF columns.
				 */
				"CFColumnsDependencies": {
					"dependencies": [
						{
							"columns": ["CFUserColumn", "CFItemColumn", "CFInteractionValueColumn"],
							"methodName": "onColumnPathVirtualColumnChanged"
						}
					]
				},

				/**
				 * Selection column for PredictionSchemaUId.
				 */
				"PredictionSchema": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Column for PredictionSchemaUId.
				 */
				"PredictionSchemaUId": {
					"dependencies": [
						{
							"columns": ["PredictionSchema"],
							"methodName": "onPredictionSchemaChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * @param {Object} column Entity schema column config.
				 * @protected
				 */
				_lookupColumnsFiltrationMethod: function(column) {
					return column.dataValueType === Terrasoft.DataValueType.LOOKUP ||
						column.dataValueType === Terrasoft.DataValueType.GUID;
				},

				/**
				 * @param {Object} column Entity schema column config.
				 * @protected
				 */
				_numericColumnsFiltrationMethod: function(column) {
					const dataValueTypes = Terrasoft.DataValueType;
					return [dataValueTypes.INTEGER, dataValueTypes.MONEY, dataValueTypes.MONEY0, 
						dataValueTypes.MONEY1, dataValueTypes.MONEY3,
						dataValueTypes.FLOAT, dataValueTypes.FLOAT0, dataValueTypes.FLOAT1, dataValueTypes.FLOAT2, 
						dataValueTypes.FLOAT3, dataValueTypes.FLOAT4, dataValueTypes.FLOAT8]
						.includes(column.dataValueType);
				},

				/**
				 * Handles selection of column.
				 * @private
				 * @param {String} modelColumnName Model column for selected value.
				 * @param {Object} linkedColumnInfo Selected column information.
				 */
				_onColumnSelected: function(modelColumnName, linkedColumnInfo) {
					const value = linkedColumnInfo.leftExpressionColumnPath;
					const displayValue = linkedColumnInfo.leftExpressionCaption;
					this.set(modelColumnName, {
						value: value,
						displayValue: displayValue
					});
				},

				/**
				 * Opens entity structure explorer module for select column macros.
				 * @private
				 */
				_openStructureExplorer: function(columnName, columnsFiltrationMethod) {
					const schemaName = this.$RootSchema.name;
					Terrasoft.StructureExplorerUtilities.open({
						scope: this,
						handlerMethod: this._onColumnSelected.bind(this, columnName),
						moduleConfig: {
							useBackwards: false,
							schemaName: schemaName,
							columnsFiltrationMethod: columnsFiltrationMethod,
							firstColumnsOnly: false
						}
					});
				},

				/**
				 * If CF column required modifies its model's property.
				 * @private
				 * @return {Boolean} True if column is required.
				 */
				_setColumnRequired: function(columnName, conditionMethod) {
					const isRequired = conditionMethod();
					this.columns[columnName].isRequired = isRequired;
					return isRequired;
				},

				/**
				 * @inheritdoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initializeRootSchema();
				},

				/**
				 * Handles modification of column path virtual column and saves corresponding real column's value.
				 */
				onColumnPathVirtualColumnChanged: function(ruleName, virtualColumnName) {
					const realColumnName = virtualColumnName + "Path";
					const oldValue = this.get(realColumnName);
					const newValue = this.getLookupValue(virtualColumnName);
					if (oldValue !== newValue &&
							(this.Ext.isEmpty(oldValue) || !this.Ext.isEmpty(newValue))) {
						this.set(realColumnName, newValue);
					}
				},

				/**
				 * @return {Boolean} True if model is of a collaborative filtering recommendation problem type.
				 */
				getIsCF: function() {
					return this.getLookupValue("MLProblemType") === MLConfigurationConsts.ProblemTypes.CF;
				},

				/**
				 * @return {Boolean} True if model is of a collaborative filtering recommendation problem type and
				 * RootSchema was selected.
				 */
				getIsCFAndRootSchemaSelected: function() {
					return this.getIsCF() && !this.Ext.isEmpty(this.get("RootSchemaUId"));
				},

				/**
				 * @return {Boolean} True if CFUserColumn column is required.
				 */
				setCFUserColumnRequired: function() {
					return this._setColumnRequired("CFUserColumn", this.getIsCF.bind(this));
				},

				/**
				 * @return {Boolean} True if CFItemColumn column is required.
				 */
				setCFItemColumnRequired: function() {
					return this._setColumnRequired("CFItemColumn", this.getIsCF.bind(this));
				},

				setPredictionSchemaRequired: function() {
					return this._setColumnRequired("PredictionSchema", this.getIsTextSimilarity.bind(this));
				},

				/**
				 * Opens structure explorer for choosing lookup linked column.
				 */
				selectLookupColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._lookupColumnsFiltrationMethod);
				},

				/**
				 * Opens structure explorer for choosing numeric linked column.
				 */
				selectNumericColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._numericColumnsFiltrationMethod);
				},

				/**
				 * Returns caption for entity column.
				 * @param {String} columnName Entity column name.
				 * @return {String} Caption for entity column.
				 */
				getEntityColumnCaption: function(columnName) {
					return this.entitySchema.getColumnByName(columnName).caption;
				},

				/**
				 * Returns caption of CFUserColumnPath.
				 * @return {String}
				 */
				getCFUserColumnCaption: function() {
					return this.getEntityColumnCaption("CFUserColumnPath");
				},

				/**
				 * Returns caption of CFItemColumnPath.
				 * @return {String}
				 */
				getCFItemColumnCaption: function() {
					return this.getEntityColumnCaption("CFItemColumnPath");
				},

				/**
				 * Returns caption of CFInteractionValueColumnPath.
				 * @return {String}
				 */
				getCFInteractionValueColumnCaption: function() {
					return this.getEntityColumnCaption("CFInteractionValueColumnPath");
				},

				/**
				 * Returns hint of CFInteractionValueColumn.
				 * @return {String}
				 */
				getCFInteractionValueColumnHint: function() {
					return recommendationModelPageResources.localizableStrings.CFInteractionValueColumnHint;
				},

				/**
				 * Returns RootSchema column caption depending on problem type.
				 * @return {String}
				 */
				getRootSchemaCaption: function() {
					if (this.getIsTextSimilarity()) {
						return textSimilarityModelPageResources.localizableStrings.RootEntityCaption;
					}
					return this.getIsCF()
						? recommendationModelPageResources.localizableStrings.CFRootSchemaCaption
						: this.getEntityColumnCaption("RootSchemaUId");
				},

				/**
				 * Returns RootSchema column hint depending on problem type.
				 * @return {String}
				 */
				getRootSchemaHint: function() {
					if (this.getIsTextSimilarity()) {
						return textSimilarityModelPageResources.localizableStrings.SubjectObjectSchemasTipContent;
					}
					return this.getIsCF()
						? recommendationModelPageResources.localizableStrings.CFRootSchemaHint
						: modelPageResources.localizableStrings.ChooseObjectStepTipCaption;
				},

				onPredictionSchemaChanged: function() {
					const selectedSchema = this.$PredictionSchema;
					const currentSelectedSchemaUId = this.$PredictionSchemaUId;
					if (this.Ext.isEmpty(selectedSchema) || selectedSchema.value === currentSelectedSchemaUId) {
						return;
					}
					this.$PredictionSchemaUId = selectedSchema.value;
				},

				getIsTextSimilarity: function() {
					return this.getLookupValue("MLProblemType") === MLConfigurationConsts.ProblemTypes.TextSimilarity;
				},

				/**
				 * Empty function for mocking control bindings.
				 */
				emptyFn: Ext.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "Name",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": true
						},
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"name": "MLProblemType",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"name": "RootSchema",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"caption": {"bindTo": "getRootSchemaCaption"},
						"tip": {
							"content": {"bindTo": "getRootSchemaHint"}
						}
					}
				},
				{
					"name": "PredictionSchema",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"tip": {
							"content": {"bindTo": "getRootSchemaHint"}
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"visible": {"bindTo": "getIsTextSimilarity"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setPredictionSchemaRequired"
							}
						},
						"caption": textSimilarityModelPageResources.localizableStrings.PredictionSchemaCaption
					}
				},
				{
					"name": "CFUserColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFUserColumnCaption"},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setCFUserColumnRequired"
							}
						}
					}
				},
				{
					"name": "CFItemColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFItemColumnCaption"},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setCFItemColumnRequired"
							}
						}
					}
				},
				{
					"name": "CFInteractionValueColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectNumericColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFInteractionValueColumnCaption"},
						"tip": {
							"content": {"bindTo": "getCFInteractionValueColumnHint"}
						},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"}
					}
				},
				{
					"operation": "merge",
					"name": "SaveEditButton",
					"values": {
						"click": {"bindTo": "openCurrentEntityPage"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});

define("MLModelMiniPage", ["MLConfigurationConsts", "MLModelPageResources"],
	function(MLConfigurationConsts, modelPageResources) {
		return {
			entitySchemaName: "MLModel",
			attributes: {
				/**
				 * Virtual column for SequenceIdentifierColumnPath lookup.
				 */
				"SequenceIdentifierColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for SequenceItemPositionColumnPath lookup.
				 */
				"SequenceItemPositionColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for SequenceItemValueColumnPath lookup.
				 */
				"SequenceItemValueColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Dependencies config for actualizing sequence prediction columns.
				 */
				"SequenceColumnsDependencies": {
					"dependencies": [
						{
							"columns": ["SequenceIdentifierColumn", "SequenceItemPositionColumn",
								"SequenceItemValueColumn"],
							"methodName": "onColumnPathVirtualColumnChanged"
						}
					]
				},

				/**
				 * ML problem type.
				 */
				"MLProblemType": {
					"lookupListConfig": {
						"filter": function () {
							return this.getMLProblemTypeFilter();
						}
					}
				}
			},
			methods: {
				/**
				 * @param {Object} column Entity schema column config.
				 * @private
				 */
				_numericOrDateColumnsFiltrationMethod: function(column) {
					return Terrasoft.isDateDataValueType(column.dataValueType) ||
						Terrasoft.isNumberDataValueType(column.dataValueType);
				},

				/**
				 * @param {Object} column Entity schema column config.
				 * @private
				 */
				_lookupOrTextColumnsFiltrationMethod: function(column) {
					return Terrasoft.isTextDataValueType(column.dataValueType) ||
						Terrasoft.utils.dataValueType.isLookupValidator(column.dataValueType);
				},

				/**
				 * Opens structure explorer for choosing numeric or date linked column.
				 */
				selectNumericOrDateColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._numericOrDateColumnsFiltrationMethod);
				},

				/**
				 * Opens structure explorer for choosing lookup or text linked column.
				 */
				selectLookupOrTextColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._lookupOrTextColumnsFiltrationMethod);
				},

				/**
				 * @return {Boolean} True if model is of a sequence prediction problem type.
				 */
				getIsSequencePrediction: function() {
					return this.getLookupValue("MLProblemType") ===
						MLConfigurationConsts.ProblemTypes.SequencePrediction;
				},

				/**
				 * @return {Boolean} True if model is of a sequence prediction problem type and RootSchema was selected.
				 */
				getIsSequencePredictionAndRootSchemaSelected: function() {
					return this.getIsSequencePrediction() && !this.Ext.isEmpty(this.get("RootSchemaUId"));
				},

				/**
				 * Returns caption of SequenceIdentifierColumnPath caption.
				 * @return {String}
				 */
				getSequenceIdentifierColumnCaption: function() {
					return this.getEntityColumnCaption("SequenceIdentifierColumnPath");
				},

				/**
				 * Returns caption of SequenceItemPositionColumnPath caption.
				 * @return {String}
				 */
				getSequenceItemPositionColumnCaption: function() {
					return this.getEntityColumnCaption("SequenceItemPositionColumnPath");
				},

				/**
				 * Returns caption of SequenceItemValueColumnPath caption.
				 * @return {String}
				 */
				getSequenceItemValueColumnCaption: function() {
					return this.getEntityColumnCaption("SequenceItemValueColumnPath");
				},

				/**
				 * @return {Boolean} True if SequenceIdentifierColumn column is required.
				 */
				setSequenceIdentifierColumnRequired: function () {
					return this._setColumnRequired("SequenceIdentifierColumn", this.getIsSequencePrediction.bind(this));
				},

				/**
				 * @return {Boolean} True if SequenceItemPositionColumn column is required.
				 */
				setSequenceItemPositionColumnRequired: function () {
					return this._setColumnRequired("SequenceItemPositionColumn",
						this.getIsSequencePrediction.bind(this));
				},

				/**
				 * @return {Boolean} True if SequenceItemValueColumn column is required.
				 */
				setSequenceItemValueColumnRequired: function () {
					return this._setColumnRequired("SequenceItemValueColumn", this.getIsSequencePrediction.bind(this));
				},

				/**
				 * Returns filter for MLProblemType.
				 * @returns {Terrasoft.CompareFilter} MLProblemType filter.
				 */
				getMLProblemTypeFilter: function () {
					if (!Terrasoft.Features.getIsEnabled("MLSequencePrediction")) {
						return Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.NOT_EQUAL,
							"Id", MLConfigurationConsts.ProblemTypes.SequencePrediction);
					}
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "SequenceIdentifierColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupOrTextColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getSequenceIdentifierColumnCaption"},
						"visible": {"bindTo": "getIsSequencePredictionAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setSequenceIdentifierColumnRequired"
							}
						}
					}
				},
				{
					"name": "SequenceItemPositionColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectNumericOrDateColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getSequenceItemPositionColumnCaption"},
						"visible": {"bindTo": "getIsSequencePredictionAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setSequenceItemPositionColumnRequired"
							}
						}
					}
				},
				{
					"name": "SequenceItemValueColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupOrTextColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getSequenceItemValueColumnCaption"},
						"visible": {"bindTo": "getIsSequencePredictionAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setSequenceItemValueColumnRequired"
							}
						}
					}
				}
			]
		};
 });

