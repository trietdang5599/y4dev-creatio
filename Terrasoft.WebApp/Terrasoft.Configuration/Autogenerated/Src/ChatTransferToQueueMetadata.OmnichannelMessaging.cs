namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Core.Factories;

	#region Class: ChatTransferToQueueData

	/// <summary>
	/// Class representing the data for transferring a chat to the queue.
	/// </summary>
	public class ChatTransferToQueueData
	{
		/// <summary>
		/// Identifier of the operator transferring the chat.
		/// </summary>
		public Guid FromOperatorId {
			get; set;
		}

		/// <summary>
		/// Identifier of the queue receiving the transferred chat.
		/// </summary>
		public Guid ToQueueId {
			get; set;
		}

		/// <summary>
		/// Chat transfer date.
		/// </summary>
		public DateTime TransferDate {
			get; set;
		}
	}

	#endregion

	#region Class: ChatTransferToAgentMetadata

	/// <summary>
	/// Implementation of <see cref="IChatMessageMetadata{ChatTransferToQueueData}"/> for generating metadata
	/// related to the transfer of a chat between operators.
	/// </summary>
	[DefaultBinding(typeof(IChatMessageMetadata<ChatTransferToQueueData>), Name = "ChatTransferToQueueMetadata")]
	public class ChatTransferToQueueMetadata : IChatMessageMetadata<ChatTransferToQueueData>
	{

		#region Methods: Public

		/// <summary>
		/// Generates metadata for a chat transfer event between operators.
		/// </summary>
		/// <param name="data">The data associated with the chat transfer event.</param>
		/// <returns>A JSON string containing the generated metadata for the chat transfer.</returns>
		public string Generate(ChatTransferToQueueData data) {
			var metadata = new List<object> {
				new {
					key = "transferDate",
					type = "datetime",
					value = data.TransferDate
				},
				new {
					key = "operatorFrom",
					type = "lookup",
					value = new
					{
						entitySchemaName = "Contact",
						primaryColumnValue = data.FromOperatorId
					}
				},
				new {
					key = "queueTo",
					type = "lookup",
					value = new
					{
						entitySchemaName = "ChatQueue",
						primaryColumnValue = data.ToQueueId
					}
				},
				new {
					key = "icon",
					type = "icon",
					value = "change-contact-icon"
				}
			};

			return JsonConvert.SerializeObject(metadata);
		}

		#endregion

	}

	#endregion
}

