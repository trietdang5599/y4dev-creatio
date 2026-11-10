/**
 * Class of content element with HTML.
 */
Ext.define("Terrasoft.controls.ContentHTMLElement", {
	extend: "Terrasoft.controls.BaseContentElement",
	alternateClassName: "Terrasoft.ContentHTMLElement",

	mixins: {
		sanitizeHtml: "Terrasoft.SanitizeHtml"
	},

	//region Properties: Private

	/**
	 * Sanitization level.
	 * @protected
	 * @type {Integer}
	 */
	sanitizationLevel: Terrasoft.sanitizationLevel.DEFAULT,

	/**
	 * Displayed content.
	 * @private
	 * @type {String}
	 */
	content: null,

	//endregion

	//region Properties: Protected

	/**
	 * A collection of toolbar items.
	 * @protected
	 * @type {Ext.util.MixedCollection}
	 */
	htmlTools: null,

	/**
	 * A collection of style classes for the tool container.
	 * @protected
	 * @type {String[]}
	 */
	htmlToolsWrapClasses: ["content-html-element-tools-wrap"],

	/**
	 * A collection of style classes for the control container.
	 * @protected
	 * @type {String[]}
	 */
	contentWrapClasses: ["content-html-element-wrap"],

	/**
	 * The style class for placeholder.
	 * @protected
	 * @type {String}
	 */
	placeholderClass: "content-html-element-placeholder",

	/**
	 * Text for placeholder.
	 * @protected
	 * @type {String}
	 */
	placeholder: "",

	/**
	 * @inheritdoc Terrasoft.controls.AbstractContainer#defaultRenderTpl
	 * @override
	 */
	defaultRenderTpl: [
		`<div id="{id}-content-html-element" style="{wrapStyle}" class="{wrapClassName}">`,
			`<tpl if="hasContent">`,
				`{content}`,
			`<tpl else>`,
				`<div class="{placeholderClass}"><span>{placeholder}</span></div>`,
			`</tpl>`,
			`<div class="content-cover"></div>`,
			`<tpl if="hasTools">`,
				`<div id="{id}-content-element-tools" class="{toolsWrapClasses}">
					<tpl for="tools">
						{%this.renderTool(out, values)%}
					</tpl>
				</div>`,
			`</tpl>`,
			`<div id="{id}-content-html-element-tools" class="{htmlToolsWrapClasses}">`,
				`<tpl for="htmlTools">`,
					`{%this.renderTool(out, values)%}`,
				`</tpl>`,
			`</div>`,
		`</div>`
	],

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.AbstractContainer#initRenderData
	 * @override
	 */
	initRenderData: function(renderData) {
		this.callParent(arguments);
		renderData.htmlTools = this.htmlTools;
	},

	/**
	 * @inheritdoc Terrasoft.BaseContentElement#initTools
	 * @override
	 */
	initTools: function() {
		this.callParent();
		var htmlTools = this.htmlTools;
		var collection = this.htmlTools = new Ext.util.MixedCollection(false, this.getComponentId);
		collection.on("add", this.onToolAdd, this);
		this.addToCollection(htmlTools, this.htmlTools);
	},

	/**
	 * @inheritdoc Terrasoft.BaseContentElement#destroyTools
	 * @override
	 */
	destroyTools: function() {
		this.callParent();
		this.destroyItemsCollection(this.htmlTools);
		this.htmlTools = null;
	},

	/**
	 * The method returns the selectors of the control.
	 * @protected
	 * @return {Object} The selector object.
	 */
	getSelectors: function() {
		var selectors = {
			toolsEl: "#" + this.id + "-content-html-element-tools",
			wrapEl: "#" + this.id + "-content-html-element"
		};
		return selectors;
	},

	/**
	 * @inheritdoc Terrasoft.BaseContentElement#getTplData
	 * @override
	 */
	getTplData: function() {
		var tplData = this.callParent(arguments);
		var hasContent = !Ext.isEmpty(this.content);
		return Ext.apply(tplData, {
			hasContent: hasContent,
			content: this.content,
			placeholder: Terrasoft.encodeHtml(this.placeholder),
			placeholderClass: this.placeholderClass,
			htmlToolsWrapClasses: this.htmlToolsWrapClasses
		});
	},

	//endregion

	//region Methods: Public

	/**
	 * Returns the configuration of the binding to the model. Implements the {@link Terrasoft.Bindable} mixin interface.
	 * @override
	 */
	getBindConfig: function() {
		var bindConfig = this.callParent(arguments);
		var sanitizeHTMLBindConfig = this.getSanitizeHtmlBindConfig();
		var elementConfig = {
			content: {
				changeMethod: "setContent"
			},
			placeholder: {
				changeMethod: "setPlaceholder"
			}
		};
		return Ext.apply(elementConfig, bindConfig, sanitizeHTMLBindConfig);
	},

	/**
	 * @inheritdoc Terrasoft.AbstractContainer#bind
	 * @override
	 */
	bind: function() {
		this.callParent(arguments);
		this.htmlTools.each(function(item) {
			item.bind(this.model);
		}, this);
	},

	/**
	 * Updates the text for the placeholder.
	 * @param {String} text Text for placeholder.
	 */
	setPlaceholder: function(text) {
		if (text !== this.placeholder) {
			this.placeholder = text;
			if (Ext.isEmpty(this.content) && this.allowRerender()) {
				this.reRender();
			}
		}
	},

	/**
	 * Updates the displayed content of the control.
	 * @param {Object} content Content.
	 */
	setContent: function(content, force) {
		content = content || "";
		if (content !== this.content || force) {
			this.content = this.getSanitizedValue(content, this.sanitizationLevel);
			this.safeRerender();
		}
	},

	/**
	 * @inheritdoc Terrasoft.SanitizeHtml#setSanitizeHtml
	 * @override
	 */
	setSanitizeHtml: function(value) {
		this.mixins.sanitizeHtml.setSanitizeHtml.call(this, value);
		this.setContent(this.content, true);
	}

	//endregion

});