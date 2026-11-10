namespace Terrasoft.Configuration.Timeline
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using DataValueType = Nui.ServiceModel.DataContract.DataValueType;

	#region class : TimelineEntityCollection

	[KnownType(typeof(LookupColumnValue))]
	public class TimelineEntityCollection : List<BoundEntityColumn>
	{
	}

	#endregion

	#region class : TimelineRequestConfig

	[DataContract]
	public class TimelineRequestConfig
	{
		/// <summary>
		/// Schema for which timeline is being loaded.
		/// </summary>
		[DataMember(Name = "masterEntitySchemaName")]
		public string MasterEntitySchemaName { get; set; }
		/// <summary>
		/// Record identifier.
		/// </summary>
		[DataMember(Name = "masterRecordId")]
		public string MasterRecordId { get; set; }
		/// <summary>
		/// Timeline record identifier.
		/// </summary>
		[DataMember(Name = "recordId")]
		public string RecordId { get; set; }
		/// <summary>
		/// Number of rows to downloadOffset number of rows.
		/// </summary>
		[DataMember(Name = "rowCount")]
		public int RowCount { get; set; }
		/// <summary>
		/// Offset number of rows.
		/// </summary>
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
		/// <summary>
		/// Offset number of rows.Entities on which it is built
		/// </summary>
		[DataMember(Name = "boundEntities")]
		/// <summary>
		/// Entities on which timmeline is built in
		/// </summary>
		public List<TimelineBoundEntity> BoundEntities { get; set; }
		/// <summary>
		/// Filters for entities
		/// </summary>
		[DataMember(Name = "filters")]
		public string Filters { get; set; }
		/// <summary>
		/// Order direction
		/// </summary>
		[DataMember(Name = "orderDirection")]
		public OrderDirection OrderDirection { get; set; }
		/// <summary>
		/// Search filter.
		/// </summary>
		[DataMember(Name = "search")]
		public string Search { get; set; }

	}

	#endregion

	#region class : TimelineBoundEntity

	[DataContract]
	public class TimelineBoundEntity
	{

		#region Properties: Public

		/// <summary>
		/// Entity schema name.
		/// </summary>
		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }
		/// <summary>
		/// Name of column which will be used for sorting.
		/// </summary>
		[DataMember(Name = "sortColumnName")]
		public string SortColumnName { get; set; }
		/// <summary>
		/// Name of column which connect entity with master entity.
		/// </summary>
		[DataMember(Name = "masterEntityColumnName")]
		public string MasterEntityColumnName { get; set; }
		/// <summary>
		/// Entity columns.
		/// </summary>
		[DataMember(Name = "columns")]
		public List<TimelineColumnConfig> Columns { get; set; }
		/// <summary>
		/// Entity data loader, which will be used for loading data.
		/// </summary>
		[DataMember(Name = "entitySchemaDataSource")]
		public string EntitySchemaDataSource { get; set; }
		/// <summary>
		/// Name of column which will be shown as author column in timeline.
		/// </summary>
		[DataMember(Name = "authorColumnName")]
		public string AuthorColumnName { get; set; }
		/// <summary>
		/// Filter column and it`s value.
		/// </summary>
		[DataMember(Name = "tileFilter")]
		public TimelineFilter TimelineFilter { get; set; }
		/// <summary>
		/// Name of column which will be shown as date column in timeline.
		/// </summary>
		[DataMember(Name = "dateColumnName")]
		public string DateColumnName { get; set; }
		
		/// <summary>
		/// Field to map timeline entity config with entity data. Do not modify value.
		/// </summary>
		[DataMember(Name = "boundEntityName")]
		public string BoundEntityName { get; set; }
		/// <summary>
		/// Is need to check user access for records loading into timeline.
		/// </summary>
		public bool IsNeedToCheckUserAccess { get; set; } = false;
		/// <summary>
		/// Additional filters.
		/// </summary>
		[DataMember(Name = "filters")]
		public string Filters { get; set; }

		#endregion

		#region Methods: Private

		private List<TimelineColumnConfig> GetBoundEntityColumnsCopy(List<TimelineColumnConfig> columns) {
			var result = new List<TimelineColumnConfig>();
			foreach (var column in columns) {
				result.Add(new TimelineColumnConfig {
					ColumnName = column.ColumnName
				});
			}
			return result;
		}

		#endregion

		#region Constructors: Public

		public TimelineBoundEntity() {
		}

		public TimelineBoundEntity(TimelineBoundEntity item) {
			SchemaName = item.SchemaName;
			SortColumnName = item.SortColumnName;
			MasterEntityColumnName = item.MasterEntityColumnName;
			Columns = item.Columns != null ? GetBoundEntityColumnsCopy(item.Columns) : null;
			EntitySchemaDataSource = item.EntitySchemaDataSource;
			AuthorColumnName = item.AuthorColumnName;
			TimelineFilter = item.TimelineFilter != null ? new TimelineFilter() {
				ColumnName = item.TimelineFilter.ColumnName,
				ColumnValue = item.TimelineFilter.ColumnValue,
				ComparisonType = item.TimelineFilter.ComparisonType,
			} : null;
			DateColumnName = item.DateColumnName;
			BoundEntityName = item.BoundEntityName;
			IsNeedToCheckUserAccess = item.IsNeedToCheckUserAccess;
		}

		#endregion

	}

	#endregion

	#region class : TimelineFilter

	[DataContract]
	public class TimelineFilter
	{
		#region Properties: Public

		[DataMember(Name = "columnName")]
		public string ColumnName { get; set; }

		[DataMember(Name = "columnValue")]
		public object ColumnValue { get; set; }

		[DataMember(Name = "comparisonType")]
		public int? ComparisonType { get; set; }

		#endregion

	}

	#endregion

	#region class : TimelineColumnConfig

	[DataContract]
	public class TimelineColumnConfig
	{
		[DataMember(Name = "columnName")]
		public string ColumnName { get; set; }

		/// <summary>
		/// Ignore administration permissions for column reading.
		/// </summary>
		public bool NoRightsCheck = false;
	}

	#endregion

	#region class : BoundEntityColumn

	[DataContract]
	public class BoundEntityColumn
	{
		/// <summary>
		/// Name of column.
		/// </summary>
		[DataMember(Name = "columnName")]
		public string ColumnName { get; set; }
		/// <summary>
		/// Value of column.
		/// </summary>
		[DataMember(Name = "columnValue")]
		public LookupColumnValue ColumnValue { get; set; }
		/// <summary>
		/// Caption of column.
		/// </summary>
		[DataMember(Name = "columnCaption")]
		public string ColumnCaption { get; set; }		
		/// <summary>
		/// Column data type.
		/// </summary>
		[DataMember(Name = "columnDataType")]
		public TimelineColumnDataType ColumnDataType { get; set; }
	}

	#endregion

	#region class : TimelineColumnDataType

	[DataContract]
	public class TimelineColumnDataType
	{
		/// <summary>
		/// Column data type.
		/// </summary>
		[DataMember(Name = "dataValueType")]
		public DataValueType DataValueType { get; set; }
		/// <summary>
		/// Lookup indicator.
		/// </summary>
		[DataMember(Name = "isLookup")]
		public bool IsLookup { get; set; }
		/// <summary>
		/// Lookup schema for lookup.
		/// </summary>
		[DataMember(Name = "referenceSchemaName")]
		public string ReferenceSchemaName { get; set; }
	}

	#endregion

	#region class : BoundTimelineEntity

	[DataContract]
	public class BoundTimelineEntity
	{
		/// <summary>
		/// Entity schema name.
		/// </summary>
		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }
		[DataMember(Name = "columnValues")]
		public TimelineEntityCollection ColumnValues { get; set; }
		
		/// <summary>
		/// Entity schema name.
		/// </summary>
		[DataMember(Name = "primaryDisplayColumnName")]
		public string PrimaryDisplayColumnName { get; set; }
		
		/// <summary>
		/// Record identifier.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }
		
		/// <summary>
		/// Entity identifier.
		/// </summary>
		[DataMember(Name = "entityId")]
		public Guid EntityId { get; set; }
		
		/// <summary>
		/// Column value which was used for sorting while loading and sorting data.
		/// </summary>
		[DataMember(Name = "sortColumn")]
		public string SortColumn { get; set; }
		
		/// <summary>
		/// Author shown on timeline tile.
		/// </summary>
		[DataMember(Name = "author")]
		public LookupColumnValue Author { get; set; }
		
		/// <summary>
		/// Shown date on timeline tile.
		/// </summary>
		[DataMember(Name = "date")]
		public string Date { get; set; }
		
		/// <summary>
		/// Field to map timeline entity config with entity data. Do not modify value.
		/// </summary>
		[DataMember(Name = "boundEntityName")]
		public string BoundEntityName { get; set; }
		
		/// <summary>
		/// User access <see cref="UserType"/>.
		/// </summary>
		[DataMember(Name = "userAccess")]
		public UserType UserAccess { get; set; } = UserType.General;

	}

	#endregion

	#region class : TimelineDataResponse

	[DataContract]

	public class TimelineDataResponse : ConfigurationServiceResponse
	{
		[DataMember(Name = "entities")]
		public List<BoundTimelineEntity> Entities { get; set; }

		[DataMember(Name = "hasPostponedColumns")]
		public bool HasPostponedColumns { get; set; }
	}

	#endregion

	#region Class: TimelineService


	/// <summary>
	/// Service for loading timeline data.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TimelineService : BaseService, IReadOnlySessionState
	{
		#region Properties: Protected

		private TimelineDataManager _loader;
		protected TimelineDataManager Loader {
			get	{
				if (_loader == null) {
					return _loader = new TimelineDataManager(GetUserConnection());
				}
				return _loader;
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _timelineLogger;
		protected ILog TimelineLogger {
			get {
				return _timelineLogger ?? (_timelineLogger = LogManager.GetLogger("Timeline"));
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
		   ResponseFormat = WebMessageFormat.Json)]
		public TimelineDataResponse LoadData(TimelineRequestConfig config) {
			TimelineDataResponse response = new TimelineDataResponse();
			try {
				response = Loader.GetDataWithoutLargeColumns(TimeLineDataCorrector.MakeCorrection(config));
			} catch (Exception ex) {
				response.Success = false;
				response.Exception = ex;
				TimelineLogger.Error(ex.Message);
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
		   ResponseFormat = WebMessageFormat.Json)]
		public TimelineDataResponse LoadLargeColumns(TimelineRequestConfig config) {
			TimelineDataResponse response = new TimelineDataResponse();
			try {
				response = Loader.GetLargeColumns(TimeLineDataCorrector.MakeCorrection(config));
				response.Entities = response.Entities.Where(x => x.ColumnValues.Count > 0).ToList();
			} catch (Exception ex) {
				response.Success = false;
				response.Exception = ex;
				TimelineLogger.Error(ex.Message);
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
		   ResponseFormat = WebMessageFormat.Json)]
		public TimelineDataResponse GetSingleEntityData(TimelineRequestConfig config) {
			TimelineDataResponse response = new TimelineDataResponse();
			try {
				response = Loader.GetSingleEntityData(config);
			} catch (Exception ex) {
				response.Success = false;
				response.Exception = ex;
				TimelineLogger.Error(ex.Message);
			}
			return response;
		}

		#endregion

	}

	#endregion
}
