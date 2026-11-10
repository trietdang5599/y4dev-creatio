define("BaseGeneratedWebFormPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveFormCodeToFileCaption: "Generate landing page code",
		CustomizeDefaultValuesFormCaption: "Set up filling in default values",
		ConfigureFormFields: "The landing page view is not set up. Set up it now?",
		IntegrationFormTabCaption: "Landing setup",
		AfterFormFillControlGroupCaption: "STEP 1. Set up a redirection URL (optional)",
		HowToPlaceFormControlGroupCaption: "STEP 2. Copy the code and configure and map the fields",
		NotesTabCaption: "Attachments and notes",
		TemplateGuideText: "To capture the object data from the landing page to Creatio, place the code below at any location in landing page code. Visit our Academy to learn more about {0}connecting your landing page to Creatio{1} and to {2}set up the object tracking{3}.",
		GenerateScriptCaption: "Generate",
		CopyScriptToClipboardCaption: "Copy",
		ObjectDefaultsCaption: "Default values",
		RedirectionUrlTipCaption: "User will be redirected to this page after submitting the form.",
		PlaceFormTipCaption: "Visit our Academy to learn more \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022LandingFieldsRelation\u0022 \u003Eabout field mapping\u003C/a\u003E",
		SubmitScriptControlGroupCaption: "STEP 3. Insert the customized code into the landing page source code. Set up a function to create the object on form submit",
		SubmitScriptTipCaption: "Visit our Academy \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022LandingSubmitScript\u0022  \u003Eto learn how to insert html-code into your landing page\u003C/a\u003E",
		SubmitScriptHelpText: "Place the edited code on your landing page. Insert the following code into the \u0026ltform\u0026gt tag of your form.",
		ExternalURLTipCaption: "Enter the landing page address, for example, www.example.com/landing.\nEnter \u201Cwww.example*\u201D to set up a single landing page for several domains.",
		UserDefinedColumnTemplate: "\u003Cbr\u003E\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u0022{0}\u0022: \u0022\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0022{2} // {1}",
		ScriptTemplate: "\u003Cdiv style=\u0022font-family: \u0026quot;Courier New\u0026quot;, monospace; font-size: 10pt;\u0022\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://webtracking-v01.bpmonline.com/JS/track-cookies.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=##apiUrl##\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026gt;\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;Replace\u0026nbsp;the\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;\u0026nbsp;placeholders\u0026nbsp;in\u0026nbsp;the\u0026nbsp;code\u0026nbsp;below\u0026nbsp;with\u0026nbsp;the\u0026nbsp;element\u0026nbsp;selectors\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing\u0026nbsp;page.\u003Cbr\u003E*\u0026nbsp;You\u0026nbsp;can\u0026nbsp;use\u0026nbsp;#id\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;CSS\u0026nbsp;selector\u0026nbsp;that\u0026nbsp;will\u0026nbsp;define\u0026nbsp;the\u0026nbsp;input\u0026nbsp;field\u0026nbsp;explicitly.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;#MyEmailField\u0026quot;.\u003Cbr\u003E*\u0026nbsp;If\u0026nbsp;you\u0026nbsp;don\u0027t\u0026nbsp;have\u0026nbsp;a\u0026nbsp;field\u0026nbsp;from\u0026nbsp;the\u0026nbsp;list\u0026nbsp;below\u0026nbsp;placed\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing,\u0026nbsp;leave\u0026nbsp;the\u0026nbsp;placeholder\u0026nbsp;or\u0026nbsp;remove\u0026nbsp;the\u0026nbsp;line.\u003Cbr\u003E*/\u003Cbr\u003Evar\u0026nbsp;config\u0026nbsp;=\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;fields:\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Name\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;visitor,\u0026nbsp;submitting\u0026nbsp;the\u0026nbsp;page\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Zip\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;ZIP\u0026nbsp;code\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;MobilePhone\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;phone\u0026nbsp;number\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Company\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;company\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Industry\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Company\u0026nbsp;industry\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullJobTitle\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;job\u0026nbsp;title\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;UseEmail\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Logical\u0026nbsp;value:\u0026nbsp;\u0027true\u0027\u0026nbsp;equals\u0026nbsp;to\u0026nbsp;visitor\u0027s\u0026nbsp;opt-in\u0026nbsp;to\u0026nbsp;receive\u0026nbsp;emails\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;City\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;City\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Country\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Country\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Commentary\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;##customColumnsComma##\u0026nbsp;//\u0026nbsp;Notes##customColumns##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landingId:\u0026nbsp;##landingId##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;serviceUrl:\u0026nbsp;##serviceUrl##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;redirectUrl:\u0026nbsp;##redirectUrl##\u003Cbr\u003E};\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;creates\u0026nbsp;a\u0026nbsp;object\u0026nbsp;from\u0026nbsp;the\u0026nbsp;submitted\u0026nbsp;data.\u003Cbr\u003E*\u0026nbsp;Bind\u0026nbsp;this\u0026nbsp;function\u0026nbsp;call\u0026nbsp;to\u0026nbsp;the\u0026nbsp;\u0026quot;onSubmit\u0026quot;\u0026nbsp;event\u0026nbsp;of\u0026nbsp;the\u0026nbsp;form\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;elements\u0026nbsp;events.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026lt;form\u0026nbsp;class=\u0026quot;mainForm\u0026quot;\u0026nbsp;name=\u0026quot;landingForm\u0026quot;\u0026nbsp;onSubmit=\u0026quot;createObject();\u0026nbsp;return\u0026nbsp;false\u0026quot;\u0026gt;\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;createObject()\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landing.createObjectFromLanding(config)\u003Cbr\u003E}\u003Cbr\u003E\u0026lt;/script\u0026gt;\u003C/div\u003E",
		TogledScriptTemplate: "\u003Cdiv style=\u0022font-family: \u0026quot;Courier New\u0026quot;, monospace; font-size: 10pt;\u0022\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://webtracking-v01.creatio.com/JS/track-cookies.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=##apiUrl##\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026gt;\u003Cbr\u003E##trackingCode##\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;Replace\u0026nbsp;the\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;\u0026nbsp;placeholders\u0026nbsp;in\u0026nbsp;the\u0026nbsp;code\u0026nbsp;below\u0026nbsp;with\u0026nbsp;the\u0026nbsp;element\u0026nbsp;selectors\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing\u0026nbsp;page.\u003Cbr\u003E*\u0026nbsp;You\u0026nbsp;can\u0026nbsp;use\u0026nbsp;#id\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;CSS\u0026nbsp;selector\u0026nbsp;that\u0026nbsp;will\u0026nbsp;define\u0026nbsp;the\u0026nbsp;input\u0026nbsp;field\u0026nbsp;explicitly.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;#MyEmailField\u0026quot;.\u003Cbr\u003E*\u0026nbsp;If\u0026nbsp;you\u0026nbsp;don\u0027t\u0026nbsp;have\u0026nbsp;a\u0026nbsp;field\u0026nbsp;from\u0026nbsp;the\u0026nbsp;list\u0026nbsp;below\u0026nbsp;placed\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing,\u0026nbsp;leave\u0026nbsp;the\u0026nbsp;placeholder\u0026nbsp;or\u0026nbsp;remove\u0026nbsp;the\u0026nbsp;line.\u003Cbr\u003E*/\u003Cbr\u003Evar\u0026nbsp;config\u0026nbsp;=\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;fields:\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Name\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;visitor,\u0026nbsp;submitting\u0026nbsp;the\u0026nbsp;page\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Zip\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;ZIP\u0026nbsp;code\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;MobilePhone\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;phone\u0026nbsp;number\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Company\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;company\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Industry\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Company\u0026nbsp;industry\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullJobTitle\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;job\u0026nbsp;title\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;UseEmail\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Logical\u0026nbsp;value:\u0026nbsp;\u0027true\u0027\u0026nbsp;equals\u0026nbsp;to\u0026nbsp;visitor\u0027s\u0026nbsp;opt-in\u0026nbsp;to\u0026nbsp;receive\u0026nbsp;emails\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;City\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;City\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Country\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Country\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Commentary\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;##customColumnsComma##\u0026nbsp;//\u0026nbsp;Notes##customColumns##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},##contactFields##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;customFields: {##customFields##},\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landingId:\u0026nbsp;##landingId##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;serviceUrl:\u0026nbsp;##serviceUrl##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;redirectUrl:\u0026nbsp;##redirectUrl##\u003Cbr\u003E};\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;creates\u0026nbsp;a\u0026nbsp;object\u0026nbsp;from\u0026nbsp;the\u0026nbsp;submitted\u0026nbsp;data.\u003Cbr\u003E*\u0026nbsp;Bind\u0026nbsp;this\u0026nbsp;function\u0026nbsp;call\u0026nbsp;to\u0026nbsp;the\u0026nbsp;\u0026quot;onSubmit\u0026quot;\u0026nbsp;event\u0026nbsp;of\u0026nbsp;the\u0026nbsp;form\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;elements\u0026nbsp;events.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026lt;form\u0026nbsp;class=\u0026quot;mainForm\u0026quot;\u0026nbsp;name=\u0026quot;landingForm\u0026quot;\u0026nbsp;onSubmit=\u0026quot;createObject();\u0026nbsp;return\u0026nbsp;false\u0026quot;\u0026gt;\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;createObject()\u0026nbsp;{\u003Cbr\u003E##createObjectServiceCall##\u003Cbr\u003E}\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;inits\u0026nbsp;landing\u0026nbsp;page\u0026nbsp;using\u0026nbsp;URL\u0026nbsp;parameters.\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;initLanding()\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landing.initLanding(config);\u003Cbr\u003E}\u003Cbr\u003EjQuery(document).ready(initLanding);\u003Cbr\u003E\u0026lt;/script\u0026gt;\u003C/div\u003E",
		ContactColumnNameAbsent: "",
		FormPrepopulationSetupAcademyUrl: "How to setup form prepopulation",
		FAQContainerCaption: "Frequently asked questions",
		TypicalSetupErrorsAcademyUrl: "Typical setup errors",
		SetupSpecialFieldsAcademyUrl: "How to set up the transfer of lookups and special fields",
		SetupUserFieldsAcademyUrl: "How to set up the transfer of custom fields",
		WebFormSetupAcademyUrl: "How to setup a web form for contacts, requests and other objects",
		ContactFieldsTemplate: "\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;contactFields: {\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullName\u0026quot;: \u0026quot;css-selector\u0026quot;, // Name of a contact\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Phone\u0026quot;: \u0026quot;css-selector\u0026quot;, // Contact\u0026#39;s mobile phone\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;: \u0026quot;css-selector\u0026quot; // Contact\u0026#39;s email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},",
		IdentificationProcessTipCaption: "Select the contact search and creation process. Click \u003Ca href=\u0022../NUI/ViewModule.aspx#LookupSectionModule/BaseLookupConfigurationSection/WebFormContactIdentifier\u0022 target=\u0022_blank\u0022\u003Ehere\u003C/a\u003E to view the process lookup.",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		EditRightsCaption: "Set up access rights",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		NewRecordPageCaptionSuffix: ": New record",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenChangeLogMenuCaption: "View change log",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		TagButtonHint: "Tags",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		FAQIcon: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "FAQIcon",
				hash: "1875f36f0da7a2086f1ac06444c432be",
				resourceItemExtension: ".png"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		},
		OpenProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseGeneratedWebFormPageV2",
				resourceItemName: "OpenProcessButtonImage",
				hash: "84a02783e1a9690c307b49af1401210d",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});