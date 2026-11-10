namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Runtime.Serialization;
	using Facebook;

	#region Class: FacebookEntityMetadata

	[DataContract]
	public class FacebookEntityMetadata : FacebookEntity
	{

		#region Properties: Public

		[DataMember(Name = "fields")]
		[FacebookMapping("fields", Parent = "metadata")]
		public JsonArray Fields {
			get;
			set;
		}

		[DataMember(Name = "type")]
		[FacebookMapping("type", Parent = "metadata")]
		public string Type {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
