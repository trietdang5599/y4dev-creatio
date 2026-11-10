Ext.define("Terrasoft.core.mixins.ProcessSchemaDesignerLogMixin", {
	alternateClassName: "Terrasoft.ProcessSchemaDesignerLogMixin",

	/**
	 * @private
	 */
	_showErrorMessage: function(errorMessage, config) {
		Terrasoft.Mask.clearMasks("body");
		Terrasoft.showErrorMessage(errorMessage, function() {
			if (!config || config.doCloseWindow !== false) {
				window.close();
			}
		}, this);
	},

	/**
	 * Returns schemaUId of the process log record.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope The context of the callback function.
	 */
	getProcessSchemaUId: function(callback, scope) {
		const sysProcessLogId = this.get("SysProcessLogId");
		const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
			rootSchemaName: "SysSchema"
		});
		esq.addColumn("UId");
		esq.filters.addItem(esq.createColumnFilterWithParameter(
			Terrasoft.ComparisonType.EQUAL, "[VwSysProcessLog:SysSchema:Id].Id", sysProcessLogId));
		esq.getEntityCollection(function(response) {
			let message;
			if (response.success) {
				const collection = response.collection;
				if (collection && collection.getCount()) {
					const schemaUId = collection.getByIndex(0).values.UId;
					callback.call(scope, schemaUId);
				} else {
					const template = Terrasoft.Resources.ProcessDiagram.Messages.ProcessSchemaNotFound;
					message = Ext.String.format(template, sysProcessLogId);
					this._showErrorMessage(message);
				}
			} else {
				message = response.errorInfo.message;
				this._showErrorMessage(message);
			}
		}, this);
	},

	/**
	 * @private
	 */
	_executeStatisticsRequest: function(requestClassName, callback, scope) {
		const sysProcessLogId = this.get("SysProcessLogId");
		const statisticsRequest = Ext.create(requestClassName, {
			sysProcessLogId: sysProcessLogId
		});
		statisticsRequest.execute(function(result) {
			if (!result.success) {
				const errorInfo = result.errorInfo;
				const message = Ext.String.format("{0}: {1}\n{2}", errorInfo.errorCode, errorInfo.message,
					errorInfo.stackTrace);
				this.error(message);
			}
			callback.call(scope, result.statisticInfo);
		}, this);
	},

	/**
	 * Get statistical information about the process.
	 * @param {Function} callback The callback function.
	 * @param {Object} callback.statisticInfo Statistical information.
	 * @param {Object} scope The context of the callback function.
	 */
	getProcessStatisticInfo: function(callback, scope) {
		this._executeStatisticsRequest("Terrasoft.ProcessStatisticInfoRequest", callback, scope);
	},

	/**
	 * Get statistical information about the multi-instance process.
	 * @param {Function} callback The callback function.
	 * @param {Object} callback.statisticInfo Statistical information.
	 * @param {Object} scope The context of the callback function.
	 */
	getProcessMultiInstanceStatisticInfo: function(callback, scope) {
		this._executeStatisticsRequest("Terrasoft.ProcessMultiInstanceStatisticInfoRequest", callback, scope);
	},

	/**
	 * Init process schema log identifier.
	 */
	initColumns: function() {
		this.columns.SysProcessLogId = {
			dataValueType: Terrasoft.DataValueType.GUID
		};
	},

	/**
	 * Init schema instance.
	 */
	init: function() {
		let schema;
		let generalStatisticInfo;
		Terrasoft.chain(
			function(next) {
				this.getProcessSchemaUId(next, this);
			},
			function(next, schemaUId) {
				this.set("SchemaUId", schemaUId);
				const item = Terrasoft.ProcessSchemaManager.createManagerItem({uId: schemaUId});
				item.getInstance(next, this);
			},
			function(next, instance) {
				schema = instance;
				this.getProcessStatisticInfo(next, this);
			},
			function(next, statisticInfo) {
				generalStatisticInfo = statisticInfo;
				if (Terrasoft.Features.getIsEnabled("ExecutionDiagramMultiInstanceLabels") &&
						schema.getContainsMultiInstanceElements()) {
					this.getProcessMultiInstanceStatisticInfo(next, this);
					return;
				}
				Ext.callback(next, this);
			},
			function(next, multiInstanceStatisticInfo) {
				schema.loadStatisticInfo(generalStatisticInfo);
				schema.loadMultiInstanceStatisticInfo(multiInstanceStatisticInfo);
				this.loadItems(schema);
				this.fireEvent("initialized", this);
				this.onSandboxInitialized();
			},
			this
		);
	}
});
