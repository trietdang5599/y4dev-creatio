Terrasoft.configuration.Structures["DuplicatesWidgetModule"] = {innerHierarchyStack: ["DuplicatesWidgetModule"]};

define("DuplicatesWidgetModule", ["DuplicatesWidget", "DuplicatesWidgetViewModel"], function() {
	Ext.define("Terrasoft.configuration.DuplicatesWidgetModule", {
		extend: "Terrasoft.configuration.BaseModule",
		alternateClassName: "Terrasoft.DuplicatesWidgetModule",
		Ext: null,
		sandbox: null,
		Terrasoft: null,
		view: null,
		model: null,
		renderToElement: null,

		messages: {
			/**
			 * @message GetDuplicatesWidgetConfig
			 * Returns duplicates widget config.
			 */
			"GetDuplicatesWidgetConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message RefreshDuplicatesWidget
			 * Refresh duplicates widget data.
			 */
			"RefreshDuplicatesWidget": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message PushHistoryState
			 * Notification that history state was modified.
			 */
			"PushHistoryState": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
		},
		
		//region Methods: Private

		/**
		 * Renders duplicates widget.
		 * @param {Object} renderTo Element to rendering.
		 * @private
		 */
		_renderDuplicatesWidget: function(renderTo) {
			if (!Terrasoft.Features.getIsEnabled("AlwaysDisplayDuplicatesWidget") && 
				(this._isLeftModulesContainerEmpty(renderTo) ||
				(!this._hasDuplicates(this.model.$Duplicates) || this.model.$IsLoading))) {
				return;
			}
			this.view = this.Ext.create("Terrasoft.DuplicatesWidget", {
				entitySchemaName: {"bindTo": "EntitySchemaName"},
				entityId: {"bindTo": "EntityId"},
				duplicates: {"bindTo": "Duplicates"},
				isLoading: {"bindTo": "IsLoading"},
				parentComponent: renderTo.id,
				widgetClick: {"bindTo": "onWidgetClick"}
			});
			this.view.bind(this.model);
			this.view.render(renderTo);
		},

		/**
		 * @private
		 */
		_updateConfig: function() {
			const config = this.sandbox.publish("GetDuplicatesWidgetConfig", null, [this.sandbox.id]) || {};
			if (!Terrasoft.Features.getIsEnabled("AlwaysDisplayDuplicatesWidget")) {
				if (config.isLoading || !this._hasDuplicates(config.duplicates)) {
					this.destroy();
					return;
				}
			}
			this.model.$EntitySchemaName = config.entitySchemaName;
			this.model.$EntityId = config.entityId;
			this.model.$Duplicates = config.duplicates;
			this.model.$IsLoading = config.isLoading;
			if (!this.view) {
				this._renderDuplicatesWidget(this.renderToElement);
			}
		},

		/**
		 * @private
		 */
		_hasDuplicates: function(duplicates) {
			return duplicates && duplicates.length > 0;
		},

		_isLeftModulesContainerEmpty: function(renderTo) {
			const leftModuleContainerChilds = this._getLeftModuleContainerChildren(renderTo);
			return (leftModuleContainerChilds.length <= 2 && !this._isProfileContainerHasChildren(leftModuleContainerChilds))
		},

		/**
		 * @private
		 */
		 _isProfileContainerHasChildren: function(leftModulecontainerChilds) {
			return leftModulecontainerChilds?.ProfileContainer?.childElementCount >= 0;
		},

		/**
		 * @private
		 */
		 _getLeftModuleContainerChildren: function(renderElement) {
			return renderElement.dom.parentElement.getElementsByTagName('div');
		},

		//endregion
		
		//region Methods: Protected

		/**
		 * @inheritDoc Terrasoft.BaseModule#init
		 * @override
		 */
		init: function() {
			this.sandbox.registerMessages(this.messages);
			this.subscribeMessages();
			const config = this.sandbox.publish("GetDuplicatesWidgetConfig", null, [this.sandbox.id]) || {};
			this.model = Ext.create("Terrasoft.DuplicatesWidgetViewModel", {
				sandbox: this.sandbox,
				Ext: this.Ext,
				Terrasoft: this.Terrasoft
			});
			this.model.$EntitySchemaName = config.entitySchemaName;
			this.model.$EntityId = config.entityId;
			this.model.$Duplicates = config.duplicates;
			this.model.$IsLoading = config.isLoading;
			this.callParent(arguments);
		},

		/**
		 * Subscribes to messages of the module.
		 * @private
		 */
		subscribeMessages: function() {
			this.sandbox.subscribe("RefreshDuplicatesWidget", this.refreshDuplicatesWidget, this, [this.sandbox.id]);
		},

		/**
		 * Refresh duplicates widget data.
		 * @param {Boolean} overdue Data Overdue duplicates data.
		 */
		refreshDuplicatesWidget: function() {
			this._updateConfig();
		},

		/**
		 * @inheritDoc Terrasoft.BaseModule#render
		 * @override
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			if (!renderTo.dom) {
				renderTo = Ext.get(renderTo.id);
			}
			this.renderToElement = renderTo;
			this._renderDuplicatesWidget(renderTo);
		},

		/**
		 * @inheritDoc Terrasoft.BaseModule#destroy
		 * @override
		 */
		destroy: function() {
			if (this.view) {
				this.view.destroy();
			}
			if (this.model) {
				this.model.destroy();
			}
			this.callParent(arguments);
		}
		
		//endregion

	});

	return Terrasoft.DuplicatesWidgetModule;

});


