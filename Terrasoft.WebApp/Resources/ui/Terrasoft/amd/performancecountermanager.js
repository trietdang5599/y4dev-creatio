(function(global) {

	/**
	 * Emulates the userTimingApi behavior
	 */
	const EmulatePerformanceApi = (function() {
		const entries = [];
		const timeOffset = new Date().valueOf();

		/**
		 * Returns the number of seconds since the application was downloaded.
		 * @private
		 * @return {TimeStamp}
		 */
		function currentTime() {
			const date = new Date();
			return date.valueOf() - timeOffset;
		}

		/**
		 * Clears the stored timestamps by the passed type and name. If no name is given, clears all the labels
		 * of the passed type.
		 * @private
		 */
		function clearEntries(entryType, name) {
			for (let i = entries.length - 1; i >= 0; i--) {
				const entry = entries[i];
				if (entry.entryType === entryType) {
					if (name == null || name === "" || entry.name === name) {
						entries.splice(i, 1);
					}
				}
			}
		}

		/**
		 * Returns the last stored timestamp with the passed name or null.
		 * @private
		 * @return {Object}
		 */
		function findLastEntryByName(name) {
			for (let i = entries.length - 1; i >= 0; i--) {
				const entry = entries[i];
				if (entry.name === name) {
					return entry;
				}
			}
			return null;
		}

		return {
			/**
			 * It increases the number of seconds since the application was downloaded.
			 * @return {TimeStamp}
			 */
			now: function() {
				return currentTime();
			},

			/**
			 * Sets the timestamp with the passed name and the "mark" type.
			 * @param {String} markName Timestamp name.
			 */
			mark: function(markName) {
				entries.push({
					startTime: currentTime(),
					duration: 0,
					entryType: "mark",
					name: markName
				});
			},

			/**
			 * Calculates the difference between two timestamps.
			 * @param {String} measureName Timestamp name with the "measure" type.
			 * @param {String} startMarkName Name of the start timestamp, if no name is given,
			 * it will be the time of start downloading the application
			 * @param {String} endMarkName The name of the final timestamp, if no name is given,
			 * the current time is taken.
			 */
			measure: function(measureName, startMarkName, endMarkName) {
				const startMark = findLastEntryByName(startMarkName);
				const endMark = findLastEntryByName(endMarkName);
				const startTime = startMark ? startMark.startTime : 0;
				const endTime = endMark ? endMark.startTime : currentTime();
				entries.push({
					startTime: startTime,
					duration: endTime - startTime,
					entryType: "measure",
					name: measureName
				});
			},

			/**
			 *Returns an array of timestamps with the specified name.
			 * @param {String} name The name of the timstamp
			 * @return {[Object]} An array of timestamps
			 */
			getEntriesByName: function(name) {
				const findedEntries = [];
				for (let i = 0, length = entries.length; i < length; i++) {
					const currentEntry = entries[i];
					if (currentEntry.name === name) {
						findedEntries.push({
							startTime: currentEntry.startTime,
							duration: currentEntry.duration,
							entryType: currentEntry.entryType,
							name: currentEntry.name
						});
					}
				}
				return findedEntries;
			},

			/**
			 * Removes all timestamps by the specified name and the "measure" type. If the name is not passed,
			 * all labels with the "measure" type.
			 * If the name is not passed, all timestamps with the "measure" type.
			 * @param {String} name The name of the timestamp
			 */
			clearMeasures: function(name) {
				clearEntries("measure", name);
			},

			/**
			 * Removes all timestamps by the specified name and the "mark" type. If the name is not passed,
			 * all labels with the "mark" type.
			 * If the name is not passed, all timestamps with the "mark" type.
			 * @param {String} name The name of the timestamp
			 */
			clearMarks: function(name) {
				clearEntries("mark", name);
			}
		};
	}());

	const indentSymbol = "\t";
	const marks = {};
	let highLightSupported = false;
	let sessionStarted = false;
	let currentSessionName = null;
	const requiredPerformanceApi = [
		"now",
		"mark",
		"measure",
		"getEntriesByName",
		"clearMeasures",
		"clearMarks"
	];
	let performanceApi = window.performance || {};
	const isPerformanceApiSupported = requiredPerformanceApi.every(function(name) {
		return performanceApi.hasOwnProperty(name);
	}, this);
	if (!isPerformanceApiSupported) {
		performanceApi = EmulatePerformanceApi;
	}
	let internalLogObject = global.console || {
		log: function() {
		}
	};

	/**
	 * @class Mark
	 * Timestamp class for profiling.
	 * @private
	 */
	function Mark(name) {
		this.name = name;
		this.measurements = [];
		this.requiredCalculateProperties = [
			"startTimeMarkName",
			"endTimeMarkName",
			"measureMarkName"
		];
	}

	Mark.prototype = {
		/**
		 * Timestamp name.
		 * @type {String}
		 */
		name: null,

		/**
		 * Session name.
		 * @type {String}
		 */
		sessionName: null,

		/**
		 * The array of measurements for the timestamp.
		 * @type {[Object]}
		 * @private
		 */
		measurements: null,

		/**
		 * An array of property names required for the calculation of the timestamp.
		 * @type {[String]}
		 * @private
		 */
		requiredCalculateProperties: null,

		/**
		 * Style to highlight the value.
		 * @type {String}
		 * @private
		 */
		durationOverflowHighlightStyle: "color: #f00",

		/**
		 * Removes all timestamps and measurements for the label.
		 */
		clear: function() {
			const markMeasurements = this.measurements;
			let measure;
			while ((measure = markMeasurements.pop()) != null) {
				performanceApi.clearMarks(measure.startTimeMarkName);
				performanceApi.clearMarks(measure.endTimeMarkName);
				performanceApi.clearMeasures(measure.measureMarkName);
			}
		},

		/**
		 * Returns a flag that all the indicators for the label are calculated.
		 * @return {Boolean}
		 */
		isCalculated: function() {
			const measurements = this.measurements;
			if (measurements.length === 0) {
				return false;
			}
			const notCalculatedMeasurements = measurements.filter(function(measure) {
				return (measure.isCalculated === false);
			}, this);
			return (notCalculatedMeasurements.length === 0);
		},

		/**
		 * Returns the flag that the transmitted measurement has already been calculated.
		 * @private
		 * @return {Boolean}
		 */
		isMeasureCalculatable: function(measure) {
			return this.requiredCalculateProperties.every(function(propertyName) {
				return measure.hasOwnProperty(propertyName);
			}, this);
		},

		/**
		 * Returns the flag that the label is being calculated.
		 * @return {Boolean}
		 */
		isCalculatable: function() {
			return this.measurements.every(function(measure) {
				return this.isMeasureCalculatable(measure);
			}, this);
		},

		/**
		 * Performs calculation of label indicators and its measurements.
		 */
		calculate: function() {
			if (!this.isStopped()) {
				return;
			}
			if (this.isCalculated()) {
				return;
			}
			if (!this.isCalculatable()) {
				return;
			}
			const markMeasurements = this.measurements;
			const measureLength = markMeasurements.length;
			let markTime = 0;
			markMeasurements.forEach(function(measure) {
				const measureMarkName = measure.measureMarkName;
				performanceApi.measure(measureMarkName, measure.startTimeMarkName, measure.endTimeMarkName);
				const entries = performanceApi.getEntriesByName(measureMarkName);
				const entry = entries[0];
				const startTime = measure.startTime = entry.startTime;
				const duration = measure.duration = entry.duration;
				measure.endTime = startTime + duration;
				measure.isCalculated = true;
				markTime += duration;
			}, this);
			this.avgDuration = Math.floor(markTime / measureLength);
			this.time = markTime;
		},

		/**
		 * Returns a copy of the label and its dimensions.
		 * @return {Mark}
		 */
		copy: function() {
			const markCopy = new Mark(this.name);
			markCopy.avgDuration = this.avgDuration;
			markCopy.time = this.time;
			this.measurements.forEach(function(measure) {
				const markCopymeasure = markCopy.createMeasure();
				markCopymeasure.startTime = measure.startTime;
				markCopymeasure.endTime = measure.endTime;
				markCopymeasure.duration = measure.duration;
				markCopymeasure.isCalculated = measure.isCalculated;
				markCopymeasure.isStopped = measure.isStopped;
				delete markCopymeasure.startTimeMarkName;
				delete markCopymeasure.endTimeMarkName;
				delete markCopymeasure.measureMarkName;
			}, this);
			return markCopy;
		},

		/**
		 * Creates a metering object for the label and returns it.
		 * @return {Object} The label metering object.
		 * @return {String} return.name Label name.
		 * @return {String} return.startTimeMarkName The name of the timestamp for the starting point of
		 * the measurement.
		 * @return {String} return.endTimeMarkName The name of the timestamp for the final measuring point.
		 * @return {String} return.measureMarkName The name of the timestamp with the result of the measurement.
		 * @return {Boolean} return.isStopped A flag that the profiling for the measurement is complete.
		 * @return {Boolean} return.isCalculated A flag that the metrics for the measurement have been completed.
		 * @return {DOMHighResTimeStamp|TimeStamp} return.duration Metering duration.
		 * @return {DOMHighResTimeStamp|TimeStamp} return.startTime The start time of the measure. Time is counted
		 * from the beginning of the application download.
		 * @return {DOMHighResTimeStamp|TimeStamp} return.endTime Metering completion time. Time is counted from
		 * the beginning of the application download.
		 */
		createMeasure: function() {
			const markMeasurements = this.measurements;
			const markName = this.name;
			const markNamePrefix = markName + "_" + markMeasurements.length;
			const measure = {
				name: markName,
				startTimeMarkName: markNamePrefix + "_start",
				endTimeMarkName: markNamePrefix + "_end",
				measureMarkName: markNamePrefix + "_measure",
				isStopped: false,
				isCalculated: false,
				duration: null,
				startTime: null,
				endTime: null
			};
			markMeasurements.push(measure);
			return measure;
		},

		/**
		 * Returns the last metering object for the label.
		 * @return {Object}
		 */
		getLastMeasure: function() {
			const markMeasurements = this.measurements;
			const measurementsLength = markMeasurements.length;
			if (measurementsLength === 0) {
				return null;
			}
			return markMeasurements[measurementsLength - 1];
		},

		/**
		 * Logs the label and its dimensions.
		 * @param {Object} config A configuration object for logging.
		 * @param {Number} config.indent The number of indents that must be done for output.
		 * The default value is 0.
		 * @param {String} config.displayName The name to display instead of the label name
		 * @param {Boolean} config.showDisplayName A flag that the label name should be displayed.
		 * The default value is true.
		 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that have exceeded the limit.
		 * The default value is false.
		 * @param {Number} config.durationLimit The limit for the value above which the value in the log is highlighted.
		 * The default value is -1.
		 * @param {Boolean} config.showAllCalls A sign that you want to print all the tag measurements.
		 * The default value is false.
		 * @private
		 */
		log: function(config) {
			const cfg = config || {};
			let indentLevel = cfg.indent || 0;
			const displayName = cfg.displayName || this.name;
			const showDisplayName = (cfg.showDisplayName !== false);
			if (showDisplayName) {
				const markNameString = Ext.String.format("{0}:", displayName);
				log(markNameString, indentLevel);
			}
			indentLevel++;
			if (this.sessionName) {
				const sessionNameString = Ext.String.format("session: {0}", this.sessionName);
				log(sessionNameString, indentLevel);
			}
			if (!this.isStopped()) {
				log("measurement is not finished", indentLevel);
				return;
			}
			const markMeasurements = this.measurements;
			this.logMetric({
				indent: indentLevel,
				name: "avgDuration",
				value: this.avgDuration,
				hightlightOverflow: config.hightlightDurationOverflow,
				limit: config.durationLimit,
				highlightStyle: this.durationOverflowHighlightStyle
			});
			this.logMetric({
				indent: indentLevel,
				name: "time",
				value: this.time
			});
			this.logMetric({
				indent: indentLevel,
				template: "{0}: {1}{2}",
				name: "callsCount",
				value: markMeasurements.length
			});
			const measurementsLogCfg = copyCfg(cfg);
			measurementsLogCfg.indent = indentLevel;
			this.logMeasurements(measurementsLogCfg);
		},

		/**
		 * Logs the label measurements.
		 * @param {Object} config A configuration object for logging.
		 * @param {Number} config.indent he number of indents that must be done for output.
		 * The default value is 0.
		 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that have exceeded the limit.
		 *  The default value is false.
		 * @param {Number} config.durationLimit The limit for the value above which the value in the log is highlighted.
		 * The default value is -1.
		 * @param {Boolean} config.showAllCalls A flag to print all the tag measurements.
		 * The default value is false.
		 * @private
		 */
		logMeasurements: function(config) {
			if (config.showAllCalls === true) {
				const indentLevel = config.indent;
				const metricIndent = indentLevel + 1;
				this.measurements.forEach(function(measure, index) {
					log("call №" + index, indentLevel);
					this.logMetric({
						indent: metricIndent,
						name: "duration",
						value: measure.duration,
						hightlightOverflow: config.hightlightDurationOverflow,
						limit: config.durationLimit,
						highlightStyle: this.durationOverflowHighlightStyle
					});
					this.logMetric({
						indent: metricIndent,
						template: "{0}: {1}{2}",
						name: "startTime",
						value: formatTime(measure.startTime)
					});
					this.logMetric({
						indent: metricIndent,
						template: "{0}: {1}{2}",
						name: "endTime",
						value: formatTime(measure.endTime)
					});
				}, this);
			}
		},

		/**
		 * Logs the metric of a label or metering.
		 * @param {Object} config A configuration object for logging.
		 * @param {String} config.template The metric output template. The default value is "{0}: {1} {2} ms".
		 * @param {String} config.name The name of the metric
		 * @param {Object} config.value The value of the metric
		 * @param {Boolean} config.hightlightDurationOverflow The flag to highlight the values,
		 * which exceeded the limit. The default value is false.
		 * @param {Number} config.limit  A limit on the value above which the value in the log is highlighted.
		 * The default value is -1.
		 * @param {String} config.highlightStyle A style for highlighting the metric. The default
		 * value is "color: # f00;".
		 * @private
		 */
		logMetric: function(config) {
			const template = config.template || "{0}: {1}{2}ms";
			const highLightParam = highLightSupported ? "%c" : "";
			const metricName = config.name;
			const metricValue = config.value;
			const logString = Ext.String.format(template, metricName, highLightParam, metricValue);
			let highlightStyle = "";
			const hightlightOverflow = (config.hightlightOverflow === true);
			const limit = config.limit || -1;
			if (hightlightOverflow && metricValue >= limit) {
				highlightStyle = config.highlightStyle || "";
			}
			log(logString, config.indent, highlightStyle);
		},

		/**
		 * Returns a flag that the label is currently profiled and all
		 * timestamps are set.
		 * @return {Object}
		 */
		isStopped: function() {
			const measure = this.getLastMeasure() || {};
			return (measure.isStopped === true);
		}
	};

	/**
	 * Searches for a label by name.
	 * @private
	 * @return {Mark|null} Label.
	 */
	function findMark(markName) {
		return marks[markName];
	}

	/**
	 * Removes labels with the passed name.
	 * @param {String} markName The name of the label.
	 * @private
	 */
	function clearMark(markName) {
		const mark = findMark(markName);
		if (!mark) {
			return;
		}
		mark.clear();
		delete marks[markName];
	}

	/**
	 * Prints to a log a message with a padded indent. Also, if the transfer of styles is supported,
	 * adds the corresponding parameter.
	 * @param {String} msg Message.
	 * @param {Number} indent Number of indents
	 * @param {String} logParams Optional logging parameter. Used to highlight values.
	 * @private
	 */
	function log(msg, indent, logParams) {
		let indentsArray = [indent || 0];
		indentsArray = indentsArray.map(function() {
			return indentSymbol;
		});
		const logArguments = [indentsArray.join("") + msg];
		if (highLightSupported) {
			logArguments.push(logParams || "");
		}
		internalLogObject.log.apply(internalLogObject, logArguments);
	}

	/**
	 * Returns the formatted output of time.
	 * @param {TimeStamp} timeStamp The number of seconds.
	 * @private
	 * @return {String}
	 */
	function formatTime(timeStamp) {
		if (!timeStamp) {
			return "--:--:--";
		}
		const time = new Date(timeStamp);
		const timeTemplate = "{0} m : {1} s : {2} ms";
		const formattedStartTime = Ext.String.format(timeTemplate, time.getMinutes(), time.getSeconds(),
			time.getMilliseconds());
		return formattedStartTime;
	}

	/**
	 * Returns the hierarchy of labels. The hierarchy is constructed by the names of the labels
	 * and the delimiter passed to it.
	 * @param {Object} config A configuration object.
	 * @param {Function} config.filterFn The function for filtering labels.
	 * @param {String} config.namespaceSeparator A separator for building a label hierarchy.
	 * @private
	 * @return {Object} Hierarchical object of  labels.
	 */
	function getMarksHierarchy(config) {
		const marksHierarchy = {
			hierarchy: {}
		};
		Terrasoft.each(marks, function(mark, markName) {
			if (!config.filterFn(mark)) {
				return;
			}
			const namespaces = markName.split(config.namespaceSeparator);
			const markIntroName = namespaces.pop();
			mark.introName = markIntroName;
			let currentHierarchyLevel = marksHierarchy.hierarchy;
			for (let i = 0, length = namespaces.length; i < length; i++) {
				const namespaceName = namespaces[i];
				if (!currentHierarchyLevel.hasOwnProperty(namespaceName)) {
					currentHierarchyLevel[namespaceName] = {};
				}
				currentHierarchyLevel = currentHierarchyLevel[namespaceName];
			}
			let markHierarchyLevel = currentHierarchyLevel[markIntroName];
			if (!markHierarchyLevel) {
				markHierarchyLevel = currentHierarchyLevel[markIntroName] = {};
			}
			markHierarchyLevel.mark = mark;
		}, this);
		return marksHierarchy;
	}

	/**
	 * Returns the copied object. The method works only for simple objects without a hierarchical structure.
	 * @param {Obkect} config The object to copy.
	 * @private
	 * @return {Object} The copied object.
	 */
	function copyCfg(config) {
		const cfg = {};
		Terrasoft.each(config, function(value, propertyName) {
			cfg[propertyName] = value;
		}, this);
		return cfg;
	}

	/**
	 * Logs a hierarchical label object.
	 * @param {Object} marksHierarchy Hierarchical label object.
	 * @param {Object} indent Number of indents for logging.
	 * @param {Object} config A configuration logging object.
	 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight the values,
	 * which exceeded the limit. The default value is false.
	 * @param {Number} config.durationLimit The limit for the value above which the value in the log is highlighted.
	 * The default value is -1.
	 * @param {Boolean} config.showAllCalls A flag to print all the label measurements.
	 * The default value is false.
	 * @private
	 */
	function logHierarchy(marksHierarchy, indent, config) {
		const indentLevel = indent;
		let markLogged = false;
		for (var namespaceName in marksHierarchy) {
			if (marksHierarchy.hasOwnProperty("mark") && !markLogged) {
				const mark = marksHierarchy.mark;
				const logConfig = copyCfg(config);
				logConfig.showDisplayName = false;
				logConfig.indent = indentLevel - 1;
				mark.log(logConfig);
				markLogged = true;
			}
			if (marksHierarchy.hasOwnProperty(namespaceName) && namespaceName !== "mark") {
				const hierarchyLevel = marksHierarchy[namespaceName];
				log(namespaceName, indentLevel);
				logHierarchy(hierarchyLevel, indentLevel + 1, config);
			}
		}
	}

	/**
	 * Calculates parameters for all labels.
	 * @private
	 */
	function calculteMarksMeasurements() {
		Terrasoft.each(marks, function(mark) {
			mark.calculate();
		}, this);
	}

	/**
	 * Searches for a label by name and returns it. If a label with this name is not passed, a new label is created.
	 * @param {String} markName The name of the label.
	 * @private
	 * @return {Mark} The label that was found or created.
	 */
	function getMark(markName) {
		let mark = findMark(markName);
		if (!mark) {
			mark = marks[markName] = new Mark(markName);
		}
		return mark;
	}

	/**
	 * Label filtering function for output.
	 * @param {String | Function} filter Filter. If a string is passed, the filtering occurs by the occurrence
	 * of a string in the label name. If the string has the "avgDurationLimit: {Number}" format the labels,
	 * the average execution time of which exceeds the limit, are being printed. If a function is passed,
	 * it is called, and a copy of the label is passed as the function parameter.
	 * The function must return a Boolean value.
	 * @param {Mark} mark Label.
	 * @private
	 * @return {Boolean}
	 */
	function marksFilter(filter, mark) {
		if (!filter) {
			return true;
		}
		let filterResult = true;
		const filterType = typeof filter;
		if (filterType === "string") {
			const timeLimitRegex = /avgDurationLimit:\s*(\d+)\s*/;
			const result = timeLimitRegex.exec(filter);
			if (result) {
				const avgDuration = parseInt(result[1], 10);
				filterResult = mark.avgDuration >= avgDuration;
			} else {
				const filterRegex = new RegExp(filter, "i");
				filterResult = filterRegex.test(mark.name);
			}
		} else if (filterType === "function") {
			const markCopy = mark.copy();
			filterResult = filter.call(this, markCopy);
		}
		return filterResult;
	}

	/**
	 * Returns the label filtering function tied to the context of the profiling manager.
	 * @param {String | Function} filter Filter.
	 * @private
	 */
	function getFilterFunction(filter) {
		return marksFilter.bind(this, filter);
	}

	/**
	 * Logs the labels by the transmitted configuration.
	 * @param {Object} config A configuration logging object.
	 * @param {Boolean} config.showFlat A flagn that the logging should be done flat.
	 * @param {Boolean} config.showByNamespace A flag that logging should be done in a hierarchical form.
	 * @param {String} config.namespaceSeparator A separator for building a label hierarchy. The default value is "_".
	 * @param {String | Function} config.filter The label filter. see {@link #marksFilter}
	 * @param {Boolean} config.showAllCalls A flag to print all measurements for the label.
	 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that exceed the limit.
	 * The default value is false. Does not work in all browsers.
	 * @param {Number} config.durationLimit Limit. The values are highlighted when this limit value us exceeded.
	 * Does not work in all browsers.
	 * @private
	 */
	function innerGetProfileInfo(config) {
		highLightSupported = !Ext.isIE;
		if (!config) {
			log("config is empty");
			return;
		}
		const cfg = {
			showFlat: config.showFlat,
			showByNamespace: config,
			namespaceSeparator: config.namespaceSeparator || "_",
			filterFn: getFilterFunction(config.filter),
			showAllCalls: (config.showAllCalls === true),
			hightlightDurationOverflow: (config.hightlightDurationOverflow === true),
			durationLimit: config.durationLimit || 0
		};
		calculteMarksMeasurements();
		const filterFn = cfg.filterFn;
		if (cfg.showFlat) {
			Terrasoft.each(marks, function(mark) {
				if (filterFn(mark)) {
					mark.log(cfg);
				}
			}, this);
		} else if (cfg.showByNamespace) {
			const marksHierarchy = getMarksHierarchy(cfg);
			logHierarchy(marksHierarchy, 0, cfg);
		}
	}

	/**
	 * Logs the labels for the transmitted configuration for the specified session.
	 * @param {Object} config A configuration logging object.
	 * @param {Boolean} config.showFlat A flag that the logging should be done flat.
	 * @param {Boolean} config.showByNamespace A flag that logging should be done in a hierarchical form.
	 * @param {String} config.namespaceSeparator A separator for building a label hierarchy. The default value is "_".
	 * @param {Boolean} config.showAllCalls A flag to print all measurements for the label.
	 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that exceed the limit.
	 * The default value is false. Does not work in all browsers.
	 * @param {Number} config.durationLimit Limit. The values are highlighted when this limit value us exceeded.
	 * Does not work in all browsers.
	 * @private
	 */
	function innerGetProfileInfoBySession(config) {
		if (!config) {
			return;
		}
		const isObject = config.isObject || false;
		const cfg = {
			showFlat: true,
			namespaceSeparator: config.namespaceSeparator || "_",
			hightlightDurationOverflow: false,
			durationLimit: config.durationLimit || 0
		};
		calculteMarksMeasurements();
		const currentMarks = {};
		Terrasoft.each(marks, function(mark, markName) {
			if (mark.sessionName && (mark.sessionName === config.sessionName)) {
				mark.log(cfg);
				if (isObject) {
					currentMarks[markName] = mark;
				}
			} else if (isObject) {
				currentMarks[markName] = mark;
			}
		}, this);
		return currentMarks;
	}

	let exports = {

		/**
		 * Returns the hierarchy of labels. The hierarchy is constructed by the names of the labels
		 * and the transferred delimiter.
		 * @param {Object} config A configuration object.
		 * @param {Function} config.filterFn The function for filtering labels.
		 * @param {String} config.namespaceSeparator A separator for constructing a label hierarchy.
		 * @private
		 * @return {Object} Hierarchical label object.
		 */
		getMarksHierarchy: function(config) {
			calculteMarksMeasurements();
			return getMarksHierarchy(config);
		},

		/**
		 * Starts the profiling session. Each label will be given the name of the session while it is running
		 * @param {string} sessionName session name
		 */
		startSession: function(sessionName) {
			sessionStarted = true;
			currentSessionName = sessionName;
		},

		/**
		 * Begins the profiling of the label with the transferred name. If the label does not exist, it is created.
		 * If the label exists and the previous iteration of the profiling is not completed for it,
		 * the profiling request is rejected.
		 * @param {String} markName The name of the label.
		 */
		start: function(markName) {
			let mark = findMark(markName);
			if (mark) {
				if (!mark.isStopped()) {
					return;
				}
			} else {
				mark = getMark(markName);
			}
			if (sessionStarted) {
				mark.sessionName = currentSessionName;
			}
			const measure = mark.createMeasure();
			performanceApi.mark(measure.startTimeMarkName);
		},

		/**
		 * Ends the profiling of the label by the passed name.
		 *  If there is no label or the previous iteration of profiling is already completed, the request is rejected.
		 * @param {String} markName The name of the label
		 */
		stop: function(markName) {
			const mark = findMark(markName);
			if (!mark || mark.isStopped()) {
				return;
			}
			const measure = mark.getLastMeasure();
			performanceApi.mark(measure.endTimeMarkName);
			measure.isStopped = true;
		},

		/**
		 * Ends the profiling session.
		 */
		stopSession: function() {
			sessionStarted = false;
			currentSessionName = null;
		},

		/**
		 * Deletes the label with the given name.
		 * @param {String} markName The name of the label.
		 */
		clear: function(markName) {
			clearMark(markName);
		},

		/**
		 * Removes all labels.
		 */
		clearAll: function() {
			Terrasoft.each(marks, function(mark, markName) {
				clearMark(markName);
			}, this);
		},

		/**
		 * Displays the profiling results in a flat view.
		 * @param {Object} config A configuration logging object.
		 * @param {String|Function} config.filter The label filter. see {@link #marksFilter}
		 * @param {Boolean} config.showAllCalls  A flag to print all measurements for the label.
		 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that exceed the limit.
		 * The default value is false. Does not work in all browsers.
		 * @param {Number} config.durationLimit Limit. The value is highlighted when the limit value is exceeded.
		 * Does not work in all browsers.
		 */
		getProfileInfo: function(config) {
			const cfg = copyCfg(config || {});
			cfg.showFlat = true;
			innerGetProfileInfo(cfg);
		},

		/**
		 * Displays the profiling results for the specified session
		 * @param {string} sessionName session name
		 * @param {boolean} isObject returns the profiling results as an object
		 * @returns {*}
		 */
		getProfileInfoBySession: function(sessionName, isObject) {
			const cfg = {
				sessionName: sessionName,
				isObject: isObject || false
			};
			const marksObject = innerGetProfileInfoBySession(cfg);
			return marksObject;
		},

		/**
		 * Displays the profiling results in a hierarchical form.
		 * @param {Object} config A configuration logging object.
		 * @param {String} config.namespaceSeparator A separator for constructing a label hierarchy.
		 * The default value is "_".
		 * @param {String|Function} config.filter The label filter. see {@link #marksFilter}
		 * @param {Boolean} config.showAllCalls A flag to print all measurements for the label.
		 * @param {Boolean} config.hightlightDurationOverflow A flag to highlight values that exceed the limit.
		 * The default value is false. Does not work in all browsers.
		 * @param {Number} config.durationLimit  Limit. The value is highlighted when the limit value is exceeded.
		 * Does not work in all browsers.
		 */
		getHierarchyProfileInfo: function(config) {
			const cfg = copyCfg(config || {});
			cfg.showFlat = false;
			cfg.showByNamespace = true;
			innerGetProfileInfo(cfg);
		},

		/**
		 * Sets the logging object.
		 * @param {Object} logObject Logging object.
		 * @param {Function} logObject.log Logging function.
		 */
		setLogObject: function(logObject) {
			internalLogObject = logObject;
		}
	};

	const Terrasoft = global.Terrasoft || {};
	if (Terrasoft.enablePerformanceManager !== true) {
		exports = {
			start: function() {
			},
			startSession: function() {
			},
			stop: function() {
			},
			stopSession: function() {
			},
			clear: function() {
			},
			clearAll: function() {
			},
			getProfileInfo: function() {
			},
			getHierarchyProfileInfo: function() {
			},
			setLogObject: function() {
			},
			getProfileInfoBySession: function() {
			},
			getMarksHierarchy: function() {
			}
		};
	}
	exports.startCounter = function() {
	};
	exports.stopCounter = function() {
	};
	exports.startAsyncCounter = function() {
	};
	exports.stopAsyncCounter = function() {
	};
	exports.setTimeStamp = function() {
	};
	exports.clearTimeStamp = function() {
	};
	exports.clearAllTimeStamps = function() {
	};
	exports.getTimeStamp = function() {
	};
	exports.getTimeSpan = function() {
	};
	const define = global.define;
	if (define) {
		define(exports);
	}
	global.performanceManager = exports;
}(window));
