namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;

	#region Interface: IImageValidator

	/// <summary>
	/// Provides validation and metadata helpers for supported image files.
	/// </summary>
	public interface IImageValidator
	{

		#region Properties: Public

		/// <summary>
		/// Gets the list of supported image file extensions.
		/// </summary>
		IReadOnlyList<string> SupportedFileExtensions { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Determines whether the specified file name belongs to a supported image file.
		/// </summary>
		/// <param name="fileName">The file name to inspect.</param>
		/// <returns><c>true</c> if the file is a supported image; otherwise, <c>false</c>.</returns>
		bool IsSupportedImage(string fileName);

		/// <summary>
		/// Attempts to resolve MIME type for the specified image file.
		/// </summary>
		/// <param name="fileName">The file name to inspect.</param>
		/// <param name="mimeType">The resolved MIME type.</param>
		/// <returns><c>true</c> if MIME type was resolved; otherwise, <c>false</c>.</returns>
		bool TryGetMimeType(string fileName, out string mimeType);

		/// <summary>
		/// Validates the specified image document.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		/// <param name="document">The document to validate.</param>
		/// <param name="totalDocumentSizeInBytes">Optional total file size in bytes.</param>
		void ValidateImage(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes = null);

		#endregion

	}

	#endregion

	#region Class: ImageValidator

	/// <summary>
	/// Default implementation of <see cref="IImageValidator"/>.
	/// </summary>
	public class ImageValidator : IImageValidator
	{

		#region Constants: Private

		private const string CreatioAiAllowedFileExtensionsSettingName = "CreatioAIAllowedFileExtensions";
		private const string DefaultAllowedFileExtensions = "jpeg,jpg,png,heic";
		private const string CreatioAiMaxSessionFileSizeSettingName = "CreatioAIMaxSessionFileSize";
		private const int DefaultMaxSessionFileSizeInMb = 5;

		#endregion

		#region Fields: Private

		private static readonly Dictionary<string, string> MimeTypes =
			new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
				{ ".jpg", "image/jpeg" },
				{ ".jpeg", "image/jpeg" },
				{ ".png", "image/png" },
				{ ".heic", "image/heic" }
			};

		#endregion

		#region Properties: Public

		/// <inheritdoc />
		public IReadOnlyList<string> SupportedFileExtensions { get; } = new List<string> {
			"jpg",
			"jpeg",
			"png",
			"heic"
		};

		#endregion

		#region Methods: Private

		private static int? GetTotalSize(ICreatioAIDocument document, UserConnection userConnection) {
			int? totalSize = null;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, document.FileSchemaName);
			esq.AddColumn("TotalSize");
			var entity = esq.GetEntity(userConnection, document.FileId);
			if (entity != null) {
				totalSize = entity.GetTypedColumnValue<int>("TotalSize");
			}
			return totalSize;
		}

		private static void ValidateExtension(UserConnection userConnection, string fileName) {
			string allowedExtensions = SysSettings.GetValue(userConnection, CreatioAiAllowedFileExtensionsSettingName,
				DefaultAllowedFileExtensions);
			HashSet<string> allowedList = allowedExtensions.Split(',')
				.Select(e => e.Trim().ToLowerInvariant()).ToHashSet();
			string fileExtension = Path.GetExtension(fileName);
			if (string.IsNullOrEmpty(fileExtension) ||
				!allowedList.Contains(fileExtension.TrimStart('.').ToLowerInvariant())) {
				string message = userConnection
					.GetLocalizableString("DocumentNotSupportedExtension", nameof(DocumentValidator)).Format(fileName);
				throw new InvalidOperationException(message);
			}
		}

		private static void ValidateTotalSize(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes) {
			if (totalDocumentSizeInBytes == null) {
				totalDocumentSizeInBytes = GetTotalSize(document, userConnection);
			}
			int fileSizeLimitInBytes = SysSettings.GetValue(userConnection, CreatioAiMaxSessionFileSizeSettingName,
				DefaultMaxSessionFileSizeInMb) * 1024 * 1024;
			if (totalDocumentSizeInBytes.HasValue && totalDocumentSizeInBytes.Value > fileSizeLimitInBytes) {
				string message = userConnection
					.GetLocalizableString("DocumentMaxAllowedSize", nameof(DocumentValidator))
					.Format(document.FileName, fileSizeLimitInBytes);
				throw new InvalidOperationException(message);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool IsSupportedImage(string fileName) {
			return TryGetMimeType(fileName, out _);
		}

		/// <inheritdoc />
		public bool TryGetMimeType(string fileName, out string mimeType) {
			mimeType = null;
			if (string.IsNullOrWhiteSpace(fileName)) {
				return false;
			}
			string extension = Path.GetExtension(fileName);
			return MimeTypes.TryGetValue(extension ?? string.Empty, out mimeType);
		}

		/// <inheritdoc />
		public void ValidateImage(UserConnection userConnection, ICreatioAIDocument document,
			int? totalDocumentSizeInBytes = null) {
			ValidateExtension(userConnection, document.FileName);
			ValidateTotalSize(userConnection, document, totalDocumentSizeInBytes);
			if (!IsSupportedImage(document.FileName)) {
				string message = userConnection
					.GetLocalizableString("DocumentNotSupportedExtension", nameof(DocumentValidator))
					.Format(document.FileName);
				throw new InvalidOperationException(message);
			}
		}

		#endregion

	}

	#endregion

}

