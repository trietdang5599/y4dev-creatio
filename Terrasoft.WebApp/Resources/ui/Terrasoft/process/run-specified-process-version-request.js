/**
 * Class represents request that runs specified process version.
 */
Ext.define("Terrasoft.process.RunSpecifiedProcessVersionRequest", {
	extend: "Terrasoft.RunProcessRequest",
	alternateClassName: "Terrasoft.RunSpecifiedProcessVersionRequest",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "RunSpecifiedProcessVersion"

	//endregion

});
