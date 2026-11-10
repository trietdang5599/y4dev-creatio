CKEDITOR.plugins.add('creatioImageFileUpload',
	{
		lang: 'en,ru',
		init: function (editor) {
			editor.addCommand('creatioImageFileUploadCommand', {
				allowedContent: {
					img: {
						attributes: '!src,srcset,alt,width,sizes'
					}
				},
				exec: chooseFile.bind(editor, 'image/*')
			});
			editor.addCommand('creatioFileUploadCommand', {
				exec: chooseFile.bind(editor, '*')
			});
			editor.ui.addButton('CreatioImageFileUploadButton', {
				label: editor.lang.creatioImageFileUpload.label,
				command: 'creatioImageFileUploadCommand'
			});
			editor.ui.addButton('CreatioFileUploadButton', {
				label: editor.lang.creatioImageFileUpload.file,
				command: 'creatioFileUploadCommand'
			});
			editor.element?.getParent()?.appendHtml('<input hidden type="file" class="rich_text_upload_input" multiple="multiple" id="upload_input_' + editor.name +'">');
		}
	});

function chooseFile(acceptTypes) {
	const hiddenUploadElement = this.document.findOne(`#upload_input_${this.name}`);
	if (!hiddenUploadElement) {
		return;
	}
	hiddenUploadElement.setAttribute('accept', acceptTypes);
	hiddenUploadElement.once('change', async (evt) => {
		const targetElement = evt.data.getTarget();
		const methodName = 'paste';
		if (acceptTypes === 'image/*') {
			Array.from(targetElement.$.files).forEach(async file => {
				try {
					const fileData = await readFile(file);
					this.fire(methodName, {
						method: methodName,
						dataValue: '\x3cimg crt-file-name\x3d"' + file.name + '" src\x3d"' + fileData + '" /\x3e',
						fileName: file.name,
						type: file.type
					});
				} catch (error) {
					console.error('Error reading file:', error);
				}
			});
		} else {
			this.fire(methodName, {
				method: methodName,
				dataValue: '',
				dataTransfer: new CKEDITOR.plugins.clipboard.dataTransfer({
					files: targetElement.$.files,
					types: ['Files'],
				}),
				type: acceptTypes
			});
		}
	});
	const onFocus = () => {
		window.removeEventListener('focus', onFocus);
		this.fire('CreatioImageWindowClose', {}, this);
	};
	hiddenUploadElement.$.addEventListener('click', () => {
		window.addEventListener('focus', onFocus);
	});
	this.fire('CreatioImageClick', {}, this);
	hiddenUploadElement.$.click();
	hiddenUploadElement.$.value = '';	
}

function readFile(file) {
	return new Promise((resolve, reject) => {
		const reader = new FileReader();

		reader.onload = function(e) {
			resolve(e.target.result);
		}

		reader.onerror = function(error) {
			reject(error);
		}

		reader.readAsDataURL(file);
	});
};