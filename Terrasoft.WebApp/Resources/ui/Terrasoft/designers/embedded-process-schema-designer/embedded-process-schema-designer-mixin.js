Ext.define("Terrasoft.EmbeddedProcessSchemaDesignerMixin", {
	alternateClassName: "Terrasoft.core.mixins.EmbeddedProcessSchemaDesignerMixin",

	// region Methods: Private

	/**
	 * @private
	 */
	_containsCaseInsensitive: function(collection, searchKey, isEmbedded) {
		const searchKeyInLowerCase = searchKey.toLowerCase();
		return collection.getKeys().some(function(key) {
			if (isEmbedded) {
				return key.toLowerCase().indexOf(searchKeyInLowerCase) > -1;
			} else {
				return key.toLowerCase() === searchKey.toLowerCase();
			}
		});
	},

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onSchemaLoaded
	 * @override
	 * @param {Terrasoft.manager.EmbeddedProcessSchema} schema Process schema.
	 */
	onSchemaLoaded: function(schema) {
		this.set("hasParentProcess", !!(schema && schema.parentOwnerSchemaUId));
		this.set("IsSchemaCaptionEnabled", false);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onGenerateItemNameAndCaption
	 * @override
	 */
	onGenerateItemNameAndCaption: function(item) {
		const schema = this.get("Schema");
		const items = this.get("Items");
		let index = 1;
		const defName = item.name;
		let key = defName + index;
		const inheritedElements = this.get("Schema").inheritedElements;
		const isEmbedded = schema.isEmbedded;
		while (this._containsCaseInsensitive(items, key, isEmbedded) ||
		this._containsCaseInsensitive(inheritedElements, key, isEmbedded)) {
			index++;
			key = defName + index;
		}
		item.name = key;
		if (isEmbedded) {
			item.name += "_" + Terrasoft.formatGUID(item.uId, "N");
		}
		const caption = item.caption;
		if (caption) {
			const cultureValues = caption.cultureValues;
			Terrasoft.each(cultureValues, function (value, culture) {
				if (value) {
					cultureValues[culture] = value + " " + index;
				}
			}, this);
		}
		return false;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolBarLefContainerItems
	 * @override
	 */
	createToolBarLefContainerItems: function(actionButtonMenuItems) {
		return [
			this.getSaveButton(),
			this.getCloseButton(),
			this.getActionsButton(actionButtonMenuItems)
		];
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolbarLeftContainer
	 * @override
	 */
	createToolbarLeftContainer: function() {
		const resources = Terrasoft.Resources.SchemaDesigner;
		const menuItems = [];
		this.addOpenParentProcessMenuItem(menuItems, resources);
		this.addProcessSourceCodeMenuItem(menuItems, resources);
		this.addSeparatorMenuItem(menuItems);
		this.addElementCopyMenuItem(menuItems, resources);
		this.addElementPasteMenuItem(menuItems, resources);
		return this.getCreateToolbarLeftContainerConfig(menuItems);
	},

	/**
	 * Opens parent process schema in new designer window.
	 * @private
	 */
	onOpenParentProcessClick: function() {
		if (this.get("hasParentProcess")) {
			const schema = this.get("Schema");
			const url = Terrasoft.workspaceBaseUrl + "/Nui/ViewModule.aspx?vm=SchemaDesigner#entityProcess/" +
				schema.parentOwnerSchemaUId;
			window.open(url);
		}
	},

	/**
	 * Adds Open Parent Process item to a button menu of Actions.
	 * @param {Array} menuItems Items of the menu.
	 * @param {Object} resources Resources.
	 */
	addOpenParentProcessMenuItem: function(menuItems, resources) {
		menuItems.push(Ext.create("Terrasoft.MenuItem", {
			id: this.id + "-open-parent-process-mi",
			caption: resources.OpenParentProcessMenuItemCaption,
			click: {bindTo: "onOpenParentProcessClick"},
			enabled: "$hasParentProcess"
		}));
	}

	// endregion
});
