var skinName = 'freedom';
CKEDITOR.skin.cssLoaded = [];
CKEDITOR.skin.name = skinName;
CKEDITOR.skin.loadPartOrigin = CKEDITOR.skin.loadPartOrigin || CKEDITOR.skin.loadPart;
CKEDITOR.skin.loadPart = function (part, fn) {
	if ( CKEDITOR.skin.name != getName() ) {
		CKEDITOR.scriptLoader.load( CKEDITOR.getUrl( CKEDITOR.skin.path() + 'skin.js' ), function() {
			loadCss(part, fn);
		} );
	} else {
		loadCss( part, fn );
	}
}

function getName() {
	return CKEDITOR.skinName.split( ',' )[ 0 ];
}

function getCssPath( part ) {
	// Check for ua-specific version of skin part.
	var uas = CKEDITOR.skin[ 'ua_' + part ], env = CKEDITOR.env;
	if ( uas ) {

		// Having versioned UA checked first.
		uas = uas.split( ',' ).sort( function( a, b ) {
			return a > b ? -1 : 1;
		} );

		for ( var i = 0, ua; i < uas.length; i++ ) {
			ua = uas[ i ];

			if ( env.ie ) {
				if ( ( ua.replace( /^ie/, '' ) == env.version ) || ( env.quirks && ua == 'iequirks' ) )
					ua = 'ie';
			}

			if ( env[ ua ] ) {
				part += '_' + uas[ i ];
				break;
			}
		}
	}
	return CKEDITOR.getUrl( CKEDITOR.skin.path() + part + '.css' );
}

function loadCss( part, callback ) {
	var path = part;
	if (CKEDITOR.skin.name === skinName) {
		part = part + '_' + skinName;
	}
	if (!CKEDITOR.skin.cssLoaded[ part ] ) {
		CKEDITOR.document.appendStyleSheet( getCssPath( path ) );
		CKEDITOR.skin.cssLoaded[ part ] = 1;
	}
	callback && callback();
}