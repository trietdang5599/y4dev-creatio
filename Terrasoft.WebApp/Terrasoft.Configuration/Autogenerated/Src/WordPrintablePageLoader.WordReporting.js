define("WordPrintablePageLoader", ["ext-base", "terrasoft", "BaseViewModule", "AngularPostMessageConnector",
	"WordPrintableConverter", "css!CommonCSSV2", "css!WordPrintablePageLoader"
], function() {

	Ext.define("Terrasoft.configuration.WordPrintablePageLoader", {
		extend: "Terrasoft.BaseViewModule",
		alternateClassName: "Terrasoft.WordPrintablePageLoader",

		// region Fields: Public

		Ext: null,
		sandbox: null,
		Terrasoft: null,
		isAsync: true,
		renderTo: "",
		messageChannel: null,
		cardState: null,
		sysModuleReport: null,

		//endregion

		// region Constructors: Public

		/**
		 * @inheritDoc Terrasoft.BaseObject#constructor.
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this._registerMessages();
			this.messageChannel = Ext.create('Terrasoft.AngularPostMessageConnector', {
				channelName: "word-printable",
				target: window.parent
			});
		},

		// endregion

		// region Methods: Private

		/**
		 * @return {Object}
		 * @private
		 */
		_getMessages: function() {
			return {
				"LoadModule": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"RefreshCacheHash": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"NavigationModuleLoaded": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.BROADCAST
				},
				"HistoryStateChanged": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.BROADCAST
				},
				"GetHistoryState": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				"PushHistoryState": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.BROADCAST
				},
				"RequestSysModuleReport": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"RequestSysModuleReportDiscard": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"ReturnSysModuleReportDiscardResult": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				"ReturnSysModuleReport": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				"RequestSysModuleReportSave": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"ReturnSysModuleReportSaveResult": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				"RequestClosePage": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"ChangeCardState": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"RequestCopyData": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				},
				"ReturnCopyData": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
			};
		},

		/**
		 * @private
		 */
		_registerMessages: function() {
			const messages = this._getMessages();
			this.sandbox.registerMessages(messages);
		},

		/**
		 * @private
		 */
		_unRegisterMessages: function() {
			const messages = this._getMessages();
			this.sandbox.unRegisterMessages(messages);
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc Terrasoft.BaseViewModule#initHomePage
		 * @overridden
		 */
		initHomePage: function(callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * @inheritDoc Terrasoft.BaseViewModule#loadMainPanelsModules
		 * @overridden
		 */
		loadMainPanelsModules: Terrasoft.emptyFn,

		/**
		 * @inheritDoc Terrasoft.BaseObject#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			this._unRegisterMessages();
			this.callParent(arguments);
		},

		// endregion

		// region Methods: Public

		/**
		 * Initializes module.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback.
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.messageChannel.connect(function(result) {
					if (result === false) {
						throw Ext.create("Terrasoft.InvalidOperationException");
					}
					const converter = Terrasoft.WordPrintableConverter;
					this.messageChannel.on('ReturnSysModuleReport', function(payload) {
						this.cardState = payload.operation;
						this.sysModuleReport = payload.printable;
						this.sourceReportId = payload.sourceReportId;
						callback.call(scope);
					}, this);
					this.messageChannel.sendMessage("RequestSysModuleReport");
					this.sandbox.subscribe("RequestCopyData", function() {
						const payload = {
							isCopy: this.cardState === "copy",
							sourceReportId: this.sourceReportId
						};
						this.sandbox.publish("ReturnCopyData", payload);
					}, this);
					this.sandbox.subscribe("RequestSysModuleReport", function() {
						const isNew = this.cardState !== "edit";
						converter.convertFromAngularDto(isNew, this.sysModuleReport, function(entityDto) {
							this.sandbox.publish("ReturnSysModuleReport", entityDto);
						}, this);
					}, this);
					this.sandbox.subscribe("ChangeCardState", function(state) {
						 this.cardState = state;
					}, this);
					this.sandbox.subscribe("RequestSysModuleReportDiscard", function() {
						this.messageChannel.sendMessage("RequestSysModuleReportDiscard");
					}, this);
					this.messageChannel.on('ReturnSysModuleReportDiscardResult', function(printable) {
						this.sysModuleReport = printable;
						this.sandbox.publish("ReturnSysModuleReportDiscardResult");
					}, this);
					this.messageChannel.on('ReturnSysModuleReportSaveResult', function(data) {
						this.sandbox.publish("ReturnSysModuleReportSaveResult", data);
					}, this);
					this.sandbox.subscribe("RequestSysModuleReportSave", function(entity) {
						converter.convertToAngularDto(entity, function(sysModuleReport) {
							this.sysModuleReport = sysModuleReport;
							this.messageChannel.sendMessage("RequestSysModuleReportSave", {printable: sysModuleReport});
						}, this);
					}, this);
					this.sandbox.subscribe("RequestClosePage", function() {
						this.messageChannel.sendMessage("RequestClosePage");
					}, this);
				}, this);
			}, this]);
		},

		/**
		 * Renders module.
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this.sandbox.subscribe("NavigationModuleLoaded", function() {
				const hash = Terrasoft.combinePath("CardModuleV2", "WordPrintablePage", this.cardState, this.sysModuleReport.id);
				this.sandbox.publish("PushHistoryState", {hash: hash});
			}, this);
		}

		//endregion
	});

	return Terrasoft.WordPrintablePageLoader;
});
