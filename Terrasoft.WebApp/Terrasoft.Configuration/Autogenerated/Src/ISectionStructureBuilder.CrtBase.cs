namespace Terrasoft.Configuration
{

	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Interface: ISectionStructureBuilder

	public interface ISectionStructureBuilder
	{
		void ApplyCustomConditions(string schemaName, Select select);
	}

	#endregion

}
