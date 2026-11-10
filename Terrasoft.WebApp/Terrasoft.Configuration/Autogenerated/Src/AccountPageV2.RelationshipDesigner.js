define("AccountPageV2", ["RelationshipDesignerMixin"], function() {
	return {
		attributes: {
			"UseRelationshipDesigner": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": Terrasoft.Features.getIsEnabled("UseRelationshipDesigner")
			}
		},
		messages: {
			"UpdateRelationshipDesigner": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			RelationshipDesignerMixin: "Terrasoft.RelationshipDesignerMixin"
		},
		methods: {

			// region Methods: Protected

			/**
			 * @override Terrasoft.BasePageV2#subscribeSandboxEvents
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.mixins.RelationshipDesignerMixin.subscribeSandboxEvents.apply(this, arguments);
			},

			/**
			 * @override Terrasoft.BaseSchemaViewModel#getModuleId
			 */
			getModuleId: function(moduleName) {
				if (moduleName === "RelationshipDesigner") {
					return this.mixins.RelationshipDesignerMixin.getRelationshipDesignerModuleSandboxId.apply(this);
				}
				return this.callParent(arguments);
			},

			/**
			 * @override Terrasoft.BaseEntityPage#updateDetails
			 */
			updateDetails: function() {
				this.callParent(arguments);
				this.loadRelationshipDesignerModule();
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "TabsContainer",
				"values": {
					"wrapClass": ["tabs-container"]
				}
			},
			{
				"operation": "merge",
				"name": "Relationships",
				"values": {
					"visible": {
						"bindTo": "UseRelationshipDesigner",
						"bindConfig": { "converter": "invertBooleanValue" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "RelationshipContainer",
				"parentName": "RelationshipTabContainer",
				"propertyName": "items",
				"values": {
					"id": "RelationshipContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"afterrerender": { "bindTo": "loadRelationshipDesignerModule" },
					"afterrender": { "bindTo": "loadRelationshipDesignerModule" },
					"visible": {
						"bindTo": "UseRelationshipDesigner"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
