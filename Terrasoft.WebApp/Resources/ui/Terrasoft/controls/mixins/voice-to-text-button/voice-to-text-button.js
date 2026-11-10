/**
 * The object of rendering the voice to text button.
 */
Ext.define("Terrasoft.controls.mixins.VoiceToTextButton", {
	alternateClassName: "Terrasoft.VoiceToTextButton",

	/**
	 * Parameter indicating that you want to use the voice to text button.
	 * @protected
	 * @property {Boolean} enableVoiceToTextButton
	 */
	enableVoiceToTextButton: false,

	/**
	 * Classes of CSS styles for the voice to text button.
	 * @protected
	 */
	voiceToTextClasses: [],

	/**
	 * Current user culture name.
	 */
	currentUserCulture: Terrasoft.currentUserCultureName,

	/**
	 * Left icon template
	 * @protected
	 */
	voiceToTextTpl: [
		"<div id=\"{id}-voice-to-text-wrapper\" class=\"base-edit-voice-to-text-wrapper\">",
		"<div id=\"{id}-voice-to-text\" class=\"{voiceToTextClasses}\">",
		"<ts-voice-to-text-button id=\"{id}-voice-to-text-component\" language=\"{currentUserCulture}\" ></ts-voice-to-text-button>",
		"</div></div>",
	],

	/**
	 * Template of how to format new value.
	 */
	newValueFormatTpl: "{0}. {1}",

	/**
	 * Initializes voice to text events.
	 */
	init: function() {
		require(["voice-to-text-component"], function(){});
		this.addEvents(
			/**
			 * @event
			 * The event is generated when the button is clicked.
			 */
			"speechRecognitionFinished"
		);
	},

	/**
	 * The method that starts the icon rendering. Called by default from the template Terrasoft.Baseedit
	 * @protected
	 * @param buffer
	 * @param renderData
	 */
	renderVoiceToTextButton: function(buffer, renderData) {
		const self = renderData.self;
		if (!self.useVoiceToTextButton()) {
			return;
		}
		const template = new Ext.Template(self.voiceToTextTpl);
		const tpl = template.apply({
			id: self.id,
			currentUserCulture: self.currentUserCulture || Terrasoft.currentUserCultureName,
			voiceToTextClasses: self.combineVoiceToTextButtonClasses(),
		});
		buffer.push(tpl);
	},

	/**
	 * Method for collecting CSS classes of the voice to text button depending on the conditions
	 * @protected
	 * @return {string}
	 */
	combineVoiceToTextButtonClasses: function() {
		let voiceToTextClasses = ["base-edit-voice-to-text"];
		if (!Ext.isEmpty(this.voiceToTextClasses)) {
			voiceToTextClasses = Ext.Array.merge(voiceToTextClasses, this.voiceToTextClasses);
		}
		return voiceToTextClasses.join(" ");
	},

	/**
	 * The method returns the convention of using the voice to text button for external settings.
	 * @return {boolean}
	 */
	useVoiceToTextButton: function() {
		return this.enableVoiceToTextButton && Terrasoft.Features.getIsEnabled("UseVoiceToText");
	},

	/**
	 * Returns the configuration of the binding to the model. Implements the {@link Terrasoft.Bindable} mixin interface.
	 * @override
	 */
	getBindConfig: function() {
		return {
			enableVoiceToTextButton: {
				changeMethod: "setEnableVoiceToTextButton",
			},
		};
	},

	/**
	 * Initializes voice to text events.
	 */
	initVoiceToTextButtonEvents: function() {
		const el = this.voiceToTextEl;
		if (el) {
			el.on("speechRecognitionFinished", this.onSpeechRecognitionFinished, this);
		}
	},

	/**
	 * Clears voice to text events.
	 */
	clearVoiceToTextButtonEvents: function() {
		const el = this.voiceToTextEl;
		if (el) {
			el.un("speechRecognitionFinished", this.onSpeechRecognitionFinished, this);
		}
	},

	/**
	 * The method returns the selectors of the control.
	 * @return {Object} The selector object.
	 */
	combineSelectors: function(selectors) {
		const id = this.id;
		selectors.voiceToTextEl = "#" + id + "-voice-to-text-component";
		selectors.voiceToTextWrapperEl = "#" + id + "-voice-to-text-wrapper";
		return selectors;
	},

	/**
	 * The handler for the click event on the voice to text button
	 * @protected
	 */
	onSpeechRecognitionFinished: function(event) {
		if (!this.enabled || !this.rendered) {
			return;
		}
		const text = event.browserEvent.detail;
		this.fireEvent("speechRecognitionFinished", text, this);
	},

	/**
	 * Sets enable flag to voice to text button.
	 * @param {Boolean} enable Enable flag.
	 */
	setEnableVoiceToTextButton: function(enable) {
		if (this.enableVoiceToTextButton === enable) {
			return;
		}
		this.enableVoiceToTextButton = enable;
		this.safeRerender();
	},

	/**
	 * Formats new text value applying to old one.
	 * @param {String} oldValue Old text.
	 * @param {String} text New recognized text.
	 * @return {String} Formatted value.
	 */
	formatVoiceValue: function(oldValue, text) {
		text = Ext.String.capitalize(text);
		if (oldValue) {
			return Ext.String.format(this.newValueFormatTpl, oldValue, text);
		}
		return text;
	}
});
