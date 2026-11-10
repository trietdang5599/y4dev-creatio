namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;


	#region class : TimeLineDataCorrector

	/// <summary>
	/// Class, that can customize data for schemas in timeline.
	/// </summary>
	public static class TimeLineDataCorrector
	{
		#region Properties: Public

		public static List<Func<TimelineRequestConfig, TimelineRequestConfig>> SchemaCorrectMethods {
			get;
			private set;
		}

		/// <summary>
		/// List of entities with columns to read as administrator (ignore rights).
		/// </summary>
		public static Dictionary<string, List<string>> NoRightsCheckSchemaColumns =
			new Dictionary<string, List<string>>() {
				{ "OmniChat", new List<string>() { "Operator.Name", "Operator.Contact.Id" } }
			};
		#endregion

		#region Constructors: Public

		static TimeLineDataCorrector() {
			SchemaCorrectMethods = new List<Func<TimelineRequestConfig, TimelineRequestConfig>> {
				 CorrectContactData, AddIsNeedToCheckUserAccess, AddNoRightsCheckColumnsProperty
			};
		}

		#endregion

		#region Methods: Private

		private static TimelineRequestConfig CorrectContactData(TimelineRequestConfig config) {
			if(config.MasterEntitySchemaName == "Contact") {
				FixActivityMasterEntityColumnName(config);
				AddAdditionalBoundEntityByOmniChat(config);
			}
			return config;
		}

		private static void FixActivityMasterEntityColumnName(TimelineRequestConfig config) {
			var activitySchemas = config.BoundEntities.Where(x => x.SchemaName.Equals("Activity"));
			foreach (var activitySchema in activitySchemas)	{
				activitySchema.MasterEntityColumnName = "[ActivityParticipant:Activity:Id].Participant";
			}
		}

		private static void AddAdditionalBoundEntityByOmniChat(TimelineRequestConfig config) {
			var omniChat = config.BoundEntities.Where(x => x.SchemaName.Equals("OmniChat") &&
			x.MasterEntityColumnName == "Contact").FirstOrDefault();
			if(omniChat != null) {
				config.BoundEntities.Add(new TimelineBoundEntity(omniChat) {
					MasterEntityColumnName = "Operator.Contact"
				});
			}
		}

		private static TimelineRequestConfig AddIsNeedToCheckUserAccess(TimelineRequestConfig config) {			
			var entitySchemas = config.BoundEntities.Where(x => x.BoundEntityName.Equals("Email"));
			foreach (var entitySchema in entitySchemas) {
				entitySchema.IsNeedToCheckUserAccess = true;
			}
			return config;
		}

		private static TimelineRequestConfig AddNoRightsCheckColumnsProperty(TimelineRequestConfig config) {
			NoRightsCheckSchemaColumns.ForEach(ignoredSchema => {
				FetchColumnsWithNoAccess(config, ignoredSchema.Key, ignoredSchema.Value);
			});
			return config;
		}

		private static void FetchColumnsWithNoAccess(TimelineRequestConfig config, string schemaName, List<string> columnNames) {
			var ignoredSchemas = config.BoundEntities.Where(be => be.SchemaName.Equals(schemaName));
			if (!ignoredSchemas.Any()) {
				return;
			}
			ignoredSchemas.ForEach(entity =>
				entity.Columns?
					.Where(column => columnNames.Contains(column.ColumnName))
					.ForEach(c => c.NoRightsCheck = true)
			);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Add correction method into correction methods collection.
		/// </summary>
		/// <param name="correctMethod">Correct method.</param>
		public static void AddSchemaCorrectMethod(Func<TimelineRequestConfig, TimelineRequestConfig> correctMethod) {
			SchemaCorrectMethods.Add(correctMethod);
		}

		/// <summary>
		/// Fix timeline data query.
		/// </summary>
		/// <param name="config">Timeline request config.</param>
		public static TimelineRequestConfig MakeCorrection(TimelineRequestConfig config) {
			var correctedConfig = config;
			foreach (var correctMethod in SchemaCorrectMethods) {
				correctedConfig = correctMethod(correctedConfig);
			}
			return correctedConfig;
		}

		#endregion

	}

	#endregion
}
