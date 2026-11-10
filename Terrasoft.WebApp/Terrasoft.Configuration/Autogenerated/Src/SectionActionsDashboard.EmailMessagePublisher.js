define("SectionActionsDashboard", ["SectionActionsDashboardResources", "EmailMessagePublisherModule"],
	function(resources) {
		return {
			attributes: {},
			messages: {
				/**
				 * @message EmailTemplateLoaded
				 * Informs action dashboard that loaded EmailTemplate from history page
				 */
				"EmailTemplateLoaded": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message EmailMessagePageLoaded
				 * Informs section that tab was loaded
				 */
				"EmailMessagePageLoaded": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SendMacrosData
				 * Informs publisher that loaded EmailTemplate from history page
				 */
				"SendMacrosData": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * @inheritdoc Terrasoft.BaseActionsDashboard#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var historyModule = this.getHistoryModuleId();
					this.sandbox.subscribe("EmailTemplateLoaded", this.setActiveTabAndSendData, this, [historyModule]);
				},

				/**
				 * Set active tab and send email data.
				 * @param {object} data from email template.
				 */
				setActiveTabAndSendData: function(args) {
					var activeTabName = "EmailMessageTab";
					this.set("ActiveTabName", activeTabName);
					this.sandbox.subscribe("EmailMessagePageLoaded", function() {
						this.sandbox.publish("SendMacrosData", args, [this.sandbox.id]);
					}, this, [this.getEmailMessagePublisherModuleId()]);
					this.sandbox.publish("SendMacrosData", args, [this.sandbox.id]);
				},

				/**
				 * Get history module id.
				 * @return {String} module id.
				 */
				getHistoryModuleId: function() {
					var moduleId = this.sandbox.id;
					return moduleId.replace("_module_DcmActionsDashboardModule", "") + "_MessageHistoryModule";
				},

				/**
				 * Get EmailMessagePublisher module id.
				 * @return {String} module id.
				 */
				getEmailMessagePublisherModuleId: function() {
					return this.sandbox.id + "_EmailMessagePublisherModule";
				},

				/**
				 * @inheritdoc Terrasoft.ActionsDashboard#getExtendedConfig
				 * @overridden
				 */
				getExtendedConfig: function() {
					var config = this.callParent(arguments);
					var lczImages = resources.localizableImages;
					config.EmailMessageTab = {
						"ImageSrc": this.Terrasoft.ImageUrlBuilder.getUrl(lczImages.EmailMessageTabImage),
						"MarkerValue": "email-message-tab",
						"Align": this.Terrasoft.Align.RIGHT,
						"Visible": this.getExtraActionDashboadTabVisible(),
						"Tag": "Email"
					};
					return config;
				},

				/**
				 * @inheritdoc Terrasoft.BaseActionsDashboard#getAllowedTabs7x
				 * @override
				 */
				getAllowedTabs7x: function() {
					var result = this.callParent(arguments);
					result.push("EmailMessageTab");
					return result;
				},

				/**
				 * @inheritdoc Terrasoft.ActionsDashboard#onGetRecordInfoForPublisher
				 * @overridden
				 */
				onGetRecordInfoForPublisher: function() {
					var info = this.callParent(arguments);
					if (info && info.relationSchemaName === "Case") {
						info.additionalInfo.title = this.getEmailTitle();
					}
					if (info && info.relationSchemaName === "Contact") {
						var recepientTemplate = "{0} <{1}>; ";
						var contact;
						if (this.get("EntitySchemaName") !== info.relationSchemaName) {
							contact = this.getMasterEntityParameterValue("Contact");
						}
						var name = contact && contact.displayValue || this.getMasterEntityParameterValue("Name");
						var email = this.getMasterEntityParameterValue("Email");
						if (name && email) {
							info.additionalInfo.recepient = this.Ext.String.format(recepientTemplate, name, email);
						} else {
							info.additionalInfo.recepient = this.Ext.emptyString.toString();
						}
					}
					return info;
				},

				/**
				 * Returns title for an email to be sent from Case section.
				 * @return {String} Email title
				 */
				getEmailTitle: function() {
					var emailTitleMessage = this.get("Resources.Strings.EmailTitleCaption");
					var title = this.getMasterEntityParameterValue("Subject");
					var number = this.getMasterEntityParameterValue("Number");
					return this.Ext.String.format(emailTitleMessage, number, title);
				},

				/**
				 * @inheritdoc Terrasoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @overridden
				 */
				getSectionPublishers: function() {
					var publishers = this.callParent(arguments);
					publishers.push("Email");
					return publishers;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "EmailMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmailMessageTabContainer",
					"parentName": "EmailMessageTab",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["email-message-content"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmailMessageModule",
					"parentName": "EmailMessageTab",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["email-message-module", "message-module"]
						},
						"itemType": this.Terrasoft.ViewItemType.MODULE,
						"moduleName": "EmailMessagePublisherModule",
						"afterrender": {
							"bindTo": "onMessageModuleRendered"
						},
						"afterrerender": {
							"bindTo": "onMessageModuleRendered"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
