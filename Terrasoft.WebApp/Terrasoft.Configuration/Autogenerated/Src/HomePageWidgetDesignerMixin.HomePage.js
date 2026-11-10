define("HomePageWidgetDesignerMixin", ["ext-base", "WidgetEnums"], function(Ext) {
	Ext.define("Terrasoft.configuration.mixins.HomePageWidgetDesignerMixin", {
		alternateClassName: "Terrasoft.HomePageWidgetDesignerMixin",

		isPopupOpened: false,

		titleResourceKeySuffix: "_title",

		//region Methods: Public

		hideDesignerLoadingMask: function() {
			const body = Ext.getBody();
			body.set({"maskState": "none"});
		},

		/**
		 * Gets the value from the resources by pattern.
		 */
		getResourceValue: function(resourcePattern) {
			const pattern = /^\#Resource[^(]+\(([^)]+)\)\#$/;
			if (pattern.test(resourcePattern)) {
				const resourceKey = resourcePattern.match(pattern)[1];
				const resources = this.get("Resources");
				const widgetResources = resources?.strings[resourceKey] ?? {};
				const currentCultureResources = widgetResources[Terrasoft.currentUserCultureName];
				const defaultCultureResources = widgetResources[Terrasoft.SysValue.PRIMARY_LANGUAGE.code];
				return currentCultureResources ?? defaultCultureResources ?? '';
			} else {
				return resourcePattern;
			}
		},

		/**
		 * Upsert the resource for current location except the value is not falsy and not setted for the first time.
		 * If resource is successfully setted returns true, if not - false.
		 */
		upsertResource: function(key, value) {
			const resources = this.get("Resources");
			const isFirstSet = !resources.strings[key];
			const valueIsEmpty = !value;
			const skipSetResource = isFirstSet  && valueIsEmpty;
			if (skipSetResource) {
				return false;
			}
			resources.strings[key] = resources.strings[key] || {};
			resources.strings[key][Terrasoft.currentUserCultureName] = value;
			this.setResources(resources);
			return true;
		},

		/**
		 * Sets the resources.
		 */
		setResources(resources) {
			this.set("Resources", resources ?? {});
		},

		getPatternLocalizedString: function(resourceKey) {
			return `#ResourceString(${resourceKey})#`;
		},

		getWidgetThemeDefaultConfig: function() {
			return Terrasoft.WidgetEnums.WidgetTheme;
		},
		
		prepareWidgetThemeList: function(filter, list) {
			this.reloadList(list, this.getWidgetThemeDefaultConfig());
		},

		reloadList: function(list, items) {
			if (list === null) {
				return;
			}
			list.clear();
			list.loadAll(items);
		},

		widgetColorVisibilityConverter: function (value) {
			return value?.value !== Terrasoft.WidgetEnums.WidgetTheme.glassmorphism?.value;
		},
			
		//endregion

	});
	return Ext.create("Terrasoft.HomePageWidgetDesignerMixin");
});
