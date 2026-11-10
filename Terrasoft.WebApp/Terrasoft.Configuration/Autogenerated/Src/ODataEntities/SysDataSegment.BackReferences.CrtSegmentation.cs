namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysDataSegment

	/// <exclude/>
	public class SysDataSegment : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysDataSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDataSegment";
		}

		public SysDataSegment(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysDataSegment";
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
		/// Segment data table name.
		/// </summary>
		public string SegmentDataTableName {
			get {
				return GetTypedColumnValue<string>("SegmentDataTableName");
			}
			set {
				SetColumnValue("SegmentDataTableName", value);
			}
		}

		/// <summary>
		/// Exit filter data.
		/// </summary>
		public string ExitFilterData {
			get {
				return GetTypedColumnValue<string>("ExitFilterData");
			}
			set {
				SetColumnValue("ExitFilterData", value);
			}
		}

		/// <summary>
		/// Entry filter data.
		/// </summary>
		public string EntryFilterData {
			get {
				return GetTypedColumnValue<string>("EntryFilterData");
			}
			set {
				SetColumnValue("EntryFilterData", value);
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
		/// Current contacts.
		/// </summary>
		public int RecordCount {
			get {
				return GetTypedColumnValue<int>("RecordCount");
			}
			set {
				SetColumnValue("RecordCount", value);
			}
		}

		/// <summary>
		/// Last actualization duration (sec).
		/// </summary>
		public int LastActualizationDuration {
			get {
				return GetTypedColumnValue<int>("LastActualizationDuration");
			}
			set {
				SetColumnValue("LastActualizationDuration", value);
			}
		}

		/// <summary>
		/// Updated.
		/// </summary>
		public DateTime LastActualizationDate {
			get {
				return GetTypedColumnValue<DateTime>("LastActualizationDate");
			}
			set {
				SetColumnValue("LastActualizationDate", value);
			}
		}

		/// <summary>
		/// Last actualization error.
		/// </summary>
		public string LastActualizationError {
			get {
				return GetTypedColumnValue<string>("LastActualizationError");
			}
			set {
				SetColumnValue("LastActualizationError", value);
			}
		}

		/// <summary>
		/// Is usable while updating.
		/// </summary>
		public bool IsUsableWhileUpdating {
			get {
				return GetTypedColumnValue<bool>("IsUsableWhileUpdating");
			}
			set {
				SetColumnValue("IsUsableWhileUpdating", value);
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
		public Guid SysStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysStatusId");
			}
			set {
				SetColumnValue("SysStatusId", value);
				_sysStatus = null;
			}
		}

		/// <exclude/>
		public string SysStatusName {
			get {
				return GetTypedColumnValue<string>("SysStatusName");
			}
			set {
				SetColumnValue("SysStatusName", value);
				if (_sysStatus != null) {
					_sysStatus.Name = value;
				}
			}
		}

		private SysSegmentSystemStatus _sysStatus;
		/// <summary>
		/// Population status.
		/// </summary>
		public SysSegmentSystemStatus SysStatus {
			get {
				return _sysStatus ??
					(_sysStatus = new SysSegmentSystemStatus(LookupColumnEntities.GetEntity("SysStatus")));
			}
		}

		/// <exclude/>
		public Guid SysRefreshModeId {
			get {
				return GetTypedColumnValue<Guid>("SysRefreshModeId");
			}
			set {
				SetColumnValue("SysRefreshModeId", value);
				_sysRefreshMode = null;
			}
		}

		/// <exclude/>
		public string SysRefreshModeName {
			get {
				return GetTypedColumnValue<string>("SysRefreshModeName");
			}
			set {
				SetColumnValue("SysRefreshModeName", value);
				if (_sysRefreshMode != null) {
					_sysRefreshMode.Name = value;
				}
			}
		}

		private SysSegmentRefreshMode _sysRefreshMode;
		/// <summary>
		/// Population mode.
		/// </summary>
		public SysSegmentRefreshMode SysRefreshMode {
			get {
				return _sysRefreshMode ??
					(_sysRefreshMode = new SysSegmentRefreshMode(LookupColumnEntities.GetEntity("SysRefreshMode")));
			}
		}

		/// <exclude/>
		public Guid SysExitModeId {
			get {
				return GetTypedColumnValue<Guid>("SysExitModeId");
			}
			set {
				SetColumnValue("SysExitModeId", value);
				_sysExitMode = null;
			}
		}

		/// <exclude/>
		public string SysExitModeName {
			get {
				return GetTypedColumnValue<string>("SysExitModeName");
			}
			set {
				SetColumnValue("SysExitModeName", value);
				if (_sysExitMode != null) {
					_sysExitMode.Name = value;
				}
			}
		}

		private SysSegmentExitMode _sysExitMode;
		/// <summary>
		/// Exit strategy.
		/// </summary>
		public SysSegmentExitMode SysExitMode {
			get {
				return _sysExitMode ??
					(_sysExitMode = new SysSegmentExitMode(LookupColumnEntities.GetEntity("SysExitMode")));
			}
		}

		/// <exclude/>
		public Guid EntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaId");
			}
			set {
				SetColumnValue("EntitySchemaId", value);
				_entitySchema = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaTitle {
			get {
				return GetTypedColumnValue<string>("EntitySchemaTitle");
			}
			set {
				SetColumnValue("EntitySchemaTitle", value);
				if (_entitySchema != null) {
					_entitySchema.Title = value;
				}
			}
		}

		private VwEntityObjects _entitySchema;
		/// <summary>
		/// Segment of.
		/// </summary>
		public VwEntityObjects EntitySchema {
			get {
				return _entitySchema ??
					(_entitySchema = new VwEntityObjects(LookupColumnEntities.GetEntity("EntitySchema")));
			}
		}

		/// <exclude/>
		public Guid SysUserStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysUserStatusId");
			}
			set {
				SetColumnValue("SysUserStatusId", value);
				_sysUserStatus = null;
			}
		}

		/// <exclude/>
		public string SysUserStatusName {
			get {
				return GetTypedColumnValue<string>("SysUserStatusName");
			}
			set {
				SetColumnValue("SysUserStatusName", value);
				if (_sysUserStatus != null) {
					_sysUserStatus.Name = value;
				}
			}
		}

		private SysSegmentUserStatus _sysUserStatus;
		/// <summary>
		/// Segment status.
		/// </summary>
		public SysSegmentUserStatus SysUserStatus {
			get {
				return _sysUserStatus ??
					(_sysUserStatus = new SysSegmentUserStatus(LookupColumnEntities.GetEntity("SysUserStatus")));
			}
		}

		#endregion

	}

	#endregion

}

