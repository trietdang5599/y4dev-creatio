Terrasoft.configuration.Structures["EntityColumnMappingMixin"] = {innerHierarchyStack: ["EntityColumnMappingMixin"]};
define("EntityColumnMappingMixin", ["terrasoft", "ModalBox", "EntityColumnMappingMixinResources",
	"EntityColumnMappingViewModel", "ProcessLookupPageMixin"],
	function(Terrasoft, ModalBox, resources) {

		/**
		 * Mixin for the Column-Value block.
		 */
		Ext.define("Terrasoft.configuration.mixins.EntityColumnMappingMixin", {
			alternateClassName: "Terrasoft.EntityColumnMappingMixin",

			//region Properties: Private
			mixins: {
				processLookupPageMixin: "Terrasoft.ProcessLookupPageMixin"
			},
			/**
			 * Attributes. Will be applied to the host class model.
			 * @private
			 */
			entityColumnMappingAttributes: {
				/**
				 * Cached collection of selected entity columns.
				 */
				"EntityColumns": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Cached collection of source entity columns.
				 */
				"SourceSchemaColumns": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Collection viewModel's controls for record column value element.
				 */
				"EntityColumnMappingsControls": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Record column values view element config.
				 */
				"EntityColumnMappingsViewConfig": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
				}
			},

			//endregion

			//region Methods: Private

			/**
			 * Applies attributes to the host class model.
			 * @private
			 */
			applyAttributes: function() {
				const entityColumnMappingAttributes = this.entityColumnMappingAttributes;
				Ext.applyIf(this.columns, entityColumnMappingAttributes);
				for (let attributeName in entityColumnMappingAttributes) {
					if (!entityColumnMappingAttributes.hasOwnProperty(attributeName)) {
						continue;
					}
					if (this.model[attributeName]) {
						continue;
					}
					const column = this.columns[attributeName];
					if (!column || !Ext.isDefined(column.value)) {
						this.set(attributeName, null);
					} else {
						this.set(attributeName, column.value);
					}
				}
			},

			/**
			 * Applies resources to the host class model.
			 * @private
			 */
			applyResources: function() {
				const attributes = this.model.attributes;
				let resourceKey, attributeName;
				const localizableStrings = resources.localizableStrings;
				const localizableImages = resources.localizableImages;
				for (resourceKey in localizableStrings) {
					if (!localizableStrings.hasOwnProperty(resourceKey)) {
						continue;
					}
					attributeName = "Resources.Strings." + resourceKey;
					if (attributes[attributeName]) {
						continue;
					}
					this.set(attributeName, localizableStrings[resourceKey]);
				}
				for (resourceKey in localizableImages) {
					if (!localizableImages.hasOwnProperty(resourceKey)) {
						continue;
					}
					attributeName = "Resources.Images." + resourceKey;
					if (attributes[attributeName]) {
						continue;
					}
					this.set(attributeName, localizableImages[resourceKey]);
				}
			},

			/**
			 * Fills EntityColumnMappingsControls with initial values from parameter EntityColumnMappings.
			 * @private
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 * @param {Terrasoft.Collection} entityColumns Entity columns collection.
			 */
			initEntityColumnMappings: function(element, entityColumns, callback, scope) {
				const controlList = Ext.create("Terrasoft.ObjectCollection");
				if (entityColumns && !entityColumns.isEmpty()) {
					const recordColumnValuesParameterName = this.getEntityColumnMappingsParameterName();
					const parameter = element.getParameterByName(recordColumnValuesParameterName);
					const metaDataCollectionValue = Terrasoft.decode(parameter.sourceValue.value);
					if (metaDataCollectionValue) {
						const recordColumnValueList = metaDataCollectionValue.$values;
						recordColumnValueList.forEach(function(item) {
							const id = item.columnMetaPath.value;
							const column = entityColumns.find(id);
							if (!column) {
								return;
							}
							const config = {
								column: column,
								columnMapping: item
							};
							const viewModel = this.getEntityColumnMappingViewModel(config);
							controlList.add(id, viewModel);
							column.selected = true;
						}, this);
					}
				}
				this.set("EntityColumnMappingsControls", controlList);
				controlList.eachAsync(function(viewModel, next) {
					viewModel.init(next, this);
				}, callback, scope);
			},

			/**
			 * Updates menus of all column mapping controls.
			 * @private
			 * @param {Terrasoft.Collection} sourceSchemaColumns Source schema columns.
			 */
			updateEntityMappingControlsMenu: function(sourceSchemaColumns) {
				const mappingControls = this.get("EntityColumnMappingsControls");
				if (mappingControls) {
					mappingControls.each(function(mappingControl) {
						mappingControl.updateSourceColumns(sourceSchemaColumns);
					});
				}
			},

			/**
			 * Returns entity column mapping parameter value for new entity column mapping collection item.
			 * @private
			 * @param {Object} column Schema column.
			 * @return {Object} The value of the mapping parameter.
			 */
			getEmptyColumnMappingParameterValue: function(column) {
				const schemaColumn = column.schemaColumn;
				const dataValueType = schemaColumn.dataValueType;
				const dataValueTypeUId = Terrasoft.convertToServerDataValueType(dataValueType);
				const value = {
					value: "",
					displayValue: "",
					source: Terrasoft.ProcessSchemaParameterValueSource.None,
					dataValueType: dataValueType,
					dataValueTypeUId: dataValueTypeUId,
					referenceSchemaUId: schemaColumn.referenceSchemaUId
				};
				return value;
			},

			/**
			 * Returns entity column mapping parameter value.
			 * @private
			 * @param {Object} columnMapping Localizable column item.
			 * @return {Object} The value of the mapping parameter.
			 */
			getColumnMappingParameterValue: function(columnMapping) {
				const parameterValue = Terrasoft.decode(columnMapping.parameterValue.value);
				let referenceSchemaUId = parameterValue.ReferenceSchemaUId;
				if (Terrasoft.isEmptyGUID(referenceSchemaUId)) {
					referenceSchemaUId = null;
				}
				const value = this.getCurrentCultureValue(columnMapping.value.value);
				const displayValue = value ? this.getCurrentCultureValue(columnMapping.displayValue.value) : "";
				let dataValueType;
				const dataValueTypeUId = parameterValue.DataValueTypeUId;
				if (dataValueTypeUId && !Terrasoft.isEmptyGUID(dataValueTypeUId)) {
					dataValueType = Terrasoft.convertToClientDataValueType(dataValueTypeUId);
				}
				return {
					value: value,
					displayValue: displayValue,
					source: parameterValue.Source,
					dataValueType: dataValueType,
					dataValueTypeUId: dataValueTypeUId,
					referenceSchemaUId: referenceSchemaUId
				};
			},

			/**
			 * Returns culture value of localizable string.
			 * @private
			 * @param {Object} localizableString Localizable string like object.
			 * @return {String}
			 */
			getCurrentCultureValue: function(localizableString) {
				if (!localizableString) {
					return "";
				}
				if (typeof localizableString === "string") {
					return localizableString;
				}
				const currentCulture = Terrasoft.SysValue.CURRENT_USER_CULTURE.displayValue;
				const cultureValue = localizableString ? localizableString.cultureValues[currentCulture] : "";
				return cultureValue;
			},

			/**
			 * Returns tools button delete menu item ViewModel.
			 * @private
			 * @return {Terrasoft.BaseViewModel} Delete menu item ViewModel.
			 */
			getDeleteMenuItemViewModel: function() {
				const caption = this.get("Resources.Strings.EntityColumnMapping_DeleteMenuItemCaption");
				return Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: Terrasoft.generateGUID(),
						Caption: caption,
						Click: {"bindTo": "onDeleteClick"},
						MarkerValue: caption,
						Tag: "DeleteButton"
					}
				});
			},

			/**
			 * Returns entity column mapping element view model.
			 * @private
			 * @param {Object} config Mapping configuration.
			 * @param {Object} config.column Schema column for the mapping.
			 * @param {Object} [config.columnMapping] Entity column mapping collection item.
			 * @return {Terrasoft.EntityColumnMappingViewModel}
			 */
			getEntityColumnMappingViewModel: function(config) {
				const column = config.column;
				const schemaColumn = column.schemaColumn;
				let mapping = config.columnMapping;
				const value = (Ext.isEmpty(mapping))
					? this.getEmptyColumnMappingParameterValue(column)
					: this.getColumnMappingParameterValue(mapping);
				mapping = mapping || {};
				const deleteMenuItemViewModel = this.getDeleteMenuItemViewModel();
				const toolsButtonMenuViewModelCollection = Ext.create("Terrasoft.BaseViewModelCollection", {
					items: {"delete": deleteMenuItemViewModel}
				});
				const toolButtonImage = this.get("Resources.Images.EntityColumnMapping_ToolButtonImage");
				const onItemRemoved = this.clearSelection.bind(this);
				const invokerUId = this.get("uId");
				const packageUId = this.get("packageUId");
				const localizableParameterValueId = mapping.ItemUId || Terrasoft.generateGUID();
				const sourceSchemaColumns = this.get("SourceSchemaColumns");
				const viewModel = Ext.create("Terrasoft.EntityColumnMappingViewModel", {
					sandbox: this.sandbox,
					values: {
						Id: column.id,
						ProcessElement: this.get("ProcessElement"),
						SchemaColumn: schemaColumn,
						Caption: column.caption,
						Value: value,
						MarkerValue: "RecordColumnValue-" + schemaColumn.name,
						LocalizableParameterValueId: localizableParameterValueId,
						ToolButtonMenu: toolsButtonMenuViewModelCollection,
						packageUId: packageUId,
						ToolButtonImage: toolButtonImage,
						InvokerUId: invokerUId
					},
					methods: {
						onItemFocused: this.onItemFocused,
						onItemRemoved: onItemRemoved
					}
				});
				viewModel.updateSourceColumns(sourceSchemaColumns);
				return viewModel;
			},

			/**
			 * Clears selection for the entity column mapping item.
			 * @private
			 * @param {String} id Column item identifier.
			 */
			clearSelection: function(id) {
				const entityColumns = this.get("EntityColumns");
				const entityColumn = entityColumns.get(id);
				entityColumn.selected = false;
			},

			/**
			 * Returns EntityColumnMappings parameter values in server format.
			 * @private
			 * @return {Object[]}
			 */
			getEntityColumnMappingsMetaValue: function() {
				const entitySchemaUId = this.getEntityColumnMappingSchemaUId();
				if (!entitySchemaUId) {
					return [];
				}
				const controlList = this.get("EntityColumnMappingsControls");
				if (!controlList) {
					return [];
				}
				const valuesList = [];
				controlList.each(function(control) {
					const mappingValue = control.get("Value");
					if (!mappingValue) {
						return;
					}
					const dataValueTypeUId = mappingValue.dataValueTypeUId;
					const source = mappingValue.source;
					const value = this.getLocalizableParameterValues(mappingValue.value, source, dataValueTypeUId);
					const displayValue = this.getLocalizableParameterValues(mappingValue.displayValue, source,
						dataValueTypeUId);
					const itemValue = {
						"ItemUId": control.get("LocalizableParameterValueId"),
						"columnMetaPath": {
							"value": control.get("Id")
						},
						"schemaUId": {
							"value": entitySchemaUId
						},
						"value": value,
						"displayValue": displayValue,
						"parameterValue": {
							"value": this.getEntityColumnMappingsParameterValue(mappingValue, dataValueTypeUId)
						}
					};
					valuesList.push(itemValue);
				}, this);
				return valuesList;
			},

			/**
			 * Gets a value indicating where column sourceValue can be localized.
			 * @private
			 * @param {String} dataValueTypeUId DataValueType identifier of the value.
			 * @param {Terrasoft.process.enums.ProcessSchemaParameterValueSource} source The source of the value.
			 * @return {Boolean} True, if value is localizable, otherwise - false.
			 */
			getIsValueLocalizable: function(source, dataValueTypeUId) {
				const sources = Terrasoft.process.enums.ProcessSchemaParameterValueSource;
				if (source === sources.Script || source === sources.Mapping) {
					return false;
				}
				const dataValueType = Terrasoft.ServerDataValueType[dataValueTypeUId];
				const isTextDataValueType = Terrasoft.isTextDataValueType(dataValueType);
				return isTextDataValueType;
			},

			/**
			 * Returns localizable parameter values of value in server format.
			 * @private
			 * @param {String} value Current culture value.
			 * @param {Terrasoft.process.enums.ProcessSchemaParameterValueSource} source The source of the value.
			 * @param {String} dataValueTypeUId DataValueType identifier of the value.
			 * @return {Object} Localizable parameter value item.
			 * @return {String|Terrasoft.LocalizableString} return.value Item value.
			 * @return {Boolean} [return.isLczValue=false] Indicates that the value is localizable.
			 */
			getLocalizableParameterValues: function(value, source, dataValueTypeUId) {
				if (!value) {
					return {
						"value": ""
					};
				}
				const isLczValue = this.getIsValueLocalizable(source, dataValueTypeUId);
				if (isLczValue) {
					return {
						"isLczValue": true,
						"value": value
					};
				}
				return {
					"value": value
				};
			},

			/**
			 * Returns EntityColumnMappings parameter value in server format.
			 * @private
			 * @param {Object} mappingValue Parameter mapping value.
			 * @param {String} dataValueTypeUId DataValueType identifier of the value.
			 * @return {String}
			 */
			getEntityColumnMappingsParameterValue: function(mappingValue, dataValueTypeUId) {
				const parameterValue = {
					"$type": "Terrasoft.Core.Process.ProcessSchemaParameterValue, Terrasoft.Core",
					"Source": mappingValue.source,
					"DisplayValue": "",
					"Value": "",
					"MetaPath": mappingValue.metaPath || null,
					"MetaDataValue": null,
					"ModifiedInSchemaUId": Terrasoft.GUID_EMPTY,
					"SchemaUId": Terrasoft.GUID_EMPTY,
					"SchemaManagerName": "",
					"DataValueTypeUId": dataValueTypeUId,
					"ReferenceSchemaUId": mappingValue.referenceSchemaUId || Terrasoft.GUID_EMPTY,
					"ResourceItemName": null
				};
				return Terrasoft.encode(parameterValue);
			},

			/**
			 * Queries entity columns for ReferenceSchemaUId.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Terrasoft.Collection} callback.entityColumns The collection of the entity schema columns.
			 * @param {Object} scope Callback function scope.
			 */
			queryEntityColumns: function(callback, scope) {
				const referenceSchemaUId = this.getEntityColumnMappingSchemaUId();
				if (!referenceSchemaUId) {
					callback.call(scope);
					return;
				}
				const entityColumns = this.get("EntityColumns");
				if (entityColumns) {
					callback.call(scope, entityColumns);
					return;
				}
				this.queryMappingEntitySchemaColumns(referenceSchemaUId, callback, scope);
			},

			/**
			 * Queries entity schema columns for ReferenceSchemaUId.
			 * @private
			 * @param {String} schemaUId UId of the entity schema.
			 * @param {Function} callback Callback function.
			 * @param {Terrasoft.Collection} callback.entityColumns The collection of the entity schema columns.
			 * @param {Object} scope Callback function scope.
			 */
			queryMappingEntitySchemaColumns: function(schemaUId, callback, scope) {
				const entityColumns = Ext.create("Terrasoft.Collection");
				const config = {
					schemaUId: schemaUId
				};
				const utils = this.getEntitySchemaDesignerUtilities();
				utils.findEntitySchemaInstance(config, function(schema) {
					if (schema) {
						schema.columns.each(function(column) {
							const id = column.uId;
							let caption = column.caption.getValue();

							// TODO #CRM-22004
							if (!caption) {
								caption = column.name;
								let message = "Title for column \"{0}.{1}\" is not defined";
								message = Ext.String.format(message, schema.name, column.name);
								this.log(message, Terrasoft.LogMessageType.WARNING);
							}
							const entityColumn = {
								id: id,
								caption: caption,
								schemaColumn: column,
								selected: false
							};
							entityColumns.add(id, entityColumn);
						}, this);
						entityColumns.sort("caption");
						this.set("EntityColumns", entityColumns);
						callback.call(scope, entityColumns);
					} else {
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * Adds column default value.
			 * @private
			 */
			onAddEntityColumnMappings: function() {
				this.queryEntityColumns(function(entityColumns) {
					this.addSubscriptionsToColumnMappingSetParametersInfo();
					this.showEntitySchemaColumnSelectPage(entityColumns);
				}, this);
			},

			/**
			 * Adds subscriptions  on SetParametersInfo.
			 * @private
			 */
			addSubscriptionsToColumnMappingSetParametersInfo: function() {
				const schemaName = "ProcessLookupPage";
				const pageId = this.sandbox.id + schemaName;
				this.sandbox.subscribe("SetParametersInfo", function(parametersInfo) {
					if (parametersInfo) {
						this.addEntityColumnMappingsControls(parametersInfo.selectedRows);
					}
					this.closeSchemaColumnSelectPage();
				}, this, [pageId]);
			},

			/**
			 * Adds controls by selected columns if not exists.
			 * @private
			 * @param {String[]} selectedRows Selected columns.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			addEntityColumnMappingsControls: function(selectedRows, callback, scope) {
				const controlList = this.get("EntityColumnMappingsControls");
				this.queryEntityColumns(function(entityColumns) {
					entityColumns.each(function(column) {
						const id = column.id;
						const selected = Ext.Array.contains(selectedRows, id);
						if (selected && !controlList.contains(id)) {
							const viewModel = this.getEntityColumnMappingViewModel({column: column});
							controlList.add(id, viewModel);
						}
						if (!selected && controlList.contains(id)) {
							controlList.removeByKey(id);
						}
						column.selected = selected;
					}, this);
					if (Ext.isFunction(callback)) {
						callback.call(scope || this);
					}
				}, this);
			},

			/**
			 * Returns tools button configuration for parameter.
			 * @private
			 * @param {String} id Control identifier.
			 */
			getToolsButtonConfig: function(id) {
				const config = {
					id: id,
					className: "Terrasoft.Button",
					style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: {"bindTo": "ToolButtonImage"},
					menu: {
						items: {
							bindTo: "ToolButtonMenu"
						}
					},
					classes: {
						imageClass: ["button-background-no-repeat"],
						wrapperClass: ["detail-tools-button-wrapper"],
						menuClass: ["detail-tools-button-menu"]
					},
					markerValue: {
						bindTo: "getToolsButtonContainerMarkerValue"
					}
				};
				return config;
			},

			/**
			 * Handles changing of 'SourceSchemaColumns' attribute.
			 * @private
			 * @param {Backbone.Model} model Model.
			 * @param {Terrasoft.Collection} sourceSchemaColumns Source schema columns.
			 */
			onSourceSchemaColumnsChanged: function(model, sourceSchemaColumns) {
				this.updateEntityMappingControlsMenu(sourceSchemaColumns);
			},

			//endregion

			//region Methods: Protected

			/**
			 * Creates an EntitySchemaDesignerUtilities class.
			 * @protected
			 * @return EntitySchemaDesignerUtilities class.
			 */
			getEntitySchemaDesignerUtilities: function() {
				const packageUId = this.getPackageUId();
				return Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(packageUId);
			},

			/**
			 * Returns the name of the parameter that stores column values data.
			 * @protected
			 * @return {String}
			 */
			getEntityColumnMappingsParameterName: function() {
				return "RecordColumnValues";
			},

			/**
			 * Returns the entity schema identifier for columns.
			 * @abstract
			 * @protected
			 * @return {String}
			 */
			getEntityColumnMappingSchemaUId: function() {
				throw new Terrasoft.exceptions.NotImplementedException();
			},

			/**
			 * Returns the entity schema identifier, which columns could be source for the mappings.
			 * @protected
			 * @return {String}
			 */
			getMappingSourceSchemaUId: function() {
				return null;
			},

			/**
			 * Generates configuration view of the element.
			 * @protected
			 * @param {Object} itemConfig Link to configuration of element in ContainerList.
			 */
			getEntityColumnMappingsControlViewConfig: function(itemConfig) {
				const cachedViewConfig = this.get("EntityColumnMappingsViewConfig");
				if (cachedViewConfig) {
					itemConfig.config = cachedViewConfig;
					return;
				}
				const buttonConfig = this.getToolsButtonConfig("ToolsButton");
				const labelConfig = {
					id: "record-column-value-caption",
					className: "Terrasoft.Label",
					caption: {bindTo: "Caption"},
					labelClass: "t-label"
				};
				const mappingEditConfig = {
					id: "Value",
					className: "Terrasoft.MappingEdit",
					value: {bindTo: "Value"},
					openEditWindow: {bindTo: "openExtendedMappingEditWindow"},
					classes: {wrapperClass: "top-caption-control"},
					markerValue: {bindTo: "MarkerValue"},
					prepareMenu: {bindTo: "onPrepareMenu"},
					menu: {
						"items": {"bindTo": "MenuItems"}
					}
				};
				const buttonContainerConfig = this.getContainerConfig(
					"ToolsButtonWrap", ["tools-button-container-wrapClass"], [buttonConfig]);
				const labelContainerConfig = this.getContainerConfig(
					"LabelWrap", ["label-container-wrapClass"], [labelConfig]);
				const toolsContainerConfig = this.getContainerConfig(
					"ToolsContainer", ["tools-container-wrapClass"], [labelContainerConfig, buttonContainerConfig]);
				toolsContainerConfig.markerValue = "entityColumnMappingToolsContainer";
				const entityColumnContainerConfig = this.getContainerConfig(
					"EntityColumnContainer", ["entity-column-mapping"], [toolsContainerConfig, mappingEditConfig]);
				entityColumnContainerConfig.markerValue = "entityColumnMappingInnerContainer";
				const config = itemConfig.config = this.getContainerConfig(
					"item-view", ["top-caption-control", "control-width-15"], [entityColumnContainerConfig]);
				config.markerValue = {"bindTo": "getMarkerValue"};
				this.set("EntityColumnMappingsViewConfig", config);
			},

			/**
			 * Clears mapping of entity columns.
			 * @protected
			 */
			clearEntityColumnMapping: function() {
				const entityColumns = this.get("EntityColumns");
				if (entityColumns) {
					entityColumns.each(function(column) {
						column.selected = false;
					});
				}
				const controlList = this.get("EntityColumnMappingsControls");
				if (controlList) {
					controlList.each(function(control) {
						control.destroy();
					});
					controlList.clear();
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * Initializes the mixin.
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 * @param {Function} callback Callback function.
			 * @param {Function} [scope] The scope for callback function.
			 */
			initEntityColumnMappingMixin: function(element, callback, scope) {
				this.applyAttributes();
				this.applyResources();
				this.on("change:SourceSchemaColumns", this.onSourceSchemaColumnsChanged, this);
				this.queryEntityColumns(function(entityColumns) {
					this.updateMappingSourceSchemaColumns(element, function() {
						this.initEntityColumnMappings(element, entityColumns, function() {
							callback.call(scope || this, entityColumns);
						}, this);
					}, this);
				}, this);
			},

			/**
			 * Updates mapping source schema columns.
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 * @param {Function} callback Callback function.
			 * @param {Object} [scope] Callback function scope.
			 */
			updateMappingSourceSchemaColumns: function(element, callback, scope) {
				const entitySchemaUId = this.getMappingSourceSchemaUId();
				if (!entitySchemaUId) {
					this.set("SourceSchemaColumns", null);
					callback.call(scope || this);
					return;
				}
				const config = {
					schemaUId: entitySchemaUId,
					packageUId: element.getPackageUId()
				};
				const utils = this.getEntitySchemaDesignerUtilities();
				utils.findEntitySchemaInstance(config, function(schema) {
					const columns = schema ? schema.columns.clone() : null;
					this.set("SourceSchemaColumns", columns);
					callback.call(scope || this);
				}, this);
			},

			/**
			 * Clears column items and initializes by current entity schema.
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 * @param {Function} callback Callback function.
			 * @param {Function} [scope] The scope for callback function.
			 */
			reInitEntityColumnMapping: function(element, callback, scope) {
				this.set("EntityColumns", null);
				this.set("EntityColumnMappingsViewConfig", null);
				this.queryEntityColumns(function() {
					this.clearEntityColumnMapping();
					this.updateMappingSourceSchemaColumns(element, callback, scope);
				}, this);
			},

			/**
			 * Saves EntityColumnMappings parameter value.
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 */
			saveEntityColumnMappings: function(element) {
				const recordColumnValuesParameterName = this.getEntityColumnMappingsParameterName();
				const parameter = element.getParameterByName(recordColumnValuesParameterName);
				const values = this.getEntityColumnMappingsMetaValue();
				parameter.setLocalizableParameterValues(values);
			},

			/**
			 * Destroys the mixin.
			 */
			destroyEntityColumnMappings: function() {
				this.set("EntityColumns", null);
				this.set("EntityColumnMappingsViewConfig", null);
				const controlList = this.get("EntityColumnMappingsControls");
				if (controlList) {
					controlList.each(function(control) {
						control.destroy();
					});
					controlList.destroy();
				}
			}

			//endregion

		});
	}
);


