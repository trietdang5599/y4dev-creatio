define("AIAgents_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		KnwSourcesTabContainer_caption: "Knowledge sources",
		KnwSourcesExpansionPanel_title: "Knowledge sources",
		KnwSourcesAddButton_caption: "New",
		KnwSourcesDS_UseCitations: "Citations",
		AccessRightsExpansionPanel_title: "Permissions to execute",
		AgentFileAddBtn_caption: "Upload",
		AgentFileListPlaceholder_caption: "Save an agent to be able to add its attachments.",
		AgentFileRefreshBtn_caption: "Refresh",
		AgentFilesExpansionPanel_title: "Attachments",
		AttachmentAddButtonCaption: "Upload",
		AttachmentRefreshButtonCaption: "Refresh",
		AttachmentsTabContainerCaption: "Attachments",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		Code_label: "Code",
		CreateNewAction_caption: "Create new",
		CreateNewSubSkills_caption: "Create new",
		DefaultHeaderCaption: "Page title",
		DeleteButton: "Delete",
		Description_placeholder: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		Description_tooltip: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		FeedTabContainerCaption: "Feed",
		GeneralInfoTab_caption: "General information",
		GridDetailAddActionBtn_caption: "New",
		GridDetailAddSubSkillsBtn_caption: "New",
		GridDetailRefreshSubSkillsBtn_caption: "Refresh",
		Label_Description_caption: "Description",
		Label_Prompt_caption: "Agent instructions",
		Label_Restrictions_caption: "Limitations and restrictions",
		Label_Role_caption: "Role",
		LlmModel_label: "Model",
		LlmModel_placeholder: "Default",
		LlmModel_tooltip: "Large language model that will be used during operation. If you don\u2019t select one, the system will use the default Creatio-hosted model.",
		NewRecord: "New record",
		Prompt_placeholder: "Define the main interaction rules, response style, and key working principles of the agent.",
		Prompt_tooltip: "Define the main interaction rules, response style, and key working principles of the agent.",
		Record: "Record",
		Restrictions_placeholder: "Specify behavioral limitations for the agent, such as restrictions on generating certain data or performing risky actions.",
		Restrictions_tooltip: "Specify behavioral limitations for the agent, such as restrictions on generating certain data or performing risky actions.",
		RoleDescription_placeholder: "Specify the role the agent plays in the system and the specific domain knowledge it has.",
		RoleDescription_tooltip: "Specify the role the agent plays in the system and the specific domain knowledge it has.",
		SaveButton: "Save",
		SchemaAccessRightBindingInstruction_caption: "When exporting a Creatio.ai agent, it is essential to manually configure access rights bindings within the package. Failure to do so will result in the skill being inaccessible to users after installation in a different environment. The agent developer is fully responsible for ensuring this configuration.",
		SchemaAccessRightPlaceholder_caption: "Save the agent to be able to edit its access rights.",
		SelectExistingProcessForAction_caption: "Select existing process",
		SelectExistingSubSkill_caption: "Select existing skill",
		SetRecordRightsButtonCaption: "Set up access rights",
		SubSkillsExpansionPanel_title: "Sub-agents",
		Title_placeholder: "Enter the agent\u0027s name",
		Title_tooltip: "The name of your AI agent. It will be displayed to users.",
		ToolsExpansionPanel_title: "AI tools"
	};
	var parametersLocalizableStrings = {
		AccessRightsValue: "AccessRightsValue"
	};
	var propertiesLocalizableStrings = {
		Caption: "Creatio.ai agent form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});