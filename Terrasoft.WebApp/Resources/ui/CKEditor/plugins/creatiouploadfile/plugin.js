CKEDITOR.plugins.add('creatiouploadfile', {
	requires: 'uploadwidget',

	init: function(editor) {
		CKEDITOR.fileTools.addUploadWidget(editor, 'uploadfile', {
			uploadUrl: 'url',	// this url will set on upload file service
			fileToElement: function(file) {
				const fileLink = new CKEDITOR.dom.element('a');
				fileLink.setText(file.name);
				fileLink.setAttribute('href', '#');
				fileLink.setAttribute('crt-uploaded-file-name', file.name);
				return fileLink;
			}
		});
	}
});
