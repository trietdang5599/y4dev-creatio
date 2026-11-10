namespace Terrasoft.Configuration.NavigationMenu
{
	using System.Collections.Generic;
	using WorkplaceApi;

	#region Class:  NavigationMenuGroupsInfo

	/// <summary>
	/// Describes navigation menu groups info
	/// </summary>
	public class NavigationMenuGroupsInfo
	{

		#region Properties: Public

		/// <summary>
		/// Collection of <see cref="NavigationMenuGroup"/>.
		/// </summary>
		public IEnumerable<NavigationMenuGroup> Groups { get; set; }

		/// <summary>
		/// Result of loading workplace structure.
		/// </summary>
		public WorkplaceLoadingResult LoadingResult { get; set; }

		#endregion

	}

	#endregion

}
