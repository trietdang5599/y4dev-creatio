define("PackageAwareEntitySchemaDesignerUtilities", ["terrasoft", "DesignTimeEnums", "EntitySchemaDesignerUtilities"],
		function(Terrasoft) {
	Ext.define("Terrasoft.configuration.PackageAwareEntitySchemaDesignerUtilities", {
		extend: "Terrasoft.configuration.EntitySchemaDesignerUtilities",
		alternateClassName: "Terrasoft.PackageAwareEntitySchemaDesignerUtilities",

		//region Properties: Private

		_packageUId: null,

		//endregion

		//region Methods: Public

		statics: {

			/**
			 * Creates an utilities class.
			 * @param {String} packageUId Package unique identifier.
			 */
			create: function(packageUId) {
				return Ext.create("Terrasoft.configuration.PackageAwareEntitySchemaDesignerUtilities", {
					_packageUId: packageUId
				});
			}

		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaDesignerUtilities#processAvailableEntitySchemasConfig
		 * @overridden
		 */
		processAvailableEntitySchemasConfig: function(config) {
			const baseConfig = this.callParent([config]);
			return Ext.apply(baseConfig, {
				packageUId: this._packageUId,
				useFullHierarchy: false
			});
		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaDesignerUtilities#findEntitySchemaInstance
		 * @overridden
		 */
		findEntitySchemaInstance: function(config, callback, scope) {
			const configWithPackageUId = Ext.apply(config, {
				packageUId: this._packageUId
			});
			Terrasoft.EntitySchemaManager.findBundleSchemaInstance(configWithPackageUId, callback, scope);
		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaDesignerUtilities#findEntitySchemaItem
		 * @overridden
		 */
		findEntitySchemaItem: function(entitySchemaUId, callback, scope) {
			Terrasoft.EntitySchemaManager.findPackageItem(entitySchemaUId, this._packageUId, callback, scope);
		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaDesignerUtilities#findEntitySchemaItems
		 * @overridden
		 */
		findEntitySchemaItems: function(callback, scope) {
			Terrasoft.EntitySchemaManager.findPackageItems(this._packageUId, callback, scope);
		},

		/**
		 * @inheritdoc Terrasoft.configuration.EntitySchemaDesignerUtilities#findAllEntitySchemaItems
		 * @overridden
		 */
		findAllEntitySchemaItems: function(callback, scope) {
			const config = {
				packageUId: this._packageUId,
				filterFn: () => true
			};
			Terrasoft.EntitySchemaManager.findPackageItems(config, callback, scope);
		},

		//endregion

	});

	return Terrasoft.PackageAwareEntitySchemaDesignerUtilities;
});
