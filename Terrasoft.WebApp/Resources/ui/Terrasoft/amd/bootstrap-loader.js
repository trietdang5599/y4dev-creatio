/**
 * Prepares current page to loading a bootstrap module (that should be specified in 'data-loadbootstrap' attribute)
 * and loads this module.
 */
(() => {
	const jQueryPropertyName = 'jQuery';
	const fileApiPropertyName = 'FileAPI.min';
	const baseUrl = getBaseUrl();
	let coreResourcesPath;
	let cacheBustingQueryString;

	/**
	 * Returns script HTML-element of bootstrap loader.
	 */
	function getBootstrapLoaderScriptElement() {
		const script = document.querySelector("script[data-loadbootstrap]");
		if (!script) {
			throw new Error("Please specify 'data-loadbootstrap' attribute!");
		}
		return script;
	}

	/**
	 * Returns value of "data-" attribute which was specified in bootstrap loader script element.
	 * @param attributeName Name of the attribute, without "data-" prefix.
	 * @returns {string} Value of the attribute.
	 */
	function getBootstrapLoaderScriptDataAttribute(attributeName) {
		const script = getBootstrapLoaderScriptElement();
		return script.getAttribute("data-" + attributeName);
	}

	/**
	 * Returns base URL that is used for all script/style tags and requests.
	 * @returns {string} Base URL of the application with a trailing slash.
	 */
	function getBaseUrl() {
		return (getBootstrapLoaderScriptDataAttribute("baseurl") || "") + "/";
	}

	/**
	 * Returns URL of the endpoint that should be used for loading of additional client scripts from the server.
	 */
	function getClientScriptEndpointUrl() {
		const prefix = document.cookie.match(new RegExp('(^| )' + 'UserType' + '=([^;]+)'))?.[2] === 'SSP' ? 'ssp/' : '';
		const defaultEndpointPrefix = `${prefix}ServiceModel/ClientScriptService.svc`;
		const defaultEndpointMethod = "GenerateLoginScripts";
		const endpointPrefix =
			getBootstrapLoaderScriptDataAttribute("clientscriptendpointprefix") || defaultEndpointPrefix;
		const endpointMethod =
			getBootstrapLoaderScriptDataAttribute("clientscriptendpoint") || defaultEndpointMethod;
		const urlParams = getBootstrapLoaderScriptDataAttribute("urlparams") || '';
		return baseUrl + endpointPrefix + '/' + endpointMethod + (urlParams ? '?' + urlParams : '');
	}

	/**
	 * Builds query string with a unique file version identifier to tell the browser that a new version of the file is available.
	 * @param {String} cacheBustingQueryParam Value of the parameter to be used in the cache busting string.
	 */
	function buildCacheBustingQueryString(cacheBustingQueryParam) {
		return "v=" + cacheBustingQueryParam;
	}

	/**
	 * Retrieves access token to be used for authentication.
	 * @returns {string | null}
	 */
	function getAccessToken() {
		return localStorage.getItem('accessToken');
	}

	/**
	 * Appends HTML element (like `script` or `link`) to the document head and waits for it to load.
	 * @param element The HTML element to append.
	 * @returns {Promise<void>} A promise that resolves when the element is loaded.
	 */
	async function appendAndWaitForLoad(element) {
		return new Promise((resolve, reject) => {
			element.addEventListener('load', () => resolve(), { once: true });
			element.addEventListener(
				'error',
				() => reject(new Error(`Failed to load: "${element.outerHTML}"`)),
				{ once: true }
			);
			document.head.appendChild(element);
		});
	}

	/**
	 * Appends 'script' tag for JS-file with specified source URL to current position in HTML.
	 * @param {String} url URL of script source file.
	 * @param {String} [customCacheBustingQueryParam] Value of the parameter to be used in the cache busting string
	 * instead of default value.
	 * @return {Promise<void>} Promise that resolves when the script is loaded.
	 */
	async function loadStaticScriptWithUrl(url, customCacheBustingQueryParam) {
		const script = document.createElement("script");
		script.type = "text/javascript";
		const paramStartIndex = url.indexOf("?");
		const paramDelimiter = paramStartIndex !== -1
			? paramStartIndex === url.length - 1
				? ""
				: "&"
			: "?";
		script.src = url + paramDelimiter + (customCacheBustingQueryParam
			? buildCacheBustingQueryString(customCacheBustingQueryParam)
			: cacheBustingQueryString);
		await appendAndWaitForLoad(script);
	}

	/**
	 * Retrieves a JavaScript code from the specific URL and appends 'script' tag to evaluate this code.
	 * @param {String} url URL of script source file.
	 * @return {Promise<void>} Promise that resolves when the script is loaded.
	 */
	async function fetchAndLoadScript(url) {
		const accessToken = getAccessToken();
		const headers = accessToken
			? { 'Authorization': `Bearer ${accessToken}` }
			: {};
		const response = await fetch(url, {
			method: 'GET',
			headers
		});
		if (!response.ok) {
			throw new Error(`Failed to fetch script from ${url}: ${response.status} ${response.statusText}`);
		}
		const jsCode = await response.text();
		const blob = new Blob([jsCode], { type: 'application/javascript' });
		const blobUrl = URL.createObjectURL(blob);
		const script = document.createElement('script');
		script.type = "text/javascript";
		script.src = blobUrl;
		try {
			await appendAndWaitForLoad(script);
		} finally {
			URL.revokeObjectURL(blobUrl);
		}
	}

	/**
	 * Appends 'link' tag for CSS-file with specified source URL to current position in HTML.
	 * @param {String} url URL of CSS source file.
	 * @return {Promise<void>} Promise that resolves when the CSS file is loaded.
	 */
	async function loadCssLinkWithUrl(url) {
		const link = document.createElement("link");
		link.type = "text/css";
		link.rel = "stylesheet";
		link.href = url + "?" + cacheBustingQueryString;
		await appendAndWaitForLoad(link);
	}

	/**
	 * Builds full path of core resource file.
	 * @param {String} resourceRelativePath Relative path of core resource file.
	 */
	function buildCoreResourceUrl(resourceRelativePath) {
		return coreResourcesPath + resourceRelativePath;
	}

	/**
	 * Receives URL of bootstrap file to load.
	 */
	function getLoadBootstrapUrl() {
		const bootstrapModulesPath = "Terrasoft/amd/";
		return buildCoreResourceUrl(bootstrapModulesPath + getBootstrapLoaderScriptDataAttribute("loadbootstrap"));
	}

	function getFileApiPath() {
		let scriptVersionPath = Terrasoft?.scriptVersionPath || {};
		return scriptVersionPath[fileApiPropertyName] || "FileApi/FileAPI.min";
	}

	function configureScriptVersionPath(requirePathsConfig) {
		const scriptPaths = Terrasoft?.scriptVersionPath || {}
		Object.keys(scriptPaths).forEach(function(key) {
			let requiredPath = scriptPaths[key];
			requirePathsConfig[key] = buildCoreResourceUrl(requiredPath);
		});
	}

	/**
	 * Configures RequireJs by initial modules before loading bootstrap module.
	 */
	function configureRequireJs() {
		const requirePathsConfig = {
			"configuration-loader": "Terrasoft/amd/configuration-loader",
			"configuration-bootstraps": "Terrasoft/amd/configuration-bootstraps",
			"require-config": "Terrasoft/amd/require-config",
			"require-url-config": "Terrasoft/amd/require-url-config",
			"core-base": "Terrasoft/amd/core-base",
			"bootstrap": "Terrasoft/amd/bootstrap",
			"performanceLogger": "Terrasoft/amd/performanceLogger",
			"performancecountermanager": "Terrasoft/amd/performancecountermanager",
			"crtrxjs": "Terrasoft/amd/crtrxjs",
			"process-designer-component": "Terrasoft/designers/process-schema-designer/process-designer-component-mf-proxy",
			"process-designer-component-mf": "Terrasoft/designers/process-designer-component/process-designer",
			"process-designer-component-styles": "Terrasoft/designers/process-designer-component/styles",
			"voice-to-text-component": "Terrasoft/controls/mixins/voice-to-text-button/voice-to-text-component-mf-proxy",
			"voice-to-text-component-mf": "Terrasoft/controls/mixins/voice-to-text-button/voice-to-text-component/voice-to-text",
			"jQuery-easing": "jQueryEasing/jQuery-easing",
			"jsrender": "jsrender/jsrender",
			"ts-diagram-require-configurator": "ts-diagram-module/ts-diagram-require-configurator",
			"ts-common-all": "ts-diagram-module/ts-common-all",
			"ts-diagram": "ts-diagram-module/ts-diagram",
			"process-schema-diagram": "Terrasoft/designers/process-schema-designer/process-schema-diagram",
			"process-schema-diagram-5x": "Terrasoft/designers/process-schema-designer/process-schema-diagram-5x",
			"ckeditor-base": "CKEditor/ckeditor",
			"html2canvas": "html2canvas/html2canvas",
			"classList-shim": "normalize/classList-shim",
			"pathSeg-polyfill": "normalize/pathSeg-polyfill",
			"login-view-utils": "Terrasoft/amd/login-view-utils",
			"ssoutils": "Terrasoft/utils/sso/ssoutils",
			"open-id-start-sso-client-provider": "Terrasoft/utils/sso/providers/open-id-start-sso-client-provider",
			"saml-start-sso-client-provider": "Terrasoft/utils/sso/providers/saml-start-sso-client-provider",
			"login-model-utils": "Terrasoft/amd/login-model-utils",
			"two-factor-auth-utils": "Terrasoft/utils/two-factor-auth/two-factor-auth-utils",
			"chartjs": "Chartjs/Chart.bundle",
			"chartjs-label": "Chartjs/chartjs-plugin-labels",
			"chartjs-defaults": "Chartjs/chartjs-defaults",
			"chartjs-funnel": "Chartjs/chart.funnel",
			"chartjs-gauge": "Chartjs/Gauge",
			"ng-core": "ng-core/src/main",
			"ng-scripts": "ng-core/src/scripts",
			"ng-polyfills": "ng-core/src/polyfills",
			"ng-polyfill-webcomp": "ng-core/src/polyfill-webcomp",
			"numeral": "Numeral/numeral.min",
			"user-agent": "Terrasoft/utils/user-agent",
			"user-agent-parser": "user-agent-parser/user-agent-parser.min",
			"@creatio-devkit/common": "creatio-devkit-common/creatio-devkit-common.umd",
			"@creatio/sdk": "creatio-devkit-common/creatio-sdk.umd",
			"@creatio/utils": "creatio-utils/creatio-utils.umd",
			"two-fa": "Terrasoft/amd/two-factor/two-fa-app",
			"two-fa-styles": "Terrasoft/amd/two-factor/styles"
		};
		Object.keys(requirePathsConfig).forEach((key) => {
			let requiredPath = requirePathsConfig[key];
			requirePathsConfig[key] = buildCoreResourceUrl(requiredPath);
		});
		configureScriptVersionPath(requirePathsConfig);
		requirePathsConfig["loadbootstrap"] = getLoadBootstrapUrl();
		requirejs.config({
			paths: requirePathsConfig,
			shim: {
				"jQuery-easing": { "deps": ["jQuery"] },
				"ts-common-all": { "deps": ["jQuery-easing", "ts-diagram-require-configurator"] },
				"ts-diagram": { "deps": ["ts-common-all", "jsrender"] },
				"process-schema-diagram": { "deps": ["ts-diagram"] },
				"process-schema-diagram-5x": { "deps": ["process-schema-diagram"] },
				"loadbootstrap": { "deps": ["classList-shim", "pathSeg-polyfill", "jQuery"] },
				"chartjs-label": { "deps": ["chartjs"] },
				"chartjs-defaults": { "deps": ["chartjs-label"] },
				"chartjs-funnel": { "deps": ["chartjs"] },
				"chartjs-gauge": { "deps": ["chartjs"] },
				"ng-core": { "deps": ["ng-scripts"] },
				"ng-scripts": { "deps": ["ng-polyfills", "ng-polyfill-webcomp"] },
				"user-agent": { "deps": [ "user-agent-parser" ] },
				"@creatio/utils": { "deps": [ "@creatio-devkit/common" ] },
				"process-designer-component": {
					"deps": ["mf!process-designer-component-mf", "css-ltr!process-designer-component-styles"]
				},
				"voice-to-text-component": {
					"deps": ["mf!voice-to-text-component-mf"]
				},
				"ckeditor-base": {
					exports: "CKEDITOR",
					init: function () {
						window.CKEDITOR.disableAutoInline = true;
						return window.CKEDITOR;
					}
				}
			},
			map: {
				'*': {
					'ej-diagram': 'ts-diagram'
				}
			},
			urlArgs: cacheBustingQueryString,
			baseUrl: baseUrl
		});
	}

	async function loadInDebugMode() {
		const requireUrl = baseUrl + buildCoreResourceUrl("requirejs/require.js");
		const bootstrapUrl = getLoadBootstrapUrl();
		await loadStaticScriptWithUrl(requireUrl);
		const coreUrl = baseUrl + coreResourcesPath;
		const config = {
			baseUrl: coreUrl + "Terrasoft/amd/"
		};
		if (Terrasoft?.addHashToScriptUrl) {
			config.urlArgs = cacheBustingQueryString;
		}
		requirejs.config(config);
		Terrasoft.scriptVersionPath = Terrasoft.scriptVersionPath || { jQuery: "jQuery/jQuery-3.7.1" };
		require([baseUrl + bootstrapUrl + ".js"], void 0);
	}

	function getIsRtlMode() {
		const resources = Terrasoft.Resources;
		const cultureSettings = resources && resources.CultureSettings;
		const isRtlMode = cultureSettings && cultureSettings.isRightToLeft;
		return Boolean(isRtlMode);
	}

	async function loadInReleaseMode() {
		const classicUICoreBaseUrlAttributeValue = getBootstrapLoaderScriptDataAttribute('7x-core-baseurl');
		const classicUICoreBaseUrl =
			(classicUICoreBaseUrlAttributeValue ? classicUICoreBaseUrlAttributeValue + "/" : baseUrl).replace(/\/\/$/, '/');
		const fileApiPath = getFileApiPath();
		const cssFileName = getIsRtlMode()
			? "combined/all-combined-rtl.css"
			: "combined/all-combined.css";
		await Promise.all([
			loadCssLinkWithUrl(classicUICoreBaseUrl + buildCoreResourceUrl(cssFileName)),
			loadStaticScriptWithUrl(classicUICoreBaseUrl + buildCoreResourceUrl(fileApiPath) + ".js"),
			loadStaticScriptWithUrl(classicUICoreBaseUrl + buildCoreResourceUrl("combined/all-combined.js"))
		]);
		const requireUrl = classicUICoreBaseUrl + buildCoreResourceUrl("requirejs/require.js");
		await loadStaticScriptWithUrl(requireUrl);
		configureRequireJs();
		require(["loadbootstrap"], void 0);
	}

	async function loadClientScript() {
		const useFetch = getBootstrapLoaderScriptDataAttribute("fetch-client-script") === "true";
		if (useFetch) {
			await fetchAndLoadScript(getClientScriptEndpointUrl());
		} else {
			const version = getBootstrapLoaderScriptDataAttribute("version") || "0.0.0.0";
			await loadStaticScriptWithUrl(getClientScriptEndpointUrl(), version);
		}
	}

	async function main() {
		await loadClientScript();
		if (!window.Terrasoft) {
			throw new Error("The global object 'Terrasoft' is not initialized yet, the page can not be loaded.")
		}
		coreResourcesPath = Terrasoft.coreModulesPath || "";
		const cacheBustingQueryParam = Terrasoft.resourceHash
			? Terrasoft.resourceHash
			: Terrasoft.coreVersion || "0.0.0.0"
		cacheBustingQueryString = buildCacheBustingQueryString(cacheBustingQueryParam);
		if (Terrasoft.isDebug) {
			await loadInDebugMode();
		} else {
			await loadInReleaseMode();
		}
	}

	main().catch(error => {
		console.error("Error during bootstrap loading: ", error);
	});
})();
