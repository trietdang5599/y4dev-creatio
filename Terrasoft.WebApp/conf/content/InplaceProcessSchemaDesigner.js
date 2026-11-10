Terrasoft.configuration.Structures["InplaceProcessSchemaDesigner"] = {innerHierarchyStack: ["InplaceProcessSchemaDesigner"]};
Ext.define("Terrasoft.Designers.InplaceProcessSchemaDesigner", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerNew",
	alternateClassName: "Terrasoft.InplaceProcessSchemaDesigner",

	/**
	 * Creates an instance of the InplaceProcessSchemaDesigner class.
	 */
	constructor: function() {
		this.callParent(arguments);
		this.addEvents("loadStart");
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.InplaceProcessSchemaDesignerViewModel",

	/**
	 * Designer instance identifier.
	 */
	designerInstanceId: null,

	/**
	 * Design package unique identifier.
	 */
	designPackageUId: null,

	/**
	 * Indicates whether the schema is new or existing.
	 */
	schemaIsNew: false,

	/**
	 * Parameters that should be created when creating a new schema.
	 * @type {Array}
	 */
	preCreateParameters: [],

	/**
	 * Method that is called for handling the changes of the properties from the outside of the designer.
	 */
	handlePropertiesChange: Terrasoft.emptyFn,

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#getDesignerViewModelConfig
	 * @override
	 */
	getDesignerViewModelConfig: function() {
		const config = this.callParent(arguments);
		config.values.DesignerInstanceId = this.designerInstanceId;
		config.values.DesignPackageUId = this.designPackageUId;
		config.values.SchemaIsNew = this.schemaIsNew;
		config.values.PreCreateParameters = this.preCreateParameters;
		return config;
	},

	/**
	 * Sets schema text property value by its name.
	 * @param {String} propertyName Property name.
	 * @param {String} value Property value.
	 */
	setSchemaTextValue: function(propertyName, value) {
		this.designerViewModel.setSchemaTextValue(propertyName, value);
	},

	/**
	 * @private
	 */
	_callHandlePropertiesChanged: function(name, value) {
		Ext.callback(this.handlePropertiesChange, this, [{
			name, value
		}]);
	},

	/**
	 * @private
	 */
	_onSchemaCaptionChange: function(model, processCaption) {
		this._callHandlePropertiesChanged('SchemaCaption', processCaption);
	},

	/**
	 * @private
	 */
	_onSchemaUIdChange: function(model, schemaUId) {
		this._callHandlePropertiesChanged('SchemaUId', schemaUId);
	},

	/**
	 * @private
	 */
	_onIsSchemaChanged: function(model, isSchemaChanged) {
		if (isSchemaChanged && this.designerViewModel?.isSavingInProgress) {
			this.designerViewModel.set('IsSchemaChanged', false, {silent: true});
			return;
		}
		this._callHandlePropertiesChanged('IsSchemaChanged', isSchemaChanged);
	},

	/**
	 * @private
	 */
	_onSchemaIsNewChange: function(model, schemaIsNew) {
		this._callHandlePropertiesChanged('SchemaIsNewChange', schemaIsNew);
	},

	/**
	 * @private
	 */
	_onSchemaDescriptionChange: function(model, schemaDescription) {
		this._callHandlePropertiesChanged('SchemaDescription', schemaDescription);
	},

	/**
	 * @private
	 */
	_onLoadStart: function () {
		this.fireEvent("loadStart");
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerNew#renderDesignContainer
	 * @override
	 */
	renderDesignContainer: function() {
		this.callParent(arguments);
		const designerViewModel = this.designerViewModel;
		designerViewModel.on("change:SchemaCaption", this._onSchemaCaptionChange, this);
		designerViewModel.on("change:SchemaDescription", this._onSchemaDescriptionChange, this);
		designerViewModel.on("change:SchemaUId", this._onSchemaUIdChange, this);
		designerViewModel.on("change:IsSchemaChanged", this._onIsSchemaChanged, this);
		designerViewModel.on("change:SchemaIsNew", this._onSchemaIsNewChange, this);
		designerViewModel.on("loadStart", this._onLoadStart, this);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#renderDesignContainer
	 * @override
	 */
	setTitle: function(model, processCaption) {
	},

	/**
	 * @inheritdoc Terrasoft.BaseSchemaDesigner#renderDesignContainer
	 * @override
	 */
	onDestroy: function() {
		const designerViewModel = this.designerViewModel;
		designerViewModel.un("change:SchemaCaption", this._onSchemaCaptionChange, this);
		designerViewModel.un("change:SchemaDescription", this._onSchemaDescriptionChange, this);
		designerViewModel.un("change:SchemaUId", this._onSchemaUIdChange, this);
		designerViewModel.un("change:IsSchemaChanged", this._onIsSchemaChanged, this);
		designerViewModel.un("change:SchemaIsNew", this._onSchemaIsNewChange, this);
		designerViewModel.un("loadStart", this._onLoadStart, this);
		this.callParent(arguments);
	}
});


