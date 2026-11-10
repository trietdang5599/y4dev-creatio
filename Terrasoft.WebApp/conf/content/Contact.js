define("Contact", ["terrasoft", "ext-base", "ContactResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.Contact", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.Contact",
			singleton: true,
			uId: "16be3651-8fe2-4159-8dd0-a803d4683dd3",
			name: "Contact",
			caption: resources.localizableStrings.ContactCaption,
			administratedByRecords: true,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Name",
			primaryImageColumnName: "Photo",
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.ContactDescription,
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
						calculatedValue: "bfc60acc-ccf0-4bd8-8817-1dad0836e33a",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				Name: {
					uId: "a5cca792-47dd-428a-83fb-5c92bdd97ff8",
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
				Owner: {
					uId: "64fa90dd-0cf5-45d7-88e4-6fa691d3c425",
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
						calculatedValue: "\/Date(1794207573883+0700)\/",
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
						calculatedValue: "\/Date(1794207573884+0700)\/",
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
				Dear: {
					uId: "c5d7c4d3-f308-40d3-8469-6ab6882bd70a",
					name: "Dear",
					caption: resources.localizableStrings.DearCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				SalutationType: {
					uId: "f16cbd03-a8a8-4bdd-9970-a0c7985a1996",
					name: "SalutationType",
					caption: resources.localizableStrings.SalutationTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "ContactSalutationType",
					referenceSchema: {
						name: "ContactSalutationType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Gender: {
					uId: "3a3317c0-09f6-4a26-998b-018d1caa2c36",
					name: "Gender",
					caption: resources.localizableStrings.GenderCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "Gender",
					referenceSchema: {
						name: "Gender",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Account: {
					uId: "5c6ca10e-1180-4c1e-8a50-55a72ff9bdd4",
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
				DecisionRole: {
					uId: "f70c762a-1038-49a7-a3e8-f24fb8cfdeef",
					name: "DecisionRole",
					caption: resources.localizableStrings.DecisionRoleCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "ContactDecisionRole",
					referenceSchema: {
						name: "ContactDecisionRole",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Type: {
					uId: "a49571cc-a9a9-4c3e-a346-46c466e9a0d3",
					name: "Type",
					caption: resources.localizableStrings.TypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "ContactType",
					referenceSchema: {
						name: "ContactType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Job: {
					uId: "344436e4-9d6b-4a30-936f-f8ea45f2adb4",
					name: "Job",
					caption: resources.localizableStrings.JobCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "Job",
					referenceSchema: {
						name: "Job",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				JobTitle: {
					uId: "8b680ac7-e46c-466c-b630-e5cb4da13a55",
					name: "JobTitle",
					caption: resources.localizableStrings.JobTitleCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Department: {
					uId: "94cb8750-ad6f-4e80-b553-7d9e194a856e",
					name: "Department",
					caption: resources.localizableStrings.DepartmentCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "Department",
					referenceSchema: {
						name: "Department",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				BirthDate: {
					uId: "3f08db69-6d2f-4b1c-87a4-acddc6c3b9d6",
					name: "BirthDate",
					caption: resources.localizableStrings.BirthDateCaption,
					dataValueType: Terrasoft.DataValueType.DATE,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Date"
				},
				Phone: {
					uId: "84c5808a-7859-4198-ba6a-243c95a3300b",
					name: "Phone",
					caption: resources.localizableStrings.PhoneCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				MobilePhone: {
					uId: "98e085c7-ad4d-4ac6-8c1c-09be09876d44",
					name: "MobilePhone",
					caption: resources.localizableStrings.MobilePhoneCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				HomePhone: {
					uId: "0a455b85-133c-4944-aff1-2ce7f7e50fee",
					name: "HomePhone",
					caption: resources.localizableStrings.HomePhoneCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Skype: {
					uId: "5ff9516e-251c-41de-a085-67fa199cdfe7",
					name: "Skype",
					caption: resources.localizableStrings.SkypeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Email: {
					uId: "dbf202ec-c444-479b-bcf4-d8e5b1863201",
					name: "Email",
					caption: resources.localizableStrings.EmailCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				AddressType: {
					uId: "5ad029c6-0fa7-4db6-8fef-c72a0f535682",
					name: "AddressType",
					caption: resources.localizableStrings.AddressTypeCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "AddressType",
					referenceSchema: {
						name: "AddressType",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Address: {
					uId: "0fb61bc8-a195-4d90-aecc-18b411b51814",
					name: "Address",
					caption: resources.localizableStrings.AddressCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					dataValueTypeName: "MaxSizeText"
				},
				City: {
					uId: "cf58ca72-531b-4dd2-b4d5-f0d5b7c556f6",
					name: "City",
					caption: resources.localizableStrings.CityCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "City",
					referenceSchema: {
						name: "City",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Region: {
					uId: "0e50f221-470e-482b-8580-f61c74b8b1c1",
					name: "Region",
					caption: resources.localizableStrings.RegionCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "Region",
					referenceSchema: {
						name: "Region",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Zip: {
					uId: "0737d99d-eebc-4b8e-9859-634414f7cc04",
					name: "Zip",
					caption: resources.localizableStrings.ZipCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				Country: {
					uId: "9463dea9-2576-4d37-812f-342ee57ddf32",
					name: "Country",
					caption: resources.localizableStrings.CountryCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "Country",
					referenceSchema: {
						name: "Country",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				DoNotUseEmail: {
					uId: "1b1d8f33-4d26-4353-a1ed-07e11fc82112",
					name: "DoNotUseEmail",
					caption: resources.localizableStrings.DoNotUseEmailCaption,
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
				DoNotUseCall: {
					uId: "a6bcf6fe-a06d-42ed-a263-f829ece05fd9",
					name: "DoNotUseCall",
					caption: resources.localizableStrings.DoNotUseCallCaption,
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
				DoNotUseFax: {
					uId: "d9deaed5-8e42-40c0-9bb1-a6bfe6716ca4",
					name: "DoNotUseFax",
					caption: resources.localizableStrings.DoNotUseFaxCaption,
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
				DoNotUseSms: {
					uId: "7e295464-4dee-4448-832c-97434b1f2943",
					name: "DoNotUseSms",
					caption: resources.localizableStrings.DoNotUseSmsCaption,
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
				DoNotUseMail: {
					uId: "238d9e74-ff12-4e40-8467-350bd9d4b58d",
					name: "DoNotUseMail",
					caption: resources.localizableStrings.DoNotUseMailCaption,
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
				Notes: {
					uId: "fd73da4b-2b3d-483e-89d2-383a6db099ac",
					name: "Notes",
					caption: resources.localizableStrings.NotesCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "MaxSizeText"
				},
				Facebook: {
					uId: "5282096d-e4af-470a-bfbc-3e3542f04515",
					name: "Facebook",
					caption: resources.localizableStrings.FacebookCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				LinkedIn: {
					uId: "644a4505-9c9c-477e-8037-b73c14d109df",
					name: "LinkedIn",
					caption: resources.localizableStrings.LinkedInCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Twitter: {
					uId: "83239d8b-efb5-4a28-80b7-219bdbd2a752",
					name: "Twitter",
					caption: resources.localizableStrings.TwitterCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				FacebookId: {
					uId: "21a16860-9d95-4f60-9c23-66b3392ea5f4",
					name: "FacebookId",
					caption: resources.localizableStrings.FacebookIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				LinkedInId: {
					uId: "10ebe04c-3e1e-4606-93a5-dbdfdb230e71",
					name: "LinkedInId",
					caption: resources.localizableStrings.LinkedInIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				TwitterId: {
					uId: "2e96804c-cf03-4ab0-a532-79b032dc4529",
					name: "TwitterId",
					caption: resources.localizableStrings.TwitterIdCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				ContactPhoto: {
					uId: "327e44bd-0b97-48c0-b11a-4686d6605b4f",
					name: "ContactPhoto",
					caption: resources.localizableStrings.ContactPhotoCaption,
					dataValueType: Terrasoft.DataValueType.BLOB,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Binary"
				},
				TwitterAFDA: {
					uId: "d1732e56-de5f-4bf6-ac22-228d7f768aa3",
					name: "TwitterAFDA",
					caption: resources.localizableStrings.TwitterAFDACaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "SocialAccount",
					referenceSchema: {
						name: "SocialAccount",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Login"
					},
					dataValueTypeName: "Lookup"
				},
				FacebookAFDA: {
					uId: "3ed551e5-7963-4056-95fb-6b6c871145af",
					name: "FacebookAFDA",
					caption: resources.localizableStrings.FacebookAFDACaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "SocialAccount",
					referenceSchema: {
						name: "SocialAccount",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Login"
					},
					dataValueTypeName: "Lookup"
				},
				LinkedInAFDA: {
					uId: "b3cf002a-466c-4ea7-a457-b3630ec24e9d",
					name: "LinkedInAFDA",
					caption: resources.localizableStrings.LinkedInAFDACaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 2,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "SocialAccount",
					referenceSchema: {
						name: "SocialAccount",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Login"
					},
					dataValueTypeName: "Lookup"
				},
				Photo: {
					uId: "0495373c-5053-4ae3-b553-dc92779c4702",
					name: "Photo",
					caption: resources.localizableStrings.PhotoCaption,
					dataValueType: Terrasoft.DataValueType.IMAGELOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					isLookup: true,
					referenceSchemaName: "SysImage",
					referenceSchema: {
						name: "SysImage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "ImageLookup"
				},
				GPSN: {
					uId: "b903e71d-74cd-4b79-9dd9-d0c84ef6ad44",
					name: "GPSN",
					caption: resources.localizableStrings.GPSNCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				GPSE: {
					uId: "b9021fa0-6606-4027-8335-bf0624b58218",
					name: "GPSE",
					caption: resources.localizableStrings.GPSECaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 2,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					size: 50,
					dataValueTypeName: "ShortText"
				},
				Surname: {
					uId: "771a60e2-020c-4dd2-8512-b428b8a47dba",
					name: "Surname",
					caption: resources.localizableStrings.SurnameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				GivenName: {
					uId: "cc26b1c5-4254-4287-9c15-0b5acd319811",
					name: "GivenName",
					caption: resources.localizableStrings.GivenNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				MiddleName: {
					uId: "33a879a3-d466-4b3f-b529-377a69ff0819",
					name: "MiddleName",
					caption: resources.localizableStrings.MiddleNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Confirmed: {
					uId: "ced280cc-7423-4175-9896-ea592a9e81a6",
					name: "Confirmed",
					caption: resources.localizableStrings.ConfirmedCaption,
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
				Completeness: {
					uId: "60367403-6019-4d03-971d-169a5ec27542",
					name: "Completeness",
					caption: resources.localizableStrings.CompletenessCaption,
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
				Language: {
					uId: "a855b7ae-45be-4d73-9074-9d84e4ae66c4",
					name: "Language",
					caption: resources.localizableStrings.LanguageCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysLanguage",
					referenceSchema: {
						name: "SysLanguage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SETTINGS,
						value: "DefaultMessageLanguage",
						calculatedValue: "6ebc31fa-ee6c-48e9-81bf-8003ac03b019"
					},
					dataValueTypeName: "Lookup"
				},
				Age: {
					uId: "bcdc7a32-4332-4caf-858d-0078b56856fe",
					name: "Age",
					caption: resources.localizableStrings.AgeCaption,
					dataValueType: Terrasoft.DataValueType.INTEGER,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					dataValueTypeName: "Integer"
				},
				IsEmailConfirmed: {
					uId: "f963730e-7256-f35d-03ff-ba60a1d641d7",
					name: "IsEmailConfirmed",
					caption: resources.localizableStrings.IsEmailConfirmedCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				}
			}
		});
		return Terrasoft.Contact;
	});