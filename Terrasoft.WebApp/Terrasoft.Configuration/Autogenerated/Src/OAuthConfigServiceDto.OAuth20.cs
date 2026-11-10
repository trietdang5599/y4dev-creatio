namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: AddClientRequest

	[DataContract]
	public class AddClientRequest
	{

		#region Properties: Public

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		[DataMember(Name = "redirectUrl")]
		public string RedirectUrl { get; set; }
		
		[DataMember(Name = "applicationUrl", IsRequired = true)]
		public string ApplicationUrl { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }
		
		[DataMember(Name = "systemUserId")]
		public Guid SystemUserId { get; set; }

		[DataMember(Name = "isPublic")]
		public bool IsPublic { get; set; }

		[DataMember(Name = "requirePKCE")]
		public bool RequirePKCE { get; set; }
		
		[DataMember(Name = "grantType")]
		public string GrantType { get; set; }

		[DataMember(Name = "allowedGrantTypes")]
		public List<string> AllowedGrantTypes { get; set; }

		/// <summary>
		/// Whether to install (register in the Identity Service) the integration on creation (ENG-78572).
		/// <c>null</c> or <c>true</c> = install (legacy behavior); <c>false</c> = create in the Not installed
		/// state without any Identity Service call.
		/// </summary>
		[DataMember(Name = "installIntegration")]
		public bool? InstallIntegration { get; set; }

		/// <summary>
		/// When creating in the Not installed state, pre-generate a <c>ClientId</c> for downstream setup
		/// (the value is reused on a later Install). Ignored when the integration is installed immediately.
		/// </summary>
		[DataMember(Name = "generateClientId")]
		public bool GenerateClientId { get; set; }

		#endregion

	}

	#endregion

	#region Class: AddClientResponse

	[DataContract]
	public class AddClientResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "clientId")]
		public string ClientId { get; set; }

		[DataMember(Name = "clientSecret")]
		public string ClientSecret { get; set; }

		[DataMember(Name = "clientAppId")]
		public Guid ClientAppId { get; set; }

		#endregion

	}

	#endregion

	#region Class: InstallStatusFeatureStateResponse

	/// <summary>
	/// Whether the OAuthClientAppInstallStatus feature is enabled (ENG-78572). Used by the creation
	/// mini-pages to gate the "Install integration" / "Generate client id" controls.
	/// </summary>
	[DataContract]
	public class InstallStatusFeatureStateResponse
	{

		#region Properties: Public

		[DataMember(Name = "enabled")]
		public bool Enabled { get; set; }

		/// <summary>
		/// Whether the UI may offer creating an integration in the Not installed state (ENG-78572).
		/// True only when both the install lifecycle (F1) and create-not-installed (F2) features are on.
		/// </summary>
		[DataMember(Name = "canCreateNotInstalled")]
		public bool CanCreateNotInstalled { get; set; }

		#endregion

	}

	#endregion

	#region Class: UpdateClientRequest

	[DataContract]
	public class UpdateClientRequest
	{
		#region Properties: Public
		
		[DataMember(Name = "clientId")]
		public string ClientId { get; set; }

		// ENG-93603 follow-up: a Not installed integration has no Identity Service ClientId yet, so it is
		// addressed by its local OAuthClientApp record Id instead. UpdateClient uses this when ClientId is empty.
		[DataMember(Name = "clientAppId")]
		public Guid? ClientAppId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "redirectUrl")]
		public string RedirectUrl { get; set; }

		[DataMember(Name = "applicationUrl")]
		public string ApplicationUrl { get; set; }

		[DataMember(Name = "systemUserId")]
		public Guid? SystemUserId { get; set; }

		[DataMember(Name = "isActive")]
		public bool? IsActive { get; set; }

		[DataMember(Name = "allowedGrantTypes")]
		public List<string> AllowedGrantTypes { get; set; }

		#endregion
	}

	#endregion

	#region Class: UpdateClientScopesRequest

	[DataContract]
	public class UpdateClientScopesRequest
	{
		#region Properties: Public
		
		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }
		
		[DataMember(Name = "resourceName", IsRequired = true)]
		public string ResourceName { get; set; }

		#endregion
	}

	#endregion

	#region Class: DeleteClientRequest

	[DataContract]
	public class DeleteClientRequest
	{
		#region Properties: Public

		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }

		#endregion
	}

	#endregion

	#region Class: GetAllowedGrantTypesRequest

	[DataContract]
	public class GetAllowedGrantTypesRequest
	{
		#region Properties: Public

		[DataMember(Name = "clientId")]
		public string ClientId { get; set; }

		[DataMember(Name = "clientAppId")]
		public string ClientAppId { get; set; }

		#endregion
	}

	#endregion

	#region Class: GetAllowedGrantTypesResponse

	[DataContract]
	public class GetAllowedGrantTypesResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		[DataMember(Name = "allowedGrantTypes")]
		public List<string> AllowedGrantTypes { get; set; }

		#endregion
	}

	#endregion

	#region Class: CreateTechnicalUserRequest

	[DataContract]
	public class CreateTechnicalUserRequest
	{
		#region Properties: Public

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		#endregion
	}

	#endregion

	#region Class: CreateTechnicalUserResponse

	[DataContract]
	public class CreateTechnicalUserResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		[DataMember(Name = "systemUserId")]
		public Guid SystemUserId { get; set; }

		[DataMember(Name = "systemUserName")]
		public string SystemUserName { get; set; }

		#endregion
	}

	#endregion

	#region Class: OAuthSettingsRequest

	[DataContract]
	public class OAuthSettingsRequest
	{
		#region Properties: Public

		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }


		[DataMember(Name = "clientSecret", IsRequired = true)]
		public string ClientSecret { get; set; }

		[DataMember(Name = "serverUrl", IsRequired = true)]
		public string ServerUrl { get; set; }

		#endregion
	}

	#endregion

	#region Class: AddResourceResponse

	[DataContract]
	public class AddResourceResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "scope")]
		public string Scope { get; set; }

		#endregion

	}

	#endregion

	#region Class: ClientSecretResponse

	[DataContract]
	public class ClientSecretResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "clientSecret")]
		public string ClientSecret { get; set; }

		#endregion

	}

	#endregion

	#region Class: ClientSecretStatusResponse

	/// <summary>
	/// Reports only whether an Identity Server client secret is currently stored, without ever
	/// returning the secret itself (ENG-92697). Replaces the plaintext-returning
	/// <c>GetIdentityServerClientSecret</c> so the OAuth Settings modal can render a
	/// write-only field: a masked placeholder when a secret exists, an empty field otherwise.
	/// </summary>
	[DataContract]
	public class ClientSecretStatusResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "hasClientSecret")]
		public bool HasClientSecret { get; set; }

		#endregion

	}

	#endregion

	#region Class: TestConnectionResponse

	/// <summary>
	/// Result of an Identity Server connection test triggered from the OAuth Settings modal
	/// (ENG-92697). <c>Connected</c> is the actual test outcome; <c>Success</c>/<c>ErrorInfo</c>
	/// still report service-level failures (feature disabled, access denied, unexpected error).
	/// </summary>
	[DataContract]
	public class TestConnectionResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "connected")]
		public bool Connected { get; set; }

		#endregion

	}

	#endregion

	#region Class: RedirectUrlsResponse

	[DataContract]
	public class RedirectUrlsResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "redirectUrls")]
		public Dictionary<Guid, string> RedirectUrls { get; set; }

		#endregion

	}

	#endregion

	#region Class: RedirectUrlsRequest

	[DataContract]
	public class RedirectUrlsRequest
	{

		#region Properties: Public

		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }

		[DataMember(Name = "redirectUrls")]
		public List<string> RedirectUrls { get; set; }

		#endregion

	}

	#endregion

	#region Class: UpdateRedirectUrlRequest

	[DataContract]
	public class UpdateRedirectUrlRequest
	{
		#region Properties: Public
		
		[DataMember(Name = "redirectUrlId", IsRequired = true)]
		public string RedirectUrlId { get; set; }

		[DataMember(Name = "redirectUrl")]
		public string RedirectUrl { get; set; }

		#endregion
	}

	#endregion

	#region Class: DeleteRedirectUrlRequest

	[DataContract]
	public class DeleteRedirectUrlRequest
	{
		#region Properties: Public

		[DataMember(Name = "redirectUrlId", IsRequired = true)]
		public string RedirectUrlId { get; set; }

		#endregion
	}

	#endregion

}

