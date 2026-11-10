namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.AsyncOperations;

	#region Class: ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs

	/// <summary>
	/// Additional arguments for ActualizeSysAdminUnitInRole async operation.
	/// </summary>
	public class ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs : EntityEventAsyncOperationArgs
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of the SysAdminUnit user to actualize roles for.
		/// </summary>
		public Guid UserId { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs"/>
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="eventArgs">Info about argument events.</param>
		public ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs(Entity entity, EventArgs eventArgs) : base(entity, eventArgs) {
		}

		#endregion

	}

	#endregion

}

