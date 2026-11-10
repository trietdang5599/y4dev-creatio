namespace Terrasoft.Configuration.Social
{
	using System;

	#region Class: FacebookMapping

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class FacebookMapping : Attribute
	{

		#region Constructors: Public

		public FacebookMapping(string name) {
			Name = name;
			Parent = string.Empty;
		}

		#endregion

		#region Properties: Public

		private string _name;
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		private string _parent;
		public string Parent {
			get {
				return _parent;
			}
			set {
				_parent = value;
			}
		}

		#endregion
	}

	#endregion

}
