define("VwCopilotSessionIntent", ["terrasoft", "ext-base", "VwCopilotSessionIntentResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwCopilotSessionIntent", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwCopilotSessionIntent",
			singleton: true,
			uId: "ab99e342-ce78-4481-9407-512fe261930a",
			name: "VwCopilotSessionIntent",
			caption: resources.localizableStrings.VwCopilotSessionIntentCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isDBView: true,
			description: resources.localizableStrings.VwCopilotSessionIntentDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				TotalTokens: {
					uId: "c4a3a8cb-af9d-c9aa-156d-d19bfbf1f210",
					name: "TotalTokens",
					caption: resources.localizableStrings.TotalTokensCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				Intent: {
					uId: "1148bcf4-5f2d-f6f7-a106-9d40e2f295e8",
					name: "Intent",
					caption: resources.localizableStrings.IntentCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "VwSysSchemaInfo",
					referenceSchema: {
						name: "VwSysSchemaInfo",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Caption"
					},
					dataValueTypeName: "Lookup"
				},
				Id: {
					uId: "84b0c317-29a0-f59e-8fd4-74af7580a8b9",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "7642fdb2-19ab-4813-ba51-fb36ef78a29f",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				CopilotSession: {
					uId: "262a775b-7dde-6408-15a9-d363bbde6ef4",
					name: "CopilotSession",
					caption: resources.localizableStrings.CopilotSessionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "CopilotSessionEnt",
					referenceSchema: {
						name: "CopilotSessionEnt",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Title"
					},
					dataValueTypeName: "Lookup"
				},
				TotalActions: {
					uId: "10e7eb3d-1572-6a75-af1a-6e875a4a06ef",
					name: "TotalActions",
					caption: resources.localizableStrings.TotalActionsCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				}
			}
		});
		return Terrasoft.VwCopilotSessionIntent;
	});