namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysLookup

	/// <exclude/>
	public class SysLookup : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookup";
		}

		public SysLookup(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLookup";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ContentBuilderCustomerFont> ContentBuilderCustomerFontCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<ContentBuilderFontSet> ContentBuilderFontSetCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<DeduplicateOperation> DeduplicateOperationCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<FileSecurityExcludedUri> FileSecurityExcludedUriCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<FileSecurityMode> FileSecurityModeCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<Lookup> LookupCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<RuleRelationSections> RuleRelationSectionsCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<SysLookupColumn> SysLookupColumnCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<SysLookupSearchColumn> SysLookupSearchColumnCollectionBySysLookup {
			get;
			set;
		}

		public IEnumerable<VwSysLookupInFolder> VwSysLookupInFolderCollectionByVwSysLookup {
			get;
			set;
		}

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
		/// System.
		/// </summary>
		/// <remarks>
		/// Important system lookup used in business processes. Changes are prohibited.
		/// </remarks>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Simple.
		/// </summary>
		/// <remarks>
		/// Simple lookup with small number of records. Cached.
		/// </remarks>
		public bool IsSimple {
			get {
				return GetTypedColumnValue<bool>("IsSimple");
			}
			set {
				SetColumnValue("IsSimple", value);
			}
		}

		/// <summary>
		/// Unique identifier of edit page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of list page.
		/// </summary>
		public Guid SysGridPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageSchemaUId");
			}
			set {
				SetColumnValue("SysGridPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of object.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
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
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysLookupFolder _sysFolder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SysLookupFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = new SysLookupFolder(LookupColumnEntities.GetEntity("SysFolder")));
			}
		}

		#endregion

	}

	#endregion

}

