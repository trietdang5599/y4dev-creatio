Terrasoft.configuration.Structures["OAuthClientAppEditPage"] = {innerHierarchyStack: ["OAuthClientAppEditPage"], structureParent: "PageWithTabsFreedomTemplate"};
define('OAuthClientAppEditPageStructure', ['OAuthClientAppEditPageResources'], function(resources) {return {schemaUId:'70f71add-e6a5-459e-83f6-c586dc7aa46a',schemaCaption: "OAuth client app edit page", parentSchemaName: "PageWithTabsFreedomTemplate", packageName: "OAuth20", schemaName:'OAuthClientAppEditPage',parentSchemaUId:'3b2e117f-8c6b-4ca5-80a2-7ebb497cddf9',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("OAuthClientAppEditPage", /**SCHEMA_DEPS*/["@creatio-devkit/common", "OAuthClientAppEditPageResources"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk, resources)/**SCHEMA_ARGS*/ {
	const MASKED_VALUE_STATE = "masked";
	const UNMASKED_VALUE_STATE = "unmasked";
	const CLIENT_CREDENTIALS_GRANT = "client_credentials";
	const AUTHORIZATION_CODE_GRANT = "authorization_code";
	const TOKEN_EXCHANGE_GRANT = "urn:ietf:params:oauth:grant-type:token-exchange";
	const CONSENT_MODE_ASK_ALWAYS = {
		value: "0fbae234-131f-4a20-b57b-fd0acb853cb1",
		displayValue: "Ask always"
	};
	const GRANT_TYPE_LOOKUPS = {
		[CLIENT_CREDENTIALS_GRANT]: {
			value: "73f0cc6d-0634-4db3-96ab-0cb549958f91",
			displayValue: "Server-to-server (client credentials)"
		},
		[AUTHORIZATION_CODE_GRANT]: {
			value: "ea4416f8-c13a-4dfd-8e41-e504735dcde8",
			displayValue: "On behalf of a user (authorization code)"
		},
		[TOKEN_EXCHANGE_GRANT]: {
			value: "de960442-76b1-4d34-bd17-7eba2db8d2d8",
			displayValue: "Token exchange"
		}
	};
	const GRANT_TYPE_IDS = Object.fromEntries(Object.entries(GRANT_TYPE_LOOKUPS)
		.map(([grantType, lookup]) => [lookup.value, grantType]));

	function getMaskedSecret(secret) {
		return typeof secret === "string" && secret.length ? "*".repeat(secret.length) : "";
	}

	async function syncClientSecretDisplay(context) {
		const secret = (await context.OAuthClientAppDS_ClientSecretText_Control) || "";
		if (!secret) {
			context.OAuthClientAppDS_ClientSecretText_MaskState = MASKED_VALUE_STATE;
			context.OAuthClientAppDS_ClientSecretText_Display = "";
			context.OAuthClientAppDS_ClientSecretText_UnmaskingDisabled = true;
			return;
		}
		const state = (await context.OAuthClientAppDS_ClientSecretText_MaskState) === UNMASKED_VALUE_STATE
			? UNMASKED_VALUE_STATE
			: MASKED_VALUE_STATE;
		context.OAuthClientAppDS_ClientSecretText_MaskState = state;
		context.OAuthClientAppDS_ClientSecretText_Display = state === UNMASKED_VALUE_STATE
			? secret
			: getMaskedSecret(secret);
		context.OAuthClientAppDS_ClientSecretText_UnmaskingDisabled = false;
	}

	async function toggleClientSecretDisplay(context) {
		context.OAuthClientAppDS_ClientSecretText_MaskState =
			(await context.OAuthClientAppDS_ClientSecretText_MaskState) === UNMASKED_VALUE_STATE
				? MASKED_VALUE_STATE
				: UNMASKED_VALUE_STATE;
		await syncClientSecretDisplay(context);
	}

	const AUTHORIZATION_CODE_GRANT_TYPE_ID = 'ea4416f8-c13a-4dfd-8e41-e504735dcde8';
	function isAuthorizationCodeGrantType(grantType) {
		if (!grantType) {
			return false;
		}
		const raw = typeof grantType === 'object' ? grantType.value : grantType;
		if (typeof raw !== 'string') {
			return false;
		}
		return raw.replace(/[{}]/g, '').toLowerCase() === AUTHORIZATION_CODE_GRANT_TYPE_ID;
	}

	function getGrantTypeId(grantType) {
		if (!grantType) {
			return "";
		}
		const raw = typeof grantType === "object" ? grantType.value : grantType;
		return typeof raw === "string" ? raw.replace(/[{}]/g, "").toLowerCase() : "";
	}

	async function getLegacyAllowedGrantTypes(context) {
		const grantType = await context.OAuthClientAppDS_GrantType;
		const grantTypeCode = GRANT_TYPE_IDS[getGrantTypeId(grantType)];
		return grantTypeCode ? [grantTypeCode] : [];
	}

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

	const NOT_INSTALLED_STATUS_ID = "273670c2-d2ef-4c6a-b0f4-44b43e08bab7";
	const INSTALLED_STATUS_ID = "87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69";

	// Calls the OAuthClientAppInstallService.Install endpoint (ENG-78572): promotes a Not installed
	// integration to Installed (validate -> register in Identity -> generate secret -> activate).
	async function callOAuthClientAppInstallService(recordId) {
		const csrfMatch = document.cookie.match(/(?:^|;\s*)BPMCSRF=([^;]+)/);
		const headers = { "Content-Type": "application/json" };
		if (csrfMatch) {
			headers.BPMCSRF = csrfMatch[1];
		}
		const response = await fetch(
			(window.Terrasoft?.workspaceBaseUrl ?? "") + "/rest/OAuthClientAppInstallService/Install",
			{ method: "POST", credentials: "include", headers, body: JSON.stringify({ recordId }) }
		);
		if (!response.ok) {
			throw new Error(`Install failed: ${response.status}`);
		}
		return response.json();
	}

	// Derives the install-lifecycle UI state from the feature toggle + current Status (ENG-78572):
	// when the feature is on and the record is Not installed, Status is shown, Active is read-only and
	// the Install button is offered. When the feature is off these stay false (legacy behavior).
	async function refreshInstallStatusState(context) {
		const featureEnabled = !!(await context.IsInstallStatusFeatureEnabled);
		const status = await context.OAuthClientAppDS_Status;
		const statusId = (status?.value || "").toString().toLowerCase();
		const isNotInstalled = featureEnabled && statusId === NOT_INSTALLED_STATUS_ID;
		await setContextAttribute(context, "IsNotInstalled", isNotInstalled);
		await setContextAttribute(context, "ShowInstallButton", isNotInstalled);
		await setContextAttribute(context, "IsActiveReadonly", isNotInstalled);
	}

	async function getSelectedGrantTypes(context) {
		const grantTypes = [];
		if (await context.UseClientCredentialsFlow) {
			grantTypes.push(CLIENT_CREDENTIALS_GRANT);
		}
		if (await context.UseAuthorizationCodeFlow) {
			grantTypes.push(AUTHORIZATION_CODE_GRANT);
		}
		if (await context.UseTokenExchangeFlow) {
			grantTypes.push(TOKEN_EXCHANGE_GRANT);
		}
		return grantTypes.length ? grantTypes : [CLIENT_CREDENTIALS_GRANT];
	}

	function normalizeAllowedGrantTypes(grantTypes) {
		const allowedGrantTypes = new Set((grantTypes || []).filter(Boolean));
		const orderedGrantTypes = [];
		if (allowedGrantTypes.has(CLIENT_CREDENTIALS_GRANT)) {
			orderedGrantTypes.push(CLIENT_CREDENTIALS_GRANT);
		}
		if (allowedGrantTypes.has(AUTHORIZATION_CODE_GRANT)) {
			orderedGrantTypes.push(AUTHORIZATION_CODE_GRANT);
		}
		if (allowedGrantTypes.has(TOKEN_EXCHANGE_GRANT)) {
			orderedGrantTypes.push(TOKEN_EXCHANGE_GRANT);
		}
		return orderedGrantTypes.length ? orderedGrantTypes : [CLIENT_CREDENTIALS_GRANT];
	}

	function getAllowedGrantTypesSignature(grantTypes) {
		return [...new Set((grantTypes || []).filter(Boolean))].sort().join("|");
	}

	function getAllowedGrantTypesFromSignature(signature) {
		if (!signature) {
			return [CLIENT_CREDENTIALS_GRANT];
		}
		return normalizeAllowedGrantTypes(signature.split("|"));
	}

	async function setContextAttribute(context, attributeName, value, options) {
		if (typeof context.set === "function") {
			return context.set(attributeName, value, options);
		}
		context[attributeName] = value;
	}

	async function applyAllowedGrantTypes(context, allowedGrantTypes, options = {}) {
		allowedGrantTypes = normalizeAllowedGrantTypes(allowedGrantTypes);
		const updateGrantTypeAttribute = options.updateGrantTypeAttribute !== false;
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		const useClientCredentials = allowedGrantTypes.includes(CLIENT_CREDENTIALS_GRANT);
		const useAuthorizationCode = allowedGrantTypes.includes(AUTHORIZATION_CODE_GRANT);
		const useTokenExchange = allowedGrantTypes.includes(TOKEN_EXCHANGE_GRANT);
		await setContextAttribute(context, "UseClientCredentialsFlow", useClientCredentials, stateChangeOptions);
		await setContextAttribute(context, "UseAuthorizationCodeFlow", useAuthorizationCode, stateChangeOptions);
		await setContextAttribute(context, "UseTokenExchangeFlow", useTokenExchange, stateChangeOptions);
		await setContextAttribute(context, "IsAuthCodeFlow", useAuthorizationCode, stateChangeOptions);
		await setContextAttribute(context, "ShowClientCredentialsSettings", useClientCredentials, stateChangeOptions);
		if (updateGrantTypeAttribute) {
			context.OAuthClientAppDS_GrantType = GRANT_TYPE_LOOKUPS[allowedGrantTypes[0] || CLIENT_CREDENTIALS_GRANT];
		}
		await setContextAttribute(context, "AllowedGrantTypesBaseline",
			getAllowedGrantTypesSignature(allowedGrantTypes), stateChangeOptions);
		await setContextAttribute(context, "HasUnsavedGrantTypeChanges", false, stateChangeOptions);
	}

	async function loadAllowedGrantTypes(context) {
		const clientId = await context.OAuthClientAppDS_ClientId_mbzavo8;
		const clientAppId = await context.OAuthClientAppDS_Id;
		if (!clientId && !clientAppId) {
			await applyAllowedGrantTypes(context, await getLegacyAllowedGrantTypes(context));
			return;
		}
		try {
			const data = await callOAuthConfigService("GetAllowedGrantTypes", {
				request: { clientId, clientAppId }
			});
			const result = data?.GetAllowedGrantTypesResult ?? data;
			const serviceGrantTypes = result?.allowedGrantTypes || result?.AllowedGrantTypes;
			const allowedGrantTypes = Array.isArray(serviceGrantTypes) && serviceGrantTypes.length
				? serviceGrantTypes
				: await getLegacyAllowedGrantTypes(context);
			await applyAllowedGrantTypes(context, allowedGrantTypes);
		} catch (error) {
			console.warn("Unable to load allowed OAuth grant types.", error);
			await applyAllowedGrantTypes(context, await getLegacyAllowedGrantTypes(context));
		}
	}

	async function prepareAllowedGrantTypesForSave(context) {
		const grantTypes = await getSelectedGrantTypes(context);
		context.OAuthClientAppDS_GrantType = GRANT_TYPE_LOOKUPS[grantTypes[0]];
		context.IsAuthCodeFlow = grantTypes.includes(AUTHORIZATION_CODE_GRANT);
		context.ShowClientCredentialsSettings = grantTypes.includes(CLIENT_CREDENTIALS_GRANT);
		// ENG-88521: do NOT clear OAuthClientAppDS_SystemUser here. The primary entity save runs before the
		// OAuthGrantTypeInClient relations are updated, so the server-side GetClientAppInfoFromEntity check
		// still sees client_credentials among the allowed grants and would throw "SystemUser field must be
		// filled in". Clearing the technical-user link is delegated to the server-side UpdateClient call
		// (synchronizeAllowedGrantTypes), which publishes the pending grant-type set so the Identity check
		// already sees client_credentials removed and the clear is safe.
		return grantTypes;
	}

	async function syncGrantTypesDirtyState(context) {
		const baselineSignature = (await context.AllowedGrantTypesBaseline) || "";
		const currentSignature = getAllowedGrantTypesSignature(await getSelectedGrantTypes(context));
		const hasUnsavedGrantTypeChanges = currentSignature !== baselineSignature;
		await setContextAttribute(context, "HasUnsavedGrantTypeChanges", hasUnsavedGrantTypeChanges);
		if (hasUnsavedGrantTypeChanges) {
			await setContextAttribute(context, "HasUnsavedData", true);
			await setContextAttribute(context, "IsChanged", true);
		}
	}

	async function resetGrantTypesDirtyState(context, options = {}) {
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		await setContextAttribute(context, "HasUnsavedGrantTypeChanges", false, stateChangeOptions);
		await setContextAttribute(context, "HasUnsavedData", false, stateChangeOptions);
		await setContextAttribute(context, "IsChanged", false, stateChangeOptions);
	}

	async function syncFooterButtonsState(context, options = {}) {
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		const hasUnsavedData = !!(await context.HasUnsavedData);
		const hasUnsavedGrantTypeChanges = !!(await context.HasUnsavedGrantTypeChanges);
		await setContextAttribute(
			context,
			"ShowSaveCancelButtons",
			hasUnsavedData || hasUnsavedGrantTypeChanges,
			stateChangeOptions
		);
	}

	function resetPagePristineState(context) {
		const formApiModel = context.formApiModel;
		if (!formApiModel) {
			return;
		}
		formApiModel.markAsPristine?.();
		formApiModel.markAsUntouched?.();
		Object.values(formApiModel.controls || {}).forEach((control) => {
			control?.markAsPristine?.();
			control?.markAsUntouched?.();
		});
		formApiModel.updateValueAndValidity?.({ emitEvent: false });
	}

	async function synchronizeAllowedGrantTypes(context, allowedGrantTypes) {
		const clientId = await context.OAuthClientAppDS_ClientId_mbzavo8;
		// A Not installed integration has no Identity Service ClientId yet, so address it by its local record
		// Id (clientAppId). Without this the multi-grant set was never persisted for Not installed clients and
		// only the legacy single GrantType column survived a save (ENG-93603 follow-up).
		const clientAppId = await context.OAuthClientAppDS_Id;
		if (!clientId && !clientAppId) {
			return;
		}
		const systemUser = await context.OAuthClientAppDS_SystemUser;
		const systemUserId = allowedGrantTypes.includes(CLIENT_CREDENTIALS_GRANT) ? systemUser?.value : null;
		await callOAuthConfigService("UpdateClient", {
			updateClientRequest: {
				clientId,
				clientAppId,
				allowedGrantTypes,
				systemUserId
			}
		});
	}

	async function isNewClientApp(context) {
		return !(await context.OAuthClientAppDS_ClientId_mbzavo8);
	}

	async function createTechnicalUser(context) {
		const data = await callOAuthConfigService("CreateTechnicalUser", {
			createTechnicalUserRequest: {
				name: await context.OAuthClientAppDS_Name_w03mr6d
			}
		});
		const result = data?.CreateTechnicalUserResponse ?? data?.CreateTechnicalUserResult ?? data;
		if (result?.success === false || result?.Success === false) {
			const errorMessage = result?.errorInfo?.message || result?.ErrorInfo?.Message
				|| resources.localizableStrings.Error_CreateTechnicalUser;
			throw new Error(errorMessage);
		}
		return {
			value: result?.systemUserId ?? result?.SystemUserId,
			displayValue: result?.systemUserName ?? result?.SystemUserName
		};
	}

	async function syncClientCredentialsEditorState(context, options = {}) {
		const showClientCredentialsSettings = !!(await context.ShowClientCredentialsSettings);
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		await setContextAttribute(context, "ShowCreateTechnicalUserOption", false, stateChangeOptions);
		await setContextAttribute(context, "ShowManualSystemUserSelection",
			showClientCredentialsSettings, stateChangeOptions);
		await setContextAttribute(context, "CreateTechnicalUser", false, stateChangeOptions);
		if (context.formApiModel?.controls?.OAuthClientAppDS_SystemUser) {
			context.formApiModel.controls.OAuthClientAppDS_SystemUser.status = "VALID";
		}
	}

	async function syncSystemUserValidation(context) {
		if (!await context.ShowClientCredentialsSettings && context.formApiModel?.controls?.OAuthClientAppDS_SystemUser) {
			context.formApiModel.controls.OAuthClientAppDS_SystemUser.status = "VALID";
		}
	}

	const TECHNICAL_USER_TYPE_VALUE = 7;

	async function refreshIsTechnicalSystemUser(context) {
		const systemUser = await context.OAuthClientAppDS_SystemUser;
		const systemUserId = systemUser?.value;
		if (!systemUserId) {
			await setContextAttribute(context, "IsTechnicalSystemUser", false);
			return;
		}
		try {
			const baseUrl = window.Terrasoft?.workspaceBaseUrl ?? "";
			const headers = {
				"Content-Type": "application/json",
				"Accept": "application/json",
				"ForceUseSession": "true"
			};
			const csrfMatch = document.cookie.match(/(?:^|;\s*)BPMCSRF=([^;]+)/);
			if (csrfMatch) {
				headers.BPMCSRF = csrfMatch[1];
			}
			const body = {
				rootSchemaName: "SysAdminUnit",
				operationType: 0,
				columns: {
					items: {
						SysAdminUnitTypeValue: {
							expression: {
								expressionType: 0,
								columnPath: "SysAdminUnitTypeValue"
							}
						}
					}
				},
				filters: {
					filterType: 6,
					logicalOperation: 0,
					isEnabled: true,
					items: {
						idFilter: {
							filterType: 1,
							comparisonType: 3,
							isEnabled: true,
							leftExpression: {
								expressionType: 0,
								columnPath: "Id"
							},
							rightExpression: {
								expressionType: 2,
								parameter: {
									dataValueType: 0,
									value: systemUserId
								}
							}
						}
					}
				}
			};
			const response = await fetch(baseUrl + "/DataService/json/reply/SelectQuery", {
				method: "POST",
				credentials: "include",
				headers,
				body: JSON.stringify(body)
			});
			if (!response.ok) {
				await setContextAttribute(context, "IsTechnicalSystemUser", false);
				return;
			}
			const data = await response.json();
			const row = data?.rows?.[0];
			const typeValue = row?.SysAdminUnitTypeValue;
			await setContextAttribute(context, "IsTechnicalSystemUser", typeValue === TECHNICAL_USER_TYPE_VALUE);
		} catch {
			await setContextAttribute(context, "IsTechnicalSystemUser", false);
		}
	}

	async function updatePublicClientState(context, options = {}) {
		const isPublicClient = !!(await context.OAuthClientAppDS_IsPublic_h19aqkh);
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		await setContextAttribute(context, "DisableNonPublicClientFlows", isPublicClient, stateChangeOptions);
		if (isPublicClient) {
			await setContextAttribute(context, "UseAuthorizationCodeFlow", true, stateChangeOptions);
			await setContextAttribute(context, "UseClientCredentialsFlow", false, stateChangeOptions);
			await setContextAttribute(context, "UseTokenExchangeFlow", false, stateChangeOptions);
		}
		const allowedGrantTypes = await getSelectedGrantTypes(context);
		const isAuthCodeFlow = allowedGrantTypes.includes(AUTHORIZATION_CODE_GRANT);
		await setContextAttribute(context, "IsAuthCodeFlow", isAuthCodeFlow, stateChangeOptions);
		await setContextAttribute(context, "ShowClientCredentialsSettings",
			allowedGrantTypes.includes(CLIENT_CREDENTIALS_GRANT), stateChangeOptions);
		await setContextAttribute(context, "IsDisableConsentCheckboxVisible",
			isAuthCodeFlow && !!(await context.IsDisableConsentFeatureEnabled), stateChangeOptions);
		await syncClientCredentialsEditorState(context, options);
	}

	async function updatePublicClientPkceState(context, options = {}) {
		const isPkceSupportEnabled = !!(await context.IsPkceSupportEnabled);
		const stateChangeOptions = options.preventStateChange ? { preventStateChange: true } : undefined;
		const isPublicClient = !!(await context.OAuthClientAppDS_IsPublic_h19aqkh);
		await setContextAttribute(context, "IsClientSecretVisible", !isPublicClient, stateChangeOptions);
		if (!isPkceSupportEnabled) {
			return;
		}
		await setContextAttribute(context, "IsEnforcePkceReadonly", isPublicClient, stateChangeOptions);
		if (isPublicClient) {
			await setContextAttribute(context, "OAuthClientAppDS_RequirePKCE_w1wlok1", true, stateChangeOptions);
		} else if (await isNewClientApp(context) && await context.OAuthClientAppDS_RequirePKCE_w1wlok1 == null) {
			await setContextAttribute(context, "OAuthClientAppDS_RequirePKCE_w1wlok1", false, stateChangeOptions);
		}
		if (context.formApiModel?.controls?.OAuthClientAppDS_RequirePKCE_w1wlok1) {
			context.formApiModel.controls.OAuthClientAppDS_RequirePKCE_w1wlok1.value =
				await context.OAuthClientAppDS_RequirePKCE_w1wlok1;
		}
	}
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"visible": "$ShowSaveCancelButtons"
				}
			},
			{
				"operation": "merge",
				"name": "CloseButton",
				"values": {
					"visible": "$ShowSaveCancelButtons | crt.InvertBooleanValue"
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"visible": "$ShowSaveCancelButtons",
					"size": "large",
					"iconPosition": "only-text"
				}
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"padding": {
						"left": "small",
						"right": "small",
						"top": "none",
						"bottom": "none"
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "SideAreaProfileContainer",
				"values": {
					"columns": [
						"minmax(64px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"visible": true,
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					"styleType": "default",
					"mode": "tab",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto"
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"iconPosition": "only-text",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "ComboBox_SystemUser",
			},
			{
				"operation": "remove",
				"name": "Checkbox_EnforcePKCE",
			},
			{
				"operation": "remove",
				"name": "Checkbox_DisableConsent",
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTabContainer"
			},
			{
				"operation": "merge",
				"name": "CardToggleTabPanel",
				"values": {
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto"
				}
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ApplicationDetails",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ApplicationDetailsTitle",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "small",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationDetailsLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(ApplicationDetailsLabel_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ApplicationDetailsTitle",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ApplicationLogoContainerTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ApplicationLogoContainerTitle_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ApplicationLogo",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "flex-start",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ImageInput_AppLogo",
				"values": {
					"type": "crt.ImageInput",
					"labelPosition": "auto",
					"value": "$OAuthClientAppDS_Logo_lovry63",
					"size": "large",
					"borderRadius": "medium",
					"positioning": "scale-down",
					"visible": true,
					"label": "$Resources.Strings.null",
					"readonly": false,
					"tooltip": ""
				},
				"parentName": "FlexContainer_ApplicationLogo",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_AppLogoDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_AppLogoDescription_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ApplicationLogo",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "NameInput",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.OAuthClientAppDS_Name_w03mr6d",
					"labelPosition": "auto",
					"control": "$OAuthClientAppDS_Name_w03mr6d"
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ApplicationURLWebInput",
				"values": {
					"type": "crt.WebInput",
					"label": "$Resources.Strings.OAuthClientAppDS_ApplicationUrl_g9yb7g8",
					"labelPosition": "auto",
					"control": "$OAuthClientAppDS_ApplicationUrl_g9yb7g8"
				},
				"parentName": "ApplicationInformationContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Checkbox_PublicClient",
				"values": {
					"type": "crt.Checkbox",
					"value": true,
					"disabled": false,
					"inversed": false,
					"label": "$Resources.Strings.OAuthClientAppDS_IsPublic_h19aqkh",
					"ariaLabel": "",
					"labelPosition": "right",
					"tooltip": "#ResourceString(Checkbox_PublicClient_tooltip)#",
					"control": "$OAuthClientAppDS_IsPublic_h19aqkh",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "LeftPanelEnforcePkceCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"value": true,
					"disabled": false,
					"inversed": false,
					"label": "$Resources.Strings.OAuthClientAppDS_RequirePKCE_w1wlok1",
					"ariaLabel": "",
					"labelPosition": "right",
					"tooltip": "#ResourceString(Checkbox_EnforcePKCE_tooltip)#",
					"control": "$OAuthClientAppDS_RequirePKCE_w1wlok1",
					"visible": "$UseAuthorizationCodeFlow",
					"readonly": "$IsEnforcePkceReadonly",
					"placeholder": ""
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "ActiveCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.OAuthClientAppDS_IsActive_m47ntk5",
					"labelPosition": "right",
					"control": "$OAuthClientAppDS_IsActive_m47ntk5",
					"visible": true,
					"readonly": "$IsActiveReadonly",
					"placeholder": "",
					"tooltip": "#ResourceString(ActiveCheckbox_tooltip)#"
				},
				"parentName": "FlexContainer_ApplicationDetails",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "InstallBannerContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"stretch": true,
					"fitContent": true,
					"visible": "$ShowInstallButton",
					"color": "primary",
					"borderRadius": "medium",
					"padding": {
						"top": "medium",
						"right": "medium",
						"bottom": "medium",
						"left": "medium"
					},
					"alignItems": "flex-start",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap",
					"styles": {
						"border": "0.5px solid #F4A259"
					}
				},
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "InstallBannerTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#ResourceString(InstallBannerTitle_caption)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#E8730C",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "InstallBannerContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "InstallHintLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#ResourceString(InstallHintLabel_caption)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "InstallBannerContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "InstallButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(InstallButton_caption)#",
					"color": "accent",
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "usr.InstallOAuthClientAppRequest",
						"params": {}
					},
					"clickMode": "default"
				},
				"parentName": "InstallBannerContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CredentialsGridContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "extra-small"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"right": "large",
						"bottom": "medium",
						"left": "large"
					},
					"color": "primary",
					"borderRadius": "medium",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "SideContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_CredentialsContainerTitle",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_CredentialsContainerTitle_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "CredentialsGridContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_dxdp9nf",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_dxdp9nf_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "CredentialsGridContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_zjp9rof",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"rowSpan": 1,
						"row": 3
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_zjp9rof_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "CredentialsGridContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_fxcon8e",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"rowSpan": 1,
						"row": 4
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_fxcon8e_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "CredentialsGridContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GridContainer_koppypu",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_plhkr33",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 3,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_plhkr33_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_koppypu",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 4,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ClientCredentialsTabContainer_caption)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": "$ShowClientCredentialsSettings",
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_koppypu",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationInformationExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ApplicationInformationExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_koppypu",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ApplicationInformationContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "ApplicationInformationExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SettingsDescriptionField",
				"values": {
					"type": "crt.Input",
					"multiline": true,
					"label": "$Resources.Strings.OAuthClientAppDS_Description_dykcgrq",
					"labelPosition": "auto",
					"control": "$OAuthClientAppDS_Description_dykcgrq",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "ApplicationInformationContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(AllowedOAuthFlowsExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_koppypu",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "AllowedOAuthFlowsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsDescriptionLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#ResourceString(AllowedOAuthFlowsDescriptionLabel_caption)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "AllowedOAuthFlowsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsColumnsContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "AllowedOAuthFlowsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsLeftColumn",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "AllowedOAuthFlowsColumnsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AllowedOAuthFlowsRightColumn",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "AllowedOAuthFlowsColumnsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AuthorizationCodeFlowCheckboxSettings",
				"values": {
					"type": "crt.Checkbox",
					"value": false,
					"disabled": false,
					"inversed": false,
					"label": "#ResourceString(AuthorizationCodeFlowCheckboxSettings_label)#",
					"ariaLabel": "#ResourceString(AuthorizationCodeFlowCheckboxSettings_label)#",
					"labelPosition": "right",
					"tooltip": "",
					"control": "$UseAuthorizationCodeFlow",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "AllowedOAuthFlowsLeftColumn",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsFlowCheckboxSettings",
				"values": {
					"type": "crt.Checkbox",
					"value": false,
					"disabled": "$DisableNonPublicClientFlows",
					"inversed": false,
					"label": "#ResourceString(ClientCredentialsFlowCheckboxSettings_label)#",
					"ariaLabel": "#ResourceString(ClientCredentialsFlowCheckboxSettings_label)#",
					"labelPosition": "right",
					"tooltip": "",
					"control": "$UseClientCredentialsFlow",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "AllowedOAuthFlowsRightColumn",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TokenExchangeFlowCheckboxSettings",
				"values": {
					"type": "crt.Checkbox",
					"value": false,
					"disabled": "$DisableNonPublicClientFlows",
					"inversed": false,
					"label": "#ResourceString(TokenExchangeFlowCheckboxSettings_label)#",
					"ariaLabel": "#ResourceString(TokenExchangeFlowCheckboxSettings_label)#",
					"labelPosition": "right",
					"tooltip": "",
					"control": "$UseTokenExchangeFlow",
					"visible": false,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "AllowedOAuthFlowsLeftColumn",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_i51ycti",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_plhkr33",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_cfglp87",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_i51ycti",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_0d393vt",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_plhkr33",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CredentialsHintLabel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(CredentialsHintLabel_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "GridContainer_0d393vt",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientIdRow",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "flex-end",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "GridContainer_0d393vt",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientIdInput",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap",
					"direction": "column"
				},
				"parentName": "FlexContainer_ClientIdRow",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientIdInput",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.OAuthClientAppDS_ClientId_mbzavo8",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_ClientId_mbzavo8",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "FlexContainer_ClientIdInput",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientIdCopyButton",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "extra-small",
						"left": "none"
					},
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainer_ClientIdRow",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Button_ClientIdCopyButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_ClientIdCopyButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "copy-icon",
					"clicked": {
						"request": "crt.CopyClipboardRequest",
						"params": {
							"value": "$OAuthClientAppDS_ClientId_mbzavo8"
						}
					},
					"clickMode": "default"
				},
				"parentName": "FlexContainer_ClientIdCopyButton",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientSecretRow",
				"values": {
					"layoutConfig": {
						"column": 2,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": "$IsClientSecretVisible",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "flex-end",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "GridContainer_0d393vt",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientSecretInput",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap",
					"direction": "column"
				},
				"parentName": "FlexContainer_ClientSecretRow",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientSecret_Input",
				"values": {
					"type": "crt.EncryptedInput",
					"label": "#ResourceString(ClientSecret_Input_label)#",
					"control": "$OAuthClientAppDS_ClientSecretText_Display",
					"state": "$OAuthClientAppDS_ClientSecretText_MaskState",
					"unmaskingDisabled": "$OAuthClientAppDS_ClientSecretText_UnmaskingDisabled",
					"toggleMaskValue": {
						"request": "usr.ToggleOAuthClientAppSecretMaskRequest"
					},
					"placeholder": "",
					"tooltip": "",
					"readonly": true,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "FlexContainer_ClientSecretInput",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ClientSecretCopyButton",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "extra-small",
						"left": "none"
					},
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainer_ClientSecretRow",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Button_ClientSecretCopyButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_ClientSecretCopyButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "copy-icon",
					"clicked": {
						"request": "crt.CopyClipboardRequest",
						"params": {
							"value": "$OAuthClientAppDS_ClientSecretText_Control"
						}
					},
					"clickMode": "default"
				},
				"parentName": "FlexContainer_ClientSecretCopyButton",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_pn9e552",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_pn9e552_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": "30",
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": "$IsConsentModeComboBoxVisible",
					"alignItems": "stretch"
				},
				"parentName": "AuthorizationCodeTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_ncyzzge",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_pn9e552",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_m2yw1ug",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_ncyzzge",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_e892j8k",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_e892j8k_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"nestedLoadDataRequestConfigs": [
								{
									"dataSourceName": "DataGrid_l5796axDS",
									"config": {
										"loadType": "reload",
										"useLastLoadParameters": true
									}
								}
							]
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "FlexContainer_m2yw1ug",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_rhgp51c",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_rhgp51c_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": []
				},
				"parentName": "FlexContainer_m2yw1ug",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MenuItem_zxufe04",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_zxufe04_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataGrid_l5796ax",
							"filters": "$DataGrid_l5796ax | crt.ToCollectionFilters : 'DataGrid_l5796ax' : $DataGrid_l5796ax_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "Button_rhgp51c",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_ijgpg3v",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_ijgpg3v_caption)#",
					"icon": "import-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "RedirectUrlInOAuthClientApp"
						}
					},
					"visible": true
				},
				"parentName": "Button_rhgp51c",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SearchFilter_3gdeykv",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilter_3gdeykv_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [],
						"from": [
							"SearchFilter_3gdeykv_SearchValue",
							"SearchFilter_3gdeykv_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_m2yw1ug",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_4ekmsev",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_4ekmsev_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_pn9e552",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_285urkm",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_pn9e552",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ComboBox_ConsentMode",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.OAuthClientAppDS_ConsentMode",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_ConsentMode",
					"listActions": [],
					"showValueAsLink": false,
					"controlActions": [],
					"tooltip": "",
					"visible": "$IsConsentModeComboBoxVisible",
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "GridContainer_285urkm",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_uv9zoxb",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_uv9zoxb_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": "30",
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "AuthorizationCodeTabContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_nws3izd",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_uv9zoxb",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_bzefk5u",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_nws3izd",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_mor0ur6",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_mor0ur6_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"nestedLoadDataRequestConfigs": [
								{
									"dataSourceName": "DataGrid_l5796axDS",
									"config": {
										"loadType": "reload",
										"useLastLoadParameters": true
									}
								}
							]
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "FlexContainer_bzefk5u",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_jjnca9d",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_jjnca9d_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": []
				},
				"parentName": "FlexContainer_bzefk5u",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MenuItem_umk8g22",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_umk8g22_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataGrid_l5796ax",
							"filters": "$DataGrid_l5796ax | crt.ToCollectionFilters : 'DataGrid_l5796ax' : $DataGrid_l5796ax_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "Button_jjnca9d",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_euyvz14",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_euyvz14_caption)#",
					"icon": "import-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "RedirectUrlInOAuthClientApp"
						}
					},
					"visible": true
				},
				"parentName": "Button_jjnca9d",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SearchFilter_575xq4t",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilter_575xq4t_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [],
						"from": [
							"SearchFilter_575xq4t_SearchValue",
							"SearchFilter_575xq4t_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_bzefk5u",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_omo1jle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_omo1jle_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_uv9zoxb",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_vg45u1g",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_uv9zoxb",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_l5796ax",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 2,
						"rowSpan": 8
					},
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						}
					},
					"items": "$DataGrid_l5796ax",
					"primaryColumnName": "DataGrid_l5796axDS_Id",
					"columns": [
						{
							"id": "4baaee29-21bf-fb1d-55f9-7faadb7aab30",
							"code": "DataGrid_l5796axDS_RedirectUrl",
							"caption": "#ResourceString(DataGrid_l5796axDS_RedirectUrl)#",
							"dataValueType": 44,
							"width": 417
						}
					],
					"selectionState": "$DataGrid_l5796ax_SelectionState",
					"_selectionOptions": {
						"attribute": "DataGrid_l5796ax_SelectionState"
					},
					"activeRow": "$DataGrid_l5796ax_ActiveRow",
					"bulkActions": []
				},
				"parentName": "GridContainer_vg45u1g",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_pc5uryq",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_pc5uryq_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "AuthorizationCodeTabContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridContainer_gkg6tlp",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_pc5uryq",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ws2s508",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_gkg6tlp",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailAddBtn_AllowedUsers",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailAddBtn_AllowedUsers_caption)#",
					"icon": "add-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.AddUsersToOAuthClientAppRequest",
						"params": {
							"clientAppId": "$Id",
							"dataSourceNames": [
								"GridDetail_x4jg0f3DS"
							]
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "FlexContainer_ws2s508",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailRefreshBtn_AllowedUsers",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailRefreshBtn_AllowedUsers_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "GridDetail_x4jg0f3DS"
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "FlexContainer_ws2s508",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSettingsBtn_AllowedUsers",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailSettingsBtn_AllowedUsers_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": []
				},
				"parentName": "FlexContainer_ws2s508",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridDetailExportDataBtn_0qokl37",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailExportDataBtn_0qokl37_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_OAuthAppAllowedUsers"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_AllowedUsers",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailImportDataBtn_np1xrqh",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailImportDataBtn_np1xrqh_caption)#",
					"icon": "import-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "OAuthAppAllowedUser"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_AllowedUsers",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSearchFilter_AllowedUsers",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridDetailSearchFilter_AllowedUsers_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridDetailSearchFilter_AllowedUsers_GridDetail_x4jg0f3",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_x4jg0f3"
										]
									}
								]
							}
						],
						"from": [
							"GridDetailSearchFilter_AllowedUsers_SearchValue",
							"GridDetailSearchFilter_AllowedUsers_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_ws2s508",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Label_AllowedUsersListDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_AllowedUsersListDescription_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_pc5uryq",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ImportantDescription",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "ExpansionPanel_pc5uryq",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_ImportantMark",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ImportantMark_caption)#)#",
					"labelType": "caption",
					"labelThickness": "bold",
					"labelEllipsis": false,
					"labelColor": "#D2310D",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ImportantDescription",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ImportantDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ImportantDescription_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ImportantDescription",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_zmyyavk",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_pc5uryq",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridDetail_OAuthAppAllowedUsers",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$GridDetail_x4jg0f3",
					"activeRow": "$GridDetail_x4jg0f3_ActiveRow",
					"selectionState": "$GridDetail_x4jg0f3_SelectionState",
					"_selectionOptions": {
						"attribute": "GridDetail_x4jg0f3_SelectionState"
					},
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "GridDetail_x4jg0f3DS_Id",
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(RowToolbar_DeleteItem_caption)#",
							"icon": "delete-row-action",
							"clicked": {
								"request": "crt.RemoveUsersFromOAuthClientAppRequest",
								"params": {
									"clientAppId": "$Id",
									"recordId": "$GridDetail_x4jg0f3.GridDetail_x4jg0f3DS_Id",
									"dataSourceNames": [
										"GridDetail_x4jg0f3DS",
										"GridDetail_0c5yamjDS"
									]
								}
							}
						}
					],
					"columns": [
						{
							"id": "c237b3ae-b183-ee1b-434b-65cb53f3b6f1",
							"code": "GridDetail_x4jg0f3DS_SysUser",
							"caption": "#ResourceString(GridDetail_x4jg0f3DS_SysUser)#",
							"dataValueType": 10,
							"width": 371
						},
						{
							"id": "9564f706-72ad-d31e-aa18-0b2f37583997",
							"code": "GridDetail_x4jg0f3DS_CreatedOn",
							"caption": "#ResourceString(GridDetail_x4jg0f3DS_CreatedOn)#",
							"dataValueType": 7
						}
					],
					"placeholder": false,
					"bulkActions": []
				},
				"parentName": "GridContainer_zmyyavk",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_x4jg0f3_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_AddTag_caption)#",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_x4jg0f3DS",
							"filters": "$GridDetail_x4jg0f3 | crt.ToCollectionFilters : 'GridDetail_x4jg0f3' : $GridDetail_x4jg0f3_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_x4jg0f3_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "GridDetail_OAuthAppAllowedUsers",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_x4jg0f3_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_RemoveTag_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_x4jg0f3DS",
							"filters": "$GridDetail_x4jg0f3 | crt.ToCollectionFilters : 'GridDetail_x4jg0f3' : $GridDetail_x4jg0f3_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_x4jg0f3_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_x4jg0f3_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_x4jg0f3_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_ExportToExcel_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_OAuthAppAllowedUsers",
							"filters": "$GridDetail_x4jg0f3 | crt.ToCollectionFilters : 'GridDetail_x4jg0f3' : $GridDetail_x4jg0f3_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_x4jg0f3_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_OAuthAppAllowedUsers",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetail_x4jg0f3_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_Delete_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveUsersFromOAuthClientAppRequest",
						"params": {
							"clientAppId": "$Id",
							"dataSourceNames": [
								"GridDetail_x4jg0f3DS",
								"GridDetail_0c5yamjDS"
							],
							"selectionState": "$GridDetail_x4jg0f3_SelectionState",
							"gridSelectionStateField": "GridDetail_x4jg0f3_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_OAuthAppAllowedUsers",
				"propertyName": "bulkActions",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(ClientCredentialsTabContainer_caption)#",
					"iconPosition": "only-text",
					"visible": false,
					"icon": null
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AuthorizationCodeTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(AuthorizationCodeTabContainer_caption)#",
					"iconPosition": "only-text",
					"visible": "$UseAuthorizationCodeFlow",
					"icon": null
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsCreateTechnicalUserTabField",
				"values": {
					"type": "crt.Checkbox",
					"value": true,
					"disabled": false,
					"inversed": false,
					"label": "#ResourceString(ClientCredentialsCreateTechnicalUserTabField_label)#",
					"ariaLabel": "#ResourceString(ClientCredentialsCreateTechnicalUserTabField_label)#",
					"labelPosition": "right",
					"tooltip": "#ResourceString(ClientCredentialsCreateTechnicalUserTabField_tooltip)#",
					"control": "$CreateTechnicalUser",
					"visible": false,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "ClientCredentialsTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsDescriptionLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#ResourceString(ClientCredentialsDescriptionLabel_caption)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ClientCredentialsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsSystemUserGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"visible": "$ShowClientCredentialsSettings",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ClientCredentialsExpansionPanel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsSystemUserFlex",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": "$ShowClientCredentialsSettings",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "flex-end",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "ClientCredentialsSystemUserGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsSystemUserInputFlex",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap",
					"direction": "column"
				},
				"parentName": "ClientCredentialsSystemUserFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsSystemUserTabField",
				"values": {
					"type": "crt.ComboBox",
					"label": "#ResourceString(ClientCredentialsSystemUserTabField_label)#",
					"labelPosition": "left",
					"control": "$OAuthClientAppDS_SystemUser",
					"listActions": [],
					"showValueAsLink": false,
					"controlActions": [],
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "",
					"layoutConfig": {},
					"stretch": true,
					"mode": "List"
				},
				"parentName": "ClientCredentialsSystemUserInputFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ClientCredentialsOpenUserButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_OpenUser_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": "$ShowClientCredentialsSettings",
					"icon": "open-button-icon",
					"clicked": {
						"request": "crt.OpenUserCardRequest",
						"params": {
							"systemUserId": "$OAuthClientAppDS_SystemUser.value",
							"openInNewWindow": true
						}
					},
					"clickMode": "default"
				},
				"parentName": "ClientCredentialsSystemUserFlex",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsExpansionPanel",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ObjectPermissionsExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": "$IsTechnicalSystemUser",
					"alignItems": "stretch"
				},
				"parentName": "ClientCredentialsTabContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsToolsContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "extra-small",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ObjectPermissionsExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsToolsFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 8,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"wrap": "wrap"
				},
				"parentName": "ObjectPermissionsToolsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsRefreshButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ObjectPermissionsRefreshButton_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "GridDetail_4sgsz13DS"
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "ObjectPermissionsToolsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsSettingsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ObjectPermissionsSettingsButton_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": [],
					"visible": true
				},
				"parentName": "ObjectPermissionsToolsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsExportMenuItem",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(ObjectPermissionsExportMenuItem_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "ObjectPermissionsList"
						}
					}
				},
				"parentName": "ObjectPermissionsSettingsButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsSearchButton",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(ObjectPermissionsSearchButton_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "ObjectPermissionsSearchButton_GridDetail_4sgsz13",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_4sgsz13"
										]
									}
								]
							}
						],
						"from": [
							"ObjectPermissionsSearchButton_SearchValue",
							"ObjectPermissionsSearchButton_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "ObjectPermissionsToolsFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ObjectPermissionsButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.OpenObjectsPermissionsSection"
					},
					"icon": "contact-lock-icon",
					"clickMode": "default"
				},
				"parentName": "ObjectPermissionsToolsFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsExpansionPanelDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(ObjectPermissionsExpansionPanelDescription_caption)#)#",
					"labelType": "button-small",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "ObjectPermissionsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsListContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ObjectPermissionsExpansionPanel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ObjectPermissionsList",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": false,
							"numeration": true,
							"toolbar": false
						},
						"columns": {
							"adding": false,
							"dragAndDrop": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$GridDetail_4sgsz13",
					"primaryColumnName": "GridDetail_4sgsz13DS_Id",
					"columns": [
						{
							"id": "ed885211-0001-4f12-95b2-000000000001",
							"code": "GridDetail_4sgsz13DS_Object",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_Object)#",
							"dataValueType": 28,
							"cellView": {
								"type": "crt.Link",
								"underlining": "hover",
								"href": "$GridDetail_4sgsz13.GridDetail_4sgsz13DS_ObjectPermissionsUrl",
								"caption": "$GridDetail_4sgsz13.GridDetail_4sgsz13DS_Object",
								"target": "_blank"
							}
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000002",
							"code": "GridDetail_4sgsz13DS_CanRead",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_CanRead)#",
							"dataValueType": 12,
							"width": 115
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000003",
							"code": "GridDetail_4sgsz13DS_CanAppend",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_CanAppend)#",
							"dataValueType": 12,
							"width": 115
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000004",
							"code": "GridDetail_4sgsz13DS_CanEdit",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_CanEdit)#",
							"dataValueType": 12,
							"width": 115
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000005",
							"code": "GridDetail_4sgsz13DS_CanDelete",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_CanDelete)#",
							"dataValueType": 12,
							"width": 115
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000006",
							"code": "GridDetail_4sgsz13DS_AdministratedByRecords",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_AdministratedByRecords)#",
							"dataValueType": 12,
							"width": 190
						},
						{
							"id": "ed885211-0001-4f12-95b2-000000000007",
							"code": "GridDetail_4sgsz13DS_AdministratedByColumns",
							"caption": "#ResourceString(GridDetail_4sgsz13DS_AdministratedByColumns)#",
							"dataValueType": 12,
							"width": 210
						}
					],
					"placeholder": false,
					"visible": true,
					"fitContent": true,
					"activeRow": "$GridDetail_4sgsz13_ActiveRow",
					"selectionState": "$GridDetail_4sgsz13_SelectionState",
					"_selectionOptions": {
						"attribute": "GridDetail_4sgsz13_SelectionState"
					},
					"bulkActions": []
				},
				"parentName": "ObjectPermissionsListContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsExpansionPanel",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(GrantedOperationsExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": "$IsTechnicalSystemUser",
					"alignItems": "stretch"
				},
				"parentName": "ClientCredentialsTabContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsToolsContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "GrantedOperationsExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsToolsFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 8,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"wrap": "wrap"
				},
				"parentName": "GrantedOperationsToolsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsRefreshButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GrantedOperationsRefreshButton_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "GrantedOperationsGridDetailDS"
						}
					}
				},
				"parentName": "GrantedOperationsToolsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsSettingsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GrantedOperationsSettingsButton_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": [],
					"visible": true
				},
				"parentName": "GrantedOperationsToolsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsExportMenuItem",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GrantedOperationsExportMenuItem_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GrantedOperationsGridDetail"
						}
					}
				},
				"parentName": "GrantedOperationsSettingsButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsSearchButton",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GrantedOperationsSearchButton_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GrantedOperationsSearchButton_GridDetail_6vxhbxx",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_6vxhbxx"
										]
									}
								]
							}
						],
						"from": [
							"GrantedOperationsSearchButton_SearchValue",
							"GrantedOperationsSearchButton_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "GrantedOperationsToolsFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "OperationPermissionsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(OperationPermissionsButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "contact-lock-icon",
					"clicked": {
						"request": "crt.OpenOperationPermissionsSection"
					}
				},
				"parentName": "GrantedOperationsToolsFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsExpansionPanelDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(GrantedOperationsExpansionPanelDescription_caption)#)#",
					"labelType": "button-small",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "GrantedOperationsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsListContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "GrantedOperationsExpansionPanel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GrantedOperationsGridDetail",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": false,
							"numeration": true,
							"toolbar": false
						},
						"columns": {
							"adding": false,
							"dragAndDrop": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$GridDetail_6vxhbxx",
					"activeRow": "$GridDetail_6vxhbxx_ActiveRow",
					"selectionState": "$GridDetail_6vxhbxx_SelectionState",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "GrantedOperationsGridDetailDS_Id",
					"columns": [
						{
							"id": "ed885211-0002-4f12-95b2-000000000001",
							"code": "GrantedOperationsGridDetailDS_SysAdminOperation",
							"caption": "#ResourceString(GrantedOperationsGridDetailDS_SysAdminOperation)#",
							"dataValueType": 10,
							"width": 404
						}
					],
					"placeholder": false
				},
				"parentName": "GrantedOperationsListContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MonitoringTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(MonitoringTabContainer_caption)#",
					"iconPosition": "only-text",
					"visible": true,
					"icon": null
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_UsersWhoSharedPermissions",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_UsersWhoSharedPermissions_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "MonitoringTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_36jwaaz",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_UsersWhoSharedPermissions",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_1n0crad",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_36jwaaz",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailRefreshBtn_tj6as9v",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailRefreshBtn_tj6as9v_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "GridDetail_0c5yamjDS"
						}
					}
				},
				"parentName": "FlexContainer_1n0crad",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailSettingsBtn_0wry23f",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailSettingsBtn_0wry23f_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": [],
					"visible": true
				},
				"parentName": "FlexContainer_1n0crad",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailExportDataBtn_ll4upwx",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailExportDataBtn_ll4upwx_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_UsersWhoSharedPermissions"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_0wry23f",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_RevokeAll",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_RevokeAll_caption)#",
					"visible": false,
					"icon": "change-contact-icon",
					"clicked": {
						"request": "crt.RevokeClientTokensRequest",
						"params": {
							"clientId": "$OAuthClientAppDS_ClientId_mbzavo8",
							"usersId": [],
							"dataSourceName": "GridDetail_0c5yamjDS"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_0wry23f",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSearchFilter_wtqp5d0",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridDetailSearchFilter_wtqp5d0_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridDetailSearchFilter_wtqp5d0_GridDetail_0c5yamj",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_0c5yamj"
										]
									}
								]
							}
						],
						"from": [
							"GridDetailSearchFilter_wtqp5d0_SearchValue",
							"GridDetailSearchFilter_wtqp5d0_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_1n0crad",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "QuickFilter_gzteuv8",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_gzteuv8_config_caption)#",
						"hint": "",
						"defaultValue": false,
						"approachState": true,
						"icon": "settings-button-icon",
						"iconPosition": "left-icon"
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_gzteuv8_GridDetail_0c5yamj",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "GridDetail_0c5yamj",
													"customFilter": {
														"items": {
															"beb25973-a396-404b-9165-c415c37c482b": {
																"filterType": 1,
																"comparisonType": 3,
																"isEnabled": true,
																"trimDateTimeParameterToDate": false,
																"leftExpression": {
																	"expressionType": 0,
																	"columnPath": "Active"
																},
																"isAggregative": false,
																"dataValueType": 12,
																"rightExpression": {
																	"expressionType": 2,
																	"parameter": {
																		"dataValueType": 12,
																		"value": true
																	}
																}
															}
														},
														"logicalOperation": 0,
														"isEnabled": true,
														"filterType": 6,
														"rootSchemaName": "UserOAuthSharedAccess"
													},
													"dependencyFilters": null
												},
												"quickFilterType": "custom",
												"config": {
													"approachState": true
												}
											}
										]
									}
								]
							}
						],
						"from": [
							"QuickFilter_gzteuv8_Value"
						]
					},
					"filterType": "custom"
				},
				"parentName": "FlexContainer_1n0crad",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Label_UsersWhoSharedPermissionsListDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_UsersWhoSharedPermissionsListDescription_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_UsersWhoSharedPermissions",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_vsb2v10",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_UsersWhoSharedPermissions",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetail_UsersWhoSharedPermissions",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							},
							"toolbar": true
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$GridDetail_0c5yamj",
					"activeRow": "$GridDetail_0c5yamj_ActiveRow",
					"selectionState": "$GridDetail_0c5yamj_SelectionState",
					"_selectionOptions": {
						"attribute": "GridDetail_0c5yamj_SelectionState"
					},
					"primaryColumnName": "GridDetail_0c5yamjDS_Id",
					"columns": [
						{
							"id": "1bc31660-f637-bbf3-9567-ab80f64c39f3",
							"code": "GridDetail_0c5yamjDS_SysUser",
							"caption": "#ResourceString(GridDetail_0c5yamjDS_SysUser)#",
							"dataValueType": 10,
							"width": 285
						},
						{
							"id": "017dd89d-9bd6-ec15-4e94-0b193016a4dd",
							"code": "GridDetail_0c5yamjDS_AccessSharedOn",
							"caption": "#ResourceString(GridDetail_0c5yamjDS_AccessSharedOn)#",
							"dataValueType": 7,
							"width": 274
						},
						{
							"id": "1922506a-318c-c7ca-b67d-29ebc29cd944",
							"code": "GridDetail_0c5yamjDS_Active",
							"caption": "#ResourceString(GridDetail_0c5yamjDS_Active)#",
							"dataValueType": 12,
							"width": 197
						}
					],
					"placeholder": false,
					"bulkActions": [],
					"visible": true,
					"fitContent": true,
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(RowToolbar_RevokeToken_caption)#",
							"icon": "change-contact-icon",
							"clicked": {
								"request": "crt.RevokeClientTokensRequest",
								"params": {
									"clientId": "$OAuthClientAppDS_ClientId_mbzavo8",
									"usersId": [
										"$GridDetail_0c5yamj.GridDetail_0c5yamjDS_SysUser"
									],
									"dataSourceName": "GridDetail_0c5yamjDS"
								}
							}
						}
					]
				},
				"parentName": "GridContainer_vsb2v10",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_0c5yamj_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_AddTag_caption)#",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_0c5yamjDS",
							"filters": "$GridDetail_0c5yamj | crt.ToCollectionFilters : 'GridDetail_0c5yamj' : $GridDetail_0c5yamj_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_0c5yamj_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "GridDetail_UsersWhoSharedPermissions",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_0c5yamj_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_RemoveTag_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_0c5yamjDS",
							"filters": "$GridDetail_0c5yamj | crt.ToCollectionFilters : 'GridDetail_0c5yamj' : $GridDetail_0c5yamj_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_0c5yamj_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_0c5yamj_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_0c5yamj_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_ExportToExcel_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_UsersWhoSharedPermissions",
							"filters": "$GridDetail_0c5yamj | crt.ToCollectionFilters : 'GridDetail_0c5yamj' : $GridDetail_0c5yamj_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_0c5yamj_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_UsersWhoSharedPermissions",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MenuItem_RevokeSelectedTokensBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_RevokeSelectedTokensBulkAction_caption)#",
					"visible": true,
					"icon": "change-contact-icon",
					"clicked": {
						"request": "crt.RevokeClientTokensRequest",
						"params": {
							"clientId": "$OAuthClientAppDS_ClientId_mbzavo8",
							"dataSourceName": "GridDetail_0c5yamjDS",
							"usersId": "$GridDetail_0c5yamj_SelectionState.selected",
							"byEntity": true
						}
					}
				},
				"parentName": "GridDetail_UsersWhoSharedPermissions",
				"propertyName": "bulkActions",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_Sessions",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_Sessions_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "MonitoringTabContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_uc6gs7l",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_Sessions",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ooth2nb",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_uc6gs7l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailRefreshBtn_xulrql4",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailRefreshBtn_xulrql4_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "GridDetail_evsys3wDS"
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "FlexContainer_ooth2nb",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailSearchFilter_qldvylf",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridDetailSearchFilter_qldvylf_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridDetailSearchFilter_qldvylf_GridDetail_evsys3w",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_evsys3w"
										]
									}
								]
							}
						],
						"from": [
							"GridDetailSearchFilter_qldvylf_SearchValue",
							"GridDetailSearchFilter_qldvylf_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_ooth2nb",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_3ujkocv",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "FlexContainer_ooth2nb",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "QuickFilter_Session_User",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_Session_User_config_caption)#",
						"hint": "#ResourceString(QuickFilter_Session_User_config_hint)#",
						"icon": "filter-column-icon",
						"iconPosition": "left-icon",
						"defaultValue": [],
						"entitySchemaName": "SysAdminUnit",
						"recordsFilter": {
							"items": {
								"3c30738d-c3a0-4e65-8b72-de0d2497f77d": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "SysAdminUnitTypeValue"
									},
									"isAggregative": false,
									"dataValueType": 4,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 4,
											"value": 4
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "SysAdminUnit"
						}
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_Session_User_GridDetail_evsys3w",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "GridDetail_evsys3w",
													"filterColumn": "SysUser"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_Session_User_Value"
					},
					"filterType": "lookup",
					"visible": true
				},
				"parentName": "FlexContainer_3ujkocv",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "QuickFilter_Session_StartSession",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_Session_StartSession_caption)#",
						"hint": "#ResourceString(QuickFilter_Session_StartSession_hint)#",
						"icon": "date",
						"iconPosition": "left-icon"
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_Session_StartSession_GridDetail_evsys3w",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "GridDetail_evsys3w",
													"filterColumn": "SessionStartDate"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_Session_StartSession_Value"
					},
					"filterType": "date-range",
					"visible": true
				},
				"parentName": "FlexContainer_3ujkocv",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "QuickFilter_Session_EndSession",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_Session_EndSession_caption)#",
						"hint": "#ResourceString(QuickFilter_Session_EndSession_hint)#",
						"icon": "date",
						"iconPosition": "left-icon"
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_Session_EndSession_GridDetail_evsys3w",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "GridDetail_evsys3w",
													"filterColumn": "SessionEndDate"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_Session_EndSession_Value"
					},
					"filterType": "date-range",
					"visible": true
				},
				"parentName": "FlexContainer_3ujkocv",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_lnnier9",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_lnnier9_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_Sessions",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_d4jjxpp",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "ExpansionPanel_Sessions",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetail_Sessions",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": false,
							"numeration": true,
							"toolbar": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						},
						"header": {
							"visible": true
						},
						"columns": {
							"dragAndDrop": true,
							"resizing": true,
							"sorting": true
						}
					},
					"items": "$GridDetail_evsys3w",
					"activeRow": "$GridDetail_evsys3w_ActiveRow",
					"selectionState": "$GridDetail_evsys3w_SelectionState",
					"_selectionOptions": {
						"attribute": "GridDetail_evsys3w_SelectionState"
					},
					"visible": true,
					"primaryColumnName": "GridDetail_evsys3wDS_Id",
					"columns": [
						{
							"id": "74722139-f32c-be54-12a9-6edeaf35effb",
							"code": "GridDetail_evsys3wDS_SysUser",
							"caption": "#ResourceString(GridDetail_evsys3wDS_SysUser)#",
							"dataValueType": 10
						},
						{
							"id": "69e2267e-c5dc-2cb0-8026-4fea96048e42",
							"code": "GridDetail_evsys3wDS_SessionStartDate",
							"caption": "#ResourceString(GridDetail_evsys3wDS_SessionStartDate)#",
							"dataValueType": 7
						},
						{
							"id": "27fdb4d7-fc09-24f7-78da-ed790313e781",
							"code": "GridDetail_evsys3wDS_SessionEndDate",
							"caption": "#ResourceString(GridDetail_evsys3wDS_SessionEndDate)#",
							"dataValueType": 7
						},
						{
							"id": "ab83c70d-6ae8-c142-7970-48c5d24d97d7",
							"code": "GridDetail_evsys3wDS_ClientIP",
							"caption": "#ResourceString(GridDetail_evsys3wDS_ClientIP)#",
							"dataValueType": 28
						},
						{
							"id": "2009109e-f8e2-a6e4-e209-2357c0d6dd9c",
							"code": "GridDetail_evsys3wDS_Agent",
							"caption": "#ResourceString(GridDetail_evsys3wDS_Agent)#",
							"dataValueType": 30
						}
					],
					"placeholder": false,
					"bulkActions": [],
					"rowToolbarItems": [],
					"fitContent": true
				},
				"parentName": "GridContainer_d4jjxpp",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_evsys3w_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_ExportToExcel_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_evsys3w",
							"filters": "$GridDetail_evsys3w | crt.ToCollectionFilters : 'GridDetail_evsys3w' : $GridDetail_evsys3w_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_evsys3w_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_Sessions",
				"propertyName": "bulkActions",
				"index": 0
			},
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"OAuthClientAppDS_Name_w03mr6d": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Name"
						}
					},
					"OAuthClientAppDS_ApplicationUrl_g9yb7g8": {
						"modelConfig": {
							"path": "OAuthClientAppDS.ApplicationUrl"
						}
					},
					"OAuthClientAppDS_Description_dykcgrq": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Description"
						}
					},
					"OAuthClientAppDS_IsActive_m47ntk5": {
						"modelConfig": {
							"path": "OAuthClientAppDS.IsActive"
						}
					},
					"OAuthClientAppDS_ClientId_mbzavo8": {
						"modelConfig": {
							"path": "OAuthClientAppDS.ClientId"
						}
					},
					"OAuthClientAppDS_Id": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Id"
						}
					},
					"OAuthClientAppDS_ClientSecretText_Control": {
						"modelConfig": {}
					},
					"OAuthClientAppDS_ClientSecretText_Display": {
						"modelConfig": {}
					},
					"OAuthClientAppDS_ClientSecretText_MaskState": {
						"value": "masked"
					},
					"OAuthClientAppDS_ClientSecretText_UnmaskingDisabled": {
						"value": true
					},
					"IsPkceSupportEnabled": {
						"value": false
					},
					"IsClientSecretVisible": {
						"value": false
					},
					"IsEnforcePkceReadonly": {
						"value": true
					},
					"IsAuthCodeFlow": {
						"value": false
					},
					"IsDisableConsentFeatureEnabled": {
						"value": false
					},
					"IsConsentModeComboBoxVisible": {
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
					"ShowClientCredentialsSettings": {
						"value": false
					},
					"CreateTechnicalUser": {
						"value": false
					},
					"ShowCreateTechnicalUserOption": {
						"value": false
					},
					"ShowManualSystemUserSelection": {
						"value": false
					},
					"AllowedGrantTypesBaseline": {
						"value": ""
					},
					"IsRestoringAllowedGrantTypes": {
						"value": false
					},
					"HasUnsavedGrantTypeChanges": {
						"value": false
					},
					"ShowSaveCancelButtons": {
						"value": false
					},
					"DisableNonPublicClientFlows": {
						"value": false
					},
					"OAuthClientAppDS_GrantType": {
						"modelConfig": {
							"path": "OAuthClientAppDS.GrantType"
						}
					},
					"OAuthClientAppDS_Status": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Status"
						}
					},
					"IsInstallStatusFeatureEnabled": {
						"value": false
					},
					"IsNotInstalled": {
						"value": false
					},
					"ShowInstallButton": {
						"value": false
					},
					"IsActiveReadonly": {
						"value": false
					},
					"DataGrid_l5796ax": {
						"isCollection": true,
						"modelConfig": {
							"path": "DataGrid_l5796axDS"
						},
						"viewModelConfig": {
							"attributes": {
								"DataGrid_l5796axDS_RedirectUrl": {
									"modelConfig": {
										"path": "DataGrid_l5796axDS.RedirectUrl"
									}
								},
								"DataGrid_l5796axDS_Id": {
									"modelConfig": {
										"path": "DataGrid_l5796axDS.Id"
									}
								}
							}
						}
					},
					"OAuthClientAppDS_ConsentMode_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					},
					"GridDetail_0c5yamj": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_0c5yamjDS",
							"filterAttributes": [
								{
									"name": "GridDetailSearchFilter_wtqp5d0_GridDetail_0c5yamj",
									"loadOnChange": true
								},
								{
									"name": "QuickFilter_gzteuv8_GridDetail_0c5yamj",
									"loadOnChange": true
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "desc",
										"columnName": "AccessSharedOn"
									}
								]
							},
							"pagingConfig": {
								"rowCount": 30,
								"rowsLimit": null
							}
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_0c5yamjDS_SysUser": {
									"modelConfig": {
										"path": "GridDetail_0c5yamjDS.SysUser"
									}
								},
								"GridDetail_0c5yamjDS_AccessSharedOn": {
									"modelConfig": {
										"path": "GridDetail_0c5yamjDS.AccessSharedOn"
									}
								},
								"GridDetail_0c5yamjDS_Active": {
									"modelConfig": {
										"path": "GridDetail_0c5yamjDS.Active"
									}
								},
								"GridDetail_0c5yamjDS_Id": {
									"modelConfig": {
										"path": "GridDetail_0c5yamjDS.Id"
									}
								}
							}
						}
					},
					"GridDetail_x4jg0f3": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_x4jg0f3DS",
							"filterAttributes": [
								{
									"name": "GridDetailSearchFilter_AllowedUsers_GridDetail_x4jg0f3",
									"loadOnChange": true
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_x4jg0f3DS_SysUser": {
									"modelConfig": {
										"path": "GridDetail_x4jg0f3DS.SysUser"
									}
								},
								"GridDetail_x4jg0f3DS_CreatedOn": {
									"modelConfig": {
										"path": "GridDetail_x4jg0f3DS.CreatedOn"
									}
								},
								"GridDetail_x4jg0f3DS_Id": {
									"modelConfig": {
										"path": "GridDetail_x4jg0f3DS.Id"
									}
								}
							}
						}
					},
					"OAuthClientAppDS_Logo_lovry63": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Logo"
						}
					},
					"GridDetail_evsys3w": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_evsys3wDS",
							"filterAttributes": [
								{
									"name": "GridDetailSearchFilter_qldvylf_GridDetail_evsys3w",
									"loadOnChange": true
								},
								{
									"name": "QuickFilter_Session_User_GridDetail_evsys3w",
									"loadOnChange": true
								},
								{
									"name": "QuickFilter_Session_StartSession_GridDetail_evsys3w",
									"loadOnChange": true
								},
								{
									"name": "QuickFilter_Session_EndSession_GridDetail_evsys3w",
									"loadOnChange": true
								}
							],
							"pagingConfig": {
								"rowCount": 30,
								"rowsLimit": null
							},
							"sortingConfig": {
								"default": [
									{
										"direction": "asc",
										"columnName": "SessionEndDate"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_evsys3wDS_SysUser": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.SysUser"
									}
								},
								"GridDetail_evsys3wDS_SessionStartDate": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.SessionStartDate"
									}
								},
								"GridDetail_evsys3wDS_SessionEndDate": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.SessionEndDate"
									}
								},
								"GridDetail_evsys3wDS_ClientIP": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.ClientIP"
									}
								},
								"GridDetail_evsys3wDS_Agent": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.Agent"
									}
								},
								"GridDetail_evsys3wDS_Id": {
									"modelConfig": {
										"path": "GridDetail_evsys3wDS.Id"
									}
								}
							}
						}
					},
					"OAuthClientAppDS_IsPublic_h19aqkh": {
						"modelConfig": {
							"path": "OAuthClientAppDS.IsPublic"
						}
					},
					"OAuthClientAppDS_RequirePKCE_w1wlok1": {
						"modelConfig": {
							"path": "OAuthClientAppDS.RequirePKCE"
						}
					},
					"OAuthClientAppDS_ConsentMode": {
						"modelConfig": {
							"path": "OAuthClientAppDS.ConsentMode"
						}
					},
					"OAuthClientAppDS_SystemUser": {
						"modelConfig": {
							"path": "OAuthClientAppDS.SystemUser"
						}
					},
					"IsTechnicalSystemUser": {
						"value": false
					},
					"GridDetail_4sgsz13": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_4sgsz13DS",
							"filterAttributes": [
								{
									"name": "ObjectPermissionsSearchButton_GridDetail_4sgsz13",
									"loadOnChange": true
								}
							],
							"sortingConfig": {
								"default": []
							}
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_4sgsz13DS_Object": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.Object"
									}
								},
								"GridDetail_4sgsz13DS_CanRead": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.CanRead"
									}
								},
								"GridDetail_4sgsz13DS_CanAppend": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.CanAppend"
									}
								},
								"GridDetail_4sgsz13DS_CanEdit": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.CanEdit"
									}
								},
								"GridDetail_4sgsz13DS_CanDelete": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.CanDelete"
									}
								},
								"GridDetail_4sgsz13DS_AdministratedByRecords": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.AdministratedByRecords"
									}
								},
								"GridDetail_4sgsz13DS_AdministratedByColumns": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.AdministratedByColumns"
									}
								},
								"GridDetail_4sgsz13DS_ObjectPermissionsUrl": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.ObjectPermissionsUrl"
									}
								},
								"GridDetail_4sgsz13DS_Id": {
									"modelConfig": {
										"path": "GridDetail_4sgsz13DS.Id"
									}
								}
							}
						}
					},
					"GridDetail_6vxhbxx": {
						"isCollection": true,
						"modelConfig": {
							"path": "GrantedOperationsGridDetailDS",
							"filterAttributes": [
								{
									"loadOnChange": true,
									"name": "GridDetail_6vxhbxx_PredefinedFilter"
								},
								{
									"name": "GrantedOperationsSearchButton_GridDetail_6vxhbxx",
									"loadOnChange": true
								}
							],
							"sortingConfig": {
								"default": []
							}
						},
						"viewModelConfig": {
							"attributes": {
								"GrantedOperationsGridDetailDS_SysAdminOperation": {
									"modelConfig": {
										"path": "GrantedOperationsGridDetailDS.SysAdminOperation"
									}
								},
								"GrantedOperationsGridDetailDS_Id": {
									"modelConfig": {
										"path": "GrantedOperationsGridDetailDS.Id"
									}
								}
							}
						}
					},
					"GridDetail_6vxhbxx_PredefinedFilter": {
						"value": {
							"items": {
								"ed885211-0002-4f12-95b2-aaaaaaaaaaaa": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "CanExecute"
									},
									"isAggregative": false,
									"dataValueType": 12,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": true
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "VwSysAdminOperationGrantee"
						}
					},
					"GridDetail_AllowedGrantTypes": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_AllowedGrantTypesDS"
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_AllowedGrantTypesDS_OAuthGrantType": {
									"modelConfig": {
										"path": "GridDetail_AllowedGrantTypesDS.OAuthGrantType"
									}
								},
								"GridDetail_AllowedGrantTypesDS_Id": {
									"modelConfig": {
										"path": "GridDetail_AllowedGrantTypesDS.Id"
									}
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "OAuthClientAppDS",
					"dependencies": {
						"DataGrid_l5796axDS": [
							{
								"attributePath": "OAuthClientApp",
								"relationPath": "OAuthClientAppDS.Id"
							}
						],
						"GridDetail_0c5yamjDS": [
							{
								"attributePath": "OAuthClientApp",
								"relationPath": "OAuthClientAppDS.Id"
							}
						],
						"GridDetail_x4jg0f3DS": [
							{
								"attributePath": "OAuthClientApp",
								"relationPath": "OAuthClientAppDS.Id"
							}
						],
						"GridDetail_evsys3wDS": [
							{
								"attributePath": "OAuthClientApp",
								"relationPath": "OAuthClientAppDS.Id"
							}
						],
						"GridDetail_AllowedGrantTypesDS": [
							{
								"attributePath": "OAuthClientApp",
								"relationPath": "OAuthClientAppDS.Id"
							}
						],
						"GridDetail_4sgsz13DS": [
							{
								"attributePath": "TechnicalUserId",
								"relationPath": "OAuthClientAppDS.SystemUser"
							}
						],
						"GrantedOperationsGridDetailDS": [
							{
								"attributePath": "SysAdminUnit",
								"relationPath": "OAuthClientAppDS.SystemUser"
							}
						]
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"OAuthClientAppDS": {
						"type": "crt.EntityDataSource",
						"scope": "page",
						"config": {
							"entitySchemaName": "OAuthClientApp",
							"loadParameters": {
								"options": {
									"pagingConfig": {
										"rowCount": 1,
										"rowsOffset": -1
									}
								}
							},
							"allowCopyingRecords": false
						}
					},
					"DataGrid_l5796axDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "RedirectUrlInOAuthClientApp",
							"attributes": {
								"RedirectUrl": {
									"path": "RedirectUrl"
								}
							}
						}
					},
					"GridDetail_0c5yamjDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "UserOAuthSharedAccess",
							"attributes": {
								"SysUser": {
									"path": "SysUser"
								},
								"AccessSharedOn": {
									"path": "AccessSharedOn"
								},
								"Active": {
									"path": "Active"
								}
							}
						}
					},
					"GridDetail_x4jg0f3DS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "OAuthAppAllowedUser",
							"attributes": {
								"SysUser": {
									"path": "SysUser"
								},
								"CreatedOn": {
									"path": "CreatedOn"
								}
							}
						}
					},
					"GridDetail_evsys3wDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "SysUserSession",
							"attributes": {
								"SysUser": {
									"path": "SysUser"
								},
								"SessionStartDate": {
									"path": "SessionStartDate"
								},
								"SessionEndDate": {
									"path": "SessionEndDate"
								},
								"ClientIP": {
									"path": "ClientIP"
								},
								"Agent": {
									"path": "Agent"
								}
							}
						}
					},
					"GridDetail_AllowedGrantTypesDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "OAuthGrantTypeInClient",
							"attributes": {
								"OAuthGrantType": {
									"path": "OAuthGrantType"
								}
							}
						}
					},
					"GridDetail_4sgsz13DS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "TechnicalUsersObjectPermissions",
							"attributes": {
								"Object": {
									"path": "Object"
								},
								"CanRead": {
									"path": "CanRead"
								},
								"CanAppend": {
									"path": "CanAppend"
								},
								"CanEdit": {
									"path": "CanEdit"
								},
								"CanDelete": {
									"path": "CanDelete"
								},
								"AdministratedByRecords": {
									"path": "AdministratedByRecords"
								},
								"AdministratedByColumns": {
									"path": "AdministratedByColumns"
								},
								"ObjectPermissionsUrl": {
									"path": "ObjectPermissionsUrl"
								}
							}
						}
					},
					"GrantedOperationsGridDetailDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "VwSysAdminOperationGrantee",
							"attributes": {
								"SysAdminOperation": {
									"path": "SysAdminOperation"
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: "crt.SaveRecordRequest",
				handler: async (request, next) => {
					const allowedGrantTypes = await prepareAllowedGrantTypesForSave(request.$context);
					if (await request.$context.OAuthClientAppDS_IsPublic_h19aqkh) {
						request.$context.OAuthClientAppDS_RequirePKCE_w1wlok1 = true;
					}
					const currentConsentMode = await request.$context.OAuthClientAppDS_ConsentMode;
					if (!currentConsentMode?.value) {
						request.$context.OAuthClientAppDS_ConsentMode = CONSENT_MODE_ASK_ALWAYS;
					}
					// ENG-88521: require a system user only when the Server-to-server (client_credentials)
					// checkbox is actually selected. Keying this on the real UseClientCredentialsFlow flag
					// (instead of allowedGrantTypes, which getSelectedGrantTypes defaults to [client_credentials]
					// when no flow is selected) prevents a spurious "system user required" error when the user
					// unchecks Server-to-server while another flow (e.g. authorization_code) remains enabled.
					const shouldRequireSystemUser = !!(await request.$context.UseClientCredentialsFlow);
					const currentSystemUser = await request.$context.OAuthClientAppDS_SystemUser;
					if (shouldRequireSystemUser && !currentSystemUser?.value) {
						if (request.$context.formApiModel?.controls?.OAuthClientAppDS_SystemUser) {
							request.$context.formApiModel.controls.OAuthClientAppDS_SystemUser.status = "INVALID";
						}
						request.$context.executeRequest({
							type: "crt.NotificationRequest",
							$context: request.$context,
							message: 'Field: "System user". Error: Enter a value'
						});
						throw new Error(resources.localizableStrings.Error_SystemUserRequired);
					}
					if (request.$context.formApiModel?.controls?.OAuthClientAppDS_SystemUser) {
						request.$context.formApiModel.controls.OAuthClientAppDS_SystemUser.status = "VALID";
					}
					const result = await next?.handle(request);
					await synchronizeAllowedGrantTypes(request.$context, allowedGrantTypes);
					await setContextAttribute(
						request.$context,
						"AllowedGrantTypesBaseline",
						getAllowedGrantTypesSignature(allowedGrantTypes)
					);
					await resetGrantTypesDirtyState(request.$context);
					await syncFooterButtonsState(request.$context);
					return result;
				}
			},
			{
				request: "crt.CancelRecordChangesRequest",
				handler: async (request, next) => {
					const baselineSignature = (await request.$context.AllowedGrantTypesBaseline) || "";
					const baselineGrantTypes = getAllowedGrantTypesFromSignature(baselineSignature);
					const result = await next?.handle(request);
					await setContextAttribute(request.$context, "IsRestoringAllowedGrantTypes",
						true, { preventStateChange: true });
					try {
						await applyAllowedGrantTypes(request.$context, baselineGrantTypes, {
							updateGrantTypeAttribute: false,
							preventStateChange: true
						});
						await updatePublicClientState(request.$context, { preventStateChange: true });
						await updatePublicClientPkceState(request.$context, { preventStateChange: true });
						await syncSystemUserValidation(request.$context);
						await resetGrantTypesDirtyState(request.$context, { preventStateChange: true });
						await syncFooterButtonsState(request.$context, { preventStateChange: true });
						resetPagePristineState(request.$context);
					} finally {
						await setContextAttribute(request.$context, "IsRestoringAllowedGrantTypes",
							false, { preventStateChange: true });
					}
					await new Promise((resolve) => setTimeout(resolve, 0));
					await resetGrantTypesDirtyState(request.$context, { preventStateChange: true });
					await syncFooterButtonsState(request.$context, { preventStateChange: true });
					resetPagePristineState(request.$context);
					return result;
				}
			},
			{
			request: "crt.HandleViewModelInitRequest",
			handler: async (request, next) => {
				await next?.handle(request);
				const featureService = new sdk.FeatureService();
				var isPkceSupportEnabled = await featureService.getFeatureState("EnablePkceSupport");
				request.$context.IsPkceSupportEnabled = isPkceSupportEnabled;
				var isDisableConsentFeatureEnabled =
					await featureService.getFeatureState("EnableOAuthClientDisableConsent");
				request.$context.IsDisableConsentFeatureEnabled = isDisableConsentFeatureEnabled;
				request.$context.IsInstallStatusFeatureEnabled =
					await featureService.getFeatureState("OAuthClientAppInstallStatus");
				const grantTypes = await getSelectedGrantTypes(request.$context);
				var isAuthCodeFlow = grantTypes.includes(AUTHORIZATION_CODE_GRANT);
				request.$context.IsAuthCodeFlow = isAuthCodeFlow;
				request.$context.IsConsentModeComboBoxVisible =
					isAuthCodeFlow && isDisableConsentFeatureEnabled;
				const handlerChain = sdk.HandlerChainService.instance;
				const response = await handlerChain.process({
					type: 'crt.OpenOAuthClientPageRequest',
					$context: request.$context
				});
				await loadAllowedGrantTypes(request.$context);
				await updatePublicClientState(request.$context);
				await syncClientSecretDisplay(request.$context);
				await updatePublicClientPkceState(request.$context);
				await syncSystemUserValidation(request.$context);
				await refreshIsTechnicalSystemUser(request.$context);
				await syncFooterButtonsState(request.$context, { preventStateChange: true });
					if (await isNewClientApp(request.$context)
							&& await request.$context.OAuthClientAppDS_IsPublic_h19aqkh) {
						request.$context.OAuthClientAppDS_RequirePKCE_w1wlok1 = true;
					}
				await refreshInstallStatusState(request.$context);
				return response;
			}
		},
		{
			request: "usr.ToggleOAuthClientAppSecretMaskRequest",
			handler: async (request) => {
				await toggleClientSecretDisplay(request.$context);
			}
		},
		{
			request: "crt.LoadDataRequest",
			handler: async (request, next) => {
				if(request.dataSourceName === "OAuthClientAppDS_SystemUser_List_DS") {
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
				}
				return await next?.handle(request);
			}
		},
		{
			request: "crt.HandleViewModelAttributeChangeRequest",
			handler: async (request, next) => {
				await next?.handle(request);
				if (request.attributeName === "OAuthClientAppDS_Status") {
					await refreshInstallStatusState(request.$context);
					return;
				}
				request.$context.IsConsentModeComboBoxVisible =
					(await request.$context.IsAuthCodeFlow)
						&& (await request.$context.IsDisableConsentFeatureEnabled);
				if (request.attributeName === "UseClientCredentialsFlow"
						|| request.attributeName === "UseAuthorizationCodeFlow"
						|| request.attributeName === "UseTokenExchangeFlow") {
					if (await request.$context.IsRestoringAllowedGrantTypes) {
						return;
					}
					if (!await request.$context.UseClientCredentialsFlow
							&& !await request.$context.UseAuthorizationCodeFlow
							&& !await request.$context.UseTokenExchangeFlow) {
						request.$context.UseClientCredentialsFlow = true;
					}
					await updatePublicClientState(request.$context);
					await updatePublicClientPkceState(request.$context);
					await syncSystemUserValidation(request.$context);
					await syncGrantTypesDirtyState(request.$context);
					await syncFooterButtonsState(request.$context);
					return;
				}
				if (request.attributeName === "OAuthClientAppDS_ClientSecretText_Control") {
					await syncClientSecretDisplay(request.$context);
					await syncFooterButtonsState(request.$context);
					return;
				}
				if (request.attributeName === "OAuthClientAppDS_SystemUser") {
					if (request.$context.formApiModel?.controls?.OAuthClientAppDS_SystemUser) {
						request.$context.formApiModel.controls.OAuthClientAppDS_SystemUser.status = "VALID";
					}
					await refreshIsTechnicalSystemUser(request.$context);
					await syncFooterButtonsState(request.$context);
					return;
				}
				if(request.attributeName === 'OAuthClientAppDS_IsPublic_h19aqkh'){
					await updatePublicClientState(request.$context);
					await updatePublicClientPkceState(request.$context);
					await syncSystemUserValidation(request.$context);
					if (await isNewClientApp(request.$context)
							&& await request.$context.OAuthClientAppDS_IsPublic_h19aqkh) {
						request.$context.OAuthClientAppDS_RequirePKCE_w1wlok1 = true;
					}
				}
				await syncFooterButtonsState(request.$context);
			}
		},
		{
			request: "crt.OpenObjectsPermissionsSection",
			handler: async (request, next) => {
				const baseUrl = window.Terrasoft?.workspaceBaseUrl ?? "";
				window.open(baseUrl + "/ClientApp/#/AdministratedObjects", "_blank")?.focus();
			}
		},
		{
			request: "crt.OpenOperationPermissionsSection",
			handler: async (request, next) => {
				const baseUrl = window.Terrasoft?.workspaceBaseUrl ?? "";
				window.open(baseUrl + "/Shell/#SectionModuleV2/SysAdminOperationSectionV2", "_blank")?.focus();
			}
		},
		{
			request: "usr.InstallOAuthClientAppRequest",
			handler: async (request) => {
				const context = request.$context;
				const recordId = await context.OAuthClientAppDS_Id;
				if (!recordId) {
					return;
				}
				// (#2) Persist any pending edits (grant type, flags, fields) so the install reflects the
				// latest configuration shown on the page (ENG-78572). Save first; if it fails validation it
				// throws and the install does not proceed.
				if ((await context.HasUnsavedData) || (await context.HasUnsavedGrantTypeChanges)) {
					await context.executeRequest({ type: "crt.SaveRecordRequest", $context: context });
				}
				await setContextAttribute(context, "ShowInstallButton", false);
				try {
					const data = await callOAuthClientAppInstallService(recordId);
					const result = data?.InstallResult ?? data;
					if ((result?.success ?? result?.Success) === false) {
						await setContextAttribute(context, "ShowInstallButton", true);
						context.executeRequest({
							type: "crt.NotificationRequest",
							$context: context,
							message: (result?.errorMessage || result?.ErrorMessage)
								|| resources.localizableStrings.InstallFailedMessage
						});
						return;
					}
					// (#3) Reflect the state the install just persisted (Status / ClientId / ClientSecret /
					// IsActive) directly on the open record instead of reloading the primary data source.
					// That data source is bound to the list navigation context (positional paging:
					// pagingConfig { rowCount: 1, rowsOffset: -1 }), so a bare "reload" re-resolves the current
					// row from its position in the list rather than by Id. Once this record leaves the Not
					// installed ordering the reload lands on the next Not installed integration, making the page
					// appear to auto-navigate away (ENG-93603). Writing the values in place keeps the page pinned
					// to the record that was just installed while showing its installed state.
					// Write with preventStateChange so these already-persisted values do NOT mark the form
					// dirty (a plain assignment would flag it as an edit and surface Save/Cancel).
					await setContextAttribute(context, "OAuthClientAppDS_Status",
						{ value: INSTALLED_STATUS_ID }, { preventStateChange: true });
					await setContextAttribute(context, "OAuthClientAppDS_IsActive_m47ntk5",
						true, { preventStateChange: true });
					const installedClientId = result?.clientId ?? result?.ClientId;
					if (installedClientId) {
						await setContextAttribute(context, "OAuthClientAppDS_ClientId_mbzavo8",
							installedClientId, { preventStateChange: true });
					}
					await setContextAttribute(context, "OAuthClientAppDS_ClientSecretText_Control",
						result?.clientSecret ?? result?.ClientSecret ?? "", { preventStateChange: true });
					await refreshInstallStatusState(context);
					await syncClientSecretDisplay(context);
					// Installing persisted these values server-side, so the in-place writes above must not
					// surface Save/Cancel. Clear the dirty flags + form pristine/touched state, then repeat the
					// cleanup once the attribute-change queue has drained (the same two-pass approach the
					// Cancel handler uses) so no asynchronous change event re-flags the form as edited.
					await resetGrantTypesDirtyState(context, { preventStateChange: true });
					resetPagePristineState(context);
					await syncFooterButtonsState(context, { preventStateChange: true });
					await new Promise((resolve) => setTimeout(resolve, 0));
					await resetGrantTypesDirtyState(context, { preventStateChange: true });
					resetPagePristineState(context);
					await syncFooterButtonsState(context, { preventStateChange: true });
					context.executeRequest({
						type: "crt.NotificationRequest",
						$context: context,
						message: resources.localizableStrings.InstallSuccessMessage
					});
				} catch (error) {
					await setContextAttribute(context, "ShowInstallButton", true);
					context.executeRequest({
						type: "crt.NotificationRequest",
						$context: context,
						message: resources.localizableStrings.InstallFailedMessage
					});
				}
			}
		}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


