namespace Terrasoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using Core.Entities;
	
	#region  Interface: IEsnMessageReader

	/// <summary>
	/// Provides methods for social network reading messages.
	/// </summary>
	public interface IEsnMessageReader
	{
		/// <summary>
		/// Get comment collection for message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="readingMode">Reading mode.</param>
		/// <returns><see cref="Entity"/>instance collection.</returns>
		IEnumerable<Entity> ReadComments(Guid messageId, FeedReadingMode readingMode = FeedReadingMode.All);

		/// <summary>
		/// Get feed attachment collection for message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns><see cref="Entity"/>instance collection.</returns>
		IEnumerable<Entity> ReadAttachments(Guid messageId);

		/// <summary>
		/// Get message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="readingMode">Reading mode.</param>
		/// <returns><see cref="Entity"/>instance.</returns>
		Entity ReadMessage(Guid messageId, FeedReadingMode readingMode  = FeedReadingMode.All);
		
		/// <summary>
		/// Get comment.
		/// </summary>
		/// <param name="commentId">Comment id.</param>
		/// <param name="readingMode">Reading mode.</param>
		/// <returns><see cref="Entity"/>instance.</returns>
		Entity ReadComment(Guid commentId, FeedReadingMode readingMode  = FeedReadingMode.All);

		/// <summary>
		/// Get message with all columns entity.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns><see cref="Entity"/>instance.</returns>
		Entity ReadMessageAllColumnsEntity(Guid messageId);

		/// <summary>
		/// Get chunk messages for entity.
		/// </summary>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns><see cref="Entity"/>instance collection.</returns>
		IEnumerable<Entity> ReadEntityMessage(Guid entityId, EsnReadMessageOptions readOptions);

		/// <summary>
		/// Get chunk messages for user feed.
		/// </summary>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Collection of message DTO <see cref="EsnReadMessageDTO" />.</returns>
		IEnumerable<Entity> ReadFeedMessage(EsnReadMessageOptions readOptions);
	}

	#endregion
}

