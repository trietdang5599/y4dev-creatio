Terrasoft.configuration.Structures["MLModelSection"] = {innerHierarchyStack: ["MLModelSectionML", "MLModelSection"], structureParent: "BaseSectionV2"};
define('MLModelSectionMLStructure', ['MLModelSectionMLResources'], function(resources) {return {schemaUId:'5d3640fc-761c-45e6-9d10-2fdbae4c19f5',schemaCaption: "MLModelSection", parentSchemaName: "BaseSectionV2", packageName: "MLSequencePrediction", schemaName:'MLModelSectionML',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MLModelSectionStructure', ['MLModelSectionResources'], function(resources) {return {schemaUId:'a6c36952-8b61-4cb2-bf4f-35a5a0ddf2c7',schemaCaption: "MLModelSection", parentSchemaName: "MLModelSectionML", packageName: "MLSequencePrediction", schemaName:'MLModelSection',parentSchemaUId:'5d3640fc-761c-45e6-9d10-2fdbae4c19f5',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MLModelSectionML",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MLModelSectionMLResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MLModelSectionML", ["SupportEmailHelper", "MLModelPageResources", "ControlGridModule", "GridUtilitiesV2",
		"MLModelStateProgressBarUtils", "GoogleTagManagerUtilities", "css!MLModelStateProgressBarUtils",
		"css!MLModelSectionCSS"],
	function(SupportEmailHelper, modelPageResources) {
		return {
			entitySchemaName: "MLModel",
			messages: {
				/**
				 * @message TrainButtonConfigUpdated
				 * Subscribes on information about current Train button's configuration.
				 */
				"TrainButtonConfigUpdated": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Train button's caption.
				 */
				"TrainButtonCaption": {
					"dataValueType": Terrasoft.DataValueType.TEXT
				},
				/**
				 * Indicates that train button is enabled.
				 */
				"IsTrainButtonEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN
				}
			},
			properties: {
				shouldShowConsultationProfileKey: "shouldShowConsultation",
				sectionShowedCountProfileKey: "sectionShowedCount"
			},
			methods: {

				/**
				 * Sends Google tag manager data.
				 * Note. This approach is slightly different from the standard one, because:
				 *  - Terrasoft.BasePageV2#sendGoogleTagManagerData is overridden as empty function;
				 *  - This approach does not require synthetic property for custom action tag.
				 * @param {String} modelActionTag Custom action tag.
				 * @private
				 */
				_sendGoogleTagManagerDataML: function(modelActionTag) {
					const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
					if (!isGoogleTagManagerEnabled) {
						return;
					}
					const data = this.getGoogleTagManagerData(modelActionTag);
					Terrasoft.GoogleTagManagerUtilities.actionModule(data);
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
						action: action
					});
					return data;
				},

				/**
				 * Loads value from profile by the given key.
				 * @param {String} key Profile key.
				 * @param {*} defaultValue Value will be returned if not data in profile.
				 */
				loadValueFromProfile: function (key, defaultValue) {
					const profile = this.getProfile() || {};
					const value = profile[key];
					return Ext.isEmpty(value) ? defaultValue : value;
				},

				/**
				 * Saves value to profile by the given key.
				 * @private
				 * @param {String} key Profile key.
				 * @param {*} value Value to save.
				 */
				saveProfileKeyValue: function (key, value) {
					const profileData = this.getProfile() || {};
					profileData[key] = value;
					Terrasoft.utils.saveUserProfile(this.getProfileKey(), profileData, false, function() {
						this.set("Profile", profileData);
					}, this);
				},

				/**
				 * Saves counter of section visits.
				 * @private
				 */
				saveSectionVisit: function () {
					const sectionShowedCount = this.loadValueFromProfile(this.sectionShowedCountProfileKey, 0);
					this.saveProfileKeyValue(this.sectionShowedCountProfileKey, sectionShowedCount + 1);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#init
				 * @override
				 */
				init: function (callback, scope) {
					this.callParent([function () {
						this.saveSectionVisit();
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
				 * @override
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "Terrasoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ExecuteJobActionCaption"
						},
						"Click": {
							bindTo: "executeMLTrainerJob"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.OpenMLProblemTypeLookup"
						},
						"Click": {
							bindTo: "openMLProblemTypeLookup"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * Executes machine learning training job.
				 */
				executeMLTrainerJob: function() {
					this.callService({
						serviceName: "MLTrainerService",
						methodName: "ExecuteModelTrainerJob"
					}, function() {
						this.showInformationDialog(this.get("Resources.Strings.ExecuteJobActionMessage"));
					});
				},

				/**
				 * Opens MLProblemType lookup.
				 */
				openMLProblemTypeLookup: function() {
					this.showBodyMask();
					this.set("IgnoreFilterUpdate", true);
					this.saveCardScroll();
					this.scrollCardTop();
					var newHash = this.Terrasoft.combinePath("LookupSectionModule", "BaseLookupConfigurationSection");
					this.sandbox.publish("PushHistoryState", {
						hash: newHash,
						silent: true,
						stateObj: {
							caption: this.get("Resources.Strings.MLProblemTypeLookupCaption"),
							entitySchemaName: "MLProblemType"
						}
					});
					this.sandbox.loadModule("LookupSectionModule", {
						renderTo: this.renderTo,
						id: this.sandbox.id + "_BaseLookupConfigurationSection",
						keepAlive: true
					});
				},

				/**
				 * @inheritdoc BaseSectionV2#subscribeSandboxEvents
				 * @protected
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("TrainButtonConfigUpdated",
						function(config) {
							this.$TrainButtonCaption = config.caption;
							this.$IsTrainButtonEnabled = config.enabled;
						}, this, this.getCardModuleSandboxIdentifiers());
					this.callParent(arguments);
				},

				/**
				 * Passes indicator config by reference.
				 * @param {Object} control Configuration object.
				 * @override
				 */
				applyControlConfig: function(control) {
					control.config = {
						className: "Terrasoft.BaseProgressBar",
						value: {
							"bindTo": "State",
							"bindConfig": {"converter": "getStateValue"}
						},
						width: "158px"
					};
				},

				/**
				 * @inheritdoc Terrasoft.GridUtilitiesV2#addColumnLink
				 * @override
				 */
				addColumnLink: function(item) {
					item.getStateValue = function(state) {
						return Terrasoft.MLModelStateProgressBarUtils.getStateProgressBarValue(state);
					};
					return this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"name": "TrainButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.core.enums.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.GREEN,
						"caption": {"bindTo": "TrainButtonCaption"},
						"enabled": {"bindTo": "IsTrainButtonEnabled"},
						"click": {"bindTo": "onCardAction"},
						"tag": "queryModelTraining",
						"markerValue": "TrainButton"
					}
				}, {
					"name": "DataGrid",
					"operation": "merge",
					"values": {
						"className": "Terrasoft.ControlGrid",
						"controlColumnName": "State",
						"applyControlConfig": {"bindTo": "applyControlConfig"}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});

define("MLModelSection", ["MLConfigurationConsts"],
	function(mlConsts) {
		return {
			entitySchemaName: "MLModel",
			methods: {
				/**
				 *Returns MLModel edit pages. Without a SequencePrediction page if the feature MLSequencePrediction is disabled
				 * @protected
				 * @return {Terrasoft.BaseViewModelCollection | null} Edit pages for ML models.
				 */
				getMLModelSectionEditPagesForAddButton: function () {
					const editPages = this.$EditPages;
					const sequencePredictionDisabled = !Terrasoft.Features.getIsEnabled("MLSequencePrediction");
					if (sequencePredictionDisabled) {
						const sequencePredictionProblemType = mlConsts.ProblemTypes.SequencePrediction;
						return editPages.filterByFn(editPage => editPage.$Tag !== sequencePredictionProblemType);
					}
					return editPages;
				},

				/**
				 * Edit pages converter
				 * @private	 
				 */
				editPagesConverter: function(editPages) {
					if (editPages.getCount() > 1) {
						return editPages;
					} else {
						return null;
					}
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "getMLModelSectionEditPagesForAddButton",
									"bindConfig": {"converter": "editPagesConverter"}
								}
							}
						}
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeAddRecordButton",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "getMLModelSectionEditPagesForAddButton",
									"bindConfig": {"converter": "editPagesConverter"}
								}
							}
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});

