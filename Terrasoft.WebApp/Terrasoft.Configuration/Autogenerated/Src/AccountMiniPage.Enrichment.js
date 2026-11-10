define("AccountMiniPage", ["CompaniesListHelper"], function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			mixins: {
				CompaniesListHelper: "Terrasoft.CompaniesListHelper"
			},
			methods: {
				/**
				 * @inheritdoc Terrasoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.mixins.CompaniesListHelper.init.call(this);
					this.callParent(arguments);
				}
			},
			attributes: {
				"Name": {
					"contentType": this.Terrasoft.ContentType.SEARCHABLE_TEXT,
					"searchableTextConfig": {
						"listAttribute": "CompaniesList",
						"prepareListMethod": "prepareCompaniesExpandableList",
						"listViewItemRenderMethod": "onCompaniesListViewItemRender",
						"itemSelectedMethod": "onCompanyItemSelected"
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
