namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.File.Abstractions;
	using Terrasoft.File.Abstractions.TextExtraction;

	internal class ImageBase64Extractor : IFileTextExtractor
	{
		private readonly IImageValidator _imageValidator;

		public ImageBase64Extractor()
			: this(new ImageValidator()) { }

		public ImageBase64Extractor(IImageValidator imageValidator) {
			_imageValidator = imageValidator ?? throw new ArgumentNullOrEmptyException(nameof(imageValidator));
		}

		public IReadOnlyList<string> SupportedFileExtensions => _imageValidator.SupportedFileExtensions;

		private static void ThrowInvalidOperationException(IFile file) {
			var message = new LocalizableString("Terrasoft.File.TextExtraction",
				"Exception.TextExtractor.FileContentMissingOrUnreadable");
			message = string.Format(message, file.Name);
			throw new InvalidOperationException(message);
		}

		public string ExtractText(IFile file) {
			file.CheckArgumentNull(nameof(file));
			if (!_imageValidator.TryGetMimeType(file.Name, out string mimeType)) {
				return null;
			}
			Stream stream = file.Read();
			if (stream == null) {
				ThrowInvalidOperationException(file);
			}
			using (stream) {
				if (!stream.CanRead) {
					ThrowInvalidOperationException(file);
				}
				using (var memoryStream = new MemoryStream()) {
					stream.CopyTo(memoryStream);
					if (memoryStream.Length == 0) {
						return null;
					}
					return $"data:{mimeType};base64,{Convert.ToBase64String(memoryStream.ToArray())}";
				}
			}
		}
	}
}

