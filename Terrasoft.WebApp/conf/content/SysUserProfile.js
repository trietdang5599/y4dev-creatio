define("SysUserProfile", ["terrasoft", "ext-base", "SysUserProfileResources"],
	function(Terrasoft, Ext, resources) {
		Ext.define("Terrasoft.data.models.SysUserProfile", {
			extend: "Terrasoft.BaseEntitySchema",
			alternateClassName: "Terrasoft.SysUserProfile",
			singleton: true,
			uId: "15e02b73-2eb5-4c03-8dee-739001875390",
			name: "SysUserProfile",
			caption: resources.localizableStrings.SysUserProfileCaption,
			administratedByRecords: false,
			administratedByOperations: true,
			isTrackChangesInDB: false,
			useMasterRecordRights: false,
			masterRecordSchemaName: "",
			primaryColumnName: "Id",
			primaryDisplayColumnName: "Username",
			isVirtual: true,
			administratedByColumns: true,
			createdOnColumnUId: "e80190a5-03b2-4095-90f7-a193a960adee",
			createdByColumnUId: "ebf6bb93-8aa6-4a01-900d-c6ea67affe21",
			modifiedOnColumnUId: "9928edec-4272-425a-93bb-48743fee4b04",
			modifiedByColumnUId: "3015559e-cbc6-406a-88af-07f7930be832",
			description: resources.localizableStrings.SysUserProfileDescription,
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
						calculatedValue: "13016fa2-6547-4def-a572-588ce3edc27e",
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
						calculatedValue: "\/Date(1794207675775+0700)\/",
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
						calculatedValue: "\/Date(1794207675776+0700)\/",
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
				DateTimeFormat: {
					uId: "5eae7609-959b-14e1-eaeb-cb578ea9732e",
					name: "DateTimeFormat",
					caption: resources.localizableStrings.DateTimeFormatCaption,
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
					dataValueTypeName: "Lookup"
				},
				Email: {
					uId: "aa5857f2-bd1f-d71d-56ee-0023d8609e98",
					name: "Email",
					caption: resources.localizableStrings.EmailCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: true,
					size: 250,
					dataValueTypeName: "EmailText"
				},
				Username: {
					uId: "d20031bc-f8ba-a4f4-6210-36f26f5de359",
					name: "Username",
					caption: resources.localizableStrings.UsernameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: false,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				Photo: {
					uId: "a134b236-83e3-567e-3dfa-0574e77ba675",
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
				FullName: {
					uId: "140a7094-abb0-e28d-e5dc-24ed7a960df3",
					name: "FullName",
					caption: resources.localizableStrings.FullNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: false,
					isSensitiveData: true,
					isRequired: true,
					size: 250,
					dataValueTypeName: "MediumText"
				},
				TimeZone: {
					uId: "74bb4924-91b6-17f4-144e-555c552ada8d",
					name: "TimeZone",
					caption: resources.localizableStrings.TimeZoneCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "TimeZone",
					referenceSchema: {
						name: "TimeZone",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				EnablePopups: {
					uId: "64a640d6-ad31-07db-f1bd-bcb3d684c53a",
					name: "EnablePopups",
					caption: resources.localizableStrings.EnablePopupsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Language: {
					uId: "dd203f0d-9267-0b7c-4729-2328a70520ae",
					name: "Language",
					caption: resources.localizableStrings.LanguageCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isRequired: true,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysLanguage",
					referenceSchema: {
						name: "SysLanguage",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				LastName: {
					uId: "b4d51aee-6883-0d93-a4ca-c2da756b3f13",
					name: "LastName",
					caption: resources.localizableStrings.LastNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 50,
					isFormatValidated: true,
					dataValueTypeName: "ShortText"
				},
				MiddleName: {
					uId: "33ca712f-dfb8-ee74-7aee-27ee1537f0d9",
					name: "MiddleName",
					caption: resources.localizableStrings.MiddleNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					isFormatValidated: true,
					dataValueTypeName: "MediumText"
				},
				FirstName: {
					uId: "41bdb5c9-f512-ab61-8bee-f3fa9f900eae",
					name: "FirstName",
					caption: resources.localizableStrings.FirstNameCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					isFormatValidated: true,
					dataValueTypeName: "MediumText"
				},
				DisableAdvancedVisualEffects: {
					uId: "35b4f3e2-4ebe-f515-0721-806f18407f52",
					name: "DisableAdvancedVisualEffects",
					caption: resources.localizableStrings.DisableAdvancedVisualEffectsCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				NumberFormat: {
					uId: "02f482f9-7abf-3fb7-e8a1-d5b54dfbf2fd",
					name: "NumberFormat",
					caption: resources.localizableStrings.NumberFormatCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "SysNumberFormat",
					referenceSchema: {
						name: "SysNumberFormat",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				WeekFirstDay: {
					uId: "e32ee711-b6ef-b914-0df0-f17f1cf8ba12",
					name: "WeekFirstDay",
					caption: resources.localizableStrings.WeekFirstDayCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "WeekFirstDay",
					referenceSchema: {
						name: "WeekFirstDay",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				UseAccessibleDesktopColor: {
					uId: "fe15b80b-e0f3-8548-7039-afb3de763688",
					name: "UseAccessibleDesktopColor",
					caption: resources.localizableStrings.UseAccessibleDesktopColorCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				UseDefaultBrowserScrollbarStyles: {
					uId: "0ed3abed-d92b-1f63-6859-18cdabae54da",
					name: "UseDefaultBrowserScrollbarStyles",
					caption: resources.localizableStrings.UseDefaultBrowserScrollbarStylesCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				OptimizeComponentsAccessibilityBehavior: {
					uId: "6b4cd1eb-ed73-169c-b3e5-7bb32f993f81",
					name: "OptimizeComponentsAccessibilityBehavior",
					caption: resources.localizableStrings.OptimizeComponentsAccessibilityBehaviorCaption,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					dataValueTypeName: "Boolean"
				},
				Contact: {
					uId: "ef2b6973-e73e-81d3-6413-8e8cee414111",
					name: "Contact",
					caption: resources.localizableStrings.ContactCaption,
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					isSimpleLookup: true,
					isLookup: true,
					referenceSchemaName: "Contact",
					referenceSchema: {
						name: "Contact",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Name"
					},
					dataValueTypeName: "Lookup"
				},
				Theme: {
					uId: "e8d2dfcd-c1c0-b4a5-4cba-717cc293ec9b",
					name: "Theme",
					caption: resources.localizableStrings.ThemeCaption,
					dataValueType: Terrasoft.DataValueType.TEXT,
					usageType: 0,
					isInherited: false,
					isValueCloneable: true,
					isSensitiveData: false,
					size: 250,
					dataValueTypeName: "MediumText"
				}
			}
		});
		return Terrasoft.SysUserProfile;
	});