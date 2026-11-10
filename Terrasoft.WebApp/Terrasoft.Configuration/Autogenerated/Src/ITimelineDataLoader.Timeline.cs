namespace Terrasoft.Configuration.Timeline
{
	using System.Collections.Generic;

	#region ITimelineDataLoader

	/// <summary>
	/// Loads Timeline data for specific entity.
	/// </summary>
	public interface ITimelineDataLoader
	{
		/// <summary>
		/// Loads Timeline data for specific entity.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="config">Timeline load config.</param>
		List<BoundTimelineEntity> LoadData(TimelineBoundEntity entity, TimelineRequestConfig config);

	}

	#endregion

}
