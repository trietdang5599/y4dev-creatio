Terrasoft.configuration.Structures["ProcessSchemaParameterViewModel"] = {innerHierarchyStack: ["ProcessSchemaParameterViewModel"]};
define("ProcessSchemaParameterViewModel", [
	"ProcessSchemaParameterViewModelResources",
	"MappingEditMixin"
],	function(resources) {
	Ext.define("Terrasoft.configuration.ProcessSchemaParameterViewModel", {
		extend: "Terrasoft.BaseViewModel",
		alternateClassName: "Terrasoft.ProcessSchemaParameterViewModel",
		mixins: {
			mappingEditMixin: "Terrasoft.MappingEditMixin"
		},
		sandbox: null,
		columns: {
			Id: {dataValueType: Terrasoft.DataValueType.TEXT},
			UId: {dataValueType: Terrasoft.DataValueType.GUID},
			InvokerUId: {dataValueType: Terrasoft.DataValueType.GUID},
			Name: {dataValueType: Terrasoft.DataValueType.TEXT},
			Caption: {dataValueType: Terrasoft.DataValueType.TEXT},
			DataValueType: {dataValueType: Terrasoft.DataValueType.INTEGER},
			DataValueTypeImage: {dataValueType: Terrasoft.DataValueType.TEXT},
			IsRequired: {dataValueType: Terrasoft.DataValueType.BOOLEAN},
			ReferenceSchemaUId: {dataValueType: Terrasoft.DataValueType.LOOKUP},
			InitialReferenceSchemaUId: {dataValueType: Terrasoft.DataValueType.LOOKUP},
			Value: {dataValueType: Terrasoft.DataValueType.MAPPING},
			Enabled: {dataValueType: Terrasoft.DataValueType.BOOLEAN},
			Visible: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},
			packageUId: { dataValueType: Terrasoft.DataValueType.GUID },
			ParameterEditToolsButtonMenu: { dataValueType: Terrasoft.DataValueType.COLLECTION },
			ActiveParameterEditUId: { dataValueType: Terrasoft.DataValueType.GUID },
			Parameters: { dataValueType: Terrasoft.DataValueType.COLLECTION },
			ProcessElement: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			Direction: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Item properties.
			 */
			ItemProperties: {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Has nested parameters.
			 */
			HasNestedParameters: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Is nested control group collapsed.
			 */
			HideNestedItems: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether user can add nested parameters or not.
			 */
			CanAddNestedItems: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether a nested parameter edit page is opened or not.
			 */
			IsNestedParameterEditPageOpened: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Caption of control group for nested parameters.
			 */
			ControlGroupCaption: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: resources.localizableStrings.CollapseControl
			},

			/**
			 * Parent parameter uId.
			 */
			ParentUId: { dataValueType: Terrasoft.DataValueType.GUID },

			/**
			 * Process schema.
			 */
			ProcessSchema: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether a value can be mapped to a parameter.
			 */
			CanAssignSourceValue: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Property for sorting by direction.
			 */
			CaptionWithDirection: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.CALCULATED_COLUMN
			},

			/**
			 * Parameter value contains mapping to the collection.
			 */
			HasCollectionMapping: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Previous parameter value.
			 */
			PreviousValue: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * AddButton menu items collection.
			 */
			AddButtonMenu: {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				value: Ext.create("Terrasoft.BaseViewModelCollection")
			},

			/**
			 * Parameter edit key.
			 */
			ParameterEditKey: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Data item marker value.
			 */
			MarkerValue: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		//region Methods: Private

		/**
		 * @private
		 */
		_mappingValidator: function(value) {
			var result = {invalidMessage: ""};
			if (value && value.isValid === false && Terrasoft.ProcessSchemaDesignerUtilities.hasMapping(value)) {
				var resource = this.get("Resources.Strings.InavalidMappingColumn");
				result.invalidMessage = resource || "Invalid formula";
			}
			return result;
		},

		/**
		 * @private
		 */
		_onItemPropertiesChanged: function() {
			this.$HasNestedParameters = this.$ItemProperties && !this.$ItemProperties.isEmpty();
		},

		/**
		 * @private
		 */
		_onValueChanged: function(args) {
			this.$PreviousValue = args.previous("Value");
		},

		/**
		 * Sets IsNestedParameterEditPageOpened attribute value recursively.
		 * @public
		 * @param isAdding
		 */
		setIsNestedParameterEditPageOpened: function(isAdding) {
			this.$IsNestedParameterEditPageOpened = isAdding;
			const itemProperties = this.$ItemProperties;
			itemProperties.each(function(item) {
				item.setIsNestedParameterEditPageOpened(isAdding);
			}, this);
		},

		//endregion

		/**
		 * @private
		 */
		_requiredParameterValidator: function(mapping) {
			if ((this.$ProcessElement instanceof Terrasoft.ProcessWebServiceSchema) &&
					this.$IsRequired && !mapping.value && !Ext.isBoolean(mapping.value)) {
				return {invalidMessage: Terrasoft.Resources.BaseViewModel.columnRequiredValidationMessage};
			}
			return {invalidMessage: ""};
		},

		/**
		 * @private
		 */
		_initProcessSchema: function(config) {
			if (config && config.values && config.values.ProcessElement) {
				var element = config.values.ProcessElement;
				this.$ProcessSchema = element.parentSchema || element;
			}
		},

		/**
		 * Determines whether to show parameter direction image or not.
		 * @returns {boolean}
		 */
		getCanShowParameterDirection: function() {
			return !this.$ParentUId;
		},

		// region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.BaseViewModel#constuctor
		 * @protected
		 */
		constructor: function(config) {
			this.callParent(arguments);
			this.addEvents("collectionMappingSet");
			this.addEvents("collectionMappingReset");
			this.addEvents("onAddNestedParameter");
			this._initProcessSchema(config);
			this.addColumnValidator("Value", Terrasoft.ProcessSchemaDesignerUtilities.mappingValidator);
			this.addColumnValidator("Value", this._requiredParameterValidator);
			this.on("change:ItemProperties", this._onItemPropertiesChanged, this);
			this.on("change:Value", this._onValueChanged, this);
			const orderDirectionValue = Terrasoft.ProcessSchemaParameterDirectionOrder[this.$Direction];
			this.$CaptionWithDirection = Ext.String.format("{0}{1}", orderDirectionValue, this.$Caption);
			this.$HasNestedParameters = this.$ItemProperties && !this.$ItemProperties.isEmpty();
			this.$ParameterEditKey = this.getParameterEditKey();
			this.$MarkerValue = this._getMarkerValue();
		},

		/**
		 * @inheritdoc MappingEditMixin#getInvokerUId
		 * @override
		 */
		getInvokerUId: function() {
			return this.get("InvokerUId");
		},

		/**
		 * @inheritdoc Terrasoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
		 * @override
		 */
		getParameterReferenceSchemaUId: function() {
			return this.get("InitialReferenceSchemaUId");
		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaSelectMixin#getEntitySchemaDesignerUtilities
		 * @override
		 */
		getEntitySchemaDesignerUtilities: function() {
			if (Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses")) {
				return Terrasoft.EntitySchemaDesignerUtilities.create();
			}
			const packageUId = this.getPackageUId();
			return Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(packageUId);
		},

		/**
		 * Returns parameter edit tools button image.
		 * @protected
		 */
		getParameterEditToolsButtonImage: function() {
			return resources.localizableImages.ParameterEditToolsButtonImage;
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:ItemProperties", this._onItemPropertiesChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Handles control group collapsedchange event.
		 * @protected
		 */
		onCollapsedChanged: function() {
			var resourceName = !this.$HideNestedItems ? "ExpandControl" : "CollapseControl";
			this.$ControlGroupCaption = resources.localizableStrings[resourceName];
		},

		// endregion

		// region Methods: Public

		/**
		 * Returns true is $ItemProperties not empty.
		 * @return {Boolean} Has nested parameters.
		 * @public
		 */
		hasItemProperties: function() {
			return this.$ItemProperties && !this.$ItemProperties.isEmpty();
		},

		/**
		 * Returns true if parameter available to use.
		 * @return {Boolean}.
		 * @public
		 */
		isAvailable: function() {
			if (!Terrasoft.Features.getIsEnabled("NoCompilationFeature") && !Terrasoft.isDebug) {
				return true;
			}
			return Terrasoft.isInstanceOfClass(this.$ProcessSchema, "Terrasoft.ProcessSchema")
				? !(this.$ProcessSchema.shouldBeCompiled() && Terrasoft.isEnumerableDataValueType(this.$DataValueType))
				: true;
		},

		/**
		 * Returns true if input parameter is available.
		 * @return {Boolean}
		 * @public
		 */
		isInputParameterAvailable: function() {
			return this.isAvailable() && this.$Direction === Terrasoft.ProcessSchemaParameterDirection.IN;
		},

		/**
		 * Determines whether a nested items control should be visible or not.
		 * @return {Boolean}
		 * @public
		 */
		getShouldShowNestedItems: function() {
			return this.$HasNestedParameters || this.$CanAddNestedItems;
		},

		/**
		 * Determines whether a value control should be visible or not.
		 * @return {Boolean}
		 * @public
		 */
		getShouldShowValueControl: function() {
			return !this.getShouldShowNestedItems();
		},

		/**
		 * Handles a click event of the AddNestedItemButton.
		 * @protected
		 * @param {String} dataValueType Data value type.
		 */
		onAddNestedItemButtonClick: function(dataValueType) {
			this.fireEvent("onAddNestedParameter", {
				dataValueType: dataValueType,
				parameterUId: this.$UId,
				parameterId: this.$Id
			});
		},

		/**
		 * @inheritdoc Terrasoft.MappingEditMixin#getParameterEditKey
		 * @override
		 */
		getParameterEditKey: function() {
			return this.get("Id") + "-" + this.get("UId");
		},

		/**
		 * Returns a data item marker value.
		 * @returns {string}
		 */
		_getMarkerValue: function() {
			return "esn-notification-item-" + this.get("Id");
		}

		// endregion

	});

	return Terrasoft.ProcessSchemaParameterViewModel;
});


