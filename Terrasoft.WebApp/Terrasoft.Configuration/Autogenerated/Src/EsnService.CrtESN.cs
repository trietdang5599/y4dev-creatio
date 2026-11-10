namespace Terrasoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Core.Factories;
	using Terrasoft.Core;
	using Terrasoft.Web.Common.ServiceRouting;
	using Web.Common;
	using global::Common.Logging;
	using Terrasoft.Core.ServiceModelContract;

	#region Class: EsnLikesServiceResponse

	[DataContract]
	public class EsnLikesServiceResponse : ConfigurationServiceResponse
	{
		#region Constructors: Public

		public EsnLikesServiceResponse() { }

		public EsnLikesServiceResponse(Exception exception) : base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "likes")]
		public IEnumerable<EsnLikeDTO> EsnLikes { get; set; }

		#endregion
	}

	#endregion

	#region  Class: EsnPostMessageResponse

	[DataContract]
	public class EsnPostMessageResponse : ConfigurationServiceResponse
	{
		#region Constructors: Public

		public EsnPostMessageResponse() { }

		public EsnPostMessageResponse(Exception exception) : base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "Id")]
		public Guid Id { get; set; }

		#endregion
	}

	#endregion

	#region  Class: EsnMessagesServiceResponse

	[DataContract]
	public class EsnMessagesServiceResponse : ConfigurationServiceResponse
	{
		public EsnMessagesServiceResponse() { }

		public EsnMessagesServiceResponse(Exception exception) : base(exception) { }

		[DataMember(Name = "EsnMessages")]
		public IEnumerable<EsnReadMessageDTO> EsnMessages { get; set; }

	}

	#endregion

	#region  Class: EsnFilesServiceResponse

	[DataContract]
	public class EsnFilesServiceResponse : ConfigurationServiceResponse
	{
		#region Constructors: Public

		public EsnFilesServiceResponse() { }

		public EsnFilesServiceResponse(Exception exception) : base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "files")]
		public IEnumerable<EsnFileDTO> EsnFiles { get; set; }

		#endregion
	}

	#endregion

	#region  Class: EsnService

	/// <summary>
	/// Provides API for work with enterprise social network.
	/// </summary>
	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EsnService : BaseService, IReadOnlySessionState
	{
		#region  Fields: Private

		private IEsnCenter _esnCenter;

		#endregion

		#region Constructors: Public

		public EsnService() {}

		public EsnService(UserConnection userConnection) : base(userConnection) {}

		#endregion

		#region Properties: Private

		private Guid GetCurrentUserId => UserConnection.CurrentUser.Id;

		private IEsnCenter EsnCenter {
			get {
				if (_esnCenter == null) {
					var centerFactory = ClassFactory.Get<IEsnCenterFactory>();
					_esnCenter = centerFactory.CreateEsnCenter(UserConnection);
				}
				return _esnCenter;
			}
		}

		private ILog _logger;
		private ILog Logger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger("EsnServiceLogger"));
			}
		}

		#endregion

		#region Methods: Private

		private T TryExecute<T>(Func<T> action) where T: ConfigurationServiceResponse, new() {
			T response;
			try {
				response = action();
			} catch (Exception exception) {
				Logger.Error(exception);
				response = new T();
				response.SetRunTimeException(exception);
			}
			return response;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get user likes for messages.
		/// </summary>
		/// <param name="messageIds">Message id collection.</param>
		/// <returns>Instance of <see cref="EsnLikesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnLikesServiceResponse GetMessageLikesForUser(List<Guid> messageIds) {
			return TryExecute(() => {
				var likes = EsnCenter.GetMessageLikesForUser(GetCurrentUserId, messageIds);
				return new EsnLikesServiceResponse {
					EsnLikes = likes
				};
			});
		}

		/// <summary>
		/// Get collection of users who liked message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnLikesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnLikesServiceResponse GetWhoLikedMessage(Guid messageId) {
			return TryExecute(() => {
				var likes = EsnCenter.GetWhoLikedMessage(messageId);
				return new EsnLikesServiceResponse {
					EsnLikes = likes
				};
			});
		}

		/// <summary>
		/// Like message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse LikeMessage(Guid messageId) {
			return TryExecute(() => {
				EsnCenter.LikeMessage(GetCurrentUserId, messageId);
				return new ConfigurationServiceResponse();
			});
		}

		/// <summary>
		/// Remove user like.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UnLikeMessage(Guid messageId) {
			return TryExecute(() => {
				EsnCenter.UnLikeMessage(GetCurrentUserId, messageId);
				return new ConfigurationServiceResponse();
			});
		}

		/// <summary>
		/// Get comment collection for message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadComments(Guid schemaUId, Guid entityId, Guid messageId) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = EsnCenter.ReadComments(schemaUId, entityId, messageId)
				};
			});
		}

		/// <summary>
		/// Get comment collection for message with mode.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <param name="readingMode">Reading mode</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadCommentsWithMode(Guid schemaUId, Guid entityId, Guid messageId,
			FeedReadingMode readingMode) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = EsnCenter.ReadComments(schemaUId, entityId, messageId, readingMode)
				};
			});
		}

		/// <summary>
		/// Get attachment collection for message.
		/// </summary>
		/// <param name="messageId">Message identtifier.</param>
		/// <param name="schemaUId">Parent schema UId.</param>
		/// <param name="entityId">Parent entity identtifier.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="columnName">Filter column name.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnFilesServiceResponse ReadAttachments(Guid messageId, Guid schemaUId, Guid entityId,
			string schemaName = "", string columnName = "") {
			return TryExecute(() => {
				return new EsnFilesServiceResponse {
					EsnFiles = EsnCenter.ReadAttachments(schemaUId, entityId, messageId, schemaName, columnName)
				};
			});
		}

		/// <summary>
		/// Delete attachment collection for message.
		/// </summary>
		/// <param name="messageId">Message identtifier.</param>
		/// <param name="attachmentsToKeepIds">Unremovable attachment identifiers.</param>
		/// <param name="schemaUId">Parent schema UId.</param>
		/// <param name="entityId">Parent entity identtifier.</param>
		/// <returns>Sign that result is success or not.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool DeleteAttachments(Guid messageId, Guid[] attachmentsToKeepIds, Guid schemaUId, Guid entityId) {
			bool result;
			try {
				result = EsnCenter.DeleteAttachments(messageId, attachmentsToKeepIds, schemaUId, entityId);
			} catch {
				result = false;
			}
			return result;
		}

		/// <summary>
		/// Get message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadMessage(Guid schemaUId, Guid entityId, Guid messageId) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = new [] { EsnCenter.ReadMessage(schemaUId, entityId, messageId) }
				};
			});
		}

		/// <summary>
		/// Get message with mode.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadMessageWithMode(Guid schemaUId, Guid entityId, Guid messageId,
			FeedReadingMode readingMode) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = new [] { EsnCenter.ReadMessage(schemaUId, entityId, messageId, readingMode) }
				};
			});
		}

		/// <summary>
		/// Get comment with mode.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadCommentWithMode(Guid schemaUId, Guid entityId, Guid messageId,
			FeedReadingMode readingMode) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = new [] { EsnCenter.ReadComment(schemaUId, entityId, messageId, readingMode) }
				};
			});
		}

		/// <summary>
		/// Get chunk messages for entity.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadEntityMessage(Guid schemaUId, Guid entityId,
				EsnReadMessageOptions readOptions) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = EsnCenter.ReadEntityMessage(schemaUId, entityId, readOptions)
				};
			});
		}

		/// <summary>
		/// Get chunk messages for user feed.
		/// </summary>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadFeed(EsnReadMessageOptions readOptions) {
			return TryExecute(() => {
				return new EsnMessagesServiceResponse {
					EsnMessages = EsnCenter.ReadFeedMessage(readOptions)
				};
			});
		}

		/// <summary>
		/// Post new message.
		/// </summary>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="EsnPostMessageResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnPostMessageResponse PostMessage(EsnWriteMessageDTO message) {
			return TryExecute(() => {
				return new EsnPostMessageResponse {
					Id = EsnCenter.PostMessage(message)
				};
			});
		}

		/// <summary>
		/// Post new comment.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="EsnPostMessageResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnPostMessageResponse PostComment(Guid messageId, EsnWriteMessageDTO comment) {
			return TryExecute(() => {
				return new EsnPostMessageResponse {
					Id = EsnCenter.PostComment(messageId, comment)
				};
			});
		}

		/// <summary>
		/// Edit message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse EditMessage(Guid messageId, EsnWriteMessageDTO message) {
			return TryExecute(() => {
				EsnCenter.EditMessage(messageId, message);
				return new ConfigurationServiceResponse();
			});
		}

		/// <summary>
		/// Edit comment.
		/// </summary>
		/// <param name="commentId">Comment id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse EditComment(Guid commentId, EsnWriteMessageDTO comment) {
			return TryExecute(() => {
				EsnCenter.EditComment(commentId, comment);
				return new ConfigurationServiceResponse();
			});
		}

		/// <summary>
		/// Delete message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteMessage(Guid schemaUId, Guid entityId, Guid messageId) {
			return TryExecute(() => {
				EsnCenter.DeleteMessage(schemaUId, entityId, messageId);
				return new ConfigurationServiceResponse();
			});
		}

		/// <summary>
		/// Delete comment.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="commentId">Comment id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteComment(Guid schemaUId, Guid entityId, Guid commentId) {
			return TryExecute(() => {
				EsnCenter.DeleteComment(schemaUId, entityId, commentId);
				return new ConfigurationServiceResponse();
			});
		}

		#endregion
	}

	#endregion
}

