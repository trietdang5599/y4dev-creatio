define("BaseGridDetailV2", ["GoogleTagManagerMeasurementsUtilities"], function() {
	return {

		mixins: {
			/**
			 * Mixin for conducting measurements for sending this data to Google tag manager.
			 */
			GoogleTagManagerMeasurementsUtilities: Terrasoft.GoogleTagManagerMeasurementsUtilities
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				this.callParent(arguments);
				this.stopGoogleTagManagerMeasurements();
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#sendGoogleTagManagerData
			 * @overridden
			 */
			sendGoogleTagManagerData: this.Terrasoft.emptyFn

			//endregion

		}
	};
});
