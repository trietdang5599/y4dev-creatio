define("MLDataPredictionUserTaskPropertiesPage", ["MLConfigurationConsts"],
	function (mlConsts) {
		return {
			methods: {
				/**
				 * Prepare ML models list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {Terrasoft.Collection} list ML models list.
				 */
				onPrepareMLModelsList: function (filter, list) {
					if (this.Ext.isEmpty(list)) {
						return;
					}
					const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "MLModel"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("MLProblemType.Id");
					const sequencePredictionDisabled = !Terrasoft.Features.getIsEnabled("MLSequencePrediction");
					if (sequencePredictionDisabled) {
						const sequencePredictionProblemType = mlConsts.ProblemTypes.SequencePrediction;
						esq.filters.add("ValueFilter", Terrasoft.createColumnFilterWithParameter(
							Terrasoft.ComparisonType.NOT_EQUAL, "MLProblemType.Id", sequencePredictionProblemType));
					}
					esq.getEntityCollection(function (response) {
						if (!response.success || !response.collection) {
							return;
						}
						const items = Ext.create("Terrasoft.Collection");
						this.Terrasoft.each(response.collection, function (model) {
							const modelId = model.get("Id");
							const modelName = model.get("Name");
							const item = {
								value: modelId,
								displayValue: modelName
							};
							items.add(modelId, item);
						});
						list.reloadAll(items);
					}, this);
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "MLModelId",
					"parentName": "MLModelContainer",
					"operation": "merge",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"prepareList": {"bindTo": "onPrepareMLModelsList"}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});