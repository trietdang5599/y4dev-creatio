define("OAuth20AppPage", [
	"OAuth20AppPageResources",
	"ServiceOAuthAuthenticatorEndpointHelper",
	"css!OAuth20AppStyles",
	"AcademyUtilities",
	"OAuth20Utilities",
	"ServiceEnums"
], function(resources) {
	return {
		entitySchemaName: "OAuthApplications",
		attributes: {

			/**
			 * The name of the operation which the user must have access to open the page.
			 */
			SecurityOperationName: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: "CanManageSolution"
			},

			/**
			 * OAuth app name.
			 */
			Name: {
				isRequired: true
			},

			/**
			 * OAuth app secret key.
			 */
			SecretKey: {
				isRequired: true
			},

			/**
			 * OAuth app authorize core request Url.
			 */
			AuthorizeUrl: {},

			/**
			 * OAuth app token request Url.
			 */
			TokenUrl: {
				isRequired: true
			},

			/**
			 * Allow use shared user.
			 */
			UseSharedUser: {
				onChange: "_onUseSharedUserOrAuthFlowChanged"
			},

			/**
			 * Credentials location in request.
			 */
			CredentialsLocationInRequest: {
				"onChange": "_onCredentialsLocationChange"
			},

			/**
			 * Access type.
			 */
			AccessType: {
				"onChange": "_onAccessTypeChange"
			},

			/**
			 * Credentials location in request list.
			 */
			CredentialsLocationLookup: {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"onChange": "_onCredentialsLocationLookupChange",
				"caption": resources.localizableStrings.CredentialsLocationCaption
			},

			/**
			 * Access type list.
			 */
			AccessTypeLookup: {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"onChange": "_onAccessTypeLookupChange",
				"caption": "Access type"
			},

			/**
			 * Access type list.
			 */
			AuthFlowLookup: {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"onChange": "_onAuthFlowLookupChange",
				"caption": "$Resources.Strings.AuthFlowCaption",
			},

			/**
			 * Access type.
			 */
			AuthFlow: {
				"onChange": "_onAuthFlowChange"
			}

		},
		properties: {

			/**
			 * Url to academy.
			 */
			academyUrl: null,

		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"OAuthAppScopeDetail28a4d31f": {
				"schemaName": "OAuthAppScopeDetail",
				"profileKey": "OAuth20AppPageOAuthAppScopeDetail",
				"entitySchemaName": "OAuthAppScope",
				"filter": {
					"detailColumn": "OAuth20App",
					"masterColumn": "Id"
				}
			},
			"OAuthAppUserDetaildd92605d": {
				"schemaName": "OAuthAppUserDetail",
				"profileKey": "OAuth20AppPageOAuthAppUserDetail",
				"entitySchemaName": "VwOAuthAppUser",
				"filter": {
					"detailColumn": "OAuthApp",
					"masterColumn": "Id"
				}
			},
			"OAuthAppExtraParamsDetail": {
				"schemaName": "OAuthAppExtraParamsDetail",
				"profileKey": "OAuth20AppPageOAuthAppExtraParamsDetail",
				"entitySchemaName": "OAuthAppExtraParams",
				"filter": {
					"detailColumn": "OAuth20App",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_onUseSharedUserOrAuthFlowChanged: function() {
				this.$SharedUser = this.$UseSharedUser ? this.$SharedUser : null;
				const usersTab = this.$TabsCollection.get("UsersTab");
				const isUsersTabVisible = !this.$UseSharedUser && this.getIsAuthCodeFlow();
				usersTab.set("Visible", isUsersTabVisible);
			},

			/**
			 * @private
			 */
			_onCredentialsLocationChange: function(model, value) {
				const locationCaptionEnum = Terrasoft.services.enums.CredentialsLocationCaption;
				this.$CredentialsLocationLookup = {
					value: value,
					displayValue: locationCaptionEnum[value]
				};
			},

			/**
			 * @private
			 */
			_onAccessTypeChange: function(model, value) {
				const accessTypeCaptionEnum = Terrasoft.services.enums.AccessTypeCaption;
				this.$AccessTypeLookup = {
					value: value,
					displayValue: accessTypeCaptionEnum[value]
				};
			},

			/**
			 * @private
			 * Clears fields dependent on AuthFlow.
			 */
			_clearAuthFlowDependentFields: function() {
				const sharedUser = this.$SharedUser;
				this.$UseSharedUser = null;
				if (sharedUser) {
					this.onRemoveSharedUser("SharedUser", Terrasoft.emptyFn, this);
				}
				const fieldsToClear = [
					"SharedUser"
				];
				
				this.$UseSharedUser = this.$AuthFlow ? false : !this.getIsFeatureEnabled("PersonalAccountsFeature") || this.canUsePersonalAccounts();
				
				Terrasoft.each(fieldsToClear, function(attrName) {
					if (!Ext.isEmpty(this.get(attrName))) {
						this.set(attrName, null);
					}
				}, this);


			},

			/**
			 * @private
			 */
			_onAuthFlowChange: function(_, value) {
				this._onUseSharedUserOrAuthFlowChanged();
				const prevValue = this.getPrevious("AuthFlow");
				this.$AuthFlowLookup = {
					value: value,
					displayValue: value ? this.get("Resources.Strings.AuthFlowClientCredentials") : this.get("Resources.Strings.AuthFlowAuthCode")
				};
	
				if (prevValue === value || prevValue === undefined) {
					return;
				}
				
				this._clearAuthFlowDependentFields();

			},

			/**
			 * Updates credentials location on lookup change.
			 * @private
			 */
			_onCredentialsLocationLookupChange: function(model, lookupValue) {
				this.$CredentialsLocationInRequest = lookupValue && lookupValue.value;
			},

			/**
			 * @private
			 */
			_onAccessTypeLookupChange: function(model, lookupValue) {
				this.$AccessType = lookupValue && lookupValue.value;
			},

			/**
			 * @private
			 */
			_onAuthFlowLookupChange: function(model, lookupValue) {
				const newValue = lookupValue?.value;
				if(!Ext.isEmpty(this.$AuthFlow) && !Ext.isEmpty(newValue) && this.$AuthFlow !== newValue) {
					const message = this.$AuthFlow
						? this.get("Resources.Strings.AuthFlowTypeChangeFromClientCredToCodeMessage")
						: this.get("Resources.Strings.AuthFlowTypeChangeFromCodeToClientCredMessage")
					this.showConfirmationDialog(
						message,
						function(result) {
							if (result === this.Terrasoft.MessageBoxButtons.NO.returnCode) {
								this._onAuthFlowChange(model, this.$AuthFlow);
							} else {
								this.$AuthFlow = newValue;
							}
						}, [this.Terrasoft.MessageBoxButtons.NO.returnCode,
							this.Terrasoft.MessageBoxButtons.YES.returnCode], null);
				} else {
					this.$AuthFlow = newValue;
				}
				
			},			

			/**
			 * @private
			 */
			_createExistingUsersFilter: function() {
				const existsfilterGroup = this.Ext.create("Terrasoft.FilterGroup");
				existsfilterGroup.add("OAuthApplication",
					Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL,
						"OAuthApp",
						this.$PrimaryColumnValue,
						Terrasoft.DataValueType.GUID));
				const filter = Terrasoft.createExistsFilter("[VwOAuthAppUser:SysUser].Id", existsfilterGroup);
				return filter;
			},

			/**
			 * @private
			 */
			_initSecretKey: function(callback, scope) {
				Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.getOAuthServiceClientSecretKey(
					this.$Id, function(success, clientSecretKey) {
						if (success) {
							if (!Ext.isEmpty(clientSecretKey)) {
								this.$SecretKey = clientSecretKey;
								delete this.changedValues.SecretKey;
								this.updateButtonsVisibility(false, {force: true});
							}
						} else {
							this.showInformationDialog(this.get("Resources.Strings.CannotReadClientSecret"));
						}
						Ext.callback(callback, scope);
					}, this);
			},

			/**
			 * Login current user.
			 * @private
			 */
			_loginUser: function(callback, scope) {
				if (this.getIsClientCredFlow()) {
					Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.processClientCredentials(this.$Id, function(success, result) {
						const parsedResult = JSON.parse(result);
						if(parsedResult.success) {
							this.assignSharedUser();
							this.showInformationDialog(parsedResult.message);
						} else {
							this.showInformationDialog(parsedResult.message);
						}
						Ext.callback(callback, scope);
					}, this);
					return;
				}

				Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.getAuthorizationGrantUrl(
					this.$Id,
					function(success, url) {
						if (success) {
							if (url) {
								window.open(url);
							}
						} else {
							this.showInformationDialog(this.get("Resources.Strings.LoginCallbackFailed"));
						}
						Ext.callback(callback, scope);
					}, this);
			},

			/**
			 * Initializes url for academy and pass it into the callback function.
			 * @param {Function} callback.
			 * @param {Object} scope.
			 * @param {String} helpId.
			 * @param {String} helpCode.
			 * @private
			 */
			_initAcademyUrl: function(helpId, helpCode, callback, scope) {
				const config = {
					contextHelpId: helpId,
					contextHelpCode: helpCode,
					callback: function(academyUrl) {
						this.academyUrl = academyUrl;
						Ext.callback(callback, scope);
					},
					scope: this
				};
				Terrasoft.AcademyUtilities.getUrl(config);
			},

			/**
			 * Set auth button text.
			 * @private
			 */
			_setAuthButtonText: function () {
				return this.$AuthFlow === 0 ? this.get('Resources.Strings.LoginSharedUserCaption') : this.get('Resources.Strings.ValidateToken');
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritDoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 * @Protected
			 */
			onEntityInitialized: function(callback, scope) {
				var parentMethod = this.getParentMethod();
				if (!this.$AuthFlow) {
					this.$AuthFlow = 0;
				}
				if (this.$AuthFlow === 0) {
					this.$UseSharedUser = !this.canUsePersonalAccounts();
				}
				if (!this.$CredentialsLocationInRequest) {
					this.$CredentialsLocationInRequest = Terrasoft.services.enums.CredentialsLocation.BASIC_HEADER;
				}
				if (!this.$AccessType) {
					this.$AccessType = Terrasoft.services.enums.AccessType.OFFLINE;
				}

				this._initSecretKey(function() {
					parentMethod.apply(this, [callback, scope]);
				}, this);
			},

			/**
			 * @inheritDoc Terrasoft.BaseSchemaViewModel#openLookup
			 * @overridden
			 * @protected
			 */
			openLookup: function(config) {
				if (config.columnName === "SharedUser") {
					config.filters.add(this._createExistingUsersFilter());
				}
				this.callParent(arguments);
			},

			/**
			 * Assign current user to the application.
			 * @protected
			 */
			assignSharedUser: function() {
				const sharedUser = {
					value: Terrasoft.SysValue.CURRENT_USER.value,
					displayValue: Terrasoft.SysValue.CURRENT_USER.displayValue
				};
				if (this.$UseSharedUser) {
					this.$SharedUser = sharedUser;
				}
				this.updateDetails();
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @protected
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					Terrasoft.chain(
						function(next) {
							this._initAcademyUrl("1907", "OAuth20AppPageTypicalIssues", next, this);
						},
						function() {
							Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.onLoggedIn({
								academyUrl: this.academyUrl,
								onSuccess: function() {
									this.assignSharedUser();
								},
								scope: this
							});
							Ext.callback(callback, scope);
						}, this);
				}, this]);
			},
			/**
			 * Remove shared user from OAuth application.
			 * @protected
			 * @param {String} propertyName Attribute name.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope.
			 */
			onRemoveSharedUser: function(propertyName, callback, scope) {
				const sharedUserId = this.getPrevious(propertyName);
				this.save({
					isSilent: true,
					callBaseSilentSavedActions: true,
					callback: function() {
						Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.removeOAuthUser(
							sharedUserId && sharedUserId.value,
							this.$Id,
							function(success) {
								if (!success) {
									this.showInformationDialog(this.get("Resources.Strings.LoginCallbackFailed"));
								}
								this.updateDetails();
								Ext.callback(callback, scope);
							}, this);
					},
					scope: this
				}, this);
			},

			// endregion

			// region Methods: Public

			/**
			 * Handles image change.
			 * @public
			 * @param {File} image Image.
			 */
			onAppImageChange: function(image) {
				if (!image) {
					this.set(this.primaryImageColumnName, null);
					return;
				}
				Terrasoft.ImageApi.upload({
					file: image,
					onComplete: this.onImageUploaded,
					onError: Terrasoft.emptyFn,
					scope: this
				});
			},

			/**
			 * Handles image uploaded event.
			 * @public
			 * @param {String} imageId Image.
			 */
			onImageUploaded: function(imageId) {
				var imageData = {
					value: imageId,
					displayValue: "Photo"
				};
				this.set(this.primaryImageColumnName, imageData);
			},

			/**
			 * Returns app image web-address.
			 * @public
			 * @return {String} App image web-address.
			 */
			getAppImage: function() {
				var primaryImageColumnValue = this.get(this.primaryImageColumnName);
				if (primaryImageColumnValue) {
					return this.getSchemaImageUrl(primaryImageColumnValue);
				}
				return this.getAppDefaultImage();
			},

			/**
			 * Returns default image.
			 * @public
			 * @return {String} Default image web address.
			 */
			getAppDefaultImage: function() {
				return Terrasoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultAppIcon"));
			},

			/**
			 * @inheritDoc Terrasoft.BasePageV2#onDiscardChangesClick
			 * @overridden
			 * @public
			 */
			onDiscardChangesClick: function(callback, scope) {
				this.callParent([
					function() {
						this._initSecretKey(callback, scope);
					}, this
				]);
			},

			/**
			 * Returns Redirect url help text.
			 * @public
			 * @returns {String}
			 */
			getRedirectUrlHelpText: function() {
				return this.get("Resources.Strings.RedirectUrlHelpLine1") +
					Terrasoft.ServiceOAuthAuthenticatorEndpointHelper.getOAuthServiceAuthorizationCodeRedirectUrl();
			},

			/**
			 * Returns Redirect url help formatted html.
			 * @public
			 * @returns {String}
			 */
			getRedirectUrlHelpHtml: function() {
				const infoImgUrl = Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.InfoImage);
				const redirectHelpText = this.getRedirectUrlHelpText();
				const line2HelpText = this.get("Resources.Strings.RedirectUrlHelpLine2");
				return "<div class=\"info-help\"><img src = \"" + infoImgUrl + "\"><div>" +
						redirectHelpText +
						"<br/>" +
						line2HelpText +
						"</div></div>";
			},

			/**
			 * @inheritdoc Terrasoft.BaseViewModel#getLookupQuery
			 * @override
			 */
			getLookupQuery: function(filterValue, columnName) {
				const esq = this.callParent(arguments);
				if (columnName === "SharedUser") {
					esq.filters.add(this._createExistingUsersFilter());
				}
				return esq;
			},

			/**
			 * Returns if Shared User exists.
			 * @return {boolean}
			 */
			getSharedUserVisible: function() {
				return this.$UseSharedUser && !Ext.isEmpty(this.$SharedUser) && this.getIsAuthCodeFlow();
			},

			/**
			 * Returns if Shared user empty.
			 * @return {boolean}
			 */
			canLoginSharedUser: function() {
				return this.getIsAuthCodeFlow() ? this.$UseSharedUser && Ext.isEmpty(this.$SharedUser) : false;
			},

			/**
			 * Performs login of current user.
			 * @public
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			onLoginSharedUser: function(callback, scope) {
				this.save({
					isSilent: true,
					callBaseSilentSavedActions: true,
					callback: function() {
						Terrasoft.OAuth20Utilities.canLoginOAuthUser(Terrasoft.SysValue.CURRENT_USER.value, this.$Id,
							function(result) {
								if (result) {
									this._loginUser(callback, scope);
								} else {
									this.assignSharedUser();
									Ext.callback(callback, scope);
								}
							}, this);
					},
					scope: this
				}, this);
			},

			/**
			 * Returns if allow use personal accounts.
			 * @public
			 */
			canUsePersonalAccounts: function() {
				return this.getIsFeatureEnabled("PersonalAccountsFeature") && this.$AuthFlow === 0;
			},

			
			/**
			 * Returns if allow change auth flow.
			 * @public
			 */
			canSelectAuthFlowType: function() {
				return !this.getIsFeatureEnabled("CanNotSelectAuthFlowType");
			},

			/**
			 * Returns FAQ photo image url.
			 * @public
			 * @return {String} Photo image url.
			 */
			getFaqIcon: function() {
				const resourceImage = this.get("Resources.Images.FAQIcon");
				return Terrasoft.ImageUrlBuilder.getUrl(resourceImage);
			},

			/**
			 * Handles click on FAQ buttons to open Academy urls.
			 */
			onFaqClick: function() {
				const tag = arguments[3];
				const callback = arguments[4];
				const scope = arguments[5];
				this._initAcademyUrl(tag.articleId, tag.articleCode, function() {
					Ext.global.open(this.academyUrl);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Fills credentials location in request list.
			 * @public
			 * @param {Object} filter Filters for data preparation.
			 * @param {Terrasoft.Collection} list The data for the drop-down list.
			 */
			prepareCredentialsLocationList: function(filter, list) {
				var result = this.Ext.create("Terrasoft.Collection");
				const locationValues = [
					Terrasoft.services.enums.CredentialsLocation.BASIC_HEADER,
					Terrasoft.services.enums.CredentialsLocation.REQUEST_BODY,
					Terrasoft.services.enums.CredentialsLocation.QUERY_STRING
				];
				const locationCaptionEnum = Terrasoft.services.enums.CredentialsLocationCaption;
				Terrasoft.each(locationValues, function(key) {
					result.add(key, {
						value: key,
						displayValue: locationCaptionEnum[key]
					});
				}, this);
				list.reloadAll(result);
			},

			/**
			 * Fills access type list.
			 * @public
			 */
			prepareAccessTypeList: function(filter, list) {
				var result = this.Ext.create("Terrasoft.Collection");
				const accessType = [
					Terrasoft.services.enums.AccessType.ONLINE,
					Terrasoft.services.enums.AccessType.OFFLINE,
					Terrasoft.services.enums.AccessType.NOT_USE,
				];
				const accessTypeCaptionEnum = Terrasoft.services.enums.AccessTypeCaption;
				Terrasoft.each(accessType, function(key) {
					result.add(key, {
						value: key,
						displayValue: accessTypeCaptionEnum[key]
					});
				}, this);
				list.reloadAll(result);
			},

			prepareAuthFlowList: function(filter, list) {
				var result = this.Ext.create("Terrasoft.Collection");
				result.add(0, {
					value: 0,
					displayValue:  this.get("Resources.Strings.AuthFlowAuthCode")
				});
				result.add(1, {
					value: 1,
					displayValue: this.get("Resources.Strings.AuthFlowClientCredentials")
				});
				list.reloadAll(result);
			},

			getIsAuthCodeFlow: function() {
				return this.$AuthFlow !== 1;
			},

			getIsClientCredFlow: function() {
				return this.$AuthFlow === 1;
			},

			getTokenUrlTip: function() {
				return this.getIsAuthCodeFlow() ? this.get("Resources.Strings.TokenUrlTip") : this.get("Resources.Strings.ClientCredTokenUrlTip");
			}

			// endregion

		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "OAuthName",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Name",
					"enabled": true,
					"isRequired": true
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"name": "FaqContainer",
				"parentName": "LeftModulesContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"rowClassName": ["faq-button-grid-layout"],
						"columnClassName": ["faq-button-grid-layout"],
						"wrapClassName": ["faq-container"]
					},
					"items": [],
					"markerValue": "FaqContainer"
				}
			},
			{
				"name": "FaqIcon",
				"parentName": "FaqContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"getSrcMethod": "getFaqIcon",
					"readonly": true,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"classes": {
						"wrapClass": ["profile-icon"]
					},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 4
					}
				}
			},
			{
				"name": "FaqHeaderCaption",
				"parentName": "FaqContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.FaqHeaderText",
					"classes": {
						"labelClass": ["faq-header"]
					},
					"layout": {
						"column": 4,
						"row": 0,
						"colSpan": 20
					}
				}
			},
			{
				"name": "OAuthFaqSettingUpUrl",
				"parentName": "FaqContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"classes": {
						"textClass": ["faq-button", "base-edit-link"]
					},
					"click": {"bindTo": "onFaqClick"},
					"caption": "$Resources.Strings.FaqSettingUpOauthUrlText",
					"tag": {
						"articleId": 1913,
						"articleCode": "OAuth20AppPageSettingUp"
					},
					"layout": {
						"column": 4,
						"row": 1,
						"colSpan": 20
					}
				}
			},
			{
				"name": "OAuthFaqTypicalIssuesUrl",
				"parentName": "FaqContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"classes": {
						"textClass": ["faq-button", "base-edit-link"]
					},
					"click": {"bindTo": "onFaqClick"},
					"caption": "$Resources.Strings.FaqTypicalIssuesUrlText",
					"tag": {
						"articleId": 1907,
						"articleCode": "OAuth20AppPageTypicalIssues"
					},
					"layout": {
						"column": 4,
						"row": 2,
						"colSpan": 20
					}
				}
			},
			{
				"operation": "insert",
				"name": "OAuthSettingsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.Tabe9ae4951TabLabelTabCaption"
					},
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Tabe9ae4951TabLabelGroup9c0d9295",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.Tabe9ae4951TabLabelGroup9c0d9295GroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "OAuthSettingsTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"values": {
					"itemType": 0,
					"items": [],
					"classes": {"wrapperClass": ["control-width-15"]},
					"collapseEmptyRow": true
				},
				"parentName": "Tabe9ae4951TabLabelGroup9c0d9295",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientIdfd814735-9bc6-41c2-b33f-b403d4f60656",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "ClientId",
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ClientIdfd8147359bc641c2b33fb403d4f60656LabelCaption"
						}
					},
					"enabled": true,
					"tip": {
						"content": "$Resources.Strings.ClientIdTip"
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SecretKey75a66b31-21af-46e2-8c55-818e6d8c5054",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 0,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "SecretKey",
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.SecretKey75a66b3121af46e28c55818e6d8c5054LabelCaption"
						}
					},
					"enabled": true,
					"isRequired": true,
					"tip": {
						"content": "$Resources.Strings.SecretKeyTip"
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AuthorizeUrl513110c8-b271-424b-bcd2-8093cc22662a",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "AuthorizeUrl",
					"enabled": true,
					"isRequired": "$getIsAuthCodeFlow",
					"visible": "$getIsAuthCodeFlow",
					"tip": {
						"content": "$Resources.Strings.AuthorizeUrlTip"
					},
					"controlConfig": {
						"placeholder": "$Resources.Strings.AuthUrlPlaceholder"
					},
					"classes": {
						"wrapClassName": [
							"show-placeholder"
						]
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 2
			},
			
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "AuthFlowLookup",
				"index": 2,
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": "$prepareAuthFlowList"
					},
					"visible": "$canSelectAuthFlowType"
				},
				
			},
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "Photo",
				"values": {
					"getSrcMethod": "getAppImage",
					"onPhotoChange": "onAppImageChange",
					"readonly": false,
					"defaultImage": {"bindTo": "getAppDefaultImage"},
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"classes": {
						"wrapClass": ["app-image"]
					}
				},
				"index": 3
			},
			{
				"operation": "insert",
				"name": "TokenUrlc221b009-19db-4f75-9450-6b95adbaa2f5",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "TokenUrl",
					"enabled": true,
					"isRequired": true,
					"tip": {
						"content": "$getTokenUrlTip"
					},
					"controlConfig": {
						"placeholder": "$Resources.Strings.TokenUrlPlaceholder"
					},
					"classes": {
						"wrapClassName": [
							"show-placeholder"
						]
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "RevokeTokenUrlf0bdc3a4-361d-4dc6-a4b8-464f0573b8ce",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "RevokeTokenUrl",
					"enabled": true,
					"visible": "$getIsAuthCodeFlow",
					"tip": {
						"content": "$Resources.Strings.RevokeTokenUrlTip"
					},
					"controlConfig": {
						"placeholder": "$Resources.Strings.RevokeUrlPlaceholder"
					},
					"classes": {
						"wrapClassName": [
							"show-placeholder"
						]
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"name": "CredentialsLocationLookup",
				"index": 1,
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 3,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": "$prepareCredentialsLocationList"
					},
					"caption": "$Resources.Strings.CredentialsLocationCaption",
					"tip": {
						"content": "$Resources.Strings.CredentialsLocationTip"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"name": "AccessTypeLookup",
				"index": 2,
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 4,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": "$prepareAccessTypeList"
					}
				}
			},
			{
				"operation": "insert",
				"name": "RedirectUrlInfo",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"itemType": 23,
					"className": "Terrasoft.HtmlControl",
					"visible": "$getIsAuthCodeFlow",
					"htmlContent": "$getRedirectUrlHelpHtml"
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "SharedAccountContainer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 5,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"labelConfig": {
						"caption": "$Resources.Strings.RadioGroupCaption",
						"classes": ["label-top"]
					},
					"classes": {
						"wrapClassName": "control-width-15 label-top"
					},
					"visible": "$canUsePersonalAccounts"
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "SharedAccountLoginContainer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 6,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"visible": "$canLoginSharedUser",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"labelConfig": {
						"caption": " "
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "insert",
				"name": "SharedAccountRadioGroup",
				"values": {
					"itemType": Terrasoft.ViewItemType.RADIO_GROUP,
					"value": "$UseSharedUser",
					"items": [],
					"wrapClass": ["shared-user-radio-group"]
				},
				"parentName": "SharedAccountContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "UsePersonalAccounts",
				"parentName": "SharedAccountRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.UsePersonalAccountsCaption"},
					"markerValue": "UsePersonalAccounts",
					"value": false
				}
			},
			{
				"operation": "insert",
				"name": "UseSharedUser",
				"parentName": "SharedAccountRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.UseSharedUserCaption"},
					"markerValue": "UseSharedUser",
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "SharedUser10a3ca5c-4637-4959-b2fe-3ddf0072f7e1",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 8,
						"layoutName": "Tabe9ae4951TabLabelGridLayout80e1a8c0"
					},
					"bindTo": "SharedUser",
					"visible": "$getSharedUserVisible",
					"controlConfig": {
						"enableRightIcon": false,
						"cleariconclick" : "$onRemoveSharedUser"
					}
				},
				"parentName": "Tabe9ae4951TabLabelGridLayout80e1a8c0",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "LoginSharedUser",
				"values": {
					"visible": "$canLoginSharedUser",
					"caption": "$_setAuthButtonText",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"click": "$onLoginSharedUser"
				},
				"parentName": "SharedAccountLoginContainer",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "OAuthAppScopeDetail28a4d31f",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "OAuthSettingsTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OAuthAppExtraParamsDetail",
				"values": {
					"itemType": 2,
					"markerValue": "extra-params-detail",
					"visible": {"bindTo": "getIsClientCredFlow"}
				},
				"parentName": "OAuthSettingsTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UsersTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.UsersTabCaption"
					},
					"visible": "$UseSharedUser",
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OAuthAppUserDetaildd92605d",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "UsersTab",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/
	};
});