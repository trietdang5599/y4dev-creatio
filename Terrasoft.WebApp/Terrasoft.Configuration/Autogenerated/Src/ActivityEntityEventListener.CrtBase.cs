namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: ActivityEntityEventListener
	/// <summary>
	/// Class provides activity result filtration validation.
	/// </summary>
	[EntityEventListener(SchemaName = "Activity")]
	public class ActivityEntityEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <inheritdoc/>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			if (Features.GetIsDisabled("UseActivityResultValidation")) {
				base.OnSaving(sender, e);
				return;
			}
			var activity = (Entity)sender;
			Guid resultId = activity.GetIsColumnValueLoaded("ResultId")
				? activity.GetTypedColumnValue<Guid>("ResultId")
				: Guid.Empty;
			var userConnection = activity.UserConnection;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Entity result = entitySchemaManager.GetEntityByName("ActivityResult", userConnection);
			if (resultId.IsEmpty() || !result.FetchFromDB(resultId)) {
				base.OnSaving(sender, e);
				return;
			}
			var categoryId = activity.GetTypedColumnValue<Guid>("ActivityCategoryId");
			Entity activityCategoryResultEntry = entitySchemaManager.GetEntityByName("ActivityCategoryResultEntry", userConnection);
			var conditions = new Dictionary<string, object> {
				{ "ActivityResult", resultId },
				{ "ActivityCategory", categoryId }
			};
			if (!activityCategoryResultEntry.FetchFromDB(conditions)) {
				throw new ActivityResultNotValid("Activity result is not allowed for activity category");
			}
			var allowedResult = activity.GetTypedColumnValue<string>("AllowedResult");
			if (allowedResult.IsNotNullOrEmpty() && allowedResult.IndexOf(resultId.ToString(), StringComparison.OrdinalIgnoreCase) == -1) {
				throw new ActivityResultNotValid("Activity result is not in activity result allowed list");
			}
			base.OnSaving(sender, e);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResultNotValid

	public class ActivityResultNotValid : Exception
	{

		public ActivityResultNotValid(string message) : base(message) {
		}
	}

	#endregion

}

