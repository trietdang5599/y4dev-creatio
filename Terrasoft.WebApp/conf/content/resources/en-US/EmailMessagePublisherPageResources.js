define("EmailMessagePublisherPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SendEmailForUserQuestion: "Fill in the \u0022From:\u0022 field to send the message",
		RecepientEmailForUserQuestion: "Fill in at least one of the \u0022To:\u0022, \u0022Cc:\u0022 or \u0022Bcc:\u0022 fields in order to send the email",
		EmailFormatString: "{0} \u003C{1}\u003E;",
		AddEmailForUserQuestion: "Mailbox synchronization parameters must be configured in order to be able to send emails. Configure parameters?",
		MailboxDoesntExist: "Mailbox synchronization parameters must be set up in order to send email messages.",
		CC: "CC",
		BCC: "BCC",
		SenderCaption: "From",
		SendButtonCaption: "Send",
		WriteEmailPostHint: "Your message will be sent via email",
		DraftBodyMessage: "DRAFT",
		EmailMaskCaption: "Email is sent",
		EmailTitleCaption: "Subject",
		TemplateButtonCaption: "Templates",
		MacroTemplate: "[#{0}#]",
		SubjectIsEmptyMessageToUser: "Field \u0022Subject\u0022: Enter a value",
		RecipientCaption: "To",
		CopyRecepientCaption: "Cc",
		BlindCopyRecepientCaption: "Bcc",
		ReplyBodyQuotesHtmlTemplate: "\u003Cblockquote style=\u0022margin-left: 0.8ex; border-left: 1px solid rgb(204,204,204); padding-left: 1ex; font: inherit\u0022\u003E{0}\u003C/blockquote\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ToolbarVisibilityButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailMessagePublisherPage",
				resourceItemName: "ToolbarVisibilityButtonImage",
				hash: "e39cdfcbd783ac8516bac5b856031c88",
				resourceItemExtension: ".png"
			}
		},
		TemplateButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailMessagePublisherPage",
				resourceItemName: "TemplateButtonImage",
				hash: "cab55b7fe67011de8d606f8a7ae2ed6c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});