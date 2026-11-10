define("LazyDuplicatesDetailViewConfig", ["BaseGridDetailV2Resources", "InformationButtonResources",
	"LazyDuplicatesDetailViewConfigResources",
	"DuplicatesDetailViewConfigV2", "css!LazyDuplicatesDetailViewConfig"],
		function(gridDetailResourses, informationButtonResources, resources) {
	Ext.define("Terrasoft.configuration.LazyDuplicatesDetailViewConfig", {
		extend: "Terrasoft.DuplicatesDetailViewConfig",
		alternateClassName: "Terrasoft.LazyDuplicatesDetailViewConfig",
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getGridContainerItems: function(instanceId, listedConfig) {
			const baseItems = this.callParent(arguments);
			baseItems.push(this.getLoadMoreButtonViewConfig(instanceId));
			return baseItems;
		},
		
		/**
		 * Returns load more button view config.
		 * @protected
		 * @param {String} instanceId Duplicate detail instance id.
		 * @returns {Object} Load more button view config.
		 */
		getLoadMoreButtonViewConfig: function (instanceId) {
			return {
				"name": instanceId + "LoadMoreButton",
				"itemType": Terrasoft.ViewItemType.BUTTON,
				"controlConfig": {
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": gridDetailResourses.localizableImages.LoadMoreIcon
				},
				"caption": gridDetailResourses.localizableStrings.LoadMoreButtonCaption,
				"enabled": {
					"bindTo": "IsGridLoading",
					"bindConfig": {
						"converter": "invertBooleanValue"
					}
				},
				"visible": {
					"bindTo": "IsAllGroupLoaded",
					"bindConfig": {
						"converter": "invertBooleanValue"
					}
				},
				"click": {"bindTo": "onLoadMoreButtonClick"},
				"markerValue": "LoadMoreButton",
				"classes": { "wrapperClass": ["load-more-btn"] }
			};
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getHeaderContainerItems: function(instanceId) {
			const items = this.callParent(arguments);
			items.push(this.getMaxDuplicatesInformatioButtonViewConfig(instanceId));
			return items;
		},
		
		/**
		 * Returns maximum duplicates count per group exceeded information button configuration.
		 * @protected
		 * @param {String} instanceId Duplicate detail instance id.
		 * @returns {Object} Information button view config.
		 */
		getMaxDuplicatesInformatioButtonViewConfig: function(instanceId) {
			return {
				"name": instanceId + "CountContainer",
				"itemType": Terrasoft.ViewItemType.CONTAINER,
				"classes": {wrapClassName: ["left-container-wrapClass"]},
				"items": [
					{
						"name": instanceId + "InformationCountLabel",
						"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"style": Terrasoft.TipStyle.RED,
						"content": {
							"bindTo": "MaxDuplicatesPerRecord",
							"bindConfig": {
								"converter": function(value) {
									// TODO.
									return Ext.String.format(resources.localizableStrings.MaxDuplicatesPerRecordErrorMsqTpl, value);
								}
							}
						},
						"controlConfig": {
							"imageConfig": informationButtonResources.localizableImages.WarningIcon,
							"visible": {
								"bindTo": "TotalDuplicatesPerGroup",
								"bindConfig": {
									"converter": function(value) {
										return value >= this.$MaxDuplicatesPerRecord;
									}
								}
							}
						}
					}
				]
			};
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getSelectAllButtonViewConfig: function() {
			const selectAllButtonConfig = this.callParent(arguments);
			const buttonItem = selectAllButtonConfig.items[0];
			Ext.apply(buttonItem, {
				"enabled": {
					"bindTo": "IsAllGroupLoaded"
				},
				"hint": resources.localizableStrings.LoadAllGroupHintText,
				"domAttributes": {
					"bindTo": "IsAllGroupLoaded",
					"bindConfig": {
						"converter": function(isAllGroupLoaded) {
							return { "select-all-group-enabled": isAllGroupLoaded };
						}
					}
				}
			});
			return selectAllButtonConfig;
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getHeaderCaptionViewConfig: function() {
			const headerCaptionViewConfig = this.callParent(arguments);
			const labelItem = headerCaptionViewConfig.items[0];
			Ext.apply(labelItem, {
				"classes": {
					"labelClass": ["t-label duplicates-header-label duplicates-header-caption"]
				}
			});
			return headerCaptionViewConfig;
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getDuplicatesDetailGridViewConfig: function() {
			const gridViewConfig = this.callParent(arguments);
			return Ext.apply(gridViewConfig, {
				"isLoading": {"bindTo": "IsGridLoading"}
			});
		}
	});
});
