define("FileImportColumnMappingMixin", ["RightUtilities", "FileImportColumnMappingMixinResources"],
	function(RightUtilities, resources) {
	const referenceSchemaRightsColumnName = "ReferenceSchemaRights";
	Ext.define("Terrasoft.configuration.mixins.FileImportColumnMappingMixin", {
		alternateClassName: "Terrasoft.FileImportColumnMappingMixin",

		/**
		 * Returns a validator function for checking schema rights.
		 * @param {String} schemaName - The name of the schema to check rights for.
		 * @param {Array} results - The array to store the check results.
		 * @returns {Function} Validator function for Terrasoft.chain.
		 */
		getReferenceSchemaRightValidator: function(schemaName, results) {
			return (next) => {
				RightUtilities.getSchemaOperationRightLevel(schemaName, function(result) {
					results.push({
						schemaName: schemaName,
						canRead: RightUtilities.canSchemaReadData(result),
						canAppend: RightUtilities.canAppendSchemaData(result)
					});
					next();
				}, this);
			}
		},

		/**
		 * Validates rights for a list of reference schemas and invokes a callback with the results.
		 * @param {Array} schemasToCheck - Array of schema names to check.
		 * @param {Function} callback - Callback to execute after validation.
		 */
		validateReferenceSchemaRights: function(schemasToCheck, callback){
			const checkResult = [];
			const tasks = schemasToCheck.map(schemaName => {
				return this.getReferenceSchemaRightValidator(schemaName, checkResult);
			});
			if (tasks.length === 0) {
				Ext.callback(callback, this, [checkedSchemas.filter(info => schemasToCheck.includes(info.schemaName))]);
				return;
			}
			Terrasoft.chain(
				...tasks,
				function(next) {
					Ext.callback(callback, this, [checkResult]);
					next();
				},
				this
			);
		},

		/**
		 * Checks if only read rights should be validated (feature flag based).
		 * @returns {Boolean} True if only read rights check is enabled, otherwise false.
		 */
		isOnlyReadRightsCheckEnabled: function() {
			return Terrasoft.Features.getIsDisabled("CheckEditRightsForImportLookupColumnDuringColumnMappingSetup");
		},

		/**
		 * Checks reference columns rights and shows a message if there are insufficient read rights.
		 * @param {Array} schemasNames - Array of schema names to check.
		 * @param {Function} callback - Callback to execute after checking rights.
		 */
		checkReferenceColumnsRights: function(schemasNames, callback) {
			if (schemasNames.length === 0) {
				const checkResult = [];
				Ext.callback(callback, this, [checkResult]);
				return;
			}
			this.validateReferenceSchemaRights(schemasNames, (results) => {
				const noReadRightsSchemaNames = results.filter(result => !result.canRead)
					.reduce((acc, result) => {
						acc.push(result.schemaName);
						return acc;
					}, []);
				if (noReadRightsSchemaNames.length > 0) {
					Terrasoft.showInformation(
						Ext.String.format(resources.localizableStrings.InsufficientPermissionsToReadRecords,
							noReadRightsSchemaNames.join(", ")));
				}
				Ext.callback(callback, this, [results, noReadRightsSchemaNames.length === 0]);
			});
		},

	});

	return Terrasoft.FileImportColumnMappingMixin;
});
