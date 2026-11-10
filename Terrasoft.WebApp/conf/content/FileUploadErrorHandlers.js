Terrasoft.configuration.Structures["FileUploadErrorHandlers"] = {innerHierarchyStack: ["FileUploadErrorHandlers"]};
define("FileUploadErrorHandlers", ["ext-base", "terrasoft", "FileUploadErrorHandlersResources", "RightUtilities",
	"CheckModuleDestroyMixin"],
	function(Ext, Terrasoft, resources, RightUtilities) {
		Ext.define("Terrasoft.configuration.mixins.FileUploadErrorHandlers", {
			alternateClassName: "Terrasoft.FileUploadErrorHandlers",

			mixins : {
				CheckModuleDestroyMixin: "Terrasoft.CheckModuleDestroyMixin"
			},

			initFileUploadErrorHadlers: function() {
				this.set("FilesUploadErrorLog", this.Ext.create("Terrasoft.Collection"));
				this.initCanManageSysSettings();
			},

			/**
			 * Initializes CanManageSysSettings rights attribute.
			 * @protected
			 */
			initCanManageSysSettings: function() {
				RightUtilities.checkCanExecuteOperation({
					operation: "CanManageSysSettings"
				}, this._onCanManageSysSettingsComplete, this);
			},

			/**
			 * Handler for message box ChangeSetting button.
			 * Navigates to setting page for changing max file size.
			 * @protected
			 */
			onChangeSettingValueHandler: function() {
				var resumeConfig = {
					method: this._navigateToChangeSettingPage,
					scope: this
				};
				if (this.canBeDestroyed(resumeConfig)) {
					this._navigateToChangeSettingPage();
				}
			},


			/**
			 * Shows message if errors occured during uploading.
			 * @private
			 * @param {Object} errorLog Contains files which were not uploaded.
			 */
			onCompleteError: function(errorLog) {
				var errorLog = this.get("FilesUploadErrorLog");
				if (!errorLog.getCount()) {
					return;
				}
				Terrasoft.each(errorLog, function(item) {
					if (!item.error) {
						item.error = item.message;
					}
				});
				const message = this.getFilesUploadErrorMessage(errorLog);
				const buttons = this._getShowErrorDialogButtons();
				this.showInformationDialog(message, Terrasoft.emptyFn, {
					buttons: buttons,
					handler: function(code) {
						if (code === "ChangeSettingValue") {
							this.onChangeSettingValueHandler();
						}
					}.bind(this)
				});
				errorLog.clear();
			},

			/**
			 * @private
			 */
			_getSettingsUrl: function() {
				return Terrasoft.combinePath("CardModuleV2",
						"SysSettingPage", "edit", "68e77c28-2ae0-df11-971b-001d60e938c6");
			},

			/**
			 * Gets files upload error message.
			 * @private
			 * @param {Object} errorLog Contains files which were not uploaded.
			 */
			getFilesUploadErrorMessage: function(errorLog) {
				const emptyLine = "\r\n\r\n";
				let filesListHeader = resources.localizableStrings.FileListHeader;
				const errorMessageTemplate = "{0}" + emptyLine + filesListHeader + ":\r\n{1}";
				const errorLogItems = errorLog.getItems().reverse();
				const groups = Terrasoft.groupBy(errorLogItems, "error");
				let errorMessage = "";
				Terrasoft.each(groups, function(items, groupMessage) {
					const names = this.getFormattedFilesNames(items);
					errorMessage += Ext.String.format(errorMessageTemplate, groupMessage, names);
					errorMessage += emptyLine;
				}, this);
				errorMessage += this._getOversizeErrorTipMessage();
				return errorMessage.slice(0, errorMessage.length - emptyLine.length);
			},

			/**
			 * @private
			 */
			_getIsOversizedErrorExist: function(filesErrorLog) {
				var errorLog = filesErrorLog || this.$FilesUploadErrorLog;
				return (errorLog && errorLog.any(function(error) {
					return error && error.isFileOversize;
				}, this)) || false;
			},

			/**
			 * @private
			 */
			_getOversizeErrorTipMessage: function(errorLog) {
				const isOversizeExist = this._getIsOversizedErrorExist(errorLog);
				const messageTemplate = "{0}\r\n\r\n";
				if (isOversizeExist) {
					return Ext.String.format(messageTemplate, resources.localizableStrings.ChangeFileSizeInfoMessage);
				} else {
					return Terrasoft.emptyString;
				}
			},

			/**
			 * Shows not valid files.
			 * @param {Number} maxFileSize Maximum upload file size in Mb from SysSetting.
			 * @param {Array} excludedFiles Array of files that wasn't uploaded.
			 */
			onFilesOversized: function(maxFileSize, excludedFiles) {
				const errorLog = this.get("FilesUploadErrorLog");
				const maxFileSizeExceededExceptionMessage = Ext.String.format(
						resources.localizableStrings.MaxFileSizeExceededExceptionMessage, maxFileSize);
				Terrasoft.each(excludedFiles, function(file) {
					errorLog.add({
						file: file,
						message: maxFileSizeExceededExceptionMessage,
						error: maxFileSizeExceededExceptionMessage,
						isFileOversize: true
					});
				}, this);
			},

			/**
			 * Gets formatted files' names string.
			 * @private
			 * @param {Array} items Files.
			 * @return {String} Formatted files' names string.
			 */
			getFormattedFilesNames: function(items) {
				const space = "\r\n";
				const names = items.map(function(item) {
					return ("- " + item.file.name);
				}).join(space);
				return names;
			},

			/**
			 * Adds file and error message into file upload log.
			 * @private
			 * @param {String} error Error message.
			 * @param {Object} file File.
			 */
			onFileCompleteError: function(error, file) {
				const errorLog = this.get("FilesUploadErrorLog");
				const defaultMessage = resources.localizableStrings.UploadFileError;
				errorLog.add({
					file: file,
					error: error,
					message: defaultMessage
				});
			},

			/**
			 * @private
			 */
			_navigateToChangeSettingPage: function() {
				const hash = this._getSettingsUrl();
				this.sandbox.publish("PushHistoryState", {hash: hash});
			},

			/**
			 * @private
			 */
			_getShowErrorDialogButtons: function() {
				const buttons = [];
				const isOversizeError = this._getIsOversizedErrorExist();
				if (isOversizeError && this.$CanManageSysSettings) {
					const changeSettingButton = Terrasoft.getBlueButtonConfig("ChangeSettingValue",
							resources.localizableStrings.ChangeSizeCaption);
					buttons.push(changeSettingButton, "cancel");
				} else {
					buttons.push("ok");
				}
				return buttons;
			},

			/**
			 * @private
			 */
			_onCanManageSysSettingsComplete: function(result) {
				this.set("CanManageSysSettings", result);
			},

		});
		return Terrasoft.FileUploadErrorHandlers;
	});


