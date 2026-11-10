define("MLSequencePredictionModelPage", ["MLConfigurationConsts", "ConfigurationEnums", "css!MLModelPageCSS", "MLListPredictionMixin"],
	function(mlConsts) {
		return {
			entitySchemaName: "MLModel",
			attributes: {
				"BatchPredictionEnabled": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				"TargetColumnEnabled": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: false
				},

				/**
				 * Virtual column for SequenceIdentifierColumnPath.
				 */
				"SequenceIdentifierColumn": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getVirtualColumnPathCaption"}
				},

				/**
				 * Virtual column for SequenceItemPositionColumnPath.
				 */
				"SequenceItemPositionColumn": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getVirtualColumnPathCaption"}
				},

				/**
				 * Virtual column for SequenceItemValueColumnPath.
				 */
				"SequenceItemValueColumn": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getVirtualColumnPathCaption"}
				}
			},
			mixins: {
				MLListPredictionMixin: "Terrasoft.MLListPredictionMixin"
			},
			methods: {

				getTrainColumnsSelectionModuleConfig: function() {
					return {};
				},

				/**
				 * Indicates that Train button is enabled.
				 * @override
				 * @return {Boolean}
				 */
				getIsTrainButtonEnabled: function () {
					const allowTrainModel = Terrasoft.Features.getIsEnabled("MLSequencePrediction");
					return allowTrainModel && this.callParent(arguments);
				},

				/**
				 * Loads captions for columns paths virtual columns.
				 * @private
				 */
				_initializeColumnPathColumnCaptions: function() {
					if (Ext.isEmpty(this.$RootSchema)) {
						return;
					}
					const schemaName = this.$RootSchema.name;
					const serviceParameters = [
						{
							schemaName: schemaName,
							columnPath: this.$SequenceIdentifierColumnPath,
							key: "SequenceIdentifierColumn"
						},
						{
							schemaName: schemaName,
							columnPath: this.$SequenceItemPositionColumnPath,
							key: "SequenceItemPositionColumn"
						},
						{
							schemaName: schemaName,
							columnPath: this.$SequenceItemValueColumnPath,
							key: "SequenceItemValueColumn"
						}
					];
					this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(captionConfigs) {
						Terrasoft.each(captionConfigs, function(captionConfig) {
							this.set(captionConfig.key, captionConfig.columnCaption);
						}, this);
					}, this);
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this._initializeColumnPathColumnCaptions();
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				getRootSchemaCaption: function() {
					return this.get("Resources.Strings.SequencePredictionRootSchemaCaption");
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				getRootSchemaHint: function() {
					return this.get("Resources.Strings.SequencePredictionRootSchemaHint");
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				getColumnSelectionModulesSandboxTags: function() {
					return [];
				}
			},
			diff: [
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
					"name": "SequenceIdentifierColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.SHORT_TEXT,
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"name": "SequenceItemPositionColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.SHORT_TEXT,
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"name": "SequenceItemValueColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.SHORT_TEXT,
						"enabled": {"bindTo": "isAddMode"}
					}
				}
			]
		};
	});
