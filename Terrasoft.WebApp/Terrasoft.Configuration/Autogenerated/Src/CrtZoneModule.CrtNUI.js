 define("CrtZoneModule", ["@creatio-devkit/common", "terrasoft"], function (devkit, Terrasoft) {
	let _isInitialized = false;
	const handlerChain = devkit.HandlerChainService.instance;

	function init() {
		if (!_isInitialized) {
			initHandler();
			_isInitialized = true;
		}
	}

	 function initHandler() {
		 const handlerType = class extends devkit.BaseRequestHandler {
			 _handleCrtZoneServiceRequest(request) {
				 if (request.method !== "runOutside") {
					 console.warn(`${request.method} is not supported yet`);
					 return;
				 }
				 const callback = request.args[0];
				 if (typeof callback === "function") {
					 return callback();
				 }
			 }
			 handle(request) {
				 if (Terrasoft.isAngularHost) {
					 return this.next?.handle(request);
				 }
				 return this._handleCrtZoneServiceRequest(request);
			 }
		 };
		 handlerChain.register({
			 requestType: "crt.ZoneService",
			 createHandler: () => new handlerType(),
			 scopes: [],
			 source: { type: devkit.HandlerSourceType.Host },
		 });
	 }

	return {
		"init": init
	};
 })