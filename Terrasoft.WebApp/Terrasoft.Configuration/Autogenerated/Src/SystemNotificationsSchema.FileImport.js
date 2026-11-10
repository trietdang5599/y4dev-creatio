define("SystemNotificationsSchema", ["TagConstantsV2", "ModuleUtils", "FileImportServiceRequest",
		"css!SystemNotificationsSchemaCSS"], function(TagConstantsV2, ModuleUtils) {
	return {
		methods: {

			/**
			 * @inheritdoc Terrasoft.configuration.BaseNotificationSchema#onNotificationSubjectClick
			 * @overridden
			 */
			onNotificationSubjectClick: function() {
				var loaderName = this.get("LoaderName");
				if (loaderName !== "ImportSession") {
					this.callParent(arguments);
					return;
				}
				var importSessionId = this.get("SubjectId");
				var url = this.Terrasoft.combinePath(this.Terrasoft.workspaceBaseUrl, "Nui",
						"ViewModule.aspx?vm=FileImportWizard#FileImportModule/FileImportResultPage",
						importSessionId);
				window.open(url, "_blank");
			},

			/**
			 * On import notification link click handler.
			 */
			onImportNotificationLinkClick: function() {
				this.getImportData(this.get("SubjectId"), this.openSectionWithImportTags, this);
			},

			/**
			 * Gets import data.
			 * @private
			 * @param {String} importSessionId Session unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getImportData: function(importSessionId, callback, scope) {
				var config = {
					contractName: "GetImportSessionInfo",
					importSessionId: importSessionId
				};
				var request = this.createFileImportRequest(config);
				request.execute(function(response) {
					this.Ext.callback(callback, scope, [response]);
				}, this);
			},

			/**
			 * @inheritdoc Terrasoft.BaseNotificationsSchema#processNotificationsCollection
			 * @overridden
			 */
			processNotificationsCollection: function(notificationsCollection) {
				this.callParent(arguments);
				notificationsCollection.each(function(notification) {
					if (notification.get("LoaderName") === "ImportSession") {
						this.getImportData(notification.get("SubjectId"), function(response) {
							notification.set("ImportedRowsCount", response.importedRowsCount);
							notification.set("TotalRowsCount", response.totalRowsCount);
							notification.set("RootSchemaName", response.rootSchemaName);
							notification.set("HasLookupProcessingErrors", response.hasLookupProcessingErrors);
						}, this);
					}
				}, this);
			},

			/**
			 * On import notification log link click handler.
			 */
			onImportNotificationLogLinkClick: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: this.Terrasoft.combinePath("LookupSectionModule", "FileImportLookupSection", "ExcelImportLog")
				});
			},

			/**
			 * Returns true if import notification initialized.
			 * @return {Boolean}
			 */
			getIsImportNotificationInitialized: function() {
				return this.get("SubjectId") && this.getIsLoadedFromImport();
			},

			/**
			 * Returns log link visibility.
			 * @return {Boolean} Log link visibility.
			 */
			isImportLogLinkVisible: function() {
				if (!this.getIsImportNotificationInitialized()) {
					return false;
				}
				if (Terrasoft.Features.getIsDisabled("ShowImportLogLinkOnErrorOnly")) {
					return true;
				}
				var totalRowsCount = this.get("TotalRowsCount");
				var importedRowsCount = this.get("ImportedRowsCount");
				return (totalRowsCount !== importedRowsCount);
			},

			/**
			 * Returns data link visibility.
			 * @return {Boolean} Data link visibility.
			 */
			isImportDataLinkVisible: function() {
				var moduleStructure = ModuleUtils.getModuleStructureByName(this.get("RootSchemaName"));
				if (!this.getIsImportNotificationInitialized() || this.Ext.isEmpty(moduleStructure) ||
						this.Ext.isEmpty(moduleStructure.sectionSchema)) {
					return false;
				}
				var importedRowsCount = this.get("ImportedRowsCount");
				return (importedRowsCount > 0);
			},

			/**
			 * Creates file import request.
			 * @private
			 * @param {Object} config File import request config.
			 * @return {Terrasoft.FileImportServiceRequest} File import request.
			 */
			createFileImportRequest: function(config) {
				return this.Ext.create("Terrasoft.FileImportServiceRequest", config);
			},

			/**
			 * Opens section with import tags.
			 * @private
			 * @param {Object} importSessionInfo Import session info.
			 */
			openSectionWithImportTags: function(importSessionInfo) {
				var moduleStructure = ModuleUtils.getModuleStructureByName(importSessionInfo.rootSchemaName);
				var sectionSchema =  moduleStructure.sectionSchema;
				var sectionModule = moduleStructure.sectionModule;
				var storage = Terrasoft.configuration.Storage.Filters = Terrasoft.configuration.Storage.Filters || {};
				var sessionFilters = storage[sectionSchema] = storage[sectionSchema] || {};
				sessionFilters.TagFilters = [{ tags: importSessionInfo.importTags }];
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state ? Terrasoft.deepClone(historyState.state): {};
				state.moduleId = sectionModule + '_' + sectionSchema;
				state.moduleName = sectionModule;
   				state.schemaName = sectionSchema;
				this.sandbox.publish("PushHistoryState", {
					stateObj: state,
					hash: this.Terrasoft.combinePath(sectionModule, sectionSchema)
				});
			},

			/**
			 * Returns true if notification loaded from import session.
			 * @private
			 * @return {Boolean}
			 */
			getIsLoadedFromImport: function() {
				return this.get("LoaderName") === "ImportSession";
			},

			/**
			 * Returns true if notification doesn't load from import session.
			 * @private
			 * @return {Boolean}
			 */
			getIsNotLoadedFromImport: function() {
				return !this.getIsLoadedFromImport();
			}
		},
		diff: [
			{
				"operation": "merge",
				"name": "NotificationSubjectCaption",
				"values": {
					"visible": {"bindTo": "getIsNotLoadedFromImport"}
				}
			},
			{
				"operation": "insert",
				"name": "ImportNotificationCaption",
				"parentName": "NotificationItemBottomContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "getNotificationSubjectCaption"},
					"classes": {"labelClass": ["subject-text-labelClass", "import-message"]},
					"visible": {"bindTo": "getIsLoadedFromImport"}
				}
			},
			{
				"operation": "insert",
				"name": "ImportNotificationLogLink",
				"parentName": "NotificationItemBottomContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.ImportNotificationLogLinkCaption"},
					"visible": {"bindTo": "isImportLogLinkVisible"},
					"click": {"bindTo": "onImportNotificationLogLinkClick"},
					"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url", "import-message"]}
				}
			},
			{
				"operation": "insert",
				"name": "ImportNotificationLink",
				"parentName": "NotificationItemBottomContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.ImportNotificationLinkCaption"},
					"visible": {"bindTo": "isImportDataLinkVisible"},
					"click": {"bindTo": "onImportNotificationLinkClick"},
					"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url", "import-message"]}
				}
			}
		]
	};
});
