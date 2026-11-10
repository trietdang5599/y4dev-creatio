define("SysAdminUnitSectionV2", ["SysAdminUnitSectionV2Resources", "GridUtilitiesV2", "ServiceHelper"],
	function(resources, GridUtilitiesV2, ServiceHelper) {
		return {
			entitySchemaName: "SysAdminUnit",
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				* Redirect link to creatio page with comparison license editions.
				* Uses when show info dialog for user which creatio has license with restrictions.
				*/
				"CreatioEditionsPageLink": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "https://creatio.com"
				}
			},
			methods: {
				/**
				 * @inheritDoc Terrasoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initLicOperation();
					this.loadCreatioComparePlansLink();
				},

				initLicOperation: function() {
					ServiceHelper.callCoreService({ 
						serviceName: "LicenseService", 
						methodName: "GetLicOperationStatus", 
						data: {
							"licOperationCode": "CanUseLdap"
						}
					},
					function (response) {
						var result = response.GetLicOperationStatusResult;
						if(result.success) {
							this.set("CanUseLdap", result.licOperationStatus);
						}
					},
					this);
				},
				
				loadCreatioComparePlansLink: function() {
					this.Terrasoft.SysSettings.querySysSettingsItem("CreatioEditionsPageLink",
						function(value) {
							if (value && value !== Terrasoft.emptyString) {
								this.set("CreatioEditionsPageLink", value);
							}
						},
						this);
				},
				/**
				 * (##########) ######### ####### ############# # LDAP
				 * @protected
				 */
				syncWithLDAP: function() {
					var obsoleteMessage = this.Terrasoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "syncWithLDAP", "runLDAPSync"));
					this.runLDAPSync();
				},

				/**
				 * (##########) ######### ####### ####### ##### # ############# ## LDAP
				 * @protected
				 */
				importLDAPElements: function() {
					var obsoleteMessage = this.Terrasoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "importLDAPElements", "runLDAPSync"));
					this.runLDAPSync();
				},

				/**
				 * ########## ###### ####### ####### ######## ############# ############# # LDAP.
				 * @protected
				 * @return {Object} config ######, ####### ######## ######## #######, ######## ######, ######.
				 * ########### #######
				 */
				getLDAPSyncConfig: function() {
					var jobName = "RunSyncWithLDAP";
					var syncJobGroupName = "LDAP";
					var syncProcessName = "RunLDAPSync";
					var schedulerName = "LdapQuartzScheduler";
					var data = {
						JobName: jobName + Terrasoft.SysValue.CURRENT_USER.value,
						SyncJobGroupName: syncJobGroupName,
						SyncProcessName: syncProcessName,
						periodInMinutes: 0,
						recreate: true,
						schedulerName: schedulerName
					};
					var config = {
						serviceName: "SchedulerJobService",
						methodName: "CreateSyncJobWithResponse",
						data: data
					};
					return config;
				},

				/**
				 * ######### ####### ############# # LDAP
				 * @protected
				 */
				runLDAPSync: function() {
					this.showBodyMask();
					var canUseLdap = this.get("CanUseLdap");
					if(!canUseLdap) {
						this.showLicOperationAccessDeniedDialog();
						this.hideBodyMask();
						return;
					}
					this.callService(this.getLDAPSyncConfig(), function(response) {
								this.runLDAPSyncCallback.call(this, response.CreateSyncJobWithResponseResult);
							}, this);
				},

				/**
				* ####### ######### ###### ######## ############# # LDAP.
				* @protected
				 */
				runLDAPSyncCallback: function(response) {
					var message;
					if (response.success) {
						message = this.get("Resources.Strings.RunLDAPSuccessMessage");
					}
					else {
						var formatMessage = this.get("Resources.Strings.SyncProcessFail");
						var errorInfo = response.errorInfo;
						var error = errorInfo && errorInfo.message ? errorInfo.message : "";
						message = this.Ext.String.format(formatMessage, error);
					}
					this.hideBodyMask();
					if (message) {
						this.Terrasoft.utils.showInformation(message, null, null, {buttons: ["ok"]});
					}
				},

				/**
				* Opens dialog box with restriction message by lic operations and 
				* ability to open in a new window compare plans link.
				* @protected
				*/
				showLicOperationAccessDeniedDialog: function() {
					var message = resources.localizableStrings.LicOperationAccessDeniedMessage;
					var compareButtonCaption = resources.localizableStrings.EditionsComparePageButtonCaption;
					var comparePlansButtonCode = "comparePlans";
					var comparePlansButton = Terrasoft.getButtonConfig(comparePlansButtonCode, compareButtonCaption);
					Terrasoft.showConfirmation(message, function(returnCode) {
						if (returnCode === comparePlansButtonCode) {
							window.open(this.get("CreatioEditionsPageLink"));
						}
					}, ["close", comparePlansButton], this);
				},

				/**
				 * ########## ######### ######## #######.
				 * @protected
				 * @overridden
				 * @return {Terrasoft.BaseViewModelCollection} ########## ######### ######## ####### # ######.
				 * ########### #######
				 */
				getCustomSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getSyncWithLDAPButton());
					return actionMenuItems;
				},

				/**
				 * ########## ###### "################ # LDAP".
				 * @protected
				 * @return {Terrasoft.BaseViewModel} ########## ######.
				 */
				getSyncWithLDAPButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.SyncronizeWithLDAPButtonCaption"},
						"Click": {"bindTo": "runLDAPSync"}
					});
				}
			}
		};
	});