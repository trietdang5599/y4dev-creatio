define("PageDesignerHeaderViewModel", ["ModalBox", "ProcessModuleUtilities", "WizardHeaderViewModel"
], function(ModalBox) {

	/**
	 * Class for PageDesignerHeaderViewModel.
	 */
	Ext.define("Terrasoft.configuration.PageDesignerHeaderViewModel", {
		extend: "Terrasoft.configuration.WizardHeaderViewModel",
		alternateClassName: "Terrasoft.PageDesignerHeaderViewModel",

		//region Methods: Private

		/**
		 * @private
		 */
		_getSchema: function() {
			return {
				uId: this.$pageUId,
				name: this.$pageName,
				packageUId: this.$pagePackageUId,
				managerName: "ClientUnitSchemaManager"
			};
		},

		//endregion

		//region Methods: Protected

		/**
		 * Shows property page.
		 * @protected
		 * @virtual
		 */
		onShowPropertyPage: function() {
			const moduleId = this.sandbox.id + "_properties-page";
			const bodyMaskId = Terrasoft.Mask.show();
			const modalBoxConfig = {
				widthPixels: 550,
				heightPixels: 300,
				boxClasses: ["base-element-properties-page"]
			};
			const renderTo = ModalBox.show(modalBoxConfig, function() {
				this.sandbox.unloadModule(moduleId);
			}, this);
			Terrasoft.Mask.hide(bodyMaskId);
			const propertyPageMaskId = Terrasoft.Mask.show({selector: "#" + renderTo.id});
			const config = {
				id: moduleId,
				renderTo: renderTo.id,
				instanceConfig: {
					schemaName: "PageDesignerPropertyPage",
					maskId: propertyPageMaskId,
					parameters: {
						viewModelConfig: {
							pageUId: this.get("pageUId")
						}
					}
				}
			};
			this.sandbox.loadModule("ElementPropertiesModule", config);
		},

		/**
		 * Opens page source code.
		 * @protected
		 */
		onOpenSourceCode: function() {
			Terrasoft.ProcessModuleUtilities.showClientUnitSchemaDesigner(this._getSchema());
		},

		/**
		 * Opens page meta data.
		 * @protected
		 */
		onOpenMetaData: function() {
			Terrasoft.BaseSchemaDesignerUtilities.openMetaData(this._getSchema());
		},

		/**
		 * Exports page meta data to file.
		 * @protected
		 */
		onExportMetaData: function() {
			Terrasoft.BaseSchemaDesignerUtilities.exportMetaData(this._getSchema());
		},

		/**
		 * Return flag that indicates whether ActionsButton is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		isActionsButtonVisible: function() {
			return Terrasoft.isDebug;
		}

		//endregion

	});

	return Terrasoft.PageDesignerHeaderViewModel;
});
