namespace Terrasoft.Configuration.Omnichannel.Messaging
{

	#region Class: IChatMessageMetadata

	/// <summary>
	/// Interface for generating chat message metadata.
	/// </summary>
	/// <typeparam name="T">The type of data used for generating chat message metadata.</typeparam>
	public interface IChatMessageMetadata<T>
	{
		/// <summary>
		/// Generates metadata for a chat message based on the provided data.
		/// </summary>
		/// <param name="data">The data used to generate the chat message metadata.</param>
		/// <returns>Returns the generated chat message metadata as a string.</returns>
		string Generate(T data);
	}

	#endregion
}
