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