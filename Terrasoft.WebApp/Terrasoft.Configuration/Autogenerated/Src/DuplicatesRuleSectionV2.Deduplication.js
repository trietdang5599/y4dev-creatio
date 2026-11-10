 define("DuplicatesRuleSectionV2", ["DuplicatesRuleSectionV2Resources"],
	function() {
		return {
			methods: {
				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.Ext.create("Terrasoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ContactsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openContactDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.AccountsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openAccountDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuSeparator());
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ScheduleCaption"
						},
						"Click": {
							"bindTo": "openScheduleSettingPage"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * Goes to contact duplicates search page.
				 * @protected
				 */
				openContactDuplicatesModule: function() {
					this.openDuplicatesModule("Contact");
				},

				/**
				 * Goes to account duplicates search page.
				 * @protected
				 */
				openAccountDuplicatesModule: function() {
					this.openDuplicatesModule("Account");
				},

				/**
				 * @inheritdoc
				 * @overridden
				 */
				openDuplicatesModule: function(entityName) {
					this.mixins.DuplicatesSearchUtilities.openDuplicatesModule.call(this, entityName);
				},

				//endregion
			}
		};
	});
