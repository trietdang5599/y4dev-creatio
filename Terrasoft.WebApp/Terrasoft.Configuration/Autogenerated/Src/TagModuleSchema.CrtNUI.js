define("TagModuleSchema", [
			"TagModuleSchemaResources", "ModalBox", "TagConstantsV2", "ViewUtilities", "LookupQuickAddMixin",
			"TagItemViewModel", "TagModuleSchemaHelper", "css!TagModuleSchemaStyles"
		],
		function(resources, ModalBox) {
			return {
				attributes: {
					/**
					 * ############# ###### #######, ####### ##########
					 */
					"RecordId": {
						"dataValueType": this.Terrasoft.DataValueType.GUID,
						"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				methods: {
					/**
					 * ############## ######### ######## ######.
					 * @protected
					 * @virtual
					 */
					init: function(callback, scope) {
						this.callParent([
							function() {
								Terrasoft.chain(
										this.loadExistingTags,
										function() {
											Ext.callback(callback, scope || this);
										},
										this
								);
							}, this
						]);
					},

					/**
					 * Loads existing tags for record.
					 * @overridden
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback context.
					 */
					loadExistingTags: function(callback, scope) {
						var recordId = this.get("RecordId");
						var entityInTagSchemaName = this.get("InTagSchemaName");
						if (!this.Ext.isEmpty(recordId) && !this.Ext.isEmpty(entityInTagSchemaName)) {
							var entityInTagItemsCollection = this.get("InTagList");
							var esq = this.getEntityInTagQuery(entityInTagSchemaName);
							var tagTypesFilter = this.getTagTypesFilter("Tag.");
							this.addPublicTagFilter(tagTypesFilter, "Tag.");
							var filterGroup = this.Ext.create("Terrasoft.FilterGroup");
							filterGroup.addItem(this.Terrasoft.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
									"Entity", recordId));
							filterGroup.addItem(tagTypesFilter);
							esq.filters.add(filterGroup);
							esq.getEntityCollection(function(result) {
								if (!result.success) {
									if (callback) {
										callback.call(scope || this);
									}
									return;
								}
								var viewModelCollection = result.collection;
								if (!viewModelCollection.isEmpty()) {
									viewModelCollection.each(function(item) {
										var itemId = item.get("Id");
										var newItem = this.getTagItem(item, this.get("RecordId"),
												this.get("InTagSchemaName"));
										this.subscribeModelEvents(newItem);
										entityInTagItemsCollection.add(itemId, newItem);
									}, this);
									ModalBox.updateSizeByContent();
								}
								Ext.callback(callback, scope || this);
							}, this);
						} else {
							Ext.callback(callback, scope || this);
						}
					},

					/**
					 * ######### ##### ### # ######.
					 * @protected
					 * @param {object} selectedTag ######### ###
					 */
					addNewTagInEntity: function(selectedTag) {
						var isAlreadyExists = this.isExistSameTag(selectedTag.displayValue, selectedTag.TagTypeId);
						if (!isAlreadyExists.isExistsInEntityInTagList) {
							var insertQuery = this.Ext.create("Terrasoft.InsertQuery", {
								rootSchemaName: this.get("InTagSchemaName")
							});
							var newGuid = this.Terrasoft.generateGUID();
							insertQuery.setParameterValue("Id", newGuid, this.Terrasoft.DataValueType.GUID);
							insertQuery.setParameterValue("Tag", selectedTag.value, this.Terrasoft.DataValueType.GUID);
							insertQuery.setParameterValue("Entity", this.get("RecordId"), this.Terrasoft.DataValueType.GUID);
							insertQuery.execute(function(response) {
								if(response.success) {
									var tagsCollection = this.get("InTagList");
									var newItem = this.getNewTagItem(newGuid, selectedTag, this.get("RecordId"),
									this.get("InTagSchemaName"));
									this.subscribeModelEvents(newItem);
									tagsCollection.add(newGuid, newItem);
									this.set("EntityTagValue", null);
									this.sandbox.publish("TagChanged", this.get("RecordId"), [this.sandbox.id]);
									ModalBox.updateSizeByContent();
								} else {
									Terrasoft.showMessage(response.errorInfo.message);
								}
							}, this);
						} else {
							this.set("EntityTagValue", null);
						}
					},

					/**
					 * ########## ####### ######## #### ## ######.
					 * @protected
					 * @param {Terrasoft.TagItemViewModel} model viewModel ####
					 */
					onDeleteEntityInTag: function(model) {
						this.unSubscribeModelEvents(model);
						var tagsCollection = this.get("InTagList");
						tagsCollection.remove(model);
						this.sandbox.publish("TagChanged", this.get("RecordId"), [this.sandbox.id]);
						ModalBox.updateSizeByContent();
					},

					/**
					 * ######## ## ####### ######## ####.
					 * @protected
					 * @param {Terrasoft.TagItemViewModel} model viewModel ####
					 */
					subscribeModelEvents: function(model) {
						model.on("entityInTagDeleted", this.onDeleteEntityInTag, this);
					},

					/**
					 * ####### ## ####### ######## ####.
					 * @protected
					 * @param {Terrasoft.TagItemViewModel} model viewModel ####
					 */
					unSubscribeModelEvents: function(model) {
						model.un("entityInTagDeleted", this.onDeleteEntityInTag, this);
					}
				}
			};
		});
