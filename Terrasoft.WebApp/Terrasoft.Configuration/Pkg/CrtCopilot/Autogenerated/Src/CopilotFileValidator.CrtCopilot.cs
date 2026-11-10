namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;

	#region Class: CopilotFileValidator

	/// <summary>
	/// Coordinates file validation for Copilot and delegates file-type-specific checks
	/// to validation handlers.
	/// </summary>
	public class CopilotFileValidator : ICopilotFileValidator
	{

		#region Fields: Private

		private readonly IDocumentValidator _documentValidator;
		private readonly IImageValidator _imageValidator;
		private readonly IReadOnlyList<ICopilotFileValidationHandler> _handlers;

		#endregion

		#region Constructors: Public

		public CopilotFileValidator()
			: this(new DocumentValidator(), new ImageValidator()) { }

		public CopilotFileValidator(IDocumentValidator documentValidator, IImageValidator imageValidator)
			: this(documentValidator, imageValidator, CreateDefaultHandlers(documentValidator, imageValidator)) { }

		public CopilotFileValidator(IDocumentValidator documentValidator, IImageValidator imageValidator,
				IEnumerable<ICopilotFileValidationHandler> handlers) {
			_documentValidator = documentValidator ?? throw new ArgumentNullOrEmptyException(nameof(documentValidator));
			_imageValidator = imageValidator ?? throw new ArgumentNullOrEmptyException(nameof(imageValidator));
			_handlers = (handlers ?? throw new ArgumentNullOrEmptyException(nameof(handlers))).ToList();
		}

		#endregion

		#region Methods: Private

		private static IReadOnlyList<ICopilotFileValidationHandler> CreateDefaultHandlers(
				IDocumentValidator documentValidator, IImageValidator imageValidator) {
			return new ICopilotFileValidationHandler[] {
				new ImageValidationHandler(imageValidator), new DocumentValidationHandler(documentValidator)
			};
		}

		private static ICreatioAIDocument CreateDocument(IFileLocator fileLocator, string fileName) {
			if (!(fileLocator is EntityFileLocator entityFileLocator)) {
				return null;
			}
			return new CreatioAIDocument {
				FileId = entityFileLocator.RecordId,
				FileName = fileName,
				FileSchemaName = entityFileLocator.EntitySchemaName
			};
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public int ValidateContent(UserConnection userConnection, IFileLocator fileLocator) {
			IFileFactory fileFactory = userConnection.GetFileFactory().WithRightsDisabled();
			IFile file = fileFactory.Get(fileLocator);
			if (!_imageValidator.IsSupportedImage(file?.Name)) {
				return _documentValidator.ValidateContent(userConnection, fileLocator);
			}
			ICreatioAIDocument document = CreateDocument(fileLocator, file.Name);
			if (document == null) {
				throw new InvalidOperationException($"Unsupported file locator {fileLocator?.GetType().Name}");
			}
			return ValidateDocument(userConnection, document);
		}

		/// <inheritdoc />
		public int GetTotalSessionFilesContentSize(UserConnection userConnection, Guid sessionId) {
			return _documentValidator.GetTotalSessionFilesContentSize(userConnection, sessionId);
		}

		/// <inheritdoc />
		public void ValidateContentSize(UserConnection userConnection, int targetContentSize) {
			_documentValidator.ValidateContentSize(userConnection, targetContentSize);
		}

		/// <inheritdoc />
		public int ValidateDocument(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes = null) {
			ICopilotFileValidationHandler handler = _handlers.FirstOrDefault(x => x.CanHandle(document));
			if (handler == null) {
				throw new InvalidOperationException($"No validation handler found for file {document?.FileName}");
			}
			return handler.Validate(userConnection, document, totalDocumentSizeInBytes);
		}

		/// <inheritdoc />
		public bool IsImageDocument(string fileName) {
			return _imageValidator.IsSupportedImage(fileName);
		}

		#endregion

	}

	#endregion

}

