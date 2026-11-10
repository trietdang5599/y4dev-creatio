define("CommunicationSynchronizerMixin", [], function() {
	/**
	 * @class Terrasoft.configuration.mixins.CommunicationSynchronizerMixin
	 * Communication synchronizer mixin.
	 */
	Ext.define("Terrasoft.configuration.mixins.CommunicationSynchronizerMixin", {

		alternateClassName: "Terrasoft.CommunicationSynchronizerMixin",

		_initializedDetails: {},
		_synchronizationOperations: {},

		_queueSynchronizationOperations: function(detailId, syncConfig) {
			this._synchronizationOperations[detailId] ??= {};
			this._synchronizationOperations[detailId][syncConfig.syncColumnName] ??= [];
			this._synchronizationOperations[detailId][syncConfig.syncColumnName].push(syncConfig);
		},

		_dequeueSynchronizationOperations: function(detailId) {
			const synchronizationOperationsMap = this._synchronizationOperations[detailId];
			if (!synchronizationOperationsMap) {
				return null;
			}
			const synchronizationOperations = Object.values(synchronizationOperationsMap).map(syncConfigs => {
				const firstOperation = syncConfigs[0];
				const lastOperation = syncConfigs[syncConfigs.length - 1];
				return {
					syncColumnName: firstOperation.syncColumnName,
					syncColumnValue: lastOperation.syncColumnValue,
					syncOldColumnValue: firstOperation.syncOldColumnValue
				};
			});
			delete this._synchronizationOperations[detailId];
			return synchronizationOperations;
		},

		initCommunicationSynchronization: function(detailId) {
			if (!detailId) {
				return;
			}
			this._initializedDetails[detailId] = true;
			const synchronizationOperations = this._dequeueSynchronizationOperations(detailId);
			if (!synchronizationOperations) {
				return;
			}
			synchronizationOperations.forEach(
				syncConfig => this.sandbox.publish("SyncCommunication", syncConfig, [detailId])
			);
		},

		clearCommunicationSynchronization: function(detailId) {
			delete this._initializedDetails[detailId];
			delete this._synchronizationOperations[detailId];
		},

		/**
		 * Removes changedValues columns wich would be synchronized by detail from entity.
		 * @protected
		 */
		clearChangedValuesSynchronizedByDetail: function() {
			var detailName = this.get("CommunicationDetailName");
			var communicationDetailId = this.getDetailId(detailName);
			if (!communicationDetailId) {
				return;
			}
			const isNewRecord = this.$Operation === Terrasoft.ConfigurationEnums.CardOperation.ADD ||
				this.$Operation === Terrasoft.ConfigurationEnums.CardOperation.COPY;
			var communicationsSavedByDetail =
				this.sandbox.publish("GetCommunicationsSynchronizedByDetail", null, [communicationDetailId]);
			this.Terrasoft.each(communicationsSavedByDetail, function(item) {
				const modelColumn = this.getColumnByName(item);
				if (!modelColumn || !this.changedValues) {
					return;
				}
				const modelColumnRequired = isNewRecord && modelColumn.isRequired;
				if (modelColumnRequired) {
					this.sandbox.publish("SkipSavingCommunicationsFromDetail", {
						communicationType: item,
						communicationItemValue: this.changedValues[item],
					}, [communicationDetailId]);
				} else {
					delete this.changedValues[item];
				}
			}, this);
		},

		/**
		 * Synchronizes entity column with communication detail.
		 * @protected
		 * @param {Mixed} arg Dependency argument.
		 * @param {String} columnName Sync column name.
		 */
		syncEntityWithCommunicationDetail: function(arg, columnName) {
			var communicationDetailName = this.get("CommunicationDetailName");
			if (this.Ext.isEmpty(communicationDetailName)) {
				return;
			}
			var syncColumnValue = this.get(columnName);
			this.set(columnName, syncColumnValue);
			var syncOldColumnValue = this.getPrevious(columnName);
			var communicationDetailId = this.getDetailId(communicationDetailName);
			const syncConfig = {
				syncColumnName: columnName,
				syncColumnValue: syncColumnValue,
				syncOldColumnValue: syncOldColumnValue
			};
			if (!this._initializedDetails[communicationDetailId]) {
				return this._queueSynchronizationOperations(communicationDetailId, syncConfig);
			}
			this.sandbox.publish("SyncCommunication", syncConfig, [communicationDetailId]);
		}
	});
	return Terrasoft.CommunicationSynchronizerMixin;
});
