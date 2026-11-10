namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;
	using IFile = Terrasoft.File.Abstractions.IFile;

	#region Enum: ResultActionTypeEnum

	/// <summary>
	/// Determines the result action to execute.
	/// </summary>
	public enum ResultActionTypeEnum
	{
		/// <summary>
		/// Save result to object file.
		/// </summary>
		SaveToFiles,

		/// <summary>
		/// Store result to result parameter.
		/// </summary>
		UseInProcess
	}

	#endregion

	#region Class: FileCopyResults

	/// <summary>
	/// Represents file copy results.
	/// </summary>
	public class FileCopyResults
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets entity file locators of read object files.
		/// </summary>
		public IList<EntityFileLocator> SourceFileLocators { get; set; }

		/// <summary>
		/// Gets or sets entity file locators of created object files.
		/// </summary>
		public IList<EntityFileLocator> TargetFileLocators { get; set; }

		#endregion

	}

	#endregion

	#region Interface: IFileProcessing

	/// <summary>
	/// Provides methods for the processing files.
	/// </summary>
	public interface IFileProcessing
	{

		#region Methods: Public

		/// <summary>
		/// Copies an existing files to new files.
		/// </summary>
		/// <param name="settings">Object files copy settings.</param>
		/// <returns>Identifiers of read and created object files.</returns>
		FileCopyResults Copy(ObjectFilesCopySettings settings);

		/// <summary>
		/// Returns file identifiers.
		/// </summary>
		/// <param name="esq">ESQ.</param>
		/// <returns>List of file locators.</returns>
		IList<EntityFileLocator> GetFileLocators(EntitySchemaQuery esq);

		#endregion

	}

	#endregion

	#region Class: FileProcessing

	/// <inheritdoc />
	public class FileProcessing : IFileProcessing
	{

		#region Constants: Private

		private const string RecordSchemaNameColumnName = "RecordSchemaName";

		#endregion

		#region Constants: Public

		public const int DefVersion = 1;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of the <see cref="FileProcessing"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public FileProcessing(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		/// <summary>
		/// Creates a new instance of the <see cref="FileProcessing"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="targetDataEntitySchemaUId">Unique identifier of the target data entity schema.</param>
		public FileProcessing(UserConnection userConnection, Guid targetDataEntitySchemaUId) {
			_userConnection = userConnection;
			TargetDataEntitySchemaUId = targetDataEntitySchemaUId;
		}

		#endregion

		#region Properties: Private

		private Guid TargetDataEntitySchemaUId { get; set; }

		#endregion

		#region Methods: Private

		private static EntitySchemaQuery InitializeEntitySchemaQuery(EntitySchemaQuery esq) {
			esq.UseAdminRights = false;
			esq.CanReadUncommitedData = true;
			esq.IgnoreDisplayValues = true;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq;
		}

		private FileCopyResults CopyUseFileFactory(ObjectFilesCopySettings settings) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			EntitySchema targetEntitySchema = entitySchemaManager.GetInstanceByUId(settings.TargetEntitySchemaUId);
			EntitySchemaColumn connectedColumn = targetEntitySchema.Columns.FindByUId(
				settings.ConnectedObjectColumnUId);
			IFileFactory fileFactory = _userConnection.GetFileFactory().WithRightsDisabled();
			EntitySchemaQuery esq = settings.EntitySchemaQuery;
			IList<EntityFileLocator> sourceFileLocators = GetFileLocators(esq);
			string recordSchemaName = ProcessUserTaskUtilities.FindEntitySchemaName(entitySchemaManager,
				TargetDataEntitySchemaUId);
			var targetFileLocators = new List<EntityFileLocator>();
			foreach (EntityFileLocator sourceFileLocator in sourceFileLocators) {
				Guid entityId = Guid.NewGuid();
				var targetFileLocator = new EntityFileLocator(targetEntitySchema.Name, entityId);
				IFile targetFile = CreateFile(fileFactory, targetFileLocator, connectedColumn,
					settings.ConnectedObjectId);
				if (recordSchemaName.IsNotNullOrEmpty()) {
					targetFile.SetAttribute(RecordSchemaNameColumnName, recordSchemaName);
				}
				targetFileLocators.Add(targetFileLocator);
				IFile sourceFile = fileFactory.Get(sourceFileLocator);
				sourceFile.Copy(targetFile);
			}
			return new FileCopyResults {
				SourceFileLocators = sourceFileLocators,
				TargetFileLocators = targetFileLocators
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates new object file.
		/// </summary>
		/// <param name="fileFactory"><see cref="Terrasoft.File.Abstractions.IFileFactory" /> instance.</param>
		/// <param name="fileLocator">File locator for new file.</param>
		/// <param name="connectedColumn">Connected object column.</param>
		/// <param name="connectedObjectId">Connected object unique identifier.</param>
		/// <returns>Created file.</returns>
		public static IFile CreateFile(IFileFactory fileFactory, EntityFileLocator fileLocator,
				EntitySchemaColumn connectedColumn, Guid connectedObjectId) {
			IFile file = fileFactory.Create(fileLocator);
			if (connectedColumn != null) {
				file.SetAttribute(connectedColumn.ColumnValueName, connectedObjectId);
			}
			file.SetAttribute("Version", DefVersion);
			return file;
		}

		/// <inheritdoc />
		public FileCopyResults Copy(ObjectFilesCopySettings settings) {
			return CopyUseFileFactory(settings);
		}

		/// <inheritdoc />
		public IList<EntityFileLocator> GetFileLocators(EntitySchemaQuery esq) {
			esq = InitializeEntitySchemaQuery(esq);
			var fileLocators = new List<EntityFileLocator>();
			string schemaName = esq.RootSchema.Name;
			Select select = esq.GetSelectQuery(_userConnection);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var id = dataReader.GetColumnValue<Guid>("Id");
						var fileLocator = new EntityFileLocator(schemaName, id);
						fileLocators.Add(fileLocator);
					}
				}
			}
			return fileLocators;
		}

		#endregion

	}

	#endregion

}

