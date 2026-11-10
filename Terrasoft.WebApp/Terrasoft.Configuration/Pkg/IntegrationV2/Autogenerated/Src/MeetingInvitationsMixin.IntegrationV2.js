define("MeetingInvitationsMixin", ["terrasoft", "ServiceHelper", "TimezoneUtils", "MeetingInvitationsMixinResources"],
	function(Terrasoft, ServiceHelper, TimezoneUtils, Resources) {

		/**
		 * @class Terrasoft.configuration.mixins.MeetingInvitationsMixin
		 * The mixin can add signature to body.
		 */
		Ext.define("Terrasoft.configuration.mixins.MeetingInvitationsMixin", {
			alternateClassName: "Terrasoft.MeetingInvitationsMixin",

			//region Fields: Public

			/**
			 * Change meeting response enumerable.
			 * @returns {{Yes: 0, No: 1, YesWithNotification: 2, YesWithObsoleteNotification: 3}}
			 */
			changeMeetingResponseEnum: {
				"Yes": 0,
				"No": 1,
				"YesWithNotification": 2, 
				"YesWithObsoleteNotification": 3
			},

			/**
			 * User confirmation result of sending meeting invitations.
			 */
			userResultOfSendingInvitations: false,

			//endregion

			//region Methods: Private

			/**
			 * Sets meeting invitation info properties.
			 * @param {Object} data Meeting invitation info data.
			 * @private
			 */
			_setMeetingInvitationInfoProperties: function(data) {
				this.set("ParticipantsInvited", data.IsParticipantsInvited);
				this.set("MeetingExported", data.IsSynchronized);
				this.set("ParticipantsExist", data.IsParticipantsExist);
				this.set("InvitationButtonEnabled", data.HasCalendarIntegration);
				this.set("OutdatedMeeting", data.IsOutdatedMeeting);
				this.set("CalendarSyncSinceDate", data.CalendarSyncSinceDate);
			},

			/**
			 * Gets configs for calling the service with the ability to send invitations.
			 * @param {String} methodName Meeting service method name.
			 * @param {Object} data Meeting service input data.
			 * @param {Function} methodName Callback function.
			 * @return {Object} Send invitations service config.
			 * @private
			 */
			_getMeetingServiceConfig: function (methodName, data, callback) {
				return {
					"serviceName": "MeetingService",
					"methodName": methodName,
					"callback": callback,
					"scope": this,
					"data": data
				};
			},

			/**
			 * Show confirmation dialog.
			 * @param {String} message Confirmation dialog message.
			 * @param {Function} resolveCallback Resolve callback.
			 * @param {Function} rejectCallback Reject callback.
			 * @param {Array} buttons Array buttons.
			 * @private
			 */
			showConfirmationDialogInternal: function (message, resolveCallback, rejectCallback, buttons) {
				this.showConfirmationDialog(message, function(result) {
					if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
						Ext.callback(resolveCallback, this);
					} else if(result === Terrasoft.MessageBoxButtons.NO.returnCode
							|| Terrasoft.MessageBoxButtons.OK.returnCode){
						Ext.callback(rejectCallback, this);
					}
				}, buttons);
			},

			/**
			 * Process send invitations response.
			 * @param {Guid} meetingId Meeting unique identifier.
			 * @param {String} response Response string code.
			 * @param {Function} resolveCallback Resolve callback.
			 * @param {Function} rejectCallback Reject callback.
			 * @private
			 */
			canUserChangeMeetingCallback: function (meetingId, response, resolveCallback, rejectCallback) {
				let notificationMessage;
				switch (response) {
					case this.changeMeetingResponseEnum.Yes:
						return Ext.callback(resolveCallback, this);
					case this.changeMeetingResponseEnum.YesWithNotification:
						notificationMessage = notificationMessage
							|| this.get("Resources.Strings.CanUserChangeMeetingResolveMessage")
							|| Resources.localizableStrings.ResendMeetingInvitationsMessage;
					case this.changeMeetingResponseEnum.YesWithObsoleteNotification:
						const meetingServiceCallback = function(responseData, response) {
							if (response && responseData) {
								const syncSinceDate = new Date(responseData.CalendarSyncSinceDate);
								if (this.$StartDate >= syncSinceDate || this.$OldStartDate >= syncSinceDate) {
									notificationMessage = notificationMessage
										|| Resources.localizableStrings.ResendObsoleteMeetingInvitationsMessage;
									this.showConfirmationDialogInternal(notificationMessage,
										function() {
											this.userResultOfSendingInvitations = true;
											Ext.callback(resolveCallback, this);
										}, rejectCallback, [Terrasoft.MessageBoxButtons.YES, Terrasoft.MessageBoxButtons.NO]);
								} else {
									Ext.callback(resolveCallback, this);
								}
							}
						};
						const config = this._getMeetingServiceConfig("GetMeetingInvitationInfo", {
							"meetingId": meetingId
						}, meetingServiceCallback);
						ServiceHelper.callService(config)
						break;
					case this.changeMeetingResponseEnum.No:
						Terrasoft.showInformation(Resources.localizableStrings.CanNotChangeMeetingMessage)
						Ext.callback(rejectCallback, this);
						break;
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * Confirm user sending invitation action.
			 * @param {Guid} meetingId Meeting identifier.
			 */
			confirmInvitationsSending: function(meetingId) {
				if (this.entitySchema.name === "Activity" && this.userResultOfSendingInvitations) {
					this.sendInvitations(meetingId, Terrasoft.emptyFn, this);
				}
			},

			/**
			 * Check the user ability send invitations.
			 * @param {Guid} meetingId Meeting unique identifier.
			 * @param {Function} resolveCallback Resolve callback.
			 * @param {Function} rejectCallback Reject callback.
			 */
			canUserChangeMeeting: function(meetingId, resolveCallback, rejectCallback) {
				this.userResultOfSendingInvitations = false;
				if (Terrasoft.Features.getIsEnabled("MeetingInvitation")) {
					const meetingServiceCallback = function(response) {
						if (response >= 0) {
							this.canUserChangeMeetingCallback(meetingId, response, resolveCallback, rejectCallback);
						} else {
							Ext.callback(rejectCallback, this);
						}
					};
					const config = this._getMeetingServiceConfig("CanUserChangeMeeting", {
						"meetingId": meetingId
					}, meetingServiceCallback);
					return ServiceHelper.callService(config);
				} else {
					Ext.callback(resolveCallback, this);
				}
			},

			/**
			 * Get meeting delete confirmation message.
			 * @param {String} baseMessage Base message about deleting a record.
			 * @param {Array} items List of elements to remove.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getMeetingDeleteConfirmationMessage: function(baseMessage, items, callback, scope) {
				if (this.getIsFeatureEnabled("MeetingInvitation") && items && items.length) { 
					this.initMeetingsInvitationInfo(items, function() {
						let message = baseMessage;
						if (this.isInvitationsSent()) {
							message = items.length > 1
								? Resources.localizableStrings.MultiDeleteMeetingWithInvitationsConfirmationMessage
								: Resources.localizableStrings.DeleteMeetingWithInvitationsConfirmationMessage;
						}
						Ext.callback(callback, scope || this, [message]);
					}, this);
				} else {
					Ext.callback(callback, scope || this, [baseMessage]);
				}
			},

			/**
			 * Send invitations to activity participants.
			 * @param {Guid} meetingId Meeting unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			sendInvitations: function(meetingId, callback, scope) {
				Terrasoft.MaskHelper.ShowBodyMask();
				const sendInvitationsCallback = function(response) {
					Terrasoft.MaskHelper.HideBodyMask();
					if (!response) {
						return Terrasoft.showInformation(Resources.localizableStrings.ErrorSendingInvitationMessage);
					}
					if (response.success) {
						Terrasoft.showInformation(Resources.localizableStrings.SuccessSendingInvitationMessage);
						return Ext.callback(callback, scope || this);
					}
					if (response.errorInfo) {
						this.error(response.errorInfo.message);
					}
					Terrasoft.showInformation(Resources.localizableStrings.ErrorSendingInvitationMessage);
				};
				const config = this._getMeetingServiceConfig("SendInvitations", {
					"meetingId": meetingId
				}, sendInvitationsCallback);
				ServiceHelper.callService(config);
			},

			/**
			 * Initializing the meetings invitation properties.
			 * @param {Array} meetingIds Meeting unique identifiers.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initMeetingsInvitationInfo: function (meetingIds, callback, scope) {
				const meetingServiceCallback = function(responseData, response) {
					if (response && responseData) {
						this._setMeetingInvitationInfoProperties(responseData);
					}
					Ext.callback(callback, scope || this);
				};
				const config = this._getMeetingServiceConfig("GetMeetingsInvitationInfo", {
					"meetingIds": meetingIds
				}, meetingServiceCallback);
				ServiceHelper.callService(config)
			},

			/**
			 * Initializing the meeting invitation properties.
			 * @param {Guid} meetingId Meeting unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initMeetingInvitationInfo: function(meetingId, callback, scope) {
				const meetingServiceCallback = function(responseData, response) {
					if (response && responseData) {
						this._setMeetingInvitationInfoProperties(responseData);
					}
					Ext.callback(callback, scope || this);
				};
				const config = this._getMeetingServiceConfig("GetMeetingInvitationInfo", {
					"meetingId": meetingId
				}, meetingServiceCallback);
				ServiceHelper.callService(config)
			},

			/**
			 * Processing the meetings collection where current user contact is organizer.
	 		 * @param {Object} responseData Service response data with filtered meeting identifiers.
	 		 * @param {Object} response Server response.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			processCurrentContactOrganizerMeetingsInfo: function(responseData, response, callback, scope) {
				let needCallDeleteMethod = true;
				if (response && responseData) {
					const isMultiSelect = this.get("MultiSelect");
					if (isMultiSelect) {
						if (responseData.length === 0) {
							needCallDeleteMethod = false;
							this.showInformationDialog(Resources.localizableStrings.MultiDeleteMeetingWithInvitationsByNotOrganizerMessage);
						} else {
							const selectedRecordsConfig = this.getSelectedRecordsConfig();
							const meetingCount = selectedRecordsConfig.selectedItems.length;
							if (meetingCount > responseData.length) {
								this.set("IsNotOrganizerSelectedRows", true);
								this.set("SelectedRows", responseData);
							}
						}
					} else if (responseData.length === 0) {
						needCallDeleteMethod = false;
						this.showInformationDialog(Resources.localizableStrings.DeleteMeetingWithInvitationsByNotOrganizerMessage);
					}
				}
				Ext.callback(callback, scope || this, [needCallDeleteMethod]);
			},

			/**
			 * Initializing the meetings collection where current user contact is organizer.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initCurrentContactOrganizerMeetingsInfo: function (callback, scope) {
				this.set("IsNotOrganizerSelectedRows", false);
				const selectedRecordsConfig = this.getSelectedRecordsConfig();
				const meetingIds = selectedRecordsConfig.selectedItems;
				const params = {
					"meetingIds": meetingIds
				};
				if (selectedRecordsConfig.selectAllMode) {
					params.filtersConfig = selectedRecordsConfig.filtersConfig;
				}
				const config = this._getMeetingServiceConfig("GetCurrentContactOrganizerMeetingIds", params,
					function(responseData, response) {
						this.processCurrentContactOrganizerMeetingsInfo(responseData, response, callback, scope);
				});
				ServiceHelper.callService(config)
			},

			/**
			 * Shows message that deleting records contain meetings whome organizers are not current user contact and so can't be deleted.
			 * @param {Object} responseObject Response of service which try to delete metings.
			 * @private
			 */
			showOrganizerDeleteResultMessage: function(responseObject) {
				if (responseObject && responseObject.DeleteRecordsAsyncResult) {
					const result = this.Terrasoft.decode(responseObject.DeleteRecordsAsyncResult);
					const success = result.Success;
					if (success) {
						if (this.get("IsNotOrganizerSelectedRows")) {
							this.showInformationDialog(Resources.localizableStrings.MultiDeleteMeetingWithInvitationsByNotOrganizerMessage);
						}
					}
				}
			},

			/**
			 * Checking that meeting invitation was sent.
			 * @returns {Boolean} True, if meeting invitations was sent, otherwise false.
			 * @protected
			 */
			isInvitationsSent: function() {
				return this.get("MeetingExported") && this.get("ParticipantsInvited");
			}

			//endregion

		});
	});
