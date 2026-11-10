namespace Terrasoft.Configuration.Timeline
{

	#region Interface: IEmailTimelinePreviewCreator

	/// <summary>
	/// Interface for creating Email preview class.
	/// </summary>
	public interface IEmailTimelinePreviewCreator
	{
		/// <summary>
		/// Splits the email content into quotes, and save it asynchronously.
		/// </summary>
		/// <param name="emailId">Activity identifier of email.</param>
		/// <param name="recordId">The master record for which the preview is creating.</param>
		/// <param name="content">Content of email body.</param>
		void GetAndSavePreview(string emailId, string recordId, string content);
	}

	#endregion

}
