namespace Terrasoft.Configuration.TextExtraction
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Wordprocessing;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.File.Abstractions;
	using Terrasoft.File.Abstractions.TextExtraction;

	#region Class: DocxTextExtractor

	/// <summary>
	/// Provides functionality to extract plain text content from Microsoft Word `.docx` files.
	/// Implements the <see cref="IFileTextExtractor"/> interface to support standardized file text extraction.
	/// </summary>
	[DefaultBinding(typeof(IFileTextExtractor), Name = nameof(DocxTextExtractor))]
	public class DocxTextExtractor : IFileTextExtractor
	{

		#region Properties: Public

		/// <inheritdoc />
		public IReadOnlyList<string> SupportedFileExtensions => new List<string> {
			"docx"
		};

		#endregion

		#region Methods: Private

		private static void ThrowInvalidOperationException(IFile file) {
			var message = new LocalizableString("Terrasoft.File.TextExtraction",
				"Exception.TextExtractor.FileContentMissingOrUnreadable");
			message = string.Format(message, file.Name);
			throw new InvalidOperationException(message);
		}

		private string ExtractAllText(Stream stream) {
			using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, false)) {
				var sb = new StringBuilder();
				var reader = OpenXmlReader.Create(wordDoc.MainDocumentPart);
				while (reader.Read()) {
					if (reader.ElementType != typeof(Text)) {
						continue;
					}
					var text = (Text)reader.LoadCurrentElement();
					sb.Append(text.Text);
				}
				return sb.ToString();
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public string ExtractText(IFile file) {
			file.CheckArgumentNull(nameof(file));
			Stream stream = file.Read();
			if (stream == null) {
				ThrowInvalidOperationException(file);
			}
			using (stream) {
				if (!stream.CanRead) {
					ThrowInvalidOperationException(file);
				}
				return ExtractAllText(stream);
			}
		}

		#endregion

	}

	#endregion

}

