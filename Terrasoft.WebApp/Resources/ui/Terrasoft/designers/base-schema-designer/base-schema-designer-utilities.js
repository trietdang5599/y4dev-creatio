/**
 */
Ext.define("Terrasoft.Designers.BaseSchemaDesignerUtilities", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.BaseSchemaDesignerUtilities",
	singleton: true,

	//region Constants: Public

	/**
	 * Schema export metadata url template.
	 * @type {String}
	 */
	EXPORT_SCHEMA_METADATA_URL_TEMPLATE: "/ServiceModel/SchemaManagerService.svc/Export?managerName={0}&schemaUId={1}",

	/**
	 * Schema metadata url template.
	 * @type {String}
	 */
	SCHEMA_METADATA_URL_TEMPLATE: "/ClientApp/#/SchemaMetaDataDesigner/{0}/{1}/{2}",

	/**
	 * Old UI window open params template.
	 * @type {String}
	 */
	WINDOW_PARAMS_TEMPLATE: "resizable,width={0},height={1},left={2},top={3}",

	/**
	 * Schema source code url template.
	 * @type {String}
	 */
	SCHEMA_SOURCECODE_URL_TEMPLATE: "/ClientApp/#/SourceCodeSchemaDesigner/{0}?showMetaItemSourceCode=true",

	/**
	 * Compilation errors url.
	 * @type {String}
	 */
	COMPILATION_ERRORS_URL: "/CompilationErrors.aspx",

	//endregion

	//region Fields: Private

	/**
	 * @private
	 */
	_classNameToWorkspaceItemTypeMap: {
		"Terrasoft.manager.ClientUnitSchema": Terrasoft.WorkspaceItemType.ClientUnitSchema,
		"Terrasoft.manager.ProcessSchema": Terrasoft.WorkspaceItemType.ProcessSchema,
		"Terrasoft.Designers.DcmSchema": Terrasoft.WorkspaceItemType.DcmSchema,
		"Terrasoft.manager.CampaignSchema": Terrasoft.WorkspaceItemType.CampaignSchema,
	},

	//endregion

	//region Methods: Private

	/**
	 * Returns schema source code file name.
	 * @private
	 * @param {String} schemaName Schema name.
	 * @param {String} packageName Schema package name.
	 * @return {String} Source code file name.
	 */
	getSourceCodeFileName: function(schemaName, packageName) {
		return schemaName + "." + packageName + ".cs";
	},

	/**
	 * Initializes WebSocket channel.
	 * @private
	 */
	initWebSocket: function() {
		var channel = Terrasoft.ServerChannel;
		var connectionState = channel.getConnectionState();
		if (connectionState === Terrasoft.SocketConnectionState.CLOSED) {
			channel.reconnectCount = 0;
			channel.init();
		}
	},

	/**
	 * @private
	 */
	_handlePublishResponse: function(result) {
		if (!Ext.isEmpty(result) && result.success) {
			Terrasoft.showInformation(result.message);
		} else {
			Terrasoft.showErrorMessage(result.message);
			this.warning(result.message);
		}
	},

	/**
	 * Opens old user interface resizable blank window.
	 * @param {String} url URL.
	 * @private
	 */
	openOldUIBlankWindow: function(url) {
		var width = 810;
		var height = 600;
		var left = screen.availLeft + (screen.availWidth - width) / 2;
		var top = screen.availTop + (screen.availHeight - height) / 2;
		var windowParams = Ext.String.format(this.WINDOW_PARAMS_TEMPLATE,
			width, height, left, top);
		window.open(url, "_blank", windowParams);
	},

	/**
	 * Opens url in new tab.
	 * @param {String} url URL.
	 * @private
	 */
	_openNewTab: function(url) {
		window.open(url, "_blank");
	},

	/**
	 * @private
	 */
	_obsoleteGetRunningProcessCountBySysSchemaUId: function(schemaUId, callback, scope) {
		const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
			rootSchemaName: "SysProcessData"
		});
		esq.addAggregationSchemaColumn("Id", Terrasoft.AggregationType.COUNT, "Count");
		let filter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
			"[VwSysSchemaInWorkspace:Id:SysSchemaId].UId", schemaUId);
		esq.filters.addItem(filter);
		filter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
			"[VwSysSchemaInWorkspace:Id:SysSchemaId].SysWorkspace.Id", Terrasoft.SysValue.CURRENT_WORKSPACE.value);
		esq.filters.addItem(filter);
		esq.getEntityCollection(function(response) {
			if (response.success) {
				const collection = response.collection;
				let result = collection.first();
				result = result.get("Count");
				callback.call(scope, result);
			} else {
				const errorInfo = response.errorInfo;
				callback.call(scope, null, errorInfo.message);
			}
		}, scope);
	},

	/**
	 * @private
	 */
	_removeBodyElementByTag: function(tagName) {
		Ext.getBody().query(tagName)[0]?.remove();
	},

	/**
	 * @private
	 */
	_getNewErrorListDialogProxyElement: function () {
		const tagName = "ts-error-list-dialog-proxy";
		this._removeBodyElementByTag(tagName);
		return document.createElement(tagName);
	},

	/**
	 * @private
	 */
	_loadSysPackage: function (packageUId, callback, scope) {
		Terrasoft.AjaxProvider.request({
			url: Terrasoft.workspaceBaseUrl + '/ServiceModel/PackageService.svc/GetPackageProperties',
			method: "POST",
			headers: {
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			params: Terrasoft.encode(packageUId),
			callback: function (request, success, response) {
				var responseObject = Terrasoft.decode(response.responseText);
				if (responseObject.success) {
					var packageData = responseObject.package;
					var packageViewModel = Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: packageData.id,
							UId: packageData.uId,
							Name: packageData.name,
							Maintainer: packageData.maintainer,
							InstallType: packageData.installType,
						}
					});
					callback.call(scope, packageViewModel);
				} else {
					callback.call(scope, null, responseObject.errorInfo.message);
				}
			},
			scope: this
		});
	},

	/**
	 * @private
	 */
	_loadSysPackageByESQ: function (packageUId, callback, scope) {
		var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
			rootSchemaName: "SysPackage",
			clientESQCacheParameters: {
				cacheItemName: packageUId + "-SysPackageName"
			}
		});
		esq.addColumn("Id");
		esq.addColumn("UId");
		esq.addColumn("Name");
		esq.addColumn("Maintainer");
		esq.addColumn("InstallType");
		esq.filters.add("UId", Terrasoft.createColumnFilterWithParameter(
			Terrasoft.ComparisonType.EQUAL, "UId", packageUId));
		esq.filters.add("SysWorkspace", Terrasoft.createColumnFilterWithParameter(
			Terrasoft.ComparisonType.EQUAL, "SysWorkspace", Terrasoft.SysValue.CURRENT_WORKSPACE.value));
		esq.getEntityCollection(function (response) {
			if (response.success) {
				var sysPackage = response.collection.first();
				callback.call(scope, sysPackage);
			} else {
				callback.call(scope, null, response.errorInfo.message);
			}
		}, this);
	},

	//endregion

	//region Methods: Public

	/**
	 * Opens schema metadata.
	 * @param {Terrasoft.manager.BaseSchema} schema Schema.
	 */
	openMetaData: function(schema) {
		const workspaceItemType = this._classNameToWorkspaceItemTypeMap[schema.$className];
		var hash = Ext.String.format(this.SCHEMA_METADATA_URL_TEMPLATE, schema.uId, workspaceItemType, schema.packageUId);
		var url = Terrasoft.workspaceBaseUrl + hash;
		this._openNewTab(url);
	},

	/**
	 * Exports schema metadata.
	 * @param {Terrasoft.manager.BaseSchema} schema Schema.
	 */
	exportMetaData: function (schema) {
		var hash = Ext.String.format(this.EXPORT_SCHEMA_METADATA_URL_TEMPLATE, schema.managerName, schema.uId);
		var href = Terrasoft.workspaceBaseUrl + hash;
		var fileName = schema.name + ".md";
		Terrasoft.download(href, fileName);
	},

	/**
	 * Opens schema source code.
	 * @param {Terrasoft.manager.BaseSchema} schema Schema.
	 */
	openSourceCode: function(schema) {
		var hash = Ext.String.format(this.SCHEMA_SOURCECODE_URL_TEMPLATE, schema.uId);
		var url = Terrasoft.workspaceBaseUrl + hash;
		this._openNewTab(url);
	},

	/**
	 * Opens entity schema source code.
	 * @param {Terrasoft.manager.BaseSchema} schema Schema.
	 */
	openEntitySourceCode: function(schema) {
		const hash = Ext.String.format(this.SCHEMA_SOURCECODE_URL_TEMPLATE, schema.realUId);
		const url = Terrasoft.workspaceBaseUrl + hash;
		this._openNewTab(url);
	},
	
	/**
	 * Opens validation errors.
	 * @param {String} validationErrorMessage Message that shows before list of errors.
	 * @param {Array} validationErrorsList Array of errors to display.
	 */
	openValidationErrors: function(validationErrorMessage, validationErrorsList) {
		const element = this._getNewErrorListDialogProxyElement();
		element.validationErrorMessage = validationErrorMessage;
		element.validationErrorsList = validationErrorsList;
		Ext.getBody().appendChild(element);
	},
	
	/**
	 * Opens compilation errors.
	 * @param {Array} errorsList Array of errors to display.
	 */
	openCompilationErrors: function(errorsList) {
		const element = this._getNewErrorListDialogProxyElement();
		element.errorsList = errorsList;
		Ext.getBody().appendChild(element);
	},

	/**
	 * Publish current workspace.
	 * @param {Terrasoft.configuration.ProcessModuleUtilities} serviceHelper Service helper.
	 * @param {Function} [callback] (optional) The callback function.
	 * @param {Object} [scope] (optional) Execution context.
	 */
	publish: function(serviceHelper, callback, scope) {
		scope = scope || this;
		var maskId = Terrasoft.Mask.show({
			caption: Terrasoft.Resources.SchemaDesigner.PublishingMaskCaption,
			timeout: 0
		});
		serviceHelper.publish(function(request, success, response) {
			serviceHelper.pingApplication(function() {
				Terrasoft.Mask.hide(maskId);
				var result = Terrasoft.deserialize(Terrasoft.deserialize(response.responseText));
				if (result && !result.success) {
					if (result.errors && result.errors.length > 0) {
						this.openCompilationErrors(result.errors);
					} else {
						var errorMessage = result && result.errorInfo && result.errorInfo.message;
						Terrasoft.showErrorMessage(errorMessage);
					}
				} else {
					Ext.callback(callback, scope);
					if (success) {
						this._handlePublishResponse(result);
					}
				}
				if (success) {
					this.initWebSocket(success);
				}
			}, this);
		}, this);
	},

	/**
	 * Opens academy online help in new window.
	 * @param {Terrasoft.configuration.AcademyUtilities} academyHelper Academy helper.
	 * @param {String} helpCode Context help code.
	 */
	openHelp: function(academyHelper, helpCode) {
		var config = {
			contextHelpCode: helpCode,
			callback: function(url) {
				window.open(url);
			},
			scope: this
		};
		academyHelper.getUrl(config);
	},

	/**
	 * Loads SysPackage info by UId for current workspace.
	 * @param {String} packageUId Package unique identifier.
	 * @param {Function} callback Callback function.
	 * @param {Object} callback.sysPackage Package view model object (Id, UId, Name, Maintainer, InstallType).
	 * @param {String} callback.errorMessage Server query error message.
	 * @param {Object} scope Callback function context.
	 */
	loadSysPackageByUId: function(packageUId, callback, scope) {
		if (Terrasoft.Features.getIsEnabled("AppsFeatures.CreateAppVirtualCurrentPackage")) {
			this._loadSysPackage(packageUId, callback, scope)
		} else {
			this._loadSysPackageByESQ(packageUId, callback, scope)
		}
	},

	/**
	 * Gets the number of running process instances with specified schema identifier.
	 * @param {String} schemaUId UId of the schema.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Context of the callback function.
	 * @param {String} managerName Manager name.
	 */
	getRunningProcessCountBySysSchemaUId: function(schemaUId, callback, scope, managerName) {
		if (Terrasoft.Features.getIsEnabled("UseObsoleteRunningProcessCountRequest")) {
			this._obsoleteGetRunningProcessCountBySysSchemaUId(schemaUId, callback, scope);
			return;
		}
		const request = Ext.create("Terrasoft.GetRunningProcessCountByUIdRequest", {
			countSpecifiedVersion: true,
			schemaUId: schemaUId,
			managerName: managerName
		});
		request.execute(function(response) {
			if (response.success) {
				callback.call(scope, response.count);
			} else {
				const errorInfo = response.errorInfo;
				callback.call(scope, null, errorInfo.message);
			}
		}, scope);
	},

	/**
	 * Determines whether the specified package was created by a third-party publisher or imported from an archive file.
	 * @param {String} packageUId UId of the package.
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The scope of callback function.
	 */
	getIsPackageForeign: function(packageUId, callback, scope) {
		Terrasoft.chain(
			function(next) {
				this.loadSysPackageByUId(packageUId, next, this);
			},
			function(next, sysPackage, errorMessage) {
				if (errorMessage) {
					callback.call(scope, null, errorMessage);
					return;
				}
				var isPackageForeign = false;
				if (sysPackage) {
					var maintainer = sysPackage.get("Maintainer");
					var installType = sysPackage.get("InstallType");
					isPackageForeign = maintainer !== Terrasoft.SysValue.CURRENT_MAINTAINER.value ||
						installType !== Terrasoft.SysPackageInstallType.SourceControl;
				}
				callback.call(scope, {
					isPackageForeign: isPackageForeign,
					sysPackage: sysPackage
				});
			}, this
		);
	}

	//endregion

});
