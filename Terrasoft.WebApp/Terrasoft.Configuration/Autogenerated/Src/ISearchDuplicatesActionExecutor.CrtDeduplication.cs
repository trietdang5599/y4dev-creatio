namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;

	#region Interface: ISearchDuplicatesActionExecutor

	/// <summary>
	/// Deduplication manager.
	/// </summary>
	public interface ISearchDuplicatesActionExecutor
	{

		#region Methods: Public

		Guid ExecuteDuplicatesSearch(SearchDuplicatesActionConfiguration searchDuplicatesActionConfiguration);
		
		#endregion

	}

	#endregion

}
