Ext.define("Terrasoft.core.SchemaManagerEventObserver", {
	alternateClassName: "Terrasoft.SchemaManagerEventObserver",

	singleton: true,

	constructor: function() {
		Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._onMessageHandler, this);
	},

	/**
	 * @private
	 */
	_publishSchemaRequireJsPathChangedBroadcastMessage: function(message) {
		const channel = new BroadcastChannel2('schema-requirejs-path-changed');
		channel.postMessage(message);
	},

	/**
	 * @private
	 */
	_onMessageHandler: function(channel, message) {
		if (Ext.isEmpty(message)) {
			return;
		}
		const header = message.Header;
		if (Ext.isEmpty(header) ||
			header.Sender !== "SchemaManagerItemEventNotifier" ||
			(header.BodyTypeName !== "ChangedSchema" && header.BodyTypeName !== "RemovedSchema")) {
			return;
		}
		const body = JSON.parse(message.Body);
		if (body.ManagerName === "ClientUnitSchemaManager") {
			this._setRequireClientUnitSchemaJsConfig(body.Name, body.IsUserLevelSchema, body.Checksum,
				header.BodyTypeName);
		}
		if (body.ManagerName === "EntitySchemaManager" && 
				Terrasoft.Features.getIsEnabled('UseRequireEntitySchema8x')) {
			this._setRequireEntitySchemaJsConfig(body.Name, body.Checksum);
		}
		this._publishSchemaRequireJsPathChangedBroadcastMessage(body);
	},

	/**
	 * @private
	 */
	_setRequireEntitySchemaJsConfig: function(schemaName, checksum) {
		require.undef(schemaName);
		const suffix = ".js";
		const hash = Terrasoft.generateGUID('N');
		const culture = Terrasoft.currentUserCultureName;
		checksum = checksum || Terrasoft.generateGUID('N') + Terrasoft.currentUserCultureName;
		let paths = {};
		if (Terrasoft.useStaticFileContent &&
				Terrasoft.Features.getIsEnabled('DisableUseImmediateSchemaContentRefresh')) {
			this.resetBundleRequireConfig();
			const resourcesSchemaName = schemaName + "Resources";
			const url = Terrasoft.workspaceBaseUrl + "/conf/content/";
			const schemaUrl = `${url}${schemaName}${suffix}?hash=${hash}`;
			const resourcesUrl = `${url}resources/${culture}/${resourcesSchemaName}${suffix}?hash=${hash}`;
			const emptyResourcesUrl = Terrasoft.coreModulesPath + "Terrasoft/configuration/resources/empty-resources";
			paths = {
				[schemaName]: schemaUrl,
				[resourcesSchemaName] : [resourcesUrl, emptyResourcesUrl]
			}
		} else {
			const schemaUrl =  `${Terrasoft.workspaceBaseUrl}/configuration/entityschema/${checksum}/${schemaName}`;
			paths = {
				[schemaName]: schemaUrl
			};
		}
		require.config({paths});
	},

	/**
	 * @private
	 */
	_setRequireClientUnitSchemaJsConfig: function(schemaName, isUserLevelSchema, checksum, bodyTypeName) {
		let paths;
		require.undef(schemaName);
		require.undef(schemaName + "Structure");
		const schemaResourcesName = schemaName + "Resources";
		require.undef(schemaResourcesName);
		if (isUserLevelSchema) {
			if (bodyTypeName !== "ChangedSchema") {
				return;
			}
			const url = Terrasoft.workspaceBaseUrl + "/configuration-uls/";
			const schemaUrl = url + checksum + "/" + schemaName;
			const version = "_" + checksum;
			paths = {[schemaName + version]: schemaUrl};
			require.config({paths});
			require.config({
				map: {
					'*': { [schemaName]: schemaName + version }
				}
			});
		} else {
			const suffix = ".js?hash=" + Date.now();
			if (Terrasoft.useStaticFileContent &&
					Terrasoft.Features.getIsEnabled('DisableUseImmediateSchemaContentRefresh')) {
				this.resetBundleRequireConfig();
				const url = Terrasoft.workspaceBaseUrl + "/conf/content/";
				const schemaUrl = url + schemaName + suffix;
				const schemaResourcesUrl = `${url}resources/${Terrasoft.currentUserCultureName}/${schemaResourcesName}` +
					suffix;
				const emptyResourcesUrl = Terrasoft.coreModulesPath + "Terrasoft/configuration/resources/empty-resources";
				paths = {
					[schemaName]: schemaUrl,
					[schemaResourcesName]: [schemaResourcesUrl, emptyResourcesUrl]
				};
			} else {
				const url = Terrasoft.workspaceBaseUrl + `/configuration/${checksum}/`;
				const schemaUrl = url + schemaName + suffix;
				paths = {[schemaName]: schemaUrl};
			}
			require.config({paths});
		}
	},

	/**
	 * Reset requireJs bundles config.
	 */
	resetBundleRequireConfig: function() {
		require.config({
			bundles: {}
		});
	}

});