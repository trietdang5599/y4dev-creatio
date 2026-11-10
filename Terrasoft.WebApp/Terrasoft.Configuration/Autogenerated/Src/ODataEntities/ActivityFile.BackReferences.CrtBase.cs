namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: ActivityFile

	/// <exclude/>
	public class ActivityFile : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActivityFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityFile";
		}

		public ActivityFile(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActivityFile";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid LockedById {
			get {
				return GetTypedColumnValue<Guid>("LockedById");
			}
			set {
				SetColumnValue("LockedById", value);
				_lockedBy = null;
			}
		}

		/// <exclude/>
		public string LockedByName {
			get {
				return GetTypedColumnValue<string>("LockedByName");
			}
			set {
				SetColumnValue("LockedByName", value);
				if (_lockedBy != null) {
					_lockedBy.Name = value;
				}
			}
		}

		private Contact _lockedBy;
		/// <summary>
		/// Locked by.
		/// </summary>
		public Contact LockedBy {
			get {
				return _lockedBy ??
					(_lockedBy = new Contact(LookupColumnEntities.GetEntity("LockedBy")));
			}
		}

		/// <summary>
		/// Locked on.
		/// </summary>
		public DateTime LockedOn {
			get {
				return GetTypedColumnValue<DateTime>("LockedOn");
			}
			set {
				SetColumnValue("LockedOn", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private FileType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public FileType Type {
			get {
				return _type ??
					(_type = new FileType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// File size.
		/// </summary>
		public int Size {
			get {
				return GetTypedColumnValue<int>("Size");
			}
			set {
				SetColumnValue("Size", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
			}
		}

		/// <summary>
		/// Created in InvisibleCRM.
		/// </summary>
		public bool CreatedByInvCRM {
			get {
				return GetTypedColumnValue<bool>("CreatedByInvCRM");
			}
			set {
				SetColumnValue("CreatedByInvCRM", value);
			}
		}

		/// <summary>
		/// Loaded.
		/// </summary>
		public bool Uploaded {
			get {
				return GetTypedColumnValue<bool>("Uploaded");
			}
			set {
				SetColumnValue("Uploaded", value);
			}
		}

		/// <summary>
		/// Loading error.
		/// </summary>
		public string ErrorOnUpload {
			get {
				return GetTypedColumnValue<string>("ErrorOnUpload");
			}
			set {
				SetColumnValue("ErrorOnUpload", value);
			}
		}

		/// <summary>
		/// ExternalStorageProperties.
		/// </summary>
		public string ExternalStorageProperties {
			get {
				return GetTypedColumnValue<string>("ExternalStorageProperties");
			}
			set {
				SetColumnValue("ExternalStorageProperties", value);
			}
		}

		/// <summary>
		/// Inline file.
		/// </summary>
		public bool Inline {
			get {
				return GetTypedColumnValue<bool>("Inline");
			}
			set {
				SetColumnValue("Inline", value);
			}
		}

		/// <exclude/>
		public Guid SysFileStorageId {
			get {
				return GetTypedColumnValue<Guid>("SysFileStorageId");
			}
			set {
				SetColumnValue("SysFileStorageId", value);
				_sysFileStorage = null;
			}
		}

		/// <exclude/>
		public string SysFileStorageName {
			get {
				return GetTypedColumnValue<string>("SysFileStorageName");
			}
			set {
				SetColumnValue("SysFileStorageName", value);
				if (_sysFileStorage != null) {
					_sysFileStorage.Name = value;
				}
			}
		}

		private SysFileContentStorage _sysFileStorage;
		/// <summary>
		/// File storage.
		/// </summary>
		public SysFileContentStorage SysFileStorage {
			get {
				return _sysFileStorage ??
					(_sysFileStorage = new SysFileContentStorage(LookupColumnEntities.GetEntity("SysFileStorage")));
			}
		}

		/// <exclude/>
		public Guid FileGroupId {
			get {
				return GetTypedColumnValue<Guid>("FileGroupId");
			}
			set {
				SetColumnValue("FileGroupId", value);
				_fileGroup = null;
			}
		}

		/// <exclude/>
		public string FileGroupName {
			get {
				return GetTypedColumnValue<string>("FileGroupName");
			}
			set {
				SetColumnValue("FileGroupName", value);
				if (_fileGroup != null) {
					_fileGroup.Name = value;
				}
			}
		}

		private FileGroup _fileGroup;
		/// <summary>
		/// FileGroup.
		/// </summary>
		public FileGroup FileGroup {
			get {
				return _fileGroup ??
					(_fileGroup = new FileGroup(LookupColumnEntities.GetEntity("FileGroup")));
			}
		}

		/// <summary>
		/// Tag.
		/// </summary>
		public string Tag {
			get {
				return GetTypedColumnValue<string>("Tag");
			}
			set {
				SetColumnValue("Tag", value);
			}
		}

		/// <summary>
		/// Total file size.
		/// </summary>
		public int TotalSize {
			get {
				return GetTypedColumnValue<int>("TotalSize");
			}
			set {
				SetColumnValue("TotalSize", value);
			}
		}

		#endregion

	}

	#endregion

}

