namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;

	#region Interface: IBulkDeduplicationManagerV2

	/// <summary>
	/// Bulk deduplication manager interface.
	/// </summary>
	public interface IBulkDeduplicationManagerV2 : IBulkDeduplicationManager
	{

		#region Methods: Public

		/// <summary>
		/// Gets groups of duplicate entities.
		/// </summary>
		/// <param name="parameters">Parameters object.</param>
		/// <returns>Groups of duplicate entities.</returns>
		BulkDuplicatesGroupResponse GetGroupsOfDuplicates(GetGroupsOfDuplicatesParams parameters);
		
		/// <summary>
		/// Gets duplicates by group.
		/// </summary>
		/// <param name="parameters">Parameters object.</param>
		/// <returns>Duplicates by group.</returns>
		BulkEntityClientDuplicatesGroup GetDuplicateEntitiesByGroup(GetDuplicateEntitiesByGroupParams parameters);
		
		/// <summary>
		/// Gets unique records ids from specified duplicates ids.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="duplicatesIds">Unique record array.</param>
		/// <returns>Unique records ids from specified duplicates ids.</returns>
		IEnumerable<Guid> GetUniqueRecordsIdsFromDuplicates(string entityName, IEnumerable<Guid> duplicatesIds);

		/// <summary>
		/// Cancel deduplication task.
		/// </summary>
		/// <param name="sectionName">Section name.</param>
		void CancelDeduplicationTask(string sectionName);

		#endregion

	}

	#endregion

}
