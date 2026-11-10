Ext.define("Terrasoft.mixins.CustomEventDomMixin", {
	alternateClassName: "Terrasoft.CustomEventDomMixin",
	statics: {
		/**
		 * Used to filter messages dispatched from same application.
		 * @type {string}
		 */
		appId: "",

		/**
		 * Listens for custom events with this name.
		 * @type {string}
		 */
		customEventName: "TSCustomEventChannel",

		/**
		 * Collection of streams of subscribed and received event types.
		 * @type {Object}
		 */
		eventObservers: {},

		/**
		 * Object that represents a disposable execution of an Observable.
		 * @protected
		 * @type {Object}
		 */
		customEventSubscriber: null,

		/**
		 * Collection of mixin instance ids.
		 * @protected
		 * @type {Object}
		 */
		instanceIds: [],
	},

	/**
	 * Used to filter messages subscribed from same instance.
	 * @private
	 * @type {string}
	 */
	_instanceId: "",

	/**
	 * Initializes an instance of the class
	 * @protected
	 */
	constructor: function() {
		this._instanceId = Terrasoft.generateGUID("N");
		Terrasoft.CustomEventDomMixin.instanceIds.push(this._instanceId);
	},

	/**
	 * Starts to listen custom events.
	 * @param {String} [appId] Custom events with same appId is ignored.
	 */
	init: function(appId) {
		this._instanceId = this._instanceId || Terrasoft.generateGUID("N");
		Terrasoft.appendIf(Terrasoft.CustomEventDomMixin.instanceIds, this._instanceId);
		if (Terrasoft.CustomEventDomMixin.appId === "") {
			Terrasoft.CustomEventDomMixin.appId = appId || Terrasoft.generateGUID("N");
			const {fromEvent, operators: {filter, map}} = Terrasoft.RX;
			const eventObservers = Terrasoft.CustomEventDomMixin.eventObservers;
			const customEventObserver$ = fromEvent(document, Terrasoft.CustomEventDomMixin.customEventName);
			Terrasoft.CustomEventDomMixin.customEventSubscriber = customEventObserver$.pipe(
				filter((event) => event.detail.sender !== Terrasoft.CustomEventDomMixin.appId),
				map((event) => event.detail)
			).subscribe((eventDetail) => {
				const eventName = eventDetail.eventName;
				eventObservers[eventName] = eventObservers[eventName] || {};
				Terrasoft.each(Terrasoft.CustomEventDomMixin.instanceIds, (instanceId) => {
					if (!eventObservers[eventName][instanceId]) {
						eventObservers[eventName][instanceId] = new Terrasoft.RX.ReplaySubject(1);
					}
				});
				Terrasoft.each(eventObservers[eventName], (observer) => {
					observer.next(eventDetail.payload);
				});
			});
		}
	},

	/**
	 * Publishes message to custom event.
	 * @public
	 * @param {String} eventType Subscribers for this event type will get message.
	 * @param {String} [payload] Data to sent in message.
	 */
	publish: function(eventType, payload) {
		const event = new CustomEvent(
			Terrasoft.CustomEventDomMixin.customEventName,
			{detail: {eventName: eventType, sender: Terrasoft.CustomEventDomMixin.appId, payload: payload}}
		);
		document.dispatchEvent(event);
	},

	/**
	 * Subscribes for messages of custom events.
	 * @public
	 * @param {String} eventType Receive messages for this custom event type.
	 * @param {Boolean} [replay=False] Replay last event to new subscriber.
	 * @return {Observable} Returns observable what emits messages for subscribed event type.
	 */
	subscribe: function(eventType, replay = false) {
		const eventObservers = Terrasoft.CustomEventDomMixin.eventObservers;
		eventObservers[eventType] = eventObservers[eventType] || {};
		const eventObserver = eventObservers[eventType];
		if (!eventObserver[this._instanceId]) {
			eventObserver[this._instanceId] = replay ? new Terrasoft.RX.ReplaySubject(1) : new Terrasoft.RX.Subject();
		}
		return eventObserver[this._instanceId].asObservable();
	},

	/**
	 * Subscribes handler for messages of custom events in zone.
	 * @param {String} eventType Receive messages for this custom event type.
	 * @param {Function} handler Handler function.
	 * @param {Object} scope Execution context.
	 * @param {Boolean} [replay=False] Replay last event to new subscriber.
	 */
	subscribeHandler: function(eventType, handler, scope, replay = false) {
		this.subscribe(eventType, replay).subscribe(function() {
			Terrasoft.utils.executionZone.safeExecute(scope, handler.bind(scope, ...arguments));
		});
	},

	/**
	 * Subscribes messages from custom events to sandbox messages.
	 * @param {Object} sandbox  Sandbox.
	 * @param {String} message Sandbox message.
	 * @param {Function} dataMapFn Data map function.
	 * @param {Object} scope Execution context.
	 */
	subscribeOnSandbox: function(sandbox, message, dataMapFn = (data) => data, scope) {
		const {operators: {map}} = Terrasoft.RX;
		return this.subscribe(message).pipe(
			map((data) => sandbox.publish(message, data, [sandbox.id])),
			map((data) => dataMapFn.apply(scope || this, [data])),
			map((data) => this.publish(message, data) || data)
		);
	},

	/**
	 * Subscribes messages from sandbox and publish them as custom events.
	 * @param {Object} sandbox Sandbox.
	 * @param {Array} event Sandbox message.
	 * @return {Object} Returns cancelable(revocable) sandbox.publish proxy.
	 */
	publishOnSandbox: function(sandbox, event) {
		const self = Terrasoft.CustomEventDomMixin.prototype;
		const publish$ = new Terrasoft.RX.Subject();
		const {operators: {tap}} = Terrasoft.RX;
		sandbox.publish = new Proxy(sandbox.publish, {
			apply: (target, thisArg, argArray) => {
				const result = target.apply(thisArg, argArray);
				const message = argArray[0];
				if (event === message) {
					publish$.next(argArray);
				}
				return result;
			}
		});
		return publish$.pipe(tap((argArray)=>{
			self.publish.apply(this, [...argArray]);
		}));
	},

	/**
	 * Unsubscribe from events and reset init properties.
	 */
	destroy: function() {
		Terrasoft.each(Terrasoft.CustomEventDomMixin.eventObservers, (eventType) => {
			const instanceEventObserver = eventType[this._instanceId] || {};
			Terrasoft.each(instanceEventObserver.observers, (observer) => {
				if (observer) {
					observer.unsubscribe();
				}
			});
		});
		Terrasoft.each(Terrasoft.CustomEventDomMixin.eventObservers, (eventType) => {
			delete eventType[this._instanceId];
		});
		const indexOfInstanceId = Terrasoft.CustomEventDomMixin.instanceIds.indexOf(this._instanceId);
		if (indexOfInstanceId > -1) {
			Terrasoft.CustomEventDomMixin.instanceIds.splice(indexOfInstanceId, 1);
		}
	}
});