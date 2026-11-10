define("SysOrgRoleInUserDetailV2", [],
	function() {
		return {
			methods: {

				/**
				 * @inheritdoc Terrasoft.BaseSysUserInRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					let filters = this.callParent(arguments);
					filters.addItem(this.Terrasoft.createColumnIsNullFilter("PortalAccount"));
					return filters;
				}

			}
		};
	});
