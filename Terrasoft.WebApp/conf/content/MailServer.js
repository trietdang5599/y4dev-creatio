define("MailServer", ["terrasoft", "ext-base", "MailServerResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.MailServer", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.MailServer",
			singleton: true,
			uId: "7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4",
			name: "MailServer",
			caption: resources.localizableStrings.MailServerCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Name",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.MailServerDescription,
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
						calculatedValue: "1d19a799-909d-4ec9-b54c-f68641c45444",
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
						calculatedValue: "\/Date(1794207605205+0700)\/",
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
						calculatedValue: "\/Date(1794207605205+0700)\/",
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
					uId: "f0fec10e-c639-4ebb-b0d4-75ba7beb2b30",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				Address: {
					uId: "be4a6212-190c-4430-8b31-6972ac32503f",
					name: "Address",
					caption: resources.localizableStrings.AddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				Port: {
					uId: "b9e6dfc3-cd79-4707-9f3d-9b6bedda3c5f",
					name: "Port",
					caption: resources.localizableStrings.PortCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				UseSSL: {
					uId: "773d7c26-389e-421c-a67e-9ca6a8b8a3e9",
					name: "UseSSL",
					caption: resources.localizableStrings.UseSSLCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
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
				EmailProtocol: {
					uId: "9a6b34c9-96b3-45f5-b005-dfcd12e79d6d",
					name: "EmailProtocol",
					caption: resources.localizableStrings.EmailProtocolCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "EmailProtocol",
					referenceSchema: {
						name: "EmailProtocol",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "65beaf50-b599-4207-b6e2-586dfa9562a6"
						}
					},
					dataValueTypeName: "Lookup"
				},
				AllowEmailDownloading: {
					uId: "89e2b329-bf63-4d5c-a079-6cf6c5fa9430",
					name: "AllowEmailDownloading",
					caption: resources.localizableStrings.AllowEmailDownloadingCaption,
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
				AllowEmailSending: {
					uId: "411aaeae-43da-4e1c-8b1c-1655c25aac96",
					name: "AllowEmailSending",
					caption: resources.localizableStrings.AllowEmailSendingCaption,
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
				SMTPServerAddress: {
					uId: "394009b0-7664-46b4-b052-5754522f03c3",
					name: "SMTPServerAddress",
					caption: resources.localizableStrings.SMTPServerAddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SMTPPort: {
					uId: "c6d3e3b2-5552-4b06-9d5c-fe34b58ae7aa",
					name: "SMTPPort",
					caption: resources.localizableStrings.SMTPPortCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				SMTPServerTimeout: {
					uId: "6094ebec-dee7-492e-8977-4e2748a9b4bb",
					name: "SMTPServerTimeout",
					caption: resources.localizableStrings.SMTPServerTimeoutCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 40
					},
					dataValueTypeName: "Integer"
				},
				UseSSLforSending: {
					uId: "33affd30-ab8b-4975-8917-9baa63d2d025",
					name: "UseSSLforSending",
					caption: resources.localizableStrings.UseSSLforSendingCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ExchangeEmailAddress: {
					uId: "ff05d2f5-bc16-4d80-b361-13120a07867e",
					name: "ExchangeEmailAddress",
					caption: resources.localizableStrings.ExchangeEmailAddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				IsExchengeAutodiscover: {
					uId: "5a1ceded-281a-4994-bf5f-5fe57b752e0b",
					name: "IsExchengeAutodiscover",
					caption: resources.localizableStrings.IsExchengeAutodiscoverCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsStartTls: {
					uId: "a017673a-f233-4df8-8ba8-fd299bae4e20",
					name: "IsStartTls",
					caption: resources.localizableStrings.IsStartTlsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Type: {
					uId: "411a2310-81f3-4a83-896e-87eccdbae77f",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "MailServerType",
					referenceSchema: {
						name: "MailServerType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				UseLogin: {
					uId: "29f424ac-945a-4548-a60e-5e738cf01711",
					name: "UseLogin",
					caption: resources.localizableStrings.UseLoginCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Logo: {
					uId: "29d0de8b-d4db-45d1-b453-8241941d7b62",
					name: "Logo",
					caption: resources.localizableStrings.LogoCaption,
					dataValueType: Terrasoft.DataValueType.IMAGELOOKUP,
					usageType: 0,
					isInherited: false,
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
				UseUserNameAsLogin: {
					uId: "30e37f76-b60e-4975-89a0-befc3e75eeb7",
					name: "UseUserNameAsLogin",
					caption: resources.localizableStrings.UseUserNameAsLoginCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				UseEmailAddressAsLogin: {
					uId: "38790f02-593c-4eb3-80be-2204877697a0",
					name: "UseEmailAddressAsLogin",
					caption: resources.localizableStrings.UseEmailAddressAsLoginCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Strategy: {
					uId: "2e121c4b-83ff-40c4-9f0e-503cee9e5cae",
					name: "Strategy",
					caption: resources.localizableStrings.StrategyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				OAuthApplication: {
					uId: "5826ac7a-d531-4540-a160-6408396cd88b",
					name: "OAuthApplication",
					caption: resources.localizableStrings.OAuthApplicationCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "OAuthApplications",
					referenceSchema: {
						name: "OAuthApplications",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				SubscriptionTtl: {
					uId: "a99c69ce-4b49-5488-5116-7054e222e995",
					name: "SubscriptionTtl",
					caption: resources.localizableStrings.SubscriptionTtlCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				SmtpSecureOption: {
					uId: "ca1e9194-bf22-6c6d-34ec-aa37bdaf446e",
					name: "SmtpSecureOption",
					caption: resources.localizableStrings.SmtpSecureOptionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MailSecureOption",
					referenceSchema: {
						name: "MailSecureOption",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				ImapSecureOption: {
					uId: "a60be2e0-94eb-9996-9d5c-f9f5d3a2f23e",
					name: "ImapSecureOption",
					caption: resources.localizableStrings.ImapSecureOptionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MailSecureOption",
					referenceSchema: {
						name: "MailSecureOption",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				IsLimitMode: {
					uId: "a8c3835b-fcbf-11cd-0454-5fa5a8d8e399",
					name: "IsLimitMode",
					caption: resources.localizableStrings.IsLimitModeCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ServiceAccountPassword: {
					uId: "0b5a45ef-c6f9-cbc4-3483-530a346a2767",
					name: "ServiceAccountPassword",
					caption: resources.localizableStrings.ServiceAccountPasswordCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "SecureText"
				},
				ServiceAccountLogin: {
					uId: "b741c8e1-e3ef-f8b3-e0c6-031c7cb5c976",
					name: "ServiceAccountLogin",
					caption: resources.localizableStrings.ServiceAccountLoginCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				UseImpersonation: {
					uId: "47657147-4320-9148-139f-a58e13886e00",
					name: "UseImpersonation",
					caption: resources.localizableStrings.UseImpersonationCaption,
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
				}
			}
		});
		return Terrasoft.MailServer;
	});