define("ContentSmartHtmlMacroListItemViewModel", ["ContentSmartHtmlMacroListItemViewModelResources",
		"ImageView"], function(resources) {
	/**
	 * @class Terrasoft.configuration.ContentSmartHtmlMacroListItemViewModel
	 */
	Ext.define("Terrasoft.configuration.ContentSmartHtmlMacroListItemViewModel", {
		extend: "Terrasoft.BaseViewModel",
		alternateClassName: "Terrasoft.ContentSmartHtmlMacroListItemViewModel",
		properties: {
			/**
			 * Parent observable container list.
			 * @type {Terrasoft.ObservableContainerList}
			 */
			containerList: null
		},
		attributes: {
			/**
			 * Macro identifier.
			 * @type {Object}
			 */
			"Id": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value.
			 * @type {Object}
			 */
			"Value": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value type.
			 * @type {String}
			 */
			"DataValueType": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro name.
			 * @type {String}
			 */
			"Name": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro description.
			 * @type {String}
			 */
			"Description": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Selected flag for observable collection.
			 */
			"Selected": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro type logo image config.
			 */
			"TypeLogo": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
			}
		},

		/**
		 * Prefix for control marker value.
		 * @type {String}
		 */
		markerValuePrefix: "macro-value",

		/**
		 * Pattern for macro.
		 * @type {String}
		 */
		macroPattern: "{{#{0}::{1}#}}",

		/**
		 * @private
		 */
		_getControlMarkerValue: function() {
			return this.markerValuePrefix + "-" + this.$Name;
		},

		/**
		 * @private
		 */
		_getWrapClassName: function() {
			var classes = ["macro-item-container"];
			if (this.$Selected) {
				classes.push("selected");
			}
			return classes;
		},

		/**
		 * @private
		 */
		_getImageUrl: function() {
			return Terrasoft.ImageUrlBuilder.getUrl(this.$TypeLogo);
		},

		/**
		 * @private
		 */
		_getMacroInputConfig: function() {
			return [
				{
					className: "Terrasoft.ImageView",
					imageSrc: "$_getImageUrl",
					canExecute: false,
					classes: {
						wrapClass: ["macro-type-image"]
					}
				},
				{
					className: "Terrasoft.Label",
					caption: "$Name"
				},
				{
					className: "Terrasoft.Button",
					imageConfig: resources.localizableImages.RemoveButtonImage,
					style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					markerValue: this._getControlMarkerValue(),
					classes: {
						"imageClass": ["button-background-no-repeat"],
						"wrapperClass": ["remove-button-wrapClass"]
					},
					click: "$onRemoveButtonClick"
				}
			];
		},

		/**
		 * Handles remove button click. Removes item from container list.
		 * @protected
		 */
		onRemoveButtonClick: function() {
			this.containerList.removeItem(this);
		},

		/**
		 * @public
		 * @returns {String} Macro final string to use.
		 */
		getMacroText: function() {
			return Ext.String.format(this.macroPattern, this.Id || this.$Id, this.$Name || "");
		},

		/**
		 * Returns config of macro value.
		 * @public
		 * @returns {Object} Macro config.
		 */
		getMacroConfig: function() {
			return {
				Id: this.$Id,
				DataValueType: this.$DataValueType,
				Name: this.$Name,
				Value: this.$Value,
				Description: this.$Description
			};
		},

		/**
		 * Sets sandbox for current item and subscribes on its messages.
		 * @public
		 * @param {Object} sandbox Sandbox object.
		 */
		initSandbox: function(sandbox) {
			this.sandbox = sandbox;
		},

		/**
		 * Sets parent container list.
		 * @public
		 * @param {Terrasoft.EditableContainerList} containerList Parent container list.
		 */
		setContainerList: function(containerList) {
			this.containerList = containerList;
		},

		/**
		 * Returns config of current item view.
		 * @public
		 * @returns {Object} View config.
		 */
		getViewConfig: function() {
			return {
				id: this.$Id,
				className: "Terrasoft.Container",
				classes: {
					wrapClassName: this._getWrapClassName()
				},
				items: [
					{
						className: "Terrasoft.Container",
						classes: {
							wrapClassName: ["macro-input-container"]
						},
						items: this._getMacroInputConfig()
					}
				]
			};
		}
	});
	return Terrasoft.ContentSmartHtmlMacroListItemViewModel;
});
