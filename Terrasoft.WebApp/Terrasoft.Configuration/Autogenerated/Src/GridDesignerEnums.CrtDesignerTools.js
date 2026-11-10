define("GridDesignerEnums", ["GridDesignerEnumsResources"], function() {

	Ext.ns("Terrasoft.GridDesignerEnums");

	/**
	 * Enumeration of list types.
	 * @enum
	 */
	Terrasoft.GridDesignerEnums.GridType = {
		Vertical: 0,
		Listed: 1,
		Tiled: 2,
		Mobile: 3
	};

	/**
	 * Default list settings that depend on the list type.
	 * @enum
	 */
	Terrasoft.GridDesignerEnums.DefaultGridSettings = {};
	Terrasoft.GridDesignerEnums.DefaultGridSettings[Terrasoft.GridDesignerEnums.GridType.Vertical] = {
		columns: 1,
		rows: 1
	};
	Terrasoft.GridDesignerEnums.DefaultGridSettings[Terrasoft.GridDesignerEnums.GridType.Listed] = {
		columns: 24,
		rows: 1
	};
	Terrasoft.GridDesignerEnums.DefaultGridSettings[Terrasoft.GridDesignerEnums.GridType.Tiled] = {
		columns: 24,
		rows: 1
	};
	Terrasoft.GridDesignerEnums.DefaultGridSettings[Terrasoft.GridDesignerEnums.GridType.Mobile] = {
		columns: 1,
		rows: 1
	};

});
