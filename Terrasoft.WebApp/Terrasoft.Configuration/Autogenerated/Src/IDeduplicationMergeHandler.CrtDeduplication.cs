namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Entities;
	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;

	#region Class: ValidateDuplicatesResponse

	/// <summary>
	/// Validation result of merge duplicate entities.
	/// </summary>
	public class ValidateDuplicatesResponse {

		public bool ConflictsExists {
			get {
				return (Conflicts != null) && (Conflicts.Any());
			}
		}

		public DataContract.EntityCollection Conflicts {
			get;
			set;
		}

		public ValidateDuplicatesResponse() {
			Conflicts = new DataContract.EntityCollection();
		}

	}

	#endregion

	#region Interface: IDeduplicationMergeHandler

	/// <summary>
	/// Implement merging collection of entities into golden entity.
	/// </summary>
	public interface IDeduplicationMergeHandler{

		/// <summary>
		/// Get collection of entity for merge.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="ids">Collection of entity identifiers.</param>
		/// <param name="columns">Names of columns to read.</param>
		/// <param name="unsavedRecordList">Optional data for an unsaved (transient) records list to get entity duplicate.</param>
		/// <returns>Collection of entity.</returns>
		EntityCollection GetEntityDublicates(string schemaName, List<Guid> ids, List<string> columns = null, List<Dictionary<string, object>> unsavedRecordList = null);

		/// <summary>
		/// Validates duplicate entities.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="duplicateRecordIds">Collection of entity identifiers.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		/// <param name="unsavedRecordList">Optional data for an unsaved (transient) records list to participate in validation.</param>
		/// <returns>Validation result.</returns>
		ValidateDuplicatesResponse ValidateDuplicates(string schemaName, List<Guid> duplicateRecordIds,
				Dictionary<string, string> resolvedConflicts, List<Dictionary<string, object>> unsavedRecordList = null);

		/// <summary>
		/// Setting group value to negative to exclude from result list for merge.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results.</param>
		void ExcludeSearchResultGroup(string schemaName, int groupId);

		/// <summary>
		/// Merge collection of entities into golden entity.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results.</param>
		/// <param name="duplicateRecordIds">Collection of entity identifiers.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		void MergeEntityDublicates(string schemaName, int groupId, List<Guid> duplicateRecordIds,
				Dictionary<string, string> resolvedConflicts);

		/// <summary>
		/// Merge collection of entities into golden entity.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results.</param>
		/// <param name="duplicateRecordIds">Collection of entity identifiers.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		/// <param name="unsavedRecordList">Optional data for an unsaved (transient) records  to participate in merge.</param>
		void MergeEntityDublicates(string schemaName, int groupId, List<Guid> duplicateRecordIds, 
				Dictionary<string, string> resolvedConflicts, List<Dictionary<string, object>> unsavedRecordList);

	}

	#endregion
}

