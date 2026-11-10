Terrasoft.configuration.Structures["EmailTemplateSectionV2"] = {innerHierarchyStack: ["EmailTemplateSectionV2"], structureParent: "BaseSectionV2"};
define('EmailTemplateSectionV2Structure', ['EmailTemplateSectionV2Resources'], function(resources) {return {schemaUId:'22f46480-f71d-40b2-a373-911a5f261a84',schemaCaption: "EmailTemplateSectionV2", parentSchemaName: "BaseSectionV2", packageName: "EmailTemplate", schemaName:'EmailTemplateSectionV2',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Parent: BaseLookupSection
 */
define("EmailTemplateSectionV2", [], function() {
	return {
		entitySchemaName: "EmailTemplate",

		methods: {

			//region Methods: Private

			_isLookupSection() {
				return this.sandbox.moduleName === "LookupSectionModule"
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseDataView#loadFiltersContainersVisibility
			 * @overridden
			 */
			loadFiltersContainersVisibility: function() {
				if (!this._isLookupSection()) {
					this.set("IsFoldersVisible", false);
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseDataView#showFolderTree
			 * @overridden
			 */
			showFolderTree: function() {
				if (!this._isLookupSection()) {
					this.callParent(arguments);
				}
			}

			//endregion

		},
	};
});


