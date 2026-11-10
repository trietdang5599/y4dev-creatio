define("SysQueryRuleApplyLogSection", ["ConfigurationEnums", "SysQueryRuleApplyLogSectionResources", "ConfigurationGrid", "ConfigurationGridGenerator",
    "ConfigurationGridUtilities" ],
function(ConfigurationEnums, Resources) {
    return {
        entitySchemaName: "SysQueryRuleApplyLog",
        attributes: {
			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#UseSeparatedPageHeader
			 * @overridden
			 */
			"UseSeparatedPageHeader": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#UseSectionHeaderCaption
			 * @overridden
			 */
			"UseSectionHeaderCaption": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			}
		},
        diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "SeparateModeActionsButton"
			},
			{
				"operation": "insert",
				"index": 0,
				"name": "SeparateModeCloseButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.GREY,
					"caption": Resources.localizableStrings.CloseButtonCaption,
					"click": {"bindTo": "closeSection"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					}
				}
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowOpenAction", //Кнопка открытия записи
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowCopyAction", //Кнопка открытия записи
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowDeleteAction", //Кнопка открытия записи
				"values": {
					"visible": false
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowShowSqlText",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.GREY,
					"caption": Resources.localizableStrings.ShowSqlText,
					"tag": "showSqlText"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowShowStackTrace",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.GREY,
					"caption": Resources.localizableStrings.ShowStackTrace,
					"tag": "showStackTrace"
				}
			},
		]/**SCHEMA_DIFF*/,
        messages: {},
        methods: {
			getDefaultGridDataViewCaption: function() {
				return this.get("Resources.Strings.ActiveViewCaption");
			},
			onActiveRowAction: function(buttonTag, primaryColumnValue) {
				switch (buttonTag) {
					case "showSqlText":
						this.tryShowSqlText();
						break;
					case "showStackTrace":
						this.tryShowStackTrace();
						break;
					default:
						this.callParent(arguments);
						break;
				}
			},
			tryShowSqlText: function() {
				var selectedItems = this.getSelectedItems();
				var id = selectedItems[0];
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {rootSchemaName: "SysQueryRuleApplyLog"});
				esq.addColumn("SysQuerySqlText.SqlText");
				var filter = Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "Id", id, Terrasoft.DataValueType.GUID);
				esq.filters.add("filter", filter);
				esq.getEntityCollection(this.showSqlTextModalBox, this);
			},
			tryShowStackTrace: function() {
				var selectedItems = this.getSelectedItems();
				var id = selectedItems[0];
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {rootSchemaName: "SysQueryRuleApplyLog"});
				esq.addColumn("SysQueryStackTrace.StackTrace");
				var filter = Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "Id", id, Terrasoft.DataValueType.GUID);
				esq.filters.add("filter", filter);
				esq.getEntityCollection(this.showStackTraceModalBox, this);
			},
			showSqlTextModalBox: function(result) {
				if (result.success) {
					var sqlText = result.collection.collection.items[0].values['SysQuerySqlText.SqlText'];
					this.showModalBox(sqlText);
				}
			},
			showStackTraceModalBox: function(result) {
				if (result.success) {
					var stackTrace = result.collection.collection.items[0].values['SysQueryStackTrace.StackTrace'];
					this.showModalBox(stackTrace);
				}
			},
			showModalBox: function(text) {
				this.sandbox.loadModule("ModalBoxSchemaModule", {
					id: this.sandbox.id + "_SysQueryRuleApplyLogModalBox",
					instanceConfig: {
						moduleInfo: {
							schemaName: "SimpleSourceCodeEditPage",
							content: text
						},
						initialSize: {width: "80%", height: "80%"}
					}
				});
			},
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},
			closeSection: function() {
				var module = "LookupSection";
				this.sandbox.publish("PushHistoryState", {
					hash: this.Terrasoft.combinePath("SectionModuleV2", module)
				});
			},
			onGridLoaded: function() {
				this.reloadGridColumnsConfig(false);
			}
		}
    };
});