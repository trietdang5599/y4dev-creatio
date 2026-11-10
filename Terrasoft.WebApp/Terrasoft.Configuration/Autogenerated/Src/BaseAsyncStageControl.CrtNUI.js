define("BaseAsyncStageControl", ["BaseStageControl"], function() {
	/**
	 * Class for BaseAsyncStageControl
	 */
	Ext.define("Terrasoft.controls.BaseAsyncStageControl", {
		extend: "Terrasoft.controls.BaseStageControl",
		alternateClassName: "Terrasoft.BaseAsyncStageControl",

		/**
		 * Changes value of current stage. Raises event activeStageClick.
		 * @protected
		 * @param {Object} stageItem Stage control element.
		 * @param {String} stageItem.id Stage primary value.
		 * @param {String} stageItem.caption Stage primary display value.
		 * @param {String} stageItem.isEnabled Stage enabled value.
		 */
		changeValueAsync: function(stageItem, callback, scope) {
			var value = stageItem.id;
			var oldValue = this.activeStageId;
			var displayValue = stageItem.caption;
			var isChanged = this.getStageIsChanged(stageItem);
			if (isChanged && stageItem.isEnabled) {
				this.fireEvent("activeStageClick", oldValue, value, displayValue, this);
			}
		},

		/**
		 * @inheritdoc Terrasoft.BaseStageControl#changeStage
		 * @override
		 */
		changeStage: function(stageData) {
			this.changeValueAsync(stageData);
			this.safeRerender();
			return false;
		}
	});
});
