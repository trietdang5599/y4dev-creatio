define("RestWebServiceMethodPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		RequestBodyBuilderCaption: "Web service request builder",
		AccessDeny: "The package of the web service cannot be modified or you do not have permission to edit this web service. Modify the \u0022Current package\u0022 system setting or obtain corresponding permissions.",
		AddressHint: "Method address parameters must be encompassed in curly braces {}. Complete web service call address has the following structure: \u0022Web service URI\u0022 \u002B \u0022Method address\u0022 \u002B \u0022?\u0022 \u002B \u0022A set of request parameters separated with \u0026\u0022",
		CancelButtonCaption: "Cancel",
		CodeCaption: "Code",
		CodeHint: "Used by developers for interacting with the web service in Creatio source code",
		ContentTypeCaption: "Content type",
		DefaultParameterValue: "value",
		DuplicateNameMessage: "Method with this code already exists.",
		FullUriCaption: "Complete address",
		HttpMethodTypeCaption: "Request type",
		MethodCaptionPrefix: "Method",
		MethodNameCaption: "Name",
		OkButtonCaption: "",
		OpenServiceClientButtonCaption: "Send test request",
		QuickSetupButtonCaption: "Quick setup",
		QuickSetupCurlButtonCaption: "Example in cURL",
		QuickSetupEmptyUriMessage: "Parameters not found in \u0022Method address field\u0022. For successful setup method address parameters must be encompassed in curly braces {} or you can specify query parameters after \u0022?\u0022 symbol.",
		QuickSetupJsonRequestButtonCaption: "Example in JSON",
		QuickSetupJsonResponseButtonCaption: "Example in JSON",
		QuickSetupRawRequestButtonCaption: "Example in RAW",
		QuickSetupRawResponseButtonCaption: "Example in RAW",
		QuickSetupUriButtonCaption: "From field \u0022Method address\u0022",
		RequestExampleSeparatorCaption: "From request example",
		RequestTabCaption: "Request parameters",
		RequestTimeoutCaption: "Response timeout, ms",
		ResponseExampleSeparatorCaption: "From Response example",
		ResponseTabCaption: "Response parameters",
		SaveButtonCaption: "Ok",
		SeveServiceSchemaForServiceClientMessage: "The web service was modified. You must save the web service to run it up-to-date. Save now?",
		UriCaption: "Method address",
		UseAuthInfoCaption: "Use authentication",
		WrongContentTypeMessage: "To set content type as \u0022XML\u0022, parameters must not contain parameters with type \u0022Body parameter\u0022. Please delete them or change their type and try again.",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first.",
		WrongPrefixMessage: "Code must contain prefix \u0022{0}\u0022",
		WrongRequestTypeMessage: "To set method type as \u0022GET\u0022, request parameters must not contain parameters with type \u0022Body parameter\u0022. Please delete them or change their type and try again.",
		WrongUriMessage: "We found new parameter in \u0022Method address\u0022 field: {0}. It must be added to the \u0022Request parameters\u0022 list. Do you want to add it automatically?",
		WrongUrisBracketsMessage: "Missing an opening \u0022{\u0022 or closing \u0022}\u0022 curly braces, or there are nested braces like {{parameter}}.",
		WrongUrisEmptyBracketsMessage: "This string contains curly braces \u0022{}\u0022 without text inside. Please write the address parameter code between braces, or delete the symbols combination \u0022{}\u0022.",
		WrongUrisMessage: "We found new parameters in \u0022Method address\u0022 field: {0}. They must be added to the \u0022Request parameters\u0022 list. \nDo you want to add them automatically?"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "RestWebServiceMethodPage",
				resourceItemName: "CloseIcon",
				hash: "563de164682be35ef981066b7287177c",
				resourceItemExtension: ".svg"
			}
		},
		WizardIcon: {
			source: 3,
			params: {
				schemaName: "RestWebServiceMethodPage",
				resourceItemName: "WizardIcon",
				hash: "b60a2ec813def6ff992e7c7633d56887",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});