define("SysDataSegment", ["terrasoft", "ext-base", "SysDataSegmentResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysDataSegment", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysDataSegment",
			singleton: true,
			uId: "91cb9657-9d75-4e75-ac6c-4704630636db",
			name: "SysDataSegment",
			caption: resources.localizableStrings.SysDataSegmentCaption,
			administratedByRecords: true,
			administratedByOperations: true,
			isTrackChangesInDB: true,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Name",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.SysDataSegmentDescription,
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
						calculatedValue: "1d79fb0a-6858-4ceb-bad3-3d3f3f8a9093",
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
						calculatedValue: "\/Date(1794207640443+0700)\/",
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
						calculatedValue: "\/Date(1794207640443+0700)\/",
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
					uId: "2835a0ce-d53f-4c6c-8f4c-921ea7746d35",
					name: "Name",
					caption: resources.localizableStrings.NameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SegmentDataTableName: {
					uId: "e01c8a80-e47b-8bb4-5fcf-7a64dd6abb3e",
					name: "SegmentDataTableName",
					caption: resources.localizableStrings.SegmentDataTableNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SysStatus: {
					uId: "cce38b97-2cfa-9efe-154f-1e71b273e651",
					name: "SysStatus",
					caption: resources.localizableStrings.SysStatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysSegmentSystemStatus",
					referenceSchema: {
						name: "SysSegmentSystemStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "831af280-4c6a-4a2a-a800-92a54e3f683a"
						}
					},
					dataValueTypeName: "Lookup"
				},
				SysRefreshMode: {
					uId: "8eb3d9ba-4213-f828-489d-2443ecc8a326",
					name: "SysRefreshMode",
					caption: resources.localizableStrings.SysRefreshModeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysSegmentRefreshMode",
					referenceSchema: {
						name: "SysSegmentRefreshMode",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "784b7c0d-29dd-4868-a0df-fa026730820b"
						}
					},
					dataValueTypeName: "Lookup"
				},
				SysExitMode: {
					uId: "ea43c428-aeb2-ed8a-406b-49dfea30b942",
					name: "SysExitMode",
					caption: resources.localizableStrings.SysExitModeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysSegmentExitMode",
					referenceSchema: {
						name: "SysSegmentExitMode",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "2766f77a-f64c-4dce-b539-e7fc03212a87"
						}
					},
					dataValueTypeName: "Lookup"
				},
				ExitFilterData: {
					uId: "3344dc97-dda3-cc47-ae60-fd557755ff49",
					name: "ExitFilterData",
					caption: resources.localizableStrings.ExitFilterDataCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				EntryFilterData: {
					uId: "057db8ef-af9c-f4c3-0c2d-e31d0f5513a1",
					name: "EntryFilterData",
					caption: resources.localizableStrings.EntryFilterDataCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				EntitySchema: {
					uId: "ff1abc3d-48e8-f6a8-0110-4013d3c8821c",
					name: "EntitySchema",
					caption: resources.localizableStrings.EntitySchemaCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "VwEntityObjects",
					referenceSchema: {
						name: "VwEntityObjects",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Title"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "16be3651-8fe2-4159-8dd0-a803d4683dd3"
						}
					},
					dataValueTypeName: "Lookup"
				},
				Description: {
					uId: "256a82bf-ff1c-4997-5feb-9d84cd3ae885",
					name: "Description",
					caption: resources.localizableStrings.DescriptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				SysUserStatus: {
					uId: "485834b0-c526-af5c-8f70-eb52e45803f5",
					name: "SysUserStatus",
					caption: resources.localizableStrings.SysUserStatusCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysSegmentUserStatus",
					referenceSchema: {
						name: "SysSegmentUserStatus",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "08f98887-eacc-4510-8d94-648f8f5d5f2f"
						}
					},
					dataValueTypeName: "Lookup"
				},
				RecordCount: {
					uId: "28f66e93-9862-45b0-0da4-c1b4cb0c723b",
					name: "RecordCount",
					caption: resources.localizableStrings.RecordCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				LastActualizationDuration: {
					uId: "4d1ad1a6-de82-5669-6fed-85a97494ce54",
					name: "LastActualizationDuration",
					caption: resources.localizableStrings.LastActualizationDurationCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				LastActualizationDate: {
					uId: "ef8a31e0-c251-f2b4-4ce6-11feb1d6c385",
					name: "LastActualizationDate",
					caption: resources.localizableStrings.LastActualizationDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				LastActualizationError: {
					uId: "8b141276-29e5-f74b-b0e7-26b08a35a8e5",
					name: "LastActualizationError",
					caption: resources.localizableStrings.LastActualizationErrorCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				IsUsableWhileUpdating: {
					uId: "71319587-008e-26b5-769f-8caf6e89e8ff",
					name: "IsUsableWhileUpdating",
					caption: resources.localizableStrings.IsUsableWhileUpdatingCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: false
					},
					dataValueTypeName: "Boolean"
				}
			}
		});
		return Terrasoft.SysDataSegment;
	});