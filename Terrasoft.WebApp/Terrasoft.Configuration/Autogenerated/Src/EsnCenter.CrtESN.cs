namespace Terrasoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using global::Common.Logging;
	using Microsoft.Exchange.WebServices.Data;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using EntitySchema = Core.Entities.EntitySchema;

	#region Class: EsnLogContext
	
	public class EsnLogContext
	{
		#region Properties: Public
		
		public bool LogEnabled { get; set; }

		public string UserName { get; set; }

		public Guid UserId { get; set; }
		
		#endregion
	}
	
	#endregion

	#region Class: EsnCenter

	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnCenter))]
	public class EsnCenter : IEsnCenter
	{

		#region Constants: Private

		private readonly IEsnLikeRepository _likeRepository;
		private readonly IEsnFileRepository _fileRepository;
		private readonly IEsnMessageReader _messageReader;
		private readonly IEsnMessageRedactor _messageRedactor;
		private readonly IEsnSecurityEngine _esnSecurityEngine;
		private readonly EsnLogContext _logContext;
		private readonly UserConnection _userConnection;
		private ILog _log;

		#endregion

		#region Properties: Private

		private ILog Logger => _log ?? (_log = LogManager.GetLogger("EsnCenterLogger"));

		private bool LogEnabled => _logContext?.LogEnabled ?? false;

		#endregion

		#region Constructors: Public

		public EsnCenter(IEsnLikeRepository esnLikeRepository, IEsnMessageReader esnMessageReader,
			IEsnMessageRedactor esnMessageRedactor, IEsnSecurityEngine esnSecurityEngine,
			IEsnFileRepository fileRepository, UserConnection userConnection, EsnLogContext logContext = null) {
			_likeRepository = esnLikeRepository;
			_messageReader = esnMessageReader;
			_messageRedactor = esnMessageRedactor;
			_esnSecurityEngine = esnSecurityEngine;
			_fileRepository = fileRepository;
			_userConnection = userConnection;
			_logContext = logContext;
		}

		#endregion

		#region Methods: Private

		private LookupColumnValue GetParent(Entity entity) {
			var parentId = entity.GetTypedColumnValue<Guid>("ParentId");
			return parentId == Guid.Empty
				? null
				: new LookupColumnValue {
					Value = parentId.ToString()
				};
		}

		private static EsnCreatedByDto GetCreatedBy(Entity entity) {
			if (!Guid.TryParse(entity.GetColumnValue("CreatedByTypedValue")?.ToString(), out Guid typedColumnValue)) {
				typedColumnValue = Guid.Empty;
			}
			return new EsnCreatedByDto {
				DisplayValue = FindColumnValue(entity, "CreatedByName"),
				PrimaryImageValue = FindColumnValue(entity, "CreatedByPrimaryImage"),
				Value = FindColumnValue(entity, "CreatedById"),
				TypedValue = typedColumnValue
			};
		}

		private bool InnerDeletePost(Guid schemaUId, Guid entityId, Guid messageId, bool isComment) {
			var messageEntity = _messageReader.ReadMessageAllColumnsEntity(messageId);
			if (messageEntity == null) {
				throw new ItemNotFoundException();
			}
			var messageAuthorId = messageEntity.GetTypedColumnValue<Guid>("CreatedById");
			if (_esnSecurityEngine.CanDeletePost(schemaUId, entityId, messageAuthorId)) {
				if (isComment) {
					return _messageRedactor.DeleteComment(messageEntity);
				} else {
					return _messageRedactor.DeleteMessage(messageEntity);
				}
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		private static string FindColumnValue(Entity entity, string columnName) {
			EntityColumnValue columnValue = entity.FindEntityColumnValue(columnName);
			return columnValue?.Value?.ToString() ?? string.Empty;
		}

		private EntitySchema GetEntitySchema(Guid entitySchemaUId) {
			var entitySchemaManager = _userConnection.EntitySchemaManager;
			if (entitySchemaManager?.FindItemByUId(entitySchemaUId) != null) {
				return entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			}
			return null;
		}

		private void WriteLog(string message) {
			if (!LogEnabled) {
				return;
			}
			Logger.Info(message);
		}

		private bool TryGetEntityDisplayValue(Dictionary<Guid, Dictionary<Guid, string>> entityDisplayValues,
				Guid entitySchemaUId, Guid entityId, out string displayValue) {
			displayValue = string.Empty;
			if (entitySchemaUId.IsEmpty() || entityId.IsEmpty()) {
				return false;
			}
			return entityDisplayValues.TryGetValue(entitySchemaUId, out Dictionary<Guid, string> schemaDisplayValues) &&
				schemaDisplayValues.TryGetValue(entityId, out displayValue);
		}

		private bool TryGetEntityDisplayValue(Dictionary<Guid, Dictionary<Guid, string>> entityDisplayValues,
				Entity entity, out string displayValue) {
			return TryGetEntityDisplayValue(entityDisplayValues,
				entity.GetTypedColumnValue<Guid>("EntitySchemaUId"),
				entity.GetTypedColumnValue<Guid>("EntityId"),
				out displayValue);
		}

		private Dictionary<Guid, string> LoadEntityDisplayValues(Guid entitySchemaUId, ICollection<Guid> entityIds) {
			var entityDisplayValues = entityIds
				.Distinct()
				.ToDictionary(entityId => entityId, _ => string.Empty);
			var entitySchema = GetEntitySchema(entitySchemaUId);
			if (entitySchema?.PrimaryDisplayColumn == null) {
				return entityDisplayValues;
			}
			var entityQuery = new EntitySchemaQuery(entitySchema) {
				UseAdminRights = false
			};
			entityQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entityQuery.AddColumn(entitySchema.PrimaryDisplayColumn.Name);
			entityQuery.Filters.Add(entityQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				entitySchema.PrimaryColumn.Name,
				entityDisplayValues.Keys.Cast<object>().ToArray()
				));
			foreach (var entity in entityQuery.GetEntityCollection(_userConnection)) {
				entityDisplayValues[entity.PrimaryColumnValue] = entity.PrimaryDisplayColumnValue;
			}
			return entityDisplayValues;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Create DTO for response.
		/// </summary>
		/// <param name="entity">Instance of <see cref="Terrasoft.Core.Entities.Entity" />.</param>
		/// <returns>Instance of <see cref="Terrasoft.Configuration.ESN.EsnLikeDTO" />.</returns>
		protected virtual EsnLikeDTO CreateEsnLikeDTO(Entity entity) =>
			new EsnLikeDTO {
				Id = entity.PrimaryColumnValue,
				SocialMessageId = entity.GetTypedColumnValue<Guid>("SocialMessageId"),
				UserId = entity.GetTypedColumnValue<Guid>("UserId"),
				ContactId = entity.GetTypedColumnValue<Guid>("CreatedById"),
				ContactName = entity.GetColumnValue("CreatedByName").ToString(),
				ContactPrimaryImageId = entity.GetTypedColumnValue<Guid>("CreatedByPrimaryImage")
			};

		/// <summary>
		/// Load target record display value from their primary display column for one schema.
		/// </summary>
		/// <param name="entitySchemaUId">Target schema UId.</param>
		/// <param name="entityId">Target record id.</param>
		/// <returns>Target record primary display value.</returns>
		protected virtual string LoadEntityDisplayValue(Guid entitySchemaUId, Guid entityId) {
			var entityDisplayValues = this.LoadEntityDisplayValues(entitySchemaUId, new List<Guid> { entityId });
			return entityDisplayValues[entityId];
		}

		/// <summary>
		/// Load target record display values for the message collection.
		/// </summary>
		/// <param name="entities">Message collection.</param>
		/// <returns>Target record primary display values keyed by record id.</returns>
		protected virtual Dictionary<Guid, Dictionary<Guid, string>> LoadEntityDisplayValues(IEnumerable<Entity> entities) {
			var entityDisplayValues = new Dictionary<Guid, Dictionary<Guid, string>>();
			var entitiesWithTargetRecord = entities
				.Where(entity => !entity.GetTypedColumnValue<Guid>("EntityId").IsEmpty() &&
					!entity.GetTypedColumnValue<Guid>("EntitySchemaUId").IsEmpty())
				.GroupBy(entity => entity.GetTypedColumnValue<Guid>("EntitySchemaUId"));
			foreach (var entityGroup in entitiesWithTargetRecord) {
				var entityIds = entityGroup.Select(entity => entity.GetTypedColumnValue<Guid>("EntityId")).ToList();
				entityDisplayValues[entityGroup.Key] = LoadEntityDisplayValues(entityGroup.Key, entityIds);
			}
			return entityDisplayValues;
		}

		/// <summary>
		/// Create message DTO for response.
		/// </summary>
		/// <param name="entity">Instance of <see cref="Entity" />.</param>
		/// <returns>Instance of <see cref="EsnReadMessageDTO" />.</returns>
		protected virtual EsnReadMessageDTO CreateEsnMessageDTO(Entity entity) =>
			new EsnReadMessageDTO {
				Id = entity.PrimaryColumnValue,
				Color = entity.GetTypedColumnValue<string>("Color"),
				CommentCount = entity.GetTypedColumnValue<int>("CommentCount"),
				CreatedBy = GetCreatedBy(entity),
				CreatedOn = GetSerializedDateTime(entity.GetTypedColumnValue<DateTime>("CreatedOn")),
				EntityId = entity.GetTypedColumnValue<Guid>("EntityId"),
				EntitySchemaName = entity.GetTypedColumnValue<string>("EntitySchemaName"),
				EntitySchemaCaption = entity.GetTypedColumnValue<string>("EntitySchemaCaption"),
				LinkPreviewData = entity.FindEntityColumnValue("LinkPreviewData") != null
					? entity.GetBytesValue("LinkPreviewData")
					: null,
				EntitySchemaUId = entity.GetTypedColumnValue<Guid>("EntitySchemaUId"),
				LastActionOn = GetSerializedDateTime(entity.GetTypedColumnValue<DateTime>("LastActionOn")),
				LikeCount = entity.GetTypedColumnValue<int>("LikeCount"),
				Message = entity.GetTypedColumnValue<string>("Message"),
				Parent = GetParent(entity),
				UserAccess = entity.GetTypedColumnValue<int>("UserAccess"),
			};

		/// <summary>
		/// Create message DTO for response with entity display value.
		/// </summary>
		/// <param name="entity">Instance of <see cref="Entity" />.</param>
		/// <param name="entityDisplayValue">Entity display value.</param>
		/// <returns>Instance of <see cref="EsnReadMessageDTO" />.</returns>
		protected virtual EsnReadMessageDTO CreateEsnMessageDTO(Entity entity, string entityDisplayValue) {
			var dto = CreateEsnMessageDTO(entity);
			dto.EntityDisplayValue = entityDisplayValue;
			return dto;
		}

		/// <summary>
		/// Create feed attachment DTO for response.
		/// </summary>
		/// <param name="entity">Instance of <see cref="Entity" />.</param>
		/// <returns>Instance of <see cref="EsnFileDTO" />.</returns>
		protected virtual EsnFileDTO CreateEsnFileDTO(Entity entity) =>
			new EsnFileDTO {
				Id = entity.PrimaryColumnValue,
				Name = entity.GetTypedColumnValue<string>("Name"),
				Size = entity.GetTypedColumnValue<int>("Size"),
				CreatedOn = GetSerializedDateTime(entity.GetTypedColumnValue<DateTime>("CreatedOn"))
			};

		/// <summary>
		/// Create serialized date in Utc time zone.
		/// </summary>
		protected string GetSerializedDateTime(DateTime dateTime) {
			return DateTimeDataValueType.Serialize(dateTime, TimeZoneInfo.Utc);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public IEnumerable<EsnLikeDTO> GetMessageLikesForUser(Guid userId, IEnumerable<Guid> messageIds) =>
			_likeRepository.GetUserLikesByMessages(userId, messageIds).Select(CreateEsnLikeDTO);

		/// <inheritdoc />
		public IEnumerable<EsnLikeDTO> GetWhoLikedMessage(Guid messageId) =>
			_likeRepository.GetWhoLikedMessage(messageId).Select(CreateEsnLikeDTO);

		/// <inheritdoc />
		public Guid LikeMessage(Guid userId, Guid messageId) => _likeRepository.AddLike(userId, messageId);

		/// <inheritdoc />
		public bool UnLikeMessage(Guid userId, Guid messageId) => _likeRepository.DeleteLike(userId, messageId);

		/// <inheritdoc />
		public IEnumerable<EsnReadMessageDTO> ReadComments(Guid schemaUId, Guid entityId, Guid messageId,
			FeedReadingMode readingMode = FeedReadingMode.All) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
				var entities = _messageReader.ReadComments(messageId, readingMode).ToList();
				var displayValuesByTargetRecord = LoadEntityDisplayValues(entities);
				return entities.Select(e =>
					CreateEsnMessageDTO(e, TryGetEntityDisplayValue(displayValuesByTargetRecord, e, out string displayValue)
						? displayValue
						: string.Empty));
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc cref="IEsnCenter.ReadAttachments(Guid, Guid, Guid, string, string)"/>
		public IEnumerable<EsnFileDTO> ReadAttachments(Guid schemaUId, Guid entityId, Guid messageId, 
			string schemaName, string columnName) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId) &&
					_esnSecurityEngine.GetHasSocialMessageExternalAccess(messageId)) {
				return _fileRepository.GetFilesByMessage(messageId, schemaName, columnName).Select(CreateEsnFileDTO);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc cref="IEsnCenter.DeleteAttachments(Guid, Guid[], Guid, Guid)"/>
		public bool DeleteAttachments(Guid messageId, Guid[] attachmentsToKeepIds, Guid schemaUId, Guid entityId) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId) &&
					_esnSecurityEngine.GetHasSocialMessageExternalAccess(messageId)) {
				return _fileRepository.DeleteFiles(messageId, attachmentsToKeepIds);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public EsnReadMessageDTO ReadMessage(Guid schemaUId, Guid entityId, Guid messageId,
			FeedReadingMode readingMode = FeedReadingMode.All) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
				var displayValue = LoadEntityDisplayValue(schemaUId, entityId);
				return CreateEsnMessageDTO(_messageReader.ReadMessage(messageId, readingMode), displayValue);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}
		
		/// <inheritdoc />
		public EsnReadMessageDTO ReadComment(Guid schemaUId, Guid entityId, Guid commentId,
			FeedReadingMode readingMode = FeedReadingMode.All) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
				var displayValue = LoadEntityDisplayValue(schemaUId, entityId);
				return CreateEsnMessageDTO(_messageReader.ReadComment(commentId, readingMode), displayValue);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public IEnumerable<EsnReadMessageDTO> ReadEntityMessage(Guid schemaUId, Guid entityId,
			EsnReadMessageOptions options) {
			if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
				var entities = _messageReader.ReadEntityMessage(entityId, options).ToList();
				var displayValuesByTargetRecord = LoadEntityDisplayValues(entities);
				return entities.Select(e =>
					CreateEsnMessageDTO(e, TryGetEntityDisplayValue(displayValuesByTargetRecord, e, out string displayValue)
						? displayValue
						: string.Empty));
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public IEnumerable<EsnReadMessageDTO> ReadFeedMessage(EsnReadMessageOptions readOptions) {
			var messages = new List<EsnReadMessageDTO>();
			var displayValuesByTargetRecord = new Dictionary<Guid, Dictionary<Guid, string>>();
			var readOptionLocal = new EsnReadMessageOptions {
				SortedBy = readOptions.SortedBy,
				ReadMessageCount = readOptions.ReadMessageCount,
				OffsetDate = readOptions.OffsetDate,
				IncludeComments = readOptions.IncludeComments,
				ReadingMode = readOptions.ReadingMode
			};
			var sortedColumnName = readOptionLocal.SortedBy.ToString();
			WriteLog($"Start read feed for user - {_logContext?.UserId} - {_logContext?.UserName}");
			do {
				var messagesFromDb = _messageReader.ReadFeedMessage(readOptionLocal).ToList();
				WriteLog($"Loaded {messagesFromDb.Count} messages");
				var readableMessages = new List<Entity>();
				foreach (var message in messagesFromDb) {
					readOptionLocal.OffsetDate = message.GetTypedColumnValue<DateTime>(sortedColumnName);
					var entityId = message.GetTypedColumnValue<Guid>("EntityId");
					var entitySchemaUId = message.GetTypedColumnValue<Guid>("EntitySchemaUId");
					if (_esnSecurityEngine.CanReadEntityMessage(entitySchemaUId, entityId)) {
						readableMessages.Add(message);
					} else {
						WriteLog($"Can't read message with entityId - {entityId} " 
							+ $"and entitySchemaUId - {entitySchemaUId} ");
					}
				}
				var unreadTargetMessages = readableMessages.Where(message =>
					!TryGetEntityDisplayValue(displayValuesByTargetRecord, message, out _)).ToList();
				if (unreadTargetMessages.Count > 0) {
					var newDisplayValuesByTargetRecord = LoadEntityDisplayValues(unreadTargetMessages);
					foreach (var schemaDisplayValuesPair in newDisplayValuesByTargetRecord) {
						if (!displayValuesByTargetRecord.TryGetValue(schemaDisplayValuesPair.Key, out Dictionary<Guid, string> schemaDisplayValues)) {
							schemaDisplayValues = new Dictionary<Guid, string>();
							displayValuesByTargetRecord[schemaDisplayValuesPair.Key] = schemaDisplayValues;
						}
						foreach (var displayValuePair in schemaDisplayValuesPair.Value) {
							schemaDisplayValues[displayValuePair.Key] = displayValuePair.Value;
						}
					}
				}
				foreach (var message in readableMessages) {
					var entityDisplayValue = TryGetEntityDisplayValue(displayValuesByTargetRecord, message, out string displayValue)
						? displayValue
						: string.Empty;
					var messageDto = CreateEsnMessageDTO(message, entityDisplayValue);
					messages.Add(messageDto);
					WriteLog($"Checked messageId {messageDto.Id}");
					if (messages.Count == readOptions.ReadMessageCount) {
						break;
					}
				}
				if (messagesFromDb.Count != readOptions.ReadMessageCount) {
					break;
				}
			} while (messages.Count < readOptions.ReadMessageCount);
			WriteLog($"Finish, messages read: {messages.Count}");
			return messages;
		}

		/// <inheritdoc />
		public Guid PostMessage(EsnWriteMessageDTO messageData) {
			if (_esnSecurityEngine.CanCreateMessage(messageData.SchemaUId, messageData.EntityId)) {
				return _messageRedactor.PostMessage(messageData);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public Guid PostComment(Guid messageId, EsnWriteMessageDTO commentData) {
			if (_esnSecurityEngine.CanCreateComment(commentData.SchemaUId, commentData.EntityId)) {
				return _messageRedactor.PostComment(messageId, commentData);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public bool EditMessage(Guid messageId, EsnWriteMessageDTO messageData) {
			var messageEntity = _messageReader.ReadMessageAllColumnsEntity(messageId);
			var messageAuthorId = messageEntity.GetTypedColumnValue<Guid>("CreatedById");
			if (_esnSecurityEngine.CanEditPost(messageData.SchemaUId, messageData.EntityId, messageAuthorId)) {
				return _messageRedactor.EditMessage(messageEntity, messageData);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public bool EditComment(Guid commentId, EsnWriteMessageDTO commentData) {
			var commentEntity = _messageReader.ReadMessageAllColumnsEntity(commentId);
			var commentAuthorId = commentEntity.GetTypedColumnValue<Guid>("CreatedById");
			if (_esnSecurityEngine.CanEditPost(commentData.SchemaUId, commentData.EntityId, commentAuthorId)) {
				return _messageRedactor.EditComment(commentEntity, commentData);
			}
			throw new SecurityException(string.Format(
				new LocalizableString("Terrasoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
				"SocialMessage"));
		}

		/// <inheritdoc />
		public bool DeleteMessage(Guid schemaUId, Guid entityId, Guid messageId) {
			return InnerDeletePost(schemaUId, entityId, messageId, false);
		}

		/// <inheritdoc />
		public bool DeleteComment(Guid schemaUId, Guid entityId, Guid commentId) {
			return InnerDeletePost(schemaUId, entityId, commentId, true);
		}

		#endregion

	}

	#endregion

}

