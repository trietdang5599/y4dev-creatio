define("FileDownloader", ["FileDownloaderResources"], function(resources) {
	/**
	 * @class Terrasoft.configuration.FileDownloader
	 * Manages downloading and creating a file path.
	 */
	Ext.define("Terrasoft.configuration.FileDownloader", {
		alternateClassName: "Terrasoft.FileDownloader",

		statics: {
            /**
             * Generates configuration for file download.
             * @param {String} fileUrl - URL of the file to download.
             * @param {String} fileName - Name to save the file as.
             * @returns {Object} Configuration object for file download.
             * @private
             */
            _getDownloadConfig: function(fileUrl, fileName) {
                return {
                    fileUrl: fileUrl,
                    success: this._handleFileDownloadSuccess.bind(this, fileName),
                    failure: this._handleFileDownloadFailure.bind(this, fileName),
                    scope: this,
                    includeStatusInFailureCallback: true
                };
            },

            /**
             * Handles successful file download.
             * @param {String} fileName - Name to save the file as.
             * @param {Blob|ArrayBuffer} fileContent - Content of the downloaded file.
             * @private
             */
            _handleFileDownloadSuccess: function(fileName, fileContent) {
                const downloadLink = document.createElement("a");
                const blob = new Blob([fileContent], { type: "application/octet-stream" });
                const url = URL.createObjectURL(blob);
                downloadLink.href = url;
                downloadLink.download = fileName;
                downloadLink.click();
                window.setTimeout(() => {
                    URL.revokeObjectURL(url);
                }, 100);
            },

            /**
             * Handles file download failures by displaying appropriate error messages.
             * @param {String} fileName - Name of the file that failed to download.
             * @private
             */
            _handleFileDownloadFailure: function(fileName, response, status) {
                const message = status === 422 ? resources.localizableStrings.FileMismatchErrorMessage
                    : resources.localizableStrings.FileDownloadErrorMessage;
                Terrasoft.showInformation(Ext.String.format(message, fileName),
					null, null, { buttons: [Terrasoft.MessageBoxButtons.CLOSE] });
            },

			/**
			 * Gets download file link.
			 * @protected
			 * @param {String} entitySchemaUid Uid of the entity schema the download file.
			 * @param {String} fileId Id of the need download file.
			 * @return {String} Full download file link url.
			 */
			getFileLink: function(entitySchemaUid, fileId) {
				var urlPattern = "{0}/rest/FileService/GetFile/{1}/{2}";
				var workspaceBaseUrl = Terrasoft.utils.uri.getConfigurationWebServiceBaseUrl();
				var url = Ext.String.format(urlPattern, workspaceBaseUrl, entitySchemaUid, fileId);
				return url;
			},

			/**
			 * Downloads file from server by file url.
			 * @param {Object} config Config object.
			 * @param {String} config.fileUrl Url of the need download file.
			 * @param {Function} config.success Success callback function.
			 * @param {Uint8Array} config.success.fileContent File content.
			 * @param {Function} config.failure Error callback function.
			 * @param {Object} config.scope Scope of the callback function.
			 * @param {boolean} config.includeStatusInFailureCallback Need to include the HTTP status code as an
			 * argument in the failure callback.
			 */
			downloadFile: function(config) {
				var xhr = new XMLHttpRequest();
				xhr.open("GET", config.fileUrl);
				xhr.responseType = "arraybuffer";
				xhr.onload = function() {
					if (this.status === 200) {
						var uint8array = new Uint8Array(this.response);
						Ext.callback(config.success, config.scope, [uint8array]);
						return;
					}
					const args = [this.response];
					if (config.includeStatusInFailureCallback) {
						args.push(this.status);
					}
					Ext.callback(config.failure, config.scope, args);
				};
				xhr.send();
			},

			/**
			 * Downloads a file with error handling.
			 * @param {String} entitySchemaUid - Unique identifier of the entity schema.
			 * @param {String} fileId - Unique identifier of the file.
			 * @param {String} fileName - Name to save the file as.
			 * @param {String} [fileUrl] - Optional URL of the file to download.
			 */
			downloadFileWithErrorHandling: function(entitySchemaUid, fileId, fileName, fileUrl) {
				fileUrl = fileUrl || Terrasoft.FileDownloader.getFileLink(entitySchemaUid, fileId);
				const downloadConfig = this._getDownloadConfig(fileUrl, fileName);
				this.downloadFile(downloadConfig);
			}
		}
	});
	return {};
});
