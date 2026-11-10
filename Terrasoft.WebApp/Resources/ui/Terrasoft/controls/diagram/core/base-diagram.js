/**
 * The class implements base functionality of diagram.
 */
Ext.define("Terrasoft.controls.BaseDiagram", {
	extend: "Terrasoft.Container",
	alternateClassName: "Terrasoft.BaseDiagram",

	/**
	 * Collection of items
	 * @type {Terrasoft.Collection}
	 */
	items: null,

	/**
	 * @inheritdoc Terrasoft.AbstractContainer#initItems
	 * @override
	 */
	initItems: Ext.emptyFn,

	/**
	 * @inheritdoc Terrasoft.AbstractContainer#prepareItems
	 * @override
	 */
	prepareItems: Ext.emptyFn,

	/**
	 * @inheritdoc Terrasoft.AbstractContainer#destroyItems
	 * @override
	 */
	destroyItems: Ext.emptyFn,

	constructor: function() {
		this.items = Ext.create("Terrasoft.Collection");
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc Terrasoft.Component#getTplData
	 * @override
	 */
	getTplData: function() {
		var tplData = this.callParent(arguments);
		this.selectors = this.getSelectors();
		return tplData;
	},

	/**
	 * @inheritdoc Terrasoft.Component#getSelectors
	 * @override
	 */
	getSelectors: function() {
		return {
			wrapEl: "#diagram-" + this.id
		};
	},

	/**
	 * Returns the configuration of the binding to the model. Implements the {@link Terrasoft.Bindable} mixin interface.
	 * @protected
	 * @override
	 */
	getBindConfig: function() {
		var bindConfig = this.callParent(arguments);
		var diagramBindConfig = {
			items: {
				changeMethod: "onCollectionDataLoaded"
			}
		};
		return Ext.apply(diagramBindConfig, bindConfig);
	},

	/**
	 * The "dataLoaded" event handler for the Terrasoft.Collection
	 * @protected
	 */
	onCollectionDataLoaded: Ext.emptyFn,

	/**
	 * Component initialization.
	 * @protected
	 * @override
	 */
	init: function() {
		this.callParent(arguments);
		this.addEvents(
			/**
			 * @event
			 * Click event by element
			 */
			"click",
			/**
			 * @event
			 * Double-click event by element
			 */
			"doubleClick",
			/**
			 * @event
			 * Event of changing the selected item
			 */
			"selectionChange",
			/**
			 * @event
			 * Connector change event
			 */
			"connectionChange",
			/**
			 * @event
			 * The mouseUp event
			 */
			"mouseUp",
			/**
			 * @event
			 * The mouseMove event
			 */
			"mouseMove",
			/**
			 * @event
			 * Event for changing the collection of items
			 */
			"nodesCollectionChange",
			/**
			 * @event
			 * Connector collection change event
			 */
			"connectorsCollectionChange",
			/**
			 * @event
			 *  Connector change event. It is generated when a connector has a connection point with a diagram element.
			 */
			"connectorsNodesChange",
			/**
			 * @event
			 * Event of changing the signature of the diagram element.
			 */
			"textChange"
		);
	}
});
