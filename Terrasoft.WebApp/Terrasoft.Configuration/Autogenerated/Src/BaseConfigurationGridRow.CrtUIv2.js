define("BaseConfigurationGridRow", ["terrasoft", "LookupQuickAddMixin"], function(Terrasoft) {
	return {
		mixins: {
			RelatedEntityColumnsMixin: "Terrasoft.RelatedEntityColumns",
			LookupQuickAddMixin: "Terrasoft.LookupQuickAddMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BasePageV2#updateDetails
			 * @overridden
			 */
			updateDetails: Terrasoft.emptyFn,
			/**
			 * @inheritdoc Terrasoft.BasePageV2#clearPageHeaderCaption
			 * @overridden
			 */
			clearPageHeaderCaption: Terrasoft.emptyFn,
			/**
			 * @inheritdoc Terrasoft.BasePageV2#resetBodyAttributes
			 * @overridden
			 */
			resetBodyAttributes: Terrasoft.emptyFn,
			/**
			 * @inheritdoc Terrasoft.BasePageV2#discardDetailChange
			 * @overridden
			 */
			discardDetailChange: Terrasoft.emptyFn,
			/**
			 * @inheritdoc Terrasoft.BasePageV2#updatePageHeaderCaption
			 * @overridden
			 */
			updatePageHeaderCaption: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseViewModel#constructor
			 * @overridden
			 */
			constructor: function(config) {
				this.callParent(arguments);
				this.setRelatedColumnsValues(this, this.columns);
				this.mixins.LookupQuickAddMixin.init.call(this);
				this._cloneDataModelCollection();
				this._setPrimaryDataModelStatus(config);
			},

			/**
			 * @private
			 */
			_cloneDataModelCollection: function() {
				const dataModelCollection = new Terrasoft.DataModelCollection();
				dataModelCollection.init(this.dataModelCollection.dataModelsConfig);
				this.dataModelCollection = dataModelCollection;
			},

			/**
			 * @private
			 */
			_setPrimaryDataModelStatus: function(config) {
				if (!config) {
					return;
				}
				const primaryModel = this.dataModelCollection.findPrimary();
				primaryModel.isNew = config.isNew;
			}
		}
	};
});
