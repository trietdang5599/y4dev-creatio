/**
 * ########## ###### ##### ##########. ############ ### ########## ###### # ######## #######.
 */
define("MainHeaderExtensions", ["ext-base"], function(Ext) {
	return {

		/**
		 * ############# ############## ###### ############# ##### ##########.
		 * @param {Terrasoft.BaseViewModel} viewModel
		 */
		customInitViewModel: Ext.emptyFn,

		/**
		 * ######### ######## ###### ############# ##### ##########.
		 * @param {Object} values ############ ######## ######.
		 */
		extendViewModelValues: Ext.emptyFn,

		/**
		 * ######### ###### ###### ############# ##### ##########.
		 * @param {Object} methods ############ ###### ######.
		 */
		extendViewModelMethods: Ext.emptyFn,

		/**
		 * ######### ######### ########### ########## ############.
		 * @param {Terrasoft.Container} imageContainer ######### ########### ########## ############.
		 */
		extendImageContainer: Ext.emptyFn
	};
});
