define("GlobalSearchViewGenerator", ["ModuleUtils", "LinkColumnHelper", "ViewGeneratorV2",
	"ConfigurationEnumsV2"], function(moduleUtils, LinkColumnHelper) {
	/**
	 * @class Terrasoft.configuration.GlobalSearchViewGenerator
	 * Global search controls generator class.
	 */
	Ext.define("Terrasoft.configuration.GlobalSearchViewGenerator", {
		extend: "Terrasoft.ViewGenerator",
		alternateClassName: "Terrasoft.GlobalSearchViewGenerator",

		/**
		 * @inheritdoc Terrasoft.ViewGenerator#generateModelItem
		 * @overridden
		 */
		generateModelItem: function(config, generateConfig) {
			this.setViewModelClass(config, generateConfig);
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.ViewGenerator#generateEditControl
		 * @overridden
		 */
		generateEditControl: function(config) {
			var itemDataValueType = this.getItemDataValueType(config);
			var controlConfig;
			switch (itemDataValueType) {
				case Terrasoft.DataValueType.LOOKUP:
				case Terrasoft.DataValueType.ENUM:
					controlConfig = this.generateLinkValue(config);
					break;
				default:
					controlConfig = this.generateLabelValue(config);
					break;
			}
			return controlConfig;
		},

		/**
		 * Generate label configuration {Terrasoft.ViewItemType.LABEL} for value.
		 * @protected
		 * @virtual
		 * @param {Object} config Label config.
		 * @return {Object} Label configuration.
		 */
		generateLabelValue: function(config) {
			if (this.hasLinkValue(config)) {
				return this.generateLinkValue(config);
			}
			this.applyDefaultControlConfig(config);
			Ext.apply(config, {
				labelClass: "base-edit-input"
			});
			this.applyRulesForLabel(config);
			return this.generateLabel(config);
		},

		/**
		 * @inheritdoc Terrasoft.ViewGenerator#generateControlLabel
		 * @overridden
		 */
		generateControlLabel: function(config) {
			if (config && config.isLinkColumn) {
				const newConfig = {...config};
				delete newConfig.isLinkColumn;
				return this.callParent([newConfig])
			}
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.ViewGenerator#generateHyperlink
		 * @overridden
		 */
		generateHyperlink: function(config) {
			if (config && config.isLinkColumn) {
				const newConfig = {...config};
				delete newConfig.isLinkColumn;
				return this.callParent([newConfig])
			}
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.ViewGenerator#getControlId
		 * @overridden
		 */
		getControlId: function(config, className) {
			if (className === "Terrasoft.Hyperlink") {
				return "";
			}
			return this.callParent(arguments);
		},

		/**
		 * Generate link configuration {Terrasoft.ViewItemType.HYPERLINK} for value.
		 * @protected
		 * @virtual
		 * @param {Object} config Link config.
		 * @return {Object} Link configuration.
		 */
		generateLinkValue: function(config) {
			if (!this.hasLinkValue(config)) {
				return this.generateLabelValue(config);
			}
			this.applyDefaultControlConfig(config);
			Ext.apply(config, {
				hyperlinkClass: "base-edit-link",
				href: config.href || {bindTo: "getLinkUrl"},
				click: config.click || {bindTo: "onLinkClick"},
				linkMouseOver: config.linkMouseOver || {bindTo: "linkMouseOver"}
			});
			return this.generateHyperlink(config);
		},

		/**
		 * Sets viewModelClass.
		 * @private
		 * @param {Object} config Item config.
		 * @param {Object} generateConfig Generator config.
		 */
		setViewModelClass: function(config, generateConfig) {
			if (Ext.isEmpty(this.viewModelClass)) {
				this.viewModelClass = generateConfig && generateConfig.viewModelClass;
				delete config.generator;
			}
		},

		/**
		 * Returns entity schema name.
		 * @private
		 * @return {String} Entity schema name.
		 */
		getEntitySchema: function() {
			var viewModel = this.viewModelClass && this.viewModelClass.prototype
					? this.viewModelClass.prototype
					: this.viewModelClass;
			return (viewModel.entitySchema && viewModel.entitySchema.name) || "";
		},

		/**
		 * Applies default settings to control config.
		 * @private
		 * @param {Object} config Control config.
		 */
		applyDefaultControlConfig: function(config) {
			var bindToItem = this.getItemBindTo(config);
			Ext.apply(config, {
				caption: {bindTo: bindToItem},
				tag: bindToItem,
				highlightText: {bindTo: "getHighlightText"},
				labelClass: ""
			});
		},

		/**
		 * Applies sensitive rules settings to label control config.
		 * @private
		 * @param {Object} config Control config.
		 */
		applyRulesForLabel: function(config) {
			var labelClassName = "Terrasoft.Label";
			var entitySchemaColumn = this.findViewModelColumn(config);
			var isClosedColumnAccess = this.isClosedColumnAccess(entitySchemaColumn) ;
			if (isClosedColumnAccess && config.className !== labelClassName) {
				Ext.apply(config, {
					className: labelClassName
				});
			}
		},

		/**
		 * Checking whether the current user has access to the manipulation of the sensitive data column.
		 * @private
		 * @param {Object} entitySchemaColumn Entity schema column.
		 */
		isClosedColumnAccess: function(entitySchemaColumn) {
			return entitySchemaColumn.isSensitiveData && !Terrasoft.CurrentUser.hasSensitiveDataAccess;
		},

		/**
		 * Checks is column has link.
		 * @private
		 * @param {Object} config Control config.
		 * @return {Boolean} True if has.
		 */
		hasLinkValue: function(config) {
			var entitySchemaColumn = this.findViewModelColumn(config);
			var isClosedColumnAccess = this.isClosedColumnAccess(entitySchemaColumn);
			if (!entitySchemaColumn || isClosedColumnAccess) {
				return false;
			}
			var moduleStructure = moduleUtils.getModuleStructureByName(entitySchemaColumn.referenceSchemaName);
			return config.isLinkColumn || !Ext.isEmpty(moduleStructure) ||
					!Ext.isEmpty(entitySchemaColumn.multiLookupColumns) ||
					LinkColumnHelper.getIsLinkColumn(this.getEntitySchema(), this.getItemBindTo(config));
		}
	});
	return Ext.create("Terrasoft.GlobalSearchViewGenerator");
});
