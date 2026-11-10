/**
 * @class Terrasoft.services.ServiceSchema
 */
Ext.define("Terrasoft.services.ServiceSchema", {
	extend: "Terrasoft.manager.BaseSchema",
	alternateClassName: "Terrasoft.ServiceSchema",

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseSchema#contractName
	 * @overridden
	 */
	contractName: "ServiceSchema",

	/**
	 * @inheritdoc Terrasoft.BaseSchema#contractName
	 * @overridden
	 */
	serializableProperties: [
		"baseUri",
		"namespace",
		"caption",
		"description",
		"methods",
		"name",
		"packageUId",
		"realUId",
		"retryCount",
		"type",
		"uId",
		"authInfo"
	],

	//endregion

	// region Properties: Public

	/**
	 * Base uri
	 * @type {String}
	 */
	baseUri: null,

	/**
	 * Service namespaces
	 * @type {Terrasoft.ObjectCollection}
	 */
	namespaces: null,

	/**
	 * Methods
	 * @type {Terrasoft.ObjectCollection}
	 */
	methods: null,

	/**
	 * Service type
	 * @type {Terrasoft.services.enums.ServiceType}
	 */
	type: Terrasoft.services.enums.ServiceType.REST,

	/**
	 * Retry count
	 * @type {Number}
	 */
	retryCount: 0,

	/**
	 * Authentification info.
	 * @type {Terrasoft.AuthInfo}
	 */
	authInfo: null,

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	_getMetaItemConfigItems: function(config, itemName) {
		return config && config[itemName] && (config[itemName].items || config[itemName].Items);
	},

	/**
	 * @private
	 */
	_getMethodsSysSettings: function() {
		const methodsSysSettings = [];
		this.methods.each(function(method) {
			if (method.request.parameters) {
				const requestParameters = this._getParameterSysSettings(method.request.parameters);
				[].push.apply(methodsSysSettings, requestParameters);
			}
			if (method.response.parameters) {
				const responseParameters = this._getParameterSysSettings(method.response.parameters);
				[].push.apply(methodsSysSettings, responseParameters);
			}
		}, this);
		return methodsSysSettings;
	},

	/**
	 * @private
	 */
	_getParameterSysSettings: function(parameters) {
		const parameterSysSettings = [];
		parameters.each(function(parameter) {
			if (parameter.itemProperties.isEmpty()) {
				const source = parameter.defValue && parameter.defValue.source;
				if (source === Terrasoft.services.enums.ServiceParameterValueSource.SYS_SETTING) {
					parameterSysSettings.push(parameter.defValue.value);
				}
			} else {
				const nestedParameters = this._getParameterSysSettings(parameter.itemProperties);
				[].push.apply(parameterSysSettings, nestedParameters);
			}
		}, this);
		return parameterSysSettings;
	},

	/**
	 * @private
	 */
	_onMethodsChange: function() {
		this.fireEvent("changed", {methods: this.methods}, this);
	},

	/**
	 * @param methods {Object}
	 * @private
	 */
	_addMethods: function(methods) {
		Terrasoft.each(methods, function(methodConfig, methodUId) {
			methodConfig._serviceSchema = this;
			this.methods.add(methodUId, Ext.create("Terrasoft.ServiceMethod", methodConfig));
		}, this);
	},

	/**
	 * @private
	 */
	_initMethods: function(config) {
		if (!this.methods) {
			this.methods = this._createServiceMetaItemCollection();
		}
		let items = this._getMetaItemConfigItems(config, "methods");
		if (items) {
			this.methods = this._createServiceMetaItemCollection();
			this._addMethods(items);
		}
		this.methods.on("changed", this._onMethodsChange, this);
	},

	/**
	 * @private
	 */
	_onMethodsChange: function() {
		this.fireEvent("changed", {methods: this.methods}, this);
	},

	/**
	 * @param methods {Object}
	 * @private
	 */
	_addMethods: function(methods) {
		Terrasoft.each(methods, function(methodConfig, methodUId) {
			methodConfig._serviceSchema = this;
			this.methods.add(methodUId, Ext.create("Terrasoft.ServiceMethod", methodConfig));
		}, this);
	},

	/**
	 * @private
	 */
	_createServiceMetaItemCollection: function() {
		return new Terrasoft.ObjectCollection({
			getKey: function(item) {
				return item && item.getPropertyValue("uId");
			}
		});
	},

	/**
	 * @param namespaces {Object}
	 * @private
	 */
	_addNamespaces: function(namespaces) {
		Terrasoft.each(namespaces, function(config, UId) {
			config._serviceSchema = this;
			this.namespaces.add(UId, Ext.create("Terrasoft.ServiceNamespace", config));
		}, this);
	},

	/**
	 * @private
	 */
	_onNamespaceChange: function() {
		this.fireEvent("changed", {namespaces: this.namespaces}, this);
	},

	/**
	 * @private
	 */
	_initNamespaces: function(config) {
		if (!this.namespaces) {
			this.namespaces = this._createServiceMetaItemCollection();
		}
		let items = this._getMetaItemConfigItems(config, "namespaces");
		if (items) {
			this.namespaces = this._createServiceMetaItemCollection();
			this._addNamespaces(items);
		}
		this.namespaces.on("changed", this._onNamespaceChange, this);
	},

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor.
	 * @overridden
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.namespaces = this.getSerializableProperty(this.namespaces);
		serializableObject.methods = this.getSerializableProperty(this.methods);
	},

	/**
	 * @inheritdoc Terrasoft.MetaUtem#restorePropertyValue.
	 * @overridden
	 */
	restorePropertyValue: function(propertyName, propertyValue) {
		if (propertyName === "methods") {
			this.methods.clear();
			this._addMethods(propertyValue.items);
		} else if (propertyName === "namespaces") {
			this.namespaces.clear();
			this._addNamespaces(propertyValue.items);
		} else {
			this.callParent(arguments);
		}
	},

	//endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor.
	 * @overridden
	 */
	constructor: function(config) {
		this.callParent(arguments);
		this._initMethods(config);
		this._initNamespaces(config);
		const authInfoConfig = (config && config.authInfo) || {};
		this.authInfo = new Terrasoft.AuthInfo(Ext.merge(authInfoConfig, {_serviceSchema: this}));
	},

	/**
	 * Created service method
	 * @param config
	 * @returns {Terrasoft.ServiceMethod}
	 */
	createMethod: function(config) {
		return Ext.create("Terrasoft.ServiceMethod", config);
	},

	/**
	 * Finds method by name.
	 * @param {String} name Method name.
	 * @returns
	 */
	findMethodByName: function(name) {
		return this.methods && this.methods.findByPath("name", name);
	},

	/**
	 * Returns array SysSettings codes used in service schema.
	 * @return {Array}
	 */
	getServiceSysSettingsCollection: function() {
		let sysSettings = [];
		if (this.methods) {
			sysSettings = this._getMethodsSysSettings();
		}
		if (this.authInfo.authType !== Terrasoft.services.enums.AuthType.None) {
			const sysSettingSource = Terrasoft.services.enums.ServiceParameterValueSource.SYS_SETTING;
			const authInfoSysSettings = this.authInfo.values.filterByPath("source", sysSettingSource);
			[].push.apply(sysSettings, authInfoSysSettings.getItems().map(function(item) {
				return item.value;
			}));
		}
		return sysSettings;
	},

	isRest: function () {
		return this.type === Terrasoft.services.enums.ServiceType.REST;
	},

	isSoap: function () {
		return this.type === Terrasoft.services.enums.ServiceType.SOAP11 || this.type === Terrasoft.services.enums.ServiceType.SOAP12;
	}

	// endregion

});
