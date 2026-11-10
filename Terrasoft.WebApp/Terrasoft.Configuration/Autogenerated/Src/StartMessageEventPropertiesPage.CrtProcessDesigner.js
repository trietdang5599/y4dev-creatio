/**
 * Edit page schema of process element Start messaage.
 * Parent: BaseMessageEventPropertiesPage
 */
define("StartMessageEventPropertiesPage", ["StartMessageEventPropertiesPageResources"],
	function() {
		return {
			methods: {},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "merge",
				"name": "RecommendationLabel",
				"values": {
					"styles": {
						"labelStyle": {
							"color": "#8ECB60"
						}
					}
				}
			}] /**SCHEMA_DIFF*/
		};
	}
);
