define("BaseSectionV2", ["EmailLinksMixin"], function() {
	return {
		mixins: {
			/**
			 * Provides methods for email sending.
			 */
			"EmailLinksMixin": "Terrasoft.EmailLinksMixin"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.initSyncMailboxCount();
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId, columnName) {
				var handled = false;
				var column = this.columns[columnName];
				if (column && column.name !== this.primaryDisplayColumnName && !column.isLookup) {
					var row = this.getGridDataRow(rowId);
					var emailConfig = this.getEmailConfig(rowId, row.get(columnName),
						row.get(this.primaryDisplayColumnName));
					handled = this.emailLinkClicked(emailConfig);
				}
 				return !handled && this.callParent(arguments);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[ ]/**SCHEMA_DIFF*/
	};
});
