Terrasoft.configuration.Structures["PreconfiguredPageUserTaskButtonViewModel"] = {innerHierarchyStack: ["PreconfiguredPageUserTaskButtonViewModel"]};
define('PreconfiguredPageUserTaskButtonViewModelStructure', ['PreconfiguredPageUserTaskButtonViewModelResources'], function(resources) {return {schemaUId:'3f20487c-00c0-43bb-ace6-71612da7036f',schemaCaption: "PreconfiguredPageUserTaskButtonViewModel", parentSchemaName: "", packageName: "CrtProcessDesigner", schemaName:'PreconfiguredPageUserTaskButtonViewModel',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("PreconfiguredPageUserTaskButtonViewModel", ["PreconfiguredPageUserTaskButtonViewModelResources",
	"ProcessUserTaskConstants", "ProcessMiniEditPageMixin"
], function() {

	/**
	 * Model button for the preconfigured page user task.
	 */
	Ext.define("Terrasoft.model.PreconfiguredPageUserTaskButtonViewModel", {
		extend: "Terrasoft.BaseModel",
		alternateClassName: "Terrasoft.PreconfiguredPageUserTaskButtonViewModel",

		Ext: null,
		Terrasoft: null,

		mixins: {
			processMiniEditPageMixin: "Terrasoft.ProcessMiniEditPageMixin"
		},

		columns: {

			/**
			 * Unique identifier of the button (GUID as string).
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Id": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": ""
			},

			/**
			 * Display caption of the button.
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Caption": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": ""
			},

			/**
			 * System (code) name of the button.
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Name": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": ""
			},

			/**
			 * Perform validation property of button.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"PerformsValidation": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Indicates whether clicking the button completes the page (finishes user task execution).
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"PerformsPageCompletion": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Visibility flag of the button.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"Visible": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Arbitrary tag (identifier) associated with the button.
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Tag": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": ""
			},

			/**
			 * Menu collection with parameter edit tool items for the button.
			 * @type {Terrasoft.dataValueType.COLLECTION}
			 */
			"ParameterEditToolsButtonMenu": {
				"dataValueType": Terrasoft.DataValueType.COLLECTION,
				"value": Ext.create("Terrasoft.BaseViewModelCollection")
			},

			/**
			 * Indicates whether the button can be edited by the user.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"IsEditable": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Parent module instance.
			 */
			"ParentModule": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
			}
		},

		//region Methods: Private

		/**
		 * @private
		 */
		_onLabelClick: function() {
			const checked = Boolean(this.get("PerformsPageCompletion"));
			this.set("PerformsPageCompletion", !checked);
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.BaseModel#constuctor
		 * @protected
		 */
		constructor: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.ProcessMiniEditPageMixin#getProcessMiniEditPageName
		 * @protected
		 */
		getProcessMiniEditPageName: function() {
			return "PreconfiguredPageUserTaskButtonMiniEditPage";
		},

		/**
		 * @inheritdoc Terrasoft.ProcessMiniEditPageMixin#getActiveItemEditName
		 * @protected
		 */
		getActiveItemEditName: function() {
			return "ProcessButtonEditName";
		},

		/**
		 * @inheritdoc Terrasoft.ProcessMiniEditPageMixin#getProcessMiniEditPageId
		 * @protected
		 */
		getProcessMiniEditPageId: function() {
			return this.sandbox.id + "buttonedit";
		},

		/**
		 * @inheritdoc Terrasoft.ProcessMiniEditPageMixin#getAddButtonEnabledProperyName
		 * @protected
		 */
		getAddButtonEnabledProperyName: function() {
			return "IsButtonToolsButtonEnabled";
		},

		/**
		 * Returns marker value for button.
		 * @protected
		 * @return {String} markerValue of button.
		 */
		getMarkerValue: function() {
			var caption = this.get("Caption");
			var parentCollection = this.parentCollection;
			var currentIndex = parentCollection.indexOf(this);
			return Ext.String.format("{0}-{1}", caption, currentIndex);
		}

		//endregion
	});

	return Terrasoft.AutoGeneratedPageUserTaskButtonViewModel;
});


