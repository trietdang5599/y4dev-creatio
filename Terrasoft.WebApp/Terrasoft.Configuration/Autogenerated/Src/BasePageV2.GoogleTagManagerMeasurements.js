define("BasePageV2", ["GoogleTagManagerMeasurementsUtilities"], function() {
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
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @overridden
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
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
