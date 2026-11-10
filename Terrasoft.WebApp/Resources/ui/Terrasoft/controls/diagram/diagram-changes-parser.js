/**
 * Diagram changes parser.
 */
Ext.define("Terrasoft.diagram.DiagramChangesParser", {
	alternateClassName: "Terrasoft.DiagramChangesParser",

	// region Methods: Private

	/**
	 * @private
	 */
	_log: function(message) {
		if (Terrasoft.isDebug) {
			console.log(message);
		}
	},

	/**
	 * @private
	 */
	_getCommand: function(change) {
		return change.commandType;
	},

	/**
	 * @private
	 */
	_getConnectionWaypointsValues: function(values) {
		const waypoints = Terrasoft.deepClone(values.waypoints);
		waypoints.pop();
		waypoints.shift();
		return waypoints.map((waypoint) => {
				if (waypoint.hasOwnProperty("original") && !waypoint.original) {
					delete waypoint.original;
				}
				return waypoint;
			});
	},

	/**
	 * @private
	 */
	_getConnectionItemValues: function(values, item) {
		values.name = item.name;
		return values;

	},

	/**
	 * @private
	 */
	_getElementItemValue: function(values) {
		const item = {
			"id": values.id,
			"caption": values.caption,
			"parent": values.parent,
			"type": values.type,
			"size": {
				"height": values.height,
				"width": values.width
			},
			"position": {
				"rx": values.rx,
				"ry": values.ry
			}
		};
		if (values.defaultParamValues) {
			item.defaultParamValues = values.defaultParamValues;
		}
		if (values.source) {
			item.source = values.source;
		}
		return item;
	},

	/**
	 * @private
	 */
	_getLabelItemValue: function(values) {
		return {
			id: values.id,
			parentUId: values.parent,
			x: values.rx,
			y: values.ry,
			nodeType: Terrasoft.diagram.UserHandlesConstraint.Label
		};
	},

	/**
	 * @private
	 */
	_findElementId: function(path, values) {
		return path[1] || Object.keys(values)[0];
	},

	/**
	 * @private
	 */
	_applyWaypointsValues: function(values) {
		const waypoints = this._getConnectionWaypointsValues(values);
		if (!Ext.isEmpty(waypoints)) {
			values.polylinePointPositions = waypoints;
		}
	},

	/**
	 * @private
	 */
	_applyPortPositionsValues: function(values) {
		const portPositions = this._getPortPositions(Terrasoft.deepClone(values));
		if (!Ext.isEmpty(portPositions)) {
			values.portPositions = portPositions;
		}
	},

	_getCenterWaypoints: function(values) {
		const waypoints = Terrasoft.deepClone(values.waypoints)
			.map((waypoint) => {
				delete waypoint.original;
				return waypoint;
		});
		const centerPoints = [];
		centerPoints.push(waypoints.shift(), waypoints.pop());
		return centerPoints;
	},

	/**
	 * @private
	 */
	_getPortPositions: function(values) {
		const waypoints = this._getConnectionWaypointsValues(values);
		let portPosition;
		if (!Ext.isEmpty(waypoints) && waypoints.length > 0) {
			const centerPoints = this._getCenterWaypoints(values);
			portPosition = {
				source: {position: centerPoints[0], side: waypoints[0]},
				target: {position: centerPoints[centerPoints.length - 1], side: waypoints[waypoints.length - 1]}
			};
		} else {
			const centerPoints = this._getCenterWaypoints(values);
			portPosition = {
				source: {position: centerPoints[0]},
				target: {position: centerPoints[centerPoints.length - 1]}
			};
		}
		return portPosition;
	},

	/**
	 * @private
	 */
	_getChangeForConnectionUpdate: function(values, item, items) {
		let changes;
		switch (true) {
			case values.hasOwnProperty("waypoints"):
				changes = [{
					name: item.name,
					polylinePointPositions: this._getConnectionWaypointsValues(values),
					portPositions: this._getPortPositions(values)
				}];
				break;
			default:
				changes = [{
					name: item.name,
					itemValue: this._getConnectionItemValues(values, item, items)
				}];
		}
		return changes;
	},

	/**
	 * @private
	 */
	isSizeChange: function(values) {
		return Object.keys(values).length > 0 && (values.hasOwnProperty("width") || values.hasOwnProperty("height"));
	},

	/**
	 * @private
	 */
	isPositionChange: function(values) {
		return values.hasOwnProperty("rx") || values.hasOwnProperty("ry");
	},

	/**
	 * @private
	 */
	isParentChange: function(values) {
		return values.hasOwnProperty("parent");
	},

	/**
	 * @private
	 */
	_isCaptionChange: function(values) {
		return values.hasOwnProperty("caption");
	},

	/**
	 * @private
	 */
	_tryApplySchemaChanges: function({schemaChanges, type, operation, id, newValues}) {
		if (type === "elements" && operation === "update") {
			if (newValues.hasOwnProperty("caption")) {
				// TODO: CRM-52108
				return true;
			}
			const addSchemaChange = schemaChanges.add.elements.find((x) => x.itemValue.id === id);
			if (addSchemaChange) {
				if (this.isPositionChange(newValues)) {
					addSchemaChange.itemValue.position = {
						...addSchemaChange.itemValue.position,
						...newValues
					};
					return true;
				} else {
					this._log(`Unknown changes: ${JSON.stringify(newValues)}`);
				}
			}
		}
	},

	/**
	 * @private
	 */
	_collectConnectionChanges: function(operation, {newValues, item, items, id}) {
		let values;
		switch (operation) {
			case "add":
				const itemValue = newValues[id];
				this._applyWaypointsValues(itemValue);
				this._applyPortPositionsValues(itemValue);
				values = [{
					itemValue: itemValue
				}];
				break;
			case "update":
				values = this._getChangeForConnectionUpdate(newValues, item, items);
				break;
			case "remove":
				values = [{
					name: item.name,
					itemValue: newValues[id]
				}];
				break;
			default:
				this._log(`Unknown command: connection.${operation}`);
		}
		return values;
	},

	/**
	 * @private
	 */
	_collectElementChanges: function(operation, {newValues, item, id}) {
		let values;
		switch (operation) {
			case "update": {
				const newValue = {itemName: item.name};
				if (this.isSizeChange(newValues)) {
					newValue.size = {
						width: newValues.width || item.width,
						height: newValues.height || item.height
					};
				}
				if (this.isPositionChange(newValues)) {
					newValue.position = {};
					if (newValues.hasOwnProperty("rx")) {
						newValue.position.x = newValues.rx || item.position.X;
					}
					if (newValues.hasOwnProperty("ry")) {
						newValue.position.y = newValues.ry || item.position.Y;
					}
				}
				if (this.isParentChange(newValues)) {
					newValue.parent = newValues.parent;
				}
				if (this._isCaptionChange(newValues)) {
					newValue.caption = newValues.caption;
				}
				values = [newValue];
				break;
			}
			case "add":
				values = [{
					itemValue: this._getElementItemValue(newValues[id])
				}];
				break;
			case "remove":
				values = [{
					name: item.name,
					itemValue: newValues[id]
				}];
				break;
			default:
				this._log(`Unknown command: element.${operation}`);
		}
		return values;
	},

	/**
	 * @private
	 */
	_collectLabelChanges: function(operation, {newValues, item, id}) {
		let values;
		switch (operation) {
			case "update": {
				const newValue = {itemName: item.name};
				if (this.isPositionChange(newValues)) {
					const position = newValue.position = {};
					if (newValues.hasOwnProperty("rx")) {
						position.x = newValues.rx;
					}
					if (newValues.hasOwnProperty("ry")) {
						position.y = newValues.ry;
					}
					values = [newValue];
				}
				break;
			}
			case "add":
				values = [{
					itemValue: this._getLabelItemValue(newValues[id])
				}];
				break;
			case "remove":
				values = [{
					name: item.name,
					itemValue: newValues[id]
				}];
				break;
			default:
				this._log(`Unknown command: label.${operation}`);
		}
		return values;
	},

	/**
	 * @private
	 */
	_getChangeForSchema: function(operation, change, items, schemaChanges) {
		const {path, newValues} = change;
		const type = path[0];
		const id = this._findElementId(path, newValues);
		const item = items.findByPath("uId", id);
		if (!item && operation !== "add") {
			if (operation === "remove") {
				// TODO: CRM-52021
				return null;
			}
			const result = this._tryApplySchemaChanges({schemaChanges, type, operation, id, newValues});
			if (!result) {
				this._log(`${type}.${operation}: element was not found! ItemId: ${id}`);
			}
			return null;
		}
		let values;
		switch (type) {
			case "connections":
				values = this._collectConnectionChanges(operation, {newValues, item, items, id});
				break;
			case "elements":
				values = this._collectElementChanges(operation, {newValues, item, id});
				break;
			case "labels":
				values = this._collectLabelChanges(operation, {newValues, item, id});
				break;
			default: {
				this._log(`Not support type: ${type}`);
				this._log(change);
			}
		}
		return {type, operation, values};
	},

	/**
	 * @private
	 */
	_applyChanges: function(schemaChanges, itemChange) {
		let operation = schemaChanges[itemChange.operation];
		if (operation) {
			let changes = operation[itemChange.type];
			if (changes) {
				changes = changes.concat(itemChange.values);
			} else {
				changes = itemChange.values;
			}
			operation[itemChange.type] = changes;
		} else {
			operation = {[itemChange.type]: itemChange.values};
		}
		schemaChanges[itemChange.operation] = operation;
	},

	// endregion

	// region Methods: Public

	/**
	 * Returns changes for implementing in schema.
	 * @param {Array} changes Changes from diagram component.
	 * @param {Terrasoft.Collection} items Process elements collection.
	 * @return {Array} Changes for implementing in process schema.
	 */
	getChangesForSchema: function(changes, items) {
		const schemaChanges = {};
		changes.forEach((change) => {
			const command = this._getCommand(change);
			const itemChange = this._getChangeForSchema(command, change, items, schemaChanges);
			if (itemChange && itemChange.values) {
				this._applyChanges(schemaChanges, itemChange);
			}
		});
		return schemaChanges;
	}

	// endregion

});
