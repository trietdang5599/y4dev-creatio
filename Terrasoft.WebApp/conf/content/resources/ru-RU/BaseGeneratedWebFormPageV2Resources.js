define("BaseGeneratedWebFormPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveFormCodeToFileCaption: "\u041F\u043E\u043B\u0443\u0447\u0438\u0442\u044C \u043A\u043E\u0434 \u0434\u043B\u044F \u0441\u0430\u0439\u0442\u0430",
		CustomizeDefaultValuesFormCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0437\u0430\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F \u043F\u043E\u043B\u0435\u0439 \u043F\u043E \u0443\u043C\u043E\u043B\u0447\u0430\u043D\u0438\u044E",
		ConfigureFormFields: "\u041D\u0435 \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D \u0432\u043D\u0435\u0448\u043D\u0438\u0439 \u0432\u0438\u0434 \u0444\u043E\u0440\u043C\u044B. \u0425\u043E\u0442\u0438\u0442\u0435 \u0435\u0433\u043E \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0441\u0435\u0439\u0447\u0430\u0441?",
		IntegrationFormTabCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043B\u0435\u043D\u0434\u0438\u043D\u0433\u0430",
		AfterFormFillControlGroupCaption: "\u0428\u0410\u0413 1. \u041D\u0430\u0441\u0442\u0440\u043E\u0439\u0442\u0435 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u043F\u0435\u0440\u0435\u0430\u0434\u0440\u0435\u0441\u0430\u0446\u0438\u0438 (\u043E\u043F\u0446\u0438\u043E\u043D\u0430\u043B\u044C\u043D\u043E)",
		HowToPlaceFormControlGroupCaption: "\u0428\u0410\u0413 2. \u0421\u043A\u043E\u043F\u0438\u0440\u0443\u0439\u0442\u0435 \u043A\u043E\u0434 \u0438 \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u0442\u0435 \u0432 \u043D\u0435\u043C \u0441\u043E\u043E\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0438\u0435 \u043F\u043E\u043B\u0435\u0439",
		NotesTabCaption: "\u0424\u0430\u0439\u043B\u044B \u0438 \u043F\u0440\u0438\u043C\u0435\u0447\u0430\u043D\u0438\u044F",
		TemplateGuideText: "\u0414\u043B\u044F \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u043F\u0435\u0440\u0435\u0434\u0430\u0447\u0438 \u043E\u0431\u044A\u0435\u043A\u0442\u0430 \u0438\u0437 \u043B\u0435\u043D\u0434\u0438\u043D\u0433\u0430 \u0432 Creatio, \u0440\u0430\u0437\u043C\u0435\u0441\u0442\u0438\u0442\u0435 \u043F\u0440\u0438\u0432\u0435\u0434\u0435\u043D\u043D\u044B\u0439 \u043D\u0438\u0436\u0435 \u043A\u043E\u0434 \u0432 \u043B\u044E\u0431\u043E\u043C \u043C\u0435\u0441\u0442\u0435 \u043D\u0430 \u043F\u043E\u0441\u0430\u0434\u043E\u0447\u043D\u043E\u0439 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435 \u0432\u0430\u0448\u0435\u0433\u043E \u0441\u0430\u0439\u0442\u0430. \u0412 \u0430\u043A\u0430\u0434\u0435\u043C\u0438\u0438 \u0432\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u0443\u0437\u043D\u0430\u0442\u044C \u0434\u0435\u0442\u0430\u043B\u044C\u043D\u0435\u0435, {0}\u043A\u0430\u043A \u0441\u0432\u044F\u0437\u0430\u0442\u044C \u043B\u0435\u043D\u0434\u0438\u043D\u0433 \u0441 Creatio{1}, \u0430 \u0442\u0430\u043A\u0436\u0435 {2}\u043A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0442\u0440\u0435\u043A\u0438\u043D\u0433 \u043E\u0431\u044A\u0435\u043A\u0442\u043E\u0432{3}.",
		GenerateScriptCaption: "\u0413\u0435\u043D\u0435\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		CopyScriptToClipboardCaption: "\u041A\u043E\u043F\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		ObjectDefaultsCaption: "\u0417\u043D\u0430\u0447\u0435\u043D\u0438\u044F \u043F\u043E \u0443\u043C\u043E\u043B\u0447\u0430\u043D\u0438\u044E",
		RedirectionUrlTipCaption: "\u041F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044C \u0431\u0443\u0434\u0435\u0442 \u043F\u0435\u0440\u0435\u0430\u0434\u0440\u0435\u0441\u043E\u0432\u0430\u043D \u043D\u0430 \u044D\u0442\u0443 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u043F\u043E\u0441\u043B\u0435 \u0437\u0430\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F \u0444\u043E\u0440\u043C\u044B",
		PlaceFormTipCaption: "\u0423\u0437\u043D\u0430\u0439\u0442\u0435 \u0432 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438, \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022LandingFieldsRelation\u0022 \u003E\u043A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0441\u043E\u043E\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0438\u0435 \u043F\u043E\u043B\u0435\u0439\u003C/a\u003E",
		SubmitScriptControlGroupCaption: "\u0428\u0410\u0413 3.  \u0412\u0441\u0442\u0430\u0432\u044C\u0442\u0435 \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D\u043D\u044B\u0439 \u043A\u043E\u0434  \u043D\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u043B\u0435\u043D\u0434\u0438\u043D\u0433\u0430. \u041D\u0430\u0441\u0442\u0440\u043E\u0439\u0442\u0435 \u0437\u0430\u043F\u0443\u0441\u043A \u0444\u0443\u043D\u043A\u0446\u0438\u0438 \u0441\u043E\u0437\u0434\u0430\u043D\u0438\u044F \u043E\u0431\u044A\u0435\u043A\u0442\u0430 \u043F\u043E submit \u0444\u043E\u0440\u043C\u044B",
		SubmitScriptTipCaption: "\u0423\u0437\u043D\u0430\u0439\u0442\u0435 \u0432 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438, \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022LandingSubmitScript\u0022 \u003E\u043A\u0430\u043A \u0440\u0430\u0437\u043C\u0435\u0441\u0442\u0438\u0442\u044C HTML-\u043A\u043E\u0434 \u0432 \u043A\u043E\u0434\u0435 \u043F\u043E\u0441\u0430\u0434\u043E\u0447\u043D\u043E\u0439 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B\u003C/a\u003E",
		SubmitScriptHelpText: "\u0420\u0430\u0437\u043C\u0435\u0441\u0442\u0438\u0442\u0435 \u043E\u0442\u0440\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u043D\u043D\u044B\u0439 \u043A\u043E\u0434 \u043D\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435 \u043B\u0435\u043D\u0434\u0438\u043D\u0433\u0430. \u0412\u0441\u0442\u0430\u0432\u044C\u0442\u0435 \u043A\u043E\u0434 \u043D\u0438\u0436\u0435 \u0432 \u0442\u0435\u0433 \u0026ltform\u0026gt \u0432\u0430\u0448\u0435\u0439 \u0444\u043E\u0440\u043C\u044B.",
		ExternalURLTipCaption: "\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u0430\u0434\u0440\u0435\u0441 \u043B\u0435\u043D\u0434\u0438\u043D\u0433\u0430, \u043D\u0430\u043F\u0440\u0438\u043C\u0435\u0440, www.example.com/landing.\u0412\u044B \u0442\u0430\u043A\u0436\u0435 \u043C\u043E\u0436\u0435\u0442\u0435 \u0432\u0432\u0435\u0441\u0442\u0438 \u0022www.example*\u0022, \u0447\u0442\u043E\u0431\u044B \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043E\u0434\u0438\u043D \u043B\u0435\u043D\u0434\u0438\u043D\u0433 \u0434\u043B\u044F \u043D\u0435\u0441\u043A\u043E\u043B\u044C\u043A\u0438\u0445 \u0434\u043E\u043C\u0435\u043D\u043E\u0432.",
		UserDefinedColumnTemplate: "\u003Cbr\u003E\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u0022{0}\u0022: \u0022\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0022{2} // {1}",
		ScriptTemplate: "\u003Cdiv style=\u0022font-family: \u0026quot;Courier New\u0026quot;, monospace; font-size: 10pt;\u0022\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://webtracking-v01.bpmonline.com/JS/track-cookies.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=##apiUrl##\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026gt;\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;Replace\u0026nbsp;the\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;\u0026nbsp;placeholders\u0026nbsp;in\u0026nbsp;the\u0026nbsp;code\u0026nbsp;below\u0026nbsp;with\u0026nbsp;the\u0026nbsp;element\u0026nbsp;selectors\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing\u0026nbsp;page.\u003Cbr\u003E*\u0026nbsp;You\u0026nbsp;can\u0026nbsp;use\u0026nbsp;#id\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;CSS\u0026nbsp;selector\u0026nbsp;that\u0026nbsp;will\u0026nbsp;define\u0026nbsp;the\u0026nbsp;input\u0026nbsp;field\u0026nbsp;explicitly.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;#MyEmailField\u0026quot;.\u003Cbr\u003E*\u0026nbsp;If\u0026nbsp;you\u0026nbsp;don\u0027t\u0026nbsp;have\u0026nbsp;a\u0026nbsp;field\u0026nbsp;from\u0026nbsp;the\u0026nbsp;list\u0026nbsp;below\u0026nbsp;placed\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing,\u0026nbsp;leave\u0026nbsp;the\u0026nbsp;placeholder\u0026nbsp;or\u0026nbsp;remove\u0026nbsp;the\u0026nbsp;line.\u003Cbr\u003E*/\u003Cbr\u003Evar\u0026nbsp;config\u0026nbsp;=\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;fields:\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Name\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;visitor,\u0026nbsp;submitting\u0026nbsp;the\u0026nbsp;page\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Zip\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;ZIP\u0026nbsp;code\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;MobilePhone\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;phone\u0026nbsp;number\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Company\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;company\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Industry\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Company\u0026nbsp;industry\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullJobTitle\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;job\u0026nbsp;title\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;UseEmail\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Logical\u0026nbsp;value:\u0026nbsp;\u0027true\u0027\u0026nbsp;equals\u0026nbsp;to\u0026nbsp;visitor\u0027s\u0026nbsp;opt-in\u0026nbsp;to\u0026nbsp;receive\u0026nbsp;emails\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;City\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;City\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Country\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Country\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Commentary\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;##customColumnsComma##\u0026nbsp;//\u0026nbsp;Notes##customColumns##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landingId:\u0026nbsp;##landingId##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;serviceUrl:\u0026nbsp;##serviceUrl##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;redirectUrl:\u0026nbsp;##redirectUrl##\u003Cbr\u003E};\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;creates\u0026nbsp;a\u0026nbsp;object\u0026nbsp;from\u0026nbsp;the\u0026nbsp;submitted\u0026nbsp;data.\u003Cbr\u003E*\u0026nbsp;Bind\u0026nbsp;this\u0026nbsp;function\u0026nbsp;call\u0026nbsp;to\u0026nbsp;the\u0026nbsp;\u0026quot;onSubmit\u0026quot;\u0026nbsp;event\u0026nbsp;of\u0026nbsp;the\u0026nbsp;form\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;elements\u0026nbsp;events.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026lt;form\u0026nbsp;class=\u0026quot;mainForm\u0026quot;\u0026nbsp;name=\u0026quot;landingForm\u0026quot;\u0026nbsp;onSubmit=\u0026quot;createObject();\u0026nbsp;return\u0026nbsp;false\u0026quot;\u0026gt;\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;createObject()\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landing.createObjectFromLanding(config)\u003Cbr\u003E}\u003Cbr\u003E\u0026lt;/script\u0026gt;\u003C/div\u003E",
		TogledScriptTemplate: "\u003Cdiv style=\u0022font-family: \u0026quot;Courier New\u0026quot;, monospace; font-size: 10pt;\u0022\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=\u0026quot;https://webtracking-v01.creatio.com/JS/track-cookies.js\u0026quot;\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026nbsp;src=##apiUrl##\u0026gt;\u0026lt;/script\u0026gt;\u003Cbr\u003E\u0026lt;script\u0026gt;\u003Cbr\u003E##trackingCode##\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;Replace\u0026nbsp;the\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;\u0026nbsp;placeholders\u0026nbsp;in\u0026nbsp;the\u0026nbsp;code\u0026nbsp;below\u0026nbsp;with\u0026nbsp;the\u0026nbsp;element\u0026nbsp;selectors\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing\u0026nbsp;page.\u003Cbr\u003E*\u0026nbsp;You\u0026nbsp;can\u0026nbsp;use\u0026nbsp;#id\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;CSS\u0026nbsp;selector\u0026nbsp;that\u0026nbsp;will\u0026nbsp;define\u0026nbsp;the\u0026nbsp;input\u0026nbsp;field\u0026nbsp;explicitly.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;#MyEmailField\u0026quot;.\u003Cbr\u003E*\u0026nbsp;If\u0026nbsp;you\u0026nbsp;don\u0027t\u0026nbsp;have\u0026nbsp;a\u0026nbsp;field\u0026nbsp;from\u0026nbsp;the\u0026nbsp;list\u0026nbsp;below\u0026nbsp;placed\u0026nbsp;on\u0026nbsp;your\u0026nbsp;landing,\u0026nbsp;leave\u0026nbsp;the\u0026nbsp;placeholder\u0026nbsp;or\u0026nbsp;remove\u0026nbsp;the\u0026nbsp;line.\u003Cbr\u003E*/\u003Cbr\u003Evar\u0026nbsp;config\u0026nbsp;=\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;fields:\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Name\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;visitor,\u0026nbsp;submitting\u0026nbsp;the\u0026nbsp;page\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Zip\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;ZIP\u0026nbsp;code\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;MobilePhone\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;phone\u0026nbsp;number\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Company\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Name\u0026nbsp;of\u0026nbsp;a\u0026nbsp;company\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Industry\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Company\u0026nbsp;industry\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullJobTitle\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Visitor\u0027s\u0026nbsp;job\u0026nbsp;title\u0026nbsp;(for\u0026nbsp;business\u0026nbsp;landing\u0026nbsp;pages)\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;UseEmail\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Logical\u0026nbsp;value:\u0026nbsp;\u0027true\u0027\u0026nbsp;equals\u0026nbsp;to\u0026nbsp;visitor\u0027s\u0026nbsp;opt-in\u0026nbsp;to\u0026nbsp;receive\u0026nbsp;emails\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;City\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;City\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Country\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;,\u0026nbsp;//\u0026nbsp;Country\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Commentary\u0026quot;:\u0026nbsp;\u0026quot;\u003Cspan style=\u0022color: #0c0cec;\u0022\u003Ecss-selector\u003C/span\u003E\u0026quot;##customColumnsComma##\u0026nbsp;//\u0026nbsp;Notes##customColumns##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},##contactFields##\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;customFields: {##customFields##},\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landingId:\u0026nbsp;##landingId##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;serviceUrl:\u0026nbsp;##serviceUrl##,\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;redirectUrl:\u0026nbsp;##redirectUrl##\u003Cbr\u003E};\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;creates\u0026nbsp;a\u0026nbsp;object\u0026nbsp;from\u0026nbsp;the\u0026nbsp;submitted\u0026nbsp;data.\u003Cbr\u003E*\u0026nbsp;Bind\u0026nbsp;this\u0026nbsp;function\u0026nbsp;call\u0026nbsp;to\u0026nbsp;the\u0026nbsp;\u0026quot;onSubmit\u0026quot;\u0026nbsp;event\u0026nbsp;of\u0026nbsp;the\u0026nbsp;form\u0026nbsp;or\u0026nbsp;any\u0026nbsp;other\u0026nbsp;elements\u0026nbsp;events.\u003Cbr\u003E*\u0026nbsp;Example:\u0026nbsp;\u0026lt;form\u0026nbsp;class=\u0026quot;mainForm\u0026quot;\u0026nbsp;name=\u0026quot;landingForm\u0026quot;\u0026nbsp;onSubmit=\u0026quot;createObject();\u0026nbsp;return\u0026nbsp;false\u0026quot;\u0026gt;\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;createObject()\u0026nbsp;{\u003Cbr\u003E##createObjectServiceCall##\u003Cbr\u003E}\u003Cbr\u003E/**\u003Cbr\u003E*\u0026nbsp;The\u0026nbsp;function\u0026nbsp;below\u0026nbsp;inits\u0026nbsp;landing\u0026nbsp;page\u0026nbsp;using\u0026nbsp;URL\u0026nbsp;parameters.\u003Cbr\u003E*/\u003Cbr\u003Efunction\u0026nbsp;initLanding()\u0026nbsp;{\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;landing.initLanding(config);\u003Cbr\u003E}\u003Cbr\u003EjQuery(document).ready(initLanding);\u003Cbr\u003E\u0026lt;/script\u0026gt;\u003C/div\u003E",
		ContactColumnNameAbsent: "",
		FormPrepopulationSetupAcademyUrl: "\u041A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0440\u0435\u0434\u0437\u0430\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u0435 \u0444\u043E\u0440\u043C\u044B",
		FAQContainerCaption: "\u0427\u0430\u0441\u0442\u043E \u0437\u0430\u0434\u0430\u0432\u0430\u0435\u043C\u044B\u0435 \u0432\u043E\u043F\u0440\u043E\u0441\u044B",
		TypicalSetupErrorsAcademyUrl: "\u0422\u0438\u043F\u0438\u0447\u043D\u044B\u0435 \u043E\u0448\u0438\u0431\u043A\u0438 \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438",
		SetupSpecialFieldsAcademyUrl: "\u041A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0435\u0440\u0435\u0434\u0430\u0447\u0443 \u0441\u043F\u0440\u0430\u0432\u043E\u0447\u043D\u044B\u0445 \u0438 \u043D\u0435\u0441\u0442\u0430\u043D\u0434\u0430\u0440\u0442\u043D\u044B\u0445 \u043F\u043E\u043B\u0435\u0439",
		SetupUserFieldsAcademyUrl: "\u041A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0435\u0440\u0435\u0434\u0430\u0447\u0443 \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044C\u0441\u043A\u0438\u0445 \u043F\u043E\u043B\u0435\u0439",
		WebFormSetupAcademyUrl: "\u041A\u0430\u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0444\u043E\u0440\u043C\u0443 \u0434\u043B\u044F \u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0430\u0446\u0438\u0438 \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u043E\u0432, \u0437\u0430\u044F\u0432\u043E\u043A \u0438 \u0434\u0440\u0443\u0433\u0438\u0445 \u043E\u0431\u044A\u0435\u043A\u0442\u043E\u0432",
		ContactFieldsTemplate: "\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;contactFields: {\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;FullName\u0026quot;: \u0026quot;css-selector\u0026quot;, // Name of a contact\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Phone\u0026quot;: \u0026quot;css-selector\u0026quot;, // Contact\u0026#39;s mobile phone\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026quot;Email\u0026quot;: \u0026quot;css-selector\u0026quot; // Contact\u0026#39;s email\u003Cbr\u003E\u0026nbsp;\u0026nbsp;\u0026nbsp;\u0026nbsp;},",
		IdentificationProcessTipCaption: "\u0422\u0443\u0442 \u0432\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u0432\u044B\u0431\u0440\u0430\u0442\u044C \u0431\u0438\u0437\u043D\u0435\u0441-\u043F\u0440\u043E\u0446\u0435\u0441\u0441 \u043F\u043E\u0438\u0441\u043A\u0430 \u0438 \u0441\u043E\u0437\u0434\u0430\u043D\u0438\u044F \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u0430, \u0441\u043F\u0440\u0430\u0432\u043E\u0447\u043D\u0438\u043A \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432 \u0434\u043E\u0441\u0442\u0443\u043F\u0435\u043D \u003Ca href=\u0022../NUI/ViewModule.aspx#LookupSectionModule/BaseLookupConfigurationSection/WebFormContactIdentifier\u0022 target=\u0022_blank\u0022\u003E\u0437\u0434\u0435\u0441\u044C\u003C/a\u003E.",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		BeginProcessButtonMenuItemCaption: "\u041D\u0430\u0447\u0430\u0442\u044C \u043F\u0440\u043E\u0446\u0435\u0441\u0441",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CanCustomizeWarning: "\u041E\u043F\u0440\u0435\u0434\u0435\u043B\u0438\u0442\u0435 {0} \u0430\u0442\u0440\u0438\u0431\u0443\u0442, \u0432\u043C\u0435\u0441\u0442\u043E \u043F\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u043A\u0438 \u043F\u0443\u0441\u0442\u043E\u0439 \u0444\u0443\u043D\u043A\u0446\u0438\u0435\u0439 \u043C\u0435\u0442\u043E\u0434\u0430 {1}",
		ClearButtonHint: "\u041E\u0447\u0438\u0441\u0442\u0438\u0442\u044C \u043F\u043E\u043B\u0435",
		CloseButtonCaption: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		ColumnFilterInvalidFormatException: "\u041D\u0435\u043A\u043E\u0440\u0440\u0435\u043A\u0442\u043D\u043E \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D\u0430 \u0444\u0438\u043B\u044C\u0442\u0440\u0430\u0446\u0438\u044F \u043F\u043E \u043A\u043E\u043B\u043E\u043D\u043A\u0435 {0}",
		ContinueProcessButtonMenuItemCaption: "\u041F\u0440\u043E\u0434\u043E\u043B\u0436\u0438\u0442\u044C \u043F\u0440\u043E\u0446\u0435\u0441\u0441",
		DelayExecutionButtonCaption: "\u0412\u044B\u043F\u043E\u043B\u043D\u0438\u0442\u044C \u043F\u043E\u0437\u0436\u0435",
		EditRightsCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0440\u0430\u0432\u0430 \u0434\u043E\u0441\u0442\u0443\u043F\u0430",
		FieldLockHint: "\u041D\u0435\u0440\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u0443\u0435\u043C\u043E\u0435 \u043F\u043E\u043B\u0435",
		FieldsGroupCollapseButtonHint: "\u0421\u0432\u0435\u0440\u043D\u0443\u0442\u044C/\u0420\u0430\u0437\u0432\u0435\u0440\u043D\u0443\u0442\u044C",
		FieldValidationError: "\u041F\u043E\u043B\u0435 \u0022{0}\u0022: {1}",
		HeaderTipAcademyBtnCaption: "\u0423\u0437\u043D\u0430\u0442\u044C \u0431\u043E\u043B\u044C\u0448\u0435 \u043D\u0430 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438",
		HeaderTipCaption: "\u0412 Creatio 7.8 \u0443\u043B\u0443\u0447\u0448\u0435\u043D \u0432\u043D\u0435\u0448\u043D\u0438\u0439 \u0432\u0438\u0434 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		HeaderTipContent: "\u0418\u0437\u043C\u0435\u043D\u0438\u043B\u043E\u0441\u044C \u0440\u0430\u0441\u043F\u043E\u043B\u043E\u0436\u0435\u043D\u0438\u0435 \u043F\u043E\u043B\u0435\u0439 \u043D\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435. \u0417\u0434\u0435\u0441\u044C \u043E\u0442\u043E\u0431\u0440\u0430\u0436\u0430\u044E\u0442\u0441\u044F \u0442\u043E\u043B\u044C\u043A\u043E \u0442\u0435 \u043F\u043E\u043B\u044F, \u043A\u043E\u0442\u043E\u0440\u044B\u0435 \u0431\u044B\u043B\u0438 \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D\u044B \u0432\u0430\u043C\u0438 \u0432 \u0445\u043E\u0434\u0435 \u0440\u0430\u0431\u043E\u0442\u044B \u0441\n\u0441\u0438\u0441\u0442\u0435\u043C\u043E\u0439. \u0414\u043B\u044F \u0443\u0434\u043E\u0431\u0441\u0442\u0432\u0430 \u0432\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u043F\u0435\u0440\u0435\u043C\u0435\u0441\u0442\u0438\u0442\u044C \u044D\u0442\u0438 \u043F\u043E\u043B\u044F \u0432 \u043F\u0440\u043E\u0444\u0438\u043B\u044C \u0437\u0430\u043F\u0438\u0441\u0438 (\u0441\u043B\u0435\u0432\u0430) \u0438\u043B\u0438 \u0432 \u043E\u0431\u043B\u0430\u0441\u0442\u044C \u0432\u043A\u043B\u0430\u0434\u043E\u043A \u0441 \u043F\u043E\u043C\u043E\u0449\u044C\u044E \u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B.",
		HeaderTipDesignerBtnCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0441\u0435\u0439\u0447\u0430\u0441",
		HeaderTipNotShowBtnCaption: "\u0411\u043E\u043B\u044C\u0448\u0435 \u043D\u0435 \u043F\u043E\u043A\u0430\u0437\u044B\u0432\u0430\u0442\u044C \u044D\u0442\u043E \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		NewRecordPageCaptionSuffix: ": \u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		NotesAndFilesTabCaption: "\u0424\u0430\u0439\u043B\u044B \u0438 \u043F\u0440\u0438\u043C\u0435\u0447\u0430\u043D\u0438\u044F",
		NotesGroupCaption: "\u041F\u0440\u0438\u043C\u0435\u0447\u0430\u043D\u0438\u044F",
		OpenChangeLogMenuCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u0436\u0443\u0440\u043D\u0430\u043B \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u0439",
		OpenListSettingsCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0441\u043F\u0438\u0441\u043A\u0430",
		OpenNewSectionDesignerButtonCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u043D\u043E\u0432\u044B\u0439 \u0434\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		OpenSectionDesignerButtonCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u0434\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		PageContainsUnsavedChanges: "\u0423 \u0432\u0430\u0441 \u0435\u0441\u0442\u044C \u043D\u0435\u0441\u043E\u0445\u0440\u0430\u043D\u0435\u043D\u043D\u044B\u0435 \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u044F, \u043A\u043E\u0442\u043E\u0440\u044B\u0435 \u0431\u0443\u0434\u0443\u0442 \u0443\u0442\u0435\u0440\u044F\u043D\u044B. \u041F\u0440\u043E\u0434\u043E\u043B\u0436\u0438\u0442\u044C?",
		PageHeaderTemplate: "{0} / {1}",
		PrintButtonCaption: "\u041F\u0435\u0447\u0430\u0442\u044C",
		ProcessEntryPointButtonCaption: "\u041F\u0440\u043E\u0434\u043E\u043B\u0436\u0438\u0442\u044C \u043F\u043E \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0443",
		ProsessButtonCaption: "\u0417\u0430\u043F\u0443\u0441\u0442\u0438\u0442\u044C \u043F\u0440\u043E\u0446\u0435\u0441\u0441",
		QuickAddButtonHint: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u0443\u044E \u0430\u043A\u0442\u0438\u0432\u043D\u043E\u0441\u0442\u044C",
		RequiredFieldIsEmptyCaption: "\u0414\u043B\u044F \u0441\u043E\u0445\u0440\u0430\u043D\u0435\u043D\u0438\u044F \u0437\u0430\u043F\u0438\u0441\u0438, \u043D\u0435\u043E\u0431\u0445\u043E\u0434\u0438\u043C\u043E \u0437\u0430\u043F\u043E\u043B\u043D\u0438\u0442\u044C \u043E\u0431\u044F\u0437\u0430\u0442\u0435\u043B\u044C\u043D\u043E\u0435 \u043F\u043E\u043B\u0435 {0}",
		SaveButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SaveEditButtonHint: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "\u041F\u0440\u043E\u043A\u0440\u0443\u0442\u0438\u0442\u044C \u0432\u043B\u0435\u0432\u043E",
		TabControlScrollRightHint: "\u041F\u0440\u043E\u043A\u0440\u0443\u0442\u0438\u0442\u044C \u0432\u043F\u0440\u0430\u0432\u043E",
		TabVisaCaption: "\u0412\u0438\u0437\u044B",
		TagButtonHint: "\u0422\u0435\u0433\u0438",
		ViewOptionsButtonCaption: "\u0412\u0438\u0434"
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