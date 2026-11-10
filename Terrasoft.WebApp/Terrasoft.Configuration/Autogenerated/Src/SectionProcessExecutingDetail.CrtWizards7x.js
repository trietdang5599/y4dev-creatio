/**
 * @class Terrasoft.SectionProcessExecutingDetail
 * @extends Terrasoft.BaseProcessExecutingDetail
 */
define("SectionProcessExecutingDetail", ["SectionProcessSettingsManager"], function() {
	return {
		methods: {
			/**
			 * @inheritdoc DataManagerGridUtilities#getEntitySchemaName
			 * @override
			 */
			getEntitySchemaName: function() {
				return "ProcessInModules";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getProcessRunnerManager
			 * @override
			 */
			getProcessRunnerManager: function() {
				return Terrasoft.SectionManager;
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerName
			 * @override
			 */
			getManagerName: function() {
				return "SectionProcessSettingsManager";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerItemName
			 * @override
			 */
			getManagerItemName: function() {
				return "SectionProcessSettingsManagerItem";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getIsParameterRequired
			 * @override
			 */
			getIsParameterRequired: function() {
				return false;
			}
		}
	};
});
