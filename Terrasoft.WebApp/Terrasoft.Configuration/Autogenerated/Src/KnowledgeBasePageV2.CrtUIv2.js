define("KnowledgeBasePageV2", ["css!KnowledgeBasePageCSS"],
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
