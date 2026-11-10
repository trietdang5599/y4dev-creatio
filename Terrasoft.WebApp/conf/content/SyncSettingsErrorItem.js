Terrasoft.configuration.Structures["SyncSettingsErrorItem"] = {innerHierarchyStack: ["SyncSettingsErrorItem"]};
define('SyncSettingsErrorItemStructure', ['SyncSettingsErrorItemResources'], function(resources) {return {schemaUId:'e43e0cb9-74a0-46cb-8498-5dc28ef99b6c',schemaCaption: "SyncSettingsErrorItem", parentSchemaName: "", packageName: "CrtUIv2", schemaName:'SyncSettingsErrorItem',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SyncSettingsErrorItem", ["SyncSettingsErrorItemResources", "css!SyncSettingsErrorsCSS",
	"CredentialsSyncSettingsMixin", "OAuthAuthenticationMixin", "AcademyUtilities"], function() {
		return {
			mixins: {
				/**
				 * @class CasePageUtilitiesV2 implements quick save cards in one click.
				 */
				CredentialsSyncSettingsMixin: "Terrasoft.CredentialsSyncSettingsMixin",

				/**
				 * @class OAuthAuthenticationMixin The mixin to work with OAuth authentication.
				 */
				OAuthAuthenticationMixin: "Terrasoft.OAuthAuthenticationMixin"
			},
			messages: {

				/**
				 * @message OpenSyncSettingsEdit
				 * Opens SyncSettingsEdit page.
				 */
				"OpenSyncSettingsEdit": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Error text.
				 * @type {String}
				 */
				"Text": {
					dataValueType: this.Terrasoft.DataValueType.TEXT
				},

				/**
				 * Error text template.
				 * @type {String}
				 */
				"TextTpl": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					value: ""
				},
				
				/**
				 * Transient extra data for template error text
				 * @type {String}
				 */
				"ExtraTplData": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * Mailbox with which a connection error occurred.
				 * @type {String}
				 */
				"Mailbox": {
					dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Displayed custom action.
				 * @type {String}
				 */
				"Action": {
					dataValueType: this.Terrasoft.DataValueType.TEXT
				},

				/**
				 * Url for an article at the academy.
				 * @type {String}
				 */
				"AcademyUrl": {
					"dataValueType": this.Terrasoft.DataValueType.TEXT,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Url caption for an article at the academy.
				 * @type {String}
				 */
				 "AcademyUrlCaption": {
					"dataValueType": this.Terrasoft.DataValueType.TEXT,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Id of the article about ExchangeListener at the academy.
				 * @type {Number}
				 */
				"ExchangeListenerAcademyArticleId": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 2074
				},

				/**
				 * Id of the article about email troubleshooting at the academy.
				 * @type {Number}
				 */
				"EmailTroubleshootingAcademyArticleId": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 2394
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Get a link to the academy by identifier.
				 * @param {Number} articleId Article identifier.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_getAcademyUrl: function(articleId, callback, scope) {
					const config = {
						scope: scope || this,
						contextHelpId: articleId,
						callback: callback
					};
					Terrasoft.AcademyUtilities.getUrl(config);
				},

				/**
				 * Set a link to academy.
				 */
				_setAcademyUrl: function() {
					var action = this.get("Action");
					if (this.isEmpty(action)) {
						return;
					}
					switch (action) {
						case "LinkToExchangeListenerServiceAcademy":
							this._getAcademyUrl(
								this.get("ExchangeListenerAcademyArticleId"),
								function (url) {
									this.set("AcademyUrl", url);
								}, this);
							this.set("AcademyUrlCaption",
								this.get("Resources.Strings.LinkToExchangeListenerServiceAcademyCaption"));
							break;
						case "LinkToEmailTroubleshootingAcademy":
							this._getAcademyUrl(
								this.get("EmailTroubleshootingAcademyArticleId"),
								function (url) {
									this.set("AcademyUrl", url);
								}, this);
							this.set("AcademyUrlCaption",
								this.get("Resources.Strings.LinkToEmailTroubleshootingAcademyCaption"));
							break;
						case "LinkToConfigurationInstructions":
							this._getAcademyUrl(
								this.get("EmailTroubleshootingAcademyArticleId"),
								function (url) {
									this.set("AcademyUrl", url);
								}, this);
							this.set("AcademyUrlCaption",
								this.get("Resources.Strings.LinkToConfigurationInstructions"));
							break;
						default:
							break;
					}
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.initErrorText();
					this._setAcademyUrl();
					this.callParent(arguments);
				},

				/**
				 * Sets error text value.
				 */
				initErrorText: function() {
					var mailbox = this.get("Mailbox");
					var textTpl = this.get("TextTpl");
					this.set("Text", this.Ext.String.format(textTpl, mailbox && mailbox.senderEmailAddress || "", this.get("ExtraTplData") || ""));
				},

				/**
				 * Sets error text value.
				 */
				changeSyncSettings: function() {
					var mailbox = this.get("Mailbox");
					this.openCredentialsSyncSettingsEdit(mailbox);
					this.sandbox.publish("OpenSyncSettingsEdit", null, ["SyncSettingsErrorItem"]);
				},

				/**
				 * Initiates OAuth authentication.
				 */
				authenticateOAuth: function() {
					var mailbox = this.get("Mailbox");
					if (mailbox.oAuthApplicationName) {
						this.useOAuthAuthentication(
							mailbox.senderEmailAddress, mailbox.oAuthApplicationName, mailbox.mailServerId);
					} else {
						this.changeSyncSettings();
					}
				},

				getExchangeListenerServiceAcademyUrl: function() {
					return this.get("Resources.Strings.LinkToExchangeListenerServiceAcademyUrl");
				},

				dismissItem: function() {
					var mailbox = this.get("Mailbox");
					var update = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					update.filters.add("MailboxIdFilter", this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Id", mailbox.id
					));
					update.setParameterValue("ErrorCode", null, this.Terrasoft.DataValueType.LOOKUP);
					update.setParameterValue("WarningCode", null, this.Terrasoft.DataValueType.LOOKUP);
					update.execute(this.Terrasoft.emptyFn);
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["sync-error"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ErrorIcon",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"enabled": false,
						"imageConfig": { "bindTo": "Resources.Images.ErrorIcon" },
						"markerValue": "errorIcon"
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"name": "ErrorText",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Text" },
						"markerValue": { "bindTo": "Text" }
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ChangeSyncSettings",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "changeSyncSettings"},
						"markerValue": "changeSyncSettingsButton",
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": [
								"change-sync-settings-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.SpecifyNewPasswordLocalizableString"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "ChangePassword" && !this.$Mailbox?.impersonated;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "OAuthAuthenticate",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "authenticateOAuth"},
						"markerValue": "oAuthAuthenticateButton",
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": [
								"oauth-authenticate-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.OAuthAuthenticateLocalizableString"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "OAuthAuthenticate" && !this.$Mailbox?.impersonated;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "Dismiss",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "dismissItem"},
						"markerValue": "dismissButton",
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": [
								"oauth-authenticate-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.Dismiss"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "ManualDismiss";
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "LinkToExchangeListenerServiceAcademy",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.HYPERLINK,
						"href": {
							"bindTo": "AcademyUrl"
						},
						"markerValue": "linkToExchangeListenerServiceAcademyButton",
						"classes": {
							"hyperlinkClass": [
								"link-to-exchange-listener-service-academy-button"
							]
						},
						"caption": {
							"bindTo": "AcademyUrlCaption"
						},
						"visible": {
							"bindTo": "AcademyUrl",
							"bindConfig": {
								"converter": function(value) {
									return this.isNotEmpty(value);
								}
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);


