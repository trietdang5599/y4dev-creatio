define("PeriodicitySettings", ["terrasoft", "ext-base", "PeriodicitySettingsResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.PeriodicitySettings", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.PeriodicitySettings",
			singleton: true,
			uId: "e97f02c2-58d9-4e2e-842a-4520d4ca0ce8",
			name: "PeriodicitySettings",
			caption: resources.localizableStrings.PeriodicitySettingsCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.PeriodicitySettingsDescription,
			parentUId: "1bab9dcf-17d5-49f8-9536-8e0064f1dce0",
			columns: {
				Id: {
					uId: "ae0e45ca-c495-4fe7-a39d-3ab7278e1617",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 1,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "c9e0d512-efd1-48b5-b1cd-47094b56ffd0",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				CreatedOn: {
					uId: "e80190a5-03b2-4095-90f7-a193a960adee",
					name: "CreatedOn",
					caption: resources.localizableStrings.CreatedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 1,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207622462+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				CreatedBy: {
					uId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
					name: "CreatedBy",
					caption: resources.localizableStrings.CreatedByCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 1,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentUserContact",
						calculatedValue: "410006e1-ca4e-4502-a9ec-e54d922d2c00",
						sourceValue: "4f367ca9-549b-4a1a-b64e-a40123f52ac0"
					},
					dataValueTypeName: "Lookup"
				},
				ModifiedOn: {
					uId: "9928edec-4272-425a-93bb-48743fee4b04",
					name: "ModifiedOn",
					caption: resources.localizableStrings.ModifiedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 1,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207622462+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				ModifiedBy: {
					uId: "3015559e-cbc6-406a-88af-07f7930be832",
					name: "ModifiedBy",
					caption: resources.localizableStrings.ModifiedByCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 1,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentUserContact",
						calculatedValue: "410006e1-ca4e-4502-a9ec-e54d922d2c00",
						sourceValue: "4f367ca9-549b-4a1a-b64e-a40123f52ac0"
					},
					dataValueTypeName: "Lookup"
				},
				ProcessListeners: {
					uId: "3fabd836-6a53-4d8d-9069-6df88d9dae1e",
					name: "ProcessListeners",
					caption: resources.localizableStrings.ProcessListenersCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 2,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				IsDaily: {
					uId: "47d763a9-8466-4603-9d1d-8b002ce224e7",
					name: "IsDaily",
					caption: resources.localizableStrings.IsDailyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				DailyPeriod: {
					uId: "4519971c-ef6a-4093-9ac2-815cba012376",
					name: "DailyPeriod",
					caption: resources.localizableStrings.DailyPeriodCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				IsWeekly: {
					uId: "12380ad3-9811-408f-a2ae-41d8824aff28",
					name: "IsWeekly",
					caption: resources.localizableStrings.IsWeeklyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				DayOfWeek: {
					uId: "3c403256-b627-45e2-ae0c-a2b8287fc9fe",
					name: "DayOfWeek",
					caption: resources.localizableStrings.DayOfWeekCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				IsMonthly: {
					uId: "c4c846c0-4f99-4c7b-96f2-96d0c2cebeb1",
					name: "IsMonthly",
					caption: resources.localizableStrings.IsMonthlyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsMonthlyCustom: {
					uId: "52b22af7-46c5-483b-9a75-03b93d4ec7a7",
					name: "IsMonthlyCustom",
					caption: resources.localizableStrings.IsMonthlyCustomCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				DayOfMonth: {
					uId: "7fd3d658-9f16-4d63-816a-a7b825256605",
					name: "DayOfMonth",
					caption: resources.localizableStrings.DayOfMonthCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				IsMonthlyLastDay: {
					uId: "e2d8c2fb-a4c7-4b5c-8d9f-bfc3ab4128d6",
					name: "IsMonthlyLastDay",
					caption: resources.localizableStrings.IsMonthlyLastDayCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsOnce: {
					uId: "69cbd451-c173-48d2-9a7f-b0e67bbd0269",
					name: "IsOnce",
					caption: resources.localizableStrings.IsOnceCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				OnceAt: {
					uId: "7817b396-8b15-4bb4-9248-7264b7a54ffa",
					name: "OnceAt",
					caption: resources.localizableStrings.OnceAtCaption,
					dataValueType: Terrasoft.DataValueType.TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Time"
				},
				IsCustom: {
					uId: "71cd487f-f25f-4202-9965-4beb10ee76a4",
					name: "IsCustom",
					caption: resources.localizableStrings.IsCustomCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				CustomPeriod: {
					uId: "87be6e44-0210-469f-86d1-1e1d19414706",
					name: "CustomPeriod",
					caption: resources.localizableStrings.CustomPeriodCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				CustomPeriodType: {
					uId: "5523cb12-f07f-4c73-b366-900c6860b9ab",
					name: "CustomPeriodType",
					caption: resources.localizableStrings.CustomPeriodTypeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				CustomFrom: {
					uId: "09b2ad89-826f-4806-869f-d4454507cb45",
					name: "CustomFrom",
					caption: resources.localizableStrings.CustomFromCaption,
					dataValueType: Terrasoft.DataValueType.TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Time"
				},
				CustomTill: {
					uId: "2b6dfefc-6012-4039-896c-f0b539b78d4e",
					name: "CustomTill",
					caption: resources.localizableStrings.CustomTillCaption,
					dataValueType: Terrasoft.DataValueType.TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Time"
				},
				SchedulerStart: {
					uId: "ef6ae8b8-d210-4da8-8025-a47a9204f8a7",
					name: "SchedulerStart",
					caption: resources.localizableStrings.SchedulerStartCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				SchedulerFinish: {
					uId: "89965a50-cf91-4b73-8ea6-41814f699f55",
					name: "SchedulerFinish",
					caption: resources.localizableStrings.SchedulerFinishCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				IsSchedulerEndless: {
					uId: "4cc31fdf-ec3c-43cb-b0f4-c2fe2b5d4928",
					name: "IsSchedulerEndless",
					caption: resources.localizableStrings.IsSchedulerEndlessCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				}
			}
		});
		return Terrasoft.PeriodicitySettings;
	});