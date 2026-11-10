define("PageSchemaViewModule", ["@creatio-devkit/common", "BaseSchemaViewModule", "HistoryStateUtilities"], function(devkit) {
	Ext.define("Terrasoft.configuration.PageSchemaViewModule", {
		alternateClassName: "Terrasoft.PageSchemaViewModule",
		extend: "Terrasoft.BaseSchemaViewModule",

		mixins: {
			historyStateUtilities: "Terrasoft.HistoryStateUtilities"
		},

		/**
		 * @protected
		 */
		componentSelector: "crt-page-component",
		/**
		 * @protected
		 */
		componentWrapSelector: "crt-page",

		/**
		 * @private
		 */
		_getPageCaptionEsq: function(name) {
			const esq = new Terrasoft.EntitySchemaQuery({
				rootSchemaName: "SysSchema",
				isDistinct: true
			});
			esq.addColumn(
				"=[VwSysSchemaExtending:BaseSchemaId:Id].[SysSchema:Id:TopExtendingSchemaId].Caption", "Caption");
			const filterName = Terrasoft.createColumnFilterWithParameter("Name", name);
			esq.filters.add("SchemaPropertyNameFilter", filterName);
			return esq;
		},

		/**
		 * @private
		 */
		_getSchemaCaption: function(callback, scope) {
			const request = this._getPageCaptionEsq(this.schemaName);
			request.execute((response) => {
				const item = response.collection.first();
				Ext.callback(callback, scope || this, [item.get("Caption")]);
			});
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = this.getSchemaNameFromHistoryState();
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#init
		 * @protected
		 */
	    init: function(callback, scope) {
			this.callParent(arguments);
			this._getSchemaCaption((caption) => {
				this.sandbox.publish("InitDataViews", { caption });
			}, this );			
		},

	});
	return Terrasoft.PageSchemaViewModule;
});
