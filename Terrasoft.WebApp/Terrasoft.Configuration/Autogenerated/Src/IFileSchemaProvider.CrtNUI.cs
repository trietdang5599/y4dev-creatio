 namespace Terrasoft.Configuration
{
	using System.Collections.Generic;

	#region Interface: IEntity

	/// <summary>
	/// Provides information about entity schemas are inherited from "Files".
	/// </summary>
	public interface IFileSchemaProvider
	{

		#region Methods: Public

		/// <summary>
		/// Returns the list of all schemas are inherited from "Files" schema, including additional information.
		/// </summary>
		/// <returns>Collection of File schemas info.</returns>
		List<FileSchemaInfo> GetAllSchemas();

		/// <summary>
		/// Returns information about file entity schema which is related to specified record entity schema.
		/// </summary>
		/// <param name="recordSchemaName">Name of the record entity schema.</param>
		/// <returns>Object with information about file schema.</returns>
		FileSchemaInfo FindSchema(string recordSchemaName);

		#endregion

	}

	#endregion

}

