namespace Terrasoft.Configuration.ML
{
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: MLBatchRegressor

	/// <summary>
	/// Regression implementetation for ML batch prediction.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ML.MLBatchNumericPredictor" />
	[DefaultBinding(typeof(IMLBatchPredictor), Name = MLConsts.RegressionProblemType)]
	public class MLBatchRegressor : MLBatchNumericPredictor
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLBatchRegressor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLBatchRegressor(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

	}

	#endregion

}

