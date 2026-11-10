define("SysActiveCall", ["terrasoft", "ext-base", "SysActiveCallResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysActiveCall", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysActiveCall",
			singleton: true,
			uId: "c159d7d4-8f45-4116-bb83-25f24f4fbb2a",
			name: "SysActiveCall",
			caption: resources.localizableStrings.SysActiveCallCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.SysActiveCallDescription,
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
						calculatedValue: "90e9a373-4a10-4ca4-a941-142dfa1b61f8",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
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
						calculatedValue: "\/Date(1794207632941+0700)\/",
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
						calculatedValue: "\/Date(1794207632941+0700)\/",
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
				IntegrationId: {
					uId: "a423b8c9-c10c-4e3e-825a-00ccf98bcc31",
					name: "IntegrationId",
					caption: resources.localizableStrings.IntegrationIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 450,
					dataValueTypeName: "LongText"
				},
				Call: {
					uId: "2426cbfb-68c3-496f-9c10-763f4249a259",
					name: "Call",
					caption: resources.localizableStrings.CallCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Call",
					referenceSchema: {
						name: "Call",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Caption"
					},
					dataValueTypeName: "Lookup"
				},
				ParentCall: {
					uId: "885f2572-4898-48f3-80c8-6e192bc2fc19",
					name: "ParentCall",
					caption: resources.localizableStrings.ParentCallCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Call",
					referenceSchema: {
						name: "Call",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Caption"
					},
					dataValueTypeName: "Lookup"
				},
				CallerId: {
					uId: "497b7659-e70d-43fc-871d-300057fdbd17",
					name: "CallerId",
					caption: resources.localizableStrings.CallerIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				CalledId: {
					uId: "63f19db3-e06e-4d91-9e83-0e7f6c09ba2e",
					name: "CalledId",
					caption: resources.localizableStrings.CalledIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				RedirectingId: {
					uId: "b05760c8-8467-47d6-a265-43995be8fa11",
					name: "RedirectingId",
					caption: resources.localizableStrings.RedirectingIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				RedirectionId: {
					uId: "c5256457-b82d-467c-a9ab-0369a236c72b",
					name: "RedirectionId",
					caption: resources.localizableStrings.RedirectionIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				StartDate: {
					uId: "4977b159-fd09-497d-9513-12670ad5820c",
					name: "StartDate",
					caption: resources.localizableStrings.StartDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				EndDate: {
					uId: "3d8b7a37-0e83-4c48-aabf-7a46b679251f",
					name: "EndDate",
					caption: resources.localizableStrings.EndDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				CurrentHoldStartTime: {
					uId: "640f3ac3-f11d-4841-8b28-46410c40fff0",
					name: "CurrentHoldStartTime",
					caption: resources.localizableStrings.CurrentHoldStartTimeCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				CurrentTalkStartTime: {
					uId: "9b7a9f11-4a3a-4286-a1bd-5e0fa3954800",
					name: "CurrentTalkStartTime",
					caption: resources.localizableStrings.CurrentTalkStartTimeCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				ConnectionStartTime: {
					uId: "5ab982e0-1acc-4a4b-8082-adc2f3121994",
					name: "ConnectionStartTime",
					caption: resources.localizableStrings.ConnectionStartTimeCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				Duration: {
					uId: "9e076a05-1c8c-4ed1-803a-b08521fe10e1",
					name: "Duration",
					caption: resources.localizableStrings.DurationCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				BeforeConnectionTime: {
					uId: "419ae3a0-cd3e-4295-afd5-a45a4c2c2667",
					name: "BeforeConnectionTime",
					caption: resources.localizableStrings.BeforeConnectionTimeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				TalkTime: {
					uId: "34a835ab-97f4-42f9-8679-e232478df68f",
					name: "TalkTime",
					caption: resources.localizableStrings.TalkTimeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				HoldTime: {
					uId: "21a54ee9-9c4e-45fb-b04b-357a187df9ac",
					name: "HoldTime",
					caption: resources.localizableStrings.HoldTimeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				State: {
					uId: "82791c92-19ce-4e92-9f02-1a4c746c05fb",
					name: "State",
					caption: resources.localizableStrings.StateCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				CallContext: {
					uId: "48d4c410-1517-4fa9-8aee-0095e9f529a3",
					name: "CallContext",
					caption: resources.localizableStrings.CallContextCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				CallContextType: {
					uId: "b7afaf05-3349-4ff0-b816-929b28262dd8",
					name: "CallContextType",
					caption: resources.localizableStrings.CallContextTypeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
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
				Direction: {
					uId: "159acd33-055d-404d-992b-9cdfba6ac86d",
					name: "Direction",
					caption: resources.localizableStrings.DirectionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "CallDirection",
					referenceSchema: {
						name: "CallDirection",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.SysActiveCall;
	});