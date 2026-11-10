/**
 * This Source Code Form is subject to the terms of the Mozilla
 * Public License, v. 2.0. If a copy of the MPL was not distributed
 * with this file, You can obtain one at https://mozilla.org/MPL/2.0/
 */

CKEDITOR.plugins.add('creatiotabletools', {
	lang: 'en,ru',
	requires: 'bpmonlinetabletools,contextmenu',
	init: function (editor) {
		var lang = editor.lang.creatiotabletools;
		editor.addCommand('CreateTable', {
			exec: function (editor) {
				const maxWidth = 500;
				const decreeseTableWidth = 12;
				const width = Math.min(editor.ui.contentsElement.$.getBoundingClientRect().width - decreeseTableWidth, maxWidth);
				var data = {
					info: {
						txtCols: "3",
						txtRows: "3",
						txtHeight: "",
						txtWidth: width + "px"
					}
				};
				CKEDITOR.plugins.bpmonlinetable.createTable(data, editor);
			},
		});

		editor.addMenuGroup('creatiotabletools');
		editor.addMenuItems({
			creatio_table: {
				label: lang.table.createTable || "Create table",
				icon: "CreateTable",
				group: "creatiotabletools",
				command: "CreateTable",
				order: 1
			},
			creatio_insert_menu: {
				label: lang.table.insert || "Insert",
				group: "creatiotabletools",
				getItems: function() {
					return {
						tablecolumn_insertLeft: this.state,
						tablecolumn_insertRight: this.state,
						tablerow_insertTop: this.state,
						tablerow_insertBelow: this.state
					}
				}
			},
			tablecolumn_insertLeft: {
				label: lang.column.insertLeft,
				group: 'creatiotabletools',
				command: 'columnInsertBefore',
			},

			tablecolumn_insertRight: {
				label: lang.column.insertRight,
				group: 'creatiotabletools',
				command: 'columnInsertAfter',
			},

			tablerow_insertTop: {
				label: lang.row.insertTop,
				group: 'creatiotabletools',
				command: 'rowInsertBefore',
			},

			tablerow_insertBelow: {
				label: lang.row.insertBelow,
				group: 'creatiotabletools',
				command: 'rowInsertAfter',
			},
			creatio_delete_menu: {
				label: lang.table.delete || "Delete",
				group: "creatiotabletools",
				getItems: function() {
					return {
						tablecolumn_delete: this.state,
						creatio_tablerow_delete: this.state,
						creatio_tabledelete: this.state
					}
				}
			},
			tablecolumn_delete: {
				label: lang.column.deleteColumn,
				group: 'creatiotabletools',
				command: 'columnDelete',
			},

			creatio_tablerow_delete: {
				label: lang.row.deleteRow,
				group: 'creatiotabletools',
				command: 'rowDelete',
			},
			creatio_tabledelete: {
				label: lang.table.deleteTable,
				group: "creatiotabletools",
				command: 'tableDelete',
			},
			tablecell_merge: {
				label: lang.cell.merge,
				group: 'creatiotabletools',
				command: 'cellMerge',
			},
			tablecell_unmerge: {
				label: lang.cell.unmerge,
				group: 'creatiotabletools',
				command: 'cellUnmerge',
			},
		});

		editor.ui.add("CreatioTable", CKEDITOR.UI_MENUBUTTON, {
			label: lang.toolbar,
			icon: "table",
			modes: {wysiwyg: 1},
			onMenu: function(element, selection, path) {
				var cell = path?.contains( { 'td': 1, 'th': 1 }, 1 );
				var isMergedCells = cell?.getAttribute('rowSpan') > 1 || cell?.getAttribute('colSpan');
				var state = cell && !cell.isReadOnly() ? CKEDITOR.TRISTATE_OFF : CKEDITOR.TRISTATE_DISABLED;
				return {
					creatio_table: CKEDITOR.TRISTATE_OFF,
					creatio_insert_menu: state,
					tablecell_merge: CKEDITOR.plugins.bpmonlinetabletools.mergeCells( selection, null, true ) ? CKEDITOR.TRISTATE_OFF : CKEDITOR.TRISTATE_DISABLED,
					tablecell_unmerge: isMergedCells ? CKEDITOR.TRISTATE_OFF : CKEDITOR.TRISTATE_DISABLED,
					creatio_delete_menu: state,
				};
			}
		});
	},
});
