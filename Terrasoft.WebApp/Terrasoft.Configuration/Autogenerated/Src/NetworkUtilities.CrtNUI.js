define("NetworkUtilities", ["MaskHelper", "ConfigurationConstants", "@creatio/utils", "ConfigurationEnumsV2", "ModuleUtils"
], function(MaskHelper, ConfigurationConstants, creatioUtils, ) {

	/**
	 * Class utility methods for working with the navigation entities.
	 */
	Ext.define("Terrasoft.utilities.NetworkUtilities", {
		extend: "Terrasoft.core.BaseObject",
		alternateClassName: "Terrasoft.NetworkUtilities",

		/**
		 * Navigation service redirecting method calling string format.
		 */
		navigationServiceRedirectStringFormat: "rest/NavigationService/Redirect?schemaName={0}&recordId={1}",

		/**
		 * #########, ######## ## ###### ########## URL'##
		 * @param {String} value ######### ############# URL'#
		 * @return {Boolean} true - #### ###### ########### ### URL #######
		 */
		isUrl: function(value) {
			return Terrasoft.isUrl(value);
		},

		/**
		 * Opens URL in new window.
		 * @param {String} value URL string.
		 */
		onUrlClick: function(value) {
			if (this.isUrl(value)) {
				window.open(value);
			}
		},

		/**
		 * Returns entity schema name by entitySchemaUId.
		 * @param {String} entitySchemaUId Entity schema unique identifier.
		 * @return {String} Entity schema name.
		 */
		getEntitySchemaName: function(entitySchemaUId) {
			return Terrasoft.ModuleUtils.getEntitySchemaNameByUId(entitySchemaUId);
		},

		/**
		 * Creates a relative URL to open the card of the entity.
		 * @throws {Terrasoft.ArgumentNullOrEmptyException} Throws an exception if not specified the schema name or
		 * the entity ID.
		 * @inheritdoc NetworkUtilities#getEntityConfigUrl
		 */
		getEntityUrl: function(config) {
			if (arguments.length > 1) {
				config = {
					entitySchema: arguments[0],
					primaryColumnValue: arguments[1],
					typeColumnValue: arguments[2],
					operation: arguments[3]
				};
			}
			let url = "";
			var entityConfig = this.getEntityConfigUrl(config);

			if (entityConfig) {
				const cardModuleAlias = ConfigurationConstants.ModuleAliases[entityConfig.cardModule];
				url = Terrasoft.combinePath(
					cardModuleAlias || entityConfig.cardModule,
					entityConfig.cardSchema,
					entityConfig.operation,
					entityConfig.primaryColumnValue
				);
			}
			return url;
		},

		/**
		 * Returns navigation service page url.
		 * @param {String} schemaName Object schema name.
		 * @param {String} recordId Record identifier.
		 * @return {Object} Navigation service page url.
		 */
		getNavigationServicePageUrl: function(schemaName, recordId) {
			return Ext.String.format(this.navigationServiceRedirectStringFormat, schemaName, recordId);
		},

		/**
		 * Returns relative Url path by card schema name.
		 * @param {String} pageSchemaName Card schema name.
		 * @param {String} operation Card operation name.
		 * @param {String} primaryColumnValue Record identifier.
		 * @return {String}
		 */
		getPageUrl: function(pageSchemaName, operation, primaryColumnValue) {
			return Terrasoft.combinePath("CardModuleV2", pageSchemaName, operation, primaryColumnValue);
		},

		/**
		 * Creates a configuration object values for the U R L to a card entity.
		 * @throws {Terrasoft.ArgumentNullOrEmptyException} Throws an exception if not specified
		 * the schema name or the entity ID.
		 * @param {Object} config Config object.
		 * @param {String} config.entitySchema The name or ID of the schema entity.
		 * @param {String} [config.entitySchemaName] The name of the schema entity. Alias for @entitySchema.
		 * @param {String} config.primaryColumnValue The entity identifier.
		 * @param {String} [config.typeColumnValue] The value of the column type.
		 * @param {String} [config.typeId] The value of the column type. Alias for @typeColumnValue.
		 * @param {String} [config.operation] Operation.
		 * @return {Object} Returns the configuration object values for the U R L to a card entity.
		 */
		getEntityConfigUrl: function(config) {
			const configArg = arguments.length === 1;
			const entitySchema = configArg ? config.entitySchema || config.entitySchemaName : arguments[0];
			const primaryColumnValue = configArg ? config.primaryColumnValue : arguments[1];
			const operation = configArg ? config.operation : arguments[3];
			var entitySchemaName = Terrasoft.isGUID(entitySchema)
				? this.getEntitySchemaName(entitySchema)
				: entitySchema;
			if (!entitySchemaName) {
				throw Ext.create("Terrasoft.ArgumentNullOrEmptyException");
			}
			var moduleStructure = Terrasoft.ModuleUtils.getModuleStructureByName(entitySchemaName);
			var entityStructure = Terrasoft.ModuleUtils.getEntityStructureByName(entitySchemaName);
			if (!entityStructure) {
				return null;
			}
			const typedPage = config.typedPage || (moduleStructure && moduleStructure.attribute) || (entityStructure && entityStructure.attribute);
			let typeColumnValue;
			if (configArg) {
				const valueFromValuePairs = config?.valuePairs?.find(valuePair => valuePair.name === typedPage)?.value;
				typeColumnValue = config.typeColumnValue || valueFromValuePairs || config.typeId;
			} else {
				typeColumnValue = arguments[2];
			}
			const defaultValues = config?.valuePairs?.map(x => {
				return {
					attributeName: x.name,
					value: x.value
				}
			});
			const options = {
				action: config.operation,
				defaultValues: defaultValues,
				entityName: config.entitySchemaName || config.entitySchema,
				entityPageName: config.schemaName,
				cardSchemaName: config.cardSchemaName,
				typeColumnValue
			};
			const page = creatioUtils.NavigationUtils.getPageForAction(options);
			var cardSchema = page.cardSchema;
			var cardModule = Terrasoft.ModuleUtils.getCardModule({
				entityName: entitySchemaName,
				cardSchema: cardSchema,
				defaultModule: "CardModuleV2",
			});
			var configUrl = {
				cardModule: cardModule,
				cardSchema: cardSchema,
				entitySchemaName: entitySchemaName,
				operation: operation || Terrasoft.ConfigurationEnums.CardOperation.EDIT,
				primaryColumnValue: primaryColumnValue
			};
			return configUrl;
		},

		getAttributeValueByRecordId: function(config, callback, scope) {
			var entitySchemaName = config.entitySchemaName;
			var entityId = config.entityId;
			var attribute = config.attribute;
			Terrasoft.chain(function(next) {
				var select = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: entitySchemaName
				});
				select.addColumn("Id");
				select.addColumn(attribute);
				select.getEntity(entityId, next, this);
			}, function(next, result) {
				var typeId = null;
				if (result && result.success) {
					var entity = result.entity;
					typeId = entity.get(attribute);
					typeId = typeId && typeId.value;
				}
				next(typeId);
			}, function(next, typeId) {
				if (callback) {
					callback.call(scope, typeId);
				}
			}, this);
		},

		/**
		 * Prepares config for card.
		 * @param {Object} config Card config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		prepareOpenConfig: function(config, callback, scope) {
			if (!Ext.isObject(config)) {
				throw Ext.create("Terrasoft.UnsupportedTypeException");
			}
			var entityId = config.entityId || (config.entityId = config.primaryColumnValue);
			var entitySchemaName = config.entitySchemaName ||
				(config.entitySchemaName = this.getEntitySchemaName(config.entitySchemaUId));
			if (Ext.isEmpty(config.sandbox) || Ext.isEmpty(entitySchemaName) ||
				(Ext.isEmpty(entityId) && config.operation !== Terrasoft.ConfigurationEnums.CardOperation.ADD)) {
				throw Ext.create("Terrasoft.ArgumentNullOrEmptyException", {
					message: "Arguments: \"sandbox\" and(or) \"entityId\" and(or) \"entitySchemaName\" was not set."
				});
			}
			var moduleStructure = Terrasoft.ModuleUtils.getModuleStructureByName(entitySchemaName);
			var attribute = (moduleStructure && moduleStructure.attribute) || null;
			if (attribute && !config.typeId) {
				Terrasoft.chain(function(next) {
					this.getAttributeValueByRecordId({
						entitySchemaName: entitySchemaName,
						entityId: entityId,
						attribute: attribute
					}, next, this);
				}, function(next, typeId) {
					config.typeId = typeId || config.typeId;
					callback.call(scope, config);
				}, this);
			} else {
				callback.call(scope, config);
			}
		},

		/**
		 * ######### ######## ######## ########.
		 * @throws {Terrasoft.UnsupportedTypeException} ####### ##########,
		 * #### ######## ############ ## ######## ########.
		 * @param {Object} config
		 * @param {String} config.entityId ############# ########.
		 * @param {String} config.entitySchemaName ### ##### ########.
		 * #### ########### ##### ########## ## ############# ##### ########.
		 * @param {String} config.entitySchemaUId ############# ##### ########.
		 * ##### ############# #### ###### ### ##### ########.
		 * @param {Object} config.sandbox ######### ###### ########### ######## ######## ######## ########.
		 * @param {Object} config.stateObj ###### ######### ########### ######## ######## ########.
		 */
		openEntityPage: function(config) {
			if (!Ext.isObject(config)) {
				throw Ext.create("Terrasoft.UnsupportedTypeException");
			}
			MaskHelper.showBodyMask();
			this.prepareOpenConfig(config, function(preparedConfig) {
				var hash = this.getEntityUrl(preparedConfig.entitySchemaName,
					preparedConfig.entityId, preparedConfig.typeId);
				preparedConfig.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: preparedConfig.stateObj || {}
				});
			}, this);
		},

		/**
		 * Opens section of the entity.
		 * @throws {Terrasoft.ArgumentNullOrEmptyException} Throws exception,
		 * if entity schema name is null or empty.
		 * @param {Object} config
		 * @param {String} config.entitySchemaName Entity name.
		 * @param {Object} config.sandbox Sandbox module.
		 */
		openEntitySection: function(config) {
			var entitySchemaName = config.entitySchemaName;
			var sandbox = config.sandbox;
			if (Ext.isEmpty(entitySchemaName) || Ext.isEmpty(sandbox)) {
				throw new Terrasoft.ArgumentNullOrEmptyException();
			}
			var moduleStructure = Terrasoft.ModuleUtils.getModuleStructureByName(entitySchemaName);
			var sectionModule = moduleStructure.sectionModule ||
				ConfigurationConstants.ModuleStructure.DefaultSectionModule;
			var sectionSchemaName = moduleStructure.sectionSchema ||
				moduleStructure.entitySchemaName +
				ConfigurationConstants.ModuleStructure.DefaultSectionSchemaSuffix;
			var hash = Terrasoft.combinePath(sectionModule, sectionSchemaName);
			sandbox.publish("PushHistoryState", {hash: hash});
		},

		/**
		 * ######### ######## # #######.
		 * @param {Object} config ############ ######## ### ######## ########.
		 * @param {String} config.entityId ############# ########.
		 * @param {String} config.entitySchemaName ### ##### ########.
		 * #### ########### ##### ########## ## ############# ##### ########.
		 * @param {String} config.entitySchemaUId ############# ##### ########.
		 * ##### ############# #### ###### ### ##### ########.
		 * @param {Object} config.sandbox ######### ###### ########### ######## ######## ######## ########.
		 * @param {String} config.typeId #### ########### ##### ########## ## ############## ##### ########.
		 */
		openCardInChain: function(config) {
			if (!Ext.isObject(config)) {
				throw Ext.create("Terrasoft.UnsupportedTypeException");
			}
			MaskHelper.showBodyMask();
			this.prepareOpenConfig(config, this.openCard, this);
		},

		/**
		 * Opens card.
		 * @param {Object} config Configuration for opening card.
		 * @param {String} config.entityId Entity identifier.
		 * @param {String} config.entitySchemaName Entity schema name.
		 * Will be defined as entity schema identifier (if not exists).
		 * @param {String} config.entitySchemaUId Entity schema identifier.
		 * Can be empty if entity schema name exists.
		 * @param {Object} config.sandbox Sandbox from module, that opens card.
		 * @param {String} config.typeId Will be defined as entity schema identifier (if not exists).
		 * @param {Terrasoft.ConfigurationEnums.CardOperation} [config.operation =
		 * Terrasoft.ConfigurationEnums.CardOperation.EDIT] Operation, that will pass to card.
		 * @param {Array} config.valuePairs Default values for card fields.
		 */
		openCard: function(config) {
			let entitySchemaConfig = this.getEntityConfigUrl(config);
			let moduleName = config.moduleName || entitySchemaConfig.cardModule;
			let historyState = config.historyState;
			let sandbox = config.sandbox;
			let entitySchemaName = entitySchemaConfig.entitySchemaName;
			const navigationConfig = {
				entitySchemaName: entitySchemaName,
				operation: entitySchemaConfig.operation,
				id: entitySchemaConfig.primaryColumnValue,
				defaultValues: config.valuePairs,
				messageTags: [config.moduleId],
			};
			if (this.tryNavigateTo8xMiniPage(navigationConfig)) {
				return;
			}
			if (this._isInsideMiniPageModal() && this.tryNavigateTo8xPage(navigationConfig)) {
				return;
			}
			let state = {
				isSeparateMode: true,
				schemaName: entitySchemaConfig.cardSchema,
				entitySchemaName: entitySchemaName,
				operation: entitySchemaConfig.operation,
				primaryColumnValue: entitySchemaConfig.primaryColumnValue,
				isInChain: true,
				valuePairs: config.valuePairs
			};
			let typeColumnName = this.getTypeColumn(entitySchemaName);
			if (!Ext.isEmpty(typeColumnName) && config.typeId) {
				state.typeColumnName = typeColumnName.path;
				state.typeUId = config.typeId;
			}
			const containerId = "centerPanel";
			const moduleParams = {
				renderTo: containerId,
				keepAlive: true
			};
			if (config.moduleId) {
				moduleParams.id = config.moduleId;
			}
			if (!moduleParams.id && Terrasoft.isAngularHost &&
				Terrasoft.Features.getIsDisabled("DisableNetworkUtilitiesOpenCardUniqueModuleId")) {
				moduleParams.id = sandbox.id + "_chain_" + Terrasoft.generateGUID("N");
			}
			const hasContainer = document.getElementById(containerId);
			state.moduleName = moduleName;
			if (!hasContainer) {
				state.keepAlive = true;
			}
			const isAngularRouting = Terrasoft.ModuleUtils.getIsAngularRouting(moduleName);
			if (isAngularRouting) {
				moduleName = 'ChainModuleStub';
			}
			sandbox.publish("PushHistoryState", {
				hash: historyState.hash.historyState,
				silent: true,
				stateObj: state
			});
			if (isAngularRouting) {
				MaskHelper.hideBodyMask();
			}
			if (hasContainer) {
				sandbox.loadModule(moduleName, moduleParams);
			}
		},

		/**
		 * Gets the Type column for the current schema.
		 * @deprecated Use {@link ModuleUtils#getTypeColumn} instead.
		 * @protected
		 * @return {Object}
		 */
		getTypeColumn: function(schemaName) {
			return Terrasoft.ModuleUtils.getTypeColumn(schemaName);
		},

		/**
		 * Opens card in new window.
		 * @param {Object} config Configuration for opening card.
		 * @param {String} config.entitySchemaName Entity schema name.
		 * @param {String} config.typeId Will be defined as entity schema identifier (if not exists).
		 * @param {Terrasoft.ConfigurationEnums.CardOperation} [config.operation =
		 * Terrasoft.ConfigurationEnums.CardOperation.EDIT] Operation, that will pass to card.
		 */
		openEntityWindow: function(config) {
			var url = this.getEntityUrl(config);
			window.open("ViewModule.aspx#" + url);
		},

		/**
		 * Opens page in new window.
		 * @param {Object} config Configuration for opening card.
		 * @param {String} config.cardSchemaName Page schema name.
		 * @param {String} config.typeId Will be defined as entity schema identifier (if not exists).
		 * @param {Terrasoft.ConfigurationEnums.CardOperation} [config.operation =
		 * Terrasoft.ConfigurationEnums.CardOperation.EDIT] Operation, that will pass to card.
		 */
		openCardWindow: function(config) {
			var url = this.getPageUrl(
				config.cardSchemaName,
				config.operation,
				config.primaryColumnValue
			);
			window.open("ViewModule.aspx#" + url);
		},

		/**
		 * Open section page in new interface.
		 * @param {String} config.entitySchemaName Page schema name.
		 */
		openSectionInNewUI: function(config) {
			const entitySchemaName = config.entitySchemaName;
			if (!entitySchemaName) {
				throw Ext.create("Terrasoft.ArgumentNullOrEmptyException", {
					message: "Arguments: entitySchemaName was not set."
				});
			}
			const url = Terrasoft.workspaceBaseUrl + "/ClientApp/#/" + entitySchemaName;
			window.open(url, "_blank");
		},

		/**
		 * @private
		 */
		_getEntityName: function(config) {
			return config.cardEntitySchemaName || config.entitySchemaName;
		},

		/**
		 * @private
		 */
		_getEntityNavigationConfig: function(config) {
			const defaultValues = config.defaultValues?.map((x) => ({attributeName: x.name, value: x.value}));
			const recordId = Terrasoft.isArray(config.id) ? config.id[0] : config.id;
			return {
				options: {
					action: config.operation,
					entityName: this._getEntityName(config),
					recordId: recordId,
					defaultValues: defaultValues,
					messageTags: config.messageTags,
					type: "entity",
				},
			};
		},

		/**
		 * @private
		 */
		_get8xMiniPage: function(config) {
			if (!this._canNavigateTo8x()) {
				return null;
			}
			const defaultValues = config?.defaultValues?.map(x => {
				return {
					attributeName: x.name,
					value: x.value
				}
			});
			const options = {
				action: config.operation,
				defaultValues: defaultValues,
				entityName: this._getEntityName(config),
				entityPageName: config?.schemaName,
				cardSchemaName: config?.cardSchemaName,
			};
			const entityStructure = Terrasoft.ModuleUtils.getEntityStructureByName(options.entityName);
			if (!entityStructure?.pages?.length) {
				return null;
			}
			const pages = entityStructure.pages;
			let page = creatioUtils.NavigationUtils.getPageForAction(options);
			page ??= pages[0];
			return page.schemaGroup === "MiniPage" ? page : null;
		},

		/**
		 * @private
		 */
		_canNavigateTo8x: function() {
			if (!Terrasoft.isAngularHost) {
				return false;
			}
			if (!window.shellNavigation) {
				console.warn("shellNavigation is not defined");
				return false;
			}
			return true;
		},

		/**
		 * @private
		 */
		_isInsideMiniPageModal: function() {
			return /\[modal=/.test(window.location.hash || "");
		},

		/**
		 * @private
		 */
		_get8xPage: function(config) {
			if (!this._canNavigateTo8x()) {
				return null;
			}
			const defaultValues = config?.defaultValues?.map(x => {
				return {
					attributeName: x.name,
					value: x.value
				}
			});
			const options = {
				action: config.operation,
				defaultValues: defaultValues,
				entityName: this._getEntityName(config),
				entityPageName: config?.schemaName,
				cardSchemaName: config?.cardSchemaName,
			};
			const entityStructure = Terrasoft.ModuleUtils.getEntityStructureByName(options.entityName);
			if (!entityStructure?.pages?.length) {
				return null;
			}
			const pages = entityStructure.pages;
			let page = creatioUtils.NavigationUtils.getPageForAction(options);
			page ??= pages[0];
			return page;
		},

		/**
		 * Navigate to any 8x Freedom UI page registered for the entity through the shell router.
		 * @param {Object} config Navigation config.
		 * @return {Boolean} True if navigation was successful.
		 */
		tryNavigateTo8xPage: function(config) {
			if (!this._canNavigateTo8x()) {
				return false;
			}
			const page = this._get8xPage(config);
			if (!page) {
				return false;
			}
			const navigateConfig = this._getEntityNavigationConfig(config);
			window.shellNavigation.navigate(navigateConfig).then();
			return true;
		},

		/**
		 * Navigate to 8x modal.
		 * @param {Object} config Navigation config.
		 * @param {String} [config.miniPageSchemaName] Fallback mini page schema name when entity has no registered pages.
		 * @param {String} [config.operation] Operation (edit, add, view).
		 * @param {String} [config.id] Record identifier.
		 * @param {String} [config.entitySchemaName] Entity schema name.
		 * @return {Boolean} True if navigation was successful.
		 */
		tryNavigateTo8xMiniPage: function(config) {
			if (config && config.excludeMiniPage) {
				return false;
			}
			if (!this._canNavigateTo8x()) {
				return false;
			}
			const miniPage = this._get8xMiniPage(config);
			if (miniPage) {
				const navigateConfig = this._getEntityNavigationConfig(config);
				window.shellNavigation.navigate(navigateConfig).then();
				return true;
			}
			if (config?.miniPageSchemaName) {
				const navigateConfig = {
					options: {
						type: "schema",
						schemaName: config.miniPageSchemaName,
						modelInitConfigs: [{
							recordId: config.id,
							action: config.operation
						}]
					}
				};
				window.shellNavigation.navigate(navigateConfig).then();
				return true;
			}
			return false;
		},

		tryGet8xMiniPageUrl: function(config) {
			// TODO: https://creatio.atlassian.net/browse/RND-37519
			let url = null;
			const miniPage = this._get8xMiniPage(config);
			if (miniPage) {
				const { options } = this._getEntityNavigationConfig(config);
				url = `${window.location.hash}[modal=${miniPage.cardSchema}/${options.action}/${options.recordId}]`;
			}
			return url;
		},

		/**
		 * Return true when url1 equal url2.
		 * @public
		 * @param {string} url1 Url.
		 * @param {string} url2 Url.
		 * @returns {Boolean}
		 */
		compareUrls: function(url1, url2) {
			return Terrasoft.Features.getIsEnabled("EnableCompareUrlWithSlash")
				? url1 === url2
				: Ext.isString(url1) && Ext.isString(url2) && url1.replace(/\/$/, "") === url2.replace(/\/$/, "");
		}
	});

	return Ext.create("Terrasoft.NetworkUtilities");
});
