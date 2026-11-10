/**
 * The object of rendering the password icon.
 */
Ext.define("Terrasoft.controls.mixins.PasswordIcon", {
	alternateClassName: "Terrasoft.PasswordIcon",

	/**
	 * Classes of CSS styles for the password icon
	 * @protected
	 */
	passwordIconClasses: [],

	/**
	 * Password icon template
	 * @protected
	 */
	passwordIconTpl: [
		"<div id=\"{id}-password-icon-wrapper\" class=\"base-edit-password-icon-wrapper\">",
		"<div id=\"{id}-password-icon\" class=\"{passwordIconClasses}\" style=\"{passwordIconStyles}\"></div>",
		"</div>"
	],

	/**
	 * The method that starts the icon rendering. Called by default from the template Terrasoft.Baseedit
	 * @protected
	 * @param buffer
	 * @param renderData
	 */
	renderPasswordIcon: function(buffer, renderData) {
		var self = renderData.self;
		if (!self.usePasswordIcon()) {
			return;
		}
		var template = new Ext.Template(self.passwordIconTpl);
		var tpl = template.apply({
			id: self.id,
			passwordIconClasses: self.combinePasswordIconClasses(),
			passwordIconStyles: self.combinePasswordIconStyles()
		});
		buffer.push(tpl);
	},

	/**
	 * Method for collecting CSS classes of the password icon depending on the conditions
	 * @protected
	 * @return {string}
	 */
	combinePasswordIconClasses: function() {
		var passwordIconClasses = ["base-edit-password-icon"];
		if (!Ext.isEmpty(this.passwordIconClasses)) {
			passwordIconClasses = Ext.Array.merge(passwordIconClasses, this.passwordIconClasses);
		}
		return passwordIconClasses.join(" ");
	},

	/**
	 * Method for collecting CSS styles of the password icon depending on the conditions
	 * @protected
	 * @return {*|String|String[]}
	 */
	combinePasswordIconStyles: function() {
		var passwordIconStyles = {};
		if (!Ext.isEmpty(this.passwordIconConfig)) {
			var passwordIconUrl = Terrasoft.ImageUrlBuilder.getUrl(this.passwordIconConfig);
			passwordIconStyles.background = "url('" + passwordIconUrl + "') no-repeat center center";
		}
		return Ext.DomHelper.generateStyles(passwordIconStyles);
	},

	/**
	 * The method returns the convention of using the right icon for external settings.
	 * @return {boolean}
	 */
	usePasswordIcon: function() {
		return this.protect && !!Terrasoft.usePasswordIconForTextEdit;
	},

	combineSelectors: function(selectors) {
		const id = this.id;
		selectors.passwordIconEl = "#" + id + "-password-icon";
		selectors.passwordIconWrapperEl = "#" + id + "-password-icon-wrapper";
		return selectors;
	},

	/**
	 * The method that initializes the events of the password icon
	 * @protected
	 */
	initPasswordIconEvents: function() {
		/**
		 * @event click
		 * Click event on the password icon
		 */
		this.passwordIconWrapperEl.on("mousedown", this.onPasswordIconMouseDown, this);
		this.passwordIconWrapperEl.on("mouseup", this.onPasswordIconMouseUp, this);
	},

	/**
	 * The handler for the mousedown event on the password icon
	 * @protected
	 */
	onPasswordIconMouseDown: function() {
		if (!this.enabled || !this.rendered) {
			return;
		}

		this.el.dom.type = "text";
	},

	/**
	 * The handler for the mouseup event on the password icon
	 * @protected
	 */
	onPasswordIconMouseUp: function() {
		if (!this.enabled || !this.rendered) {
			return;
		}

		this.el.dom.type = "password";
	},
});