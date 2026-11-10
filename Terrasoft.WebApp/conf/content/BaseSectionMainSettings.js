Terrasoft.configuration.Structures["BaseSectionMainSettings"] = {innerHierarchyStack: ["BaseSectionMainSettings"]};
define('BaseSectionMainSettingsStructure', ['BaseSectionMainSettingsResources'], function(resources) {return {schemaUId:'14f4b7e5-7687-41e9-b43c-e323c8d6d945',schemaCaption: "Section - Main settings (without minipages and visas)", parentSchemaName: "", packageName: "CrtWizards7x", schemaName:'BaseSectionMainSettings',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("BaseSectionMainSettings", [
	"BaseSectionMainSettingsResources",
	"ApplicationStructureWizardUtils",
	"SectionInWorkplaceManager",
	"DesignTimeEnums",
	"ModuleSectionEnums",
	"BaseWizardStepSchemaMixin",
	"LookupUtilitiesV2"
], function() {
	return {
		messages: {
			/**
			 * Publishing message for package identifier request.
			 */
			"GetPackageUId": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Publishing message for updating wizard steps configuration.
			 */
			"UpdateWizardConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Publishing message for HistoryState request.
			 */
			"GetHistoryState": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Publishing message for update HistoryState.
			 */
			"ReplaceHistoryState": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Subscribing on message for return multi page settings.
			 */
			"GetSysModuleSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 */
			"GetEntitySchemaInstance": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Publishing when update multi page settings.
			 */
			"ChangeModuleSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Publishing message for check multi page settings validate.
			 */
			"ValidateMultiPageSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Subscribing on message for change multi page settings.
			 */
			"PageSettingsChanged": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Subscribing on message who call when SysModuleSettings is initialized.
			 */
			"SysModuleSettingsInitialized": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Subscribing on message who call when SectionPageSettings module is initialized.
			 */
			"SectionPageSettingsInitialized": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Publishing message to actualize SysModuleEntity settings.
			 */
			"ActualizeSysModuleEntitySettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 */
			"SaveSectionPageSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Subscribing on message who call when Visa module settings is initialized.
			 */
			"VisaModuleSettingsInitialized": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Publishing message for saving section visa settings.
			 */
			"SaveSectionVisaSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			BaseWizardStepSchemaMixin: "Terrasoft.BaseWizardStepSchemaMixin"
		},
		attributes: {

			/**
			 * Initialized.
			 */
			"Initialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				onChange: "onCaptionChange",
				dependencies: [
					{
						columns: ["PropertyInitialized", "MultiPageInitialized", "SectionPageSettingsInitialized",
							"VisaSettingsInitialized"],
						methodName: "onInitialized"
					}
				]
			},

			/**
			 * Indicates if VisaSettings initialized.
			 */
			"VisaSettingsInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * PropertyInitialized.
			 */
			"PropertyInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * MultiPageInitialized.
			 */
			"MultiPageInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Indicates if SectionPageSettings initialized.
			 */
			"SectionPageSettingsInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Caption.
			 */
			"Caption": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onCaptionChange",
				isRequired: true,
				value: null
			},

			/**
			 * Code.
			 */
			"Code": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onCodeChange",
				isRequired: true,
				value: null
			},

			/**
			 * System section.
			 */
			"IsSystem": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onIsSystemChange",
				value: null
			},

			/**
			 * Code prefix.
			 */
			"CodePrefix": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Default icon URL.
			 */
			"DefaultIconSrc": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Background icon color.
			 */
			"IconBackground": {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: "",
				onChange: "onIconBackgroundChange",
			},

			/**
			 * Entity schema UId.
			 */
			"EntitySchemaUId": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Icon.
			 */
			"Icon": {
				dataValueType: Terrasoft.DataValueType.IMAGE,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Indicates if section is new.
			 */
			"IsNewSection": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Package identifier.
			 */
			"PackageUId": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Section manager item.
			 */
			"SectionManagerItem": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Top control group header.
			 */
			"TopControlGroupHeader": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Selected workplace.
			 */
			"Workplace": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "onWorkplaceChange",
				value: null
			},

			/**
			 * List of all workplaces.
			 */
			"WorkplacesList": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Section in workplace manager item.
			 */
			"SectionInWorkplaceManagerItem": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Code enabled.
			 */
			"IsCodeEnabled": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Global search available.
			 * @protected
			 */
			"GlobalSearchAvailable": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false,
				onChange: "onGlobalSearchAvailableChange"
			},

			/**
			 * Global search enabled tag.
			 * @protected
			 */
			"IsGlobalSearchEnabled": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Duplication rule exists tag.
			 * @protected
			 */
			"IsDuplicationRuleExists": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Section types enum.
			 * @protected
			 */
			"SectionTypes": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * @private
			 */
			"SelectExistObjectSearchData": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * @private
			 */
			"SelectExistObjectSearchColumn": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				value: null
			}
		},
		modules: {
			"MultiPageModule": {
				config: {
					schemaName: "BaseSectionPageSettings",
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			},
			"VisaSettingsModule": {
				config: {
					schemaName: "SectionVisaSettings",
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_generateSchemaNameUniquePart: function() {
				return Terrasoft.generateGUID().substring(0, 8);
			},

			/**
			 * @private
			 */
			_applyModuleEntitySchema: function(sysModuleEntityManagerItem) {
				const entitySchemaUId = sysModuleEntityManagerItem.getEntitySchemaUId();
				const entitySchemaManagerItem = Terrasoft.EntitySchemaManager.getItem(entitySchemaUId);
				this.set("ModuleEntitySchema", entitySchemaManagerItem.instance);
			},

			/**
			 * Method return instance of EntitySchemaManagerItem.
			 * @private
			 * @param {Function} next Callback method.
			 * @param {Terrasoft.manager.EntitySchemaManagerItem} entitySchemaManagerItem Manager item.
			 */
			_getEntitySchemaInstanceChain: function(next, entitySchemaManagerItem) {
				const config = {
					packageUId: this.get("packageUId"),
					schemaUId: entitySchemaManagerItem.getEntitySchemaUId()
				};
				Terrasoft.EntitySchemaManager.forceGetPackageSchema(config, function(entitySchema) {
					this.set("ModuleEntitySchema", entitySchema);
					next();
				}, this);
			},

			/**
			 * Show EntitySchema validation message for user and clear the code field.
			 * @param {String} message Text message.
			 * @private
			 */
			showEntitySchemaValidationMessage: function(message) {
				Terrasoft.showMessage({
					caption: message,
					buttons: ["ok"],
					defaultButton: 0,
					style: Terrasoft.MessageBoxStyles.BLUE,
					handler: this.entitySchemaValidationHandler,
					scope: this
				});
			},

			/**
			 * Empty code.
			 * @private
			 */
			entitySchemaValidationHandler: function() {
				this.set(this.codeColumnName, "");
			},

			/**
			 * Returns flag indicating that the properties are initialized.
			 * @private
			 * @return {Boolean}
			 */
			_getIsInitialized: function() {
				const columns = this.getSubModulesIsInitedColumns();
				columns.push("SectionPageSettingsInitialized");
				const notInitializedProperty = _.find(columns, function(column) {
					return !this.get(column);
				}, this);
				const initialized = Ext.isEmpty(notInitializedProperty);
				return initialized;
			},

			/**
			 * @private
			 */
			_findExistingEntitySchemaItem: function(callback, scope) {
				const entitySchemaUId = this.get(this.entitySchemaUIdColumnName);
				if (entitySchemaUId) {
					const manager = Terrasoft.EntitySchemaManager;
					const managerItem = manager.findItem(entitySchemaUId);
					const name = managerItem.name;
					manager.getPackageSchemaInstanceBySchemaName(name, this.$packageUId, (instance) => {
						const item = Terrasoft.EntitySchemaManager.findItem(instance.uId);
						callback.call(scope, item);
					}, this);
				} else {
					callback.call(scope, null);
				}
			},

			/**
			 * @private
			 */
			_setEntitySchemaCaption: function(value) {
				if (this.getIsSspSection()) {
					return;
				}
				this._findExistingEntitySchemaItem((entitySchemaItem) => {
					if (entitySchemaItem && entitySchemaItem.packageUId === this.$packageUId) {
						entitySchemaItem.setLocalizableStringPropertyValue("caption", value);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_subscribeSectionPageSettingsMessages: function() {
				const tag = this.getSectionPageSettingsModuleId();
				this.sandbox.subscribe("GetSysModuleSettings", this.onGetSysModuleSettings, this, [tag]);
				this.sandbox.subscribe("SectionPageSettingsInitialized", this.onSectionPageSettingsInitialized, this, [tag]);
				this.sandbox.subscribe("GetEntitySchemaInstance", this._onGetEntitySchemaInstance, this, [tag]);
				this.sandbox.subscribe("PageSettingsChanged", this.onPageSettingsChanged, this, [tag]);
			},

			/**
			 * @private
			 */
			_subscribeMultiPageSettingsMessages: function() {
				const tag = this.getMultiPageSettingsModuleId();
				this.sandbox.subscribe("GetSysModuleSettings", this.onGetSysModuleSettings, this, [tag]);
				this.sandbox.subscribe("SysModuleSettingsInitialized", this.onSysModuleSettingsInitialized, this, [tag]);
				this.sandbox.subscribe("GetEntitySchemaInstance", this._onGetEntitySchemaInstance, this, [tag]);
				this.sandbox.subscribe("PageSettingsChanged", this.onPageSettingsChanged, this, [tag]);
			},

			/**
			 * @private
			 */
			_subscribeVisaSettingsMessages: function() {
				const tag = this.getVisaSettingsModuleId();
				this.sandbox.subscribe("GetSysModuleSettings", this.onGetSysModuleSettings, this, [tag]);
				this.sandbox.subscribe("VisaModuleSettingsInitialized", this.onVisaModuleSettingsInitialized, this, [tag]);
				this.sandbox.subscribe("GetEntitySchemaInstance", this._onGetEntitySchemaInstance, this, [tag]);
			},

			/**
			 * @private
			 */
			_validateEntitySchemaName: function(name) {
				const info = this.validateCode(name, this.columns.Code);
				const isValid = Ext.isEmpty(info.invalidMessage);
				if (!isValid) {
					this._showTryAgainMessage(info.invalidMessage);
				}
				return isValid;
			},

			/**
			 * @private
			 */
			_showEntityIsViewMessage: function() {
				const message = this.get("Resources.Strings.EntityIsViewMessage");
				this._showTryAgainMessage(message);
			},

			/**
			 * @private
			 */
			_showCurrentPackageSettingsErrorMessage: function() {
				const packageUId = this.get("packageUId");
				Terrasoft.chain(
					function(next) {
						Terrasoft.PackageManager.getPackageInfo([packageUId], next, this);
					},
					function(next, packageInfo) {
						const packageName = packageInfo[packageUId];
						const template = this.get("Resources.Strings.CurrentPackageSettingsErrorMessage");
						const message = Ext.String.format(template, packageName);
						this._showTryAgainMessage(message);
					}, this
				);
			},

			/**
			 * @private
			 */
			_checkPrimaryDisplayColumn: function(entitySchema, callback, scope) {
				if (entitySchema.primaryDisplayColumn) {
					Ext.callback(callback, scope);
				} else {
					const message = this.get("Resources.Strings.PrimaryDisplayColumnRequiredMessage");
					this._showTryAgainMessage(message);
				}
			},

			/**
			 * @private
			 */
			_checkExistSection: function(schemaUId, callback, scope) {
				Terrasoft.chain(
					function(next) {
						Terrasoft.SysModuleEntityManager.findItemsByEntitySchemaUId(schemaUId, next, this);
					},
					function(next, sysModuleEntities) {
						const existsSection = sysModuleEntities.any(function(sysModuleEntity) {
							const sectionManagerItems = Terrasoft.SectionManager.getItems();
							return sectionManagerItems.any(function(sectionManagerItem) {
								return sectionManagerItem.getSysModuleEntityId() === sysModuleEntity.getId();
							}, this);
						}, this);
						if (existsSection) {
							const message = this.get("Resources.Strings.EntitySectionExistsMessage");
							this._showTryAgainMessage(message);
						} else {
							Ext.callback(callback, scope);
						}
					}, this
				);
			},

			/**
			 * @private
			 */
			_checkParentSchema: function(entitySchema, callback, scope) {
				const deniedParentUIds = [
					Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_FOLDER,
					Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_FOLDER,
					Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_TAG,
					Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_TAG
				];
				if (Terrasoft.contains(deniedParentUIds, entitySchema.parentUId)) {
					const message = this.get("Resources.Strings.EntityUsingInExistSectionMessage");
					this._showTryAgainMessage(message);
				} else {
					Ext.callback(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_showTryAgainMessage: function(message) {
				const tryAgainButton = {
					className: "Terrasoft.Button",
					caption: this.get("Resources.Strings.TryAgainMessageButtonCaption"),
					markerValue: "tryAgain",
					returnCode: "tryAgain",
					style: Terrasoft.controls.ButtonEnums.style.BLUE
				};
				Terrasoft.showMessage({
					caption: message,
					buttons: [tryAgainButton, Terrasoft.MessageBoxButtons.CANCEL],
					defaultButton: 0,
					style: Terrasoft.MessageBoxStyles.BLUE,
					handler: function(buttonCode) {
						if (buttonCode === tryAgainButton.returnCode) {
							this.onSelectExistObjectButtonClick.call(this);
						} else {
							this.set("SelectExistObjectSearchData", "");
							this.set("SelectExistObjectSearchColumn", null);
						}
					},
					scope: this
				});
			},

			/**
			 * @private
			 */
			_checkPrefix: function(entitySchema, callback, scope) {
				if (Terrasoft.EntitySchemaManager.startWithPrefix(entitySchema.name)) {
					callback.call(scope, entitySchema);
				} else {
					Terrasoft.showMessage({
						caption: this.get("Resources.Strings.ForeignPublisherMessage"),
						buttons: ["ok"],
						defaultButton: 0,
						style: Terrasoft.MessageBoxStyles.BLUE,
						handler: callback.bind(scope, entitySchema),
						scope: this
					});
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * Returns column names array. This columns used as child modules initiated flags.
			 * @protected
			 * @return {Array[]} Column names array.
			 */
			getSubModulesIsInitedColumns: function() {
				return ["PropertyInitialized", "VisaSettingsInitialized"];
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#initLookupQuickAddMixin
			 * @override
			 */
			initLookupQuickAddMixin: function(next, scope) {
				Ext.callback(next, scope);
			},

			/**
			 * Sets properties to viewModel.
			 * @protected
			 * @param {Object} config Section configuration.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			setProperties: function(config, callback, scope) {
				Terrasoft.chain(
					function(next) {
						this.setSectionTypes(config);
						this.setColumnNames();
						this.setSectionManagerItem(config);
						this.setIsNewSection();
						this.setTopControlGroupHeader();
						this.setCaption();
						this.setGlobalSearchAvailable();
						this.setCode();
						this.setIsSystem();
						this.setDefaultIconSrc();
						this.setIcon();
						this.setIconBackground();
						this.setValidationConfig();
						this.initWorkplacesList(next, this);
					},
					this.setGlobalSearchEnabled,
					function(next) {
						this.setCodePrefix(next, this);
					},
					function(next) {
						this.setWorkplace(next, this);
					},
					function(next) {
						Terrasoft.EntitySchemaManager.initialize(next, this);
					},
					function(next) {
						this.getSysModuleEntityManagerItem(null, next, this);
					},
					function(next, sysModuleEntityManagerItem) {
						this.setEntitySchemaUId(sysModuleEntityManagerItem);
						const entitySchemaUId = sysModuleEntityManagerItem.getEntitySchemaUId();
						this.set("IsCodeEnabled", Ext.isEmpty(entitySchemaUId));
						next(entitySchemaUId);
					},
					function(next, entitySchemaUId) {
						this.setDuplicationRuleExists(entitySchemaUId, function() {
							next(entitySchemaUId);
						}, this);
					},
					function(next, entitySchemaUId) {
						const entitySchemaManager = Terrasoft.EntitySchemaManager;
						if (this.get(this.isNewSectionColumnName) && !this.getIsSspSection()) {
							this.renderSchemaNamePrefix();
						}
						if (Terrasoft.isEmpty(entitySchemaUId)) {
							return Ext.callback(callback, scope);
						}
						entitySchemaManager.forceGetPackageSchema({
							packageUId: this.get("packageUId"),
							schemaUId: entitySchemaUId
						}, function(entitySchema) {
							this.set("ModuleEntitySchema", entitySchema);
							if (this.getIsSspSection() && this.$IsNewSection &&
								!entitySchemaManager.findItem(entitySchema.uId)) {
								entitySchemaManager.addSchema(entitySchema);
							}
							Ext.callback(callback, scope);
						}, this);
					},
					this
				);
			},

			/**
			 * Sets section types attribute.
			 * @protected
			 * @param {Object} config Section item config.
			 * @param {Object} config.sectionTypes Section types enum.
			 */
			setSectionTypes: function(config) {
				this.$SectionTypes = Terrasoft.deepClone(config.sectionTypes);
			},

			/**
			 * Sets IsDuplicationRuleExists value.
			 * @protected
			 * @param {Guid} entitySchemaUid Manager entity schema uid.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			setDuplicationRuleExists: function(entitySchemaUid, callback, scope) {
				if (!this.get("IsGlobalSearchEnabled")) {
					this.set("IsDuplicationRuleExists", false);
					Ext.callback(callback, scope);
					return;
				}
				this.callService({
					data: entitySchemaUid,
					serviceName: "DuplicatesRuleService",
					methodName: "CheckIsDuplicationRuleExist"
				}, function(response) {
					this.set("IsDuplicationRuleExists", response && response.isExists);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Sets IsGlobalSearchEnabled value.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			setGlobalSearchEnabled: function(callback, scope) {
				Terrasoft.SysSettings.querySysSettings(["GlobalSearchConfigServiceUrl", "GlobalSearchUrl"],
					function(sysSettings) {
						const isFeaturesEnabled = this.getIsFeatureEnabled("GlobalSearch") &&
							this.getIsFeatureEnabled("GlobalSearch_V2");
						this.set("IsGlobalSearchEnabled", isFeaturesEnabled &&
							!Ext.isEmpty(sysSettings.GlobalSearchConfigServiceUrl) &&
							!Ext.isEmpty(sysSettings.GlobalSearchUrl));
						Ext.callback(callback, scope);
					}, this);
			},

			/**
			 * Sets viewModel column names.
			 * @protected
			 */
			setColumnNames: function() {
				this.captionColumnName = "Caption";
				this.codeColumnName = "Code";
				this.codePrefixColumnName = "CodePrefix";
				this.defaultIconSrcColumnName = "DefaultIconSrc";
				this.entitySchemaUIdColumnName = "EntitySchemaUId";
				this.iconColumnName = "Icon";
				this.isNewSectionColumnName = "IsNewSection";
				this.packageUIdColumnName = "PackageUId";
				this.sectionManagerItemColumnName = "SectionManagerItem";
				this.topControlGroupHeaderColumnName = "TopControlGroupHeader";
				this.workplaceColumnName = "Workplace";
				this.workplacesListColumnName = "WorkplacesList";
			},

			/**
			 * Sets section manager item to viewModel.
			 * @protected
			 * @param {Object} config Section configuration.
			 */
			setSectionManagerItem: function(config) {
				const appStructureItem = config && config.applicationStructureItem;
				this.set("packageUId", config && config.packageUId);
				if (Ext.isEmpty(appStructureItem)) {
					throw new Terrasoft.ItemNotFoundException({
						message: this.get("Resources.Strings.SectionManagerItemNotFoundExceptionMessage")
					});
				}
				this.set(this.sectionManagerItemColumnName, appStructureItem);
			},

			/**
			 * Sets isSectionNew indicator to viewModel.
			 * @protected
			 */
			setIsNewSection: function() {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				this.set(this.isNewSectionColumnName, sectionManagerItem.getIsNew());
			},

			/**
			 * Sets top control group settings label to viewModel.
			 * @protected
			 */
			setTopControlGroupHeader: function() {
				const labelCaption = this.get("Resources.Strings.SectionSettingsLabel");
				this.set(this.topControlGroupHeaderColumnName, labelCaption);
			},

			/**
			 * Sets caption value to viewModel.
			 * @protected
			 */
			setCaption: function() {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				const caption = (sectionManagerItem && sectionManagerItem.getCaption()) || "";
				this.set(this.captionColumnName, caption, {silent: true});
			},

			/**
			 * Sets global search available to view model.
			 * @protected
			 */
			setGlobalSearchAvailable: function() {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				const globalSearchAvailable = sectionManagerItem && sectionManagerItem.getGlobalSearchAvailable();
				this.set("GlobalSearchAvailable", Boolean(globalSearchAvailable));
			},

			/**
			 * Sets code value to viewModel.
			 * @protected
			 */
			setCode: function() {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				let code = (sectionManagerItem && sectionManagerItem.getCode()) || "";
				if (this.get("IsNewSection") && !this.getIsSspSection()) {
					code = code.replace(Terrasoft.EntitySchemaManager.getSchemaNamePrefix(), "");
				}
				this.set(this.codeColumnName, code, {silent: true});
			},

			/**
			 * Sets code value to viewModel.
			 * @protected
			 */
			setIsSystem: function() {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				const isSystem = (sectionManagerItem && sectionManagerItem.getIsSystem()) || false;
				this.set("IsSystem", isSystem, {silent: true});
			},

			/**
			 * Sets code prefix to viewModel.
			 * @param {Object} next Callback.
			 * @param {Object} scope Context.
			 * @protected
			 */
			setCodePrefix: function(next, scope) {
				Terrasoft.SysSettings.querySysSettings(["SchemaNamePrefix"], function(settings) {
					this.set(this.codePrefixColumnName, settings.SchemaNamePrefix || "");
					Ext.callback(next, scope);
				}, this);
			},

			/**
			 * Initializes workplaces list.
			 * @protected
			 * @param {Function} callback Callback function
			 * @param {Object} scope Callback function context.
			 */
			initWorkplacesList: function(callback, scope) {
				if (!this.get(this.isNewSectionColumnName)) {
					Ext.callback(callback, scope);
					return;
				}
				this.set(this.workplacesListColumnName, Ext.create("Terrasoft.Collection"));
				this.getWorkplacesListQuery(callback, scope);
			},

			/**
			 * Gets tip message for Code control.
			 * @protected
			 * @return {String} Tip message for Code control.
			 */
			getCodeTipMessage: function() {
				return Ext.String.format(this.get("Resources.Strings.NewSectionCodeMessage"),
					this.get(this.codePrefixColumnName));
			},

			/**
			 * Gets workplaces list from database.
			 * @param {Object} callback Function.
			 * @param {Object} scope Context.
			 * @protected
			 */
			getWorkplacesListQuery: function(callback, scope) {
				const select = new Terrasoft.EntitySchemaQuery("SysWorkplace");
				select.addColumn("Id");
				select.addColumn("Name");
				select.getEntityCollection(function(response) {
					if (response.success) {
						const items = response.collection.getItems();
						this.initWorkplacesConfig(items);
						Ext.callback(callback, scope);
					}
				}, this);
			},

			/**
			 * Initializes workplace configuration for workplace combo-box.
			 * @protected
			 * @param {Object} items Workplaces items.
			 */
			initWorkplacesConfig: function(items) {
				this.workplacesConfig = {};
				Terrasoft.each(items, function(item) {
					const workplaceId = item.get("Id");
					this.workplacesConfig[workplaceId] = {
						value: workplaceId,
						displayValue: item.get("Name")
					};
				}, this);
			},

			/**
			 * Returns new section default workplace.
			 * @protected
			 * @return {Object} Workplace lookup value.
			 */
			getDefaultWorkplace: function() {
				const currentState = this.sandbox.publish("GetHistoryState");
				const workplaceId = currentState.hash.recordId;
				if (this.getIsSspSection() && this.get("IsNewSection")) {
					return this.workplacesConfig[workplaceId];
				}
				return null;
			},

			/**
			 * Sets workplace.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope callback scope.
			 */
			setWorkplace: function(callback, scope) {
				const sectionManagerItem = this.get("SectionManagerItem");
				Terrasoft.chain(
					function(next) {
						sectionManagerItem.getSectionInWorkplaceManagerItems(next, this);
					},
					function(next, sectionInWorkplaceManagerItems) {
						if (sectionInWorkplaceManagerItems.isEmpty()) {
							const config = {
								propertyValues: {
									id: Terrasoft.generateGUID(),
									section: {value: sectionManagerItem.getId()}
								}
							};
							Terrasoft.SectionInWorkplaceManager.createItem(config, next, this);
						} else {
							next(sectionInWorkplaceManagerItems.getByIndex(0));
						}
					},
					function(next, sectionInWorkplaceManagerItem) {
						this.set("SectionInWorkplaceManagerItem", sectionInWorkplaceManagerItem);
						const workplaceId = sectionInWorkplaceManagerItem.getWorkplaceId();
						const workplace = Ext.isEmpty(workplaceId)
							? this.getDefaultWorkplace()
							: {
								value: workplaceId,
								displayValue: sectionInWorkplaceManagerItem.getWorkplaceName()
							};
						this.set("Workplace", workplace);
						callback.call(scope);
					}, this
				);
			},

			/**
			 * Sets default icon URl to viewModel.
			 * @protected
			 */
			setDefaultIconSrc: function() {
				const defaultIcon = this.get("Resources.Images.DefaultIcon");
				this.set(this.defaultIconSrcColumnName, this.getIconSrc(defaultIcon));
			},

			/**
			 * Sets icon to viewModel.
			 * @protected
			 * @param {String} imageId Image identifier.
			 */
			setIcon: function(imageId) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				let id = imageId ? imageId : sectionManagerItem.getLeftPanelLogo();
				if (!id || !Terrasoft.isGUID(id) || Terrasoft.isEmptyGUID(id)) {
					id = Terrasoft.DesignTimeEnums.DefaultIcon.SECTION_DEFAULT_ICON_ID;
				}
				sectionManagerItem.setLeftPanelLogo(id);
				const icon = {
					source: Terrasoft.ImageSources.ENTITY_COLUMN,
					params: {
						schemaName: "SysImage",
						columnName: "Data",
						primaryColumnValue: id
					}
				};
				this.set(this.iconColumnName, icon);
			},

			/**
			 * Gets icon URL.
			 * @protected
			 * @param {Object} icon Icon config.
			 * @return {String} Icon URL.
			 */
			getIconSrc: function(icon) {
				icon = icon || this.get(this.iconColumnName);
				if (!Ext.isEmpty(icon)) {
					return Terrasoft.ImageUrlBuilder.getUrl(icon);
				}
			},

			/**
			 * Sets icon background value to viewModel.
			 * @protected
			 */
			setIconBackground: function() {
				if(this.getIsEnabledChangeBackgroundIconColor7x()) {
					const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
					const iconBacgroundColor = (sectionManagerItem && sectionManagerItem.getIconBackground()) || "";
					this.set("IconBackground", Terrasoft.ModuleSectionEnums.BackgroundColors[iconBacgroundColor], {silent: true});
				}				
			},

			/**
			 * Sets entity schema UId value to viewModel.
			 * @protected
			 * @param {Object} sysModuleEntityManagerItem SysModuleEntityManagerItem.
			 */
			setEntitySchemaUId: function(sysModuleEntityManagerItem) {
				const entitySchemaUId = sysModuleEntityManagerItem && sysModuleEntityManagerItem.getEntitySchemaUId();
				this.set(this.entitySchemaUIdColumnName, entitySchemaUId);
			},

			/**
			 * Subscribes sandbox to messages.
			 * @protected
			 */
			subscribeMessages: function() {
				this._subscribeSectionPageSettingsMessages();
				this._subscribeVisaSettingsMessages();
			},

			/**
			 * Handler for dependency change Initialize property.
			 * @protected
			 */
			onInitialized: function() {
				if (this._getIsInitialized()) {
					this.hideBodyMask();
				}
			},

			/**
			 * Handler for message VisaModuleSettingsInitialized.
			 * @protected
			 */
			onVisaModuleSettingsInitialized: function() {
				this.set("VisaSettingsInitialized", true);
			},

			/**
			 * Handler for message SysModuleSettingsInitialized.
			 * @protected
			 */
			onSysModuleSettingsInitialized: function() {
				this.set("MultiPageInitialized", true);
			},

			/**
			 * Handler for message SectionPageSettingsInitialized.
			 * @protected
			 */
			onSectionPageSettingsInitialized: function() {
				this.set("SectionPageSettingsInitialized", true);
			},

			/**
			 * @private
			 */
			_onGetEntitySchemaInstance: function() {
				return this.get("ModuleEntitySchema");
			},

			/**
			 * Handler for GetSysModuleSettings message.
			 * @param {String} senderId Sender message ID.
			 * @protected
			 */
			onGetSysModuleSettings: function(senderId) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				if (sectionManagerItem) {
					sectionManagerItem.getSysModuleEntityManagerItem(function(sysModuleEntityManagerItem) {
						if (sysModuleEntityManagerItem) {
							this.sandbox.publish("ChangeModuleSettings", {
								"sysModuleEntityUId": sysModuleEntityManagerItem.id,
								"packageUId": this.get("packageUId"),
								"sectionManagerItemId": sectionManagerItem.getId(),
								"sectionTypes": Terrasoft.deepClone(this.$SectionTypes)
							}, [senderId]);
						}
					}, this);
				}
			},

			/**
			 * Handler for PageSettingsChanged message.
			 * @protected
			 */
			onPageSettingsChanged: function() {
				const sectionManagerItem = this.get("SectionManagerItem");
				this.sandbox.publish("UpdateWizardConfig", sectionManagerItem, [this.sandbox.id]);
				Terrasoft.chain(
					function(next) {
						sectionManagerItem.getSysModuleEntityManagerItem(next, this);
					},
					function(next, moduleEntity) {
						this.afterPageSettingsChanged(moduleEntity);
					}, this
				);
			},

			/**
			 * After page settings changed event handler.
			 * @protected
			 * @virtual
			 * @param {Object} moduleEntity Changed manager item.
			 */
			afterPageSettingsChanged: Terrasoft.emptyFn,

			/**
			 * Processes section parameters validation on save/left wizard action.
			 * @protected
			 */
			onValidate: function() {
				let isValid = this.validate();
				if (isValid) {
					const tag = this.getSectionPageSettingsModuleId();
					isValid = this.sandbox.publish("ValidateMultiPageSettings", null, [tag]);
				}
				Terrasoft.chain(
					function(next) {
						if (this.createNewSectionEntitiesInProgress) {
							this.createNewSectionEntities(next);
						} else {
							next();
						}
					},
					function() {
						this.mixins.BaseWizardStepSchemaMixin.publishValidationResult.call(this, isValid);
					}, this
				);
			},

			/**
			 * Processes section parameters saving on save/left wizard action.
			 * @protected
			 */
			onSave: function() {
				Terrasoft.chain(
					function(next) {
						const tag = this.getSectionPageSettingsModuleId();
						this.sandbox.publish("SaveSectionPageSettings", next, [tag]);
					},
					function(next) {
						this.saveAditionalInfo(next, this);
					},
					function(next) {
						if (this.validate()) {
							this.showBodyMask();
							this.saveSection(next, this);
						}
					},
					function() {
						this.hideBodyMask();
						const saveResult = this.get(this.sectionManagerItemColumnName);
						this.mixins.BaseWizardStepSchemaMixin.publishSavingResult.call(this, saveResult);
					}, this
				);
			},

			/**
			 * Any aditional save steps.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			saveAditionalInfo: function(callback, scope) {
				Terrasoft.chain(
					function(next) {
						this.sandbox.publish("SaveSectionVisaSettings", next);
					},
					function() {
						Ext.callback(callback, scope);
					},
					this
				);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepSchemaMixin#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config, next, scope) {
				this.setProperties(config, function() {
					this.set("PropertyInitialized", true);
					Ext.callback(next, scope);
				}, this);
			},

			/**
			 * Processes caption control value changing.
			 * @protected
			 * @param {Object} model Model.
			 * @param {String} value Changed value.
			 */
			onCaptionChange: function(model, value) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.setCaption(value);
				this._setEntitySchemaCaption(value);
				if (this.validate()) {
					this._findExistingEntitySchemaItem((entitySchemaItem) => {
						if (!entitySchemaItem) {
							this.createNewSectionEntities();
						}
					}, this);
				}
			},

			/**
			 * Processes IsSystem control value changing.
			 * @protected
			 * @param {Object} model Model.
			 * @param {String} value Changed value.
			 */
			onIsSystemChange: function(model, value) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.setIsSystem(value);
			},

			/**
			 * Processes code control value changing.
			 * @protected
			 * @param {Object} model Model.
			 * @param {String} value Changed value.
			 */
			onCodeChange: function() {
				const isNewSection = this.get(this.isNewSectionColumnName);
				if (isNewSection && this.validate() && this.validateEntitySchemaExist()) {
					this.createNewSectionEntities();
				}
			},

			/**
			 * Handler for click on SelectExistObjectButton.
			 * @protected
			 */
			onSelectExistObjectButtonClick: function() {
				const config = {
					lookupConfig: {
						entitySchemaName: "VwSysEntitySchemaInWorkspace",
						lookupPostfix: "_SelectExistObject",
						filters: this.getSelectExistObjectFilters(),
						hideActions: true,
						settingsButtonVisible: false,
						multiSelect: false,
						captionLookup: this.get("Resources.Strings.SelectExistObjectLookupPageCaption"),
						searchColumn: this.get("SelectExistObjectSearchColumn"),
						searchValue: this.get("SelectExistObjectSearchData")
					},
					sandbox: this.sandbox
				};
				Terrasoft.LookupUtilities.open(config, this.onSelectExistObjectButtonCallback, this);
			},

			/**
			 * Returns filter for SelectExistObject lookup window.
			 * @protected
			 * @return {Terrasoft.FilterGroup} Collection of filters.
			 */
			getSelectExistObjectFilters: function() {
				const filters = Terrasoft.createFilterGroup();
				filters.logicalOperation = Terrasoft.LogicalOperatorType.AND;
				const comparisonTypeNotStartWith = Terrasoft.ComparisonType.NOT_START_WITH;
				const sysFilters = Terrasoft.createFilterGroup();
				sysFilters.name = "sysFilters";
				sysFilters.logicalOperation = Terrasoft.LogicalOperatorType.OR;
				sysFilters.add("NotSysFilter", Terrasoft.createColumnFilterWithParameter(
					comparisonTypeNotStartWith, "Name", "Sys", Terrasoft.DataValueType.TEXT
				));
				const notInFilter = Terrasoft.createColumnInFilterWithParameters("Name", [
					"SysAdminUnit", "SysAdminUnitInRole", "SysUserInRole", "SysTranslation"
				]);
				notInFilter.comparisonType = Terrasoft.ComparisonType.EQUAL;
				sysFilters.add("SysFilter", notInFilter);
				filters.add("ExcludeSysEntity", sysFilters);
				filters.add("CurrentWorkspaceFilter", Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "SysWorkspace.Id", Terrasoft.SysValue.CURRENT_WORKSPACE.value,
					Terrasoft.DataValueType.TEXT
				));
				filters.add("EntitySchemaManagerFilter", Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "ManagerName", this.managerName, Terrasoft.DataValueType.TEXT
				));
				filters.add("ExtendParentFalseFilter", Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "ExtendParent", false, Terrasoft.DataValueType.BOOLEAN
				));
				return filters;
			},

			/**
			 * Callback for SelectExistObjectButton.
			 * @protected
			 * @param {Object} response Response object.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			onSelectExistObjectButtonCallback: function(response, callback, scope) {
				this.set("SelectExistObjectSearchData", response.searchData);
				this.set("SelectExistObjectSearchColumn", response.searchColumn);
				const selectedRows = response.selectedRows;
				if (selectedRows.isEmpty()) {
					return;
				}
				const selectedRecord = selectedRows.first();
				const entityId = selectedRecord.Id;
				const packageUId = this.get("packageUId");
				Terrasoft.chain(
					function(next) {
						Terrasoft.EntitySchemaManager.getSchemaUIdById(entityId, next, this);
					},
					function(next, schemaUId) {
						this.checkExistEntitySchema(schemaUId, packageUId, next, this);
					},
					function(next, entitySchema) {
						this._checkPrefix(entitySchema, next, this);
					},
					function(next, entitySchema) {
						this._createExistingObjectNewSectionEntities({entitySchema, packageUId}, next, this);
					},
					function(next, name, caption) {
						this._setExistingObjectSectionSettings({name, caption}, callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_setExistingObjectSectionSettings: function({name, caption}, callback, scope) {
				this._removeSchemaNamePrefix();
				this.$Code = name;
				this.$Caption = caption;
				Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_createExistingObjectNewSectionEntities: function({entitySchema, packageUId}, next, scope) {
				const name = entitySchema.getName();
				const rootItem = Terrasoft.EntitySchemaManager.findRootSchemaItemByName(entitySchema.name);
				const caption = entitySchema.getDisplayValue();
				const existEntityUId = rootItem.uId;
				const config = {
					existEntityUId,
					name,
					caption,
					packageUId
				};
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.setCaption(caption);
				sectionManagerItem.setCode(name);
				this.createNewSectionEntities(() => {
					Ext.callback(next, scope, [name, caption]);
				}, config);
			},

			/**
			 * Check entity schema allow use for new section.
			 * @protected
			 * @param {String} schemaUId Entity schema UId.
			 * @param {String} packageUId Current package UId.
			 * @param {Function} callback Callback function.
			 * @param {Terrasoft.EntitySchema} callback.entitySchema Entity schema instance.
			 * @param {Object} scope Callback scope.
			 */
			checkExistEntitySchema: function(schemaUId, packageUId, callback, scope) {
				let entitySchema = null;
				Terrasoft.chain(
					function(next) {
						Terrasoft.EntitySchemaManager.forceGetPackageSchema({schemaUId, packageUId}, next, this);
					},
					function(next, _entitySchema) {
						if (_entitySchema) {
							entitySchema = _entitySchema;
							this._checkParentSchema(entitySchema, next, this);
						} else {
							this._showCurrentPackageSettingsErrorMessage();
						}
					},
					function(next) {
						if (!this._validateEntitySchemaName(entitySchema.name)) {
							return;
						}
						if (entitySchema.isDBView) {
							this._showEntityIsViewMessage();
							return;
						}
						this._checkPrimaryDisplayColumn(entitySchema, next, this);
					},
					function(next) {
						this._checkExistSection(schemaUId, next, this);
					},
					function() {
						Ext.callback(callback, scope, [entitySchema]);
					}, this
				);
			},

			/**
			 * Validates entity schema exists by Code attributes.
			 * @protected
			 * @return {Boolean}
			 */
			validateEntitySchemaExist: function() {
				const code = this.get(this.codeColumnName);
				const validateResult = Terrasoft.ApplicationStructureWizardUtils.validateEntitySchemaExist(code);
				const result = validateResult.isValid;
				if (!result) {
					this.showEntitySchemaValidationMessage(validateResult.message);
				}
				return result;
			},

			/**
			 * Create new section entities.
			 * @protected
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [config] Configuration object.
			 * @param {String} [config.existEntityUId] Exist entity identifier.
			 * @param {String} [config.name] Entity name.
			 * @param {String} [config.caption] Entity caption.
			 * @param {String} [config.packageUId] Package unique identifier.
			 */
			createNewSectionEntities: function(callback, config) {
				this.createNewSectionEntitiesCallback = callback;
				if (this.createNewSectionEntitiesInProgress) {
					return;
				}
				this.createNewSectionEntitiesInProgress = true;
				this.createNewSectionEntitySchemas(config, function(sysModuleEntityManagerItem) {
					this.set("IsCodeEnabled", false);
					this.hideBodyMask();
					const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
					const message = {
						"sysModuleEntityUId": sysModuleEntityManagerItem.id,
						"packageUId": this.get("packageUId"),
						"sectionManagerItemId": sectionManagerItem.getId(),
						"sectionTypes": Terrasoft.deepClone(this.$SectionTypes)
					};
					this._applyModuleEntitySchema(sysModuleEntityManagerItem);
					this.publishChangeModuleSettingsMessage(message);
					this.createNewSectionEntitiesInProgress = false;
					Ext.callback(this.createNewSectionEntitiesCallback);
				}, this);
			},

			/**
			 * Sends ChangeModuleSettings message to child modules.
			 * @protected
			 * @param {Object} message Changed properties config.
			 */
			publishChangeModuleSettingsMessage: function(message) {
				this.sandbox.publish("ChangeModuleSettings", message, [this.getMultiPageSettingsModuleId()]);
				this.sandbox.publish("ChangeModuleSettings", message, [this.getVisaSettingsModuleId()]);
			},

			/**
			 * Returns VisaSettingsModule id.
			 * @protected
			 * @return {String}
			 */
			getVisaSettingsModuleId: function() {
				return Ext.String.format("{0}_module_VisaSettingsModule", this.sandbox.id);
			},

			/**
			 * Executes validation code.
			 * @protected
			 * @param {String} value Column value.
			 * @param {Object} column Column to validate.
			 * @return {Object} Validation message.
			 */
			validateCode: function(value, column) {
				let code, validators;
				let userPrefix = this.get(this.codePrefixColumnName);
				if (this.get("IsNewSection")) {
					if (userPrefix.length > 0 && !value.startsWith(userPrefix)) {
						code = userPrefix + value;
					}
					validators = [this.validateCodeValue, this.validateCodeValueLength];
				} else {
					code = value;
				}
				return this.executeValidation(validators, code, column);
			},

			/**
			 * Processes workplace changing.
			 * @protected
			 */
			onWorkplaceChange: function() {
				const sectionInWorkplaceManager = Terrasoft.SectionInWorkplaceManager;
				const sectionInWorkplaceManagerItem = this.get("SectionInWorkplaceManagerItem");
				const workplace = this.get("Workplace");
				const workplaceId = workplace && workplace.value;
				const currentItemId = sectionInWorkplaceManagerItem.getId();
				const currentItem = sectionInWorkplaceManager.findItem(currentItemId);
				if (Terrasoft.isGUID(workplaceId)) {
					if (Ext.isEmpty(currentItem)) {
						sectionInWorkplaceManager.addItem(sectionInWorkplaceManagerItem);
					}
					sectionInWorkplaceManagerItem.setWorkplace(workplace);
				} else {
					sectionInWorkplaceManager.discardItem(sectionInWorkplaceManagerItem);
				}
			},

			/**
			 * Processes icon control value changing.
			 * @protected
			 * @param {Object} icon Changed icon.
			 */
			onIconChange: function(icon) {
				if (Ext.isEmpty(icon)) {
					const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
					sectionManagerItem.setLeftPanelLogo(null);
					this.set(this.iconColumnName, null);
					return;
				}
				const config = {
					file: icon,
					onComplete: this.setIcon,
					onError: Ext.emptyFn,
					scope: this
				};
				Terrasoft.ImageApi.upload(config);
			},

			/**
			 * Processes GlobalSearchAvailable control value changing.
			 * @param {model} model Model.
			 * @param {value} value Changed value.
			 */
			onGlobalSearchAvailableChange: function(model, value) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.setGlobalSearchAvailable(value);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator(this.captionColumnName, this.validateCaption);
				this.addColumnValidator(this.codeColumnName, this.validateCode);
			},

			/**
			 * Executes validation caption.
			 * @protected
			 * @param {String} value Caption value.
			 * @param {Object} column Column to validate.
			 * @return {Object} Validation message.
			 */
			validateCaption: function(value, column) {
				const validators = [this.validateStringValueLength];
				return this.executeValidation(validators, value, column);
			},

			/**
			 * Executes full validation for control.
			 * @protected
			 * @param {Function[]} validators Validators array.
			 * @param {Object} value Value to validate.
			 * @param {Object} column Column to validate.
			 * @return {Object} Validation message.
			 */
			executeValidation: function(validators, value, column) {
				let message;
				if (!Ext.isEmpty(validators)) {
					for (let i = 0; i < validators.length; i++) {
						message = validators[i].call(this, value, column);
						if (!message.isValid) {
							break;
						}
					}
				}
				return message || this.getValidationMessageTemplate("", true);
			},

			/**
			 * Validates string value length.
			 * @protected
			 * @param {String} value String value.
			 * @param {Object} column Model column.
			 * @param {String} [messageTemplate] Validation message template.
			 * @return {Object} Validation error message object.
			 */
			validateStringValueLength: function(value, column, messageTemplate) {
				let message = "";
				let isValid = true;
				if (!Ext.isEmpty(value)) {
					const valueSize = value.length;
					const columnSize = column.size;
					isValid = valueSize <= columnSize;
					if (!messageTemplate) {
						messageTemplate = Terrasoft.Resources.BaseViewModel.columnIncorrectTextRangeValidationMessage + " ({0}/{1})";
					}
					message = isValid
						? ""
						: messageTemplate;
					if (message) {
						message = Ext.String.format(message, valueSize, columnSize);
					}
				}
				return this.getValidationMessageTemplate(message, isValid);
			},

			/**
			 * Validates code value.
			 * @protected
			 * @param {String} value Code value.
			 * @return {Object} Validation error message object.
			 */
			validateCodeValue: function(value) {
				let message = "";
				let isValid = true;
				if (!Ext.isEmpty(value)) {
					const regExp = new RegExp("^[a-zA-Z]{1}[a-zA-Z0-9_]{0," + value.length + "}$");
					isValid = regExp.test(value);
					message = isValid ? "" : this.get("Resources.Strings.WrongCodeMessage");
				}
				return this.getValidationMessageTemplate(message, isValid);
			},

			/**
			 * Validates code value length.
			 * @protected
			 * @param {String} value Code value.
			 * @param {Object} column Model column.
			 * @return {Object} Validation error message object.
			 */
			validateCodeValueLength: function(value, column) {
				const messageTemplate = this.get("Resources.Strings.SchemaCodeIsTooLongMessage");
				return this.validateStringValueLength(value, column, messageTemplate);
			},

			/**
			 * Gets validation message.
			 * @protected
			 * @param {String} message Validation message.
			 * @param {Boolean} isValid Is valid flag.
			 * @return {Object} Validation message.
			 */
			getValidationMessageTemplate: function(message, isValid) {
				return {
					invalidMessage: message || "",
					isValid: isValid || false
				};
			},

			/**
			 * Prepares workplaces drop-down list.
			 * @protected
			 * @param {String} filter Filter.
			 * @param {Terrasoft.core.collections.Collection} list List.
			 */
			prepareWorkplacesList: function(filter, list) {
				if (Ext.isEmpty(list)) {
					return;
				}
				list.clear();
				list.loadAll(this.workplacesConfig);
			},

			/**
			 * Saves section.
			 * @protected
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope.
			 */
			saveSection: function(callback, scope) {
				const entitySchemaUId = this.get(this.entitySchemaUIdColumnName);
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				const entitySchema = this.get("ModuleEntitySchema");
				Terrasoft.chain(
					function(next) {
						const config = {
							entitySchema: entitySchema,
							sectionManagerItem: sectionManagerItem,
							callback: next,
							scope: this
						};
						if (sectionManagerItem.getSchemaUId()) {
							this.saveExistingSection(config);
						} else {
							this.saveNewSection(config);
						}
					},
					function(next) {
						this.getSysModuleEntityManagerItem({entitySchemaUId: entitySchemaUId}, next, this);
					},
					function(next, sysModuleEntityManagerItem) {
						const config = {
							entitySchema: entitySchema,
							managerItem: sysModuleEntityManagerItem,
							callback: next,
							scope: this
						};
						this.getSysModuleEditManagerItems(config);
					},
					function() {
						callback.call(scope);
					}, this
				);
			},

			/**
			 * Saves existing section.
			 * @protected
			 * @param {Object} config Updating schema configuration.
			 */
			saveExistingSection: function(config) {
				const callback = config.callback;
				const scope = config.scope;
				if (this.get(this.isNewSectionColumnName)) {
					callback.call(scope);
				} else {
					const schemaConfig = {
						schemaUId: config.sectionManagerItem.getSchemaUId(),
						entitySchema: config.entitySchema
					};
					this.updateSectionSchema(schemaConfig, callback, scope);
				}
			},

			/**
			 * Saves new section.
			 * @protected
			 * @param {Object} config Creating schema configuration.
			 */
			saveNewSection: function(config) {
				const schemaConfig = {
					entitySchema: config.entitySchema
				};
				this.createSectionSchema(schemaConfig, function(sectionSchema) {
					const schemaUId = sectionSchema.getPropertyValue("uId");
					config.sectionManagerItem.setSchemaUId(schemaUId);
					config.callback.call(config.scope);
				}, this);
			},

			/**
			 * Creates (if does not exist) and returns sysModuleEntityManagerItem.
			 * @protected
			 * @param {Object} [config] Configuration object.
			 * @param {Object} config.entitySchemaUId entity schema UId.
			 * @param {Object} [config.typeColumnUId] type column UId.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			getSysModuleEntityManagerItem: function(config, callback, scope) {
				config = config || {};
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.getSysModuleEntityManagerItem(function(sysModuleEntityManagerItem) {
					if (Ext.isEmpty(sysModuleEntityManagerItem)) {
						const sysModuleEntityId = Terrasoft.generateGUID();
						config.id = sysModuleEntityId;
						this.createSysModuleEntityManagerItem(config, function(newSysModuleEntityManagerItem) {
							sectionManagerItem.setSysModuleEntityId(sysModuleEntityId);
							if (this.getIsSspSection()) {
								const entity = Terrasoft.EntitySchemaManager.findItemByName(sectionManagerItem.getCode());
								newSysModuleEntityManagerItem.setEntitySchemaUId(entity.uId);
							}
							callback.call(scope, newSysModuleEntityManagerItem);
						}, this);
					} else {
						callback.call(scope, sysModuleEntityManagerItem);
					}
				}, this);
			},

			/**
			 * Creates sysModuleEntityManagerItem.
			 * @protected
			 * @param {Object} config Configuration object.
			 * @param {Object} config.entitySchemaUId entity schema UId.
			 * @param {Object} config.typeColumnUId type column UId.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			createSysModuleEntityManagerItem: function(config, callback, scope) {
				Terrasoft.SysModuleEntityManager.createItem({propertyValues: config}, function(item) {
					Terrasoft.SysModuleEntityManager.addItem(item);
					callback.call(scope, item);
				}, this);
			},

			/**
			 * Gets sysModuleEditManagerItems and completes section saving.
			 * @protected
			 * @param {Object} config Configuration.
			 */
			getSysModuleEditManagerItems: function(config) {
				const managerItem = config.managerItem;
				managerItem.getSysModuleEditManagerItems(function(sysModuleEditManagerItems) {
					const callback = config.callback;
					const scope = config.scope;
					if (sysModuleEditManagerItems.getCount() > 0) {
						callback.call(scope);
					} else {
						const registerSysModuleEditConfig = {
							sysModuleEntityId: managerItem.getId(),
							entitySchema: config.entitySchema
						};
						this.registerSysModuleEdit(registerSysModuleEditConfig, callback, scope);
					}
				}, this);
			},

			/**
			 * Registers sysModuleEntityEdit configuration.
			 * @protected
			 * @param {Object} config SysModuleEntityEdit configuration.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Context.
			 */
			registerSysModuleEdit: function(config, callback, scope) {
				Terrasoft.chain(
					function(next) {
						this.createPageSchema({entitySchema: config.entitySchema}, next, this);
					},
					function(next, pageSchema) {
						Terrasoft.SysModuleEditManager.createItem(null, function(item) {
							this.initSysModuleEditManagerItem(item, config.sysModuleEntityId, pageSchema);
							callback.call(scope, item);
						}, this);
					}, this
				);
			},

			/**
			 * Initializes sysModuleEditManageItem.
			 * @protected
			 * @param {Object} item SysModuleEditManagerItem.
			 * @param {String} sysModuleEntityId sysModuleEntity identifier.
			 * @param {Object} pageSchema Page schema.
			 */
			initSysModuleEditManagerItem: function(item, sysModuleEntityId, pageSchema) {
				if (Ext.isEmpty(item)) {
					return;
				}
				const pageCaptionLcz = pageSchema.getPropertyValue(this.captionColumnName.toLowerCase());
				item.setSysModuleEntityId(sysModuleEntityId);
				item.setCardSchemaUId(pageSchema.getPropertyValue("uId"));
				item.setPageCaption(pageCaptionLcz.getValue());
				Terrasoft.SysModuleEditManager.addItem(item);
			},

			/**
			 * Updates section schema.
			 * @protected
			 * @param {Object} config Configuration.
			 * @param {Function} callback Callback.
			 * @param {Scope} scope Context.
			 */
			updateSectionSchema: function(config, callback, scope) {
				const getPackageSchemaConfig = {
					packageUId: this.getPackageUId(),
					schemaUId: config.schemaUId
				};
				Terrasoft.ClientUnitSchemaManager.forceGetPackageSchema(getPackageSchemaConfig, function(schema) {
					const caption = this.get(this.captionColumnName);
					this.setSchemaLocalizableStringValue(schema, caption);
					this.setSchemaBody(schema, config.entitySchema);
					this.addSchemaToClientUnitSchemaManger(schema, schema.getPropertyValue("uId"));
					schema.define(function() {
						callback.call(scope);
					}, this);
				}, this);
			},

			/**
			 * Creates client unit schema name for new section.
			 * @param {String} entitySchemaName Section entity schema name.
			 * @return {String} New section client unit schema name.
			 */
			getNewSectionSchemaName: function(entitySchemaName) {
				let sectionSchemaNameTemplate = entitySchemaName + "{0}Section";
				const prefix = this.get(this.codePrefixColumnName);
				if (!this.isEmpty(prefix) && !sectionSchemaNameTemplate.startsWith(prefix)) {
					sectionSchemaNameTemplate = prefix + sectionSchemaNameTemplate;
				}
				return this.getClientUnitSchemaName(sectionSchemaNameTemplate);
			},

			/**
			 * Creates client unit section schema.
			 * @protected
			 * @param {Object} schemaConfig Schema configuration.
			 * @param {Function} callback Callback.
			 * @param {Scope} scope Context.
			 */
			createSectionSchema: function(schemaConfig, callback, scope) {
				Terrasoft.ClientUnitSchemaManager.initialize(function() {
					const config = this.getClientUnitSchemaSectionConfig(schemaConfig);
					const primaryCaptionColumnName = this.captionColumnName;
					const sectionCaption = this.get(primaryCaptionColumnName);
					config.schemaName = this.getNewSectionSchemaName(config.entitySchemaName);
					config.schemaCaption = this.getSectionSchemaCaption(sectionCaption);
					const sectionSchema = this.createClientUnitSchema(config, true);
					sectionSchema.localizableStrings.add(primaryCaptionColumnName,
						this.setLocalizableString(sectionCaption));
					Terrasoft.ClientUnitSchemaManager.addSchema(sectionSchema);
					sectionSchema.define(function() {
						callback.call(scope, sectionSchema);
					}, this);
				}, this);
			},

			/**
			 * Creates client unit edit page schema.
			 * @protected
			 * @param {Object} schemaConfig Schema configuration.
			 * @param {Function} callback Callback.
			 * @param {Scope} scope Context.
			 */
			createPageSchema: function(schemaConfig, callback, scope) {
				Terrasoft.ClientUnitSchemaManager.initialize(function() {
					const config = this.getClientUnitSchemaPageConfig(schemaConfig);
					const pageSchemaNameTemplate = config.entitySchemaName + "{0}Page";
					config.schemaName = this.getClientUnitSchemaName(pageSchemaNameTemplate);
					config.schemaCaption = this.getEditPageSchemaCaption(config.entitySchema);
					const editPageSchema = this.createClientUnitSchema(config, false);
					Terrasoft.ClientUnitSchemaManager.addSchema(editPageSchema);
					editPageSchema.define(function() {
						callback.call(scope, editPageSchema);
					}, this);
				}, this);
			},

			/**
			 * Gets base configuration for creating client unit schema.
			 * @protected
			 * @param {Object} schemaConfig Schema configuration.
			 * @return {Object} Base configuration.
			 */
			getClientUnitSchemaBaseConfig: function(schemaConfig) {
				const entitySchema = schemaConfig.entitySchema;
				const schemaType = schemaConfig.schemaType;
				return {
					schemaType: schemaType,
					bodyTemplate: Terrasoft.ClientUnitSchemaBodyTemplate[schemaType],
					entitySchema: entitySchema,
					entitySchemaName: entitySchema.getPropertyValue("name"),
					packageUId: this.getPackageUId(),
					parentSchemaUId: schemaConfig.parentSchemaUId
				};
			},

			/**
			 * Returns client unit schema section configuration.
			 * @param {Object} schemaConfig Configuration object.
			 * @param {Object} schemaConfig.entitySchema Entity schema.
			 * @return {Object} Client unit schema section configuration.
			 */
			getClientUnitSchemaSectionConfig: function(schemaConfig) {
				const baseUIds = Terrasoft.DesignTimeEnums.BaseSchemaUId;
				const parentSchemaUId = this.getIsSspSection()
					? baseUIds.BASE_DATA_VIEW
					: baseUIds.BASE_SECTION;
				Ext.apply(schemaConfig, {
					schemaType: Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,
					parentSchemaUId: parentSchemaUId
				});
				return this.getClientUnitSchemaBaseConfig(schemaConfig);
			},

			/**
			 * Returns client unit schema page configuration.
			 * @param {Object} schemaConfig Configuration object.
			 * @param {Object} schemaConfig.entitySchema Entity schema.
			 * @return {Object} Client unit schema section configuration.
			 */
			getClientUnitSchemaPageConfig: function(schemaConfig) {
				const baseUIds = Terrasoft.DesignTimeEnums.BaseSchemaUId;
				const parentSchemaUId = this.getIsSspSection()
					? baseUIds.BASE_SECTION_PAGE
					: baseUIds.BASE_MODULE_PAGE;
				Ext.apply(schemaConfig, {
					schemaType: Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
					parentSchemaUId: parentSchemaUId
				});
				return this.getClientUnitSchemaBaseConfig(schemaConfig);
			},

			/**
			 * Creates client unit schema.
			 * @protected
			 * @param {Object} config Client unit schema configuration.
			 * @param {Boolean} isExtendedParent IsExtendedParent indicator.
			 * @return {Object} Client unit schema.
			 */
			createClientUnitSchema: function(config, isExtendedParent) {
				const schemaName = config.schemaName;
				const clientUnitSchema = Terrasoft.ClientUnitSchemaManager.createSchema({
					uId: Terrasoft.generateGUID(),
					name: schemaName,
					packageUId: config.packageUId,
					caption: new Terrasoft.LocalizableString(config.schemaCaption),
					body: Ext.String.format(config.bodyTemplate, schemaName, config.entitySchemaName),
					schemaType: config.schemaType,
					parentSchemaUId: config.parentSchemaUId
				});
				if (!isExtendedParent) {
					clientUnitSchema.extendParent = false;
				}
				return clientUnitSchema;
			},

			/**
			 * Gets package UId.
			 * @protected
			 * @return {String} Package UId.
			 */
			getPackageUId: function() {
				let packageUId = this.get(this.packageUIdColumnName);
				if (!packageUId) {
					const sandbox = this.sandbox;
					packageUId = sandbox.publish("GetPackageUId", null, [sandbox.id]);
					this.set(this.packageUIdColumnName, packageUId);
				}
				return packageUId;
			},

			/**
			 * Sets schema localizable string value.
			 * @protected
			 * @param {Object} schema Schema.
			 * @param {String} value Value.
			 */
			setSchemaLocalizableStringValue: function(schema, value) {
				const primaryCaptionColumnName = this.captionColumnName;
				const caption = this.getSectionSchemaCaption(value);
				schema.localizableStrings.removeByKey(primaryCaptionColumnName);
				schema.localizableStrings.add(primaryCaptionColumnName, this.setLocalizableString(value));
				schema.setLocalizableStringPropertyValue(primaryCaptionColumnName.toLowerCase(), caption);
			},

			/**
			 * Sets localizable string value.
			 * @protected
			 * @param {String} value Value.
			 * @return {Object} Localizable string.
			 */
			setLocalizableString: function(value) {
				return new Terrasoft.LocalizableString(value);
			},

			/**
			 * Gets section schema caption.
			 * @protected
			 * @param {String} sectionCaption Caption.
			 * @return {String} Section caption in format "Section schema: "{0}"".
			 */
			getSectionSchemaCaption: function(sectionCaption) {
				const sectionSchemaCaptionTemplate = this.get("Resources.Strings.SectionSchemaCaptionTemplate");
				return Ext.String.format(sectionSchemaCaptionTemplate, sectionCaption);
			},

			/**
			 * Gets edit page schema caption.
			 * @protected
			 * @param {Object} entitySchema EntitySchema object.
			 * @return {String} Edit page caption in format "Card schema: "{0}"".
			 */
			getEditPageSchemaCaption: function(entitySchema) {
				const primaryCaptionColumnName = this.captionColumnName.toLowerCase();
				const entitySchemaCaptionLcz = entitySchema.getPropertyValue(primaryCaptionColumnName);
				const entitySchemaCaption = entitySchemaCaptionLcz.getValue();
				const editPageCaptionTemplate = this.get("Resources.Strings.EditPageCaptionTemplate");
				return Ext.String.format(editPageCaptionTemplate, entitySchemaCaption);
			},

			/**
			 * Sets schema body.
			 * @protected
			 * @param {Object} schema Schema.
			 * @param {Object} entitySchema entitySchema.
			 */
			setSchemaBody: function(schema, entitySchema) {
				const schemaBody = schema.getPropertyValue("body");
				if (!schemaBody) {
					const schemaName = schema.getPropertyValue("name");
					const entitySchemaName = entitySchema.getPropertyValue("name");
					const schemaType = Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA;
					const bodyTemplate = Terrasoft.ClientUnitSchemaBodyTemplate[schemaType];
					const body = Ext.String.format(bodyTemplate, schemaName, entitySchemaName);
					schema.setPropertyValue("body", body);
				}
			},

			/**
			 * Adds schema to client unit schema manager.
			 * @protected
			 * @param {Object} schema Schema.
			 * @param {String} schemaUId schemaUId.
			 */
			addSchemaToClientUnitSchemaManger: function(schema, schemaUId) {
				const manager = Terrasoft.ClientUnitSchemaManager;
				if (!manager.findItem(schemaUId)) {
					manager.addSchema(schema);
				}
			},

			/**
			 * Gets client unit schema name.
			 * @protected
			 * @param {String} schemaNameTemplate Schema name template.
			 * @return {String} Schema name.
			 */
			getClientUnitSchemaName: function(schemaNameTemplate) {
				if (Terrasoft.useSchemaUniqueNameRandomGenerator) {
					const uniqueSchemaNamePart = this._generateSchemaNameUniquePart();
					return Ext.String.format(schemaNameTemplate, uniqueSchemaNamePart);
				}
				const clientUnitSchemaManagerItems = Terrasoft.ClientUnitSchemaManager.getItems();
				let schemaName;
				for (let i = 1, iterations = clientUnitSchemaManagerItems.getCount(); i < iterations; i++) {
					schemaName = Ext.String.format(schemaNameTemplate, i);
					const foundItems = this.findClientUnitSchemaManagerItemsByName(schemaName);
					if (foundItems.isEmpty()) {
						break;
					}
				}
				return schemaName;
			},

			/**
			 * Finds client unit schema manager item by name.
			 * @protected
			 * @param {String} schemaName Schema name.
			 * @return {Object} ClientUnitSchemaManagerItems.
			 */
			findClientUnitSchemaManagerItemsByName: function(schemaName) {
				return Terrasoft.ClientUnitSchemaManager.getItems().filterByPath("name", schemaName);
			},

			/**
			 * Returns MultiPageSettingsModule id.
			 * @protected
			 * @return {String}
			 */
			getMultiPageSettingsModuleId: function() {
				return Ext.String.format("{0}_module_MultiPageModule", this.sandbox.id);
			},

			/**
			 * Returns SectionPageSettings module id.
			 * @protected
			 * @return {String}
			 */
			getSectionPageSettingsModuleId: function() {
				return Ext.String.format("{0}_module_MultiPageModule", this.sandbox.id);
			},

			/**
			 * Checks is current section type SSP.
			 * @protected
			 * @return {Boolean} True if current section type SSP, false otherwise.
			 */
			getIsSspSection: function() {
				const sectionManagerItem = this.get("SectionManagerItem");
				const types = this.$SectionTypes || {};
				return sectionManagerItem.type === types.SSP;
			},

			/**
			 * Checks is current section type General.
			 * @protected
			 * @return {Boolean} True if current section type General, false otherwise.
			 */
			getIsGeneralSection: function() {
				return !this.getIsSspSection();
			},

			/**
			 * Creates new section entity schemas.
			 * @protected
			 * @param {Object} [config] Configuration object.
			 * @param {String} [config.existEntityUId] Exist entity identifier.
			 * @param {String} [config.name] Entity name.
			 * @param {String} [config.caption] Entity caption.
			 * @param {String} [config.packageUId] Package unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			createNewSectionEntitySchemas: function(config, callback, scope) {
				const sectionManagerItem = this.get("SectionManagerItem");
				Terrasoft.chain(
					function(next) {
						sectionManagerItem.getSysModuleEntityManagerItem(next, this);
					},
					function(next, sysModuleEntityManagerItem) {
						const entitySchemaUId = sysModuleEntityManagerItem.getEntitySchemaUId();
						if (Terrasoft.EntitySchemaManager.contains(entitySchemaUId)) {
							return Ext.callback(callback, scope, [sysModuleEntityManagerItem]);
						} else {
							return this.createNewSectionEntitiesSchemasInChain(config, callback, scope);
						}
					}, this
				);
			},

			/**
			 * Create new section entities schemas in chain.
			 * @param {Object} [config] Configuration object.
			 * @param {String} [config.existEntityUId] Exist entity identifier.
			 * @param {String} [config.name] Entity name.
			 * @param {String} [config.caption] Entity caption.
			 * @param {String} [config.packageUId] Package unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			createNewSectionEntitiesSchemasInChain: function(config, callback, scope) {
				this.showBodyMask();
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				if (!config) {
					const code = this.get(this.codeColumnName);
					const codeWithPrefix = this.get(this.codePrefixColumnName) + code;
					sectionManagerItem.setCode(codeWithPrefix);
					config = {
						name: code,
						caption: this.get("Caption"),
						packageUId: this.get("packageUId")
					};
				}
				let sectionEntityUId;
				Terrasoft.chain(
					function(next) {
						Terrasoft.ApplicationStructureWizardUtils.createNewSectionEntitySchemas(config, next, this);
					},
					function(next, _sectionEntityUId) {
						sectionEntityUId = _sectionEntityUId;
						sectionManagerItem.getSysModuleEntityManagerItem(next, this);
					},
					function(next, sysModuleEntityManagerItem) {
						sysModuleEntityManagerItem.setEntitySchemaUId(sectionEntityUId);
						this.setEntitySchemaUId(sysModuleEntityManagerItem);
						this.sandbox.publish("UpdateWizardConfig", sectionManagerItem, [this.sandbox.id]);
						Ext.callback(callback, scope, [sysModuleEntityManagerItem]);
					}, this
				);
			},

			/**
			 * Returns code enabled.
			 * @return {Boolean} Code enabled.
			 */
			getIsCodeEnabled: function() {
				return this.get("IsNewSection") && this.get("IsCodeEnabled");
			},

			/**
			 * Returns global search available enable tag.
			 * @returns {Boolean} GlobalSearchAvailable enable tag.
			 */
			getIsGlobalSearchAvailableEnabled: function() {
				const isNewSection = this.get("IsNewSection");
				if (isNewSection) {
					return true;
				}
				const isGlobalSearchEnabled = this.get("IsGlobalSearchEnabled");
				const isDuplicationRuleExists = this.get("IsDuplicationRuleExists");
				return Boolean(isGlobalSearchEnabled && !isDuplicationRuleExists);
			},

			/**
			 * Renders schema name prefix.
			 */
			renderSchemaNamePrefix: function() {
				const prefix = this.get(this.codePrefixColumnName);
				if (prefix) {
					const schemaNamePrefixClass = "schema-name-prefix";
					const schemaNamePrefixClassTpl = ".schema-name-prefix>div {white-space: nowrap;}";
					const schemaNamePrefixBeforeClassTpl = ".schema-name-prefix>div:before {content: \"{0}\"; " +
						"display: inline-block; font-size: 1.4em; " +
						"font-family: \"Bpmonline Open Sans\",serif;color: #676666;}";
					Ext.util.CSS.createStyleSheet(schemaNamePrefixClassTpl, schemaNamePrefixClass);
					Ext.util.CSS.createStyleSheet(
						Ext.String.format(schemaNamePrefixBeforeClassTpl, prefix), schemaNamePrefixClass
					);
				}
			},

			/**
			 * @private
			 */
			_removeSchemaNamePrefix: function() {
				Ext.util.CSS.createStyleSheet(".schema-name-prefix>div:before {content:none}");
			},

			/**
			 * Initializes schema attributes.
			 * @protected
			 */
			initAttributes: function() {
				this.columns.Code.size = Terrasoft.EntitySchemaManager.getMaxEntitySchemaNameLength() -
					Terrasoft.DesignTimeEnums.SysModuleColumnSizes.MAX_ENTITY_SCHEMA_NAME_SUFFIX;
				this.columns.Caption.size = Terrasoft.DesignTimeEnums.SysModuleColumnSizes.MAX_CAPTION_SIZE;
			},

			/**
			 * Checks is workplace combobox visible.
			 * @protected
			 * @return {Boolean} Workplace combobox visibility.
			 */
			getIsWorkplaceVisible: function() {
				const isSsp = this.getIsSspSection();
				const workplaceSet = !Ext.isEmpty(this.get("Workplace"));
				const isNew = this.get("IsNewSection");
				if (!isSsp) {
					return isNew;
				}
				return isNew && workplaceSet;
			},

			/**
			 * Checks feature ChangeBackgroundIconColor7x is enabled.
			 * @protected
			 * @return {Boolean} Feature is enabled.
			 */
			getIsEnabledChangeBackgroundIconColor7x: function() {
				return this.getIsFeatureEnabled("ChangeBackgroundIconColor7x");
			},			

			/**
			 * Returns background color object.
			 * @protected
			 * @virtual
			 * @return {Object} Background color object.
			 */
			getIconBackgroundDefaultConfig: function() {
				return Terrasoft.ModuleSectionEnums.IconBackgroundColors;
			},

			/**
			 * Fill background color collection.
			 * @protected
			 * @virtual
			 * @param {String} filter Filtering string.
			 * @param {Terrasoft.Collection} list List.
			 */
			prepareIconBackgroundList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getIconBackgroundDefaultConfig());
			},

			/**
			 * Processes IconBackground control value changing.
			 * @protected
			 * @param {Object} model Model.
			 * @param {String} value Changed value.
			 */
			onIconBackgroundChange: function(model, value) {
				const sectionManagerItem = this.get(this.sectionManagerItemColumnName);
				sectionManagerItem.setIconBackground(value.value);
			},

			//endregion

			//region Methods: Public

			/**
			 * Initializes section wizard main settings step.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Context.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initAttributes();
					this.subscribeMessages();
					this.mixins.BaseWizardStepSchemaMixin.init.call(this, function() {
						Ext.callback(callback, scope);
					});
				}, this]);
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MainSettingsWrapper",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["main-settings-wrapper"]},
					"items": [
						{
							"name": "TopControlGroup",
							"itemType": Terrasoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["top-control-group-container"]},
							"items": [
								{
									"name": "TopControlGroupTextContainer",
									"itemType": Terrasoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["section-settings-label-container"]},
									"items": [
										{
											"name": "TopControlGroupLabel",
											"itemType": Terrasoft.ViewItemType.LABEL,
											"caption": {"bindTo": "TopControlGroupHeader"},
											"labelClass": ["top-control-group-label section-settings-label"]
										}
									]
								},
								{
									"name": "TopControlGroupRightContainer",
									"itemType": Terrasoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["top-control-group-right-container"]},
									"items": [
										{
											"name": "Icon",
											"dataValueType": Terrasoft.DataValueType.IMAGE,
											"defaultImageSrc": {"bindTo": "DefaultIconSrc"},
											"generator": "ImageSectionWizardCustomGenerator.generateCustomImageControlWithLabel",
											"imageSrc": {"bindTo": "getIconSrc"},
											"labelConfig": {"visible": false},
											"onPhotoChange": "onIconChange",
											"hint": {"bindTo": "Resources.Strings.IconLabel"}
										},
										{
											"name": "TopControlGroupSettingsContainer1",
											"itemType": Terrasoft.ViewItemType.CONTAINER,
											"classes": {"wrapClassName": ["top-control-group-settings-container"]},
											"items": [
												{
													"name": "Caption",
													"bindTo": "Caption",
													"labelConfig": {"caption": {"bindTo": "Resources.Strings.CaptionLabel"}}
												},
												{
													"name": "Code",
													"controlConfig": {"value": {"bindTo": "Code"}},
													"controlWrapConfig": {"classes": {"wrapClassName": "schema-name-prefix"}},
													"enabled": {"bindTo": "getIsCodeEnabled"},
													"labelConfig": {
														"caption": {"bindTo": "Resources.Strings.CodeLabel"},
														"labelClass": ["t-label t-label-is-required"]
													},
													"tip": {
														"content": {"bindTo": "getCodeTipMessage"},
														"enabled": {"bindTo": "IsNewSection"}
													}
												},
												{
													"name": "Workplace",
													"dataValueType": Terrasoft.DataValueType.ENUM,
													"controlConfig": {
														"list": {"bindTo": "WorkplacesList"},
														"prepareList": {"bindTo": "prepareWorkplacesList"},
														"value": {"bindTo": "Workplace"}
													},
													"labelConfig": {"caption": {"bindTo": "Resources.Strings.WorkplaceLabel"}},
													"visible": {"bindTo": "getIsWorkplaceVisible"},
													"enabled": {"bindTo": "getIsGeneralSection"}
												},
												{													
													"name": "IconBackground",
													"bindTo": "IconBackground",
													"dataValueType": Terrasoft.DataValueType.ENUM,								
													"labelConfig": {
														"caption": { "bindTo": "Resources.Strings.BackgroundIconColorLabel" }
													},
													"visible": {"bindTo": "getIsEnabledChangeBackgroundIconColor7x"},
													"controlConfig": {
														"className": "Terrasoft.ComboBoxEdit",
														"prepareList": {
															"bindTo": "prepareIconBackgroundList"
														},
														"list": {
															"bindTo": "IconBackgroundList"
														}
													}													
												}
											]
										},
										{
											"name": "TopControlGroupSettingsContainer2",
											"itemType": Terrasoft.ViewItemType.CONTAINER,
											"classes": {"wrapClassName": ["top-control-group-settings-container"]},
											"items": [
												{
													"name": "SelectExistObjectGroup",
													"itemType": Terrasoft.ViewItemType.CONTAINER,
													"classes": {"wrapClassName": ["select-exist-object-group-container"]},
													"items": [
														{
															"name": "SelectExistObjectButton",
															"itemType": Terrasoft.ViewItemType.BUTTON,
															"caption": {"bindTo": "Resources.Strings.SelectExistingObjectButtonCaption"},
															"click": {"bindTo": "onSelectExistObjectButtonClick"},
															"style": Terrasoft.controls.ButtonEnums.style.DEFAULT,
															"visible": {"bindTo": "getIsCodeEnabled"}
														}
													]
												},
												{
													"name": "GlobalSearchAvailable",
													"bindTo": "GlobalSearchAvailable",
													"enabled": {"bindTo": "getIsGlobalSearchAvailableEnabled"},
													"visible": {"bindTo": "IsGlobalSearchEnabled"},
													"labelConfig": {
														"caption": {"bindTo": "Resources.Strings.GlobalSearchAvailableLabel"}
													}
												},
												{
													"name": "IsSystem",
													"dataValueType": Terrasoft.DataValueType.BOOLEAN,
													"visible": Terrasoft.isDebug,
													"caption": {"bindTo": "Resources.Strings.IsSystem"}
												}
											]
										}
									]
								}
							]
						},
						{
							"name": "MultiPageSettingsModuleContainer",
							"itemType": Terrasoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["multi-page-settings-module-container"]},
							"items": [
								{
									"name": "MultiPageModule",
									"itemType": Terrasoft.ViewItemType.MODULE
								}
							]
						}
					]
				}
			},
			{
				"operation": "insert",
				"parentName": "MainSettingsWrapper",
				"propertyName": "items",
				"name": "SectionVisaSettingsModuleContainer",
				"index": 3,
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["visa-settings-module-container"]},
					"items": [
						{
							"name": "VisaSettingsModule",
							"itemType": Terrasoft.ViewItemType.MODULE
						}
					]
				}
			}
		]
	};
});


