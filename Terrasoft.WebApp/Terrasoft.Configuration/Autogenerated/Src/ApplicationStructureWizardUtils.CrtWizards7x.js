define("ApplicationStructureWizardUtils", ["terrasoft", "ApplicationStructureWizardUtilsResources",
	"DesignTimeEnums", "LookupManager", "ConfigurationEnumsV2"
], function(Terrasoft, resources) {

	/**
	 * Class for ApplicationStructureWizardUtils.
	 */
	Ext.define("Terrasoft.configuration.ApplicationStructureWizardUtils", {
		extend: "Terrasoft.core.BaseObject",
		alternateClassName: "Terrasoft.ApplicationStructureWizardUtils",
		singleton: true,

		// region Methods: Private

		/**
		 * @private
		 */
		_getLocalizableStrings: function(callback) {
			const item = Terrasoft.ClientUnitSchemaManager.findByFn((item) => item.name === "ApplicationStructureWizardUtils");
			const config = {schemaUId: item.uId, packageUId: item.packageUId};
			Terrasoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, (instance) => {
				const localizableStrings = instance.localizableStrings.clone();
				callback(localizableStrings);
			}, this);
		},

		// endregion

		/**
		 * Creates Entity schemas for new section.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} [config.sectionEntityUId] New section entity UId.
		 * @param {String} [config.sectionEntityFolderUId] New folder entity UId.
		 * @param {String} [config.sectionEntityTagUId] New tag entity UId.
		 * @param {String} [config.uId] UId.
		 * @param {String} [config.existEntityUId] Exist entity schema UId.
		 * @param {Function} callback The callback function.
		 * @param {String} callback.sectionEntityUId New section entity UId.
		 * @param {Object} scope The scope of callback function.
		 */
		createNewSectionEntitySchemas: function(config, callback, scope) {
			config.sectionEntityFolderUId = Terrasoft.generateGUID();
			config.sectionEntityTagUId = Terrasoft.generateGUID();
			config.uId = null;
			Terrasoft.chain(
				function(next) {
					if (config.existEntityUId) {
						config.sectionEntityUId = config.existEntityUId;
						this.updateSectionEntity(next, config);
					} else {
						config.sectionEntityUId = Terrasoft.generateGUID();
						this.createSectionEntity(next, config);
					}
				},
				this.createSectionFile,
				this.createSectionFolder,
				this.createSectionInFolder,
				this.createSectionTag,
				this.createSectionInTag,
				this.defineSectionEntity,
				function() {
					callback.call(scope, config.sectionEntityUId);
				}, this
			);
		},

		/**
		 * Returns entity name with user prefix.
		 * @param {String} name Section code.
		 * @param {String} [target] Optional, target string.
		 * @return {String} Generated full name.
		 */
		getEntityFullName: function(name, target) {
			const prefix = Terrasoft.EntitySchemaManager.getSchemaNamePrefix() || "";
			target = target || "";
			const nameWithOutPrefix = name.startsWith(prefix) ? name.slice(prefix.length) : name;
			return prefix + nameWithOutPrefix + target;
		},

		/**
		 * Create section entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 * @param {String} config.existEntityUId Exists entity UId.
		 */
		updateSectionEntity: function(callback, config) {
			Terrasoft.chain(
				function(next) {
					Terrasoft.EntitySchemaManager.forceGetPackageSchema({
						packageUId: config.packageUId,
						schemaUId: config.sectionEntityUId
					}, next, this);
				},
				function(next, entitySchema) {
					if (!Terrasoft.EntitySchemaManager.contains(entitySchema.uId)) {
						Terrasoft.EntitySchemaManager.addSchema(entitySchema);
					}
					this.addNotesColumn(entitySchema);
					callback(config);
				}, this
			);
		},

		/**
		 * Create section entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 * @param {String} config.existEntityUId Exists entity UId.
		 */
		createSectionEntity: function(callback, config) {
			const name = this.getEntityFullName(config.name);
			const newSchema = Terrasoft.EntitySchemaManager.createSchema({
				"uId": config.sectionEntityUId,
				"name": name,
				"packageUId": config.packageUId,
				"caption": {}
			});
			newSchema.setLocalizableStringPropertyValue("caption", config.caption);
			Terrasoft.chain(
				this._getLocalizableStrings,
				(next, localizableStrings) => {
					const name = localizableStrings.get("SectionEntityDisplayColumnName");
					this.addNameColumn(newSchema, name);
					const notes = localizableStrings.get("NotesColumnCaption");
					this.addNotesColumn(newSchema, notes);
					newSchema.setParent(Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ENTITY, next);
				},
				() => {
					Terrasoft.EntitySchemaManager.addSchema(newSchema);
					callback(config);
				}, this
			);
		},

		/**
		 * Create name column.
		 * @protected
		 * @param {Terrasoft.EntitySchemaManagerItem} newSchema Target schema.
		 * @param {Terrasoft.LocalizableString} [caption] Caption.
		 */
		addNameColumn: function(newSchema, caption) {
			const nameColumnName = this.getEntityFullName("Name");
			const nameColumnUId = Terrasoft.generateGUID();
			const nameColumn = newSchema.createColumn({
				"name": nameColumnName,
				"uId": nameColumnUId,
				"caption": caption || resources.localizableStrings.SectionEntityDisplayColumnName,
				"isRequired": true,
				"dataValueType": Terrasoft.DataValueType.MEDIUM_TEXT
			});
			newSchema.addColumn(nameColumn);
			newSchema.setPropertyValue("primaryDisplayColumnUId", nameColumnUId);
		},

		/**
		 * Create notes column.
		 * @protected
		 * @param {Terrasoft.EntitySchemaManagerItem} newSchema Target schema.
		 * @param {Terrasoft.LocalizableString} [caption] Caption.
		 */
		addNotesColumn: function(newSchema, caption) {
			const notesColumnName = this.getEntityFullName("Notes");
			let notesColumn = newSchema.columns.getItems().find(function(column) {
				return column.name === notesColumnName;
			});
			if (notesColumn) {
				return;
			}
			notesColumn = newSchema.createColumn({
				"name": notesColumnName,
				"uId": Terrasoft.generateGUID(),
				"caption": caption || resources.localizableStrings.NotesColumnCaption,
				"dataValueType": Terrasoft.DataValueType.MAXSIZE_TEXT
			});
			newSchema.addColumn(notesColumn);
		},

		/**
		 * Create section File entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.schemaCaption Caption for current entity.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 */
		createSectionFile: function(callback, config) {
			config.entityName = this.getEntityFullName(config.name, "File");
			const schemaCaptionTemplate = resources.localizableStrings.SectionEntityFileCaption;
			config.schemaCaption = Ext.String.format(schemaCaptionTemplate, config.caption);
			const newSchema = this.createNewSchema(config);
			this.createNewLookupColumn(config, newSchema);
			const parentUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_FILE;
			newSchema.setParent(parentUId, function() {
				Terrasoft.EntitySchemaManager.addSchema(newSchema);
				callback(config);
			});
		},

		/**
		 * Create section Folder entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityFolderUId Entity folder UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 */
		createSectionFolder: function(callback, config) {
			config.entityName = this.getEntityFullName(config.name, "Folder");
			const schemaCaptionTemplate = resources.localizableStrings.SectionEntityFolderCaption;
			config.schemaCaption = Ext.String.format(schemaCaptionTemplate, config.caption);
			config.uId = config.sectionEntityFolderUId;
			config.administratedByRecords = true;
			const newSchema = this.createNewSchema(config);
			config.uId = null;
			const parentUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_FOLDER;
			newSchema.setParent(parentUId, function() {
				const columns = newSchema.getPropertyValue("columns");
				const filteredColumns = columns.filterByFn(function(item) {
					return item.name === "Parent";
				});
				const column = filteredColumns.getByIndex(0);
				column.referenceSchemaUId = config.sectionEntityFolderUId;
				Terrasoft.EntitySchemaManager.addSchema(newSchema);
				callback(config);
			});
		},

		/**
		 * Create section InFolder entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 * @param {String} config.sectionEntityFolderUId New folder entity UId.
		 */
		createSectionInFolder: function(callback, config) {
			config.entityName = this.getEntityFullName(config.name, "InFolder");
			const schemaCaptionTemplate = resources.localizableStrings.SectionEntityInFolderCaption;
			config.schemaCaption = Ext.String.format(schemaCaptionTemplate, config.caption);
			const newSchema = this.createNewSchema(config);
			this.createNewLookupColumn(config, newSchema);
			const parentUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_FOLDER;
			newSchema.setParent(parentUId, function() {
				const columns = newSchema.getPropertyValue("columns");
				const filteredColumns = columns.filterByFn(function(item) {
					return item.name === "Folder";
				});
				const column = filteredColumns.getByIndex(0);
				if (config.sectionEntityFolderUId) {
					const columnCaption = Ext.String.format(resources.localizableStrings.SectionEntityFolderCaption,
						config.caption);
					column.setPropertyValue("referenceSchemaUId", config.sectionEntityFolderUId);
					column.setPropertyValue("isVirtual", false);
					column.setLocalizableStringPropertyValue("caption", columnCaption);
				}
				Terrasoft.EntitySchemaManager.addSchema(newSchema);
				callback(config);
			});
		},

		/**
		 * Create section Tag entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 */
		createSectionTag: function(callback, config) {
			config.entityName = this.getEntityFullName(config.name, "Tag");
			const schemaCaptionTemplate = resources.localizableStrings.SectionEntityTagCaption;
			config.schemaCaption = Ext.String.format(schemaCaptionTemplate, config.caption);
			config.uId = config.sectionEntityTagUId;
			const newSchema = this.createNewSchema(config);
			config.uId = null;
			const parentUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_TAG;
			newSchema.setParent(parentUId, function() {
				Terrasoft.EntitySchemaManager.addSchema(newSchema);
				callback(config);
			});
		},

		/**
		 * Create section InTag entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.packageUId Current package UId.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 * @param {String} config.sectionEntityTagUId New folder entity UId.
		 */
		createSectionInTag: function(callback, config) {
			config.entityName = this.getEntityFullName(config.name, "InTag");
			const schemaCaptionTemplate = resources.localizableStrings.SectionEntityInTagCaption;
			config.schemaCaption = Ext.String.format(schemaCaptionTemplate, config.caption);
			const newSchema = this.createNewSchema(config);
			const parentUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_TAG;
			newSchema.setParent(parentUId, function() {
				const columns = newSchema.getPropertyValue("columns");
				const tagColumns = columns.filterByPath("name", "Tag");
				const entityColumns = columns.filterByPath("name", "Entity");
				const tagColumn = tagColumns.first();
				const entityColumn = entityColumns.first();
				if (config.sectionEntityTagUId) {
					const tagColumnCaption = Ext.String.format(resources.localizableStrings.SectionEntityTagCaption,
						config.caption);
					tagColumn.setPropertyValue("referenceSchemaUId", config.sectionEntityTagUId);
					tagColumn.setPropertyValue("isVirtual", false);
					tagColumn.setLocalizableStringPropertyValue("caption", tagColumnCaption);
					entityColumn.setPropertyValue("referenceSchemaUId", config.sectionEntityUId);
					entityColumn.setPropertyValue("isVirtual", false);
					entityColumn.setLocalizableStringPropertyValue("caption", config.caption);
				}
				Terrasoft.EntitySchemaManager.addSchema(newSchema);
				callback(config);
			});
		},

		/**
		 * Creates and returns new lookup column.
		 * @param {Object} config Configuration.
		 * @param {String} config.name Code of new section.
		 * @param {String} config.caption Caption of new section.
		 * @param {String} config.sectionEntityUId New section entity UId.
		 * @param {Terrasoft.manager.EntitySchema} schema Entity schema.
		 */
		createNewLookupColumn: function(config, schema) {
			const name = this.getEntityFullName(config.name);
			const newColumn = schema.createColumn({
				"name": name,
				"uId": Terrasoft.generateGUID(),
				"caption": config.caption || {},
				"isRequired": true,
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"referenceSchemaUId": config.sectionEntityUId,
				"isCascade": true
			});
			newColumn.setLocalizableStringPropertyValue("caption", config.caption.toString());
			return schema.addColumn(newColumn);
		},

		/**
		 * Create new entity schema.
		 * @param {Object} config Configuration.
		 * @param {String} config.uId UId.
		 * @param {String} config.entityName Name of new entity.
		 * @param {String} config.schemaCaption Caption for current entity.
		 * @param {String} config.packageUId Current package UId.
		 * @param {Boolean} [config.administratedByRecords] Enable administered by records.
		 */
		createNewSchema: function(config) {
			const uId = config.uId || Terrasoft.generateGUID();
			const newSchema = Terrasoft.EntitySchemaManager.createSchema({
				"uId": uId,
				"name": config.entityName,
				"packageUId": config.packageUId,
				"caption": config.schemaCaption || {},
				"administratedByRecords": Boolean(config.administratedByRecords)
			});
			newSchema.setLocalizableStringPropertyValue("caption", config.schemaCaption.toString());
			return newSchema;
		},

		/**
		 * Create new entity schema with primary display column.
		 * @param {Object} config Configuration.
		 * @param {String} config.schemaName Name of new entity.
		 * @param {String | LocalizableString} config.schemaCaption Caption for current entity.
		 * @param {String} config.packageUId Current package UId.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Scope.
		 */
		createNewSchemaWithPrimaryDisplayColumn: function({schemaName, schemaCaption, packageUId}, callback, scope) {
			const newSchema = this.createNewSchema({
				schemaCaption,
				packageUId,
				entityName: schemaName,
				administratedByRecords: true
			});
			Terrasoft.chain(
				this._getLocalizableStrings,
				(next, localizableStrings) => {
					const nameColumnCaption = localizableStrings.get("SectionEntityDisplayColumnName");
					this.addNameColumn(newSchema, nameColumnCaption);
					newSchema.setParent(Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_ENTITY, next);
				},
				() => {
					Terrasoft.EntitySchemaManager.addSchema(newSchema);
					Ext.callback(callback, scope, [newSchema]);
				}, this
			);
		},

		/**
		 * Return validate schema exist in the EntitySchemaManager.
		 * @param {String} name Schema name.
		 * @return {Object}
		 */
		validateEntitySchemaExist: function(name) {
			const itemCount = this.getEntitySchemaExistCount(name);
			const itemExist = itemCount !== 0;
			const message = itemExist ? resources.localizableStrings.EntitySchemaExistValidateMessage : "";
			return {
				message: message,
				isValid: !itemExist
			};
		},

		/**
		 * Return count of existing schemas.
		 * @private
		 * @param {String} name Schema name.
		 * @return {Number} Count of schemas exist.
		 */
		getEntitySchemaExistCount: function(name) {
			name = this.getEntityFullName(name);
			const items = Terrasoft.EntitySchemaManager.getItems();
			const systemEntitySchemaNames = this.getSectionEntitySchemaAdditionalSchemaNames(name);
			const filteredItems = items.filterByFn(
				function(item) {
					const itemName = item.name;
					return Terrasoft.contains(
						systemEntitySchemaNames,
						itemName
					);
				}
			);
			return filteredItems.getCount();
		},

		/**
		 * Defines section entity schema.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} config Configuration object.
		 * @param {String} config.sectionEntityUId Section entity schema UId.
		 */
		defineSectionEntity: function(callback, config) {
			Terrasoft.EntitySchemaManager.getInstanceByUId(config.sectionEntityUId, function(entitySchema) {
				entitySchema.define();
				callback();
			}, this);
		},

		/**
		 * Updates lookup manager if typeColumn lookup doesn't registered.
		 * @param {Object} entitySchema Instance of Terrasoft.EntitySchema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		createLookupManagerItem: function(entitySchema, callback, scope) {
			Terrasoft.LookupManager.initialize(null, function() {
				const referenceSchemaUId = entitySchema.uId;
				if (Terrasoft.LookupManager.findItemBySysEntitySchemaUId(referenceSchemaUId)) {
					return Ext.callback(callback, scope);
				}
				const config = {
					propertyValues: {
						name: entitySchema.caption.toString(),
						sysEntitySchemaUId: referenceSchemaUId
					}
				};
				if (entitySchema.caption instanceof Terrasoft.LocalizableString) {
					config.propertyLczValues = {
						name: entitySchema.caption
					}
				}
				Terrasoft.LookupManager.createItem(config, function(lookupManagerItem) {
					Terrasoft.LookupManager.addItem(lookupManagerItem);
					Ext.callback(callback, scope);
				}, this);
			}, this);
		},

		/**
		 * Creates array of names of section schemas.
		 * @param {String} name Entity schema name.
		 * @return {Array} Array of section entity schema names.
		 */
		getSectionEntitySchemaAdditionalSchemaNames: function(name) {
			return [
				name,
				name + "Folder",
				name + "File",
				name + "InFolder",
				name + "Tag",
				name + "InTag"
			];
		},

		/**
		 * Creates array of uIds of system schemas.
		 * @param {String} name Entity schema name.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getSectionEntitySchemaAdditionalSchemaUIds: function(name, callback, scope) {
			const schemaUIds = [];
			const currentEntitySchemas = this.getSectionEntitySchemaAdditionalSchemaNames(name);
			Terrasoft.each(currentEntitySchemas, function(itemName) {
				const schema = Terrasoft.EntitySchemaManager.findRootSchemaItemByName(itemName);
				if (schema && schema.uId) {
					schemaUIds.push(schema.uId);
				}
			}, this);
			Ext.callback(callback, scope, [schemaUIds]);
		},

		/**
		 * Creates client unit schema.
		 * @param {Terrasoft.SchemaType} schemaType Schema type
		 * @param {String} parentSchemaUId UId of the parent schema.
		 * @param {Terrasoft.EntitySchema} entitySchema Entity schema.
		 * @param {String} packageUId Package identifier.
		 * @param {Terrasoft.LocalizableString} caption Caption.
		 * @param {String} name Name.
		 * @param {Boolean} extendParent Indicates that schema extend parent.
		 * @param {String} [bodyTemplate] Body template.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		createClientUnitSchema: function({schemaType, parentSchemaUId, entitySchema, packageUId, caption, name, extendParent, bodyTemplate}, callback, scope) {
			bodyTemplate = bodyTemplate || Terrasoft.ClientUnitSchemaBodyTemplate[schemaType];
			const entitySchemaName = entitySchema.getPropertyValue("name");
			Terrasoft.ClientUnitSchemaManager.initialize(function() {
				const schema = Terrasoft.ClientUnitSchemaManager.createSchema({
					uId: Terrasoft.generateGUID(),
					name,
					packageUId,
					caption: caption || {},
					extendParent: Boolean(extendParent),
					body: Ext.String.format(bodyTemplate, name, entitySchemaName),
					schemaType,
					parentSchemaUId
				});
				schema.localizableStrings.add("Caption", caption);
				Terrasoft.ClientUnitSchemaManager.addSchema(schema);
				schema.define(() => callback.call(scope, schema), this);
			}, this);
		}
	});
});
