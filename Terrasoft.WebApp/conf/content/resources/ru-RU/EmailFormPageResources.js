define("EmailFormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		TabContainer_2eqcl4q_caption: "\u041E\u0431\u0449\u0430\u044F \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F",
		SaveButton_caption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		CancelButton_caption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		GridDetailSearchFilter_90nxrnj_placeholder: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		GridDetailRefreshBtn_iu8up48_caption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		GridDetailAddBtn_bnf7kkh_caption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		ExpansionPanel_ogdvdph_title: "\u0424\u0430\u0439\u043B\u044B \u0438 \u0441\u0441\u044B\u043B\u043A\u0438",
		AttachmentsTabContainer_caption: "\u0424\u0430\u0439\u043B\u044B",
		Label_qh6twyb_caption: "\u0424\u0430\u0439\u043B\u044B",
		TabContainer_x9ufdpr_caption: "\u0424\u0430\u0439\u043B\u044B",
		ConnectionsTabContainer_caption: "\u0421\u0432\u044F\u0437\u0438",
		FeedTabContainer_caption: "\u041B\u0435\u043D\u0442\u0430",
		Label_2jzb4wj_caption: "\u041B\u0435\u043D\u0442\u0430",
		TabContainer_msxap8x_caption: "\u041B\u0435\u043D\u0442\u0430",
		Label_v9e0gvg_caption: "\u0421\u0432\u044F\u0437\u0438",
		TabContainer_4qky7oz_caption: "\u0421\u0432\u044F\u0437\u0438",
		addRecord_hi4kfnp_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_u2ih2ms_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_jxahw51_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		GridDetailSearchFilter_55p780w_placeholder: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		GridDetailImportDataBtn_vp5z3z6_caption: "\u0418\u043C\u043F\u043E\u0440\u0442 \u0434\u0430\u043D\u043D\u044B\u0445",
		GridDetailExportDataBtn_sdroz27_caption: "\u042D\u043A\u043F\u043E\u0440\u0442 \u0432 Excel",
		GridDetailSettingsBtn_gedpuqq_caption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		GridDetailRefreshBtn_xpb1hrb_caption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		GridDetailAddBtn_xfpniv9_caption: "\u041D\u043E\u0432\u044B\u0439",
		ExpansionPanel_kb90i8i_title: "\u041A\u043E\u043D\u0442\u0430\u043A\u0442\u044B \u0438\u0437 \u043F\u0435\u0440\u0435\u043F\u0438\u0441\u043A\u0438",
		GridDetail_jj11595DS_Role: "\u041D\u0430\u043F\u0440\u0430\u0432\u043B\u0435\u043D\u0438\u0435",
		GridDetail_jj11595DS_ParticipantJob: "\u0414\u043E\u043B\u0436\u043D\u043E\u0441\u0442\u044C",
		GridDetail_jj11595DS_ParticipantAccount: "\u041A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442",
		GridDetail_jj11595DS_Participant: "\u041A\u043E\u043D\u0442\u0430\u043A\u0442",
		ReplyButton_caption: "\u041E\u0442\u0432\u0435\u0442\u0438\u0442\u044C/\u041F\u0435\u0440\u0435\u0441\u043B\u0430\u0442\u044C",
		SummarizeButton_caption: "\u0420\u0435\u0437\u044E\u043C\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u043F\u0438\u0441\u044C\u043C\u043E",
		AttachmentAddButtonCaption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		AttachmentRefreshButtonCaption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		AttachmentsTabContainerCaption: "\u0424\u0430\u0439\u043B\u044B",
		BackButton: "\u041D\u0430\u0437\u0430\u0434",
		CancelButton: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CloseButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		FeedTabContainerCaption: "\u041B\u0435\u043D\u0442\u0430",
		GeneralInfoTab_caption: "\u0421\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		SaveButton: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SetRecordRightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 Email"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});