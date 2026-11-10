(function(global) {
	requirejs.config({
		waitSeconds: 240,
		paths: {
			"ext-base": "ExtJs/extjs-base-debug",
			"json-applier-differ-mock":
				"Terrasoft/utils/common/tests/json-applier-differ-mock",
			"data-manager-item-mock":
				"Terrasoft/manager/data-manager/tests/data-manager-item-mock",
			"schema-manager-data-provider-mock":
				"Terrasoft/manager/tests/schema-manager-data-provider-mock",
			"data-manager-methods-mock":
				"Terrasoft/manager/data-manager/tests/data-manager-methods-mock",
			"service-provider-mock": "Terrasoft/core/service-provider-mock",
			"process-module-utilities-mock":
				"Terrasoft/designers/process-schema-designer/tests/process-module-utilities-mock",
			"sys-settings-mock": "Terrasoft/core/tests/sys-settings-mock",
			"ajax-provider-mock": "Terrasoft/core/tests/ajax-provider-mock",
			"require-url-config": "Terrasoft/amd/require-url-config",
			"xmlhttprequest-mock": "Terrasoft/core/tests/xmlhttprequest-mock",
			"xml-http-request-mock": "Terrasoft/core/tests/xml-http-request-mock",
			"process-diagram-requests-mock": "Terrasoft/process/tests/process-diagram-requests-mock",
			"process-flow-element-schema-manager-mock":
				"Terrasoft/controls/diagram/tests/process-flow-element-schema-manager-mock",
			"core-base": "Terrasoft/amd/core-base",
			crtrxjs: "Terrasoft/amd/crtrxjs",
			performancecountermanager:
				"Terrasoft/amd/performancecountermanager",
			bootstrap: "Terrasoft/amd/bootstrap",
			performanceLogger: "./Terrasoft/amd/performanceLogger",
			dragMock: "node_modules/drag-mock/dist/drag-mock.min",
			"login-model-utils": "Terrasoft/amd/login-model-utils"
		},
		shim: {
			"ext-base": {
				exports: "Ext"
			},
			"login-model-utils": {
				deps: ["ext-base"]
			},
			"data-manager-item-mock": {
				deps: ["json", "base-view-model", "data-manager-item"]
			},
			"schema-manager-data-provider-mock": {
				deps: [
					"schema-manager-data-provider",
					"entity-schema",
					"entity-schema-request"
				]
			},
			"data-manager-methods-mock": {
				deps: ["data-manager-item-mock", "core-resources"]
			},
			"service-provider-mock": {
				deps: ["service-provider"]
			},
			"process-module-utilities-mock": {
				deps: ["ext-base"]
			},
			"requirejs/less-loader!Terrasoft/controls/sidebar/sidebar": {
				deps: ["core-resources"]
			},
			"sys-settings-mock": {
				deps: ["sys-settings"]
			},
			"ajax-provider-mock": {
				deps: ["ajax-provider"]
			},
			"process-flow-element-schema-manager-mock": {
				deps: ["ext-base", "process-flow-element-schema-manager"]
			}
		}
	});
	global.Bootstrap.init(global.coreModules, "/base");
	const allTestFiles = [];
	const testType = window.__karma__.config.args[1] || "ui|unit|integration";
	const TEST_REGEXP = new RegExp(`(${testType})\.spec\.js$`); //i;
	Object.keys(window.__karma__.files).forEach(function(file) {
		if (TEST_REGEXP.test(file)) {
			const normalizedTestModule = file.replace(/^\/base\/|\.js$/g, "");
			allTestFiles.push(normalizedTestModule);
		}
	});
	require([
		"json-applier-differ-mock",
		"ext-base",
		"baseobject",
		"sys-settings",
		"features",
		"base-css",
		"normalize-css",
		"package-manager",
		"exceptions",
		"entity-schema-query",
		"base-manager",
		"messagebox",
		"json",
		"json-applier",
		"process-constants",
		"esq-expression-converter"
	], function(jsonApplierDifferMock) {
		window.jsonApplierDifferMock = jsonApplierDifferMock;
		const cachedSettings = Terrasoft.deepClone(Terrasoft.SysSettings.cachedSettings);
		const cachedFeatures = Terrasoft.deepClone(Terrasoft.Features);
		const sysValues = Terrasoft.deepClone(Terrasoft.process.constants.SYS_VARIABLES);
		let cachedValues;

		beforeEach(() => {
			cachedValues = Terrasoft.deepClone(Terrasoft.SysValue) || cachedValues;
			const elements = Array.from(document.body.children).filter(x =>
				x.tagName !== "SCRIPT" &&
				x.tagName !== "LINK" &&
				!x.classList.contains("ts-messagebox-box")
			);
			Terrasoft.each(elements, (el) => {
				document.body.removeChild(el);
			});
		});

		afterEach(() => {
			Terrasoft.SysSettings.cachedSettings = Terrasoft.deepClone(cachedSettings);
			Terrasoft.process.constants.SYS_VARIABLES = Terrasoft.deepClone(sysValues);
			Terrasoft.Features = Terrasoft.deepClone(cachedFeatures);
			Terrasoft.SysValue = Object.assign({}, {
				CURRENT_USER_CULTURE: {
					displayValue: "ru-RU"
				},
				PRIMARY_CULTURE: {
					displayValue: "ru-RU"
				}
			}, Terrasoft.deepClone(cachedValues));
			Terrasoft.workspaceBaseUrl = "";
			Terrasoft.PackageManager.currentPackageUId = null;
			Terrasoft.EntitySchemaQuery.cache = {};
			Terrasoft.EntitySchemaQuery._bundleSchemaCache = {};
			const managers = Object.values(Ext.ClassManager.classes).filter(
				x => x instanceof Terrasoft.BaseManager
			);
			Terrasoft.each(managers, (manager) => {
				try {
					manager.clear();
				} catch {
					let type = "Terrasoft.Collection";
					if (manager.items && manager.items.$className) {
						type = manager.items.$className;
					}
					manager.items = Ext.create(type, {});
				}
				manager.isInitialized = false;
			});
			if (Terrasoft.MessageBox) {
				try {
					Terrasoft.MessageBox.setVisible(false);
				} catch {
				}
			}
		});
		const testDataMap = {};
		global.getRootTest = function(key) {
			if (!testDataMap.hasOwnProperty(key)) {
				testDataMap[key] = {
					data: {}
				};
			}
			return testDataMap[key];
		};
		document.body.style.height = "100%";
		document.body.style.width = "100%";
		// document.body.style["pointer-events"] = "none";
		const html = document.querySelector("html");
		html.style.height = "100%";
		html.style.width = "100%";
		requirejs.onError = function(err) {
			console.error(err);
		};
		jasmine.getEnv().allowRespy(true);
		require.config({
			baseUrl: "/base",
			deps: allTestFiles,
			callback: window.__karma__.start,
			catchError: true
		});
	});
})(this);
