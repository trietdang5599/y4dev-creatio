namespace Terrasoft.Configuration.Timeline
{
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region FileTimelineDataLoader

	/// <summary>
	/// Timeline data loader for File.
	/// </summary>
	[DefaultBinding(typeof(ITimelineDataLoader), Name = "SysFile")]
	public class FileTimelineDataLoader : ITimelineDataLoader
	{

		#region Constructors: Public

		public FileTimelineDataLoader(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		private ITimelineDataLoader _esqTimelineDataLoader;
		public ITimelineDataLoader EsqTimelineDataLoader {
			get {
				if (_esqTimelineDataLoader == null) {
					_esqTimelineDataLoader = new EsqTimelineDataLoader(UserConnection);
				}
				return _esqTimelineDataLoader;
			}
			set { 
				_esqTimelineDataLoader = value;
			}
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads Timeline data for file.
		/// </summary>
		/// <param name="entity">entity.</param>
		/// <param name="config">Timeline load config.</param>
		public List<BoundTimelineEntity> LoadData(TimelineBoundEntity entity, TimelineRequestConfig config) {
			entity.MasterEntityColumnName = "RecordId";
			entity.TimelineFilter = new TimelineFilter { ColumnName = "RecordSchemaName",
				ColumnValue = config.MasterEntitySchemaName,
				ComparisonType = (int)FilterComparisonType.Equal
			};
			var result = EsqTimelineDataLoader.LoadData(entity, config);
			if (UserConnection.EntitySchemaManager.FindItemByName(config.MasterEntitySchemaName + "File") != null) {
				result.AddRange(EsqTimelineDataLoader.LoadData(new TimelineBoundEntity {
					SchemaName = config.MasterEntitySchemaName + "File",
					BoundEntityName = entity.BoundEntityName,
					MasterEntityColumnName = config.MasterEntitySchemaName,
					SortColumnName = entity.SortColumnName,
					Columns = entity.Columns,
					AuthorColumnName = entity.AuthorColumnName,
					DateColumnName = entity.DateColumnName,
					Filters = entity.Filters
				}, config));
			}
			return result;
		}

		#endregion

	}

	#endregion

}  
