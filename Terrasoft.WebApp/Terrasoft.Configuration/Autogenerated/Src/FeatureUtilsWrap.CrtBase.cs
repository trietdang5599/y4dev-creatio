namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: FeatureUtilsWrap

	[DefaultBinding(typeof(IFeatureUtilities))]
	public class FeatureUtilsWrap : IFeatureUtilities
	{

		#region Methods: Public

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabled(UserConnection, string)"/>
		public bool GetIsFeatureEnabled(UserConnection uc, string code) {
			return uc.GetIsFeatureEnabled(code);
		}

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabled(UserConnection, string, Guid)"/>
		public bool GetIsFeatureEnabled(UserConnection uc, string code, Guid sysAdminUnitId) {
			return uc.GetIsFeatureEnabled(code, sysAdminUnitId);
		}

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabledForAnyUser(UserConnection, string)"/>
		public bool GetIsFeatureEnabledForAnyUser(UserConnection uc, string code) {
			return uc.GetIsFeatureEnabledForAnyUser(code);
		}

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabledForAll(UserConnection, string)"/>
		public bool GetIsFeatureEnabledForAll(UserConnection uc, string code) {
			return uc.GetIsFeatureEnabledForAllUsers(code);
		}

		#endregion

	}

	#endregion

}
