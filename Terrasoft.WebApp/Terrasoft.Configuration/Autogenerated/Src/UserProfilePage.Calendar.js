define("UserProfilePage", ["RightUtilities", "UserCalendarMixin"], function(RightUtilities) {
	return {
		attributes: {
			/**
			 * Sign of personal calendar feature.
			 * @type {Boolean}
			 */
			IsUserCalendarFeature: {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			/**
			 * Identifier of the personal calendar.
			 * @type {Guid}
			 */
			UserCalendarId: {
				dataValueType: this.Terrasoft.DataValueType.GUID,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Identifier of the default personal calendar.
			 * @type {Guid}
			 */
			BaseUserCalendarId: {
				dataValueType: this.Terrasoft.DataValueType.GUID,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Default personal calendar.
			 * @type {Object}
			 */
			LoadedBaseUserCalendar: {
				dataValueType: this.Terrasoft.DataValueType.ENTITY,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Sign of rights for administration.
			 * @type {Boolean}
			 */
			CanManageAdministration: {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			/**
			 * Sing of personal calendar feature.
			 * @type {Boolean}
			 */
			IsVisibleCalendarButton: {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},
		mixins: {
			UserCalendarMixin: "Terrasoft.UserCalendarMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.UserProfilePage#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.set("IsUserCalendarFeature", this.Terrasoft.Features.getIsEnabled("UserCalendar"));
				if (this.get("IsUserCalendarFeature")) {
					this.callParent([function() {
								this.initCalendar(callback, scope);
							}, this
					]);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Initialize calendar.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initCalendar: function(callback, scope) {
				this.Terrasoft.chain(
						this.checkRightOperation,
						this.initUserCalendar,
						this.setVisibleCalendarButton,
						function() {
							this.Ext.callback(callback, scope || this);
						}, this
				);
			},

			/**
			 * Checking administration rights.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			checkRightOperation: function(callback, scope) {
				RightUtilities.checkCanExecuteOperation({
					operation: this.getOperationRight()
				}, function(result) {
					this.set("CanManageCalendar", result);
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Returns operation right name.
			 * @protected
			 * @return {String} Operation name.
			 */
			getOperationRight: function() {
				return "CanManageAdministration";
			},

			/**
			 * Sets visible calendar button.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			setVisibleCalendarButton: function(callback, scope) {
				var canManaged = this.get("CanManageCalendar");
				var feature = this.get("IsUserCalendarFeature");
				this.set("IsVisibleCalendarButton", canManaged && feature);
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * @inheritdoc Terrasoft.UserProfilePage#initSysSettings
			 * @overridden
			 */
			initSysSettings: function() {
				this.initSysSettingBaseUserCalendar();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.UserCalendarMixin#initUserCalendarQueryFilters
			 * @overridden
			 */
			initUserCalendarQueryFilters: function(esq) {
				var filter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						"User",
						this.Terrasoft.SysValue.CURRENT_USER.value);
				esq.filters.addItem(filter);
			},

			/**
			 * @inheritdoc Terrasoft.UserCalendarMixin#setUserCalendarParameterValues
			 * @overridden
			 */
			setUserCalendarParameterValues: function(update) {
				update.setParameterValue("User",
						this.Terrasoft.SysValue.CURRENT_USER.value,
						this.Terrasoft.DataValueType.GUID);
				update.setParameterValue("Name",
						this.getUserCalendarName(),
						this.Terrasoft.DataValueType.TEXT);
			},

			/**
			 * @inheritdoc Terrasoft.UserCalendarMixin#getUserCalendarName
			 * @overridden
			 */
			getUserCalendarName: function() {
				var template = this.getUserCalendarNameTemplate();
				return this.Ext.String.format(template, this.Terrasoft.SysValue.CURRENT_USER.displayValue);
			},

			/**
			 * @inheritdoc Terrasoft.UserCalendarMixin#openCalendarCard
			 * @overridden
			 */
			openCalendarCard: function() {
				var recordId = this.getUserCalendarId();
				this.openCardInChain({
					schemaName: "CalendarPage",
					id: recordId,
					operation: this.Terrasoft.ConfigurationEnums.CardOperation.EDIT,
					renderTo: "centerPanel"
				});
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "CalendarContainer",
				"parentName": "leftTopGroupContainer",
				"propertyName": "items",
				"values": {
					"id": "CalendarContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["profile-module-left-container-bottom-border"],
					"visible": {"bindTo": "IsVisibleCalendarButton"},
					"items": []
				},
				"index": 7
			},
			{
				"operation": "insert",
				"name": "Calendar",
				"parentName": "CalendarContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CalendarCaption"},
					"click": {"bindTo": "onCalendarClick"},
					"classes": {"textClass": "profile-button"},
					"markerValue": "CalendarButton"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
