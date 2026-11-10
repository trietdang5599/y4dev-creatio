namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Applications.Abstractions.Content;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages.Exceptions;
	using Terrasoft.Core.ServiceModelContract.Designers;

	#region Class: ApplicationSectionEventListener

	/// <summary>
	/// Listener for 'ApplicationSection' entity events.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "ApplicationSection")]
	public class ApplicationSectionEventListener : BaseEntityEventListener
	{

		#region Class: AppSectionCreationPackageDependencyExceptionData

		[DataContract]
		public class AppSectionCreationPackageDependencyExceptionData
		{
			#region Properties: Public

			[DataMember(Name = "errorMessage")]
			public string ErrorMessage { get; set; }

			[DataMember(Name = "errors")]
			public ICollection<ValidationErrorResponse> Errors { get; set; }

			#endregion
		}

		#endregion

		#region Fields: Private

		private readonly IEnumerable<string> _imageSchemaNames = new[] { "SysImage", "SysAppIcons" };
		private IAppSectionManager _appSectionManager;

		#endregion

		#region Properties: Protected

		protected IAppSectionManager AppSectionManager => _appSectionManager ?? (_appSectionManager = ClassFactory.Get<IAppSectionManager>());

		#endregion

		#region Methods: Private

		private string GetImageData(UserConnection userConnection, Guid logoId) {
			if (logoId.Equals(Guid.Empty)) {
				return string.Empty;
			}
			byte[] dataBytes = GetDataFromImageEntity(userConnection, logoId);
			return dataBytes?.Length > 0 ? Convert.ToBase64String(dataBytes) : string.Empty;
		}

		private byte[] GetDataFromImageEntity(UserConnection userConnection, Guid Id) {
			Entity image = GetImageEntity(userConnection, Id);
			return GetDataFromEntity(image);
		}

		private Entity GetImageEntity(UserConnection userConnection, Guid id) {
			foreach (string schemaName in _imageSchemaNames) {
				Entity imageEntityBySchema = GetImageEntityBySchema(userConnection, schemaName, id);
				if (imageEntityBySchema != null) {
					return imageEntityBySchema;
				}
			}
			return null;
		}

		private Entity GetImageEntityBySchema(UserConnection userConnection, string schemaName, Guid id) {
			EntitySchemaQuery esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
			esq.AddColumn("Data");
			return esq.GetEntity(userConnection, id);
		}

		private byte[] GetDataFromEntity(Entity image) {
			return image != null ? image.GetBytesValue("Data") : null;
		}

		private bool IsApplicationSectionExists(Entity section) {
			UserConnection userConnection = section.UserConnection;
			Guid sectionId = section.GetTypedColumnValue<Guid>("Id");
			EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByName("SysModule");
			Entity entity = schema.CreateEntity(userConnection);
			return entity.ExistInDB(sectionId);
		}

		private AppSectionInfo GetAppSectionInfo(Entity applicationSection) {
			var logoId = applicationSection.GetTypedColumnValue<Guid>("LogoId");
			string logoData = GetImageData(applicationSection.UserConnection, logoId);
			string entitySchemaName = applicationSection.GetIsColumnValueLoaded("EntitySchemaName")
				? applicationSection.GetTypedColumnValue<string>("EntitySchemaName")
				: null;
			var type = applicationSection.GetTypedColumnValue<SectionType>("Type");
			return new AppSectionInfo {
				ApplicationId = applicationSection.GetTypedColumnValue<Guid>("ApplicationId"),
				Caption = applicationSection.FindEntityColumnValue("Caption")?.LocalizableValue,
				Code = applicationSection.GetTypedColumnValue<string>("Code"),
				Description = applicationSection.GetTypedColumnValue<string>("Description"),
				Icon = logoData,
				EntitySchemaName = entitySchemaName,
				IconBackground = applicationSection.GetTypedColumnValue<string>("IconBackground"),
				Type = type,
				ClientTypeId = applicationSection.GetTypedColumnValue<Guid>("ClientTypeId")
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles on saving entity event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event arguments.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var applicationSection = (Entity)sender;
			AppSectionInfo sectionInfo = GetAppSectionInfo(applicationSection);
			try {
				if (IsApplicationSectionExists(applicationSection)) {
					sectionInfo.Id = applicationSection.GetTypedColumnValue<Guid>("Id");
					AppSectionManager.Update(sectionInfo);
					return;
				}
				AppSectionManager.Create(sectionInfo);
			} catch (AutoAddPackageDependenciesValidateException exception) {
				ICollection<ValidationErrorResponse> mappedErrors = exception.DependenciesError.Select(x =>
					new ValidationErrorResponse {
						Package = x.PackageName,
						Reference = x.Reference,
						Source = x.Source
					}).ToList();
				var exceptionData = new AppSectionCreationPackageDependencyExceptionData {
					Errors = mappedErrors,
					ErrorMessage = new LocalizableString("Terrasoft.Core.ServiceModel",
						"EntitySchemaDesignerService.Errors.ValidationDependencyErrorMessage")
				};
				throw new AppSectionCreationPackageDependencyException(Json.Serialize(exceptionData, true));
			}
		}

		#endregion

	}

	#endregion

}

