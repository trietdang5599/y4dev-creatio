namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Facebook;

	#region Class: AccessTokenInfo

	[Serializable]
	[DataContract]
	public class AccessTokenInfo
	{

		#region Properties: Public

		[DataMember(Name = "accessToken")]
		[FacebookMapping("access_token")]
		public string AccessToken {
			get;
			set;
		}

		[DataMember(Name = "appId")]
		[FacebookMapping("app_id")]
		public string AppId {
			get;
			set;
		}

		[DataMember(Name = "application")]
		[FacebookMapping("application")]
		public string Application {
			get;
			set;
		}

		[DataMember(Name = "expiresAt")]
		[FacebookMapping("expires_at")]
		public long ExpiresAt {
			get;
			set;
		}

		[DataMember(Name = "expiresIn")]
		[FacebookMapping("expires_in")]
		public long ExpiresIn {
			get;
			set;
		}

		[DataMember(Name = "isValid")]
		[FacebookMapping("is_valid")]
		public bool IsValid {
			get;
			set;
		}

		[DataMember(Name = "issuedAt")]
		[FacebookMapping("issued_at")]
		public long IssuedAt {
			get;
			set;
		}

		[DataMember(Name = "scopes")]
		[FacebookMapping("scopes")]
		public List<object> Scopes {
			get;
			set;
		}

		[DataMember(Name = "tokenType")]
		[FacebookMapping("token_type")]
		public string TokenType {
			get;
			set;
		}

		[DataMember(Name = "userId")]
		[FacebookMapping("user_id")]
		public string UserId {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
