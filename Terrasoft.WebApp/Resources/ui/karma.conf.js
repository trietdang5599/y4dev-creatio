function coerceBooleanProperty(value) {
	return value != null && `${value}` !== 'false';
}
module.exports = function (config) {
	const frameworks = coerceBooleanProperty(config.parallel)
		? ["parallel", "jasmine", "requirejs"]
		: ["jasmine", "requirejs"];
	config.set({
		basePath: "",
		frameworks,
		files: [
			"./karma-dom-utils.js",
			"./Terrasoft/amd/core-modules-object.js",
			"./Terrasoft/amd/configuration-modules-object.js",
			"./Terrasoft/amd/base-bootstrap.karma.js",
			"./Terrasoft/amd/bootstrap.karma.js",
			{ pattern: "**/*.js", included: false },
			{ pattern: "**/*.less", included: false },
			{ pattern: "**/*.css", included: false },
			{ pattern: "**/*.png", included: false },
			{ pattern: "**/*.svg", included: false },
			{ pattern: "**/*.woff", included: false },
			{ pattern: "**/*.ttf", included: false }
		],
		exclude: [
			"coverage/**/*",
		],
		preprocessors: coerceBooleanProperty(config.coverage)
			? {
				"Terrasoft/controls/**/!(*.spec|tests|mixins/voice-to-text-button/voice-to-text-component/*).js": [
					"coverage"
				],
				"Terrasoft/designers/**/!(*.spec|tests|process-designer-component/*).js": [
					"coverage"
				],
				"Terrasoft/core/**/!(*.spec|tests).js": ["coverage"],
				"Terrasoft/data/**/!(*.spec|tests).js": ["coverage"],
				"Terrasoft/manager/**/!(*mock|*.spec|tests).js": ["coverage"],
				"Terrasoft/exporters/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/integration/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/utils/dom/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/utils/dragdrop/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/utils/syncfusion/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/process/**/!(*.spec|tests).js": ["coverage"],
				"Terrasoft/configuration/applicationinstall/**/!(*.spec|tests).js": [
					"coverage"
				],
				"Terrasoft/amd/**/!(*.spec|tests|two-factor/*).js": ["coverage"]
			}
			: {},
		reporters: ["spec", "summary", ...(coerceBooleanProperty(config.coverage) ? ["coverage"] : [])],
		specReporter: {
			suppressSkipped: true,
			suppressPassed: true
		},
		summaryReporter: {
			show: "failed",
			overviewColumn: true
		},
		port: 9876,
		failOnEmptyTestSuite: false,
		colors: true,
		logLevel: config.LOG_INFO,
		autoWatch: true,
		browsers: ["HeadlessChrome"],
		customLaunchers: {
			HeadlessChrome: {
				base: 'ChromeHeadless',
				flags: ['--no-sandbox']
			}
		},
		singleRun: false,
		concurrency: Infinity,
		coverageReporter: {
			type: "lcovonly",
			dir: "coverage/",
			file: "lcov.info",
			subdir: "."
		},
		client: {
			args: ["--grep", config.grep],
			captureConsole: false,
			jasmine: {
				random: false,
				failSpecWithNoExpectations: false,
				stopSpecOnExpectationFailure: false,
				stopOnSpecFailure: false,
			}
		},
		parallelOptions: {
			executors: 2,
			shardStrategy: "custom",
			customShardStrategy: function (config) {
				if (config.description.includes(".ui.")) {
					return config.shardIndex === config.executors - 1;
				} else {
					if (config.shardIndex === config.executors - 1) {
						return false;
					}
					window.parallelDescribeCount =
						window.parallelDescribeCount || 0;
					window.parallelDescribeCount++;
					return (
						window.parallelDescribeCount %
						(config.executors - 1) ===
						config.shardIndex
					);
				}
			}
		}
	});
};
