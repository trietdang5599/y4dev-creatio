namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core;

	/// <summary>
	/// Webhook log writer.
	/// </summary>
	public class WebhookLogWriter
	{

		#region Fields: Private

		private readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public WebhookLogWriter(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Log webhook error.
		/// </summary>
		/// <param name="webhookId">webhook id.</param>
		/// <param name="massage">Error message.</param>
		public void LogWebhookError(Guid webhookId, string massage) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("WebhookLog");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("WebhookId", webhookId);
			entity.SetColumnValue("Message", massage);
			entity.Save();
		}

		#endregion

	}
}
