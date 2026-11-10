define("MainMenuResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SettingsButtonCatpion: "Settings",
		ProfileButtonCatpion: "Profile",
		ExitButtonCaption: "Exit",
		JournalProcessesButtonCatpion: "Process log",
		ConfigurationSettingsMenuCaption: "Advanced settings",
		WorkplaceSettingsMenuCaption: "Workplace setup",
		ExternalFormsSettingsMenuCaption: "Landing page setup",
		SysOperationAuditSectionMenuCaption: "Audit log",
		SectionDesignerMenuItemCaption: "Create new section",
		SysProcessLogSectionMenuCaption: "Process log"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SettingsIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "SettingsIcon",
				hash: "ccc404d136d73edb907a333daafd9184",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "ProfileIcon",
				hash: "e3f52eaeb5006161a315564d21985c4e",
				resourceItemExtension: ".png"
			}
		},
		Logo: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "Logo",
				hash: "b1e3109969481938f5eb3d283823c343",
				resourceItemExtension: ".png"
			}
		},
		ExitIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "ExitIcon",
				hash: "6578427df816ae8ca009f5286cdddd70",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});