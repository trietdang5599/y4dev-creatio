define("CopilotMessageEnt", ["terrasoft", "ext-base", "CopilotMessageEntResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.CopilotMessageEnt", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.CopilotMessageEnt",
			singleton: true,
			uId: "427e6cd6-9696-4887-a905-5cfc48217c0a",
			name: "CopilotMessageEnt",
			caption: resources.localizableStrings.CopilotMessageEntCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.CopilotMessageEntDescription,
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
						calculatedValue: "4b7c1e56-000d-448b-9261-d93df77da7d2",
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
						calculatedValue: "\/Date(1794207579634+0700)\/",
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
						calculatedValue: "\/Date(1794207579634+0700)\/",
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
				ToolCallId: {
					uId: "189620e3-cecb-64b1-963e-061f764bdfa8",
					name: "ToolCallId",
					caption: resources.localizableStrings.ToolCallIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Role: {
					uId: "f100144e-3028-59e1-57e0-69347d471c3e",
					name: "Role",
					caption: resources.localizableStrings.RoleCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "CopilotMessageRoleEnt",
					referenceSchema: {
						name: "CopilotMessageRoleEnt",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Content: {
					uId: "d3eab9a1-1032-12d6-f591-1f63fb8a267f",
					name: "Content",
					caption: resources.localizableStrings.ContentCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				CopilotSession: {
					uId: "680c2c8c-f74f-8c26-91d9-5de4670a5aef",
					name: "CopilotSession",
					caption: resources.localizableStrings.CopilotSessionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isLookup: true,
					referenceSchemaName: "CopilotSessionEnt",
					referenceSchema: {
						name: "CopilotSessionEnt",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Title"
					},
					dataValueTypeName: "Lookup"
				},
				Intent: {
					uId: "e66fba18-ba06-1679-8b64-93bea7a6b639",
					name: "Intent",
					caption: resources.localizableStrings.IntentCaption,
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
				CopilotRequest: {
					uId: "093c5917-f943-7c1c-7b75-e7b59a180023",
					name: "CopilotRequest",
					caption: resources.localizableStrings.CopilotRequestCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "CopilotRequestEnt",
					referenceSchema: {
						name: "CopilotRequestEnt",
						primaryColumnName: "Id",
						primaryDisplayColumnName: null
					},
					dataValueTypeName: "Lookup"
				},
				RootIntent: {
					uId: "1d6c0059-53a8-5fc2-ed4e-5f3932c7522e",
					name: "RootIntent",
					caption: resources.localizableStrings.RootIntentCaption,
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
				SummarizedBy: {
					uId: "a004540c-c09c-bcac-696a-5fabfd55646a",
					name: "SummarizedBy",
					caption: resources.localizableStrings.SummarizedByCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "CopilotMessageEnt",
					referenceSchema: {
						name: "CopilotMessageEnt",
						primaryColumnName: "Id",
						primaryDisplayColumnName: null
					},
					dataValueTypeName: "Lookup"
				},
				IsSummary: {
					uId: "0d70d5c1-4ec6-2fc1-8f6b-4e99a1128858",
					name: "IsSummary",
					caption: resources.localizableStrings.IsSummaryCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsFromSystemIntent: {
					uId: "ae602d87-73b7-2825-1a06-5dc684b0b407",
					name: "IsFromSystemIntent",
					caption: resources.localizableStrings.IsFromSystemIntentCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				IsFromSystemPrompt: {
					uId: "36d1d153-6113-c244-f391-98162b8a1e5d",
					name: "IsFromSystemPrompt",
					caption: resources.localizableStrings.IsFromSystemPromptCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ForwardToClient: {
					uId: "1ac193e8-0da3-8bac-3343-1701ce6cc49b",
					name: "ForwardToClient",
					caption: resources.localizableStrings.ForwardToClientCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ContentType: {
					uId: "e88c9ea4-6689-c34f-ce21-f61c0d6c1cb8",
					name: "ContentType",
					caption: resources.localizableStrings.ContentTypeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				OmitAssistantResponse: {
					uId: "521ebdc7-c6c1-b8bb-0d7c-b8875a10c2ab",
					name: "OmitAssistantResponse",
					caption: resources.localizableStrings.OmitAssistantResponseCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				ConfirmationResult: {
					uId: "3a5a1668-eb09-3ea5-cfb6-04e9af4b685a",
					name: "ConfirmationResult",
					caption: resources.localizableStrings.ConfirmationResultCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ToolCallIdsRequireConfirmation: {
					uId: "207d3dd3-1586-7e6e-8b98-b41f8e4c6aac",
					name: "ToolCallIdsRequireConfirmation",
					caption: resources.localizableStrings.ToolCallIdsRequireConfirmationCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ProcessElement: {
					uId: "ac9d5ccc-81da-41d0-dc88-7aa4ea4c75af",
					name: "ProcessElement",
					caption: resources.localizableStrings.ProcessElementCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysProcessElementData",
					referenceSchema: {
						name: "SysProcessElementData",
						primaryColumnName: "Id",
						primaryDisplayColumnName: null
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.CopilotMessageEnt;
	});