define("ChatContactDuplicatesDetailViewModel", ["NetworkUtilities", "ChatContactDuplicatesDetailViewModelResources",
	"ServiceHelper", "DuplicatesDetailViewModelV2", "css!ChatContactDuplicatesDetailViewModel"],
	function (NetworkUtilities, resources, ServiceHelper) {
	Ext.define("Terrasoft.configuration.ChatContactDuplicatesDetailViewModel", {
		extend: "Terrasoft.DuplicatesDetailViewModel",
		alternateClassName: "Terrasoft.ChatContactDuplicatesDetailViewModel",

		// region Methods: Private

		/**
		 * @private
		 */
		_isCurrent: function(item) {
			return item.id === this.get("currentContactId").toLowerCase();
		},

		/**
		 * @private
		 */
		_getContactUrl: function(contactId) {
			const config = {
				entitySchema: this.entitySchemaName,
				primaryColumnValue: contactId,
				operation: Terrasoft.ConfigurationEnums.CardOperation.EDIT
			};
			return (Terrasoft.isAngularHost ? "#" : "ViewModule.aspx#") + NetworkUtilities.getEntityUrl(config);
		},

		// endregion

		// region Methods: Protected

		/**
		 * @protected
		 */
		getCurrentLabelConfig: function() {
			return {
				"className": "Terrasoft.Label",
				"caption": resources.localizableStrings.CurrentContactLabel,
				"classes": {
					"labelClass": ["current-entity-label"]
				}
			};
		},

		/**
		 * @protected
		 */
		getContactNameConfig: function(item) {
			return {
				"className": "Terrasoft.Hyperlink",
				"href": this._getContactUrl(item.id),
				"caption": {"bindTo": item.columnName.bindTo},
				"classes": {
					"hyperlinkClass": ["contact-name-link"]
				},
				"target": this.Terrasoft.controls.HyperlinkEnums.target.SELF
			};
		},

		// endregion

		// region Methods: Public

		/**
		 * Applies custom control config to the row
		 * @param {Object} control Configuration object.
		 * @param {Object} item Item of grid row element.
		 */
		applyControlConfig: function(control, item) {
			const configItems = [this.getContactNameConfig(item)];
			if (this._isCurrent(item)) {
				configItems.push(this.getCurrentLabelConfig());
			}
			control.config = {
				"className": "Terrasoft.Container",
				"classes": {
					"wrapClassName": ["contact-name-container"]
				},
				"items": configItems
			};
		},

		/**
		 * @inheritdoc DuplicatesDetailViewModelV2#mergeEntityDuplicatesAsync
		 * @override
		 */
		mergeEntityDuplicatesAsync: function () {
			this.callParent(arguments);
			ServiceHelper.callService("OmnichannelChatService", "ClearContactIdentityCache", Ext.emptyFn, {
				contactIds: this.get("SelectedRows")
			}, this);
		},

		/**
		 * @override
		 */
		isBulkESDeduplicationEnabled: function () {
			return false;
		}
		
		// endregion

	});
});
