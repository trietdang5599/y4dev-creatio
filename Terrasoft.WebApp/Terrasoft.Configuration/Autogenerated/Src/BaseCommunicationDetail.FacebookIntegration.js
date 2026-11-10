define("BaseCommunicationDetail", ["ConfigurationConstants", "FacebookClientUtilities",
		"FacebookCommunicationViewModel"], function(ConfigurationConstants) {
	return {
		attributes: {
			/**
			 * ####### ####, ### ######## ####### Facebook.
			 */
			FacebookProfileExists: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * ######## ##### ######## ###### # Facebook.
			 */
			FacebookSearchSchemaName: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: "FacebookSearchSchema"
			}
		},
		properties: {
			canDirectManageаFacebookProfile: true
		},
		mixins: {
			FacebookClientUtilities: "Terrasoft.FacebookClientUtilities"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#changeCardPageButtonsVisibility
			 * @overridden
			 */
			changeCardPageButtonsVisibility: function() {
				this.callParent(arguments);
				this.updateFacebookProfileInfo();
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#onContainerListDataLoaded
			 * @overridden
			 */
			onContainerListDataLoaded: function() {
				this.callParent(arguments);
				var collection = this.get("Collection");
				this.setCanDirectManageаFacebookProfile(collection.getItems(), this.canDirectManageаFacebookProfile);
				this.updateFacebookProfileInfo();
			},

			/**
			 * ######### ####### ####### ######## ##### # ##### Facebook.
			 * @protected
			 * @virtual
			 */
			updateFacebookProfileInfo: function() {
				var facebookCommunications =
					this.getCommunications(ConfigurationConstants.CommunicationTypes.Facebook);
				var facebookProfileExists = !facebookCommunications.isEmpty();
				this.set("FacebookProfileExists", facebookProfileExists);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#addSocialNetworkMenuItem
			 * @overridden
			 */
			addSocialNetworkMenuItem: function(socialNetworksMenuItems, menuItem) {
				this.callParent(arguments);
				if (menuItem.get("Id") === ConfigurationConstants.CommunicationTypes.Facebook) {
					this.modifyFacebookMenuItem(menuItem);
				}
			},

			/**
			 * ######## ######## ### ######## ########## ### ###### #### Facebook.
			 * @protected
			 * @param {Object} facebookMenuItem ####### ########## ### ###### #### Facebook.
			 */
			modifyFacebookMenuItem: function(facebookMenuItem) {
				facebookMenuItem.set("Click", {
					bindTo: "onFacebookMenuItemClick"
				});
			},

			/**
			 * ########## ####### ###### #### Facebook.
			 */
			onFacebookMenuItemClick: function() {
				var schemaName = this.get("FacebookSearchSchemaName");
				this._addFacebookProfile();
			},

			/**
			 * ########## ####### ###### Facebook.
			 */
			onFacebookButtonClick: function() {
				var facebookProfileExists = this.get("FacebookProfileExists");
				if (!facebookProfileExists) {
					this._addFacebookProfile()
				} else {
					this.openProfilePage(ConfigurationConstants.CommunicationTypes.Facebook);
				}
			},

			/**
			 * ######### ######## ####### ############ # ########### ## #### ######## #####.
			 * @protected
			 * @param {String} communicationType ### ######## #####.
			 */
			openProfilePage: function(communicationType) {
				var communications = this.getCommunications(communicationType);
				var firstCommunication = communications.getByIndex(0);
				var facebookLink = firstCommunication.getFacebookUrl();
				window.open(facebookLink);
			},

			/**
			 * ########## ###### ### ###### Facebook.
			 * @protected
			 * @return {String} ###### ### ###### Facebook.
			 */
			getFacebookButtonMarkerValue: function() {
				var facebookProfileExists = this.get("FacebookProfileExists");
				return facebookProfileExists ? "FacebookProfile" : "FacebookProfileSearch";
			},

			/**
			 * ######### ###### ###### # ########## #####.
			 * @protected
			 * @param {String} schemaName ######## #####, ####### ##### ############## #######.
			 */
			openSocialSearchPage: function(schemaName) {
				this.getFacebookConnector(function(connector) {
					var config = {};
					connector.checkCanOperate(config, function(response) {
						var success = response.success;
						if (!success) {
							return this.handleConnectorError(response.errorInfo, function() {
								this.loadSocialSearchModule({
									schemaName: schemaName
								});
							}, this);
						}
						this.loadSocialSearchModule({
							schemaName: schemaName
						});
					}, this);
				}, this);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#getCommunicationViewModelClassName
			 * @overridden
			 */
			getCommunicationViewModelClassName: function(communicationTypeId) {
				if (communicationTypeId === ConfigurationConstants.CommunicationTypes.Facebook) {
					return "Terrasoft.FacebookCommunicationViewModel";
				} else {
					return this.callParent(arguments);
				}
			},

			/**
			 * @private
			 */
			_addFacebookProfile: function() {
				if (this.canDirectManageаFacebookProfile) {
					this.addItem(ConfigurationConstants.CommunicationTypes.Facebook);
					return;
				}
				var schemaName = this.get("FacebookSearchSchemaName");
				this.openSocialSearchPage(schemaName);
			},

			addItem: function() {
				var item = this.callParent(arguments);
				item.set("CanDirectChangeRecord", this.canDirectManageаFacebookProfile);
				return item;
			},

			init: function () {
				this.initCanDirectManageаFacebookProfile();
				this.callParent(arguments);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "FacebookButton",
				"parentName": "SocialNetworksContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"click": {"bindTo": "onFacebookButtonClick"},
					"classes": {
						"wrapperClass": ["t-btn-full-image", "t-btn-facebook"]
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.FacebookLinkImage"},
					"markerValue": {"bindTo": "getFacebookButtonMarkerValue"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
