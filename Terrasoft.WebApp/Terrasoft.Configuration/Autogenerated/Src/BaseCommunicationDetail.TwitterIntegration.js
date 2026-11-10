define("BaseCommunicationDetail", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		attributes: {
			TwitterConnectorInitialized: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * ####### ####, ### ######## ####### Twitter.
			 */
			TwitterProfileExists: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			}
		},

		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#changeCardPageButtonsVisibility
			 * @overridden
			 */
			changeCardPageButtonsVisibility: function() {
				this.callParent(arguments);
				this.updateTwitterProfileInfo();
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#onContainerListDataLoaded
			 * @overridden
			 */
			onContainerListDataLoaded: function() {
				this.callParent(arguments);
				this.updateTwitterProfileInfo();
			},

			/**
			 * ######### ####### ####### ######## ##### # ##### Twitter.
			 * @protected
			 * @virtual
			 */
			updateTwitterProfileInfo: function() {
				var twitterCommunications =
						this.getCommunications(ConfigurationConstants.CommunicationTypes.Twitter);
				var twitterProfileExists = !twitterCommunications.isEmpty();
				this.set("TwitterProfileExists", twitterProfileExists);
			},

			/**
			 * ########## ####### ###### Twitter.
			 */
			onTwitterButtonClick: function() {
				var communicationType = ConfigurationConstants.CommunicationTypes.Twitter;
				var twitterCommunication = this.addItem(communicationType);
				twitterCommunication.getSocialNetworkAccountsCount({value: communicationType},
						function(accountsCount) {
							if (accountsCount === 0) {
								twitterCommunication.handleMissingSocialNetworkAccount("Twitter");
								twitterCommunication.deleteItem();
								return;
							} else {
								twitterCommunication.onLookUpClick();
							}
						}, this);
			},

			/**
			 * ########## ####### ###### #### Twitter.
			 */
			onTwitterMenuItemClick: function() {
				this.onTwitterButtonClick();
			},

			/**
			 * ########## ###### ### ###### Twitter.
			 * @protected
			 * @return {String} ###### ### ###### Twitter.
			 */
			getTwitterButtonMarkerValue: function() {
				var twitterProfileExists = this.get("TwitterProfileExists");
				return twitterProfileExists ? "TwitterProfile" : "TwitterProfileSearch";
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#addSocialNetworkMenuItem
			 * @overridden
			 */
			addSocialNetworkMenuItem: function(socialNetworksMenuItems, menuItem) {
				this.callParent(arguments);
				if (menuItem.get("Id") === ConfigurationConstants.CommunicationTypes.Twitter) {
					this.modifyTwitterMenuItem(menuItem);
				}
			},

			/**
			 * ######## ######## ### ######## ########## ### ###### #### Twitter.
			 * @protected
			 * @param {Object} twitterMenuItem ####### ########## ### ###### #### Twitter.
			 */
			modifyTwitterMenuItem: function(twitterMenuItem) {
				twitterMenuItem.set("Click", {
					bindTo: "onTwitterMenuItemClick"
				});
				twitterMenuItem.set("Enabled", {
					bindTo: "getTwitterButtonEnabled"
				});
			},

			/**
			 * ########## ########### ###### #### Twitter.
			 * @protected
			 * @return {#oolean} ########### ###### #### Twitter.
			 */
			getTwitterButtonEnabled: function() {
				var twitterButtonEnabled = !this.get("TwitterProfileExists");
				return twitterButtonEnabled;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "TwitterButton",
				"parentName": "SocialNetworksContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"click": {"bindTo": "onTwitterButtonClick"},
					"enabled": {
						"bindTo": "getTwitterButtonEnabled"
					},
					"classes": {
						"wrapperClass": ["t-btn-full-image", "t-btn-twitter"]
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.TwitterLinkImage"},
					"markerValue": {"bindTo": "getTwitterButtonMarkerValue"},
					"visible": {"bindTo": "TwitterConnectorInitialized"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
