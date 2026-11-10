Terrasoft.configuration.Structures["WindowUnloadWatcher"] = {innerHierarchyStack: ["WindowUnloadWatcher"]};
define('WindowUnloadWatcherStructure', ['WindowUnloadWatcherResources'], function(resources) {return {schemaUId:'aac9c8d6-3d84-442f-847e-525e82591aa8',schemaCaption: "WindowUnloadWatcher", parentSchemaName: "", packageName: "CrtNUI", schemaName:'WindowUnloadWatcher',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("WindowUnloadWatcher", ["CheckModuleDestroyMixin"], function() {
	return {
		mixins: {
			CheckModuleDestroyMixin: "Terrasoft.CheckModuleDestroyMixin",
		},
		methods: {
			init: function () {
				this.callParent(arguments);
				if (Terrasoft.Features.getIsEnabled("DisableWindowUnloadWatcher")) {
					return;
				}
				window.addEventListener('beforeunload', this.beforePageUnload.bind(this));
			},

			beforePageUnload: function (event) {
				if (Terrasoft.SessionEndUserNotification?.sessionExpired) {
					return true;
				}
				const hasUnsavedChangesResult = this.hasUnsavedChanges();
				if (!hasUnsavedChangesResult?.hasChanges) {
					return true;
				}
				const message = hasUnsavedChangesResult?.message;
				if (event) {
					event.returnValue = message;
				}
				return message;
			}
		}
	};
});


