namespace Terrasoft.Configuration.NavigationMenu
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: GetNavigationMenuGroupsResponse

	[DataContract]
	public class GetNavigationMenuGroupsResponse : Core.ServiceModelContract.BaseResponse
	{
		[DataMember(Name = "workplaces")]
		public IEnumerable<NavigationMenuGroup> Workplaces { get; set; }

		[DataMember(Name = "loadingResult")]
		public string LoadingResult { get; set; }
	}

	#endregion

	#region Class: NavigationMenuGroup

	[DataContract]
	public class NavigationMenuGroup
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "sections")]
		public IList<NavigationMenuItem> Sections { get; set; }

	}

	#endregion

	#region Class: NavigationMenuItem

	[DataContract]
	public class NavigationMenuItem
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "iconBackgroundColor")]
		public string IconBackgroundColor { get; set; }

		[DataMember(Name = "iconUrl")]
		public string IconUrl { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		public string Type { get; set; }

		[DataMember(Name = "searchCaption")]
		public string SearchCaption { get; set; }
	}

	#endregion
}

