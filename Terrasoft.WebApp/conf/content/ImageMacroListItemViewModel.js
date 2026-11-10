Terrasoft.configuration.Structures["ImageMacroListItemViewModel"] = {innerHierarchyStack: ["ImageMacroListItemViewModel"]};
define('ImageMacroListItemViewModelStructure', ['ImageMacroListItemViewModelResources'], function(resources) {return {schemaUId:'0e496a59-5150-4a13-a771-6381d463e2e0',schemaCaption: "ImageMacroListItemViewModel", parentSchemaName: "", packageName: "ContentBuilder", schemaName:'ImageMacroListItemViewModel',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("ImageMacroListItemViewModel", ["ImageMacroListItemViewModelResources", "ContentBuilderConstants", "BaseMacroListItemViewModel"],
		function(resources, ContentBuilderConstants) {
	/**
	 * @class Terrasoft.configuration.ImageMacroListItemViewModel
	 */
	Ext.define("Terrasoft.configuration.ImageMacroListItemViewModel", {
		extend: "Terrasoft.BaseMacroListItemViewModel",
		alternateClassName: "Terrasoft.ImageMacroListItemViewModel",

		attributes: {
			/**
			 * Image display value.
			 */
			ImageDisplayValue: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		/**
		 * @override
		 */
		isEmailMacroButtonVisible: false,

		/**
		 * @private
		 */
		_onImageDisplayValueChanged: function(model, value) {
			if (!Ext.isEmpty(value) && value !== resources.localizableStrings.ImageEmbedded) {
				this.$Value = value;
			}
			if (Ext.isEmpty(value)) {
				this.$Value = null;
			}
		},

		/**
		 * @private
		 */
		_initImageDisplayValue: function(config) {
			var image = config.Value;
			if (!image) {
				return;
			}
			if (this._isImageEmbedded(image)) {
				config.ImageDisplayValue = resources.localizableStrings.ImageEmbedded;
			} else {
				config.ImageDisplayValue = image;
			}
		},

		/**
		 * @private
		 */
		_isImageEmbedded: function(image) {
			return image.startsWith("data:") || image.startsWith("../rest/FileService/");
		},

		/**
		 * @inheritdoc Terrasoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function(config) {
			config && config.values && this._initImageDisplayValue(config.values);
			this.callParent(arguments);
			this.on("change:ImageDisplayValue", this._onImageDisplayValueChanged, this);
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:ImageDisplayValue", this._onImageDisplayValueChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Upload image button handler.
		 * @param {Array} image array.
		 * @public
		 */
		onImageSelected: function(image) {
			if (image || Ext.isArray(image)) {
				FileAPI.readAsDataURL(image[0], function (e) {
					this.$ImageDisplayValue = resources.localizableStrings.ImageEmbedded;
					if (this.$Value !== e.result) {
						this.$Value = e.result;
					}
				}.bind(this));
			}
		},

		/**
		 * @inheritdoc BaseMacroListItemViewModel#getMacroInputConfig
		 * @override
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "Terrasoft.Container",
					classes: {
						wrapClassName: ["control-editor-wrapper"]
					},
					items: [
						{
							className: "Terrasoft.Container",
							classes: {
								wrapClassName: ["image-icon", "icon-16x16"]
							},
							items: []
						},
						{
							className: "Terrasoft.TextEdit",
							value: "$ImageDisplayValue",
							placeholder: resources.localizableStrings.ImageUrlPlaceholder,
							hasClearIcon: true,
							classes: {
								wrapClass: ["show-placeholder", "control-editor-wrapper"]
							}
						},
						{
							className: "Terrasoft.Button",
							imageConfig: resources.localizableImages.UploadImage,
							fileTypeFilter: [ContentBuilderConstants.AllowedImageExtensions],
							fileUpload: true,
							filesSelected: "$onImageSelected",
							fileUploadMultiSelect: false,
							classes: {
								wrapperClass: ["upload-icon-wrapper"]
							}
						}
					]
				}
			];
		}
	});
	return Terrasoft.ImageMacroListItemViewModel;
});


