define("PackageDependenciesDiagramModule", ["ext-base", "terrasoft", "ej-diagram", "process-schema-diagram", "BaseViewModule", "css!PackageDependenciesDiagramModule"],
	function(Ext, Terrasoft) {
		/**
		 * @class Terrasoft.configuration.PackageDependenciesDiagramModule
		 * Class for load packages diagram.
		 */
		Ext.define("Terrasoft.configuration.PackageDependenciesDiagramModule", {
			extend: "Terrasoft.BaseViewModule",
			alternateClassName: "Terrasoft.PackageDependenciesDiagramModule",

			//region Fields: Private

			/**
			 * Diagram instance. Type of diagram calculated by hash.
			 * @private
			 * @type {Terrasoft.BaseSchemaDesigner}
			 */
			_diagram: null,

			/**
			 * @private
			 */
			_wrapClassName: "package-dependencies-diagram",

			//endregion

			//region Fields: Protected

			/**
			 * @overridden
			 * @inheritdoc Terrasoft.BaseViewModule#diff
			 */
			diff: null,

			//endregion
			
			//region Methods: Private.

			/**
			 * Prepare diagram metadata
			 * @private
			 * @param response
			 */
			_prepareMetaData: function (response) {
				const responseValue = response.responseText;
				const responseData = Terrasoft.decode(responseValue);
				return {
					message: "ReadMetaData",
					metaData: responseData.metaData,
					resources: this._prepareResources(responseData.resources),
				};
			},

			/**
			 * Generate config for request.
			 * @private
			 * @returns {object} config.
			 */
			_getMetaDataRequestConfig: function () {
				const csrfToken = Ext.util.Cookies.get(Terrasoft.csrfCookieName);
				const requestUrl = Terrasoft.workspaceBaseUrl + '/ServiceModel/PackageService.svc/GetDependencyDiagramMetaData';
				const config = {
					url: requestUrl,
					headers: {
						'Content-Type': 'application/json',
						'Accept': 'application/json',
						[Terrasoft.csrfCookieName]: csrfToken || "",
					},
					method: 'POST',
					scope: this,
				};
				config.timeout = Terrasoft.BaseServiceProvider.getRequestTimeout(config);
				return config;
			},

			/**
			 * Prepare resources from response.
			 * @private
			 * @param resourcesFromResponse response.
			 * @returns {object} resources.
			 */
			_prepareResources: function (resourcesFromResponse) {
				const resources = {};
				resourcesFromResponse.forEach(resource => {
					const values = {};
					resources[resource.Key] = values;
					resource.Value.forEach(resourceValue => {
						values[resourceValue.Key] = resourceValue.Value;
					});
				});
				return resources;
			},

			/**
			 * @private
			 * @param callback
			 * @param scope
			 */
			_initModule: function(callback, scope) {
				const requestConfig = this._getMetaDataRequestConfig();
				requestConfig.callback = function(request, success, response) {
					Ext.EventManager.addListener(window, "message", function(message) {
						this._onMessageReceived(message, response);
					}, this);
					Ext.callback(callback, scope);
				}.bind(this);
				Ext.Ajax.request(requestConfig);
			},

			/**
			 * Handler that process received messages from diagram module.
			 * @private
			 * @param message received message.
			 * @param response data for send to diagram module.
			 */
			_onMessageReceived: function(message, response) {
				const messageData = message.browserEvent.data;
				if (messageData.indexOf("GetMetaData") < 0) {
					return;
				}
				const data = this._prepareMetaData(response);
				window.parent.postMessage(Terrasoft.encode(data), window.location.origin);
			},

			/**
			 * Parse received hash string and return diagram class name.
			 * @private
			 * @param {String} hash Hash
			 * @return {String} diagram class name.
			 */
			_parseHash: function(hash) {
				const params = hash.split("/");
				return params[0] || "";
			},

			/**
			 * Returns diagram class name by type.
			 * @private
			 * @param {String} diagramTypeName
			 * @param {String} oldClassName
			 * @param {String} newClassName
			 * @return {String} diagram class name.
			 */
			_getDiagramClassName: function(diagramTypeName, oldClassName, newClassName) {
				if (Terrasoft.endsWith(diagramTypeName, "Old")) {
					return oldClassName;
				}
				if (Terrasoft.endsWith(diagramTypeName, "New")) {
					return newClassName;
				}
				return Terrasoft.Features.getIsEnabled("UseProcessDiagramComponent")
					? newClassName
					: oldClassName;
			},

			/**
			 * Initialize schema diagram (see {@link #diagram}) by hash.
			 * @private
			 * @param {Object} config Configuration object.
			 * @param {String} config.hash Hash.
			 */
			_initDiagram: function(config) {
				let diagram;
				const diagramName = this._parseHash(config.hash);
				const packageDependenciesDiagram = this._getDiagramClassName(diagramName,
					"Terrasoft.PackageDependenciesDiagram", "Terrasoft.PackageDependenciesDiagramNew");
				diagram = Ext.create(packageDependenciesDiagram, {
					sandbox: this.sandbox
				});

				this._diagram = diagram;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc Terrasoft.BaseViewModule#onHistoryStateChanged
			 * Hides base implementation, because diagram does not support loading schemes by historyState
			 * @overridden
			 */
			onHistoryStateChanged: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseViewModule#init
			 * @overridden
			 * @param callback
			 * @param scope
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this._initModule(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseViewModule#loadMainPanelsModules
			 * Hides base implementation, because diagram does not load nested modules.
			 * @overridden
			 */
			loadMainPanelsModules: function() {
				const currentState = this.sandbox.publish("GetHistoryState");
				const hash = currentState.hash.historyState;
				this._initDiagram({
					hash: hash
				});
				if (!this._diagram) {
					return;
				}
				this._diagram.render({
					renderTo: this.renderTo,
					sandbox: this.sandbox
				});
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
					}
				});
			},

			/**
			 * Render diagram.
			 * @param {Ext.Element} renderTo Container to render diagram.
			 */
			render: function(renderTo) {
				const renderContainerName = "packageDependenciesDiagram";
				const mainContentWrapper = Ext.get("mainContentWrapper");
				mainContentWrapper.addCls(this._wrapClassName);
				this.renderTo = renderTo;
				this.loadNonVisibleModules();
			},

			/**
			 * @overridden
			 * @inheritdoc Terrasoft.BaseObject#onDestroy
			 */
			onDestroy: function() {
				const diagram = this._diagram;
				if (diagram) {
					diagram.destroy();
				}
				this.callParent(arguments);
			}

			//endregion

		});

		return Terrasoft.PackageDependenciesDiagramModule;
	});
