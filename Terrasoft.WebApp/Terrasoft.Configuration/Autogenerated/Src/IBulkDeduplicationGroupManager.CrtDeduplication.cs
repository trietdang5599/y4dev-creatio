 namespace Terrasoft.Configuration.Deduplication
{
	using System;

	#region Interface: IBulkDeduplicationGroupManager

	/// <summary>
	/// Bulk deduplication group manager.
	/// </summary>
	public interface IBulkDeduplicationGroupManager
	{
		#region Methods: Public

		bool AddGroupToUniqueList(string entityName, Guid groupId);

		#endregion
	}

	#endregion

}
