 /**
 * ProcessBaseEventPropertiesPage edit page schema.
 * Parent: ProcessBaseEventPropertiesPage => ProcessFlowElementPropertiesPage
 */
define("ProcessTerminateEventPropertiesPage", function() {
	return {
		messages: {},
		attributes: {},
		methods: {
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "useBackgroundMode"
			},
			{
				"operation": "remove",
				"name": "BackgroundModePriorityConfig"
			}
		]/**SCHEMA_DIFF*/
	};
});
