define("ContentSmartHtmlPropertiesPage", ["ContentSmartHtmlPropertiesPageResources", "AcademyUtilities", "ModalBox",
		"css!ContentSmartHtmlPropertiesPageCSS", "BaseMacroListItemViewModel", "MultilineLabel",
		"ColorMacroListItemViewModel", "ImageMacroListItemViewModel", "TextMacroListItemViewModel"],
		function(resources, AcademyUtilities, ModalBox) {
	return {
		attributes: {
			/**
			 * Element macros collection.
			 */
			"Macros": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				value: Ext.create("Terrasoft.BaseViewModelCollection")
			},

			/**
			 * Sign for macros collection visibility.
			 */
			"IsMacrosVisible": {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			}
		},
		messages: {
			/**
			 * @message SmartHtmlContentSaved
			 * Message indicates need save current smart html.
			 */
			"SmartHtmlContentSaved": {
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
				mode: Terrasoft.MessageMode.PTP
			},

			/**
			 * @message SmartHtmlEditCancel
			 * Message for canceling smart html saving process.
			 */
			"SmartHtmlEditCancel": {
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
				mode: Terrasoft.MessageMode.PTP
			},

			/**
			 * @message OpenMacrosDialog
			 * Opens bulk email macros dialog.
			 */
			"OpenMacrosDialog": {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.PTP
			},

			/**
			 * @message IsEmailMacroAvailable.
			 * Defines visibility of macro buttons.
			 */
			"IsEmailMacroAvailable": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * Inits macro values.
			 * @private
			 * @param {Array} macros Configured macro values.
			 */
			_initMacros: function(macros) {
				this.$Macros.clear();
				var values = new Terrasoft.BaseViewModelCollection();
				Terrasoft.each(macros, function(macro) {
					var listItem = this.createMacroListItemViewModel(macro);
					values.add(macro.Id, listItem);
				}, this);
				this.$IsMacrosVisible = !values.isEmpty();
				this.$IsMacrosVisible && this.$Macros.loadAll(values);
			},

			/**
			 * @private
			 */
			_onMacrosChanged: function() {
				var macros =  this.getMacroValues();
				this.$Config.Macros = JSON.stringify(macros);
				this.save();
			},

			/**
			 * @private
			 */
			_getContentSmartHtmlEditModuleId: function() {
				return this.sandbox.id + "_ContentSmartHtmlEditPage";
			},

			/**
			 * @private
			 */
			_subscribeMessages: function() {
				this.sandbox.subscribe("SmartHtmlContentSaved", this.onSmartHtmlContentSaved, this,
					[this._getContentSmartHtmlEditModuleId()]);
				this.sandbox.subscribe("SmartHtmlEditCancel", this.onEditHtmlCancel, this,
					[this._getContentSmartHtmlEditModuleId()]);
			},

			/**
			 * Handles content smart html saved action.
			 * @protected
			 * @param {Object} savingData Object contains saving data for properties page.
			 */
			onSmartHtmlContentSaved: function(savingData) {
				this._initMacros(savingData.macros);
				this.$Config.HtmlSrc = savingData.htmlSrc;
				this._onMacrosChanged();
				ModalBox.close();
			},

			/**
			 * Handles content smart html save action canceled.
			 * @protected
			 */
			onEditHtmlCancel: function() {
				ModalBox.close();
			},

			/**
			 * @inheritdoc Terrasoft.configuration.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.$Macros.on("itemChanged", this._onMacrosChanged, this);
				this._subscribeMessages();
				this.initHelpUrl();
			},

			/**
			 * Initialize link to Academy.
			 * @protected
			 */
			initHelpUrl: function() {
				var contextHelpCode = "ContentRawHtmlProperties";
				var helpConfig = {
					callback: function(url) {
						this.set("HelpUrl", url);
					},
					scope: this,
					contextHelpCode: contextHelpCode
				};
				AcademyUtilities.getUrl(helpConfig);
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this._initMacros(config.Macros);
				}
			},

			/**
			 * Returns instance of the list item view model.
			 * @public
			 * @param {Object} macro Macro object.
			 * @returns {Terrasoft.BaseMacroListItemViewModel} List item view model.
			 */
			createMacroListItemViewModel: function(macro) {
				var listItemViewModel;
				var defaultConfig = {
					values: macro,
					sandbox: this.sandbox
				};
				switch (macro.DataValueType) {
					case Terrasoft.DataValueType.LONG_TEXT:
						listItemViewModel = new Terrasoft.TextMacroListItemViewModel(defaultConfig);
						break;
					case Terrasoft.DataValueType.COLOR:
						listItemViewModel = new Terrasoft.ColorMacroListItemViewModel(defaultConfig);
						break;
					case Terrasoft.DataValueType.IMAGE:
						listItemViewModel = new Terrasoft.ImageMacroListItemViewModel(defaultConfig);
						break;
					default:
						listItemViewModel = new Terrasoft.BaseMacroListItemViewModel(defaultConfig);
				}
				return listItemViewModel;
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.$Macros.un("itemChanged", this._onMacrosChanged, this);
				this.callParent(arguments);
			},

			/**
			 * Returns serialized collection of selected macro values.
			 * @protected
			 * @returns {String} Serialized selected macro values.
			 */
			getMacroValues: function() {
				var macroValues = [];
				macroValues = this.$Macros.getItems().map(function(item) {
					return item.getMacroConfig();
				});
				return macroValues;
			},

			/**
			 * Generates configuration view of the element.
			 * @protected
			 * @param {Object} itemConfig Link to configuration of element in ContainerList.
			 * @param {Terrasoft.BaseParameterListItemViewModel} item Macros list item.
			 * @returns {Object} Configuration of macro value in ContainerList.
			 */
			getMacroViewConfig: function(itemConfig, item) {
				if (Ext.isFunction(item.getViewConfig)) {
					itemConfig.config = item.getViewConfig();
				}
				return itemConfig;
			},

			/**
			 * Gets image of placeholder.
			 * @protected
			 * @return {String} Image of placeholder.
			 */
			getNoMacrosImage: function() {
				return Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.BlankSlateImage);
			},

			/**
			 * Gets text of placeholder.
			 * @protected
			 * @return {String} Text of placeholder.
			 */
			getBlankSlateLabelText: function() {
				return Ext.String.format(resources.localizableStrings.BlankSlateLabel, this.get("HelpUrl"));
			},

			/**
			 * Loads ContentSmartHtmlEditModule.
			 * @protected
			 */
			loadContentSmartHtmlEditModule: function() {
				var moduleId = this._getContentSmartHtmlEditModuleId();
				var modalBoxConfig = {
					heightPixels: 610,
					widthPixels: 1140
				};
				var windowRenderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, windowRenderTo);
				}, this);
				this.sandbox.loadModule("ContentSmartHtmlEditModule", {
					renderTo: windowRenderTo.id,
					id: moduleId,
					parameters: {
						viewModelConfig: {
							MacrosConfig: typeof this.$Config.Macros === "string"
								? this.$Config.Macros
								: JSON.stringify(this.$Config.Macros),
							HtmlSrc: this.$Config.HtmlSrc,
							ContentBuilderState: this.$ContentBuilderState
						}
					}
				});
			},

			/**
			 * Open modal box for edit smart block HTML.
			 * @protected
			 */
			editSmartBlock: function() {
				this.loadContentSmartHtmlEditModule();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentPropertiesContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-smarthtml-properties-container"]
				}
			},
			{
				"operation": "insert",
				"name": "BlankSlateContainer",
				"parentName": "ContentPropertiesContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "IsMacrosVisible",
						"bindConfig": { converter: "invertBooleanValue" }
					},
					"classes": {
						"wrapClassName": ["blank-slate-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NotSelectedImage",
				"parentName": "BlankSlateContainer",
				"propertyName": "items",
				"values": {
					"markerValue": "NotSelectedImage",
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"onPhotoChange": Terrasoft.emptyFn,
					"getSrcMethod": "getNoMacrosImage",
					"classes": {
						"wrapClass": ["not-selected-image"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NotSelectedLabel",
				"parentName": "BlankSlateContainer",
				"propertyName": "items",
				"values": {
					"className": "Terrasoft.MultilineLabel",
					"itemType": this.Terrasoft.ViewItemType.LABEL,
					"caption": "$getBlankSlateLabelText",
					"contentVisible": true,
					"showLinks": true,
					"classes": {
						"labelClass": ["description-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "EditButtonContainer",
				"parentName": "ContentPropertiesContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["edit-button-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EditButton",
				"parentName": "EditButtonContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"click": "$editSmartBlock",
					"caption": "$Resources.Strings.EditButtonCaption",
					"classes": {
						"textClass": ["edit-smart-block-button"]
					},
					"style": this.Terrasoft.controls.ButtonEnums.style.DEFAULT
				}
			},
			{
				"operation": "insert",
				"name": "MacrosListContainer",
				"parentName": "ContentPropertiesContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"visible": "$IsMacrosVisible",
					"classes": {
						"wrapClassName": ["macros-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MacrosListLabel",
				"parentName": "MacrosListContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.MacrosListLabelCaption",
					"classes": {
						"labelClass": ["t-title-label-content-block"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "MacrosListValuesContainer",
				"parentName": "MacrosListContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"className": "Terrasoft.ContainerList",
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "Macros",
					"onGetItemConfig": "getMacroViewConfig",
					"itemPrefix": "ContentSmartHtmlElement",
					"classes": {
						"wrapClassName": ["macro-values-container"]
					}
				}
			}
		]
	};
});
