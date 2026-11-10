namespace Terrasoft.Configuration.ESN
{
	using System;

	#region  Interface: IEsnSecurityEngine

	/// <summary>
	/// Provides methods for checking permission to enterprise social network messages.
	/// </summary>
	public interface IEsnSecurityEngine
	{
		/// <summary>
		/// Check whether the user has access to receive entity messages.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanReadEntityMessage(Guid schemaUId, Guid entityId);
		
		/// <summary>
		/// Check whether the user has access to posting message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanCreateMessage(Guid schemaUId, Guid entityId);

		/// <summary>
		/// Check whether the user has access to posting comment.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanCreateComment(Guid schemaUId, Guid entityId);

		/// <summary>
		/// Check whether the user has access to editing message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageAuthorId">Message author id.</param>
		bool CanEditPost(Guid schemaUId, Guid entityId, Guid messageAuthorId);

		/// <summary>
		/// Check whether the user has access to deleting message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageAuthorId">Message author id.</param>
		bool CanDeletePost(Guid schemaUId, Guid entityId, Guid messageAuthorId);

		/// <summary>
		/// Check whether the external user has access to social message.
		/// </summary>
		/// <param name="socialMessageId">Social message identifier.</param>
		/// <returns>
		/// <para>- <c>true</c> if user is internal;</para>
		/// <para>- <c>true</c> if external user, but social message is external;</para>
		/// <para>- <c>true</c> if <paramref name="socialMessageId"/> is not social message entity;</para>
		/// <para>- <c>fasle</c> otherwise</para>
		/// </returns>
		bool GetHasSocialMessageExternalAccess(Guid socialMessageId);

		}

	#endregion
}

