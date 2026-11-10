Ext.define("Terrasoft.utils.UserAgent", {
	singleton: true,
	_supportedBrowsers: {
		chrome: '138',
		firefox: '140',
		safari: '18',
		edge: '138',
		'webkit': '620',
		'chrome webview': '138'
	},

	/**
	 * @return {Boolean} True if browser is supported.
	 */
	isBrowserSupported: function() {
		let userAgent = null;
		let userAgentParser = require("user-agent-parser");
		if (userAgentParser) {
			userAgent = new userAgentParser();
		}
		const browser = userAgent?.getBrowser();
		if (!browser) {
			return false;
		}
		const currentBrowserName = browser.name.toLowerCase();
		const currentBrowserMajorVersion = browser.major;
		const minSupportedBrowserVersion = this._supportedBrowsers[currentBrowserName];
		if (!minSupportedBrowserVersion) {
			return false;
		}
		return parseFloat(currentBrowserMajorVersion) >= parseFloat(minSupportedBrowserVersion);
	},
});
