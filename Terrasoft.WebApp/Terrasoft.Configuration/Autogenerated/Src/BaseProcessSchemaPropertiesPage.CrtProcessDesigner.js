/**
 * Page schema for base process schema properties.
 * Parent: ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("BaseProcessSchemaPropertiesPage", ["terrasoft", "BaseProcessSchemaPropertiesPageResources",
		"ProcessModuleUtilities"],
	function(Terrasoft, resources, ProcessModuleUtilities) {
		return {
			mixins: {
				observableItem: "Terrasoft.ObservableItem"
			},
			messages: {
				/**
				 * @message SchemaPropertyChanged
				 * Receive current schema property value.
				 */
				"SchemaPropertiesChanged": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				}
			},
			attributes: {
				/**
				 * Flag that indicates enabled schema or not.
				 */
				"enabled": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.EnabledCaption
				},
				/**
				 * Indicates whether this schema is the actual version in current package.
				 */
				"isActualVersion": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.IsActiveVersionCaption
				},
				/**
				 * Version.
				 */
				"version": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.VersionCaption
				},
				/**
				 * Package.
				 */
				"SysPackage": {
					dataValueType: Terrasoft.DataValueType.ENUM,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					caption: resources.localizableStrings.SysPackageCaption
				},
				/**
				 * Maximum repeat count.
				 */
				"maxLoopCount": {
					dataValueType: this.Terrasoft.DataValueType.INTEGER,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.MaxLoopCountCaption
				},
				/**
				 * Package list for drop down menu.
				 */
				"SysPackageList": {
					dataValueType: Terrasoft.DataValueType.ENUM,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: Ext.create("Terrasoft.Collection")
				},
				/**
				 * Flag that indicates whether SysPackage edit is enabled.
				 */
				"IsSysPackageEnabled": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Indicates whether is system security context used during runtime.
				 */
				"useSystemSecurityContext": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.UseSystemSecurityContextCaption
				},

				/**
				 * Indicates whether is needed to use user permissions.
				 */
				"useUserPermissions": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.UseUserPermissionsCaption
				},

				/**
				 * Studio free process link.
				 */
				 "StudioFreeProcessUrl":  {
					 dataValueType: Terrasoft.DataValueType.TEXT,
					 type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					 caption: resources.localizableStrings.StudioFreeProcessUrlCaption
				 },
				/**
				 * Name.
				 */
				"name": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					size: 250
				},
			},
			methods: {

				//region Methods: Private

				/**
				 * Initializes SysPackage.
				 * @private
				 * @param {GUID} packageUId Package unique identifier.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Execution context.
				 */
				initSysPackage: function(packageUId, callback, scope) {
					if (Terrasoft.isEmptyGUID(packageUId)) {
						const value = {
							UId: Terrasoft.GUID_EMPTY,
							value: Terrasoft.GUID_EMPTY,
							displayValue: resources.localizableStrings.CustomPackageName
						};
						this.set("SysPackage", value);
						this.on("change:SysPackage", this.onSysPackageChanged, this);
						callback.call(scope || this);
					} else {
						this.loadSysPackageDisplayValue(packageUId, callback, scope);
					}
				},

				/**
				 * Loads SysPackage display value.
				 * @private
				 * @param {String} packageUId Package identifier.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Execution context.
				 */
				loadSysPackageDisplayValue: function(packageUId, callback, scope) {
					this.set("SysPackage", {UId: packageUId});
					Terrasoft.BaseSchemaDesignerUtilities.loadSysPackageByUId(packageUId, function(sysPackage) {
						if (sysPackage) {
							const value = {
								UId: sysPackage.get("UId"),
								value: sysPackage.get("Id"),
								displayValue: sysPackage.get("Name")
							};
							this.set("SysPackage", value);
							const maintainer = sysPackage.get("Maintainer");
							this.set("IsSysPackageEnabled", maintainer === Terrasoft.SysValue.CURRENT_MAINTAINER.value);
						}
						this.on("change:SysPackage", this.onSysPackageChanged, this);
						callback.call(scope || this);
					}, this);
				},

				/**
				 * Handles on SysPackage change, shows confirmation message.
				 * @private
				 * @param {Terrasoft.BaseViewModel} model Page view model.
				 * @param {Object} sysPackage Current SysPackage value.
				 * @param {Object} options Binding options.
				 */
				onSysPackageChanged: function(model, sysPackage, options) {
					let previousSysPackage = model.previous("SysPackage");
					if (!sysPackage && previousSysPackage) {
						this.set("PreviousSysPackage", previousSysPackage);
						return;
					}
					if (options.showConfirmationDialog === false) {
						return;
					}
					const value = sysPackage ? sysPackage.value : null;
					const oldValue = previousSysPackage ? previousSysPackage.value : null;
					if (value === oldValue) {
						return;
					}
					const buttonCaption = resources.localizableStrings.ChangSysPackageButtonCaption;
					const message = resources.localizableStrings.ChangeSysPackageConfirmationMessage;
					const changeButton = Terrasoft.getButtonConfig("modify", buttonCaption, "Modify");
					this.showConfirmationDialog(message, function(returnCode) {
						if (returnCode === Terrasoft.MessageBoxButtons.NO.returnCode) {
							previousSysPackage = previousSysPackage || this.get("PreviousSysPackage");
							this.set("SysPackage", previousSysPackage, {showConfirmationDialog: false});
						}
					}, [changeButton, Terrasoft.MessageBoxButtons.NO], {defaultButton: 0});
				},

				/**
				 * @inheritdoc Terrasoft.ObservableItem#getAttributeMap
				 * @override
				 */
				getAttributeMap: function() {
					const map = this.callParent();
					return Object.assign(map, {studioFreeProcessUrl: "StudioFreeProcessUrl"});
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getExtendedModeMenuItem.
				 * @overridden
				 */
				getExtendedModeMenuItem: Terrasoft.emptyFn,

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#initIsSerializeToDBEnabled.
				 * @overridden
				 */
				initIsSerializeToDBEnabled: function(element, callback, scope) {
					this.set("IsSerializeToDBEnabled", true);
					callback.call(scope);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("name", this.columnLengthValidator);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#duplicateNameValidator
				 * @overridden
				 */
				duplicateNameValidator: function() {
					return {invalidMessage: ""};
				},

				/**
				 * Returns if name is required.
				 * @private
				 * @return {Boolean}
				 */
				_getIsNameRequired: function() {
					return this.getIsNewProcess() === false;
				},

				//endregion

				//region Methods: Protected

				/**
				 * Handles diagram caption change, sets new caption to properties page.
				 * @param schemaCaption
				 */
				onDiagramCaptionChanged: function(schemaCaption) {
					this.set("caption", schemaCaption);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(schema, callback, scope) {
					this.set("FeatureDisableAdminRightsInScriptTaskEnabled",
						Terrasoft.Features.getIsEnabled("DisableAdminRightsInScriptTask"));
					this.sandbox.subscribe("DiagramPageCaptionChanged", this.onDiagramCaptionChanged, this);
					this.callParent([schema, function() {
						this.sandbox.subscribe("SchemaPropertiesChanged", this.schemaPropertiesChanged, this);
						this.set("enabled", schema.enabled);
						this.set("isActualVersion", schema.getIsActualVersion());
						this.set("maxLoopCount", schema.maxLoopCount);
						this.set("useSystemSecurityContext", schema.useSystemSecurityContext);
						this.set("useUserPermissions", schema.useUserPermissions);
						this.set("StudioFreeProcessUrl", schema.studioFreeProcessUrl);
						this.initSysPackage(schema.packageUId, function () {
							callback.call(scope);
						}, this);
					}, this]);
				},

				/**
				 * Open studio free button handler.
				 * @public
				 */
				onOpenStudioFreeButtonClick: function(){
					if (Terrasoft.isUrl(this.$StudioFreeProcessUrl)) {
						const tab = window.open(this.$StudioFreeProcessUrl, "_blank");
						tab.focus();
					}
				},
				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @overridden
				 */
				saveValues: function() {
					this.callParent(arguments);
					const process = this.get("ProcessElement");
					process.setPropertyValue("enabled", this.get("enabled"));
					const sysPackage = this.get("SysPackage") || this.get("PreviousSysPackage") || {};
					process.setPropertyValue("packageUId", sysPackage.UId);
					process.setPropertyValue("maxLoopCount", this.get("maxLoopCount"));
					process.setPropertyValue("useSystemSecurityContext", this.get("useSystemSecurityContext"));
					process.setPropertyValue("useUserPermissions", this.get("useUserPermissions"));
					process.setPropertyValue("studioFreeProcessUrl", this.$StudioFreeProcessUrl);
				},

				/**
				 * Sets schema properties
				 */
				schemaPropertiesChanged: function(changeObject) {
					Terrasoft.each(changeObject, function(value, name) {
						this.set(name, value);
					}, this);
				},

				/**
				 * Data handler preparation event for the drop-down package list.
				 * @param {Object} filter Filters for data preparation.
				 * @param {Terrasoft.Collection} list The data for the drop-down list.
				 */
				onPrepareSysPackageList: function(filter, list) {
					ProcessModuleUtilities.onPrepareSysPackageList(filter, list);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#onPageCaptionChanged.
				 * @overridden
				 */
				onElementCaptionChanged: function(model, caption) {
					this.sandbox.publish("PropertiesPageCaptionChanged", caption);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#nameValidator
				 * @override
				 */
				nameValidator: function(code) {
					const isNew = this.getIsNewProcess();
					if (isNew && !code) {
						return {invalidMessage: ""};
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getBackgroundModePriorityCaption.
				 * @overridden
				 */
				getBackgroundModePriorityCaption: function() {
					return resources.localizableStrings.BackgroundModePriorityCaption;
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#isBackgroundModePriorityVisible.
				 * @overridden
				 */
				isBackgroundModePriorityVisible: function() {
					return this.getCanUseBackgroundModePriority();
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getAllowedBackgroundModePriorities.
				 * @overridden
				 */
				getAllowedBackgroundModePriorities: function() {
					return [
						Terrasoft.process.enums.BackgroundModePriority.High,
						Terrasoft.process.enums.BackgroundModePriority.Medium,
						Terrasoft.process.enums.BackgroundModePriority.Low
					];
				},

				/**
				 * Returns if process schema is new or not.
				 * @protected
				 * @return {Boolean}
				 */
				getIsNewProcess: function() {
					const managerItem = this.sandbox.publish("GetSchemaManagerItem");
					const isNew = managerItem && managerItem.isNew();
					return Boolean(isNew);
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "name",
					"values": {
						"isRequired": {"bindTo": "_getIsNameRequired"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
