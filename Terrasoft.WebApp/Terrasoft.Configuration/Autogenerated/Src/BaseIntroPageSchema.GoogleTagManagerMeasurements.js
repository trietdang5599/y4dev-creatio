define("BaseIntroPageSchema", ["GoogleTagManagerMeasurementsUtilities"], function() {
	return {

		mixins: {
			GoogleTagManagerMeasurementsUtilities: Terrasoft.GoogleTagManagerMeasurementsUtilities
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseIntroPageSchema#init
			 * @override
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseIntroPageSchema#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.stopGoogleTagManagerMeasurements();
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#sendGoogleTagManagerData
			 * @override
			 */
			sendGoogleTagManagerData: this.Terrasoft.emptyFn

			//endregion

		}
	};
});
