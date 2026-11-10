/**
 */
Ext.define("Terrasoft.Designers.ProcessSchemaDesignerNew", {
	extend: "Terrasoft.Designers.ProcessSchemaDesigner",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#schemaDiagramClassName
	 * @override
	 */
	schemaDiagramClassName: "Terrasoft.ProcessDiagramComponent",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.ProcessSchemaDesignerViewModelNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#hasLeftToolbar
	 * @override
	 */
	hasLeftToolbar: false,

	/**
	 * Define whether to show Import Process button.
	 */
	showImportButton: true,

	/**
	 * Determines whether to show the header or not.
	 */
	isDesignerHeaderVisible: true,

	/**
	 * @private
	 */
	_getImageConfig: function(imageName) {
		if (!imageName) {
			return null;
		}
		return {
			source: Terrasoft.ImageSources.RESOURCE_MANAGER,
			params: {
				resourceManagerName: "Terrasoft.Nui",
				resourceItemName: "ProcessSchemaDesigner." + imageName
			}
		};
	},

	/**
	 * Adds ImportProcess item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 */
	_addImportProcessMenuItem: function(menuItems) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-import-process-mi",
			caption: Terrasoft.Resources.SchemaDesigner.ImportFromBpmnCaption,
			markerValue: Terrasoft.Resources.SchemaDesigner.ImportFromBpmnCaption,
			fileUpload: true,
			fileTypeFilter: [".bpmn"],
			filesSelected: {bindTo: "onBpmnFileSelected"},
			imageConfig: this._getImageConfig("ImportIconButton.svg")
		}));
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#getDesignerViewModelConfig
	 * @override
	 */
	getDesignerViewModelConfig: function() {
		const config = this.callParent(arguments);
		config.values.IsDesignerHeaderVisible = this.isDesignerHeaderVisible;
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#getDiagramConfig
	 * @override
	 */
	getDiagramConfig: function() {
		const baseConfig = this.callParent(arguments);
		const config = {
			...baseConfig,
			diagramItemCreated: {
				bindTo: "onItemCreate"
			},
			connectorCreate: {
				bindTo: "onConnectorCreate"
			},
			connectorUpdatingType: {
				bindTo: "onConnectorChangingType"
			},
			diagramConfig: {
				bindTo: "DiagramConfig"
			},
			itemValidateUpdatingType: {
				bindTo: "onItemValidateUpdatingType"
			},
			itemTypeUpdated: {
				bindTo: "onItemTypeUpdated"
			},
			itemSelected: {
				bindTo: "onItemSelected"
			},
			openPropertyPage: {
				bindTo: "onOpenPropertyPage"
			},
			pasteElement: {
				bindTo: "onPasteElement"
			},
			canCopy: {
				bindTo: "onCanCopy"
			},
			itemsRemoved: {
				bindTo: "onItemsRemoved"
			},
			importData: {
				bindTo: "ImportData"
			},
			importError: {
				bindTo: "onImportError"
			},
			diagramImportStart: {
				bindTo: "onDiagramImportStart"
			},
			updateStudioFreeDiagramUrl: {
				bindTo: "onUpdateStudioFreeDiagramUrl"
			},
			suggestions: {
				bindTo: "Suggestions"
			},
			suggestionsTriggered: {
				bindTo: "SuggestionsTriggered"
			},
			itemSuggestionsClick: {
				bindTo: "onItemSuggestionsClick"
			}
		};
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#renderDesignContainer
	 * @override
	 */
	renderDesignContainer: function() {
		this.callParent(arguments);
		const designerViewModel = this.designerViewModel;
		designerViewModel.on("itemCenterViewBox", this.onItemCenterViewBox, this);
		designerViewModel.on("itemMarkersChanged", this._onItemMarkersChanged, this);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#onAfterDesignerRender
	 * @override
	 */
	onAfterDesignerRender: function() {
		this.callParent(arguments);
		this.diagram.initDiagram();
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#onItemIsValidChanged
	 * @override
	 */
	onItemIsValidChanged: function(item) {
		this.diagram.setIsElementValid(item.uId, item.isValid);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#onUpdateItemsHighlighter
	 * @override
	 */
	onUpdateItemsHighlighter: function(selectedItems, selectedItemName) {
		// TODO CRM-51478
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#getActionsButton
	 * @overridden
	 */
	getActionsButton(actionButtonsMenuItems) {
		if (Terrasoft.Features.getIsEnabled("AllowBpmnImportInProcessLibrary") && this.showImportButton) {
			this._addImportProcessMenuItem(actionButtonsMenuItems);
		}
		return this.callParent([actionButtonsMenuItems]);
	},

	/**
	 * @override
	 */
	focusDesigner: function() {
		this.callParent(arguments);
		this.focusEl.blur();
	},

	/**
	 * @override
	 */
	addElementCopyMenuItem: Terrasoft.emptyFn,

	/**
	 * @override
	 */
	addElementPasteMenuItem: Terrasoft.emptyFn,

	/**
	 * Handler for itemCenterViewBox event.
	 * @private
	 */
	onItemCenterViewBox: function(itemName) {
		this.diagram.itemCenterViewBox(itemName);
	},

	/**
	 * @private
	 */
	_onItemMarkersChanged: function({uId, markers}) {
		this.diagram.updateElementMarkers(uId, markers);
	}
});
