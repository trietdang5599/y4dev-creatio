namespace Terrasoft.Configuration.Url {
	using System;

	/// <summary>
	/// Contains configuration for generating an open URL.
	/// </summary>
	public class OpenUrlConfig
	{


		/// <summary>
		/// Gets or sets the schema name.
		/// </summary>
		public string SchemaName { get; set; }

		/// <summary>
		/// Gets or sets the record identifier.
		/// </summary>
		public Guid RecordId { get; set; }

	}

	/// <summary>
	/// Interface for generating URLs for different navigation options.
	/// </summary>
	#region Interface: IOpenLinkUrlGenerator

	public interface IOpenLinkUrlGenerator
	{

		#region Methods: Public


		/// <summary>
		/// Generates a URL based on the provided configuration.
		/// </summary>
		/// <param name="config">The configuration for generating the URL.<see cref="OpenUrlConfig"/></param>
		/// <exception cref="Terrasoft.Common.ArgumentNullOrEmptyException"> Thrown when the config null
		/// or schema name is empty or null.</exception>
		/// <exception cref="Terrasoft.Common.ItemNotFoundException"> Thrown when the schema is not found by name.</exception>
		/// <returns>A string representing the generated URL.</returns>
		string GetUrl(OpenUrlConfig config);

		#endregion

	}

	#endregion

}
