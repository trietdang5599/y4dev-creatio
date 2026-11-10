define("SoapWebServiceMethodPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		UriTip: "XML element name of root message element in \u0026#x3C;soap:Body\u0026#x3E;. Usually the same as operation name in WSDL. For example, it will be \u0022MessageElementName\u0022 in the following request body:\n\u0026#x3C;soap:Body\u0026#x3E;\n    \u0026#x3C;MessageElementName\u0026#x3E;\n        \u0026#x3C;Parameters\u0026#x3E;\n            ...\n        \u0026#x3C;/Parameters\u0026#x3E;\n    \u0026#x3C;/MessageElementName\u0026#x3E;\n\u0026#x3C;/soap:Body\u0026#x3E;",
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
		UriCaption: "Message element code",
		UseAuthInfoCaption: "Use authentication",
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
				schemaName: "SoapWebServiceMethodPage",
				resourceItemName: "CloseIcon",
				hash: "563de164682be35ef981066b7287177c",
				resourceItemExtension: ".svg"
			}
		},
		WizardIcon: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceMethodPage",
				resourceItemName: "WizardIcon",
				hash: "b60a2ec813def6ff992e7c7633d56887",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});