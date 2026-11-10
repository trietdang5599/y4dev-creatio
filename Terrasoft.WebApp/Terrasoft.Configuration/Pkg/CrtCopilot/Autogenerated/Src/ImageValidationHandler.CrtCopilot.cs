namespace Creatio.Copilot
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;

	#region Class: ImageValidationHandler

	/// <summary>
	/// Validates supported image files in the Copilot file validation chain.
	/// </summary>
	public class ImageValidationHandler : ICopilotFileValidationHandler
	{

		#region Fields: Private

		private readonly IImageValidator _imageValidator;

		#endregion

		#region Constructors: Public

		public ImageValidationHandler(IImageValidator imageValidator) {
			_imageValidator = imageValidator ?? throw new ArgumentNullOrEmptyException(nameof(imageValidator));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool CanHandle(ICreatioAIDocument document) {
			return _imageValidator.IsSupportedImage(document?.FileName);
		}

		/// <inheritdoc />
		public int Validate(UserConnection userConnection, ICreatioAIDocument document,
				int? totalDocumentSizeInBytes = null) {
			_imageValidator.ValidateImage(userConnection, document, totalDocumentSizeInBytes);
			return 0;
		}

		#endregion
	}

	#endregion

}

