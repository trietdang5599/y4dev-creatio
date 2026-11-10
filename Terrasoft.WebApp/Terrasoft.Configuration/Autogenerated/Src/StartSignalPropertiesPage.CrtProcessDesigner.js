/**
 * Edit page schema of process element "start signal".
 * Parent: BaseSignalEventPropertiesPage => ProcessBaseEventPropertiesPage => ProcessFlowElementPropertiesPage
 *  => BaseProcessSchemaElementPropertiesPage
 */
define("StartSignalPropertiesPage", ["StartSignalPropertiesPageResources"],
	function() {
		return {
			attributes: {
				/**
				 * Attribute names that triggers update of next elements suggestions.
				 * @protected
				 * @type {Object}
				 */
				"SuggestionsTriggerAttributes": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: [
						{
							name: "EntitySchemaUId",
							predictionParameterName: "entitySchemaUId"
						}
					]
				}
			},
			methods: {},
			diff: /**SCHEMA_DIFF*/ [] /**SCHEMA_DIFF*/
		};
	}
);
