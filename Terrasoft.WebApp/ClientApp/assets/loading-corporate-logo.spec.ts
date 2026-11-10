describe('loading-corporate-logo', () => {
	let domContentLoadedHandler: EventListener | null;

	function loadScript(hash: string, pathname = '/ClientApp/'): void {
		jest.spyOn(window, 'location', 'get').mockReturnValue({
			hash,
			origin: 'http://localhost',
			pathname,
		} as unknown as Location);
		jest.spyOn(window, 'addEventListener').mockImplementation(((eventName, handler) => {
			if (eventName === 'DOMContentLoaded') {
				domContentLoadedHandler = handler as EventListener;
			}
		}) as typeof window.addEventListener);
		jest.isolateModules(() => {
			require('./loading-corporate-logo.js');
		});
		if (!domContentLoadedHandler) {
			throw new Error('DOMContentLoaded handler was not registered');
		}
		domContentLoadedHandler(new Event('DOMContentLoaded'));
	}

	beforeEach(() => {
		document.body.style.backgroundImage = '';
		domContentLoadedHandler = null;
		jest.resetModules();
	});

	afterEach(() => {
		jest.restoreAllMocks();
	});

	it('skips splash logo request for LicenseManager login route', () => {
		loadScript('#/LicenseManager?mode=login');

		expect(document.body.style.backgroundImage).toBe('');
	});

	it.each([
		['LicenseManager route without login mode', '#/LicenseManager'],
		['nested LicenseManager route', '#/LicenseManager/package-id'],
		['LicenseManager login route under /0/', '#/LicenseManager?mode=login', '/0/ClientApp/'],
		['other route', '#/WorkspaceExplorer'],
	])('keeps splash logo request for %s', (_caseName, hash, pathname = '/ClientApp/') => {
		loadScript(hash, pathname);

		expect(document.body.style.backgroundImage).toContain('ConfigurationPageLogoImage');
	});
});
