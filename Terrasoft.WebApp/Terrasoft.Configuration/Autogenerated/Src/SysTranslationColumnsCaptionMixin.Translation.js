define("SysTranslationColumnsCaptionMixin", [], function() {
	/**
	 * Mixin for the SysTranlation columns configure.
	 */
	Ext.define("Terrasoft.configuration.mixins.SysTranslationColumnsCaptionMixin", {
		alternateClassName: "Terrasoft.SysTranslationColumnsCaptionMixin",

		/**
		 * @private
		 */
		columnConfigure: function(entitySchemaColumns, columnsConfig) {
			Terrasoft.each(columnsConfig, function(columnConfig) {
				var schemaColumn = entitySchemaColumns[columnConfig.Name];
				schemaColumn.caption = columnConfig.Caption;
				schemaColumn.usageType = columnConfig.UsageType;
			}, this);
		},

		/**
		 * Initialization "SysTranslation" schema columns properties.
		 * @public
		 * @param {Function} entitySchemaColumns entity schema columns.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback execution scope.
		 */
		initSysTranslationColumnsProperties: function(entitySchemaColumns, callback, scope) {
			var request = this.Ext.create(Terrasoft.ConfigurationServiceRequest, {
				serviceName: "TranslationConfigureService",
				contractName: "GetConfiguredSysTranslationColumns"
			});
			request.execute(function(response) {
				var columnsConfig;
				if(response.success) {
					columnsConfig = response.ColumnsConfig;
					this.columnConfigure(entitySchemaColumns, columnsConfig);
				}
				if(callback) {
					callback.call(scope || this, columnsConfig);
				}
			}, this);
		}
		
	});

	return Terrasoft.SysTranslationColumnsCaptionMixin;
});