define("Portal_SysModule", ["terrasoft", "ext-base", "Portal_SysModuleResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.Portal_SysModule", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.Portal_SysModule",
			singleton: true,
			uId: "0f41b8e1-ab86-4833-b11f-9df7cbb0a686",
			name: "Portal_SysModule",
			caption: resources.localizableStrings.Portal_SysModuleCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Caption",
			primaryImageColumnName: "Image32",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.Portal_SysModuleDescription,
			parentUId: "2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5",
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
						calculatedValue: "6396f98a-f9ec-466a-9dd4-c978bf621d94",
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
						calculatedValue: "\/Date(1794207617776+0700)\/",
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
						calculatedValue: "\/Date(1794207617776+0700)\/",
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
				Caption: {
					uId: "3da3c3b2-02fb-4cca-80c3-7946d4e8f565",
					name: "Caption",
					caption: resources.localizableStrings.CaptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				SysModuleEntity: {
					uId: "3f098e0d-6cbd-4e8f-bc3e-00709f2d8d82",
					name: "SysModuleEntity",
					caption: resources.localizableStrings.SysModuleEntityCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysModuleEntity",
					referenceSchema: {
						name: "SysModuleEntity",
						primaryColumnName: "Id",
						primaryDisplayColumnName: null
					},
					dataValueTypeName: "Lookup"
				},
				Image16: {
					uId: "6d827ba7-a622-47cc-8f11-b40b91c7441a",
					name: "Image16",
					caption: resources.localizableStrings.Image16Caption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Image"
				},
				Image20: {
					uId: "ed272316-b65f-41db-a9b4-e53ab939e4d6",
					name: "Image20",
					caption: resources.localizableStrings.Image20Caption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Image"
				},
				FolderMode: {
					uId: "d3afc924-2d21-4c0e-b2f3-9f8c180221f9",
					name: "FolderMode",
					caption: resources.localizableStrings.FolderModeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "SysModuleFolderMode",
					referenceSchema: {
						name: "SysModuleFolderMode",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				GlobalSearchAvailable: {
					uId: "eea74681-e019-4885-9a1e-e8261f2665ea",
					name: "GlobalSearchAvailable",
					caption: resources.localizableStrings.GlobalSearchAvailableCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				HasAnalytics: {
					uId: "34dfc288-1b25-4d53-bdf3-16b58a84e276",
					name: "HasAnalytics",
					caption: resources.localizableStrings.HasAnalyticsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				HasActions: {
					uId: "a0fd39b2-b680-4515-ac3c-72322db4f1b8",
					name: "HasActions",
					caption: resources.localizableStrings.HasActionsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				HasRecent: {
					uId: "80769c54-f4f4-43cb-93f8-0824715969a6",
					name: "HasRecent",
					caption: resources.localizableStrings.HasRecentCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Code: {
					uId: "e0c474a3-e4bc-457e-bb67-c1ec1b399f60",
					name: "Code",
					caption: resources.localizableStrings.CodeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				HelpContextId: {
					uId: "9a366fd1-19c8-4ba7-9bdd-039f164c08ec",
					name: "HelpContextId",
					caption: resources.localizableStrings.HelpContextIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
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
				ModuleHeader: {
					uId: "7b904e78-84bf-408c-a7a1-1287e66837d3",
					name: "ModuleHeader",
					caption: resources.localizableStrings.ModuleHeaderCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				Attribute: {
					uId: "bd3cf32d-f9b5-471b-a0ca-f541296b979d",
					name: "Attribute",
					caption: resources.localizableStrings.AttributeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				SysPageSchemaUId: {
					uId: "b3fefb7f-2aab-4b16-97aa-6ca3f3bd7ac2",
					name: "SysPageSchemaUId",
					caption: resources.localizableStrings.SysPageSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				CardSchemaUId: {
					uId: "327a0dc4-df63-4f6e-9d33-bc403d284cb6",
					name: "CardSchemaUId",
					caption: resources.localizableStrings.CardSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				SectionModuleSchemaUId: {
					uId: "d57c3c34-e293-4aed-bff6-91dc90408958",
					name: "SectionModuleSchemaUId",
					caption: resources.localizableStrings.SectionModuleSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				SectionSchemaUId: {
					uId: "af5bbb5e-9c78-44b7-8fdd-2bfc4353b4a8",
					name: "SectionSchemaUId",
					caption: resources.localizableStrings.SectionSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				CardModuleUId: {
					uId: "cb4bb1d2-d369-406e-8150-502dd7af2199",
					name: "CardModuleUId",
					caption: resources.localizableStrings.CardModuleUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "4e1670dc-10db-4217-929a-669f906e5d75"
					},
					dataValueTypeName: "Guid"
				},
				TypeColumnValue: {
					uId: "f3a29fb6-f13d-443e-8360-d4f51e8bcec8",
					name: "TypeColumnValue",
					caption: resources.localizableStrings.TypeColumnValueCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				Image32: {
					uId: "63f1eb37-455a-4a53-ace2-fa5ef4c3d10f",
					name: "Image32",
					caption: resources.localizableStrings.Image32Caption,
					dataValueType: Terrasoft.DataValueType.IMAGELOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysImage",
					referenceSchema: {
						name: "SysImage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "ImageLookup"
				},
				Logo: {
					uId: "380d55b9-487c-429b-9aff-e04101ffc307",
					name: "Logo",
					caption: resources.localizableStrings.LogoCaption,
					dataValueType: Terrasoft.DataValueType.IMAGELOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysImage",
					referenceSchema: {
						name: "SysImage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "ImageLookup"
				},
				SysModuleVisa: {
					uId: "e6243d2b-cc8f-4b2d-8646-36bac9fb48e9",
					name: "SysModuleVisa",
					caption: resources.localizableStrings.SysModuleVisaCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysModuleVisa",
					referenceSchema: {
						name: "SysModuleVisa",
						primaryColumnName: "Id",
						primaryDisplayColumnName: null
					},
					dataValueTypeName: "Lookup"
				},
				IsSystem: {
					uId: "dedaabd6-732d-47ac-b229-50a8ee02292c",
					name: "IsSystem",
					caption: resources.localizableStrings.IsSystemCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Type: {
					uId: "1e4741cc-9a6e-446f-9865-5f5910fadd67",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 0
					},
					dataValueTypeName: "Integer"
				},
				Description: {
					uId: "48b260f5-5aad-608c-73a9-2b835ef697f4",
					name: "Description",
					caption: resources.localizableStrings.DescriptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				IconBackground: {
					uId: "48ed5be5-6dcd-44ba-6294-a29c8daef880",
					name: "IconBackground",
					caption: resources.localizableStrings.IconBackgroundCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				MobileSectionSchemaUId: {
					uId: "74a0895a-c418-9012-441c-0c888293e434",
					name: "MobileSectionSchemaUId",
					caption: resources.localizableStrings.MobileSectionSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				}
			}
		});
		return Terrasoft.Portal_SysModule;
	});