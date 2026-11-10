Terrasoft.configuration.Structures["ChatTemplatePage"] = {innerHierarchyStack: ["ChatTemplatePage"], structureParent: "EmailTemplatePageMultilingual"};
define('ChatTemplatePageStructure', ['ChatTemplatePageResources'], function(resources) {return {schemaUId:'107605c8-459c-4fa0-8f02-0ed9faa52212',schemaCaption: "Edit page: \"Chat message template\"", parentSchemaName: "EmailTemplatePageMultilingual", packageName: "OmnichannelMessaging", schemaName:'ChatTemplatePage',parentSchemaUId:'afc0c17e-46ad-4e86-8945-443934c00af2',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Parent: EmailTemplatePageMultilingual
 */
define("ChatTemplatePage", ["OmnichannelConsts"], function(OmnichannelConsts) {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseMultilingualEntityLookupPage#getModuleSchemaName
			 * @override
			 */
			getModuleSchemaName: function() {
				return "ChatTemplateContentEditSchema";
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				if (this.isNew && this.isEmpty(this.get("Object"))) {
					this.setOmniChatObject();
				}
			},

			/**
			 * Returns query to SysSchemaInfo.
			 * @protected
			 * @return {Terrasoft.EntitySchemaQuery} Query to SysSchemaInfo.
			 */
			getVwSysSchemaInfoEsq: function() {
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysSchemaInfo"
				});
				esq.addColumn("Caption");
				return esq;
			},

			/**
			 * Sets OmniChat schema to Object property.
			 * @protected
			 */
			setOmniChatObject: function() {
				const esq = this.getVwSysSchemaInfoEsq();
				esq.getEntity(OmnichannelConsts.OmniChatSchemaUId, function(result) {
					if (result.success) {
						var entity = result.entity;
						this.set("Object", {
							value: OmnichannelConsts.OmniChatSchemaUId,
							displayValue: entity.get('Caption')
						});
					}
				}, this);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Object",
				"values": {
					"enabled": false
				}
			},
		]/**SCHEMA_DIFF*/
	};
});


