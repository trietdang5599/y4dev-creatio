Ext.ns("Terrasoft.diagram.enums");

Terrasoft.diagram.enums.ProcessDiagramType = {
	"Terrasoft.manager.ProcessLaneSchema": "lane",
	"Terrasoft.manager.ProcessLaneSetSchema": "laneSet",
	"Terrasoft.manager.ProcessStartEventSchema": "startEvent",
	"Terrasoft.manager.ProcessStartMessageSchema": "startEventMessage",
	"Terrasoft.manager.ProcessStartSignalSchema": "startEventSignal",
	"Terrasoft.manager.ProcessIntermediateCatchMessageSchema": "intermediateCatchEventMessage",
	"Terrasoft.manager.ProcessIntermediateCatchSignalSchema": "intermediateCatchEventSignal",
	"Terrasoft.manager.ProcessIntermediateCatchTimerSchema": "intermediateCatchEventTimer",
	"Terrasoft.manager.ProcessStartTimerEventSchema": "startEventTimer",
	"Terrasoft.manager.ProcessIntermediateThrowMessageSchema": "intermediateThrowEventMessage",
	"Terrasoft.manager.ProcessIntermediateThrowSignalSchema": "intermediateThrowEventSignal",
	"Terrasoft.manager.ProcessTerminateEventSchema": "endEvent",
	"Terrasoft.manager.ProcessExclusiveEventBasedGatewaySchema": "exclusiveEventBasedGateway",
	"Terrasoft.manager.ProcessExclusiveGatewaySchema": "exclusiveGateway",
	"Terrasoft.manager.ProcessInclusiveGatewaySchema": "inclusiveGateway",
	"Terrasoft.manager.ProcessParallelGatewaySchema": "parallelGateway",
	"Terrasoft.manager.ProcessSubprocessSchema": "callActivity",
	"Terrasoft.manager.ProcessScriptTaskSchema": "scriptTask",
	"Terrasoft.manager.ProcessFormulaTaskSchema": "userTask",
	"Terrasoft.manager.ProcessSequenceFlowSchema": "connection",
	"Terrasoft.manager.ProcessConditionalSequenceFlowSchema": "conditionalConnection",
	"Terrasoft.manager.ProcessDefaultSequenceFlowSchema": "defaultConnection",
	"Terrasoft.manager.ProcessEventSubprocessSchema": "eventSubProcessExpanded",
	"Terrasoft.manager.ProcessEventBasedGatewaySchema": "eventBasedGateway",
	"Terrasoft.manager.ProcessUserTaskSchema": "userTask",
	"Terrasoft.manager.ProcessSchemaUserTask": "userTask",
	"Terrasoft.manager.ProcessWebServiceSchema": "userTask",
	"Terrasoft.manager.ProcessStartMessageNonInterruptingSchema": "startEventMessageNonInterrupting",
	"Terrasoft.manager.ProcessEndEventSchema": "endEvent",
	"Terrasoft.manager.ProcessStartSignalNonInterruptingSchema": "startEventSignalNonInterrupting",
	"Terrasoft.manager.ProcessStartTimerEventNonInterruptingSchema": "startEventTimerNonInterrupting",
	"Terrasoft.manager.ProcessLabelSchema": "label"
};

Terrasoft.diagram.enums.ProcessBoundaryEventTypes = [
	"boundaryInterruptingEventMessage",
	"boundaryInterruptingEventTimer",
	"boundaryInterruptingEventError",
	"boundaryInterruptingEventEscalation",
	"boundaryInterruptingEventCompensation",
	"boundaryInterruptingEventConditional",
	"boundaryInterruptingEventSignal",
	"boundaryInterruptingEventMultiple",
	"boundaryInterruptingEventParallel",
	"boundaryNonInterruptingEventMessage",
	"boundaryNonInterruptingEventTimer",
	"boundaryNonInterruptingEventEscalation",
	"boundaryNonInterruptingEventConditional",
	"boundaryNonInterruptingEventSignal",
	"boundaryNonInterruptingEventMultiple",
	"boundaryNonInterruptingEventParallel"
];

Terrasoft.diagram.enums.ProcessDiagramUnsupportedTerminateEventTypes = [
	"endEventMessage",
	"endEventEscalation",
	"endEventError",
	"endEventCompensate",
	"endEventSignal",
	"endEventTerminate",
	"endEventMultiple",
	"endEventCancel"
];

Terrasoft.diagram.enums.ProcessDiagramUnsupportedSquareTypes = [
	"complexGateway",
	"startEventConditional",
	"startEventMultiple",
	"startEventParallel",
	"startEventEscalation",
	"startEventError",
	"startEventCompensation",
	"startEventEscalationNonInterrupting",
	"startEventMultipleNonInterrupting",
	"startEventParallelNonInterrupting",
	"startEventConditionalNonInterrupting",
	"intermediateThrowEvent",
	"intermediateThrowEventEscalation",
	"intermediateThrowEventCompensate",
	"intermediateThrowEventLink",
	"intermediateThrowEventMultiple",
	"intermediateCatchEventConditional",
	"intermediateCatchEventLink",
	"intermediateCatchEventMultiple",
	"intermediateCatchEventParallel",
	...Terrasoft.diagram.enums.ProcessDiagramUnsupportedTerminateEventTypes,
	...Terrasoft.diagram.enums.ProcessBoundaryEventTypes
];

Terrasoft.diagram.enums.ProcessDiagramUnsupportedRectangleTypes = [
	"subProcessCollapsed",
	"task",
	"manualTask",
	"businessRuleTask",
	"serviceTask",
	"receiveTask",
	"sendTask",
	"subProcessExpanded"
];

Terrasoft.diagram.enums.UnsupportedTypeToUserTaskType = {
	task: "activityUserTask",
	manualTask: "activityUserTask",
	sendTask: "emailTemplateUserTask",
	serviceTask: "webService"
};

Terrasoft.diagram.enums.ProcessDiagramUnsupportedElemenetConst = {
	size: {
		round: {diameter: 31},
		rectangle: {width: 69, height: 55}
	}
};

Terrasoft.diagram.enums.ProcessDiagramUnsupportedTypes =
	[
		...Terrasoft.diagram.enums.ProcessDiagramUnsupportedSquareTypes,
		...Terrasoft.diagram.enums.ProcessDiagramUnsupportedRectangleTypes
	];

/**
 * Shortening for {@link Terrasoft.diagram.enums.UnsupportedTypeToUserTaskType}
 * @member Terrasoft
 * @inheritdoc Terrasoft.diagram.enums.UnsupportedTypeToUserTaskType
 */
Terrasoft.UnsupportedTypeToUserTaskType = Terrasoft.diagram.enums.UnsupportedTypeToUserTaskType;

Terrasoft.ProcessDiagramTypesEnum = Terrasoft.diagram.enums.ProcessDiagramType;

Terrasoft.ProcessDiagramUnsupportedTypes = Terrasoft.diagram.enums.ProcessDiagramUnsupportedTypes;

Terrasoft.ProcessBoundaryEventTypes = Terrasoft.diagram.enums.ProcessBoundaryEventTypes;
Terrasoft.ProcessDiagramUnsupportedTerminateEventTypes = Terrasoft.diagram.enums.ProcessDiagramUnsupportedTerminateEventTypes;
