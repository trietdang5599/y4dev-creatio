define("PushTemplateContentEditSchema", ["PushTemplateContentEditSchemaResources", "MacrosUtilities",
	"css!EmailTemplatePageV2V2Styles", "css!EmailMLangContentEditSchemaStyles", "css!DetailModule"
], function(resources) {
	return {
		mixins: {
			/**
			 * @class Terrasoft.MacrosUtilities
			 * Mixin for processing macroses.
			 */
			MacrosUtilities: "Terrasoft.MacrosUtilities"
		},
		attributes: {

			/**
			 * Notification title (stored in the Subject column).
			 */
			"Subject": {
				"dataValueType": this.Terrasoft.DataValueType.TEXT
			},

			/**
			 * Template body.
			 */
			"Body": {
				"dataValueType": this.Terrasoft.DataValueType.TEXT,
				"dependencies": [{
					"columns": ["Body"],
					"methodName": "bodyTemplateChanged"
				}]
			}
		},
		messages: {

			/**
			 * @message MacroSelected
			 * Handles macros selected event from macroses modalbox page.
			 */
			"MacroSelected": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MainContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["mlang-content-main-container"]
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ContentGridGroup",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ModuleEditCaption"
					},
					"items": [],
					"tools": [],
					"controlConfig": {
						"collapsed": false,
						"classes": ["detail"]
					}
				},
				"parentName": "MainContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ContentGridLayout",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "ContentGridGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Subject",
				"values": {
					"tag": "Subject",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					},
					"value": {
						"bindTo": "Subject"
					},
					"classes": {
						"labelClass": ["mlang-subject-label-class"]
					},
					"wrapClass": ["mlang-subject-label-wrap"],
					"caption": {
						"bindTo": "Resources.Strings.TitleCaption"
					},
					"change": {
						"bindTo": "onControlValueChanged"
					}
				},
				"parentName": "ContentGridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TemplateBodyContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24,
						"rowSpan": 1
					},
					"wrapClass": ["control-width-15 control-left"],
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"items": []
				},
				"parentName": "ContentGridLayout",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "TemplateBodyWrap",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-wrap"],
					"items": []
				},
				"parentName": "TemplateBodyContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Body",
				"values": {
					"tag": "Body",
					"bindTo": "Body",
					"contentType": this.Terrasoft.ContentType.RICH_TEXT,
					"generator": "InlineTextEditViewGenerator.generate",
					"labelConfig": {
						"visible": true
					},
					"selectedText": {
						"bindTo": "SelectedText"
					},
					"markerValue": "Body",
					"controlConfig": {
						"macrobuttonclicked": {
							"bindTo": "onOpenMacrosPage"
						},
						"hasFullScreen": true,
						"inlineTextControlConfig": {
							"ckeditorDefaultConfig": {
								"allowedContent": true,
								"removeButtons": "JustifyCenter,JustifyLeft,JustifyRight,Font,FontSize,Link" +
									",JustifyBlock,TextColor,bpmonlineemailtemplatelink,Indent,Outdent," +
									"bpmonlinesource,lineheight,letterspacing,lineheightpanel," +
									"letterspacingpanel,indentpanel,NumberedList,BulletedList,Bold,Italic,Underline"
							}
						}
					}
				},
				"parentName": "TemplateBodyWrap",
				"propertyName": "items"
			}
		],
		methods: {

			/**
			 * Handles changes on body property.
			 */
			bodyTemplateChanged: function() {
				this.onControlValueChanged(this.clearBodyFormatting(this.$Body), "Body");
			},

			/**
			 * Strips all HTML formatting added by the rich-text editor so the push notification
			 * body is stored as plain text. Line breaks are kept as newlines; macros ([#...#]) are preserved.
			 * @protected
			 * @param {String} value Body value.
			 * @return {String} Plain-text body value.
			 */
			clearBodyFormatting: function(value) {
				if (!value) {
					return value;
				}
				return value
					.replace(/<\s*br\s*\/?>/gi, "\n")
					.replace(/<\/\s*(?:p|div)\s*>/gi, "\n")
					.replace(/<[^>]+>/g, "")
					.replace(/&nbsp;/gi, " ")
					.replace(/&lt;/gi, "<")
					.replace(/&gt;/gi, ">")
					.replace(/&quot;/gi, "\"")
					.replace(/&#(\d+);/g, function(match, code) {
						return String.fromCharCode(parseInt(code, 10));
					})
					.replace(/&amp;/gi, "&")
					.replace(/\n{3,}/g, "\n\n")
					.replace(/^\s+|\s+$/g, "");
			},

			/**
			 * Opens selecting macroses.
			 * @param {String} macrosType Macros type ("macros" - system macros, "column" - object columns).
			 */
			onOpenMacrosPage: function(macrosType) {
				switch (macrosType) {
					case "macros":
						this.openMacrosPage();
						break;
					case "column":
						this.openMacrosColumnsPage();
						break;
					default:
						throw Ext.create("Terrasoft.UnsupportedTypeException " + macrosType);
				}
			},

			/**
			 * Opens entity structure explorer for the object selected on the card (macros source).
			 * @protected
			 */
			openMacrosColumnsPage: function() {
				var pageSandboxId = this.getPageSandboxId();
				var columnsValues = this.sandbox.publish("GetColumnsValues", ["Object"], [pageSandboxId]) || {};
				var object = columnsValues.Object;
				if (!object || !object.value) {
					this.showInformationDialog(this.get("Resources.Strings.EmptyObjectMessage"));
					return;
				}
				this.Terrasoft.EntitySchemaManager.findItemByUId(object.value, function(schema) {
					if (!schema) {
						return;
					}
					this.Terrasoft.StructureExplorerUtilities.open({
						scope: this,
						handlerMethod: this.onMacrosColumnSelected,
						moduleConfig: {
							useBackwards: false,
							schemaName: schema.name
						}
					});
				}, this);
			},

			/**
			 * Subscribes on events of sandbox.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				var macrosModuleId = this.getMacrosModuleId();
				this.sandbox.subscribe("MacroSelected", this.onGetMacros, this, [macrosModuleId]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseViewModule#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.subscribeSandboxEvents();
			},

			/**
			 * Processes the macros selection.
			 * @protected
			 * @param {String} macros Macros.
			 */
			onGetMacros: function(macros) {
				this.set("SelectedText", macros);
			}
		}
	};
});
