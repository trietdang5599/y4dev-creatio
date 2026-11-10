describe("voice-to-text-button.ui.spec", function() {
	let getRootTest;
	var memoEditMock;
	var preparePredictableListHandler;
	var textValue = "voice text";
	beforeAll(() => {
		getRootTest = window.getRootTest.bind(
			this,
			"voice-to-text-button.ui.spec.js"
		);
	});

	beforeAll(done =>
		require([
			"voice-to-text-button",
			"baseedit",
			"memoedit",
			"base-view-model"
		], () => {
			done();
		})
	);
	beforeEach(function() {
		spyOn(Terrasoft.Features, "getIsEnabled").and.returnValue(true);
		Terrasoft.currentUserCultureName = "ru-RU";
		memoEditMock = Ext.create("Terrasoft.MemoEdit", {
			renderTo: Ext.getBody(),
			width: "300px",
			enableVoiceToTextButton: true
		});
	});
	afterEach(function() {
	});
	describe("rendered", function() {
		it("control is rendered", function () {
			expect(Ext.query(".base-edit-voice-to-text").length).toBe(1);
		});
		it("custom css classes are applies", function () {
			Ext.create("Terrasoft.MemoEdit", {
				renderTo: Ext.getBody(),
				width: "300px",
				enableVoiceToTextButton: true,
				voiceToTextClasses: "test-style-class"
			});
			expect(Ext.query(".test-style-class").length).toBe(1);
		});
		it("culture is applied", function () {
			var voiceControl = Ext.query("ts-voice-to-text-button")[0];
			expect(voiceControl.getAttribute('language')).toBe("ru-RU");
		});
	});
	describe("setEnableVoiceToTextButton", function() {
		it("when set false - should hide component", function () {
			memoEditMock.setEnableVoiceToTextButton(false);
			expect(Ext.query(".base-edit-voice-to-text").length).toBe(0);
		});
	});
	describe("onSpeechRecognitionFinished", function() {
		it("when has no value - should set new value", function () {
			memoEditMock.onSpeechRecognitionFinished({
				browserEvent: {
					detail: textValue
				}
			});
			expect(memoEditMock.getValue()).toBe("Voice text");
		});
		it("when has no value - should set new value", function () {
			memoEditMock.setValue("Old value");
			memoEditMock.onSpeechRecognitionFinished({
				browserEvent: {
					detail: textValue
				}
			});
			expect(memoEditMock.getValue()).toBe("Old value. Voice text");
		});
	});
});
