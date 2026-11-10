Terrasoft.configuration.Structures["OAuthClientAppMiniPage"] = {innerHierarchyStack: ["OAuthClientAppMiniPage"], structureParent: "BaseMiniPageTemplate"};
define('OAuthClientAppMiniPageStructure', ['OAuthClientAppMiniPageResources'], function(resources) {return {schemaUId:'ade36f5a-2e24-4d7a-9889-65771091bc46',schemaCaption: "OAuth client app mini page", parentSchemaName: "BaseMiniPageTemplate", packageName: "OAuth20", schemaName:'OAuthClientAppMiniPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,schemaDifferences:function(){

}};});
define("OAuthClientAppMiniPage", /**SCHEMA_DEPS*/["@creatio-devkit/common", "OAuthClientAppMiniPageResources"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk, resources)/**SCHEMA_ARGS*/ {
	const CLIENT_CREDENTIALS_GRANT = "client_credentials";
	const AUTHORIZATION_CODE_GRANT = "authorization_code";
	const TOKEN_EXCHANGE_GRANT = "urn:ietf:params:oauth:grant-type:token-exchange";

	async function callOAuthConfigService(methodName, payload) {
		const csrfMatch = document.cookie.match(/(?:^|;\s*)BPMCSRF=([^;]+)/);
		const headers = { "Content-Type": "application/json" };
		if (csrfMatch) {
			headers.BPMCSRF = csrfMatch[1];
		}
		const response = await fetch(
			(window.Terrasoft?.workspaceBaseUrl ?? "") + `/rest/OAuthConfigService/${methodName}`,
			{ method: "POST", credentials: "include", headers, body: JSON.stringify(payload) }
		);
		if (!response.ok) {
			throw new Error(`${methodName} failed: ${response.status}`);
		}
		return response.json();
	}

	async function refreshMiniPageState(context) {
		if (await context.IsSaveInProgress) {
			context.SaveButtonDisabled = true;
			return;
		}
		const nameStatus = context.formApiModel?.controls?.OAuthClientAppName?.status;
		let isDisabled = nameStatus !== "VALID";
		if (await context.IsFlowSelectionStage) {
			const hasAnyVisibleFlow = !!(await context.UseAuthorizationCodeFlow) || !!(await context.UseClientCredentialsFlow);
			isDisabled = isDisabled || !hasAnyVisibleFlow;
			if (await context.UseClientCredentialsFlow && !await context.CreateTechnicalUser) {
				const systemUserStatus = context.formApiModel?.controls?.OAuthClientAppSystemUser?.status;
				isDisabled = isDisabled || systemUserStatus !== "VALID";
			}
		}
		context.SaveButtonDisabled = isDisabled;
	}

	async function updateConfidentialFlowState(context) {
		const useClientCredentialsFlow = !!(await context.UseClientCredentialsFlow);
		const showTechnicalUserOptions = !!(await context.IsFlowSelectionStage) && useClientCredentialsFlow;
		context.ShowCreateTechnicalUserOption = showTechnicalUserOptions;
		context.ShowManualSystemUserSelection = showTechnicalUserOptions && !await context.CreateTechnicalUser;
		if (!showTechnicalUserOptions) {
			context.CreateTechnicalUser = false;
		}
		if (showTechnicalUserOptions && await context.CreateTechnicalUser == null) {
			context.CreateTechnicalUser = true;
		}
		await refreshMiniPageState(context);
	}

	async function getCreatePayload(context, systemUserId) {
		const isPublic = !!(await context.OAuthClientAppDS_IsPublic);
		let allowedGrantTypes;
		if (isPublic) {
			allowedGrantTypes = [AUTHORIZATION_CODE_GRANT];
		} else {
			allowedGrantTypes = [];
			if (await context.UseClientCredentialsFlow) {
				allowedGrantTypes.push(CLIENT_CREDENTIALS_GRANT);
			}
			if (await context.UseAuthorizationCodeFlow) {
				allowedGrantTypes.push(AUTHORIZATION_CODE_GRANT);
			}
			if (await context.UseTokenExchangeFlow) {
				allowedGrantTypes.push(TOKEN_EXCHANGE_GRANT);
			}
		}
		const installIntegration = (await context.InstallIntegration) !== false;
		return {
			addClientRequest: {
				name: await context.OAuthClientAppName,
				applicationUrl: await context.OAuthClientAppDS_ApplicationUrl_020cu01,
				description: await context.OAuthClientAppDS_Description_qo5ljt9,
				isPublic,
				requirePKCE: isPublic,
				systemUserId: systemUserId || "00000000-0000-0000-0000-000000000000",
				grantType: allowedGrantTypes[0],
				allowedGrantTypes,
				installIntegration,
				generateClientId: !installIntegration && !!(await context.GenerateClientIdOption)
			}
		};
	}

	async function openClientEditPage(context, clientAppId) {
		const handlerChain = sdk.HandlerChainService.instance;
		await handlerChain.process({
			type: "crt.CancelRecordChangesRequest",
			$context: context
		});
		await handlerChain.process({
			type: "crt.UpdateRecordRequest",
			$context: context,
			entityName: "OAuthClientApp",
			recordId: clientAppId
		});
		await handlerChain.process({
			type: "crt.ClosePageRequest",
			$context: context
		});
	}

	async function createTechnicalUserIfNeeded(context) {
		if (!await context.UseClientCredentialsFlow || !await context.CreateTechnicalUser) {
			return null;
		}
		const data = await callOAuthConfigService("CreateTechnicalUser", {
			createTechnicalUserRequest: {
				name: await context.OAuthClientAppName
			}
		});
		const result = data?.CreateTechnicalUserResponse ?? data?.CreateTechnicalUserResult ?? data;
		if (result?.success === false || result?.Success === false) {
			throw new Error(result?.errorInfo?.message || result?.ErrorInfo?.Message || resources.localizableStrings.Error_CreateTechnicalUser);
		}
		const createdSystemUser = {
			value: result?.systemUserId ?? result?.SystemUserId,
			displayValue: result?.systemUserName ?? result?.SystemUserName
		};
		context.OAuthClientAppSystemUser = createdSystemUser;
		return createdSystemUser.value;
	}

	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "ContinueInOtherPageButton"
			},
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#ResourceString(PageTitle_caption)#"
				}
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"items": [],
					"direction": "column"
				}
			},
			{
				"operation": "merge",
				"name": "FooterContainer",
				"values": {
					"alignItems": "center",
					"color": "transparent",
					"borderRadius": "none",
					"gap": "small"
				}
			},
			{
				"operation": "insert",
				"name": "MainFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FirstStepFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column",
					"visible": "$IsFlowSelectionStage | crt.InvertBooleanValue",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_ApplicationName",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "#ResourceString(Input_ApplicationName_label)#",
					"labelPosition": "above",
					"control": "$OAuthClientAppName",
					"placeholder": "#ResourceString(Input_ApplicationName_placeholder)#"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicatinUrlInput",
				"values": {
					"type": "crt.WebInput",
					"label": "#ResourceString(ApplicationUrlInput_label)#",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_ApplicationUrl_020cu01",
					"placeholder": "#ResourceString(ApplicatinUrlInput_placeholder)#"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ApplicationDescriptionInput",
				"values": {
					"type": "crt.Input",
					"multiline": true,
					"label": "#ResourceString(ApplicationDescriptionInput_label)#",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_Description_qo5ljt9",
					"placeholder": "#ResourceString(Input_eoyxijl_placeholder)#"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "PublicClientCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"value": false,
					"label": "#ResourceString(PublicClientCheckbox_label)#",
					"labelPosition": "right",
					"tooltip": "#ResourceString(PublicClientCheckbox_tooltip)#",
					"control": "$OAuthClientAppDS_IsPublic"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "InstallIntegrationCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"value": true,
					"label": "#ResourceString(InstallIntegrationCheckbox_label)#",
					"labelPosition": "right",
					"tooltip": "#ResourceString(InstallIntegrationCheckbox_tooltip)#",
					"control": "$InstallIntegration",
					"visible": "$ShowInstallIntegration"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "GenerateClientIdCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"value": false,
					"label": "#ResourceString(GenerateClientIdCheckbox_label)#",
					"labelPosition": "right",
					"tooltip": "#ResourceString(GenerateClientIdCheckbox_tooltip)#",
					"control": "$GenerateClientIdOption",
					"visible": "$ShowGenerateClientIdOption"
				},
				"parentName": "FirstStepFlexContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "SecondStepFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column",
					"visible": "$IsFlowSelectionStage",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AllowedFlowsTitleLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#ResourceString(AllowedFlowsTitleLabel_caption)#",
					"labelType": "body-large",
					"labelThickness": "semibold"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AuthorizationCodeFlowCardContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": ["minmax(32px, 1fr)"],
					"rows": "minmax(max-content, 32px)",
					"gap": { "columnGap": "large", "rowGap": "extra-small" },
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "small",
						"right": "medium",
						"bottom": "small",
						"left": "medium"
					},
					"color": "transparent",
					"borderRadius": "medium",
					"visible": true,
					"alignItems": "stretch",
					"styles": "$UseAuthorizationCodeFlow | usr.FlowCardStyles"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AuthorizationCodeFlowCheckbox",
				"values": {
					"layoutConfig": { "column": 1, "row": 1, "colSpan": 1, "rowSpan": 1 },
					"type": "crt.Checkbox",
					"value": false,
					"label": "#ResourceString(AuthorizationCodeFlowCheckbox_label)#",
					"labelPosition": "right",
					"control": "$UseAuthorizationCodeFlow"
				},
				"parentName": "AuthorizationCodeFlowCardContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AuthorizationCodeDescriptionLabel",
				"values": {
					"layoutConfig": { "column": 1, "row": 2, "colSpan": 1, "rowSpan": 1 },
					"type": "crt.Label",
					"caption": "#ResourceString(AuthorizationCodeDescriptionLabel_caption)#",
					"labelType": "caption",
					"labelColor": "#757575"
				},
				"parentName": "AuthorizationCodeFlowCardContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsFlowCardContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": ["minmax(32px, 1fr)"],
					"rows": "minmax(max-content, 32px)",
					"gap": { "columnGap": "large", "rowGap": "extra-small" },
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "small",
						"right": "medium",
						"bottom": "small",
						"left": "medium"
					},
					"color": "transparent",
					"borderRadius": "medium",
					"visible": true,
					"alignItems": "stretch",
					"styles": "$UseClientCredentialsFlow | usr.FlowCardStyles"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsFlowCheckbox",
				"values": {
					"layoutConfig": { "column": 1, "row": 1, "colSpan": 1, "rowSpan": 1 },
					"type": "crt.Checkbox",
					"value": false,
					"label": "#ResourceString(ClientCredentialsFlowCheckbox_label)#",
					"labelPosition": "right",
					"control": "$UseClientCredentialsFlow"
				},
				"parentName": "ClientCredentialsFlowCardContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsDescriptionLabel",
				"values": {
					"layoutConfig": { "column": 1, "row": 2, "colSpan": 1, "rowSpan": 1 },
					"type": "crt.Label",
					"caption": "#ResourceString(ClientCredentialsDescriptionLabel_caption)#",
					"labelType": "caption",
					"labelColor": "#757575"
				},
				"parentName": "ClientCredentialsFlowCardContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TokenExchangeFlowCardContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": ["minmax(32px, 1fr)"],
					"rows": "minmax(max-content, 32px)",
					"gap": { "columnGap": "large", "rowGap": "extra-small" },
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "small",
						"right": "medium",
						"bottom": "small",
						"left": "medium"
					},
					"color": "transparent",
					"borderRadius": "medium",
					"visible": false,
					"alignItems": "stretch",
					"styles": "$UseTokenExchangeFlow | usr.FlowCardStyles"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "TokenExchangeFlowCheckbox",
				"values": {
					"layoutConfig": { "column": 1, "row": 1, "colSpan": 1, "rowSpan": 1 },
					"type": "crt.Checkbox",
					"value": false,
					"label": "#ResourceString(TokenExchangeFlowCheckbox_label)#",
					"labelPosition": "right",
					"control": "$UseTokenExchangeFlow",
					"visible": false
				},
				"parentName": "TokenExchangeFlowCardContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CreateNewSystemUserCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"value": true,
					"label": "#ResourceString(CreateNewSystemUserCheckbox_label)#",
					"labelPosition": "right",
					"tooltip": "#ResourceString(CreateNewSystemUserCheckbox_tooltip)#",
					"control": "$CreateTechnicalUser",
					"visible": "$ShowCreateTechnicalUserOption"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "SystemUserComboBox",
				"values": {
					"type": "crt.ComboBox",
					"label": "#ResourceString(SystemUserComboBox_label)#",
					"labelPosition": "above",
					"control": "$OAuthClientAppSystemUser",
					"listActions": [],
					"showValueAsLink": false,
					"controlActions": [],
					"visible": "$ShowManualSystemUserSelection",
					"readonly": false,
					"placeholder": "#ResourceString(ComboBox_User_placeholder)#",
					"mode": "List"
				},
				"parentName": "SecondStepFlexContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "BaseButtonsFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "move",
				"name": "CancelButton",
				"parentName": "BaseButtonsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"layoutConfig": {}
				}
			},
			{
				"operation": "move",
				"name": "SaveButton",
				"parentName": "BaseButtonsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"caption": "#ResourceString(SaveButton_Next_caption)#",
					"clicked": {
						"request": "usr.ProceedOAuthClientCreationRequest"
					},
					"disabled": "$SaveButtonDisabled",
					"styles": "$SaveButtonStyles",
					"iconPosition": "only-text",
					"layoutConfig": {}
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": ["attributes"],
				"values": {
					"SaveButtonDisabled": {
						"value": true
					},
					"SaveButtonStyles": {
						"value": {}
					},
					"IsSaveInProgress": {
						"value": false
					},
					"IsFlowSelectionStage": {
						"value": false
					},
					"UseClientCredentialsFlow": {
						"value": false
					},
					"UseAuthorizationCodeFlow": {
						"value": false
					},
					"UseTokenExchangeFlow": {
						"value": false
					},
					"CreateTechnicalUser": {
						"value": true
					},
					"ShowCreateTechnicalUserOption": {
						"value": false
					},
					"ShowManualSystemUserSelection": {
						"value": false
					},
					"InstallIntegration": {
						"value": true
					},
					"GenerateClientIdOption": {
						"value": false
					},
					"ShowInstallIntegration": {
						"value": false
					},
					"ShowGenerateClientIdOption": {
						"value": false
					},
					"OAuthClientAppName": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Name"
						},
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					},
					"OAuthClientAppDS_ApplicationUrl_020cu01": {
						"modelConfig": {
							"path": "OAuthClientAppDS.ApplicationUrl"
						}
					},
					"OAuthClientAppDS_Description_qo5ljt9": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Description"
						}
					},
					"OAuthClientAppDS_IsPublic": {
						"modelConfig": {
							"path": "OAuthClientAppDS.IsPublic"
						}
					},
					"OAuthClientAppSystemUser": {
						"modelConfig": {
							"path": "OAuthClientAppDS.SystemUser"
						},
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": ["attributes", "Id", "modelConfig"],
				"values": {
					"path": "OAuthClientAppDS.Id"
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"dataSources": {
						"OAuthClientAppDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "OAuthClientApp"
							}
						}
					},
					"primaryDataSourceName": "OAuthClientAppDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: "crt.HandleViewModelInitRequest",
				handler: async (request, next) => {
					const response = await next?.handle(request);
					await request.$context.disableAttributeValidator("OAuthClientAppSystemUser", "required");
					// The "Install integration" / "Generate client id" controls let the user CREATE a
					// Not installed integration, so they are gated by the create-not-installed feature
					// (F2, which itself requires F1). When off, creation always installs (legacy, ENG-78572).
					let canCreateNotInstalled = false;
					try {
						const featureData = await callOAuthConfigService("GetInstallStatusFeatureState", {});
						const featureResult = featureData?.GetInstallStatusFeatureStateResult ?? featureData;
						canCreateNotInstalled = !!(featureResult?.canCreateNotInstalled
							?? featureResult?.CanCreateNotInstalled);
					} catch (e) {
						canCreateNotInstalled = false;
					}
					request.$context.ShowInstallIntegration = canCreateNotInstalled;
					request.$context.ShowGenerateClientIdOption = false;
					await refreshMiniPageState(request.$context);
					return response;
				}
			},
			{
				request: "crt.LoadDataRequest",
				handler: async (request, next) => {
					if (request.dataSourceName !== "OAuthClientAppSystemUser_List_DS") {
						return await next?.handle(request);
					}
					const filter = new sdk.FilterGroup();
					filter.logicalOperation = sdk.LogicalOperatorType.Or;
					await filter.addSchemaColumnFilterWithParameter(sdk.ComparisonType.Equal, "SysAdminUnitTypeValue", 7);
					await filter.addSchemaColumnFilterWithParameter(sdk.ComparisonType.Equal, "SysAdminUnitTypeValue", 4);
					const newFilter = Object.assign({}, filter);
					newFilter.items = filter.items;
					request.parameters.push({
						type: "filter",
						value: newFilter
					});
					return await next?.handle(request);
				}
			},
			{
				request: "usr.ProceedOAuthClientCreationRequest",
				handler: async (request, next) => {
					const context = request.$context;
					const installIntegration = (await context.InstallIntegration) !== false;
					// Not installed: create a bare record immediately, skip flow selection and Identity (ENG-78572).
					if (installIntegration && !await context.IsFlowSelectionStage && !await context.OAuthClientAppDS_IsPublic) {
						context.IsFlowSelectionStage = true;
						context.CreateTechnicalUser = true;
						await updateConfidentialFlowState(context);
						return;
					}
					const handlerChain = sdk.HandlerChainService.instance;
					const maskTaskName = "oauth-create-integration";
					context.IsSaveInProgress = true;
					context.SaveButtonDisabled = true;
					context.SaveButtonStyles = { cursor: "progress" };
					await handlerChain.process({
						type: "crt.SchemaViewMaskRequest",
						$context: context,
						action: "addTask",
						taskName: maskTaskName
					});
					try {
						let systemUserId = null;
						if (await context.IsFlowSelectionStage && await context.UseClientCredentialsFlow) {
							if (await context.CreateTechnicalUser) {
								systemUserId = await createTechnicalUserIfNeeded(context);
							} else {
								systemUserId = (await context.OAuthClientAppSystemUser)?.value;
								if (!systemUserId) {
									throw new Error(resources.localizableStrings.Error_SystemUserRequired);
								}
							}
						}
						const payload = await getCreatePayload(context, systemUserId);
						const data = await callOAuthConfigService("AddClient", payload);
						const result = data?.AddClientResult ?? data;
						if (result?.success === false || result?.Success === false) {
							throw new Error(result?.errorInfo?.message || result?.ErrorInfo?.Message || resources.localizableStrings.Error_SaveOAuthIntegration);
						}
						await openClientEditPage(context, result?.clientAppId ?? result?.ClientAppId);
					} finally {
						await handlerChain.process({
							type: "crt.SchemaViewMaskRequest",
							$context: context,
							action: "removeTask",
							taskName: maskTaskName
						});
						context.IsSaveInProgress = false;
						context.SaveButtonStyles = {};
						await refreshMiniPageState(context);
					}
				}
			},
			{
				request: "crt.HandleViewModelAttributeChangeRequest",
				handler: async (request, next) => {
					const response = await next?.handle(request);
					if (request.attributeName === "InstallIntegration") {
						// "Generate client id" is offered only while "Install integration" is unchecked (ENG-78572).
						const installChecked = (await request.$context.InstallIntegration) !== false;
						const featureOn = !!(await request.$context.ShowInstallIntegration);
						request.$context.ShowGenerateClientIdOption = featureOn && !installChecked;
						if (installChecked) {
							request.$context.GenerateClientIdOption = false;
						}
						return response;
					}
					if (request.attributeName === "CreateTechnicalUser"
							|| request.attributeName === "UseClientCredentialsFlow"
							|| request.attributeName === "UseAuthorizationCodeFlow"
							|| request.attributeName === "OAuthClientAppSystemUser"
							|| request.attributeName === "OAuthClientAppName"
							|| request.attributeName === "IsFlowSelectionStage") {
						if (request.attributeName === "UseClientCredentialsFlow"
								&& await request.$context.UseClientCredentialsFlow) {
							request.$context.CreateTechnicalUser = true;
						}
						const needsManualSystemUser = !!(await request.$context.IsFlowSelectionStage)
							&& !!(await request.$context.UseClientCredentialsFlow)
							&& !(await request.$context.CreateTechnicalUser);
						if (needsManualSystemUser) {
							await request.$context.enableAttributeValidator("OAuthClientAppSystemUser", "required");
						} else {
							await request.$context.disableAttributeValidator("OAuthClientAppSystemUser", "required");
							if (request.$context.formApiModel?.controls?.OAuthClientAppSystemUser) {
								request.$context.formApiModel.controls.OAuthClientAppSystemUser.status = "VALID";
							}
						}
						await updateConfidentialFlowState(request.$context);
					}
					return response;
				}
			},
			{
				request: "crt.CanDiscardUnsavedDataRequest",
				handler: async (request, next) => {
					const context = request.$context;
					const hasUserInput = !!(await context.OAuthClientAppName)
						|| !!(await context.UseAuthorizationCodeFlow)
						|| !!(await context.UseClientCredentialsFlow)
						|| !!(await context.UseTokenExchangeFlow)
						|| !!(await context.OAuthClientAppDS_IsPublic)
						|| !!((await context.OAuthClientAppSystemUser)?.value);
					if (!hasUserInput) {
						return true;
					}
					const dialogConfig = {
						data: {
							message: resources.localizableStrings.ConfirmCancelDialog_message,
							actions: [
								{
									key: "DONT_SAVE",
									config: {
										color: "primary",
										caption: resources.localizableStrings.ConfirmCancelDialog_dontSave
									}
								},
								{
									key: "CANCEL",
									config: {
										color: "default",
										caption: resources.localizableStrings.ConfirmCancelDialog_cancel
									}
								}
							]
						}
					};
					const result = await request.$context.executeRequest({
						type: "crt.ShowDialogRequest",
						$context: request.$context,
						dialogConfig
					});
					return result === "DONT_SAVE";
				}
			}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{
			"usr.FlowCardStyles": (isSelected) => ({
				"background-color": "transparent",
				"border": "1px solid " + (isSelected ? "rgb(179, 202, 243)" : "#F0F0F0")
			})
		}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


