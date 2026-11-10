Ext.ns("Terrasoft.Core.Process");

/**
 * Process execution data item type.
 */
Terrasoft.Core.Process.ProcessExecutionDataItemType = {
	ElementExecutionData: 0,
	CompletionData: 1
};

/**
 * Provides helper methods to work with process execution data.
 */
Ext.define("Terrasoft.Core.Process.ExecutionDataUtils", {
	alternateClassName: "Terrasoft.ProcessExecutionDataUtils",
	singleton: true,
	_sessionStoragePrefix: "CompletedProcessElement.",
	_completedProcessElementsStorage: null,
	_isDisableRingBufferForCompletedProcessElements: false,

	constructor: function() {
		this._isDisableRingBufferForCompletedProcessElements =
			Terrasoft.Features.getIsEnabled("DisableRingBufferForCompletedProcessElements");
		if (!this._isDisableRingBufferForCompletedProcessElements) {
			const bufferMaxLength =
				Terrasoft.SysSettings.getCachedSysSetting("RingBufferLengthForCompletedProcessElements") || 50000;
			this._completedProcessElementsStorage = Ext.create("Terrasoft.RingBuffer", {
				maxLength: bufferMaxLength,
				isOnlyUniqueItems: true
			});
		}
	},

	/**
	 * @private
	 */
	_markElementAsCompleted: function(processElementUId) {
		if (this._isDisableRingBufferForCompletedProcessElements) {
			window.sessionStorage.setItem(`${this._sessionStoragePrefix}${processElementUId}`, "1");
		} else {
			this._completedProcessElementsStorage.pushItem(processElementUId);
		}
	},

	/**
	 * Returns boolean value that determines whether the specified process element is completed.
	 * @public
	 * @param {String} processElementUId Unique identifier of the process element.
	 */
	getIsElementCompleted: function(processElementUId) {
		if (this._isDisableRingBufferForCompletedProcessElements) {
			return Boolean(window.sessionStorage.getItem(`${this._sessionStoragePrefix}${processElementUId}`));
		} else {
			return this._completedProcessElementsStorage.getIsItemExists(processElementUId);
		}
	},

	/**
	 * @private
	 */
	_getProcessStepsInfo: function(currentExecutionDataItem, currentProcessUId) {
		let anotherProcessItem = null;
		let currentProcessItem = null;
		const elementUIds = Object.keys(currentExecutionDataItem)
			.filter(key => currentExecutionDataItem[key].procElUId === key);
		const items = elementUIds.map(key => currentExecutionDataItem[key]);
		Terrasoft.each(items, function(innerItem) {
			const executionDataItem = {
				processId: currentExecutionDataItem.processId,
				elementCaption: currentExecutionDataItem.elementCaption,
				processCaption: currentExecutionDataItem.processCaption,
				batchStartSessionId: currentExecutionDataItem.batchStartSessionId
			};
			executionDataItem[innerItem.procElUId] = innerItem;
			if (innerItem.processId === currentProcessUId) {
				currentProcessItem = executionDataItem;
			} else {
				anotherProcessItem = executionDataItem;
			}
		}, this);
		return {
			nextProcessItem: anotherProcessItem,
			currentProcessItem: currentProcessItem
		};
	},

	/**
	 * Handles complete execution message.
	 * @public
	 * @param {Object} executionDataItem - execution data item to handle.
	 */
	tryHandleCompletionData: function(executionDataItem) {
		if (executionDataItem.type === Terrasoft.Core.Process.ProcessExecutionDataItemType.CompletionData) {
			this._markElementAsCompleted(executionDataItem.data.uId);
			return true;
		}
		return false;
	},

	/**
	 * Returns next execution data of the process element.
	 * @public
	 * @param {Object} executionData Execution data of the process element.
	 * @param {String} currentProcessUId Unique identifier of the current process.
	 * @param {String} currentElementUId Unique identifier of the current process element.
	 */
	getNextElementData: function(executionData, currentProcessUId, currentElementUId) {
		let isCurrentElementCompleted = false;
		let currentProcessItem = null;
		let nextProcessItem = null;
		Terrasoft.each(executionData, function(executionDataItem) {
			if (executionDataItem.type === Terrasoft.Core.Process.ProcessExecutionDataItemType.CompletionData) {
				if (executionDataItem.data.uId === currentElementUId) {
					isCurrentElementCompleted = true;
				}
				this._markElementAsCompleted(executionDataItem.data.uId);
			}
			if (!Ext.isDefined(executionDataItem.type)) {
				const processStepsInfo = this._getProcessStepsInfo(executionDataItem, currentProcessUId);
				currentProcessItem = processStepsInfo.currentProcessItem || currentProcessItem;
				nextProcessItem = processStepsInfo.nextProcessItem || nextProcessItem;
			}
		}, this);
		nextProcessItem = nextProcessItem || currentProcessItem;
		return {
			nextPage: nextProcessItem,
			isCurrentElementCompleted: isCurrentElementCompleted,
			currentProcessPage: nextProcessItem === currentProcessItem ? null : currentProcessItem
		};
	},

	/**
	 * @private
	 */
	_markExecutionDataItemsWithBatchId: function(executionDataItems) {
		const batchStartSessionId = Terrasoft.generateGUID();
		Terrasoft.each(executionDataItems, function(executionData) {
			executionData.batchStartSessionId = batchStartSessionId;
		}, this);
	},

	/**
	 * Marks all items with same batch start session id, and splits its into two groups. First contains items should be
	 * enqueued, second contains items to execute now.
	 * @param executionDataItems Source execution data items.
	 * @return {{readyItems: [], itemsToEnqueue: []}} Grouped items.
	 */
	prepareBatchExecutionDataItems: function (executionDataItems) {
		this._markExecutionDataItemsWithBatchId(executionDataItems);
		const result = {readyItems: executionDataItems, itemsToEnqueue: []};
		if (executionDataItems && executionDataItems.length > 1) {
			if (Terrasoft.Features.getIsEnabled("DisplayAllProcessPagesStartedByRecords")) {
				result.itemsToEnqueue = executionDataItems.slice(1).reverse();
				result.readyItems = executionDataItems.slice(0, 1);
			} else {
				executionDataItems.reverse();
			}
		}
		return result;
	},

	/**
	 * Returns flag, indicates that provided items marked with same batch start session id.
	 * @param {Object} firstItem First execution data item.
	 * @param {Object} secondItem Second execution data item.
	 * @return {Boolean}
	 */
	getIsExecutionDataItemsHaveSameBatchId: function(firstItem, secondItem) {
		const firstItemSessionId = firstItem && firstItem.batchStartSessionId;
		const secondItemSessionId = secondItem && secondItem.batchStartSessionId;
		return firstItemSessionId === secondItemSessionId;
	}
});
