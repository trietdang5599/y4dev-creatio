define("Favorites", ["terrasoft", "ext-base", "FavoritesResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.Favorites", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.Favorites",
			singleton: true,
			uId: "b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62",
			name: "Favorites",
			caption: resources.localizableStrings.FavoritesCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			description: resources.localizableStrings.FavoritesDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "67f86eb6-ce69-4b9f-8266-91d261f6596d",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					defaultValue: {
						source: Terrasoft.EntitySchemaColumnDefSource.SYSTEM_VALUE,
						value: "AutoGuid",
						calculatedValue: "e82b9d13-a15e-4083-b312-bf75d02aea1b",
						sourceValue: "03fac162-6a98-4f29-8d28-dc2f23ab48da"
					},
					dataValueTypeName: "Guid"
				},
				Contact: {
					uId: "26a9bb7b-13ac-483e-b9f7-b509de43c77d",
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
				KnowledgeBase: {
					uId: "4635886d-64eb-41ec-acf4-a974bcab3964",
					name: "KnowledgeBase",
					caption: resources.localizableStrings.KnowledgeBaseCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "KnowledgeBase",
					referenceSchema: {
						name: "KnowledgeBase",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.Favorites;
	});