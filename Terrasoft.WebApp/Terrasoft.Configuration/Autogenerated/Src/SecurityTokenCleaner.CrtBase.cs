namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Terrasoft.Core;

	#region Class : SecurityTokenCleaner

	/// <summary>
	/// Represents a cleaner job for expired security tokens.
	/// </summary>
	public class SecurityTokenCleaner : IJobExecutor
	{

		#region Methods : Public

		/// <summary>
		/// Deletes expired security tokens.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			new SecurityTokenUtilities(userConnection).DeleteExpiredTokens();
		}

		#endregion

	}

	#endregion

}
