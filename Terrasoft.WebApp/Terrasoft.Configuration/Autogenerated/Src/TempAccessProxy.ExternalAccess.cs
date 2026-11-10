namespace Terrasoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.DTO;

	#region Interface: ITempAccessProxy

	/// <summary>
	/// Proxy for TempAccess service Api.
	/// </summary>
	public interface ITempAccessProxy
	{

		#region Methods: Public

		/// <summary>
		/// Grants the access.
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="expirationDate">The expiration date.</param>
		/// <param name="grantorSysAdminUnitId">The grantor system admin unit id.</param>
		/// <param name="isDataIsolationEnabled">The value indicating whether data isolation mode is enabled</param>
		/// <param name="isSystemOperationsRestricted">The value indicating whether system operations are restricted</param>
		/// <param name="granteeClientIds">The grantee client ids.</param>
		void GrantAccess(string resourceName, string reason, DateTime expirationDate, Guid grantorSysAdminUnitId,
			bool isDataIsolationEnabled, bool isSystemOperationsRestricted, string[] granteeClientIds);

		/// <summary>
		/// Enumerate granted access list.
		/// </summary>
		/// <param name="customerIds">The customer ids (Access grantors).</param>
		/// <param name="clientId">Access grantor's client id. If set, accesses of the given client will be added to
		/// the result set.</param>
		List<GetAccessListDto> GetAccessList(string[] customerIds, string clientId = null);

		/// <summary>
		/// Request access token.
		/// </summary>
		/// <param name="accessId">Access id.</param>
		string GetAccessToken(string accessId);

		#endregion

	}

	#endregion

	#region Interface: ITempAccessDeactivator

	/// <summary>
	/// Proxy for TempAccess deactivation Api.
	/// </summary>
	public interface ITempAccessDeactivator
	{

		#region Methods: Public

		/// <summary>Deactivates the specified access ids.</summary>
		/// <param name="accessIds">The access ids.</param>
		/// <returns>Affected access count.</returns>
		int Deactivate(string[] accessIds);

		#endregion

	}

	#endregion

	#region Interface: IIdentityServiceClientFinder

	/// <summary>
	/// Proxy for Identity service client finder Api.
	/// </summary>
	public interface IIdentityServiceClientFinder
	{

		#region Methods: Public

		/// <summary>Searches clients by customer ids or client id.</summary>
		/// <param name="clientsFilter">Filter info (customerIds, clientId, etc.) to search clients.</param>
		IList<ShortIdentityClientInfo> Search(FindIdentityClientsFilter clientsFilter);

		#endregion

	}

	#endregion

	#region Struct: GetAccessListDto

	/// <summary>
	/// Response Dto for GetAccessList method.
	/// </summary>
	public struct GetAccessListDto {

		#region Properties: Public

		/// <summary>
		/// Gets or sets the access identifier.
		/// </summary>
		/// <value>
		/// The access identifier.
		/// </value>
		public string AccessId { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the expiration date.
		/// </summary>
		/// <value>
		/// The expiration date.
		/// </value>
		public DateTime ExpirationDate { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier (CID).
		/// </summary>
		/// <value>
		/// The customer identifier (CID).
		/// </value>
		public string CustomerId { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether data isolation mode is enabled.
		/// </summary>
		/// <value>
		/// The indicator whether data isolation mode is enabled.
		/// </value>
		public bool IsDataIsolationEnabled { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether system operations are restricted.
		/// </summary>
		/// <value>
		/// The indicator whether system operations are restricted.
		/// </value>
		public bool IsSystemOperationsRestricted { get; set; }

		#endregion

	}

	#endregion

	#region Class: TempAccessProxy

	/// <summary>
	/// Default proxy for TempAccess service Api.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ExternalAccessPackage.ITempAccessProxy" />
	[DefaultBinding(typeof(ITempAccessProxy))]
	[DefaultBinding(typeof(ITempAccessDeactivator))]
	[DefaultBinding(typeof(IIdentityServiceClientFinder))]
	public class TempAccessProxy : ITempAccessProxy, ITempAccessDeactivator, IIdentityServiceClientFinder
	{

		#region Constants: Public

		public const string RegisterAccessScopes = "register_own_resource IdentityServerApi";
		public const string ListAccessScopes = "get_resource_list IdentityServerApi";
		public const string ClientInfoScopes = "get_client_info IdentityServerApi";
		public const string FindClientsScopes = "find_clients IdentityServerApi";
		public const int RegistrationTimeoutMs = 20000;
		public const string RegisterAccessMethod = "OwnedResources/register";
		public const string ListAccessMethod = "OwnedResources/list";
		public const string RemoveAccessesMethod = "OwnedResources/delete";
		public const string FindClientsMethod = "Clients/find";

		#endregion

		#region Fields: Private

		private readonly string _serverUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TempAccessProxy"/> class.
		/// </summary>
		/// <param name="serverUrl">The identity server URL.</param>
		/// <param name="clientId">The application client id.</param>
		/// <param name="clientSecret">The client secret.</param>
		public TempAccessProxy(string serverUrl, string clientId, string clientSecret) {
			serverUrl.CheckArgumentNullOrWhiteSpace(nameof(serverUrl));
			clientId.CheckArgumentNullOrWhiteSpace(nameof(clientId));
			_serverUrl = serverUrl;
			_clientId = clientId;
			_clientSecret = clientSecret;
		}

		#endregion

		#region Properties: Private
		
		private IIdentityServiceWrapper _identityServiceWrapper;
		private IIdentityServiceWrapper IdentityServiceWrapper => _identityServiceWrapper ??
			(_identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance());

		#endregion

		#region Methods: Public

		/// <summary>
		/// Grants the access.
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="expirationDate">The expiration date.</param>
		/// <param name="grantorSysAdminUnitId">The grantor system admin unit id.</param>
		/// <param name="isDataIsolationEnabled">The value indicating whether data isolation mode is enabled</param>
		/// <param name="isSystemOperationsRestricted">The value indicating whether system operations are restricted</param>
		/// <param name="granteeClientIds">The grantee client ids.</param>
		public void GrantAccess(string resourceName, string reason, DateTime expirationDate, Guid grantorSysAdminUnitId,
				bool isDataIsolationEnabled, bool isSystemOperationsRestricted, string[] granteeClientIds) {
			resourceName.CheckArgumentNullOrWhiteSpace(nameof(resourceName));
			var apiResource = new ApiResourceInfo {
				Name = resourceName,
				DisplayName = reason,
				Properties = new Dictionary<string, string> {
					{ "ExpirationDate", expirationDate.ToUniversalTime().ToString("o") },
					{ "IsSystemOperationsRestricted", isSystemOperationsRestricted.ToString() },
					{ "IsDataIsolationEnabled", isDataIsolationEnabled.ToString() },
					{ "SysAdminUnitId", grantorSysAdminUnitId.ToString() },
					{ "Type", "TempAccess" }
				}
			};
			IdentityServiceWrapper.AddResource(apiResource, granteeClientIds);
		}

		/// <summary>
		/// Enumerate granted access list.
		/// </summary>
		/// <param name="customerIds">The customer ids (Access grantors).</param>
		/// <param name="clientId">Access grantor's client id. If set, accesses of the given client will be added to
		/// the result set.</param>
		public List<GetAccessListDto> GetAccessList(string[] customerIds, string clientId = null) {
			if (customerIds.IsNullOrEmpty() && clientId.IsNullOrEmpty()) {
				throw new ArgumentNullOrEmptyException($"{nameof(customerIds)} or {nameof(clientId)}");
			}
			var resourcesList = IdentityServiceWrapper.GetResourcesList("TempAccess", customerIds, clientId);
			var accessList = resourcesList.SelectMany(clientInfo => clientInfo.Resources.Select(item =>
				new GetAccessListDto {
					AccessId = item.Name,
					Url = clientInfo.ClientUri,
					Description = item.DisplayName,
					ExpirationDate = item.ExpirationDate,
					CustomerId = clientInfo.CustomerId,
					IsDataIsolationEnabled =
						item.AdditionalProperties.IsNotNullOrEmpty() &&
						item.AdditionalProperties.ContainsKey("IsDataIsolationEnabled") &&
						bool.Parse(item.AdditionalProperties["IsDataIsolationEnabled"]),
					IsSystemOperationsRestricted =
						item.AdditionalProperties.IsNotNullOrEmpty() &&
						item.AdditionalProperties.ContainsKey("IsSystemOperationsRestricted") &&
						bool.Parse(item.AdditionalProperties["IsSystemOperationsRestricted"])
				})).ToList();
			return accessList;
		}

		/// <summary>
		/// Request access token.
		/// </summary>
		/// <param name="accessId">The access id.</param>
		/// <returns></returns>
		public string GetAccessToken(string accessId) {
			return IdentityServiceWrapper.GetAccessToken(accessId);
		}

		/// <summary>Deactivates the specified access list.</summary>
		/// <param name="accessIds">The access ids.</param>
		/// <returns>Affected access count.</returns>
		public int Deactivate(string[] accessIds) {
			return IdentityServiceWrapper.RemoveResource(accessIds);
		}

		/// <summary>Searches clients by customer ids or client id.</summary>
		/// <param name="clientsFilter">Filter info (customerIds, clientId, etc.) to search clients.</param>
		public IList<ShortIdentityClientInfo> Search(FindIdentityClientsFilter clientsFilter) {
			if (clientsFilter.CustomerIds.IsNullOrEmpty() && clientsFilter.ClientId.IsNullOrEmpty()) {
				throw new ArgumentNullOrEmptyException($"{nameof(clientsFilter.CustomerIds)} or " +
					$"{nameof(clientsFilter.ClientId)}");
			}
			var findClientsDto = new OAuthIntegration.DTO.FindIdentityClientsFilter {
				ClientId = clientsFilter.ClientId,
				CustomerIds = clientsFilter.CustomerIds
			};
			return IdentityServiceWrapper.FindClients(findClientsDto).Select(clientInfo =>
				new ShortIdentityClientInfo {
					ClientId = clientInfo.ClientId,
					ClientName = clientInfo.ClientName,
					Description = clientInfo.Description,
					CustomerId = clientInfo.CustomerId
				}).ToList();
		}

		#endregion

	}

	#endregion

}
