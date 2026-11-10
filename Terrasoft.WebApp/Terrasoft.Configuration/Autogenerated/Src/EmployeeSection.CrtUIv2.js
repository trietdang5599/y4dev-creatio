define("EmployeeSection", ["css!EmployeeSectionCSS"], function() {
	return {
		entitySchemaName: "Employee",
		attributes: {

			/**
			 * If true shows only working employees. If false shows all employees.
			 */
			"IsActive": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#UseStaticFolders
			 * @overridden
			 */
			"UseStaticFolders": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#ContextHelpId
			 * @overridden
			 */
			"ContextHelpId": {
				"dataValueType": this.Terrasoft.DataValueType.INTEGER,
				"value": 1692
			},

			/**
			 * Primary image column name.
			 */
			"primaryImageColumnName": {
				"dataValueType": this.Terrasoft.DataValueType.TEXT,
				"value": "Contact.Photo"
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var sectionFilters = this.callParent(arguments);
				this.setIsActiveFilter(sectionFilters);
				return sectionFilters;
			},

			/**
			 * Adds or removes IsActiveFilter to filter collection.
			 * @protected
			 * @param {Terrasoft.Collection} filterCollection Filter collection.
			 */
			setIsActiveFilter: function(filterCollection) {
				var isActive = this.get("IsActive");
				if (isActive) {
					if (!filterCollection.contains("IsActiveFilter")) {
						filterCollection.add("IsActiveFilter", this.Terrasoft.createColumnIsNullFilter("CareerDueDate"));
					}
				} else {
					filterCollection.removeByKey("IsActiveFilter");
				}
			},

			/**
			 * Handles IsActiveCheckbox checked.
			 * @param {Boolean} value True if checked.
			 */
			onIsActiveCheckboxChecked: function(value) {
				if (!this.get("IsSectionVisible")) {
					return;
				}
				this.set("IsActive", value);
				this.sandbox.publish("FiltersChanged", null, [this.sandbox.id]);
				this.reloadGridData();
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "IsActiveFiltersContainer",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["isActive-filter-container-wrapClass"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "IsActiveFiltersContainer",
				"propertyName": "items",
				"name": "IsActiveCheckbox",
				"values": {
					"bindTo": "IsActive",
					"caption": {
						"bindTo": "Resources.Strings.IsActiveCheckboxCaption"
					},
					"controlConfig": {
						"className": "Terrasoft.CheckBoxEdit",
						"checkedchanged": {
							"bindTo": "onIsActiveCheckboxChecked"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name":"DataGrid",
				"values": {
					"defaultImageColumnName" :"Contact.Photo"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
