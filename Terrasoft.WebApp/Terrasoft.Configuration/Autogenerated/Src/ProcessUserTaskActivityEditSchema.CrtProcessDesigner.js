define("ProcessUserTaskActivityEditSchema", ["ProcessUserTaskActivityEditSchemaResources",
		"ProcessSchemaUserTaskUtilities", "ActivityConnectionsEditMixin", "ProcessSchemaParametersEditMixin",
		"MappingEditMixin"],
	function(resources, userTaskUtilities) {
		return {
			messages: {
				/**
				 * @message GetProcessElementInfo
				 * Returns process element and package unique identifier.
				 */
				"GetProcessElementInfo": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				/**
				 * @message ValidateProcessElement
				 * Validates process element.
				 */
				"ValidateProcessElement": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveProcessElement
				 * Saves process element.
				 */
				"SaveProcessElement": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetProcessSchema
				 * Returns process schema instance.
				 */
				"GetProcessSchema": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SetParametersInfo
				 * Sets parameters info.
				 */
				"SetParametersInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetParametersInfo
				 * Pass parameter values.
				 */
				"GetParametersInfo": {
					"mode": this.Terrasoft.MessageMode.PTP,
					"direction": this.Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Package unique identifier.
				 */
				"PackageUId": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Process element.
				 */
				"ProcessElement": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Start in.
				 * @type {DateTime}
				 */
				"StartIn": {
					dataValueType: this.Terrasoft.DataValueType.MAPPING,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "initProperty"
				},
				/**
				 * Start in period.
				 * @type {Integer}
				 */
				"StartInPeriod": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					parameterBindConfig: {
						onInit: "_initPeriod",
						onSave: "_savePeriod",
						defaultValue: "0"
					}
				},
				/**
				 * Duration.
				 * @type {DateTime}
				 */
				"Duration": {
					dataValueType: this.Terrasoft.DataValueType.MAPPING,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "initProperty"
				},
				/**
				 * Duration period.
				 * @type {Integer}
				 */
				"DurationPeriod": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					parameterBindConfig: {
						onInit: "_initPeriod",
						onSave: "_savePeriod",
						defaultValue: "0"
					}
				},
				/**
				 * Remind before.
				 * @type {DateTime}
				 */
				"RemindBefore": {
					dataValueType: this.Terrasoft.DataValueType.MAPPING,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "initProperty"
				},
				/**
				 * Remind before period.
				 * @type {Integer}
				 */
				"RemindBeforePeriod": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					parameterBindConfig: {
						onInit: "_initPeriod",
						onSave: "_savePeriod",
						defaultValue: "0"
					}
				},
				/**
				 * Activity priority.
				 * @type {Guid}
				 */
				"ActivityPriority": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					parameterBindConfig: {
						onInit: "_initActivityPriority",
						onSave: "_saveActivityPriority"
					}
				},
				/**
				 * Activity connection view models.
				 */
				"ActivityConnectionViewModels": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: this.Ext.create("Terrasoft.ObjectCollection")
				},
				/**
				 * Entity connections.
				 */
				"EntityConnections": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			mixins: {
				mappingEditMixin: "Terrasoft.MappingEditMixin",
				parametersEditMixin: "Terrasoft.ProcessSchemaParametersEditMixin",
				activityConnectionsEditMixin: "Terrasoft.ActivityConnectionsEditMixin"
			},
			methods: {

				// region Methods: Public

				/**
				 * @inheritdoc Terrasoft.configuration.BaseSchemaViewModel#init
				 * @override
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						const sandbox = this.sandbox;
						const tags = [sandbox.id];
						const config = sandbox.publish("GetProcessElementInfo", null, tags);
						this._setAttributes(config);
						this.initParameters(config.processElement);
						sandbox.subscribe("SaveProcessElement", this._onSaveProcessElement, this, tags);
						sandbox.subscribe("ValidateProcessElement", this._onValidateProcessElement, this, tags);
						this.mixins.activityConnectionsEditMixin.init.call(this, true, callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.configuration.EntitySchemaSelectMixin#getPackageUId
				 * @override
				 */
				getPackageUId: function() {
					return this.get("PackageUId");
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("AssignmentTypeSelect", userTaskUtilities.validateSelectValue);
					this.addColumnValidator("AssigneeValue", userTaskUtilities.validateMappingValue);
				},

				// endregion

				// region Methods: Private

				/**
				 * @private
				 */
				_setAttributes: function(config) {
					this.set("PackageUId", config.packageUId);
					this.set("ProcessElement", config.processElement);
					this.set("EntitySchema", config.entitySchema);
				},

				/**
				 * @private
				 */
				_setActivityPriority: function(value, displayValue) {
					this.set("ActivityPriority", {
						"value": value,
						"displayValue": displayValue
					});
				},

				/**
				 * @private
				 */
				_initActivityPriority: function(parameter) {
					const value = parameter.getValue();
					this._getActivityPriorities(function(collection) {
						const displayValue = collection.find(value);
						this._setActivityPriority(value, displayValue?.get("Name"));
					}, this);
				},

				/**
				 * @private
				 */
				_saveActivityPriority: function(parameter) {
					const parameterValue = parameter.getValue();
					const value = this.get("ActivityPriority");
					if (parameterValue !== value?.value) {
						this.saveParameter(parameter);
					}
				},

				/**
				 * @private
				 */
				_getActivityPriorities: function(callback, scope) {
					const rootSchemaName = "ActivityPriority";
					const cacheItemName = rootSchemaName + "_" + this.name;
					const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: rootSchemaName,
						clientESQCacheParameters: {
							cacheItemName: cacheItemName
						}
					});
					esq.addColumn("Name");
					esq.getEntityCollection(function(result) {
						if (result.success) {
							Ext.callback(callback, scope, [result.collection]);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_getActivityPriorityList: function(callback, scope) {
					scope = scope || this;
					const activityPriorityList = this.Ext.create("Terrasoft.Collection");
					this._getActivityPriorities(function(collection) {
						collection.each(function(item) {
							const id = item.get("Id");
							const name = item.get("Name");
							activityPriorityList.add(id, {
								value: id,
								displayValue: name
							});
						}, this);
						callback.call(scope, activityPriorityList);
					}, this);
				},

				/**
				 * @private
				 */
				_initPeriod: function(parameter, columnConfig) {
					const defValue = this.getDefaultValueFromColumnConfig(columnConfig);
					const parameterName = parameter.name;
					const parameterValue = parameter.getValue();
					const value = Ext.isEmpty(parameterValue) ? defValue : parameterValue;
					const periodConfig = this._getPeriodConfig();
					const item = Terrasoft.findWhere(periodConfig, { value: value });
					this.set(parameterName, item);
				},

				/**
				 * @private
				 */
				_savePeriod: function(parameter, columnConfig) {
					const defaultValue = this.getDefaultValueFromColumnConfig(columnConfig);
					const value = this.get(parameter.name);
					if (value && value.value !== defaultValue) {
						this.saveParameter(parameter);
					}
				},

				/**
				 * @private
				 */
				_getPeriodConfig: function() {
					return {
						"minutes": {
							value: "0",
							displayValue: this.get("Resources.Strings.MinutesCaption")
						},
						"hours": {
							value: "1",
							displayValue: this.get("Resources.Strings.HoursCaption")
						},
						"days": {
							value: "2",
							displayValue: this.get("Resources.Strings.DaysCaption")
						},
						"weeks": {
							value: "3",
							displayValue: this.get("Resources.Strings.WeeksCaption")
						},
						"months": {
							value: "4",
							displayValue: this.get("Resources.Strings.MonthsCaption")
						}
					};
				},

				/**
				 * @private
				 */
				_onPreparePeriodList: function(filter, list) {
					if (Terrasoft.isEmptyObject(list)) {
						return;
					}
					list.clear();
					list.loadAll(this._getPeriodConfig());
				},

				/**
				 * @private
				 */
				_onPrepareActivityPriorityList: function(filter, list) {
					if (Terrasoft.isEmptyObject(list)) {
						return;
					}
					list.clear();
					this._getActivityPriorityList((activityPriorityList) => list.loadAll(activityPriorityList));
				},

				/**
				 * @private
				 */
				_onSaveProcessElement: function() {
					const processElement = this.get("ProcessElement");
					this.saveParameters(processElement);
					this.saveActivityConnectionParameters(processElement);
				},

				/**
				 * @private
				 */
				_onValidateProcessElement: function() {
					this.validate();
					return Terrasoft.filter(this.validationInfo.attributes, (item) => !item.isValid, this);
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ActivityEditContainer",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.GRID_LAYOUT,
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "StartInLabel",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.StartInCaption" },
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "StartIn",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 14 },
						"labelConfig": {
							"visible": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "StartInPeriod",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 16, "row": 1, "colSpan": 8 },
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "_onPreparePeriodList"
							}
						},
						"labelConfig": {
							"visible": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "DurationLabel",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 2, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.DurationCaption" },
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "Duration",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 3, "colSpan": 14 },
						"labelConfig": {
							"visible": false
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DurationPeriod",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 16, "row": 3, "colSpan": 8 },
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "_onPreparePeriodList"
							}
						},
						"labelConfig": {
							"visible": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "RemindBeforeLabel",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 4, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.RemindBeforeCaption" },
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "RemindBefore",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 5, "colSpan": 14 },
						"labelConfig": {
							"visible": false
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "RemindBeforePeriod",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 16, "row": 5, "colSpan": 8 },
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "_onPreparePeriodList"
							}
						},
						"labelConfig": {
							"visible": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ActivityPriority",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 6, "colSpan": 24 },
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "_onPrepareActivityPriorityList"
							}
						},
						"caption": { "bindTo": "Resources.Strings.ActivityPriorityCaption" },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ActivityConnectionTitleContainer",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 8, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["container-list-header"],
						"items": [],
						"visible": { "bindTo": "getIsActivityTaskVisible" }
					}
				},
				{
					"operation": "insert",
					"name": "ActivityConnectionLabel",
					"parentName": "ActivityConnectionTitleContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.ActivityLinksCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddActivityConnectionRecordButton",
					"parentName": "ActivityConnectionTitleContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": { "bindTo": "Resources.Images.AddButtonImage" },
						"click": { "bindTo": "openLookupActivityConnectionWindow" }
					}
				},
				{
					"operation": "insert",
					"name": "ActivityConnection",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "ElementId",
						"onItemClick": { "bindTo": "onItemClick" },
						"collection": "ActivityConnectionViewModels",
						"onGetItemConfig": "getConnectionParameterViewConfig",
						"rowCssSelector": ".paramContainer",
						"classes": { "wrapClassName": ["activity-connection"] },
						"visible": { "bindTo": "getIsActivityTaskVisible" }
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
