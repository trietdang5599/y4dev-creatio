define("VwSysProcessSchemaUserRight", ["terrasoft", "ext-base", "VwSysProcessSchemaUserRightResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwSysProcessSchemaUserRight", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwSysProcessSchemaUserRight",
			singleton: true,
			uId: "a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0",
			name: "VwSysProcessSchemaUserRight",
			caption: resources.localizableStrings.VwSysProcessSchemaUserRightCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isDBView: true,
			description: resources.localizableStrings.VwSysProcessSchemaUserRightDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				Id: {
					uId: "07d99fc6-e660-ebf6-f047-1ed37d55f93c",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				},
				SysAdminUnit: {
					uId: "008c0bf1-dd97-4cfe-5d71-16bf25aedc39",
					name: "SysAdminUnit",
					caption: resources.localizableStrings.SysAdminUnitCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				SysSchema: {
					uId: "f99bb190-3298-0c75-da20-ac0752ae8f34",
					name: "SysSchema",
					caption: resources.localizableStrings.SysSchemaCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isLookup: true,
					referenceSchemaName: "SysSchema",
					referenceSchema: {
						name: "SysSchema",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Caption"
					},
					dataValueTypeName: "Lookup"
				}
			}
		});
		return Terrasoft.VwSysProcessSchemaUserRight;
	});