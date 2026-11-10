define("Activity", ["terrasoft", "ext-base", "ActivityResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.Activity", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.Activity",
			singleton: true,
			uId: "c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
			name: "Activity",
			caption: resources.localizableStrings.ActivityCaption,
			administratedByRecords: true,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Title",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.ActivityDescription,
			parentUId: "1bab9dcf-17d5-49f8-9536-8e0064f1dce0",
			columns: {
				Id: {
					uId: "ae0e45ca-c495-4fe7-a39d-3ab7278e1617",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "dd641609-ca49-449f-87f2-111866a06773",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				Title: {
					uId: "4dcf0a31-7fd7-4dba-a004-e413b1753431",
					name: "Title",
					caption: resources.localizableStrings.TitleCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isRequired: true,
					size: 450,
					dataValueTypeName: "LongText"
				},
				CreatedOn: {
					uId: "e80190a5-03b2-4095-90f7-a193a960adee",
					name: "CreatedOn",
					caption: resources.localizableStrings.CreatedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207558204+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				CreatedBy: {
					uId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
					name: "CreatedBy",
					caption: resources.localizableStrings.CreatedByCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
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
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207558204+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				ModifiedBy: {
					uId: "3015559e-cbc6-406a-88af-07f7930be832",
					name: "ModifiedBy",
					caption: resources.localizableStrings.ModifiedByCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
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
				StartDate: {
					uId: "a12ca538-61b1-4907-9fdf-01969163d4dd",
					name: "StartDate",
					caption: resources.localizableStrings.StartDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207558204+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				DueDate: {
					uId: "4038ce1f-15b2-4630-abb6-0c7377ab4c9b",
					name: "DueDate",
					caption: resources.localizableStrings.DueDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "CurrentDateTime",
						calculatedValue: "\/Date(1794207558204+0700)\/",
						sourceValue: "d7c295d3-3146-4ee1-ac49-3a7bd0edc45d"
					},
					dataValueTypeName: "DateTime"
				},
				Priority: {
					uId: "4248a634-bad1-4a20-a6af-4cd85fd24630",
					name: "Priority",
					caption: resources.localizableStrings.PriorityCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "ActivityPriority",
					referenceSchema: {
						name: "ActivityPriority",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "ab96fa02-7fe6-df11-971b-001d60e938c6"
						}
					},
					dataValueTypeName: "Lookup"
				},
				Author: {
					uId: "60c813ae-ce04-4c50-9049-affa1ce6e7b8",
					name: "Author",
					caption: resources.localizableStrings.AuthorCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
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
				RemindToAuthor: {
					uId: "0d677c6b-95fd-47e2-a8b1-eadea6767eff",
					name: "RemindToAuthor",
					caption: resources.localizableStrings.RemindToAuthorCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				RemindToAuthorDate: {
					uId: "69e70c11-5851-467a-b74b-15d3505e4f57",
					name: "RemindToAuthorDate",
					caption: resources.localizableStrings.RemindToAuthorDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				Owner: {
					uId: "f0736fa3-79d1-4760-ae69-96ec56993491",
					name: "Owner",
					caption: resources.localizableStrings.OwnerCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
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
				RemindToOwner: {
					uId: "de2d9c7f-a8b4-4f28-85d3-ee2593ac0f00",
					name: "RemindToOwner",
					caption: resources.localizableStrings.RemindToOwnerCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				RemindToOwnerDate: {
					uId: "9917a146-aa6a-46d0-bd35-a9356c4d4992",
					name: "RemindToOwnerDate",
					caption: resources.localizableStrings.RemindToOwnerDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				Type: {
					uId: "5491c33f-e927-4ca8-a579-d4810ea54c56",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "ActivityType",
					referenceSchema: {
						name: "ActivityType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "fbe0acdc-cfc0-df11-b00f-001d60e938c6"
						}
					},
					dataValueTypeName: "Lookup"
				},
				ActivityCategory: {
					uId: "c814fa71-e01b-4325-ac8d-8d4a293ed138",
					name: "ActivityCategory",
					caption: resources.localizableStrings.ActivityCategoryCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "ActivityCategory",
					referenceSchema: {
						name: "ActivityCategory",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "f51c4643-58e6-df11-971b-001d60e938c6"
						}
					},
					dataValueTypeName: "Lookup"
				},
				ShowInScheduler: {
					uId: "ff2dec51-885c-428a-8e6a-80c0c14b1434",
					name: "ShowInScheduler",
					caption: resources.localizableStrings.ShowInSchedulerCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Status: {
					uId: "c8d84f9c-b48b-479b-9ac6-4412f3436ca2",
					name: "Status",
					caption: resources.localizableStrings.StatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "ActivityStatus",
					referenceSchema: {
						name: "ActivityStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "384d4b84-58e6-df11-971b-001d60e938c6"
						}
					},
					dataValueTypeName: "Lookup"
				},
				Result: {
					uId: "ae372cfa-a21f-47f0-8a64-17d137ebe966",
					name: "Result",
					caption: resources.localizableStrings.ResultCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "ActivityResult",
					referenceSchema: {
						name: "ActivityResult",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				DetailedResult: {
					uId: "070b689f-c9d8-46e3-bb52-bcb1f430f5cf",
					name: "DetailedResult",
					caption: resources.localizableStrings.DetailedResultCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				TimeZone: {
					uId: "06ff3e76-36f0-44d2-8f07-ffb752ffde09",
					name: "TimeZone",
					caption: resources.localizableStrings.TimeZoneCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "TimeZone",
					referenceSchema: {
						name: "TimeZone",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Account: {
					uId: "fb0d6fd1-17a1-4a04-a155-a4b643c6d048",
					name: "Account",
					caption: resources.localizableStrings.AccountCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Account",
					referenceSchema: {
						name: "Account",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Contact: {
					uId: "bfaa9c7f-c368-4402-8310-a17660faf148",
					name: "Contact",
					caption: resources.localizableStrings.ContactCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Sender: {
					uId: "52b16ed8-6a96-4c0d-9887-4ba8cbb953e9",
					name: "Sender",
					caption: resources.localizableStrings.SenderCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Recepient: {
					uId: "0cb5732f-80c0-41ab-a51a-8a509143a98b",
					name: "Recepient",
					caption: resources.localizableStrings.RecepientCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				CopyRecepient: {
					uId: "b2e5a95e-72e6-4985-b9b2-af1c335ed333",
					name: "CopyRecepient",
					caption: resources.localizableStrings.CopyRecepientCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				BlindCopyRecepient: {
					uId: "a1502eb1-c06a-4e2e-8010-f51eed7315d4",
					name: "BlindCopyRecepient",
					caption: resources.localizableStrings.BlindCopyRecepientCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				Body: {
					uId: "618e7503-83b1-452d-aa33-8f76792853b5",
					name: "Body",
					caption: resources.localizableStrings.BodyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				Notes: {
					uId: "961b5183-9eff-4424-b7f8-ee5267b489b6",
					name: "Notes",
					caption: resources.localizableStrings.NotesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				Color: {
					uId: "b5b47ef8-e084-4cb0-bf59-19b3199014c7",
					name: "Color",
					caption: resources.localizableStrings.ColorCaption,
					dataValueType: Terrasoft.DataValueType.COLOR,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "#405f97"
					},
					size: 250,
					dataValueTypeName: "Color"
				},
				SendDate: {
					uId: "6689a019-c904-4b25-a89d-d17f3f3767cc",
					name: "SendDate",
					caption: resources.localizableStrings.SendDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				EmailSendStatus: {
					uId: "4935a122-b7bc-443c-a282-72bd82f76ec4",
					name: "EmailSendStatus",
					caption: resources.localizableStrings.EmailSendStatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "EmailSendStatus",
					referenceSchema: {
						name: "EmailSendStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				DurationInMinutes: {
					uId: "dd115e6f-5443-4238-97d5-3f9c36d8a9db",
					name: "DurationInMinutes",
					caption: resources.localizableStrings.DurationInMinutesCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				ErrorOnSend: {
					uId: "5ff0586c-bedc-4c23-84f3-086402411dbb",
					name: "ErrorOnSend",
					caption: resources.localizableStrings.ErrorOnSendCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				DurationInMnutesAndHours: {
					uId: "487c8731-254d-4f2d-b152-9d823db2fc51",
					name: "DurationInMnutesAndHours",
					caption: resources.localizableStrings.DurationInMnutesAndHoursCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				AllowedResult: {
					uId: "7bb00970-c11a-4a5a-82e5-d0a613afde06",
					name: "AllowedResult",
					caption: resources.localizableStrings.AllowedResultCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				CreatedByInvCRM: {
					uId: "c7636768-5007-4cb9-800f-0d729fcadf4f",
					name: "CreatedByInvCRM",
					caption: resources.localizableStrings.CreatedByInvCRMCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				MessageType: {
					uId: "af5a73d3-20ec-4419-819b-1575ce196bd2",
					name: "MessageType",
					caption: resources.localizableStrings.MessageTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "EmailType",
					referenceSchema: {
						name: "EmailType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				ProcessListeners: {
					uId: "3fabd836-6a53-4d8d-9069-6df88d9dae1e",
					name: "ProcessListeners",
					caption: resources.localizableStrings.ProcessListenersCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				IsHtmlBody: {
					uId: "80fd1395-7e28-485e-a566-82fa964ba80b",
					name: "IsHtmlBody",
					caption: resources.localizableStrings.IsHtmlBodyCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				MailHash: {
					uId: "1c19adcd-d3b5-4403-b515-b5c2cc9e481c",
					name: "MailHash",
					caption: resources.localizableStrings.MailHashCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				ProcessElementId: {
					uId: "ee2173fc-0840-4735-8c14-b58b6e3d9b99",
					name: "ProcessElementId",
					caption: resources.localizableStrings.ProcessElementIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				GlobalActivityID: {
					uId: "d480d73a-f329-47f2-a0a2-cac4e82a2a40",
					name: "GlobalActivityID",
					caption: resources.localizableStrings.GlobalActivityIDCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				IsNeedProcess: {
					uId: "004b1104-cc46-4865-b079-f23d2665c922",
					name: "IsNeedProcess",
					caption: resources.localizableStrings.IsNeedProcessCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ActivityConnection: {
					uId: "2bbd4d7c-2727-47d6-bde1-311fdbbbb97e",
					name: "ActivityConnection",
					caption: resources.localizableStrings.ActivityConnectionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Activity",
					referenceSchema: {
						name: "Activity",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Title"
					},
					dataValueTypeName: "Lookup"
				},
				Organizer: {
					uId: "734dfca1-2478-4719-8f3c-bfe3c6d1813d",
					name: "Organizer",
					caption: resources.localizableStrings.OrganizerCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
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
				CallDirection: {
					uId: "a3d9fc18-5ad2-486f-9efd-be29f0d4429a",
					name: "CallDirection",
					caption: resources.localizableStrings.CallDirectionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "CallDirection",
					referenceSchema: {
						name: "CallDirection",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "1d96a65f-2131-4916-8825-2d142b1000b2"
						}
					},
					dataValueTypeName: "Lookup"
				},
				HeaderProperties: {
					uId: "3f1f6edd-5b9c-45d5-9575-edcf22c54893",
					name: "HeaderProperties",
					caption: resources.localizableStrings.HeaderPropertiesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				IsAutoSubmitted: {
					uId: "7737db5f-7bab-4188-9d8e-a89636a84370",
					name: "IsAutoSubmitted",
					caption: resources.localizableStrings.IsAutoSubmittedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				SenderContact: {
					uId: "67551707-45c4-4d2b-a77b-683eb8aa5fe1",
					name: "SenderContact",
					caption: resources.localizableStrings.SenderContactCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Preview: {
					uId: "6bb4799d-c450-4d98-ae51-a92e9689c358",
					name: "Preview",
					caption: resources.localizableStrings.PreviewCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				OmniChat: {
					uId: "e4eae837-3880-4fb6-b3d9-1e07e1412230",
					name: "OmniChat",
					caption: resources.localizableStrings.OmniChatCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "OmniChat",
					referenceSchema: {
						name: "OmniChat",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				EnrchEmailData: {
					uId: "ace5b35d-0166-48ca-b2d4-20add837dbbd",
					name: "EnrchEmailData",
					caption: resources.localizableStrings.EnrchEmailDataCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "EnrchEmailData",
					referenceSchema: {
						name: "EnrchEmailData",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Hash"
					},
					dataValueTypeName: "Lookup"
				},
				EnrichStatus: {
					uId: "1c44eeca-97e9-4a02-a9a7-fff0eb8a4afb",
					name: "EnrichStatus",
					caption: resources.localizableStrings.EnrichStatusCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				UserEmailAddress: {
					uId: "024c7e3b-9ce7-4ec6-aaf5-bdedd07ac300",
					name: "UserEmailAddress",
					caption: resources.localizableStrings.UserEmailAddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Location: {
					uId: "be1d624b-b774-40ab-85cc-9364dacd6199",
					name: "Location",
					caption: resources.localizableStrings.LocationCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 500,
					dataValueTypeName: "LongText"
				},
				OwnerRole: {
					uId: "44967d0f-c9bf-4baa-2759-11e670e86cc3",
					name: "OwnerRole",
					caption: resources.localizableStrings.OwnerRoleCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "VwSysRole",
					referenceSchema: {
						name: "VwSysRole",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				RemoteCreatedOn: {
					uId: "3a15a3c6-e7e4-06da-c667-5561e5f9cd1d",
					name: "RemoteCreatedOn",
					caption: resources.localizableStrings.RemoteCreatedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: true,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				MeetingPlatform: {
					uId: "94b8d117-26d0-4946-82fa-c7c7a9c9547c",
					name: "MeetingPlatform",
					caption: resources.localizableStrings.MeetingPlatformCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MeetingPlatform",
					referenceSchema: {
						name: "MeetingPlatform",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				MeetingTranscript: {
					uId: "68eb9c65-1801-998b-ea4b-96bedf911618",
					name: "MeetingTranscript",
					caption: resources.localizableStrings.MeetingTranscriptCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: true,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MeetingTranscript",
					referenceSchema: {
						name: "MeetingTranscript",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "MeetingSummary"
					},
					dataValueTypeName: "Lookup"
				},
				IsAiGenerated: {
					uId: "e0756196-837f-8a40-55ed-9acbc79e1c53",
					name: "IsAiGenerated",
					caption: resources.localizableStrings.IsAiGeneratedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsAiGeneratedUnchanged: {
					uId: "1ee312c6-6f88-4ecd-4daf-ec2e0fe00918",
					name: "IsAiGeneratedUnchanged",
					caption: resources.localizableStrings.IsAiGeneratedUnchangedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				}
			}
		});
		return Terrasoft.Activity;
	});