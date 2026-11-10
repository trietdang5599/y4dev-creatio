Terrasoft.configuration.Structures["AngularStructureExplorerViewModel"] = {innerHierarchyStack: ["AngularStructureExplorerViewModel"]};
define("AngularStructureExplorerViewModel", [], function() {
	Ext.define("Terrasoft.configuration.AngularStructureExplorerViewModel", {
		alternateClassName: "Terrasoft.AngularStructureExplorerViewModel",
		extend: "Terrasoft.BaseViewModel",

		callback: null,
		scope: null,

		columns: {
			config: {dataValueType: Terrasoft.DataValueType.OBJECT}
		},

		_getGeneralizedDataValueType: function(type) {
			switch (type) {
				case Terrasoft.DataValueType.SHORT_TEXT:
				case Terrasoft.DataValueType.MEDIUM_TEXT:
				case Terrasoft.DataValueType.LONG_TEXT:
				case Terrasoft.DataValueType.RICH_TEXT:
				case Terrasoft.DataValueType.MAXSIZE_TEXT:
				case Terrasoft.DataValueType.TEXT:
				case Terrasoft.DataValueType.SECURE_TEXT:
				case Terrasoft.DataValueType.PHONE_TEXT:
				case Terrasoft.DataValueType.WEB_TEXT:
				case Terrasoft.DataValueType.EMAIL_TEXT:
				case Terrasoft.DataValueType.HASH_TEXT:
					return Terrasoft.DataValueType.TEXT;
				case Terrasoft.DataValueType.FLOAT:
				case Terrasoft.DataValueType.FLOAT0:
				case Terrasoft.DataValueType.FLOAT1:
				case Terrasoft.DataValueType.FLOAT2:
				case Terrasoft.DataValueType.FLOAT3:
				case Terrasoft.DataValueType.FLOAT4:
				case Terrasoft.DataValueType.FLOAT8:
					return Terrasoft.DataValueType.FLOAT;
				default:
					return type;
			}
		},

		_convertItemsDataValueTypeToGeneralized: function(items) {
			if (!Ext.isArray(items)) {
				return;
			}
			items.forEach(function(item) {
				if (item.data && item.data.dataValueType) {
					item.data.dataValueType = this._getGeneralizedDataValueType(item.data.dataValueType);
				}
			}, this);
		},

		_getArguments: function(result) {
			const value = Ext.isArray(result) ? result[0] : null;
			if (!value) {
				return;
			}
			return {
				caption: value.metaPathCaption.split('.'),
				dataValueType: value.data.dataValueType,
				isBackward: false,
				isLookup: value.data.isLookupType,
				leftExpressionCaption: value.metaPathCaption,
				leftExpressionColumnPath: value.columnPath,
				metaPath: value.metaPath.split('.'),
				path: value.columnPath.split('.'),
				referenceSchemaName: value.data.referenceSchemaName
			}
		},

		/**
		 * Handle selected.
		 * @param {Object} result Selected result.
		 */
		handleSelected: function(result) {
			this._convertItemsDataValueTypeToGeneralized(result);
			const args = this._getArguments(result);
			if (args) {
				this.callback.call(this.scope, args);
			}
		},
	});
	return Terrasoft.AngularStructureExplorerViewModel;
});


