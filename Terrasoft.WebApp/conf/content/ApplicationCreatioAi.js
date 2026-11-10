define("ApplicationCreatioAi", ["terrasoft", "ext-base", "ApplicationCreatioAiResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.ApplicationCreatioAi", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.ApplicationCreatioAi",
			singleton: true,
			uId: "c158b6c5-d484-4608-8909-a0bfb6452686",
			name: "ApplicationCreatioAi",
			caption: resources.localizableStrings.ApplicationCreatioAiCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isVirtual: true,
			description: resources.localizableStrings.ApplicationCreatioAiDescription,
			parentUId: "51fab605-6f0c-4ff7-8398-b933f6a09128",
			columns: {
				Id: {
					uId: "5a25e41d-f073-771a-0eb2-2da08ca742a2",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				PackageUId: {
					uId: "f5fd2219-389e-3e60-e95c-dc22be46d406",
					name: "PackageUId",
					caption: resources.localizableStrings.PackageUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				UId: {
					uId: "14ac57c1-5195-558b-ef35-4fa49d31bb23",
					name: "UId",
					caption: resources.localizableStrings.UIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				ModifiedOn: {
					uId: "d8eb7579-e1c4-3e88-b0eb-094d967c9091",
					name: "ModifiedOn",
					caption: resources.localizableStrings.ModifiedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				Caption: {
					uId: "6eb5acae-3d96-0bf5-4d99-87d116ef914c",
					name: "Caption",
					caption: resources.localizableStrings.CaptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Name: {
					uId: "251fc201-caf9-3f60-75a5-4ef63df7d403",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Application: {
					uId: "44e4b2a2-7b6b-37ad-e441-6c77a1f4d2d9",
					name: "Application",
					caption: resources.localizableStrings.ApplicationCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
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
				Package: {
					uId: "b954fdf8-e061-162c-42c6-e997686069c8",
					name: "Package",
					caption: resources.localizableStrings.PackageCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysPackage",
					referenceSchema: {
						name: "SysPackage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Model: {
					uId: "25373927-c030-4859-dee1-974ecedc18fb",
					name: "Model",
					caption: resources.localizableStrings.ModelCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				Status: {
					uId: "f15abb63-76f5-9e6b-4f5c-94971326b705",
					name: "Status",
					caption: resources.localizableStrings.StatusCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				Type: {
					uId: "889fc303-1fdb-9539-140a-2ab688f196a8",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
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
		return Terrasoft.ApplicationCreatioAi;
	});