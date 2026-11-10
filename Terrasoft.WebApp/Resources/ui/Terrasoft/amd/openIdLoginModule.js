define(["ext-base", "terrasoft", "login-view-utils", "login-model-utils"], function(Ext, Terrasoft, loginViewUtils,
																					loginModelUtils) {
	const _module = {};

	const renderView = function(renderTo) {
		// Class names for elements
		const headClass = "openid-login-label-logo";
		const loginOutsideContainerClass = "openid-login-outside-container";
		let logoImageUrl = Terrasoft.useConstLoginImageUrl
			? "/Login/logo.svg"
			: window.loginImageUrl;
		logoImageUrl = Ext.String.format("{0}{1}",
			Terrasoft.workspaceBaseUrl, logoImageUrl);
		// elements
		const logo = Ext.create("Terrasoft.ImageEdit", {
			readonly: true,
			classes: {
				wrapClass: [headClass]
			},
			imageSrc: logoImageUrl
		});
		_module.view = Ext.create("Terrasoft.Container", {
			id: "viewContainer",
			selectors: {
				wrapEl: "#viewContainer"
			},
			classes: {
				wrapClassName: [loginOutsideContainerClass]
			},
			items: [logo],
			renderTo: renderTo
		});
	};

	const prepareModel = function() {
		_module.model = Ext.create("Terrasoft.BaseViewModel", {
			values: {},
			columns: {},
			methods: {
				init: function() {
					if (loginModelUtils.tryShowAuthenticationErrorMsg(this.onOpenIdLoginError.bind(this))) {
						return;
					}
					Terrasoft.OpenIdStartSsoClientProvider.redirectToOpenIdAuthorizeEndpoint();
				},
				onOpenIdLoginError: function () {
					if (Terrasoft.openIdOnErrorRedirectUrl) {
						window.location.replace(Terrasoft.openIdOnErrorRedirectUrl);
					}
				}
			}
		});
	};

	return {
		renderTo: Ext.getBody(),
		render: function(renderTo) {
			loginModelUtils.checkOpenIdUnauthorized();
			prepareModel();
			_module.model.init();
			renderView(renderTo);
			_module.view.bind(_module.model);
		}
	};
});
