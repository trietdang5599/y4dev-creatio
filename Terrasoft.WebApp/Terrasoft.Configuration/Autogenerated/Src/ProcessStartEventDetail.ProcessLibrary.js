define("ProcessStartEventDetail", function() {
	return {
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseProcessSettingDetailV2#getProcessElementCaptionColumnsConfig
			 * @override
			 */
			getProcessElementCaptionColumnsConfig: function() {
				return {
					detailColumn: "ElementName",
					processElementUIdColumn: "ProcessElementUId"
				};
			}
		}
	};
});