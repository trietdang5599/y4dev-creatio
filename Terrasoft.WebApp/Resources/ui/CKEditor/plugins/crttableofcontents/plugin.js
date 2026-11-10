CKEDITOR.plugins.add('crttableofcontents', {
    lang: 'en,ru',
    init: function (editor) {
        const lang = editor.lang.crttableofcontents;
        editor.addCommand('insertTableOfContents', {
            exec: function (editor) {
                editor.fire('CrtInsertTableOfContentsPlaceholder', {}, editor);
            }
        });
        editor.ui.addButton('CrtTableOfContents', {
            label: lang.title,
            command: 'insertTableOfContents',
            toolbar: 'insert',
			icon: CKEDITOR.plugins.getPath('crtTableOfContents') + 'icon.svg',
        });
    }
});
