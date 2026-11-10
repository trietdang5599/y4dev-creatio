Terrasoft.configuration.Structures["LinkTimelineItemViewModel"] = {innerHierarchyStack: ["LinkTimelineItemViewModel"]};
define("LinkTimelineItemViewModel", ["LinkTimelineItemViewModelResources", "BaseTimelineItemViewModel"],
	function() {
		/**
		 * @class Terrasoft.configuration.LinkTimelineItemViewModel
		 * Link timeline item view model class.
		 */
		Ext.define("Terrasoft.configuration.LinkTimelineItemViewModel", {
			alternateClassName: "Terrasoft.LinkTimelineItemViewModel",
			extend: "Terrasoft.BaseTimelineItemViewModel",

			// region Methods: Public

			/**
			 * Returns link preview visible value.
			 * @return {Boolean}
			 * @obsolete
			 * Link preview is no longer supported starting from version 8.2.3.
			 */
			getLinkPreviewVisible: function() {
				return false;
			}

			// endregion

		});
	});


