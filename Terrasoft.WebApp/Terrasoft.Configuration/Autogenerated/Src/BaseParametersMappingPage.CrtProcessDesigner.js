define("BaseParametersMappingPage", ["GridUtilitiesV2", "MappingEnums"],
		function() {
			return {
				mixins: {
					GridUtilities: "Terrasoft.GridUtilities"
				},
				attributes: {
					////TODO: #CRM-28545
					/**
					 * Config that contains filters parameters.
					 */
					"FilterConfig": {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT
					},

					/**
					 * Parameters grid data.
					 */
					"ParametersGridData": {
						dataValueType: this.Terrasoft.DataValueType.COLLECTION
					},

					/**
					 * Flag that indicates whether process elements grid is hierarchical.
					 */
					IsElementsGridHierarchical: {
						dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
						value: false
					},

					/**
					 * Parameters grid active row.
					 */
					"ParametersGridActiveRow": {
						dataValueType: Terrasoft.DataValueType.GUID
					},

					/**
					 * Flag that indicates whether parameters grid is empty.
					 */
					"IsParametersGridEmpty": {
						dataValueType: Terrasoft.DataValueType.BOOLEAN
					},

					/**
					 * Flag that indicates whether process has any parameters.
					 */
					"HasParameters": {
						dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
						type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Process schema instance.
					 */
					ProcessSchema: {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT
					},

					/**
					 * Maximum parameter nesting level that allowed to specify mapping to. If defined as null parameter
					 * with any nesting level will be allowed to map to.
					 */
					"AllowedCollectionItemNestingLevel": {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
						value: null
					},

					/**
					 * Process schema parameter instance of InvokerUId
					 */
					"DestinationParameter": {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
						value: null
					},

					/**
					 * UId of the parent parameter of the destination parameter.
					 */
					"ParentParameterUId": {
						dataValueType: this.Terrasoft.DataValueType.GUID
					}
				},
				messages: {
					/**
					 * Returns process schema.
					 * @message GetProcessSchema
					 */
					"GetProcessSchema": {
						direction: Terrasoft.MessageDirectionType.PUBLISH,
						mode: Terrasoft.MessageMode.PTP
					},

					/**
					 * Returns selected rows.
					 * @message ResultSelectedRows
					 */
					"ResultSelectedRows": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					},

					/**
					 * Returns active row.
					 * @message ResultSelectedRows
					 */
					"ResultActiveRow": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					},

					/**
					 * Returns selected process parameter.
					 * @message GetSelectedProcessParameter
					 */
					"GetSelectedProcessParameter": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * Returns the parameter mapping data.
					 * @message GetParameterMappingInfo
					 */
					"GetParameterMappingInfo": {
						direction: Terrasoft.MessageDirectionType.PUBLISH,
						mode: Terrasoft.MessageMode.PTP
					}
				},
				methods: {
					/**
					 * Returns selected row data.
					 * @protected
					 * @abstract
					 * @return {Object} Selected data.
					 * @return {String} return.caption Selected item caption.
					 * @return {String} return.value Path to parameter.
					 */
					getSelectedData: Terrasoft.emptyFn,

					/**
					 * Returns active row.
					 * @private
					 * @return {Terrasoft.BaseViewModel} Active row view model.
					 */
					getActiveRow: Terrasoft.emptyFn,

					/**
					 * Returns grid collection in callback function.
					 * @protected
					 * @abstract
					 * @param {Function} callback The callback function.
					 */
					getMainCollection: Terrasoft.emptyFn,

					/**
					 * Returns grid rows view model collection.
					 * @protected
					 * @abstract
					 * @param {Object} parameters Parameters.
					 * @return {Object} Grid rows view model collection.
					 */
					getMainRowCollection: Terrasoft.emptyFn,

					/**
					 * Initializes active rows.
					 * @protected
					 * @abstract
					 */
					initActiveRow: Terrasoft.emptyFn,

					/**
					 * Applies empty message config for parameters grid.
					 * @protected
					 * @abstract
					 * @param {Object} config Configuration object.
					 */
					applyEmptyParametersGridMessageConfig: Terrasoft.emptyFn,

					/**
					 * Loads grid collection.
					 * @protected
					 * @abstract
					 * @param {Terrasoft.Collection} collection Data collection.
					 */
					loadMainGridCollection: Terrasoft.emptyFn,

					/**
					 * Initializes process schema.
					 * @protected
					 */
					initProcessSchema: function() {
						var processSchema = this.sandbox.publish("GetProcessSchema");
						this.set("ProcessSchema", processSchema);
						this._initDestinationParameterInfo(processSchema);
					},

					/**
					 * @private
					 */
					_initDestinationParameterInfo(processSchema) {
						const parameters = processSchema?.parameters;
						if (this.$ProcessElementUId) {
							const element = processSchema.flowElements.findByFn(x => x.uId === this.$ProcessElementUId);
							this.$DestinationParameterParent = element?.parameters.find(this.$ParentParameterUId);
						} else {
							this.$DestinationParameterParent = parameters?.find(this.$ParentParameterUId);
						}
						this.$DestinationParameterRootUId = this.$DestinationParameterParent?.getRoot()?.uId ?? this.$ParameterUId;
					},

					////TODO: #CRM-28545
					/**
					 * Filters collection from invoker of the mapping window.
					 * @protected
					 * @virtual
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @return {Terrasoft.Collection} Filtered collection
					 */
					excludeSelfFromMapping: function(collection) {
						let result = collection;
						const itemUIdToRemove = this.get("InvokerUId");
						const rootUId = this.$DestinationParameterRootUId;
						if (collection && (itemUIdToRemove || rootUId)) {
							result = collection.filterByFn(function(item) {
								if (item.uId === itemUIdToRemove){
									return false;
								}
								return !this._getIsParameter(item) || (item.getRoot().uId !== rootUId);
							}, this);
						}
						return result;
					},

					////TODO: #CRM-28545
					/**
					 * Filters collection by reference schema for lookup.
					 * @protected
					 * @virtual
					 * @param {Terrasoft.Collection} collection Collection  to filter.
					 * @return {Terrasoft.Collection} Filtered collection.
					 */
					getFilteredByReferenceSchemaUId: function(collection) {
						var referenceSchemaUId = this.get("referenceSchemaUId");
						return this.applyReferenceSchemaFilters(collection, referenceSchemaUId);
					},

					////TODO: #CRM-28545
					/**
					 * Filters collection by data type.
					 * @protected
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @param {Number} dataValueType value type.
					 * @return {Terrasoft.Collection} Filtered collection.
					 */
					getFilteredByDataValueTypeParameters: function(collection, dataValueType) {
						var result = collection;
						var validator = Terrasoft.findDataValueTypeValidator(dataValueType);
						if (collection && validator) {
							result = collection.filterByFn(function(item) {
								return validator(item.dataValueType);
							});
						}
						return result;
					},

					////TODO: #CRM-28545
					/**
					 * Applies filters to collection according to filter flags.
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @param {Boolean} isLookup Is parameter a lookup.
					 * @param {Number} dataValueType Parameter value type.
					 * @returns {Terrasoft.Collection} Filtered collection.
					 */
					applyFilters: function(collection, isLookup, dataValueType) {
						var shouldBeCompiled = Terrasoft.isInstanceOfClass(this.$ProcessSchema,
							"Terrasoft.ProcessSchema") && this.$ProcessSchema.shouldBeCompiled();
						if (shouldBeCompiled &&	(Terrasoft.isDebug ||
								Terrasoft.Features.getIsEnabled("NoCompilationFeature"))) {
							collection = collection.filterByFn(function(parameter) {
								return !Terrasoft.isEnumerableDataValueType(parameter.dataValueType);
							});
						}
						if (this.useGridItemsFilter()) {
							return collection;
						}
						dataValueType = dataValueType || this.get("DataValueType");
						isLookup = isLookup || Terrasoft.isLookupDataValueType(dataValueType);
						var filterConfig = this.get("FilterConfig");
						if (filterConfig) {
							collection = this.applyFilterConfig(collection, filterConfig);
						} else {
							collection = this.getFilteredByDataValueTypeParameters(collection, dataValueType);
							if (isLookup) {
								collection = this.getFilteredByReferenceSchemaUId(collection);
							}
						}
						return collection;
					},

					/**
					 * @protected
					 */
					useGridItemsFilter: function() {
						return true;
					},

					////TODO: #CRM-28545
					/**
					 * Applies data value type filters array to collection.
					 * @private
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @param {Array} filterArray Data value type filters array.
					 * @returns {Terrasoft.Collection} Filtered collection.
					 */
					applyDataValueTypeFilters: function(collection, filterArray) {
						if (collection) {
							collection = collection.filterByFn(function(item) {
								return Terrasoft.contains(filterArray, item.dataValueType);
							}, this);
						}
						return collection;
					},

					////TODO: #CRM-28545
					/**
					 * Applies reference schema uid filter to collection.
					 * @private
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @param {String} referenceSchemaUId Reference schema uid to filter.
					 * @returns {Terrasoft.Collection} Filtered collection.
					 */
					applyReferenceSchemaFilters: function(collection, referenceSchemaUId) {
						if (collection) {
							collection = collection.filterByFn(function(item) {
								if (item.dataValueType === Terrasoft.DataValueType.GUID) {
									return true;
								}
								var itemReferenceSchemaUId = item.referenceSchemaUId ||
									item.sourceValue.referenceSchemaUId;
								return itemReferenceSchemaUId === referenceSchemaUId;
							}, this);
						}
						return collection;
					},

					////TODO: #CRM-28545
					/**
					 * Applies filters from filter config to collection.
					 * @private
					 * @param {Terrasoft.Collection} collection Collection to filter
					 * @param {Object} filterConfig Filter object.
					 * @returns {Terrasoft.Collection} Filtered collection.
					 */
					applyFilterConfig: function(collection, filterConfig) {
						var referenceSchemaUId = filterConfig.filterSchemaUId;
						var allowedDataValueTypes = filterConfig.allowedDataValueTypes;
						if (!Ext.isEmpty(allowedDataValueTypes)) {
							collection = this.applyDataValueTypeFilters(collection, allowedDataValueTypes);
						}
						if (!Ext.isEmpty(referenceSchemaUId)) {
							collection = this.applyReferenceSchemaFilters(collection, referenceSchemaUId);
						}
						return collection;
					},

					/**
					 * @private
					 */
					_getReferenceSchemaValidator: function() {
						var filterConfig = this.get("FilterConfig");
						var isLookup = Terrasoft.isLookupDataValueType(this.get("DataValueType"));
						var referenceSchemaUId = filterConfig
							? filterConfig.filterSchemaUId
							: (isLookup ? this.get("referenceSchemaUId") : null);
						return function(item) {
							var result = true;
							if (Terrasoft.isLookupDataValueType(item.dataValueType) && referenceSchemaUId) {
								var itemReferenceSchemaUId = item.referenceSchemaUId ||
									item.sourceValue.referenceSchemaUId;
								result = itemReferenceSchemaUId === referenceSchemaUId;
							}
							return result;
						};
					},

					/**
					 * @private
					 */
					_getCompositeTextDataValueTypeValidator: function(sourceDataValueType, targetDataValueType) {
						const validators = [];
						if (Terrasoft.utils.dataValueType.isExtraTextDataValueType(sourceDataValueType)) {
							validators.push((type) => sourceDataValueType === type);
							validators.push((type) => Terrasoft.utils.dataValueType.isTextDataValueType(type) &&
								!Terrasoft.utils.dataValueType.isExtraTextDataValueType(type));
						} else {
							validators.push((type) =>
								Terrasoft.utils.dataValueType.isTextDataValueTypeWithExtraTypes(type));
						}
						if (Terrasoft.utils.dataValueType.isExtraTextDataValueType(targetDataValueType)) {
							validators.push((type) => sourceDataValueType === type);
						}
						return (type) => validators.reduce((result, validator) => result || validator(type), false);
					},

					/**
					 * @private
					 */
					_getDataValueTypeValidator: function() {
						let validator;
						const filterConfig = this.get("FilterConfig");
						if (filterConfig) {
							validator = function(item) {
								return Terrasoft.contains(filterConfig.allowedDataValueTypes, item.dataValueType);
							};
						} else {
							const getCompositeValidator = this._getCompositeTextDataValueTypeValidator.bind(this);
							validator = function(item) {
								if (this.get("AllowAnyDataValueType")) {
									return true;
								}
								let dataValueType = this.get("DataValueType");
								let dataTypeValidator;
								if (Terrasoft.utils.dataValueType.isTextDataValueTypeWithExtraTypes(dataValueType)) {
									dataTypeValidator = getCompositeValidator(dataValueType, item.dataValueType);
								} else {
									dataTypeValidator = Terrasoft.findDataValueTypeValidator(dataValueType);
								}
								return dataTypeValidator ? dataTypeValidator(item.dataValueType) : true;
							};
						}
						return validator;
					},

					/**
					 * @private
					 */
					_validateCompositeParameter: function(parameter) {
						const destinationDataValueType = this.get("DataValueType");
						if (Terrasoft.isEnumerableDataValueType(destinationDataValueType)) {
							return true;
						}
						if (Terrasoft.isEnumerableDataValueType(parameter.dataValueType) &&
								this.get("IsMultiInstanceSupportedByElement")) {
							return true;
						}
						if (parameter.dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT) {
							return true;
						}
						const canBeMappedToNestedParameter = this.$HasParent ||
							!Terrasoft.isEmpty(this.$AllowedCollectionItemNestingLevel);
						return canBeMappedToNestedParameter
							? this._validateNestedParameters(parameter.itemProperties)
							: false;
					},

					/**
					 * @private
					 */
					_validateNestedParameters: function(collection) {
						const filteredNestedParameters = collection.filterByFn(function(item) {
							if (!this._validateParameterNestingLevel(item)) {
								return false;
							}
							return item.hasNestedParameters()
								? this._validateNestedParameters(item.itemProperties)
								: this._validateParameterOrElement(item);
						}, this);
						return !filteredNestedParameters.isEmpty();
					},

					/**
					 * @private
					 */
					_validateParameterNestingLevel: function(parameter) {
						const nestingLevelSpecified = !Terrasoft.isEmpty(this.$AllowedCollectionItemNestingLevel);
						return !nestingLevelSpecified || parameter.getNestingLevel() <=
							this.$AllowedCollectionItemNestingLevel;
					},

					/**
					 * @private
					 */
					_validateParameterOrElement: function(parameter) {
						var validators = this.getParameterValidators();
						var isValid = true;
						validators.each(function(validator) {
							if (isValid && validator) {
								isValid = validator.call(this, parameter);
							}
						}, this);
						return isValid;
					},

					/**
					 * Initializes subscriber for the GetSelectedProcessParameter message.
					 * @protected
					 * @virtual
					 */
					initGetSelectedParameterSubscription: function() {
						var sandbox = this.sandbox;
						sandbox.subscribe("GetSelectedProcessParameter", this.getSelectedData, this, [sandbox.id]);
					},

					/**
					 * Active row change handler.
					 * @protected
					 * @virtual
					 */
					onChangeActiveRow: function() {
						var selectedRows = this.getSelectedRows();
						this.sandbox.publish("ResultActiveRow", selectedRows, [this.sandbox.id]);
					},

					/**
					 * Initializes grid data.
					 * @protected
					 * @virtual
					 */
					initGridData: function() {
						this.set("ParametersGridData", this.Ext.create("Terrasoft.BaseViewModelCollection"));
					},

					/**
					 * Returns image Url.
					 * @private
					 * @param {String} imageName Image name.
					 * @return {String} Image URL.
					 */
					getImageUrl: function(imageName) {
						return Terrasoft.ImageUrlBuilder.getUrl({
							source: Terrasoft.ImageSources.RESOURCE_MANAGER,
							params: {
								resourceManagerName: "Terrasoft.Nui",
								resourceItemName: "ProcessSchemaDesigner." + imageName
							}
						});
					},

					/**
					 * Returns selected rows data.
					 * @private
					 * @return {Object}
					 */
					getSelectedRows: function() {
						var selectedData = this.getSelectedData();
						var result = new Terrasoft.Collection();
						if (selectedData) {
							result.add(selectedData.Id, selectedData);
						}
						return {
							selectedRows: result
						};
					},

					/**
					 * Grid double click handler.
					 * @protected
					 */
					onGridDoubleClick: function() {
						var selectedRows = this.getSelectedRows();
						this.sandbox.publish("ResultSelectedRows", selectedRows, [this.sandbox.id]);
					},

					/**
					 * Applies empty grid message config.
					 * @protected
					 * @param {Object} config Configuration object.
					 * @param {String} title Empty message label text.
					 * @param {Array} wrapClasses Empty message label wrap classes.
					 */
					applyEmptyGridMessageConfig: function(config, title, wrapClasses) {
						var emptyGridMessageProperties = {
							title: title,
							wrapClasses: wrapClasses
						};
						var emptyGridMessageViewConfig = this.getEmptyGridMessageViewConfig(emptyGridMessageProperties);
						this.Ext.apply(config, emptyGridMessageViewConfig);
					},

					/**
					 * Returns view config for empty grid message.
					 * @protected
					 * @param {Object} messageProperties Message properties.
					 * @param {String} messageProperties.title Message.
					 * @param {Array} messageProperties.wrapClasses Wrap classes array.
					 * @return {Object}.
					 */
					getEmptyGridMessageViewConfig: function(messageProperties) {
						var config = {
							className: "Terrasoft.Container",
							classes: {
								wrapClassName: messageProperties.wrapClasses
							},
							items: []
						};
						config.items.push({
							className: "Terrasoft.Container",
							classes: {
								wrapClassName: ["title"]
							},
							items: [
								{
									className: "Terrasoft.Label",
									caption: messageProperties.title
								}
							]
						});
						return config;
					},

					/**
					 * Returns sorted by caption parameters collection.
					 * @protected
					 * @param {Terrasoft.Collection} collection Source collection.
					 * @return {Terrasoft.BaseViewModelCollection} Sorted collection.
					 */
					sortParametersByCaption: function(collection) {
						var sortedCollection = this.Ext.create("Terrasoft.BaseViewModelCollection", {
							getKey: function(item) {
								return item.get("Id");
							}
						});
						var sortColumn = "Caption";
						sortedCollection.loadAll(collection);
						sortedCollection.sortByFn(function(item1, item2) {
							var item1Caption = item1.get(sortColumn);
							var item2Caption = item2.get(sortColumn);
							return item1Caption.localeCompare(item2Caption);
						});
						return sortedCollection;
					},

					/**
					 * Returns collection of validators.
					 * @protected
					 * @virtual
					 * @return {Terrasoft.Collection}
					 */
					getParameterValidators: function() {
						var dataValueTypeValidator = this._getDataValueTypeValidator();
						var referenceSchemaValidator = this._getReferenceSchemaValidator();
						var validators = new Terrasoft.Collection();
						validators.add(dataValueTypeValidator);
						validators.add(referenceSchemaValidator);
						return validators;
					},

					/**
					 * @private
					 */
					_getIsDestinationParameterPartOfCollection() {
						if (this.$DestinationParameterParent) {
							return this.$DestinationParameterParent?.getIsPartOfCollectionStructure();
						}
						if (this.$DataValueType){
							return Terrasoft.isEnumerableDataValueType(this.$DataValueType);
						}
						if (this.get("DestinationParameterSelectionMode")) {
							return false;
						}
						return true;
					},

					/**
					 * @private
					 */
					_getIsParameter(parameter) {
						return parameter instanceof Terrasoft.ProcessSchemaParameter;
					},

					/**
					 * Returns filtered grid items collection.
					 * @protected
					 * @param {Terrasoft.Collection} collection Source collection.
					 */
					getFilteredGridItems: function(collection) {
						var filteredCollection = this.Ext.create("Terrasoft.BaseViewModelCollection", {
							getKey: function(item) {
								return item.get("Id");
							}
						});
						filteredCollection.loadAll(collection);
						const destinationIsPartOfCollection = this._getIsDestinationParameterPartOfCollection();
						filteredCollection = filteredCollection.filterByFn(function(item) {
							const parameter = item.get("Parameter");
							if (!this._getIsParameter(parameter)) {
								return this._validateParameterOrElement(parameter);
							}
							if (!this.$ProcessElementUId) {
								if (!destinationIsPartOfCollection && parameter.getIsPartOfCollectionStructure()) {
									return false;
								}
							}
							return parameter.hasNestedParameters()
								? this._validateCompositeParameter(parameter)
								: this._validateParameterOrElement(parameter);
						}, this);
						filteredCollection = this._filterCompositeParametersWithoutStructure(filteredCollection);
						return filteredCollection;
					},

					/**
					 * @private
					 */
					_filterCompositeParametersWithoutStructure: function (collection) {
						const allParameterUIds = collection.getKeys();
						return collection.filterByFn(item => {
							const parameter = item.$Parameter;
							if (!this._getIsParameter(parameter)) {
								return true;
							}
							return this._hasSimpleParameters(allParameterUIds, parameter)
						});
					},

					/**
					 * @private
					 */
					_hasSimpleParameters:  function(availableParameterUIds, parameter) {
						if (!availableParameterUIds.includes(parameter.uId)) {
							return false;
						}
						if (!Terrasoft.utils.dataValueType.isCompositeDataValueType(parameter.dataValueType)) {
							return true;
						}
						return !!parameter.itemProperties.findByFn(item =>
							this._hasSimpleParameters(availableParameterUIds, item))
					}
				}
			};
		});
