namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ITagRightsHelper

	/// <summary>
	/// Class helper for tag rights.
	/// </summary>
	public interface ITagRightsHelper
	{

		#region Methods: Public

		/// <summary>
		/// Check if user has access grantee for tagging operation.
		/// </summary>
		/// <param name="tagId">Tag id.</param>
		/// <param name="sysAdminUserId">Sys admin user id.</param>
		/// <returns>.</returns>
		bool CanTag(Guid tagId, Guid sysAdminUserId);

		/// <summary>
		/// Check if user has access grantee for create tag operation.
		/// </summary>
		/// <param name="tagAccessId">Tag access id.</param>
		/// <param name="sysAdminUserId">Sys admin user id.</param>
		/// <returns>.</returns>
		bool CanCreate(Guid tagAccessId, Guid sysAdminUserId);

		/// <summary>
		/// Return user`s tagging TagAccess list ids.
		/// </summary>
		/// <param name="sysAdminUserId">Sys admin user id.</param>
		/// <returns>List of tagging TagAccess ids</returns>
		List<Guid> GetTaggingTagAccessesForUser(Guid sysAdminUserId);

		#endregion

	}

	#endregion

	#region Class: TagRightsHelper

	/// <summary>
	/// Class helper for tag rights.
	/// </summary>
	[DefaultBinding(typeof(ITagRightsHelper), Name = nameof(TagRightsHelper))]
	public class TagRightsHelper : ITagRightsHelper
	{

		#region Consts: Private

		private readonly string CanTagColumnName = "CanTag";
		private readonly string CanCreateColumnName = "CanCreate";

		#endregion

		#region Properties: Public

		public UserConnection UserConnection { get; set; }

		#endregion

		#region Constructor: Public

		public TagRightsHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool IsUserHasOperationGrantee(Guid tagId, Guid tagAccessId, Guid sysAdminUnitId,
			string tagAccessGranteeColumnName) {
			var tagAccessGranteeCollection = GetTagAccessGranteeByTag(tagId, tagAccessId, tagAccessGranteeColumnName);
			if (!tagAccessGranteeCollection.Any()) {
				return true;
			}
			var rolesIds = tagAccessGranteeCollection
				.Where((grantee) => grantee.GetTypedColumnValue<bool>(tagAccessGranteeColumnName))
				.Select((grantee) => grantee.GetTypedColumnValue<object>("SysAdminUnitId")).ToList();
			rolesIds.AddIfNotExists(BaseConsts.SystemAdministratorsSysAdminUnitId);
			return IsUserInSysUserInRoles(rolesIds, sysAdminUnitId);
		}

		private EntityCollection GetTagAccessGranteeByTag(Guid tagId, Guid tagAccessId,
			string tagAccessGranteeColumnName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TagAccessGrantee");
			esq.UseAdminRights = false;
			esq.AddColumn("SysAdminUnit");
			esq.AddColumn(tagAccessGranteeColumnName);
			if (tagAccessId.Equals(Guid.Empty)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"[Tag:TagAccess:TagAccess].Id", tagId));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "TagAccess", tagAccessId));
			}
			return esq.GetEntityCollection(UserConnection);
		}

		private bool IsUserInSysUserInRoles(List<object> rolesIds, Guid sysAdminUnitId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			esq.UseAdminRights = false;
			esq.RowCount = 1;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysRole", rolesIds));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", sysAdminUnitId));
			EntityCollection result = esq.GetEntityCollection(UserConnection);
			return result.Any();
		}

		private bool IsUserInSysUserInRole(Guid rolesId, Guid sysAdminUnitId) {
			return IsUserInSysUserInRoles(new List<object>() {
				rolesId
			}, sysAdminUnitId);
		}

		private bool IsSystemAdministratorsUser(Guid sysAdminUnitId) {
			return IsUserInSysUserInRole(BaseConsts.SystemAdministratorsSysAdminUnitId, sysAdminUnitId);
		}

		private List<Entity> GetTagAccessesForUser(Guid sysAdminUserId, string tagAccessGranteeColumnName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TagAccessGrantee");
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("TagAccess");
			esq.AddColumn("SysAdminUnit");
			esq.AddColumn(tagAccessGranteeColumnName);
			if (IsSystemAdministratorsUser(sysAdminUserId)) {
				return esq.GetEntityCollection(UserConnection).Distinct().ToList();
			}
			return esq.GetEntityCollection(UserConnection)
				.Where(e => e.GetTypedColumnValue<bool>(tagAccessGranteeColumnName))
				.Where(e => IsUserInSysUserInRole(e.GetTypedColumnValue<Guid>("SysAdminUnitId"), sysAdminUserId))
				.Distinct()
				.ToList();
		}

		#endregion

		#region Public: Methods

		/// <inheritdoc/>
		public bool CanCreate(Guid tagAccessId, Guid sysAdminUserId) {
			return IsUserHasOperationGrantee(Guid.Empty, tagAccessId, sysAdminUserId, CanCreateColumnName);
		}

		/// <inheritdoc/>
		public bool CanTag(Guid tagId, Guid sysAdminUserId) {
			return IsUserHasOperationGrantee(tagId, Guid.Empty, sysAdminUserId, CanTagColumnName);
		}

		/// <inheritdoc/>
		public List<Guid> GetTaggingTagAccessesForUser(Guid sysAdminUserId) {
			return GetTagAccessesForUser(sysAdminUserId, CanTagColumnName)
				.Select(e => (Guid)e.GetColumnValue("TagAccessId")).ToList();
		}

		#endregion

	}

	#endregion

}

