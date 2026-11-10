define("OAuthClientApp", ["terrasoft", "ext-base", "OAuthClientAppResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.OAuthClientApp", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.OAuthClientApp",
			singleton: true,
			uId: "2372e343-8d09-4fc4-a1ca-b7f708eaafed",
			name: "OAuthClientApp",
			caption: resources.localizableStrings.OAuthClientAppCaption,
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
			description: resources.localizableStrings.OAuthClientAppDescription,
			parentUId: "1bab9dcf-17d5-49f8-9536-8e0064f1dce0",
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
						calculatedValue: "0fad9901-30c3-4ade-8ecb-292076452bb2",
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
						calculatedValue: "\/Date(1794207612095+0700)\/",
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
						calculatedValue: "\/Date(1794207612095+0700)\/",
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
				Name: {
					uId: "a38174ae-0e3e-4c37-8630-4f88fac36c0c",
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
				ClientId: {
					uId: "16220101-22c4-40ca-a6c9-8c3c1afa75a1",
					name: "ClientId",
					caption: resources.localizableStrings.ClientIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				ClientSecret: {
					uId: "701b3c29-37f1-4d60-9361-c29bb15c25cb",
					name: "ClientSecret",
					caption: resources.localizableStrings.ClientSecretCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "SecureText"
				},
				RedirectUrl: {
					uId: "a5c9087d-a8de-464e-9375-9aec4759eb05",
					name: "RedirectUrl",
					caption: resources.localizableStrings.RedirectUrlCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ApplicationUrl: {
					uId: "9c9cd4e6-da72-49e5-96b2-b9c9d6450492",
					name: "ApplicationUrl",
					caption: resources.localizableStrings.ApplicationUrlCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "WebText"
				},
				IsActive: {
					uId: "eea83bb7-ff41-4c06-a99e-c9b334f7e91d",
					name: "IsActive",
					caption: resources.localizableStrings.IsActiveCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: true
					},
					dataValueTypeName: "Boolean"
				},
				SystemUser: {
					uId: "c26abcd2-3719-48c1-856a-f9d28c8bfb57",
					name: "SystemUser",
					caption: resources.localizableStrings.SystemUserCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Description: {
					uId: "5dad3c79-ebcd-40cd-ad94-b51ec88bd452",
					name: "Description",
					caption: resources.localizableStrings.DescriptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				GrantType: {
					uId: "6573758c-5c7f-d7cd-50a1-68d1cdafd87f",
					name: "GrantType",
					caption: resources.localizableStrings.GrantTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "OAuthGrantType",
					referenceSchema: {
						name: "OAuthGrantType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "73f0cc6d-0634-4db3-96ab-0cb549958f91"
						}
					},
					dataValueTypeName: "Lookup"
				},
				Logo: {
					uId: "10586996-ffaf-6fc8-3170-847e98fbee12",
					name: "Logo",
					caption: resources.localizableStrings.LogoCaption,
					dataValueType: Terrasoft.DataValueType.IMAGELOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysImage",
					referenceSchema: {
						name: "SysImage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "ImageLookup"
				},
				AllowPlainTextPkce: {
					uId: "17f10d28-e75e-c968-ab1d-020d5dc33dda",
					name: "AllowPlainTextPkce",
					caption: resources.localizableStrings.AllowPlainTextPkceCaption,
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
				RequirePKCE: {
					uId: "62488ad8-d0b7-db14-6f87-95f8106efacf",
					name: "RequirePKCE",
					caption: resources.localizableStrings.RequirePKCECaption,
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
				IsPublic: {
					uId: "39a3c404-7efe-8989-dbf6-455cd66a0249",
					name: "IsPublic",
					caption: resources.localizableStrings.IsPublicCaption,
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
				ConsentMode: {
					uId: "89cc97fd-1bee-4430-bad6-6c52494efc68",
					name: "ConsentMode",
					caption: resources.localizableStrings.ConsentModeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "OAuthConsentMode",
					referenceSchema: {
						name: "OAuthConsentMode",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "0fbae234-131f-4a20-b57b-fd0acb853cb1"
						}
					},
					dataValueTypeName: "Lookup"
				},
				Status: {
					uId: "db76db0f-a0b2-62b6-51ab-94f3e312d1bd",
					name: "Status",
					caption: resources.localizableStrings.StatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "OAuthClientAppStatus",
					referenceSchema: {
						name: "OAuthClientAppStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69"
						}
					},
					dataValueTypeName: "Lookup"
				},
				GenerateClientId: {
					uId: "b8e4a2c1-3f6d-4e8a-9c2b-1d5e7f0a9b34",
					name: "GenerateClientId",
					caption: resources.localizableStrings.GenerateClientIdCaption,
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
				AccessTokenLifetime: {
					uId: "4f6c1a2e-9d3b-4c7a-8e5f-1a2b3c4d5e60",
					name: "AccessTokenLifetime",
					caption: resources.localizableStrings.AccessTokenLifetimeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				SlidingRefreshTokenLifetime: {
					uId: "5a7d2b3f-0e4c-4d8b-9f60-2b3c4d5e6f71",
					name: "SlidingRefreshTokenLifetime",
					caption: resources.localizableStrings.SlidingRefreshTokenLifetimeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				}
			}
		});
		return Terrasoft.OAuthClientApp;
	});