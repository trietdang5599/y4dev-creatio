define("VwSysAdminOperationGrantee", ["terrasoft", "ext-base", "VwSysAdminOperationGranteeResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.VwSysAdminOperationGrantee", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.VwSysAdminOperationGrantee",
			singleton: true,
			uId: "01b6a706-8496-4038-b5df-f8aae1979426",
			name: "VwSysAdminOperationGrantee",
			caption: resources.localizableStrings.VwSysAdminOperationGranteeCaption,
			administratedByRecords: false,
			administratedByOperations: false,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			isDBView: true,
			description: resources.localizableStrings.VwSysAdminOperationGranteeDescription,
			parentUId: "00000000-0000-0000-0000-000000000000",
			columns: {
				CanExecute: {
					uId: "427d4e42-eb66-e7eb-c51f-bef524f301aa",
					name: "CanExecute",
					caption: resources.localizableStrings.CanExecuteCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				SysAdminOperation: {
					uId: "86909788-ace2-8cb7-b6f0-a1f6b2573c88",
					name: "SysAdminOperation",
					caption: resources.localizableStrings.SysAdminOperationCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysAdminOperation",
					referenceSchema: {
						name: "SysAdminOperation",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				SysAdminUnit: {
					uId: "31cea678-a885-4a3c-f117-b75dbbc2cb27",
					name: "SysAdminUnit",
					caption: resources.localizableStrings.SysAdminUnitCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysAdminUnit",
					referenceSchema: {
						name: "SysAdminUnit",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Id: {
					uId: "b015c8eb-33ea-f191-9123-f4079b0f2194",
					name: "Id",
					caption: resources.localizableStrings.IdCaption,
					dataValueType: Terrasoft.DataValueType.GUID,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					dataValueTypeName: "Guid"
				}
			}
		});
		return Terrasoft.VwSysAdminOperationGrantee;
	});