Terrasoft.configuration.Structures["MobilePushNotificationReceiver"] = {innerHierarchyStack: ["MobilePushNotificationReceiver"]};
/**
 * @class Terrasoft.configuration.PushNotificationReceiver
 * @abstract
 */
Ext.define("Terrasoft.configuration.PushNotificationReceiver", {
	extend: "Terrasoft.nativeApi.BasePushNotificationReceiver",
	alternateClassName: "Terrasoft.PushNotificationReceiver",

	/**
	 * @private
	 */
	synchronizeToCacheIfNeeded: function(modelName) {
		return new Promise(function(resolve) {
			if (!Terrasoft.ModelCache.isEnabled()) {
				resolve();
				return;
			}
			var cacheManager = Terrasoft.ModelCache.getManager(modelName);
			if (cacheManager && cacheManager instanceof Terrasoft.SynchronizableCacheManager) {
				Terrasoft.Mask.show();
				cacheManager.synchronizeToCache({
					cancellationId: Terrasoft.util.genGuid(),
				}).then(function() {
					Terrasoft.Mask.hide();
					resolve();
				}).catch(function(exception) {
					Terrasoft.Mask.hide();
					Terrasoft.Logger.error(exception);
				});
			} else {
				resolve();
			}
		});
	},

	/**
	 * @private
	 */
	openVisa: function(visaRecordId, visaEntityName) {
		Terrasoft.util.openFlutterPage({
			routeName: "VisaScreen",
			routeArguments: {
				recordId: visaRecordId,
				schemaName: visaEntityName
			},
			replace: false
		});
	},
	
	/**
	 * @private
	 */
	openFlutterEditPage: function(entityName, recordId) {
		if (!Ext.isFunction(Terrasoft.util.openFlutterPageByMetadata)) {
			Terrasoft.Logger.warn("There is no Terrasoft.util.openFlutterPageByMetadata in this version of app. You must update app");
			return;
		}
		Terrasoft.util.openFlutterPageByMetadata({
			type: Terrasoft.ScreenType.Edit,
			entityName: entityName,
			recordId: recordId,
			updateCache: true
		});
	},

	/**
	 * Adds grid page to history state if there is no page has been opened.
	 * @protected
	 * @virtual
	 *
	 * @param {String} modelName Name of model
	 */
	openGridIfNeeded: function(modelName) {
		var mainController = Terrasoft.util.getMainController();
		var mainPageView = mainController.getView();
		var cardIsEmpty = mainPageView.getCardIsEmpty();
		if (cardIsEmpty) {
			mainPageView.setCardIsEmpty(false);
			mainPageView.selectByName(modelName, false, true);
			mainPageView.closeMenu();
			Terrasoft.util.openGridPage(modelName, {
				isStartPage: true,
				routeConfig: {
					skipLoading: true
				}
			});
		}
	},

	/**
	 * Opens page.
	 * @protected
	 * @virtual
	 * @param {String} modelName Name of model
	 * @param {String} recordId Id of recoed
	 */
	openPage: function(modelName, recordId) {
		var modelConfig = Terrasoft.ApplicationConfig.getModelConfig(modelName);
		var pageName = modelConfig && modelConfig[Terrasoft.PageTypes.Preview];
		if (!pageName) {
			Terrasoft.Logger.warn("PushNotificationReceiver.openPage: " +
				"Page for model '" + modelName + "' not found while opening page.");
			return;
		}
		this.openGridIfNeeded(modelName);
		Terrasoft.util.openPreviewPage(modelName, {
			recordId: recordId
		});
	},

	/**
	 * Checks, if record exists.
	 * @protected
	 * @virtual
	 * @param {String} modelName Name of model.
	 * @param {String} recordId Id of record.
	 * @param {Function} callback Callback function.
	 */
	checkRecordExistence: function(modelName, recordId, callback) {
		Terrasoft.StructureLoader.loadModelsWithDependencies({
			modelNames: [modelName],
			success: function() {
				var model = Ext.ClassManager.get(modelName);
				if (!model) {
					Terrasoft.Logger.warn("PushNotificationReceiver.checkRecordExistence: " +
						"Model with name '" + modelName + "' not found");
					return;
				}
				var queryConfig = Ext.create("Terrasoft.QueryConfig", {
					modelName: modelName,
					columns: [model.PrimaryColumnName]
				});
				model.load(recordId, {
					isCancelable: false,
					queryConfig: queryConfig,
					success: function(record) {
						var isExisted = !Ext.isEmpty(record);
						Ext.callback(callback, this, [isExisted]);
					},
					failure: function(record, operation) {
						var exception = operation.getError();
						Terrasoft.Logger.logException(Terrasoft.LogSeverityLevel.Error, exception);
						if (exception && exception instanceof Terrasoft.ODataItemNotFoundException) {
							Ext.callback(callback, this, [false]);
						}
					},
					scope: this
				});
			},
			scope: this
		});
	},

	/**
	 * Checks, if module available for opening preview page.
	 * @protected
	 * @virtual
	 * @param {String} moduleName Name of module.
	 * @return {Boolean} True, if available.
	 */
	checkIfModuleAvailable: function(moduleName) {
		var moduleConfig = Terrasoft.ApplicationConfig.getModuleConfig(moduleName);
		return moduleConfig && !moduleConfig.Hidden;
	},

	/**
	 * Called when notification has been tapped.
	 * @protected
	 * @virtual
	 * @param {Object} data Notification data.
	 */
	onTap: function(data) {
		Terrasoft.AnalyticsManager.trackEvent({
			eventName: Terrasoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "push",
				entityName: (!Ext.isEmpty(data)) ? data.entityName || data.visaEntityName : null,
				additionalInfo: (!Ext.isEmpty(data)) ? Terrasoft.encode(data) : null,
			}
		});
		if (data.visaRecordId && Terrasoft.Features.getIsEnabled("UseMobileFlutterApprovals")) {
			this.openVisa(data.visaRecordId, data.visaEntityName);
			return;
		}
		if (Ext.isEmpty(data.entityName) || Ext.isEmpty(data.recordId)) {
			return;
		}
		var entityName = data.entityName;
		var recordId = data.recordId;
		if (!this.checkIfModuleAvailable(entityName)) {
			Terrasoft.MessageBox.showMessage(Terrasoft.LS["PushNotificationReceiver.ModuleIsNotAvailable"]);
		} else {
			if (Ext.isFunction(Terrasoft.ApplicationConfig.isFlutterModule)) {
				if (Terrasoft.ApplicationConfig.isFlutterModule(entityName)) {
					this.openFlutterEditPage(entityName, recordId);
					return;
				}
			} else {
				Terrasoft.Logger.warn("There is no Terrasoft.ApplicationConfig.isFlutterModule in this version of app. You must update app");
			}
			this.checkRecordExistence(data.entityName, data.recordId, function(isExisted) {
				if (isExisted) {
					this.synchronizeToCacheIfNeeded(data.entityName).then(function() {
						this.openPage(entityName, recordId);
					}.bind(this));
				} else {
					var errorMessage = Terrasoft.ApplicationUtils.isOnlineMode() ?
						Terrasoft.LS["PushNotificationReceiver.RecordNotFound"] :
						Terrasoft.LS["PushNotificationReceiver.RecordNotLoaded"];
					Terrasoft.MessageBox.showMessage(errorMessage);
				}
			});
		}
	}

});

Terrasoft.PushNotification.setDefaultReceiver("Terrasoft.PushNotificationReceiver");


