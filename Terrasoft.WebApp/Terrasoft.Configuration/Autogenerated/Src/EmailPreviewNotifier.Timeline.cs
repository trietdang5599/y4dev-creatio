namespace Terrasoft.Configuration.Timeline
{
	using global::Common.Logging;
	using System;
	using Terrasoft.Messaging.Common;
	using Newtonsoft.Json;

	#region class: EmailPreview

	/// <summary>
	/// Email preview DTO.
	/// </summary>
	public class EmailPreview
	{
		/// <summary>
		/// Id of email Activity entity.
		/// </summary>
		public Guid EmailId { get; set; }

		/// <summary>
		/// Short email preview.
		/// </summary>
		public string PreviewBody { get; set; }
	}

	#endregion

	#region Class: EmailPreviewNotifier

	/// <summary>
	/// Class for sending an Email preview via websockets.
	/// </summary>
	public class EmailPreviewNotifier
	{
		#region Properties: private

		private string websocketSenderName = "EmailPreview";

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _timelineLogger;
		protected ILog TimelineLogger {
			get
			{
				return _timelineLogger ?? (_timelineLogger = LogManager.GetLogger("Timeline"));
			}
		}

		#endregion

		#region Methods: private

		private void Notify(Guid userId, object data) {
			try {
				MsgChannelManager msgManager = MsgChannelManager.Instance;
				var message = new SimpleMessage {
					Body = SerializeObject(data),
					Header = { Sender = websocketSenderName, BodyTypeName = "System.String" }
				};
				msgManager.Post(new[] { userId }, message);
			} catch (Exception e) {
				TimelineLogger.Error($"EmailPreviewNotifier: Error while posting WS message to the user {userId}", e);
			}
		}

		private string SerializeObject(object data) {
			return JsonConvert.SerializeObject(data);
		}

		#endregion

		#region Methods: public

		/// <summary>
		/// Send email preview to user via websockets.
		/// </summary>
		/// <param name="preview">Preview of email</param>
		/// <param name="userId">User ID of the user to whom the preview will be sent.</param>
		public virtual void SendEmailPreview(EmailPreview preview, Guid userId) {
			Notify(userId, new {id= preview.EmailId, content = preview.PreviewBody});
		}

		#endregion
	}

	#endregion
}

