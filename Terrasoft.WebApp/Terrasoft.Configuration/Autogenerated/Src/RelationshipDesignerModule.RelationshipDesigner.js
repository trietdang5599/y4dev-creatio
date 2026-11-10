define("RelationshipDesignerModule", ["BaseModule", "RelationshipDesignerComponent"], function() {
	Ext.define("Terrasoft.RelationshipDesignerModule", {
		extend: "Terrasoft.configuration.BaseModule",

		messages: {
			"GetColumnsValues": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			"GetEntityInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			"UpdateRelationshipDesigner": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},

		// region Methods: Private

		_getMasterEntityInfo: function() {
			return this.sandbox.publish("GetEntityInfo", null, [this.sandbox.id]);
		},

		_subscribeUpdateDesignerMessage: function() {
			this.sandbox.subscribe(
				"UpdateRelationshipDesigner", this._onUpdateRelationshipDesigner, this, [this.sandbox.id]);
		},

		_onUpdateRelationshipDesigner: function(entityInfo) {
			if (!this.relationshipComponent || this.relationshipComponent.destroyed) {
				return false;
			}
			return this.relationshipComponent.setDiagramData({
				selectedRecordId: entityInfo.primaryColumnValue,
				schemaName: entityInfo.entitySchemaName
			});
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.BaseModule#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages(this.messages);
			this._subscribeUpdateDesignerMessage();
		},

		/**
		 * Render designer.
		 * @param {Ext.Element} renderTo Container to render designer.
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this.relationshipComponent = this.Ext.create("Terrasoft.RelationshipDesignerComponent", {
				id: "relationship-designer-component",
				classes: {
					wrapClassName: ["diagram", "ts-box-sizing"]
				}
			});
			const diagramContainer = this.Ext.create("Terrasoft.Container", {
				id: "relationship-designer-ct",
				classes: {
					wrapClassName: ["schema-designer", "ts-box-sizing"]
				},
				items: [this.relationshipComponent]
			});
			const masterEntityInfo = this._getMasterEntityInfo();
			this.relationshipComponent.setDiagramData({
				selectedRecordId: masterEntityInfo.primaryColumnValue,
				schemaName: masterEntityInfo.entitySchemaName
			});
			diagramContainer.render(renderTo);
		},

		/**
		 * @inheritDoc Terrasoft.BaseModule#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			if (this.relationshipComponent) {
				this.relationshipComponent = null;
			}
			this.callParent(arguments);
		}

		// endregion

	});

	return Terrasoft.RelationshipDesignerModule;
});
