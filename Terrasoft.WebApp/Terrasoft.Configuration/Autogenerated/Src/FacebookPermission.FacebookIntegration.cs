namespace Terrasoft.Configuration.Social
{

	#region Class: FacebookPermission

	public class FacebookPermission : BasePermission {

		#region Properties: Public

		public string Name {get; set;}

		public string Description {get; set;}

		public PermissionStatus Status {get; set;}

		#endregion

		#region Constructors: Public

		public FacebookPermission(string name, string description) {
			this.Name = name;
			this.Description = description;
		}

		#endregion

	}

	#endregion

}
