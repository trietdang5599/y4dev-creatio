define("BusinessRuleSectionResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddNewRuleButtonCaption: "Add business rule",
		OpenButtonCaption: "Open",
		BusinessRuleGridNameCaption: "Name",
		BusinessRuleGridDescriptionCaption: "Description",
		BusinessRuleGridPageCaption: "Page",
		DisableButtonCaption: "Disable",
		EnableButtonCaption: "Enable",
		ConfirmRemoveBusinessRuleMessage: "Business rule will be removed. Continue?",
		BusinessRuleGridEnabledCaption: "State",
		BusinessRuleGridEnabledText: "Enabled",
		BusinessRuleGridDisabledText: "Disabled",
		InvalidRulePrefix: "(Invalid rule)",
		EmptyInfoTitle: "This section has no records.",
		EmptyInfoRecommendation: "Learn more about this section from the \u003Ca target=\u0022_blank\u0022 href=\u0022{0}\u0022\u003EAcademy\u003C/a\u003E.",
		EmptyInfoDescription: "Add a new record to make it look prettier.",
		InvalidBusinessRuleSectionLabel: "Unable to modify business rules because the \u0022{0}\u0022 page source code contains invalid json symbols. Your system administrator will have to delete these symbols. After the mentioned above symbols have been deleted, you need to re-open the wizard, and business rules will be available for edit.",
		CantEditMessageText: "This business rule is not available in the current browser. You can configure it in another browser - Google Chrome or Mozilla Firefox.",
		AddButtonCaption: "New",
		DeleteButtonCaption: "Delete",
		EditButtonCaption: "Edit"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "BusinessRuleSection",
				resourceItemName: "EmptyInfoImage",
				hash: "f7367adb83003fc8600e74023d24be5c",
				resourceItemExtension: ".svg"
			}
		},
		InvalidBusinessRuleSectionImage: {
			source: 3,
			params: {
				schemaName: "BusinessRuleSection",
				resourceItemName: "InvalidBusinessRuleSectionImage",
				hash: "fe6489ee78ae1e42bf52ac05d4dfac7a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});