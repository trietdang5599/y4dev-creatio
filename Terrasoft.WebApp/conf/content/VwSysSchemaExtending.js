define("VwSysSchemaExtending", ["terrasoft", "ext-base", "VwSysSchemaExtendingResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwSysSchemaExtending", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwSysSchemaExtending",
			singleton: true,
			uId: "58474b1f-f909-42bc-8663-5dc081875a67",
			name: "VwSysSchemaExtending",
			caption: resources.localizableStrings.VwSysSchemaExtendingCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "BaseSchemaId",
			primaryDisplayColumnName: "TopExtendingCaption",
			isDBView: true,
			description: resources.localizableStrings.VwSysSchemaExtendingDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				TopExtendingSchemaId: {
					uId: "cb598230-8d89-ed49-124d-8f280990999d",
					name: "TopExtendingSchemaId",
					caption: resources.localizableStrings.TopExtendingSchemaIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				BaseSchemaId: {
					uId: "049ee76b-194a-cf70-0f0e-a2c670fc254d",
					name: "BaseSchemaId",
					caption: resources.localizableStrings.BaseSchemaIdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				TopExtendingCaption: {
					uId: "579906fb-fbe4-cd29-6c45-1c867ca8a2cd",
					name: "TopExtendingCaption",
					caption: resources.localizableStrings.TopExtendingCaptionCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 500,
					dataValueTypeName: "LongText"
				}
			}
		});
		return Terrasoft.VwSysSchemaExtending;
	});