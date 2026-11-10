define("MailboxSyncSettings", ["terrasoft", "ext-base", "MailboxSyncSettingsResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.MailboxSyncSettings", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.MailboxSyncSettings",
			singleton: true,
			uId: "5e487721-02e2-48ee-b755-dfa5160f5315",
			name: "MailboxSyncSettings",
			caption: resources.localizableStrings.MailboxSyncSettingsCaption,
			administratedByRecords: true,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "SenderEmailAddress",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.MailboxSyncSettingsDescription,
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
						calculatedValue: "84682b88-aa9d-4dee-bf3a-7dd418c7fe9d",
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
						calculatedValue: "\/Date(1794207604331+0700)\/",
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
						calculatedValue: "\/Date(1794207604331+0700)\/",
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
				SysAdminUnit: {
					uId: "b238f1d8-39c2-4498-b0a1-d63f123309ea",
					name: "SysAdminUnit",
					caption: resources.localizableStrings.SysAdminUnitCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentUser",
						calculatedValue: "7f3b869f-34f3-4f20-ab4d-7480a5fdf647",
						sourceValue: "b70afa32-18c9-4e69-949e-89ddac35ca98"
					},
					dataValueTypeName: "Lookup"
				},
				MailServer: {
					uId: "04423276-208b-4661-8602-6b6eadd409b9",
					name: "MailServer",
					caption: resources.localizableStrings.MailServerCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "MailServer",
					referenceSchema: {
						name: "MailServer",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				UserName: {
					uId: "3490d31d-b9b4-4017-a5c4-3019416d0c0e",
					name: "UserName",
					caption: resources.localizableStrings.UserNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isRequired: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				UserPassword: {
					uId: "6f989bb4-4185-4531-87c8-62927005896b",
					name: "UserPassword",
					caption: resources.localizableStrings.UserPasswordCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "SecureText"
				},
				EnableMailSynhronization: {
					uId: "ead0a7dd-f3e3-4679-b766-d8a9f70b2b53",
					name: "EnableMailSynhronization",
					caption: resources.localizableStrings.EnableMailSynhronizationCaption,
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
				AutomaticallyAddNewEmails: {
					uId: "1dd6b43d-22e9-49f5-9676-f4e93fffc0a5",
					name: "AutomaticallyAddNewEmails",
					caption: resources.localizableStrings.AutomaticallyAddNewEmailsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				CyclicallyAddNewEmails: {
					uId: "5b147af6-5886-41cd-b7aa-2ba9a253aab5",
					name: "CyclicallyAddNewEmails",
					caption: resources.localizableStrings.CyclicallyAddNewEmailsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				EmailsCyclicallyAddingInterval: {
					uId: "04e621fc-8584-4c36-b616-5e790d2d28ca",
					name: "EmailsCyclicallyAddingInterval",
					caption: resources.localizableStrings.EmailsCyclicallyAddingIntervalCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SETTINGS,
						value: "MailboxSyncInterval",
						calculatedValue: 15
					},
					dataValueTypeName: "Integer"
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
				IsCustomFlagsNotSuported: {
					uId: "c8b179f9-5a7e-4c20-944e-b6930162b98f",
					name: "IsCustomFlagsNotSuported",
					caption: resources.localizableStrings.IsCustomFlagsNotSuportedCaption,
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
				LastSyncDate: {
					uId: "64ef7eb3-9995-497d-9c61-e4e09e951132",
					name: "LastSyncDate",
					caption: resources.localizableStrings.LastSyncDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				IsShared: {
					uId: "bd47456d-aeb5-4454-b2ce-f6dff54a7794",
					name: "IsShared",
					caption: resources.localizableStrings.IsSharedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				SendEmailsViaThisAccount: {
					uId: "e727b47c-883f-4fdf-94aa-e85369c2f8f1",
					name: "SendEmailsViaThisAccount",
					caption: resources.localizableStrings.SendEmailsViaThisAccountCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsDefault: {
					uId: "2b8a9515-0fd9-40ea-84d2-ba1fa641e03e",
					name: "IsDefault",
					caption: resources.localizableStrings.IsDefaultCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				LoadAllEmailsFromMailBox: {
					uId: "d52de6c0-104f-4d78-8e92-3376e97a8268",
					name: "LoadAllEmailsFromMailBox",
					caption: resources.localizableStrings.LoadAllEmailsFromMailBoxCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				LoadEmailsFromDate: {
					uId: "705a60bf-aee9-4168-993d-ed634328174c",
					name: "LoadEmailsFromDate",
					caption: resources.localizableStrings.LoadEmailsFromDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDate",
						calculatedValue: "\/Date(1794157200000+0700)\/",
						sourceValue: "91bd3856-9686-4eb2-9e7c-99f1e6ca0f02"
					},
					dataValueTypeName: "Date"
				},
				MailboxName: {
					uId: "06c19861-2ce5-4eb7-88b0-117c28deecf4",
					name: "MailboxName",
					caption: resources.localizableStrings.MailboxNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SenderEmailAddress: {
					uId: "1400f977-628f-4ebe-bcdb-9fbd661d4799",
					name: "SenderEmailAddress",
					caption: resources.localizableStrings.SenderEmailAddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				MailSyncPeriod: {
					uId: "6c99d648-2324-4384-8330-b32cf258cb37",
					name: "MailSyncPeriod",
					caption: resources.localizableStrings.MailSyncPeriodCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "MailSyncPeriod",
					referenceSchema: {
						name: "MailSyncPeriod",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "2d480351-94b7-4cad-b02f-885730c7eb3e"
						}
					},
					dataValueTypeName: "Lookup"
				},
				IsAnonymousAuthentication: {
					uId: "f13ef65d-d5d7-4ef4-af7f-0091a818d68d",
					name: "IsAnonymousAuthentication",
					caption: resources.localizableStrings.IsAnonymousAuthenticationCaption,
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
				ExchangeAutoSynchronization: {
					uId: "befec718-bb2e-4b77-95b3-f421c0a72196",
					name: "ExchangeAutoSynchronization",
					caption: resources.localizableStrings.ExchangeAutoSynchronizationCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ExchangeSyncInterval: {
					uId: "d55aa1b5-9c33-4635-9aef-0e1d5a80f96e",
					name: "ExchangeSyncInterval",
					caption: resources.localizableStrings.ExchangeSyncIntervalCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SETTINGS,
						value: "MailboxSyncInterval",
						calculatedValue: 15
					},
					dataValueTypeName: "Integer"
				},
				ContactSyncInterval: {
					uId: "a08de309-02eb-45f1-84a0-d627fcfe054f",
					name: "ContactSyncInterval",
					caption: resources.localizableStrings.ContactSyncIntervalCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SETTINGS,
						value: "MailboxSyncInterval",
						calculatedValue: 15
					},
					dataValueTypeName: "Integer"
				},
				ExchangeAutoSyncActivity: {
					uId: "e4fe0282-0d7d-4eaf-8dd2-69edeab162d7",
					name: "ExchangeAutoSyncActivity",
					caption: resources.localizableStrings.ExchangeAutoSyncActivityCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				SenderDisplayValue: {
					uId: "70615ebe-d19c-4f72-bc86-bfb4df3d0e7e",
					name: "SenderDisplayValue",
					caption: resources.localizableStrings.SenderDisplayValueCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Signature: {
					uId: "7a199eeb-e500-49fd-b0ad-9b67a46c2954",
					name: "Signature",
					caption: resources.localizableStrings.SignatureCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				UseSignature: {
					uId: "a1893376-351f-4313-ac3c-9cce40a90fb7",
					name: "UseSignature",
					caption: resources.localizableStrings.UseSignatureCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ActualizeMessageRelations: {
					uId: "15fdc6ab-dabd-4cae-bd25-8a43e6b9e4e2",
					name: "ActualizeMessageRelations",
					caption: resources.localizableStrings.ActualizeMessageRelationsCaption,
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
				LastError: {
					uId: "2c6db188-9b8b-4f1c-8be7-150749951df2",
					name: "LastError",
					caption: resources.localizableStrings.LastErrorCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				ErrorCode: {
					uId: "286e13db-feea-4cb1-94eb-1243692da2b1",
					name: "ErrorCode",
					caption: resources.localizableStrings.ErrorCodeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SyncErrorMessage",
					referenceSchema: {
						name: "SyncErrorMessage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				RetryCounter: {
					uId: "1117201b-9272-4977-b4bb-fb4e958c272b",
					name: "RetryCounter",
					caption: resources.localizableStrings.RetryCounterCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				OAuthTokenStorage: {
					uId: "ce5f1f0d-f5f9-42b6-b855-8ec26bc97177",
					name: "OAuthTokenStorage",
					caption: resources.localizableStrings.OAuthTokenStorageCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "OAuthTokenStorage",
					referenceSchema: {
						name: "OAuthTokenStorage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "UserAppLogin"
					},
					dataValueTypeName: "Lookup"
				},
				SyncDateMinutesOffset: {
					uId: "6ddcc001-933c-4c78-8e0d-c9804c067489",
					name: "SyncDateMinutesOffset",
					caption: resources.localizableStrings.SyncDateMinutesOffsetCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 2,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 5
					},
					dataValueTypeName: "Integer"
				},
				SendWebsocketNotifications: {
					uId: "13a7f989-c37b-415d-a681-84d0f520eb87",
					name: "SendWebsocketNotifications",
					caption: resources.localizableStrings.SendWebsocketNotificationsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 1,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: true
					},
					dataValueTypeName: "Boolean"
				},
				PersonalMetrics: {
					uId: "fe0b3b4a-7029-4031-b6a8-1718944fc658",
					name: "PersonalMetrics",
					caption: resources.localizableStrings.PersonalMetricsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				SynchronizationStopped: {
					uId: "a5839346-f78d-43e6-964a-e108f8f129d8",
					name: "SynchronizationStopped",
					caption: resources.localizableStrings.SynchronizationStoppedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				MarkEmailsAsSynchronized: {
					uId: "427e10cf-20ea-f378-9adb-4b75170f8c18",
					name: "MarkEmailsAsSynchronized",
					caption: resources.localizableStrings.MarkEmailsAsSynchronizedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: true
					},
					dataValueTypeName: "Boolean"
				},
				WarningCode: {
					uId: "b80833e9-9f09-ccf0-84f2-c925ff94f917",
					name: "WarningCode",
					caption: resources.localizableStrings.WarningCodeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SyncErrorMessage",
					referenceSchema: {
						name: "SyncErrorMessage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.MailboxSyncSettings;
	});