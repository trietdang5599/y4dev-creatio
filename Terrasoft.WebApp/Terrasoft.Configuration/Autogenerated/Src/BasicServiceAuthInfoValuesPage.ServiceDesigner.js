define("BasicServiceAuthInfoValuesPage", [], function() {
	return {
		attributes: {

			/**
			 * UId of service schema.
			 */
			ServiceSchemaUId: {
				dataValueType: Terrasoft.DataValueType.GUID
			},

			/**
			 * Is allow edit schema.
			 */
			CanEditSchema: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			}
		},
		modules: {
			AuthInfoUsernameParameter: {
				moduleId: "AuthInfoUsernameParameterValuePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "AuthInfoUsernameValuePage",
					parameters: {
						viewModelConfig: {
							ServiceSchemaUid: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			},
			AuthInfoPasswordParameter: {
				moduleId: "AuthInfoPasswordParameterValuePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "AuthInfoPasswordValuePage",
					parameters: {
						viewModelConfig: {
							ServiceSchemaUid: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "BasicAuthInfoContainer",
				"parentName": "ParameterEdit",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AuthInfoUsernameParameter",
				"parentName": "BasicAuthInfoContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE
				}

			},
			{
				"operation": "insert",
				"name": "AuthInfoPasswordParameter",
				"parentName": "BasicAuthInfoContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE
				}
			}
		]
	};
});
