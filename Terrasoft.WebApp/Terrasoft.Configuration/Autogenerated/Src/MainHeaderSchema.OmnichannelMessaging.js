define("MainHeaderSchema", ["RightUtilities"], function (RightUtilities) {
	return {
		properties: {
			omnichannelOperatorServiceName: "OmnichannelOperatorService",
			operatorStateSchemaName: "OperatorState"
		},
		attributes: {
			/**
			 * The current operator state code.
			 * @private
			 * @type {String}
			 */
			"OperatorState": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: Terrasoft.emptyString
			},

			/**
			 * A collection of operator states.
			 * @private
			 * @type {Terrasoft.Collection}
			 */
			"OperatorStates": {
				dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},

			/**
			 * User has omnichannel license operation.
			 * @type {Boolean}
			 */
			"HasOmnichannelLicOperation": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Current user has omnichannel rights.
			 * @private
			 * @type {Boolean}
			 */
			"HasOmnichannelRights": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: null
			}
		},
		messages: {},
		mixins: {},
		methods: {

			//region Methods: Private

			/**
			 * Returns operator state info.
			 * @private
			 * @param {String} stateCode Operator status code.
			 * @return {Object} Operator info result.
			 */
			_getOperatorStateInfo: function (stateCode) {
				const operatorStates = this.get("OperatorStates");
				return operatorStates && operatorStates.find(stateCode);
			},

			/**
			 * Updates operator status on server message.
			 * @private
			 * @param {Object} scope message scope.
			 * @param {Object} message Server channel message.
			 */
			_onOperatorStatusChanged: function(scope, message) {
				if (message.Header.Sender === "OperatorStateChanged") {
					const body = this.Ext.decode(message.Body);
					this.set("OperatorState", body.StateCode);
				}
			},

			/**
			 * Check license operation for using chats.
			 */
			_checkOmnichannelLicOperation: function(callback, scope) {
				scope.callService({
					serviceName: "CtiRightsService",
					methodName: "GetUserHasOperationLicense",
					data: {
						operations: ['Chats.Use'],
						isAnyOperation: false
					}
				}, function(result) {
					this.$HasOmnichannelLicOperation = result.GetUserHasOperationLicenseResult;
					this.Ext.callback(callback, scope);
				}, this);
			},

			_hasOmnichannelRights: function(callback, scope) {
				RightUtilities.getSchemaEditRights({schemaName: "OmniChat"}, function(result) {
					this.$HasOmnichannelRights = this.Ext.isEmpty(result);
					Ext.callback(callback, scope);
				}, this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#loadProfileButtonMenu
			 * @override
			 */
			loadProfileButtonMenu: function () {
				const parentMethod = this.getParentMethod();
				if (this.getIsFeatureEnabled("ShowOmniChatInCommPanel")) {
					Terrasoft.chain(
						function (next) {
							this.getCurrentUserOperatorInfo(next, this);
						},
						function (next) {
							this._hasOmnichannelRights(next, this);
						},
						function (next) {
							if (this.$HasOmnichannelRights &&
								this.isNotEmpty(this.get("OperatorState"))) {
								this.addOperatorStatesToProfileButtonMenu(next, this);
							} else {
								next();
							}
						},
						function () {
							parentMethod.call(this);
						}, this);
				} else {
					parentMethod.call(this);
				}
			},

			/**
			 * Forms a collection of operator states from the result of a selection request to the database.
			 * @protected
			 * @param {Object} operatorStatesQueryResult Result of a database query for a selection of operator states.
			 * @returns {Terrasoft.Collection} A collection of operator states.
			 */
			getOperatorStates: function (operatorStatesQueryResult) {
				const operatorStates = new Terrasoft.Collection();
				operatorStatesQueryResult.collection.each(function (item) {
					const valueCode = item.get("Code");
					let operatorState = operatorStates.find(valueCode);
					if (!operatorState) {
						operatorState = {
							value: item.get("Id"),
							displayValue: item.get("Name"),
							code: valueCode,
							operatorAvailable: item.get("OperatorAvailable"),
							iconConfig: this.getIconConfig(item.get("Id"),
								this.operatorStateSchemaName, "Image"),
						};
						operatorStates.add(valueCode, operatorState);
					}
				}, this);
				return operatorStates;
			},

			/**
			 * Sets the state of the operator.
			 * @protected
			 * @param {String} tag Element tag.
			 */
			onChatOperatorStateChange: function (tag) {
				if (this.isEmpty(tag) || tag === this.get("OperatorState")) {
					return;
				}
				this.changeOperatorState(tag, this.handleOperatorStateChange);
			},

			/**
			 * Getting the current state of the operator.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @protected
			 */
			getCurrentUserOperatorInfo: function (callback, scope) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "GetCurrentState"
				};
				this.callService(config, function (response) {
					if (response) {
						if (response.success) {
							this.set("OperatorState", response.CurrentStateCode);
						} else if (response.errorInfo) {
							this.error(response.errorInfo.message);
						}
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * #all the service of changing the operator state.
			 * @param {String} newState New state for operator.
			 * @param {Function} callback Callback function.
			 * @protected
			 */
			changeOperatorState: function (newState, callback) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "ChangeState",
					data: {
						newState: newState
					}
				};
				this.callService(config, callback, this);
			},

			/**
			 * Handles after change operator state.
			 * @param {Object} response Response from server.
			 * @protected
			 */
			handleOperatorStateChange: function (response) {
				if (response) {
					if (response.success) {
						this.set("OperatorState", response.CurrentStateCode);
					} else if (response.errorInfo) {
						this.error(response.errorInfo.message);
					}
				}
			},

			/**
			 * Add omnichannel operator statuses.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			addOperatorStatesToProfileButtonMenu: function (callback, scope) {
				this.executeOperatorStateQuery(function (result) {
					const operatorStates = this.getOperatorStates(result);
					this.set("OperatorStates", operatorStates);
					this.generateOperatorStateMenuItems(operatorStates);
					Ext.callback(callback, scope);
				});
			},

			/**
			 * Request to read operator statuses
			 * @param {Function} Callback function.
			 * @protected
			 */
			executeOperatorStateQuery: function (callback) {
				const operatorStateEsq = this.getOperatorStateEsq();
				operatorStateEsq.getEntityCollection(callback, this);
			},

			/**
			 * Creates a query to select an operator state.
			 * @protected
			 * @returns {Terrasoft.EntitySchemaQuery} Operator state select query.
			 */
			getOperatorStateEsq: function () {
				const cacheKey = "OperatorState_ProfileMenuStatuses";
				const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: this.operatorStateSchemaName,
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					},
					serverESQCacheParameters: {
						cacheLevel: Terrasoft.ESQServerCacheLevels.SESSION,
						cacheGroup: this.operatorStateSchemaName,
						cacheItemName: cacheKey
					}
				});
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Code");
				esq.addColumn("Image");
				esq.addColumn("OperatorAvailable");
				return esq;
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#getOperatorStatusProfileIcon
			 * @override
			 */
			getOperatorStatusProfileIcon: function () {
				const currentOperatorStateInfo = this._getOperatorStateInfo(this.get("OperatorState"));
				const baseProfileIcon = this.callParent(arguments);
				if (this.isEmpty(currentOperatorStateInfo)) {
					return baseProfileIcon;
				}
				const resultProfileIcon = currentOperatorStateInfo.operatorAvailable && this.isNotEmpty(baseProfileIcon)
					? baseProfileIcon
					: currentOperatorStateInfo.iconConfig;
				return resultProfileIcon;
			},

			/**
			 * Forms menu items of operator states in the profile button menu.
			 * @protected
			 * @param {Terrasoft.Collection} operatorStates Operator state collection.
			 */
			generateOperatorStateMenuItems: function (operatorStates) {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Type: "Terrasoft.MenuSeparator",
						Caption: {
							bindTo: "Resources.Strings.ChatMenuSeparator"
						},
					}
				}));
				operatorStates.each(function (item) {
					const menuItem = this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Caption: item.displayValue,
							MarkerValue: item.displayValue,
							Tag: item.code,
							ImageConfig: item.iconConfig,
							Click: { bindTo: "onChatOperatorStateChange" }
						}
					});
					profileMenuCollection.addItem(menuItem);
				}, this);
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Type: "Terrasoft.MenuSeparator",
						Caption: Terrasoft.emptyString
					}
				}));
			},

			/**
			 * Returns operator state display value.
			 * @override
			 */
			getOperatorStateDisplayValue: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._onOperatorStatusChanged, this);
					this.Ext.callback(callback, scope || this);
				}, this]);
			}

			//endregion

		},
		diff: []
	};
});
