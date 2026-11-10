define("MainHeaderSchema", ["CtiConstants", "CtiAgentStateMixin"],
		function(CtiConstants) {
			return {
				mixins: {
					CtiAgentStateMixin: Terrasoft.CtiAgentStateMixin
				},
				attributes: {
					/**
					 * ####### ### ######### #########.
					 * @private
					 * @type {String}
					 */
					"AgentState": {
						dataValueType: this.Terrasoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * Current agent state display value.
					 * @private
					 * @type {String}
					 */
					"AgentStateDisplayValue": {
						dataValueType: this.Terrasoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * ######### ######### #########.
					 * @private
					 * @type {Terrasoft.Collection}
					 */
					"AgentStates": {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
						value: null
					}
				},
				methods: {

					//region Methods: Protected

					/**
					 * @inheritdoc Terasoft.MainHeaderSchemaViewModel#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						var ctiModel = Terrasoft.CtiModel;
						if (ctiModel && ctiModel.get("IsConnected")) {
							this.onCtiPanelConnected();
						}
						this.sandbox.subscribe("AgentStateChanged", function(stateCode) {
							this.set("AgentState", stateCode);
						}, this);
						this.sandbox.subscribe("CtiPanelConnected", this.onCtiPanelConnected, this);
						this.on("change:AgentState", this.onAgentStateChanged, this);
					},

					/**
					 * ########## ############ ###### ######### ######### ### ###### #######.
					 * @protected
					 * @return {Object} ############ ###########.
					 */
					getOperatorStatusProfileIcon: function() {
						var stateCode = this.get("AgentState");
						return this.getProfileMenuStatusIcon(stateCode);
					},

					/**
					 * ############ ########## # cti #######.
					 * @protected
					 */
					onCtiPanelConnected: function() {
						this.loadAgentStatesMenu(function() {
							this.loadProfileButtonMenu();
							this.setSavedAgentState();
						});
					},

					/**
					 * Sets agent state from profile.
					 * @protected
					 */
					setSavedAgentState: function() {
						if (this.getIsFeatureDisabled("SetSavedAgentState")) {
							return;
						}
						var profile = this.getProfile() || {};
						var savedState = profile.agentState;
						if (!savedState) {
							return;
						}
						this.onOperatorStatusChange(savedState);
					},

					/**
					 * ########## ############ ########### ###### #### ######### #########.
					 * @obsolete
					 * @param {Object} image ######, # ####### ########### ########### ## #### ######.
					 * @param {String} image.value ############# ###########.
					 * @return {Object} ############ ###########.
					 */
					getAgentStateIconConfig: function(image) {
						var iconId = image && image.value;
						if (Ext.isEmpty(iconId) || this.Terrasoft.isEmptyGUID(iconId)) {
							iconId = CtiConstants.DefaultSysMsgUserStateIconId;
						}
						var iconConfig = {
							source: this.Terrasoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysMsgUserStateIcon",
								columnName: "Image",
								primaryColumnValue: iconId
							}
						};
						return {
							source: Terrasoft.ImageSources.URL,
							url: Terrasoft.ImageUrlBuilder.getUrl(iconConfig)
						};
					},

					/**
					 * ######### ###### #### ######### ######### # #### ###### #######.
					 * @protected
					 * @param {Terrasoft.Collection} agentStates ######### ######### #########.
					 * @param {Function} callback ####### ######### ######.
					 */
					generateAgentStateMenuItems: function(agentStates, callback) {
						var profileMenuCollection = this.get("ProfileMenuCollection");
						profileMenuCollection.clear();
						profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
							values: {
								Type: "Terrasoft.MenuSeparator",
								Caption: {
									bindTo: "Resources.Strings.TelephonyMenuSeparator"
								},
							}
						}));
						this.generateAgentStateMenuItemsInternal(agentStates, profileMenuCollection);
						profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
							values: {
								Type: "Terrasoft.MenuSeparator",
								Caption: ""
							}
						}));
						callback.call(this);
					},

					/**
					 * Handler of the agent state attribute change event.
					 * @protected
					 * @param {Backbone.Model} model Model.
					 * @param {String} stateCode Agent state code.
					 */
					onAgentStateChanged: function(model, stateCode) {
						this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
						this.saveProfileData(stateCode);
					},

					/**
					 * Save agent state to profile.
					 * @protected
					 * @param {String} stateCode Agent state code.
					 */
					saveProfileData: function(stateCode) {
						if (this.getIsFeatureDisabled("SetSavedAgentState") || !stateCode
								|| stateCode === Terrasoft.FinesseAgentState.LOGOUT) {
							return;
						}
						var profileData = Ext.Object.merge(this.getProfile() || {}, {"agentState": stateCode});
						Terrasoft.utils.saveUserProfile(this.getProfileKey(), profileData, false, function() {
							this.set("Profile", profileData);
						}, this);
					},

					/**
					 * Returns schema profile key.
					 * @protected
					 */
					getProfileKey: function() {
						return "MainHeaderSchemaProfile";
					},

					/**
					 * Returns operator state display value.
					 * @protected
					 */
					getOperatorStateDisplayValue: function() {
						return this.get("AgentStateDisplayValue") || Ext.emptyString;
					}

					//endregion

				},
				diff: [
					{
						"operation": "insert",
						"name": "operatorStatusIcon",
						"parentName": "UserProfileContainer",
						"propertyName": "items",
						"values": {
							"id": "view-button-operatorStatusIcon",
							"itemType": Terrasoft.ViewItemType.BUTTON,
							"selectors": {
								wrapEl: "#view-button-operatorStatusIcon"
							},
							"classes": {
								"wrapperClass": ["operator-status-icon-wrapper"],
								"pressedClass": ["pressed-button-view"],
								"imageClass": ["operator-status-icon", "view-images-class"]
							},
							"hint": {"bindTo": "getOperatorStateDisplayValue"},
							"tips": [],
							"click": {"bindTo": "onViewButtonClick"},
							"imageConfig": {"bindTo": "getOperatorStatusProfileIcon"},
							"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"iconAlign": this.Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
							"markerValue": {"bindTo": "AgentState"},
							"tag": "operatorStatusIcon"
						}
					}
				]
			};
		});
