Terrasoft.configuration.Structures["MLPredictor"] = {innerHierarchyStack: ["MLPredictor"]};
define("MLPredictor", [], function() {

	/**
	 * Mixin for machine learning prediction.
	 */
	Ext.define("Terrasoft.configuration.mixins.MLPredictor", {
		alternateClassName: "Terrasoft.MLPredictor",

		/**
		 * Updates ML 'clouds' for prediction target columns.
		 * @private
		 */
		_updateControlPredictionState: function() {
			if (this.getPredictableColumnsStates) {
				this.getPredictableColumnsStates(this.setPredictableColumnsStates, this);
			}
		},

		/**
		 * @private
		 */
		_getEntityValue: function(columnName) {
			const modelValue = this.get(columnName);
			if (!Ext.isDefined(modelValue)) {
				return null;
			}
			return Ext.isObject(modelValue) ? modelValue.value || null : modelValue;
		},

		/**
		 * Prepares ML model input data needed for correct serialization to C# Dictionary<string, object> format.
		 * @param {[String] | {}} inputs Inputs {@see MLPredictor#predictClassification}.
		 * @return {[{Key: String, Value: String}]} Input data needed for correct serialization to C#
		 * Dictionary<string, object> format.
		 * @private
		 */
		_prepareInputsForService: function(inputs) {
			if (Ext.isArray(inputs)) {
				return Terrasoft.map(inputs, function(columnName) {
					return {
						"Key": columnName,
						"Value": this._getEntityValue(columnName)
					};
				}, this);
			}
			if (Ext.isObject(inputs)) {
				return Terrasoft.map(inputs, function(columnValue, columnName) {
					return {
						"Key": columnName,
						"Value": columnValue
					};
				});
			}
			throw new Terrasoft.UnsupportedTypeException();
		},

		/**
		 * Makes classification prediction for the target lookup column based on custom input values. Updates 'clouds'
		 * of the target lookup column.
		 * @param {[String] | {}} inputs Inputs represented in one of the next forms:
		 * 1. Array of column names. In this case key of the input is the given name and value is entity column value
		 * from the current view model.
		 * 2. Object, where key is input name, value is input value.
		 * All required columns for ML model should be passed.
		 * @param {String} targetColumnPath Target lookup column name.
		 * @param {Function} [callback] Callback function.
		 * @param {[{Probability: Number, Value: *}]} callback Predicted items.
		 */
		predictClassification: function (inputs, targetColumnPath, callback) {
			const config = {
				serviceName: "MLPredictorService",
				methodName: "ClassifyDataset",
				data: {
					inputs: this._prepareInputsForService(inputs),
					entitySchemaName: this.entitySchemaName,
					targetColumnPath: targetColumnPath,
					entityId: this.get("Id")
				}
			};
			Terrasoft.ConfigurationServiceProvider.callService(config, function (response, isSuccess) {
				if (!isSuccess || !response) {
					callback.call(this, null);
					return;
				}
				const classificationResults = response.result && response.result.classificationResults;
				this._updateControlPredictionState();
				if (callback) {
					callback.call(this, classificationResults);
				}
			}, this);
		}
	});
});


