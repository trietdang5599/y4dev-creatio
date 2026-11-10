namespace Terrasoft.Configuration.Timeline
{
	using Terrasoft.Core;

	#region Class: TimelineUtilities

	/// <summary>
	/// Provides Timeline utility methods.
	/// </summary>
	public static class TimelineUtilities
	{

		#region Constants: Private

		private static int _maxSizeDefColumnValue = 1024 * 50;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets email body column max size.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <returns>A max size email body value.</returns>
		public static int GetEmailMaxSizeColumnValue(UserConnection userConnection) {
			return Core.Configuration.SysSettings.GetValue(userConnection, "LargeSizeEmailValueInFreedomUI", _maxSizeDefColumnValue);
		}

		#endregion

	}

	#endregion

}
