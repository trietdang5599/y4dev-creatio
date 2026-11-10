Terrasoft.configuration.Structures["MLModelPage"] = {innerHierarchyStack: ["MLModelPage"], structureParent: "BaseModulePageV2"};
define('MLModelPageStructure', ['MLModelPageResources'], function(resources) {return {schemaUId:'e198e03f-20ef-49bf-9167-0faa7be3f977',schemaCaption: "MLModelPage", parentSchemaName: "BaseModulePageV2", packageName: "ML", schemaName:'MLModelPage',parentSchemaUId:'d62293c0-7f14-44b1-b547-735fb40499cd',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MLModelPage", ["MLConfigurationConsts", "GoogleTagManagerUtilities", "ConfigurationEnums",
		"DesktopPopupNotification", "SupportEmailHelper", "MLModelPageResources", "SourceCodeEditGenerator",
		"SourceCodeEdit", "css!MLModelPageCSS", "TooltipUtilities", "CardWidgetModule", "EntityColumnLookupMixin",
		"MLModelStateProgressBarUtils", "css!MLModelStateProgressBarUtils", "RootSchemaLookupMixin",
		"StructureExplorerUtilities", "EntityStructureHelperMixin", "MLModelColumnViewModel", "MLPredictionPageMixin",
		"ImageCustomGeneratorV2", "MLModelPageFiltersMixin", "AcademyUtilities"],
	function(MLConfigurationConsts, GoogleTagManagerUtilities, ConfigurationEnums, DesktopPopupNotification,
			 SupportEmailHelper) {
		return {
			entitySchemaName: "MLModel",
			mixins: {
				TooltipUtilities: "Terrasoft.TooltipUtilities",
				EntityColumnLookupMixin: "Terrasoft.EntityColumnLookupMixin",
				RootSchemaLookupMixin: "Terrasoft.RootSchemaLookupMixin",
				EntityStructureHelper: "Terrasoft.EntityStructureHelperMixin",
				MLPredictionPageMixin: "Terrasoft.MLPredictionPageMixin",
				MLModelPageFiltersMixin: "Terrasoft.MLModelPageFiltersMixin"
			},
			messages: {
				/**
				 * @message SetFilterModuleConfig
				 * Applies settings for the filter unit.
				 */
				"SetFilterModuleConfig": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetFilterModuleConfig
				 * Returns settings for the filter unit.
				 */
				"GetFilterModuleConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message OnFiltersChanged
				 * Subscription for the filter unit modification event.
				 */
				"OnFiltersChanged": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetColumnsLookupInfo
				 * Gets selected columns from lookup page.
				 */
				"SetColumnsLookupInfo": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message TrainButtonConfigUpdated
				 * Publishes information about current Train button's configuration.
				 */
				"TrainButtonConfigUpdated": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * Returns entity data for ml prediction & explanation.
				 * @message GetMLExplanationConfig
				 */
				"GetMLExplanationConfig": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * Trigger to reload ml explanation data.
				 * @message ReloadMLExplanationsModule
				 */
				"ReloadMLExplanationsModule": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * Hides ML explanations module container.
				 * @message HideMLExplanationsModule
				 */
				"HideMLExplanationsModule": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetSelectionSchemaInfo
				 * Query for information about column selection schema.
				 */
				"GetSelectionSchemaInfo": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SelectedModelColumnsChanged
				 * Triggered, when collection of selected columns has been changed.
				 */
				"SelectedModelColumnsChanged": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message MLModelSaved
				 * Triggered, when ML model has been saved.
				 */
				"MLModelSaved": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			properties: {
				/**
				 * Timer task, that continues updating model state until training finish or model page close.
				 * @private
				 * @type {Object}
				 */
				updateStateTask: null,
				/**
				 * Timeout for re-query training status in seconds.
				 * @private
				 * @type {Number}
				 */
				trainingStatusAutoRefreshTimeout: 0,
				/**
				 * Default re-train frequency in days.
				 * @private
				 * @type {Number}
				 */
				defaultTrainFrequency: 30,

				/**
				 * Array of the model designed columns' identifiers before all modifications.
				 * @type {Array}
				 */
				initialColumnCollectionIdentifiers: null
			},
			attributes: {
				/**
				 * Root schema lookup value.
				 */
				"RootSchema": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"caption": {"bindTo": "getRootSchemaCaption"}
				},

				/**
				 * Aggregated localizable (MetadataLcz) and not localizable parts of Metadata.
				 */
				"MetadataWithLcz": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getMetadataColumnCaption"}
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
				 * Root schema columns suitable for target column of the model.
				 */
				"RootSchemaColumns": {
					"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Target column for model.
				 */
				"TargetColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": false,
					"onChange": "onTargetColumnChanged"
				},

				/**
				 * Root object's column that stores predicted result.
				 */
				"PredictedResultColumn": {
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": false,
					"onChange": "onPredictedResultColumnChanged"
				},

				/**
				 * Indicates that ColumnCollection was modified by user.
				 */
				"IsColumnCollectionChanged": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Indicates that batch prediction should start automatically.
				 */
				"UseAutomaticBatchPrediction": {
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Train button's caption.
				 */
				"TrainButtonCaption": {
					"dataValueType": Terrasoft.DataValueType.TEXT
				},

				/**
				 * Progress of the current training state (i.e. records uploaded in data transferring state).
				 */
				"TrainingProgress": {
					"dataValueType": Terrasoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * Indicates that train button is enabled.
				 */
				"IsTrainButtonEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN
				},

				/**
				 * Indicates that Automatic re-train enabled.
				 */
				"IsAutomaticRetrainEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false,
					"onChange": "onIsAutomaticRetrainEnabledChanged"
				},

				/**
				 * Indicates possible existence of the explanation info for the trained model.
				 * @type {Boolean}
				 */
				"IsTrainingExplanationInfoCanBeFound": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Mode for advanced model tuning.
				 * @type {Boolean}
				 */
				"IsAdvancedMode": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Batch prediction enabled for current problem type.
				 */
				"BatchPredictionEnabled": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Target column enabled for current problem type.
				 */
				"TargetColumnEnabled": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Show consultation banner.
				 */
				"IsConsultationBannerVisible": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Last training error text.
				 */
				"TrainErrorText": {
					type: Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: Terrasoft.DataValueType.TEXT
				}
			},
			details: /**SCHEMA_DETAILS*/{
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "MLModelFile",
					filter: {
						masterColumn: "Id",
						detailColumn: "MLModel"
					}
				},
				TrainSessions: {
					schemaName: "MLModelTrainSessionDetailV2",
					entitySchemaName: "MLTrainSession",
					filter: {
						masterColumn: "Id",
						detailColumn: "MLModel"
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				//region Methods: Private

				/**
				 * Sends Google tag manager data.
				 * Note. This approach is slightly different from the standard one, because:
				 *  - Terrasoft.BasePageV2#sendGoogleTagManagerData is overridden as empty function;
				 *  - This approach does not require synthetic property for custom action tag.
				 * @param {String} modelActionTag Custom action tag.
				 * @private
				 */
				_sendGoogleTagManagerDataMLModelPage: function(modelActionTag) {
					const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
					if (!isGoogleTagManagerEnabled) {
						return;
					}
					const data = this.getGoogleTagManagerData(modelActionTag);
					Terrasoft.GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * Utility function for post-processing of automatically generated metadata.
				 * @param {String} key The key to be replaced.
				 * @param {Object} value The value to be replaced.
				 * @private
				 */
				_metadataReplacer: function(key, value) {
					return (value == null || key === "isRequired") ? undefined : value;
				},

				/**
				 * Gets metric indicator visibility flag.
				 * @return {Boolean} Indicator visibility value.
				 * @private
				 */
				_getIsMetricIndicatorVisible: function() {
					return !this.isNewMode();
				},

				/**
				 * Converts arguments to lookup item.
				 * @private
				 * @param {Object} value Value of lookup.
				 * @param {String} displayValue DisplayValue of lookup.
				 * @param {String} name Name of lookup.
				 * @return {Object} Lookup item.
				 */
				_getListValue: function(value, displayValue, name) {
					return {
						value: value,
						displayValue: displayValue,
						name: name
					};
				},

				/**
				 * Initializes TargetColumn, PredictedResultColumn properties.
				 * @private
				 */
				_initializeTargetColumns: function() {
					this.set("TargetColumn", null);
					this.set("PredictedResultColumn", null);
					const targetObjectColumns = this.get("TargetObjectColumns");
					if (!targetObjectColumns) {
						return;
					}
					const targetColumn = targetObjectColumns[this.$TargetColumnUId];
					this.set("TargetColumn", targetColumn);
					const predictedResultColumn = targetObjectColumns[this.$PredictedResultColumnUId];
					this.set("PredictedResultColumn", predictedResultColumn);
				},

				/**
				 * Sets list of numeric columns into TargetObjectColumns property.
				 * @private
				 * @param {Array} columns Array of columns.
				 * @param {String} dropdownListAttribute - attribute to save items for dropdown.
				 */
				_onSchemaColumnsLoaded: function(columns, dropdownListAttribute) {
					const items = {};
					Terrasoft.each(columns, function(column) {
						if (this.filterTargetColumns(column)) {
							items[column.uId] = this._getListValue(column.uId, column.caption, column.name);
						}
					}, this);
					this.set(dropdownListAttribute, items);
				},

				/**
				 * Loads columns of target object and executes callback function.
				 * @private
				 * @param {String} schemaName Name of entity schema.
				 * @param {String} columnsListAttribute - name of attribute to save schema columns.
				 * @param {String} dropdownListAttribute - name of attribute to save dropdown list items.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context of callback function.
				 */
				_loadSchemaColumns: function(schemaName, columnsListAttribute, dropdownListAttribute,
											 callback, scope) {
					Terrasoft.require([schemaName], function(entitySchema) {
						const columns = entitySchema && entitySchema.columns;
						this.set(columnsListAttribute, columns);
						this._onSchemaColumnsLoaded(columns, dropdownListAttribute);
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				initializeSchemaColumns: function(columnListAttribute, schemaAttribute, dropdownListAttribute, callback, scope) {
					this.set(columnListAttribute, null);
					const schema = this.get(schemaAttribute);
					if (Terrasoft.isEmpty(schema)) {
						callback.call(scope);
						return;
					}
					this._loadSchemaColumns(schema.name, columnListAttribute, dropdownListAttribute, callback, scope);
				},

				/**
				 * Initializes TargetObjectColumns property.
				 * @private
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Execution context of callback function.
				 */
				_initializeRootSchemaColumns: function(callback, scope) {
					this.initializeSchemaColumns("RootSchemaColumns", "RootSchema", "TargetObjectColumns",
						callback, scope);
				},

				/**
				 * @private
				 */
				_initCollections: function() {
					this.set("ColumnCollection", this.Ext.create("Terrasoft.BaseViewModelCollection"));
				},

				/**
				 * @private
				 */
				_subscribeOnEvents: function() {
					this.subscribeOnColumnChange("ModelInstanceUId", this.columnChanged, this);
					this.subscribeOnColumnChange("State", this._updateTrainButtonConfig, this);
				},

				/**
				 * Updates value for such root entity related attributes like TargetColumn, PredictedResultColumn.
				 * @private
				 */
				_setRootEntityColumnAttributeValue: function(attribute) {
					const item = this.get(attribute);
					if (!this.Ext.isEmpty(item) && !this.Ext.isEmpty(item.value)) {
						this.set(attribute + "UId", item.value);
					}
				},

				/**
				 * @private
				 */
				_initUseAutomaticBatchPrediction: function() {
					const batchPredictionStartMethod = this.getLookupValue("BatchPredictionStartMethod");
					const value = batchPredictionStartMethod === MLConfigurationConsts.MLTaskStartMethods.Automatically;
					this.set("UseAutomaticBatchPrediction", value);
				},

				/**
				 * Stops the task for updating model state.
				 * @private
				 */
				_stopUpdateStateTask: function() {
					const task = this.updateStateTask;
					if (!this.Ext.isEmpty(task)) {
						task.destroy();
					}
				},

				/**
				 * Shows the notification about training finish.
				 * @private
				 */
				_showTrainingNotification: function(resultCode) {
					const config = DesktopPopupNotification.createConfig();
					const image = this.get("Resources.Images.MLIcon");
					const title = this.get("Resources.Strings.TrainingStatusNotificationTitle");
					const body = resultCode === MLConfigurationConsts.ModelStates.Done.code
						? this.Ext.String.format(this.get("Resources.Strings.TrainModelActionSucceedMessage"),
							resultCode)
						: this.get("Resources.Strings.TrainModelActionFailedMessage");
					DesktopPopupNotification.show(this.Ext.apply(config, {
						onClick: this.Ext.global.focus,
						title: title,
						body: body,
						icon: Terrasoft.ImageUrlBuilder.getUrl(image)
					}));
				},

				/**
				 * Handler of update state task tick.
				 * @private
				 */
				_updateStateTaskHandler: function() {
					this.callService({
						serviceName: "MLTrainerService",
						methodName: "QueryLastTrainingState",
						data: {
							"modelId": this.get("Id")
						}
					}, function(responseResult) {
						const sessionStateCode = Terrasoft.findValueByPath(responseResult, "trainSessionState.value");
						const modelStates = MLConfigurationConsts.ModelStates;
						this._updateModelStateByCode(sessionStateCode);
						if (!sessionStateCode) {
							this._stopUpdateStateTask();
							return;
						}
						if (sessionStateCode === modelStates.Done.code || sessionStateCode === modelStates.Error.code) {
							if (!this.$IsChanged) {
								// fires model handlers for TrainSessionId changes that were made in silent mode
								this.trigger("change:TrainSessionId", this.$TrainSessionId);
								this.reloadEntity();
							}
						} else {
							this.updateDetail({detail: "TrainSessions"});
						}
						if (this._isFiniteStateCode(sessionStateCode)) {
							this._stopUpdateStateTask();
							this._showTrainingNotification(sessionStateCode);
						}
					}, this);
				},

				/**
				 * Updates State attribute by the current training state code.
				 * @param {String} stateCode Current training state code.
				 * @private
				 */
				_updateModelStateByCode: function(stateCode) {
					const states = MLConfigurationConsts.ModelStates;
					const state = Terrasoft.findWhere(states, {code: stateCode});
					if (state) {
						this.set("State", {
							value: state.id,
							displayValue: stateCode
						}, {silent: true});
					}
					this._updateTrainButtonConfig();
				},

				/**
				 * Sends training button config message.
				 * @private
				 */
				_updateTrainButtonConfig: function() {
					this.$TrainButtonCaption = this.getTrainButtonCaption();
					this.$IsTrainButtonEnabled = this.getIsTrainButtonEnabled();
					this.sandbox.publish("TrainButtonConfigUpdated", {
						caption: this.$TrainButtonCaption,
						enabled: this.$IsTrainButtonEnabled
					}, [this.sandbox.id]);
				},

				/**
				 * Checks if the given state is finite (by code).
				 * @param {String} stateCode Code of the state to check.
				 * @private
				 */
				_isFiniteStateCode: function(stateCode) {
					return Terrasoft.findWhere(MLConfigurationConsts.FiniteModelStates, {code: stateCode});
				},

				/**
				 * Checks if the give state is finite (by id).
				 * @param {String} stateId Id of the state to check.
				 * @return {Boolean}
				 * @private
				 */
				_isFiniteStateId: function(stateId) {
					return !!Terrasoft.findWhere(MLConfigurationConsts.FiniteModelStates, {id: stateId});
				},

				/**
				 * @private
				 */
				_initializeMetadata: function() {
					const metadata = this._tryDeserializeMetadata(this.$MetaData);
					if (!metadata) {
						this.$MetadataWithLcz = this.$MetaData;
						return;
					}
					const metadataLcz = this._tryDeserializeMetadata(this.$MetaDataLcz);
					if (!metadataLcz) {
						this.$MetadataWithLcz = this.$MetaData;
						return;
					}
					if (metadata.output) {
						metadata.output.caption = metadataLcz.output && metadataLcz.output.caption || "";
					}
					if (!metadata.inputs || !metadataLcz) {
						this.$MetadataWithLcz = this.$MetaData;
						return;
					}
					Terrasoft.each(metadata.inputs, function(input) {
						const inputLcz = Terrasoft.findWhere(metadataLcz.inputs, {
							name: input.name
						});
						input.caption = inputLcz && inputLcz.caption || "";
					}, this);
					this.$MetadataWithLcz = JSON.stringify(metadata, null, "\t");
				},

				/**
				 * @private
				 */
				_separateMetadata: function() {
					const metadataWithLcz = this._tryDeserializeMetadata(this.$MetadataWithLcz);
					if (!metadataWithLcz) {
						this.$MetaData = this.$MetadataWithLcz;
						this.$MetaDataLcz = "";
						return;
					}
					const inputsLcz = [];
					const inputs = metadataWithLcz.inputs || [];
					Terrasoft.each(inputs, function(input) {
						if (!input.caption) {
							return true;
						}
						inputsLcz.push({
							name: input.name,
							caption: input.caption
						});
						delete input.caption;
					}, this);
					const metadataLcz = {
						inputs: inputsLcz
					};
					if (metadataWithLcz.output) {
						metadataLcz.output = {
							name: metadataWithLcz.output.name,
							caption: metadataWithLcz.output.caption
						};
						delete metadataWithLcz.output.caption;
					}
					this.$MetaDataLcz = JSON.stringify(metadataLcz, null, "\t");
					this.$MetaData = JSON.stringify(metadataWithLcz, null, "\t");
				},

				/**
				 * @return {Boolean|Object} Deserialized metadata. False if it can't be deserialized or it's empty.
				 * @private
				 */
				_tryDeserializeMetadata: function(serializedMetadata) {
					if (!serializedMetadata) {
						return false;
					}
					let metadata;
					try {
						metadata = JSON.parse(serializedMetadata) || {};
					} catch (e) {
						this.error(e);
						return false;
					}
					if (!metadata.inputs && !metadata.output) {
						return false;
					}
					return metadata;
				},

				/**
				 * @return {Boolean} True if model has trained session.
				 * @private
				 */
				_getIsModelHasTrainingExplanations: function() {
					return !Ext.isEmpty(this.$TrainSessionId) && !Ext.isEmpty(this.$ModelInstanceUId) &&
						this.$IsTrainingExplanationInfoCanBeFound;
				},

				/**
				 * @return {Boolean} True if model has no trained session.
				 * @private
				 */
				_getIsModelHasNoTrainingExplanations: function() {
					return !this._getIsModelHasTrainingExplanations();
				},

				/**
				 * @private
				 */
				_getTrainingHeaderCaption: function() {
					const formattedDateTime = Terrasoft.toCultureDateTime(this.$TrainedOn);
					return Ext.String.format(this.get("Resources.Strings.TopFeaturesCaption"), formattedDateTime);
				},

				/**
				 * @private
				 */
				_subscribeOnMLExplanationModuleMessages: function() {
					this.$IsTrainingExplanationInfoCanBeFound = true;
					const moduleId = this.modules.MLExplanationModule.moduleId;
					this.sandbox.subscribe("GetMLExplanationConfig", function() {
						if (!this._getIsModelHasTrainingExplanations()) {
							return null;
						}
						return {
							operation: "getModelExplanation",
							recordDescription: this._getTrainingHeaderCaption(),
							trainSessionId: this.$TrainSessionId
						};
					}.bind(this), this, [moduleId]);
					this.sandbox.subscribe("HideMLExplanationsModule", function() {
						this.$IsTrainingExplanationInfoCanBeFound = false;
					}, this, [moduleId]);
				},

				/**
				 * @private
				 */
				_loadTrainColumnsSelectionModule: function() {
					const config = this.getTrainColumnsSelectionModuleConfig();
					if (this.Ext.isEmpty(config)) {
						return;
					}
					this.sandbox.loadModule("MLColumnSelectionModule", config);
				},

				_subscribeToColumnsSelectionModuleMessages: function() {
					this.sandbox.subscribe("SelectedModelColumnsChanged", function() {
						this.$IsColumnCollectionChanged = true;
					}, this);
					this.sandbox.subscribe("GetSelectionSchemaInfo", this.getColumnSelectionModuleInfo, this);
				},

				_updateColumnSelectionModule: function(updateMethod) {
					if (!this.$IsEntityInitialized) {
						return;
					}
					updateMethod.call(this);
				},

				/**
				 * Removes viewmodel subscription to server messages.
				 * @protected
				 */
				unsubscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.un(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Subscribes viewmodel to server messages.
				 * @protected
				 */
				subscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.on(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Server message handler.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server message.
				 */
				onServerChannelMessage: function(scope, message) {
					if (message && message.Header && message.Header.Sender !== "ML") {
						return;
					}
					const body = this.Ext.decode(message.Body);
					switch (message.Header.BodyTypeName) {
						case "MLModelState":
							if (body.modelId === this.$Id) {
								this._updateModelStateByCode(body.state);
								if (body.sessionId) {
									this.set("TrainSessionId", body.sessionId, {silent: true});
								}
							}
							break;
						case "MLModelStateWithProgress":
							if (body.sessionId === this.$TrainSessionId) {
								this.set("TrainingProgress", body.progress, {silent: true});
								this._updateModelStateByCode(body.state);
							}
							break;
						default:
							break;
					}
				},

				/**
				 * Returns config to init train columns selection module.
				 * @protected
				 */
				getTrainColumnsSelectionModuleConfig: function() {
					return {
						"id": "TrainingQueryColumnSelectionModule",
						"renderTo": "TrainingQueryColumnSelectionModule",
						"instanceConfig": {
							"isSchemaConfigInitialized": true,
							"useHistoryState": false,
							"rootSchema": "RootSchema"
						}
					};
				},

				/**
				 * Returns caption of column path virtual column.
				 * @return {String}
				 */
				getVirtualColumnPathCaption: function(columnName) {
					return this.getEntityColumnCaption(columnName + "Path");
				},

				//endregion

				//region Methods: Public

				columnChanged: function() {
					this.updateMLExplanationModule();
					this._updateTrainButtonConfig();
				},

				columnTypeFilter: function(columnType) {
					return true;
				},

				/**
				 * Reloads ml explanation data.
				 * @protected
				 */
				updateMLExplanationModule: function() {
					this.sandbox.publish("ReloadMLExplanationsModule");
				},

				/**
				 * Handles changing target entity schema and sets appropriate schema UId.
				 */
				onRootSchemaChanged: function() {
					this.mixins.RootSchemaLookupMixin.onRootSchemaChanged.call(this);
					if (!this.get("RootSchemaInitialized")) {
						return;
					}
					this.set("TargetColumnUId", null);
					this.set("TargetColumn", null);
					this.set("PredictedResultColumnUId", null);
					this.set("PredictedResultColumn", null);
					this._initializeRootSchemaColumns(function() {
						this.updateTrainingFilterModule();
						this.updateBatchPredictionFilterUnitModule();
					}, this);
				},

				/**
				 * Processes key press in metadata text box.
				 * Requests service to automatically generate metadata when 'Ctrl+Alt+G' is pressed.
				 * @param {Object} event Keyboard event.
				 */
				metaDataOnKeyDown: function(event) {
					if (event && event.keyCode === Ext.EventObject.G && event.ctrlKey && event.altKey) {
						this.callService({
							serviceName: "MLUtilityService",
							methodName: "GenerateMetadata",
							data: {
								"selectText": this.get("TrainingSetQuery")
							}
						}, function(responseResult) {
							const disclaimer =
								"This metadata was generated automatically and should be verified manually!\n\n";
							const metadataString = JSON.stringify(responseResult.metadata, this._metadataReplacer, 4);
							this.set("MetaData", disclaimer + metadataString);
							this._initializeMetadata();
						}, this);
					}
				},

				/**
				 * Handles click on FAQ buttons to open Academy urls.
				 * @param {Object} btnArgA Reserved system argument.
				 * @param {Object} btnArgB Reserved system argument.
				 * @param {Object} btnArgC Reserved system argument.
				 * @param {Array} tag Attributes to create context help link.
				 */
				onFaqClick: function(btnArgA, btnArgB, btnArgC, tag) {
					this._sendGoogleTagManagerDataMLModelPage("MLModelFAQClick");
					if (tag.contextHelpId) {
						Terrasoft.AcademyUtilities.getUrl({
							contextHelpId: tag.contextHelpId,
							callback: function(url) {
								Ext.global.open(url);
							}
						});
						return;
					}
					const faqLink = this.get(tag.link);
					Ext.global.open(faqLink);
				},

				/**
				 * Returns FAQ photo image url.
				 * @return {String} Photo image url.
				 */
				getFaqIcon: function() {
					const resourceImage = this.get("Resources.Images.FAQIcon");
					return Terrasoft.ImageUrlBuilder.getUrl(resourceImage);
				},

				/**
				 * Returns consultation banner image url.
				 * @return {String} Consultation banner url.
				 */
				getConsultationBannerIcon: function () {
					const resourceImage = this.get("Resources.Images.ConsultationBanner");
					return Terrasoft.ImageUrlBuilder.getUrl(resourceImage);
				},

				/**
				 * Executes action of consultation to support.
				 */
				onConsultationBannerButtonClick: function () {
					SupportEmailHelper.callMailTo({
						sandbox: this.sandbox,
						mailSettingCode: "SupportEmailDef"
					});
				},

				/**
				 * Returns column caption for entity column.
				 * @param {String} columnName Entity column name.
				 * @return {String} Caption for entity column.
				 */
				getEntityColumnCaption: function(columnName) {
					return this.entitySchema.getColumnByName(columnName).caption;
				},

				/**
				 * Returns Metadata column caption.
				 * @return {String} Metadata column caption.
				 */
				getMetadataColumnCaption: function() {
					return this.getEntityColumnCaption("MetaData");
				},

				/**
				 * Returns RootSchema column caption depending on problem type.
				 * @return {String}
				 */
				getRootSchemaCaption: function() {
					return this.getEntityColumnCaption("RootSchemaUId");
				},

				/**
				 * Returns RootSchema column hint depending on problem type.
				 * @return {String}
				 */
				getRootSchemaHint: function() {
					return this.get("Resources.Strings.ChooseObjectStepTipCaption");
				},


				/**
				 * Prepare model for machine learning training.
				 */
				queryModelTraining: function() {
					if (!this.$IsChanged) {
						this.trainModel();
						return;
					}
					this.showConfirmationDialog(this.get("Resources.Strings.SavePageConfirmation"), function(result) {
						if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
							const config = {
								isSilent: true,
								callback: this.trainModel,
								scope: this
							};
							this.save(config);
						}
					}, ["yes", "no"]);
				},

				/**
				 * Executes machine learning training job.
				 */
				trainModel: function() {
					this._sendGoogleTagManagerDataMLModelPage("MLModelTrain");
					this.callService({
						serviceName: "MLTrainerService",
						methodName: "TrainModel",
						data: {
							"modelId": this.get("Id")
						}
					}, function(responseResult, response) {
						let message;
						const sessionState = responseResult.trainSessionState;
						this.setActiveTab("TrainingTab");
						this.runModelStateListener();
						if (!sessionState) {
							message = response.timedout
								? this.get("Resources.Strings.TrainModelActionTimedOutMessage")
								: this.get("Resources.Strings.TrainModelActionFailedMessage");
							this.warning(message);
							return;
						}
						const sessionStateValue = sessionState.value;
						if (!sessionStateValue) {
							message = sessionState.exceptionType === "IncorrectConfigurationException"
								? this.get("Resources.Strings.TrainModelActionWrongConfigMessage")
								: this.get("Resources.Strings.TrainModelActionFailedMessage");
							this.showInformationDialog(message);
							return;
						}
						this._updateModelStateByCode(sessionStateValue);
					}, this);
				},

				/**
				 * Handles TargetColumn change.
				 */
				onTargetColumnChanged: function() {
					this._setRootEntityColumnAttributeValue("TargetColumn");
					if (!this.get("RootSchemaInitialized")) {
						return;
					}
					const targetColumn = this.$TargetColumn;
					const predictedResultColumn = this.$PredictedResultColumn;
					if (!this.Ext.isEmpty(targetColumn) && !this.Ext.isEmpty(targetColumn.value) &&
						(this.Ext.isEmpty(predictedResultColumn) || this.Ext.isEmpty(targetColumn.value))) {
						this.$PredictedResultColumn = targetColumn;
					}
				},

				/**
				 * Handles PredictedResultColumn change.
				 */
				onPredictedResultColumnChanged: function() {
					this._setRootEntityColumnAttributeValue("PredictedResultColumn");
				},

				/**
				 * Loads values into combobox of column related to root entity.
				 * @param {String} filterValue ComboboxEdit value.
				 * @param {Terrasoft.core.collections.Collection} list List of comboboxEdit values.
				 */
				prepareRootEntityColumnList: function(filterValue, list) {
					if (this.Ext.isEmpty(list)) {
						return;
					}
					const targetObjectColumns = this.get("TargetObjectColumns");
					list.reloadAll(targetObjectColumns);
				},

				/**
				 * @inheritdoc Terrasoft.MLModelStateProgressBarUtils#getStateProgressBarValue
				 */
				getStateProgressBarValue: function(stateConfig) {
					return Terrasoft.MLModelStateProgressBarUtils.getStateProgressBarValue(stateConfig);
				},

				/**
				 * Returns true, when columns with specified dataValueType can
				 * be selected for current model page.
				 * @param dataValueType {Terrasoft.DataValueType} - type for check.
				 * @returns {boolean}
				 */
				columnDataValueTypeFilter: function(dataValueType) {
					return true;
				},

				/**
				 * Returns column collection for specified schema attribute.
				 * @param {String} attributeName name of schema attribute
				 * @returns {*}
				 */
				getSelectionModuleInfoCollection: function(attributeName) {
					return this.$ColumnCollection;
				},

				/**
				 * Get info for column selection module for specified schema attribute.
				 * @param {String} attributeName name of schema attribute
				 * @returns {*}
				 */
				getColumnSelectionModuleInfo: function(attributeName) {
					const selectionModuleInfo = {
						schema: this.get(attributeName),
						modelId: this.$Id,
						schemaColumns: this.get(attributeName + "Columns"),
						isCardCopyMode: this.isCopyMode(),
						columnDataValueTypeFilter: this.columnDataValueTypeFilter,
						columnCollection: this.getSelectionModuleInfoCollection(attributeName),
						sourceEntityId: this.$SourceEntityPrimaryColumnValue
					};
					return this.Ext.apply(selectionModuleInfo,
						this.getColumnSelectionModuleLocalizableStrings(attributeName));
				},

				/**
				 * Returns tags for all columns selection modules on page.
				 * @returns {*[]}
				 */
				getColumnSelectionModulesSandboxTags: function() {
					return ["TrainingQueryColumnSelectionModule"];
				},

				//endregion

				//region Methods: Protected override

				/**
				 * @inheritdoc BasePageV2#init
				 * @protected
				 * @override
				 */
				init: function(callback, scope) {
					const parentInit = this.getParentMethod();
					this._subscribeOnEvents();
					this.subscribeServerChannelEvents();
					if (this.getIsFeatureEnabled("DisableMLConsultationBanner")) {
						this.$IsConsultationBannerVisible = false;
					}
					Terrasoft.EntitySchemaManager.initialize(function() {
						this._initCollections();
						parentInit.call(this, function() {
							callback.call(scope);
						}, this);
					}, this);
				},

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @protected
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this._subscribeToColumnsSelectionModuleMessages();
					this._initUseAutomaticBatchPrediction();
					this.set("RootSchemaInitialized", false);
					this.set("ColumnCollection", this.Ext.create("Terrasoft.BaseViewModelCollection"));
					this.initializeRootSchema();
					this.initializeAdditionalSchemas();
					this.$IsAutomaticRetrainEnabled = (this.$TrainFrequency > 0);
					Terrasoft.SysSettings.querySysSettingsItem("MLModelTrainingAutoRefreshSeconds",
						function(value) {
							this.trainingStatusAutoRefreshTimeout = value;
						}, this);
					this._updateTrainButtonConfig();
					this._initializeMetadata();
					this._initializeRootSchemaColumns(function() {
						this._initializeTargetColumns();
						this.updateTrainingFilterModule();
						this.updateBatchPredictionFilterUnitModule();
						this.set("RootSchemaInitialized", true);
						const currentStateId =
							this.getLookupValue("State") || MLConfigurationConsts.ModelStates.NotStarted.id;
						if (!this._isFiniteStateId(currentStateId)) {
							this.runModelStateListener();
						}
						this._subscribeOnMLExplanationModuleMessages();
						this._loadTrainColumnsSelectionModule();
					}, this);
				},

				/**
				 * Method for additional schemas attributes initialization.
				 */
				initializeAdditionalSchemas: Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BasePageV2#save
				 * @override
				 */
				save: function() {
					if (!this.$IsAutomaticRetrainEnabled) {
						this.$TrainFrequency = 0;
					}
					this._separateMetadata();
					this.callParent(arguments);
					this._sendGoogleTagManagerDataMLModelPage("Save");
				},

				/**
				 * @inheritdoc BaseObject#onDestroy
				 * @override
				 */
				onDestroy: function() {
					this.unsubscribeServerChannelEvents();
					this._stopUpdateStateTask();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#saveEntityInChain
				 * @override
				 */
				saveEntityInChain: function(callback, scope) {
					const saveCallback = function() {
						const columnsSaveMethods = [];
						for (const tag of this.getColumnSelectionModulesSandboxTags()) {
							columnsSaveMethods.push(this.sandbox.publish("MLModelSaved", null, [tag]));
						}
						this.$IsColumnCollectionChanged = false;
						Terrasoft.chain(
							...columnsSaveMethods,
							function() {
								this.Ext.callback(callback, scope);
							}, this);
					};
					this.callParent([saveCallback.bind(this), scope]);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#getGoogleTagManagerData
				 * @param action {String} action tag to send.
				 * @protected
				 * @override
				 */
				getGoogleTagManagerData: function(action) {
					const data = this.callParent();
					this.Ext.apply(data, {
						action: action || "MLModelPageOpen",
						description: this.$MLProblemType.value,
						primaryColumnValue: this.getPrimaryColumnValue()
					});
					return data;
				},

				/**
				 * @inheritDoc Terrasoft.BasePageV2#getEntitySchemaQuery
				 * @overridden
				 */
				getEntitySchemaQuery: function() {
					const esq = this.callParent(arguments);
					if (esq.columns.contains("TrainErrorText")) {
						esq.columns.removeByKey("TrainErrorText");
					}
					esq.addColumn("LastTrainingError.Text", "TrainErrorText");
					return esq;
				},

				/**
				 * @inheritDoc Terrasoft.BasePageV2#isChanged
				 * @override
				 */
				isChanged: function() {
					const isChanged = this.callParent(arguments);
					return isChanged || this.$IsColumnCollectionChanged;
				},

				/**
				 * Returns Target expression group caption.
				 * @return {String}
				 */
				getTargetColumnGroupCaption: function() {
					return this.get("Resources.Strings.TargetColumnGroupCaption");
				},

				/**
				 * Returns Target expression group tip content.
				 * @return {String}
				 */
				getTargetColumnGroupInfoButtonContent: function() {
					return this.get("Resources.Strings.TargetColumnGroupInfoButtonContent");
				},

				/**
				 * Handles 'UseAutomaticBatchPrediction' toggled edit value changed.
				 * @param {Boolean} checked New value.
				 */
				onUseAutomaticBatchPredictionChanged: function(checked) {
					if (!this.$IsEntityInitialized) {
						return;
					}
					const value = (checked)
						? MLConfigurationConsts.MLTaskStartMethods.Automatically
						: MLConfigurationConsts.MLTaskStartMethods.Manually;
					if (this.getLookupValue("BatchPredictionStartMethod") !== value) {
						this.$BatchPredictionStartMethod = {
							value: value,
							displayValue: ""
						};
					}
				},

				/**
				 * Handles 'IsAutomaticRetrainEnabled' value changed.
				 */
				onIsAutomaticRetrainEnabledChanged: function() {
					if (!this.$IsEntityInitialized) {
						return;
					}
					if (this.$IsAutomaticRetrainEnabled && this.$TrainFrequency <= 0) {
						this.$TrainFrequency = this.defaultTrainFrequency;
					}
				},

				/**
				 * Returns Train button's caption.
				 * @return {String}
				 */
				getTrainButtonCaption: function() {
					const modelStates = MLConfigurationConsts.ModelStates;
					const currentStateId = this.getLookupValue("State") || modelStates.NotStarted.id;
					let suffix = null;
					let resourceName;
					if (currentStateId === modelStates.DataTransferring.id) {
						resourceName = "TrainModelButtonCaption_DataTransferring";
						if (this.$TrainingProgress > 0) {
							let recordsCount = this.$TrainingProgress;
							if (recordsCount > 1000) {
								recordsCount = (recordsCount / 1000) + 'K';
							}
							suffix = `(${recordsCount})`;
						}
					} else if (!this._isFiniteStateId(currentStateId)) {
						resourceName = "TrainModelButtonCaption_InProgress";
					} else if (this.$ModelInstanceUId) {
						resourceName = "TrainModelButtonCaption_Finished";
					} else {
						resourceName = "TrainModelButtonCaption_NotStarted";
					}
					let caption = this.get("Resources.Strings." + resourceName);
					if (suffix) {
						caption = caption + " " + suffix;
					}
					return caption;
				},

				/**
				 * Indicates that Train button is enabled.
				 * @return {Boolean}
				 */
				getIsTrainButtonEnabled: function() {
					const modelStates = MLConfigurationConsts.ModelStates;
					const currentStateId = this.getLookupValue("State") || modelStates.NotStarted.id;
					return this._isFiniteStateId(currentStateId);
				},

				//endregion

				//region Methods: Protected virtual

				/**
				 * Runs task for updating model state.
				 * @protected
				 */
				runModelStateListener: function() {
					this._stopUpdateStateTask();
					if (this.trainingStatusAutoRefreshTimeout <= 0) {
						return;
					}
					const task = this.Ext.TaskManager.newTask({
						run: this._updateStateTaskHandler,
						scope: this,
						fireOnStart: true,
						interval: this.trainingStatusAutoRefreshTimeout * 1000
					});
					this.updateStateTask = task;
					this.Ext.TaskManager.start(task);
				},

				/**
				 * Filters target object columns for displaying in list.
				 * @protected
				 * @virtual
				 * @param {Object} column Target object's column.
				 * @return {boolean|Boolean} True if column is suitable.
				 */
				filterTargetColumns: function(column) {
					return column.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.General;
				},

				/**
				 * @protected
				 * @return {String} Image url fro empty ml explanation data.
				 */
				getEmptyInfoImage: function() {
					const resourceImage = this.get("Resources.Images.EmptyInfoImage");
					return Terrasoft.ImageUrlBuilder.getUrl(resourceImage);
				},

				/**
				 * @inheritdoc BasePageV2#onKeyDown
				 * @protected
				 * @override
				 */
				onKeyDown: function(event) {
					if (event.altKey && event.ctrlKey && event.keyCode === event.A) {
						event.preventDefault();
						this.set("IsAdvancedMode", true);
						return false;
					}
					this.callParent(arguments);
				},

				getColumnSelectionModuleLocalizableStrings: function(attributeName) {
					return {
						title: this.get("Resources.Strings.TrainingQueryFieldsGroupCaption"),
						helpText: this.get("Resources.Strings.TrainingQueryFieldsGroupInfoButtonContent")
					};
				},

				/**
				 * Returns text for training error label.
				 */
				getTrainErrorText: function () {
					return `<h3>${this.get("Resources.Strings.TrainErrorTextTitle")}</h3>${this.get("TrainErrorText")}`;
				},

				/**
				 * Indicates that train error lable is visible.
				 * @returns {boolean}
				 */
				isTrainErrorVisible: function () {
					return !!this.get("TrainErrorText");
				},

				/**
				 * Reloads training columns selection module on card rerender.
				 */
				updateTrainingQueryColumnSelectionModule: function () {
					this._updateColumnSelectionModule(this._loadTrainColumnsSelectionModule);
				}

				//endregion

			},
			modules: /**SCHEMA_MODULES*/{
				"MetricIndicator": {
					"moduleId": "c54af51c-0947-4958-adb9-796c42da1cd0",
					"moduleName": "CardWidgetModule",
					"config": {
						"parameters": {
							"viewModelConfig": {
								"widgetKey": "MLModelPageMetricIndicator",
								"recordId": "dc755ef4-81e9-4ccb-b72a-831d1d6fcb84"
							}
						}
					}
				},
				"MLExplanationModule": {
					"moduleId": "cd8f28c4-a95c-4127-b067-5b067000f089",
					"config": {
						"schemaName": "MLPredictionExplanation",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"IsModalBoxMode": false
							}
						}
					}
				}
			}/**SCHEMA_MODULES*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "CardContentWrapper",
					"values": {
						"wrapClass": ["card-content-container", "ml-model-card-content-container"]
					}
				},
				{
					"name": "TrainButton",
					"parentName": "LeftContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.GREEN,
						"caption": {"bindTo": "TrainButtonCaption"},
						"click": {"bindTo": "queryModelTraining"},
						"enabled": {"bindTo": "IsTrainButtonEnabled"},
						"markerValue": "TrainButton"
					}
				},

				// Left
				{
					"name": "Name",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						}
					}
				},
				{
					"name": "MLProblemType",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"enabled": false
					}
				},
				{
					"name": "RootSchema",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"enabled": {"bindTo": "isAddMode"},
						"tip": {
							"content": {"bindTo": "getRootSchemaHint"}
						},
						"wrapClass": ["root-schema-control-container"]
					}
				},
				{
					"name": "StateProgressBar",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.BaseProgressBar",
						"maxValue": 5,
						"value": {
							"bindTo": "State",
							"bindConfig": {"converter": "getStateProgressBarValue"}
						}
					}
				},
				{
					"name": "PredictionEnabled",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.PedictionEnabledTip"}
						},
						"wrapClass": ["prediction-enabled-control-container"]
					}
				},
				{
					"name": "MetricIndicator",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 24,
							"rowSpan": 3,
							"column": 0,
							"row": 8,
							"layoutName": "ProfileContainer",
							"useFixedColumnHeight": false
						},
						"itemType": Terrasoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": [
								"card-widget-grid-layout-item"
							]
						},
						"visible": {"bindTo": "_getIsMetricIndicatorVisible"}
					}
				},
				{
					"name": "ConsultationBannerContainer",
					"parentName": "LeftModulesContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "MLConsultationBannerContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "ConsultationBannerContainer",
						"visible": {
							"bindTo": "IsConsultationBannerVisible"
						}
					}
				},
				{
					"name": "ConsultationBannerImage",
					"parentName": "ConsultationBannerContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "MLConsultationBannerImage",
						"getSrcMethod": "getConsultationBannerIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["ml-consultation-banner"]
						}
					}
				},
				{
					"name": "ConsultationBannerText",
					"parentName": "ConsultationBannerContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.ConsultationBannerText",
						"classes": {
							"labelClass": ["ml-consultation-banner-text"]
						}
					}
				},
				{
					"name": "ConsultationBannerButton",
					"parentName": "ConsultationBannerContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": ["ml-consultation-banner-button"]
						},
						"click": {"bindTo": "onConsultationBannerButtonClick"},
						"caption": "$Resources.Strings.ConsultationBannerButtonCaption"
					}
				},
				{
					"name": "FaqContainer",
					"parentName": "LeftModulesContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"markerValue": "FaqContainer"
					}
				},
				{
					"name": "FaqIcon",
					"parentName": "FaqContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getFaqIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["profile-icon"]
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 4
						}
					}
				},
				{
					"name": "FaqUrls",
					"parentName": "FaqContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "FaqUrls",
						"layout": {
							"column": 4,
							"row": 0,
							"colSpan": 20
						}
					}
				},
				{
					"name": "FaqHeaderCaption",
					"parentName": "FaqUrls",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.FAQContainerCaption"
						},
						"classes": {
							"labelClass": ["faq-header", "label-green-color"]
						}
					}
				},
				{
					"name": "PredictiveAnalysisAcademyUrl",
					"parentName": "FaqUrls",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": ["faq-button", "base-edit-link"]
						},
						"click": {"bindTo": "onFaqClick"},
						"caption": "$Resources.Strings.PredictiveAnalysisAcademyCaption",
						"tag": {"link": "Resources.Strings.PredictiveAnalysisAcademyUrl"}
					}
				},
				{
					"name": "BusinessProcessAcademyUrl",
					"parentName": "FaqUrls",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": ["faq-button", "base-edit-link"]
						},
						"click": {"bindTo": "onFaqClick"},
						"caption": "$Resources.Strings.BusinessProcessAcademyCaption",
						"tag": {"contextHelpId": 1950}
					}
				},
				{
					"name": "MLServiceAcademyUrl",
					"parentName": "FaqUrls",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": ["faq-button", "base-edit-link"]
						},
						"click": {"bindTo": "onFaqClick"},
						"caption": "$Resources.Strings.MLServiceAcademyCaption",
						"tag": {"contextHelpId": 15756}
					}
				},

				// Right
				{
					"name": "ModelSettingsTab",
					"parentName": "Tabs",
					"operation": "insert",
					"index": 0,
					"propertyName": "tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ModelSettingsTabCaption"
						},
						"items": []
					}
				},
				{
					"name": "AdvancedModelSettingsTab",
					"parentName": "Tabs",
					"operation": "insert",
					"index": 1,
					"propertyName": "tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.AdvancedModelSettingsTabCaption"
						},
						"items": []
					}
				},
				{
					"name": "TrainingTab",
					"parentName": "Tabs",
					"operation": "insert",
					"index": 2,
					"propertyName": "tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.TrainingTabCaption"
						},
						"items": []
					}
				},
				{
					"name": "MLExplanationContainer",
					"parentName": "TrainingTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["ml-explanation-widget"],
						"items": []
					}
				},
				{
					"name": "EmptyExplanationMessage",
					"parentName": "MLExplanationContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"wrapClass": ["empty-training-data-message"],
						"visible": {"bindTo": "_getIsModelHasNoTrainingExplanations"},
						"markerValue": "EmptyExplanationMessage",
						"items": [
							{
								"name": "EmptyExplanationImage",
								"classes": {
									wrapClass: ["image-container"]
								},
								"getSrcMethod": "getEmptyInfoImage",
								"onPhotoChange": Terrasoft.emptyFn,
								"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
							},
							{
								"name": "MLExplanationsNoDataLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"caption": "$Resources.Strings.NoTrainingData",
								"labelConfig": {
									"classes": ["placeholder-label"]
								}
							}
						]
					}
				},
				{
					"name": "MLExplanationModule",
					"parentName": "MLExplanationContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"visible": {"bindTo": "_getIsModelHasTrainingExplanations"}
					}
				},
				{
					"name": "TrainSessions",
					"parentName": "TrainingTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"name": "NotesTab",
					"parentName": "Tabs",
					"operation": "insert",
					"index": 3,
					"propertyName": "tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.NotesTabCaption"
						},
						"items": []
					}
				},
				{
					"name": "Files",
					"parentName": "NotesTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"name": "NotesControlGroup",
					"parentName": "NotesTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"name": "Notes",
					"parentName": "NotesControlGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"contentType": Terrasoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"labelConfig": {"visible": false},
						"controlConfig": {
							"imageLoaded": {"bindTo": "insertImagesToNotes"},
							"images": {"bindTo": "NotesImagesCollection"}
						}
					}
				},
				{
					"name": "TargetColumnGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "getTargetColumnGroupCaption"},
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["target-column-control-group"]
						}
					}
				},
				{
					"name": "TargetColumnGroupInfoButton",
					"parentName": "TargetColumnGroup",
					"operation": "insert",
					"index": 1,
					"propertyName": "tools",
					"values": {
						"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"content": {"bindTo": "getTargetColumnGroupInfoButtonContent"},
						"behaviour": {
							"displayEvent": Terrasoft.TipDisplayEvent.HOVER
						},
						"controlConfig": {
							"classes": {
								"wrapperClass": "rootentity-info-button-control-group"
							}
						}
					}
				},
				{
					"name": "TargetColumnGroupGrid",
					"parentName": "TargetColumnGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"visible": {
							"bindTo": "TargetColumnEnabled"
						},
						"items": []
					}
				},
				{
					"name": "TargetColumn",
					"parentName": "TargetColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 12
						},
						"bindTo": "TargetColumn",
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"labelConfig": {"visible": false},
						"controlConfig": {
							"className": "Terrasoft.ComboBoxEdit",
							"classes": ["target-column"],
							"prepareList": {
								"bindTo": "prepareRootEntityColumnList"
							}
						},
						"visible": {
							"bindTo": "TargetColumnEnabled"
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
					}
				},
				{
					"name": "AdvancedQuerySettingsGroup",
					"parentName": "AdvancedModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.AdvancedQuerySettingsGroupCaption",
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["advanced-query-control-group"],
							"collapsed": true
						}
					}
				},
				{
					"name": "AdvancedQuerySettingsGroupInfoButton",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"index": 1,
					"propertyName": "tools",
					"values": {
						"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.AdvancedQuerySettingsGroupInfoButtonContent",
						"behaviour": {
							"displayEvent": Terrasoft.TipDisplayEvent.HOVER
						},
						"controlConfig": {
							"classes": {
								"wrapperClass": "rootentity-info-button-control-group",
								"imageClass": "rootentity-info-button-image"
							}
						}
					}
				},
				{
					"name": "TrainingSetQueryLabel",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getEntityColumnCaption"
						},
						"tag": "TrainingSetQuery",
						"labelConfig": {
							"classes": ["memo-label"]
						}
					}
				},
				{
					"name": "TrainingSetQuery",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"contentType": this.Terrasoft.ContentType.RICH_TEXT,
						"generator": "SourceCodeEditGenerator.generate",
						"id": "TrainingSetQuery",
						"markerValue": "TrainingSetQuery"
					}
				},
				{
					"name": "MetaDataLabel",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getEntityColumnCaption"
						},
						"tag": "MetaData",
						"labelConfig": {
							"classes": ["memo-label"]
						}
					}
				},
				{
					"name": "MetaData",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"value": {"bindTo": "MetadataWithLcz"},
						"contentType": this.Terrasoft.ContentType.RICH_TEXT,
						"generator": "SourceCodeEditGenerator.generate",
						"showLineNumbers": false,
						"id": "MetaData",
						"markerValue": "MetaData",
						"keydown": {"bindTo": "metaDataOnKeyDown"}
					}
				},
				{
					"name": "BatchPredictionQueryLabel",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getEntityColumnCaption"
						},
						"tag": "BatchPredictionQuery",
						"labelConfig": {
							"classes": ["memo-label"]
						},
						"visible": {
							"bindTo": "BatchPredictionEnabled"
						}
					}
				},
				{
					"name": "BatchPredictionQuery",
					"parentName": "AdvancedQuerySettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"contentType": this.Terrasoft.ContentType.RICH_TEXT,
						"generator": "SourceCodeEditGenerator.generate",
						"id": "BatchPredictionQuery",
						"markerValue": "BatchPredictionQuery",
						"visible": {
							"bindTo": "BatchPredictionEnabled"
						}
					}
				},
				{
					"name": "AdvancedModelParametersGroup",
					"parentName": "AdvancedModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.AdvancedModelParametersGroupCaption",
						"tools": [],
						"items": []
					}
				},
				{
					"name": "TrainingMinimumRecordsCount",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {}
				},
				{
					"name": "TrainingMaxRecordsCount",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {}
				},
				{
					"name": "TrainingFilterDataContainer",
					"parentName": "FilterForTrainingGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "TrainingFilterDataContainer",
						"selectors": {"wrapEl": "#TrainingFilterDataContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["training-filters-container"],
						"beforererender": {bindTo: "unloadTrainingFilterUnitModule"},
						"afterrender": {bindTo: "updateTrainingFilterModule"},
						"afterrerender": {bindTo: "updateTrainingFilterModule"}
					}
				},
				{
					"name": "TrainErrorText",
					"parentName": "FilterForTrainingGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "TrainErrorText",
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.HtmlControl",
						"htmlContent": {"bindTo": "getTrainErrorText"},
						"visible": {"bindTo": "isTrainErrorVisible"}
					}
				},
				{
					"name": "FilterForTrainingGroupEmptyRootSchemaLabel",
					"parentName": "FilterForTrainingGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.RootSchemaNotSet",
						"visible": {
							"bindTo": "getIsRootSchemaNotSet"
						},
						"labelConfig": {
							"classes": ["placeholder-label"]
						}
					}
				},
				{
					"name": "FilterForTrainingGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "MLFilterForTrainingGroup",
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.FilterForTrainingGroupCaption",
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["training-filter-control-group"]
						}
					}
				},
				{
					"name": "PredictedResultColumnGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.PredictedResultColumnGroupCaption",
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["predicted-result-control-group"]
						}
					}
				},
				{
					"name": "PredictedResultColumnGroupGrid",
					"parentName": "PredictedResultColumnGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"name": "PredictedResultColumnGroupInfoButton",
					"parentName": "PredictedResultColumnGroup",
					"operation": "insert",
					"index": 1,
					"propertyName": "tools",
					"values": {
						"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.PredictedResultColumnGroupInfoButtonContent",
						"behaviour": {
							"displayEvent": Terrasoft.TipDisplayEvent.HOVER
						},
						"controlConfig": {
							"classes": {
								"wrapperClass": "rootentity-info-button-control-group"
							}
						}
					}
				},
				{
					"name": "PredictedResultColumn",
					"parentName": "PredictedResultColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 12
						},
						"bindTo": "PredictedResultColumn",
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"labelConfig": {"visible": false},
						"controlConfig": {
							"className": "Terrasoft.ComboBoxEdit",
							"classes": ["predicted-result-column"],
							"prepareList": {
								"bindTo": "prepareRootEntityColumnList"
							}
						},
						"tip": {
							"content": "$Resources.Strings.PredictedResultColumnTip"
						}
					}
				},

				{
					"name": "TrainingSettingsGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.TrainingSettingsGroupCaption",
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["training-settings-control-group"]
						}
					}
				},
				{
					"name": "AutomaticRetrainToggleEdit",
					"parentName": "TrainingSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"bindTo": "IsAutomaticRetrainEnabled",
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"className": "Terrasoft.ToggleEdit"
						},
						"wrapClass": ["toggle-edit"]
					}
				},
				{
					"name": "AutomaticRetrainToggleEditLabel",
					"parentName": "TrainingSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.AutomaticRetrainToggleEditCaption",
						"labelConfig": {
							"classes": ["toggle-edit-label"]
						}
					}
				},
				{
					"name": "TrainingSettingsGroupGrid",
					"parentName": "TrainingSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"name": "TrainingSettingsInfoButton",
					"parentName": "TrainingSettingsGroup",
					"operation": "insert",
					"index": 1,
					"propertyName": "tools",
					"values": {
						"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.TrainingSettingsInfoButtonCaption",
						"behaviour": {
							"displayEvent": Terrasoft.TipDisplayEvent.HOVER
						},
						"controlConfig": {
							"classes": {
								"wrapperClass": "rootentity-info-button-control-group",
								"imageClass": "rootentity-info-button-image"
							}
						}
					}
				},
				{
					"name": "TrainFrequency",
					"parentName": "TrainingSettingsGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"caption": "$Resources.Strings.RetrainLabelCaption",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 12
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.RetrainTip"}
						}
					}
				},
				{
					"name": "MetricThreshold",
					"parentName": "TrainingSettingsGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 12,
							"row": 0,
							"colSpan": 12
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.LowerMetricTip"}
						}
					}
				},

				{
					"name": "BatchPredictionSettingsGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.BatchPredictionSettingsGroupCaption",
						"tools": [],
						"items": [],
						"controlConfig": {
							"classes": ["batch-prediction-settings-control-group"],
							"visible": {"bindTo": "BatchPredictionEnabled"}
						}
					}
				},
				{
					"name": "BatchPredictionStartMethodToggleEdit",
					"parentName": "BatchPredictionSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"bindTo": "UseAutomaticBatchPrediction",
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"className": "Terrasoft.ToggleEdit",
							"checked": {
								"bindTo": "UseAutomaticBatchPrediction"
							},
							"checkedchanged": {
								"bindTo": "onUseAutomaticBatchPredictionChanged"
							}
						},
						"wrapClass": ["toggle-edit"]
					}
				},
				{
					"name": "BatchPredictionStartMethodToggleEditLabel",
					"parentName": "BatchPredictionSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.BatchPredictionStartMethodToggleEditCaption",
						"labelConfig": {
							"classes": ["toggle-edit-label"]
						}
					}
				},
				{
					"name": "BatchPredictionFilterDataLabel",
					"parentName": "BatchPredictionSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.BatchPredictionFilterLabelCaption",
						"labelConfig": {
							"classes": ["batch-prediction-filters-label"]
						},
						"visible": {
							"bindTo": "UseAutomaticBatchPrediction"
						}
					}
				},
				{
					"name": "BatchPredictionFilterDataContainer",
					"parentName": "BatchPredictionSettingsGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"id": "BatchPredictionFilterDataContainer",
						"selectors": {"wrapEl": "#BatchPredictionFilterDataContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["batch-prediction-filters-container"],
						"beforererender": {"bindTo": "unloadBatchPredictionFilterUnitModule"},
						"afterrender": {"bindTo": "updateBatchPredictionFilterUnitModule"},
						"afterrerender": {"bindTo": "updateBatchPredictionFilterUnitModule"},
						"visible": {
							"bindTo": "UseAutomaticBatchPrediction"
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});


