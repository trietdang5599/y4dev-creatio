/**
 * Data converter adapter for diagram component.
 */
Ext.define("Terrasoft.diagram.BaseDiagramDataAdapter", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.BaseDiagramDataAdapter",

	/**
	 * Collection of items
	 * @private
	 * @type {String}
	 */
	defaultParent: "root1",

	// region Methods: Private

	/**
	 * @private
	 */
	_getProcessSchema: function(items) {
		return items.getItems().find((item) => Boolean(item.parentSchema)).parentSchema;
	},

	/**
	 * @private
	 */
	_getProcessCaption: function(schema) {
		return schema.caption.getValue();
	},

	/**
	 * @private
	 */
	_getProcessId: function(schema) {
		return schema.uId;
	},

	/**
	 * @private
	 */
	_getElements: function(schema, items) {
		const elements = {};
		Terrasoft.each(items, (item) => {
			const element = this.getElementConfig(schema, item);
			if (element) {
				elements[element.id] = element;
			}
		}, this);
		return elements;
	},

	/**
	 * @private
	 */
	_getExecutedCountLabels: function(items) {
		const labels = {};
		items
			.filter((item) => item.nodeType !== Terrasoft.diagram.UserHandlesConstraint.Label)
			.each((item) => {
				const label = this.getExecutedCountLabels(item, items);
				if (label) {
					Ext.apply(labels, label);
				}
			});
		return labels;
	},

	/**
	 * @private
	 */
	_getLabels: function(items) {
		const labels = {};
		items
			.filter((item) => item.nodeType === Terrasoft.diagram.UserHandlesConstraint.Label)
			.each((item) => {
				const label = this.getLabelConfig(item, items);
				if (label) {
					Ext.apply(labels, label);
				}
			});
		return labels;
	},

	/**
	 * @private
	 */
	_getConnections: function(items) {
		const connectionTypes = ["connection", "conditionalConnection", "defaultConnection"];
		return items.getItems().reduce((connections, item) => {
			const type = this.getType(item);
			if (connectionTypes.includes(type)) {
				connections[item.uId] = this.getConnectionConfig(item);
			}
			return connections;
		}, {});
	},

	_pointEqual: function(a, b) {
		return Math.abs(a - b) <= 2;
	},

	/**
	 * @private
	 */
	_isConnectionStraight: function(waypoints) {
		if (!waypoints || waypoints.length < 2) {
			return false;
		}
		for (let pointIndex = 0; pointIndex < waypoints.length - 1; pointIndex++) {
			const pointA = waypoints[pointIndex];
			const pointB = waypoints[pointIndex + 1];
			if (!this._pointEqual(pointA.x, pointB.x) && !this._pointEqual(pointA.y, pointB.y)) {
				return false;
			}
		}
		return true;
	},

	/**
	 * @private
	 */
	_getConnectionHintForElement: function(localPointPosition) {
		const directions = {
			"{X=0,Y=0}": "h",
			"{X=0,Y=1}": "t",
			"{X=0,Y=-1}": "b",
			"{X=-1,Y=0}": "l",
			"{X=1,Y=0}": "r",
			"{X=-1,Y=1}": "t",
			"{X=1,Y=1}": "t",
			"{X=-1,Y=-1}": "b",
			"{X=1,Y=-1}": "b"
		};
		return directions[localPointPosition] || "h";
	},

	/**
	 * @private
	 */
	_getConnectionHints: function(connection) {
		return [this._getConnectionHintForElement(connection.sourcePort) +
			":" + this._getConnectionHintForElement(connection.targetPort)];
	},

	/**
	 * @private
	 */
	_roundPoint: function(point) {
		point.x = Math.round(point.x);
		point.y = Math.round(point.y);
		return point;
	},

	/**
	 * @private
	 */
	_initializeOrthogonalSegments: function(waypoints) {
		const length = waypoints.length;
		if (length <= 2) {
			return;
		}
		const lastIndex = waypoints.length - 1;
		this._alignPoints(waypoints[0], waypoints[1]);
		this._alignPoints(waypoints[lastIndex], waypoints[lastIndex - 1]);
	},

	/**
	 * @private
	 */
	_alignPoints: function(sourcePoint, alignPoint) {
		if (this._pointEqual(sourcePoint.x, alignPoint.x)) {
			alignPoint.x = sourcePoint.x;
		}
		if (this._pointEqual(sourcePoint.y, alignPoint.y)) {
			alignPoint.y = sourcePoint.y;
		}
	},

	/**
	 * @private
	 */
	_isElement: function(item) {
		const constraint = Terrasoft.diagram.UserHandlesConstraint;
		const nonElements = [constraint.Lane, constraint.Connector, constraint.LaneSet, constraint.Label];
		return !nonElements.includes(item.nodeType);
	},

	// endregion

	// region Methods: Protected

	/**
	 * @protected
	 * @abstract
	 */
	hasEmbeddedLabel: Terrasoft.emptyFn,

	/**
	 * @protected
	 * @virtual
	 */
	getType: function () {
		return "shape";
	},

	/**
	 * @private
	 */
	_createItemLabelConfig: function(item) {
		return {
			parent: item.uId,
			backgroundType: item.executionCountLabelTag,
			fontColor: item.executionCountFontColor
		}
	},

	/**
	 * @private
	 */
	_createLabel: function(config) {
		return {
			id: config.id,
			parent: config.parent,
			type: "label",
			rx: 0,
			ry: config.offsetY || 0,
			caption: config.caption,
			horizontalAlignment: "center",
			verticalAlignment: "center",
			backgroundStyle: {
				type: config.backgroundType,
				fill: config.fillColor,
				padding: 4.5,
				filter: {
					name: "StatisticInfoShadow_filter",
					color: "#000",
					opacity: 0.4,
					offsetX: 1,
					offsetY: 2,
					blur: 2
				}
			},
			tooltip: config.tooltipText,
			style: {
				fill: config.fontColor
			}
		};
	},

	/**
	 * @protected
	 * @virtual
	 */
	addMultiInstanceLabels: function(item, labels, baseLabelConfig) {
		const drawMultiInstanceLabels = Terrasoft.Features.getIsEnabled("ExecutionDiagramMultiInstanceLabels") &&
			item instanceof Terrasoft.ProcessActivitySchema &&
			item.getIsMultiInstanceModeEnabled();
		if (drawMultiInstanceLabels) {
			const miTotalId = item.uId + "_miExecCount_completed_label";
			labels[miTotalId] = this._createLabel(Ext.apply(baseLabelConfig, {
				id: miTotalId,
				caption: item.completedCount.toString(),
				fillColor: item.executedMICompletedFillColor,
				offsetY: 25,
				tooltipText: item.completedCountTooltipText
			}));
			const miFailedId = item.uId + "_miExecCount_failed_label";
			labels[miFailedId] = this._createLabel(Ext.apply(baseLabelConfig, {
				id: miFailedId,
				caption: item.failedCount.toString(),
				fillColor: item.executedMIFailedFillColor,
				offsetY: 50,
				tooltipText: item.failedCountTooltipText
			}));
		}
	},

	/**
	 * @obsolete
	 * @protected
	 * @virtual
	 */
	getExecutedCountLabel: function(item) {
		const obsoleteMessage = Ext.String.format(Terrasoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
			"getExecutedCountLabel", "getExecutedCountLabels");
		console.warn(obsoleteMessage);
		return this.getExecutedCountLabels(item);
	},

	/**
	 * @protected
	 * @virtual
	 */
	getExecutedCountLabels: function(item, itemsCollection) {
		const labels = {};
		const id = item.uId + "_execCount_label";
		const baseLabelConfig = this._createItemLabelConfig(item);
		labels[id] = this._createLabel(Ext.apply(baseLabelConfig, {
			id: id,
			caption: item.executedCount.toString(),
			fillColor: item.executionCountFillColor
		}));
		this.addMultiInstanceLabels(item, labels, baseLabelConfig);
		return labels;
	},

	/**
	 * @protected
	 * @virtual
	 */
	getElementConfig: function(schema, item) {
		if (!this._isElement(item)) {
			return null;
		}
		const type = this.getType(item);
		const parent = schema.flowElements.find(item.parent) ? item.containerUId : this.defaultParent;
		return {
			type,
			parent,
			id: item.uId,
			itemName: item.name,
			caption: item.caption.getValue(),
			height: item.size.height,
			width: item.size.width,
			rx: item.position.X,
			ry: item.position.Y,
			markers: item.getMarkersConfig()
		};
	},

	/**
	 * @protected
	 */
	getLabelConfig: function(labelConfig, items) {
		const labels = {};
		const element = items.findByPath("uId", labelConfig.parentUId);
		if (!element) {
			console.warn(`Invalid diagram data: parent element with uId "${labelConfig.parentUId}" not found ` +
				`for label with uId "${labelConfig.uId}"`);
			return null;
		}
		const caption = element.caption && element.caption.getValue();
		if (!caption) {
			return null;
		}
		const label = labels[labelConfig.uId] = {
			id: labelConfig.uId,
			type: "label",
			parent: labelConfig.parentUId,
			itemName: labelConfig.name
		};
		if (!Terrasoft.isNull(labelConfig.x)) {
			label.rx = labelConfig.x;
		}
		if (!Terrasoft.isNull(labelConfig.y)) {
			label.ry = labelConfig.y;
		}
		return labels;
	},

	/**
	 * @protected
	 */
	getConnectionConfig: function(item) {
		const config = item.getDiagramConfig();
		const type = this.getType(item);
		const connectionConfig = {
			type,
			id: item.uId,
			itemName: item.name,
			caption: item.caption.getValue(),
			source: item.sourceRefUId,
			target: item.targetRefUId
		};
		const waypoints = [
			...[item.startPoint || config.sourcePoint],
			...(item.polylinePointPositions || []),
			...[item.endPoint || config.targetPoint]
		];
		this._initializeOrthogonalSegments(waypoints);
		waypoints.forEach((segment) => this._roundPoint(segment));
		if (this._isConnectionStraight(waypoints)) {
			connectionConfig.waypoints = waypoints;
		} else if (waypoints.length > 1) {
				connectionConfig.hints = {
					connectionStart: waypoints.shift(),
					connectionEnd: waypoints.pop(),
					preferredLayouts: this._getConnectionHints(config)
				};
			}
		return connectionConfig;
	},

	// endregion

	// region Methods: Public

	/**
	 * Returns diagram data from items collection.
	 * @public
	 * @param {Terrasoft.Collection} items Collection of items.
	 * @return {Object} Diagram data json.
	 */
	getDiagramData: function(items) {
		const schema = this._getProcessSchema(items);
		const caption = this._getProcessCaption(schema);
		const elements = this._getElements(schema, items);
		const connections = this._getConnections(items);
		const labels = this._getLabels(items);
		const executedCountLabels = this._getExecutedCountLabels(items);
		Ext.apply(labels, executedCountLabels);
		const documentation = "";
		const id = this._getProcessId(schema);
		return {caption, elements, connections, labels, documentation, id};
	}

	// endregion

});
