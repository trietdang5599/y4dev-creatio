namespace Creatio.Copilot
{
	using Terrasoft.Core;

	#region Interface: ICopilotFileValidationHandler

	/// <summary>
	/// Represents a handler in the Copilot file validation chain.
	/// </summary>
	public interface ICopilotFileValidationHandler
	{

		#region Methods: Public

		/// <summary>
		/// Determines whether the current handler can validate the specified document.
		/// </summary>
		/// <param name="document">The document to inspect.</param>
		/// <returns><c>true</c> if the handler can process the document; otherwise, <c>false</c>.</returns>
		bool CanHandle(ICreatioAIDocument document);

		/// <summary>
		/// Validates the specified document.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="document">The document to validate.</param>
		/// <param name="totalDocumentSizeInBytes">Optional total file size in bytes.</param>
		/// <returns>The validated file content size.</returns>
		int Validate(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes = null);

		#endregion

	}

	#endregion

}

