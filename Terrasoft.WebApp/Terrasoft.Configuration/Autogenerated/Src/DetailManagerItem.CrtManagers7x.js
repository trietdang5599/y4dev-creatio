define("DetailManagerItem", ["DetailManagerItemResources", "SectionManager"], function() {

	/**
	 * @class Terrasoft.DetailManagerItem
	 * ##### ######## ######### #######.
	 */

	Ext.define("Terrasoft.DetailManagerItem", {
		extend: "Terrasoft.ObjectManagerItem",
		alternateClassName: "Terrasoft.DetailManagerItem",

		// region Properties: Private

		/**
		 * #########.
		 * @private
		 * @type {String}
		 */
		caption: null,

		/**
		 * ############# ##### ######.
		 * @private
		 * @type {String}
		 */
		detailSchemaUId: null,

		/**
		 * ############# entity ##### ######.
		 * @private
		 * @type {String}
		 */
		entitySchemaUId: null,

		/**
		 * ######## ##### ######.
		 * @private
		 * @type {String}
		 */
		detailSchemaName: null,

		/**
		 * ######## entity ##### ######.
		 * @private
		 * @type {String}
		 */
		entitySchemaName: null,

		// endregion

		// region Methods: Private

		_filterBy7xModules: function(items) {
			const section7xModuleSchema = Terrasoft.DesignTimeEnums.BaseSchemaUId.SECTION_MODULE_SCHEMA;
			const modules7x = Terrasoft.SectionManager
				.filterByFn((section) => section.getModuleSchemaUId() === section7xModuleSchema)
				.getItems();
			return items.filterByFn((item) => {
				const hasModule7x = modules7x.some((section) => section.getSysModuleEntityId() === item.getId());
				return hasModule7x;
			});
		},

		// endregion

		// region Methods: Public

		/**
		 * ##### ########## ######## ######### ########.
		 * @return {String} ########## ######## #########.
		 */
		getCaption: function() {
			return this.caption;
		},

		/**
		 * ##### ########## ######## UId ##### ######.
		 * @return {String} ########## ######## UId ##### ######.
		 */
		getDetailSchemaUId: function() {
			return this.getPropertyValue("detailSchemaUId");
		},

		/**
		 * ##### ########## ######## Name ##### ######.
		 * @return {String} ########## ######## Name ##### ######.
		 */
		getDetailSchemaName: function() {
			return this.detailSchemaName;
		},

		/**
		 * ##### ########## ######## UId entity #####.
		 * @return {String} ########## ######## UId entity ##### ######.
		 */
		getEntitySchemaUId: function() {
			return this.getPropertyValue("entitySchemaUId");
		},

		/**
		 * ##### ########## ######## Name entity #####.
		 * @return {String} ########## ######## Name entity ##### ######.
		 */
		getEntitySchemaName: function() {
			return this.entitySchemaName;
		},

		/**
		 * ##### ############# ######## ### ######### ########.
		 * @param {String} caption #########.
		 */
		setCaption: function(caption) {
			this.setPropertyValue("caption", caption);
		},

		/**
		 * ##### ############# ############# ###### ### #####.
		 * @param {String} schemaUId #########.
		 */
		setDetailSchemaUId: function(schemaUId) {
			this.setPropertyValue("detailSchemaUId", schemaUId);
		},

		/**
		 * ##### ############# ############# entity ##### ######.
		 * @param {String} schemaUId #########.
		 */
		setEntitySchemaUId: function(schemaUId) {
			this.setPropertyValue("entitySchemaUId", schemaUId);
		},

		/**
		 * ########## ####### ######### #### ####### ### ############# entity-##### ######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ######## ###### callback-#######.
		 * @return {Terrasoft.SysModuleEntityManagerItem} ####### ######### #### ####### ### #############
		 * entity-##### ######.
		 */
		getSysModuleEntityManagerItem: function(callback, scope) {
			Terrasoft.chain(
				function(next) {
					Terrasoft.SectionManager.initialize(next);
				},
				function(next) {
					Terrasoft.SysModuleEntityManager.findItemsByEntitySchemaUId(this.entitySchemaUId, next, this);
				},
				function(next, sysModuleEntityManagerItems) {
					let items = sysModuleEntityManagerItems;
					if (items.getCount() > 1) {
						items = this._filterBy7xModules(items);
						if (items.getCount() === 0) {
							items = sysModuleEntityManagerItems;
						}
					}
					callback.call(scope, items.first());
				},
				this
			);
		}

		// endregion

	});

	return Terrasoft.DetailManagerItem;

});
