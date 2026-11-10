namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Core.Factories;

	#region Class: ChatCompletedData

	/// <summary>
	/// Class representing the data for a completed chat.
	/// </summary>
	public class ChatCompletedData
	{
		/// <summary>
		/// Date and time when the chat was closed.
		/// </summary>
		public DateTime CloseDate {
			get; set;
		}
	}

	#endregion

	#region Class: ChatCompletedMetadata

	/// <summary>
	/// Implementation of <see cref="IChatMessageMetadata{ChatCompletedData}"/> for generating metadata
	/// related to a completed chat.
	/// </summary>
	[DefaultBinding(typeof(IChatMessageMetadata<ChatCompletedData>), Name = "ChatCompletedMetadata")]
	public class ChatCompletedMetadata : IChatMessageMetadata<ChatCompletedData>
	{
		/// <summary>
		/// Generates metadata for a completed chat event.
		/// </summary>
		/// <param name="data">The data associated with the completed chat event.</param>
		/// <returns>A JSON string containing the generated metadata for the completed chat.</returns>
		public string Generate(ChatCompletedData data) {
			var metadata = new List<object> {
				new {
					key = "closeDate",
					type = "datetime",
					value = data.CloseDate
				},
				new {
					key = "icon",
					type = "icon",
					value = "checkbox-icon"
				}
			};

			return JsonConvert.SerializeObject(metadata);
		}
	}

	#endregion


	#region Class: ChatAgentClosedData

	/// <summary>
	/// Class representing the data for a chat closed by an operator.
	/// </summary>
	public class ChatAgentClosedData
	{
		/// <summary>
		/// Date and time when the chat was closed.
		/// </summary>
		public DateTime CloseDate {
			get; set;
		}

		/// <summary>
		/// Identifier of the operator who closed the chat.
		/// </summary>
		public Guid AgentId {
			get; set;
		}
	}

	#endregion

	#region Class: ChatAgentClosedMetadata

	/// <summary>
	/// Implementation of <see cref="IChatMessageMetadata{ChatAgentClosedData}"/> for generating metadata
	/// related to a chat closed by an agent.
	/// </summary>
	[DefaultBinding(typeof(IChatMessageMetadata<ChatAgentClosedData>), Name = "ChatAgentClosedMetadata")]
	public class ChatAgentClosedMetadata : IChatMessageMetadata<ChatAgentClosedData>
	{
		/// <summary>
		/// Generates metadata for a chat closed by operator event.
		/// </summary>
		/// <param name="data">The data associated with the chat closed by agent event.</param>
		/// <returns>A JSON string containing the generated metadata for the chat closed by agent.</returns>
		public string Generate(ChatAgentClosedData data) {
			var metadata = new List<object> {
				new {
					key = "closeDate",
					type = "datetime",
					value = data.CloseDate
				},
				new {
					key = "agent",
					type = "lookup",
					value = new
					{
						entitySchemaName = "Contact",
						primaryColumnValue = data.AgentId
					}
				},
				new {
					key = "icon",
					type = "icon",
					value = "checkbox-icon"
				}
			};

			return JsonConvert.SerializeObject(metadata);
		}
	}

	#endregion

	#region Class: ChatEndUserClosedData

	/// <summary>
	/// Class representing the data for a chat closed by an end user.
	/// </summary>
	public class ChatEndUserClosedData
	{
		/// <summary>
		/// Date and time when the chat was closed.
		/// </summary>
		public DateTime CloseDate {
			get; set;
		}
	}

	#endregion

	#region Class: ChatEndUserClosedMetadata

	/// <summary>
	/// Implementation of <see cref="IChatMessageMetadata{ChatEndUserClosedData}"/> for generating metadata
	/// related to a chat closed by an end user.
	/// </summary>
	[DefaultBinding(typeof(IChatMessageMetadata<ChatEndUserClosedData>), Name = "ChatEndUserClosedMetadata")]
	public class ChatEndUserClosedMetadata : IChatMessageMetadata<ChatEndUserClosedData>
	{
		/// <summary>
		/// Generates metadata for a chat closed by end user event.
		/// </summary>
		/// <param name="data">The data associated with the chat closed by end user event.</param>
		/// <returns>A JSON string containing the generated metadata for the chat closed by end user.</returns>
		public string Generate(ChatEndUserClosedData data) {
			var metadata = new List<object> {
				new {
					key = "closeDate",
					type = "datetime",
					value = data.CloseDate
				},
				new {
					key = "icon",
					type = "icon",
					value = "checkbox-icon"
				}
			};

			return JsonConvert.SerializeObject(metadata);
		}
	}

	#endregion

}
