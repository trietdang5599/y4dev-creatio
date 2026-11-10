define("MobileDesignerSchemaManager", ["MobileSha3", "MobileDesignerUtils"],
	function(Sha3, MobileDesignerUtils) {

		Ext.define("Terrasoft.MobileDesignerSchemaManager", {

			statics: {

				CUSTOM_PACKAGE_UID: "a00051f4-cde3-4f3f-b08e-c5ad1a5c735a",

				/**
				 * @private
				 */
				schemaNamePrefix: null,

				/**
				 * @private
				 */
				workplaceCode: null,

				/**
				 * @protected
				 */
				packageUId: null,

				/**
				 * @private
				 */
				schemaCache: null,

				/**
				 * @private
				 */
				cultureNames: [],

				/**
				 * @private
				 */
				packageTopologicalOrderCache: null,

				/**
				 * @private
				 */
				getCultureNames: function(callback, scope) {
					var select = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "SysCulture"
					});
					select.addColumn("Name");
					select.getEntityCollection(function(response) {
						if (response && response.success) {
							var itemsCollection = response.collection;
							itemsCollection.each(function(item) {
								var name = item.get("Name");
								this.cultureNames.push(name);
							}, this);
							if (this.cultureNames.length === 0) {
								this.cultureNames = ["en-US"];
							}
						}
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @private
				 */
				getCultureValues: function(value) {
					var cultureNames = this.cultureNames;
					var result = {};
					for (var i = 0, ln = cultureNames.length; i < ln; i++) {
						result[cultureNames[i]] = value;
					}
					return result;
				},

				/**
				 * @private
				 */
				getSchemaName: function(name) {
					return "Mobile" + name + this.workplaceCode;
				},

				/**
				 * @private
				 */
				getSchemaNameWithPrefix: function(name) {
					return this.schemaNamePrefix + name;
				},

				/**
				 * @private
				 */
				getManifestSchemaName: function() {
					return this.getSchemaName("ApplicationManifest");
				},

				/**
				 * @private
				 */
				getBaseManifestSchemaName: function() {
					return "MobileApplicationBaseManifest";
				},

				/**
				 * @private
				 */
				useMobileDesignerShortSchemaNames: function(schemaName) {
					return Terrasoft.Features.getIsEnabled("UseMobileDesignerShortSchemaNames") && schemaName.length >= 70;
				},

				/**
				 * @private
				 */
				getSchemaNameHash: function(schemaName) {
					return shake128 ? shake128(schemaName, 64) : schemaName;
				},

				/**
				 * @private
				 */
				getSettingsShortSchemaName: function(modelName, settingsType) {
					var schemaName = this.getSettingsSchemaName(modelName, settingsType);
					return "M_" + this.getSchemaNameHash(schemaName) + settingsType + "Settings" + this.workplaceCode;
				},

				/**
				 * Initialize.
				 * @param {Object} config Configuration object.
				 * @param {String} config.packageUId UId of package.
				 * @param {String} config.workplaceCode Code of work place.
				 * @param {Function} config.callback Callback function.
				 * @param {Object} config.scope Scope for callback function.
				 */
				initialize: function(config) {
					this.packageUId = config.packageUId;
					this.workplaceCode = config.workplaceCode;
					this.schemaCache = {};
					this.getCultureNames(function() {
						Terrasoft.ClientUnitSchemaManager.initialize(function() {
							var schemaNamePrefixSettingName = "SchemaNamePrefix";
							Terrasoft.SysSettings.querySysSettings(schemaNamePrefixSettingName, function(sysSettingObject) {
								this.schemaNamePrefix = sysSettingObject[schemaNamePrefixSettingName];
								Ext.callback(config.callback, config.scope);
							}, this);
						}, this);
					}, this);
				},

				/**
				 * Adds localizable string to schema.
				 * @param {Object} schemaInstance Schema instance.
				 * @param {String} name Name of localizable string.
				 * @param {String} value Value of localizable string.
				 */
				addLocalizableString: function(schemaInstance, name, value) {
					var localizableStringItem = schemaInstance.localizableStrings.find(name);
					if (localizableStringItem) {
						localizableStringItem.setValue(value);
					} else {
						var localizableString = Ext.create("Terrasoft.LocalizableString", {
							cultureValues: this.getCultureValues(value)
						});
						schemaInstance.localizableStrings.add(name, localizableString);
					}
				},

				/**
				 * Returns localizable strings.
				 * @param {Object} schemaInstance Schema instance.
				 * @return {Object} Localizable strings.
				 */
				getSchemaLocalizableStrings: function(schemaInstance) {
					var result = {};
					var itemsCollection = schemaInstance.localizableStrings.collection;
					itemsCollection.eachKey(function(key, item) {
						result[key] = item.getValue();
					});
					return result;
				},

				/**
				 * Returns body of schema.
				 * @param {Object} schemaInstance Schema instance.
				 * @return {Object} Body of schema.
				 */
				getManifestBody: function(schemaInstance) {
					var manifest = Ext.JSON.decode(schemaInstance.body, true);
					return manifest || {};
				},

				/**
				 * Checks, whether schema is new.
				 * @param {Object} schemaInstance Schema instance.
				 * @return {Boolean} True, if schema is new.
				 */
				isNewSchemaInstance: function(schemaInstance) {
					if (!schemaInstance) {
						return false;
					}
					var managerItem = Terrasoft.ClientUnitSchemaManager.getItem(schemaInstance.uId);
					return managerItem.getStatus() === Terrasoft.ModificationStatus.NEW;
				},

				/**
				 * Returns name of settings schema.
				 * @param {String} modelName Name of model.
				 * @param {String} settingsType Type.
				 * @return {String} Schema name.
				 */
				getSettingsSchemaName: function(modelName, settingsType) {
					let name = modelName;
					if (settingsType) {
						var screens = Terrasoft.MobileDesignerUtils.manifest.getScreens(modelName);
						if (screens) {
							if (settingsType === Terrasoft.MobileDesignerEnums.SettingsType.RecordPage && screens.edit) {
								return screens.edit.schemaName;
							} else if (settingsType === Terrasoft.MobileDesignerEnums.SettingsType.GridPage && screens.start) {
								return screens.start.schemaName;
							}
						}
						name += settingsType + "Settings";
					}
					return this.getSchemaName(name);
				}

			},

			/**
			 * Indicates that manifest is new.
			 */
			manifestSchemaIsNew: null,

			//region Methods: Private

			/**
			 * @private
			 */
			addDependenciesToPackage: function(items) {
				const customPackageUId = this.self.CUSTOM_PACKAGE_UID;
				const promises = items
					.filter(item => item.getPackageUId() === customPackageUId)
					.map(item => this.processSchemaItem(item));
				return Promise.all(promises);
			},

			/**
			 * @private
			 */
			processSchemaItem: function(item) {
				return new Promise((resolve, reject) => {
					Terrasoft.MobileDesignerUtils.addDependenciesToPackage({
						clientUnitSchemaNames: [item.getName()],
						packageUId: item.getPackageUId(),
						success: resolve,
						failure: reject,
						scope: this
					});
				});
			},

			/**
			 * @private
			 */
			prepareModifiedItems: function() {
				return new Promise((resolve) => {
					const modifiedItems = Terrasoft.ClientUnitSchemaManager.getModifiedItems();
					const modifiedFilledItems = [];
					const promises = modifiedItems.map(item => {
						if (item.isNew()) {
							return new Promise((itemResolve) => {
								item.getInstance((instance) => {
									if (Ext.isEmpty(instance.body)) {
										Terrasoft.ClientUnitSchemaManager.remove(item.getUId());
									} else {
										modifiedFilledItems.push(item);
									}
									itemResolve();
								});
							});
						}
						modifiedFilledItems.push(item);
						return Promise.resolve();
					});
					Promise.all(promises).then(() => {
						resolve(modifiedFilledItems);
					});
				});
			},
			
			/**
			 * @private
			 */
			createSchema: function(config) {
				const schemaName = config.name;
				const packageUId = this.self.packageUId;
				const caption = config.caption || schemaName;
				const uId = Terrasoft.generateGUID();
				const schema = Terrasoft.ClientUnitSchemaManager.createSchema({
					uId: uId,
					realUId: uId,
					name: schemaName,
					packageUId: packageUId,
					parentSchemaUId: config.parentSchemaUId,
					extendParent: config.extendParent,
					caption: this.self.getCultureValues(caption)
				});
				Terrasoft.ClientUnitSchemaManager.addSchema(schema);
				return schema;
			},

			/**
			 * @private
			 */
			findClientUnitSchemaInstance: function(config) {
				var schemaName = config.schemaName;
				var shortSchemaName = config.shortSchemaName;
				var packageUId = config.searchInAllPackages ? null : this.self.packageUId;
				var allSchemas = Terrasoft.ClientUnitSchemaManager.getItems();
				var parentSchema;
				var schemas = allSchemas.filterByFn(function(item) {
					var isNeededSchema = Ext.String.endsWith(item.name, schemaName);
					if (!isNeededSchema && shortSchemaName !== null) {
						isNeededSchema = Ext.String.endsWith(item.name, shortSchemaName);
					}
					var itemPackageUId = item.packageUId;
					if (isNeededSchema && !item.extendParent && itemPackageUId !== packageUId) {
						parentSchema = item;
					}
					if (packageUId) {
						return isNeededSchema && itemPackageUId === packageUId;
					} else {
						return isNeededSchema;
					}
				});
				var schema = schemas.getByIndex(0);
				if (schema) {
					schema.getInstance(function(schemaInstance) {
						Ext.callback(config.callback, this, [schemaInstance, parentSchema]);
					}, this);
				} else {
					Ext.callback(config.callback, this, [null, parentSchema]);
				}
			},

			/**
			 * @private
			 */
			getSchemaFromCache: function(schemaName) {
				return this.self.schemaCache[schemaName];
			},

			/**
			 * @private
			 */
			addSchemaToCache: function(schemaName, schemaInstance) {
				if (!this.getSchemaFromCache(schemaName)) {
					this.self.schemaCache[schemaName] = schemaInstance;
				}
			},

			/**
			 * @private
			 */
			callback: function() {
				var config = this.currentAsyncConfig;
				Ext.callback(config.callback, config.scope, arguments);
			},

			/**
			 * Reads schema.
			 * @obsolete
			 * @private
			 * @param {Object} config Config object.
			 * @param {String} config.schemaName Name of schema.
			 * @param {Boolean} config.createIfNotExist If true, creates a schema if it does not exist.
			 * @param {Boolean} config.cacheSchemaInstance If true, caches a schema.
			 * @param {Boolean} config.searchInAllPackages If true, searches for the schema in all packages.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			readSchema: function(config) {
				Ext.applyIf(config, {
					createIfNotExist: true,
					cacheSchemaInstance: true,
					searchInAllPackages: false
				});
				var schemaName = config.schemaName;
				var shortSchemaName = config.shortSchemaName;
				this.findClientUnitSchemaInstance({
					schemaName: schemaName,
					shortSchemaName: config.shortSchemaName,
					searchInAllPackages: config.searchInAllPackages,
					callback: function(schemaInstance, parentSchema) {
						if (!schemaInstance) {
							var caption;
							if (!Ext.isEmpty(shortSchemaName)) {
								caption = schemaName;
								schemaName = shortSchemaName;
							}
							var extendParent = Boolean(parentSchema);
							var realSchemaName = extendParent
								? parentSchema.name
								: this.self.getSchemaNameWithPrefix(schemaName);
							if (config.createIfNotExist) {
								var parentSchemaUId = extendParent ? parentSchema.uId : null;
								schemaInstance = this.createSchema({
									name: realSchemaName,
									caption: caption,
									parentSchemaUId: parentSchemaUId,
									extendParent: extendParent
								});
							}
						}
						if (config.cacheSchemaInstance) {
							this.addSchemaToCache(schemaName, schemaInstance);
						}
						Ext.callback(config.callback, config.scope, [schemaInstance]);
					}
				});
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc
			 */
			constructor: function(config) {
				this.initConfig(config);
				this.manifestSchemaIsNew = null;
			},

			/**
			 * Deletes schema.
			 * @param {Object} config Config object.
			 * @param {String} config.schemaName Name of schema.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			removeSchema: function(config) {
				this.findClientUnitSchemaInstance({
					schemaName: config.schemaName,
					searchInAllPackages: false,
					callback: function(schemaInstance) {
						if (this.self.isNewSchemaInstance(schemaInstance)) {
							Terrasoft.ClientUnitSchemaManager.remove(schemaInstance.uId);
						}
						Ext.callback(config.callback, config.scope);
					}
				});
			},

			/**
			 * Reads settings schema.
			 * @param {Object} config Config object.
			 * @param {String} config.entitySchemaName Name of schema.
			 * @param {String} config.settingsType Type of settings.
			 * @param {Boolean} config.createIfNotExist If true, creates a schema if it does not exist.
			 * @param {Boolean} config.cacheSchemaInstance If true, caches a schema.
			 * @param {Boolean} config.searchInAllPackages If true, searches for the schema in all packages.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			readSettingsSchema: function(config) {
				var entitySchemaName = config.entitySchemaName;
				var settingsType = config.settingsType;
				var schemaName = this.self.getSettingsSchemaName(entitySchemaName, settingsType);
				var shortSchemaName = null;
				if (this.self.useMobileDesignerShortSchemaNames(schemaName)) {
					shortSchemaName = this.self.getSettingsShortSchemaName(entitySchemaName, settingsType);
				}
				if (!schemaName) {
					Ext.callback(config.callback, config.scope);
					return;
				}
				this.readSchema({
					schemaName: schemaName,
					shortSchemaName: shortSchemaName,
					searchInAllPackages: config.searchInAllPackages,
					createIfNotExist: config.createIfNotExist,
					cacheSchemaInstance: config.cacheSchemaInstance,
					callback: config.callback,
					scope: config.scope
				});
			},

			/**
			 * Reads manifest schema.
			 * @param {Object} config Config object.
			 * @param {Boolean} config.createIfNotExist If true, creates a schema if it does not exist.
			 * @param {Boolean} config.cacheSchemaInstance If true, caches a schema.
			 * @param {Boolean} config.searchInAllPackages If true, searches for the schema in all packages.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			readManifestSchema: function(config) {
				var schemaName = this.self.getManifestSchemaName();
				this.readSchema({
					schemaName: schemaName,
					searchInAllPackages: config.searchInAllPackages,
					createIfNotExist: config.createIfNotExist,
					cacheSchemaInstance: config.cacheSchemaInstance,
					callback: function(schemaInstance) {
						const isNewSchemaInstance = this.self.isNewSchemaInstance(schemaInstance);
						if (isNewSchemaInstance && !schemaInstance.parentSchemaUId) {
							this.manifestSchemaIsNew = true;
							schemaInstance.body = "{}";
							Ext.callback(config.callback, config.scope, [schemaInstance]);
						} else {
							this.manifestSchemaIsNew = false;
							Ext.callback(config.callback, config.scope, [schemaInstance]);
						}
					},
					scope: this
				});
			},

			/**
			 * Reads base manifest schemas instances.
			 * @param {Object} config Config object.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			readBaseManifestSchemaInstances: function(config) {
				this.readSchemaInstances({
					schemaName: this.self.getBaseManifestSchemaName(),
					callback: config.callback,
					scope: config.scope
				});
			},

			/**
			 * Reads manifests schema instances.
			 * @param {Object} config Config object.
			 * @param {String} config.schemaName Name of schema.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for callback function.
			 */
			readSchemaInstances: function(config) {
				const schemaName = config.schemaName;
				const items = Terrasoft.ClientUnitSchemaManager.getItems();
				const schemas = items.filterByFn(function(item) {
					return item.name === schemaName;
				});
				Terrasoft.ClientUnitSchemaManager.getInstances(schemas.collection.items, config.callback, config.scope);
			},

			/**
			 * Save schemas.
			 * @param {Object} config Config object.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Scope for the callback function.
			 */
			saveSchemas: function(config) {
				this.prepareModifiedItems()
					.then(modifiedItems => {
						return new Promise((resolve, reject) => {
							Terrasoft.ClientUnitSchemaManager.save((managerSaveResponse) => {
								if (managerSaveResponse && !managerSaveResponse.success && managerSaveResponse.errorInfo) {
									reject(managerSaveResponse.errorInfo.message);
									return;
								}
								resolve(modifiedItems);
							});
						});
					})
					.then((modifiedItems) => {
						return new Promise((resolve) => {
							Terrasoft.SchemaDesignerUtilities.refreshClientUnitSchemaItems(() => {
								resolve(modifiedItems);
							}, this);
						});
					})
					.then((modifiedItems) => {
						return this.addDependenciesToPackage(modifiedItems);
					})
					.then(() => {
						Ext.callback(config.callback, config.scope);
					})
					.catch(errorText => {
						Ext.callback(config.callback, config.scope, [errorText]);
					});
			},

			/**
			 * Writes new values in manifest.
			 * @param {Object} schemaBody Body of schema.
			 * @param {Object} localizableStrings Localizable strings.
			 */
			updateCurrentPackageManifest: function(schemaBody, localizableStrings) {
				var schemaInstance = this.getManifestSchemaInstance();
				for (var localizableStringName in localizableStrings) {
					if (localizableStrings.hasOwnProperty(localizableStringName)) {
						var localizableStringValue = localizableStrings[localizableStringName];
						this.self.addLocalizableString(schemaInstance, localizableStringName, localizableStringValue);
					}
				}
				schemaInstance.setPropertyValue("body", schemaBody);
			},

			/**
			 * Returns instance of settings schema.
			 * @param {String} modelName Name of model.
			 * @param {String} settingsType Type.
			 * @return {Object} Instance of schema.
			 */
			getSettingsSchemaInstance: function(modelName, settingsType) {
				var schemaName = this.self.getSettingsSchemaName(modelName, settingsType);
				var schema = this.getSchemaFromCache(schemaName);
				if (!schema && this.self.useMobileDesignerShortSchemaNames(schemaName)) {
					schemaName = this.self.getSettingsShortSchemaName(modelName, settingsType);
					schema = this.getSchemaFromCache(schemaName);
				}
				return schema;
			},

			/**
			 * Returns instance of manifest schema.
			 * @return {Object} Instance of schema.
			 */
			getManifestSchemaInstance: function() {
				const schemaName = this.self.getManifestSchemaName();
				return this.getSchemaFromCache(schemaName);
			},

			/**
			 * Returns package hierarchy. If hierarchy is contained in cache, returns from cache.
			 * @param {Object} config Configuration object.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function context.
			 */
			getPackageTopologicalOrder: function(config) {
				if (this.packageTopologicalOrderCache) {
					Ext.callback(config.callback, config.scope, [this.packageTopologicalOrderCache]);
					return;
				}
				const request = Ext.create("Terrasoft.BuildPackageHierarchyRequest");
				request.execute(function(response) {
					if (response && response.success) {
						this.packageTopologicalOrderCache = response.packageTopologicalOrder;
						Ext.callback(config.callback, config.scope, [this.packageTopologicalOrderCache]);
					} else {
						throw new Terrasoft.InvalidOperationException({
							message: response.errorInfo.toString()
						});
					}
				}, this);
			}

			//endregion

		});

		return Terrasoft.MobileDesignerSchemaManager;
	}
);
