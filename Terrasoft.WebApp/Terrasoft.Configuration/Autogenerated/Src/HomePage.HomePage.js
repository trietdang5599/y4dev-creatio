define("HomePage", ["MaskHelper", "BaseSchemaViewModule", "mf!SchemaViewComponent", "css-ltr!SchemaViewComponentStyles",
	"css!HomePage","ContextHelpMixin"], function (MaskHelper) {
	Ext.define("Terrasoft.configuration.HomePage", {
		alternateClassName: "Terrasoft.HomePage",
		extend: "Terrasoft.BaseSchemaViewModule",
		mixins: {
			ContextHelpMixin: "Terrasoft.ContextHelpMixin"
		},

		/**
		 * @private
		 */
		_renderTo: null,

		/**
		 * @protected
		 */
		componentSelector: "crt-home-page-component",

		/**
		 * @protected
		 */
		componentWrapSelector: "home-page",

		/**
		 * @private
		 */
		_getHomePageSchemaName() {
			const historyState = this.sandbox.publish("GetHistoryState");
			return historyState?.hash.entityName;
		},

		/**
		 * @private
		 */
		_getSchemaCaption: function(callback, scope) {
			const homePageSchemaName = this._getHomePageSchemaName();
			const request = this._getHomePageEsq(homePageSchemaName);
			request.execute((response) => {
				const item = response.collection.first();
				callback.call(scope || this, item.get("Caption"));
			});
		},

		/**
		 * @private
		 */
		_getHomePageEsq: function(name) {
			const esqAngularHomePages = new Terrasoft.EntitySchemaQuery({
				rootSchemaName: "SysSchema",
				isDistinct: true
			});
			esqAngularHomePages.addColumn(
				"=[VwSysSchemaExtending:BaseSchemaId:Id].[SysSchema:Id:TopExtendingSchemaId].Caption", "Caption");
			esqAngularHomePages.addParameterColumn(true, Terrasoft.DataValueType.BOOLEAN,
				"isHomePage");
			const filterName = Terrasoft.createColumnFilterWithParameter("Name", name);
			esqAngularHomePages.filters.add("SchemaPropertyNameFilter", filterName);
			return esqAngularHomePages;
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#init
		 * @protected
		 */
		init: function() {
			this.callParent(arguments);
			const historyState = this.sandbox.publish("GetHistoryState");
			const {hash} = historyState;
			this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
			this._getSchemaCaption((caption) => {
				const headerConfig = {
					isMainMenu: false,
					isLogoVisible: true,
					isCaptionVisible: true,
					isContextHelpVisible: true,
					caption,
					moduleName: this.schemaName
				};
				this.sandbox.publish("InitDataViews", headerConfig);
				this.sandbox.subscribe("NeedHeaderCaption", function () {
					this.sandbox.publish("InitDataViews", headerConfig);
					this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
				}, this);
			});
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#getMessages
		 * @protected
		 */
		getMessages: function() {
			const message = this.callParent(arguments);
			return Ext.apply(message, {
				"SelectedSideBarItemChanged": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"NeedHeaderCaption": {
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE,
					mode: this.Terrasoft.MessageMode.BROADCAST
				},
				"InitContextHelp": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"UpdateSection": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			});
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 */
		initSchemaName: function() {
			this.schemaName = this._getHomePageSchemaName();
		}
	});
	return Terrasoft.HomePage;
});
