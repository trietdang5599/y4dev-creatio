define("VwUserEmailsCount", ["terrasoft", "ext-base", "VwUserEmailsCountResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwUserEmailsCount", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwUserEmailsCount",
			singleton: true,
			uId: "5e07723e-b353-4e59-b9d4-bed6e7674c59",
			name: "VwUserEmailsCount",
			caption: resources.localizableStrings.VwUserEmailsCountCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isDBView: true,
			description: resources.localizableStrings.VwUserEmailsCountDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "5fd002bc-3832-4dd5-814f-28cd338eeb18",
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
						calculatedValue: "0353f7a7-a54e-4918-aab5-a9c2067ee8d1",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				SysAdminUnit: {
					uId: "af7c853b-8b91-44e3-9098-cb79c9b64b56",
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
				EmailsCount: {
					uId: "e219f4d0-68b9-4ce3-bc4a-5c489af9f036",
					name: "EmailsCount",
					caption: resources.localizableStrings.EmailsCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				}
			}
		});
		return Terrasoft.VwUserEmailsCount;
	});