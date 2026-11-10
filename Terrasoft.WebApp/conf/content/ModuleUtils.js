Terrasoft.configuration.Structures["ModuleUtils"] = {innerHierarchyStack: ["ModuleUtils"]};
define("ModuleUtils", ["ConfigurationConstants", "@creatio/utils"], function(ConfigurationConstants, creatioUtils) {

	/**
	 * @class Terrasoft.manager.ModuleUtils
	 * Class of the manager structure for modules and objects.
	 */
	Ext.define("Terrasoft.manager.ModuleUtils", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.ModuleUtils",
		singleton: true,

		entityStructure: Terrasoft.configuration.EntityStructure,

		moduleStructure: Terrasoft.configuration.ModuleStructure,

		/**
		 * Default card module.
		 * @private
		 * @type {String}
		 */
		defaultCardModule: "CardModuleV2",

		/**
		 * Return module tag by structure object.
		 * @param {string} module Module structure object.
		 * @returns {string} Module tag.
		 */
		_getModuleTagByStructure: function(moduleStructure) {
			let tag = "";
			if (!moduleStructure) {
				return tag;
			}
			if (moduleStructure.sectionModule) {
				tag = moduleStructure.sectionModule + "/";
			}
			if (moduleStructure.sectionSchema) {
				tag += moduleStructure.sectionSchema + "/";
			}
			return tag;
		},

		_getModuleStructureByEntity: function(entitySchemaName) {
			const structuresByEntity = Object.values(this.moduleStructure || {})
				.filter(structure => structure?.entitySchemaName === entitySchemaName);
			return structuresByEntity.find(structure => structure.primary) ?? structuresByEntity[0];
		},

		/**
		 * Return module tag.
		 * @param {string} module Module name.
		 * @returns {string} Module tag.
		 */
		getModuleTag: function(module) {
			var tag = "";
			switch (module) {
				case "Process":
					tag = "ProcessExecute/";
					break;
				default:
					var moduleStructure = this.getModuleStructureByName(module);
					tag = this._getModuleTagByStructure(moduleStructure);
					break;
			}
			return tag;
		},

		/**
		 * Returns default card module.
		 * @return {String} Card module name.
		 */
		getDefaultCardModule: function() {
			return this.defaultCardModule;
		},

		/**
		 * Returns entity structure by  name.
		 * @param {String} entitySchemaName Entity schema name.
		 * @return {Object} Entity structure.
		 */
		getEntityStructureByName: function(entitySchemaName) {
			var entityStructure = this.entityStructure || {};
			return entityStructure[entitySchemaName];
		},

		getModuleStructureById: function(moduleId) {
			return Object.values(this.moduleStructure || {})
				.find(structure => structure?.moduleId === moduleId);
		},

		/**
		 * Returns module structure.
		 * @param {String} key Can be either module name, module identifier or name of module entity schema.
		 * @return {Object} Module structure.
		 */
		getModuleStructure: function(key) {
			if (!key) {
				return null;
			}
			const moduleStructure = this.moduleStructure || {};
			let result = this.getModuleStructureById(key);
			result ??= moduleStructure[key];
			result ??= this._getModuleStructureByEntity(key);
			return result;
		},

		/**
		 * Returns module structure.
		 * @param {String} key Can be either module name, module identifier or name of module entity schema.
		 * @return {Object} Module structure.
		 */
		getModuleStructureByName: function(key) {
			return this.getModuleStructure(key);
		},

		/**
		 * Returns name of the entity schema by UId, if it was registered.
		 * @param {String} entitySchemaUId Entity schema UId.
		 * @return {String} Entity schema name.
		 */
		getEntitySchemaNameByUId: function(entitySchemaUId) {
			if (Ext.isEmpty(entitySchemaUId)) {
				return null;
			}
			var filterExpression = { "entitySchemaUId": entitySchemaUId };
			var structure = Terrasoft.where(this.moduleStructure, filterExpression);
			if (Ext.isEmpty(structure)) {
				structure = Terrasoft.where(this.entityStructure, filterExpression);
			}
			if (Ext.isEmpty(structure)) {
				return null;
			}
			return structure[0].entitySchemaName || null;
		},

		/**
		 * Returns entity name from module structure.
		 * @param {String} schemaName Schema name.
		 * @return {String} Entity name.
		 */
		getEntityNameBySchemaName: function(schemaName) {
			var entityName = "";
			if (Ext.isEmpty(schemaName)) {
				return entityName;
			}
			Terrasoft.each(this.moduleStructure, function(item) {
				if (item.cardSchema === schemaName || item.sectionSchema === schemaName) {
					entityName = item.entitySchemaName;
					return false;
				}
				Terrasoft.each(item.pages || [], function(page) {
					if (page.cardSchema === schemaName) {
						entityName = item.entitySchemaName;
						return false;
					}
				});
				if (!Ext.isEmpty(entityName)) {
					return false;
				}
			});
			return entityName;
		},

		/**
		 * Returns module structure by card schema name.
		 * @param {String} cardSchemaName Card schema name.
		 * @return {Object} Module structure object.
		 */
		getModuleStructureBySchemaName: function(cardSchemaName) {
			return cardSchemaName && Object.values(this.moduleStructure).find((item) => (
				item.cardSchema === cardSchemaName || item.pages?.some((page) => page.cardSchema === cardSchemaName)
			));
		},

		/**
		 * Returns entity structure by card schema name and card module name.
		 * @param {String} cardSchemaName Card schema name.
		 * @param {String} cardModuleName Card module name, optional.
		 * @return {Object} Entity structure object.
		 */
		getEntityStructureBySchemaName: function(cardSchemaName, cardModuleName = null) {
			return Object.values(this.entityStructure).find((structure) =>
				structure.pages?.some((page) => page.cardSchema === cardSchemaName) &&
				(!cardModuleName || structure.cardModuleName === cardModuleName),
			);
		},

		/**
		 * Returns module structure by section schema name.
		 * @param {String} sectionSchemaName Section schema name.
		 * @return {Object} Module structure object.
		 */
		getModuleStructureBySectionSchema: function(sectionSchemaName) {
			return Object.values(this.moduleStructure).find((item) => item.sectionSchema === sectionSchemaName);
		},

		/**
		 * Returns available pages.
		 * @param {Object} entityStructure Entity structure.
		 * @param {Terrasoft.ConfigurationEnums.CardOperation} operation By default - edit.
		 * @return {Object}
		 */
		getPages: function(entityStructure, operation = Terrasoft.ConfigurationEnums.CardOperation.EDIT) {
			if (operation === Terrasoft.ConfigurationEnums.CardOperation.ADD) {
				return creatioUtils.NavigationUtils.getPagesForAddAction(entityStructure.pages);
			}
			const defaultPages = entityStructure.pages.filter(x => x.isDefault || !x.actions);
			const typedPages = _.filter(defaultPages, (page) => page.UId);
			if (Ext.isEmpty(typedPages) && defaultPages.length) {
				typedPages.push(defaultPages[0]);
			}
			return typedPages;
		},

		/**
		 * Returns module name for card schema.
		 * @param {Object} config Config.
		 * @param {String} config.entityName Entity name.
		 * @param {String} [config.cardSchema] Card schema name.
		 * @param {Terrasoft.ConfigurationEnums.CardOperation} [config.operation] Operation.
		 * @param {Object} [config.defaultModule] Default module name.
		 * @return {String} Module name.
		 */
		getCardModule: function(config) {
			const { entityName, cardSchema, operation, defaultModule } = config;
			const entityStructure = this.getEntityStructureByName(entityName);
			const entityPages = entityStructure && this.getPages(entityStructure, operation);
			const entityPage = cardSchema && entityPages?.find((p) => p.cardSchema === cardSchema);
			let moduleName = entityPage?.cardModuleName || entityStructure?.cardModuleName;
			const moduleStructure = this.getModuleStructureByName(entityName);
			if (!moduleName && moduleStructure && cardSchema) {
				const modulePage = moduleStructure.pages?.find((p) => p.cardSchema === cardSchema);
				const useModuleStructureCardModule = modulePage || moduleStructure.cardSchema === cardSchema;
				if (useModuleStructureCardModule) {
					moduleName = ConfigurationConstants.ModuleAliases[moduleStructure.cardModule] ||
						moduleStructure.cardModule;
				}
			}
			return moduleName || defaultModule;
		},

		/**
		 * Internal use only. Returns flag that indicates if 8x schema should be rendered.
		 * @param {string} moduleName Module name.
		 * @returns {*|boolean}
		 * @internal
		 */
		getIsAngularRouting: function(moduleName) {
			return Terrasoft.isAngularHost && ['PageSchemaViewModule', 'CardSchemaViewModule', 'Desktop', 'HomePage', 'SectionSchemaViewModule'].includes(moduleName);
		},

		/**
		 * Gets the Type column for the current schema.
		 * @param {string} schemaName Schema to get the type column for.
		 * @returns {{path: *}|null}
		 */
		getTypeColumn: function(schemaName) {
			let entityStructure = this.getEntityStructureByName(schemaName);
			let typeColumnName = (entityStructure && entityStructure.attribute) || null;
			return typeColumnName ? {path: typeColumnName} : null;
		}

	});

	return Terrasoft.ModuleUtils;

});


