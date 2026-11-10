/**
 * @deprecated Use Terrasoft.ProcessSchemaDesignerNew instead.
 */
Ext.define("Terrasoft.Designers.ProcessSchemaDesigner", {
	extend: "Terrasoft.Designers.BaseProcessSchemaDesigner",
	alternateClassName: "Terrasoft.ProcessSchemaDesigner",

	/**
	 * Process diagram.
	 * @type {Terrasoft.ProcessSchemaDiagram}
	 * @private
	 */
	diagram: null,

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.ProcessSchemaDesignerViewModel",

	/**
	 * Flag that indicates whether left panel is collapsed.
	 * @type {Boolean}
	 */
	leftPanelCollapsed: false,

	/**
	 * Left panel collapse class name.
	 * @type {String}
	 */
	leftPanelCollapseClass: "schema-designer-left-panel-collapsed",

	/**
	 * Local storage property name for process designer left panel collapsed state.
	 * @protected
	 * @type {String}
	 */
	storageLeftPanelCollapsed: "ProcessDesigner_LeftPanelCollapsed",

	/**
	 * Name of left toolbar class.
	 * @protected
	 * @type {String}
	 */
	leftToolbarClassName: "Terrasoft.ProcessSchemaDesignerLeftToolbar",

	/**
	 * Name of schema diagram class name.
	 * @protected
	 * @type {String}
	 */
	schemaDiagramClassName: "Terrasoft.ProcessSchemaDiagram",

	/**
	 * Caption of left toolbar.
	 * @protected
	 * @type {String}
	 */
	leftToolbarHeaderButtonCaption: Terrasoft.Resources.SchemaDesigner.LeftPanelHeaderButtonCaption,

	/**
	 * @protected
	 */
	hasLeftToolbar: true,

	/**
	 * Diagram config.
	 * @private
	 * @type {Object}
	 */
	diagramConfig: {
		classes: {
			wrapClassName: ["ej-diagram", "ts-box-sizing"]
		},
		items: {
			bindTo: "Items"
		},
		click: {
			bindTo: "onDiagramClick"
		},
		doubleClick: {
			bindTo: "onDiagramDoubleClick"
		},
		connectorsNodesChange: {
			bindTo: "onConnectorsNodesChange"
		},
		itemsContainerChanged: {
			bindTo: "onItemsContainerChanged"
		},
		itemsPositionChanged: {
			bindTo: "onItemsPositionChanged"
		},
		textChange: {
			bindTo: "onTextChange"
		},
		linePositionChanged: {
			bindTo: "onLinePositionChanged"
		},
		sizeChanged: {
			bindTo: "onElementSizeChanged"
		},
		generateItemNameAndCaption: {
			bindTo: "onGenerateItemNameAndCaption"
		},
		polylinePointPositionsChanged: {
			bindTo: "onPolylinePointPositionsChanged"
		},
		insertNodeInConnector: {
			bindTo: "onInsertNodeInConnector"
		},
		nodesCollectionChange: {
			bindTo: "onNodesCollectionChange"
		},
		itemsRemoving: {
			bindTo: "onItemsRemoving"
		}
	},

	/**
	 * Diagram config.
	 * @protected
	 * @type {Object}
	 */
	getDiagramConfig: function() {
		return Ext.apply({}, this.diagramConfig, {id: this.id});
	},

	/**
	 * Adds ElementCopy item to a button menu of Actions.
	 * @protected
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addElementCopyMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-copy-element-mi",
			caption: resources.CopyElementMenuItemCaption,
			onItemClick: this.onCopyElementClick.bind(this)
		}));
	},

	/**
	 * Adds ElementPaste item to a button menu of Actions.
	 * @protected
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addElementPasteMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-paste-element-mi",
			caption: resources.PasteElementMenuItemCaption,
			onItemClick: this.onPasteElementClick.bind(this)
		}));
	},

	/**
	 * Adds ActualizeActiveVersion item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addActualizeActiveVersionMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-actualize-schema-mi",
			caption: resources.ActualizeSchemaMessage,
			click: {
				bindTo: "onActualize"
			},
			enabled: {
				bindTo: "IsActiveVersionMenuItemEnabled",
				bindConfig: {
					converter: function(invertBooleanValue) {
						return !invertBooleanValue;
					}
				}
			}
		}));
	},

	/**
	 * Adds ProcessSourceCode item to a button menu of Actions.
	 * @protected
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addProcessSourceCodeMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-source-code-mi",
			caption: resources.SourceCodeMenuItemCaption,
			click: {bindTo: "onOpenSourceCodeClick"}
		}));
	},

	/**
	 * Adds ProcessMetaData item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addProcessMetaDataMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-meta-data-mi",
			caption: resources.MetaDataMenuItemCaption,
			click: {bindTo: "onOpenMetaDataClick"}
		}));
	},

	/**
	 * Adds ProcessCopy item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addProcessCopyMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-copy-mi",
			caption: resources.CopyMenuItemCaption,
			click: {bindTo: "onCopyProcessClick"}
		}));
	},

	/**
	 * Adds SchemaExport item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addSchemaExportMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-export-to-png-mi",
			caption: resources.ExportMetaDataItemCaption,
			click: {bindTo: "onExportSchemaClick"}
		}));
	},

	/**
	 * Adds ProcessLog item to a button menu of Actions.
	 * @private
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addProcessLogMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-process-log-mi",
			caption: resources.ProcessLogMenuItemCaption,
			click: {bindTo: "onShowProcessLog"}
		}));
	},

	/**
	 * Adds separator menu item.
	 * @protected
	 * @param {Array} menuItems Items of the menu.
	 */
	addSeparatorMenuItem: function(menuItems) {
		menuItems.push({
			className: "Terrasoft.MenuSeparator"
		});
	},

	/**
	 * Returns config for save button.
	 * @protected
	 * @return {Object}
	 */
	getSaveButton: function() {
		return {
			className: "Terrasoft.Button",
			id: this.id + "-save-btn",
			caption: Terrasoft.Resources.SchemaDesigner.SaveButtonCaption,
			style: {
				bindTo: "getSaveButtonStyle"
			},
			click: {
				bindTo: "save"
			},
			hint: {
				bindTo: "getSaveButtonHint"
			},
			markerValue: "save",
			menu: {
				items: {
					bindTo: "SaveButtonMenuItems"
				}
			}
		};
	},


	/**
	 * Returns config for run button.
	 * @return {Object}
	 */
	getRunButton: function() {
		return {
			className: "Terrasoft.Button",
			id: this.id + "-run-btn",
			caption: Terrasoft.Resources.SchemaDesigner.RunButtonCaption,
			style: Terrasoft.controls.ButtonEnums.style.BLUE,
			click: {bindTo: "onRunProcessClick"},
			hint: Terrasoft.Resources.SchemaDesigner.RunButtonHint,
			markerValue: "run"
		};
	},

	/**
	 * Returns config for close button.
	 * @return {Object}
	 */
	getCloseButton: function() {
		return {
			className: "Terrasoft.Button",
			id: this.id + "-close-btn",
			caption: Terrasoft.Resources.SchemaDesigner.CloseButtonCaption,
			style: Terrasoft.controls.ButtonEnums.style.GREY,
			click: {bindTo: "close"},
			markerValue: "close"
		};
	},

	/**
	 * Returns config for actions button.
	 * @param {Array} actionButtonMenuItems Action button menu items.
	 * @return {Object}
	 */
	getActionsButton: function(actionButtonMenuItems) {
		return {
			className: "Terrasoft.Button",
			id: this.id + "-actions-btn",
			caption: Terrasoft.Resources.SchemaDesigner.ActionsButtonCaption,
			classes: {wrapperClass: ["t-btn-actions"]},
			menu: {items: actionButtonMenuItems},
			markerValue: "actions"
		};
	},

	/**
	 * Creates left toolbar buttons
	 * @protected
	 * @param {Array} actionButtonMenuItems Action button menu items.
	 * @return {Array}
	 */
	createToolBarLefContainerItems: function(actionButtonMenuItems) {
		return [
			this.getSaveButton(),
			this.getRunButton(),
			this.getCloseButton(),
			this.getActionsButton(actionButtonMenuItems)
		];
	},

	/**
	 * Returns toolbar left container config for menu items.
	 * @protected
	 * @param {Array} menuItems Items of the menu.
	 */
	getCreateToolbarLeftContainerConfig: function(menuItems) {
		return {
			className: "Terrasoft.Container",
			id: this.id + "-toolbar-left",
			classes: {
				wrapClassName: ["toolbar-left"]
			},
			items: this.createToolBarLefContainerItems(menuItems),
			visible: {
				bindTo: "IsDesignerHeaderVisible"
			}
		};
	},

	/**
	 * Creates toolbar left container.
	 * @protected
	 * @return {Object}
	 */
	createToolbarLeftContainer: function() {
		const resources = Terrasoft.Resources.SchemaDesigner;
		const menuItems = [];
		this.addProcessSourceCodeMenuItem(menuItems, resources);
		this.addProcessMetaDataMenuItem(menuItems, resources);
		this.addProcessCopyMenuItem(menuItems, resources);
		this.addSchemaExportMenuItem(menuItems, resources);
		this.addProcessLogMenuItem(menuItems, resources);
		this.addActualizeActiveVersionMenuItem(menuItems, resources);
		this.addSeparatorMenuItem(menuItems);
		this.addElementCopyMenuItem(menuItems, resources);
		this.addElementPasteMenuItem(menuItems, resources);
		return this.getCreateToolbarLeftContainerConfig(menuItems);
	},

	/**
	 * Returns config for toolbar search show button.
	 * @private
	 * @return {Object}
	 */
	getSearchShowButtonConfig: function() {
		return {
			id: this.id + "-search-show-btn",
			classes: {
				wrapperClass: "t-btn-image margin-right-0px t-btn-image-left search-show-button"
			},
			click: {
				bindTo: "onSearchShowButtonClick"
			},
			visible: {
				bindTo: "IsSearchVisible",
				bindConfig: {
					converter: function(isSearchVisible) {
						return !isSearchVisible;
					}
				}
			},
			hint: Terrasoft.Resources.SchemaDesigner.SearchShowButtonHint,
			markerValue: "SearchShowButton"
		};
	},

	/**
	 * Creates toolbar right container.
	 * @private
	 */
	createToolbarRightContainer: function() {
		const searchContainer = this.createSearchContainer();
		const searchShowButton = Ext.create("Terrasoft.Button", this.getSearchShowButtonConfig());
		const schemaPropertiesButton = Ext.create("Terrasoft.Button", this.getSchemaPropertiesButtonConfig());
		const helpButton = Ext.create("Terrasoft.Button", this.getHelpButtonConfig());
		const items = [
			searchContainer,
			searchShowButton,
			schemaPropertiesButton,
			helpButton
		];
		if (Terrasoft.Features.getIsEnabled("ProcessESN")) {
			const feedButton = Ext.create("Terrasoft.Button", this.getESNFeedButtonConfig());
			items.splice(2, 0, feedButton);
		}
		return {
			className: "Terrasoft.Container",
			id: this.id + "-toolbar-right",
			classes: {
				wrapClassName: ["toolbar-right"]
			},
			items: items
		};
	},

	/**
	 * Creates search container.
	 * @private
	 */
	createSearchContainer: function() {
		const resources = Terrasoft.Resources.SchemaDesigner;
		const buttonWrapperClass = "t-btn-image t-btn-image-left ";
		const searchTextEdit = this.searchTextEdit = Ext.create("Terrasoft.TextEdit", {
			id: this.id + "-search-edit",
			classes: {
				wrapClass: ["ts-box-sizing", "search-edit"]
			},
			value: {
				bindTo: "SearchTextEditValue"
			},
			listeners: {
				enterkeypressed: this.onSearchTextEditEnterKeyPressed.bind(this),
				keydown: this.onSearchTextEditKeyDown.bind(this),
				keyup: this.onSearchTextEditKeyUp.bind(this)
			},
			placeholder: resources.SearchTextEditPlaceholder,
			markerValue: "SearchTextEdit"
		});
		const searchInfoLabel = Ext.create("Terrasoft.Label", {
			id: this.id + "-search-info-label",
			caption: {
				bindTo: "SearchInfo"
			},
			classes: {
				labelClass: ["search-info-label"]
			},
			visible: {
				bindTo: "IsItemsFound"
			},
			markerValue: "SearchInfoLabel"
		});
		const searchErrorInfoLabel = Ext.create("Terrasoft.Label", {
			id: this.id + "-search-error-info-label",
			caption: {
				bindTo: "SearchErrorInfo"
			},
			classes: {
				labelClass: ["search-info-label", "search-error-info-label"]
			},
			visible: {
				bindTo: "FoundItems",
				bindConfig: {
					converter: function(items) {
						return items && items.isEmpty();
					}
				}
			},
			markerValue: "SearchErrorInfoLabel"
		});
		const searchPreviousButton = Ext.create("Terrasoft.Button", {
			id: this.id + "-search-previous-btn",
			classes: {
				wrapperClass: buttonWrapperClass + "search-previous-button"
			},
			click: {
				bindTo: "onSearchPreviousButtonClick"
			},
			visible: {
				bindTo: "IsItemsFound"
			},
			hint: Terrasoft.Resources.SchemaDesigner.SearchPreviousButtonHint,
			markerValue: "SearchPreviousButton"
		});
		const searchNextButton = Ext.create("Terrasoft.Button", {
			id: this.id + "-search-next-btn",
			classes: {
				wrapperClass: buttonWrapperClass + "search-next-button"
			},
			click: {
				bindTo: "onSearchNextButtonClick"
			},
			visible: {
				bindTo: "IsItemsFound"
			},
			hint: Terrasoft.Resources.SchemaDesigner.SearchNextButtonHint,
			markerValue: "SearchNextButton"
		});
		const searchButton = Ext.create("Terrasoft.Button", {
			id: this.id + "-search-btn",
			classes: {
				wrapperClass: buttonWrapperClass + "search-button"
			},
			click: {
				bindTo: "onSearchButtonClick"
			},
			hint: Terrasoft.Resources.SchemaDesigner.SearchButtonHint,
			markerValue: "SearchButton"
		});
		const searchHideButton = Ext.create("Terrasoft.Button", {
			id: this.id + "-search-hide-btn",
			classes: {
				wrapperClass: buttonWrapperClass + "search-hide-button"
			},
			click: {
				bindTo: "onSearchHideButtonClick"
			},
			hint: Terrasoft.Resources.SchemaDesigner.SearchHideButtonHint,
			markerValue: "SearchHideButton"
		});
		const searchToolsContainer = Ext.create("Terrasoft.Container", {
			id: this.id + "-search-tools-container",
			classes: {
				wrapClassName: ["search-tools-container"]
			},
			items: [
				searchInfoLabel,
				searchErrorInfoLabel,
				searchPreviousButton,
				searchNextButton,
				searchButton,
				searchHideButton
			]
		});
		return Ext.create("Terrasoft.Container", {
			id: this.id + "-search-container",
			classes: {
				wrapClassName: ["search-container"]
			},
			visible: {
				bindTo: "IsSearchVisible"
			},
			items: [
				searchTextEdit,
				searchToolsContainer
			]
		});
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#createToolbarContainer
	 * @override
	 */
	createToolbarContainer: function() {
		const toolbar = this.callParent(arguments);
		const leftToolbar = this.createToolbarLeftContainer();
		const rightToolbar = this.createToolbarRightContainer();
		toolbar.add(leftToolbar);
		toolbar.add(rightToolbar);
		return toolbar;
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#renderDesignContainer
	 * @override
	 */
	renderDesignContainer: function() {
		this.callParent(arguments);
		const designerViewModel = this.designerViewModel;
		designerViewModel.on("itemschanged", this.onProcessSchemaItemAdd, this);
		designerViewModel.on("itemCaptionChanged", this.onItemCaptionChanged, this);
		designerViewModel.on("itemIsValidChanged", this.onItemIsValidChanged, this);
		designerViewModel.on("clearSelection", this.onClearSelection, this);
		designerViewModel.on("itemSelected", this.onItemSelected, this);
		designerViewModel.on("updateItemsHighlighter", this.onUpdateItemsHighlighter, this);
		designerViewModel.on("change:IsSearchVisible", this.onIsSearchVisibleChange, this);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#initDesignerManagers
	 * @override
	 */
	initDesignerManagers: function(callback, scope) {
		this.callParent([async function() {
			await Terrasoft.ProcessFlowElementSchemaManager.initializeAsync();
			callback.call(scope);
		}, this]);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#onAfterDesignerRender
	 * @override
	 */
	onAfterDesignerRender: function() {
		this.callParent(arguments);
		this.preloadDragImages();
	},

	/**
	 * Preload images which used for dragging.
	 * @protected
	 */
	preloadDragImages: function() {
		const managerItemsCollection = Terrasoft.ProcessFlowElementSchemaManager.getItems();
		if (managerItemsCollection.isEmpty()) {
			return;
		}
		const flowItems = managerItemsCollection.getItems();
		Terrasoft.chain.apply(this, flowItems.map(function(item) {
			return function(next) {
				item.getInstance(function(instance) {
					this.preloadDragImage(instance, next);
				}, this);
			};
		}, this));
	},

	/**
	 * Preload drag image for instance of ProcessFlowElementSchema.
	 * @private
	 * @param {Terrasoft.ProcessFlowElementSchema} instance Schema instance.
	 * @param {Function} callback Callback function.
	 */
	preloadDragImage: function(instance, callback) {
		if (instance.getDragImage) {
			const image = new Image();
			image.onload = callback;
			image.onerror = () => {
				if (Terrasoft.isDebug) {
					const template = "Drag image not found for schema '{0}'. Source url: {1}";
					const errorMessage = Ext.String.format(template, instance.$className, image.src);
					this.error(errorMessage);
				}
				callback();
			};
			const imageConfig = instance.getDragImage();
			image.src = Terrasoft.ImageUrlBuilder.getUrl(imageConfig);
		} else {
			callback();
		}
	},

	/**
	 * Toggles left panel collapse state and only collapse when argument doCollapse is true.
	 * @private
	 * @param {Boolean} [doCollapse] Collapse left panel.
	 */
	toggleLeftPanel: function(doCollapse) {
		const collapseClass = this.leftPanelCollapseClass;
		const wrapEl = this.leftPanel.wrapEl;
		if (doCollapse !== undefined) {
			if (doCollapse) {
				wrapEl.addCls(collapseClass);
			} else {
				wrapEl.removeCls(collapseClass);
			}
		} else {
			wrapEl.toggleCls(collapseClass);
		}
		this.leftPanelCollapsed = wrapEl.hasCls(collapseClass);
		window.localStorage.setItem(this.storageLeftPanelCollapsed, this.leftPanelCollapsed);
		const leftPanelCloseAnimationDuration = 1000;
		setTimeout(function() {
			this.onDesignContentSizeChanged();
		}.bind(this), leftPanelCloseAnimationDuration);
	},

	/**
	 * Handler for LeftPanelHeaderButton click. Toggle collapsed class.
	 */
	onLeftPanelHeaderButtonClick: function() {
		this.toggleLeftPanel();
	},

	/**
	 * Returns classes for left panel container.
	 * @private
	 * @return {Object}
	 */
	getLeftPanelClasses: function() {
		const classes = ["schema-designer-left-panel"];
		const doCollapse = (window.localStorage.getItem(this.storageLeftPanelCollapsed) === "true") || false;
		if (doCollapse) {
			classes.push(this.leftPanelCollapseClass);
		}
		return {
			wrapClassName: classes
		};
	},

	/**
	 * Returns model columns. If columns property is null, returns empty object.
	 * @return {Object} Model columns.
	 */
	getModelColumns: function() {
		return _.clone(this.columns) || {};
	},

	/**
	 * Creates process diagram control.
	 * @private
	 * @return {Terrasoft.ProcessSchemaDiagram}
	 */
	createDiagram: function() {
		const config = this.getDiagramConfig();
		const diagram = this.diagram = Ext.create(this.schemaDiagramClassName, config);
		diagram.on("click", this.onElementClick, this);
		diagram.on("doubleClick", this.onElementDoubleClick, this);
		return diagram;
	},

	/**
	 * Inserts left panel to diagram container
	 * @private
	 */
	addLeftToolbar: function() {
		const leftPanel = this.leftPanel = Ext.create("Terrasoft.Container", {
			id: this.id + "-left-panel",
			classes: this.getLeftPanelClasses()
		});
		const leftPanelHeaderButton = Ext.create("Terrasoft.Button", {
			id: this.id + "-left-panel-header-button",
			style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
			classes: "schema-designer-left-panel-header-button",
			caption: this.leftToolbarHeaderButtonCaption,
			markerValue: "CollapseToolbar",
			onClick: this.onLeftPanelHeaderButtonClick.bind(this)
		});
		const leftToolBar = this.leftToolBar = Ext.create(this.leftToolbarClassName, {
			id: this.id + "-left-toolbar",
			designer: this,
			itemDrop: {
				bindTo: "onItemDrop"
			}
		});
		leftPanel.add(leftPanelHeaderButton);
		leftPanel.add(leftToolBar);
		leftToolBar.initToolbarItems();
		this.contentContainer.insert(leftPanel, 0);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesigner#createDesignContainer
	 * @override
	 */
	createDesignContainer: function() {
		const designMainContainer = this.callParent(arguments);
		if (this.hasLeftToolbar) {
			this.addLeftToolbar();
		}
		const diagram = this.createDiagram();
		this.diagramContainer.add(diagram);
		return designMainContainer;
	},

	/**
	 * Handler add event element to the diagram.
	 */
	onProcessSchemaItemAdd: function() {
		Ext.get("diagram-" + this.id).focus();
	},

	/**
	 * Click event handler on an element in the design process.
	 * @protected
	 */
	onElementClick: function() {
		this.focusDesigner();
	},

	/**
	 * The event handler by double-clicking an element in the design process.
	 * @private
	 */
	onElementDoubleClick: function() {
		this.diagram.updatePageSize();
	},

	/**
	 * Processor title change event process element.
	 * @private
	 */
	onItemCaptionChanged: function(item) {
		const nodeName = item.name;
		const caption = item.caption ? item.caption.getValue() || "" : "";
		const captionPrefix = item.notValidCaptionPrefix;
		this.diagram.setNodeCaption(nodeName, caption, captionPrefix);
	},

	/**
	 * Processor isValid change event process element.
	 * @protected
	 */
	onItemIsValidChanged: function(item) {
		const nodeName = item.name;
		const itemCaption = item.caption ? item.caption.getValue() : "";
		const caption = item.getLabelText(itemCaption, item.isValid);
		const fontColor = item.getLabelFontColor(item.isValid);
		this.diagram.setNodeCaptionWithColor(nodeName, caption, fontColor);
	},

	/**
	 * Handler for CopyElement menu item click.
	 * @private
	 */
	onCopyElementClick: function(menuItem) {
		this.diagram.copyElement();
		menuItem.parentMenu.hide();
	},

	/**
	 * Handler for PasteElement menu item click.
	 * @private
	 */
	onPasteElementClick: function(menuItem) {
		this.diagram.pasteElement();
		menuItem.parentMenu.hide();
	},

	/**
	 * Handler for clearSelection event.
	 * @private
	 */
	onClearSelection: function() {
		this.diagram.clearSelection();
	},

	/**
	 * Handler for itemSelected event.
	 * @private
	 */
	onItemSelected: function(itemName) {
		this.diagram.selectItem(itemName);
	},

	/**
	 * Handler for change of attribute IsSearchVisible of designer view model.
	 * @private
	 */
	onIsSearchVisibleChange: function(model, value) {
		if (value) {
			const el = this.searchTextEdit.getEl();
			el.focus();
			if (el && el.dom) {
				el.dom.select();
			}
		}
	},

	/**
	 * Handler for press "ENTER" key in the SearchTextEdit control.
	 * @private
	 */
	onSearchTextEditEnterKeyPressed: function() {
		this.designerViewModel.onSearchButtonClick();
	},

	/**
	 * Handler for KeyDown event on SearchTextEdit control.
	 * @private
	 * @param {Object} control Control.
	 * @param {Object} event Event object.
	 */
	onSearchTextEditKeyDown: function(control, event) {
		const viewModel = this.designerViewModel;
		if (event.keyCode === event.ESC) {
			event.preventDefault();
			viewModel.onSearchHideButtonClick();
			return;
		}
		if (event.shiftKey && (event.keyCode === event.ENTER || event.keyCode === event.F3)) {
			event.preventDefault();
			viewModel.searchPreviousItem();
			return;
		}
		if (!event.shiftKey && event.keyCode === event.F3) {
			event.preventDefault();
			viewModel.onSearchButtonClick();
		}
	},

	/**
	 * Handler for KeyUp event on SearchTextEdit control.
	 * @private
	 * @param {Object} control Control.
	 */
	onSearchTextEditKeyUp: function(control) {
		const value = control.getTypedValue();
		control.changeValue(value);
	},

	/**
	 * Handler for highlight items on diagram
	 * @param {Terrasoft.Collection} selectedItems Diagram items for highlight.
	 * @param {String} selectedItemName The name of selected item.
	 */
	onUpdateItemsHighlighter: function(selectedItems, selectedItemName) {
		this.diagram.updateItemsHighlighter(selectedItems, selectedItemName);
	}

});
