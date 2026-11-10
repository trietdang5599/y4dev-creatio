define("NextStep", ["terrasoft", "ext-base", "NextStepResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.NextStep", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.NextStep",
			singleton: true,
			uId: "953be763-691e-4c7c-831d-d7e5318d4715",
			name: "NextStep",
			caption: resources.localizableStrings.NextStepCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isVirtual: true,
			description: resources.localizableStrings.NextStepDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "3014ab94-afdc-1bab-f2c6-16e8e06a7e67",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				Caption: {
					uId: "2fadad61-6d22-b8fb-5421-c5e0691a7b03",
					name: "Caption",
					caption: resources.localizableStrings.CaptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					isFormatValidated: true,
					dataValueTypeName: "MediumText"
				},
				MasterEntityId: {
					uId: "daac6137-0810-d610-b094-41a7764c21d2",
					name: "MasterEntityId",
					caption: resources.localizableStrings.MasterEntityIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				EntityName: {
					uId: "29956451-c1e8-4c91-f1b7-2ec8e543cda5",
					name: "EntityName",
					caption: resources.localizableStrings.EntityNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					isFormatValidated: true,
					dataValueTypeName: "MediumText"
				},
				MasterEntityName: {
					uId: "c6495efe-0663-4a94-ded1-9b393a42d62f",
					name: "MasterEntityName",
					caption: resources.localizableStrings.MasterEntityNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					isFormatValidated: true,
					dataValueTypeName: "MediumText"
				},
				IsRequired: {
					uId: "18d7018b-5065-e3ec-21ff-3c5cf949bf63",
					name: "IsRequired",
					caption: resources.localizableStrings.IsRequiredCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ProcessElementId: {
					uId: "4998cf58-eac4-bdb0-5ee8-9e5eb8e82d2c",
					name: "ProcessElementId",
					caption: resources.localizableStrings.ProcessElementIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				Date: {
					uId: "8185f764-ad2f-6fea-1093-94e6148e3f1f",
					name: "Date",
					caption: resources.localizableStrings.DateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				AdditionalInfo: {
					uId: "651185ea-1e5a-2a48-b58d-506e4a169b01",
					name: "AdditionalInfo",
					caption: resources.localizableStrings.AdditionalInfoCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isFormatValidated: true,
					dataValueTypeName: "MaxSizeText"
				},
				Owner: {
					uId: "9eddf217-f666-6bf4-40e6-9b2b5e83019e",
					name: "Owner",
					caption: resources.localizableStrings.OwnerCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				IsOwnerRole: {
					uId: "f484c715-f5a5-e2db-b095-23bb80f811bd",
					name: "IsOwnerRole",
					caption: resources.localizableStrings.IsOwnerRoleCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				}
			}
		});
		return Terrasoft.NextStep;
	});