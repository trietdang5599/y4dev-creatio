define("ContactPageV2", ["ContactCommunication", "ConfigurationConstants", "ConfigurationFileApi"],
		function(ContactCommunication, ConfigurationConstants) {
	return {
		messages: {
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
			 * @inheritdoc Terrasoft.BasePageV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("SearchResultBySocialNetworks", this.onSearchResultBySocialNetworks, this);
			},

			/*
			 * ############ ######## ######## ######## ####### ##### ## ###. #####.
			 * @param {Object} config.selectedItems ###### ####### ####### ####### ##### ## ###. #####.
			 */
			onSearchResultBySocialNetworks: function(config) {
				var collection = config.selectedItems;
				if (collection.isEmpty()) {
					return;
				}
				var socialContact = collection.getByIndex(0);
				this.setPhotoFromSocialNetworks(socialContact);
				this.setNameFromSocialNetworks(socialContact);
			},

			/*
			 * #### # ######## ###### #### "###" ## ############# ### ########
			 * ## ######### ###### ###### ########## ########## ######## ## ###. ####.
			 * @param {Object} socialContact ###### ########## ########## ######## ## ###. ####.
			 */
			setNameFromSocialNetworks: function(socialContact) {
				if (!this.Ext.isEmpty(this.get("Name")) || this.Ext.isEmpty(socialContact)) {
					return;
				}
				var name = socialContact.get("Name");
				if (name) {
					this.set("Name", name);
				}
			},

			/*
			 * #### # ######## ### #### ## ############# ####
			 * ## ######### ###### ###### ########## ########## ######## ## ###. ####.
			 * @param {Object} socialContact ###### ########## ########## ######## ## ###. ####.
			 */
			setPhotoFromSocialNetworks: function(socialContact) {
				var contactPhoto = this.get(this.primaryImageColumnName);
				if (!this.Ext.isEmpty(contactPhoto) || this.Ext.isEmpty(socialContact)) {
					return;
				}
				var isDefaultPhoto = socialContact.get("IsDefaultPhoto");
				var photoUrl = socialContact.get("Photo");
				if (isDefaultPhoto === true || this.Ext.isEmpty(photoUrl)) {
					return;
				}
				this.Terrasoft.ConfigurationFileApi.getImageFile(photoUrl, this.onPhotoChange, this);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#getActions
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuSeparator());
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "openSocialContactPage",
					"Caption": {bindTo: "Resources.Strings.FillContactWithSocialNetworksDataActionCaption"}
				}));
				return actionMenuItems;
			},

			/**
			 * ######## "########## ####### ## ###. #####".
			 */
			openSocialContactPage: function() {
				this.save({
					callback: function() {
						this.checkCanOpenSocialContactPage(function() {
							this.loadSocialContactPage();
						}, this);
					},
					callBaseSilentSavedActions: true,
					isSilent: true
				});
			},

			/**
			 * #########, ######## ## ####### ## ######## ########## ######## ## ######## #######.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ###### ####### ######### ######.
			 */
			checkCanOpenSocialContactPage: function(callback, scope) {
				this.checkHasSocialCommunications(function() {
					callback.call(scope);
				}, this);
			},

			/**
			 * #########, ########## ## ######## #####.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ###### ####### ######### ######.
			 */
			checkHasSocialCommunications: function(callback, scope) {
				var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchema: ContactCommunication
				});
				esq.addAggregationSchemaColumn(
					ContactCommunication.primaryColumnName, this.Terrasoft.AggregationType.COUNT, "Count");
				var contactFilter = this.Terrasoft.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL, "Contact", this.get("Id"));
				esq.filters.addItem(contactFilter);
				var socialTypeFilter = this.Terrasoft.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					"[ComTypebyCommunication:CommunicationType:CommunicationType].Communication",
					ConfigurationConstants.Communication.SocialNetwork);
				esq.filters.addItem(socialTypeFilter);
				esq.getEntityCollection(function(response) {
					if (!response.success) {
						throw new Terrasoft.UnknownException();
					}
					var queryResult = response.collection.getByIndex(0);
					var socialCommunicationsCount = queryResult.get("Count");
					if (socialCommunicationsCount === 0) {
						var message = this.get("Resources.Strings.FillContactQuestion");
						return this.showInformationDialog(message);
					}
					callback.call(scope);
				}, this);
			},

			/**
			 * ######### ###### ###### # ########## #####.
			 * @protected
			 */
			loadSocialContactPage: function() {
				var schemaName = "SocialContactPage";
				var primaryColumnValue = this.get("PrimaryColumnValue") || this.get(this.primaryColumnName);
				var hash = this.Terrasoft.combinePath("CardModuleV2", schemaName, "edit", primaryColumnValue);
				this.sandbox.publish("PushHistoryState", {hash: hash});
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
