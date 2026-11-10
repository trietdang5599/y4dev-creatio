Terrasoft.configuration.Structures["FileImportStartPage"] = {innerHierarchyStack: ["FileImportStartPage"], structureParent: "FileImportWizardStepPage"};
define('FileImportStartPageStructure', ['FileImportStartPageResources'], function(resources) {return {schemaUId:'374b0166-0e42-4d4b-acad-176fffce5bc9',schemaCaption: "FileImportStartPage", parentSchemaName: "FileImportWizardStepPage", packageName: "FileImport", schemaName:'FileImportStartPage',parentSchemaUId:'c28ed8d9-a852-43ed-ad8d-f594bb3a094f',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("FileImportStartPage", [
	"FileImportStartPageResources", "VwSysSchemaInWorkspace", "LookupUtilities",
	"AcademyUtilities", "RightUtilities", "ServiceHelper", "FileImportConstants", "ConfigurationFileApi", "FileImportServiceRequest",
	"FileImportMixin", "FileImportTemplateMixin"
], function(resources, VwSysSchemaInWorkspace, LookupUtilities, AcademyUtilities, RightUtilities, ServiceHelper) {
	return {
		attributes: {
			ImportSessionId: {
				dataValueType: Terrasoft.DataValueType.GUID
			},
			ImportObject: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				onChange: "_onImportObjectChange"
			},
			FileUploadWebServicePath: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: "FileImportService/SaveFile"
			},
			File: {dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT},
			SaveFileResult: {dataValueType: Terrasoft.DataValueType.BOOLEAN},
			ErrorMessage: {dataValueType: Terrasoft.DataValueType.TEXT},
			NextStepPageName: {
				value: "FileImportColumnsMappingPage"
			},

			/**
			 * Contains error link url.
			 */
			ErrorLinkHref: {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Is template selected
			 */
			IsTemplateInitialized: {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Selected template Id
			 */
			ImportTemplateId: {
				dataValueType: this.Terrasoft.DataValueType.GUID,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onImportTemplateIdChange"
			},

			/**
			 * Selected template name
			 */
			ImportTemplateName: {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Selected template schema UId
			 */
			ImportTemplateSchemaUId: {
				dataValueType: this.Terrasoft.DataValueType.GUID,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onImportTemplateSchemaUIdChange"
			},
			ChunkSize: {
				value: null
			}
		},
		mixins: {
			FileImportMixin: "Terrasoft.FileImportMixin",
			FileImportTemplateMixin: "Terrasoft.FileImportTemplateMixin"
		},
		methods: {

			//region Methods: Private

			/**
			 * Sets error message.
			 * @private
			 * @param {String} message Error message.
			 */
			setErrorMessage: function(message) {
				this.set("ErrorMessage", message);
			},

			/**
			 * Sets error link.
			 * @private
			 * @param {String} link Error link.
			 */
			setErrorLink: function(link) {
				if (this.Ext.isEmpty(link)) {
					return;
				}
				this.set("ErrorLinkCaption", link.caption);
				if (this.Ext.isEmpty(link.academyId)) {
					this.setErrorLinkHref(link.url);
				} else {
					var helpConfig = {
						callback: this.setErrorLinkHref,
						scope: this,
						contextHelpId: link.academyId
					};
					AcademyUtilities.getUrl(helpConfig);
				}
			},

			/**
			 * Clears error link.
			 * @private
			 */
			clearErrorLink: function() {
				this.set("ErrorLinkCaption", null);
			},

			/**
			 * Sets error link url.
			 * @private
			 * @param {String} url Error url.
			 */
			setErrorLinkHref: function(url) {
				this.set("ErrorLinkHref", url);
			},

			/**
			 * Gets import object query filters.
			 * @private
			 * @return {Terrasoft.data.filters.FilterGroup}
			 */
			createObjectMenuItemsFilters: function() {
				return this.mixins.FileImportMixin.getEntitySchemaFilters();
			},

			/**
			 * Returns file upload config.
			 * @private
			 * @param {Object} file File to upload.
			 * @param {Object} [importObject] Object for import.
			 * @param {Object} importObject.uId Import object UId.
			 * @param {String} importObject.name Import object name.
			 * @param {String} importObject.caption Import object caption.
			 * @param {Boolean} importObject.isOtherObject Indicates that is import object selected from lookup.
			 * @return {Object}
			 */
			getFileUploadConfig: function(file, importObject) {
				var data = {importSessionId: this.get("ImportSessionId")};
				if (importObject) {
					data.entitySchemaUId = importObject.uId;
					data.entitySchemaName = importObject.name;
					data.isOtherObject = importObject.isOtherObject;
				}
				if (this._canUploadByChunk()) {
					return this.getChunkedUploadConfig(file, data);
				}
				return {
					onComplete: this.onFileUploadEnd,
					data: data,
					columnName: "columnName",
					parentColumnName: "parentColumnName",
					parentColumnValue: "parentColumnValue",
					files: [file],
					uploadWebServicePath: this.get("FileUploadWebServicePath"),
					isChunkedUpload: false,
					scope: this
				};
			},

			/**
			 * Returns chunked file upload config.
			 * @private
			 */
			getChunkedUploadConfig: function (file, data) {
				data.fileId = this.$ImportSessionId;
				return {
					onComplete: this.onFileUploadEnd,
					entitySchemaName: "FileImportParameters",
					data: data,
					columnName: "FileData",
					parentColumnName: "Id",
					parentColumnValue: this.$ImportSessionId,
					files: [file],
					maxFileSizeSysSettingsName: "FileImportMaxFileSize",
					uploadWebServicePath: "FileImportUploadFileService/SaveFile",
					isChunkedUpload: true,
					chunkSize: this.$ChunkSize,
					scope: this
				};
			},

			/**
			 * Gets file import service request.
			 * @private
			 * @param {Object} requestConfig Request configuration.
			 * @return {Terrasoft.configuration.fileImport.FileImportServiceRequest}
			 */
			getFileImportServiceRequest: function(requestConfig) {
				return this.Ext.create(Terrasoft.configuration.fileImport.FileImportServiceRequest, requestConfig);
			},

			/**
			 * Initializes import session information.
			 * @private
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback execution scope.
			 */
			initImportSessionInfo: function(callback, scope) {
				var requestConfig = {
					contractName: "GetImportSessionInfo",
					importSessionId: this.get("ImportSessionId")
				};
				this.sendRequest(requestConfig, function(response) {
					var importObject = response.importObject;
					if (importObject) {
						this.set("ImportObject", importObject);
					}
					var fileName = response.fileName;
					if (fileName) {
						var file = {name: fileName};
						this.set("File", file);
						this.set("SaveFileResult", true);
					}
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * @private
			*/
			_initImportTemplate: function(callback, scope) {
				if (!this.isUseFileImportTemplate()) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				this.loadImportTemplateId(this.$ImportSessionId, function(importTemplateId) {
					this.$ImportTemplateId = importTemplateId;
					this._loadImportTemplateAdditionalData();
					this.$IsTemplateInitialized = true;
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			_initIsFreedomUI: function() {
				const isFreedomUI = !!Terrasoft.getQueryParameter(window.location.href, "isFreedomUI");
				this.set("IsFreedomUI", isFreedomUI);
			},

			/**
			 * Validates selected import object.
			 * @private
			 * @return {Boolean}
			 */
			validateImportObject: function() {
				var importObject = this.get("ImportObject");
				var isImportObjectValid = !this.Ext.isEmpty(importObject);
				if (!isImportObjectValid) {
					var message = this.get("Resources.Strings.EmptyImportObjectMessage");
					this.showInformationDialog(message);
				}
				return isImportObjectValid;
			},

			/**
			 * Validates file upload result.
			 * @private
			 * @return
			 */
			validateFile: function() {
				var saveFileResult = this.get("SaveFileResult");
				if (!saveFileResult) {
					var message = this.get("Resources.Strings.FileNotSelectedMessage");
					this.setErrorMessage(message);
				}
				return saveFileResult;
			},

			/**
			 * Validates file type.
			 * Checking file name is necessary until issues https://github.com/mailru/FileAPI/issues/351 and
			 * https://code.google.com/p/chromium/issues/detail?id=155455 are resolved.
			 * @private
			 * @param {Object} file Files to upload.
			 * @return {Boolean}
			 */
			validateFileType: function(file) {
				var validationResult = false;
				if (file) {
					var fileType = this.getFileType(file);
					if (fileType) {
						var excelMediaTypeRegExp = /application\/vnd\.openxmlformats-officedocument\.spreadsheetml/;
						validationResult = excelMediaTypeRegExp.test(fileType);
					} else {
						var fileName = file.name;
						var excelExtensionRegExp = /.xlsx$/;
						validationResult = excelExtensionRegExp.test(fileName);
					}
				}
				var message = (validationResult) ? "" : this.get("Resources.Strings.InvalidFileTypeMessage");
				this.setErrorMessage(message);
				return validationResult;
			},

			/**
			 * Initializes "drag" and "drop" events.
			 * @private
			 */
			initDropzoneEvents: function() {
				var dropzone = this.getDropzone();
				this.Terrasoft.ConfigurationFileApi.initDropzoneEvents(dropzone, this.onDropzoneHover.bind(this),
						this.onFilesSelected.bind(this));
			},

			/**
			 * Handles dropzone "dragenter" and "dragleave" events.
			 * @private
			 */
			onDropzoneHover: function(over, event) {
				var dropzone = this.getDropzone();
				if (over) {
					dropzone.classList.add("dropzone-hover");
				} else {
					dropzone.classList.remove("dropzone-hover");
					this.setFileType(event);
				}
			},

			/**
			 * Handles file upload error.
			 * @private
			 * @param {Object} errorInfo Error information.
			 */
			handleFileUploadError: function(errorInfo) {
				this.logRequestError(errorInfo, this.Terrasoft.LogMessageType.INFORMATION);
				var errorCode = errorInfo.errorCode;
				var errorMessage = errorInfo.message;
				var exception = this.Terrasoft.FileImportConstants.Exceptions[errorCode];
				if (exception) {
					errorMessage = exception.message;
					var errorLink = exception.link;
					this.setErrorLink(errorLink);
				}
				this.setErrorMessage(errorMessage);
			},

			/**
			 * Sets uploading file type.
			 * @private
			 * @param {MouseEvent} event Mouse event.
			 * @param {Object} event.dataTransfer Holds the data that is being dragged during a drag and drop.
			 */
			setFileType: function(event) {
				var dataTransfer = event.dataTransfer || event.originalEvent.dataTransfer;
				var file = dataTransfer.files[0];
				if (file) {
					var fileType = this.getFileType(file);
					this.set("FileType", fileType);
				}
			},

			/**
			 * Gets file type.
			 * @private
			 * @param {Object} file File to upload.
			 */
			getFileType: function(file) {
				return ((file && file.type) || this.get("FileType"));
			},

			/**
			 * Gets drop zone.
			 * @private
			 * @return {Element}
			 */
			getDropzone: function() {
				var element = this.Ext.get("DragAndDropContainer");
				return element.dom;
			},

			/**
			 * Initializes import object buttons.
			 * @private
			 * @param {Array|String} schemaNames Names of modules for loading.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback execution scope.
			 */
			initImportObjectButtons: function(schemaNames, callback, scope) {
				this.Terrasoft.require(schemaNames, function() {
					if (!arguments) {
						return;
					}
					var importButtons = this.get("ImportButtons") || [];
					this.Terrasoft.each(arguments, function(schema) {
						var name = schema.name;
						importButtons[name] = {
							caption: schema.caption,
							name: name,
							uId: schema.uId,
							isOtherObject: false
						};
						this.set("ImportButtons", importButtons);
					}, this);
					this.Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Handles import objects lookup result.
			 * @private
			 * @param {Object} result Result.
			 */
			onOtherImportObjectSelected: function(result) {
				var selectedRows = result.selectedRows;
				if (selectedRows.isEmpty()) {
					return;
				}
				var selectedRow = selectedRows.getByIndex(0);
				this.setImportObject({
					caption: selectedRow.Caption,
					isOtherObject: true,
					name: selectedRow.Name,
					uId: selectedRow.UId
				});
			},

			/**
			 * Handles select templates lookup result.
			 * @private
			 * @param {Object} result Result.
			 */
			_onImportTemplateSelected: function(result) {
				var selectedRows = result.selectedRows;
				if (selectedRows.isEmpty()) {
					return;
				}
				this._prepareSelectedImportTemplateData(selectedRows.getByIndex(0));
			},

			/**
			 * @private
			 */
			_prepareSelectedImportTemplateData: function(data) {
				this.$ImportTemplateId = data.Id;
				this._setImportTemplateAdditionalData(data.Name, data.EntitySchemaUId);
			},

			/**
			 * @private
			 */
			_onImportTemplateIdChange: function() {
				if (!this.$IsTemplateInitialized || this.getPrevious("ImportTemplateId") === this.$ImportTemplateId) {
					return;
				}
				this.saveImportTemplateId({
					"importTemplateId": this.$ImportTemplateId,
					"importSessionId": this.$ImportSessionId
				});
				if (!this._isImportTemplateSelected()) {
					this._clearImportTemplateAdditionalData();
				}
			},

			/**
			 * @private
			 */
			_onImportTemplateSchemaUIdChange: function() {
				if (!this.$IsTemplateInitialized || this.getPrevious("ImportTemplateSchemaUId") === this.$ImportTemplateSchemaUId) {
					return;
				}
				this._setImportObjectByEntityShemaUId(this.$ImportTemplateSchemaUId);
			},

			/**
			 * @private
			 */
			_clearImportTemplateAdditionalData: function() {
				this._setImportTemplateAdditionalData('', null);
			},

			/**
			 * @private
			 */
			_setImportTemplateAdditionalData: function(name, entitySchemaUId) {
				this.$ImportTemplateName = name;
				this.$ImportTemplateSchemaUId = entitySchemaUId;
			},

			/**
			 * @private
			 */
			_onImportObjectChange: function() {
				if (this.isUseFileImportTemplate()) {
					this._clearImportTemplateByImportObject();
				}
			},

			/**
			 * @private
			 */
			_clearImportTemplateByImportObject: function() {
				if (!this.$ImportObject || this.$ImportObject.uId !== this.$ImportTemplateSchemaUId) {
					this._unSelectImportTemplate();
				}
			},

			/**
			 * @private
			*/
			_loadImportTemplateAdditionalData: function() {
				if (!this._isImportTemplateSelected()) {
					return;
				}
				this.loadImportTemplateAdditionalData(this.$ImportTemplateId, function(name, entitySchemaUId) {
					this._setImportTemplateAdditionalData(name, entitySchemaUId);
				}, this);
			},

			/**
			 * @private
			*/
			_setImportObjectByEntityShemaUId: function(entitySchemaUId) {
				if (this.Ext.isEmpty(entitySchemaUId) || (this.$ImportObject && this.$ImportObject.uId === entitySchemaUId)) {
					return;
				}
				this.Terrasoft.EntitySchemaManager.getItemByUId(entitySchemaUId, function(entitySchemaItem) {
					this.setImportObject({
						caption: entitySchemaItem.caption,
						isOtherObject: true,
						name: entitySchemaItem.name,
						uId: entitySchemaItem.uId
					});
				}, this);
			},

			/**
			 * @private
			*/
			_unSelectImportTemplate: function() {
				this.$ImportTemplateId = null;
			},

			/**
			 * @private
			 */
			setFileInfo: function(callback, fileName) {
				var requestConfig = {
					contractName: "SetFileInfo",
					importSessionId: this.$ImportSessionId,
					fileName: fileName
				};
				var request = this.getFileImportServiceRequest(requestConfig);
				request.execute(callback, this);
			},

			/**
			 * Clears file selection.
			 * @private
			 */
			clearFileSelection: function(callback) {
				if (!this.$File) {
					Ext.callback(callback, this, [{success: true}]);
					return;
				}
				this.set("SaveFileResult", false);
				this.set("File", null);
				this.executeRequestToDeleteFile(callback);
			},

			executeRequestToDeleteFile: function (callback) {
				if (this._canUploadByChunk()) {
					this.callService({
						methodName: "DeleteFile",
						data: {importSessionId: this.$ImportSessionId},
						serviceName: "FileImportUploadFileService"
					}, function(deleteResponse) {
						Ext.callback(callback, this, [deleteResponse.DeleteFileResult]);
					}, this);
				} else {
					this.setFileInfo(callback);
				}
			},

			/**
			 * @private
			 */
			logFailedResponse: function(response) {
				if (!response.success) {
					this.logRequestError(response.errorInfo);
				}
			},

			/**
			 * @private
			 */
			_isImportTemplateSelected: function() {
				return this.Terrasoft.isGUID(this.$ImportTemplateId) && !this.Terrasoft.isEmptyGUID(this.$ImportTemplateId);
			},

			/**
			 * @private
			 */
			_applyImportTemplate: function(callback, scope) {
				this.callImportTemplateService({
					"methodName": "ApplyImportTemplate",
					"data": {"importSessionId": this.$ImportSessionId},
					"callback": function() {
						this.Ext.callback(callback, scope || this);
					},
					"scope": this
				});
			},

			/**
			 * @private
			 */
			_forceCleanAppliedImportId: function(callback, scope) {
				if (!this.isUseFileImportTemplate()) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				this.callImportTemplateService({
					"methodName": "ForceCleanAppliedImportTemplateId",
					"data": {"importSessionId": this.$ImportSessionId},
					"callback": function() {
						this.Ext.callback(callback, scope || this);
					},
					"scope": this
				});
			},

			//endregion

			//region Methods: Protected

			/**
			 * Gets default import object schema names.
			 * @protected
			 * @virtual
			 * @return {string[]}
			 */
			getDefaultImportObjectSchemaNames: function() {
				return ["Contact", "Account"];
			},

			/**
			 * @inheritdoc Terrasoft.FileImportWizardStepPage#applyImportSessionInfoParameters
			 * @protected
			 * @overridden
			 */
			applyImportSessionInfoParameters: this.Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.FileImportWizardStepPage#setImportSessionInfoParameters
			 * @protected
			 * @overridden
			 */
			setImportSessionInfoParameters: function(callback, scope) {
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepPage#getValidationResult
			 * @overridden
			 * @protected
			 */
			getValidationResult: function() {
				var validationResult = true;
				validationResult = validationResult && this.validateFile();
				validationResult = validationResult && this.validateImportObject();
				return validationResult;
			},

			/**
			 * Initializes import object from history state info.
			 * Requires entity schema, if it is exists.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution context.
			 */
			initImportEntity: function(callback, scope) {
				const historyStateInfo = this.getStateInfo();
				const entityName = historyStateInfo.operation;
				if (this.isNotEmpty(entityName)) {
					Terrasoft.require([entityName], function(entitySchema) {
						if (this.isNotEmpty(entitySchema)) {
							const isOtherObject = this.$IsFreedomUI
								|| !Terrasoft.contains(this.getDefaultImportObjectSchemaNames(), entityName);
							const importObjectCfg = {
								uId: entitySchema.uId,
								caption: entitySchema.caption,
								name: entitySchema.name,
								isOtherObject: isOtherObject
							};
							this.setImportObject(importObjectCfg);
						}
						Ext.callback(callback, scope || this);
					}, this);
				} else {
					Ext.callback(callback, scope || this);
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * Uploads file.
			 * @param {Object} file File for import.
			 * @param {Object} importObject Object for import.
			 * @param {Object} importObject.uId Import object UId.
			 * @param {String} importObject.name Import object name.
			 * @param {String} importObject.caption Import object caption.
			 * @param {Boolean} importObject.isOtherObject Indicates that is import object selected from lookup.
			 */
			upload: function(file, importObject) {
				this.showBodyMask();
				var config = this.getFileUploadConfig(file, importObject);
				this.Terrasoft.ConfigurationFileApi.upload(config);
			},

			/**
			 * Sets the import object.
			 * @param {Object} importObject Object for import.
			 * @param {Object} importObject.uId Import object UId.
			 * @param {String} importObject.name Import object name.
			 * @param {String} importObject.caption Import object caption.
			 * @param {Boolean} importObject.isOtherObject Indicates that import object is selected from lookup.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			setImportObject: function(importObject, callback, scope) {
				if (!importObject) {
					return;
				}
				var currentImportObject = this.get("ImportObject");
				if (importObject === currentImportObject) {
					return;
				}
				this.showBodyMask();
				RightUtilities.getSchemaEditRights({
					schemaName: importObject.name
				}, function(result) {
					if (Ext.isEmpty(result)) {
						this.set("ImportObject", importObject);
						var requestConfig = {
							contractName: "SetImportObject",
							importSessionId: this.get("ImportSessionId"),
							importObject: importObject
						};
						var request = this.getFileImportServiceRequest(requestConfig);
						request.execute(function(response) {
							this.hideBodyMask();
							this.logFailedResponse(response);
							this._forceCleanAppliedImportId();
							Ext.callback(callback, scope);
						}, this);
					} else {
						this.hideBodyMask();
						var message = Ext.String.format(this.get("Resources.Strings.InvalidObjectRights"),
								importObject.caption);
						this.showInformationDialog(message);
						Ext.callback(callback, scope);
					}
				}, this);
			},

			/**
			 * Opens import objects lookup.
			 */
			onSelectCustomImportObjectButtonClick: function() {
				var filters = this.createObjectMenuItemsFilters();
				var config = {
					entitySchemaName: "VwSysSchemaInWorkspace",
					filters: filters,
					columns: ["UId", "Name", "Caption"],
					multiSelect: false,
					actionsButtonVisible: false
				};
				LookupUtilities.Open(this.sandbox, config, this.onOtherImportObjectSelected, this, null, false, false);
			},

			/**
			 * Opens import templates lookup.
			 */
			onSelectTemplateButtonClick: function() {
				var config = {
					entitySchemaName: "FileImportTemplate",
					columns: ["Id", "Name", "EntitySchemaUId"],
					multiSelect: false,
					actionsButtonVisible: false
				};
				this.openLookup(config, this._onImportTemplateSelected, this);
			},

			/**
			 * Handles import object button click.
			 */
			onSelectImportObjectButtonClick: function() {
				var tag = arguments[0] || arguments[3];
				var importButtons = this.get("ImportButtons") || [];
				var importObject = importButtons[tag];
				this.setImportObject(importObject);
			},

			/**
			 * Starts file upload.
			 * @param {Array} files Files to upload.
			 */
			onFilesSelected: function(files) {
				this.clearFileSelection(function(response) {
					if (!response.success) {
						this.logFailedResponse(response);
						return;
					}
					this.clearErrorLink();
					var file = files[0];
					if (!this.validateFileType(file)) {
						return;
					}
					var importObject = this.get("ImportObject");
					this.upload(file, importObject);
					this._forceCleanAppliedImportId();
				});
			},

			/**
			 * Processes file upload results.
			 * @param {Boolean|String} error False, if there is no error, else error message.
			 * @param {Object} xhr Request.
			 */
			onFileUploadEnd: function(error, xhr) {
				if (error) {
					this.setErrorMessage(error);
					throw new Terrasoft.UnknownException({message: error});
				}
				var response = this.Terrasoft.decode(xhr.responseText);
				var result = response.SaveFileResult;
				var saveFileResult = result.success;
				if (!saveFileResult) {
					this.onRequestLoadFileError(result.errorInfo);
					return;
				}
				var file = xhr.files[0];
				this.set("File", file);
				this.checkIsLoadedFileValid(this.onValidateLoadedFile);
			},

			/**
			 * @private
			 */
			onRequestLoadFileError: function (errorInfo) {
				this.hideBodyMask();
				this.handleFileUploadError(errorInfo);
				this.clearFileSelection(this.logFailedResponse);
			},

			/**
			 * @private
			 */
			onValidateLoadedFile: function(validateFileResponse) {
				var validateResult = validateFileResponse.CheckIsFileValidResult;
				if (!validateResult.success) {
					this.onRequestLoadFileError(validateResult.errorInfo);
				} else {
					this.setFileInfo(function(setFileInfoResponse) {
						if (!setFileInfoResponse.success) {
							this.onRequestLoadFileError(setFileInfoResponse.errorInfo);
						} else {
							this.hideBodyMask();
							this.set("SaveFileResult", true);
						}
					}, this.getFileName());
				}
			},

			/**
			 * @private
			 */
			_canUploadByChunk: function() {
				return Terrasoft.Features.getIsEnabled("UploadLargeFileByChunk") && Terrasoft.Features.getIsEnabled("UsePersistentFileImport");
			},

			/**
			 * @private
			 */
			checkIsLoadedFileValid: function(callback) {
				if (this._canUploadByChunk()) {
					this.callService({
						methodName: "CheckIsFileValid",
						data: {
							importSessionId: this.$ImportSessionId
						},
						serviceName: "FileImportUploadFileService"
					}, callback, this);
				} else {
					Ext.callback(callback, this, [{CheckIsFileValidResult: {success: true}}]);
				}
			},

			/**
			 * Gets import template name loading state.
			 * @return {Boolean}
			 */
			isImportTemplateNameLoaded: function() {
				return this._isImportTemplateSelected() && !this.Ext.isEmpty(this.$ImportTemplateName);
			},

			/**
			 * Deletes file.
			 */
			onFileDeleteButtonClick: function() {
				this.clearFileSelection(this.logFailedResponse);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepPage#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.showBodyMask();
				this.callParent([
					function() {
						this.Terrasoft.chain(
							function(next) {
								this._initIsFreedomUI();
								this.Terrasoft.EntitySchemaManager.initialize(next, this);
							},
							this.initImportEntity,
							this.initImportSessionInfo,
							this._initImportTemplate,
							function(next) {
								var defaultImportObjectSchemaNames = this.getDefaultImportObjectSchemaNames();
								this.initImportObjectButtons(defaultImportObjectSchemaNames, next, this);
							},
							function(next) {
								if (Terrasoft.Features.getIsEnabled("UseDefaultFileChunkSizeForFileImport")) {
									next();
									return;
								}
								Terrasoft.SysSettings.querySysSettingsItem("FileImportUploadingFileChunkSize", (value) => {
									if (value > 0) {
										this.$ChunkSize = value * FileAPI.MB;
									}
									next();
								});
							},
							function() {
								this.hideBodyMask();
								callback.call(scope);
							},
							this);
					}, this
				]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepPage#saveStep
			 * @overridden
			 */
			saveStep: function(wizardInfo) {
				var parentMethod = this.getParentMethod();
				if (this.isUseFileImportTemplate()) {
					this._applyImportTemplate(function() {
						parentMethod.call(this, [wizardInfo]);
					}, this);
				} else {
					parentMethod.call(this, [wizardInfo]);
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				this.initDropzoneEvents();
			},

			/**
			 * Gets import object button pressed state.
			 * @param {String} tag Element tag.
			 * @return {Boolean}
			 */
			getImportObjectButtonPressed: function(tag) {
				var importObject = this.get("ImportObject");
				if (!importObject) {
					return false;
				}
				var isOtherObject = importObject.isOtherObject;
				return ((!isOtherObject && tag === importObject.name) ||
						(isOtherObject && tag === "OtherObject"));
			},

			/**
			 * Gets import object button image.
			 * @param {String} tag Element tag.
			 * @return {String}
			 */
			getImportObjectButtonImage: function(tag) {
				var pressed = this.getImportObjectButtonPressed(tag);
				var localizableImages = resources.localizableImages;
				var localizableImageName = tag + "Image" + (pressed ? "Selected" : "");
				return localizableImages[localizableImageName];
			},

			/**
			 * Gets other object button caption.
			 * @return {String}
			 */
			getOtherObjectButtonCaption: function() {
				const importObject = this.get("ImportObject");
				const emptyObjectCaption = this.$IsFreedomUI
					? this.get("Resources.Strings.SelectEntityCaption")
					: this.get("Resources.Strings.OtherObjectCaption");
				return importObject?.isOtherObject ? importObject.caption : emptyObjectCaption;
			},

			/**
			 * Gets empty file container visibility.
			 * @return {Boolean}
			 */
			getEmptyFileContainerVisibility: function() {
				return !this.get("SaveFileResult");
			},

			/**
			 * Gets error file container visibility.
			 * @return {Boolean}
			 */
			getErrorFileContainerVisibility: function() {
				var message = this.get("ErrorMessage");
				return !this.Ext.isEmpty(message);
			},

			/**
			 * Gets empty file container visibility.
			 * @return {Boolean}
			 */
			getUploadFileContainerVisibility: function() {
				return (!this.getErrorFileContainerVisibility() && this.getEmptyFileContainerVisibility());
			},

			/**
			 * Gets file name.
			 * @return {String}
			 */
			getFileName: function() {
				var file = this.get("File");
				return (file && file.name);
			},

			/**
			 * Gets empty dropzone image.
			 * @return {String}
			 */
			getEmptyFileImage: function() {
				var image = this.get("Resources.Images.EmptyFileImage");
				return Terrasoft.ImageUrlBuilder.getUrl(image);
			},

			/**
			 * Gets broken file image.
			 * @return {String}
			 */
			getErrorFileImage: function() {
				var image = this.get("Resources.Images.ErrorFileImage");
				return Terrasoft.ImageUrlBuilder.getUrl(image);
			},

			/**
			 * Gets excel file image.
			 * @return {String}
			 */
			getExcelFileImage: function() {
				var image = this.get("Resources.Images.ExcelFileImage");
				return Terrasoft.ImageUrlBuilder.getUrl(image);
			}

			//endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "HeaderContainer"
			},
			{
				"operation": "insert",
				"name": "DragAndDropContainer",
				"parentName": "CenterContainer",
				"propertyName": "items",
				"values": {
					"id": "DragAndDropContainer",
					"selectors": {
						"wrapEl": "#DragAndDropContainer"
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["dropzone"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "DragAndDropContainer",
				"name": "EmptyFileContainer",
				"propertyName": "items",
				"values": {
					"id": "EmptyFileContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["flex-vertical-center"],
					"items": [],
					"visible": {"bindTo": "getEmptyFileContainerVisibility"}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmptyFileContainer",
				"name": "UploadFileContainer",
				"propertyName": "items",
				"values": {
					"id": "UploadFileContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["flex-vertical-center"],
					"items": [],
					"visible": {"bindTo": "getUploadFileContainerVisibility"}
				}
			},
			{
				"operation": "insert",
				"parentName": "UploadFileContainer",
				"name": "EmptyFileImage",
				"propertyName": "items",
				"values": {
					"readonly": true,
					"getSrcMethod": "getEmptyFileImage",
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
					"classes": {
						"wrapClass": ["empty-file-image-wrapper"]
					},
					"markerValue": "EmptyFileImage"
				}
			},
			{
				"operation": "insert",
				"parentName": "UploadFileContainer",
				"name": "EmptyFileCaption",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.DragAndDropContainerCaption"},
					"classes": {
						"wrapClassName": ["upload-caption"],
						"labelClass": ["upload-caption"]
					},
					"markerValue": "EmptyFileCaption"
				}
			},
			{
				"operation": "insert",
				"parentName": "EmptyFileContainer",
				"name": "ErrorFileContainer",
				"propertyName": "items",
				"values": {
					"id": "ErrorFileContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["flex-vertical-center"],
					"items": [],
					"visible": {"bindTo": "getErrorFileContainerVisibility"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ErrorFileContainer",
				"name": "ErrorFileImage",
				"propertyName": "items",
				"values": {
					"readonly": true,
					"defaultImage": Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.ErrorFileImage),
					"getSrcMethod": "getErrorFileImage",
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
					"classes": {
						"wrapClass": ["empty-file-image-wrapper"]
					},
					"markerValue": "ErrorFileImage"
				}
			},
			{
				"operation": "insert",
				"parentName": "ErrorFileContainer",
				"name": "ErrorFileCaption",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "ErrorMessage"},
					"classes": {
						"wrapClassName": ["error-caption"],
						"labelClass": ["error-caption"]
					},
					"markerValue": "ErrorFileCaption"
				}
			},
			{
				"operation": "insert",
				"parentName": "ErrorFileContainer",
				"name": "ErrorFileCaptionLink",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.HYPERLINK,
					"href": {"bindTo": "ErrorLinkHref"},
					"caption": {"bindTo": "ErrorLinkCaption"},
					"classes": {"hyperlinkClass": ["error-link-caption"]},
					"markerValue": "ErrorFileCaptionLink"
				}
			},
			{
				"operation": "insert",
				"parentName": "EmptyFileContainer",
				"name": "UploadFileButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "Resources.Strings.UploadFileButtonCaption"},
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": ["upload-button"],
						"wrapperClass": ["upload-button"]
					},
					"fileTypeFilter": ["application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"],
					"fileUpload": true,
					"filesSelected": {"bindTo": "onFilesSelected"},
					"fileUploadMultiSelect": false,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"markerValue": "UploadFileButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "DragAndDropContainer",
				"name": "ExcelFileContainer",
				"propertyName": "items",
				"values": {
					"id": "ExcelFileContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["flex-vertical-center"],
					"items": [],
					"visible": {"bindTo": "SaveFileResult"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ExcelFileContainer",
				"name": "ExcelFileCaption",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.ExcelFileCaption"},
					"classes": {
						"wrapClassName": ["excel-file-caption"],
						"labelClass": ["excel-file-caption"]
					},
					"markerValue": "ExcelFileCaption"
				}
			},
			{
				"operation": "insert",
				"parentName": "ExcelFileContainer",
				"name": "ExcelFileImage",
				"propertyName": "items",
				"values": {
					"readonly": true,
					"defaultImage": Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.ExcelFileImage),
					"getSrcMethod": "getExcelFileImage",
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
					"classes": {
						"wrapClass": ["excel-file-image-wrapper"]
					},
					"markerValue": "ExcelFileImage"
				}
			},
			{
				"operation": "insert",
				"parentName": "ExcelFileContainer",
				"name": "ExcelFileNameContainer",
				"propertyName": "items",
				"values": {
					"id": "ExcelFileNameContainer",
					"selectors": {
						"wrapEl": "#ExcelFileNameContainer"
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["excel-file-name-wrapper"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ExcelFileNameContainer",
				"name": "ExcelFileName",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getFileName"},
					"classes": {
						"wrapperClass": ["excel-file-name-wrapper"],
						"textClass": ["excel-file-name-caption"]
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"markerValue": "ExcelFileName"
				}
			},
			{
				"operation": "insert",
				"parentName": "ExcelFileNameContainer",
				"name": "ExcelFileDeleteButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": "",
					"click": {"bindTo": "onFileDeleteButtonClick"},
					"classes": {
						"wrapperClass": ["excel-file-delete-button-wrapper"]
					},
					"imageConfig": resources.localizableImages.ExcelFileDeleteImage,
					"iconAlign": Terrasoft.controls.ButtonEnums.iconAlign.RIGHT,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"markerValue": "ExcelFileDeleteButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "CenterContainer",
				"name": "ImportTemplateSelectorContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["import-template-selector-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportTemplateSelectorContainer",
				"name": "SelectImportObjectLabel",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.SelectImportObject"},
					"markerValue": "SelectImportObjectLabel",
					"classes": {
						"labelClass": ["import-template-selector-label"]
					},
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportTemplateSelectorContainer",
				"name": "SelectTemplateButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "Resources.Strings.SelectTemplateLabel"},
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": ["upload-template-button"],
						"wrapperClass": ["upload-template-button"]
					},
					"click": {"bindTo": "onSelectTemplateButtonClick"},
					"visible": {"bindTo": "isUseFileImportTemplate"},
					"markerValue": "SelectTemplateButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "CenterContainer",
				"name": "ImportObjectContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["import-object-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportObjectContainer",
				"name": "ImportObjectButtonsContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["import-object-buttons-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportObjectButtonsContainer",
				"name": "SelectContactButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "Resources.Strings.ContactCaption"},
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["import-object-button"],
						"imageClass": ["import-object-button-image"]
					},
					"visible": {
						"bindTo": "IsFreedomUI",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"click": {"bindTo": "onSelectImportObjectButtonClick"},
					"pressed": {"bindTo": "getImportObjectButtonPressed"},
					"imageConfig": {"bindTo": "getImportObjectButtonImage"},
					"tag": "Contact",
					"markerValue": "SelectContactButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportObjectButtonsContainer",
				"name": "SelectAccountButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "Resources.Strings.AccountCaption"},
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["import-object-button"],
						"imageClass": ["import-object-button-image"]
					},
					"visible": {
						"bindTo": "IsFreedomUI",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"click": {"bindTo": "onSelectImportObjectButtonClick"},
					"pressed": {"bindTo": "getImportObjectButtonPressed"},
					"imageConfig": {"bindTo": "getImportObjectButtonImage"},
					"tag": "Account",
					"markerValue": "SelectAccountButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportObjectButtonsContainer",
				"name": "SelectImportObjectButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "getOtherObjectButtonCaption"},
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["import-object-button"],
						"imageClass": ["import-object-button-image"]
					},
					"click": {"bindTo": "onSelectCustomImportObjectButtonClick"},
					"pressed": {"bindTo": "getImportObjectButtonPressed"},
					"imageConfig": {"bindTo": "getImportObjectButtonImage"},
					"tag": "OtherObject",
					"markerValue": "SelectOtherObjectButton"
				}
			},
			{
				"operation": "insert",
				"parentName": "CenterContainer",
				"name": "SelectedTemplateContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["import-template-inform-wrap"],
					"items": [],
					"visible": {"bindTo": "isImportTemplateNameLoaded"}
				}
			},
			{
				"operation": "insert",
				"parentName": "SelectedTemplateContainer",
				"name": "SelectedTemplateLabel",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.SelectedTemplateLabel"},
					"markerValue": "SelectedTemplateLabel",
					"classes": {
						"labelClass": ["import-template-inform-label"]
					},
				}
			},
			{
				"operation": "insert",
				"parentName": "SelectedTemplateContainer",
				"name": "ImportTemplateName",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "ImportTemplateName"},
					"markerValue": "ImportTemplateName",
					"classes": {
						"labelClass": ["import-template-inform-name"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SelectedTemplateContainer",
				"name": "UnSelectInportTemplateButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": "",
					"click": {"bindTo": "_unSelectImportTemplate"},
					"classes": {
						"wrapperClass": ["import-template-inform-unselect-button"]
					},
					"imageConfig": resources.localizableImages.ExcelFileDeleteImage,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"markerValue": "UnSelectInportTemplateButton"
				}
			}
		]
	};
});


