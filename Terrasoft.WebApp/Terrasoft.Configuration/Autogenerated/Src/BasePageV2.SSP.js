define("BasePageV2", ["PortalClientConstants", "SchemaAccessControllerMixin"], function (PortalConsts) {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		mixins: {
			"SchemaAccessControllerMixin": "Terrasoft.SchemaAccessControllerMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @override
			 */
			init: function () {
				if (this._isNeedToCheckAccess()) {
					const historyState = this.getHistoryStateInfo();
					const hash = this.Terrasoft.combinePath("CardModuleV2", "cardSchema",
						historyState.operation, historyState.primaryColumnValue);
					const isRedirected = this.redirectIfDenied("cardSchema", hash);
					if (isRedirected) {
						return;
					}
				}
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_isNeedToCheckAccess: function() {
				return this.Terrasoft.isCurrentUserSsp() && !this.Terrasoft.isAngularHost &&
					this._checkDesignerPages() &&
					!(this.$IsProcessMode || this.$IsInChain);
			},

			/**
			 * @private
			 */
			_checkDesignerPages: function () {
				return !this.Terrasoft.contains(Object.values(PortalConsts.DesignerPagesName), this.name);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
