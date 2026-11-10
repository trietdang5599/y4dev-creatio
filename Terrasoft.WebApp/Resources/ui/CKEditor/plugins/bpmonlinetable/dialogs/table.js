/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */

/**
 * This Source Code Form is subject to the terms of the Mozilla
 * Public License, v. 2.0. If a copy of the MPL was not distributed
 * with this file, You can obtain one at https://mozilla.org/MPL/2.0/
 */

( function() {
	var defaultToPixel = CKEDITOR.tools.cssLength;

	var commitValue = function( data ) {
			var id = this.id;
			if ( !data.info )
				data.info = {};
			data.info[ id ] = this.getValue();
		};

	function tableColumns( table ) {
		var cols = 0,
			maxCols = 0;
		for ( var i = 0, row, rows = table.$.rows.length; i < rows; i++ ) {
			row = table.$.rows[ i ], cols = 0;
			for ( var j = 0, cell, cells = row.cells.length; j < cells; j++ ) {
				cell = row.cells[ j ];
				cols += cell.colSpan;
			}

			cols > maxCols && ( maxCols = cols );
		}

		return maxCols;
	}


	// Whole-positive-integer validator.
	function validatorNum( msg ) {
		return function() {
			var value = this.getValue(),
				pass = !!( CKEDITOR.dialog.validate.integer()( value ) && value > 0 );

			if ( !pass ) {
				alert( msg ); // jshint ignore:line
				this.select();
			}

			return pass;
		};
	}

	function tableDialog( editor, command ) {
		var editable = editor.editable();

		var dialogadvtab = editor.plugins.dialogadvtab;

		function addCssClass(className, elementDomId) {
			var element = Ext.get(elementDomId);
			element.addCls(className);
		}

		return {
			title: editor.lang.table.title,
			minWidth: 100,
			minHeight: CKEDITOR.env.ie ? 150 : 120,
			resizable: CKEDITOR.DIALOG_RESIZE_NONE,
			onLoad: function() {
				var dialog = this;

				var styles = dialog.getContentElement( 'advanced', 'advStyles' );

				if ( styles ) {
					styles.on( 'change', function() {
						// Synchronize width value.
						var width = this.getStyle( 'width', '' ),
							txtWidth = dialog.getContentElement( 'info', 'txtWidth' );

						txtWidth && txtWidth.setValue( width, true );

						// Synchronize height value.
						var height = this.getStyle( 'height', '' ),
							txtHeight = dialog.getContentElement( 'info', 'txtHeight' );

						txtHeight && txtHeight.setValue( height, true );
					} );
				}
			},
			onShow: function() {
				// Detect if there's a selected table.
				var selection = editor.getSelection(),
					ranges = selection.getRanges(),
					table;

				var rowsInput = this.getContentElement( 'info', 'txtRows' ),
					colsInput = this.getContentElement( 'info', 'txtCols' ),
					widthInput = this.getContentElement( 'info', 'txtWidth' ),
					heightInput = this.getContentElement( 'info', 'txtHeight' );
				addCssClass("cke_table_" + rowsInput.id, rowsInput.domId);
				addCssClass("cke_table_" + colsInput.id, colsInput.domId);
				addCssClass("cke_table_" + widthInput.id, widthInput.domId);
				addCssClass("cke_table_" + heightInput.id, heightInput.domId);

				if ( command == 'tableProperties' ) {
					var selected = selection.getSelectedElement();
					if ( selected && selected.is( 'table' ) )
						table = selected;
					else if ( ranges.length > 0 ) {
						// Webkit could report the following range on cell selection (https://dev.ckeditor.com/ticket/4948):
						// <table><tr><td>[&nbsp;</td></tr></table>]
						if ( CKEDITOR.env.webkit )
							ranges[ 0 ].shrink( CKEDITOR.NODE_ELEMENT );

						table = editor.elementPath( ranges[ 0 ].getCommonAncestor( true ) ).contains( 'table', 1 );
					}

					// Save a reference to the selected table, and push a new set of default values.
					this._.selectedElement = table;
				}

				// Enable or disable the row, cols, width fields.
				if ( table ) {
					this.setupContent( table );
					rowsInput && rowsInput.disable();
					colsInput && colsInput.disable();
				} else {
					rowsInput && rowsInput.enable();
					colsInput && colsInput.enable();
				}

				// Call the onChange method for the widht and height fields so
				// they get reflected into the Advanced tab.
				widthInput && widthInput.onChange();
				heightInput && heightInput.onChange();
			},
			onOk: function() {
				CKEDITOR.plugins.bpmonlinetable.createTable.call(this, null, editor);
			},
			contents: [ {
				id: 'info',
				label: editor.lang.table.title,
				elements: [ {
					type: 'hbox',
					styles: [ 'vertical-align:top' ],
					children: [{
						type: 'vbox',
						padding: 0,
						children: [ {
							type: 'text',
							id: 'txtRows',
							'default': 3,
							label: editor.lang.table.rows,
							required: true,
							controlStyle: 'width:6em;margin-right:3em',
							validate: validatorNum( editor.lang.table.invalidRows ),
							setup: function( selectedElement ) {
								this.setValue( selectedElement.$.rows.length );
							},
							commit: commitValue
						},
						{
							type: 'text',
							id: 'txtCols',
							'default': 2,
							label: editor.lang.table.columns,
							required: true,
							controlStyle: 'width:6em;margin-right:3em',
							validate: validatorNum( editor.lang.table.invalidCols ),
							setup: function( selectedTable ) {
								this.setValue( tableColumns( selectedTable ) );
							},
							commit: commitValue
						}]
					},
					{
						type: 'vbox',
						padding: 0,
						children: [ {
							type: 'hbox',
							widths: [ '6em' ],
							children: [ {
								type: 'text',
								id: 'txtWidth',
								requiredContent: 'table{width}',
								controlStyle: 'width:6em',
								label: editor.lang.common.width,
								title: editor.lang.common.cssLengthTooltip,
								// Smarter default table width. (https://dev.ckeditor.com/ticket/9600)
								'default': editor.filter.check( 'table{width}' ) ? ( editable.getSize( 'width' ) < 500 ? '100%' : 500 ) : 0,
								getValue: defaultToPixel,
								validate: CKEDITOR.dialog.validate.cssLength( editor.lang.common.invalidCssLength.replace( '%1', editor.lang.common.width ) ),
								onChange: function() {
									var styles = this.getDialog().getContentElement( 'advanced', 'advStyles' );
									styles && styles.updateStyle( 'width', this.getValue() );
								},
								setup: function( selectedTable ) {
									var val = selectedTable.getStyle( 'width' );
									this.setValue( val );
								},
								commit: commitValue
							} ]
						},
						{
							type: 'hbox',
							widths: [ '6em' ],
							children: [ {
								type: 'text',
								id: 'txtHeight',
								requiredContent: 'table{height}',
								controlStyle: 'width:6em',
								label: editor.lang.common.height,
								title: editor.lang.common.cssLengthTooltip,
								'default': '',
								getValue: defaultToPixel,
								validate: CKEDITOR.dialog.validate.cssLength( editor.lang.common.invalidCssLength.replace( '%1', editor.lang.common.height ) ),
								onChange: function() {
									var styles = this.getDialog().getContentElement( 'advanced', 'advStyles' );
									styles && styles.updateStyle( 'height', this.getValue() );
								},

								setup: function( selectedTable ) {
									var val = selectedTable.getStyle( 'height' );
									val && this.setValue( val );
								},
								commit: commitValue
							} ]
						}]
					} ]
				} ]
			}
		] };
	}

	CKEDITOR.on("dialogDefinition", function(event) {
		var dialogName = event.data.name;
		var dialogDefinition = event.data.definition;
		if ( dialogName === 'bpmonlinetable' ) {
			var scope = this;
			dialogDefinition.onFocus = function() {
				var dialog = this.parts.dialog.$;
				var dialogWrapEl = Ext.get(dialog);
				dialogWrapEl.addCls("cke_no_min_size");
			};
		}
	});
	CKEDITOR.dialog.add( 'bpmonlinetable', function( editor ) {
		return tableDialog( editor, 'table' );
	} );
	CKEDITOR.dialog.add( 'bpmonlinetableProperties', function( editor ) {
		return tableDialog( editor, 'tableProperties' );
	} );
} )();