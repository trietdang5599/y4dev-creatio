namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: ChatTransferServiceResponse

	[DataContract]
	public class ChatTransferServiceResponse
	{
		[DataMember]
		public bool Success { get; set; }
		[DataMember]
		public string Message { get; set; }
		[DataMember]
		public Guid NewChatId { get; set; }
	}

	#endregion

	#region Class: ChatTransferService

	/// <summary>
	/// Service for transferring chats
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class ChatTransferService : BaseService
	{

		#region Properties: Public

		private ChatOperatorTransferStore _store;
		private ChatOperatorTransferStore Store => _store ?? (_store = new ChatOperatorTransferStore(UserConnection));

		#endregion


		#region Constructors: Public

		public ChatTransferService() : base() {
		}

		/// <summary>
		/// Initializes new instance of <see cref="ChatTransferService"/>.
		/// </summary>
		public ChatTransferService(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Transfers chat to queue
		/// </summary>
		/// <param name="message">System message template to be published after chat was transferred.</param>
		/// <param name="queueId">ID of queue to be chat transferred</param>
		/// <returns>Result of chat transferring.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public ChatTransferServiceResponse TransferChatToQueue(MessagingMessage message, Guid queueId) {
			var response = new ChatTransferServiceResponse();
			var (success, newChatId) = new TransferChatToQueueProvider(UserConnection, message).Transfer(queueId);
			response.Success = success;
			response.NewChatId = newChatId;
			return response;
		}

		/// <summary>
		/// Transfers chat to queue
		/// </summary>
		/// <param name="message">System message template to be published after chat was transferred.</param>
		/// <param name="operatorId">Identifier of operator to be chat transferred</param>
		/// <returns>Result of chat transferring.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public ChatTransferServiceResponse TransferChatToOperator(MessagingMessage message, Guid operatorId) {
			var response = new ChatTransferServiceResponse();
			var (success, newChatId) = new TransferChatToOperatorProvider(UserConnection, message).Transfer(operatorId);
			response.Success = success;
			response.NewChatId = newChatId;
			return response;
		}

		/// <summary>
		/// Gets list of operators for chat transferring.
		/// </summary>
		/// <param name="search">Operators search pattern.</param>
		/// <returns>List of operators</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public List<TransferOperatorResponse> GetOperators(string search) {
			var response = new List<TransferOperatorResponse>();
			var operators = Store.GetOperators(search);
			operators.ForEach(o => response.Add(new TransferOperatorResponse {
				Id = o.Id,
				Contact = new OperatorContactResponse {
					Id = o.Contact.Id,
					Name = o.Contact.Name,
					PhotoId = o.Contact.PhotoId.ToString()
				},
				Status = o.Status
			}));
			return response;
		}

		/// <summary>
		/// Gets list of queues for chat transferring.
		/// </summary>
		/// <param name="search">Queues search pattern.</param>
		/// <returns>List of queues</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public List<TransferQueueResponse> GetQueues(string search) {
			var response = new List<TransferQueueResponse>();
			var queues = Store.GetQueues(search);
			queues.ForEach(q => response.Add(new TransferQueueResponse {
				Id = q.Id,
				Name = q.Name,
				ActiveOperatorCount = q.ActiveOperatorCount
			}));
			return response;
		}

		#endregion

	}

	#endregion

	#region TransferOperatorResponse

	/// <summary>
	/// Response with operator for chat transferring.
	/// </summary>
	[DataContract]
	public class TransferOperatorResponse
	{

		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "contact")]
		public OperatorContactResponse Contact { get; set; }

		[DataMember(Name = "status")]
		public TransferOperatorStatus Status { get; set; } = TransferOperatorStatus.InActive;

	}

	#endregion

	#region OperatorContactResponse

	/// <summary>
	/// Response with operator contact.
	/// </summary>
	[DataContract]
	public class OperatorContactResponse
	{
		[DataMember(Name = "id")]
		public Guid Id;

		[DataMember(Name = "name")]
		public string Name;

		[DataMember(Name = "photoId")]
		public string PhotoId;
	}

	#endregion

	#region TransferQueueResponse

	/// <summary>
	/// Response with queue for chat transferring.
	/// </summary>
	[DataContract]
	public class TransferQueueResponse
	{

		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "activeOperatorCount")]
		public int ActiveOperatorCount { get; set; }

	}

	#endregion

}
