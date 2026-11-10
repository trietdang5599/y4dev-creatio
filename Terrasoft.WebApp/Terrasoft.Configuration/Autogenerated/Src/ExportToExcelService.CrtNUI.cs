namespace Terrasoft.Configuration.ExportToExcel
{
	using System;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.OperationLog;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using Terrasoft.Web.Common;

	#region Class: ExportToExcelResponse

	/// <summary>
	/// Export to excel DTO.
	/// </summary>
	[DataContract]
	public class ExportToExcelResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public ExportToExcelResponse()
		{
		}

		public ExportToExcelResponse(Exception ex) : base(ex)
		{
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "key")]
		[JsonProperty(PropertyName = "key")]
		public string Key { get; set; }

		[DataMember(Name = "count")]
		[JsonProperty(PropertyName = "count")]
		public UInt64 Count { get; set; }

		#endregion

	}

	#endregion

	#region Class: ExportToExcelService

	/// <summary>
	/// Entity that handles excel creation request.
	/// </summary>
	public class ExportToExcelService : BaseService {

		#region Constants: Public

		public const string CanExportGridOperationCode = "CanExportGrid";
		public const string CanExportGridEntityOperationCode = "Export";
		public const string UseEntityOperationFeatureCode = "UseEntityOperationGrantee";

		#endregion

		#region Fields: Private

		private IRepository<StorableStreamEntity> _streamRepository;

		private IOperationLogger _operationLogger;

		private ExcelConverter _excelConverter;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Stream repository.
		/// </summary>
		protected IRepository<StorableStreamEntity> StreamRepository {
			get { 
				if (_streamRepository == null) {
					_streamRepository = ClassFactory.Get<IRepository<StorableStreamEntity>>();
				}
				_streamRepository.CheckArgumentNull("ExportToExcelService.StreamRepository");
				return _streamRepository;
			}
		}

		/// <summary>
		/// Operation logger.
		/// </summary>
		protected IOperationLogger OperationLogger {
			get {
				if (_operationLogger == null) {
					_operationLogger = ClassFactory.Get<IOperationLogger>();
				}
				_operationLogger.CheckArgumentNull("ExportToExcelService.OperationLogger");
				return _operationLogger;
			}
		}

		/// <summary>
		/// Error logger.
		/// </summary>
		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("Excel"));

		/// <summary>
		/// Excel converter.
		/// </summary>
		protected ExcelConverter ExcelConverter {
			get { 
				if (_excelConverter == null) {
					_excelConverter = ClassFactory.Get<ExcelConverter>(
						new ConstructorArgument("excelCulture", GetExcelCulture()));
				}
				_excelConverter.CheckArgumentNull("ExportToExcelService.ExcelConverter");
				return _excelConverter;
			}
		}

		/// <summary>
		/// Default size for excel export batch.
		/// </summary>
		protected int DefaultExcelExportBatchSize => 2000;

		/// <summary>
		/// Excel export batch size system setting name.
		/// </summary>
		protected string ExcelExportBatchSizeSettingsName => "ExcelExportBatchSize";

		/// <summary>
		/// Size for excel export batch
		/// </summary>
		protected int BatchSize {
			get {
				if (Convert.ToBoolean(Core.Configuration.SysSettings.TryGetValue(UserConnection,
					ExcelExportBatchSizeSettingsName, out var batchSizeSetting))) {
					if (batchSizeSetting is int batchSize) {
						return batchSize;
					} else {
						return DefaultExcelExportBatchSize;
					}
				} else {
					return DefaultExcelExportBatchSize;
				}
			}
		}

		#endregion

		#region Methods: Private

		private CultureInfo GetExcelCulture() {
			var currentUser = UserConnection.CurrentUser;
			try {
				var dateTimeFormatCode = currentUser?.DateTimeFormatCode;
				if (!string.IsNullOrEmpty(dateTimeFormatCode)) {
					return CultureInfo.GetCultureInfo(dateTimeFormatCode);
				}
			} catch (CultureNotFoundException ex) {
				Log.Error($"CultureNotFoundException. {ex}");
			}
			return currentUser?.Culture;
		}

		private EntitySchemaQuery RemoveBinaryColumnsFromQuery(EntitySchemaQuery entitySchemaQuery) {
			var columns = entitySchemaQuery.Columns.Where(x =>
						x.GetResultDataValueType(entitySchemaQuery.RootSchema.DataValueTypeManager) is BinaryDataValueType
						|| x.GetResultDataValueType(entitySchemaQuery.RootSchema.DataValueTypeManager) is ImageLookupDataValueType)
					.ToList();
			foreach (var column in columns) {
				entitySchemaQuery.RemoveColumn(column.Name);
			}
			return entitySchemaQuery;
		}

		private void CheckCanExport(string schemaName) {
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation(CanExportGridOperationCode);
			} catch (SecurityException e) {
				if (UserConnection.GetIsFeatureEnabled(UseEntityOperationFeatureCode)) {
					UserConnection.DBSecurityEngine.CheckCanExecuteEntityOperation(schemaName, CanExportGridEntityOperationCode);
				} else {
					throw;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates and writes excel stream to local storage and return export key.
		/// </summary>
		/// <param name="esqSerialized">Serialized export esq.</param>
		/// <returns><see cref="ExportToExcelResponse"/>.</returns>
		public virtual ExportToExcelResponse PrepareExport(string esqSerialized) {
			esqSerialized.CheckArgumentNull("ExportToExcelService.PrepareExport esqSerialized");
			UserConnection.CheckArgumentNull("ExportToExcelService UserConnection");
			var selectQuery = Json.Deserialize<SelectQuery>(esqSerialized);
			selectQuery.CheckArgumentNull("ExportToExcelService.PrepareExport deserialized SelectQuery");
			CheckCanExport(selectQuery.RootSchemaName);
			var entitySchemaQuery = selectQuery.BuildEsq(UserConnection);
			entitySchemaQuery.CheckArgumentNull("ExportToExcelService.PrepareExport entitySchemaQuery");
			entitySchemaQuery = RemoveBinaryColumnsFromQuery(entitySchemaQuery);
			ExcelConverter.BatchSize = BatchSize;
			var excelData = ExcelConverter.GetExcelData(entitySchemaQuery, UserConnection);
			OperationLogger.LogDataExportOperation(UserConnection, ExcelConverter.ExportedRowCount, entitySchemaQuery);
			var storableExcelStream = new StorableStreamEntity { Data = excelData };
			var id = StreamRepository.Create(storableExcelStream);
			return new ExportToExcelResponse {
				Key = id.ToString(),
				Count = ExcelConverter.ExportedRowCount
			};
		}

		/// <summary>
		/// Returns excel memory stream by id and removes it from storage.
		/// </summary>
		/// <returns>Excel memory stream.</returns>
		public virtual Stream GetExcelStream(string id) {
			var streamId = Guid.Parse(id);
			var stream = StreamRepository.Find(streamId);
			StreamRepository.Remove(streamId);
			return new MemoryStream(stream.Data);
		}

		#endregion
	}

	#endregion
}
