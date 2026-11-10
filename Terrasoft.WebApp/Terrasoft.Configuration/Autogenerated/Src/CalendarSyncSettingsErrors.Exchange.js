define("CalendarSyncSettingsErrors", ["SyncSettingsErrors"], function() {
	return {
		methods: {

			//region methods: protected

			addSyncFilters: function(esq) {
				let syncronizationFilters = esq.createFilterGroup();
				syncronizationFilters.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
				const activitySyncColumnPathTpl = "[ActivitySyncSettings:MailboxSyncSettings:Id].{0}";
				syncronizationFilters.add("calendarFilter", esq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					Ext.String.format(activitySyncColumnPathTpl,"ImportAppointments"),
					true));
				syncronizationFilters.add("tasksFilter", esq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					Ext.String.format(activitySyncColumnPathTpl,"ImportTasks"),
					true));
				syncronizationFilters.add("activitiesFilter", esq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					Ext.String.format(activitySyncColumnPathTpl,"ExportActivities"),
					true));
				esq.filters.add("HasActivitySync", syncronizationFilters);
			}

			//endregion
		}
	};
});
