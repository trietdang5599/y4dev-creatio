namespace Terrasoft.Configuration.Url {

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Section;
	using Terrasoft.Configuration.Workplace;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using WorkplaceApi;

	#region Class: OpenLinkUrlGenerator

	[DefaultBinding(typeof(IOpenLinkUrlGenerator), Name = nameof(OpenLinkUrlGenerator))]
	public class OpenLinkUrlGenerator : IOpenLinkUrlGenerator
	{

		#region Fields: Private

		private readonly IUrlGenerator _urlGenerator;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public OpenLinkUrlGenerator(IUrlGenerator urlGenerator, UserConnection userConnection) {
			_urlGenerator = urlGenerator;
			_userConnection = userConnection;
		}

		#endregion

		private ClientUnitSchema FindClientUnitSchema(string schemaName) {
			ClientUnitSchemaManager clientUnitSchemaManager = _userConnection.ClientUnitSchemaManager;
			ClientUnitSchema clientUnitSchema = clientUnitSchemaManager.FindInstanceByName(schemaName);
			return clientUnitSchema;
		}

		private bool TryGetSchemaType(string schemaName, out string type) {
			ClientUnitSchema clientUnitSchema = FindClientUnitSchema(schemaName);
			if (clientUnitSchema == null) {
				type = string.Empty;
				return false;
			}
			type = clientUnitSchema.SchemaType == ClientUnitSchemaType.Module ? "module" : "schema";
			return true;
		}

		private bool GetIsSchemaNameExistsInWorkplaceStructure(string schemaName) {
			var workplaceManager = ClassFactory.Get<IWorkplaceManager>(new ConstructorArgument("uc", _userConnection));
			return workplaceManager.GetIsSchemaNameExistsInWorkplaceStructure(schemaName);
		}

		#region Methods: Public

		/// <summary>
		/// <inheritdoc cref="IOpenLinkUrlGenerator.GetUrl"/>
		/// </summary>
		public string GetUrl(OpenUrlConfig config) {
			config.CheckArgumentNull(nameof(config));
			string schemaName = config.SchemaName;
			schemaName.CheckArgumentNullOrEmpty(nameof(schemaName));
			Guid recordId = config.RecordId;
			if (config.RecordId.IsNotEmpty()) {
				return _urlGenerator.GetUrl(schemaName, recordId);
			}
			string defaultUrl = _urlGenerator.GetDefaultUrl();
			if (!GetIsSchemaNameExistsInWorkplaceStructure(schemaName) || !TryGetSchemaType(schemaName,
					out string type)) {
				return defaultUrl;
			}
			return $"{defaultUrl}#CrtNavigation/{schemaName}/?type={type}";
		}

		#endregion

	}

	#endregion

}
