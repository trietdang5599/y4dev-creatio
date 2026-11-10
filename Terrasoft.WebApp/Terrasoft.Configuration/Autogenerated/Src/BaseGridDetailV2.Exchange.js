define("BaseGridDetailV2", ["EmailLinksMixin"], function() {
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
			 * @inheritdoc Terrasoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.initSyncMailboxCount();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseGridDetailV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId, columnName) {
				var handled = false;
				var column = this.columns[columnName];
				if (column && column.name !== this.primaryDisplayColumnName && !column.isLookup) {
					var data = this.getGridData();
					var row = data.get(rowId);
					var emailConfig = this.getEmailConfig(rowId, row.get(columnName));
					handled = this.emailLinkClicked(emailConfig);
				}
				return !handled && this.callParent(arguments);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[ ]/**SCHEMA_DIFF*/
	};
});
