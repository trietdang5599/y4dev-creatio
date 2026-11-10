namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ObjectRecordRightsActualizationProcessMethodsWrapper

	/// <exclude/>
	public class ObjectRecordRightsActualizationProcessMethodsWrapper : ProcessModel
	{

		public ObjectRecordRightsActualizationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ActualizationExecutionScriptTaskExecute", ActualizationExecutionScriptTaskExecute);
		}

		#region Methods: Private

		private bool ActualizationExecutionScriptTaskExecute(ProcessExecutingContext context) {
			// Retrieve process parameters
			var entitySchemaUId = Get<Guid>("EntitySchemaUId");
			var userConnection = Get<UserConnection>("UserConnection");
			var dateRangeIntervalDays = Get<int>("DateRangeIntervalDays");
			// Initialize and configure the rights actualizer
			var actualizer = new ObjectRecordRightsActualizer(userConnection)
			{
			    ChunkSize = Get<int>("ChunkSize"),
			    ChunkProcessingDelay = Get<int>("ChunkProcessingDelay"),
			    MaxDegreeOfParallelism = Get<int>("MaxDegreeOfParallelism")
			};
			// Get entity schema information
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var administratedObject = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			string entityName = administratedObject.Name;
			bool isActivityEntity = entitySchemaUId.Equals(ActivityConsts.ActivityEntitySchemaUId);
			// Query the oldest record date to determine the actualization range
			DateTime? oldestRecordDate = null;
			var minDateQuery = new Select(UserConnection)
				.Column(Func.Min(entityName, "CreatedOn")).As("MinCreatedOn")
				.From(entityName);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = minDateQuery.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						var columnIndex = reader.GetOrdinal("MinCreatedOn");
						if (!reader.IsDBNull(columnIndex)) {
							oldestRecordDate = reader.GetColumnValue<DateTime>("MinCreatedOn");
						}
					}
				}
			}
			// Handle case when no records exist
			if (!oldestRecordDate.HasValue) {
				var message = string.Format(Get<string>("ActualizationSuccessMessage"), entityName);
				SendReminding(message);
				return true;
			}
			var currentDate = DateTime.UtcNow;
			var totalDaysInRange = (int)(currentDate - oldestRecordDate.Value).TotalDays;
			// Calculate the number of intervals needed, ensuring at least one
			var intervalCount = Math.Max(1, (int)Math.Ceiling((double)totalDaysInRange / dateRangeIntervalDays));
			// Process records in configurable day-based intervals
			for (int currentIntervalIndex = 0; currentIntervalIndex < intervalCount; currentIntervalIndex++) {
				// Calculate interval boundaries
				var rangeStartDate = oldestRecordDate.Value.AddDays(currentIntervalIndex * dateRangeIntervalDays);
				var rangeEndDate = rangeStartDate.AddDays(dateRangeIntervalDays);
				// Ensure the final interval does not exceed the current date
				if (rangeEndDate > currentDate || currentIntervalIndex == intervalCount - 1) {
					rangeEndDate = currentDate;
				}
				// Build the date range filter for this interval
				Select recordsSelectFilter;
				if (isActivityEntity) {
					// Special handling for Activity entity: exclude email activities
					recordsSelectFilter = new Select(UserConnection)
						.Column("Id")
						.From(entityName)
						.Where("CreatedOn").IsGreaterOrEqual(Column.Parameter(rangeStartDate))
						.And("CreatedOn").IsLessOrEqual(Column.Parameter(rangeEndDate))
						.And("TypeId").IsNotEqual(Column.Parameter(ActivityConsts.EmailTypeUId)) as Select;
				} else {
					// Standard date range filter for other entities
					recordsSelectFilter = new Select(UserConnection)
						.Column("Id")
						.From(entityName)
						.Where("CreatedOn").IsGreaterOrEqual(Column.Parameter(rangeStartDate))
						.And("CreatedOn").IsLessOrEqual(Column.Parameter(rangeEndDate)) as Select;
				}
				actualizer.EntityRecordIdSelectFilter = recordsSelectFilter;
				// Execute actualization for the current interval
				try {
					actualizer.Actualize(entitySchemaUId);
				} catch (Exception) {
					// Log error using configured message parameters
					string errorMessage = entityName.IsNotNullOrEmpty()
						? string.Format(Get<string>("ErrorMessage"), entityName)
						: Get<string>("GeneralErrorMessage");
					SendReminding(errorMessage);
					throw;
				}
			}
			// Log final completion using configured success message
			var successMessage = string.Format(Get<string>("ActualizationSuccessMessage"), entityName);
			SendReminding(successMessage);
			return true;
		}

			public virtual void SendReminding(string message) {
				RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ObjectRecordRightsActualizationProcess", message);
			}

		#endregion

	}

	#endregion

}

