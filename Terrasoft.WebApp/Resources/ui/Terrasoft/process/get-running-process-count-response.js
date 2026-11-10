/**
 * Returns count of the running process instances by schema Id or UId.
 */
Ext.define("Terrasoft.process.GetRunningProcessCountResponse", {
	extend: "Terrasoft.BaseResponse",
	alternateClassName: "Terrasoft.GetRunningProcessCountResponse",

	//region Properties: Public

	/**
	 * Count of the running process instances.
	 * @type {Integer}
	 */
	count: 0

	//endregion

});
