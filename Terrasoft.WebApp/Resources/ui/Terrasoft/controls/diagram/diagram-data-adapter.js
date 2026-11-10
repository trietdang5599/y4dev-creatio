/**
 * Data converter adapter for diagram component.
 */
Ext.define("Terrasoft.diagram.DiagramDataAdapter", {
	extend: "Terrasoft.BaseDiagramDataAdapter",
	alternateClassName: "Terrasoft.DiagramDataAdapter",

	// region Methods: Private

	/**
	 * @private
	 */
	_getUserTaskType: function(item) {
		const items = Terrasoft.ProcessFlowElementSchemaManager.getItems().getItems();
		const schema = items.find((x) => x.uId === item.managerItemUId);
		if (!schema) {
			return null;
		}
		const schemaInstance = schema.instance;
		const type = this.getType(item);
		return (type === "userTask") ? Terrasoft.toLowerCamelCase(schemaInstance.name) : schemaInstance.type;
	},

	// endregion

	// region Methods: Protected

	/**
	 * @override
	 */
	hasEmbeddedLabel: function(item) {
		const embeddedLabels = ["lane", "laneSet", "eventSubProcessExpanded"];
		const type = this.getType(item);
		return embeddedLabels.includes(type);
	},

	/**
	 * @override
	 */
	getExecutedCountLabels: function(item) {
		if (item.executedCount <= 0) {
			return null;
		}
		return this.callParent(arguments);
	},

	/**
	 * @override
	 */
	getType: function(item) {
		const typeResolver = Ext.create("Terrasoft.diagram.ProcessDiagramTypeResolver");
		let type = typeResolver.toDiagramType(item);
		if (!type) {
			console.warn("Not supported class" + item.$className);
			type = "userTask";
		}
		return type;
	},

	/**
	 * @override
	 */
	getElementConfig: function(schema, item) {
		const config = this.callParent(arguments);
		if (!config) {
			return null;
		}
		const userTaskType = this._getUserTaskType(item);
		Ext.apply(config, { userTaskType });
		return config;
	}

	// endregion

});
