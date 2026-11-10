define("MLModelSection", ["MLConfigurationConsts"],
	function(mlConsts) {
		return {
			entitySchemaName: "MLModel",
			methods: {
				/**
				 *Returns MLModel edit pages. Without a SequencePrediction page if the feature MLSequencePrediction is disabled
				 * @protected
				 * @return {Terrasoft.BaseViewModelCollection | null} Edit pages for ML models.
				 */
				getMLModelSectionEditPagesForAddButton: function () {
					const editPages = this.$EditPages;
					const sequencePredictionDisabled = !Terrasoft.Features.getIsEnabled("MLSequencePrediction");
					if (sequencePredictionDisabled) {
						const sequencePredictionProblemType = mlConsts.ProblemTypes.SequencePrediction;
						return editPages.filterByFn(editPage => editPage.$Tag !== sequencePredictionProblemType);
					}
					return editPages;
				},

				/**
				 * Edit pages converter
				 * @private	 
				 */
				editPagesConverter: function(editPages) {
					if (editPages.getCount() > 1) {
						return editPages;
					} else {
						return null;
					}
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "getMLModelSectionEditPagesForAddButton",
									"bindConfig": {"converter": "editPagesConverter"}
								}
							}
						}
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeAddRecordButton",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "getMLModelSectionEditPagesForAddButton",
									"bindConfig": {"converter": "editPagesConverter"}
								}
							}
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});