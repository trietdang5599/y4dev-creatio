Terrasoft.configuration.Structures["SysProcessLogSectionV2GridRowViewModel"] = {innerHierarchyStack: ["SysProcessLogSectionV2GridRowViewModel"]};
define("SysProcessLogSectionV2GridRowViewModel", ["ext-base", "SysProcessLogSectionV2GridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext, resources) {
	/**
	 * @class Terrasoft.configuration.SysProcessLogSectionV2GridRowViewModel
	 */
	Ext.define("Terrasoft.configuration.SysProcessLogSectionV2GridRowViewModel", {
		extend: "Terrasoft.BaseSectionGridRowViewModel",
		alternateClassName: "Terrasoft.SysProcessLogSectionV2GridRowViewModel",

		/**
		 * @inheritdoc Terrasoft.BaseSectionGridRowViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initErrorInfo();
			this.initCancelExecutionButtonCaption();
		},

		/**
		 * ############## #######.
		 * @overridden
		 * @inheritdoc Terrasoft.configuration.BaseGridRowViewModel#initResources
		 */
		initResources: function() {
			this.callParent();
			if (!resources.localizableStrings) {
				return;
			}
			Terrasoft.each(resources.localizableStrings, function(value, key) {
				this.set("Resources.Strings." + key, value);
			}, this);
		},

		/**
		 * Set state of the Visible parameter of "DataGridActiveRowCancelExecution.
		 * @virtual
		 * @param {Boolean} flag state of the Visible parameter.
		 */
		setCancelExecutionButtonVisible: function (flag) {
			this.set("CancelExecutionButtonVisible", this.canCancelProcessExecution() && flag);
			this.set("CancelExecutionButtonCaption", resources.localizableStrings.ForceCancelExecutionButtonCaption);
		},

		/**
		 * Initial Caption property of "DataGridActiveRowCancelExecution
		 * @protected
		 */
		initCancelExecutionButtonCaption: function () {
			return this.set("CancelExecutionButtonCaption", resources.localizableStrings.CancelExecutionButtonCaption);
		},

		/**
		 * Determines whether an element has trace data or not.
		 * @returns {boolean} True if it has, false otherwise.
		 */
		getElementHasTraceData: function() {
			return this.get("TraceDataCount") > 0;
		},

		/**
		 * Returns flag, indicates that current log item has error description defined.
		 * @returns {boolean}
		 */
		hasErrorDescription: function() {
			return Boolean(this.getFullErrorDescription());
		},

		/**
		 * Initializes error description data for displaying in grid.
		 */
		initErrorInfo: function() {
			if (!this.hasErrorDescription()) {
				return;
			}
			this._sourceErrorDescription = this.$ErrorDescription;
			const newlineIndex = this._sourceErrorDescription.indexOf("\n");
			if (newlineIndex > -1) {
				this.$ErrorDescription = this._sourceErrorDescription.substring(0, newlineIndex);
			}
		},

		/**
		 * Returns full error description for current log item.
		 * @returns {String}
		 */
		getFullErrorDescription: function() {
			return this._sourceErrorDescription || this.$ErrorDescription;
		}
	});
	return Terrasoft.SysProcessLogSectionV2GridRowViewModel;
});


