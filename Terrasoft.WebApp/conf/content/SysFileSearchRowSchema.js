Terrasoft.configuration.Structures["SysFileSearchRowSchema"] = {innerHierarchyStack: ["SysFileSearchRowSchema"], structureParent: "FileSearchRowSchema"};
define('SysFileSearchRowSchemaStructure', ['SysFileSearchRowSchemaResources'], function(resources) {return {schemaUId:'c93f5e37-c718-4df8-bbb1-0bd5bc8dee64',schemaCaption: "SysFileSearchRowSchema", parentSchemaName: "FileSearchRowSchema", packageName: "GlobalSearch", schemaName:'SysFileSearchRowSchema',parentSchemaUId:'1cbf389d-95ba-4ab5-bf87-ab153ea60c02',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SysFileSearchRowSchema", [], function() {
	return {
		attributes: {},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseSearchRowSchema#init
			 * @overridden
			 */
			init: function(callback, scope) {
				const parentColumnName = this.getParentEntityColumnName();
				this.columns[parentColumnName] = { referenceSchemaName: parentColumnName };
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.FileSearchRowSchema#getParentEntityColumnName
			 * @overridden
			 */
			getParentEntityColumnName: function() {
				return this.get("RecordSchemaName");
			},
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});

