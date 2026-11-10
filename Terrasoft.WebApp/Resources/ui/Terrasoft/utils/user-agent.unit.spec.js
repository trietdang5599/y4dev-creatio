describe("user-agent.unit.spec.js", () => {
	let getRootTest;
	let browser;

	beforeAll(() => {
		getRootTest = window.getRootTest.bind(this, "user-agent.unit.spec.js");
	});
	beforeAll(done => {
		const userAgentParserMock = {
			getBrowser: () => {
				return browser;
			},
		};
		define("user-agent-parser", [], () => {
			return function() {
				return userAgentParserMock;
			};
		});
		require(["user-agent"], () => done());
	});

	const testCases = [
		{
			browser: { name: "Chrome", major: "137" },
			expected: false,
		},
		{
			browser: { name: "Chrome", major: "138" },
			expected: true,
		},
		{
			browser: { name: "Chrome", major: "139" },
			expected: true,
		},
		{
			browser: { name: "Firefox", major: "139" },
			expected: false,
		},
		{
			browser: { name: "Firefox", major: "140" },
			expected: true,
		},
		{
			browser: { name: "Firefox", major: "141" },
			expected: true,
		},
		{
			browser: { name: "Safari", major: "17" },
			expected: false,
		},
		{
			browser: { name: "Safari", major: "18" },
			expected: true,
		},
		{
			browser: { name: "Safari", major: "19" },
			expected: true,
		},
		{
			browser: { name: "Edge", major: "137" },
			expected: false,
		},
		{
			browser: { name: "Edge", major: "138" },
			expected: true,
		},
		{
			browser: { name: "Edge", major: "139" },
			expected: true,
		},
		{
			browser: { name: "WebKit", major: "619" },
			expected: false,
		},
		{
			browser: { name: "WebKit", major: "620" },
			expected: true,
		},
		{
			browser: { name: "WebKit", major: "621" },
			expected: true,
		},
		{
			browser: { name: "Chrome WebView", major: "137" },
			expected: false,
		},
		{
			browser: { name: "Chrome WebView", major: "138" },
			expected: true,
		},
		{
			browser: { name: "Chrome WebView", major: "139" },
			expected: true,
		},
		{
			browser: { name: "?", major: "?" },
			expected: false,
		},
	];

	testCases.forEach(testCase => {
		describe(`when browser is ${testCase.browser.name} ${testCase.browser.major}`, () => {
			beforeEach(() => {
				browser = testCase.browser;
			});

			it("should return expected value", () => {
				expect(Terrasoft.utils.UserAgent.isBrowserSupported()).toBe(testCase.expected);
			});
		});
	});
});
