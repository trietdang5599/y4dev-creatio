define("WebServicesDesigner", ["ext-base", "terrasoft", "BaseViewModule", "css!WebServicesDesigner"], function(Ext, Terrasoft) {
	return Ext.define("Terrasoft.configuration.WebServicesDesigner", {
		extend: "Terrasoft.BaseViewModule",
		alternateClassName: "Terrasoft.WebServicesDesigner",
		/**
		 * @private
		 */
		_wrapClassName: "web-services",
		/**
		 * @private
		 */
		_cardModuleV2Name: 'CardModuleV2',
		/**
		 * @param {String} hash Hash
		 * @return {String}
		 * @private
		 */
		_parseHash: function(hash) {
			const params = hash.split("/");
			const operation = params[0];
			if (operation === this._cardModuleV2Name) {
				return hash;
			}
			if (operation === 'edit') {
				return this._prepareEditParameters(params[1]);
			}
			return this._prepareAddParameters(params[1], params[3]);
		},

		/**
		 * @param {String} type
		 * @param {String} packageUId
		 * @returns {String}
		 * @private
		 */
		_prepareAddParameters: function(type, packageUId) {
			return Ext.String.format("{0}/{1}WebServiceV2Page/add/packageUId/{2}", this._cardModuleV2Name, type, packageUId);
		},
		/**
		 * @param {String} schemaId
		 * @returns {String}
		 * @private
		 */
		_prepareEditParameters: function(schemaId) {
			return Ext.String.format("{0}/WebServiceV2Page/edit/{1}", this._cardModuleV2Name, schemaId);
		},
		/**
		 * @inheritdoc Terrasoft.BaseViewModule#render
		 * @overridden
		 */
		render: function(renderTo) {
			const mainContentWrapper = Ext.get("mainContentWrapper");
			mainContentWrapper.addCls(this._wrapClassName);
			this.renderTo = renderTo;
			this.callParent(arguments);
		},
		/**
		 * @inheritdoc Terrasoft.BaseViewModule#loadMainPanelsModules
		 * @overridden
		 */
		loadMainPanelsModules: function() {
			const sandbox = this.sandbox;
			const state = sandbox.publish("GetHistoryState");
			const hashFromHistoryState = state.hash.historyState;
			const newHash = this._parseHash(hashFromHistoryState) ;
			sandbox.publish("ReplaceHistoryState", {hash: newHash});
		},
		/**
		 * @inheritdoc Terrasoft.BaseViewModule#getMessages
		 * @overridden
		 * @returns {*}
		 */
		getMessages: function() {
			const parentMessages = this.callParent(arguments) || {};
			return this.Ext.apply(parentMessages, {
				"LoadModule": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"HistoryStateChanged": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"RefreshCacheHash": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"NavigationModuleLoaded": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"GetHistoryState": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"ReplaceHistoryState": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			});
		},
	});
 });
