namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Feature;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;

	#region Class: File_CrtBaseEventsProcess

	public partial class File_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Fields: private

		private IFile _fileToDelete;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Gets a value indicating whether the Entity File API feature is enabled.
		/// </summary>
		private bool UseEntityFileApi => Features.GetIsEnabled("UseEntityFileApi");

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag, indicates that file api should not be notified when record is deleting. For internal usage only.
		/// </summary>
		public bool SkipDeletingFileUsingFileApi { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Invokes when file is deleting.
		/// </summary>
		protected virtual void OnFileDeleting() {
			if (UseEntityFileApi || !GlobalAppSettings.FeatureUseFileApi || SkipDeletingFileUsingFileApi) {
				return;
			}
			var fileLocator = new EntityFileLocator(Entity.Schema.Name, Entity.PrimaryColumnValue);
			IFileFactory fileFactory = UserConnection.GetFileFactory();
			var options = new FileOptions {
				UseRights = false,
				RemoveMetadataOnDelete = false
			};
			options.Context.Add($"Entity_{fileLocator.EntitySchemaName}_{fileLocator.RecordId}", Entity);
			IFile file = fileFactory.Get(fileLocator, options);
			if (file.Exists) {
				_fileToDelete = file;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Invokes when file is saving.
		/// </summary>
		public virtual void OnFileSaving() {
			Nullable<int> version = Entity.GetTypedOldColumnValue<int>("Version") as Nullable<int>;
			version = (version == null) ? 1 : version;
			var increaseVersion = false;
			var changedColumnValues = Entity.GetChangedColumnValues();
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			EntityColumnValue dataColumnValue = changedColumnValues.FirstOrDefault(col => col.Name == "Data");

			// TODO #RND-15156, #RND-15155: Revert changes when both tasks are completed.
			if (dataColumnValue != null) {
				if (Entity.GetColumnValue("Data") is byte[] data) {
					Entity.SetColumnValue("Size", data.Length);
				}
			}
			if (fileType == Terrasoft.WebApp.FileConsts.FileTypeUId) {
				if (dataColumnValue != null) {
					increaseVersion = true;
				}
			} else {
				var nameOldValue = Entity.GetTypedOldColumnValue<string>("Name");
				var nameNewValue = Entity.GetTypedColumnValue<string>("Name");
				if (nameNewValue != nameOldValue) {
					increaseVersion = true;
				}
			}
			if (increaseVersion) {
				Entity.SetColumnValue("Version", version + 1);
			} else {
				Entity.SetColumnValue("Version", version);
			}
		}

		/// <summary>
		/// Invokes when file is saved.
		/// </summary>
		public virtual void OnFileSaved() {
		}

		/// <summary>
		/// Invokes when file is deleted.
		/// </summary>
		public virtual void OnFileDeleted() {
			if (UseEntityFileApi) {
				return;
			}
			_fileToDelete?.Delete();
		}

		/// <summary>
		/// Invokes when file is updated.
		/// </summary>
		public virtual void OnFileUpdated() {
		}

		#endregion

	}

	#endregion

}
