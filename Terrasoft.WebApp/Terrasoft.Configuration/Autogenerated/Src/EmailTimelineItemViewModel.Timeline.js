define("EmailTimelineItemViewModel", ["ConfigurationConstants", "BaseTimelineItemViewModel",
		"EmailTimelineItemViewModelResources", "EmailActionsMixin"],
	function(ConfigurationConstants) {
		/**
		 * @class Terrasoft.configuration.EmailTimelineItemViewModel
		 * Email timeline item view model class.
		 */
		Ext.define("Terrasoft.configuration.EmailTimelineItemViewModel", {
			alternateClassName: "Terrasoft.EmailTimelineItemViewModel",
			extend: "Terrasoft.BaseTimelineItemViewModel",

			mixins: {
				EmailActionsMixin: "Terrasoft.EmailActionsMixin",
			},

			// region Properties: Protected

			/**
			 * Sender name and address parse regexp.
			 * @type {String}
			 */
			emailContactInfoRegExp: "(.+) <(.+)>",

			/**
			 * Email new line parse regexp.
			 * @type {RegExp}
			 */
			emailNewLineRegExp: /\n/g,

			/**
			 * Email new line html tag.
			 * @type {String}
			 */
			emailNewLineHtml: "<br />",

			/**
			 * Email is html regexp.
			 * @type {RegExp}
			 */
			emailIsHtmlRegExp: /<[a-z/][\s\S]*>/i,

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.prepareEmailMessage();
			},

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				this.set("ShowAuthorIcon", true);
				this.set("UseAuthorCaption", true);
				this.set("RecipientName", this.getRecipientName());
			},

			/**
			 * Checks if text is html.
			 * @protected
			 * @param {String} text Text.
			 * @return {Boolean}
			 */
			isHtmlText: function(text) {
				return this.emailIsHtmlRegExp.test(text);
			},

			/**
			 * Prepares email message.
			 * @protected
			 */
			prepareEmailMessage: function() {
				var message = this.$Message || "";
				if (!this.isHtmlText(message)) {
					this.$Message = message.replace(this.emailNewLineRegExp, this.emailNewLineHtml);
				} else {
					this.$Message = this.replaceImportantHeight(message);
				}
			},

			/**
			 * Returns feature enabled state.
			 * @param {String} code Feature code.
			 * @return {Boolean} Is feature enabled.
			 */
			getIsFeatureEnabled: function(code) {
				return Terrasoft.Features.getIsEnabled(code);
			},

			/**
			 * Returns email author name.
			 * @protected
			 * @param {String} emailAuthor Sender.
			 * @return {String}
			 */
			getEmailAuthorName: function(emailAuthor) {
				var emailAuthorName = "";
				if (!Ext.isEmpty(emailAuthor)) {
					var regExp = new RegExp(this.emailContactInfoRegExp);
					var emailAuthorInfo = emailAuthor.match(regExp);
					emailAuthorName = emailAuthorInfo ? emailAuthorInfo[1] : emailAuthor;
				}
				return emailAuthorName;
			},

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#getAuthorName
			 * @override
			 */
			getAuthorName: function() {
				var author;
				var participants = this.get("Participants") || [];
				var participantsFrom = participants && participants.filter(function(item) {
					return item?.Role?.value === ConfigurationConstants.Activity.ParticipantRole.From;
				});
				if (participantsFrom.length > 0) {
					author = participantsFrom[0].Participant;
					this.set("Author", author);
				}
				return (author && author.displayValue) || this.getEmailAuthorName(this.get("AuthorEmail"));
			},

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#getAuthorUrl
			 * @override
			 */
			getAuthorUrl: function() {
				var author = this.get("Author");
				if (!Ext.isEmpty(author)) {
					return this.getEntityUrl(this.authorEntitySchemaName, author.value, null);
				}
				var mailTo = this.getEmailByColumnName(this.get("AuthorEmail"));
				if (mailTo) {
					return mailTo;
				}
				return null;
			},

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#onAuthorCaptionClick
			 * @override
			 */
			onAuthorCaptionClick: function() {
				var author = this.get("Author");
				var mailTo = this.getEmailByColumnName(this.get("AuthorEmail"));
				if (!Ext.isEmpty(author)) {
					this.openEntityCard(this.authorEntitySchemaName, author.value);
					return false
				}
				if (mailTo) {
					window.open(mailTo, '_self');
				}
				return false;
			},

			// endregion

			// region Methods: Public

			/**
			 * Returns recipient name.
			 * @return {String}
			 */
			getRecipientName: function() {
				var recipientName = Terrasoft.emptyString;
				var participants = this.get("Participants") || [];
				var to = this.get("RecipientEmail") || Terrasoft.emptyString;
				var participantsTo = participants && participants.filter(function(item) {
					return item?.Role?.value === ConfigurationConstants.Activity.ParticipantRole.To 
						&& item.Email !== Terrasoft.emptyString && to.toLowerCase().includes(item.Email.toLowerCase());
				});
				var currentParticipant = participantsTo.find(i => i.Participant.value === this.get("MasterRecordId"));
				if (!currentParticipant && participantsTo.length > 0) {
					currentParticipant = participantsTo[0];
				}
				if (currentParticipant) {
					this.set("Recipient", currentParticipant.Participant);
					recipientName = currentParticipant.Participant.displayValue;
				}
				recipientName = recipientName === Terrasoft.emptyString ? to : recipientName;
				return recipientName;
			},

			getEmailByColumnName: function(value) {
				var values = value.trim().split(";");
				var isSingleValue = values.length === 1 || values.length === 2 && values[1] === Terrasoft.emptyString;
				if (value.includes("@") && value.includes(".") && isSingleValue) {
					return "mailto:" + value;
				}
				return null;
			},


			/**
			 * Handles click on record recipient caption.
			 */
			onRecipientCaptionClick: function() {
				var recipient = this.get("Recipient");
				var mailTo = this.getEmailByColumnName(this.get("RecipientName"));
				if (Ext.isObject(recipient)) {
					this.openEntityCard(this.authorEntitySchemaName, recipient.value);
					return false;
				}
				if (mailTo) {
					window.open(mailTo, '_self');
				}
				return false;
			},

			/**
			 * Generates hyperlink URL for record recipient entity.
			 * @return {String|null} URL address if recipient column is defined, otherwise null.
			 */
			getRecipientUrl: function() {
				var recipient = this.get("Recipient");
				if (Ext.isObject(recipient)) {
					return this.getEntityUrl(this.authorEntitySchemaName, recipient.value, null);
				}
				var mailTo = this.getEmailByColumnName(this.get("RecipientName"));
				if (mailTo) {
					return mailTo;
				}
				return null;
			},

			recipientLinkVisible: function() {
				return !Terrasoft.isEmpty(this.getRecipientUrl());
			},

			recipientLabelVisible: function() {
				return Terrasoft.isEmpty(this.getRecipientUrl());
			},

			/**
			 * Handles on recipient link mouse over.
			 * @param {Object} target Target object.
			 */
			recipientLinkMouseOver: function(target) {
				var recipient = this.get("Recipient");
				if (!Ext.isEmpty(this.authorEntitySchemaName) && !Ext.isEmpty(recipient)) {
					this.showMiniPage({
						targetId: target.targetId,
						entitySchemaName: this.authorEntitySchemaName,
						recordId: recipient.value
					});
				}
			},

			/**
			 * Returns body style for email message iframe element.
			 * @return {Object} Object with styles.
			 */
			getMessageIframeBodyStyle: function() {
				var isCollapsed = this.get("IsCollapsed");
				return {
					"overflow": isCollapsed ? "hidden" : "auto",
					"margin": 0,
					"font-family": "Verdana",
					"font-size": "12.4px",
					"lineHeight": "18px",
					"color": "#444444",
					"word-break": "break-word"
				}
			}

			// endregion

		});
	});
