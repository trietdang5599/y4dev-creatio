 define("DuplicatesMergeFreedomUIModule", ["DuplicatesMergeModuleV2", "DuplicatesMergeViewModelFreedomUI", "DuplicatesMergeViewConfigFreedomUI"],
	function() {
		Ext.define("Terrasoft.configuration.DuplicatesMergeFreedomUIModule", {
			extend: "Terrasoft.DuplicatesMergeModule",
			alternateClassName: "Terrasoft.DuplicatesMergeFreedomUIModule",

			viewModelClassName: "Terrasoft.DuplicatesMergeViewModelFreedomUI",
			viewConfigClassName: "Terrasoft.DuplicatesMergeViewConfigFreedomUI",

			/**
			 * @inheritDoc Terrasoft.configuration.BaseNestedModule#createView
			 * @overridden
			 */
			createView: function() {
				var viewConfig = Terrasoft.deepClone(this.viewConfig);
				var containerClassName = viewConfig.className || "Terrasoft.Container";
				return Ext.create(containerClassName, viewConfig);
			},

			createViewModel: function() {
				return Ext.create(this.viewModelClass, this.getViewModelConfig());
			}
		});
		
		return Terrasoft.DuplicatesMergeFreedomUIModule;
	});
