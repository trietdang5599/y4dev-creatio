{
	"SyncOptions": {
		"SysSettingsImportConfig": [
			"PrimaryCurrency",
			"SchedulerTimingStart",
			"SchedulerTimingEnd"
		],
		"SysLookupsImportConfig": [
			"ActivityCategory",
			"ActivityPriority",
			"ActivityResult",
			"ActivityResultCategory",
			"ActivityStatus",
			"ActivityType",
			"ActivityCategoryResultEntry",
			"ActivityParticipantRole",
			"AccountType",
			"AccountCategory"
		],
		"SyncRules": {
			"EmployeeLookup": {
				"importOptions": {
					"entityName": "Contact",
					"adapterType": "Entity",
					"useLastSyncDate": false,
					"dependencies": [
						{
							"importOptions": {
								"entityName": "SysAdminUnit",
								"adapterType": "Entity"
							},
							"deleteNonExistentRecords": false,
							"masterColumn": "Id",
							"detailColumn": "Contact"
						}
					]
				}
			}
		}
	}
}