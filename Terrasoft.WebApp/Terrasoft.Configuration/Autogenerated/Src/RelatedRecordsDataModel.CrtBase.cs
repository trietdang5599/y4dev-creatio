namespace Terrasoft.Configuration.RelatedRecords
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.Entities;

	#region Interface: IRelatedRecordsServiceRequest

	/// <summary>
	/// Interface of request of related records service.
	/// </summary>
	public interface IRelatedRecordsServiceRequest
	{

		#region Properties: Public

		/// <summary>
		/// Serialized entity schema query of main records.
		/// </summary>
		string MainRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Serialized entity schema query of related records.
		/// </summary>
		string RelatedRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Schema name of related in main records.
		/// </summary>
		string RelatedInMainRecordsSchemaName { get; set; }

		/// <summary>
		/// Main record colummn name.
		/// </summary>
		string MainRecordColumnName { get; set; }

		/// <summary>
		/// Related record column name.
		/// </summary>
		string RelatedRecordColumnName { get; set; }

		/// <summary>
		/// Serialized collection of default values.
		/// </summary>
		string DefaultValues { get; set; }

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsServiceResponse

	/// <summary>
	/// Class of reponse of related records service.
	/// </summary>
	[DataContract]
	public class RelatedRecordsServiceResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Count of processed records.
		/// </summary>
		[DataMember(Name = "processedRecordsCount")]
		public int ProcessedRecordsCount { get; set; }

		#endregion

		#region Constructors: Public

		public RelatedRecordsServiceResponse(int processedRecordsCount) {
			this.ProcessedRecordsCount = processedRecordsCount;
		}

		public RelatedRecordsServiceResponse(Exception e)
			: base(e) { }

		#endregion

	}

	#endregion

	#region Interface: IBaseRelatedRecordsData

	/// <summary>
	/// Interface of base related records data.
	/// </summary>
	public interface IBaseRelatedRecordsData
	{

		#region Properties: Public

		/// <summary>
		/// Entity schema query of main records.
		/// </summary>
		EntitySchemaQuery MainRecordsSchemaQuery { get; set; }

		/// <summary>
		/// Entity schema query of related records.
		/// </summary>
		EntitySchemaQuery RelatedRecordsSchemaQuery { get; set; }

		/// <summary>
		/// Schema name of related in main records.
		/// </summary>
		string RelatedInMainRecordsSchemaName { get; set; }

		/// <summary>
		/// Main record colummn name.
		/// </summary>
		string MainRecordColumnName { get; set; }

		/// <summary>
		/// Related record column name.
		/// </summary>
		string RelatedRecordColumnName { get; set; }

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsHandlerData

	/// <summary>
	/// Class of related records handler data.
	/// </summary>
	public class RelatedRecordsHandlerData : IBaseRelatedRecordsData
	{

		#region Properties: Public

		/// <summary>
		/// Serialized entity schema query of main records.
		/// </summary>
		public string MainRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Entity schema query of main records.
		/// </summary>
		public EntitySchemaQuery MainRecordsSchemaQuery { get; set; }

		/// <summary>
		/// Serialized entity schema query of related records.
		/// </summary>
		public string RelatedRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Entity schema query of related records.
		/// </summary>
		public EntitySchemaQuery RelatedRecordsSchemaQuery { get; set; }

		/// <summary>
		/// Schema name of related in main records.
		/// </summary>
		public string RelatedInMainRecordsSchemaName { get; set; }

		/// <summary>
		/// Main record colummn name.
		/// </summary>
		public string MainRecordColumnName { get; set; }

		/// <summary>
		/// Related record column name.
		/// </summary>
		public string RelatedRecordColumnName { get; set; }

		/// <summary>
		/// Collection of default values.
		/// </summary>
		public IDictionary<string, string> DefaultValues { get; set; }

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsHandlerResult

	/// <summary>
	/// Class of related records handler result.
	/// </summary>
	public class RelatedRecordsHandlerResult
	{

		#region Properties: Public

		/// <summary>
		/// Count of processed records.
		/// </summary>
		public int ProcessedRecordsCount { get; set; }

		/// <summary>
		/// Exception.
		/// </summary>
		public Exception Exception { get; set; }

		#endregion

		#region Constructors: Public

		public RelatedRecordsHandlerResult(int processedRecordsCount) {
			this.ProcessedRecordsCount = processedRecordsCount;
		}

		public RelatedRecordsHandlerResult(Exception e) {
			this.ProcessedRecordsCount = -1;
			this.Exception = e;
		}

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsManagerData

	/// <summary>
	/// Class of related records manager data.
	/// </summary>
	public class RelatedRecordsManagerData : IBaseRelatedRecordsData
	{

		#region Properties: Public

		/// <inheritdoc />
		public EntitySchemaQuery MainRecordsSchemaQuery { get; set; }

		/// <inheritdoc />
		public EntitySchemaQuery RelatedRecordsSchemaQuery { get; set; }

		/// <inheritdoc />
		public string RelatedInMainRecordsSchemaName { get; set; }

		/// <inheritdoc />
		public string MainRecordColumnName { get; set; }

		/// <inheritdoc />
		public string RelatedRecordColumnName { get; set; }

		/// <summary>
		/// Collection of default values.
		/// </summary>
		public IDictionary<string, string> DefaultValues { get; set; }

		#endregion

	}

	#endregion

	#region Class: BaseRelatedRecordsProviderData

	/// <summary>
	/// Class of base related records provider data.
	/// </summary>
	public class BaseRelatedRecordsProviderData : IBaseRelatedRecordsData
	{

		#region Properties: Public

		/// <inheritdoc />
		public EntitySchemaQuery MainRecordsSchemaQuery { get; set; }

		/// <inheritdoc />
		public EntitySchemaQuery RelatedRecordsSchemaQuery { get; set; }

		/// <inheritdoc />
		public string RelatedInMainRecordsSchemaName { get; set; }

		/// <inheritdoc />
		public string MainRecordColumnName { get; set; }

		/// <inheritdoc />
		public string RelatedRecordColumnName { get; set; }

		#endregion

		#region Constructors: Public

		public BaseRelatedRecordsProviderData() { }

		public BaseRelatedRecordsProviderData(BaseRelatedRecordsProviderData baseData) {
			SetBaseProperties(baseData);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Sets base properties from passed data.
		/// </summary>
		/// <param name="baseData"><see cref="BaseRelatedRecordsProviderData"/>.</param>
		protected void SetBaseProperties(BaseRelatedRecordsProviderData baseData) {
			this.MainRecordsSchemaQuery = baseData.MainRecordsSchemaQuery;
			this.RelatedRecordsSchemaQuery = baseData.RelatedRecordsSchemaQuery;
			this.RelatedInMainRecordsSchemaName = baseData.RelatedInMainRecordsSchemaName;
			this.MainRecordColumnName = baseData.MainRecordColumnName;
			this.RelatedRecordColumnName = baseData.RelatedRecordColumnName;
		}

		#endregion

	}

	#endregion

}

