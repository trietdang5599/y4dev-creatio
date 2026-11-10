define("SystemDesigner", ["SystemDesignerResources", "RightUtilities", "PackageHelper",
	"ConfigurationConstants", "ConfigurationEnums", "ServiceHelper", "ProcessModuleUtilities", "ChangeLogUtilities",
	"WizardUtilities", "SystemOperationsPermissionsMixin", "ManageApplicationRouter", "css!IntroPage"
], function(resources, RightUtilities, PackageHelper, ConfigurationConstants, ConfigurationEnums, ServiceHelper,
		ProcessUtilities, ChangeLogUtilities) {
	return {
		mixins: {
			WizardUtilities: "Terrasoft.WizardUtilities",
			SystemOperationsPermissionsMixin: "Terrasoft.SystemOperationsPermissionsMixin",
			ManageApplicationRouter: "Terrasoft.ManageApplicationRouter"
		},
		attributes: {
			"CanManageProcessDesign": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanViewSysOperationAudit": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanImportFromExcel": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"WindowHeight": {
				dataValueType: Terrasoft.DataValueType.INTEGER,
				value: 300
			},

			"WindowWidth": {
				dataValueType: Terrasoft.DataValueType.INTEGER,
				value: 600
			},

			"IsSectionDesignerAvailable": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanAccessConfigurationSettings": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageWorkplaces": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageLogo": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageSectionPanelColorSettings": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			/**
			 * Parameter contains information about the availability of the partition directories to the current user.
			 */
			"CanManageChangeLog": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			/**
			 * Parameter contains information about the availability change log management for the current user.
			 */
			"CanManageAdministration": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageReports": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageMobileApplication": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"CanManageUsers": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			/**
			 * A sign to access the system configuration.
			 */
			"CanManageSolution": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			/**
			 * The parameter containing the information about the availability of the partition directories to the current user.
			 */
			"CanManageLookup": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			/**
			 * Selected package name.
			 */
			"SelectedPackage": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			},

			/**
			 * Flag install extension visible.
			 */
			"IsInstallExtensionsVisible": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Flag that indicates usage feature "InstalledApp"
			 */
			"UseFeatureInstalledApp": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Redirect link to creatio page with comparison license editions.
			 * Uses when show info dialog for user which creatio has license with restrictions.
			 */
			"CreatioEditionsPageLink": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: "https://creatio.com"
			},

			/**
			 * @override
			 */
			"IsMobilePannerVisible": {
				value: false
			},

			/**
			 * @override
			 */
			"IsSdkPanelVisible": {
				value: true
			},

			/**
			 * @override
			 */
			"IsSocialAccountsPanelVisible": {
				value: false
			}

		},
		properties: {
			_useNewApplicationManagement: false
		},
		methods: {

			//region Methods: Private

			/**
			 * Returns features page visible flag.
			 * @private
			 * @return {Boolean}
			 */
			getIsFeaturesPageVisible: function() {
				return Terrasoft.isDebug && Terrasoft.SysValue.CURRENT_MAINTAINER.value === "Terrasoft";
			},

			/**
			 * Opens features page.
			 * @private
			 */
			openFeaturesPage: function() {
				const featuresPageUrl = Terrasoft.workspaceBaseUrl + "/Nui/ViewModule.aspx#Features";
				window.open(featuresPageUrl);
				return false;
			},

			/**
			 * Opens package market page.
			 * @private
			 */
			openPackageMarket: function() {
				const packageMarketUrl = Terrasoft.workspaceBaseUrl + "/NUI/ViewModule.aspx?vm=PackageMarketModule";
				window.open(packageMarketUrl);
				return false;
			},

			/**
			 * Returns package market visible flag.
			 * @private
			 * @return {Boolean} Package market visible flag.
			 */
			getPackageMarketVisible: function() {
				return this.getIsFeatureEnabled("PackageMarket");
			},

			/**
			 * Returns change log visible flag.
			 * @private
			 * @return {Boolean} Change log visible flag.
			 */
			getChangeLogVisible: function() {
				return this.getIsFeatureEnabled("NewChangeLogUI");
			},

			/**
			 * Returns is SetupAppearance visible flag.
			 * @private
			 * @return {Boolean} Change log visible flag.
			 */
			getIsNavigateToSetupAppearanceVisible: function() {
				return Terrasoft.isAngularHost;
			},

			/**
			 * Returns a flag indicating whether link to the new license manager should be visible.
			 * @private
			 * @return {Boolean}
			 */
			_getLicenseManagerVisible: function() {
				return this.getIsFeatureEnabled("NewLicenseManagerUI");
			},

			/**
			 * Initialize section designer rights.
			 * @private
			 */
			onStartSectionDesignerClick: function() {
				if (this.get("IsSectionDesignerAvailable") == null) {
					this.getIsSectionDesignerAvailable(function() {
						this.startSectionDesigner();
					}, this);
				} else {
					this.startSectionDesigner();
				}
				return false;
			},

			/**
			 * Initialize advanced settings rights.
			 * @private
			 */
			onNavigateToConfigurationSettingsClick: function() {
				if (this.get("CanAccessConfigurationSettings") == null) {
					ServiceHelper.callService("MainMenuService", "GetCanAccessConfigurationSettings", function(response) {
						if (response) {
							const result = response.GetCanAccessConfigurationSettingsResult;
							const value = result && Ext.isBoolean(result);
							this.set("CanAccessConfigurationSettings", Boolean(value));
							this.navigateToConfigurationSettings();
						}
					}, {}, this);
				} else {
					this.navigateToConfigurationSettings();
				}
				return false;
			},

			/**
			 * Checks the rights to change operation settings.
			 * @private
			 * @param {Object} options Check parameters right.
			 * @param {String} options.operationName Operation code whose rights we want to check.
			 * @param {Function} options.callback The callback function after getting the value right.
			 */
			checkRights: function(options) {
				const operation = options.operationName;
				const callback = options.callback;
				const currentRights = this.get(operation);
				if (currentRights != null) {
					callback.call(this, currentRights);
				}
				RightUtilities.checkCanExecuteOperation({operation: operation}, function(result) {
					this.set(operation, result);
					callback.call(this, result);
				}, this);
			},

			/**
			 * ######### ###### #########.
			 * @private
			 */
			navigateToSectionPanelSettingsSection: function() {
				if (this.get("CanCustomizeBranding") === true) {
					this.sandbox.requireModuleDescriptors(["SysSectionPanelSettingsModule"], function() {
						this.sandbox.publish("PushHistoryState", {hash: "SysSectionPanelSettingsModule"});
					}, this);
				} else {
					this.showLicOperationAccessDeniedDialog();
				}
			},

			/**
			 * ######### ###### ######### ######## #####.
			 * @private
			 */
			navigateToSetupAppearance: function() {
				if (this.get("CanCustomizeBranding") === true) {
					const url = Terrasoft.getUIHostUrl() + "#PageSchemaViewModule/SetupAppearance";
					window.open(url, "_self");
				} else {
					this.showLicOperationAccessDeniedDialog();
				}
			},

			/**
			 * ######### ###### "########## ########" ### ########## ######### # ######.
			 * @private
			 */
			navigateToProcessLibSection: function() {
				this.openSection("VwProcessLibSection");
			},

			/**
			 * ######### ###### "###### ########" ### ########## ######### # ######.
			 * @private
			 */
			navigateToProcessLogSection: function() {
				this.openSection("SysProcessLogSectionV2");
			},

			/**
			 * Opens process designer.
			 * @private
			 */
			navigateToProcessDesigner: function() {
				ProcessUtilities.showProcessSchemaDesigner();
			},

			/**
			 * Opens page wizard.
			 * @private
			 */
			navigateToPageWizard: function() {
				ProcessUtilities.showPageTemplateLookup();
			},

			/**
			 * ######### ###### "###### ######" ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysOperationAuditSection: function() {
				if (this.get("CanUseAuditLog") === true) {
					this.openSection("SysOperationAuditSectionV2");
				} else {
					this.showLicOperationAccessDeniedDialog();
				}
			},

			/**
			 * ######### #### ####### ###### ## Excel.
			 * @private
			 */
			navigateToImportFromExcel: function() {
				const url = Terrasoft.workspaceBaseUrl + ConfigurationConstants.ApplicationPage.ExcelImport;
				const windowFeatures = "height=" + this.get("WindowHeight") + ",width=" + this.get("WindowWidth");
				window.open(url, "_blank", windowFeatures);
			},

			/**
			 * ######### ######## ########## ##########.
			 * @private
			 */
			navigateToMobileAppDesignerSection: function() {
				Terrasoft.PackageManager.getCurrentPackageUId(function(currentPackageUId) {
					Terrasoft.DomainCache.setItem("SectionDesigner_CurrentPackageUId", currentPackageUId);
					this.showBodyMask();
					const newHash = Terrasoft.combinePath("SectionModuleV2", "SysMobileWorkplaceSection");
					this.sandbox.publish("PushHistoryState", {hash: newHash});
				}.bind(this));
			},

			/**
			 * Check available and open section designer.
			 * @private
			 */
			startSectionDesigner: function() {
				if (this.getCanDesignWizard()) {
					this.openSectionWindow("New");
				} else {
					this.showPermissionsErrorMessage("CanManageSolution");
				}
			},

			/**
			 * ######### ###### ####### ### ########## ######### # ######.
			 * @private
			 */
			startDetailWizard: function() {
				this.mixins.WizardUtilities.openDetailWindow("New");
			},

			/**
			 * ######### ####### ###### Platform # ####### #### ### ####### # ####.
			 * @private
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ########.
			 */
			getIsSectionDesignerAvailable: function(callback, scope) {
				PackageHelper.getIsPackageInstalled(ConfigurationConstants.PackageUId.CrtPlatform7x, function(isPackageInstalled) {
					if (isPackageInstalled) {
						require(["SectionDesignerUtils"], function(module) {
							module.getCanUseSectionDesigner(function(result) {
								this.set("IsSectionDesignerAvailable", result.canUseSectionDesigner);
								callback.call(scope);
							}.bind(this));
						}.bind(this));
					} else {
						this.set("IsSectionDesignerAvailable", false);
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * ######### ########## ############# ### ########## ######### # ######.
			 * @private
			 */
			navigateToConfigurationSettings: function() {
				if (this.get("CanAccessConfigurationSettings") === true) {
					var url = Terrasoft.workspaceBaseUrl + "/ClientApp/#/WorkspaceExplorer";
					window.open(url, "_blank");
				} else {
					this.showPermissionsErrorMessage("CanManageSolution");
				}
			},

			/**
			 * ######### ###### ######### ####### #### ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysWorkPlaceSection: function() {
				this.showBodyMask();
				this.openSection("SysWorkplaceSectionV2");
			},

			/**
			 * ######### ###### ######### ############# ######### ### ########## ######### ## ######.
			 * @private
			 */
			navigateToSysLogoSettings: function() {
				if (this.get("CanCustomizeBranding") === true) {
					this.sandbox.publish("PushHistoryState", {
						hash: "SysLogoSettingsModule"
					});
				} else {
					this.showLicOperationAccessDeniedDialog();
				}
			},

			/**
			 * @private
			 */
			navigateToReportSetup: function() {
				const url = Terrasoft.workspaceBaseUrl + "/ClientApp/#/Printables";
				window.open(url, "_blank");
			},

			/**
			 * ######### #### ################# #### ########.
			 * @private
			 */
			navigateToObjectRightsManagement: function() {
				let url = Terrasoft.workspaceBaseUrl;
				url += this.getIsFeatureEnabled("NewRightsManagementUI")
					? "/ClientApp/#/AdministratedObjects"
					: ConfigurationConstants.ApplicationPage.ObjectRightsManagement;
				window.open(url, "_blank");
			},

			/**
			 * Open change log management window.
			 * @private
			 */
			navigateToChangeLogManagement: function() {
				if (this.getIsFeatureEnabled("NewChangeLogUI")) {
					ChangeLogUtilities.openChangeLogSettings();
				}
			},

			/**
			 * Open license manager window.
			 * @private
			 */
			_navigateToLicenseManager: function() {
				const url = Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "ClientApp/#/LicenseManager");
				window.open(url, "_blank");
			},

			/**
			 * ######### ############# ############### #### # ####### ################# #############.
			 * @private
			 */
			navigateToOrgRoles: function() {
				this.goToSysAdminUnitSection("SysAdminUnitPageV2");
			},

			/**
			 * ######### ############# ############## #### # ####### ################# #############.
			 * @private
			 */
			navigateToFuncRoles: function() {
				this.goToSysAdminUnitSection("SysAdminUnitFuncRolePageV2");
			},

			/**
			 * ######### ####### # ###### SysAdminUnitSection.
			 * @private
			 * @param {String} pageName ######## ######## ##############, ####### ##### ####### ### ######## # ######.
			 */
			goToSysAdminUnitSection: function(pageName) {
				const primaryId = ConfigurationConstants.SysAdminUnit.Id.AllEmployees;
				this.sandbox.publish("PushHistoryState", {
					hash: Terrasoft.combinePath("SectionModuleV2", "SysAdminUnitSectionV2",
						pageName, ConfigurationEnums.CardState.Edit, primaryId),
					stateObj: {
						module: "SectionModuleV2",
						operation: ConfigurationEnums.CardState.Edit,
						primaryColumnValue: primaryId,
						schemas: [
							this.name,
							pageName
						],
						workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
						moduleId: this.sandbox.id,
						skipCardHistoryStateActualization: true
					}
				});
			},

			/**
			 * ######### ############# ############ # ####### ################# #############.
			 * @private
			 */
			navigateToUsers: function() {
				this.openSection("UsersSectionV2");
			},


			/**
			 * Navigates to Content Security Policy setup interface.
			 * @private
			 */
			navigateToCSP: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "Section/ContentSecurityPolicy_ListPage"
				});
			},

			/**
			 * ######### ###### ########### ####### ########.
			 * @private
			 */
			navigateToSysAdminOperationSection: function() {
				this.openSection("SysAdminOperationSectionV2");
			},

			_initManageApplicationRouter: function (callback, scope) {
				this.mixins.ManageApplicationRouter.init.call(this, callback, scope);
			},

			_loadCreatioComparePlansLink: function() {
				this.Terrasoft.SysSettings.querySysSettingsItem("CreatioEditionsPageLink",
					function(value) {
						if (value && value !== "") {
							this.set("CreatioEditionsPageLink", value);
						}
					},
					this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @protected
			 * @return {Object}.
			 */
			getLicOperationCodes: function() {
				return {
					"licOperationCodes": ["CanUseAuditLog", "CanUseLdap", "CanCustomizeBranding"]
				};
			},

			/**
			 * @protected
			 * @param {Function} callback.
			 * @param {Object} scope.
			 */
			callLicenseService: function(config, callback, scope) {
				ServiceHelper.callCoreService({
					serviceName: "LicenseService",
					methodName: config.methodName,
					data: config.data
				}, callback	 , this);
			},

			/**
			 * @protected
			 * @param {Function} callback.
			 * @param {Object} scope.
			 */
			initUserLicOperationsRights: function(callback, scope) {
				var licOperationCodes = this.getLicOperationCodes();
				var config = {
					methodName: "GetLicOperationStatuses",
					data: licOperationCodes
				};
				this.callLicenseService(config, function(result) {
					if (result.GetLicOperationStatusesResult && result.GetLicOperationStatusesResult.success) {
						Terrasoft.each(result.GetLicOperationStatusesResult.licOperationStatuses, function(licOperationStatus) {
							this.set(licOperationStatus.Key, licOperationStatus.Value);
						}, this);
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initUserOperationsRights(function() {
						this.initUserLicOperationsRights(function() {
							this._loadCreatioComparePlansLink();
							this.setPackageZipFileStorageFeatureParameter();
							this.setDefaultParameters();
							this.set("ProductEdition", "BPMS");
							this._initManageApplicationRouter(callback, scope);
						}, this);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.hideBodyMask();
			},

			/**
			 * @inheritdoc Terrasoft.configuration.mixins.WizardUtilities#getCanDesignWizard
			 * @override
			 */
			getCanDesignWizard: function() {
				return this.get("IsSectionDesignerAvailable");
			},

			/**
			 * ########## ###### ######## ######## # ######## ####.
			 * @protected
			 * @return {Object} ###### ########.
			 */
			getOperationRightsDecoupling: function() {
				return {
					"navigateToProcessLibSection": "CanManageProcessDesign",
					"navigateToProcessLogSection": "CanManageProcessLogSection",
					"navigateToProcessDesigner": "CanManageProcessDesign",
					"navigateToPageWizard": "CanManageProcessDesign",
					"navigateToOrgRoles": "CanManageUsers",
					"navigateToFuncRoles": "CanManageUsers",
					"navigateToUsers": "CanManageUsers",
					"navigateToSysOperationAuditSection": "CanViewSysOperationAudit",
					"navigateToImportFromExcel": "CanImportFromExcel",
					"navigateToSysWorkPlaceSection": "CanManageWorkplaceSettings",
					"navigateToSysLogoSettings": "CanManageLogo",
					"navigateToSetupAppearance": "CanManageSolution",
					"startDetailWizard": "CanManageSolution",
					"navigateToObjectRightsManagement": "CanManageAdministration",
					"navigateToReportSetup": "CanManageReports",
					"navigateToSysAdminOperationSection": "CanManageAdministration",
					"navigateToMobileAppDesignerSection": "CanManageMobileApplication",
					"navigateToSectionPanelSettingsSection": "CanManageSectionPanelColorSettings",
					"navigateToSysSettings": "CanManageSysSettings",
					"navigateToLookupSection": "CanManageLookups",
					"navigateToInstalledApp": "CanManageSolution",
					"navigateToChangeLogManagement": "CanManageChangeLog",
					"navigateToCSP": "CanManageSolution",
					"_navigateToLicenseManager": "CanManageLicUsers"
				};
			},

			/**
			 * ############## ###### ########## ############ ## ### ############ ########.
			 * @protected
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ###### ######### ####### ######### ######.
			 */
			initUserOperationsRights: function(callback, scope) {
				const getOperationRightsDecoupling = this.getOperationRightsDecoupling();
				const operationRightsNames = Ext.Object.getValues(getOperationRightsDecoupling);
				const uniqueOperationNames = [];
				Terrasoft.each(operationRightsNames, function(operationName) {
					if (uniqueOperationNames.indexOf(operationName) < 0) {
						uniqueOperationNames.push(operationName);
					}
				}, this);
				if (uniqueOperationNames.indexOf("CanViewConfiguration") < 0) {
					uniqueOperationNames.push("CanViewConfiguration");
				}
				RightUtilities.checkCanExecuteOperations(uniqueOperationNames, function(result) {
					Terrasoft.each(result, function(operationRight, operationName) {
						this.set(operationName, operationRight);
					}, this);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * ######### ########## ######## # ######### #### ## ###. #### #### ###, ####### #########.
			 * @protected
			 * @return {boolean} ########## false ### ########### ######### ####### ####### ## ######.
			 */
			invokeOperation: function() {
				const operationName = arguments[1] || arguments[0];
				const operationRightsDecoupling = this.getOperationRightsDecoupling();
				const rightsName = operationRightsDecoupling[operationName];
				if (!Ext.isEmpty(rightsName) && !this.get(rightsName) && !this.get("CanViewConfiguration")) {
					this.showPermissionsErrorMessage(rightsName);
				} else {
					const operation = this[operationName];
					if (!Ext.isEmpty(operation) && Ext.isFunction(operation)) {
						operation.call(this);
					}
				}
				return false;
			},

			/**
			 * Opens section using section schema name.
			 * @protected
			 * @param {String} sectionSchemaName Section schema name.
			 */
			openSection: function(sectionSchemaName) {
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/" + sectionSchemaName
				});
			},

			/**
			 * ######### ####### # ###### ############.
			 * @protected
			 */
			navigateToSysSettings: function() {
				this.openSection("SysSettingsSection");
			},

			/**
			 * ######### ####### # ###### ############.
			 * @protected
			 */
			navigateToLookupSection: function() {
				const lookupModuleStructure = Terrasoft.configuration.ModuleStructure.Lookup;
				if (lookupModuleStructure) {
					const newHash = Terrasoft.combinePath(lookupModuleStructure.sectionModule,
						lookupModuleStructure.sectionSchema);
					this.sandbox.publish("PushHistoryState", {hash: newHash});
				}
			},

			/**
			 * Sets value of the parameters.
			 * @protected
			 */
			setDefaultParameters: Terrasoft.emptyFn,

			/**
			 * Opens installed application page.
			 * @protected
			 */
			navigateToInstalledApp: function() {
				this.openInstaledApplications();
			},

			/**
			 * Opens dialog box with restriction message by lic operations and
			 * ability to open in a new window compare plans link.
			 * @protected
			 */
			showLicOperationAccessDeniedDialog: function() {
				const message = resources.localizableStrings.LicOperationAccessDeniedMessage;
				const compareButtonCaption = resources.localizableStrings.EditionsComparePageButtonCaption;
				const comparePlansButtonCode = "comparePlans";
				const comparePlansButton = Terrasoft.getButtonConfig(comparePlansButtonCode, compareButtonCaption);
				Terrasoft.showConfirmation(message, function(returnCode) {
					if (returnCode === comparePlansButtonCode) {
						window.open(this.get("CreatioEditionsPageLink"));
					}
				}, ["close", comparePlansButton], this);
			},

			getIsOldSectionWizardVisible: function() {
				return this.getIsFeatureEnabled("ShowOldSectionWizardLinks"); 
			},

			//endregion

			//region Methods: deprecated

			/**
			 * @deprecated
			 */
			defineExistentConfigurationPackage: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			initInstallPackages: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			getInstallPackages: function() {
				return [];
			},

			/**
			 * @deprecated
			 */
			getInstallPackagesConfig: function() {
				return {};
			},

			/**
			 * @deprecated
			 */
			setExistentConfigurationPackage: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			setPackageZipFileStorageFeatureParameter: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			loadExistentConfigurationPackage: function(installPackages, callback, scope) {
				callback.call(scope);
			},

			/**
			 * @deprecated
			 */
			updatePropertyExistentPackages: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			createExistentConfigurationPackageSelect: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			setExistentConfigurationPackageFilters: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			initParametersEvent: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			initLinkCaption: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			onInstallPackageClick: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			setSelectedPackage: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			onConfirm: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			installPackage: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			getSelectedPackage: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			responseInstallFromStorageHandler: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			responseServiceHandler: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			getSysSettingPackageUrlName: Terrasoft.emptyFn,

			/**
			 * @deprecated
			 */
			onFilesSelected: Terrasoft.emptyFn

			//endregion
		},
		diff: [
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"markerValue": "system-designer-page"
				}
			},
			{
				"operation": "insert",
				"name": "ProcessTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ProcessCaption"},
					"cls": ["process", "designer-tile"],
					"icon": resources.localizableImages.ProcessIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessDesigner",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessDesignerLinkCaption"},
					"tag": "navigateToProcessDesigner",
					"click": {"bindTo": "invokeOperation"},
					"visible": Terrasoft.isDebug || Terrasoft.Features.getIsEnabled("GoToProcessDesigner")
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "PageWizard",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.PageWizardLinkCaption"},
					"tag": "navigateToPageWizard",
					"click": {"bindTo": "invokeOperation"},
					"visible": Terrasoft.isDebug || Terrasoft.Features.getIsEnabled("GoToProcessDesigner")
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessLibrary",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessLibraryLinkCaption"},
					"tag": "navigateToProcessLibSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessLog",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessLogLinkCaption"},
					"tag": "navigateToProcessLogSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "UsersTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.UsersCaption"},
					"cls": ["sales-tile", "designer-tile"],
					"icon": resources.localizableImages.UsersIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "Users",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.UsersLinkCaption"},
					"tag": "navigateToUsers",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "OrgRoles",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OrgRolesLinkCaption"},
					"tag": "navigateToOrgRoles",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "FuncRoles",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.FuncRolesLinkCaption"},
					"tag": "navigateToFuncRoles",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "ObjectRightsManagement",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ObjectRightsManagementLinkCaption"},
					"tag": "navigateToObjectRightsManagement",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "OperationRightsManagement",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OperationRightsManagementLinkCaption"},
					"tag": "navigateToSysAdminOperationSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "AuditLog",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.AuditLogLinkCaption"},
					"tag": "navigateToSysOperationAuditSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "ChangeLog",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ChangeLogLinkCaption"},
					"tag": "navigateToChangeLogManagement",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getChangeLogVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "LicenseManager",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LicenseManagerLinkCaption"},
					"tag": "_navigateToLicenseManager",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "_getLicenseManagerVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "SecurityTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SecurityCaption"},
					"icon": resources.localizableImages.SecuritySectionIcon,
					"cls": ["sales-tile", "designer-tile"],
					"visible": Terrasoft.Features.getIsEnabled("UseCspUI"),
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SecurityTile",
				"name": "CSP",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.CSPCaption"},
					"tag": "navigateToCSP",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "IntegrationTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.IntegrationCaption"},
					"cls": ["settings", "designer-tile"],
					"icon": resources.localizableImages.IntegrationIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "ExcelImport",
				"index": 0,
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ExcelImportLinkCaption"},
					"tag": "navigateToImportFromExcel",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "InstallExtensionsTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ApplicationManagementCaption"},
					"cls": ["extensions", "designer-tile"],
					"icon": resources.localizableImages.InstallExtensionsIcon,
					"visible": {"bindTo": "IsInstallExtensionsVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "InstallExtensionsTile",
				"name": "InstalledAppLink",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ApplicationHubCaption"},
					"visible": {"bindTo": "UseFeatureInstalledApp"},
					"tag": "navigateToInstalledApp",
					"click": {"bindTo": "invokeOperation"},
					"isNew": false
				}
			},
			{
				"operation": "insert",
				"name": "SystemSettingsTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SystemSettingsCaption"},
					"cls": ["analytics", "designer-tile"],
					"icon": resources.localizableImages.SystemSettingsIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "Features",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.FeaturesPage"},
					"click": {"bindTo": "openFeaturesPage"},
					"visible": {"bindTo": "getIsFeaturesPageVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "PackageMarket",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.PackageMarketCaption"},
					"click": {"bindTo": "openPackageMarket"},
					"visible": {"bindTo": "getPackageMarketVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "LookupSection",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LookupsLinkCaption"},
					"tag": "navigateToLookupSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "SysSettingsSection",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysSettingsLinkCaption"},
					"tag": "navigateToSysSettings",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "ReportSetup",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ReportSetupLinkCaption"},
					"tag": "navigateToReportSetup",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "SectionDesigner",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SectionDesignerLinkCaption"},
					"click": {"bindTo": "onStartSectionDesignerClick"},
					"visible": {"bindTo": "getIsOldSectionWizardVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "DetailWizard",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.DetailWizardLinkCaption"},
					"tag": "startDetailWizard",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getIsOldSectionWizardVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "MobileAppDesignerLink",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.MobileAppDesignerLinkCaption"},
					"tag": "navigateToMobileAppDesignerSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "SystemViewTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SystemViewCaption"},
					"cls": ["basis", "designer-tile"],
					"icon": resources.localizableImages.SystemViewIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysWorkplace",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysWorkplaceLinkCaption"},
					"tag": "navigateToSysWorkPlaceSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysLogoManagement",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysLogoManagementLinkCaption"},
					"tag": "navigateToSysLogoSettings",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysColorManagement",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysColorManagementLinkCaption"},
					"tag": "navigateToSectionPanelSettingsSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SetupAppearance",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SetupAppearanceLinkCaption"},
					"tag": "navigateToSetupAppearance",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getIsNavigateToSetupAppearanceVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "ConfigurationTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ConfigurationCaption"},
					"cls": ["configuration", "designer-tile"],
					"icon": resources.localizableImages.ConfigurationIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ConfigurationTile",
				"name": "ConfigurationLink",
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ConfigurationLinkCaption"},
					"click": {"bindTo": "onNavigateToConfigurationSettingsClick"}
				}
			},
			{
				"operation": "merge",
				"name": "AcademyPanel",
				"propertyName": "items",
				"parentName": "RightContainer",
				"values": {
					"bannerImage": resources.localizableImages.BPMSbanner,
					"wrapClassName": "bpms-banner"
				}
			},
			{
				"operation": "merge",
				"name": "TerrasoftAccountsLinksPanel",
				"values": {
					"wrapClassName": "system-designer"
				}
			}
		]
	};
});
