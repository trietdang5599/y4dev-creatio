define("SystemNotificationsSchema", ["PrintReportUtilitiesResources"],
		function(printUtilitiesResources) {
			return {
				entitySchemaName: "Reminding",
				attributes: {
					/**
					 * @private
					 */
					"NotificationConfig": {
						"dataValueType": this.Terrasoft.DataValueType.CUSTOM_OBJECT,
						"value": null
					}
				},
				methods: {
					
					/**
					 * @inheritdoc Terrasoft.BaseNotificationsSchema#getNotificationLinkAttributes
					 * @overridden
					 */
					getNotificationLinkAttributes: function() {
						if (this.isSuccessReportNotification()) {
							return { activelink: true };
						}
						return this.callParent(arguments);
					},
					
					/**
					 * @inheritdoc Terrasoft.BaseNotificationsSchema#onNotificationSubjectClick
					 * @overridden
					 */
					onNotificationSubjectClick: function () {
						if (this.isSuccessReportNotification()) {
							const config = this.getNotificationConfig();
							const href = Ext.String.format("../rest/{0}/{1}/{2}",
									config.serviceName,
									config.methodName,
									config.taskId);
							Terrasoft.download(href, config.reportName);
							return;
						}
						this.callParent(arguments);
					},
					
					/**
					 * @inheritdoc Terrasoft.BaseNotificationsSchema#getNotificationSubjectCaption
					 * @overridden
					 */
					getNotificationSubjectCaption: function() {
						if (this.isReportNotification()) {
							return this.isSuccessReportNotification()
									? this.get("Resources.Strings.ReportNotificationSubject")
									: Ext.String.format(printUtilitiesResources
													.localizableStrings.AsynGenerationErrorPopupBodyTpl,
											this.getNotificationConfig().reportName);
						}
						return this.callParent(arguments);
					},
					
					/**
					 * @inheritdoc Terrasoft.BaseNotificationsSchema#getNotificationEntity
					 * @overridden
					 */
					getNotificationEntity: function() {
						if (this.isReportNotification()) {
							return this.isSuccessReportNotification()
									? Ext.String.format(this.get("Resources.Strings.ReportNotificationHeaderTpl"),
											this.getNotificationConfig().reportName)
									: Terrasoft.emptyString;
						}
						return this.callParent(arguments);
					},
					
					/**
					 * Returns true if report notification.
					 * @protected
					 * @returns {Boolean} True if report notification.
					 */
					isReportNotification: function() {
						return this.get("SchemaName") === "SysModuleReport";
					},
					
					/**
					 * Returns true if success report generation notification.
					 * @protected
					 * @returns {Boolean} True if success report generation notification.
					 */
					isSuccessReportNotification: function() {
						return this.isReportNotification() && this.getNotificationConfig().success;
					},
					
					/**
					 * Returns notification config.
					 * @protected
					 * @returns {String|Object} Notification config.
					 */
					getNotificationConfig: function() {
						if (this.$NotificationConfig) {
							return this.$NotificationConfig;
						}
						const config = this.get("Config");
						try {
							this.$NotificationConfig = JSON.parse(config);
						} catch (e) {
							this.$NotificationConfig = config || {};
						}
						return this.$NotificationConfig;
					},
					
					
					/**
					 * @inheritdoc Terrasoft.BaseNotificationsSchema#addColumns
					 * @overridden
					 */
					addColumns: function(select) {
						this.callParent(arguments);
						select.addColumn("Config");
					}
				},
				diff: []
			};
		});
