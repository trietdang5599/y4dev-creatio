Terrasoft.configuration.Structures["MobileDesignerConfigManager"] = {innerHierarchyStack: ["MobileDesignerConfigManager"]};
define("MobileDesignerConfigManager", ["EntityStructureHelperMixin"],
	function() {

		Ext.define("Terrasoft.configuration.MobileDesignerConfigManager", {
			alternateClassName: "Terrasoft.MobileDesignerConfigManager",

			mixins: {
				EntityStructureHelper: "Terrasoft.EntityStructureHelperMixin"
			},

			config: {

				schemaInstance: null,

				schemaManager: null

			},

			//region Methods: Private

			/**
			 * @private
			 */
			getParentDesignerConfig: function(diffs) {
				let parentConfig = [];
				for (let i = 0, ln = diffs.length; i < ln; i++) {
					parentConfig = Terrasoft.JsonApplier.applyDiff(parentConfig, diffs[i]);
				}
				return parentConfig;
			},

			/**
			 * @private
			 */
			formatMetadata: function(metadata) {
				return JSON.stringify(metadata, null, "\t");
			},

			/**
			 * @private
			 */
			processDesignerConfig: function(config) {
				const items = !Ext.isArray(config) ? [config] : config;
				Terrasoft.each(items, function(item) {
					Terrasoft.each(item, function(itemProperty) {
						if (Ext.isArray(itemProperty)) {
							this.processDesignerConfig(itemProperty);
						}
					}, this);
					item.operation = "insert";
				}, this);
				return config;
			},

			/**
			 * @private
			 */
			addDiffFromSchema: function(diffs, localizableStrings, schema) {
				const schemaLocalizableStrings =
					Terrasoft.MobileDesignerSchemaManager.getSchemaLocalizableStrings(schema);
				Ext.merge(localizableStrings, schemaLocalizableStrings);
				const diff = JSON.parse(this.formatSchema(schema.body));
				if (diff) {
					diffs.push(diff);
				}
			},

			/**
			 * @private
			 */
			getSchemaDiffs: function(config) {
				const schemaInstance = this.getSchemaInstance();
				const schemaUId = schemaInstance.uId;
				const schemaPackageUId = schemaInstance.packageUId;
				const schemaManager = this.getSchemaManager();
				schemaManager.readSchemaInstances({
					schemaName: schemaInstance.name,
					callback: function(schemas) {
						Terrasoft.SchemaDesignerUtilities.getSchemaPackageHierarchy(schemaInstance.name, function(packageHierarchy) {
							const diffs = [];
							let localizableStrings = {};
							let hierarchyContainCurrentSchema = false;
							for (let i = 0; i < packageHierarchy.length; i++) {
								const packageUId = packageHierarchy[i].Value;
								let schema = Ext.Array.findBy(schemas, function(schemaItem) {
									return schemaItem.packageUId === packageUId;
								});
								if (schema && (config.includeCurrentSchema || schema.packageUId !== schemaPackageUId)) {
									if (schema.uId === schemaUId) {
										this.addDiffFromSchema(diffs, localizableStrings, schemaInstance);
										hierarchyContainCurrentSchema = true;
									} else {
										this.addDiffFromSchema(diffs, localizableStrings, schema);
									}
								}
							}
							if (config.includeCurrentSchema && !hierarchyContainCurrentSchema) {
								this.addDiffFromSchema(diffs, localizableStrings, schemaInstance);
							}
							Ext.callback(config.callback, config.scope, [diffs, localizableStrings]);
						}, this);
					},
					scope: this
				});
			},

            /**
			 * @private
			 */
			formatSchema: function(body) {
                if (body) {
                  return body.replaceAll("\\$", "$");
                } else {
                  return body;
                }
			},
          
			//#endregion

			//region Methods: Public

			constructor: function(config) {
				this.initConfig(config);
			},

			/**
			 * ###### ########## ####### ######## ## ###### ####### ########, ###### ## ###### #######.
			 * @param {Object} config ################ ###### # ########### ###### ######:
			 * @param {Object} config.schemaInstance ######### #####.
			 * @param {Function} config.callback ####### ######### ######.
			 * @param {Object} config.scope ######## ####### ######### ######.
			 */
			buildDesignerConfig: function(config) {
				this.getSchemaDiffs({
					includeCurrentSchema: true,
					callback: function(diffs, localizableStrings) {
						let designerConfig = this.getParentDesignerConfig(diffs);
						designerConfig = (designerConfig && designerConfig.length === 0) ? null : designerConfig[0];
						if (localizableStrings && designerConfig !== null) {
							designerConfig.localizableStrings = localizableStrings;
						}
						Ext.callback(config.callback, config.scope, [designerConfig]);
					},
					scope: this
				});
			},

			applyDesignerConfig: function(config) {
				const schemaInstance = this.getSchemaInstance();
				const designerConfig = this.processDesignerConfig(config.designConfig);
				this.getSchemaDiffs({
					callback: function(diffs) {
						const parentConfig = this.getParentDesignerConfig(diffs);
						designerConfig.name = "settings";
						const diff = Terrasoft.JsonDiffer.getJsonDiff(parentConfig, designerConfig);
						const body = this.formatMetadata(diff);
						schemaInstance.setPropertyValue("body", body);
						const localizableStrings = config.designConfig.localizableStrings;
						for (const name in localizableStrings) {
							if (localizableStrings.hasOwnProperty(name)) {
								const value = localizableStrings[name];
								Terrasoft.MobileDesignerSchemaManager.addLocalizableString(schemaInstance, name, value);
							}
						}
						Ext.callback(config.callback, config.scope, [diff]);
					},
					scope: this
				});
			}

			//#endregion

		});

		return Terrasoft.MobileDesignerConfigManager;
	}
);


