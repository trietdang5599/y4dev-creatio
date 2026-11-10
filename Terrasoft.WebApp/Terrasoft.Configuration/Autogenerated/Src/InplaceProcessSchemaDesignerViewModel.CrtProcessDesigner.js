Ext.define("Terrasoft.Designers.InplaceProcessSchemaDesignerViewModel", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModelNew",
	alternateClassName: "Terrasoft.InplaceProcessSchemaDesignerViewModel",

	mixins: {
		customEvent: "Terrasoft.mixins.CustomEventDomMixin",
	},

	/**
	 * @private
	 */
	_saveCallback: null,

	/**
	 * @private
	 */
	_saveSubscription: null,

	/**
	 * Indicates that there is an active saving operation
	 * @public
	 */
	isSavingInProgress: false,

	/**
	 * Disable all hotkeys on the copilot action page
	 * @override
	 */
	addHotkeys: Terrasoft.emptyFn,

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#showMessagePanel
	 * @override
	 */
	showMessagePanel: Terrasoft.emptyFn,

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#getIsNeedReplaceUrl
	 * @override
	 */
	getIsNeedReplaceUrl: function() {
		return false;
	},

	/**
	 * @private
	 */
	_setSchemaIsNew: function() {
		const isSchemaNew = this.getIsNew();
		this.set("SchemaIsNew", isSchemaNew);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#onAfterSchemaSaved
	 * @override
	 */
	onAfterSchemaSaved: function(validatorInfo, isValid, callback, scope) {
		this.callParent([validatorInfo, isValid, () => {
			this._setSchemaIsNew();
			callback.call(scope, validatorInfo, isValid);
		}, scope]);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#onSaveSchemaCanceled
	 * @override
	 */
	onSaveSchemaCanceled: function() {
		this._setSchemaIsNew();
	},

	/**
	 * @private
	 */
	_onSaveEvent: function(event) {
		const instanceId = this.get("DesignerInstanceId");
		if (!event || event.designerInstanceId !== instanceId) {
			return;
		}
		let saveCallback = (validatorInfo, isValid) => {
			this.isSavingInProgress = false;
			event.saveCallback?.({
				isCanceled: false,
				isValid: isValid
			});
		};
		this.isSavingInProgress = true;
		if (event.needSaveNewVersion) {
			this.saveNewVersion(saveCallback);
		} else {
			saveCallback.onSaveSchemaCanceled = () => {
				event.saveCallback?.({
					isCanceled: true,
					isValid: true
				});
			};
			this.save(saveCallback, this);
		}
	},

	/**
	 * @private
	 */
	_onCancelEvent: function(event) {
		const instanceId = this.get("DesignerInstanceId");
		if (event?.designerInstanceId === instanceId) {
			this.cancelChanges(event.callback, this);
		}
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getModelColumns
	 * @override
	 */
	getModelColumns: function() {
		const columns = this.callParent(arguments);
		columns.DesignerInstanceId = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.GUID
		};
		columns.SchemaDescription = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.TEXT
		};
		columns.SchemaCode = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.TEXT
		};
		columns.DesignPackageUId = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.GUID
		};
		columns.SchemaIsNew = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.BOOLEAN
		};
		return columns;
	},

	/**
	 * @private
	 */
	_onPropertiesPageDescriptionChanged: function(description) {
		this.set("SchemaDescription", description);
	},

	/**
	 * @private
	 */
	_onPropertiesPageCodeChanged: function(schemaCode) {
		this.set("SchemaCode", schemaCode);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#onSandboxInitialized
	 * @override
	 */
	onSandboxInitialized: function() {
		this.callParent(arguments);
		this.sandbox.registerMessages({
			"PropertiesPageDescriptionChanged": {
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
				mode: Terrasoft.MessageMode.PTP
			}
		});
		this.sandbox.registerMessages({
			"PropertiesPageCodeChanged": {
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
				mode: Terrasoft.MessageMode.PTP
			}
		});
		this.sandbox.subscribe("PropertiesPageDescriptionChanged", this._onPropertiesPageDescriptionChanged, this);
		this.sandbox.subscribe("PropertiesPageCodeChanged", this._onPropertiesPageCodeChanged, this);
	},

	/**
	 * Sets schema text property value by its name.
	 * @param {String} propertyName Property name.
	 * @param {String} value Property value.
	 */
	setSchemaTextValue: function(propertyName, value) {
		this.set(propertyName, value);
	},

	/**
	 * @private
	 */
	_initializeSchemaProperties: function(schema) {
		this.set("SchemaDescription", schema.description.getValue());
		this.set("SchemaCode", schema.name);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#loadItems
	 * @override
	 */
	loadItems: function(schema) {
		this.callParent(arguments);
		this._initializeSchemaProperties(schema);
	},

	/**
	 * @private
	 */
	_onSchemaDescriptionChange: function(_, description) {
		const schema = this.get("Schema");
		schema.setLocalizableStringPropertyValue("description", description);
	},

	/**
	 * @private
	 */
	_onSchemaCodeChange: function(_, name) {
		const schema = this.get("Schema");
		schema.setPropertyValue("name", name);
	},

	/**
	 * @inheritdoc Terrasoft.Designers.ProcessSchemaDesignerViewModel#init
	 * @overridde
	 */
	init: function() {
		this.callParent(arguments);
		const customEvent = this.mixins.customEvent;
		customEvent.init();
		this._saveSubscription = customEvent.subscribe("saveProcessSchema").subscribe(this._onSaveEvent.bind(this));
		this._cancelSubscription = customEvent.subscribe("cancelProcessSchemaChanges")
			.subscribe(this._onCancelEvent.bind(this));
		this.on("change:SchemaDescription", this._onSchemaDescriptionChange, this);
		this.on("change:SchemaCode", this._onSchemaCodeChange, this);
	},

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#createSchema
	 * @overridde
	 */
	createSchema: function(schemaUId) {
		const targetPackageUId = this.get("PackageUId");
		const designPackageUId = this.get("DesignPackageUId");
		if (targetPackageUId !== designPackageUId) {
			this.set("PackageUId", designPackageUId);
		}
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#saveNewSchemaVersion
	 * @overridde
	 */
	saveNewSchemaVersion: function(config, callback, scope) {
		const parentMethod = this.getParentMethod();
		const parentMethodArguments = arguments;
		const sourceSchema = this.get("Schema");
		const sourcePackageUId = sourceSchema.packageUId;
		const designPackageUId = this.get("DesignPackageUId");
		if (sourcePackageUId !== designPackageUId) {
			Terrasoft.BaseSchemaDesignerUtilities.loadSysPackageByUId(designPackageUId, function(sysPackage) {
				config.sysPackage = sysPackage;
				config.canEditPackageSchema = true;
				Ext.callback(parentMethod, this, parentMethodArguments);
			}, this);
			return;
		}
		Ext.callback(parentMethod, this, parentMethodArguments);
	},

	/**
	 * @inheritdoc Terrasoft.core.BaseObject#onDestroy
	 * @override
	 */
	onDestroy: function() {
		this._saveSubscription?.unsubscribe();
		this._cancelSubscription?.unsubscribe();
		this.un("change:SchemaDescription", this._onSchemaDescriptionChange, this);
		this.un("change:SchemaCode", this._onSchemaCodeChange, this);
		this.callParent(arguments);
	}

});
