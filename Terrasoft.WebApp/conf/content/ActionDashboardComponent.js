Terrasoft.configuration.Structures["ActionDashboardComponent"] = {innerHierarchyStack: ["ActionDashboardComponent"]};
 define("ActionDashboardComponent", ["Base7xViewElement", "css!ActionDashboardComponent",
 		"ActionsDashboardUtils", "css!ActionsDashboardCSS", "css!BaseStageControl"],
		function(Base7xViewElement) {
	class CrtActionDashboard7xComponent extends Base7xViewElement {
		_moduleId;
		_entitySchemaName;
		_primaryColumnValue;
		_primaryDisplayColumnValue;
		_operation;
		_allowedActions;
		_actionsMapping = [];

		constructor() {
			super("SectionActionsDashboard");
			this._actionsMapping = {
				Dashboard: 'DashboardTab',
				Call: 'CallMessageTab',
				Email: 'EmailMessageTab',
				Feed: 'SocialMessageTab',
				Task: 'TaskMessageTab'
			};
		}

		get actionsMapping() {
			return this._actionsMapping;
		}

		get allowedActions() {
			return this._allowedActions;
		}

		set allowedActions(value) {
			const actions = [this.actionsMapping["Dashboard"]];
			value.forEach((el) => {
				const action = this.actionsMapping[el];
				if (action) {
					actions.push(action);
				}
			}, this);
			this._allowedActions = actions;
		}

		get operation() {
			return this._operation;
		}
		set operation(value) {
			this._operation = value;
		}

		get entitySchemaName() { return this._entitySchemaName; }
		set entitySchemaName(value) {
			this._entitySchemaName = value;
			this._render();
		}

		get primaryColumnValue() { return this._primaryColumnValue; }
		set primaryColumnValue(value) {
			this._primaryColumnValue = value;
		}
		get primaryDisplayColumnValue() { return this._primaryDisplayColumnValue; }
		set primaryDisplayColumnValue(value) {
			this._primaryDisplayColumnValue = value;
		}

		_render() {
			this.initContext(async () => {
				this._showLoadingSkeleton();
				this._moduleId = this.sandbox.id + "_ActionDashboardComponent";
				this.operation = await this.sandbox.publish("GetOperation");
				this.loadActionDashboardModule();
			});
		}

		_showLoadingSkeleton() {
			const selector = "DcmActionsDashboardContainer";
			const wrapHtml = this.ext.String.format("<div id=\"{0}\"></div>", selector);
			const element = Ext.select("#" + this.id).elements[0];
			this.ext.DomHelper.insertHtml("afterBegin", element, wrapHtml);
			this.terrasoft.ActionsDashboardUtils.showMask({
				showSpinnerEl: false,
				selector: "#" + selector,
				collapsed: false,
				hasAnyDcm: true
			});
		}

		getActionDashboardModuleViewConfig() {
			return {
				EntitySchemaName: this.entitySchemaName,
				PrimaryColumnValue: this.primaryColumnValue,
				Id: this.primaryColumnValue,
				PrimaryDisplayColumnValue: this.primaryDisplayColumnValue,
				Operation: this.operation,
				AllowedActions: this.allowedActions
			}
		}

		getMessages() {
			const messages = super.getMessages();
			return Object.assign(messages, {
				"GetOperation": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			});
		}

		loadActionDashboardModule() {
			var viewConfig = this.getActionDashboardModuleViewConfig();
			if (viewConfig.EntitySchemaName) {
				this._moduleId = this.sandbox.loadModule("BaseSchemaModuleV2", {
					id: this._moduleId,
					renderTo: this._renderTo,
					instanceConfig: {
						schemaName: "ActionDashboardComponentPage",
						isSchemaConfigInitialized: true,
						useHistoryState: false,
						showMask: true,
						parameters: {
							viewModelConfig: viewConfig
						},
					}
				}, this);
			}
		}

		connectedCallback() {
			super.connectedCallback();
			this._render();
		}

		disconnectedCallback() {
			this.sandbox?.unloadModule(this._moduleId, this._renderTo);
			super.disconnectedCallback();
		}
	}
	if (!customElements.get('crt-action-dashboard-7x')) {
		customElements.define('crt-action-dashboard-7x', CrtActionDashboard7xComponent);
	}
	return CrtActionDashboard7xComponent;
});


