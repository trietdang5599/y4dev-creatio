define("BpmonlineCloudIntegrationPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WebHooksCaption: "Domain to receive responses",
		ServiceIsUnavailable: "Creatio cloud service is unavailable",
		WrongApiKey: "Not valid api key",
		UnhandledErrorMessage: "Unhandled error: {0}",
		WebHooksInfoMessage: "Your Creatio application domain URL accessible from the Internet in the format: \u003Ca \u003Ehttp://yourdomain.com\u0022\u003C/a\u003E. Creatio cloud email service will send responses to this URL:  \u003Ca \u003Ehttp://yourdomain.com/0/ServiceModel/CESWebhooksService.svc/HandleWebHooks\u003C/a\u003E",
		UnreachableResource: "We were not able to connect to the specified address: {0}. Please check if you have set up your firewall to receive POST-requests from the Internet to your domain.",
		GeneralSettingsTabCaption: "General settings",
		SenderDomainsTabCaption: "Sender domains",
		SubscriptionManagementTabCaption: "Subscription management",
		SetupInstructionsCaptionTemplate: "Domain \u00AB{0}\u00BB: DKIM/SPF setup instructions",
		SenderDomainsHelpTextCaption: "In order to send emails from your domain, you should ask your domain admins to modify the DNS record in your domain hosting. Use the following instructions for setup. For setup guides for the most popular hosting providers please visit our \u003Ca href=\u0022{0}\u0022 target=\u0022_blank\u0022 data-context-help-id=\u00221495\u0022  \u003EAcademy\u003C/a\u003E.\u003Cbr\u003E\u003Cbr\u003EInstructions for different domains are different. You have to add and select each domain to get different instructions.\u003Cbr\u003E\u003Cbr\u003E1. Add and select the domain from the list on this page. ",
		SPFTextLabelCaption: "\u003Cb\u003ESPF settings.\u003C/b\u003E In your domain\u0027s DNS settings create first TXT record for your SPF key. Copy and paste there the following text:",
		SPFFootnoteCaption: "*DNS settings should only have 1 SPF record. If there is an existing SPF record, just add the domain from \u0022include:\u0022 parameter above to the existing record. Make sure it is added before any IPs.",
		DKIMTextLabelCaption: "\u003Cb\u003EDKIM settings.\u003C/b\u003E In your domain\u0027s DNS settings create second TXT record with DKIM key. Copy and paste there the following text:",
		DKIMFootnoteCaption: "*DNS settings can have as many DKIM records as needed.",
		SPFScriptTemplate: "{0}",
		DKIMScriptTemplate: "_domainkey TXT o=~\nus._domainkey TXT k=rsa; p={0}",
		EmailSendSetupControlGroupCaption: "Sending email setup",
		ResponseReceiveSetupControlGroupCaption: "Email responses setup",
		CheckSettingsButtonCaption: "Check settings",
		EmailServiceProviderCaption: "Email service provider",
		ApiKeyCaption: "API key",
		ApiKeyInfoButtonCaption: "API key to access the Creatio cloud services",
		CloudConnectionUrlCaption: "Creatio cloud services connection URL",
		CloudConnectionUrlInfoButtonCaption: "Creatio cloud services address",
		ConnectionStatusCaption: "Connection status",
		AuthKeyCaption: "Auth key",
		WebHooksInfoButtonCaption: "Address of your Creatio site.\nFor on-site customers that address must be accessible for the data transfer.",
		AuthKeyInfoButtonCaption: "Authentication key to receive responses",
		ErrorMessageCaption: "Error message",
		ConnectedCaption: "Connection is active",
		DisconnectedCaption: "Connection error",
		WrongAuthKeyMessage: "Not valid auth key",
		WrongWebHookDomainMessage: "Domain to receive responses is unavaialble",
		SetupInstructionsDefaultCaption: "DKIM/SPF setup instructions",
		MailingServiceInActive: "Cloud email service is not active",
		ResponsesParsingSettingsTabCaption: "Responses parsing settings",
		StopParsingWebhooksControlGroupCaption: "Time period to stop parsing bulk email responses",
		StopHandleWebHookProcessAt: "From",
		StartHandleWebHookProcessAt: "To",
		DMARCSettingCaption: "\u003Cb\u003EDMARC settings.\u003C/b\u003E In your domain\u0027s DNS settings create new TXT record with DMARC key. Copy and paste there the following text:",
		DMARCSettingHelpCaption: "*DMARC verification is added only after you add SPF and DKIM records",
		AdditionalSettingsCaption: "\u003Cb\u003EAdditional settings.\u003C/b\u003E In your domain\u0027s DNS settings create new TXT record to set the following functions:.",
		AdditionalSettingsHelpCaption: "",
		SystemEmailControlGroupCaption: "Default ESP email",
		CheckEmailButtonCaption: "Check email",
		DefaultESPEmailCaption: "Default ESP email",
		DefaultESPEmailStateCaption: "Check status",
		DefaultESPEmailInfoMessage: "Email address for sending system messages to the ESP. Specify the real email of the corporate domain.",
		InvalidEmailErrorMessage: "Enter a valid email",
		EmailCheckedStatusCaption: "Checked",
		EmailCheckFailedStatusCaption: "Check failed",
		FieldEmptyValidationMessage: "Enter a value",
		MxScriptTemplate: "{0}",
		MxTextLabelCaption: "\u003Cb\u003EMX settings.\u003C/b\u003E In your domain\u0027s DNS settings create first MX record for your subdomain. Copy and paste there the following text:",
		MxFootnoteCaption: "*There is only SendGrid ESP requires to add MX record. For the rest ESPs this block will be blank.",
		GetCheckedEmailFailedErrorMessage: "Could not check the email address {0} due to sending from the domain {1} is not configured. On the \u0022Sender Domains\u0022 section you may find the required DNS records for your domain. Please, configure the domain and re-check the email address.",
		UnableToConnectToCesError: "Error occurred connecting to Cloud Email Service. Please contact system administrator.",
		EspManagementsTabCaption: "Email providers",
		IsEmptyDomainsGrid: "No sender domains have been added. To add a new sender domain, click \u201C\u002B\u201D",
		DomainsDataNotAvailableBlankSlate: "The sender domain list cannot be viewed because Cloud Email Service is not available. Check the connectivity settings in the \u201CGeneral settings\u201D tab",
		ProvidersDataNotAvailableBlankSlate: "Email provider list is not available. Check the connections to Email service in \u0022General settings\u0022 tab. ",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		NewRecordPageCaptionSuffix: ": New record",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "Email settings",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "BpmonlineCloudIntegrationPageV2",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});