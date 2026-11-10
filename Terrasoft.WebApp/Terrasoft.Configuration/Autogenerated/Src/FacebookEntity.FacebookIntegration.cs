namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Facebook;

	#region Class: FacebookEntity

	[DataContract]
	public class FacebookEntity
	{

		#region Properties: Public

		[DataMember(Name = "id")]
		[FacebookMapping("id")]
		public string Id {
			get;
			set;
		}

		[DataMember(Name = "name")]
		[FacebookMapping("name")]
		public string Name {
			get;
			set;
		}

		[DataMember(Name = "imageUrl")]
		[FacebookMapping("url", Parent = "picture")]
		public string ImageUrl {
			get;
			set;
		}

		[DataMember(Name = "isDefaultImage")]
		[FacebookMapping("is_silhouette", Parent = "picture")]
		public bool IsDefaultImage {
			get;
			set;
		}

		[DataMember(Name = "coverUrl")]
		[FacebookMapping("source", Parent = "cover")]
		public string CoverUrl {
			get;
			set;
		}

		[DataMember(Name = "category")]
		[FacebookMapping("category")]
		public string Category {
			get;
			set;
		}

		[DataMember(Name = "about")]
		[FacebookMapping("about")]
		public string About {
			get;
			set;
		}

		[DataMember(Name = "website")]
		[FacebookMapping("website")]
		public string Website {
			get;
			set;
		}

		[DataMember(Name = "street")]
		[FacebookMapping("street", Parent = "location")]
		public string Street {
			get;
			set;
		}

		[DataMember(Name = "state")]
		[FacebookMapping("state", Parent = "location")]
		public string State {
			get;
			set;
		}

		[DataMember(Name = "city")]
		[FacebookMapping("city", Parent = "location")]
		public string City {
			get;
			set;
		}

		[DataMember(Name = "country")]
		[FacebookMapping("country", Parent = "location")]
		public string Country {
			get;
			set;
		}

		[DataMember(Name = "zip")]
		[FacebookMapping("zip", Parent = "location")]
		public string Zip {
			get;
			set;
		}

		[DataMember(Name = "latitude")]
		[FacebookMapping("latitude", Parent = "location")]
		public double Latitude {
			get;
			set;
		}

		[DataMember(Name = "longtitude")]
		[FacebookMapping("longtitude", Parent = "location")]
		public double Longtitude {
			get;
			set;
		}

		[DataMember(Name = "phone")]
		[FacebookMapping("phone")]
		public string Phone {
			get;
			set;
		}

		[DataMember(Name = "email")]
		[FacebookMapping("email")]
		public string Email {
			get;
			set;
		}

		[DataMember(Name = "emails")]
		[FacebookMapping("emails")]
		public JsonArray Emails {
			get;
			set;
		}

		[DataMember(Name = "founded")]
		[FacebookMapping("founded")]
		public string Founded {
			get;
			set;
		}

		[DataMember(Name = "birthday")]
		[FacebookMapping("birthday")]
		public string Birthday {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
