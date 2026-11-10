define("CompositeCronExpressionPage", ["CompositeCronExpressionPageResources", "CronExpressionPageMixin",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		mixins: {
			CronExpressionPageMixin : "Terrasoft.CronExpressionPageMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseCronExpressionPage#getDefCronExpressionValue
			 * @protected
			 */
			getDefCronExpressionValue: function () {
				var cron = this.getCompositeCronExpressionValue();
				return cron.toString();
			},

			/**
			 *@protected
			 */
			getCompositeCronExpressionValue: function() {
				return Terrasoft.CronExpression.create();
			},

			/**
			 * @protected
			 */
			onCronExpressionPartChange: function() {
				var cron = this.getCompositeCronExpressionValue();
				if (cron) {
					this.set("CronExpression", cron.toString());
				}
			}
		}
	};
});
