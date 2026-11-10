namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.OrgStructure;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Class: ExternalApplicationHubProvider

	/// <summary>
	/// Provides information about ALM application hub.
	/// Implements <see cref="IExternalApplicationHubProvider"/> interface.
	/// </summary>
	[DefaultBinding(typeof(IExternalApplicationHubProvider))]
	public class AlmApplicationHubProvider : IExternalApplicationHubProvider
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private IOrgStructureManager _orgStructureManager;
		private IOrgStructureManager OrgStructureManager => _orgStructureManager
			?? (_orgStructureManager = new OrgStructureManager(_userConnection.AppConnection.SystemUserConnection));

		#endregion

		#region Constructors: Public

		public AlmApplicationHubProvider(UserConnection userConnection, IOrgStructureManager orgStructureManager = null) {
			_userConnection = userConnection;
			_orgStructureManager = orgStructureManager;
		}

		#endregion

		#region Methods: Private

		private HashSet<Guid> GetAlmFunctionalRoles() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysAlmRole") {
				UseAdminRights = false,
				PrimaryQueryColumn = {
					IsAlwaysSelect = true
				},
				IsDistinct = true
			};
			string roleColumnName = esq.AddColumn("Role.Id").Name;
			return new HashSet<Guid>(esq.GetEntityCollection(_userConnection)
				.Select(entity => entity.GetTypedColumnValue<Guid>(roleColumnName)));
		}

		private string GetAlmPortalEnvironmentManagementUrl() {
			return SystemSettings.GetValue(_userConnection, "AlmPortalEnvironmentManagementUrl", string.Empty);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the URL of the ALM application hub.
		/// </summary>
		/// <returns>The URL of the ALM application hub if the user has ALM roles;
		/// otherwise, an empty string.</returns>
		public string GetUrl() {
			HashSet<Guid> almFunctionalRoles = GetAlmFunctionalRoles();
			Guid userId = _userConnection.CurrentUser.Id;
			bool isAlmUser = almFunctionalRoles.Any(roleId => OrgStructureManager.GetUserHasOrgStructureRole(userId, roleId));
			return isAlmUser ? GetAlmPortalEnvironmentManagementUrl() : string.Empty;
		}

		#endregion

	}

	#endregion

}
