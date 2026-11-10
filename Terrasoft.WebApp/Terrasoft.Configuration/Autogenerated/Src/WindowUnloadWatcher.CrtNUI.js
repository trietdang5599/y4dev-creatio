 define("WindowUnloadWatcher", ["CheckModuleDestroyMixin"], function() {
	return {
		mixins: {
			CheckModuleDestroyMixin: "Terrasoft.CheckModuleDestroyMixin",
		},
		methods: {
			init: function () {
				this.callParent(arguments);
				if (Terrasoft.Features.getIsEnabled("DisableWindowUnloadWatcher")) {
					return;
				}
				window.addEventListener('beforeunload', this.beforePageUnload.bind(this));
			},

			beforePageUnload: function (event) {
				if (Terrasoft.SessionEndUserNotification?.sessionExpired) {
					return true;
				}
				const hasUnsavedChangesResult = this.hasUnsavedChanges();
				if (!hasUnsavedChangesResult?.hasChanges) {
					return true;
				}
				const message = hasUnsavedChangesResult?.message;
				if (event) {
					event.returnValue = message;
				}
				return message;
			}
		}
	};
});
