define("UserProfilePage", [],
	function() {
		return {
			methods: {
				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.UserProfilePage#getSysCultureDisplayValue
				 * @overridden
				 */
				getSysCultureDisplayValue: function(item) {
					var language = item.get("Language");
					return language.displayValue;
				},

				/**
				 * @inheritdoc Terrasoft.UserProfilePage#initSysAdminUnitQueryColumns
				 * @overridden
				 */
				initSysAdminUnitQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("[SysCulture:Id:SysCulture].Language", "Language");
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc Terrasoft.UserProfilePage#initSysCultureQueryFilters
				 * @overridden
				 */
				initSysCultureQueryFilters: function(esq) {
					this.callParent(arguments);
					esq.filters.add("ActiveLanguageFilter", this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Active", true));
				},

				/**
				 * @inheritdoc Terrasoft.UserProfilePage#initSysCultureQueryColumns
				 * @overridden
				 */
				initSysCultureQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("Language");
				}

				//endregion
			}
		};
	}
);
