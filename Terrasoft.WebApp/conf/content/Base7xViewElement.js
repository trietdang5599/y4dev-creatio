Terrasoft.configuration.Structures["Base7xViewElement"] = {innerHierarchyStack: ["Base7xViewElement"]};
define("Base7xViewElement", [], function() {
	class CrtBase7xViewElement extends HTMLElement {
		_ext;
		_terrasoft;
		_sandbox;
		_componentName;
		_renderTo;

		get componentName() {
			return this._componentName;
		}

		get ext() {
			return this._ext;
		}

		get terrasoft() {
			return this._terrasoft;
		}

		get sandbox() {
			return this._sandbox;
		}

		get renderTo() {
			return this._renderTo;
		}

		constructor(name) {
			super();
			this._componentName = name;
			this._renderTo = name + "_" + Terrasoft.generateGUID("N");
		}

		connectedCallback() {
			this.setAttribute("id", this._renderTo);
		}

		disconnectedCallback() {}

		initContext(callback, scope) {
			if (!this.componentName) {
				throw new Error("Name for web component module must be specified");
			}
			const core = require("core-base");
			const id = this.componentName + "_injected_" + Terrasoft.generateGUID("N");
			core.createContext(this.componentName, {"id": id, "moduleName": this.componentName + "Module"});
			require(["ext_" + id, "terrasoft_" + id, "sandbox_" + id], (Ext, Terrasoft, sandbox) => {
				this.onContextInited(Ext, Terrasoft, sandbox, callback, scope);
			}, this);
		}

		getMessages() {
			return {};
		}

		onContextInited(ext, terrasoft, sandbox, callback, scope) {
			this._ext = ext;
			this._terrasoft = terrasoft;
			this._sandbox = sandbox;
			const messages = this.getMessages();
			this.sandbox.registerMessages(messages);
			callback?.call(scope, ext, terrasoft, sandbox);
		}
	}

	return CrtBase7xViewElement;
});


