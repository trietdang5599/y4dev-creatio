Ext.define("Terrasoft.PackageDependenciesDiagramMixin", {
	alternateClassName: "Terrasoft.core.mixins.PackageDependenciesDiagramMixin",

	//region Methods: Private

	/**
	 * Handler for event message.
	 * @private
	 * @param {Object} event Event data.
	 */
	onMessageReceived: function(event) {
		const response = Terrasoft.decode(event.browserEvent.data);
		if (response.message === "ReadMetaData") {
			this.loadProcessSchema(response);
		}
	},

	/**
	 * Loads process schema.
	 * @private
	 * @param {Object} response Server response.
	 */
	loadProcessSchema: function(response) {
		const metaData = response.metaData;
		const schema = Terrasoft.SchemaDesignerUtilities.createInstanceByMetaData({
			metaData: metaData,
			schemaClassName: "Terrasoft.ProcessSchema",
			resources: response.resources
		});
		this.loadItems(schema);
		this.fireEvent("initialized", this);
	},

	/**
	 * Returns location origin. IE fix.
	 * @private
	 * @return {String}
	 */
	getLocationOrigin: function() {
		let origin = window.location.origin;
		if (!origin) {
			origin = window.location.protocol + "//" + window.location.hostname +
				(window.location.port ? ":" + window.location.port : "");
		}
		return origin;
	},

	/**
	 * Sends to server message of process schema changes.
	 * @param {Object} requestJson Request JSON object.
	 */
	sendMessage: function(requestJson) {
		const message = Terrasoft.encode(requestJson);
		const locationOrigin = this.getLocationOrigin();
		const parent = window.parent;
		parent.postMessage(message, locationOrigin);
	},

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		Ext.EventManager.addListener(window, "message", this.onMessageReceived, this);
		this.sendMessage({
			message: "GetMetaData"
		});
	}
});
