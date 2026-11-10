define("SysWorkplacePageV2",
	[
		"ServiceHelper",
		"SystemOperationsPermissionsMixinResources",
		"ConfigurationConstants",
		"SectionServiceMixin",
		"css!SysWorkplacePageV2Styles"
	],
	function(serviceHelper, resources, ConfigurationConstants) {
		return {
			entitySchemaName: "SysWorkplace",
			messages: {
				/**
				 * @message UpdateWorkplaceType
				 * Calls workplace type update for page and detail.
				 */
				"UpdateWorkplaceType": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message RefreshWorkplace
				 * Calls refresh workplace structure.
				 */
				"RefreshWorkplace": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"GetWorkplaceTypeCode": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"GetIsWebApplicationWorkplace": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message WorkplaceAppTypeChanged
				 * Publish workplace application type changed.
				 */
				"WorkplaceAppTypeChanged": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				/**
				 * @class SectionServiceMixin
				 * Section service mixin.
				 */
				SectionServiceMixin: Terrasoft.SectionServiceMixin
			},
			attributes: {
				/**
				 * Sign that current workplace is portal.
				 */
				"IsCurrentWorkplaceSSP": {
					dataValue: this.Terrasoft.DataValueType.BOOLEAN
				},

				/**
				 * Section types enum.
				 * @protected
				 */
				"SectionTypes": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Workplace type.
				 */
				"Type": {
					"type": this.Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						"columns": ["Code"]
					}
				},

				/**
				 * Home page lookup.
				 */
				"HomePageLookup": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Available home pages.
				 */
				"AvailableHomePages": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"CanEnableEditButton": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				"CanUseApplicationClientType": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Terrasoft.Features.getIsDisabled("DisableSetupMobileWorkplaces") &&
						Terrasoft.Features.getIsEnabled("UseMobilePageDesigner")
				},

				"IsWebApplicationWorkplaceType": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				"SysApplicationClientType": {
					"dependencies": [
						{
							"columns": ["SysApplicationClientType"],
							"methodName": "onSysApplicationClientTypeChanged"
						}
					],
				},

				"PrevSysApplicationClientType": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			properties: {
				_isAddNewHomePage: false,
				_isCopyHomePage: false,
				_pageTemplates: {
					PageWithTabsTemplate: "05477cbd-1ca8-4658-b427-971fc58bbc08",
					PageWithRightAreaAndTabsTemplate: "98ca84c1-5f6a-4a55-9c3f-d668ce12378c",
					PageWithTopAreaAndTabsTemplate: "3176536a-77ac-403a-932e-28dd4b50e4e6",
					PageWithLeftAreaTemplate: "0f8eb896-7b62-4dfa-bd55-a414f50932a7",
					PageWithAreaTemplate: "e4b45c7b-cfe3-4ee4-b56b-502f690db0d5",
					BaseHomePage: "0c5cfb7a-1ed9-41b8-905e-9a38c6915550",
					BaseGridSectionTemplate: "a5678241-e5e0-f691-b825-84b6039d5fa2",
					BlankPageTemplate: "f691e828-0b36-42a7-898f-c337e9af67d0",
					BaseSectionTemplate: "9d0fd8cc-431b-455a-beeb-3bb93c64cb38",
					BaseTemplate: "c6a6e333-21c2-4f43-b6fb-cf4b0369b09f",
					BasePageTemplate: "1a29b42d-f75e-48e5-b227-0b29bf0e676d",
					BaseMiniPageTemplate: "ecdcc8ff-272c-4957-9381-7d74ce17e140"
				}
			},
			details: /**SCHEMA_DETAILS*/{
				SysAdminUnit: {
					schemaName: "SysAdminUnitInWorkplaceDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysWorkplace"
					},
					defaultValues: {
						SysWorkplace: {
							masterColumn: "Id"
						}
					}
				},
				SysModule: {
					schemaName: "SysModuleInWorkplaceDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysWorkplace"
					},
					defaultValues: {
						SysWorkplace: {
							masterColumn: "Id"
						},
						IsCurrentWorkplaceSSP: {
							masterColumn: "IsCurrentWorkplaceSSP"
						},
						SectionTypes: {
							masterColumn: "SectionTypes"
						}
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				//region Methods: Private

				/**
				 * Updates card state after workplace saved using workplace API.
				 * @private
				 * @param {Object} result Save workplace result.
				 */
				_updateCardState: function(result) {
					const workplaceId = result.CreateWorkplaceResult;
					this.$Id = workplaceId;
					this.$PrimaryColumnValue = workplaceId;
					this.isNew = false;
					this.updateDetails();
				},

				/**
				 * Set workplace type from defaultValues.
				 * @private
				 */
				_applyWorkplaceTypeValues: function() {
					if (this.getIsFeatureDisabled("UseTypedWorkplaces")) {
						return;
					}
					const type = this.getDefaultValueByName("Type");
					const code = this.getDefaultValueByName("Code");
					this.$Type = type ? {value: type} : this.$Type;
					this.$TypeCode = Terrasoft.isNotEmpty(code) ? code : this.$TypeCode;
				},

				/**
				 * @private
				 */
				_getHomePageEsq: function() {
					const esq = new Terrasoft.EntitySchemaQuery({
						rootSchemaName: "SysSchema",
						isDistinct: true
					});
					esq.addColumn("UId");
					esq.addColumn("ModifiedOn");
					esq.addColumn("Name");
					esq.addColumn(
						"=[VwSysSchemaExtending:BaseSchemaId:Id].[SysSchema:Id:TopExtendingSchemaId].Caption",
						"Caption");
					esq.addParameterColumn(true, Terrasoft.DataValueType.BOOLEAN,
						"isAngularPage");
					const filterName = Terrasoft.createColumnFilterWithParameter(
						"[SysSchemaProperty:SysSchema:Id].Name", "SchemaType");
					const filterType = Terrasoft.createColumnFilterWithParameter(
						"[SysSchemaProperty:SysSchema:Id].Value", "AngularSchema");
					esq.filters.add("SchemaPropertyNameFilter", filterName);
					esq.filters.add("SchemaPropertyTypeFilter", filterType);
					esq.filters.add("withoutDetails",
						Terrasoft.createNotExistsFilter("[SysDetail:DetailSchemaUId:UId].DetailSchemaUId"));
					esq.filters.add("withoutEditPage",
						Terrasoft.createNotExistsFilter("[SysModuleEdit:CardSchemaUId:UId].CardSchemaUId"));
					Object.values(this._pageTemplates).forEach((uId) => {
						esq.filters.add(uId, Terrasoft.createColumnFilterWithParameter(
							Terrasoft.ComparisonType.NOT_EQUAL, "UId", uId));
					});
					return esq;
				},

				/**
				 * @private
				 */
				_getMainPageEsq: function() {
					const esqMainPages = new Terrasoft.EntitySchemaQuery({
						rootSchemaName: "ApplicationMainMenu",
						isDistinct: true
					});
					esqMainPages.addColumn("IntroPageUId", "UId");
					esqMainPages.addColumn("[SysSchema:UId:IntroPageUId].Caption", "Caption");
					esqMainPages.addColumn("ModifiedOn");
					esqMainPages.addColumn("Name");
					return esqMainPages;
				},

				/**
				 * @private
				 */
				_initAvailableHomePages: function(callback, scope) {
					if (this.canSetHomePageForWorkplace()) {
						const batch = Ext.create("Terrasoft.BatchQuery");
						batch.add(this._getHomePageEsq());
						batch.add(this._getMainPageEsq());
						batch.execute((response) => {
							this.$AvailableHomePages = new Terrasoft.Collection();
							for (const queryResult of response.queryResults) {
								if (queryResult.success) {
									queryResult.rows.forEach(function(item) {
										if(!this.$AvailableHomePages
											.findByFn(homePageItem => homePageItem.uId === item.UId)){
												this.$AvailableHomePages.add(item.UId, {
												uId: item.UId,
												caption: item.Caption,
												modifiedOn: item.ModifiedOn,
												isAngularPage: item.isAngularPage,
												name: item.Name
											});
										}
									}, this);
								}
							}
							this.$AvailableHomePages.sortByFn((item1, item2) => Date.parse(item2.modifiedOn) - Date.parse(item1.modifiedOn));
							Ext.callback(callback, scope);
						});
					} else {
						Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_prepareHomePageList: function(filter, list) {
					const result = {};
					Terrasoft.each(this.$AvailableHomePages, function({uId, caption}) {
						result[uId] = {
							value: uId,
							displayValue: caption
						};
					}, this);
					list.reloadAll(result);
				},

				/**
				 * @private
				 */
				_onServerMessage: function(channel, message) {
					if (message && message.event === "HomePageDesignerSaved") {
						this._initAvailableHomePages(() => {
							if ((!this.$HomePageUId && this._isAddNewHomePage) || this._isCopyHomePage) {
								const schemaName = message.name;
								const item = this.$AvailableHomePages.findByFn((item) => item.name === schemaName);
								this.$HomePageUId = item.uId;
								this._isAddNewHomePage = false;
								this._isCopyHomePage = false;
								this.onItemFocused();
							}
							this._initHomePageLookup();
						});
					}
				},

				/**
				 * @private
				 */
				_initHomePageLookup: function() {
					if (this.canSetHomePageForWorkplace()) {
						this.$HomePageLookup = {
							value: this.$HomePageUId,
							displayValue: this._findHomePageCaption()
						};
					}
				},

				/**
				 * @private
				 */
				_findHomePageCaption: function() {
					if (!this.$HomePageUId) {
						return "";
					}
					const homePage = this.$AvailableHomePages?.find(this.$HomePageUId);
					if (!homePage?.caption) {
						const message = this.get("Resources.Strings.HomepageWithUIdNotFound");
						this.showInformationDialog(message);
						this.error(message);
					}
					return homePage?.caption || this.$HomePageUId;
				},

				_updateIsWebAppWorkplaceTypeAttribute: function() {
					const currentClientType = this.$SysApplicationClientType;
					const isWebAppWorkplace = this._getIsWebApplicationWorkplace(currentClientType?.value);
					this.set("IsWebApplicationWorkplaceType", isWebAppWorkplace);
				},

				_getIsWebApplicationWorkplace: function(value) {
					return value.toLowerCase() ===
						ConfigurationConstants.WorkplaceClientApplicationsTypes.BrowserClientTypeValue;
				},

				_afterSysApplicationClientTypeChanged: function() {
					this._updateIsWebAppWorkplaceTypeAttribute();
					this.$PrevSysApplicationClientType = Ext.apply({}, this.$SysApplicationClientType);
					if (!this._getIsWebApplicationWorkplace(this.$SysApplicationClientType?.value)) {
						this.$HomePageLookup = null;
					}
					this.sandbox.publish("WorkplaceAppTypeChanged");
				},

				_deleteAllSectionsFromWorkplace: function() {
					this.save({isSilent: true});
					const serviceConfig = this._getRemoveAllSectionsServiceConfig();
					this.callService(serviceConfig, function (result) {
						if (!result || !result.success) {
							const message = result.errorInfo?.message || this.get("Resources.Strings.CallServiceErrorMessage");
							this.showConfirmationDialog(message, () => {
								this.$SysApplicationClientType = prevClientType;
								this._updateIsWebAppWorkplaceTypeAttribute();
							});
							return;
						}
						this.updateDetail({detail: "SysModule"});
						this._afterSysApplicationClientTypeChanged();
					});
				},

				_getRemoveAllSectionsServiceConfig: function() {
					return {
						data: {
							workplaceId: this.$Id
						},
						serviceName: "WorkplaceService",
						methodName: "RemoveAllSectionsFromWorkplace"
					};
				},

				//endregion

				//region Methods: Protected

				/**
				 * ############## ####### ######### ########
				 * @protected
				 */
				initHeaderCaption: function() {
					const caption = this.get("Resources.Strings.HeaderCaption");
					this.set("NewRecordPageCaption", caption);
				},

				/**
				 * ########## ###### ######### ######## ########
				 * @override
				 * @return {Terrasoft.BaseViewModelCollection} ########## ######### ######## ########
				 */
				getActions: function() {
					const actionMenuItems = this.Ext.create("Terrasoft.BaseViewModelCollection");
					return actionMenuItems;
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([
						function() {
							this._applyWorkplaceTypeValues();
							Terrasoft.chain(
								this.initSectionTypes.bind(this),
								this._initAvailableHomePages.bind(this),
								() => {
									this._initHomePageLookup();
									this.on("change:HomePageLookup", () => {
										this.$HomePageUId = this.$HomePageLookup?.value;
										this._setCanEnableEditButton();
									}, this);
									this._setCanEnableEditButton();
									Terrasoft.ServerChannel.on(Terrasoft.ServerChannelSender.BROADCAST_MESSAGE,
										this._onServerMessage, this);
									Ext.callback(callback, scope);
								}
							);
						}, this
					]);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#reloadEntity
				 * @overridden
				 */
				reloadEntity: function(callback, scope) {
					this.callParent([
						() => {
							Terrasoft.chain(
								(next) => {
									if (this.$AvailableHomePages) {
										next();
									} else {
										this._initAvailableHomePages(next, this);
									}
								},
								() => {
									this._initHomePageLookup()
									this._updateIsWebAppWorkplaceTypeAttribute();
									Ext.callback(callback, scope);
								}
							);
						}, this
					]);
				},


				/**
				 * @inheritdoc Terrasoft.BasePageV2#onDiscardChangesClick
				 * @overridden
				 */
				onDiscardChangesClick: function(callback, scope) {
					this.callParent([
						() => {
							this._initHomePageLookup();
							this.Ext.callback(callback, scope);
						}
					]);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("UpdateWorkplaceType", this.updateWorkplaceType, this);
				},

				/**
				 * Updates workplace type for page and section.
				 * @protected.
				 */
				updateWorkplaceType: function() {
					this.initCurrentWorkspaceType(this.$SectionTypes, function() {
						const detailId = this.getDetailId("SysModule");
						this.sandbox.publish("UpdateWorkplaceType", this.$IsCurrentWorkplaceSSP, [detailId]);
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this._updateIsWebAppWorkplaceTypeAttribute();
					if (this.getIsFeatureEnabled("UseTypedWorkplaces") && this.isEditMode()) {
						this.$TypeCode = this.$Type && this.$Type.Code;
						this.initCurrentWorkspaceType();
					}
					this._afterSysApplicationClientTypeChanged();
				},

				/**
				 * Sets "SectionTypes" attribute.
				 * @overridden
				 * @param {Object} result Section types enum (values: "General" or "SSP").
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				processedSectionTypes: function(result, callback, scope) {
					const sectionTypes = JSON.parse(result.GetSectionTypesResult);
					this.$SectionTypes = sectionTypes;
					this.initCurrentWorkspaceType(sectionTypes, callback, scope);
				},

				/**
				 * Initializes "IsCurrentWorkplaceSSP" attribute.
				 * @protected
				 * @param {Object} sectionTypes Section types enum (values: "General" or "SSP").
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				initCurrentWorkspaceType: function(sectionTypes, callback, scope) {
					if (this.getIsFeatureEnabled("UseTypedWorkplaces") && !this.Terrasoft.isNull(this.$TypeCode)) {
						this.$IsCurrentWorkplaceSSP = this.$TypeCode == ConfigurationConstants.WorkplaceTypesCodes.SSP;
						this.Ext.callback(callback, scope || this);
						return;
					}
					const config = {
						data: {
							"type": sectionTypes.SSP
						},
						serviceName: "WorkplaceService",
						methodName: "GetWorkplacesByType"
					};
					this.callService(config, function(result) {
						const workplacesByType = result.GetWorkplacesByTypeResult;
						if (workplacesByType) {
							const currentWorkplaceSSP = Ext.Array.findBy(workplacesByType, function(item) {
								return JSON.parse(item).Id === this.$PrimaryColumnValue;
							}, this);
							this.$IsCurrentWorkplaceSSP = !Ext.isEmpty(currentWorkplaceSSP);
						}
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc Terrasoft.BaseEntityPage#save
				 * @override
				 */
				save: function(config) {
					const parentMethod = this.getParentMethod(this, arguments);
					if (!this.isAddMode()) {
						parentMethod();
						return;
					}
					this.saveUsingApi(config);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#onSaved
				 */
				onSaved: function() {
					if (this.canSetHomePageForWorkplace()) {
						serviceHelper.callService("WorkplaceService", "ResetScriptCache", () => {
							this.sandbox.publish("RefreshWorkplace");
						});
					}
					const config = {
						serviceName: "WorkplaceService",
						methodName: "ResetWorkplaceCache"
					};
					this.callService(config, () => {}, this);
					this.callParent(arguments);
				},

				/**
				 * Saves new workplace using workplace API.
				 * @protected
				 * @param {Object} config Save card config.
				 */
				saveUsingApi: function(config) {
					const sectionTypes = this.$SectionTypes || {};
					const type = this.getIsFeatureEnabled("UseTypedWorkplaces")
						? this.$TypeCode
						: sectionTypes.GENERAL;
					const serviceConfig = {
						data: {
							name: this.$Name,
							type,
							homePageUId: this.$HomePageUId,
							clientApplicationTypeId: this.$SysApplicationClientType?.value
						},
						serviceName: "WorkplaceService",
						methodName: "CreateWorkplace"
					};
					this.callService(serviceConfig, function(result) {
						this._updateCardState(result);
						this.Terrasoft.chain(this.saveDetailsInChain, function() {
							this.onSaved({success: Boolean(result?.CreateWorkplaceResult)}, config);
						}, this);
					}, this);
				},

				/**
				 * @private
				 */
				_getWorkplaceTypesNotAllowedForHomePage: function() {
					const workplaceTypesCodes = ConfigurationConstants.WorkplaceTypesCodes;
					return [
						workplaceTypesCodes.LIMITED_INTERNAL,
						workplaceTypesCodes.SELF_SERVICE
					];
				},

				/**
				 * Determines whenever user can set the home page for workplace.
				 * @protected
				 */
				canSetHomePageForWorkplace: function() {
					return this.$IsWebApplicationWorkplaceType
						&& !this.$IsCurrentWorkplaceSSP
						&& Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace")
						&& !this._getWorkplaceTypesNotAllowedForHomePage().includes(this.$TypeCode);
				},

				/**
				 * @private
				 */
				_setCanEnableEditButton: function() {
					let canShow = true;
					if (this.$HomePageUId && this.$AvailableHomePages) {
						const item = this.$AvailableHomePages.findByFn((item) => item.uId === this.$HomePageUId);
						canShow = item && item.isAngularPage;
					}
					this.$CanEnableEditButton = this.canSetHomePageForWorkplace() && canShow;
				},

				/**
				 * @protected
				 */
				getHomePageDesignerButtonImage: function() {
					const imageName = this.$HomePageUId ? "OpenButtonImage" : "AddButtonImage";
					return this.get("Resources.Images." + imageName);
				},

				/**
				 * Returned edit home button page hint.
				 * @protected
				 * @return {String}
				 */
				getHomePageDesignerButtonHint: function() {
					let stringName;
					if (this.$CanEnableEditButton) {
						stringName = this.$HomePageUId
							? "OpenHomePageDesignerButtonHintCaption"
							: "AddNewHomePageButtonHintCaption";
					} else {
						stringName = "CannotEditPageHintCaption";
					}
					return this.get("Resources.Strings." + stringName);
				},

				/**
				 * Returned copy home button page hint.
				 * @protected
				 * @return {String}
				 */
				getCopyHomePageDesignerButtonHint: function() {
					const stringName = this.getCopyButtonEnabled()
						? "CopyHomePageDesignerButtonHintCaption"
						: "CannotCopyPageHintCaption";
					return this.get("Resources.Strings." + stringName);
				},

				/**
				 * @private
				 */
				_getInterfaceDesignerUrl: function(pageUId, operation, caption) {
					return this._getDesignerUrl("InterfaceDesigner", pageUId, operation, caption);
				},

				/**
				 * @private
				 */
				_getHomePageDesignerUrl: function(pageUId, operation, caption) {
					return this._getDesignerUrl("HomePageDesigner", pageUId, operation, caption);
				},

				/**
				 * @private
				 */
				_getDesignerUrl: function(designerName, pageUId, operation, caption) {
					let url = Terrasoft.workspaceBaseUrl + "/ClientApp/#/" + designerName;
					if (operation) {
						url += "/" + operation;
					}
					if (pageUId) {
						url += "/" + pageUId;
					}
					if (caption && !pageUId) {
						const captionParam = new URLSearchParams();
						captionParam.set("workplace", caption);
						url += "?" + captionParam.toString();
					}
					return url;
				},

				/**
				 * @private
				 */
				_showCanNotChangeAdminOperationMessage: function() {
					const localizableStrings = resources.localizableStrings;
					let message = localizableStrings.RightsErrorMessage;
					message += Ext.String.format(localizableStrings.CanNotChangeAdminOperationMessage, "CanManageSolution");
					Terrasoft.showInformation(message);
				},

				_getGoogleAction: function(action) {
					let tag = "HomePageDesigner_OpenFromWorkplace";
					if (action) {
						tag += "_" + action;
					}
					return tag;
				},

				_getGoogleTagData: function(tag) {
					const sandbox = this.sandbox;
					return {
						action: tag,
						schemaName: this.name,
						moduleName: sandbox.moduleName,
						virtualUrl: Terrasoft.workspaceBaseUrl + "/" + sandbox.id
					};
				},

				_sendGoogleAnalytics: function(action) {
					const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
					if (!isGoogleTagManagerEnabled) {
						return;
					}
					const tag = this._getGoogleAction(action);
					const data = this._getGoogleTagData(tag);
					Terrasoft.GoogleTagManagerUtilities.actionModule(data);
				},


				_getRemoveButtonConfig: function() {
					var returnCode = Terrasoft.MessageBoxButtons.YES.returnCode;
					var caption = this.get("Resources.Strings.RemoveButtonCaption");
					return Terrasoft.getButtonConfig(returnCode, caption);
				},


				/**
				 * @protected
				 */
				openHomePageDesigner: function() {
					if (!this.$CanDesignPage) {
						return this._showCanNotChangeAdminOperationMessage();
					}
					this._isAddNewHomePage = !this.$HomePageUId;
					const operation = this._isAddNewHomePage ? "add": "edit";
					const url = this._isAddNewHomePage
						? this._getHomePageDesignerUrl(this.$HomePageUId, operation, this.$Name)
						: this._getInterfaceDesignerUrl(this.$HomePageUId);
					this._sendGoogleAnalytics(operation);
					window.open(url, "_blank");
				},

				/**
				 * @protected
				 */
				copyHomePageDesigner: function() {
					this.save({
						isSilent: true,
						callback: ({success}) => {
							if (!success) {
								return;
							}
							if (!this.$CanDesignPage) {
								return this._showCanNotChangeAdminOperationMessage();
							}
							this._isCopyHomePage = true;
							const operation = "copy";
							const url = this._getInterfaceDesignerUrl(this.$HomePageUId, operation);
							this._sendGoogleAnalytics(operation);
							window.open(url, "_blank");
						},
						scope: this
					});
				},

				/**
				 * Returns flag that indicates when to enable copy button
				 * @protected
				 */
				getCopyButtonEnabled: function() {
					return this.$AvailableHomePages?.findByFn((item) => item.uId === this.$HomePageUId)?.isAngularPage;
				},

				/**
				 * @inheritdoc WizardUtilities#initCanDesignPage
				 * @override
				 */
				initCanDesignPage: function(callback, scope) {
					this.canUseWizard(function(result) {
						this.set("CanDesignPage", result);
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.callParent(arguments);
					Terrasoft.ServerChannel.un(Terrasoft.ServerChannelSender.BROADCAST_MESSAGE, this._onServerMessage,
						this);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var detailsIds = [this.getDetailId("SysAdminUnit"), this.getDetailId("SysModule")];
					var scope = this;
					this.sandbox.subscribe("GetWorkplaceTypeCode", function(){
						return scope.$TypeCode;
					}, detailsIds);
					this.sandbox.subscribe("GetIsWebApplicationWorkplace", function() {
						return scope._getIsWebApplicationWorkplace(scope.$SysApplicationClientType?.value);
					}, detailsIds);
				},

				//endregion

				//region: Methods: Public

				onSysApplicationClientTypeChanged: function() {
					const currentClientType = this.$SysApplicationClientType;
					const prevClientType = this.$PrevSysApplicationClientType;
					if (currentClientType === prevClientType) {
						return;
					}
					const workplaceId = this.$Id;
					const serviceConfig = {
						data: {
							workplaceId: workplaceId
						},
						serviceName: "WorkplaceService",
						methodName: "GetWorkplaceSectionCount"
					};
					this.callService(serviceConfig, function(result) {
						if (!result || !result.success) {
							this.showConfirmationDialog(this.get("Resources.Strings.CallServiceErrorMessage"), () => {
								this.$SysApplicationClientType = prevClientType;
								this._updateIsWebAppWorkplaceTypeAttribute();
							});
							return;
						}
						if (result.value === 0) {
							this._afterSysApplicationClientTypeChanged();
							return;
						}
						this.showConfirmationDialog(this.get("Resources.Strings.ChangeApplicationTypeWarningMessage"),
							(returnCode) => {
							if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
								this._deleteAllSectionsFromWorkplace();
								return;
							}
							this.$SysApplicationClientType = prevClientType;
						}, [this._getRemoveButtonConfig(), this.Terrasoft.MessageBoxButtons.NO]);
					});
				},

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"bindTo": "Name",
						"layout": {"column": 0, "row": 0, "colSpan": 12}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "UseOnlyShell",
					"values": {
						"bindTo": "UseOnlyShell",
						"layout": {"column": 0, "row": 1, "colSpan": 12},
						"visible": {
							"bindTo": "IsWebApplicationWorkplaceType"
						},
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "SysApplicationClientType",
					"values": {
						"bindTo": "SysApplicationClientType",
						"controlConfig": {
							"className": "Terrasoft.ComboBoxEdit",
						},
						"visible": {
							"bindTo": "CanUseApplicationClientType"
						},
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"layout": {"column": 12, "row": 0, "colSpan": 10}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "HomePageLookup",
					"values": {
						"caption": "$Resources.Strings.HomePageCaption",
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"controlConfig": {
							"className": "Terrasoft.ComboBoxEdit",
							"prepareList": "$_prepareHomePageList"
						},
						"visible": {
							"bindTo": "canSetHomePageForWorkplace"
						},
						"layout": {"column": 12, "row": 1, "colSpan": 10}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "HomePageButtonContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["home-page-button-container"],
						"layout": {"column": 22, "row": 1, "colSpan": 2},
						"visible": {
							"bindTo": "canSetHomePageForWorkplace"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OpenHomePageDesignerButton",
					"parentName": "HomePageButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"hint": {
							"bindTo": "getHomePageDesignerButtonHint"
						},
						"imageConfig": {
							"bindTo": "getHomePageDesignerButtonImage"
						},
						"classes": {
							"wrapperClass": ["open-home-page-designer-button"]
						},
						"click": {"bindTo": "openHomePageDesigner"},
						"enabled": {
							"bindTo": "CanEnableEditButton"
						}
					}
				},
				{
					"operation": "insert",
					"name": "copyHomePageDesignerButton",
					"parentName": "HomePageButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"hint": {
							"bindTo": "getCopyHomePageDesignerButtonHint"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.CopyButtonImage"
						},
						"classes": {
							"wrapperClass": ["open-home-page-designer-button"]
						},
						"click": {"bindTo": "copyHomePageDesigner"},
						"enabled": {
							"bindTo": "HomePageUId",
							"bindConfig": {
								"converter": "getCopyButtonEnabled"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "SettingsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {bindTo: "Resources.Strings.SettingsTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "SysModule",
					"values": {
						"itemType": Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "SysAdminUnit",
					"values": {
						"itemType": Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				}
			]/**SCHEMA_DIFF*/
		};
	});
