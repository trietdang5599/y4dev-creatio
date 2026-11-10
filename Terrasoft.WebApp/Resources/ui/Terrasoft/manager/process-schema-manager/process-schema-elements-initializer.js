Ext.define("Terrasoft.manager.ProcessSchemaElementsInitializer", {
	extend: "Terrasoft.manager.BaseProcessSchemaElementsInitializer",
	alternateClassName: "Terrasoft.ProcessSchemaElementsInitializer",

	// region Methods: Private

	/**
	 * Creates process lane set.
	 * @private
	 * @param {String} createdInSchemaUId Process schema identifier.
	 * @return {Terrasoft.ProcessLaneSetSchema}
	 */
	_createLaneSet: function(createdInSchemaUId) {
		const laneSet = Ext.create("Terrasoft.ProcessLaneSetSchema", {
			uId: Terrasoft.generateGUID(),
			name: "LaneSet1",
			createdInSchemaUId: createdInSchemaUId,
			modifiedInSchemaUId: createdInSchemaUId
		});
		laneSet.setLocalizableStringPropertyValue("caption", "LaneSet 1");
		return laneSet;
	},

	/**
	 * Creates process lane.
	 * @private
	 * @param {String} createdInSchemaUId Process schema identifier.
	 * @param {String} containerUId Parent element identifier.
	 */
	_createLane: function(createdInSchemaUId, containerUId) {
		const lane = Ext.create("Terrasoft.ProcessLaneSchema", {
			uId: Terrasoft.generateGUID(),
			name: "Lane1",
			containerUId: containerUId,
			createdInSchemaUId: createdInSchemaUId,
			modifiedInSchemaUId: createdInSchemaUId
		});
		lane.setLocalizableStringPropertyValue("caption", "Lane 1");
		return lane;
	},

	/**
	 * Creates process start event.
	 * @private
	 * @param {String} createdInSchemaUId Process schema identifier.
	 * @param {String} containerUId Parent element identifier.
	 */
	_createStartEvent: function(createdInSchemaUId, containerUId) {
		return Ext.create("Terrasoft.ProcessStartEventSchema", {
			uId: Terrasoft.generateGUID(),
			name: "StartEvent1",
			position: "50;184",
			containerUId: containerUId,
			createdInSchemaUId: createdInSchemaUId,
			modifiedInSchemaUId: createdInSchemaUId
		});
	},

	/**
	 * Creates process terminate event.
	 * @private
	 * @param {String} createdInSchemaUId Process schema identifier.
	 * @param {String} containerUId Parent element identifier.
	 */
	_createTerminateEvent: function(createdInSchemaUId, containerUId) {
		return Ext.create("Terrasoft.ProcessTerminateEventSchema", {
			uId: Terrasoft.generateGUID(),
			name: "TerminateEvent1",
			position: "600;184",
			containerUId: containerUId,
			createdInSchemaUId: createdInSchemaUId,
			modifiedInSchemaUId: createdInSchemaUId
		});
	},

	/**
	 * Creates process sequence flow.
	 * @private
	 * @param {String} createdInSchemaUId Process schema identifier.
	 */
	_createSequenceFlow: function(createdInSchemaUId) {
		return Ext.create("Terrasoft.ProcessSequenceFlowSchema", {
			uId: Terrasoft.generateGUID(),
			name: "SequenceFlow1",
			createdInSchemaUId: createdInSchemaUId,
			modifiedInSchemaUId: createdInSchemaUId
		});
	},

	// endregion

	// region Methods: Protected

	/**
	 * @override
	 * @param {Terrasoft.ProcessSchema} schema Process schema.
	 */
	initializeSchema: function(schema) {
		const schemaUId = schema.uId;
		const laneSet = this._createLaneSet(schemaUId);
		const lane = this._createLane(schemaUId, laneSet.uId);
		const startEvent = this._createStartEvent(schemaUId, lane.uId);
		const terminateEvent = this._createTerminateEvent(schemaUId, lane.uId);
		const sequenceFlow = this._createSequenceFlow(schemaUId);
		sequenceFlow.sourceRefUId = startEvent.uId;
		sequenceFlow.targetRefUId = terminateEvent.uId;
		schema.add(laneSet);
		schema.add(lane);
		schema.add(startEvent);
		schema.add(terminateEvent);
		schema.add(sequenceFlow);
	}

	// endregion

});