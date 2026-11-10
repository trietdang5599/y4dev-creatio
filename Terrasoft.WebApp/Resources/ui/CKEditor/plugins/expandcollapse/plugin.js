const minAmountOfButtons = 5;
const buttonsSpacing = 8;
const firstButtonWidth = 90;
const hideClass = 'item-hide';
let CKEditorCurrentInstanceName;
const editorToolbars = [];
const toolbarElements = [];
let toolbarFitsViewport = true;

CKEDITOR.plugins.add('expandcollapse',
{
	lang: 'en,ru',
	init: function (editor) {
		const lang = editor.lang.expandcollapse;
		editor.ui.addButton('Expand',
			{
				label: lang.expand,
				command: 'Expand',
				icon: CKEDITOR.plugins.getPath('expandcollapse') + 'expand.svg',
			});
		editor.addCommand('Expand', { exec: expandToolbar });

		editor.ui.addButton('Collapse',
			{
				label: lang.collapse,
				command: 'Collapse',
				icon: CKEDITOR.plugins.getPath('expandcollapse') + 'collapse.svg'
			});
		editor.addCommand('Collapse', { exec: collapseToolbar });

		editor.on('focus', () => initToolbar());
		editor.on('toggleToolbar', (e) => onToggleToolbar(e.data.display));
	}
});

function onToggleToolbar(display) {
	if (!CKEditorCurrentInstanceName) {
		initToolbar();
	}
	if(display) {
		toggleToolbar();
	} else {
		expandToolbar(false);
	}
}

function initToolbar() {
	CKEditorCurrentInstanceName = CKEDITOR.currentInstance?.name || CKEDITOR.instances[0]?.name;
	setEventsToButtons();
}

function toggleToolbar() {
	expandToolbar(false);
	collapseToolbar(false);
}

function setEventsToButtons () {
	getToolbarItems().forEach(item => {
		item.onfocus = (event) => {
			if(event.target.style.position === 'absolute') {
				if(event.currentTarget.id > event.relatedTarget.id) {
					getLastVisibleButton(event.relatedTarget.id).focus();
				} else {
					getPreviousVisibleButton().focus();
				}
			}
		}
	});
}

function collapseToolbar(refresh = true) {
	const outer = document.querySelector('.cke_toolbar');
	outer.style.width = '';
	const items = getToolbarItems();
	if(items?.length > 0) {
		let collapseStartIndex = getCollapseIndex(items[1]);
		collapseStartIndex = correctCollapseIndex(collapseStartIndex, items.length);
		const itemsToCollapse = items.slice(collapseStartIndex);
		hideSeparator(items, itemsToCollapse, collapseStartIndex);
		toggleItems(itemsToCollapse, true);
		if(collapseStartIndex < items.length - 1) {
			toggleItem(getExpandButton());
			if (toolbarFitsViewport) {
				changeButtonIcon('Expand', CKEDITOR.plugins.getPath('expandcollapse') + 'expand.svg');
				changeButtonIcon('Collapse', CKEDITOR.plugins.getPath('expandcollapse') + 'collapse.svg');
			} else {
				changeButtonIcon('Expand', CKEDITOR.plugins.getPath('expandcollapse') + 'expand_down.svg');
				changeButtonIcon('Collapse', CKEDITOR.plugins.getPath('expandcollapse') + 'collapse_up.svg');
				const outer = document.querySelector('.cke_toolbar');
				outer.style.width = window.getComputedStyle(outer).width;
			}
		}
		refreshToolbar(refresh);
		if (refresh) {
			getCkeditorCurrentInstance()?.toolbox.toolbars[0].items
				.find(item => item.button?.command === "Expand")?.focus();
		}
		window.dispatchEvent(new Event('scroll'));
	}
}

function isToolbarFitsViewport() {
	const maxWindowPercentUsage = 90;
	const viewPortWidth = window.innerWidth;
	const toolbarPaddings = getToolbarHorizontalPaddings();
	let toolbarElements = getToolbarElementSizes();
	let totalWidth = 0;
	toolbarElements.forEach(element => totalWidth += element.width);
	totalWidth = totalWidth + getToolbarGapSize() * toolbarElements.length;
	return viewPortWidth * maxWindowPercentUsage / 100 >= totalWidth + toolbarPaddings;
}

function getToolbarHorizontalPaddings() {
	const editor = getCkeditorCurrentInstance();
	if (!editor) {
		return 0;
	}
	const toolbarElement = document.querySelector(`#cke_${editor.name} .cke_top`);
	if (!toolbarElement) {
		return null;
	}
	const toolbarStyle = window.getComputedStyle(toolbarElement);
	return parseFloat(toolbarStyle.paddingLeft) + parseFloat(toolbarStyle.paddingRight) +
		2 * parseFloat(toolbarStyle.borderWidth);
}

function getToolbarGapSize() {
	const editor = getCkeditorCurrentInstance();
	if (!editor) {
		return 0;
	}
	const toolbarElement = document.querySelector(`#cke_${editor.name} .cke_toolbar`);
	if (!toolbarElement) {
		return 0;
	}
	return parseFloat(window.getComputedStyle(toolbarElement).gap) || 0;
}

function getToolbarElementSizes() {
	const elementSizes = [];
	const editor = getCkeditorCurrentInstance();
	if (!editor) {
		return [0];
	}
	const toolbarElement = document.querySelector(`#cke_${editor.name} .cke_top`);
	if (!toolbarElement) {
		return null;
	}
	const toolbarItems = toolbarElement.querySelectorAll(
		'.cke_button, .cke_toolbar_separator, .cke_combo'
	);

	toolbarItems.forEach((item) => {
		let type = 'unknown';
		if (item.classList.contains('cke_button')) {
			type = 'button';
		} else if (item.classList.contains('cke_toolbar_separator')) {
			type = 'separator';
		} else if (item.classList.contains('cke_combo')) {
			type = 'dropdown';
		}
		const size = {
			name: item.title || item.getAttribute('aria-label') || 'Unnamed',
			type: type,
			width: item.offsetWidth,
		};
		elementSizes.push(size);
	});

	return elementSizes;
}

function getCkeditorCurrentInstance() {
	return CKEDITOR.currentInstance || CKEDITOR.instances[CKEditorCurrentInstanceName];
}

function changeButtonIcon(buttonName, newIconPath) {
	let editor = getCkeditorCurrentInstance();
	if (!editor) {
		return;
	}
	const button = editor.ui.items[buttonName];
	const buttonId = `.cke_editor_${editor.name} .cke_button__${buttonName.toLowerCase()}`;
	const buttonElement = document.querySelector(buttonId);
	if (button && buttonElement) {
		button.icon = newIconPath;
		const iconElement = buttonElement.querySelector('.cke_button_icon');
		if (iconElement) {
			iconElement.style.backgroundImage = `url('${newIconPath}')`;
		}
	}
}

function expandToolbar(refresh = true) {
	const items = getToolbarItems();
	if(items?.length > 0) {
		toggleItems(items);
		toggleItem(getExpandButton(), true);
		refreshToolbar(refresh);
		if (refresh) {
			window.dispatchEvent(new Event('scroll'));
			getCkeditorCurrentInstance()?.toolbox.toolbars[0].items
				.find(item => item.button?.command === "Collapse")?.focus();
		}
		toolbarFitsViewport = isToolbarFitsViewport()
	}
}

function actualizeButtonsOrder() {
	const editor = getCkeditorCurrentInstance();
	if (!editor) {
		return;
	}
	const toolbar = editor.toolbox.toolbars[0];
	const toolbarButtons = [...document.querySelectorAll(`#cke_${editor.name} .cke_toolbar [role=button]`)];
	let hiddenButtonsIds = toolbarButtons.filter(x => x.classList.contains(hideClass)).map(element => element.id);
	const toolbarVisibleItems = toolbar.items.filter((item) => hiddenButtonsIds.indexOf(item.id) === -1);

	toolbarVisibleItems[0].previous = undefined;
	toolbarVisibleItems[0].next = toolbarVisibleItems.length > 1 ? toolbarVisibleItems[1] : undefined;
	toolbarVisibleItems[toolbarVisibleItems.length - 1].previous = toolbarVisibleItems.length > 1 ?
		toolbarVisibleItems[toolbarVisibleItems.length - 2] : undefined;
	toolbarVisibleItems[toolbarVisibleItems.length - 1].next = undefined;

	for (let i = 1; i < toolbarVisibleItems.length-1; i++) {
		toolbarVisibleItems[i].previous = toolbarVisibleItems[i-1];
		toolbarVisibleItems[i].next = toolbarVisibleItems[i+1];
	}
}

function refreshToolbar(refresh) {
	if(refresh) {
		const toolbar = getToolbar();
		// for Safari force re-render dom element after toolbar buttons visibility manipulation.
		// https://stackoverflow.com/questions/8840580/force-dom-redraw-refresh-on-chrome-mac
		toolbar.style.display = 'flex';
		setTimeout(() => {
			toolbar.style.display = 'block';
		}, 0);
	}
	actualizeButtonsOrder();
}

function getToolbar() {
	return document.querySelector('#cke_' + CKEditorCurrentInstanceName);
}

function getToolbarItems() {
	if(!editorToolbars[CKEditorCurrentInstanceName]) {
		const items = getToolbarElementByClass('cke_toolgroup')?.childNodes;
		editorToolbars[CKEditorCurrentInstanceName] = items ? Array.from(items) : null;
	}
	return editorToolbars[CKEditorCurrentInstanceName] || [];
}

function getToolbarElementByClass(className) {
	if(!toolbarElements[CKEditorCurrentInstanceName + className]) {
		toolbarElements[CKEditorCurrentInstanceName + className] = document.querySelector(`#cke_${CKEditorCurrentInstanceName} .${className}`)
	}
	return toolbarElements[CKEditorCurrentInstanceName + className];
}

function getExpandButton() {
	return getToolbarElementByClass('cke_button__expand');
}

function getPreviousVisibleButton() {
	const visibleItems = getToolbarItems().filter(x => !x.classList.contains(hideClass));
	return visibleItems[visibleItems.length - 2];
}

function getLastVisibleButton(id) {
	let visibleButton = getToolbarItems().findLast(x => !x.classList.contains(hideClass));
	if(visibleButton.id === id) {
		visibleButton = getToolbarElementByClass('cke_combo_button');
	}
	return visibleButton;
}

function toggleItems(items, hide = false) {
	items.forEach(item => {
		toggleItem(item, hide);
	});
}

function toggleItem(item, hide = false) {
	hide ? item.classList.add(hideClass) : item.classList.remove(hideClass);
	item.style.display = hide ? 'none' : '';
}

function getCollapseIndex(item) {
	const currentInstance = CKEDITOR.currentInstance || CKEDITOR.instances[CKEditorCurrentInstanceName];
	const currentEditorWidth = currentInstance.getResizable().getClientSize().width;
	const averageButtonWidth = parseInt(window.getComputedStyle(item).width.replace('px', ''));
	return Math.round((currentEditorWidth - firstButtonWidth) / (averageButtonWidth + buttonsSpacing)) - 1;
}

function correctCollapseIndex(collapseStartIndex, buttonsCount) {
	if(collapseStartIndex < minAmountOfButtons) {
		collapseStartIndex = minAmountOfButtons - 1;
	}
	if(collapseStartIndex >= buttonsCount - 4) {
		collapseStartIndex = buttonsCount - 1;
	}
	return collapseStartIndex;
}

function hideSeparator(items, itemsToCollapse, collapseStartIndex) {
	if(items[collapseStartIndex - 1].className === 'cke_toolbar_separator') {
		itemsToCollapse.unshift(items[collapseStartIndex - 1]);
	}
}
