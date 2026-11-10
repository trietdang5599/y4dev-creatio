 namespace Terrasoft.Configuration.ESN {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Common;
	using Core;
	using Core.Entities;
	using Core.Factories;
	using Terrasoft.Core.DB;

	#region Interface: IEsnFileRepository

	public interface IEsnFileRepository {

		/// <summary>
		/// Checks file access rights.
		/// </summary>
		/// <param name="entitySchema">Entity schema.</param>
		/// <param name="recordId">Identifier of the file entity.</param>
		/// <returns>Returns <c>true</c> when file can be read.</returns>
		bool CheckReadFileAccess(EntitySchema entitySchema, Guid fileId);

		/// <summary>
		/// Returns attachments for message.
		/// </summary>
		/// <param name="messageId">Message identifier.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="columnName">Filter column name.</param>
		/// <returns><see cref="Terrasoft.Core.Entities.Entity"/>instance collection.</returns>
		IEnumerable<Entity> GetFilesByMessage(Guid messageId, string schemaName, string columnName);

		/// <summary>
		/// Delete attachments for message.
		/// </summary>
		/// <param name="messageId">Message identifier.</param>
		/// <param name="attachmentsToKeepIds">Unremovable attachment identifiers.</param>
		/// <returns>Sign that result is success or not.</returns>
		bool DeleteFiles(Guid messageId, Guid[] attachmentsToKeepIds);

	}

	#endregion

	#region Class: EsnFileRepository

	/// <summary>
	/// Provides api for operation in database for <see cref="Terrasoft.Configuration.SocialLike" />
	/// </summary>
	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnFileRepository))]
	public class EsnFileRepository : IEsnFileRepository
	{

		#region Constants: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Fields: Private
		private const string _defSchemaName = "FeedFile";
		private string _schemaName;
		private string _columnName;
		private IEsnSecurityEngine _esnSecurityEngine;

		#endregion

		#region Properties: Private

		private IEsnSecurityEngine EsnSecurityEngine => _esnSecurityEngine ?? (_esnSecurityEngine
			= ClassFactory.Get<IEsnSecurityEngine>(new ConstructorArgument("userConnection", _userConnection)));

		#endregion

		public EsnFileRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#region Methods: Private

		private string GetSortedColumnName(SortedMessageColumn sortedMessageColumn) => sortedMessageColumn.ToString();

		private void SetOrder(EntitySchemaQuery messageQuery, SortedMessageColumn sortedMessageColumn,
				OrderDirection direction) {
			var sortedColumn = messageQuery.Columns.GetByName(GetSortedColumnName(sortedMessageColumn));
			sortedColumn.OrderDirection = direction;
			sortedColumn.OrderPosition = 1;
		}

		private EntitySchema GetEsnFileSchema() => _userConnection.EntitySchemaManager.GetInstanceByName(_schemaName);

		private EntitySchemaQuery GetEsq() {
			var esnMessageSchema = GetEsnFileSchema();
			var messageQuery = new EntitySchemaQuery(esnMessageSchema) {
				UseAdminRights = _schemaName != _defSchemaName
			};
			return messageQuery;
		}

		#region Methods: Private

		private bool GetCanReadEntityMessage(IDataReader reader) {
			var entitySchemaUId = reader.GetColumnValue<Guid>("EntitySchemaUId");
			var entityId = reader.GetColumnValue<Guid>("EntityId");
			var canReadEntityMessage = EsnSecurityEngine.CanReadEntityMessage(entitySchemaUId, entityId);
			var isExternalUser = _userConnection.CurrentUser.ConnectionType == UserType.SSP;
			var userAccess = reader.GetColumnValue<UserAccess>("UserAccess");
			return canReadEntityMessage && (!isExternalUser || userAccess == UserAccess.External);
		}

		private bool TryReadAsParentMessage(Guid fileId) {
			var select = new Select(_userConnection)
				.Column("EntitySchemaUId")
				.Column("EntityId")
				.Column("UserAccess")
			.From("SocialMessage")
			.InnerJoin("FeedFile").On("FeedFile", "RecordId").IsEqual("SocialMessage", "Id")
			.Where("FeedFile", "Id").IsEqual(Column.Parameter(fileId))
				.And("FeedFile", "RecordSchemaName").IsEqual(Column.Const("SocialMessage"))
				.And("SocialMessage", "ParentId").IsNull() as Select;
			using (DBExecutor executor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(executor)) {
					if (reader.Read()) {
						return GetCanReadEntityMessage(reader);
					}
				}
			}
			return false;
		}

		private bool TryReadAsComment(Guid fileId) {
			var select = new Select(_userConnection)
				.Column("ParentMessage", "EntitySchemaUId")
				.Column("ParentMessage", "EntityId")
				.Column("ParentMessage", "UserAccess")
			.From("SocialMessage").As("ParentMessage")
			.InnerJoin("SocialMessage").As("CommentMessage").On("CommentMessage", "ParentId").IsEqual("ParentMessage", "Id")
			.InnerJoin("FeedFile").On("FeedFile", "RecordId").IsEqual("CommentMessage", "Id")
			.Where("FeedFile", "Id").IsEqual(Column.Parameter(fileId))
				.And("FeedFile", "RecordSchemaName").IsEqual(Column.Const("SocialMessage")) as Select;
			if (_userConnection.CurrentUser.ConnectionType == UserType.SSP) {
				select.And("CommentMessage", "UserAccess").IsEqual(Column.Const((int)UserAccess.External));
			}
			using (DBExecutor executor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(executor)) {
					if (reader.Read()) {
						return GetCanReadEntityMessage(reader);
					}
				}
			}
			return false;
		}

		#endregion

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get query for retrieving messages.
		/// </summary>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageQuery() {
			var messageQuery = GetEsq();
			AddMessageQueryColumns(messageQuery);
			return messageQuery;
		}

		/// <summary>
		/// Get query for retrieving messages.
		/// </summary>
		/// <param name="sortedBy">Sorted messages by <see cref="SortedMessageColumn" />.</param>
		/// <param name="direction">Sorted direction.</param>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageQuery(SortedMessageColumn sortedBy, OrderDirection direction =
				OrderDirection.Descending) {
			var messageQuery = GetMessageQuery();
			SetOrder(messageQuery, sortedBy, direction);
			return messageQuery;
		}

		/// <summary>
		/// Add column to messages query.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" />.</param>
		protected virtual void AddMessageQueryColumns(EntitySchemaQuery messageQuery) {
			messageQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			messageQuery.AddColumn("Name");
			messageQuery.AddColumn("Size");
			messageQuery.AddColumn("CreatedOn");
		}

		/// <summary>
		/// Add filter by message id.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" /></param>
		/// <param name="messageId">Message identifier.</param>
		protected virtual void AddQueryFilter(EntitySchemaQuery messageQuery, Guid messageId) {
			messageQuery.Filters.Add(
				messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, _columnName, messageId));
			if (_schemaName == _defSchemaName) {
				messageQuery.Filters.Add(
					messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "RecordSchemaName", "SocialMessage"));
				var tagFilter = new EntitySchemaQueryFilterCollection(messageQuery) {
					LogicalOperation = LogicalOperationStrict.Or
				};
				tagFilter.Add(messageQuery.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Tag", "inline"));
				tagFilter.Add(messageQuery.CreateFilterWithParameters(FilterComparisonType.IsNull, "Tag"));
				messageQuery.Filters.Add(tagFilter);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IEsnFileRepository.DeleteFiles(Guid, Guid[])"/>
		public bool DeleteFiles(Guid messageId, Guid[] attachmentsToKeepIds) {
			var delete = new Delete(_userConnection)
				.From("FeedFile")
				.Where("RecordId").IsEqual(Column.Parameter(messageId))
					.And("RecordSchemaName").IsEqual(Column.Const("SocialMessage"))
					.And("Tag").IsNotEqual(Column.Const("inline"))
					.And("CreatedById").IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId));
			if (attachmentsToKeepIds.Length > 0) {
				delete = delete.And("Id").Not().In(Column.Parameters(attachmentsToKeepIds));
			}
			delete.Execute();
			return true;
		}

		/// <inheritdoc cref="IEsnFileRepository.GetFilesByMessage(Guid, string, string)"/>
		public IEnumerable<Entity> GetFilesByMessage(Guid messageId, string schemaName, string columnName) {
			_schemaName = schemaName ?? _defSchemaName;
			_columnName = columnName ?? "RecordId";
			var messageQuery = GetMessageQuery(SortedMessageColumn.CreatedOn, OrderDirection.Ascending);
			AddQueryFilter(messageQuery, messageId);
			return messageQuery.GetEntityCollection(_userConnection);
		}

		/// <inheritdoc cref="IEsnFileRepository.CheckReadFileAccess(EntitySchema, Guid)"/>
		public bool CheckReadFileAccess(EntitySchema entitySchema, Guid fileId) {
			if (TryReadAsParentMessage(fileId)) {
				return true;
			}
			return TryReadAsComment(fileId);
		}

		#endregion
	}

	#endregion
}

