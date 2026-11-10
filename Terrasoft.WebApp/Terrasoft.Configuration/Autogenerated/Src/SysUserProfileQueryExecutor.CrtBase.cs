 namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: SysUserProfileQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SysUserProfileQueryExecutor")]
	public class SysUserProfileQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public SysUserProfileQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns user profile.
		/// </summary>
		/// <param name="filters">Filters.</param>
		/// <returns>SysUserProfile sections.</returns>
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var entityResolver = ClassFactory.Get<CurrentSysUserProfileResolver>(new ConstructorArgument(
				"userConnection", _userConnection));
			Entity userProfileEntity = entityResolver.GetCurrentUserProfile();
			var collection = new EntityCollection(_userConnection, entityResolver.EntitySchema);
			if (userProfileEntity != null) {
				collection.Add(userProfileEntity);
			}
			return collection;
		}

		#endregion

	}

	#endregion

}

