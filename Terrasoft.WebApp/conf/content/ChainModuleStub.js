Terrasoft.configuration.Structures["ChainModuleStub"] = {innerHierarchyStack: ["ChainModuleStub"]};
define("ChainModuleStub", [], function() {
	Ext.define("Terrasoft.configuration.ChainModuleStub", {
		alternateClassName: "Terrasoft.ChainModuleStub",
		extend: "Terrasoft.BaseModule",
		Ext: null,
		sandbox: null,
		Terrasoft: null,

		/**
		 * ViewModel rendering container name.
		 */
		_renderTo: "",

		resetBodyAttributes: function() {
			Terrasoft.utils.dom.setAttributeToBody("is-card-opened", false);
			Terrasoft.utils.dom.setAttributeToBody('is-main-header-visible', true);
		},

		render: function(renderTo) {
			this._renderTo = renderTo;
			this._renderTo.dom.innerHTML = '<div data-item-marker="ChainModuleStub"></div>'
		},

		init: function() {
			this.sandbox.registerMessages({
				"GetHistoryState": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"ReplaceHistoryState": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.BROADCAST
				},

			})
			this.initHistoryState();
		},

		initHistoryState: function() {
			var sandbox = this.sandbox;
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = this.prepareHistoryState(currentState);
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		},

		prepareHistoryState: function(currentState) {
			var newState = this.Terrasoft.deepClone(currentState);
			newState.moduleId = this.sandbox.id;
			return newState;
		},

		destroy: function() {
			this.resetBodyAttributes();
			this._renderTo.dom.innerHTML = ''
		}
	});
	return Terrasoft.ChainModuleStub;
})


