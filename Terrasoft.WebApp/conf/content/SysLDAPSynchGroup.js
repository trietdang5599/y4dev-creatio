define("SysLDAPSynchGroup", ["terrasoft", "ext-base", "SysLDAPSynchGroupResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysLDAPSynchGroup", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysLDAPSynchGroup",
			singleton: true,
			uId: "3b4b2253-8bfd-4e68-8843-adcc2d61bb27",
			name: "SysLDAPSynchGroup",
			caption: resources.localizableStrings.SysLDAPSynchGroupCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "RecordId",
			description: resources.localizableStrings.SysLDAPSynchGroupDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				RecordId: {
					uId: "2c496268-390a-457a-9eb5-6eb0f2b53f50",
					name: "RecordId",
					caption: resources.localizableStrings.RecordIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "c64f8892-96f9-4ac7-92c3-86e991c3c2ba",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				Id: {
					uId: "d507c7f5-0b4f-4047-8390-3d5a45e44978",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Name: {
					uId: "89d40f75-400a-488c-a964-3e7646fac78f",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Dn: {
					uId: "7df0b36a-4cd9-4de2-9149-df57708b2535",
					name: "Dn",
					caption: resources.localizableStrings.DnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				ModifiedOn: {
					uId: "97beaab9-f711-4646-b723-284f63a8bf77",
					name: "ModifiedOn",
					caption: resources.localizableStrings.ModifiedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				LdapSyncId: {
					uId: "35c00167-a658-e3c2-c1b4-0949a0aab983",
					name: "LdapSyncId",
					caption: resources.localizableStrings.LdapSyncIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				}
			}
		});
		return Terrasoft.SysLDAPSynchGroup;
	});