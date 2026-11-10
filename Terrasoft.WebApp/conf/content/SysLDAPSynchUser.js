define("SysLDAPSynchUser", ["terrasoft", "ext-base", "SysLDAPSynchUserResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysLDAPSynchUser", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysLDAPSynchUser",
			singleton: true,
			uId: "886c0437-cad4-4960-823c-d8ffee96ae3f",
			name: "SysLDAPSynchUser",
			caption: resources.localizableStrings.SysLDAPSynchUserCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "RecordId",
			description: resources.localizableStrings.SysLDAPSynchUserDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				RecordId: {
					uId: "f5d2acb3-b39a-49d8-9a5d-79c06c7f8fda",
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
						calculatedValue: "076ef7ff-953f-4d65-84c0-5c0bcc9e9a78",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				Id: {
					uId: "d452da23-d99c-4b68-9665-e5110c5566b7",
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
					uId: "776a4b48-99de-474f-aff2-1e9ac7b9d1fa",
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
				ModifiedOn: {
					uId: "3fefe25d-e666-4f24-963f-be76dd042fb1",
					name: "ModifiedOn",
					caption: resources.localizableStrings.ModifiedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				Company: {
					uId: "4a17fe84-8964-4bd9-b300-9c20681d2a22",
					name: "Company",
					caption: resources.localizableStrings.CompanyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Email: {
					uId: "c538cf71-3e9d-4fbe-aa8f-4da219ee8cae",
					name: "Email",
					caption: resources.localizableStrings.EmailCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Phone: {
					uId: "16e756fe-bee6-466d-b1d8-09763b798d39",
					name: "Phone",
					caption: resources.localizableStrings.PhoneCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				JobTitle: {
					uId: "1e239dd8-2950-4be2-bcc7-3d76999ed2ee",
					name: "JobTitle",
					caption: resources.localizableStrings.JobTitleCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				IsActive: {
					uId: "fb3288a1-a46c-4d8b-874b-719e7c3375ec",
					name: "IsActive",
					caption: resources.localizableStrings.IsActiveCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				FullName: {
					uId: "7f46ee1a-e732-4ee3-be2a-3076ae2319a0",
					name: "FullName",
					caption: resources.localizableStrings.FullNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Dn: {
					uId: "eab52745-becb-4233-b9d5-254bbd7d2aac",
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
				LdapSyncId: {
					uId: "9c96ad55-9dd3-4c08-7b79-c26bc6abda1d",
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
		return Terrasoft.SysLDAPSynchUser;
	});