namespace Creatio.Copilot
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.File.Abstractions;

	#region Interface: ICopilotFileValidator

	/// <summary>
	/// Provides a unified entry point for file validation in Copilot scenarios.
	/// Routes file-specific validation to the appropriate validator/handler and
	/// exposes shared session content size checks.
	/// </summary>
	public interface ICopilotFileValidator
	{

		#region Methods: Public

		/// <summary>
		/// Validates file content using a file locator.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="fileLocator">The locator of the file to validate.</param>
		/// <returns>The validated file content size.</returns>
		int ValidateContent(UserConnection userConnection, IFileLocator fileLocator);

		/// <summary>
		/// Gets the total content size of all files in a session.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="sessionId">The Copilot session identifier.</param>
		/// <returns>Total session file content size.</returns>
		int GetTotalSessionFilesContentSize(UserConnection userConnection, Guid sessionId);

		/// <summary>
		/// Validates target total file content size against configured limits.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="targetContentSize">The target content size to validate.</param>
		void ValidateContentSize(UserConnection userConnection, int targetContentSize);

		/// <summary>
		/// Validates a Copilot document using the appropriate validation handler.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="document">The document to validate.</param>
		/// <param name="totalDocumentSizeInBytes">Optional total file size in bytes.</param>
		/// <returns>The validated file content size.</returns>
		int ValidateDocument(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes = null);

		/// <summary>
		/// Determines whether the specified file name belongs to an image file supported by Copilot.
		/// </summary>
		/// <param name="fileName">The file name to inspect.</param>
		/// <returns><c>true</c> if the file is a supported image; otherwise, <c>false</c>.</returns>
		bool IsImageDocument(string fileName);

		#endregion

	}

	#endregion

}

