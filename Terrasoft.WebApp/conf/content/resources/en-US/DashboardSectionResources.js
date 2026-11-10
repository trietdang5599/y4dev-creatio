define("DashboardSectionResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		summaryCaption: "{0}",
		opportunityByCategory: "OPPORTUNITIES BY CATEGORY",
		awaitingOpportunities: "UNPAID INVOICES",
		invoicesByStatus: "INVOICES BY STATUS",
		paymentByOwner: "PAYMENTS BY OWNER",
		opportunitySummaryCaption: "Dashboards: Opportunities",
		activitySummaryCaption: "Dashboards: Activities",
		noSummaryCaption: "Dashboards are not set up"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});