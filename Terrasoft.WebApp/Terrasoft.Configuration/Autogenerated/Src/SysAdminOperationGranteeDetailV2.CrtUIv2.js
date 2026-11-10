/**
 * Parent: BaseOperationGranteeDetail
 */
define("SysAdminOperationGranteeDetailV2", ["RightsServiceHelper", "SysAdminOperationGranteeDetailV2Resources"], function() {
	return {
		entitySchemaName: "SysAdminOperationGrantee",
		mixins: {
			RightsServiceHelper: "Terrasoft.RightsServiceHelper"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseOperationGranteeDetail#checkCanChangeGrantee
			 * @overridden
			 */
			checkCanChangeGrantee: function(callbackAllow, callbackDenied, scope) {
				this.checkCanChangeAdminOperationGrantee(callbackAllow, callbackDenied, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseOperationGranteeDetail#deleteGrantees
			 * @overridden
			 */
			deleteGrantees: function(itemIds, callback, scope) {
				this.deleteAdminOperationGrantee(itemIds, callback, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseOperationGranteeDetail#insertGrantees
			 * @overridden
			 */
			setOperationGrantees: function(adminUnitIds, canExecute, callback, scope) {
				const adminOperationId = this.get("MasterRecordId");
				this.setAdminOperationGrantees(adminOperationId, adminUnitIds, canExecute, callback, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseOperationGranteeDetail#setGranteePosition
			 * @overridden
			 */
			setGranteePosition: function(itemId, position, callback, scope) {
				this.setAdminOperationGranteePosition(itemId, position, callback, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseOperationGranteeDetail#getAdminUnitLookupFilters
			 * @overridden
			 */
			getAdminUnitLookupFilters: function() {
				const filterGroup = this.callParent(arguments);
				const operationFilter = this.Terrasoft.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL, "SysAdminOperation", this.get("MasterRecordId"));
				filterGroup.subFilters.addItem(operationFilter);
				return filterGroup;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
	};
});
