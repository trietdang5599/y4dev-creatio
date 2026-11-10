namespace Terrasoft.Configuration.EmailsSearch
{
	using System.Collections.Generic;

	#region Interface: IESEmailManager

	/// <summary>
	/// Provides methods for email searching.
	/// </summary>
	public interface IESEmailManager
	{

		#region Methods: Public

		/// <summary>
		/// Search emails.
		/// </summary>
		/// <param name="request">List of search strings.</param>
		/// <param name="rowCount">Count of rows in return value.</param>
		/// <param name="rowsOffset">Rows offset in general response.</param>
		/// <returns>Dictionary of emails.</returns>
		IEnumerable<Dictionary<string, string>> SearchEmails(List<string> request, int rowCount = 0, int rowsOffset = 0);

		#endregion

	}

	#endregion

}
