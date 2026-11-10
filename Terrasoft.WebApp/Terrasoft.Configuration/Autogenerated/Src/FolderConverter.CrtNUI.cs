namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Class: FolderConverter

	/// <summary>
	/// Class for work with groups
	/// </summary>
	public class FolderConverter
	{

		#region Class: FolderConverterInfo

		private class FolderConverterInfo
		{
			public Guid RecordId { get; set; }

			public Guid FolderId { get; set; }
		}

		#endregion

		#region Constants: Private

		private const int MaxChunkSize = 1000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private int _chunkSize = -1;
		private readonly int _maxBulkCount;

		#endregion

		#region Properties: Public

		public int ConvertingTimeout { get; }

		public int ChunkSize {
			get {
				if (_chunkSize < 0) {
					int size = SystemSettings.GetValue(_userConnection, "ConvertToStaticFolderChunkSize", MaxChunkSize);
					_chunkSize = (size > MaxChunkSize || size < 0) ? MaxChunkSize : size;
				}
				return _chunkSize;
			}
		}

		#endregion

		#region Constructors: Public

		public FolderConverter(UserConnection userConnection) {
			_userConnection = userConnection;
			ConvertingTimeout = SystemSettings.GetValue(_userConnection, "ConvertContactGroupTimeout", 2000);
			_maxBulkCount = SystemSettings.GetValue(_userConnection, "ConvertToStaticFolderMaxBulkCount", MaxChunkSize);
		}

		#endregion

		#region Methods: Private

		private string GetInFolderSchemaName(string entitySchemaName) {
			return entitySchemaName + "InFolder";
		}

		private EntitySchemaColumn GetRefEntityColumn(string entitySchemaName, string inFolderSchemaName) {
			EntitySchema inFolderSchema = _userConnection.EntitySchemaManager.GetInstanceByName(inFolderSchemaName);
			return inFolderSchema.Columns.FindByName(entitySchemaName);
		}

		private EntitySchemaQuery CreateEntityPrimaryColumnEsq(string entitySchemaName) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(entitySchemaName);
			var esq = new EntitySchemaQuery(entitySchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq;
		}

		private IEntitySchemaQueryFilterItem GetFolderEsqFilters(string entitySchemaName, Guid folderId) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			Guid sourceSchemaUId = entitySchemaManager.GetInstanceByName(entitySchemaName).UId;
			Guid folderSchemaUId = entitySchemaManager.GetInstanceByName($"{entitySchemaName}Folder").UId;
			return
				CommonUtilities.GetFolderEsqFilters(_userConnection, folderId, folderSchemaUId, sourceSchemaUId, true);
		}
		private EntitySchemaQuery CreateEntityDataEsq(string entitySchemaName, Guid folderId) {
			EntitySchemaQuery esq = CreateEntityPrimaryColumnEsq(entitySchemaName);
			IEntitySchemaQueryFilterItem esqFilter = GetFolderEsqFilters(entitySchemaName, folderId);
			esq.Filters.Add(esqFilter);
			return esq;
		}

		private void InsertRecordsFromList(List<Guid> recordIds, Guid newFolderId, string entitySchemaName) {
			if (!recordIds.Any()) {
				return;
			}
			string inFolderSchemaName = GetInFolderSchemaName(entitySchemaName);
			EntitySchemaColumn refEntityColumn = GetRefEntityColumn(entitySchemaName, inFolderSchemaName);
			Insert inFolderSchemaNameInsert = new Insert(_userConnection).Into(inFolderSchemaName);
			IEnumerable<FolderConverterInfo> folderConverterInfos = recordIds.Select(recordId =>
				new FolderConverterInfo() {
					RecordId = recordId,
					FolderId = newFolderId
				});
			inFolderSchemaNameInsert.BulkExecute(folderConverterInfos, _maxBulkCount, (insert, folderConverterInfo) => {
				insert.Set(refEntityColumn.ColumnValueName, Column.Parameter(folderConverterInfo.RecordId))
					.Set("FolderId", Column.Parameter(folderConverterInfo.FolderId));
			});
		}

		private void CheckConvertInputArgs(Guid newFolderId, Guid parentFolderId, string entitySchemaName) {
			newFolderId.CheckArgumentEmpty(nameof(newFolderId));
			parentFolderId.CheckArgumentEmpty(nameof(parentFolderId));
			entitySchemaName.CheckArgumentNullOrEmpty(nameof(entitySchemaName));
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Create select for entity.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <param name="folderId">Search folder id</param>
		/// <param name="newFolderId">New folder id</param>
		/// <returns>Select query</returns>
		protected virtual Select CreateEntityDataSelect(string entitySchemaName, Guid folderId, Guid newFolderId) {
			EntitySchemaQuery esq = CreateEntityDataEsq(entitySchemaName, folderId);
			esq.AddColumn(newFolderId, _userConnection.DataValueTypeManager.FindDataValueTypeByType(typeof(Guid)));
			return esq.GetSelectQuery(_userConnection);
		}

		/// <summary>
		/// Create insert select for add new entity folder.
		/// </summary>
		/// <param name="select">Entity select</param>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <returns>Insert select</returns>
		protected virtual InsertSelect GetInsertSelectForEntityFolder(Select select, string entitySchemaName) {
			string inFolderSchemaName = GetInFolderSchemaName(entitySchemaName);
			EntitySchemaColumn refEntityColumn = GetRefEntityColumn(entitySchemaName, inFolderSchemaName);
			return new InsertSelect(_userConnection).Into(inFolderSchemaName).Set(refEntityColumn.ColumnValueName)
				.Set("FolderId").FromSelect(select);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Fill static group by dynamic group filter.
		/// </summary>
		/// <param name="newFolderId">New static folder Id</param>
		/// <param name="parentFolderId">Search folder Id</param>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <returns>Result response</returns>
		public void Convert(Guid newFolderId, Guid parentFolderId, string entitySchemaName) {
			CheckConvertInputArgs(newFolderId, parentFolderId, entitySchemaName);
			var selectFromEsq = CreateEntityDataSelect(entitySchemaName, parentFolderId, newFolderId);
			selectFromEsq.SpecifyNoLockHints();
			var entityFolderInsertSelect = GetInsertSelectForEntityFolder(selectFromEsq, entitySchemaName);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				dbExecutor.CommandTimeout = ConvertingTimeout;
				entityFolderInsertSelect.Execute(dbExecutor);
			}
		}

		/// <summary>
		/// Fill static group by dynamic group filter by chunk.
		/// </summary>
		/// <param name="newFolderId">New static folder Id</param>
		/// <param name="parentFolderId">Search folder Id</param>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <returns>Number of records in static group</returns>
		public int ConvertToStaticFolder(Guid newFolderId, Guid parentFolderId, string entitySchemaName) {
			CheckConvertInputArgs(newFolderId, parentFolderId, entitySchemaName);
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(entitySchemaName);
			IEntitySchemaQueryFilterItem filters = GetFolderEsqFilters(entitySchemaName, parentFolderId);
			var segmentProcessor =
				ClassFactory.Get<EntitySegmentProcessorFactory>().Invoke(entitySchema, _userConnection);
			segmentProcessor.SegmentChunk = ChunkSize;
			segmentProcessor.Filters.Add(filters);
			return segmentProcessor.ProcessSegment((recordIds) => {
				InsertRecordsFromList(recordIds.ToList(), newFolderId, entitySchemaName);
			});
		}

		#endregion

	}

	#endregion

}

