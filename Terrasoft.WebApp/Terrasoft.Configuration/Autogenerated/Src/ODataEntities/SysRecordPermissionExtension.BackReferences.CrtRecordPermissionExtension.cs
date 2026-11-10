namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysRecordPermissionExtension

	/// <exclude/>
	public class SysRecordPermissionExtension : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysRecordPermissionExtension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRecordPermissionExtension";
		}

		public SysRecordPermissionExtension(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysRecordPermissionExtension";
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
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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

		/// <summary>
		/// Schema names.
		/// </summary>
		public string SchemaNames {
			get {
				return GetTypedColumnValue<string>("SchemaNames");
			}
			set {
				SetColumnValue("SchemaNames", value);
			}
		}

		/// <summary>
		/// Is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Extension name.
		/// </summary>
		public string ExtensionName {
			get {
				return GetTypedColumnValue<string>("ExtensionName");
			}
			set {
				SetColumnValue("ExtensionName", value);
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

		/// <exclude/>
		public Guid ExtensionCombinationModeId {
			get {
				return GetTypedColumnValue<Guid>("ExtensionCombinationModeId");
			}
			set {
				SetColumnValue("ExtensionCombinationModeId", value);
				_extensionCombinationMode = null;
			}
		}

		/// <exclude/>
		public string ExtensionCombinationModeName {
			get {
				return GetTypedColumnValue<string>("ExtensionCombinationModeName");
			}
			set {
				SetColumnValue("ExtensionCombinationModeName", value);
				if (_extensionCombinationMode != null) {
					_extensionCombinationMode.Name = value;
				}
			}
		}

		private SysExtensionCombinationMode _extensionCombinationMode;
		/// <summary>
		/// Extension combination mode.
		/// </summary>
		public SysExtensionCombinationMode ExtensionCombinationMode {
			get {
				return _extensionCombinationMode ??
					(_extensionCombinationMode = new SysExtensionCombinationMode(LookupColumnEntities.GetEntity("ExtensionCombinationMode")));
			}
		}

		/// <exclude/>
		public Guid RecordPermissionOperationTypeId {
			get {
				return GetTypedColumnValue<Guid>("RecordPermissionOperationTypeId");
			}
			set {
				SetColumnValue("RecordPermissionOperationTypeId", value);
				_recordPermissionOperationType = null;
			}
		}

		/// <exclude/>
		public string RecordPermissionOperationTypeName {
			get {
				return GetTypedColumnValue<string>("RecordPermissionOperationTypeName");
			}
			set {
				SetColumnValue("RecordPermissionOperationTypeName", value);
				if (_recordPermissionOperationType != null) {
					_recordPermissionOperationType.Name = value;
				}
			}
		}

		private EntitySchemaRecRightOperation _recordPermissionOperationType;
		/// <summary>
		/// Record permission operation type.
		/// </summary>
		public EntitySchemaRecRightOperation RecordPermissionOperationType {
			get {
				return _recordPermissionOperationType ??
					(_recordPermissionOperationType = new EntitySchemaRecRightOperation(LookupColumnEntities.GetEntity("RecordPermissionOperationType")));
			}
		}

		#endregion

	}

	#endregion

}

