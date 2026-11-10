namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Scheduler;
	using Terrasoft.Core.Tasks;

	#region Class : EmailTimelinePreviewCreator

	/// <summary>
	/// Asynchronous creating Email preview class.
	/// </summary>
	[DefaultBinding(typeof(IEmailTimelinePreviewCreator))]
	public class EmailTimelinePreviewCreator : IEmailTimelinePreviewCreator
	{

		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailTimelinePreviewCreator"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public EmailTimelinePreviewCreator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public void GetAndSavePreview(string emailId, string recordId, string content) {
			Task.StartNewWithUserConnection<EmailTimelinePreviewCreatorBackgroundTask, EmailTimelinePreviewCreatorBackgroundTaskDto>(
				new EmailTimelinePreviewCreatorBackgroundTaskDto {
					EmailId = Guid.Parse(emailId),
					RecordId = Guid.Parse(recordId),
					Content = content
				}
			);
		}

		#endregion

	}

	#endregion

} 
