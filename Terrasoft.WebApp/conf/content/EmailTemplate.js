define("EmailTemplate", ["terrasoft", "ext-base", "EmailTemplateResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.EmailTemplate", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.EmailTemplate",
			singleton: true,
			uId: "93030575-f70f-4041-902e-c4badaf62c63",
			name: "EmailTemplate",
			caption: resources.localizableStrings.EmailTemplateCaption,
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
			description: resources.localizableStrings.EmailTemplateDescription,
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
						calculatedValue: "e5093bbb-3b06-4137-ad0e-2dcbf7b7c0d1",
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
						calculatedValue: "\/Date(1794207585483+0700)\/",
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
						calculatedValue: "\/Date(1794207585483+0700)\/",
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
					uId: "ca53e2c8-0767-4f2c-8a18-2ee5821f134e",
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
				Object: {
					uId: "26bd9f25-0d50-4c47-829f-8b286576317c",
					name: "Object",
					caption: resources.localizableStrings.ObjectCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "VwSysSchemaInfo",
					referenceSchema: {
						name: "VwSysSchemaInfo",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Caption"
					},
					dataValueTypeName: "Lookup"
				},
				Recipient: {
					uId: "382c1794-3e8d-4895-91ce-02c9f5e3553e",
					name: "Recipient",
					caption: resources.localizableStrings.RecipientCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Binary"
				},
				CopyRecipient: {
					uId: "085d7c7c-fdbc-443a-ad06-1f04ace34173",
					name: "CopyRecipient",
					caption: resources.localizableStrings.CopyRecipientCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Binary"
				},
				BlindCopyRecipient: {
					uId: "47e72ecd-b21c-4b09-933e-6c1263381425",
					name: "BlindCopyRecipient",
					caption: resources.localizableStrings.BlindCopyRecipientCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Binary"
				},
				Subject: {
					uId: "2e7c35e3-0774-4a4a-bea5-6ce4c8de1465",
					name: "Subject",
					caption: resources.localizableStrings.SubjectCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				Priority: {
					uId: "feab52f3-9df5-4499-8425-855973838905",
					name: "Priority",
					caption: resources.localizableStrings.PriorityCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "ActivityPriority",
					referenceSchema: {
						name: "ActivityPriority",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Body: {
					uId: "54425b16-8b5b-40a1-baf1-3997560a6b0e",
					name: "Body",
					caption: resources.localizableStrings.BodyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				IsHtmlBody: {
					uId: "698c2960-3832-4ba4-ad56-8a6489b32ad4",
					name: "IsHtmlBody",
					caption: resources.localizableStrings.IsHtmlBodyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Macros: {
					uId: "e6618002-83f7-419a-a866-63ea7599b123",
					name: "Macros",
					caption: resources.localizableStrings.MacrosCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Binary"
				},
				SendIndividualEmail: {
					uId: "cf75d513-0d42-439c-b19f-8c7fe4234460",
					name: "SendIndividualEmail",
					caption: resources.localizableStrings.SendIndividualEmailCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "EmailTemplateSendFlag",
					referenceSchema: {
						name: "EmailTemplateSendFlag",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "e75ac3fe-be9b-4a01-87db-c7dffd354f8c"
						}
					},
					dataValueTypeName: "Lookup"
				},
				SaveAsActivity: {
					uId: "613d189f-c6a0-4ec4-b2b0-a43199cacef4",
					name: "SaveAsActivity",
					caption: resources.localizableStrings.SaveAsActivityCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ObjectFieldInActivity: {
					uId: "b1b8aa8c-787f-42e0-8af1-603d1761f75a",
					name: "ObjectFieldInActivity",
					caption: resources.localizableStrings.ObjectFieldInActivityCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				ShowBeforeSending: {
					uId: "aa4c5784-7f68-47d8-b7bb-ee3f89221ac8",
					name: "ShowBeforeSending",
					caption: resources.localizableStrings.ShowBeforeSendingCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				TemplateConfig: {
					uId: "b4972436-c042-4a3b-a025-f04575f10532",
					name: "TemplateConfig",
					caption: resources.localizableStrings.TemplateConfigCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				ConfigType: {
					uId: "f73ea119-e10f-4db3-a89f-02b338f69444",
					name: "ConfigType",
					caption: resources.localizableStrings.ConfigTypeCaption,
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
				PreviewImage: {
					uId: "1fea7f02-7faa-4a8b-a1f9-ee4e05fef97d",
					name: "PreviewImage",
					caption: resources.localizableStrings.PreviewImageCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
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
					dataValueTypeName: "Lookup"
				},
				Notes: {
					uId: "2f0c4548-e688-4561-a3a3-e6e9422ff3f7",
					name: "Notes",
					caption: resources.localizableStrings.NotesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				TemplateType: {
					uId: "08aeb0b2-b929-4208-900f-d5d58700a872",
					name: "TemplateType",
					caption: resources.localizableStrings.TemplateTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "MessageTemplateType",
					referenceSchema: {
						name: "MessageTemplateType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.EmailTemplate;
	});