 namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Factories;

	#region Class: FolderTreeAppTemplateMacrosProvider

	/// <summary>
	/// Provides additional macros for folder tree control in application being created from template.
	/// </summary>
	[DefaultBinding(typeof(IAppTemplateMacrosProvider), Name = "FolderTreeAppTemplateMacrosProvider")]
	public class FolderTreeAppTemplateMacrosProvider : IAppTemplateMacrosProvider
	{

		#region Constants: Private

		private const string SourceSchemaNameMacro = "FolderTreeSourceSchemaName";
		private const string DefaultSourceSchemaName = "FolderTree";
		private const string OldSourceSchemaNameSuffix = "Folder";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public FolderTreeAppTemplateMacrosProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, string> GetFolderTreeMacros(string sourceSchemaName) {
			return new Dictionary<string, string> {
				{ SourceSchemaNameMacro, sourceSchemaName },
			};
		}

		private Dictionary<string, string> GetDefaultFolderTreeMacros() =>
			GetFolderTreeMacros(DefaultSourceSchemaName);

		private bool IsSchemaNotExist(string schemaName) {
			return _userConnection.EntitySchemaManager.FindItemByName(schemaName) is null;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public Dictionary<string, string> GetAppTemplateMacros(IAppTemplateInfo newAppInfo) {
			bool useExistingEntitySchema = newAppInfo.OptionalTemplateData?.UseExistingEntitySchema == true;
			if (!useExistingEntitySchema) {
				return GetDefaultFolderTreeMacros();
			}
			string sourceSchemaName = $"{newAppInfo.OptionalTemplateData.EntitySchemaName}{OldSourceSchemaNameSuffix}";
			return IsSchemaNotExist(sourceSchemaName)
				? GetDefaultFolderTreeMacros()
				: GetFolderTreeMacros(sourceSchemaName);
		}

		#endregion

	}

	#endregion

}

