namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Factories;

	#region Class: AttachmentsAppTemplateMacrosProvider

	/// <summary>
	/// Provides additional macros for file list control in application being created from template.
	/// </summary>
	[DefaultBinding(typeof(IAppTemplateMacrosProvider), Name = "FileListAppTemplateMacrosProvider")]
	public class FileListAppTemplateMacrosProvider : IAppTemplateMacrosProvider
	{

		#region Constants: Private

		private const string FileEntityNameMacro = "FileEntityName";
		private const string FileEntityRecordColumnNameMacro = "FileEntityRecordColumnName";
		private const string DefaultFileEntityName = "SysFile";
		private const string DefaultFileEntityRecordColumnName = "RecordId";

		#endregion

		#region Fields: Private

		private readonly IFileSchemaProvider _fileSchemaProvider;

		#endregion

		#region Constructors: Public

		public FileListAppTemplateMacrosProvider(IFileSchemaProvider fileSchemaProvider) {
			_fileSchemaProvider = fileSchemaProvider.EnsureDependencyNotNull(nameof(fileSchemaProvider));
		}

		#endregion

		#region Methods: Private

		private static Dictionary<string, string> GetFileEntityMacros(string fileEntityName,
				string fileEntityRecordColumnName) {
			return new Dictionary<string, string> {
				{ FileEntityNameMacro, fileEntityName },
				{ FileEntityRecordColumnNameMacro, fileEntityRecordColumnName },
			};
		}

		private static Dictionary<string, string> GetDefaultFileEntityMacros() =>
			GetFileEntityMacros(DefaultFileEntityName, DefaultFileEntityRecordColumnName);

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public Dictionary<string, string> GetAppTemplateMacros(IAppTemplateInfo newAppInfo) {
			bool useExistingEntitySchema = newAppInfo.OptionalTemplateData?.UseExistingEntitySchema == true;
			if (!useExistingEntitySchema) {
				return GetDefaultFileEntityMacros();
			}
			string entitySchemaName = newAppInfo.OptionalTemplateData.EntitySchemaName;
			FileSchemaInfo fileSchemaInfo = _fileSchemaProvider.FindSchema(entitySchemaName);
			return fileSchemaInfo is null
				? GetDefaultFileEntityMacros()
				: GetFileEntityMacros(fileSchemaInfo.Name, fileSchemaInfo.RecordColumnName);
		}

		#endregion

	}

	#endregion

}

