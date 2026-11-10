define("AccountSectionV2", ["MapsUtilities", "MapsHelper"],
	function(MapsUtilities, MapsHelper) {
		return {
			entitySchemaName: "Account",
			methods: {
				/**
				 * ######## "######## ## #####".
				 */
				openShowOnMap: function() {
					var config = {
						columnNameLongitude: "GPSE",
						columnNameLatitude: "GPSN"
					};
					MapsHelper.openShowOnMap.call(this, this.entitySchemaName, function(mapsConfig) {
						MapsUtilities.open({
							scope: this,
							mapsConfig: mapsConfig
						});
					}, null, config);
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
