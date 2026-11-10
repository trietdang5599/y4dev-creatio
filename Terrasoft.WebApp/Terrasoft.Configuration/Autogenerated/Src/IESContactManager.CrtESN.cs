namespace Terrasoft.Configuration.ESN
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	#region Interface: IESEmailManager
	/// <summary>
	/// Provides methods for contacts searching.
	/// </summary>
	public interface IESContactManager
	{

		#region Methods: Public

		/// <summary>
		/// Search contacts.
		/// </summary>
		/// <param name="request">List of search strings.</param>
		/// <param name="rowCount">Count of rows in return value.</param>
		/// <param name="rowsOffset">Rows offset in general response.</param>
		/// <returns>List of <see cref="ContactForMention"/>.</returns>
		Task<IEnumerable<ContactForMention>> SearchContactsAsync(List<string> request, int rowCount = 0, int rowsOffset = 0);

		#endregion

	}

	#endregion

}
