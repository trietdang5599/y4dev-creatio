CKEDITOR.plugins.add('creatiovideo', {
	lang: 'en,ru',
	init: function (editor) {
		var lang = editor.lang.creatiovideo;
		editor.ui.addButton('CreatioVideo', {
			label: lang.tooltip,
			command: 'CreatioVideo_Command',
			icon: CKEDITOR.plugins.getPath('creatiovideo') + 'creatiovideo.svg',
		});
		editor.addCommand('CreatioVideo_Command', {
			exec: function (editor) {
				editor.fire('CreatioVideoClick', {}, editor);
			},
		});
	},
});