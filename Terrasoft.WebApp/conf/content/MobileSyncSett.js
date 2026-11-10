define("MobileSyncSett", ["terrasoft", "ext-base", "MobileSyncSettResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.MobileSyncSett", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.MobileSyncSett",
			singleton: true,
			uId: "7412bbef-fe51-4fbf-8a61-a64c133e6095",
			name: "MobileSyncSett",
			caption: resources.localizableStrings.MobileSyncSettCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "EntityCaption",
			isVirtual: true,
			description: resources.localizableStrings.MobileSyncSettDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "0e501436-cf6e-20e1-c369-e48a86046079",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					dataValueTypeName: "Guid"
				},
				WorkplaceCode: {
					uId: "d24a8d81-94b4-4376-d10f-ae650a6574ce",
					name: "WorkplaceCode",
					caption: resources.localizableStrings.WorkplaceCodeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				IsEnabled: {
					uId: "16e56b05-b9f6-8af7-d8ab-9bceee1d2b85",
					name: "IsEnabled",
					caption: resources.localizableStrings.IsEnabledCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Count: {
					uId: "088daa1e-4a55-73d7-9d24-81292b6d95e2",
					name: "Count",
					caption: resources.localizableStrings.CountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				TotalCount: {
					uId: "d50c8ad1-d40e-ed5e-c16c-82ab948b8838",
					name: "TotalCount",
					caption: resources.localizableStrings.TotalCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				EntityName: {
					uId: "0c873556-e74a-6646-a122-93516c704b0f",
					name: "EntityName",
					caption: resources.localizableStrings.EntityNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				EntityCaption: {
					uId: "8b1006a1-0ba1-9810-17eb-b7bc6edca2b9",
					name: "EntityCaption",
					caption: resources.localizableStrings.EntityCaptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				FilterData: {
					uId: "aa3cb291-9c64-d8c0-b817-64e6b5fa4a76",
					name: "FilterData",
					caption: resources.localizableStrings.FilterDataCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				WorkplaceName: {
					uId: "842a1580-765b-5631-9565-74339f862451",
					name: "WorkplaceName",
					caption: resources.localizableStrings.WorkplaceNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				}
			}
		});
		return Terrasoft.MobileSyncSett;
	});