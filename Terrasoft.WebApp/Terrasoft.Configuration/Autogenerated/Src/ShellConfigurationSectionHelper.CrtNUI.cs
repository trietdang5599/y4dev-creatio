namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Configuration.WorkplaceSectionAccess;
	using Terrasoft.Core;
	using Terrasoft.Web.Http.Abstractions;

	#region Class: ShellConfigurationSectionHelper

	public class ShellConfigurationSectionHelper : ConfigurationSectionHelper
	{

		#region Constructors: Public

		public ShellConfigurationSectionHelper(UserConnection userConnection)
			: base(userConnection) {
		}

		public ShellConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor)
			: base(userConnection, httpContextAccessor) {
		}

		public ShellConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
			IClientUnitSchemaDecorator clientUnitSchemaDecorator)
			: base(userConnection, httpContextAccessor, clientUnitSchemaDecorator) {
		}

		public ShellConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
			IClientUnitSchemaDecorator clientUnitSchemaDecorator,
			IConfigurationDataRelatedPagesApplier configurationDataRelatedPagesApplier)
			: base(userConnection, httpContextAccessor, clientUnitSchemaDecorator,
				configurationDataRelatedPagesApplier) {
		}

		public ShellConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
			IClientUnitSchemaDecorator clientUnitSchemaDecorator,
			IConfigurationDataRelatedPagesApplier configurationDataRelatedPagesApplier,
			IBaseWorkplaceSectionAccessManager workplaceSectionAccessManager)
			: base(userConnection, httpContextAccessor, clientUnitSchemaDecorator, configurationDataRelatedPagesApplier,
				workplaceSectionAccessManager) {
		}

		#endregion

		#region Properties: Protected

		protected override bool UseShellConfigurationScript => true;

		#endregion

		#region Methods: Protected

		protected override Dictionary<Guid, EntityStructure> GetEntitiesStructure(UserConnection userConnection) {
			return new Dictionary<Guid, EntityStructure>();
		}

		protected override Dictionary<string, ModuleStructure> GetModulesStructure(UserConnection userConnection) {
			return new Dictionary<string, ModuleStructure>();
		}

		#endregion

		#region Methods: Public

		public override string GetPreloadedFeatures(UserConnection userConnection) {
			return string.Empty;
		}

		#endregion

	}

	#endregion

}
