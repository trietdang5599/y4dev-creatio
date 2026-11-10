Ext.define("Terrasoft.Designers.EmbeddedProcessSchemaDesignerViewModelNew", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModelNew",
	alternateClassName: "Terrasoft.EmbeddedProcessSchemaDesignerViewModelNew",

	mixins: {
		embeddedProcessSchemaDesignerMixin: "Terrasoft.EmbeddedProcessSchemaDesignerMixin"
	},

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#contextHelpCode
	 * @override
	 */
	contextHelpCode: "EmbeddedProcessSchemaDesigner",

	/**
	 * @inheritdoc Terrasoft.Designers.ProcessSchemaDesignerViewModel#schemaManager
	 * @override
	 */
	schemaManager: Terrasoft.EmbeddedProcessSchemaManager,

	/**
	 * @inheritdoc Terrasoft.Designers.ProcessSchemaDesignerViewModel#urlHashPrefix
	 * @override
	 */
	urlHashPrefix: "entityProcess",

	/**
	 * Local storage property name for user defined code.
	 * @protected
	 * @type {String}
	 */
	storageSchemaUserDefinedCode: "ProcessSchemaUserDefinedCode",

	// endregion

	// region Properties: Public

	/**
	 * Flag specifying that the this schema has a parent process schema.
	 * @type {Boolean}
	 */
	hasParentProcess: false,

	// endregion

	//region Methods: Private

	/**
	 * @private
	 */
	_saveUserDefinedCodeToStorage: function() {
		const schema = this.get("Schema");
		this.localStore.setItem(this.storageSchemaUserDefinedCode, schema.userDefinedCode);
	},

	/**
	 * @private
	 */
	_getElementToolsConfig: function() {
		return {
			type: "scriptTask",
			userTaskType: null
		};
	},

	//endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onSchemaLoaded
	 * @override
	 * @param {Terrasoft.manager.EmbeddedProcessSchema} schema Process schema.
	 */
	onSchemaLoaded: function(schema) {
		this.callParent(arguments);
		this.mixins.embeddedProcessSchemaDesignerMixin.onSchemaLoaded.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#openSourceCode
	 * @override
	 */
	openSourceCode: function(schema) {
		Terrasoft.BaseSchemaDesignerUtilities.openEntitySourceCode(schema);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onGenerateItemNameAndCaption
	 * @override
	 */
	onGenerateItemNameAndCaption: function(item) {
		return this.mixins.embeddedProcessSchemaDesignerMixin.onGenerateItemNameAndCaption.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#showProcessConfirmationDialog
	 * @override
	 */
	showProcessConfirmationDialog: function(title, message, handler, buttons) {
		this.callParent([title, null, handler, buttons]);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#getDiagramConfig
	 * @override
	 */
	getDiagramConfig: function() {
		const config = this.callParent();
		config.isEmbeddedProcess = true;
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getElementSchemaManagerItems
	 * @override
	 */
	getElementSchemaManagerItems: function() {
		const items = this.callParent(arguments);
		return items.filter((item) => item.instance.supportEmbeddedProcess);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getPaletteUserTask
	 * @override
	 */
	getPaletteUserTask: function() {
		return null;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getServiceTask
	 * @override
	 */
	getPaletteServiceTask: function() {
		return  {
			...this.callParent(arguments),
			...this._getElementToolsConfig()
		};
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getElementToolsUserTask
	 * @override
	 */
	getElementToolsUserTask: function() {
		return null;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getElementToolsServiceTask
	 * @override
	 */
	getElementToolsServiceTask: function() {
		return  {
			...this.callParent(arguments),
			...this._getElementToolsConfig()
		};
	},

	/**
	 * @protected
	 */
	getCustomPaletteElements: function() {
		const paletteElements = this.callParent(arguments);
		delete paletteElements.endEvent;
		return {
			...paletteElements,
			startEvent: {
				...paletteElements.startEvent,
				type: "startEventMessage",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.StartMessageCaption
			}
		};
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModelNew#getEventSubProcessStartSignalElementSchema
	 * @override
	 */
	getEventSubProcessStartSignalElementSchema: function() {
		return Terrasoft.ProcessStartMessageNonInterruptingSchema;
	},

	/**
	 * @inheritDoc Terrasoft.BaseSchemaDesignerStorageMixin#saveSchemaToStorage
	 * @override
	 */
	saveSchemaToStorage: function() {
		const result = this.mixins.BaseSchemaDesignerStorageMixin.saveSchemaToStorage.call(this);
		if (result) {
			this._saveUserDefinedCodeToStorage();
		}
		return result;
	},

	/**
	 * @inheritDoc Terrasoft.BaseSchemaDesignerStorageMixin#getSchemaFromStorage
	 * @override
	 */
	getSchemaFromStorage: function() {
		const storageSchema = this.mixins.BaseSchemaDesignerStorageMixin.getSchemaFromStorage.call(this);
		if (storageSchema) {
			const userDefinedCode = this.localStore.getItem(this.storageSchemaUserDefinedCode);
			storageSchema.userDefinedCode = userDefinedCode;
		}
		return storageSchema;
	},

	/**
	 * @inheritDoc Terrasoft.BaseProcessSchemaDesignerViewModel#clearSchemaStorageInfo
	 * @override
	 */
	clearSchemaStorageInfo: function() {
		this.callParent(arguments);
		this.localStore.removeItem(this.storageSchemaUserDefinedCode);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#getSaveButtonMenuItems
	 * @override
	 */
	getSaveButtonMenuItems: function() {
		return [];
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#getIsSuggestionsEnabled
	 * @override
	 */
	getIsSuggestionsEnabled: function() {
		return false;
	}

	// endregion

});
