define("SectionActionsDashboard", ["SectionActionsDashboardResources", "ConfigurationConstants",
			"NetworkUtilities", "SocialMessagePublisherModule"],
	function(resources, ConfigurationConstants, NetworkUtilities) {
		return {
			attributes: {},
			messages: {},
			methods: {

				/**
				 * @inheritdoc Terrasoft.ActionsDashboard#getExtendedConfig
				 * @overridden
				 */
				getExtendedConfig: function() {
					var config = this.callParent(arguments);
					var lczImages = resources.localizableImages;
					config.TaskMessageTab = {
						"ImageSrc": this.Terrasoft.ImageUrlBuilder.getUrl(lczImages.TaskMessageTabImage),
						"MarkerValue": "task-message-tab",
						"Align": this.Terrasoft.Align.RIGHT,
						"Tag": "Task"
					};
					return config;
				},

				/**
				 * @inheritdoc Terrasoft.BaseActionsDashboard#getAllowedTabs7x
				 * @override
				 */
				getAllowedTabs7x: function() {
					var result = this.callParent(arguments);
					result.push("TaskMessageTab");
					return result;
				},

				/**
				 * @inheritdoc Terrasoft.ActionsDashboard#onActiveTabChange
				 * @overridden
				 */
				onActiveTabChange: function(activeTab) {
					var messageType = activeTab.get("Name");
					if (messageType === "TaskMessageTab") {
						var operation = this.getMasterEntityParameterValue("Operation");
						var cardOperations = this.Terrasoft.ConfigurationEnums.CardOperation;
						if (operation === cardOperations.ADD || operation === cardOperations.COPY) {
							var config = {
								callback: this.openTask
							};
							this.saveMasterEntity(config, this);
						} else {
							this.openTask();
						}
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * Opens task card.
				 * @private
				 */
				openTask: function() {
					var task = this.getTaskEntityStructure();
					if (task && task.hasAddMiniPage) {
						this.openTaskMiniPage();
					} else {
						this.openTaskPage(task?.cardSchema);
					}
				},

				/**
				 * Opens task page with default values.
				 * @private
				 */
				openTaskPage: function(schemaName) {
					var defaultValues = this.getDefaultValues();
					var config = {
						"schemaName": schemaName ?? "ActivityPageV2",
						"operation": this.Terrasoft.ConfigurationEnums.CardOperation.ADD,
						"moduleId": this.sandbox.id + "ActivityPageV2",
						"renderTo": "centerPanel",
						"defaultValues": defaultValues
					}
					if (NetworkUtilities.tryNavigateTo8xMiniPage(config)) {
						return true;
					}
					this.openCardInChain(config);
				},

				/**
				 * Opens task MiniPage with default values.
				 * @private
				 */
				openTaskMiniPage: function() {
					var defaultValues = this.getDefaultValues();
					this.openMiniPage({
						"entitySchemaName": "Activity",
						"operation": this.Terrasoft.ConfigurationEnums.CardOperation.ADD,
						"valuePairs": defaultValues,
						"isFixed": true,
						"showDelay": 0
					});
				},

				/**
				 * Returns default values for the task page.
				 * @protected
				 * @return {Object} DefaultValues.
				 */
				getDefaultValues: function() {
					var defaultValues = [];
					var activityId = this.Terrasoft.generateGUID();
					defaultValues.push({
						name: "Id",
						value: activityId
					});
					var activityConfig = this.getDashboardItemsConfig("Activity");
					if (activityConfig && activityConfig.referenceColumnName) {
						defaultValues.push({
							name: activityConfig.referenceColumnName,
							value: this.getMasterEntityParameterValue("Id")
						});
					}
					var contact = this.getMasterEntityParameterValue("Contact");
					if (this.Ext.isObject(contact) && contact.value) {
						defaultValues.push({
							name: "Contact",
							value: contact.value
						});
					}
					var account = this.getMasterEntityParameterValue("Account");
					if (this.Ext.isObject(account) && account.value) {
						defaultValues.push({
							name: "Account",
							value: account.value
						});
					}
					var activityType = ConfigurationConstants.Activity.Type.Task;
					defaultValues.push({
						name: "Type",
						value: activityType
					});
					return defaultValues;
				},
				/**
				 * @inheritdoc Terrasoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @overridden
				 */
				getSectionPublishers: function() {
					var publishers = this.callParent(arguments);
					publishers.push("Task");
					return publishers;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "TaskMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
