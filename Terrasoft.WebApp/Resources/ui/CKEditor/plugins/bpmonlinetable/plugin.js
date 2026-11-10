/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */

/**
 * This Source Code Form is subject to the terms of the Mozilla
 * Public License, v. 2.0. If a copy of the MPL was not distributed
 * with this file, You can obtain one at https://mozilla.org/MPL/2.0/
 */

CKEDITOR.plugins.add( 'bpmonlinetable', {
	requires: 'dialog,bpmonlinetabletools',
	// jscs:disable maximumLineLength
	lang: 'af,ar,az,bg,bn,bs,ca,cs,cy,da,de,de-ch,el,en,en-au,en-ca,en-gb,eo,es,es-mx,et,eu,fa,fi,fo,fr,fr-ca,gl,gu,he,hi,hr,hu,id,is,it,ja,ka,km,ko,ku,lt,lv,mk,mn,ms,nb,nl,no,oc,pl,pt,pt-br,ro,ru,si,sk,sl,sq,sr,sr-latn,sv,th,tr,tt,ug,uk,vi,zh,zh-cn', // %REMOVE_LINE_CORE%
	// jscs:enable maximumLineLength
	icons: 'bpmonlinetable', // %REMOVE_LINE_CORE%
	init: function( editor ) {
		if ( editor.blockless )
			return;
		var lang = editor.lang.table;

		editor.addCommand( 'table', new CKEDITOR.dialogCommand( 'bpmonlinetable', {
			context: 'table',
			allowedContent: 'table{width,height}[align,border,cellpadding,cellspacing,summary];' +
				'caption tbody thead tfoot;' +
				'th td tr[scope];' +
				( editor.plugins.dialogadvtab ? 'table' + editor.plugins.dialogadvtab.allowedContent() : '' ),
			requiredContent: 'table',
			contentTransformations: [
				[ 'table{width}: sizeToStyle', 'table[width]: sizeToAttribute' ],
				[ 'td: splitBorderShorthand' ],
				[ {
					element: 'table',
					right: function( element ) {
						if ( element.styles ) {
							var parsedStyle;
							if ( element.styles.border ) {
								parsedStyle = CKEDITOR.tools.style.parse.border( element.styles.border );
							} else if ( CKEDITOR.env.ie && CKEDITOR.env.version === 8 ) {
								var styleData = element.styles;
								// Workaround for IE8 browser. It transforms CSS border shorthand property
								// to the longer one, consisting of border-top, border-right, etc. We have to check
								// if all those properties exists and have the same value (#566).
								if ( styleData[ 'border-left' ] && styleData[ 'border-left' ] === styleData[ 'border-right' ] &&
									styleData[ 'border-right' ] === styleData[ 'border-top' ] &&
									styleData[ 'border-top' ] === styleData[ 'border-bottom' ] ) {

									parsedStyle = CKEDITOR.tools.style.parse.border( styleData[ 'border-top' ] );
								}
							}
							if ( parsedStyle && parsedStyle.style && parsedStyle.style === 'solid' &&
								parsedStyle.width && parseFloat( parsedStyle.width ) !== 0 ) {
								element.attributes.border = 1;
							}
							if ( element.styles[ 'border-collapse' ] == 'collapse' ) {
								element.attributes.cellspacing = 0;
							}
						}
					}
				} ]
			]
		} ) );

		function createDef( def ) {
			return CKEDITOR.tools.extend( def || {}, {
				contextSensitive: 1,
				refresh: function( editor, path ) {
					this.setState( path.contains( 'table', 1 ) ? CKEDITOR.TRISTATE_OFF : CKEDITOR.TRISTATE_DISABLED );
				}
			} );
		}

		editor.addCommand( 'tableProperties', new CKEDITOR.dialogCommand( 'bpmonlinetableProperties', createDef() ) );
		editor.addCommand( 'tableDelete', createDef( {
			exec: function( editor ) {
				var path = editor.elementPath(),
					table = path.contains( 'table', 1 );

				if ( !table )
					return;

				// If the table's parent has only one child remove it as well (unless it's a table cell, or the editable element)
				//(https://dev.ckeditor.com/ticket/5416, https://dev.ckeditor.com/ticket/6289, https://dev.ckeditor.com/ticket/12110)
				var parent = table.getParent(),
					editable = editor.editable();

				if ( parent.getChildCount() == 1 && !parent.is( 'td', 'th' ) && !parent.equals( editable ) )
					table = parent;

				var range = editor.createRange();
				range.moveToPosition( table, CKEDITOR.POSITION_BEFORE_START );
				table.remove();
				range.select();
			}
		} ) );

		CKEDITOR.dialog.add( 'bpmonlinetable', this.path + 'dialogs/table.js' );
		CKEDITOR.dialog.add( 'bpmonlinetableProperties', this.path + 'dialogs/table.js' );

		var bpmonlineLang = window.Terrasoft?.Resources?.ExternalLibraries?.CKEditor || {};
		editor.addMenuGroup("bpmonlinetable_group");
		editor.addMenuItems({
			table: {
				label: bpmonlineLang.CreateTable || "Create table",
				icon: "tablecreate",
				group: "bpmonlinetable_group",
				command: "table",
				order: 1
			},
			split_row: {
				label: lang.cell.splitHorizontal,
				icon: "split_row",
				group: "bpmonlinetable_group",
				command: "cellHorizontalSplit",
				order: 3
			},
			split_column: {
				label: lang.cell.splitVertical,
				icon: "split_column",
				group: "bpmonlinetable_group",
				command: "cellVerticalSplit",
				order: 4
			},
			insert: {
				label: bpmonlineLang.Insert || "Insert",
				icon: "tableinsert",
				group: "bpmonlinetable_group",
				order: 5,
				getItems: function() {
					return {
						insert_row_before: CKEDITOR.TRISTATE_OFF,
						insert_row_after: CKEDITOR.TRISTATE_OFF,
						insert_column_before: CKEDITOR.TRISTATE_OFF,
						insert_column_after: CKEDITOR.TRISTATE_OFF
					}
				}
			},
			insert_row_before: {
				icon: "tableinsert_rowbefore",
				label: lang.row.insertBefore,
				command: 'rowInsertBefore',
				group: 'bpmonlinetable_group',
				order: 10
			},
			insert_row_after: {
				icon: "tableinsert_rowafter",
				label: lang.row.insertAfter,
				command: 'rowInsertAfter',
				group: 'bpmonlinetable_group',
				order: 11
			},
			insert_column_before: {
				label: lang.column.insertBefore,
				icon: "tableinsert_columnbefore",
				group: 'bpmonlinetable_group',
				command: 'columnInsertBefore',
				order: 12
			},
			insert_column_after: {
				label: lang.column.insertAfter,
				icon: "tableinsert_columnafter",
				group: 'bpmonlinetable_group',
				command: 'columnInsertAfter',
				order: 13
			},
			tabledelete_menu: {
				label: bpmonlineLang.Delete || "Delete",
				icon: "tabledelete_menu",
				group: "bpmonlinetable_group",
				order: 6,
				getItems: function() {
					return {
						tablecell_delete: CKEDITOR.TRISTATE_OFF,
						tablerow_delete: CKEDITOR.TRISTATE_OFF,
						tabledelete: CKEDITOR.TRISTATE_OFF
					}
				}
			},
			tablerow_delete: {
				label: lang.row.deleteRow,
				icon: "tabledelete_row",
				group: 'bpmonlinetable_group',
				command: 'rowDelete',
				order: 15
			},
			tablecell_delete: {
				label: lang.column.deleteColumn,
				icon: "tabledelete_cell",
				group: 'bpmonlinetable_group',
				command: 'columnDelete',
				order: 16
			},
			tabledelete: {
				label: lang.deleteTable,
				icon: "tabledelete",
				group: 'bpmonlinetable_group',
				command: 'tableDelete',
				order: 17
			}

		});
		
		editor.ui.add("bpmonlinetable", CKEDITOR.UI_MENUBUTTON, {
			label: "",
			icon: "table",
			modes: {wysiwyg: 1},
			onMenu: function() {
				return {
					table: CKEDITOR.TRISTATE_OFF,
					merge: CKEDITOR.TRISTATE_OFF,
					split_row: CKEDITOR.TRISTATE_OFF,
					split_column: CKEDITOR.TRISTATE_OFF,
					insert: CKEDITOR.TRISTATE_OFF,
					tabledelete_menu: CKEDITOR.TRISTATE_OFF
				};
			}
		});
		
		CKEDITOR.plugins.bpmonlinetable = {
			createTable: function(config, editor) {
				var makeElement = function( name ) {
					return new CKEDITOR.dom.element( name, editor.document );
				};
				var selectedElement = this._ && this._.selectedElement;
				var selection = editor.getSelection(),
					bms = selectedElement && selection.createBookmarks();

				var table = selectedElement || makeElement( 'table' ),
					data = config || {};

				if (!config) {
					this.commitContent( data, table );
				}				
				table.setAttribute( 'border', 1 );
				table.addClass( 'creatio-editor-table', 1 );
				if ( data.info ) {
					var info = data.info;

					// Generate the rows and cols.
					if ( !selectedElement ) {
						var tbody = table.append( makeElement( 'tbody' ) ),
							rows = parseInt( info.txtRows, 10 ) || 0,
							cols = parseInt( info.txtCols, 10 ) || 0;

						for ( var i = 0; i < rows; i++ ) {
							var row = tbody.append( makeElement( 'tr' ) );
							for ( var j = 0; j < cols; j++ ) {
								var cell = row.append( makeElement( 'td' ) );
								cell.appendBogus();
							}
						}
					}

					// Modify the table headers. Depends on having rows and cols generated
					// correctly so it can't be done in commit functions.

					// Should we make a <thead>?
					var headers = info.selHeaders;
					if ( !table.$.tHead && ( headers == 'row' || headers == 'both' ) ) {
						var thead = table.getElementsByTag( 'thead' ).getItem( 0 );
						tbody = table.getElementsByTag( 'tbody' ).getItem( 0 );
						var theRow = tbody.getElementsByTag( 'tr' ).getItem( 0 );

						if ( !thead ) {
							thead = new CKEDITOR.dom.element( 'thead' );
							thead.insertBefore( tbody );
						}

						// Change TD to TH:
						for ( i = 0; i < theRow.getChildCount(); i++ ) {
							var th = theRow.getChild( i );
							// Skip bookmark nodes. (https://dev.ckeditor.com/ticket/6155)
							if ( th.type == CKEDITOR.NODE_ELEMENT && !th.data( 'cke-bookmark' ) ) {
								th.renameNode( 'th' );
								th.setAttribute( 'scope', 'col' );
							}
						}
						thead.append( theRow.remove() );
					}

					if ( table.$.tHead !== null && !( headers == 'row' || headers == 'both' ) ) {
						// Move the row out of the THead and put it in the TBody:
						thead = new CKEDITOR.dom.element( table.$.tHead );
						tbody = table.getElementsByTag( 'tbody' ).getItem( 0 );

						var previousFirstRow = tbody.getFirst();
						while ( thead.getChildCount() > 0 ) {
							theRow = thead.getFirst();
							for ( i = 0; i < theRow.getChildCount(); i++ ) {
								var newCell = theRow.getChild( i );
								if ( newCell.type == CKEDITOR.NODE_ELEMENT ) {
									newCell.renameNode( 'td' );
									newCell.removeAttribute( 'scope' );
								}
							}
							theRow.insertBefore( previousFirstRow );
						}
						thead.remove();
					}

					// Should we make all first cells in a row TH?
					if ( !this.hasColumnHeaders && ( headers == 'col' || headers == 'both' ) ) {
						for ( row = 0; row < table.$.rows.length; row++ ) {
							newCell = new CKEDITOR.dom.element( table.$.rows[ row ].cells[ 0 ] );
							newCell.renameNode( 'th' );
							newCell.setAttribute( 'scope', 'row' );
						}
					}

					// Should we make all first TH-cells in a row make TD? If 'yes' we do it the other way round :-)
					if ( ( this.hasColumnHeaders ) && !( headers == 'col' || headers == 'both' ) ) {
						for ( i = 0; i < table.$.rows.length; i++ ) {
							row = new CKEDITOR.dom.element( table.$.rows[ i ] );
							if ( row.getParent().getName() == 'tbody' ) {
								newCell = new CKEDITOR.dom.element( row.$.cells[ 0 ] );
								newCell.renameNode( 'td' );
								newCell.removeAttribute( 'scope' );
							}
						}
					}

					// Set the width and height.
					info.txtHeight ? table.setStyle( 'height', info.txtHeight ) : table.removeStyle( 'height' );
					info.txtWidth ? table.setStyle( 'width', info.txtWidth ) : table.removeStyle( 'width' );
					table.setStyle( 'border-spacing', 'initial' );
					table.setStyle( 'border-collapse', 'collapse' );

					if ( !table.getAttribute( 'style' ) )
						table.removeAttribute( 'style' );
				}

				// Insert the table element if we're creating one.
				if ( !selectedElement ) {
					editor.insertElement( table );
					// Override the default cursor position after insertElement to place
					// cursor inside the first cell (https://dev.ckeditor.com/ticket/7959), IE needs a while.
					setTimeout( function() {
						var firstCell = new CKEDITOR.dom.element( table.$.rows[ 0 ].cells[ 0 ] );
						var range = editor.createRange();
						range.moveToPosition( firstCell, CKEDITOR.POSITION_AFTER_START );
						range.select();
					}, 0 );
				}
				// Properly restore the selection, (https://dev.ckeditor.com/ticket/4822) but don't break
				// because of this, e.g. updated table caption.
				else {
					try {
						selection.selectBookmarks( bms );
					} catch ( er ) {
					}
				}
			}
		}
	}

} );
