namespace Terrasoft.Configuration
{

	#region Interface: IExternalApplicationHubProvider

	/// <summary>
	/// Interface for providing information about external application hub.
	/// </summary>
	public interface IExternalApplicationHubProvider
	{

		#region Methods: Public

		/// <summary>
		/// Gets the external application hub URL.
		/// </summary>
		/// <returns>The URL of the external application hub.</returns>
		string GetUrl();

		#endregion

	}

	#endregion

}
