Terrasoft.configuration.Structures["WidgetDuplicatesDetailViewModel"] = {innerHierarchyStack: ["WidgetDuplicatesDetailViewModel"]};
 define("WidgetDuplicatesDetailViewModel", ["ChatContactDuplicatesDetailViewModel"], 	function () {
	Ext.define("Terrasoft.configuration.ChatContactDuplicatesDetailViewModel", {
		extend: "Terrasoft.ChatContactDuplicatesDetailViewModel",
		alternateClassName: "Terrasoft.WidgetDuplicatesDetailViewModel",

		/**
		 * @inheritdoc Terrasoft.DuplicatesDetailViewModel#isBulkESDeduplicationEnabled
		 * @override
		 */
		isBulkESDeduplicationEnabled: function () {
			return Terrasoft.Features.getIsEnabled("BulkESDeduplication");
		}
	});
});


