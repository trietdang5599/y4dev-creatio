namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Core.Factories;

	#region Class: ChatTransferredToAgentData

	/// <summary>
	/// Class representing the data for transferring a chat to an agent.
	/// </summary>
	public class ChatTransferredToAgentData
	{
		/// <summary>
		/// Identifier of the operator transferring the chat.
		/// </summary>
		public Guid FromOperatorId {
			get; set;
		}

		/// <summary>
		/// Identifier of the operator receiving the transferred chat.
		/// </summary>
		public Guid ToOperatorId {
			get; set;
		}

		/// <summary>
		/// Chat transfer date.
		/// </summary>
		public DateTime TransferDate { get; set; }
		}

	#endregion

	#region Class: ChatTransferToAgentMetadata

	/// <summary>
	/// Implementation of <see cref="IChatMessageMetadata{ChatTransferredToAgentData}"/> for generating metadata
	/// related to the transfer of a chat between operators.
	/// </summary>
	[DefaultBinding(typeof(IChatMessageMetadata<ChatTransferredToAgentData>), Name = "ChatTransferToAgentMetadata")]
	public class ChatTransferToAgentMetadata : IChatMessageMetadata<ChatTransferredToAgentData>
	{

		#region Methods: Public

		/// <summary>
		/// Generates metadata for a chat transfer event between operators.
		/// </summary>
		/// <param name="data">The data associated with the chat transfer event.</param>
		/// <returns>A JSON string containing the generated metadata for the chat transfer.</returns>
		public string Generate(ChatTransferredToAgentData data) {
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
					key = "operatorTo",
					type = "lookup",
					value = new
					{
						entitySchemaName = "Contact",
						primaryColumnValue = data.ToOperatorId
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

