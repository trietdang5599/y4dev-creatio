using System.Collections.Generic;
using Terrasoft.Configuration.NavigationMenu;

/// <summary>
/// Workplace data provider for navigation panel.
/// </summary>
public interface IWorkplaceNavigationPanelProvider
{

	#region Methods: Public

	/// <summary>
	/// Loads workspace groups for navigation panel.
	/// </summary>
	/// <returns>Workspace groups collection</returns>
	IEnumerable<NavigationMenuGroup> Load();

	#endregion

}
