Ext.ns("Terrasoft.router");

if (Terrasoft.isAngularHost) {
	Ext.define("Terrasoft.router.AngularHistoryNavigationProvider", {
		extend: "Terrasoft.BaseNavigationProvider",
		alternateClassName: "Terrasoft.AngularHistoryNavigationProvider",

		/**
		 * @override Terrasoft.BaseNavigationProvider#pushState
		 * @inheritdoc
		 */
		pushState: function(stateObj, pageTitle, hash) {
			this.context.historyWrapper.pushState(stateObj, pageTitle, this.getFullUrl(hash));
			this.doStateChanged();
		},

		/**
		 * @override Terrasoft.BaseNavigationProvider#replaceState
		 * @inheritdoc
		 */
		replaceState: function(stateObj, pageTitle, hash) {
			this.context.historyWrapper.replaceState(stateObj, pageTitle, this.getFullUrl(hash));
			this.doStateChanged();
		},

		/**
		 * @override Terrasoft.BaseNavigationProvider#back
		 * @inheritdoc
		 */
		back: function() {
			this.go(-1);
		},

		/**
		 * @override Terrasoft.BaseNavigationProvider#forward
		 * @inheritdoc
		 */
		forward: function() {
			this.go(1);
		},

		/**
		 * @override Terrasoft.BaseNavigationProvider#go
		 * @inheritdoc
		 */
		go: function(delta) {
			this.context.historyWrapper.go(delta);
		},

		/**
		 * @override Terrasoft.BaseNavigationProvider#onPopState
		 * @inheritdoc
		 */
		onPopState: function() {
		}
	});
}
