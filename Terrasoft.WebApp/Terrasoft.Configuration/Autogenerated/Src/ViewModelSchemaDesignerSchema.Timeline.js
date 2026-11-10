define("ViewModelSchemaDesignerSchema", ["TimelineManager"], function() {
	return {
		attributes: {},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				var parentInitMethod = this.getParentMethod();
				this.Terrasoft.TimelineManager.initialize(function() {
					parentInitMethod.call(this, callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc Terrasoft.BaseModulePageV2#hasTimelineConfig
			 * @override
			 */
			hasTimelineConfig: function() {
				var designedPageSchema = this.get("Schema");
				var timelinePageConfig =
					this.Terrasoft.TimelineManager.getTimelinePageConfig(designedPageSchema.schemaName);
				return !this.isEmpty(timelinePageConfig);
			}

			// endregion

		}
	};
});
