namespace Terrasoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.Factories;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.ML.Interfaces;
	using Terrasoft.ML.Interfaces.Responses;

	/// <summary>
	/// Prediction parameters for sequence prediction tasks.
	/// </summary>
	public class SequencePredictionParams
	{
		/// <summary>
		/// Count of next possible sequence continuations to predict.
		/// </summary>
		public int PossibleContinuationsCount { get; set; }
	}

	/// <summary>
	/// Sequence prediction implementation of <see cref="IMLEntityPredictor"/> and <see cref="IMLPredictor{TOut}"/>.
	/// </summary>
	[DefaultBinding(typeof(IMLEntityPredictor), Name = MLConsts.SequencePredictionProblemType)]
	[DefaultBinding(typeof(IMLPredictor<SequencePredictionOutput>), Name = MLConsts.SequencePredictionProblemType)]
	[DefaultBinding(typeof(IMLParametrizedPredictor<SequencePredictionParams, SequencePredictionOutput>),
		Name = MLConsts.SequencePredictionProblemType)]
	public class MLSequencePredictionEntityPredictor : MLBaseEntityPredictor<SequencePredictionOutput>,
		IMLParametrizedPredictor<SequencePredictionParams, SequencePredictionOutput>
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLSequencePredictionEntityPredictor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLSequencePredictionEntityPredictor(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the problem type identifier.
		/// </summary>
		/// <value>
		/// The problem type identifier.
		/// </value>
		protected override Guid ProblemTypeId => new Guid(MLConsts.SequencePredictionProblemType);
		
		/// <summary>
		/// Model should have <see cref="MLModelConfig.PredictedResultColumnName"/> filled.
		/// </summary>
		protected override bool MustHavePredictedResultColumn { get; } = false;

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Predicts using the specified proxy.
		/// </summary>
		/// <param name="proxy">The proxy.</param>
		/// <param name="model">The model.</param>
		/// <param name="data">The input data.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Predicted result.</returns>
		protected override SequencePredictionOutput Predict(IMLServiceProxy proxy, MLModelConfig model,
				Dictionary<string, object> data, MLDataPredictionUserTask predictionUserTask) {
			var dataList = new List<Dictionary<string, object>> { data };
			SequencePredictionResponse response = proxy.Predict<SequencePredictionResponse>(
				model.ModelInstanceUId, dataList, model.PredictionEndpoint);
			return response?.Outputs.FirstOrDefault();
		}

		/// <summary>
		/// Predicts results for the given batch of records with extra params taken from user task.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="dataList">Batch of records.</param>
		/// <param name="proxy">ML service proxy.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Prediction results.</returns>
		protected override List<SequencePredictionOutput> Predict(MLModelConfig model,
				IList<Dictionary<string, object>> dataList, IMLServiceProxy proxy,
				MLDataPredictionUserTask predictionUserTask) {
			SequencePredictionResponse response = proxy.Predict<SequencePredictionResponse>(
				model.ModelInstanceUId, dataList, model.PredictionEndpoint);
			return response.Outputs;
		}

		/// <summary>
		/// Does nothing as not applicable for this problem type.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SavePrediction(MLModelConfig model, Guid entityId,
			SequencePredictionOutput predictedResult) {
		}

		/// <summary>
		/// Does nothing as not applicable for this problem type.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SaveEntityPredictedValues(MLModelConfig model, Guid entityId,
			SequencePredictionOutput predictedResult) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Predicts result by given input data.
		/// </summary>
		/// <param name="model">Machine learning model configuration from database.</param>
		/// <param name="data">The input data.</param>
		/// <param name="predictionParams">Prediction extra params.</param>
		/// <returns>Prediction result.</returns>
		public List<SequencePredictionOutput> Predict(MLModelConfig model, IList<Dictionary<string, object>> data,
				SequencePredictionParams predictionParams) {
			try {
				IMLServiceProxy proxy = GetMLProxy(model);
				var response = proxy.Predict<SequencePredictionResponse>(model.ModelInstanceUId, data,
					model.PredictionEndpoint, new SequencePredictionInput {
						PossibleContinuationsCount = predictionParams.PossibleContinuationsCount
					});
				return response?.Outputs;
			} catch (IncorrectConfigurationException ex) {
				_log.WarnFormat($"Can't predict value for model {model.Id}", ex);
				throw;
			}
		}

		#endregion

	}

}

