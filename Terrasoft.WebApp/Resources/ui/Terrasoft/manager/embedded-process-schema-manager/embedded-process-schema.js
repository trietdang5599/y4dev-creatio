/**
 */
Ext.define("Terrasoft.manager.EmbeddedProcessSchema", {
	extend: "Terrasoft.manager.ProcessSchema",
	alternateClassName: "Terrasoft.EmbeddedProcessSchema",

	// region Properties: Private

	/**
	 * @private
	 */
	convertedMethodsSchemaUIdList: null,

	/**
	 * @private
	 */
	_initialUserDefinedCode: null,

	// endregion

	// region Properties: Public

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#contractName
	 * @override
	 */
	contractName: "ContractEmbeddedProcessSchema",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#managerName
	 * @override
	 */
	managerName: "EmbeddedProcessSchemaManager",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#isCreatedInSvg
	 * @override
	 */
	isCreatedInSvg: true,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.EmbeddedProcessSchema",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#isEmbedded
	 * @override
	 */
	isEmbedded: true,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#useForceCompile
	 * @override
	 */
	useForceCompile: true,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#useNotificationCaption
	 * @override
	 */
	useNotificationCaption: false,

	/**
	 * User defined code.
	 * @type {String}
	 */
	userDefinedCode: null,

	/**
	 * Parent Entity schema unique identifier.
	 * @type {String}
	 */
	parentOwnerSchemaUId: null,

	/**
	 * Entity schema name.
	 * @type {String}
	 */
	ownerSchemaName: "",

	// endregion

	// region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.initCollection("convertedMethodsSchemaUIdList", "Terrasoft.GuidMetaItem", this);
	},

	// endregion

	// region Methods: Private

	/**
	 * @private
	 */
	_getLocalizableValue: function(localizableValues, localizableString) {
		return localizableValues.LocalizableStrings[localizableString.name];
	},

	/**
	 * @private
	 */
	_getLocalizableValueByUId: function(localizableValues, localizableString) {
		return {
			Caption: localizableValues[localizableString.uId + ".Caption"],
			Value: localizableValues[localizableString.uId + ".Value"]
		};
	},

	/**
	 * @private
	 */
	_loadLocalizableStrings: function(localizableValues, getLocalizableValueFn) {
		const localizableStrings = new Terrasoft.Collection();
		Terrasoft.each(this.localizableStrings, (localizableString) => {
			const localizableValue = getLocalizableValueFn.call(this, localizableValues, localizableString);
			const schemaLocalizableString = this.createSchemaLocalizableString(localizableString, localizableValue);
			localizableStrings.add(schemaLocalizableString.uId, schemaLocalizableString);
		}, this);
		this.localizableStrings = localizableStrings;
	},

	/**
	 * @private
	 */
	createSchemaLocalizableString: function(localizableString, localizableValue) {
		const schemaLocalizableString = Ext.create("Terrasoft.SchemaLocalizableString", localizableString);
		schemaLocalizableString.setValue({
			caption: new Terrasoft.LocalizableString({cultureValues: localizableValue.Caption}),
			value: new Terrasoft.LocalizableString({cultureValues: localizableValue.Value})
		});
		return schemaLocalizableString;
	},

	// endregion

	// region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#getEditPageSchemaName
	 * @override
	 */
	getEditPageSchemaName: function(callback, scope) {
		callback.call(scope, "EmbeddedProcessSchemaPropertiesPage");
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#getSerializableObject
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		this.setSerializableCollectionProperty(serializableObject, "convertedMethodsSchemaUIdList");
		this.setSerializableCollectionProperty(serializableObject, "localizableStrings");
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const serializableProperties = this.callParent(arguments);
		const propertiesToRemove = ["notificationCaption", "useSystemSecurityContext", "serializeToDB",
			"serializeToMemory", "isLogging", "enabled", "isActiveVersion", "version", "isDelivered",
			"isEmbedded", "isInterpretable", "useForceCompile", "methodsBody", "compiledMethodsBody",
			"backgroundModePriority", "useUserPermissions"];
		propertiesToRemove.forEach(propertyName => Ext.Array.remove(serializableProperties, propertyName));
		return serializableProperties;
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#loadLocalizableValues
	 * @override
	 */
	loadLocalizableValues: function(localizableValues) {
		if (!localizableValues) {
			return;
		}
		this.callParent(arguments);
		this._loadLocalizableStrings(localizableValues, this._getLocalizableValue);
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#loadLocalizableValuesByUIds
	 * @override
	 */
	loadLocalizableValuesByUIds: function(localizableValues) {
		this.callParent(arguments);
		if (!localizableValues) {
			return;
		}
		this._loadLocalizableStrings(localizableValues, this._getLocalizableValueByUId);
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#getLocalizableValues
	 * @override
	 */
	getLocalizableValues: function(localizableValues) {
		this.callParent(arguments);
		this.localizableStrings.each(function(localizableString) {
			localizableString.getLocalizableValues(localizableValues);
		}, this);
	},

	// endregion

	// region Methods: Public

	/**
	 * Adds 'LocalizableString' to collection.
	 * @param {Object} config Config for create 'LocalizableString'.
	 * @param {String} config.uId Element identifier.
	 * @param {String} config.name SchemaLocalizableString name.
	 * @param {String} config.caption SchemaLocalizableString caption.
	 * @param {String} config.value SchemaLocalizableString value.
	 */
	addLocalizableString: function(config) {
		Ext.apply(config, {
			createdInSchemaUId: this.uId,
			modifiedInSchemaUId: this.uId,
			createdInPackageId: this.createdInPackageId
		});
		const localizableString = Ext.create("Terrasoft.SchemaLocalizableString", config);
		this.localizableStrings.add(localizableString.uId, localizableString);
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#getValidateFormulaServerMethodName
	 * @override
	 */
	getValidateFormulaServerMethodName: function() {
		return "ValidateEmbeddedProcessFormula";
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessSchema#shouldBeCompiled
	 * @override
	 */
	shouldBeCompiled: function() {
		return true;
	},

	/**
	 * Determines whether schema has own lane sets or not.
	 * @returns {boolean}
	 */
	hasOwnLaneSet: function() {
		return this.laneSets.getCount() !== 0;
	},

	/**
	 * Returns string that represents initial user defined code.
	 * @returns {String} initial user defined code.
	 */
	getInitialUserDefinedCode: function() {
		return this._initialUserDefinedCode;
	},

	/**
	 * Sets string that represents initial user defined code.
	 */
	setInitialUserDefinedCode: function(initialUserDefinedCode) {
		this._initialUserDefinedCode = initialUserDefinedCode;
	}

	// endregion

});
