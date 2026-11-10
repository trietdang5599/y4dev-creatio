Ext.define("Terrasoft.configuration.VisaActionsUtilities", {
	singleton: true,

	updateVisaStatusInCache: function(sourceRecord, parentModelName, statusId) {
		return new Promise(function(resolve) {
			var modelName = sourceRecord.self.modelName;
			if (!Terrasoft.ApplicationUtils.isOnlineMode() ||
					Terrasoft.ModelCache.isEnabledForModel(modelName, parentModelName)) {
				var queryConfig = Ext.create("Terrasoft.QueryConfig", {
					isLogged: false,
					updateSysColumns: false,
					modelName: modelName,
					columns: ["Status"],
					autoSetProxy: false
				});
				var record = sourceRecord.clone();
				record.setProxyType(Terrasoft.ProxyType.Offline);
				record.set("Status", statusId);
				record.save({
					isCancelable: false,
					queryConfig: queryConfig,
					success: function() {
						resolve();
					},
					failure: function() {
						resolve();
					}
				}, this);
			} else {
				resolve();
			}
		});
	}

});

/**
 * @class Terrasoft.VisaApproveAction
 * Performs approval of visa.
 */
Ext.define("Terrasoft.configuration.VisaApproveAction", {
	extend: "Terrasoft.ActionBase",

	execute: function() {
		this.callParent(arguments);
		var record = this.getRecord();
		var actionConfig = this.getActionConfig() || {};
		var modelName = record.self.modelName;
		Terrasoft.NativeServices.ApprovalService.approve(
				modelName, record.getPrimaryColumnValue()).then(function(result) {
			if (result) {
				Terrasoft.configuration.VisaActionsUtilities.updateVisaStatusInCache(
						record, actionConfig.parentModelName, Terrasoft.VisaStatusId.Positive).then(function() {
					this.executionEnd(true);
				}.bind(this));
			} else {
				this.executionEnd(true);
			}
		}.bind(this)).catch(function(exception) {
			Terrasoft.MessageBox.showException(exception);
			this.executionEnd(false);
		}.bind(this));
	}

});

/**
 * @class Terrasoft.VisaRejectAction
 * Performs rejection of visa.
 */
Ext.define("Terrasoft.configuration.VisaRejectAction", {
	extend: "Terrasoft.ActionBase",

	execute: function() {
		this.callParent(arguments);
		var record = this.getRecord();
		var actionConfig = this.getActionConfig() || {};
		Terrasoft.NativeServices.ApprovalService.reject(
				record.self.modelName, record.getPrimaryColumnValue(), actionConfig.comment).then(function(result) {
			if (result) {
				Terrasoft.configuration.VisaActionsUtilities.updateVisaStatusInCache(
						record, actionConfig.parentModelName, Terrasoft.VisaStatusId.Negative).then(function() {
					this.executionEnd(true);
				}.bind(this));
			} else {
				this.executionEnd(true);
			}
		}.bind(this)).catch(function(exception) {
			Terrasoft.MessageBox.showException(exception);
			this.executionEnd(false);
		}.bind(this));
	}

});
