define("BaseFiltersGenerateModule", ["BaseFiltersGenerateModuleResources", "ConfigurationConstants"],
	function(resources, ConfigurationConstants) {
		function getIsNotNullFilterGroup(refSchema) {
			const userFilter = Terrasoft.createColumnIsNotNullFilter(refSchema + ".Id");
			const filters = Ext.create("Terrasoft.FilterGroup");
			filters.addItem(userFilter);
			return filters;
		}

		function employeesFilter() {
			const sysAdminUnitRef = "[SysAdminUnit:Contact]";
			const employeesFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					sysAdminUnitRef + ".ConnectionType",
					ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
			const filters = getIsNotNullFilterGroup(sysAdminUnitRef);
			filters.addItem(employeesFilter);
			return filters;
		}

		function allUsersFilter() {
			return getIsNotNullFilterGroup("[VwSystemUsers:Contact]");
		}

		function selfFilter() {
			let primaryColumnName = "Id";
			if (this.entitySchema && this.entitySchema.primaryColumnName) {
				primaryColumnName = this.entitySchema.primaryColumnName;
			}
			const primaryColumnValue = this.get(primaryColumnName);
			return Terrasoft.createColumnFilterWithParameter(
				Terrasoft.ComparisonType.NOT_EQUAL, primaryColumnName, primaryColumnValue);
		}

		/**
		 * Returns the users of the specified role filter.
		 * @param {String} roleId Role identifier.
		 * @returns {Terrasoft.FilterGroup}
		 */
		function usersInRoleFilter(roleId) {
			const filters = allUsersFilter();
			if (Terrasoft.isNotEmpty(roleId)) {
				const roleFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"[VwSystemUsers:Contact:Id].[SysAdminUnitInRole:SysAdminUnit:Id].SysAdminUnitRoleId",
					roleId, Terrasoft.DataValueType.GUID);
				filters.addItem(roleFilter);
			}
			return filters;
		}

		/**
		 * Returns the system users of the specified role filter.
		 * @param {String} roleId Role identifier.
		 * @returns {Terrasoft.FilterGroup}
		 */
		function ownersInRoleFilter(roleId) {
			const filters = usersInRoleFilter(roleId);
			const employeesFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
				"[VwSystemUsers:Contact].ConnectionType",
				ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
			filters.addItem(employeesFilter);
			return filters;
		}

		return {
			OwnerFilter: employeesFilter,
			SelfFilter: selfFilter,
			AllUsersFilter: allUsersFilter,
			UsersInRoleFilter: usersInRoleFilter,
			OwnersInRoleFilter: ownersInRoleFilter
		};
	});
