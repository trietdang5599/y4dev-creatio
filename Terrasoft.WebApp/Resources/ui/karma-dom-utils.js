(function(global) {
	const getElement = element => {
		if (typeof element === "string") {
			return document.querySelector(element);
		} else if (element instanceof Array) {
			return document.elementFromPoint.apply(document, element);
		} else if (element instanceof Ext.dom.AbstractElement) {
			return element.dom;
		} else {
			return element;
		}
	};
	const getOffset = (element, [x, y]) => {
		const offset = (elementSize, value) => {
			if (typeof value === "string") {
				if (value.indexOf("%") > 0) {
					return (
						elementSize * (parseFloat(value.split("%")[0]) / 100)
					);
				} else {
					return parseFloat(value);
				}
			} else {
				return value;
			}
		};
		return [
			offset(element.offsetWidth, x),
			offset(element.offsetHeight, y)
		];
	};
	global.mouseState = {};
	global.mouseOut = function(element, callback, scope) {
		element = getElement(element);
		element.dispatchEvent(
			new MouseEvent("mouseout", {
				bubbles: true,
				cancelable: true
			})
		);
		Ext.callback(callback, scope);
	};
	global.scroll = function(element, callback, scope) {
		element = getElement(element);
		element.dispatchEvent(
			new MouseEvent("scroll", {
				bubbles: true,
				cancelable: true
			})
		);
		Ext.callback(callback, scope);
	};
	const mouseMove = function(element, x, y) {
		let currentX = 0,
			currentY = 0;
		let currentElement = document.body;
		const switchElement = newElement => {
			if (newElement !== currentElement) {
				global.mouseOut(currentElement);
				newElement.dispatchEvent(
					new MouseEvent("mouseenter", {
						bubbles: true,
						cancelable: true
					})
				);
				global.mouseOver(newElement);
				currentElement = newElement;
			}
		};
		while (currentX++ <= x) {
			const newElement = document.elementFromPoint.apply(document, [
				currentX,
				currentY
			]);
			switchElement(newElement);
		}
		while (currentY++ <= y) {
			const newElement = document.elementFromPoint.apply(document, [
				currentX,
				currentY
			]);
			switchElement(newElement);
		}
		const bounds = element.getBoundingClientRect();
		element = getElement([bounds.x + currentX, bounds.y + currentY]);
		element.dispatchEvent(
			new MouseEvent("mousemove", {
				clientX: bounds.x + currentX,
				clientY: bounds.y + currentY,
				view: global,
				bubbles: true,
				cancelable: true
			})
		);
	};
	global.mouseUp = function(
		element,
		options,
		offset = [0, 0],
		callback,
		scope
	) {
		if (!element) {
			element = global.mouseState.downElement;
		}
		const initialElement = element;
		element = getElement(element);
		offset = getOffset(element, offset);
		let { x, y } = element.getBoundingClientRect();
		if (initialElement instanceof Array) {
			x = initialElement[0];
			y = initialElement[1];
		} else {
			x += offset[0];
			y += offset[1];
		}
		const newElement = getElement([x, y]);
		if (newElement && initialElement instanceof Array) {
			element = newElement;
		}
		const event = new MouseEvent("mouseup", {
			bubbles: true,
			cancelable: true,
			clientX: x,
			clientY: y,
			...options
		});
		element.dispatchEvent(event);
		Ext.callback(callback, scope);
	};
	global.mouseDown = function(
		element,
		options,
		offset = [0, 0],
		callback,
		scope
	) {
		const initialElement = element;
		element = getElement(element);
		offset = getOffset(element, offset);
		let { x, y } = element.getBoundingClientRect();
		if (initialElement instanceof Array) {
			x = initialElement[0];
			y = initialElement[1];
		} else {
			x += offset[0];
			y += offset[1];
		}
		const newElement = getElement([x, y]);
		if (newElement && initialElement instanceof Array) {
			element = newElement;
		}
		const event = new MouseEvent("mousedown", {
			bubbles: true,
			cancelable: true,
			clientX: x,
			clientY: y,
			...options
		});
		element.dispatchEvent(event);
		global.mouseState.downElement = element;
		const bounds = element.getBoundingClientRect();
		global.mouseState.offset = [x - bounds.x, y - bounds.y];
		Ext.callback(callback, scope);
	};
	global.mouseOver = function(element, callback, scope) {
		element = getElement(element);
		element.dispatchEvent(
			new MouseEvent("mouseover", {
				bubbles: true,
				cancelable: true
			})
		);
		Ext.callback(callback, scope);
	};
	global.focus = function(element) {
		element = getElement(element);
		if (!element.getAttribute("tabindex") && element.tagName !== "INPUT") {
			element.setAttribute("tabindex", 1);
		}
		element.focus();
		element.dispatchEvent(
			new Event("focus", {
				bubbles: true,
				cancelable: true
			})
		);
	};
	global.moveCursorTo = function(element, callback, scope, offset = [0, 0]) {
		const initialElement = element;
		element = getElement(element);
		offset = getOffset(element, offset);
		if (initialElement instanceof Array) {
			offset = getOffset(
				element,
				offset.map((el, index) => el + initialElement[index])
			);
			element = document.body;
		}
		mouseMove(element, ...offset);
		Ext.callback(callback, scope);
	};
	global.moveMouseTo = function(element, callback, scope, offset = [0, 0]) {
		global.moveCursorTo.apply(this, arguments);
	};
	global.moveCursorBy = function(element, callback, scope, offset = [0, 0]) {
		global.moveCursorTo.apply(this, arguments);
	};
	global.moveMouseBy = function(element, callback, scope, offset = [0, 0]) {
		global.moveCursorTo.apply(this, arguments);
	};
	global.blur = function(element, callback, scope) {
		element = getElement(element);
		element.blur();
		element.dispatchEvent(
			new Event("blur", {
				cancelable: true,
				bubbles: true
			})
		);
		Ext.callback(callback, scope);
	};
	global.doubleClick = function(
		element,
		callback,
		scope,
		options = {},
		offset = [0, 0],
		simulateEvent = false
	) {
		global._click(
			"dblclick",
			element,
			callback,
			scope,
			options,
			offset,
			simulateEvent
		);
	};
	global.click = function(
		element,
		callback,
		scope,
		options = {},
		offset = [0, 0],
		simulateEvent = false
	) {
		global._click(
			"click",
			element,
			callback,
			scope,
			options,
			offset,
			simulateEvent
		);
	};
	global._click = function(
		event,
		element,
		callback,
		scope,
		options = {},
		offset = [0, 0],
		simulateEvent
	) {
		options = options || {};
		element = getElement(element);
		offset = getOffset(element, offset);
		element.scrollIntoView();
		const [offsetX, offsetY] = offset;
		const x = offsetX || element.offsetWidth / 2;
		const y = offsetY || element.offsetHeight / 2;
		if (document.activeElement !== element) {
			global.blur(document.activeElement);
		}
		if (!simulateEvent) {
			mouseMove(element, x, y);
		}
		options.clientX = x;
		options.clientY = y;
		if (!simulateEvent) {
			global.mouseDown(element, options, [x, y]);
		}
		global.focus(element);
		if (!simulateEvent) {
			global.mouseUp(element, options, [x, y]);
		}
		element.dispatchEvent(
			new MouseEvent(event, {
				bubbles: true,
				cancelable: true,
				...options
			})
		);
		Ext.callback(callback, scope);
	};
	const elementIsVisible = function(element) {
		if (element instanceof Ext.dom.AbstractElement) {
			element = element.dom;
		}
		return element && element.offsetWidth > 0 && element.offsetHeight > 0;
	};
	global.elementIsVisible = function(element) {
		expect(elementIsVisible(element)).toBeTruthy();
	};
	global.elementIsNotVisible = function(element) {
		expect(elementIsVisible(element)).toBeFalsy();
	};
	const hasCls = function(element, className) {
		if (element instanceof Ext.dom.AbstractElement) {
			element = element.dom;
		}
		return element && element.classList.contains(className);
	};
	global.hasCls = function(element, className) {
		expect(hasCls(element, className)).toBeTruthy();
	};
	global.hasNotCls = function(element, className) {
		expect(hasCls(element, className)).toBeFalsy();
	};
	const executeCommand = (element, command, events, options) => {
		const removeChar = backspace => {
			if (element.selectionEnd === element.selectionStart) {
				if (backspace) {
					element.value = element.value.slice(0, -1);
				}
			} else {
				const charArray = Array.from(element.value);
				charArray.splice(
					element.selectionStart,
					element.selectionEnd - element.selectionStart
				);
				element.value = charArray.reduce(
					(acc, char) => (acc += char),
					""
				);
			}
		};
		const commands = {
			"[CTRL]": {
				key: "Control",
				keyCode: 17
			},
			"[SHIFT]": {
				key: "ShiftLeft",
				keyCode: 16
			},
			"[ENTER]": {
				key: "Enter",
				keyCode: 13
			},
			"[ESCAPE]": {
				key: "Escape",
				keyCode: 27
			},
			"[TAB]": {
				key: "Tab",
				keyCode: 9
			},
			"[DOWN]": {
				key: "ArrowDown",
				keyCode: 40
			},
			"[UP]": {
				key: "ArrowUp",
				keyCode: 38
			},
			"[LEFT]": {
				key: "ArrowLeft",
				keyCode: 37
			},
			"[RIGHT]": {
				key: "ArrowRight",
				keyCode: 39
			},
			"[HOME]": {
				key: "Home",
				keyCode: 36
			},
			"[END]": {
				key: "End",
				keyCode: 35
			},
			"[DELETE]": {
				key: "Delete",
				keyCode: 46,
				removeChar: true
			},
			"[BACKSPACE]": {
				key: "Backspace",
				keyCode: 8,
				removeChar: true,
				backspace: true
			},
			"[SPACE]": {
				key: "Space",
				keyCode: 32
			}
		};
		if (command[0].toUpperCase() in commands) {
			const keyCommand = commands[command[0].toUpperCase()];
			Terrasoft.each(events, (event) => {
				element.dispatchEvent(
					new KeyboardEvent(event, {
						key: keyCommand.key,
						keyCode: keyCommand.keyCode,
						code: keyCommand.key,
						bubbles: true,
						cancelable: true,
						...options
					})
				);
				if (keyCommand.removeChar && event === "keypress") {
					removeChar(keyCommand.backspace);
				}
			});
		} else {
			throw new Terrasoft.InvalidOperationException(
				`Typing command ${command[0]} has not supported yet`
			);
		}
	};
	const getCommands = text => Array.from(text.matchAll(/\[[^\]]+\]/g));
	const changeInputValue = (element, text) => {
		if (element.selectionEnd === element.selectionStart) {
			element.value += text;
		} else {
			const charArray = Array.from(element.value);
			charArray.splice(
				element.selectionStart,
				element.selectionEnd - element.selectionStart,
				...Array.from(text)
			);
			element.value = charArray.reduce((acc, char) => (acc += char), "");
		}
	};
	global.type = function(element, type, callback, scope, options) {
		if (typeof callback !== "function") {
			options = callback;
		}
		const events = ["keydown", "keypress", "keyup"];
		element = getElement(element);
		if (element !== document.activeElement) {
			global.focus(element);
		}
		const commands = getCommands(type);
		for (let i = 0; i < type.length; ) {
			if (commands.some(x => x.index === i)) {
				const command = commands.find(x => x.index === i);
				executeCommand(element, command, events, options);
				i += command[0].length;
			} else {
				Terrasoft.each(events, (event) => {
					element.dispatchEvent(
						new KeyboardEvent(event, {
							key: type[i],
							keyCode:
								Ext.EventObjectImpl.prototype[
									type[i].toUpperCase()
								],
							code: type[i],
							bubbles: true,
							cancelable: true,
							...options
						})
					);
					if (event === "keypress") {
						changeInputValue(element, type[i]);
					}
				});
				i++;
			}
		}
		Ext.callback(callback, scope);
	};
	global.keyPress = function(element, text, callback, scope, options) {
		if (typeof callback !== "function") {
			options = callback;
		}
		const events = ["keydown", "keypress", "input", "keyup"];
		element = getElement(element);
		const commands = getCommands(text);
		for (let i = 0; i < text.length; ) {
			if (commands.some(x => x.index === i)) {
				const command = commands.find(x => x.index === i);
				executeCommand(element, command, events, options);
				i += command[0].length;
			} else {
				let word = text.substring(i);
				word = word.substring(
					word.indexOf("[") === -1 ? word.indexOf("[") : word.length
				);
				Terrasoft.each(events, (event) => {
					element.dispatchEvent(
						new KeyboardEvent(event, {
							key: word,
							keyCode:
								Ext.EventObjectImpl.prototype[
									word.toUpperCase()
								],
							code: word,
							bubbles: true,
							cancelable: true,
							...options
						})
					);
					if (event === "keypress") {
						changeInputValue(element, word);
					}
				});
				i += word.length;
			}
		}
		Ext.callback(callback, scope);
	};
	global.selectText = function(element, start, end, callback, scope) {
		element = getElement(element);
		if (["input", "textarea"].includes(element.tagName.toLowerCase())) {
			if (element.setSelectionRange) {
				element.setSelectionRange(
					start || 0,
					end || element.value.length
				);
			} else {
				const range = element.createTextRange();
				range.moveStart("character", start);
				range.moveEnd("character", end - el.value.length);
				range.select();
			}
			if (Ext.isGecko || Ext.isOpera) {
				global.focus(element);
			}
			element.dispatchEvent(
				new Event("select", {
					bubbles: true,
					cancelable: true
				})
			);
			Ext.callback(callback, scope);
		}
	};
	global.selectorExists = function(selector) {
		const el = document.querySelector(selector);
		expect(el).toBeTruthy();
	};
	global.selectorNotExists = function(selector) {
		const el = document.querySelector(selector);
		expect(el).toBeFalsy();
	};
	global.selectorCountIs = function(selector, element, count) {
		element = getElement(element);
		const elements = element.querySelectorAll(selector);
		expect(elements.length).toBe(count);
	};
	global.waitForSelector = function(selector, callback, scope) {
		const interval = setInterval(() => {
			const el = document.querySelector(selector);
			if (el) {
				clearInterval(interval);
				Ext.callback(callback, scope, [el]);
			}
		}, 10);
	};
	global.waitForFunctionResult = function(
		fn,
		callback,
		scope,
		timeout = 3000
	) {
		const timeoutRef = setTimeout(function() {
			console.error("Wait timeout exceeded");
		}, timeout);
		const interval = setInterval(() => {
			if (fn()) {
				clearInterval(interval);
				clearTimeout(timeoutRef);
				Ext.callback(callback, scope);
			}
		}, 10);
	};
	global.waitForFn = global.waitForFunctionResult;
	global.waitForDelay = function(delay, callback, scope) {
		setTimeout(() => Ext.callback(callback, scope), delay);
	};

	global.waitFor = function(config) {
		if (config.method) {
			global.waitForFunctionResult(
				config.method,
				config.callback,
				config.scope,
				config.timeout
			);
		} else if (config.selector) {
			global.waitForSelector(
				config.selector,
				config.callback,
				config.scope,
				config.timeout
			);
		}
	};

	global.isFiredWithSignature = function(target, event, validator) {
		let fired = false
		const fn = function(...args) {
			fired = validator(...args);
		};
		target.on(event, fn, target);
		return () => {
			target.un(event, fn, target);
			expect(fired).toBeTruthy();
		};
	};
	global.firesAtLeastNTimes = function(target, event, count) {
		let fires = 0;
		const fn = () => {
			fires++;
		};
		target.on(event, fn);
		return () => {
			target.un(event, fn);
			expect(fires).toBeGreaterThanOrEqual(count);
		};
	};
	global.firesOnce = function(target, event) {
		let fired = false;
		const handler = () => {
			if (fired) {
				throw new Error("Event has been already fired");
			} else {
				fired = true;
			}
		};
		target.on(event, handler);
		return () => {
			target.un(event, handler);
			return fired;
		};
	};
	global.wontFire = function(target, event) {
		target.on(event, () => {
			throw new Error("Event has been fired");
		});
	};
	global.livesOk = function(fn) {
		let success = true;
		try {
			fn();
		} catch {
			success = false;
		} finally {
			expect(success).toBeTruthy();
		}
	};
	global._throws = function(fn) {
		let exception;
		try {
			fn();
		} catch (e) {
			exception = e;
		}
		return exception;
	};
	global.throws = function(fn, exception) {
		let success = false;
		const throwedException = global._throws(fn);
		if (throwedException) {
			success = true;
			if (exception) {
				if (typeof exception === "string") {
					expect(throwedException.toString()).toContain(exception);
				} else if (exception instanceof RegExp) {
					expect(throwedException.toString()).toMatch(exception);
				} else {
					expect(throwedException).toBeInstanceOf(exception);
				}
			}
		}
		expect(success).toBeTruthy();
	};
	global.notThrows = function(fn, exception) {
		let success = true;
		const throwedException = global._throws(fn);
		if (
			(!exception && throwedException) ||
			(exception && !throwedException instanceof exception)
		) {
			success = false;
		}
		expect(success).toBeTruthy();
	};
	global.typeOf = function(value) {
		return Object.prototype.toString.call(value).slice(8, -1);
	};
	global.isaOk = function(instance, expectedClassName) {
		expect(
			Terrasoft.isInstanceOfClass(instance, expectedClassName)
		).toBeTruthy();
	};
	global.dragTo = function(
		source,
		target,
		callback,
		scope,
		options,
		dragOnly,
		sourceOffset,
		targetOffset
	) {
		const initialSource = source;
		const initialTarget = target;
		const initialTargetOffset = targetOffset || [0, 0];
		source = getElement(source);
		if (!sourceOffset) {
			const { x, y } = source.getBoundingClientRect();
			if (!sourceOffset && initialSource instanceof Array) {
				sourceOffset = [initialSource[0] - x, initialSource[1] - y];
			}
		}
		global.moveMouseTo(initialSource, null, this);
		global.mouseDown(source, null, sourceOffset);
		global.moveMouseTo(initialTarget, null, this);
		if (!dragOnly) {
			target = getElement(target);
			const { x, y } = target.getBoundingClientRect();
			if (initialTarget instanceof Array) {
				targetOffset = [
					initialTarget[0] + initialTargetOffset[0],
					initialTarget[1] + initialTargetOffset[1]
				];
			} else {
				if (initialTarget instanceof Array) {
					targetOffset = [x + targetOffset[0], y + targetOffset[1]];
				}
			}
			this.mouseUp(target, options, targetOffset);
		}
		Ext.callback(callback, scope);
	};
	global.simulateEvent = function(element, eventName, options = {}) {
		element = getElement(element);
		const event = new MouseEvent(eventName, {
			bubbles: true,
			cancelable: true,
			...options
		});
		element.dispatchEvent(event);
	};
})(this);
