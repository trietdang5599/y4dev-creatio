/**
 * Class that represents request to get process element multi-instance trace data.
 */
﻿Ext.define("Terrasoft.process.ProcessMultiInstanceTraceDataRequest", {
	extend: "Terrasoft.BaseProcessLogRequest",
	alternateClassName: "Terrasoft.ProcessMultiInstanceTraceDataRequest",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName.
	 * @protected
	 * @override
	 */
	contractName: "GetProcessMultiInstanceTraceData",

	//endregion

	//region Properties: Public

	/**
	 * SysProcessLog identifier.
	 */
	iteratorElementId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.iteratorElementId = this.iteratorElementId;
	}

	//endregion

});
