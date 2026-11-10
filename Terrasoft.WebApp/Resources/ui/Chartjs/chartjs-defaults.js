(function () {
	if (typeof Chart === "undefined") {
		console.error("Can not find Chart object.");
		return;
	}
	Ext.apply(Chart.defaults.global, {
		defaultFontFamily: "'Bpmonline Open Sans', sans-serif",
		defaultFontSize: 13
	});
	Ext.apply(Chart.defaults.global.tooltips, {
		mode: "nearest",
		intersect: true,
		backgroundColor: "rgba(255, 255, 255, 0.8)",
		titleFontColor: "#000000",
		bodyFontColor: "#000000",
		borderColor: "#e2e2e2",
		borderWidth: 1,
	});
	Ext.apply(Chart.defaults.global.hover, {
		onHover: function(e) {
			const point = this.getElementAtEvent(e);
			e.target.style.cursor = point && point.length ? "pointer" : "default";
		}
	});
	Ext.apply(Chart.defaults.global.legend, {
		onHover: function(e) {
			e.target.style.cursor = "pointer";
		}
	});
	Ext.merge(Chart.defaults.scale, {
		gridLines: {
			display: true,
			drawBorder: true,
			drawOnChartArea: false
		},
		scaleLabel: {
			fontColor: "#999999",
			fontStyle: "bold"
		},
		ticks: {
			suggestedMin: 0,
			suggestedMax: 0,
			fontColor: "#999999",
			fontStyle: "bold"
		}
	});
	Ext.apply(Chart.defaults.horizontalBar.tooltips, {
		mode: "nearest"
	});
	Ext.apply(Chart.defaults.tsfunnel, {
		sort: "desc"
	});
	Ext.apply(Chart.defaults.tsgauge, {
		tooltips: {
			enabled: false
		}
	});
	Ext.apply(Chart.defaults.line.scales.xAxes[0], {
		offset: true
	});
})();