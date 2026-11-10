Ext.ns("Terrasoft.data.queries");

/**
 * Request for data localization changes
 * Example:
 *
 *  var esq = new Terrasoft.SelectLocalizationQuery({rootSchemaName: "SysDetail"});
 *  esq.addColumn("Caption", "cultureValue");
 *  esq.addColumn("[SysCulture:Id:SysCulture].Name", "cultureName");
 *  esq.execute(function(response) {}, this);
 */
Ext.define("Terrasoft.data.queries.SelectLocalizationQuery", {
	extend: "Terrasoft.EntitySchemaQuery",
	alternateClassName: "Terrasoft.SelectLocalizationQuery",
	/**
	 * Query type.
	 * @type {Terrasoft.QueryOperationType}
	 */
	operationType: Terrasoft.QueryOperationType.SELECT_LOCALIZATION,
});