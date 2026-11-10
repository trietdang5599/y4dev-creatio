define("SocialAccount", ["terrasoft", "ext-base", "SocialAccountResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SocialAccount", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SocialAccount",
			singleton: true,
			uId: "76e3d8e8-6c6b-48b5-9f43-3b361c368bff",
			name: "SocialAccount",
			caption: resources.localizableStrings.SocialAccountCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Login",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.SocialAccountDescription,
			parentUId: "a22b1e79-7fc1-4fe5-aba0-538e9df96f17",
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
						calculatedValue: "a7280ce4-b52e-4fbe-94cc-1ed6e9dfb62b",
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
						calculatedValue: "\/Date(1794207627181+0700)\/",
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
						calculatedValue: "\/Date(1794207627181+0700)\/",
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
				Notes: {
					uId: "abc96728-faf6-451d-91f6-35bc53ea9745",
					name: "Notes",
					caption: resources.localizableStrings.NotesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				Login: {
					uId: "6a86e81d-86b2-4650-b1dc-fd775bd0a277",
					name: "Login",
					caption: resources.localizableStrings.LoginCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 1,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Public: {
					uId: "6287d2bd-93ac-4ca2-921f-3e87d81dc00b",
					name: "Public",
					caption: resources.localizableStrings.PublicCaption,
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
				AccessToken: {
					uId: "14f15a6f-d70a-4c77-8f00-984f7bc1821f",
					name: "AccessToken",
					caption: resources.localizableStrings.AccessTokenCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isRequired: true,
					dataValueTypeName: "MaxSizeText"
				},
				AccessSecretToken: {
					uId: "ef8d65a0-3f11-43ac-a259-a28a34494d23",
					name: "AccessSecretToken",
					caption: resources.localizableStrings.AccessSecretTokenCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ConsumerKey: {
					uId: "eee3f2c0-52b4-4d86-95bf-bf4d7fe00f24",
					name: "ConsumerKey",
					caption: resources.localizableStrings.ConsumerKeyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Type: {
					uId: "6be6d2f0-6c1c-463b-8daa-972f1687ec4f",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "CommunicationType",
					referenceSchema: {
						name: "CommunicationType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				User: {
					uId: "f22ba771-1414-4be2-9ff8-3028ce093bcf",
					name: "User",
					caption: resources.localizableStrings.UserCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				SocialId: {
					uId: "72ef9eba-b06f-4bda-b9e1-4c04309aaf5e",
					name: "SocialId",
					caption: resources.localizableStrings.SocialIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 1,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				IsExpired: {
					uId: "e2a409c4-5ace-48d0-ac77-766ed29cb397",
					name: "IsExpired",
					caption: resources.localizableStrings.IsExpiredCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 1,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Name: {
					uId: "bbaf2034-8e52-432d-849c-9ddf83e19d6f",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
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
				MailServer: {
					uId: "71a9d7b4-9e55-d643-e1bb-d308a72a1820",
					name: "MailServer",
					caption: resources.localizableStrings.MailServerCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MailServer",
					referenceSchema: {
						name: "MailServer",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Enable: {
					uId: "a9d64e3e-a2df-c59c-c162-3fb51c942bd1",
					name: "Enable",
					caption: resources.localizableStrings.EnableCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: false
					},
					dataValueTypeName: "Boolean"
				},
				MailboxSyncSettings: {
					uId: "c7f17ae5-e207-34d7-b382-6705c7e55a41",
					name: "MailboxSyncSettings",
					caption: resources.localizableStrings.MailboxSyncSettingsCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MailboxSyncSettings",
					referenceSchema: {
						name: "MailboxSyncSettings",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "SenderEmailAddress"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.SocialAccount;
	});