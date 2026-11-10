 define("BR7xCaseDesignerViewModel", ["BR7xCaseDesignerViewModelResources", "BR7xElementDesignerViewModel",
	 "BR7xConditionGroupDesignerViewModel",
 ], function(resources) {

	Ext.define("Terrasoft.Designers.BR7xCaseDesignerViewModel", {
		extend: "Terrasoft.BR7xElementDesignerViewModel",
		alternateClassName: "Terrasoft.BR7xCaseDesignerViewModel",

		columns: {
			/**
			 * Case condition group.
			 * @type {Terrasoft.BR7xConditionGroupDesignerViewModel}
			 */
			"ConditionGroup": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Add icon enabled image.
			 * @type {Object}
			 */
			"AddIconEnabled": {
				"dataValueType": Terrasoft.DataValueType.IMAGE,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": resources.localizableImages.AddIconEnabled
			},
			/**
			 * Add condition button caption.
			 * @type {String}
			 */
			"AddConditionButtonCaption": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": resources.localizableStrings.AddConditionButtonCaption
			}
		},

		/**
		 * Prepares condition collection from meta item.
		 * @protected
		 */
		prepareConditionGroup: function(callback, scope) {
			var metaItem = this.getMetaItem();
			var conditionGroup = this.createBusinessRuleConditionGroupViewModel({
				MetaItem: metaItem.getPropertyValue("condition"),
				MetaItemType: "BusinessRuleConditionGroup"
			});
			conditionGroup.on("itemCollectionChanged", this.updateCanAddConditionProperty, this);
			this.set("ConditionGroup", conditionGroup);
			conditionGroup.waitLoaded(callback, scope);
		},

		/**
		 * Creates business rule condition designer view model.
		 * @protected
		 * @param {Object} columnValues Column values.
		 * @return {Terrasoft.BR7xConditionGroupDesignerViewModel} Business rule condition designer view model.
		 */
		createBusinessRuleConditionGroupViewModel: function(columnValues) {
			return this.createItemViewModel("Terrasoft.BR7xConditionGroupDesignerViewModel", columnValues);
		},

		/**
		 * Updates condition meta item.
		 * @protected
		 */
		updateConditionMetaItem: function(next, metaItem) {
			var conditionGroupViewModel = this.get("ConditionGroup");
			conditionGroupViewModel.updateMetaItem(function() {
				metaItem.setPropertyValue("condition", conditionGroupViewModel.getMetaItem());
				next();
			}, this);
		},

		/**
		 * @inheritdoc Terrasoft.BR7xElementDesignerViewModel#getMetaItemUpdaters
		 * @overridden
		 */
		getMetaItemUpdaters: function() {
			var updaters = this.callParent(arguments);
			updaters.push(this.updateConditionMetaItem);
			return updaters;
		},

		/**
		 * Unsubscribe condition group events.
		 * @protected
		 */
		unsubscribeConditionGroupEvents: function() {
			var conditionGroup = this.get("ConditionGroup");
			conditionGroup.un("itemCollectionChanged", this.updateCanAddConditionProperty, this);
		},

		/**
		 * @inheritdoc Terrasoft.Component#onDestroy
		 * @protected
		 */
		onDestroy: function() {
			this.unsubscribeConditionGroupEvents();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.prepareConditionGroup(function() {
				this.completeLoaded();
			}, this);
			this.updateCanAddConditionProperty();
		},

		/**
		 * Adds condition.
		 */
		addCondition: function() {
			var conditionGroup = this.get("ConditionGroup");
			conditionGroup.addEmptyCondition();
		},

		/**
		 * Returns condition button image.
		 * @return {Object} Condition button image.
		 */
		getConditionIcon: function() {
			return this.get("AddIconEnabled");
		},

		/**
		 * Returns is can add condition.
		 * @protected
		 * @return {Boolean} Can add condition.
		 */
		updateCanAddConditionProperty: function() {
			var conditionGroup = this.get("ConditionGroup");
			if (conditionGroup) {
				var conditions = conditionGroup.get("Items");
				var visible = conditions && !conditions.isEmpty();
				conditionGroup.set("Visible", visible);
				this.onItemViewModelChange();
			}
		},

		/**
		 * @inheritdoc Terrasoft.BR7xElementDesignerViewModel#getAsyncValidateList
		 * @overridden
		 */
		getAsyncValidators: function() {
			var validationMethods = this.callParent();
			validationMethods.push(this.validateCase, this.asyncValidateConditionGroup);
			return validationMethods;
		},

		/**
		 * Async validate condition group.
		 * @param {Function} next Callback method.
		 * @param {Object} Validation info.
		 */
		asyncValidateConditionGroup: function(next, validationInfo) {
			var conditionGroup = this.get("ConditionGroup");
			if (Ext.isEmpty(conditionGroup)) {
				next(validationInfo);
				return;
			}
			conditionGroup.asyncValidate(function(groupValidationInfo) {
				this.applyValidationInfo(validationInfo, groupValidationInfo);
				next(validationInfo);
			}, this);
		},

		/**
		 * Validate case.
		 * @param {Function} callback Callback function.
		 * @param {Object} validationInfo Validation information.
		 */
		validateCase: function(callback, validationInfo) {
			var conditionGroup = this.get("ConditionGroup");
			var conditions = conditionGroup.get("Items");
			var countCondition = conditions.getCount();
			if (countCondition === 0) {
				validationInfo.isValid = false;
				validationInfo.messageList.push(resources.localizableStrings.InvalidConditionCountMessage);
			}
			callback.call(this, validationInfo);
		},

		createMetaItem: function() {
			return Ext.create("Terrasoft.BusinessRuleCase");
		}

	});

	return Terrasoft.BR7xCaseDesignerViewModel;
});
