namespace Terrasoft.Configuration.LiveEditing
{
	using System.Collections.Generic;
	using System;

	#region Enum: LiveEditingEventType

	/// <summary>
	/// Kind of entity event.
	/// </summary>
	public enum LiveEditingEventType {
		Inserted,
		Updated,
		Deleted
	}

	#endregion

	#region Class: EntityLiveEditingEventData

	/// <summary>
	/// Entity event parameters DTO.
	/// </summary>
	public class EntityLiveEditingEventData
	{
		/// <summary>
		/// Kind of entity event.
		/// </summary>
		public LiveEditingEventType EventType {
			get; set;
		}

		/// <summary>
		/// Name of schema that triggers event.
		/// </summary>
		public string EntitySchemaName {
			get; set;
		}

		/// <summary>
		/// Entity primary column name.
		/// </summary>
		public string PrimaryColumnName {
			get; set;
		}

		/// <summary>
		/// Entity primary column value.
		/// </summary>
		public Guid PrimaryColumnValue {
			get; set;
		}

		/// <summary>
		/// Id of user who made action.
		/// </summary>
		public Guid ModifiedById {
			get; set;
		}

		/// <summary>
		/// Timestamp of triggered event.
		/// </summary>
		public DateTime ModifiedOn {
			get; set;
		}

		/// <summary>
		/// List of column names affected by operation.
		/// </summary>
		public List<string> ColumnNames {
			get; set;
		}

		/// <summary>
		/// List of connected live schema column values.
		/// </summary>
		public Dictionary<string, object> ConnectedLiveSchemaColumns
		{
			get; set;
		}

	}

	#endregion

}
