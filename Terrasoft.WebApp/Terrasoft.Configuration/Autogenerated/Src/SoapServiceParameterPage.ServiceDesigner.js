define("SoapServiceParameterPage", ["ServiceEnums"], function() {
	return {
		mixins: {},
		messages: {},
		properties: {},
		modules: {},
		attributes: {
			/**
			 * Sequence element name.
			 */
			"SequenceElementName": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			"IsSoapHeader": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "onIsSoapHeaderChange"
			},

		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getAttributeMap
			 * @override
			 */
			getAttributeMap: function() {
				const attributeMap = this.callParent(arguments);
				return Ext.apply(attributeMap, {
					sequenceElementName: "SequenceElementName",
					isSoapHeader: "IsSoapHeader"
				});
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#onIsArrayChange
			 * @override
			 */
			onIsArrayChange: function() {
				if (!this.$IsArray) {
					this.$SequenceElementName = "item";
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getTrackedAttributes
			 * @override
			 */
			getTrackedAttributes: function() {
				const attributes = this.callParent(arguments);
				attributes.push("SequenceElementName");
				attributes.push("IsSoapHeader");
				return attributes;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getPathPlaceholder
			 * @override
			 */
			getPathPlaceholder: function() {
				if (this.$ParameterType === Terrasoft.services.enums.ServiceParameterType.BODY) {
					return "";
				}
				return this.callParent(arguments);
			},

			getAvailableServiceParameterTypes: function() {
				return [
					Terrasoft.services.enums.ServiceParameterType.BODY,
					Terrasoft.services.enums.ServiceParameterType.HTTP_HEADER,
					Terrasoft.services.enums.ServiceParameterType.COOKIE
				];
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns true if sequence item type allowed for parameter.
			 */
			isSequenceElementNameVisible: function() {
				return this.$Schema && this.$IsArray;
			},

			isIsSoapHeaderVisible: function() {
				return this.$Schema && this.$ParameterType === Terrasoft.services.enums.ServiceParameterType.BODY;
			},

			isIsSoapHeaderEnabled: function() {
				return this.$CanEditSchema && !this.$HasParent;
			},

			/**
			 * Returns hint for sequence element name.
			 * @public
			 * @return {String} sequence element name hint.
			 */
			getSequenceElementNameHint: function() {
				switch (this.$DataValueTypeName) {
					case Terrasoft.services.enums.DataValueTypeName.Object:
						return this.get("Resources.Strings.SequenceObjectElementNameTip");
					default:
						return this.get("Resources.Strings.SequenceElementNameTip");
				}
			},

			onIsSoapHeaderChange: function() {
				function setIsSoapHeader(item, value) {
					item.isSoapHeader = value;
					Terrasoft.each(item.itemProperties, (nestedItem) => {
						setIsSoapHeader(nestedItem, value);
					});
				}
				const rootItem = this.items.find(item => item.uId == this.$UId);
				Terrasoft.each(rootItem.itemProperties, (item) => {
					setIsSoapHeader(item, this.$IsSoapHeader);
				});
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "SequenceElementName",
				"index": 6,
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 8},
					"bindTo": "SequenceElementName",
					"caption": "$Resources.Strings.SequenceElementNameCaption",
					"controlConfig": {
						"markerValue": "ParameterSequenceElementNameMarker"
					},
					"visible": {"bindTo": "isSequenceElementNameVisible"},
					"enabled": "$CanEditSchema",
					"classes": {"wrapClassName": ["grid-layout-row"]},
					"tip": {"content": "$getSequenceElementNameHint"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "IsSoapHeader",
				"index": 7,
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 8},
					"bindTo": "IsSoapHeader",
					"caption": "$Resources.Strings.IsSoapHeaderCaption",
					"controlConfig": {
						"markerValue": "IsSoapHeaderMarker"
					},
					"visible": {"bindTo": "isIsSoapHeaderVisible"},
					"enabled": {"bindTo": "isIsSoapHeaderEnabled"},
					"classes": {"wrapClassName": ["grid-layout-row"]},
					"tip": {"content": "$Resources.Strings.IsSoapHeaderCaptionTip"}
				}
			},
		]/**SCHEMA_DIFF*/
	};
});
