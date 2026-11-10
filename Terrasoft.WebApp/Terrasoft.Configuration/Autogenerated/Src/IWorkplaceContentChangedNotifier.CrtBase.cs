 namespace Terrasoft.Configuration
{
	using System;

	/// <summary>
	/// Interface for sending notification message about workplace content changing.
	/// </summary>
	public interface IWorkplaceContentChangedNotifier
	{

		#region Methods: Public
		
		/// <summary>
		/// Sends notification message about workplace content changing.
		/// <param name="userIds">Ids of users to send message.</param>
		/// </summary>
		void Notify(Guid[] userIds);

		#endregion
	}
}
