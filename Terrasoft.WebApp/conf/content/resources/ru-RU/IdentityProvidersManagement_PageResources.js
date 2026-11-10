define("IdentityProvidersManagement_PageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		GridDetailSearchFilter_qnkfcxl_placeholder: "Search",
		GridDetailImportDataBtn_0v8f2zs_caption: "Data import",
		GridDetailExportDataBtn_ekuwodt_caption: "Export to Excel",
		GridDetailSettingsBtn_ymjiu1r_caption: "Actions",
		GridDetailRefreshBtn_rqpozn7_caption: "Refresh",
		ExpansionPanel_6rwxxnz_title: "Services mapping",
		PageTitle_caption: "Identity providers management",
		Label_toitcmb_caption: "Use this list to assign an identity provider to each Creatio service or service group. When Creatio needs to reach an external system, it requests an access token from the mapped provider and uses it to authenticate",
		GridDetailSearchFilter_73otd7j_placeholder: "Search",
		GridDetailImportDataBtn_wpb5ohg_caption: "Data import",
		GridDetailExportDataBtn_sdgp61i_caption: "Export to Excel",
		GridDetailSettingsBtn_9urdxx1_caption: "Actions",
		GridDetailRefreshBtn_4hojsus_caption: "Refresh",
		GridDetailAddBtn_pfzpzfw_caption: "New",
		ExpansionPanel_v0knqpd_title: "Identity providers",
		Label_o6g2892_caption: "Use this list to create and manage identity provider connections. Each record stores the settings Creatio needs to request access tokens from a specific provider and reach external applications and services.",
		GridDetail_l6id9tzDS_IsSystemSetting: "System Setting",
		addRecord_2lsh9md_caption: "Add new",
		Label_rgb5td9_caption: "Specify the default identity provider to use when no provider is assigned in the Services mapping list below",
		DefaultIdentityProviderCode_placeholder: "Select default identity provider",
		addRecord_lq6vguz_caption: "Add new",
		Label_tni8gmr_caption: "Help",
		TabContainer_1ydvbaj_caption: "Help",
		Label_o9j546q_caption: "This section is where you set up and manage those connections. In Identity providers, you register each identity provider Creatio can request tokens from, storing the details it needs \u2014 base URL, client Id, and client secret. You can then choose one provider as the default for cases where no specific one is assigned.",
		Label_4mkm1f7_caption: "In Services mapping, you assign a provider to individual Creatio services or service groups, so each can authenticate through its own provider independently. When a service has no mapping of its own, Creatio uses the default provider instead.",
		Label_o1j1755_caption: "Some Creatio features need to connect to external applications and services to do their work \u2014 for example, to exchange data or call an external API. These services don\u0027t accept anonymous requests: before Creatio can reach them, it has to authenticate and obtain an access token that proves the request is authorized.",
		ExpansionPanel_2pz7pos_title: "Default identity provider",
		BackButton: "\u041D\u0430\u0437\u0430\u0434",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		GeneralInfoTab_caption: "\u041E\u0441\u043D\u043E\u0432\u043D\u0430\u044F \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		SetRecordRightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432"
	};
	var parametersLocalizableStrings = {
		TextParameter1: "Text 3",
		DefaultIdentityProviderCode: "Default identity provider",
		TextParameter3: "Text 2",
		TextParameter2: "Text 1"
	};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0441 \u0432\u043A\u043B\u0430\u0434\u043A\u0430\u043C\u0438 \u0438 \u043E\u0441\u0442\u0440\u043E\u0432\u043E\u043C \u0441\u0432\u0435\u0440\u0445\u0443"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});