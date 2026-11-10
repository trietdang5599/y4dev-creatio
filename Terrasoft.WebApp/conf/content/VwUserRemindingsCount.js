define("VwUserRemindingsCount", ["terrasoft", "ext-base", "VwUserRemindingsCountResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwUserRemindingsCount", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwUserRemindingsCount",
			singleton: true,
			uId: "9a61795f-29dd-4f13-b3cd-5f4fa181df52",
			name: "VwUserRemindingsCount",
			caption: resources.localizableStrings.VwUserRemindingsCountCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isDBView: true,
			description: resources.localizableStrings.VwUserRemindingsCountDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "6a544324-59f5-4a7b-bb7f-1437b4a08acb",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 1,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "527c3ef0-546f-480b-87d8-746fd021562a",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				RemindingsCount: {
					uId: "d322fdf6-3f7f-4594-ab55-d668184340ed",
					name: "RemindingsCount",
					caption: resources.localizableStrings.RemindingsCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				SysAdminUnit: {
					uId: "911467ad-c977-417b-b5b0-4b93afad1fda",
					name: "SysAdminUnit",
					caption: resources.localizableStrings.SysAdminUnitCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				RemindTime: {
					uId: "6e105fbb-1592-4cef-8ee4-3b9627d876a7",
					name: "RemindTime",
					caption: resources.localizableStrings.RemindTimeCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				TimeZoneId: {
					uId: "fdcfa94c-ed63-439b-a7ca-74dcd32d11d1",
					name: "TimeZoneId",
					caption: resources.localizableStrings.TimeZoneIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				}
			}
		});
		return Terrasoft.VwUserRemindingsCount;
	});