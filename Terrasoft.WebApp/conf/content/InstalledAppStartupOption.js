define("InstalledAppStartupOption", ["terrasoft", "ext-base", "InstalledAppStartupOptionResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.InstalledAppStartupOption", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.InstalledAppStartupOption",
			singleton: true,
			uId: "d7a798d1-d3bd-9f93-d0cb-b5f0331da842",
			name: "InstalledAppStartupOption",
			caption: resources.localizableStrings.InstalledAppStartupOptionCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Name",
			isVirtual: true,
			description: resources.localizableStrings.InstalledAppStartupOptionDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				IsActive: {
					uId: "4a690161-e3bf-0f18-3e26-5aaf333dde8a",
					name: "IsActive",
					caption: resources.localizableStrings.IsActiveCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				RunType: {
					uId: "67bb8115-bd33-41d4-610d-5e6b8a298028",
					name: "RunType",
					caption: resources.localizableStrings.RunTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysInstalledAppRunType",
					referenceSchema: {
						name: "SysInstalledAppRunType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				InstalledApp: {
					uId: "96001313-75be-586f-a64a-42dae50a02e5",
					name: "InstalledApp",
					caption: resources.localizableStrings.InstalledAppCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysInstalledApp",
					referenceSchema: {
						name: "SysInstalledApp",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Name: {
					uId: "215990de-d8e7-b0e4-9576-be25dd3d4a02",
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
				Id: {
					uId: "eac4acea-34cb-3b49-2094-9e014efd0e71",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 1,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "c1a79862-72d3-4883-8faf-02e9516ed95d",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				}
			}
		});
		return Terrasoft.InstalledAppStartupOption;
	});