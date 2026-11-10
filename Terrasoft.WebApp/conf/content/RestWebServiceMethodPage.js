Terrasoft.configuration.Structures["RestWebServiceMethodPage"] = {innerHierarchyStack: ["RestWebServiceMethodPage"], structureParent: "WebServiceMethodPage"};
define('RestWebServiceMethodPageStructure', ['RestWebServiceMethodPageResources'], function(resources) {return {schemaUId:'29e1d10d-fa15-5ed3-1c5b-769d6186ac6d',schemaCaption: "Page schema: \"Rest Web Services Method\"", parentSchemaName: "WebServiceMethodPage", packageName: "ServiceDesigner", schemaName:'RestWebServiceMethodPage',parentSchemaUId:'09cfe46e-ba2d-4bba-9f0d-d9decef0e4ac',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("RestWebServiceMethodPage", [ "RestWebServiceMethodPageResources"
], function(resources) {
	return {
		attributes: {

			/**
			 * Full Request URI.
			 */
			"FullUri": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Can open Uri request builder.
			 */
			"CanOpenUriRequestBuilder": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Content.
			 */
			 "Content": {
				"dataValueType": Terrasoft.DataValueType.ENUM,
				"onChange": "onContentAttributeChange"
			},

			/**
			 * Content Type.
			 */
			"ContentType": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "_onContentTypeChange",
				"isRequired": true,
				"validateOrder": 4
			},

			/**
			 * Content type list.
			 */
			"ContentTypeList": {
				"dataValueType": Terrasoft.DataValueType.COLLECTION
			},

			/**
			 * Request body builder Id.
			 */
			"RequestBodyBuilderId": {
				"dataValueType": Terrasoft.DataValueType.GUID,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Request body builder.
			 */
			"RequestBodyBuilder": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "_onRequestBodyBuilderChange"
			},

			/**
			 * Request body builder list.
			 */
			"RequestBodyBuilderList": {
				"dataValueType": Terrasoft.DataValueType.COLLECTION
			}
		},
		methods: {

			//region Private

			/**
			 * Update FullUri attribute to display.
			 * @param uri
			 * @private
			 */
			_updateFullUri: function(uri) {
				const baseUri = this.$ServiceSchema.baseUri;
				this.$FullUri = uri === null ? baseUri : baseUri + this._appendQueryParameters(uri);
			},

			/**
			 * @private
			 */
			_hasNewUriParameters: function() {
				const parameterNames = this._getNewUriParametersNames();
				return parameterNames.length > 0;
			},

			/**
			 * @private
			 */
			_getNewUriParametersNames: function() {
				const uriParametersNames = this._getUriParametersNames();
				const serviceParameterTypeEnum = Terrasoft.services.enums.ServiceParameterType;
				const queryParameters = this._findParametersByType(serviceParameterTypeEnum.QUERY_STRING);
				const urlSegments = this._findParametersByType(serviceParameterTypeEnum.URL_SEGMENT);
				const urlSegmentsDifference = _.difference(uriParametersNames.uri,
					_.pluck(urlSegments.getItems(), "path"));
				const queryParametersDifference = _.difference(uriParametersNames.query,
					_.pluck(queryParameters.getItems(), "path"));
				return urlSegmentsDifference.concat(queryParametersDifference);
			},

			/**
			 * @private
			 */
			_getUriParametersNames: function() {
				const uriParametersJson = this._getUriParametersJson();
				return {
					uri: _.keys(uriParametersJson.request.uri),
					query: _.keys(uriParametersJson.request.query)
				};
			},

			/**
			 * @private
			 */
			_hasUriParameters: function() {
				const uriParametersNames = this._getUriParametersNames();
				var allUriParametersNames = uriParametersNames.uri.concat(uriParametersNames.query);
				return allUriParametersNames.length > 0;
			},

			/**
			 * @private
			 */
			_getUriParametersJson: function() {
				const uriConverter = new Terrasoft.UriJsonConverter();
				return uriConverter.convert(this.$Uri);
			},

			/**
			 * @private
			 */
			_findParametersByType: function(parametersType) {
				return this.$Parameters.filterByPath("type", parametersType);
			},

			/**
			 * @private
			 */
			_appendQueryParameters: function(uri) {
				if (!uri) {
					uri = this.$Uri || "";
				}
				const defaultValue = this.get("Resources.Strings.DefaultParameterValue");
				const queryPart = this._findParametersByType(Terrasoft.services.enums.ServiceParameterType.QUERY_STRING)
					.map(function(parameter) {
						if (!Ext.isEmpty(parameter.defValue.value)) {
							const defValue = Terrasoft.ServiceDesignerUtilities.getFormattedValue(parameter.defValue,
								parameter.dataValueTypeName);
							return parameter.path + "=" + (parameter.defValue.source ===
							Terrasoft.services.enums.ServiceParameterValueSource.CONST
								? defValue
								: "{" + defValue + "}");
						} else {
							return Ext.String.format("{0}={{1}}", parameter.path, defaultValue);
						}
					})
					.getItems()
					.join("&");
				return uri + (queryPart ? "?" + queryPart : queryPart);
			},

			/**
			 * @private
			 */
			_updateCanOpenUriRequestBuilderAttribute: function() {
				this.$CanOpenUriRequestBuilder = this.$Uri && this._hasNewUriParameters();
			},

			/**
			 * @private
			 */
			_updateMethodUri: function(uri) {
				uri = uri.trim();
				var domain = Terrasoft.getUrlDomain(uri);
				if (Ext.isEmpty(this.$ServiceSchema.baseUri) && domain) {
					this.$ServiceSchema.setPropertyValue("baseUri", domain);
				}
				if (domain) {
					uri = uri.replace(domain, "");
				}
				Terrasoft.defer(function() {
					this.$Uri = uri;
				}, this);
			},

			/**
			 * Fill content method type list.
			 * @private
			 * @param {String} filter The filter string.
			 * @param {Terrasoft.Collection} list The list.
			 */
			_prepareContentTypeList: function(filter, list) {
				this._reloadTypeList(Terrasoft.services.enums.ServiceContentType, filter, list);
			},

			_prepareRequestBodyBuilderList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				var webServiceRequestBuilderEsq = this._getWebServiceRequestBuilderEsq();
				webServiceRequestBuilderEsq.getEntityCollection(function(result) {
					var collection = result.collection;
					var requestBodyBuilders = {};
					if (collection && collection.collection.length > 0) {
						Terrasoft.each(collection.collection.items, function(item) {
							var lookupValue = {
								displayValue: item.values.Name,
								value: item.values.Id
							};
							if (!list.contains(item.values.Id)) {
								requestBodyBuilders[item.values.Id] = lookupValue;
							}
						}, this);
						list.reloadAll(requestBodyBuilders);
						this._setRequestBodyBuilder();
					}
				}, this);
			},

			_getWebServiceRequestBuilderEsq: function() {
				var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "WebServiceRequestBuilder"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				return esq;
			},

			_setRequestBodyBuilder: function() {
				if (!Ext.isEmpty(this.$RequestBodyBuilderId)) {
					this.set("RequestBodyBuilder", this.$RequestBodyBuilderList.get(this.$RequestBodyBuilderId));
				}
			},

			/**
			 * @private
			 */
			_onContentTypeChange: function(model, valueType) {
				if (valueType) {
					this._contentTypeValidator(valueType.value, function(result) {
						if (result.invalidMessage) {
							var previousValue = this.getPrevious("ContentType");
							Terrasoft.defer(function() {
								this.$ContentType = previousValue;
							}, this);
							this.showInformationDialog(result.invalidMessage);
						} else {
							this.$Content = valueType && valueType.value;
							if (Terrasoft.services.enums.ServiceContentType.XML !== this.$Content) {
								this.$RequestBodyBuilder = null;
							}
						}
					}, this);
				}
			},

			_onRequestBodyBuilderChange: function(model, valueType) {
				const valueToSet = valueType ? valueType.value : null;
				this.$RequestBodyBuilderId = valueToSet;
				this.$Request.setPropertyValue("bodyBuilderId", valueToSet);
			},

			/**
			 * @private
			 */
			_contentTypeValidator: function(type, callback, scope) {
				var validationResult = {
					invalidMessage: ""
				};
				var searchConfig = {
					serviceUId: this.$ServiceSchema.uId,
					methodUId: this.$Method.uId,
					type: Terrasoft.services.enums.ServiceParameterType.BODY
				};
				if (type === Terrasoft.services.enums.ServiceContentType.XML &&
						this.$ServiceSchema.type === Terrasoft.services.enums.ServiceType.REST &&
						!this.getIsFeatureEnabled("UseCustomRequestBodyBuilder")) {
					this._validateParameters(searchConfig, callback, scope);
				} else {
					Ext.callback(callback, scope, [validationResult]);
				}
			},

			/**
			* @private
			*/
			_validateParameters: function(parameterSearchConfig, callback, scope) {
				var validationResult = {
					invalidMessage: ""
				};
				Terrasoft.chain(
					function(next) {
						Terrasoft.ServiceSchemaManager.findRequestParameterByType(parameterSearchConfig, next, this);
					},
					function(next, parameter) {
						if (parameter) {
							validationResult.invalidMessage = this.get("Resources.Strings.WrongContentTypeMessage");
							Ext.callback(callback, scope, [validationResult]);
						} else {
							Terrasoft.ServiceSchemaManager.findResponseParameterByType(parameterSearchConfig, next, this);
						}
					},
					function(next, parameter) {
						if (parameter) {
							validationResult.invalidMessage = this.get("Resources.Strings.WrongContentTypeMessage");
						}
						Ext.callback(callback, scope, [validationResult]);
					},
					this
				);
			},

			_getContentTypeName: function(contentType) {
				var contentTypeName = null;
				Terrasoft.each(Terrasoft.services.enums.ServiceContentType, function(typeValue, typeName) {
					if (contentType === typeValue) {
						contentTypeName = typeName;
					}
				}, this);
				return contentTypeName;
			},

			//endregion

			//region Protected

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#onUriAttributeChange.
			 * @overridden
			 */
			onUriAttributeChange: function(model, value) {
				this._updateFullUri(value);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#onAddRequestParameter.
			 * @overridden
			 */
			onAddRequestParameter: function() {
				this.callParent(arguments);
				this._updateCanOpenUriRequestBuilderAttribute();
				this._updateFullUri();
			},

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#initMethodParameters.
			 * @overridden
			 */
			initMethodParameters: function() {
				this.callParent(arguments);
				if (this.$Method.request.uri) {
					this._updateFullUri(this.$Method.request.uri);
				}
				this.set("Content", this.$Method.request.contentType, {silent: true});
				this.$ContentType = {
					displayValue: this._getContentTypeName(this.$Method.request.contentType),
					value: this.$Method.request.contentType
				};
				this.set("RequestBodyBuilderId", this.$Method.request.bodyBuilderId, {silent: true});
				this._prepareRequestBodyBuilderList("", this.$RequestBodyBuilderList);
			},

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#onLoadCanEditSchema.
			 * @overridden
			 */
			onLoadCanEditSchema: function() {
				this._updateCanOpenUriRequestBuilderAttribute();
			},

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#onSchemaChanged.
			 * @overridden
			 */
			onSchemaChanged: function(changes) {
				this.callParent(arguments);
				if (changes.uri) {
					this._updateMethodUri(changes.uri);
				}
				this._updateFullUri();
				this._updateCanOpenUriRequestBuilderAttribute();
				if (changes.contentType) {
					this.$ContentType = {
						displayValue: this._getContentTypeName(this.$Method.request.contentType),
						value: this.$Method.request.contentType
					};
				}
			},

			/**
			 * @inheritdoc Terrasoft.WebServiceMethotPage#validateUri.
			 * @overridden
			 */
			validateUri: function(callback, scope) {
				if (this._hasNewUriParameters()) {
					var parameterNames = this._getNewUriParametersNames();
					var confirmationMessage;
					var template = this.get("Resources.Strings.WrongUriMessage");
					if (parameterNames.length === 1) {
						confirmationMessage = this.Ext.String.format(template, parameterNames[0]);
					}
					if (parameterNames.length > 1) {
						template = this.get("Resources.Strings.WrongUrisMessage");
						confirmationMessage = this.Ext.String.format(template, parameterNames.join(", "));
					}
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
								this.openUriRequestBuilder();
							}
							callback.call(scope, false);
						}, ["yes", "no"]);
				} else {
					callback.call(scope, true);
				}
			},

			/**
			 * @protected
			 */
			 onContentAttributeChange: function(model, value) {
				if (this.$Request) {
					this._onAttributeChange(this.$Request, model, value);
				}
				if (this.$Response) {
					this._onAttributeChange(this.$Response, model, value);
				}
			},

			//endregion

			//region Public

			/**
			 * Quick setup from cURL button handler.
			 */
			openCurlRequestBuilder: function() {
				this._showQuickSetupWindow("CurlRequestBuilder");
			},

			/**
			 * Quick setup request from Raw button handler.
			 */
			openRawRequestBuilder: function() {
				this._showQuickSetupWindow("RawRequestBuilder");
			},

			/**
			 * Quick setup response from Raw button handler.
			 */
			openRawResponseBuilder: function() {
				this._showQuickSetupWindow("RawResponseBuilder");
			},

			/**
			 * Quick setup Request from JSON button handler.
			 */
			openJsonRequestBuilder: function() {
				this._showQuickSetupWindow("JsonRequestBuilder");
			},

			/**
			 * Quick setup Response from JSON button handler.
			 */
			openJsonResponseBuilder: function() {
				this._showQuickSetupWindow("JsonResponseBuilder");
			},

			/**
			 * Open uri request builder handler in quick setup.
			 */
			onQuickSetupUriRequestBuilderClick: function() {
				if (this.$Uri && this._hasUriParameters()) {
					this.openUriRequestBuilder();
				} else {
					this.showInformationDialog(this.get("Resources.Strings.QuickSetupEmptyUriMessage"));
				}
			},

			/**
			 * Open uri request builder handler.
			 */
			openUriRequestBuilder: function() {
				this._showQuickSetupWindow("UriRequestBuilder", this.$Uri);
			},

			getQuickSetupVisible: function() {
				return this.$Content === Terrasoft.services.enums.ServiceContentType.JSON;
			},

			isRequestBodyBuilderVisible: function() {
				return this.getIsFeatureEnabled("UseCustomRequestBodyBuilder") &&
					Terrasoft.services.enums.ServiceContentType.XML === this.$Content;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "HttpMethodType",
				"values": {
					"layout": {"column": 15, "row": 0, "colSpan": 9},
					"bindTo": "HttpMethodType",
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"caption": {"bindTo": "Resources.Strings.HttpMethodTypeCaption"},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {"bindTo": "_prepareMethodTypeList"}
					},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ContentType",
				"values": {
					"layout": {"column": 15, "row": 1, "colSpan": 9},
					"bindTo": "ContentType",
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"caption": {"bindTo": "Resources.Strings.ContentTypeCaption"},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {"bindTo": "_prepareContentTypeList"}
					},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},

			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "RequestBodyBuilder",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"layout": {"column": 15, "row": 4, "colSpan": 9},
					"visible": {"bindTo": "isRequestBodyBuilderVisible"},
					"caption": {"bindTo": "Resources.Strings.RequestBodyBuilderCaption"},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"list": {
							"bindTo": "RequestBodyBuilderList"
						},
						"prepareList": {
							"bindTo": "_prepareRequestBodyBuilderList"
						}
					},
					"bindTo": "RequestBodyBuilder"
				}
			},

			{
				"operation": "insert",
				"name": "UseAuthInfo",
				"values": {
					"contentType": Terrasoft.ContentType.LONG_TEXT,
					"layout": {"column": 15, "row": 3, "colSpan": 9},
					"bindTo": "UseAuthInfo",
					"caption": {"bindTo": "Resources.Strings.UseAuthInfoCaption"},
					"enabled": "$CanChangeUseAuthInfo"
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Uri",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 14},
					"bindTo": "Uri",
					"caption": {"bindTo": "Resources.Strings.UriCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					},
					"tip": {"content": "$Resources.Strings.AddressHint"},
					"controlConfig": {
						"rightIconClick": "$openUriRequestBuilder",
						"enableRightIcon": "$CanOpenUriRequestBuilder",
						"rightIconConfig": {
							"source": Terrasoft.ImageSources.URL,
							"url": Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.WizardIcon)
						},
						"rightIconClasses": ["open-web-service-method-builder-right-icon"]
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "RequestTimeout",
				"values": {
					"layout": {"column": 15, "row": 2, "colSpan": 9},
					"bindTo": "RequestTimeout",
					"caption": {"bindTo": "Resources.Strings.RequestTimeoutCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "FullUri",
				"values": {
					"contentType": Terrasoft.ContentType.LONG_TEXT,
					"layout": {"column": 0, "row": 3, "colSpan": 14},
					"bindTo": "FullUri",
					"caption": {"bindTo": "Resources.Strings.FullUriCaption"},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				operation: "insert",
				name: "QuickSetupButton",
				parentName: "ActionContainer",
				propertyName: "items",
				index: 2,
				values: {
					itemType: Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.DEFAULT,
					caption: {bindTo: "Resources.Strings.QuickSetupButtonCaption"},
					imageConfig: {bindTo: "Resources.Images.WizardIcon"},
					visible: {bindTo: "getQuickSetupVisible"},
					menu: {
						items: [
							{
								caption: "$Resources.Strings.RequestExampleSeparatorCaption",
								className: "Terrasoft.MenuSeparator"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupCurlButtonCaption"},
								click: "$openCurlRequestBuilder",
								markerValue: "CurlRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupRawRequestButtonCaption"},
								click: "$openRawRequestBuilder",
								markerValue: "RawRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupJsonRequestButtonCaption"},
								click: "$openJsonRequestBuilder",
								markerValue: "JsonRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupUriButtonCaption"},
								click: "$onQuickSetupUriRequestBuilderClick",
								markerValue: "UriRequestBuilder"
							},
							{
								caption: "$Resources.Strings.ResponseExampleSeparatorCaption",
								className: "Terrasoft.MenuSeparator"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupRawResponseButtonCaption"},
								click: "$openRawResponseBuilder",
								markerValue: "RawResponseBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupJsonResponseButtonCaption"},
								click: "$openJsonResponseBuilder",
								markerValue: "JsonResponseBuilder"
							}
						]
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/
	};
});


