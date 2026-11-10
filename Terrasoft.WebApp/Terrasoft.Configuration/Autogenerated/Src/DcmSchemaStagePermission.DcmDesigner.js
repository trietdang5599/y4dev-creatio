define("DcmSchemaStagePermission", ["ext-base", "terrasoft"],
	function(Ext, Terrasoft) {
		Ext.define("Terrasoft.Designers.DcmSchemaStagePermission", {
			extend: "Terrasoft.BaseObject",
			alternateClassName: "Terrasoft.DcmSchemaStagePermission",

			/**
			 * Collection of allowed SysAdminUnit identifiers changed stage.
			 * @type {Terrasoft.Collection}
			 */
			permissions: null,

			/**
			 * Collection of editable container list items.
			 * @type {Terrasoft.BaseViewModelCollection}
			 */
			containerListItems: null,

			/**
			 * Separator for permission string.
			 */
			_separator: ",",

			/**
			 * ESQ page size for batch loading existing SysAdminUnit collection.
			 */
			_pageSize: 10000,

			/**
			 * Init for DcmSchemaStagePermission class.
			 */
			init: function(callback, scope) {
				Terrasoft.chain(
					this._initPermissions,
					this._initContainerItems,
					() => Ext.callback(callback, scope),
					this
				);
			},

			// region Methods: Private

			/**
			 * Initialize container items collection.
			 * @private
			 * @param callback {Function} Callback function.
			 * @param scope {Object} Callback scope.
			 */
			_initContainerItems: function(callback, scope) {
				if(Terrasoft.Features.getIsEnabled("LoadDcmSchemaPermissionInBatch")) {
					this._initContainerItemsInBatches(callback, scope);
				} else {
					const select = this._getContainerItemsEsq();
					select.getEntityCollection(function(result) {
						if (result.success) {
							this.containerListItems = result.collection;
						}
						Ext.callback(callback, scope);
					}, this);
				}
			},

			/**
			 * Transformed string permissions to collection.
			 * @private
			 * @param callback {Function} Callback function.
			 * @param scope {Object} Callback scope.
			 */
			_initPermissions: function(callback, scope) {
				const permissionsString = this.permissions;
				const collection = Ext.create("Terrasoft.Collection");
				if (Ext.isString(permissionsString) && permissionsString) {
					const permissionsIds = permissionsString.split(this._separator);
					permissionsIds.forEach(function (id) {
						collection.add(id, id);
					}, this);
				}
				this.permissions = collection;
				Ext.callback(callback, scope);
			},

			/**
			 * Get ESQ for selecting SysAdminUnit.
			 * @private
			 * @return {Terrasoft.EntitySchemaQuery} ESQ for selecting SysAdminUnit.
			 */
			_getContainerItemsEsq: function() {
				const select = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "SysAdminUnit",
					clientESQCacheParameters: {
						cacheLevel: Terrasoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "DcmStages",
						cacheItemName: "DcmStage"
					}
				});
				select.addColumn("Id");
				select.addColumn("Name");
				return select;
			},

			/**
			 * Initialize container items collection. Data will be loaded from DB in batches.
			 * @private
			 * @param callback {Function} Callback function.
			 * @param scope {Object} Callback scope.
			 */
			_initContainerItemsInBatches: function(callback, scope) {
				const select = this._getContainerItemsPageEsq();
				select.getEntityCollection(function(result) {
					if (result.success) {
						if (!this.containerListItems) {
							this.containerListItems = result.collection;
						} else {
							this.containerListItems.loadAll(result.collection);
						}
						if (result.collection.getCount() >= this._pageSize) {
							return this._initContainerItemsInBatches(callback, scope);
						}
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Get ESQ for selecting page of SysAdminUnit records.
			 * @private
			 * @return {Terrasoft.EntitySchemaQuery} ESQ for selecting SysAdminUnit.
			 */
			_getContainerItemsPageEsq: function() {
				const select = this._getContainerItemsEsq();
				select.isPageable = true,
				select.rowCount = this._pageSize,
				select.rowsOffset = this.containerListItems
						? this.containerListItems.getCount()
						: 0
				select.clientESQCacheParameters.cacheItemName = `DcmStage_${select.rowsOffset}`
				return select;
			},

			// endregion

			// region Methods: Protected

			/**
			 * Get transformed permissions collection.
			 * @protected
			 * @return {string} Transformed permissions collection.
			 */
			getPermissionsString: function() {
				const keys = this.permissions.getKeys();
				return keys.join(this._separator);
			},

			/**
			 * Gets collection for filling container.
			 * @protected
			 * @return {Terrasoft.BaseViewModelCollection} Collection for filling container.
			 */
			getContainerItems: function() {
				return this.containerListItems;
			},

			/**
			 * Reload permissions collection data.
			 * @protected
			 * @param {Terrasoft.Collection} collection Items that will be initialized permissions collection.
			 */
			reloadPermissions: function(collection) {
				this.permissions.reloadAll(collection);
			},

			/**
			 * Return true, if stage permissions already contains selected permissions.
			 * @protected
			 * @param {String} key Permission key.
			 * @return {boolean} True if stage permissions contains in SyAdminUnit.
			 */
			contains: function(key) {
				return this.permissions.contains(key);
			},

			/**
			 * Clear permissions collection - enabled readOnly stage state.
			 * @protected
			 */
			clearPermissions: function() {
				this.permissions.clear();
			}

			// endregion

		});

		return Terrasoft.Designers.DcmSchemaStagePermission;
	}
);
