namespace Creatio.Copilot
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;

	#region Class: DocumentValidationHandler

	/// <summary>
	/// Fallback validation handler for non-image documents in the Copilot file validation chain.
	/// </summary>
	public class DocumentValidationHandler : ICopilotFileValidationHandler
	{

		#region Fields: Private

		private readonly IDocumentValidator _documentValidator;

		#endregion

		#region Constructors: Public

		public DocumentValidationHandler(IDocumentValidator documentValidator) {
			_documentValidator = documentValidator ?? throw new ArgumentNullOrEmptyException(nameof(documentValidator));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool CanHandle(ICreatioAIDocument document) {
			return document != null;
		}

		/// <inheritdoc />
		public int Validate(UserConnection userConnection, ICreatioAIDocument document,
				int? totalDocumentSizeInBytes = null) {
			return _documentValidator.ValidateDocument(userConnection, document, totalDocumentSizeInBytes);
		}

		#endregion
	}

	#endregion

}

