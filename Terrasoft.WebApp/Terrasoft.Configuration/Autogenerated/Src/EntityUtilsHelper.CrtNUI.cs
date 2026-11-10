namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;

	#region Class: EntityUtilsHelper

	/// <summary>
	/// Helper class for working with entity.
	/// </summary>
	public class EntityUtilsHelper
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly Guid _fileSchemaUid = Guid.Parse("08733C65-57EB-48AC-8170-AEF1C0D0BDFD");

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the class <see cref="EntityUtilsHelper"/>,
		/// using the specified user connection.</summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public EntityUtilsHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public EntityUtilsHelper() {
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, object> GetColumnValues(Entity sourceEntity, EntitySchemaColumn column, string refColumnName, string masterEntitySchemaName, Guid recipientEntityId) {
			var result = new Dictionary<string, object>();
			DataValueType dataValueType = column.DataValueType;
			if (dataValueType.IsLookup) {
				object columnValue;
				object displayColumnValue;
				string columnValueName = column.ColumnValueName;
				string displayColumnValueName = column.DisplayColumnValueName;
				if (column.Name == refColumnName) {
					Entity entity = _userConnection.EntitySchemaManager
						.GetInstanceByName(masterEntitySchemaName).CreateEntity(_userConnection);
					entity.FetchFromDB(recipientEntityId);
					columnValue = entity.GetColumnValue(entity.Schema.PrimaryColumn.Name);
					displayColumnValue = entity.GetColumnValue(entity.Schema.PrimaryDisplayColumn.Name);
				} else {
					columnValue = sourceEntity.GetColumnValue(columnValueName);
					displayColumnValue = sourceEntity.GetColumnValue(displayColumnValueName);
				}
				result.Add(columnValueName, columnValue);
				result.Add(displayColumnValueName, displayColumnValue);
				return result;
			}
			string columnName = column.Name;
			object value = sourceEntity.GetColumnValue(columnName);
			if (!dataValueType.IsBinary) {
				if (columnName != sourceEntity.Schema.GetPrimaryColumnName()) {
					result.Add(columnName, value);
				}
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates data collection for copying.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="columnName">The column name for linking with <paramref name="sourceEntitySchemaName"/>.
		/// </param>
		/// <param name="sourceEntitySchemaName">The name of the entity schema, from which data will be copied.</param>
		/// <returns><see cref="EntityCollection"/> instance.</returns>
		protected virtual EntityCollection GetSourceEntityCollection(Guid sourceEntityId, string columnName,
				string sourceEntitySchemaName) {
			var sourceQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, sourceEntitySchemaName);
			sourceQuery.AddAllSchemaColumns();
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, columnName,
				sourceEntityId));
			return sourceQuery.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Creates data collection for copying.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="columnName">The column name for linking with <paramref name="sourceEntitySchemaName"/>.
		/// </param>
		/// <param name="sourceEntitySchemaName">The name of the entity schema, from which data will be copied.</param>
		/// <param name="inlineIds">Additional filter on primary column.</param>
		/// <returns><see cref="EntityCollection"/> instance.</returns>
		protected virtual EntityCollection GetSourceEntityCollection(Guid sourceEntityId, string columnName,
				string sourceEntitySchemaName, IEnumerable<object> inlineIds) {
			var sourceQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, sourceEntitySchemaName);
			sourceQuery.AddAllSchemaColumns();
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, columnName,
				sourceEntityId));
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				inlineIds));
			return sourceQuery.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Calls <see cref="Entity.Save(bool, bool)"/> method for <paramref name="entity"/>.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> instance.</param>
		/// <remarks>
		/// External dependency allocation.
		/// </remarks>
		protected virtual void SaveEntity(Entity entity) {
			entity.Save();
		}

		/// <summary>
		/// Fills columns of the new entity by values from the source <paramref name="sourceEntity"/>.
		/// </summary>
		/// <param name="sourceEntity">The entity, from which column values will be copied.</param>
		/// <param name="newEntity">The entity, to which column values will be copied.</param>
		/// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
		/// <param name="refColumnName">Reference column name.</param>
		/// <param name="entitySchemaName">The new entity schema name for <paramref name="recipientEntityId"/>.</param>
		protected virtual void FillEntityColumnValues(Entity sourceEntity, Entity newEntity, Guid recipientEntityId,
				string refColumnName, string entitySchemaName) {
			newEntity.SetDefColumnValues();
			foreach (var column in sourceEntity.Schema.Columns) {
				if (!column.IsValueCloneable) {
					continue;
				}
				DataValueType dataValueType = column.DataValueType;
				if (!dataValueType.IsBinary) {
					foreach (var columnValue in GetColumnValues(sourceEntity, column, refColumnName, entitySchemaName, recipientEntityId)) {
						newEntity.SetColumnValue(columnValue.Key, columnValue.Value);
					}
				} else {
					string columnName = column.Name;
					object value = sourceEntity.GetColumnValue(columnName);
					var byteArray = value as byte[];
					if (byteArray != null) {
						newEntity.SetBytesValue(columnName, byteArray);
					} else {
						newEntity.SetStreamValue(columnName, value as Stream);
					}
				}
			}
		}

		/// <summary>
		/// Fills columns of the new entity by values from the source <paramref name="sourceEntity"/>.
		/// </summary>
		/// <param name="sourceEntity">The entity, from which column values will be copied.</param>
		/// <param name="descFile">The entity, to which column values will be copied.</param>
		/// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
		/// <param name="refColumnName">Reference column name.</param>
		/// <param name="entitySchemaName">The new entity schema name for <paramref name="recipientEntityId"/>.</param>
		protected void FillEntityColumnValues(Entity sourceEntity, IFile descFile, Guid recipientEntityId,
				string refColumnName, string entitySchemaName) {
			foreach (var column in sourceEntity.Schema.Columns) {
				DataValueType dataValueType = column.DataValueType;
				if (!column.IsValueCloneable || dataValueType.IsBinary) {
					continue;
				}
				foreach (var columnValue in GetColumnValues(sourceEntity, column, refColumnName, entitySchemaName, recipientEntityId)) {
					descFile.SetAttribute(columnValue.Key, columnValue.Value);
				}
			}
		}

		protected bool GetIsFile(string schemaName) {
			var manager = _userConnection.EntitySchemaManager as IManager;
			var item = manager.FindItemByName(schemaName) as ISchemaManagerItem<EntitySchema>;
			while (item != null && item.RealParentItemUId.IsNotEmpty()) {
				if (item.RealParentItemUId == _fileSchemaUid) {
					return true;
				}
				item = manager.FindItemByRealUId(item.RealParentItemUId) as ISchemaManagerItem<EntitySchema>;
			}
			return false;
		}

        #endregion

        #region Methods: Public

        /// <summary>
        /// Copies and links data to the specified entity <paramref name="recipientEntityId"/> from the source
        /// <paramref name="sourceEntityId"/>.
        /// </summary>
        /// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
        /// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
        /// <param name="columnName">The column name for linking with
        /// <paramref name="sourceEntitySchemaNames"/>.</param>
        /// <param name="entitySchemaName">Entity name of source and recipient.</param>
        /// <param name="sourceEntitySchemaNames">List of entity schema names, from which data will be copied.</param>
        /// <param name="attachmentIds">List of attachment identifiers that should be copied.</param>
        /// <param name="onlyDefiniteAttachments">Flag that forces to copy only definite attachments.</param>
        /// <returns>The result of copying.</returns>
        public Dictionary<string, string> Copy(Guid sourceEntityId, Guid recipientEntityId, string columnName,
				string entitySchemaName, List<string> sourceEntitySchemaNames, List<object> attachmentIds = null,
				bool onlyDefiniteAttachments = false) {
			var mappingIds = new Dictionary<string, string>();
			if (onlyDefiniteAttachments && attachmentIds.IsNullOrEmpty()) {
				return mappingIds;
			}
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				try {
					dbExecutor.StartTransaction();
					foreach (var sourceEntitySchemaName in sourceEntitySchemaNames) {
						EntityCollection sourceEntityCollection;
						if (onlyDefiniteAttachments) {
							sourceEntityCollection = GetSourceEntityCollection(sourceEntityId, columnName,
								sourceEntitySchemaName, attachmentIds);
						} else {
							sourceEntityCollection = GetSourceEntityCollection(sourceEntityId, columnName, 
								sourceEntitySchemaName);
						}
						if (sourceEntityCollection.Count == 0) {
							continue;
						}
						var isFile = GetIsFile(sourceEntitySchemaName);
						foreach (var sourceEntity in sourceEntityCollection) {
							Guid sourceId = sourceEntity.PrimaryColumnValue;
							var recipientId = Guid.Empty;
							if (GlobalAppSettings.FeatureUseFileApi && isFile) {
								var fileLocator = new EntityFileLocator(sourceEntitySchemaName, sourceId);
								IFile file = _userConnection.GetFile(fileLocator);
								recipientId = Guid.NewGuid();
								var copyFileLocator = new EntityFileLocator(sourceEntitySchemaName, recipientId);
								IFile copyFile = _userConnection.CreateFile(copyFileLocator);
								FillEntityColumnValues(sourceEntity, copyFile, recipientEntityId, columnName, entitySchemaName);
								file.Copy(copyFile);
							} else {
								Entity recipientEntity = _userConnection.EntitySchemaManager
								.GetInstanceByName(sourceEntitySchemaName).CreateEntity(_userConnection);
								FillEntityColumnValues(sourceEntity, recipientEntity, recipientEntityId, columnName,
									entitySchemaName);
								SaveEntity(recipientEntity);
								recipientId = recipientEntity.PrimaryColumnValue;
							}
							mappingIds.Add(sourceId.ToString(), recipientId.ToString());
						}
					}
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return mappingIds;
		}

		#endregion

	}

	#endregion

}

