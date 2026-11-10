Terrasoft.configuration.Structures["EntitySchemaDesignerUtilities"] = {innerHierarchyStack: ["EntitySchemaDesignerUtilities"]};
define("EntitySchemaDesignerUtilities", [
	"terrasoft", "ServiceHelper", "SectionDesignerEnums", "DesignTimeEnums"],
	function(Terrasoft, ServiceHelper, SectionDesignerEnums) {
		Ext.define("Terrasoft.configuration.EntitySchemaDesignerUtilities", {
			extend: "Terrasoft.BaseObject",
			alternateClassName: "Terrasoft.EntitySchemaDesignerUtilities",
	
			//region Methods: Private
	
			/**
			 * @private
			 */
			_createSelectItem: function(schemaItem, entityFileInfo) {
				return {
					value: schemaItem.getUId(),
					displayValue: schemaItem.getCaption(),
					name: schemaItem.getName(),
					entitySchemaUId: entityFileInfo.entitySchemaUId,
					entitySchemaName: entityFileInfo.entitySchemaName
				};
			},
	
			/**
			 * @private
			 */
			_getEntitySchemaColumnSelect: function(config) {
				const id = config.uId;
				const caption = config.caption.getValue();
				return {
					id: id,
					value: id,
					name: config.name,
					caption: caption,
					displayValue: caption,
					selected: false
				};
			},
	
			/**
			 * Indicates that lookup columns are compatible by their types.
			 * @private
			 * @param {Object} sourceDataValueTypeInfo Source data value type info.
			 * @param {String} sourceDataValueTypeInfo.dataValueType Target data value type.
			 * @param {String} sourceDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
			 * is needed for a lookup data value type.
			 * @param {Object} targetDataValueTypeInfo Target data value type info.
			 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
			 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
			 * is needed for a lookup data value type.
			 * @return {Boolean} True, if value from source column can be set to the target column. Otherwise, false.
			 */
			_getAreCompatibleLookupColumnTypes: function(sourceDataValueTypeInfo, targetDataValueTypeInfo) {
				const sourceType = sourceDataValueTypeInfo.dataValueType;
				const targetType = targetDataValueTypeInfo.dataValueType;
				if ((sourceType === Terrasoft.DataValueType.GUID) && (targetType === Terrasoft.DataValueType.GUID)) {
					return true;
				}
				if (Terrasoft.isLookupDataValueType(sourceType) && (targetType === Terrasoft.DataValueType.GUID)) {
					return true;
				}
				if (Terrasoft.isLookupDataValueType(targetType) && (sourceType === Terrasoft.DataValueType.GUID)) {
					return true;
				}
				if (Terrasoft.isLookupDataValueType(sourceType) && Terrasoft.isLookupDataValueType(targetType)) {
					return sourceDataValueTypeInfo.referenceSchemaUId === targetDataValueTypeInfo.referenceSchemaUId;
				}
				return false;
			},
	
			/**
			 * Indicates that schema columns are compatible by their types.
			 * @private
			 * @param {Object} sourceDataValueTypeInfo Source data value type info.
			 * @param {String} sourceDataValueTypeInfo.dataValueType Target data value type.
			 * @param {String} sourceDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
			 * is needed for a lookup data value type.
			 * @param {Object} targetDataValueTypeInfo Target data value type info.
			 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
			 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
			 * is needed for a lookup data value type.
			 * @return {Boolean} True, if value from source column can be set to the target column. Otherwise, false.
			 */
			_getAreCompatibleColumnTypes: function(sourceDataValueTypeInfo, targetDataValueTypeInfo) {
				const sourceType = sourceDataValueTypeInfo.dataValueType;
				const targetType = targetDataValueTypeInfo.dataValueType;
				if (Terrasoft.utils.dataValueType.isTextDataValueType(sourceType) &&
						Terrasoft.utils.dataValueType.isTextDataValueType(targetType)) {
					return true;
				}
				if (Terrasoft.utils.dataValueType.isDateDataValueType(sourceType) &&
						Terrasoft.utils.dataValueType.isDateDataValueType(targetType)) {
					return true;
				}
				if (Terrasoft.utils.dataValueType.isNumberDataValueType(sourceType) &&
						Terrasoft.utils.dataValueType.isNumberDataValueType(targetType)) {
					return true;
				}
				if (sourceType === Terrasoft.DataValueType.INTEGER &&
						Terrasoft.utils.dataValueType.isNumberDataValueType(targetType)) {
					return true;
				}
				if (Terrasoft.isLookupDataValueType(sourceType) || (sourceType === Terrasoft.DataValueType.GUID)) {
					return this._getAreCompatibleLookupColumnTypes(sourceDataValueTypeInfo, targetDataValueTypeInfo);
				}
				if (sourceType === targetType) {
					return true;
				}
			},
	
			//endregion
	
			//region Methods: Public
	
			statics: {
	
				/**
				 * Creates an utilities class.
				 * @returns {Terrasoft.EntitySchemaDesignerUtilities} Initialized instance of the 
				 * EntitySchemaDesignerUtilities class.
				 */
				create: function() {
					return Ext.create("Terrasoft.configuration.EntitySchemaDesignerUtilities");
				},
	
				/**
				 * Returns file entities collection.
				 * @param {Guid} packageUId Package unique identifier.
				 * @param {Array} entitySchemaUIdList Optional array of entity schema unique identifiers to filter entities by.
				 * @param {Function} callback Callback.
				 * @param {Object} scope Scope object.
				 */
				getFileEntities: function(packageUId, entitySchemaUIdList, callback, scope) {
					const utils = Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(packageUId);
					utils.getFileEntities(entitySchemaUIdList, callback, scope);
				},
	
				/**
				 * Returns a connected column for the provided entity schema.
				 * @param {Object} config Config object.
				 * @param {String} config.entitySchemaUId Unique identifier of the entity schema.
				 * @param {String} config.packageUId Unique identifier of the package.
				 * @param {String} config.connectedSchemaUId Connected entity schema unique identifier.
				 * @param {String} config.connectedSchemaName Connected entity schema name.
				 * @param {Function} callback Callback.
				 * @param {Object} scope Scope object.
				 * @deprecated Use instance method instead.
				 */
				findConnectedColumn: function(config, callback, scope) {
					const utils = Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(config.packageUId);
					utils.findConnectedColumn(config, callback, scope);
				},
	
				/**
				 * Returns sorting columns select items.
				 * @param {Guid} packageUId Package unique identifier.
				 * @param {Guid} entitySchemaUId Entity schema unique identifier.
				 * @param {Function} callback Callback.
				 * @param {Object} scope Scope object.
				 * @deprecated Use instance method instead.
				 */
				getSortingColumnsSelectItems: function(packageUId, entitySchemaUId, callback, scope) {
					const utils = Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(packageUId);
					utils.getSortingColumnsSelectItems(entitySchemaUId, callback, scope);
				},
	
				/**
				 * Returns the collection of columns, that fit the target column by their types.
				 * @param {Object} targetDataValueTypeInfo Target data value type info.
				 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
				 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
				 * is needed for a lookup data value type.
				 * @param {Terrasoft.Collection} sourceSchemaColumns The collection of source column.
				 * @return {Terrasoft.Collection} Objects with id and caption of columns, that fit target column by their
				 * types.
				 * @deprecated Use instance method instead.
				 */
				filterSourceSchemaColumns: function(sourceSchemaColumns, targetDataValueTypeInfo) {
					const utils = Terrasoft.EntitySchemaDesignerUtilities.create();
					return utils.filterSourceSchemaColumns(sourceSchemaColumns, targetDataValueTypeInfo);
				},
	
				/**
				 * Returns an entity schema UId by it's name.
				 * @param {String} schemaName Schema name to get UId of.
				 * @return {Guid} Schema unique identifier.
				 * @deprecated Use instance method instead.
				 */
				getEntitySchemaUIdByName: function(schemaName) {
					const utils = Terrasoft.EntitySchemaDesignerUtilities.create();
					return utils.getEntitySchemaUIdByName(schemaName);
				}
	
			},
	
			/**
			 * Finds an entity schema instance.
			 * @param {Object} config Configuration object.
			 * @param {String} config.schemaUId Schema UId.
			 * @param {Boolean} [config.useCache=true] Using cache.
			 * @param {Function} callback The callback function.
			 * @param {Object|null} callback.schema Schema instance.
			 * @param {Object} scope The scope for the callback.
			 */
			findEntitySchemaInstance: function(config, callback, scope) {
				Terrasoft.EntitySchemaManager.findAggregatedSchemaInstance(config, callback, scope);
			},
	
			/**
			 * Finds entity schema item by it's unique identifier.
			 * @param {String} entitySchemaUId Entity schema unique identifier.
			 * @param {Function} callback The callback function.
			 * @param {Terrasoft.EntitySchemaManagerItem} callback.schemaItem Entity schema manager item.
			 * @param {Object} scope The scope for the callback.
			 */
			findEntitySchemaItem: function(entitySchemaUId, callback, scope) {
				Terrasoft.EntitySchemaManager.findItemByUId(entitySchemaUId, callback, scope);
			},
	
			/**
			 * Finds entity schema items.
			 * @param {Function} callback The callback function.
			 * @param {Terrasoft.Collection} callback.collection Collection of items.
			 * @param {Object} scope The scope for the callback.
			 */
			findEntitySchemaItems: function(callback, scope) {
				Terrasoft.EntitySchemaManager.findSortedByTopologyItems({
					includeExtensionItems: false,
					callback: callback,
					scope: scope
				});
			},
	
			/**
			 * Finds entity schema items including extension items.
			 * @param {Function} callback The callback function.
			 * @param {Terrasoft.Collection} callback.collection Collection of items.
			 * @param {Object} scope The scope for the callback.
			 */
			findAllEntitySchemaItems: function(callback, scope) {
				Terrasoft.EntitySchemaManager.findSortedByTopologyItems({
					includeExtensionItems: true,
					callback: callback,
					scope: scope
				});
			},
	
			/**
			 * @private
			 */
			_getFileEntityNamesByModuleStructure: function() {
				const fileEntityNames = Ext.create("Terrasoft.Collection");
				Terrasoft.each(Terrasoft.configuration.ModuleStructure, function(item) {
					if (item.entitySchemaUId && item.entitySchemaName) {
						const fileEntitySchemaName = item.entitySchemaName === "Lead" ?
							"FileLead"
							: Ext.String.format("{0}File", item.entitySchemaName);
						if (fileEntityNames.find(fileEntitySchemaName)) {
							return;
						}
						fileEntityNames.add(fileEntitySchemaName, {
							entitySchemaUId: item.entitySchemaUId.toLowerCase().replace(/[{}]/g, ""),
							entitySchemaName: item.entitySchemaName
						});
					}
				}, this);
				return fileEntityNames;
			},
	
			/**
			 * @private
			 */
			_getFileEntitiesByModuleStructure: function(entitySchemaUIdList, callback, scope) {
				const fileEntityNames = this._getFileEntityNamesByModuleStructure();
				this.findEntitySchemaItems((entities) => {
					entities.sort("caption", Terrasoft.OrderDirection.ASC);
					const filteredEntities = entities
						.filter((item) => !item.getIsVirtual())
						.filter((item) => fileEntityNames.contains(item.getName()))
						.filter((item) => !entitySchemaUIdList || entitySchemaUIdList &&
							Terrasoft.contains(entitySchemaUIdList, item.getUId()));
					const resultEntities = {};
					filteredEntities.each(function(entity) {
						const entitySchemaUId = entity.getUId();
						const schemaSchemaName = entity.getName();
						const entityFileInfo = fileEntityNames.get(schemaSchemaName);
						resultEntities[entitySchemaUId] = this._createSelectItem(entity, entityFileInfo);
					}, this);
					Ext.callback(callback, scope, [resultEntities]);
				}, this);
			},

			/**
			 * @private
			 */
			_filterAvailableEntities: function(schemaItems, callback, scope) {
				const config = {
					useFullHierarchy: true
				};
				this.getAvailableEntitySchemas(config, function(result) {
					if (!result.success) {
						Ext.callback(callback, scope, [schemaItems]);
						return;
					}
					const filteredItems = schemaItems?.filterByFn((item) => result.items.filter((entity) => {
						return entity.uId === item.uId;
					}).length > 0);
					Ext.callback(callback, scope, [filteredItems]);
				}, this);
			},

			/**
			 * @private
			 */
			_filterFileItems: function(entitySchemaItems, entitySchemaUIdList) {
				const fileSchemaUId = SectionDesignerEnums.BaseSchemeUIds.BASE_FILE;
				return entitySchemaItems
					.filter((item) => {
						const hierarchy = item.getHierarchyUIds();
						return item.uId !== fileSchemaUId &&
							Terrasoft.contains(hierarchy, fileSchemaUId) &&
							Terrasoft.isEmpty(Terrasoft.find(hierarchy, this.getIsSysFileSchema, this));
					})
					.filter((item) => !entitySchemaUIdList || (entitySchemaUIdList &&
						Terrasoft.contains(entitySchemaUIdList, item.getUId())));
			},

			/**
			 * @private
			 */
			_isNotExtendBaseObjects: function(parentUId) {
				const baseObjectsList = [
					SectionDesignerEnums.BaseSchemeUIds.BASE_ENTITY_IN_TAG,
					SectionDesignerEnums.BaseSchemeUIds.BASE_FOLDER,
					SectionDesignerEnums.BaseSchemeUIds.BASE_ITEM_IN_FOLDER,
					SectionDesignerEnums.BaseSchemeUIds.BASE_TAG
				];
				return !Terrasoft.contains(baseObjectsList, parentUId);
			},

			/**
			 * @private
			 */
			_addFileEntities: function(selectItemsList, fileEntities) {
				fileEntities.eachKey((uId, fileEntity) => {
					selectItemsList.add(uId, {
						value: uId,
						displayValue: fileEntity.relatedEntity?.uId
							? `${fileEntity.relatedEntity?.caption} (${fileEntity.caption})`
							: fileEntity.caption,
						name: fileEntity.name,
						entitySchemaUId: fileEntity.relatedEntity?.uId ?? uId,
						entitySchemaName: fileEntity.relatedEntity?.name ?? fileEntity.name,
						entitySchemaCaption: fileEntity.relatedEntity?.caption ?? fileEntity.caption,
						fileEntitySchemaUId: uId,
						isFileSuccessor: true
					});
				});
			},

			/**
			 * @private
			 */
			_addNonFileEntities: function(selectItemsList, entitySchemaItems, entitySchemaUIdList) {
				const sysFileItem = entitySchemaItems.findByFn((item) => this.getIsSysFileSchema(item.getUId()), this);
				if (!Boolean(sysFileItem)) {
					return;
				}
				entitySchemaItems
					.filter((item) => !selectItemsList.contains(item.getUId()) &&
						!Boolean(selectItemsList.findByPath('entitySchemaUId', item.getUId())) &&
						item.uId !== SectionDesignerEnums.BaseSchemeUIds.BASE_FILE)
					.filter((item) => !entitySchemaUIdList || (entitySchemaUIdList &&
						Terrasoft.contains(entitySchemaUIdList, item.getUId())))
					.each((item) => {
						const uId = item.getUId();
						selectItemsList.add(uId, {
							value: uId,
							displayValue: `${item.caption}`,
							name: item.name,
							entitySchemaUId: item.uId,
							entitySchemaName: item.name,
							entitySchemaCaption: item.caption,
							fileEntitySchemaUId: sysFileItem.getUId(),
							isFileSuccessor: false
						});
					});
			},

			/**
			 * @private
			 */
			_createSortedFileEntitiesObject: function(fileEntities) {
				const resultFileEntitiesObject = {};
				fileEntities.sort("entitySchemaCaption", Terrasoft.OrderDirection.ASC);
				fileEntities.each((item) => Ext.apply(resultFileEntitiesObject, { [item.value]: item }));
				return resultFileEntitiesObject;
			},

			/**
			 * @private
			 */
			_filterByExtendBaseObjects: function(schemaItems, callback, scope) {
				const filteredSchemaItems = schemaItems.filter((item) => {
					return this._isNotExtendBaseObjects(item.parentUId);
				});
				Ext.callback(callback, scope, [filteredSchemaItems]);
			},

			/**
			 * @private
			 */
			_getFileEntities: function(entitySchemaUIdList, callback, scope) {
				let entitySchemaItems;
				Terrasoft.chain(
					(next) => this.findEntitySchemaItems(next, this),
					(next, schemaItems) => this._filterAvailableEntities(schemaItems, next, this),
					(next, schemaItems) => this._filterByExtendBaseObjects(schemaItems, next, this),
					(next, entitySchemaItemsResult) => {
						entitySchemaItems = entitySchemaItemsResult;
						const fileItems = this._filterFileItems(entitySchemaItems, entitySchemaUIdList);
						Ext.callback(next, this, [fileItems]);
					},
					(next, fileItems) => {
						const fileEntities = Ext.create("Terrasoft.Collection");
						fileItems.each((item) => {
							const relatedEntityName = item.name !== "FileLead"
								? item.name.replace(new RegExp('File$'), '')
								: "Lead";
							const relatedEntityItem = entitySchemaItems.findByPath('name', relatedEntityName);
							if (relatedEntityItem) {
								fileEntities.add(item.uId, {
									relatedEntity: {
										uId: relatedEntityItem.uId.toLowerCase().replace(/[{}]/g, ""),
										name: relatedEntityItem.name,
										caption:relatedEntityItem.caption
									},
									name: item.name,
									caption: item.caption
								});
							} else {
								fileEntities.add(item.uId, {
									name: item.name,
									caption: item.caption
								});
							}
						});
						Ext.callback(next, this, [fileEntities]);
					},
					(_, fileEntities) => {
						const resultEntities = Ext.create("Terrasoft.Collection");
						this._addFileEntities(resultEntities, fileEntities);
						this._addNonFileEntities(resultEntities, entitySchemaItems, entitySchemaUIdList);
						const resultEntitiesObject = this._createSortedFileEntitiesObject(resultEntities);
						Ext.callback(callback, scope, [resultEntitiesObject]);
					},
					this
				);
			},
	
			/**
			 * Modifies the config for the getAvailableEntitySchemas method.
			 * @protected
			 * @param {Object} config Config object.
			 * @param {String} config.useFullHierarchy Determines whether to use fill hierarchy or not.
			 * @param {String} config.allowDbView Determines whether to include db views or not.
			 * @param {String} config.allowVirtual Determines whether to include virtual schemas or not.
			 * @param {String} config.useExtensions Determines whether to include extension items or not.
			 * @param {String} config.isAdvancedObjectDisplayModeEnabled Determines whether to enable advanced object
			 * display mode or not.
			 * @return {Object} Modified config.
			 */
			processAvailableEntitySchemasConfig: function(config) {
				return {
					useFullHierarchy: config.useFullHierarchy,
					AllowDbView: config.allowDbView,
					AllowVirtual: config.allowVirtual,
					useExtensions: config.useExtensions,
					isAdvancedObjectDisplayModeEnabled: config.isAdvancedObjectDisplayModeEnabled
				};
			},
			
			/**
			 * Returns all available entity schemas collection.
			 * @param {Object} config Config object.
			 * @param {String} config.useFullHierarchy Determines whether to use fill hierarchy or not.
			 * @param {String} config.allowDbView Determines whether to include db views or not.
			 * @param {String} config.allowVirtual Determines whether to include virtual schemas or not.
			 * @param {String} config.useExtensions Determines whether to include extension items or not.
			 * @param {String} config.isAdvancedObjectDisplayModeEnabled Determines whether to enable advanced object
			 * display mode or not.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope object.
			 */
			getAvailableEntitySchemas: function(config, callback, scope) {
				const processedConfig = this.processAvailableEntitySchemasConfig(config);
				ServiceHelper.callCoreService({
					serviceName: "SchemaDataDesignerService",
					methodName: "GetAvailableEntitySchemas",
					data: processedConfig
				}, callback, scope);
			},
			
			/**
			 * Returns file entities collection.
			 * @param {Array} entitySchemaUIdList Optional array of entity schema unique identifiers to filter entities by.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope object.
			 */
			getFileEntities: function(entitySchemaUIdList, callback, scope) {
				if (Terrasoft.Features.getIsEnabled("ProcessFeatures.UseSysFileInObjectFileProcessing")) {
					this._getFileEntities(entitySchemaUIdList, callback, scope);
				} else {
					this._getFileEntitiesByModuleStructure(entitySchemaUIdList, callback, scope);
				}
			},
	
			/**
			 * Returns a connected column for the provided entity schema.
			 * @param {Object} config Config object.
			 * @param {String} config.entitySchemaUId Unique identifier of the entity schema.
			 * @param {String} config.connectedSchemaUId Connected entity schema unique identifier.
			 * @param {String} config.connectedSchemaName Connected entity schema name.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope object.
			 */
			findConnectedColumn: function(config, callback, scope) {
				const managerConfig = {
					schemaUId: config.entitySchemaUId
				};
				this.findEntitySchemaInstance(managerConfig, function(schema) {
					if (schema) {
						const referenceColumn = schema.columns.findByFn(function(column) {
							return column.referenceSchemaUId === config.connectedSchemaUId &&
								column.name === config.connectedSchemaName;
						}, this);
						let result;
						if (referenceColumn) {
							result = {
								referenceSchemaUId: referenceColumn.referenceSchemaUId,
								uId: referenceColumn.uId,
								caption: referenceColumn.caption.toString()
							};
						}
						Ext.callback(callback, scope, [result]);
						return;
					}
					Ext.callback(callback, scope);
				}, this);
			},
	
			/**
			 * Returns sorting columns select items.
			 * @param {Guid} entitySchemaUId Entity schema unique identifier.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope object.
			 */
			getSortingColumnsSelectItems: function(entitySchemaUId, callback, scope) {
				const config = {
					schemaUId: entitySchemaUId
				};
				const entitySchemaColumns = Ext.create("Terrasoft.Collection");
				this.findEntitySchemaInstance(config, function(schema) {
					if (schema) {
						schema.columns.each(function(column) {
							const entitySchemaColumn = this._getEntitySchemaColumnSelect(column);
							entitySchemaColumns.add(entitySchemaColumn.id, entitySchemaColumn);
						}, this);
						entitySchemaColumns.sort("caption");
						Ext.callback(callback, scope, [entitySchemaColumns]);
					}
				}, this);
			},
	
			/**
			 * Returns the collection of columns, that fit the target column by their types.
			 * @param {Object} targetDataValueTypeInfo Target data value type info.
			 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
			 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
			 * is needed for a lookup data value type.
			 * @param {Terrasoft.Collection} sourceSchemaColumns The collection of source column.
			 * @return {Terrasoft.Collection} Objects with id and caption of columns, that fit target column by their
			 * types.
			 */
			filterSourceSchemaColumns: function(sourceSchemaColumns, targetDataValueTypeInfo) {
				const filteredColumns = Ext.create("Terrasoft.Collection");
				if (sourceSchemaColumns && !sourceSchemaColumns.isEmpty()) {
					sourceSchemaColumns.each(function(sourceSchemaColumn) {
						const dataValueType = sourceSchemaColumn.getPropertyValue("dataValueType");
						const referenceSchemaUId = sourceSchemaColumn.getPropertyValue("referenceSchemaUId");
						const sourceDataValueTypeInfo = {
							dataValueType: dataValueType,
							referenceSchemaUId: referenceSchemaUId
						};
						if (!this._getAreCompatibleColumnTypes(sourceDataValueTypeInfo, targetDataValueTypeInfo)) {
							return;
						}
						const id = sourceSchemaColumn.uId;
						filteredColumns.add(id, {
							id: sourceSchemaColumn.uId,
							caption: sourceSchemaColumn.caption.getValue()
						});
					}, this);
				}
				return filteredColumns;
			},
	
			/**
			 * Returns an entity schema UId by it's name.
			 * @param {String} schemaName Schema name to get UId of.
			 * @return {Guid} Schema unique identifier.
			 */
			getEntitySchemaUIdByName: function(schemaName) {
				const item = Terrasoft.EntitySchemaManager.findItemByName(schemaName);
				return item?.uId;
			},

			/**
			 * Determines whether the schema is SYS_FILE or not.
			 * @param {String} schemaUId Schema unique identifier to check.
			 * @return {Boolean} Whether the schema is SysFile or not.
			 */
			getIsSysFileSchema: function(schemaUId) {
				return schemaUId === SectionDesignerEnums.BaseSchemeUIds.SYS_FILE;
			},
	
			//endregion
	
		});
	
		return Terrasoft.EntitySchemaDesignerUtilities;
	});


