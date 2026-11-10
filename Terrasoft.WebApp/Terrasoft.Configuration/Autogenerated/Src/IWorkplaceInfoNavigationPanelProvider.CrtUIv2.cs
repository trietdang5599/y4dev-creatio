using System.Collections.Generic;
using Terrasoft.Configuration.NavigationMenu;
using WorkplaceApi;

/// <summary>
/// Workplace info data provider for navigation panel.
/// </summary>
public interface IWorkplaceInfoNavigationPanelProvider
{

	#region Methods: Public

	/// <summary>
	/// Loads workspaces info for navigation panel.
	/// </summary>
	/// <returns>Workspace groups collection</returns>
	NavigationMenuGroupsInfo LoadInfo();

	/// <summary>
	/// Loads workspaces info for mobile app.
	/// </summary>
	/// <returns>Workspace groups collection for mobile app</returns>
	NavigationMenuGroupsInfo LoadMobileWorkplaces();

	#endregion

}
