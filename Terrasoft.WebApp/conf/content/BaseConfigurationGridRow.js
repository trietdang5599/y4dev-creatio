Terrasoft.configuration.Structures["BaseConfigurationGridRow"] = {innerHierarchyStack: ["BaseConfigurationGridRow"]};
define('BaseConfigurationGridRowStructure', ['BaseConfigurationGridRowResources'], function(resources) {return {schemaUId:'67fb39c9-833b-448b-a982-ed2a9b6e351b',schemaCaption: "Base view class model - Configuration list string", parentSchemaName: "", packageName: "CrtUIv2", schemaName:'BaseConfigurationGridRow',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
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


