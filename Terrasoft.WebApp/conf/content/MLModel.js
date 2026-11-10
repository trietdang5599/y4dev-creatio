define("MLModel", ["terrasoft", "ext-base", "MLModelResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.MLModel", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.MLModel",
			singleton: true,
			uId: "f0d58f4a-303d-477c-8cf9-d00eaf04f32b",
			name: "MLModel",
			caption: resources.localizableStrings.MLModelCaption,
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
			description: resources.localizableStrings.MLModelDescription,
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
						calculatedValue: "a5742742-b158-4470-aa97-e8a8b9eaa806",
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
						calculatedValue: "\/Date(1794207607868+0700)\/",
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
						calculatedValue: "\/Date(1794207607869+0700)\/",
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
					uId: "736c30a7-c0ec-4fa9-b034-2552b319b633",
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
				Description: {
					uId: "9e53fd7c-dde4-4502-a64c-b9e34148108b",
					name: "Description",
					caption: resources.localizableStrings.DescriptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				TrainFrequency: {
					uId: "564a0aee-87ac-4689-9164-615feb8c6aa7",
					name: "TrainFrequency",
					caption: resources.localizableStrings.TrainFrequencyCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Integer"
				},
				TrainedOn: {
					uId: "7dcd6a05-f8cf-4f26-a162-852c0d390e12",
					name: "TrainedOn",
					caption: resources.localizableStrings.TrainedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				TriedToTrainOn: {
					uId: "90154141-9251-4342-981f-4c0acf2b8557",
					name: "TriedToTrainOn",
					caption: resources.localizableStrings.TriedToTrainOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				MetaData: {
					uId: "37801848-9109-4a6e-9426-e4e9df99c227",
					name: "MetaData",
					caption: resources.localizableStrings.MetaDataCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "{\n}"
					},
					dataValueTypeName: "MaxSizeText"
				},
				MetaDataLcz: {
					uId: "2ed22e17-707f-4fac-a992-4118fdf240bd",
					name: "MetaDataLcz",
					caption: resources.localizableStrings.MetaDataLczCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				TrainingSetQuery: {
					uId: "eeaf6c5e-39ec-43d3-9804-44f7aad138ff",
					name: "TrainingSetQuery",
					caption: resources.localizableStrings.TrainingSetQueryCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "new Select(userConnection)"
					},
					dataValueTypeName: "MaxSizeText"
				},
				RootSchemaUId: {
					uId: "4052a73f-aa84-4af8-88e1-33cfaf7dec09",
					name: "RootSchemaUId",
					caption: resources.localizableStrings.RootSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				State: {
					uId: "3489b79b-de7a-4a1c-b6ee-c1202ce67226",
					name: "State",
					caption: resources.localizableStrings.StateCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "MLModelState",
					referenceSchema: {
						name: "MLModelState",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "a241f7fd-00dc-4c4e-a461-f86c5663d630"
						}
					},
					dataValueTypeName: "Lookup"
				},
				InstanceMetric: {
					uId: "076fc8aa-541b-4a7a-8bb3-93a29ee60537",
					name: "InstanceMetric",
					caption: resources.localizableStrings.InstanceMetricCaption,
					dataValueType: Terrasoft.DataValueType.FLOAT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 18,
					precision: 2,
					dataValueTypeName: "Float2"
				},
				MetricThreshold: {
					uId: "aa12d9d8-4268-4b2b-8bc0-02e5b0479ea2",
					name: "MetricThreshold",
					caption: resources.localizableStrings.MetricThresholdCaption,
					dataValueType: Terrasoft.DataValueType.FLOAT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 18,
					precision: 2,
					dataValueTypeName: "Float2"
				},
				PredictionEnabled: {
					uId: "604e5349-5cac-4321-ae4e-0e2c051b40bd",
					name: "PredictionEnabled",
					caption: resources.localizableStrings.PredictionEnabledCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: true
					},
					dataValueTypeName: "Boolean"
				},
				TrainSessionId: {
					uId: "daba050d-dd24-4318-88e8-39c0ed224874",
					name: "TrainSessionId",
					caption: resources.localizableStrings.TrainSessionIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				MLProblemType: {
					uId: "f9b286c5-f7e4-4903-946e-3ff5e9f0d126",
					name: "MLProblemType",
					caption: resources.localizableStrings.MLProblemTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MLProblemType",
					referenceSchema: {
						name: "MLProblemType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				ModelInstanceUId: {
					uId: "506e63a6-8aa9-46c9-9dd4-925c32021296",
					name: "ModelInstanceUId",
					caption: resources.localizableStrings.ModelInstanceUIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				LastError: {
					uId: "793e2e39-52cf-4c85-9e48-88b495f7ff0c",
					name: "LastError",
					caption: resources.localizableStrings.LastErrorCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				Notes: {
					uId: "5cf9d816-7f33-4b2b-b8ad-1501aa3ff764",
					name: "Notes",
					caption: resources.localizableStrings.NotesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				BatchPredictedOn: {
					uId: "c8ee1799-f14e-4aad-b913-e3c3c16b1b80",
					name: "BatchPredictedOn",
					caption: resources.localizableStrings.BatchPredictedOnCaption,
					dataValueType: Terrasoft.DataValueType.DATE_TIME,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "DateTime"
				},
				BatchPredictionQuery: {
					uId: "0f24d427-9ad0-48f3-aa43-5641c7b15a4c",
					name: "BatchPredictionQuery",
					caption: resources.localizableStrings.BatchPredictionQueryCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				TargetColumnUId: {
					uId: "db5a1dd8-8e54-4367-bd56-984f22db12fc",
					name: "TargetColumnUId",
					caption: resources.localizableStrings.TargetColumnUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				BatchPredictionStartMethod: {
					uId: "bc0eb497-2a76-49b4-bba4-98fcb1e32af2",
					name: "BatchPredictionStartMethod",
					caption: resources.localizableStrings.BatchPredictionStartMethodCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MLTaskStartMethod",
					referenceSchema: {
						name: "MLTaskStartMethod",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				TrainingMinimumRecordsCount: {
					uId: "99275f57-7f37-4fd5-8b7c-424fdb8c3c5d",
					name: "TrainingMinimumRecordsCount",
					caption: resources.localizableStrings.TrainingMinimumRecordsCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 100
					},
					dataValueTypeName: "Integer"
				},
				TrainingMaxRecordsCount: {
					uId: "5e98be1f-c32b-401e-a72f-7439fd52dbba",
					name: "TrainingMaxRecordsCount",
					caption: resources.localizableStrings.TrainingMaxRecordsCountCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 75000
					},
					dataValueTypeName: "Integer"
				},
				TrainingFilterData: {
					uId: "0349a6eb-617b-476a-a594-6d587aa871b6",
					name: "TrainingFilterData",
					caption: resources.localizableStrings.TrainingFilterDataCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Binary"
				},
				PredictedResultColumnUId: {
					uId: "5f778292-a679-4ef2-829a-1d2730b81ec2",
					name: "PredictedResultColumnUId",
					caption: resources.localizableStrings.PredictedResultColumnUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				TrainingOutputFilterData: {
					uId: "dc14983a-57e2-414d-9c45-0a7c43aa382e",
					name: "TrainingOutputFilterData",
					caption: resources.localizableStrings.TrainingOutputFilterDataCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Binary"
				},
				BatchPredictionFilterData: {
					uId: "bddb237e-fac4-4795-8764-fdf68d8146fd",
					name: "BatchPredictionFilterData",
					caption: resources.localizableStrings.BatchPredictionFilterDataCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Binary"
				},
				MLConfidentValueMethod: {
					uId: "813876a1-a87e-4e68-8560-d9c61d37bbf2",
					name: "MLConfidentValueMethod",
					caption: resources.localizableStrings.MLConfidentValueMethodCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MLConfidentValueMethod",
					referenceSchema: {
						name: "MLConfidentValueMethod",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: {
							value: "5ce3f5dc-f541-4d6c-b7f8-819c33139b7f"
						}
					},
					dataValueTypeName: "Lookup"
				},
				ConfidentValueLowEdge: {
					uId: "ac91d6c5-6153-46c7-846a-1b5738dc2fc4",
					name: "ConfidentValueLowEdge",
					caption: resources.localizableStrings.ConfidentValueLowEdgeCaption,
					dataValueType: Terrasoft.DataValueType.FLOAT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 18,
					precision: 2,
					dataValueTypeName: "Float2"
				},
				CFUserColumnPath: {
					uId: "c455f536-c33d-4f53-a5c7-1d9e8982cff3",
					name: "CFUserColumnPath",
					caption: resources.localizableStrings.CFUserColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				CFItemColumnPath: {
					uId: "40918ea8-2a5f-497a-9dc9-fd69ef47b4b9",
					name: "CFItemColumnPath",
					caption: resources.localizableStrings.CFItemColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				CFInteractionValueColumnPath: {
					uId: "539587f7-13b7-4cc8-82c2-08ec77e08100",
					name: "CFInteractionValueColumnPath",
					caption: resources.localizableStrings.CFInteractionValueColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				ListPredictResultSchemaUId: {
					uId: "d0953cec-19dc-4134-bb88-18a9cd4eaae5",
					name: "ListPredictResultSchemaUId",
					caption: resources.localizableStrings.ListPredictResultSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				ListPredictResultSubjectColumn: {
					uId: "7c18fdbc-9258-41c1-a5a2-7194ea2610ea",
					name: "ListPredictResultSubjectColumn",
					caption: resources.localizableStrings.ListPredictResultSubjectColumnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ListPredictResultObjectColumn: {
					uId: "d7d07f8a-5e8a-426c-ae4a-a4b88069d77c",
					name: "ListPredictResultObjectColumn",
					caption: resources.localizableStrings.ListPredictResultObjectColumnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ListPredictResultValueColumn: {
					uId: "9d052301-6653-42b9-acc8-0dc988afc9ad",
					name: "ListPredictResultValueColumn",
					caption: resources.localizableStrings.ListPredictResultValueColumnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ListPredictResultModelColumn: {
					uId: "a9f0280b-9a29-4ef3-87ad-32e543a57734",
					name: "ListPredictResultModelColumn",
					caption: resources.localizableStrings.ListPredictResultModelColumnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ListPredictResultDateColumn: {
					uId: "f041f086-2b10-4c4c-9b57-25236c891492",
					name: "ListPredictResultDateColumn",
					caption: resources.localizableStrings.ListPredictResultDateColumnCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				FactorsCounts: {
					uId: "e42aafab-672a-4444-a293-dd07a7434898",
					name: "FactorsCounts",
					caption: resources.localizableStrings.FactorsCountsCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "2; 5; 10; 15; 20; 50; 100"
					},
					size: 250,
					dataValueTypeName: "MediumText"
				},
				RegularizationValues: {
					uId: "492d9f04-91b8-4f9a-994a-39a8e6bf3efa",
					name: "RegularizationValues",
					caption: resources.localizableStrings.RegularizationValuesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: "0.1; 2; 5; 10; 15; 20; 25"
					},
					size: 250,
					dataValueTypeName: "MediumText"
				},
				PredictionSchemaUId: {
					uId: "ffedfecc-b449-2667-61df-3cd62b305b75",
					name: "PredictionSchemaUId",
					caption: resources.localizableStrings.PredictionSchemaUIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				LowerScoreThreshold: {
					uId: "1f53be63-a6af-4d56-bcfa-359532e4f7ff",
					name: "LowerScoreThreshold",
					caption: resources.localizableStrings.LowerScoreThresholdCaption,
					dataValueType: Terrasoft.DataValueType.FLOAT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 0.3
					},
					size: 20,
					precision: 4,
					dataValueTypeName: "Float4"
				},
				LastTrainingError: {
					uId: "aee98bfe-4872-d6a5-ef3d-b06afaa3f476",
					name: "LastTrainingError",
					caption: resources.localizableStrings.LastTrainingErrorCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "MLError",
					referenceSchema: {
						name: "MLError",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				SequenceItemValueColumnPath: {
					uId: "896dc1cc-8a21-61d1-7c3e-ccb4831d11cb",
					name: "SequenceItemValueColumnPath",
					caption: resources.localizableStrings.SequenceItemValueColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				SequenceItemPositionColumnPath: {
					uId: "8843aee6-538f-57f8-02ae-383554fbe6ef",
					name: "SequenceItemPositionColumnPath",
					caption: resources.localizableStrings.SequenceItemPositionColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				SequenceIdentifierColumnPath: {
					uId: "87256965-4d21-8957-8ffd-852deeb913d1",
					name: "SequenceIdentifierColumnPath",
					caption: resources.localizableStrings.SequenceIdentifierColumnPathCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				},
				OpenaiApiKey: {
					uId: "1d272df2-dc16-e0bb-b155-aef8f74445b7",
					name: "OpenaiApiKey",
					caption: resources.localizableStrings.OpenaiApiKeyCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				LlmModelPrompt: {
					uId: "0fe63c77-1ab6-ba24-8ac2-9ada8a4f6e33",
					name: "LlmModelPrompt",
					caption: resources.localizableStrings.LlmModelPromptCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "RichText"
				},
				LlmModelName: {
					uId: "2e2a0f0b-db2b-c543-abfc-cbb5db69a5e9",
					name: "LlmModelName",
					caption: resources.localizableStrings.LlmModelNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				LlmModelTemperature: {
					uId: "5523b5a6-b5d0-c765-7734-0a5980048dae",
					name: "LlmModelTemperature",
					caption: resources.localizableStrings.LlmModelTemperatureCaption,
					dataValueType: Terrasoft.DataValueType.FLOAT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					size: 18,
					precision: 2,
					dataValueTypeName: "Float2"
				},
				DocumentMaxChunkSize: {
					uId: "1a847f96-71ad-8fa6-6202-fe68e558c6b1",
					name: "DocumentMaxChunkSize",
					caption: resources.localizableStrings.DocumentMaxChunkSizeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 4000
					},
					dataValueTypeName: "Integer"
				},
				DocumentChunkSizeOverlap: {
					uId: "081bef1d-02af-259e-ba2b-1e5875f7f46b",
					name: "DocumentChunkSizeOverlap",
					caption: resources.localizableStrings.DocumentChunkSizeOverlapCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.CONST,
						value: 200
					},
					dataValueTypeName: "Integer"
				}
			}
		});
		return Terrasoft.MLModel;
	});