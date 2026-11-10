namespace Terrasoft.Configuration.Timeline
{
	using System.Collections.Generic;

	#region Interface: IEmailContentProcessor

	/// <summary>
	/// Interface for processing email content.
	/// </summary>
	public interface IEmailContentProcessor
	{

		#region Methods: Public

		/// <summary>
		/// Retrieves a preview of the email content.
		/// </summary>
		/// <param name="email">The content of the email as HTML.</param>
		/// <returns>A short snippet of the email content for preview purposes.</returns>
		string GetPreview(string email);

		/// <summary>
		/// Splits the email content into quotes, and returns it`s position in the original email.
		/// </summary>
		/// <param name="email">The content of the email as HTML.</param>
		/// <returns>A list of email parts positions, where each part represents a distinct quote or citation.</returns>
		List<(int start, int end)> GetQuotationsPosition(string email);

		#endregion

	}

	#endregion

}
