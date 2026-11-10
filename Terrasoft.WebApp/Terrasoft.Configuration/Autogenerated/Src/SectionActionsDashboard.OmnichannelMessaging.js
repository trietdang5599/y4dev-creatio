define("SectionActionsDashboard", ["SectionActionsDashboardResources", "OmnichannelConsts",
	"SocialMessagePublisherModule", "css!OmnichannelSectionActionsDashboardCSS"],
	function (resources, OmnichannelConsts) {
		return {
			attributes: {
				/**
				 * List of suggested contacts to chat with.
				 */
				"ChatContactsMenuItems": {
					"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
					"value": []
				},

				/**
				 * Flag that shows if Tip opened in 'menu' mode.
				 */
				"IsTipMenuMode": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Current selected omnichannel provider AD channel.
				 */
				"ActiveOmniProvider": {
					"dataValueType": Terrasoft.DataValueType.GUID
				},

				/**
				 * Identifier of DOM element relative to which the tip will be aligned.
				 */
				"AlignTipToElId": {
					"dataValueType": Terrasoft.DataValueType.TEXT
				},

				/**
				 * Stores state of tip visibility,
				 */
				"IsTipVisible": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Stores state of chat component loading.
				 */
				"IsChatComponentLoaded": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			messages: {
				/**
				 * @message OpenChatWithContact
				 * Notify about start conversation with contact.
				 * @param {Guid} Contact identifier.
				 */
				"OpenChatWithContact": {
					"mode": Terrasoft.MessageMode.BROADCAST,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},
			},
			properties: {
				/**
				 * Tip element for displaying omnichannel info.
				 */
				tabTip: {}
			},
			mixins: {
				customEvent: "Terrasoft.CustomEventDomMixin"
			},
			methods: {

				/**
				 * @inheritDoc Terrasoft.ActionsDashboard#getExtendedConfig
				 * @overridden
				 */
				getExtendedConfig: function () {
					let config = this.callParent(arguments);
					const lczImages = resources.localizableImages;
					this.Terrasoft.each(OmnichannelConsts.ChannelProviders, function (id, name) {
						config[name + "MessageTab"] = {
							"Id": name + "-message-tab-" + id,
							"ImageSrc": this.Terrasoft.ImageUrlBuilder.getUrl(lczImages[name + "MessageTabImage"]),
							"MarkerValue": name + "-message-tab",
							"Align": this.Terrasoft.Align.RIGHT,
							"Visible": this._getTabsVisibility(),
							"Tag": name
						};
					}, this);
					return config;
				},

				/**
				 * @inheritDoc Terrasoft.SectionActionsDashboard#onDefaultValuesInitialized
				 * @overridden
				 */
				onDefaultValuesInitialized: function () {
					this.callParent(arguments);
					const components =  [
						"mf!OmnichannelMessagingComponent",
						"css-ltr!OmnichannelMessagingComponentStyles"
					];
					this.Terrasoft.require(components, function () {
						this.set("IsChatComponentLoaded", true);
					}, this);
				},

				/**
				 * @private
				 */
				_getTabTipConfig: function (alignToEl) {
					return {
						displayMode: Terrasoft.controls.TipEnums.displayMode.WIDE,
						hide: function () {
							this.destroy();
						},
						initialAlignType: Terrasoft.AlignType.BOTTOM,
						alignToEl: alignToEl,
						visible: { bindTo: "IsTipVisible" },
						id: "omnichannel-contacts-tooltip",
						items: [{
							className: "Terrasoft.Menu",
							ulClass: "ad-tooltip-menu",
							scrollWrapperClass: "menu-scroll-wrapper",
							hide: { bindTo: "hideTipOnMenuClosed" },
							items: this.$ChatContactsMenuItems,
							visible: { bindTo: "IsTipMenuMode" }
						}]
					};
				},

				/**
				 * Hides tip when menu closed.
				 * @protected
				 */
				hideTipOnMenuClosed: function () {
					this.$IsTipVisible = false;
				},

				/**
				 * Get omnichannel contacts list menu item.
				 * @param contactConfig Menu item config.
				 * @returns {Object} Menu item.
				 */
				getContactMenuItem: function (contactConfig) {
					var config =
					{
						caption: contactConfig.displayValue || "",
						tag: contactConfig.value,
						click: {
							bindTo: "onMenuItemClick"
						},
					};
					if (contactConfig.photo) {
						config.imageConfig = {
							source: Terrasoft.ImageSources.URL,
							url: Terrasoft.ImageUrlBuilder.getUrl({
								source: this.Terrasoft.ImageSources.ENTITY_COLUMN,
								params: {
									schemaName: "SysImage",
									columnName: "Data",
									primaryColumnValue: contactConfig.photo
								}
							})
						}
					}
					return config;
				},

				/**
				 * Tries to open chat with found contact.
				 */
				openChatForChannel: function () {
					this.getContactsList(function () {
						this.onChatContactListFilled();
					});
				},

				/**
				 * Handler of omnichat contacts list filled.
				 */
				onChatContactListFilled: function () {
					if (this.$ChatContactsMenuItems.length === 0) {
						this.showTextTip(this.getNoContactForChatMessage());
						return;
					}
					if (this.$ChatContactsMenuItems.length === 1) {
						this.openChatWithContact(this.$ChatContactsMenuItems[0].tag);
						return;
					}
					this.showContactList();
				},

				/**
				 * Returns 'Contact(s) not found' message dependent on section entity schema.
				 * @returns {String} Message.
				 */
				getNoContactForChatMessage: function () {
					switch (this.$entitySchemaName) {
						case "Contact":
						case "Case":
						case "Lead":
						case "OmniChat":
							return this.get("Resources.Strings.NoContactForChatMessage");
						default:
							return this.get("Resources.Strings.NoContactsForChatMessage");
					}
				},

				/**
				 * Shows list of contacts.
				 * @protected
				 */
				showContactList: function () {
					const popupList = document.createElement("ts-popup-contact-list");
					const contacts = this.$ChatContactsMenuItems.map(el => {
						return {
							id: el.tag,
							name: el.caption,
							photo: el.imageConfig?.url
						}
					});
					this.Ext.get(this.$AlignTipToElId).appendChild(popupList);
					popupList.addEventListener("contactClick", (eventData) => {
						this.openChatWithContact(eventData.detail.contactId)
					});
					this.mixins.customEvent.publish("SetContactList", contacts, this);
				},

				/**
				 * Shows tip with text.
				 * @param {String} text Tip text.
				 * @protected
				 */
				showTextTip: function (text) {
					this.$IsTipMenuMode = false;
					this.tabTip = this._getTabTipControl();
					this.tabTip.setContent(text);
					this.tabTip.show();
				},

				/**
				 * Fetches list of contacts to chat depending on current section entity schema.
				 * @param callback
				 */
				getContactsList: function (callback) {
					let contactId;
					switch (this.$entitySchemaName) {
						case "Contact":
							contactId = this.getContactId();
							this.$ChatContactsMenuItems = contactId &&
								[this.getContactMenuItem({ value: contactId })] || [];
							break;
						case "Case":
						case "OmniChat":
							contactId = this.getContactId("Contact");
							this.$ChatContactsMenuItems = contactId &&
								[this.getContactMenuItem({ value: contactId })] || [];
							break;
						case "Lead":
							contactId = this.getContactId("QualifiedContact");
							this.$ChatContactsMenuItems = contactId &&
								[this.getContactMenuItem({ value: contactId })] || [];
							break;
						case "Account":
							this.getOmnichannelContactsOfAccount(function () {
								callback.call(this);
							});
							return;
						case "Opportunity":
							this.getOmnichannelContactsOfOpportunity(function () {
								callback.call(this);
							});
							return;
						default:
							this.$ChatContactsMenuItems = this.getDefaultContacts();
					}
					callback.call(this);
				},

				/**
				 * Handles click by menu item.
				 * @param {String} tag Clicked element tag.
				 * @protected
				 */
				onMenuItemClick: function (tag) {
					this.tabTip.hide();
					this.$IsTipVisible = false;
					this.openChatWithContact(tag);
				},

				/**
				 * @private
				 */
				_getTabsVisibility: function () {
					return !this.Terrasoft.isCurrentUserSsp();
				},

				/**
				 * Returns tip to display after messenger tab click.
				 */
				_getTabTipControl: function () {
					const wrapEl = Ext.get(this.$AlignTipToElId);
					const config = this._getTabTipConfig(wrapEl);
					const tabTip = Ext.create("Terrasoft.Tip", config);
					tabTip.bind(this);
					this.$IsTipVisible = true;
					return tabTip;
				},

				/**
				 * @inheritDoc Terrasoft.ActionsDashboard#onActiveTabChange
				 * @overridden
				 */
				onActiveTabChange: function (activeTab) {
					const messageType = activeTab.get("Name").replace("MessageTab", "");
					const providerId = OmnichannelConsts.ChannelProviders[messageType];
					if (providerId) {
						if (!this.$IsChatComponentLoaded) {
							return;
						}
						this.$AlignTipToElId = activeTab.$Id;
						this.$ActiveOmniProvider = providerId;
						this._backToPreviousTab(activeTab);
						this.openChatForChannel(providerId);
					} else {
						this.callParent(arguments);
					}
				},
	
				/**
				 * Open chat with specified contact via specified channel.
				 * @param contactId Id of contact to chat.
				 */
				openChatWithContact: function (contactId) {
					this.callService(this.getServiceConfig(this.$ActiveOmniProvider, contactId), function (response) {
						if (response && response.success) {
							if (Terrasoft.isAngularHost) {
								this.mixins.customEvent.publish("RightPanelContactChat", Terrasoft.encode({
									Header: {
										Sender: "RightPanelContactChat",
									},
									Body: {
										ChatId: response.lastChatId
									}
								}));
							} else {
								this.sandbox.publish("OpenChatWithContact", response.lastChatId);
							}

						} else {
							const errorMessage = response && response.errorInfo && response.errorInfo.message;
							this.showTextTip(errorMessage ||
								this.get("Resources.Strings.SendToChatContactErrorMessage"));
						}
					}, this);
				},

				/**
				 * Returns config to contact service.
				 * @param {String} providerId Identifier of channel provider.
				 * @param {String} contactId Identifier of current contact.
				 */
				getServiceConfig: function (providerId, contactId) {
					return {
						serviceName: "OmnichannelContactService",
						methodName: "GetLastChatId",
						data: {
							providerId,
							contactId
						}
					};
				},

				/**
				 * @private
				 */
				_backToPreviousTab: function (activeTab) {
					const previousTabName = this.$ActiveTabName;
					this.setActiveTab(activeTab.get("Name"));
					this.setActiveTab(previousTabName);
				},

				/**
				 * Returns identifier of contact.
				 * @protected
				 * @returns {Guid} Contact identifier.
				 */
				getContactId: function (columnName) {
					let masterValue = this.getMasterEntityParameterValue(columnName || "Id");
					return masterValue.value || masterValue;
				},

				/**
				 * @inheritDoc Terrasoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @overridden
				 */
				getSectionPublishers: function () {
					let publishers = this.callParent(arguments);
					publishers = publishers.concat(this._providers);
					return publishers;
				},

				/**
				 * Returns list of contacts from master entity.
				 * @protected
				 */
				getDefaultContacts: function () {
					const entitySchema = this.get("EntitySchema");
					const schemaColumns = entitySchema && entitySchema.columns;
					let contactColumns = [];
					if (schemaColumns) {
						this.Terrasoft.each(schemaColumns, function (column) {
							if (this.isContactReferenceColumn(column)) {
								contactColumns.push(column.columnPath);
							}
						}, this);
					}
					return this.loadReferenceColumnsValues(contactColumns);
				},

				/**
				 * Returns true if column is reference to contact entity.
				 * @param {Object} column Column from master entity.
				 * @protected
				 */
				isContactReferenceColumn: function (column) {
					return column.isLookup && column.referenceSchemaName === this.getReferenceColumnSchemaName() &&
						this.excludedReferenceColumns().indexOf(column.columnPath) === -1;
				},

				/**
				 * Returns list of columns to be included while loading from master entity.
				 * @protected
				 */
				excludedReferenceColumns: function () {
					return ["ModifiedBy", "CreatedBy"];
				},

				/**
				 * Loads column values by given column names from master entity.
				 * @param {Array} columnsName Column names from master entity.
				 * @protected
				 */
				loadReferenceColumnsValues: function (columnsName) {
					let columnValues = [];
					this.Terrasoft.each(columnsName, function (columnName) {
						const columnValue = this.getMasterEntityParameterValue(columnName);
						if (columnValue) {
							columnValues.push(this.getContactMenuItem({
								displayValue: columnValue.displayValue,
								image: columnValue.primaryImageValue,
								value: columnValue.value
							}));
						}
					}, this);
					return columnValues;
				},

				/**
				 * Returns reference column schema name.
				 * @protected
				 */
				getReferenceColumnSchemaName: function () {
					return "Contact";
				},

				/**
				 * @protected
				 * Fetches contacts from account for omnichannel chat.
				 * @param callback Callback function on contacts fetched.
				 */
				getOmnichannelContactsOfAccount: function (callback) {
					this.$ChatContactsMenuItems = [];

					let accountId = this.getMasterEntityParameterValue("Id");
					const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "Contact"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("Photo");
					esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Account", accountId));
					esq.execute(function (response) {
						if (response.success && !response.collection.isEmpty()) {
							Terrasoft.each(response.collection.getItems(), function (item) {
								this.$ChatContactsMenuItems.push(this.getContactMenuItem({
									value: item.$Id,
									displayValue: item.$Name,
									photo: item.$Photo && item.$Photo.value || null
								}));
							}, this);
						}
						callback.call(this);
					}, this);
				},

				/**
				 * @protected
				 * Fetches contacts from opportunity for omnichannel chat.
				 * @param callback Callback function on contacts fetched.
				 */
				getOmnichannelContactsOfOpportunity: function (callback) {
					this.$ChatContactsMenuItems = [];

					let opportunityId = this.getMasterEntityParameterValue("Id");
					const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityContact"
					});
					esq.addColumn("Contact.Id", "ContactId");
					esq.addColumn("Contact.Name", "ContactName");
					esq.addColumn("Contact.Photo", "ContactPhoto");
					esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Opportunity", opportunityId));
					esq.execute(function (response) {
						if (response.success && !response.collection.isEmpty()) {
							Terrasoft.each(response.collection.getItems(), function (item) {
								this.$ChatContactsMenuItems.push(this.getContactMenuItem({
									value: item.$ContactId,
									displayValue: item.$ContactName,
									photo: item.$ContactPhoto && item.$ContactPhoto.value || null
								}));
							}, this);
						}
						callback.call(this);
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "FacebookMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"visible": { "bindTo": "_getTabsVisibility" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TelegramMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"visible": { "bindTo": "_getTabsVisibility" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "WhatsAppMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"visible": { "bindTo": "_getTabsVisibility" },
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
