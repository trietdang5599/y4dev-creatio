define("login-view-utils", ["ext-base", "terrasoft", "user-agent"], function(Ext, Terrasoft) {
	return {
		/**
		 * Creates login table container.
		 * @param {String} idName container id.
		 */
		createTableContainer: function(idName) {
			return Ext.create("Terrasoft.Container", {
				id: idName,
				selectors: {
					wrapEl: "#" + idName
				},
				classes: {
					wrapClassName: ["login-table-container"]
				}
			});
		},
		/**
		 * Creates login container for row of inputs and messages.
		 * @param {String} idName container id.
		 */
		createRowContainer: function(idName) {
			return Ext.create("Terrasoft.Container", {
				id: idName,
				selectors: {
					wrapEl: "#" + idName
				},
				classes: {
					wrapClassName: ["login-row-container"]
				}
			});
		},
		/**
		 * Creates login container for inputs and messages.
		 * @param {String} idName container id.
		 */
		createCellContainer: function(idName) {
			return Ext.create("Terrasoft.Container", {
				id: idName,
				selectors: {
					wrapEl: "#" + idName
				},
				classes: {
					wrapClassName: ["login-cell-container"]
				}
			});
		},
		/**
		 * Creates label with login page styles.
		 * @param {String} caption label text.
		 */
		createLabel: function(caption) {
			return Ext.create("Terrasoft.Label", {
				caption: caption,
				classes: {
					labelClass: ["login-info-label"]
				}
			});
		},

		/**
		 * Creates container for unsupported browser message.
		 * @return {Terrasoft.Container} Unsupported browser message container.
		 */
		createUnsupportedBrowserContainer: function() {
			const unsupportedBrowserTitle = Ext.create("Terrasoft.Container", {
				classes: {
					wrapClassName: ['unsupported-browser__title']
				},
				items: [
					Ext.create("Terrasoft.HtmlControl", {
						tpl: [
							`<img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTYiIGhlaWdodD0iMTYiIHZpZXdCb3g9IjAgMCAxNiAxNiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik04IDJDNy43MDY3MiAyIDcuNDE4NjUgMi4wNzQwNyA3LjE2NDk1IDIuMjE0NzJDNi45MTE4MiAyLjM1NTA0IDYuNzAxODcgMi41NTY2NiA2LjU1NjI0IDIuNzk5MjVMNi41NTUyNCAyLjgwMDkzTDEuMjI0MjUgMTEuNjAzNkMxLjA3Nzg3IDExLjg0NiAxLjAwMDI2IDEyLjEyMTYgMSAxMi40MDE1QzAuOTk5NzQyIDEyLjY4MTMgMS4wNzY0MiAxMi45NTY0IDEuMjIyMzYgMTMuMTk5QzEuMzY4MjkgMTMuNDQxNiAxLjU3ODM2IDEzLjY0MzMgMS44MzE1MiAxMy43ODM5QzIuMDg0NjcgMTMuOTI0NSAyLjM3MjAzIDEzLjk5OSAyLjY2NDc5IDE0TDIuNjY3MjYgMTRMMTMuMzMyNyAxNEwxMy4zMzUyIDE0QzEzLjYyOCAxMy45OTkgMTMuOTE1MyAxMy45MjQ1IDE0LjE2ODUgMTMuNzgzOUMxNC40MjE2IDEzLjY0MzMgMTQuNjMxNyAxMy40NDE2IDE0Ljc3NzYgMTMuMTk5QzE0LjkyMzYgMTIuOTU2NCAxNS4wMDAzIDEyLjY4MTMgMTUgMTIuNDAxNUMxNC45OTk3IDEyLjEyMTYgMTQuOTIyNiAxMS44NDY3IDE0Ljc3NjIgMTEuNjA0M0w5LjQ0NDc2IDIuODAwOTNMOS40NDM3NiAyLjc5OTI1QzkuMjk4MTIgMi41NTY2NiA5LjA4ODE4IDIuMzU1MDQgOC44MzUwNSAyLjIxNDcyQzguNTgxMzUgMi4wNzQwNyA4LjI5MzI4IDIgOCAyWk04LjAwMzU1IDkuNjg4NjhDNy41MjA5OSA5LjY4ODY4IDcuMTI5OCA5LjMxNDcxIDcuMTI5OCA4Ljg1MzRWNi43MzgxMkM3LjEyOTggNi4yNzY4MSA3LjUyMDk5IDUuOTAyODQgOC4wMDM1NSA1LjkwMjg0QzguNDg2MTEgNS45MDI4NCA4Ljg3NzMgNi4yNzY4MSA4Ljg3NzMgNi43MzgxMlY4Ljg1MzRDOC44NzczIDkuMzE0NzEgOC40ODYxMSA5LjY4ODY4IDguMDAzNTUgOS42ODg2OFpNOC4wMDM1NSAxMi4wMjc0QzguNDg2MTEgMTIuMDI3NCA4Ljg3NzMgMTEuNjUzNCA4Ljg3NzMgMTEuMTkyMUM4Ljg3NzMgMTAuNzMwOCA4LjQ4NjExIDEwLjM1NjggOC4wMDM1NSAxMC4zNTY4SDcuOTk2NTdDNy41MTQwMiAxMC4zNTY4IDcuMTIyODMgMTAuNzMwOCA3LjEyMjgzIDExLjE5MjFDNy4xMjI4MyAxMS42NTM0IDcuNTE0MDIgMTIuMDI3NCA3Ljk5NjU3IDEyLjAyNzRIOC4wMDM1NVoiIGZpbGw9IiMwRDJFNEUiLz4KPC9zdmc+Cg==">`,
						],
					}),
					Ext.create("Terrasoft.HtmlControl", {
						htmlContent: Terrasoft.Resources.LoginPage.UnsupportedBrowserTitle,
					}),
				]
			});
			const unsupportedBrowserMessage = Ext.create("Terrasoft.Container", {
				classes: {
					wrapClassName: ['unsupported-browser__message']
				},
				items: [
					Ext.create("Terrasoft.HtmlControl", {
						htmlContent: Terrasoft.Resources.LoginPage.UnsupportedBrowserMessage,
					}),
				]
			});
			return Ext.create("Terrasoft.Container", {
				classes: {
					wrapClassName: ['unsupported-browser']
				},
				items:[unsupportedBrowserTitle, unsupportedBrowserMessage],
				visible: false,
			});
		},

		/**
		 * Checks supporting current browser.
		 * @return {Boolean} True if current browser is unsupported.
		 */
		checkIsBrowserUnsupported: function() {
			const unsupportedBrowserInfo = window.unsupportedBrowserInfo || {visible: true};
			if (unsupportedBrowserInfo.visible === false) {
				return false;
			}
			return Terrasoft.utils.UserAgent.isBrowserSupported() === false;
		}
	}
});
