Terrasoft.configuration.Structures["PushTemplatePage"] = {innerHierarchyStack: ["PushTemplatePage"], structureParent: "EmailTemplatePageMultilingual"};
define('PushTemplatePageStructure', ['PushTemplatePageResources'], function(resources) {return {schemaUId:'258861ee-df42-445a-8f3d-47b398b5df40',schemaCaption: "PushTemplatePage", parentSchemaName: "EmailTemplatePageMultilingual", packageName: "EmailTemplate", schemaName:'PushTemplatePage',parentSchemaUId:'afc0c17e-46ad-4e86-8945-443934c00af2',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 /**
 * Parent: EmailTemplatePageMultilingual
 */
define("PushTemplatePage", [], function() {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseMultilingualEntityLookupPage#getModuleSchemaName
			 * @override
			 */
			getModuleSchemaName: function() {
				return "PushTemplateContentEditSchema";
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});


