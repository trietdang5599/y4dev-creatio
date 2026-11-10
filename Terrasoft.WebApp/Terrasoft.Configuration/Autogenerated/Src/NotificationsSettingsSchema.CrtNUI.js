define("NotificationsSettingsSchema", ["DesktopPopupNotification"],
	function(DesktopPopupNotification) {
		return {
			entitySchemaName: "NotificationsSettings",
			attributes: {
				/**
				 * State of popups.
				 * @type {Boolean}
				 */
				"PopupsStateFlag": {
					name: "PopupsStateFlag",
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			mixins: {
				CustomEvent: "Terrasoft.mixins.CustomEventDomMixin"
			},

			methods: {
				/**
				 * @inheritDoc Terrasoft.BaseViewModel#init
				 * @overridden
				 */
				init: function() {
					this.initPopupsState();
					this.initHeader();
					if (Terrasoft.isAngularHost) {
						this.mixins.CustomEvent.init.call(this);
					}
					this.callParent(arguments);
				},

				/**
				 * Initialize header of page.
				 */
				initHeader: function() {
					var headerCaption = this.get("Resources.Strings.PageTitle");
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: headerCaption,
						dataViews: new this.Terrasoft.Collection()
					});
					this.sandbox.subscribe("NeedHeaderCaption", function() {
						this.sandbox.publish("InitDataViews", {caption: headerCaption});
					}, this);
				},

				/**
				 * Save all notifications settings.
				 */
				saveSettings: function() {
					this.savePopupsState();
				},

				/**
				 * Discards changes.
				 */
				cancelChanges: function() {
					this.goBack();
				},

				/**
				 * Returns to previous state of history.
				 * @private
				 */
				goBack: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * Save state of popups.
				 * @private
				 */
				savePopupsState: function() {
					if (DesktopPopupNotification.getPermissionLevel() !== DesktopPopupNotification.PermissionType.GRANTED) {
						DesktopPopupNotification.requestPermission(this.setPopupsState, this);
					} else {
						this.setPopupsState();
					}
				},

				/**
				 * Sets state of popups.
				 * @private
				 */
				setPopupsState: function() {
					var state = this.get("PopupsStateFlag");
					let callback = this.goBack.bind(this);
					if(Terrasoft.isAngularHost) {
						callback = () => {
							this.mixins.CustomEvent.publish.call(this, 'UserDesktopNotificationSettingsChanged', state);
							this.goBack.call(this);
						}
					}
					DesktopPopupNotification.setNotificationsState(state, callback);
				},

				/**
				 * Initialize state of popups.
				 * @private
				 */
				initPopupsState: function() {
					DesktopPopupNotification.getNotificationsState(function(enabled) {
						this.set("PopupsStateFlag", enabled);
					}, this);
				}
			},
			diff: [{
				"operation": "insert",
				"name": "NotificationsSettingsContainer",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "topSettings",
				"parentName": "NotificationsSettingsContainer",
				"propertyName": "items",
				"values": {
					"id": "topSettings",
					"selectors": {"wrapEl": "#topSettings"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["top-settings-container"],
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "SaveButton",
				"parentName": "topSettings",
				"propertyName": "items",
				"values": {
					"id": "SaveButton",
					"markerValue": "SaveButton",
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"click": {"bindTo": "saveSettings"},
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"selectors": {"wrapEl": "#rightPanelCloseButton"},
					"style": this.Terrasoft.controls.ButtonEnums.style.GREEN,
					"tag": "save"
				}
			}, {
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "topSettings",
				"propertyName": "items",
				"values": {
					"id": "CancelButton",
					"markerValue": "CancelButton",
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"click": {"bindTo": "cancelChanges"},
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {"textClass": ["cancel-button"]},
					"selectors": {"wrapEl": "#rightPanelCloseButton"},
					"style": this.Terrasoft.controls.ButtonEnums.style.DEFAULT,
					"tag": "cancel"
				}
			}, {
				"operation": "insert",
				"name": "PopupsStateCheckBoxContainer",
				"parentName": "NotificationsSettingsContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["check-box-container", "stateflag-container"],
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "PopupsStateCheckBoxContainer",
				"propertyName": "items",
				"name": "PopupsStateCheckBox",
				"classes": ["t-checkboxedit"],
				"wrapClass": ["t-checkboxedit"],
				"values": {
					"bindTo": "PopupsStateFlag",
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.PopupsState"}
					}
				}
			}]
		};
	});