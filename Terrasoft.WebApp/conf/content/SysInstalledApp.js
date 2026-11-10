define("SysInstalledApp", ["terrasoft", "ext-base", "SysInstalledAppResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysInstalledApp", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysInstalledApp",
			singleton: true,
			uId: "91d3eeb0-086c-4143-b671-dd2b77634d39",
			name: "SysInstalledApp",
			caption: resources.localizableStrings.SysInstalledAppCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Name",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.SysInstalledAppDescription,
			parentUId: "2681062b-df59-4e52-89ed-f9b7dc909ab2",
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
						calculatedValue: "85086e41-4ee8-4b44-a824-523f1677cd9b",
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
						calculatedValue: "\/Date(1794207646493+0700)\/",
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
						calculatedValue: "\/Date(1794207646493+0700)\/",
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
				Name: {
					uId: "736c30a7-c0ec-4fa9-b034-2552b319b633",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Description: {
					uId: "9e53fd7c-dde4-4502-a64c-b9e34148108b",
					name: "Description",
					caption: resources.localizableStrings.DescriptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				Code: {
					uId: "13aad544-ec30-4e76-a373-f0cff3202e24",
					name: "Code",
					caption: resources.localizableStrings.CodeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
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
				Maintainer: {
					uId: "5420bb26-d1bc-4732-8c82-372e1e870cdc",
					name: "Maintainer",
					caption: resources.localizableStrings.MaintainerCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				InstallDate: {
					uId: "aad2b3b4-a300-4468-bca3-ce64c6308a76",
					name: "InstallDate",
					caption: resources.localizableStrings.InstallDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Date"
				},
				LastUpdate: {
					uId: "934b7730-1761-4b06-9429-dcf70712663c",
					name: "LastUpdate",
					caption: resources.localizableStrings.LastUpdateCaption,
					dataValueType: Terrasoft.DataValueType.DATE,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Date"
				},
				MarketplaceLink: {
					uId: "9b0af75c-6cb3-4826-9244-ce4f82f760d7",
					name: "MarketplaceLink",
					caption: resources.localizableStrings.MarketplaceLinkCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				HelpLink: {
					uId: "b4fcdf44-2fd7-4144-a7ac-f0499af1f29c",
					name: "HelpLink",
					caption: resources.localizableStrings.HelpLinkCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				FileLink: {
					uId: "9b1eb4c0-e32e-4a5d-8345-a4cd2eb79ea6",
					name: "FileLink",
					caption: resources.localizableStrings.FileLinkCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SupportEmail: {
					uId: "95b9bde0-84ef-4a32-93d7-a18b08cb93f9",
					name: "SupportEmail",
					caption: resources.localizableStrings.SupportEmailCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				OrderLink: {
					uId: "2b224027-2933-49e7-b508-3adbeac9f399",
					name: "OrderLink",
					caption: resources.localizableStrings.OrderLinkCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SysInstalledAppStatus: {
					uId: "9c9e5d69-f096-4e6c-833c-5296db9d68b4",
					name: "SysInstalledAppStatus",
					caption: resources.localizableStrings.SysInstalledAppStatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysInstalledAppStatus",
					referenceSchema: {
						name: "SysInstalledAppStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				IconBackground: {
					uId: "5f10bf59-890d-51c1-9bd3-63b1c6f1fe52",
					name: "IconBackground",
					caption: resources.localizableStrings.IconBackgroundCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "#FF4013"
					},
					size: 50,
					dataValueTypeName: "ShortText"
				},
				SysAppIcon: {
					uId: "d4bad5e8-9a59-399a-0f1e-1c80ebc4f075",
					name: "SysAppIcon",
					caption: resources.localizableStrings.SysAppIconCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysAppIcons",
					referenceSchema: {
						name: "SysAppIcons",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "1a1ee397-d500-4dff-9006-98626855b7e9"
						}
					},
					dataValueTypeName: "Lookup"
				},
				IsDeleteDeny: {
					uId: "1f2718fc-2d34-d61e-d542-227e6bca9605",
					name: "IsDeleteDeny",
					caption: resources.localizableStrings.IsDeleteDenyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: false
					},
					dataValueTypeName: "Boolean"
				},
				Checksum: {
					uId: "7cb6351b-6acc-e834-0c7a-88abf422bfd1",
					name: "Checksum",
					caption: resources.localizableStrings.ChecksumCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				NeedUpdate: {
					uId: "be0cdfa6-c4f4-aecd-0d55-76b4d410453f",
					name: "NeedUpdate",
					caption: resources.localizableStrings.NeedUpdateCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				VersionForUpdate: {
					uId: "d8249844-d703-06e8-f401-3fbde82715e2",
					name: "VersionForUpdate",
					caption: resources.localizableStrings.VersionForUpdateCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					isFormatValidated: true,
					dataValueTypeName: "ShortText"
				},
				Version: {
					uId: "ebf523f3-ef86-11c1-9062-533e155fdd78",
					name: "Version",
					caption: resources.localizableStrings.VersionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "1.0.0"
					},
					size: 50,
					dataValueTypeName: "ShortText"
				},
				MarketplaceAppId: {
					uId: "5dd7f89c-0d6c-41ac-9932-9c778e931701",
					name: "MarketplaceAppId",
					caption: resources.localizableStrings.MarketplaceAppIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					isFormatValidated: true,
					dataValueTypeName: "ShortText"
				},
				RunParams: {
					uId: "2add1918-6c17-ee72-310b-09268428a17b",
					name: "RunParams",
					caption: resources.localizableStrings.RunParamsCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				RunType: {
					uId: "cf9a68be-abff-380b-708b-442b38faa647",
					name: "RunType",
					caption: resources.localizableStrings.RunTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysInstalledAppRunType",
					referenceSchema: {
						name: "SysInstalledAppRunType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				IsHidden: {
					uId: "0d8a3206-0f71-fc96-3347-881569f948e3",
					name: "IsHidden",
					caption: resources.localizableStrings.IsHiddenCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: false
					},
					dataValueTypeName: "Boolean"
				},
				RequiredPlatformVersion: {
					uId: "3e4ece6d-8ca7-dbcb-a13f-a425646eb323",
					name: "RequiredPlatformVersion",
					caption: resources.localizableStrings.RequiredPlatformVersionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SETTINGS,
						value: "ConfigurationVersion",
						calculatedValue: "10.0.0"
					},
					size: 50,
					dataValueTypeName: "ShortText"
				}
			}
		});
		return Terrasoft.SysInstalledApp;
	});