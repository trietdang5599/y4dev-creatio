(function(global) {
	function performanceLogger(global) {
		const Terrasoft = global.Terrasoft || {};
		const performance = global.performance || {};
		const _resourceTimingBufferSize = 3000;
		const _maxLoadedModulesCount = 100;
		const _maxSentEventsCount = 100;
		const _pendingTime = 1500;
		const _addEventActionName = "AddClientEvent";
		let _performanceLoggerServiceUrl = Terrasoft.clientPerformanceLoggerServiceUri || "";
		let _geolocationServiceUrl = ""; // TODO RND-23904
		let _configurationVersion = "";
		const _geolocationDataFieldNames = {
			countryCode: "countryCode",
			city: "city",
			ip: "query"
		};
		let _sessionId;
		let _countryCode;
		let _city;
		let _clientIp;
		let _eventCounter = 0;
		let _timeStamp;
		let _eventStartTime;
		let _eventEndTime;
		let _lastChangeTime = performance.now();
		let _executingModules = [];
		let _modules = [];
		let _ajaxRequests = [];
		let _isNeedSetup = true;
		let _started = true;
		let _startHash = _getHash();
		let _isLastRemovePending = false;
		let _isLocked = false;
		let _wasTabInBackground = document.hidden;

		/**
		 * Handles response from geolocation service.
		 * @private
		 * @param {Object} data Service data.
		 */
		function _processGeolocationData(data) {
			if (data) {
				_countryCode = data[_geolocationDataFieldNames.countryCode];
				_city = data[_geolocationDataFieldNames.city];
				_clientIp = data[_geolocationDataFieldNames.ip];
			}
		}

		function _initGeolocation(callback) {
			const safeCallback = function() {
				if (typeof callback === "function") {
					callback();
				}
			};
			if (!_geolocationServiceUrl) {
				safeCallback();
				return;
			}
			const xhr = new XMLHttpRequest();
			xhr.open("GET", _geolocationServiceUrl, true);
			xhr.setRequestHeader("Content-Type", "text/plain");
			xhr.send();
			xhr.onload = function() {
				const data = xhr.responseText && JSON.parse(xhr.responseText);
				_processGeolocationData(data);
				safeCallback();
			};
			xhr.onerror = function() {
				global.console.info("Geolocation service responded with error %d.", this.status);
				safeCallback();
			};
		}

		function _initServiceUrls() {
			const protocol = global.location.protocol;
			const delimiterChar = "/";
			let regExp = /^https:/;
			if (protocol === "https:") {
				regExp = /^http:/;
			}
			_performanceLoggerServiceUrl =
				_performanceLoggerServiceUrl.replace(regExp, protocol);
			_geolocationServiceUrl =
				_geolocationServiceUrl.replace(regExp, protocol);
			const urlLength = _performanceLoggerServiceUrl.length;
			if (urlLength > 0 && _performanceLoggerServiceUrl[urlLength - 1] !== delimiterChar) {
				_performanceLoggerServiceUrl += delimiterChar;
			}
		}

		function _isPerformanceMethodSupported(method) {
			return typeof method === "function";
		}

		function _getHash() {
			return global.location.hash.replace("#", "");
		}

		function _clearResourceEntries() {
			if (_isPerformanceMethodSupported(performance.clearResourceTimings)) {
				performance.clearResourceTimings();
			}
		}

		function _getSessionId() {
			let sessionId = Terrasoft.sessionId;
			if (!sessionId) {
				const strCookies = document.cookie;
				const cookiearray = strCookies.split(";");
				for (let i = 0; i < cookiearray.length; i++) {
					const cookieNameValue = cookiearray[i].split("=");
					if (cookieNameValue && cookieNameValue[0] && cookieNameValue[1]) {
						const name = cookieNameValue[0].trim();
						if (name === Terrasoft.sessionCookieName || name === Terrasoft.csrfCookieName) {
							sessionId = cookieNameValue[1].trim();
							break;
						}
					}
				}
			}
			return sessionId;
		}

		function _initConfigurationVersion(callback) {
			const safeCallback = function() {
				if (typeof callback === "function") {
					callback();
				}
			};
			if (!Terrasoft.SysSettings) {
				safeCallback();
			}
			Terrasoft.SysSettings.querySysSettingsItem("ConfigurationVersion", function(value) {
				_configurationVersion = value;
				safeCallback();
			});
		}

		function _setup(callback) {
			if (!_isNeedSetup) {
				if (typeof callback === "function") {
					callback();
				}
				return;
			}
			_isNeedSetup = false;
			_initServiceUrls();
			_sessionId = _getSessionId();
			_initConfigurationVersion(function() {
				_initGeolocation(callback);
			});
		}

		function _sendData(logData, methodName) {
			const xhr = new XMLHttpRequest();
			xhr.open("POST", _performanceLoggerServiceUrl + methodName, true);
			xhr.setRequestHeader("Content-Type", "text/plain");
			xhr.onerror = function() {
				global.console.info("Client performance logger service responded with error %d.", this.status);
			};
			xhr.send(JSON.stringify(logData));
		}

		function _getRequestResourceEntryData(startTime) {
			let requestData = _ajaxRequests.filter(function(request) {
				return request.startTime === startTime;
			})[0] || {};
			requestData = requestData.data;
			if (requestData && typeof requestData !== "string") {
				try {
					requestData = JSON.stringify(requestData);
				} catch (e) {
					requestData = undefined;
				}
			}
			return requestData;
		}

		function _getResourceEntryInfo(entry) {
			const info = {
				name: entry.name,
				duration: entry.duration,
				initiatorType: entry.initiatorType,
				startTime: entry.startTime,
				transferSize: entry.transferSize > Number.MAX_SAFE_INTEGER
					? 0
					: entry.transferSize,
				responseDuration: entry.responseEnd - entry.responseStart,
				encodedBodySize: entry.encodedBodySize > Number.MAX_SAFE_INTEGER
					? 0
					: entry.encodedBodySize
			};
			if (info.initiatorType === "xmlhttprequest") {
				info.requestData = _getRequestResourceEntryData(info.startTime);
			}
			return info;
		}

		function _getPerformanceEntries(isFirstEvent) {
			const isGetEntriesByTypeSupported = _isPerformanceMethodSupported(performance.getEntriesByType);
			const isGetEntriesSupported = _isPerformanceMethodSupported(performance.getEntries);
			if (!isFirstEvent && isGetEntriesByTypeSupported) {
				return performance.getEntriesByType("resource");
			} else if (isGetEntriesSupported) {
				return performance.getEntries();
			} else {
				return [];
			}
		}

		function _sendEvent(isFirstEvent) {
			const duration = isFirstEvent ? _eventEndTime : (_eventEndTime - _eventStartTime);
			if (!duration) {
				global.console.info("Duration can't be uncertain");
				return;
			}
			const resources = _getPerformanceEntries(isFirstEvent);
			const data = {
				startTime: isFirstEvent ? Date.now() - performance.now() : _timeStamp,
				duration: duration,
				urlHash: _getHash(),
				modules: _modules,
				entries: resources.map(_getResourceEntryInfo),
				userName: Terrasoft.SysValue.CURRENT_USER.displayValue,
				userId: Terrasoft.SysValue.CURRENT_USER.value,
				sessionId: _sessionId,
				hostName: Terrasoft.loaderBaseUrl,
				countryCode: _countryCode,
				city: _city,
				clientIp: _clientIp,
				version: _configurationVersion
			};
			_sendData(data, _addEventActionName);
		}

		function _setResourceTimingBufferSize(bufferSize) {
			if (_isPerformanceMethodSupported(performance.setResourceTimingBufferSize)) {
				performance.setResourceTimingBufferSize(bufferSize);
			}
		}

		function _checkToDisable() {
			const resources = _getPerformanceEntries(true);
			return _eventCounter >= _maxSentEventsCount || resources.length > _resourceTimingBufferSize ||
				_modules.length > _maxLoadedModulesCount;
		}

		function _disableLogging() {
			_isLocked = true;
			_executingModules = null;
			_modules = null;
			_ajaxRequests = null;
			_clearResourceEntries();
			_setResourceTimingBufferSize(0);
		}

		function _clear() {
			_clearResourceEntries();
			_executingModules = [];
			_modules = [];
			_ajaxRequests = [];
			_started = false;
			_startHash = null;
			_wasTabInBackground = false;
		}

		function _onAllModuleLoaded() {
			const hash = _getHash();
			if (!_wasTabInBackground && hash && (!_startHash || _startHash === hash)) {
				const isFirstEvent = _eventCounter === 0;
				_eventCounter++;
				_isLocked = true;
				_setup(function() {
					_sendEvent(isFirstEvent);
					_clear();
					_isLocked = false;
				});
			} else {
				_clear();
			}
		}

		function _getModuleById(id) {
			const module = _modules.filter(function(item) {
				return item.moduleId === id;
			})[0];
			return module;
		}

		function _initVisibilityChangeEvent() {
			document.addEventListener("visibilitychange", function() {
				_wasTabInBackground = _wasTabInBackground || (_started && document.hidden);
			});
		}

		function _findPerfEntryByXhr(xhrResponseLength, xhrRequestStartTime) {
			const entries = _getPerformanceEntries();
			const maxLookBack = 5;
			const entriesLength = entries.length;
			const minIndex = entriesLength > maxLookBack
				? entriesLength - maxLookBack
				: 0;
			for (let i = entriesLength - 1; i >= minIndex; i--) {
				const entry = entries[i];
				if (entry) {
					const entryStartTime = Math.floor(entry.startTime);
					const requestDataStartTime = Math.floor(xhrRequestStartTime);
					if (xhrResponseLength === entry.encodedBodySize &&
						(entryStartTime === requestDataStartTime ||
							Math.abs(entryStartTime - requestDataStartTime) === 1)) {
						return entry;
					}
				}
			}
			return null;
		}

		function _initAjax() {
			if (!XMLHttpRequest) {
				return;
			}
			const originalSend = XMLHttpRequest.prototype.send;
			const currentHost = global.location.origin || "";
			XMLHttpRequest.prototype.send = function(data) {
				this.addEventListener("loadstart", function() {
					if (_isLocked) {
						return;
					}
					const requestData = this.requestData;
					if (requestData.data) {
						requestData.startTime = performance.now();
					}
				}, false);
				this.addEventListener("loadend", function() {
					if (_isLocked) {
						return;
					}
					const requestData = this.requestData || {};
					const responseURL = this.responseURL || "";
					const isNotCors = responseURL.indexOf(currentHost) > -1;
					if (requestData.data && isNotCors) {
						let contentLength = this.getResponseHeader("Content-Length");
						contentLength = Number.parseInt(contentLength) || this.responseText.length;
						const entry = _findPerfEntryByXhr(contentLength, requestData.startTime);
						if (entry) {
							requestData.startTime = entry.startTime;
							_ajaxRequests.push(requestData);
						}
					}
				}, false);
				const requestData = this.requestData = {};
				requestData.data = data;
				return originalSend.apply(this, arguments);
			};
		}

		/**
		 * Initializes performance logger.
		 */
		function init() {
			_initAjax();
			_initVisibilityChangeEvent();
			_setResourceTimingBufferSize(_resourceTimingBufferSize);
		}

		/**
		 * Resets performance logger to initial state.
		 */
		function reset() {
			_clear();
			_setResourceTimingBufferSize(_resourceTimingBufferSize);
			_isLocked = false;
			_started = false;
			_startHash = _getHash();
			_wasTabInBackground = false;
			_eventCounter = 0;
		}

		/**
		 * Adds module to execution history buffer.
		 * @param {String} moduleId Module identifier.
		 * @param {String} moduleName Module name.
		 */
		function addModule(moduleId, moduleName) {
			if (_isLocked) {
				return;
			}
			if (_checkToDisable()) {
				_disableLogging();
				return;
			}
			const hash = _getHash();
			if (_started && _startHash !== hash) {
				if (_startHash) {
					_eventCounter++;
					_clear();
				} else {
					_startHash = hash;
				}
			}
			const now = performance.now();
			if (!_started) {
				_timeStamp = Date.now();
				_eventStartTime = now;
				_started = true;
				_startHash = hash;
			}
			if (_executingModules.indexOf(moduleId) === -1) {
				_modules.push({
					moduleId: moduleId,
					name: moduleName,
					startLoading: now
				});
				_executingModules.push(moduleId);
				_lastChangeTime = now;
			} else {
				global.console.info("Module %s should not be loaded twice.", moduleId);
			}
		}

		/**
		 * Removes module from execution history buffer.
		 * @param {String} moduleId Module identifier.
		 */
		function removeModule(moduleId) {
			if (_isLocked) {
				return;
			}
			const now = performance.now();
			const startIndex = _executingModules.indexOf(moduleId);
			if (startIndex !== -1) {
				const module = _getModuleById(moduleId);
				module.endLoading = now;
				_executingModules.splice(startIndex, 1);
				_lastChangeTime = now;
			}

			if (_executingModules.length === 0 && !_isLastRemovePending) {
				if (_lastChangeTime + _pendingTime <= now) {
					try {
						_eventEndTime = _lastChangeTime;
						_onAllModuleLoaded();
					} catch (e) {
						global.console.info(e);
						_clear();
					}
				} else {
					_isLastRemovePending = true;
					setTimeout(function() {
						_isLastRemovePending = false;
						removeModule(moduleId);
					}, _pendingTime);
				}
			}
		}

		/**
		 * Sets module start init mark.
		 * @param {String} moduleId Module identifier.
		 */
		function startInitModule(moduleId) {
			if (_isLocked) {
				return;
			}
			const module = _getModuleById(moduleId);
			if (module) {
				module.startInit = performance.now();
			}
		}

		/**
		 * Sets module end init mark.
		 * @param {String} moduleId Module identifier.
		 */
		function endInitModule(moduleId) {
			if (_isLocked) {
				return;
			}
			const module = _getModuleById(moduleId);
			if (module) {
				module.endInit = performance.now();
			}
		}

		/**
		 * Sets module start render mark.
		 * @param {String} moduleId Module identifier.
		 */
		function startRenderModule(moduleId) {
			if (_isLocked) {
				return;
			}
			const module = _getModuleById(moduleId);
			if (module) {
				module.startRender = performance.now();
			}
		}

		/**
		 * Sets module end render mark.
		 * @param {String} moduleId Module identifier.
		 */
		function endRenderModule(moduleId) {
			if (_isLocked) {
				return;
			}
			const module = _getModuleById(moduleId);
			if (module) {
				module.endRender = performance.now();
			}
		}

		/**
		 * Returns current executing modules.
		 * @return {Array} Executing modules.
		 */
		function getCurrentExecutingModules() {
			return _executingModules;
		}

		const exports = {
			init: init,
			reset: reset,
			addModule: addModule,
			removeModule: removeModule,
			startInitModule: startInitModule,
			endInitModule: endInitModule,
			startRenderModule: startRenderModule,
			endRenderModule: endRenderModule,
			getCurrentExecutingModules: getCurrentExecutingModules
		};
		return exports;
	}

	const logger = performanceLogger(global);
	logger.init();
	global.performanceLogger = logger;
}(window));

define("performanceLogger", [], function() {
	return window.performanceLogger;
});
