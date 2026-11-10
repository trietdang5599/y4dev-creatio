/**
 * Generates view config for visa detail.
 */
Ext.define("Terrasoft.configuration.VisaEmbeddedDetailGenerator", {
	extend: "Terrasoft.EmbeddedDetailGenerator",

	/**
	 * @inheritdoc
	 * @protected
	 * @override
	 */
	generateItem: function() {
		var config = this.callParent(arguments);
		config.xtype = "cfvisaedetailitem";
		config.parentModelName = this.getCardGenerator().getModelName();
		return config;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @override
	 */
	generate: function() {
		var config = this.callParent(arguments);
		var cardGenerator = this.getCardGenerator();
		var isEdit = cardGenerator.isEdit();
		if (isEdit || !Terrasoft.Features.getIsEnabled("UseMobileApprovals")) {
			return null;
		}
		return config;
	}

});