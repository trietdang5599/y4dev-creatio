define("NotifySettingsByUser", ["terrasoft", "ext-base", "NotifySettingsByUserResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.NotifySettingsByUser", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.NotifySettingsByUser",
			singleton: true,
			uId: "7a9002d3-3962-4679-afb5-5d711b49af63",
			name: "NotifySettingsByUser",
			caption: resources.localizableStrings.NotifySettingsByUserCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isVirtual: true,
			description: resources.localizableStrings.NotifySettingsByUserDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				State: {
					uId: "ed387e59-9fcf-3ad6-af58-cd0005064661",
					name: "State",
					caption: resources.localizableStrings.StateCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Name: {
					uId: "0dcd97f3-4254-9fd0-7bbd-3f36336aca11",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Code: {
					uId: "66146f5d-dc6a-97a2-4b93-1900134be8b6",
					name: "Code",
					caption: resources.localizableStrings.CodeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Id: {
					uId: "50c363d5-ceff-3fcc-6f3b-16461ab73f39",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					dataValueTypeName: "Guid"
				}
			}
		});
		return Terrasoft.NotifySettingsByUser;
	});