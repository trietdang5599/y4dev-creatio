CKEDITOR.plugins.add('creatiolink', {
	lang: 'en,ru',
	init: function (editor) {
		var lang = editor.lang.creatiolink;
		editor.ui.addButton('CreatioLink', {
			label: lang.tooltip,
			command: 'CreatioLink_Command',
			icon: CKEDITOR.plugins.getPath('creatiolink') + 'creatiolink.svg',
		});
		editor.addCommand('CreatioLink_Command', {
			exec: function (editor) {
				editor.fire('CreatioLinkClick', {}, editor);
			},
		});
		editor.setKeystroke( CKEDITOR.CTRL + 75 /*K*/, 'CreatioLink_Command' );
		editor.setKeystroke( CKEDITOR.CTRL + 76 /*L*/, 'CreatioLink_Command' );
		editor.on(
			'doubleclick',
			function (evt) {
				var element = evt.data.element.getAscendant({ a: 1, img: 1 }, true);
				if (element && !element.isReadOnly()) {
					if (element.is('a')) {
						editor.fire('CreatioLinkDoubleClick', { element }, editor);
						evt.stop();
					}
				}
			}.bind(this),
			null,
			null,
			0,
		);
		if (editor.contextMenu) {
			editor.contextMenu.addListener(function (element, selection) {
				if (!element.is('a')) {
					return null;
				}
				editor.contextMenu.removeAll();
				return null;
			});
		}
		CKEDITOR.plugins.creatiolink = {
			createRangeForLink: function (editor, link) {
				const range = editor.createRange();
				range.setStartBefore(link);
				range.setEndAfter(link);
				return range;
			},
			editLinksInSelection: function (editor, selectedElements, data) {
				const ranges = [];
				let element, i;
				for (i = 0; i < selectedElements.length; i++) {
					element = selectedElements[i];
					element.setAttributes({
						'data-cke-saved-href': data.url,
						href: data.url,
					});
					element.setText(data.linkText);
					ranges.push(this.createRangeForLink(editor, element));
				}
				editor.getSelection().selectRanges(ranges);
				this.setCursorPositionAtTheEndOfTheLink(editor);
			},
			insertLinksIntoSelection(editor, data) {
				const ranges = editor.getSelection().getRanges();
				const style = new CKEDITOR.style({
					element: 'a',
					attributes: {
						'data-cke-saved-href': data.url,
						href: data.url,
					},
				});
				const rangesToSelect = [];
				let range, text, nestedLinks, i, j;

				style.type = CKEDITOR.STYLE_INLINE;
				if (!data.linkText) {
					data.linkText = data.url;
				}
				for (i = 0; i < ranges.length; i++) {
					range = ranges[i];
					if (range.collapsed) {
						text = new CKEDITOR.dom.text(data.linkText, editor.document);
						range.insertNode(text);
						range.selectNodeContents(text);
					}
					nestedLinks = range._find('a');
					for (j = 0; j < nestedLinks.length; j++) {
						nestedLinks[j].remove(true);
					}
					style.applyToRange(range, editor);
					rangesToSelect.push(range);
				}
				editor.getSelection().selectRanges(rangesToSelect);
				this.setCursorPositionAtTheEndOfTheLink(editor);
			},
			setCursorPositionAtTheEndOfTheLink: function (editor) {
				const oldRanges = editor.getSelection().getRanges();
				const oldRange = oldRanges[oldRanges.length - 1];
				const newRange = editor.createRange();
				newRange.setStart(oldRange.endContainer, oldRange.endOffset);
				newRange.setEnd(oldRange.endContainer, oldRange.endOffset);
				editor.getSelection().selectRanges([newRange]);
				const element = editor.document.createElement('img', {
					attributes: {
						width: '0',
						height: '0',
					},
				});
				editor.insertElement(element);
				element.remove();
			},
			getSelectedLink: function (editor, returnMultiple) {
				var selection = editor.getSelection(),
					selectedElement = selection.getSelectedElement(),
					ranges = selection.getRanges(),
					links = [],
					link,
					range;
				if (!returnMultiple && selectedElement && selectedElement.is('a')) {
					return selectedElement;
				}
				for (var i = 0; i < ranges.length; i++) {
					range = selection.getRanges()[i];
					range.shrink(CKEDITOR.SHRINK_ELEMENT, true, { skipBogus: true });
					link = editor.elementPath(range.getCommonAncestor()).contains('a', 1);
					if (link && returnMultiple) {
						links.push(link);
					} else if (link) {
						return link;
					}
				}
				return returnMultiple ? links : null;
			},
			insertOrUpdateLink: function (data, editor) {
				const selectedlinkElements = this.getSelectedLink(editor, true);
				if (!selectedlinkElements.length) {
					this.insertLinksIntoSelection(editor, data);
				} else {
					this.editLinksInSelection(editor, selectedlinkElements, data);
				}
			},
		};
	},
});
