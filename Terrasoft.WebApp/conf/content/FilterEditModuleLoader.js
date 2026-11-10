Terrasoft.configuration.Structures["FilterEditModuleLoader"] = {innerHierarchyStack: ["FilterEditModuleLoader"]};
 define("FilterEditModuleLoader", ["ext-base", "terrasoft", "IFramePageLoader", "AngularPostMessageConnector",
	 "ESQMetadataConverter", "css!FilterEditModuleLoader"], function () {

		Ext.define("Terrasoft.configuration.FilterEditModuleLoader", {
			extend: "Terrasoft.IFramePageLoader",
			alternateClassName: "Terrasoft.FilterEditModuleLoader",

			// TODO rename channel and message names.
			messageChannelName: "widget-designer-channel",
			requestConfigMessageName: 'RequestWidgetConfig',
			responseConfigMessageName: 'ResponseWidgetConfig',

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getSandboxMessages: function () {
				const messages = this.callParent(arguments);
				return Ext.apply(messages || {}, {
					"GetFilterModuleConfig": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"OnFiltersChanged": {
						mode: Terrasoft.MessageMode.BROADCAST,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
				})
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			subscribeSandboxMessages: function () {
				const filterModuleId = this.getLoaderModuleId();
				this.sandbox.subscribe("OnFiltersChanged", (result) => {
					this.messageChannel.sendMessage("DesignerLoaded");
					this.initialConfig.filters =
						Terrasoft.ESQMetadataConverter.toAngularFilters({
							filterData: result.serializedFilter
						});
					this.messageChannel.sendMessage("SaveWidgetConfig", this.initialConfig);
				}, this, [filterModuleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", () => {
					const filters = this.initialConfig.filters
						&& JSON.stringify(Terrasoft.ESQMetadataConverter.toExtFilters(this.initialConfig.filters));
					return {
						rootSchemaName: this.initialConfig.entitySchemaName,
						filters: filters
					}
				}, this, [filterModuleId]);
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getLoaderModuleId: function () {
				return this.sandbox.id + "_" + "FilterEditModule";
			},
			
			_applyStyles: function() {
				const styles = this.initialConfig?.stylesConfig;
				const modalBoxPosition = styles?.modalBoxPosition;
				const isHtmlRtl = document.querySelector('html').getAttribute('dir') === 'rtl';
				const isDesignTime = this.initialConfig?.isDesignTime;
				const isRtl = this.initialConfig?.isRtl;
				if (modalBoxPosition === 'top') {
					document.body.classList.add('modalbox-top-position');

					const isFirefox = window.navigator.userAgent.match(/Firefox\/([0-9]+)\./);
					if(isFirefox) {
						document.querySelector('html').classList.add('firefox-hide-scroll');
					}
					const isSafari = /^((?!chrome|android).)*safari/i.test(navigator.userAgent);
					if(isSafari && !(isHtmlRtl && isDesignTime)) {
						let dirPropertyValue = isRtl ? 'ltr' : 'rtl';
						document.querySelector('html').style.direction = dirPropertyValue;
					}
				}
				if(isRtl) {
					document.body.classList.add('modalbox-rtl');
				}
				if(isHtmlRtl && isDesignTime) {
					document.body.classList.add('modalbox-design-rtl');
				}
				const mainContentContainer = document.querySelector('.main-content-wrapper');
				if (mainContentContainer) {
					mainContentContainer.style.padding = styles?.paddings || '0 25px';
				}
	        }, 

			/**
			 * @inheritDoc
			 * @overridden
			 */
			loadContent: function (renderTo) {
				this.callParent(arguments);
				this._applyStyles();
				this.sandbox.loadModule("FilterEditModule", {
					keepAlive: true,
					renderTo: renderTo,
					id: this.getLoaderModuleId()
				});
			}
		});

		return Terrasoft.FilterEditModuleLoader;
	});


