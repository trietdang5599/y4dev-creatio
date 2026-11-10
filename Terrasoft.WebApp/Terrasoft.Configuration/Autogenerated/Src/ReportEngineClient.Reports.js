define("ReportEngineClient", ["ConfigurationServiceProvider"], function() {
	Ext.ns("Terrasoft.Reporting.Enums");

	/**
	 * Report type.
	 * @type {Object.<String, Number>}
	 */
	Terrasoft.Reporting.Enums.ReportType = {
		MsWord: 1,
		FastReport: 2
	};

	/**
	 * Report engine client.
	 */
	Ext.define("Terrasoft.Configuration.ReportEngineClient", {
		extend: "Terrasoft.BaseObject",

		/**
		 * @private
		 */
		_getReportTemplates: function(callback, scope) {
			const config = {
				serviceName: "ReportEngineService",
				methodName: "GetReportTemplates"
			};
			Terrasoft.ConfigurationServiceProvider.callService(config, function(response, isSuccess) {
				if (!isSuccess || !response) {
					callback.call(this, null);
					return;
				}
				const templates = response && response.reportTemplates;
				Ext.callback(callback, scope, [templates]);
			}, this);
		},

		/**
		 * Returns available report templates information.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getReportTemplates: function(callback, scope) {
			this._getReportTemplates(function(reports) {
				const reportsCollection = Ext.create("Terrasoft.Collection");
				Terrasoft.each(reports, function(info) {
					reportsCollection.add(info.id, {
						value: info.id,
						displayValue: info.caption,
						entitySchemaName: info.entitySchemaName,
						reportType: info.type
					});
				}, this);
				Ext.callback(callback, scope, [reportsCollection]);
			}, scope);
		}
	});

	return Ext.create("Terrasoft.Configuration.ReportEngineClient");
});
