Terrasoft.configuration.Structures["DcmUtilities"] = {innerHierarchyStack: ["DcmUtilities"]};
define("DcmUtilities", ["RightUtilities", "SectionManager", "DcmSchemaManager", "SysDcmSettingsManager",
	"FilterUtilities", "EntitySchemaDesignerUtilities", "DcmConstants",
	"PackageAwareEntitySchemaDesignerUtilities"], function(rightUtilities) {
	Ext.define("Terrasoft.configuration.DcmUtilities", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.DcmUtilities",
		singleton: true,

		//region Methods: Private

		findSectionManagerItems: function(viewModel) {
			if (Terrasoft.Features.getIsEnabled("UsePrimaryModuleStructureForDcm")) {
				const moduleStructure = viewModel.getModuleStructure();
				if (!moduleStructure) {
					return [];
				}
				return [moduleStructure, Terrasoft.SectionManager.findItem(moduleStructure.moduleId)];
			}
			const sectionCode = viewModel.getSectionCode();
			const moduleStructures =
				Object.values(Terrasoft.configuration.ModuleStructure).filter(x => x.entitySchemaName === sectionCode);
			return moduleStructures
				.map(moduleStructure => [moduleStructure, Terrasoft.SectionManager.findItem(moduleStructure.moduleId)]);
		},

		findSysDcmSettingsItemBySectionManagerItem: function(moduleStructure, sectionManagerItem) {
			if (!sectionManagerItem) {
				const useDcmForGeneralObject = Terrasoft.Features.getIsEnabled("UseDcmForGeneralObject");
				if (useDcmForGeneralObject) {
					const entitySchemaUId = moduleStructure.entitySchemaUId;
					return Terrasoft.SysDcmSettingsManager.findBySysModuleEntityId(entitySchemaUId);
				} else {
					return null;
				}
			}
			const sysModuleEntityId = sectionManagerItem.getSysModuleEntityId();
			return Terrasoft.SysDcmSettingsManager.findBySysModuleEntityId(sysModuleEntityId);
		},

		/**
		 * Returns SysDcmSettings manager item.
		 * @private
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Terrasoft.manager.SysDcmSettingsManagerItem/null}
		 */
		findSysDcmSettingsItem: function(viewModel) {
			const sectionManagerItems = this.findSectionManagerItems(viewModel);
			for (const [moduleStructure, sectionManagerItem] of sectionManagerItems) {
				const sysDcmSettingsItem =
					this.findSysDcmSettingsItemBySectionManagerItem(moduleStructure, sectionManagerItem);
				if (sysDcmSettingsItem) {
					return sysDcmSettingsItem;
				}
			}
			return null;
		},

		/**
		 * Returns entity schema query for running dcm processes.
		 * @private
		 * @param {String} recordId Current record identifier.
		 * @param {String} entitySchemaUId Entity schema identifier.
		 * @return {Terrasoft.EntitySchemaQuery}
		 */
		getRunningProcessesEsq: function(recordId, entitySchemaUId) {
			const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "SysEntityCommonPrcEl",
				rowCount: 1
			});
			esq.addColumn("ProcessElement.SysProcess.SysSchema.UId", "UId");
			esq.addColumn("ProcessElement.SysProcess.SysSchema.Name", "Name");
			esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
				"RecordId", recordId, Terrasoft.DataValueType.GUID));
			esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
				"EntitySchemaUId", entitySchemaUId, Terrasoft.DataValueType.GUID));
			esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
				"ProcessElement.SysProcess.SysSchema.ManagerName", "DcmSchemaManager"));
			return esq;
		},

		/**
		 * Returns running dcm process instances identifiers for current record.
		 * @private
		 * @param {String} recordId Current record identifier.
		 * @param {String} entitySchemaUId Entity schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Terrasoft.DcmSchemaManagerItem} callback.item Dcm schema manager item.
		 * @param {Object} scope The scope of callback function.
		 */
		_getRunningProcesses: function(recordId, entitySchemaUId, callback, scope) {
			if (!Terrasoft.Features.getIsEnabled('UseDcmServerEndPoint')) {
				const esq = this.getRunningProcessesEsq(recordId, entitySchemaUId);
				esq.getEntityCollection(function(result) {
					let managerItem = null;
					result.collection.each(function(record) {
						const uId = record.get('UId');
						const item = Terrasoft.DcmSchemaManager.findItem(uId);
						const itemEntitySchemaUId = item.getEntitySchemaUId();
						if (entitySchemaUId === itemEntitySchemaUId) {
							managerItem = item;
							return false;
						}
					}, this);
					callback.call(scope, managerItem);
				}, this);
			} else {
				const request = new Terrasoft.ParametrizedRequest({
					contractName: 'DcmRunningProcessRequest',
					config: {
						recordId: recordId,
						entitySchemaUId: entitySchemaUId
					}
				});
				request.execute(function(result) {
					let managerItem = null;
					if (result.rowsAffected === 1) {
						const uId = result.UId;
						const item = Terrasoft.DcmSchemaManager.findItem(uId);
						const itemEntitySchemaUId = item.getEntitySchemaUId();
						if (entitySchemaUId === itemEntitySchemaUId) {
							managerItem = item;
						}
					}
					callback.call(scope, managerItem);
				}, scope);
			}
		},

		/**
		 * Returns running dcm schema manager item for existing entity record.
		 * @private
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {Terrasoft.manager.DcmSchemaManagerItem} callback.item Actual DcmSchemaManager item.
		 * @param {Object} scope The scope of callback function.
		 */
		findRunningDcmSchemaManagerItem: function(viewModel, callback, scope) {
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			const recordId = viewModel.get("Id");
			if (sysDcmSettingsItem && recordId) {
				const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
				this._getRunningProcesses(recordId, entitySchemaUId, callback, scope);
			} else {
				callback.call(scope, null);
			}
		},

		/**
		 * Returns collection of active dcm schema manager items for section.
		 * @private
		 * @param {string} sectionEntitySchemaUId Section entity schema uId.
		 * @return {Terrasoft.Collection}
		 */
		getSectionDcmSchemaManagerItems: function(sectionEntitySchemaUId) {
			return Terrasoft.DcmSchemaManager.filterByFn(function(dcmSchemaManagerItem) {
				const isSchemaActive = dcmSchemaManagerItem.getIsActive();
				const dcmEntitySchemaUId = dcmSchemaManagerItem.getEntitySchemaUId();
				return isSchemaActive && dcmEntitySchemaUId === sectionEntitySchemaUId;
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match dcm schema filters.
		 * @private
		 * @param {Terrasoft.manager.DcmSchemaManagerItem} dcmSchemaManagerItem Dcm schema manager item.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		getIsViewModelMatchDcmSchemaFilters: function(dcmSchemaManagerItem, viewModel) {
			const dcmSchemaFiltersGroup = dcmSchemaManagerItem.getFilterGroup();
			if (!dcmSchemaFiltersGroup || dcmSchemaFiltersGroup.isEmpty()) {
				return true;
			}
			const dcmSchemaFilters = dcmSchemaFiltersGroup.getItems();
			return _.every(dcmSchemaFilters, function(filterItem) {
				return this.checkFilter(filterItem, viewModel);
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match filter item.
		 * @private
		 * @param {Terrasoft.data.filters.BaseFilter} filterItem Filter item.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkFilter: function(filterItem, viewModel) {
			if (filterItem.isEnabled !== true) {
				return false;
			}
			switch (filterItem.filterType) {
				case Terrasoft.FilterType.IN:
					return this.checkInFilter(filterItem, viewModel);
				case Terrasoft.FilterType.IS_NULL:
					return this.checkIsNullFilter(filterItem, viewModel);
				default:
					return false;
			}
		},

		/**
		 * Returns view model column by filter left expression column path.
		 * @private
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Terrasoft.data.filters.BaseFilter} filterItem Filter item.
		 * @return {Object}
		 */
		getViewModelColumnByFilterItem: function(viewModel, filterItem) {
			const columnPath = filterItem.leftExpression.columnPath;
			return  this.getViewModelColumnByPath(viewModel, columnPath);
		},

		/**
		 * Returns view model column by column path.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {string} columnPath Column path.
		 * @return {Object}
		 */
		getViewModelColumnByPath: function(viewModel, columnPath) {
			let foundColumn = null;
			Terrasoft.each(viewModel.columns, function(column) {
				if (column.columnPath === columnPath) {
					foundColumn = column;
				}
				return foundColumn == null;
			});
			return foundColumn;
		},

		/**
		 * Returns flag that indicates whether the viewModel match InFilter.
		 * @private
		 * @param {Terrasoft.data.filters.InFilter} filterItem Filter item.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkInFilter: function(filterItem, viewModel) {
			const column = this.getViewModelColumnByFilterItem(viewModel, filterItem);
			if (!column) {
				return false;
			}
			const columnDataValueType = column.dataValueType;
			const columnValue = viewModel.get(column.name);
			const viewModelColumnValue = this.getPrimitiveValue(columnDataValueType, columnValue);
			return Terrasoft.some(filterItem.rightExpressions, function (rightExpression) {
				const filterParameter = rightExpression.parameter;
				if (filterParameter.dataValueType !== columnDataValueType) {
					return false;
				}
				return this.compareFilterParameterValue(viewModelColumnValue, filterParameter);
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match IsNullFilter.
		 * @private
		 * @param {Terrasoft.data.filters.IsNullFilter} filterItem Filter item.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkIsNullFilter: function(filterItem, viewModel) {
			const column = this.getViewModelColumnByFilterItem(viewModel, filterItem);
			if (!column) {
				return false;
			}
			const columnValue = viewModel.get(column.name);
			const viewModelColumnValue = this.getPrimitiveValue(column.dataValueType, columnValue);
			return viewModelColumnValue == null;
		},

		/**
		 * Compare filter parameter value with passed value.
		 * @private
		 * @param {Object} value Value to compare with filter.
		 * @param {Terrasoft.data.filters.Parameter} filterParameter Filter parameter.
		 * @return {Boolean}
		 */
		compareFilterParameterValue: function(value, filterParameter) {
			const filterValue = filterParameter.getValue();
			const filterParameterValue = this.getPrimitiveValue(filterParameter.dataValueType, filterValue);
			return filterParameterValue === value;
		},

		/**
		 * Returns primitive value by data value type.
		 * @private
		 * @param {Terrasoft.core.enums.DataValueType} dataValueType Data value type.
		 * @param {Object} value Value.
		 * @return {Object|null}
		 */
		getPrimitiveValue: function(dataValueType, value) {
			if (!value) {
				return null;
			}
			const isLookup = Terrasoft.isLookupDataValueType(dataValueType);
			return isLookup ? value.value : value;
		},

		/**
		 * Initialize managers.
		 * @private
		 * @param {Function} callback callback function.
		 */
		initializeManagers: function(callback) {
			const managers = [
				Terrasoft.SectionManager,
				Terrasoft.SysModuleEntityManager,
				Terrasoft.DcmSchemaManager,
				Terrasoft.SysDcmSettingsManager
			];
			Terrasoft.eachAsyncAll(managers, function(manager, next) {
				manager.initialize(next, this);
			}, callback, this);
		},

		/**
		 * Returns flag that indicates if section has any enabled dcm schema.
		 * @private
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 */
		getHasAnyDcmSchema: function(viewModel) {
			let result = false;
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			if (sysDcmSettingsItem) {
				const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
				result = !this.getSectionDcmSchemaManagerItems(entitySchemaUId).isEmpty();
			}
			return result;
		},

		//endregion

		//region Methods: Public

		/**
		 * Check rights for operation CanManageDcm.
		 * @param {Function} callback Callback method.
		 * @param {Boolean} callback.canManageDcm Flag that indicates whether the user has
		 * appropriate rights to manage dcm.
		 * @param {Object} scope Callback method context.
		 */
		checkCanManageDcmRights: function(callback, scope) {
			rightUtilities.checkCanExecuteOperation({"operation": "CanManageDcm"}, callback, scope);
		},

		/**
		 * Returns actual dcm schema uId for section or page view model.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 * @param {Function} callback Callback function.
		 * @param {string} callback.dcmSchemaUId Actual dcm schema uId.
		 * @param {Boolean} callback.hasAnyDcmSchema Flag that indicates if section has any enabled dcm schema.
		 * @param {Object} scope Callback function call context.
		 */
		getActualDcmSchemaUId: function(viewModel, callback, scope) {
			Terrasoft.chain(
				this.initializeManagers,
				function() {
					const dcmSchemaManagerItem = this.findActualDcmSchemaManagerItem(viewModel);
					const dcmSchemaUId = dcmSchemaManagerItem ? dcmSchemaManagerItem.getUId() : null;
					if (dcmSchemaUId) {
						callback.call(scope, dcmSchemaUId, true);
					} else {
						callback.call(scope, dcmSchemaUId, this.getHasAnyDcmSchema(viewModel));
					}
				},
				this
			);
		},

		/**
		 * Returns an array of column names by which SysDcmSettings filters were built.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 * @param {Function} callback Callback function.
		 * @param {string[]} callback.dcmSchemaUId Array of column names.
		 * @param {Object} scope Callback function call context.
		 */
		getFilteredColumns: function(viewModel, callback, scope) {
			const entitySchema = viewModel.entitySchema;
			if (!entitySchema) {
				callback.call(scope, []);
				return;
			}
			Terrasoft.chain(
				this.initializeManagers,
				function() {
					const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
					const filteredColumns = [];
					if (sysDcmSettingsItem) {
						const filters = sysDcmSettingsItem.getFilters();
						filters.forEach(function(filter) {
							const entitySchemaColumn = entitySchema.findColumnByUId(filter.columnUId);
							if (!entitySchemaColumn) {
								return;
							}
							const viewModelColumn = this.getViewModelColumnByPath(viewModel, entitySchemaColumn.name);
							filteredColumns.push(viewModelColumn.name);
						}, this);
					}
					callback.call(scope, filteredColumns);
				}, this);
		},

		/**
		 * @deprecated
		 */
		getIsDcmDesignerAvailable: function(viewModel, callback, scope) {
			if (!viewModel.entitySchema) {
				callback.call(scope, false);
				return;
			}
			this.checkCanManageDcmRights(callback, scope);
		},

		/**
		 * Returns running dcm schema identifier for existing entity record.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {Terrasoft.manager.DcmSchemaManagerItem} callback.schemaUId Running dcm schema identifier.
		 * @param {Boolean} callback.isActive Flag that indicates dcm schema active state.
		 * @param {Object} scope The scope of callback function.
		 */
		findRunningDcmSchemaUId: function(viewModel, callback, scope) {
			if (viewModel.isNewMode()) {
				callback.call(scope, null);
				return;
			}
			Terrasoft.chain(
				this.initializeManagers,
				function(next) {
					this.findRunningDcmSchemaManagerItem(viewModel, next, this);
				},
				function(next, item) {
					let isActive = false;
					let schemaUId = null;
					if (item) {
						schemaUId = item.getUId();
						isActive = item.getIsActive();
					}
					callback.call(scope, schemaUId, isActive);
				},
				this
			);
		},

		/**
		 * Returns actual dcmSchemaManager item for page view model.
		 * If section has no SysDcmSettings records, returns null.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Terrasoft.manager.DcmSchemaManagerItem/null}
		 */
		findActualDcmSchemaManagerItem: function(viewModel) {
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			if (!sysDcmSettingsItem) {
				return null;
			}
			const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
			const dcmSchemaManagerItems = this.getSectionDcmSchemaManagerItems(entitySchemaUId).getItems();
			const actualManagerItem = _.find(dcmSchemaManagerItems, function(dcmSchemaManagerItem) {
				const isActualVersion = dcmSchemaManagerItem.isActiveVersion;
				return this.getIsViewModelMatchDcmSchemaFilters(dcmSchemaManagerItem, viewModel) && isActualVersion;
			}, this);
			return actualManagerItem;
		},

		/**
		 * Returns whether view model has dcm schema.
		 * @param {Terrasoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {Boolean} callback.result Flag that indicates whether view model has dcm schema or not.
		 * @param {Object} scope The scope of callback function.
		 */
		hasAnyDcmSchema: function(viewModel, callback, scope) {
			const enitySctructure = viewModel.entitySchema && viewModel.getEntityStructure();
			const entitySchemaUId = enitySctructure && enitySctructure.entitySchemaUId;
			if (!entitySchemaUId) {
				return callback.call(scope, false);
			}
			this.checkAnyDcmSchema(entitySchemaUId, callback, scope);
		},

		/**
		 * Checks dcm schema existing for entity schema by UId.
		 * @param {string} entitySchemaUId Entity schema UId.
		 * @param {Function} callback The callback function.
		 * @param {Boolean} callback.result Flag that indicates whether view model has dcm schema or not.
		 * @param {Object} scope The scope of callback function.
		 */
		checkAnyDcmSchema: function(entitySchemaUId, callback, scope) {
			Terrasoft.chain(
				function(next) {
					Terrasoft.DcmSchemaManager.initialize(next, this);
				},
				function() {
					const dcmItem = Terrasoft.DcmSchemaManager.findByFn(function (item) {
						return item.getIsActive() && item.getEntitySchemaUId() === entitySchemaUId;
					}, this);
					const result = !Ext.isEmpty(dcmItem) && !Ext.Object.isEmpty(dcmItem);
					callback.call(scope, result);
				}, this
			);
		},

		/**
		 * @private
		 */
		_updateStageFilterCaptions: function(filters, stageEntitySchema) {
			Terrasoft.each(filters, function(filter) {
				const item = Terrasoft.EntitySchemaManager.findItemByName(filter.referenceSchemaName);
				if (item) {
					const stageColumn = stageEntitySchema.columns.findByFn(function(column) {
						return column.referenceSchemaUId === item.uId;
					}, this);
					filter.leftExpressionCaption = stageColumn && stageColumn.caption.getValue() ||
						filter.leftExpressionCaption;
				}
			}, this);
		},

		/**
		 * Returns stage filters display value.
		 * @param {Terrasoft.data.filters.FilterGroup} filters Stage filters.
		 * @param {Terrasoft.manager.EntitySchema} stageEntitySchema Stage entity schema.
		 */
		getStageFiltersDisplayValue: function(filters, stageEntitySchema) {
			this._updateStageFilterCaptions(filters, stageEntitySchema);
			return Terrasoft.FilterUtilities.getExtendedFilterDisplayValue(filters);
		},

		/**
		 * @private
		 */
		_getEntitySchemaDesignerUtilities: function(callback, scope) {
			const utils = Terrasoft.EntitySchemaDesignerUtilities.create();
			Ext.callback(callback, scope, [utils]);
		},

		/**
		 * @private
		 */
		_getPackageAwareEntitySchemaDesignerUtilities: function(callback, scope) {
			if (Terrasoft.Features.getIsEnabled("UseRegularPackageBehaviorInCustomPackage")) {
				Terrasoft.PackageManager.getCurrentPackageUId(function(currentPackageUId) {
					const utils = Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(currentPackageUId);
					Ext.callback(callback, scope, [utils]);
				}, this);
			} else {
				Terrasoft.PackageManager.getCustomPackageUId(function(customPackageUId) {
					const utils = Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(customPackageUId);
					Ext.callback(callback, scope, [utils]);
				}, this);
			}
		},

		/**
		 * Returns stage column display name.
		 * @param {GUID} stageColumnUId Stage column unique identifier.
		 * @param {GUID} entitySchemaUId Stage entity schema unique identifier.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback scope.
		 */
		getStageColumnDisplayName: function(stageColumnUId, entitySchemaUId, callback, scope) {
			if (!stageColumnUId || !entitySchemaUId) {
				return;
			}
			const utilitiesFactory = Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses")
					? this._getEntitySchemaDesignerUtilities
					: this._getPackageAwareEntitySchemaDesignerUtilities;
			Terrasoft.chain(
				utilitiesFactory,
				function(next, utils) {
					utils.findEntitySchemaInstance({ schemaUId: entitySchemaUId }, next, this);
				},
				function(next, schema) {
					const column = schema && schema.columns.find(stageColumnUId);
					const columnCaption = column && column.caption.getValue();
					const columnName = column && column.name;
					Ext.callback(callback, scope, [columnCaption || columnName || stageColumnUId]);
				}, this
			);
		},

		/**
		 * Returns new stage color.
		 * @param {string} currentColor
		 * @returns Stage color.
		 */
		convertTo8xStageColor: function(currentColor) {
			const newColor = Terrasoft.DcmConstants.StageColorsMap.find(colorMap => colorMap.oldColor === currentColor.toUpperCase())?.newColor;
			return newColor ? newColor : currentColor;
		}

		//endregion

	});
});


