 namespace Terrasoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Class: MLSequencePredictionModelBuilder

	/// <summary>
	/// Implements the behavior of the SequencePrediction MLModel
	/// </summary>
	[DefaultBinding(typeof(IMLModelBuilder), Name = MLConsts.SequencePredictionProblemType)]
	public class MLSequencePredictionModelBuilder : MLDefaultModelBuilder
	{

		#region Methods: Private

		private static IEnumerable<MLColumnExpression> GetModelColumns(MLModelConfig modelConfig) {
			var columns = new List<MLColumnExpression>();
			if (modelConfig.SequenceIdentifierColumnPath.IsNotNullOrEmpty()) {
				columns.Add(new MLColumnExpression {
					ColumnPath = modelConfig.SequenceIdentifierColumnPath,
					Alias = "SequenceId"
				});
			}
			if (modelConfig.SequenceItemPositionColumnPath.IsNotNullOrEmpty()) {
				columns.Add(new MLColumnExpression {
					ColumnPath = modelConfig.SequenceItemPositionColumnPath,
					Alias = "Position"
				});
			}
			if (modelConfig.SequenceItemValueColumnPath.IsNotNullOrEmpty()) {
				columns.Add(new MLColumnExpression {
					ColumnPath = modelConfig.SequenceItemValueColumnPath,
					Alias = "Value"
				});
			}
			return columns;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads the required columns to train model.
		/// </summary>
		/// <param name="modelConfig">ML model configuration.</param>
		/// <param name="userConnection">UserConnection instance.</param>
		public override void LoadMLModelColumns(UserConnection userConnection, MLModelConfig modelConfig) {
			modelConfig.ColumnUIds = new List<Guid>();
			modelConfig.ColumnExpressions = GetModelColumns(modelConfig);
			modelConfig.PredictionColumnExpressions = new List<MLColumnExpression>();
		}

		/// <summary>
		/// Expands the original query with an output column.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="modelConfig">ML model configuration.</param>
		/// <param name="userConnection">UserConnection instance.</param>
		public override void AddQueryOutputColumn(UserConnection userConnection, Select query, MLModelConfig modelConfig) {
			query.Column(Column.Const(1)).As(MLConsts.DefaultOutputColumnAlias);
		}

		#endregion

	}

	#endregion

}

