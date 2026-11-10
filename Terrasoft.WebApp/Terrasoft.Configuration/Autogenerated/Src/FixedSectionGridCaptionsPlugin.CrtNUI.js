define("FixedSectionGridCaptionsPlugin", [], function() {
	Ext.define("Terrasoft.FixedSectionGridCaptionsPlugin", {

		/**
		 * Handler of scroll value changed.
		 * @type {Function}
		 * @private
		 */
		 _debounceOnScrollChangedFn: null,

		 /**
		 * Checks that fixed section grid captions should be enabled.
		 * @protected
		 */
		isEnabledFixedSectionGridCaptions: function() {
			return Terrasoft.Features.getIsEnabled("FixedSectionGridCaptions");
		},

		/**
		 * Checks possibility captions container updates.
		 * @protected
		 */
		canUpdateGridCaptionsContainer: function() {
			var analyticsContainerEl = Ext.select("#AnalyticsGridLayoutContainer").elements[0];
			return this.isEnabledFixedSectionGridCaptions() && 
				!!Ext.get("SectionContainer") && (!analyticsContainerEl || analyticsContainerEl.offsetHeight === 0);
		},

		/**
		 * Updates width and position of the captions container element in the section grid.
		 * @public
		 */
		updateGridCaptionsContainer: function() {
			var canUpdate = this.canUpdateGridCaptionsContainer();
			if (!canUpdate) {
				return;
			}
			var rightSectionContainerSelector = "#RightSectionContainer";
			var gridCaptions = Ext.select(Ext.String.format("{0} .grid-captions", rightSectionContainerSelector)).elements[0];
			var gridRow = Ext.select(Ext.String.format("{0} .grid-listed-row, {1} .grid-active-selectable",
				rightSectionContainerSelector, rightSectionContainerSelector)).elements[0];
			var utilsContainer =
			Ext.select(Ext.String.format("{0} .utils-container-wrapClass", rightSectionContainerSelector)).elements[0];
			if (!gridCaptions || !gridRow || !utilsContainer) {
				return;
			}
			var utilsContainerBoundingRect = utilsContainer.getBoundingClientRect();
			Ext.get(gridCaptions).setStyle({
				top: Ext.String.format("{0}px", (utilsContainerBoundingRect.top + utilsContainerBoundingRect.height)),
				width: Ext.String.format("{0}px", gridCaptions.parentElement.clientWidth),
				position: "fixed"
			});
			var gridList = Ext.select(Ext.String.format("{0} .grid.grid-listed", rightSectionContainerSelector)).elements[0];
			Ext.get(gridList).setStyle({
				paddingTop: Ext.String.format("{0}px", gridCaptions.clientHeight)
			})
		},

		/**
		 * Subscribes on window "scroll" event by updating grid captions.
		 */
		subscribeUpdateGridCaptionsContainer: function() {
			if (!this.isEnabledFixedSectionGridCaptions()) {
				return;
			}
			var updateDelay = 200;
			this._debounceOnScrollChangedFn = Terrasoft.debounce(this.updateGridCaptionsContainer.bind(this), updateDelay);
			Ext.EventManager.addListener(window, "scroll", this._debounceOnScrollChangedFn, this);
		},

		/**
		 * Unsubscribes on window "scroll" event.
		 */
		unsubscribeUpdateGridCaptionsContainer: function() {
			Ext.EventManager.removeListener(window, "scroll", this._debounceOnScrollChangedFn, this);
		}
	});

	return Ext.create("Terrasoft.FixedSectionGridCaptionsPlugin");
});
