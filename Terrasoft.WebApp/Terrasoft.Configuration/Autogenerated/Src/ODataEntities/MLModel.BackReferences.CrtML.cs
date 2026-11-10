namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: MLModel

	/// <exclude/>
	public class MLModel : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModel";
		}

		public MLModel(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLModel";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MLClassificationResult> MLClassificationResultCollectionByModel {
			get;
			set;
		}

		public IEnumerable<MLModelColumn> MLModelColumnCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelFile> MLModelFileCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelInFolder> MLModelInFolderCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelInTag> MLModelInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<MLPrediction> MLPredictionCollectionByModel {
			get;
			set;
		}

		public IEnumerable<MLTrainSession> MLTrainSessionCollectionByMLModel {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Retrain after, days.
		/// </summary>
		public int TrainFrequency {
			get {
				return GetTypedColumnValue<int>("TrainFrequency");
			}
			set {
				SetColumnValue("TrainFrequency", value);
			}
		}

		/// <summary>
		/// When the model was trained.
		/// </summary>
		public DateTime TrainedOn {
			get {
				return GetTypedColumnValue<DateTime>("TrainedOn");
			}
			set {
				SetColumnValue("TrainedOn", value);
			}
		}

		/// <summary>
		/// Last attempt to train date.
		/// </summary>
		public DateTime TriedToTrainOn {
			get {
				return GetTypedColumnValue<DateTime>("TriedToTrainOn");
			}
			set {
				SetColumnValue("TriedToTrainOn", value);
			}
		}

		/// <summary>
		/// Query metadata for selecting additional training data.
		/// </summary>
		public string MetaData {
			get {
				return GetTypedColumnValue<string>("MetaData");
			}
			set {
				SetColumnValue("MetaData", value);
			}
		}

		/// <summary>
		/// Localizable part of metadata.
		/// </summary>
		public string MetaDataLcz {
			get {
				return GetTypedColumnValue<string>("MetaDataLcz");
			}
			set {
				SetColumnValue("MetaDataLcz", value);
			}
		}

		/// <summary>
		/// Query for selecting additional training data.
		/// </summary>
		public string TrainingSetQuery {
			get {
				return GetTypedColumnValue<string>("TrainingSetQuery");
			}
			set {
				SetColumnValue("TrainingSetQuery", value);
			}
		}

		/// <summary>
		/// Object.
		/// </summary>
		public Guid RootSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("RootSchemaUId");
			}
			set {
				SetColumnValue("RootSchemaUId", value);
			}
		}

		/// <summary>
		/// Evaluation metric.
		/// </summary>
		public Decimal InstanceMetric {
			get {
				return GetTypedColumnValue<Decimal>("InstanceMetric");
			}
			set {
				SetColumnValue("InstanceMetric", value);
			}
		}

		/// <summary>
		/// Quality metric lower limit.
		/// </summary>
		public Decimal MetricThreshold {
			get {
				return GetTypedColumnValue<Decimal>("MetricThreshold");
			}
			set {
				SetColumnValue("MetricThreshold", value);
			}
		}

		/// <summary>
		/// Prediction enabled.
		/// </summary>
		public bool PredictionEnabled {
			get {
				return GetTypedColumnValue<bool>("PredictionEnabled");
			}
			set {
				SetColumnValue("PredictionEnabled", value);
			}
		}

		/// <summary>
		/// Current training session.
		/// </summary>
		public Guid TrainSessionId {
			get {
				return GetTypedColumnValue<Guid>("TrainSessionId");
			}
			set {
				SetColumnValue("TrainSessionId", value);
			}
		}

		/// <summary>
		/// Model instance Id.
		/// </summary>
		public string ModelInstanceUId {
			get {
				return GetTypedColumnValue<string>("ModelInstanceUId");
			}
			set {
				SetColumnValue("ModelInstanceUId", value);
			}
		}

		/// <summary>
		/// Last error message text.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Batch prediction date.
		/// </summary>
		public DateTime BatchPredictedOn {
			get {
				return GetTypedColumnValue<DateTime>("BatchPredictedOn");
			}
			set {
				SetColumnValue("BatchPredictedOn", value);
			}
		}

		/// <summary>
		/// Query for selecting additional prediction data.
		/// </summary>
		public string BatchPredictionQuery {
			get {
				return GetTypedColumnValue<string>("BatchPredictionQuery");
			}
			set {
				SetColumnValue("BatchPredictionQuery", value);
			}
		}

		/// <summary>
		/// Outcome column.
		/// </summary>
		public Guid TargetColumnUId {
			get {
				return GetTypedColumnValue<Guid>("TargetColumnUId");
			}
			set {
				SetColumnValue("TargetColumnUId", value);
			}
		}

		/// <summary>
		/// Minimum training record count.
		/// </summary>
		public int TrainingMinimumRecordsCount {
			get {
				return GetTypedColumnValue<int>("TrainingMinimumRecordsCount");
			}
			set {
				SetColumnValue("TrainingMinimumRecordsCount", value);
			}
		}

		/// <summary>
		/// Maximum training record count.
		/// </summary>
		public int TrainingMaxRecordsCount {
			get {
				return GetTypedColumnValue<int>("TrainingMaxRecordsCount");
			}
			set {
				SetColumnValue("TrainingMaxRecordsCount", value);
			}
		}

		/// <summary>
		/// Prediction result column.
		/// </summary>
		public Guid PredictedResultColumnUId {
			get {
				return GetTypedColumnValue<Guid>("PredictedResultColumnUId");
			}
			set {
				SetColumnValue("PredictedResultColumnUId", value);
			}
		}

		/// <summary>
		/// Lower limit of probability for predicted value selection.
		/// </summary>
		public Decimal ConfidentValueLowEdge {
			get {
				return GetTypedColumnValue<Decimal>("ConfidentValueLowEdge");
			}
			set {
				SetColumnValue("ConfidentValueLowEdge", value);
			}
		}

		/// <summary>
		/// Recommended to (Subject).
		/// </summary>
		public string CFUserColumnPath {
			get {
				return GetTypedColumnValue<string>("CFUserColumnPath");
			}
			set {
				SetColumnValue("CFUserColumnPath", value);
			}
		}

		/// <summary>
		/// Recommended object.
		/// </summary>
		public string CFItemColumnPath {
			get {
				return GetTypedColumnValue<string>("CFItemColumnPath");
			}
			set {
				SetColumnValue("CFItemColumnPath", value);
			}
		}

		/// <summary>
		/// Recommendation dependency column.
		/// </summary>
		public string CFInteractionValueColumnPath {
			get {
				return GetTypedColumnValue<string>("CFInteractionValueColumnPath");
			}
			set {
				SetColumnValue("CFInteractionValueColumnPath", value);
			}
		}

		/// <summary>
		/// List predict result schema.
		/// </summary>
		public Guid ListPredictResultSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ListPredictResultSchemaUId");
			}
			set {
				SetColumnValue("ListPredictResultSchemaUId", value);
			}
		}

		/// <summary>
		/// List prediction subject column.
		/// </summary>
		public string ListPredictResultSubjectColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultSubjectColumn");
			}
			set {
				SetColumnValue("ListPredictResultSubjectColumn", value);
			}
		}

		/// <summary>
		/// List prediction result object column.
		/// </summary>
		public string ListPredictResultObjectColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultObjectColumn");
			}
			set {
				SetColumnValue("ListPredictResultObjectColumn", value);
			}
		}

		/// <summary>
		/// List prediction result value column.
		/// </summary>
		public string ListPredictResultValueColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultValueColumn");
			}
			set {
				SetColumnValue("ListPredictResultValueColumn", value);
			}
		}

		/// <summary>
		/// List prediction result model column.
		/// </summary>
		public string ListPredictResultModelColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultModelColumn");
			}
			set {
				SetColumnValue("ListPredictResultModelColumn", value);
			}
		}

		/// <summary>
		/// List prediction result date column.
		/// </summary>
		public string ListPredictResultDateColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultDateColumn");
			}
			set {
				SetColumnValue("ListPredictResultDateColumn", value);
			}
		}

		/// <summary>
		/// List of factors count.
		/// </summary>
		public string FactorsCounts {
			get {
				return GetTypedColumnValue<string>("FactorsCounts");
			}
			set {
				SetColumnValue("FactorsCounts", value);
			}
		}

		/// <summary>
		/// List of regularization values.
		/// </summary>
		public string RegularizationValues {
			get {
				return GetTypedColumnValue<string>("RegularizationValues");
			}
			set {
				SetColumnValue("RegularizationValues", value);
			}
		}

		/// <summary>
		/// Prediction schema.
		/// </summary>
		public Guid PredictionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("PredictionSchemaUId");
			}
			set {
				SetColumnValue("PredictionSchemaUId", value);
			}
		}

		/// <summary>
		/// Lower score threshold.
		/// </summary>
		public Decimal LowerScoreThreshold {
			get {
				return GetTypedColumnValue<Decimal>("LowerScoreThreshold");
			}
			set {
				SetColumnValue("LowerScoreThreshold", value);
			}
		}

		/// <summary>
		/// Sequence item value column.
		/// </summary>
		public string SequenceItemValueColumnPath {
			get {
				return GetTypedColumnValue<string>("SequenceItemValueColumnPath");
			}
			set {
				SetColumnValue("SequenceItemValueColumnPath", value);
			}
		}

		/// <summary>
		/// Sequence item position column.
		/// </summary>
		public string SequenceItemPositionColumnPath {
			get {
				return GetTypedColumnValue<string>("SequenceItemPositionColumnPath");
			}
			set {
				SetColumnValue("SequenceItemPositionColumnPath", value);
			}
		}

		/// <summary>
		/// Sequence identifier column.
		/// </summary>
		public string SequenceIdentifierColumnPath {
			get {
				return GetTypedColumnValue<string>("SequenceIdentifierColumnPath");
			}
			set {
				SetColumnValue("SequenceIdentifierColumnPath", value);
			}
		}

		/// <summary>
		/// Open AI api key.
		/// </summary>
		public string OpenaiApiKey {
			get {
				return GetTypedColumnValue<string>("OpenaiApiKey");
			}
			set {
				SetColumnValue("OpenaiApiKey", value);
			}
		}

		/// <summary>
		/// LLM model prompt.
		/// </summary>
		public string LlmModelPrompt {
			get {
				return GetTypedColumnValue<string>("LlmModelPrompt");
			}
			set {
				SetColumnValue("LlmModelPrompt", value);
			}
		}

		/// <summary>
		/// LLM model name.
		/// </summary>
		public string LlmModelName {
			get {
				return GetTypedColumnValue<string>("LlmModelName");
			}
			set {
				SetColumnValue("LlmModelName", value);
			}
		}

		/// <summary>
		/// Temperature value for LLM model.
		/// </summary>
		public Decimal LlmModelTemperature {
			get {
				return GetTypedColumnValue<Decimal>("LlmModelTemperature");
			}
			set {
				SetColumnValue("LlmModelTemperature", value);
			}
		}

		/// <summary>
		/// Maximum size for document chunks.
		/// </summary>
		public int DocumentMaxChunkSize {
			get {
				return GetTypedColumnValue<int>("DocumentMaxChunkSize");
			}
			set {
				SetColumnValue("DocumentMaxChunkSize", value);
			}
		}

		/// <summary>
		/// Overlap size for document chunks.
		/// </summary>
		public int DocumentChunkSizeOverlap {
			get {
				return GetTypedColumnValue<int>("DocumentChunkSizeOverlap");
			}
			set {
				SetColumnValue("DocumentChunkSizeOverlap", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private MLModelState _state;
		/// <summary>
		/// Status.
		/// </summary>
		public MLModelState State {
			get {
				return _state ??
					(_state = new MLModelState(LookupColumnEntities.GetEntity("State")));
			}
		}

		/// <exclude/>
		public Guid MLProblemTypeId {
			get {
				return GetTypedColumnValue<Guid>("MLProblemTypeId");
			}
			set {
				SetColumnValue("MLProblemTypeId", value);
				_mLProblemType = null;
			}
		}

		/// <exclude/>
		public string MLProblemTypeName {
			get {
				return GetTypedColumnValue<string>("MLProblemTypeName");
			}
			set {
				SetColumnValue("MLProblemTypeName", value);
				if (_mLProblemType != null) {
					_mLProblemType.Name = value;
				}
			}
		}

		private MLProblemType _mLProblemType;
		/// <summary>
		/// Type.
		/// </summary>
		public MLProblemType MLProblemType {
			get {
				return _mLProblemType ??
					(_mLProblemType = new MLProblemType(LookupColumnEntities.GetEntity("MLProblemType")));
			}
		}

		/// <exclude/>
		public Guid BatchPredictionStartMethodId {
			get {
				return GetTypedColumnValue<Guid>("BatchPredictionStartMethodId");
			}
			set {
				SetColumnValue("BatchPredictionStartMethodId", value);
				_batchPredictionStartMethod = null;
			}
		}

		/// <exclude/>
		public string BatchPredictionStartMethodName {
			get {
				return GetTypedColumnValue<string>("BatchPredictionStartMethodName");
			}
			set {
				SetColumnValue("BatchPredictionStartMethodName", value);
				if (_batchPredictionStartMethod != null) {
					_batchPredictionStartMethod.Name = value;
				}
			}
		}

		private MLTaskStartMethod _batchPredictionStartMethod;
		/// <summary>
		/// Method of batch prediction start.
		/// </summary>
		public MLTaskStartMethod BatchPredictionStartMethod {
			get {
				return _batchPredictionStartMethod ??
					(_batchPredictionStartMethod = new MLTaskStartMethod(LookupColumnEntities.GetEntity("BatchPredictionStartMethod")));
			}
		}

		/// <exclude/>
		public Guid MLConfidentValueMethodId {
			get {
				return GetTypedColumnValue<Guid>("MLConfidentValueMethodId");
			}
			set {
				SetColumnValue("MLConfidentValueMethodId", value);
				_mLConfidentValueMethod = null;
			}
		}

		/// <exclude/>
		public string MLConfidentValueMethodName {
			get {
				return GetTypedColumnValue<string>("MLConfidentValueMethodName");
			}
			set {
				SetColumnValue("MLConfidentValueMethodName", value);
				if (_mLConfidentValueMethod != null) {
					_mLConfidentValueMethod.Name = value;
				}
			}
		}

		private MLConfidentValueMethod _mLConfidentValueMethod;
		/// <summary>
		/// Predicted value selection method.
		/// </summary>
		public MLConfidentValueMethod MLConfidentValueMethod {
			get {
				return _mLConfidentValueMethod ??
					(_mLConfidentValueMethod = new MLConfidentValueMethod(LookupColumnEntities.GetEntity("MLConfidentValueMethod")));
			}
		}

		/// <exclude/>
		public Guid LastTrainingErrorId {
			get {
				return GetTypedColumnValue<Guid>("LastTrainingErrorId");
			}
			set {
				SetColumnValue("LastTrainingErrorId", value);
				_lastTrainingError = null;
			}
		}

		/// <exclude/>
		public string LastTrainingErrorName {
			get {
				return GetTypedColumnValue<string>("LastTrainingErrorName");
			}
			set {
				SetColumnValue("LastTrainingErrorName", value);
				if (_lastTrainingError != null) {
					_lastTrainingError.Name = value;
				}
			}
		}

		private MLError _lastTrainingError;
		/// <summary>
		/// Last training error.
		/// </summary>
		public MLError LastTrainingError {
			get {
				return _lastTrainingError ??
					(_lastTrainingError = new MLError(LookupColumnEntities.GetEntity("LastTrainingError")));
			}
		}

		#endregion

	}

	#endregion

}

