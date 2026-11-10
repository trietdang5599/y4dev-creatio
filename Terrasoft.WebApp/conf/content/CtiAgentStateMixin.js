Terrasoft.configuration.Structures["CtiAgentStateMixin"] = {innerHierarchyStack: ["CtiAgentStateMixin"]};
define("CtiAgentStateMixin", ["CtiConstants"],
	function(CtiConstants) {
		/**
		 * @class Terrasoft.configuration.mixins.CtiAgentStateMixin
		 * Entity connection lookup columns mixin.
		 * @type {Terrasoft.BaseObject}
		 */
		Ext.define("Terrasoft.configuration.mixins.CtiAgentStateMixin", {
			extend: "Terrasoft.core.BaseObject",
			alternateClassName: "Terrasoft.CtiAgentStateMixin",

			/**
			 * Creates and executes CTI agents state DB request.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Function} scope Callback function scope.
			 */
			executeAgentStateQuery: function(callback, scope) {
				if (!Terrasoft.SysValue.CTI.sysMsgLibId) {
					return Ext.callback(callback, scope || this);
				}
				var cacheKey = "SysMsgUserState_ProfileMenuStatuses";
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "SysMsgUserState",
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					}
				});
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Code", "Code");
				esq.addColumn("Icon", "Icon");
				esq.addColumn("IsDisplayOnly", "IsDisplayOnly");
				esq.addColumn("[SysMsgUserStateReason:SysMsgUserState].Code", "StateReasonCode");
				esq.addColumn("[SysMsgUserStateReason:SysMsgUserState].Name", "StateReasonName");
				esq.filters.add("filterSysMsgUserState", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL,
						"[SysMsgUserStateInLib:SysMsgUserState].SysMsgLib",
						Terrasoft.SysValue.CTI.sysMsgLibId));
				esq.getEntityCollection(callback, scope);
			},

			/**
			 * Handles CTI agents state DB request result.
			 * @protected
			 * @param {Object} result Request result object.
			 * @param {Function} callback Callback function.
			 * @param {Function} scope Callback function scope.
			 */
			onAgentStateQueryLoaded: function(result, callback, scope) {
				var agentStates = this.getAgentStates(result);
				this.set("AgentStates", agentStates);
				var ctiModel = Terrasoft.CtiModel;
				if (ctiModel) {
					var stateCode = ctiModel.get("AgentState");
					this.set("AgentState", stateCode);
					this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
				}
				this.generateAgentStateMenuItems(agentStates, callback, scope);
			},

			/**
			 * Loads CTI agents state menu.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Function} scope Callback function scope.
			 */
			loadAgentStatesMenu(callback, scope) {
				this.executeAgentStateQuery(function(result) {
					this.onAgentStateQueryLoaded(result, callback, scope);
				}, this);
			},

			/**
			 * Returns agent state display value by code.
			 * @protected
			 * @param {String} stateCode Code of the agent state.
			 * @return {String} Agent state display value.
			 */
			getAgentStateDisplayValue: function(stateCode) {
				var agentStates = this.get("AgentStates");
				if (Ext.isEmpty(agentStates)) {
					return CtiConstants.LocalizableStrings.ActiveAgentStateCaption;
				}
				var agentState = agentStates.find(stateCode);
				var agentStateDisplayValue = Ext.isEmpty(agentState) 
					? CtiConstants.LocalizableStrings.ActiveAgentStateCaption
					: agentState.displayValue;
				return agentStateDisplayValue;
			},

			/**
			 * Returns the configuration of the operator state menu icon.
			 * @protected
			 * @param {String} iconId Image ID.
			 * @param {String} schemaName Entity schema name.
			 * @param {String} columnName Entity column name.
			 * @return {Object} Image config.
			 */
			getIconConfig: function (imageId, schemaName, columnName) {
				if (Ext.isEmpty(imageId) || Terrasoft.isEmptyGUID(imageId)) {
					imageId = CtiConstants.DefaultSysMsgUserStateIconId;
				}
				const iconConfig = {
					source: Terrasoft.ImageSources.ENTITY_COLUMN,
					params: {
						schemaName: schemaName,
						columnName: columnName,
						primaryColumnValue: imageId
					}
				};
				return {
					source: Terrasoft.ImageSources.URL,
					url: Terrasoft.ImageUrlBuilder.getUrl(iconConfig)
				};
			},

			/**
			 * Returns the configuration of current agent state icon.
			 * @protected
			 * @param {String} stateCode Code of the agent state.
			 * @return {Object} Image config.
			 */
			getProfileMenuStatusIcon: function(stateCode) {
				var agentStates = this.get("AgentStates");
				var agentState = agentStates && agentStates.find(stateCode);
				return agentState 
					? agentState.iconConfig
					: this.getIconConfig(CtiConstants.ActiveSysMsgUserStateIconId, "SysMsgUserStateIcon", "Image");
			},

			/**
			 * Creates cti agent state config collection using DB request result.
			 * @protected
			 * @param {Object} agentStatesQueryResult Cti agent state DB request result.
			 * @returns {Terrasoft.Collection} Cti agent state config collection.
			 */
			getAgentStates: function(agentStatesQueryResult) {
				var agentStates = new Terrasoft.Collection();
				if (!agentStatesQueryResult) {
					return agentStates;
				}
				agentStatesQueryResult.collection.each(function(item) {
					var valueCode = item.get("Code");
					var image = item.get("Icon");
					var agentState = agentStates.find(valueCode);
					if (!agentState) {
						agentState = {
							value: item.get("Id"),
							displayValue: item.get("Name"),
							code: valueCode,
							iconConfig: this.getIconConfig(image && image.value,
								"SysMsgUserStateIcon", "Image"),
							isDisplayOnly: item.get("IsDisplayOnly"),
							reasons: null
						};
						agentStates.add(valueCode, agentState);
					}
					var stateReasonCode = item.get("StateReasonCode");
					if (Ext.isEmpty(stateReasonCode)) {
						return;
					}
					var stateReasonName = item.get("StateReasonName");
					agentState.reasons = agentState.reasons || new Terrasoft.Collection();
					agentState.reasons.add(stateReasonCode, {
						code: stateReasonCode,
						displayValue: stateReasonName
					});
				}, this);
				return agentStates;
			},

			/**
			 * Creates cti agent state menu items.
			 * @protected
			 * @param {Terrasoft.Collection} agentStates Cti agent state config collection.
			 * @param {Terrasoft.BaseViewModelCollection} menuCollection Menu items collection.
			 */
			generateAgentStateMenuItemsInternal: function(agentStates, menuCollection) {
				agentStates.each(function(item) {
					if (item.isDisplayOnly) {
						return true;
					}
					var hasReasons = !this.Ext.isEmpty(item.reasons);
					var menuItem = this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Caption: item.displayValue,
							MarkerValue: item.displayValue,
							Tag: item.code,
							ImageConfig: this.getProfileMenuStatusIcon(item.code),
							Click: hasReasons ? null : {bindTo: "onOperatorStatusChange"},
							Items: hasReasons ? this.getAgentStateReasons(item.code, item.reasons) : null
						}
					});
					menuCollection.addItem(menuItem);
				}, this);
			},

			/**
			 * Creates cti agent state change reasons menu items.
			 * @protected
			 * @param {String} stateCode Code of the agent state.
			 * @param {Terrasoft.Collection} reasons Cti agent state change reasons config collection.
			 * @return {Terrasoft.BaseViewModelCollection} Menu items collection.
			 */
			getAgentStateReasons: function(stateCode, reasons) {
				var reasonCollection = this.Ext.create("Terrasoft.BaseViewModelCollection");
				reasons.each(function(reason) {
					reasonCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Caption: reason.displayValue,
							Tag: stateCode + "/" + reason.code,
							Click: {bindTo: "onOperatorStatusReasonChange"}
						}
					}));
				}, this);
				return reasonCollection;
			},

			/**
			 * Cti agent state change handler.
			 * @protected
			 * @param {Object} tag agent state config object.
			 */
			onOperatorStatusChange: function(tag) {
				var ctiModel = Terrasoft.CtiModel;
				ctiModel.setAgentState(tag);
			},

			/**
			 * Cti agent state and reason change handler.
			 * @protected
			 * @param {Object} tag agent state config object.
			 */
			onOperatorStatusReasonChange: function(tag) {
				var tagParams = tag.split("/");
				var agentState = tagParams[0];
				var agentStateReasonCode = tagParams[1];
				var ctiModel = Terrasoft.CtiModel;
				ctiModel.setAgentState(agentState, agentStateReasonCode);
			}
		});
	});


