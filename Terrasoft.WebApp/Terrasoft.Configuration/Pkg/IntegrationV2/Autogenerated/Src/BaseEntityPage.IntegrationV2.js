define("BaseEntityPage", ["MeetingInvitationsMixin"], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		mixins: {
			"MeetingInvitationsMixin": "Terrasoft.MeetingInvitationsMixin"
		},
		properties: {

			/**
			 * Calendar listening columns.
			 * @type {Array}
			 */
			_calendarListenColumns: [
				"Title",
				"Location",
				"StartDate",
				"DueDate",
				"Priority",
				"Notes",
				"ShowInScheduler",
				"Contact"
			],

			/**
			 * Calendar listening initial columns values.
			 * @type {Object}
			 */
			_calendarListenColumnsValues: null
	
		},
		methods: {

			//region Methods: Private

			_isActivityChanged: function() {
				for (let property in this.changedValues) {
					if (this._calendarListenColumns.includes(property)){
						const oldColumnValue = (this._calendarListenColumnsValues || {})[property];
						const newColumnValue = this.get(property);
						if(oldColumnValue === newColumnValue
								|| (this.isEmpty(oldColumnValue) && this.isEmpty(newColumnValue))) {
							continue;
						} else {
							return true;
						}
					}
				}
				return  false;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseEntityPage#init
			 * @overridden
			 */
			init: function() {
				const entityInitializedPromise = this._getSubscribePromise("EntityInitialized");
				const onEntityInitialized = this.initListenColumnsValues.bind(this);
				Promise.all([entityInitializedPromise]).then(onEntityInitialized);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseEntityPage#getEntityInitializedSubscribers
			 * @overridden
			 */
			getEntityInitializedSubscribers: function() {
				if (this.entitySchemaName === "Activity") {
					this.$OldStartDate =  this.$StartDate;
				}
				return this.callParent(arguments);
			},

			/**
			 * Initialize calendar listening columns with values before saving.
			 */
			initListenColumnsValues: function() {
				if (this.entitySchemaName != "Activity") {
					return;
				}
				if(this._calendarListenColumnsValues === null) {
					this._calendarListenColumnsValues = {};
					this.Terrasoft.each(this._calendarListenColumns, function(columnName) {
						this._calendarListenColumnsValues[columnName] = this.get(columnName);
					}, this);
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc Terrasoft.BaseEntityPage#asyncValidate
			 * @overridden
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(result) {
					if (this.entitySchemaName === "Activity" && this._isActivityChanged()) {
						this.canUserChangeMeeting(this.$Id, function () {
							Ext.callback(callback, scope, [result]);
						}, function () {
							this.cancelSave();
							this.hideBodyMask();
						});
					} else {
						Ext.callback(callback, scope, [result]);
					}

				}, this]);
			},

			/**
			 * Cancel save user action.
			 */
			cancelSave: function() {
				this.onCardAction("onDiscardChangesClick");
			},

			/**
			 * @inheritdoc Terrasoft.BaseEntityPage#saveEntity
			 * @overridden
			 */
			saveEntity: function(callback, scope) {
				this.callParent([function(response) {
					Ext.callback(callback, scope || this, [response]);
					this.confirmInvitationsSending(this.$Id);
				}, scope || this]);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
