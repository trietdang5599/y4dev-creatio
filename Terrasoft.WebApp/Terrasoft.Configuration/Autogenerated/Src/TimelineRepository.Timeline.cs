namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Configuration.Section;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Enum: TileDataSource

	public enum TileDataSource
	{
		Entity = 0,
		Complex = 1
	}

	#endregion

	#region Class: TimelineTileSource

	[Serializable]
	[DataContract]
	public class TimelineTileSource
	{
		/// <summary>
		/// Name of source.
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// UId of entity.
		/// </summary>
		[DataMember]
		public Guid UId { get; set; }

		/// <summary>
		/// Data source type.
		/// </summary>
		[DataMember]
		public TileDataSource DataSource { get; set; }
	}

	#endregion

	#region Class: ITimelineRepository

	public interface ITimelineRepository
	{
		/// <summary>
		/// Returns all timeline sources <see cref="TimelineTileSource"/>.
		/// </summary>
		/// <param name="referenceSchemaName">Name of reference schema.</param>
		/// <returns>List of sources.</returns>
		List<TimelineTileSource> GetTimelineSources(string referenceSchemaName);

		/// <summary>
		/// Adds new item to timeline sources.
		/// </summary>
		/// <param name="newItem">New item <see cref="TimelineTileSource"/>.</param>
		void AddTimelineSource(TimelineTileSource newItem);
	}

	#endregion

	#region Class: TimelineRepository

	/// <summary>
	/// Repository of timeline data.
	/// </summary>
	[DefaultBinding(typeof(ITimelineRepository))]
	public class TimelineRepository: ITimelineRepository
	{

		/// <summary>
		/// <see cref="ISectionManager"/> implementation instance.
		/// </summary>
		private readonly ISectionManager _sectionManager;
		private readonly UserConnection _userConnetion;
		private const string CACHE_KEY = "Timeline_Sources";

		#region Constructors: Public

		public TimelineRepository(UserConnection uc) {
			_userConnetion = uc;
			_sectionManager = ClassFactory.Get<ISectionManager>(new ConstructorArgument("uc", uc),
				new ConstructorArgument("sectionType", SectionType.General.ToString()));
		}

		#endregion

		#region Methods: Private

		private List<TimelineTileSource> GetFromCache() {
			return _userConnetion.ApplicationCache[CACHE_KEY] as List<TimelineTileSource>;
		}

		private void UpdateCache(List<TimelineTileSource> sources) {
			_userConnetion.ApplicationCache[CACHE_KEY] = sources;
		}

		private List<TimelineTileSource> GetSectionEntities() {
			List<Section> sections = _sectionManager.GetByType(SectionType.General).ToList();
			List<TimelineTileSource> sources = new List<TimelineTileSource>();
			sections.ForEach(s => {
				var entity = _userConnetion.EntitySchemaManager.FindInstanceByUId(s.EntityUId);
				if (entity != null) {
					sources.Add(new TimelineTileSource {
						Name = entity.Name,
						UId = s.EntityUId,
						DataSource = TileDataSource.Entity
					});
				}
			});
			return sources;
		}

		private List<TimelineTileSource> GetComplexSources() {
			return new List<TimelineTileSource> {
				new TimelineTileSource {
					Name = "ESN",
					DataSource = TileDataSource.Complex
				}
			};
		}

		private List<TimelineTileSource> GetAllSources() {
			var sources = GetSectionEntities();
			var complex = GetComplexSources();
			sources.AddRange(complex);
			UpdateCache(sources);
			return sources;
		}

		private List<TimelineTileSource> FilterByReferenceSchema(List<TimelineTileSource> list, string referenceSchemaName) {
			return list.Where(l => {
				if (l.DataSource != TileDataSource.Entity) {
					return true;
				} else {
					var entity = _userConnetion.EntitySchemaManager.FindInstanceByUId(l.UId);
					var isFound = false;
					if (entity != null) {
						var referenceColumns = entity.Columns.Where(c => c.ReferenceSchema?.Name == referenceSchemaName);
						if (referenceColumns.Any()) {
							isFound = true;
						}
					}
					return isFound;
				}
			}).ToList();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns all timeline sources <see cref="TimelineTileSource"/>.
		/// </summary>
		/// <param name="referenceSchemaName">Name of reference schema.</param>
		/// <returns>List of sources.</returns>
		public List<TimelineTileSource> GetTimelineSources(string referenceSchemaName) {
			var sources = GetFromCache() ?? GetAllSources();
			return FilterByReferenceSchema(sources, referenceSchemaName);
		}

		/// <summary>
		/// Adds new item to timeline sources.
		/// </summary>
		/// <param name="newItem">New item <see cref="TimelineTileSource"/>.</param>
		public void AddTimelineSource(TimelineTileSource newItem) {
			var sources = GetFromCache() ?? GetAllSources();
			sources.Add(newItem);
			UpdateCache(sources);
		}

		#endregion
	}

	#endregion

}

