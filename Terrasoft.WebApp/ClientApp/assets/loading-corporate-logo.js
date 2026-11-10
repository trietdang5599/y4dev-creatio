(function () {
	const sysSettingsResourceUrl = 'img/terrasoft.axd?s=nui-binary-syssetting&r=ConfigurationPageLogoImage';

	function addPathEndSlash(path) {
		if (!path.endsWith('/')) {
			path += '/';
		}
		return path;
	}

	function trimSlashes(path) {
		return path.replace(/(^([/\\])+)|(([/\\])+$)/, '');
	}

	function joinPath(...pathParts) {
		return pathParts.map((path) => trimSlashes(path)).join('/');
	}

	function getUrl() {
		var pathName = location.pathname;
		var matches = pathName.match(/.*?\/\d\/?/);
		if (matches && matches.length === 1) {
			pathName = addPathEndSlash(matches[0]);
		} else {
			pathName = '';
		}
		return joinPath(location.origin, pathName);
	}

	function isNetCoreLicenseManagerLoginRoute() {
		return location.hash.startsWith('#/LicenseManager?mode=login') && !location.pathname.includes('/0/');
	}

	window.addEventListener(
		'DOMContentLoaded',
		() => {
			if (isNetCoreLicenseManagerLoginRoute()) {
				return;
			}
			const logoUrl = getUrl();
			const backgroundImageUrl = `${logoUrl}${sysSettingsResourceUrl}`;
			document.body.style.backgroundImage = `url(${backgroundImageUrl})`;
		},
		false,
	);
})();
