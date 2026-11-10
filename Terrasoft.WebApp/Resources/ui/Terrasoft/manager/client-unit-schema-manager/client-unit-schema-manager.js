/**
 */
Ext.define("Terrasoft.manager.ClientUnitSchemaManager", {
	extend: "Terrasoft.manager.BaseSchemaManager",
	alternateClassName: "Terrasoft.ClientUnitSchemaManager",

	singleton: true,

	// region Properties: Protected

	/**
	 * Name of the manager item class.
	 * @protected
	 * @property {String} itemClassName
	 */
	itemClassName: "Terrasoft.ClientUnitSchemaManagerItem",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#managerName
	 * @protected
	 * @override
	 */
	managerName: "ClientUnitSchemaManager",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#outdatedEventName
	 * @override
	 */
	outdatedEventName: "ClientUnitSchema_Outdated",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManagerItem#useNotification
	 * @override
	 */
	useNotification: true,

	// endregion

	// region Methods: Private

	/**
	 * @private
	 */
	_assignParentSchemaParameters: function(schema, callback, scope) {
		var parentSchemaUId = schema && schema.parentSchemaUId;
		if (Terrasoft.isEmpty(parentSchemaUId)) {
			callback.call(scope);
			return;
		}
		Terrasoft.ClientUnitSchemaManager.getSchemaInstance(parentSchemaUId, function(parentSchema) {
			parentSchema.parameters.each(function(item) {
				var parameter = item.clone();
				parameter.uId = item.uId;
				parameter.parentSchema = schema;
				schema.parameters.add(parameter.uId, parameter);
			}, this);
			callback.call(scope);
		}, this);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchemaManager#initItems
	 * @override
	 */
	initItems: function(items) {
		if (Terrasoft.Features.getIsEnabled("CRM-39598")) {
			this.initServiceItems(items);
			return;
		}
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchemaManager#queryItems
	 * @override
	 */
	queryItems: function(callback, scope) {
		if (Terrasoft.Features.getIsEnabled("CRM-39598")) {
			var request = new Terrasoft.BaseRequest({
				contractName: "ClientUnitSchemaManagerRequest"
			});
			return request.execute(callback, scope);
		}
		this.callParent(arguments);
	},

	// endregion
	
	// region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#getSelectQuery
	 * @override
	 */
	getSelectQuery: function() {
		const itemsQuery = this.callParent(arguments);
		if (Terrasoft.Features.getIsDisabled("CRM-39598") &&
				Terrasoft.Features.getIsEnabled("ProcessFeatures.Use8XPages")) {
			const schemaTypeExtraPropertyFilter = Terrasoft.createColumnFilterWithParameter(
				"[SysSchemaProperty:SysSchema:Id].Name", "SchemaType");
			itemsQuery.filters.addItem(schemaTypeExtraPropertyFilter);
		}
		return itemsQuery;
	},

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchemaManager#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		const columnsConfig = {
			parentSchemaUId: "Parent.UId",
		};
		if (Terrasoft.Features.getIsDisabled("CRM-39598") &&
				Terrasoft.Features.getIsEnabled("ProcessFeatures.Use8XPages")) {
			columnsConfig.schemaType = "[SysSchemaProperty:SysSchema:Id].Value"
		}
		Ext.apply(this.propertyColumnNames, columnsConfig);
	},

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#getDesignSchemaRequestParameters.
	 * @protected
	 * @override
	 */
	getDesignSchemaRequestParameters: function() {
		return {
			contractName: "DesignClientUnitSchemaRequest",
			responseClassName: "Terrasoft.ClientUnitSchemaResponse"
		};
	},

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#createSchemaInstance.
	 * @protected
	 * @override
	 */
	createSchemaInstance: function(config, callback, scope) {
		this.callParent([config,
			function(schema, managerItem, errorMessage) {
				this._assignParentSchemaParameters(schema, function() {
					callback.call(scope, schema, managerItem, errorMessage);
				}, this);
			},
			this]);
	},

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#getBundleInstanceRequest.
	 * @protected
	 * @override
	 */
	getBundleInstanceRequest: function(schemaUId, packageUId) {
		return new Terrasoft.ClientUnitBundleSchemaRequest({
			uId: schemaUId,
			packageUId: packageUId
		});
	},

	/**
	 * Finds client unit schema parameter by UId.
	 * @param {Object} config
	 * @param {String} config.schemaUId Schema UId.
	 * @param {String} config.parameterUId Parameter UId.
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The scope of callback function.
	 * @return {Terrasoft.ClientUnitSchemaParameter}
	 */
	findParameterByUId: function(config, callback, scope) {
		this.getInstanceByUId(config.schemaUId, function(schema) {
			var parameter = schema.parameters.find(config.parameterUId);
			callback.call(scope, parameter);
		}, this);
	},

	/**
	 * Finds client unit schema parameter by name.
	 * @param {Object} config
	 * @param {String} config.schemaUId Schema UId.
	 * @param {String} config.parameterName Parameter UId.
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The scope of callback function.
	 * @return {Terrasoft.ClientUnitSchemaParameter}
	 */
	findParameterByName: function(config, callback, scope) {
		this.getInstanceByUId(config.schemaUId, function(schema) {
			var parameter = schema.parameters.findByPath("name", config.parameterName);
			callback.call(scope, parameter);
		}, this);
	},

	/**
	 * Returns schema of current package by schema UId.
	 * @param {String} schemaUId Parent schema UId.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Callback function context.
	 */
	getCurrentPackageSchemaByUId: function(schemaUId, callback, scope) {
		Terrasoft.PackageManager.getCurrentPackageUId(function(packageUId) {
			const config = {
				packageUId: packageUId,
				schemaUId: schemaUId
			};
			this.forceGetPackageSchema(config, callback, scope);
		}, this);
	},

	/**
	 * Prepares client unit schema for page designer.
	 * @param {Terrasoft.manager.ClientUnitSchema} schema Client unit schema instance.
	 * @param {String} entitySchemaName Entity schema name.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Context.
	 */
	prepareDesignPageSchema: function(schema, entitySchemaName, callback, scope) {
		if (this.contains(schema.uId)) {
			callback.call(scope, schema);
			return;
		}
		const schemaType = Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA;
		schema.setDefaultSchemaBody(schemaType, {"entitySchemaName": entitySchemaName});
		this.addSchema(schema);
		if (Terrasoft.Features.getIsEnabled("UseSectionWizardHierarchy")) {
			return schema.define(function() {
				return Ext.callback(callback, scope, [schema]);
			}, this);
		}
		const utilities = Terrasoft.SchemaDesignerUtilities;
		utilities.getCurrentPackageUId(function(currentPackageUId) {
			utilities.forceGetPackageHierarchy(currentPackageUId, function(hierarchy, order) {
				if (order.slice(-1)[0] === currentPackageUId) {
					return Ext.callback(callback, scope, [schema]);
				} else {
					schema.define(function() {
						return Ext.callback(callback, scope, [schema]);
					}, this);
				}
			}, this);
		}, this);
	},

	/**
	 * Prepares page schema for design.
	 * @param {Object} config
	 * @param {String} config.schemaUId Page schema UId.
	 * @param {String} config.packageUId Current package UId.
	 * @param {String} config.entityName Page schema entity schema name.
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The scope of callback function.
	 */
	designPageSchema: function(config, callback, scope) {
		let schema;
		Terrasoft.chain(
			function(next) {
				this.forceGetPackageSchema({
					schemaUId: config.schemaUId,
					packageUId: config.packageUId
				}, next, this);
			},
			function(next, instance) {
				schema = instance;
				this.prepareDesignPageSchema(schema, config.entityName || "", next, this);
			},
			function() {
				callback.call(scope, schema);
			}, this
		);
	},

	/**
	 * Returns extended item of schema in package.
	 * @param {String} schemaUId Schema UId.
	 * @param {String} packageUId Package UId.
	 * @return {Terrasoft.manager.ClientUnitSchemaManagerItem | null}
	 */
	findExtendedItem: function(schemaUId, packageUId) {
		return this.findByFn(function(item) {
			return item.extendParent && item.parentSchemaUId === schemaUId && item.packageUId === packageUId;
		}, this);
	},

	/**
	 * Copies client unit schema.
	 * @override
	 * @param {Terrasoft.manager.ClientUnitSchema} sourcePage Schema instance for copy.
	 * @return {Terrasoft.manager.ClientUnitSchemaManagerItem} Returns added manager item with copy of schema.
	 */
	copySchema: function(sourcePage) {
		let config = {};
		sourcePage.getSerializableObject(config);
		const propertiesToReplace = ["createdInSchemaUId", "modifiedInSchemaUId"];
		const schemaUId = Terrasoft.generateGUID();
		config = this.replaceObjectProperty(config, propertiesToReplace, sourcePage.uId, schemaUId);
		config.uId = schemaUId;
		config.realUId = schemaUId;
		let namePrefix = sourcePage.name;
		if (namePrefix.indexOf(this.schemaNamePrefix) !== 0) {
			namePrefix = this.schemaNamePrefix + namePrefix;
		}
		const name = this.generateItemUniqueName(namePrefix);
		config.extendParent = false;
		const item = this.get(sourcePage.uId);
		config.copySourceSchemaUId = item.status === Terrasoft.ModificationStatus.NEW
			? sourcePage.copySourceSchemaUId
			: sourcePage.uId;
		config.dependencies = sourcePage.dependencies.clone();
		config.parameters = sourcePage.parameters.clone();
		const schema = Ext.create(this.itemInstanceClassName, config);
		this.copyLocalizableResources(sourcePage, schema);
		schema.setPropertyValue("name", name);
		return this.addSchema(schema);
	},

	/**
	 * Set require js path.
	 * @param {String} schemaName Schema name.
	 * @deprecated
	 */
	setRequireJsConfig: function(schemaName) {
		let paths;
		require.undef(schemaName);
		require.undef(schemaName + "Structure");
		const schemaResourcesName = schemaName + "Resources";
		require.undef(schemaResourcesName);
		if (Terrasoft.useStaticFileContent) {
			const url = Terrasoft.workspaceBaseUrl+ "/conf/content/";
			const schemaUrl = url + schemaName;
			const schemaResourcesUrl = `${url}resources/${Terrasoft.currentUserCultureName}/${schemaResourcesName}`;
			const emptyResourcesUrl = Terrasoft.coreModulesPath + "Terrasoft/configuration/resources/empty-resources";
			paths = {
				[schemaName]: schemaUrl,
				[schemaResourcesName]: [schemaResourcesUrl, emptyResourcesUrl]
			};
		} else {
			const url = Terrasoft.workspaceBaseUrl+ "/configuration/hash/";
			const schemaUrl = url + schemaName;
			paths = {[schemaName]: schemaUrl};
		}
		require.config({paths});
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseManager#createManagerItem
	 * @override
	 */
	createManagerItem: function(config) {
		if (Terrasoft.Features.getIsDisabled("CRM-39598") &&
				Ext.isString(config.schemaType) && !config.extraProperties) {
			config.extraProperties = {
				schemaType: Terrasoft.ServerSchemaType[config.schemaType]
			};
			delete config.schemaType;
		}
		return this.callParent(arguments);
	},

	// endregion

});
