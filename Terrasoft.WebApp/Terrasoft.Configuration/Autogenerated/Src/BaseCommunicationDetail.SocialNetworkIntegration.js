define("BaseCommunicationDetail", ["CommunicationUtils", "SocialSearch"], function(CommunicationUtils) {
	return {
		attributes: {
			SocialSearchModuleId: {dataValueType: Terrasoft.DataValueType.TEXT}

		},
		messages: {
			/**
			 * @message
			 * ########## ######### ### ######### ########## # ######## ### ######.
			 */
			"GetDetailInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message
			 * ########## ######### ######### ######### ####### ########.
			 */
			"PushHistoryState": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SearchResultBySocialNetworks
			 * ######## ######### ###### ## ########## #####.
			 */
			"SearchResultBySocialNetworks": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("SearchResultBySocialNetworks", this.onSearchResultBySocialNetworks, this);
			},

			/**
			 * ############ ######### ###### ####### ###### # ########## ####.
			 * @private
			 * @param {Object} searchResult ######### ###### ####### ###### # ########## ####.
			 * @param {Terrasoft.Collection} searchResult.selectedItems ######### ######### ####### ## ######## ######.
			 */
			onSearchResultBySocialNetworks: function(searchResult) {
				var collection = searchResult.selectedItems;
				collection.each(function(item) {
					var newItem = this.addItem(item.get("CommunicationType"));
					newItem.set("Number", item.get("Name"));
					newItem.set("SocialMediaId", item.get("Id"));
				}, this);
			},

			/**
			 * ########## ############### ## #### ######## ##### ######### ###### ######.
			 * @protected
			 * @param {String} communicationTypeFilter ### ######## #####.
			 * @return {Terrasoft.Collection} ############### ## #### ######## ##### ######### ###### ######.
			 */
			getCommunications: function(communicationTypeFilter) {
				var collection = this.get("Collection");
				var filteredCollection = collection.filterByFn(function(communication) {
					var communicationType = communication.get("CommunicationType");
					if (!communicationType) {
						return false;
					}
					return (communicationType.value === communicationTypeFilter);
				});
				return filteredCollection;
			},

			/**
			 * ######### ###### ###### # ########## #####.
			 * @protected
			 * @param {Object} config ######### ######## ######.
			 * @param {String} config.schemaName ######## #####, ####### ##### ############## #######.
			 */
			loadSocialSearchModule: function(config) {
				var moduleId = this.sandbox.id + "_SocialSearch";
				var detailInfo = this.getDetailInfo();
				var moduleConfig = {
					moduleId: moduleId,
					moduleName: "SocialSearch",
					stateObj: {},
					instanceConfig: {
						isSchemaConfigInitialized: true,
						schemaName: config.schemaName,
						searchQuery: detailInfo.masterRecordDisplayValue
					}
				};
				this.sandbox.publish("OpenCard", moduleConfig, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCommunicationDetail#addMenuItem
			 * @overridden
			 */
			addMenuItem: function(typeMenuItems, communicationType) {
				var value = communicationType.get("Id");
				if (CommunicationUtils.isSocialNetworkType(value)) {
					return;
				}
				this.callParent(arguments);
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SocialNetworksContainer",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"visible": {"bindTo": "getToolsVisible"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["social-networks-container"],
					"items": []
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
