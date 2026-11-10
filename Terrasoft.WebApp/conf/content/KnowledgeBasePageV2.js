Terrasoft.configuration.Structures["KnowledgeBasePageV2"] = {innerHierarchyStack: ["KnowledgeBasePageV2CrtUIv2", "KnowledgeBasePageV2Playbook", "KnowledgeBasePageV2"], structureParent: "BaseModulePageV2"};
define('KnowledgeBasePageV2CrtUIv2Structure', ['KnowledgeBasePageV2CrtUIv2Resources'], function(resources) {return {schemaUId:'9dbd0611-fa52-4a90-9542-e5fd997b4afd',schemaCaption: "Knowledge base edit page", parentSchemaName: "BaseModulePageV2", packageName: "CrtESN7x", schemaName:'KnowledgeBasePageV2CrtUIv2',parentSchemaUId:'d62293c0-7f14-44b1-b547-735fb40499cd',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('KnowledgeBasePageV2PlaybookStructure', ['KnowledgeBasePageV2PlaybookResources'], function(resources) {return {schemaUId:'cf66c61d-a570-48ac-944e-732a11b98502',schemaCaption: "Knowledge base edit page", parentSchemaName: "KnowledgeBasePageV2CrtUIv2", packageName: "CrtESN7x", schemaName:'KnowledgeBasePageV2Playbook',parentSchemaUId:'9dbd0611-fa52-4a90-9542-e5fd997b4afd',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"KnowledgeBasePageV2CrtUIv2",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('KnowledgeBasePageV2Structure', ['KnowledgeBasePageV2Resources'], function(resources) {return {schemaUId:'7a31f1c5-8794-48b2-9c67-85a0ccc326b7',schemaCaption: "Knowledge base edit page", parentSchemaName: "KnowledgeBasePageV2Playbook", packageName: "CrtESN7x", schemaName:'KnowledgeBasePageV2',parentSchemaUId:'cf66c61d-a570-48ac-944e-732a11b98502',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"KnowledgeBasePageV2Playbook",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('KnowledgeBasePageV2CrtUIv2Resources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("KnowledgeBasePageV2CrtUIv2", ["css!KnowledgeBasePageCSS"],
	function() {
		return {
			entitySchemaName: "KnowledgeBase",
			attributes: {
				"HtmlEditModeEnabled": {
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": true
				}
			},
			messages: {
				/**
				 * @message GetRecordInfo
				 * ######## ###### # ###### #####
				 */
				"GetRecordInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			details: /**SCHEMA_DETAILS*/{
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "KnowledgeBaseFile",
					filter: {
						masterColumn: "Id",
						detailColumn: "KnowledgeBase"
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * ############## ########## ########.
				 * @overridden
				 */
				init: function() {
					this.set("HtmlEditModeEnabled", this.getIsFeatureEnabled("Playbook"));
					this.initializeHtmlEditor();
					this.callParent(arguments);
				},

				/**
				 * #####, ############# ##### ############# #######
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.InitializeLike();
					this.callParent(arguments);
				},

				/**
				 * ######### ######### ############# ####### ### HtmlEditor.
				 * @private
				 */
				initializeHtmlEditor: function() {
					this.set("knowBaseImagesCollection", Ext.create("Terrasoft.BaseViewModelCollection"));
					this.set("plainTextMode", false);
				},

				/**
				 * ##### Helper ### ######## ######.
				 * @private
				 */
				pushLikeItCountSelect: function(batch) {
					var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "Like"
					});
					select.addAggregationSchemaColumn("LikeIt", this.Terrasoft.AggregationType.SUM, "LikeItSUM");
					select.filters.addItem(select.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"KnowledgeBase", this.get("Id")));
					var callback = function(response) {
						var likeItSUM = "";
						var responseCollection = response.collection;
						if (response.success && !responseCollection.isEmpty()) {
							var result = responseCollection.getByIndex(0);
							likeItSUM = result.get("LikeItSUM");
						}
						this.set("LikeItSUM", likeItSUM);
					};
					batch.add(select, callback, this);
				},

				/**
				 * ######## ############# LikeIt.
				 * @private
				 */
				InitializeLike: function() {
					var batch = this.Ext.create("Terrasoft.BatchQuery");
					this.pushLikeItCountSelect(batch);
					this.pushLikeItSelect(batch);
					batch.execute(null, this);
				},

				/**
				 * ######## ####### ############ # htmlEditor.
				 * @private
				 */
				insertImagesToKnowledgeBase: function(files) {
					Terrasoft.each(files, function(file) {
						this.readAsDataURL(file, function(image) {
							var imagesCollection = this.get("knowBaseImagesCollection");
							if (imagesCollection) {
								imagesCollection.add(imagesCollection.getUniqueKey(), image);
							}
						}, this);
					}, this);
				},

				/**
				 * ######## ########### ### ###### LikeIt LikeItIcon #### NoLikeItIcon.
				 * @private
				 */
				getLikeImageConfig: function() {
					return this.get("likeSet")
						? this.get("Resources.Images.LikeItIcon")
						: this.get("Resources.Images.NoLikeItIcon");
				},

				/**
				 * ############# ###########  ### ###### LikeIt LikeItIcon #### NoLikeItIcon.
				 * @private
				 */
				setLikeItImage: function(response) {
					if (!this.isInstance || !response.success) {
						return;
					}
					var result = (response.success && !response.collection.isEmpty() || response.rowsAffected > 0);
					this.set("likeSet", result);
				},

				/**
				 * ######## ###### # #### ######, ####### Like.
				 * @private
				 */
				pushLikeItSelect: function(batch) {
					var recordId = this.get("Id");
					var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "Like"
					});
					select.addColumn("Contact");
					select.addColumn("KnowledgeBase");
					select.filters.addItem(select.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Contact",
						this.Terrasoft.SysValue.CURRENT_USER_CONTACT.value));
					select.filters.addItem(select.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "KnowledgeBase", recordId));
					batch.add(select, this.setLikeItImage, this);
				},

				/**
				 * ######### ####### likeIt.
				 * @private
				 */
				insertLikeIt: function() {
					var insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "Like"
					});
					insert.setParameterValue("KnowledgeBase", this.get("Id"), this.Terrasoft.DataValueType.GUID);
					insert.setParameterValue("Contact", this.Terrasoft.SysValue.CURRENT_USER_CONTACT.value,
						this.Terrasoft.DataValueType.GUID);
					insert.setParameterValue("LikeIt", 1, this.Terrasoft.DataValueType.INTEGER);
					insert.execute(this.InitializeLike, this);
				},

				/**
				 * ############# LikeIT/DislikeIt.
				 * @private
				 */
				setLikeIt: function() {
					var likeSet = this.get("likeSet");
					this.set("likeSet", !likeSet);
					var deleteQuery = this.Ext.create("Terrasoft.DeleteQuery", {
						rootSchemaName: "Like"
					});
					deleteQuery.filters.add("IdFilter", deleteQuery.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "KnowledgeBase", this.get("Id")));
					deleteQuery.filters.add("userFilter", deleteQuery.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Contact",
						this.Terrasoft.SysValue.CURRENT_USER_CONTACT.value));
					if (!likeSet) {
						deleteQuery.execute(this.insertLikeIt, this);
					} else {
						deleteQuery.execute(this.InitializeLike, this);
					}
				},

				/**
				 * ############### #### # ######### ###### #### ##### ######## ## #######.
				 * @protected
				 * @overridden
				 */
				initTags: function() {
					this.tagSchemaName = this.entitySchemaName + "TagV2";
					this.inTagSchemaName = this.entitySchemaName + "InTagV2";
					this.callParent(arguments);
				},
				
				/**
				 * Initialize containers visibility.
				 * @protected
				 * @overridden
				 */
				initContainersVisibility: function() {
					this.callParent(arguments);
					this.getIsFeatureEnabled("OldUI") || this.set("IsActionDashboardContainerVisible", false);
				},
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "FilesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.FilesTabCaption"},
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"caption": {"bindTo": "Resources.Strings.NameCaption"}
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Type",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"contentType": Terrasoft.ContentType.ENUM,
						"caption": {"bindTo": "Resources.Strings.TypeCaption"}
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ModifiedBy",
					"values": {
						"layout": {"column": 0, "row": 2},
						"controlConfig": {"enabled": false}
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ModifiedOn",
					"values": {
						"layout": {"column": 12, "row": 2},
						"controlConfig": {"enabled": false}
					}
				}, {
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "KnowledgeBasePageGeneralBlock",
					"index": 0,
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"classes": {"wrapClassName": ["knowledge-base-general-block"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "KnowledgeBasePageGeneralBlock",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": Terrasoft.ContentType.RICH_TEXT,
						"fitContent": true,
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToKnowledgeBase"
							},
							"plainTextValue": {
								"bindTo": "NotHtmlNote"
							},
							"htmlEditEnabled": {
								"bindTo": "HtmlEditModeEnabled"
							},
							"images": {
								"bindTo": "knowBaseImagesCollection"
							},
							"plainTextMode": {
								"bindTo": "plainTextMode"
							}
						}
					}
				}, {
					"operation": "insert",
					"parentName": "KnowledgeBasePageGeneralBlock",
					"propertyName": "items",
					"name": "LikeContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"layout": {"column": 0, "row": 1, "colSpan": 4},
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "LikeContainer",
					"propertyName": "items",
					"name": "Like",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getLikeImageConfig"},
						"caption": {
							"bindTo": "LikeItSUM"
						},
						"click": {"bindTo": "setLikeIt"},
						"visible": {
							"bindTo": "isEditMode"
						},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
					}
				}, {
					"operation": "insert",
					"parentName": "FilesTab",
					"propertyName": "items",
					"name": "Files",
					"values": {
						"itemType": Terrasoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});

define('KnowledgeBasePageV2PlaybookResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("KnowledgeBasePageV2Playbook", [], function() {
	return {
		details: /**SCHEMA_DETAILS*/{
			"PlaybookDetail": {
				"schemaName": "PlaybookDetail",
				"entitySchemaName": "Playbook",
				"filter": {
					"detailColumn": "KnowledgeBase",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
		attributes: {
			"PlaybookTabName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: "PlaybookTab"
			},
			"PlaybookEnabled": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: Terrasoft.Features.getIsEnabled("Playbook")
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		methods: {

			/**
			 * @inheritDoc BasePageV2#initTabs
			 * @overridden
			 */
			initTabs: function() {
				this.setPlaybookTabVisibility();
				this.callParent(arguments);
			},

			/**
			 * Set playbook tab visibility.
			 * @private
			 */
			setPlaybookTabVisibility: function() {
				if (this.get("PlaybookEnabled")) {
					return;
				}
				const tabs = this.get("TabsCollection");
				const playbookTab = tabs.find(this.$PlaybookTabName);
				this.changeActiveTabWhenPlaybookInsivible()
				tabs.remove(playbookTab);
			},

			/**
			 * If Active tab is "Playbook"
			 * then set default tab to active.
			 * @private
			 */
			changeActiveTabWhenPlaybookInsivible: function() {
				if (this.$ActiveTabName === this.$PlaybookTabName) {
					this.setActiveTab("GeneralInfoTab");
				}
			},
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"order": 0
				}
			},
			{
				"operation": "insert",
				"name": "PlaybookTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.PlaybookTabCaption"
					},
					"items": [],
					"order": 1,
					
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "PlaybookDetail",
				"values": {
					"itemType": 2,
					"markerValue": "playbook-detail",
					"visible": {"bindTo": "PlaybookEnabled"}
				},
				"parentName": "PlaybookTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "FilesTab",
				"values": {
					"order": 2
				}
			}
		]/**SCHEMA_DIFF*/
	};
});

define("KnowledgeBasePageV2", [],
		function() {
			return {
				entitySchemaName: "KnowledgeBase",
				messages: {},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				methods: {
					/**
					 * ############## ######### ######## ###### ### Tabs.
					 * @overridden
					 */
					initTabs: function() {
						this.setActiveTab("GeneralInfoTab");
						this.callParent(arguments);
						var tabsCollection = this.get("TabsCollection");
						if (tabsCollection.contains("ESNTab")) {
							tabsCollection.removeByKey("ESNTab");
						}
					},
					/**
					 * @overridden
					 * @inheritdoc BasePageV2#getDefaultTabName
					 */
					getDefaultTabName: function() {
						var defaultTabName = this.callParent(arguments);
						if (defaultTabName === "ESNTab") {
							defaultTabName = "GeneralInfoTab";
						}
						return defaultTabName;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "move",
						"parentName": "GeneralInfoTab",
						"name": "ESNFeedContainer",
						"propertyName": "items",
						"values": {
							"itemType": Terrasoft.ViewItemType.CONTAINER,
							"items": []
						}
					}, {
						"operation": "move",
						"parentName": "ESNFeedContainer",
						"propertyName": "items",
						"name": "ESNFeed",
						"values": {
							"itemType": Terrasoft.ViewItemType.MODULE,
							"afterrender": { "bindTo": "loadESNFeed" },
							"afterrerender": { "bindTo": "loadESNFeed" }
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});


