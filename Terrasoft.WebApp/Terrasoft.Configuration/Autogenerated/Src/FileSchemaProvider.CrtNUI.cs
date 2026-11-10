namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: FileSchemaInfo

	[DataContract]
	public class FileSchemaInfo
	{

		#region Properties: Public

		[DataMember(Name = "name")]
		public string Name;

		[DataMember(Name = "caption")]
		public string Caption;

		[DataMember(Name = "recordColumnName")]
		public string RecordColumnName;

		[DataMember(Name = "recordSchemaName")]
		public string RecordSchemaName;

		#endregion

	}

	#endregion

	#region Class: FileSchemaProvider

	/// <inhetitdoc cref="IFileSchemaProvider"/>
	[DefaultBinding(typeof(IFileSchemaProvider), Name = nameof(FileSchemaProvider))]
	public class FileSchemaProvider : IFileSchemaProvider
	{

		#region Fields: Private

		private readonly string _fileSchemaName = "File";
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public FileSchemaProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private EntitySchemaManager EntitySchemaManager => _userConnection.EntitySchemaManager;

		#endregion

		#region Methods: Private

		private bool CheckHasParentSchema(Guid schemaUId, Guid parentSchemaUId) {
			Collection<Guid> hierarchy = EntitySchemaManager.GetSchemaHierarchy(schemaUId);
			return hierarchy.Select(EntitySchemaManager.FindItemByUId).Any(item => item?.UId == parentSchemaUId);
		}

		private Guid GetSchemaUId(string schemaName) =>
			_userConnection.EntitySchemaManager.GetItemByName(schemaName).UId;

		private FileSchemaInfo GetFileSchemaInfo(ISchemaManagerItem<EntitySchema> schema) {
			string fileSchemaName = schema.Name;
			string columnName;
			string recordSchemaName;
			if (fileSchemaName == nameof(SysFile)) {
				columnName = nameof(SysFile.RecordId);
				recordSchemaName = fileSchemaName;
			} else {
				recordSchemaName = fileSchemaName.EndsWith(_fileSchemaName)
					? fileSchemaName.Substring(0, fileSchemaName.Length - _fileSchemaName.Length)
					: fileSchemaName.StartsWith(_fileSchemaName)
						? fileSchemaName.Substring(_fileSchemaName.Length)
						: fileSchemaName;
				columnName = $"{recordSchemaName}Id";
			}
			EntitySchema fileSchema = _userConnection.EntitySchemaManager.GetInstanceByName(fileSchemaName);
			if (fileSchema == null) {
				return null;
			}
			EntitySchemaColumn recordColumn = fileSchema.FindSchemaColumnByPath(recordSchemaName);
			if (recordColumn == null) {
				recordSchemaName = string.Empty;
				recordColumn = fileSchema.FindSchemaColumnByPath(columnName);
			} else {
				recordSchemaName = recordColumn.ReferenceSchema?.Name;
			}
			return new FileSchemaInfo {
				Name = fileSchemaName,
				Caption = schema.Caption,
				RecordSchemaName = recordSchemaName ?? string.Empty,
				RecordColumnName = recordColumn?.Name ?? string.Empty
			};
		}

		private IEnumerable<FileSchemaInfo> GetAllFileSchemas() {
			Guid parentSchemaUId = GetSchemaUId(_fileSchemaName);
			return EntitySchemaManager.GetItems()
				.Where(schema => schema.UId != parentSchemaUId && CheckHasParentSchema(schema.UId, parentSchemaUId))
				.Select(GetFileSchemaInfo)
				.Where(fileSchemaInfo => fileSchemaInfo != null && fileSchemaInfo.RecordColumnName.IsNotNullOrEmpty());
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public List<FileSchemaInfo> GetAllSchemas() => GetAllFileSchemas().ToList();

		/// <inheritdoc />
		public FileSchemaInfo FindSchema(string recordSchemaName) =>
			GetAllFileSchemas().FirstOrDefault(fileSchemaInfo => fileSchemaInfo.RecordSchemaName == recordSchemaName);

		#endregion

	}

	#endregion

}

