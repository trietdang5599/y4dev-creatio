define("AccountMiniPage", ["AccountMiniPageResources", "AddressHelperV2"],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			messages: {
				/**
				 * @message GetMapsConfig
				 * Gets config for MapsModule.
				 * @param {Object} Parameters for showing account address on map.
				 */
				"GetMapsConfig": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message AfterRenderMap
				 * Execute function after render map.
				 */
				"AfterRenderMap": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				AddressHelperV2: "Terrasoft.AddressHelperV2"
			},
			methods: {
				/**
				 * Returns map button visibility.
				 * @protected
				 * @return {Boolean} Map button visibility.
				 */
				getMapButtonVisibility: function() {
					return !this.Ext.isEmpty(this.get("FullAddress")) && this.isViewMode();
				},

				/**
				 * Shows map.
				 * @protected
				 */
				showMap: function() {
					this.showAddressOnMap(this.close);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "FullAddress",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 21
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "ShowMapButton",
					"values": {
						"layout": {
							"column": 21,
							"row": 2,
							"colSpan": 3
						},
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "showMap"},
						"classes": {
							"wrapperClass": ["show-map-button-image-wrap"],
							"imageClass": ["show-map-button-image"]
						},
						"imageConfig": {
							"bindTo": "Resources.Images.ShowMapButtonImage"
						},
						"visible": {
							"bindTo": "getMapButtonVisibility"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
