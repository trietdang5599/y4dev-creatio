/**
 * Parent: BaseModalBoxPage
 */
define("ProcessTaskExecutionDetailsEditPage", ["ProcessTaskExecutionDetailsEditPageResources",
	"BaseFiltersGenerateModule", "ProcessTaskExecutionDetailsActivityEditPage",
	"css!BaseModalBoxPageCss", "css!ProcessTaskExecutionDetailsEditPage"
], function(resources, BaseFiltersGenerateModule) {
	return {
		messages: {
			/**
			 * @message ValidateRecord
			 * Validates record.
			 */
			"ValidateRecord": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetChangedValues
			 * Returns changed values.
			 */
			"GetChangedValues": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Role value.
			 */
			"OwnerRole": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"referenceSchemaName": "VwSysRole",
				"isRequired": false
			},
			/**
			 * Owner value.
			 */
			"Owner": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.LOOKUP,
				"isLookup": true,
				"referenceSchemaName": "Contact",
				"isRequired": false
			},
			/**
			 * Process element unique identifier.
			 */
			"ElementUId": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.GUID
			},
			/**
			 * Determines whether the data was changed or not.
			 */
			"IsChanged": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Determines whether the modal box is closed with save click or not.
			 */
			"IsSaved": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},
			/**
			 * Determines whether the role assignment is supported or not.
			 */
			"IsRoleAssignmentSupported": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Activity record identifier.
			 */
			"ActivityRecordId": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.GUID
			},
			/**
			 * Determines whether the user task has technical activity.
			 */
			"HasTechnicalActivity": {
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getLookupValue: function(entitySchemaName, recordId, callback, scope) {
				if (Terrasoft.isEmpty(recordId)) {
					Ext.callback(callback, scope);
					return;
				}
				const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: entitySchemaName
				});
				this.addPrimaryDisplayColumn(esq);
				esq.enablePrimaryColumnFilter(recordId);
				esq.getEntityCollection(function(response) {
					let lookupValue;
					if (response.success && response.collection.getCount() === 1) {
						const entity = response.collection.getByIndex(0);
						lookupValue = {
							displayValue: entity.get("displayValue"),
							value: entity.get("Id")
						};
					}
					Ext.callback(callback, scope, [lookupValue]);
				}, this);
			},

			/**
			 * @private
			 */
			_initContactLookupValue(recordId, callback, scope) {
				this._getLookupValue("Contact", recordId, function(value) {
					this.set("Owner", value);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_initRoleLookupValue(recordId, callback, scope) {
				this._getLookupValue("VwSysRole", recordId, function(value) {
					this.set("OwnerRole", value);
					this.on("change:OwnerRole", function() {
						if (this.getLookupValue("OwnerRole") != null) {
							this.set("Owner", null);
						}
					}, this);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_getInitialExecutionData: function() {
				return this.get("ProcessData");
			},

			/**
			 * @private
			 */
			_initAttributes: function(callback, scope) {
				let assignmentOptions;
				Terrasoft.chain(function(next) {
					const executionData = this._getInitialExecutionData();
					if (!executionData || !executionData.assignmentOptions) {
						const currentUserContactId = Terrasoft.SysValue.CURRENT_USER_CONTACT.value;
						this._initContactLookupValue(currentUserContactId, callback, scope);
						return;
					}
					this.set("ElementUId", executionData.procElUId);
					const activityRecordId = executionData.activityRecordId;
					assignmentOptions = executionData.assignmentOptions;
					const roleAssignmentSupported = assignmentOptions.assignmentType !== Terrasoft
						.process.enums.AssignmentType.NONE;
					this.set("IsRoleAssignmentSupported", roleAssignmentSupported);
					if (Terrasoft.isNotEmpty(activityRecordId) && !Terrasoft.isEmptyGUID(activityRecordId)) {
						this.set("HasTechnicalActivity", true);
						this.set("ActivityRecordId", activityRecordId);
					}
					Ext.callback(next, this);
				}, function(next) {
					this._initRoleLookupValue(assignmentOptions.groupId, next, this);
				}, function() {
					this._initContactLookupValue(assignmentOptions.performerId, callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_getPerformerOptions: function() {
				const ownerId = this.getLookupValue("Owner");
				const roleId = this.getLookupValue("OwnerRole");
				return {
					performerId: ownerId,
					groupId: roleId
				};
			},

			/**
			 * @private
			 */
			_getIsNotChanged: function(initialOptions, currentOptions) {
				if (!Boolean(currentOptions.performerId)) {
					currentOptions.performerId = Terrasoft.GUID_EMPTY;
				}
				if (!Boolean(currentOptions.groupId)) {
					currentOptions.groupId = Terrasoft.GUID_EMPTY;
				}
				const hasTechnicalActivity = this.get("HasTechnicalActivity");
				return (initialOptions?.performerId === currentOptions.performerId &&
					initialOptions?.groupId === currentOptions.groupId) && !hasTechnicalActivity;
			},

			/**
			 * @private
			 */
			_handleSaveResponse: function(response) {
				if (response.success) {
					this.set("IsChanged", true);
					this.set("IsSaved", true);
					this.close();
				} else {
					const message = response.errorInfo.toString();
					Terrasoft.showErrorMessage(message);
				}
			},

			/**
			 * @private
			 */
			_getSaveRecordMessageConfig: function() {
				return {
					additionalAttributeValues: {
						"Owner": this.get("Owner"),
						"OwnerRole": this.get("OwnerRole")
					}
				};
			},

			/**
			 * @private
			 */
			_onSave: function() {
				if (!this._validateBeforeSave()) {
					return;
				}
				const elementUId = this.get("ElementUId");
				const currentOptions = this._getPerformerOptions();
				const executionData = this._getInitialExecutionData();
				const initialOptions = executionData.assignmentOptions;
				const isNotChanged = this._getIsNotChanged(initialOptions, currentOptions);
				if (isNotChanged) {
					this.close();
					return;
				}
				const requestConfig = {
					elementUId: elementUId,
					performer: {
						contactId: currentOptions.performerId,
						adminRoleId: currentOptions.groupId
					}
				};
				if (this.get("HasTechnicalActivity")) {
					const moduleId = this.getModuleId("ProcessTaskExecutionDetailsActivityEditModule");
					const messageConfig = this._getSaveRecordMessageConfig();
					requestConfig.technicalActivityValues = this.sandbox
						.publish("GetChangedValues", messageConfig, [moduleId]);
				}
				const request = Ext.create("Terrasoft.ChangeProcessElementStateRequest", requestConfig);
				request.execute(this._handleSaveResponse, this);
			},

			/**
			 * @private
			 */
			_validateActivityEditModule: function() {
				let isValid = true;
				if (this.get("HasTechnicalActivity")) {
					const moduleId = this.getModuleId("ProcessTaskExecutionDetailsActivityEditModule");
					isValid = this.sandbox.publish("ValidateRecord", null, [moduleId]);
				}
				return isValid;
			},

			/**
			 * @private
			 */
			_validateBeforeSave: function() {
				let isValid = true;
				const ownerId = this.getLookupValue("Owner");
				const roleId = this.getLookupValue("OwnerRole");
				if (!ownerId && !roleId) {
					isValid = false;
					const invalidMessage = resources.localizableStrings.MissingRequiredFieldValuesMessage;
					this.showInformationDialog(invalidMessage);
				}
				return isValid && this._validateActivityEditModule();
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc Terrasoft.EntityBaseViewModelMixin#addLookupQueryFilter
			 * @override
			 */
			addLookupQueryFilter: function(esq) {
				this.callParent(arguments);
				if (esq.rootSchemaName === "Contact") {
					const roleId = this.getLookupValue("OwnerRole");
					let roleFilter = this.getIsFeatureEnabled("ShowAllContactsAsOwner")
						? BaseFiltersGenerateModule.UsersInRoleFilter(roleId)
						: BaseFiltersGenerateModule.OwnersInRoleFilter(roleId);
					esq.filters.add("RoleFilter", roleFilter);
				}
			},

			/**
			 * @inheritdoc Terrasoft.configuration.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this._initAttributes(callback, scope);
				}, this]);
			},

			/**
			 * @inheritDoc Terrasoft.BaseModalBoxPage#getHeader.
			 * @overridden
			 */
			getHeader: function() {
				return resources.localizableStrings.PageHeaderCaption;
			},

			/**
			 * @inheritdoc Terrasoft.BaseModalBoxPage#getModalClosingMessageArgs
			 * @overridden
			 */
			getModalClosingMessageArgs: function() {
				const shouldReturnResult = this.get("IsChanged") && this.get("IsSaved");
				return shouldReturnResult ? this._getPerformerOptions() : null;
			},

			/**
			 * @inheritdoc Terrasoft.BaseModalBoxPage#getModalBoxInitialConfig
			 * @override
			 */
			getModalBoxInitialConfig: function() {
				const height = this.get("HasTechnicalActivity") ? "55.5em" : "26em"
				return {
					modalBoxConfig: {
						boxClasses: ["execution-details-edit-page-modal"]
					},
					initialSize: {
						width: "40em",
						height: height
					}
				};
			}

			// endregion

		},
		modules: {
			"ProcessTaskExecutionDetailsActivityEditModule": {
				"config": {
					"schemaName": "ProcessTaskExecutionDetailsActivityEditPage",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"showMask": true,
					"parameters": {
						"viewModelConfig": {
							"ActivityRecordId": {
								"attributeValue": "ActivityRecordId"
							}
						}
					},
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "HeaderCaptionContainer",
				"values": {
					"wrapClass": ["process-task-execution-detail-header-name-container"],
				}
			}, {
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["execution-details-edit-page"]
				}
			}, {
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "PerformerAssignmentLayout",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"controlConfig": {
						"collapseEmptyRow": true
					},
					"items": [
						{
							"name": "OwnerRole",
							"contentType": Terrasoft.ContentType.ENUM,
							"caption": { "bindTo": "Resources.Strings.RoleCaption" },
							"layout": { "column": 0, "row": 0, "colSpan": 24 },
							"visible": { "bindTo": "IsRoleAssignmentSupported" }
						}, {
							"name": "Owner",
							"markerValue": "OwnerContact",
							"contentType": Terrasoft.ContentType.ENUM,
							"caption": { "bindTo": "Resources.Strings.OwnerCaption" },
							"layout": { "column": 0, "row": 1, "colSpan": 24 }
						}
					]
				}
			}, {
				"operation": "insert",
				"name": "ProcessTaskExecutionDetailsActivityEditModule",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE,
					"items": [],
					"visible": { "bindTo": "HasTechnicalActivity" }
				}
			}, {
				"operation": "insert",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"name": "BottomButtonsWrapper",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["bottom-buttons-wrapper"],
					"items": [
						{
							"itemType": Terrasoft.ViewItemType.BUTTON,
							"name": "SaveButton",
							"style": Terrasoft.controls.ButtonEnums.style.BLUE,
							"click": { "bindTo": "_onSave" },
							"caption": { "bindTo": "Resources.Strings.SaveButtonCaption" },
							"classes": { "textClass": "right-button" }
						}, {
							"itemType": Terrasoft.ViewItemType.BUTTON,
							"name": "CancelButton",
							"style": Terrasoft.controls.ButtonEnums.style.DEFAULT,
							"click": { "bindTo": "close" },
							"caption": { "bindTo": "Resources.Strings.CancelButtonCaption" },
							"classes": { "textClass": "right-button" }
						}
					]
				}
			}
		]
	};
});
