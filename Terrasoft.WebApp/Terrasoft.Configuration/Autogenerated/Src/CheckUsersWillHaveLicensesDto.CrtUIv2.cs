namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Enum: ChangeRoleOperationType

	public enum ChangeRoleOperationType
	{
		AddRolesToUser = 0,
		DeleteRoleFromUser = 1,
		AddFuncRoleToOrgRole = 2,
		DeleteFuncRoleFromOrgRole = 3
	}

	#endregion

	#region Class: CheckUsersWillHaveLicensesDto

	[DataContract]
	public class CheckUsersWillHaveLicensesDto
	{

		#region Properties: Public

		[DataMember(Name = "orgRoles")]
		public List<string> OrgRoles { get; set; }

		[DataMember(Name = "funcRoles")]
		public List<string> FuncRoles { get; set; }

		[DataMember(Name = "changeRoleOperationType")]
		public ChangeRoleOperationType ChangeRoleOperationType { get; set; }

		[DataMember(Name = "users")]
		public List<string> Users { get; set; }

		#endregion

	}

	#endregion

}
