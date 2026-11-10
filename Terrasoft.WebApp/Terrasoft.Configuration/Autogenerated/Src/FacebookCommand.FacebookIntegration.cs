namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: FacebookCommand

	public class FacebookCommand : BaseCommand
	{

		#region Constructors: Public

		public FacebookCommand() {
			Permissions = new List<BasePermission> {
				new FacebookPermission("user_about_me", "user_about_me"),
				new FacebookPermission("email", "email"),
				new FacebookPermission("user_friends", "user_friends"),
				new FacebookPermission("user_likes", "user_likes"),
				new FacebookPermission("user_photos", "user_photos")
			};
		}

		#endregion

	}

	#endregion

}
