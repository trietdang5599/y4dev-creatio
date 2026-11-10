namespace Terrasoft.Configuration.OpenIdAuth
{
	using System;
	using Terrasoft.Core;
	
	#region Interface: IOpenIdRoleChangeValidator

	public interface IOpenIdRoleChangeValidator
	{
		bool CanChangeUserInRole(UserConnection userConnection, Guid userId, Guid roleId);
	}
	
	#endregion
	
}
