 define("BaseDataView", ["PortalFolderManagerViewModel", "SSPGridMixin", "SspMiniPageListener"], function() {
		return {
			messages: {
				/**
				 * @message GetExtendedFilterConfig
				 * Quick filters settings generate.
				 */
				"GetExtendedFilterConfig": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				/**
				 * Provides methods for grid handling in ssp sections.
				 */
				"SSPGridMixin": "Terrasoft.SSPGridMixin"
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseDataView#getEntitySchemaFilterProviderModuleName
				 * @overridden
				 */
				getEntitySchemaFilterProviderModuleName: function() {
					if (this.Terrasoft.isCurrentUserSsp()) {
						return "PortalEntitySchemaFilterProviderModule";
					}
					return this.callParent();
				},

				/**
				 * @inheritdoc Terrasoft.BaseDataView#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function () {
					this.callParent(arguments);
					const quickFilterModuleId = this.getQuickFilterModuleId();
					this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfigForSSPUser,
						this, [quickFilterModuleId]);
				},

				/**
				 * Returns quick filters current section settings.
				 * @protected
				 * @return {Object} Filter settings.
				 */
				onGetExtendedFilterConfigForSSPUser: function () {
					return {
						hasExtendedMode: !this.Terrasoft.isCurrentUserSsp(),
						allowedColumns: this.mixins.SSPGridMixin.getAllowedColumns(this.entitySchemaName)
					};
				},

				/**
				 * @inheritDoc Terrasoft.BaseDataView#init.
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.$IsImportDisabled = this.Terrasoft.isCurrentUserSsp();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc Terrasoft.initPrintButtonsMenu#init.
				 * @override
				*/
				initPrintButtonsMenu: function(callback, scope) {
					if (this.Terrasoft.isCurrentUserSsp()) {
						this.Ext.callback(callback, scope || this);
						return;
					}
					this.callParent(arguments);
				}

				//endregion

			},
			properties: {
				folderManagerViewModelClassName: "Terrasoft.PortalFolderManagerViewModel"
			}
		};
	}
);
