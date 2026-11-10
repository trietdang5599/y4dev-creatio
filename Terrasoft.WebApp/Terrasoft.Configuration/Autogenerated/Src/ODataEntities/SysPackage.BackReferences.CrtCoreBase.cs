namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysPackage

	/// <exclude/>
	public class SysPackage : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackage";
		}

		public SysPackage(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPackage";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysAppDependency> SysAppDependencyCollectionByDependOnPackage {
			get;
			set;
		}

		public IEnumerable<SysDataLocalizableValue> SysDataLocalizableValueCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysDataLocalizableValueChecksum> SysDataLocalizableValueChecksumCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysInstalledPackageData> SysInstalledPackageDataCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysLocalizableValue> SysLocalizableValueCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageDependency> SysPackageDependencyCollectionByDependOnPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageDependency> SysPackageDependencyCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageHierarchy> SysPackageHierarchyCollectionByBaseSysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageHierarchy> SysPackageHierarchyCollectionByDependOnPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageHierarchy> SysPackageHierarchyCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageHotfixInfo> SysPackageHotfixInfoCollectionByPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageInInstalledApp> SysPackageInInstalledAppCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageReferenceAssembly> SysPackageReferenceAssemblyCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageResourceChecksum> SysPackageResourceChecksumCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageSchemaData> SysPackageSchemaDataCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPackageSqlScript> SysPackageSqlScriptCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysPkgInstallScript> SysPkgInstallScriptCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<SysSchema> SysSchemaCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwProcessLib> VwProcessLibCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysClientUnitSchema> VwSysClientUnitSchemaCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysClientUnitSchemaInPackage> VwSysClientUnitSchemaInPackageCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysDcmLib> VwSysDcmLibCollectionByPackage {
			get;
			set;
		}

		public IEnumerable<VwSysEntitySchemaInPackage> VwSysEntitySchemaInPackageCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysEntitySchemaInWorkspace> VwSysEntitySchemaInWorkspaceCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysPageSchemaInWorkspace> VwSysPageSchemaInWorkspaceCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysProcess> VwSysProcessCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInfo> VwSysSchemaInfoCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInPackage> VwSysSchemaInPackageCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysSchemaInWorkspace> VwSysSchemaInWorkspaceCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwSysSqlScriptInPackage> VwSysSqlScriptInPackageCollectionBySysPackage {
			get;
			set;
		}

		public IEnumerable<VwWebServiceV2> VwWebServiceV2CollectionBySysPackage {
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
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public string Version {
			get {
				return GetTypedColumnValue<string>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Maintainer.
		/// </summary>
		public string Maintainer {
			get {
				return GetTypedColumnValue<string>("Maintainer");
			}
			set {
				SetColumnValue("Maintainer", value);
			}
		}

		/// <summary>
		/// Essentially.
		/// </summary>
		public bool Essential {
			get {
				return GetTypedColumnValue<bool>("Essential");
			}
			set {
				SetColumnValue("Essential", value);
			}
		}

		/// <summary>
		/// Annotation.
		/// </summary>
		public string Annotation {
			get {
				return GetTypedColumnValue<string>("Annotation");
			}
			set {
				SetColumnValue("Annotation", value);
			}
		}

		/// <summary>
		/// Package changed.
		/// </summary>
		public bool IsChanged {
			get {
				return GetTypedColumnValue<bool>("IsChanged");
			}
			set {
				SetColumnValue("IsChanged", value);
			}
		}

		/// <summary>
		/// Package locked.
		/// </summary>
		public bool IsLocked {
			get {
				return GetTypedColumnValue<bool>("IsLocked");
			}
			set {
				SetColumnValue("IsLocked", value);
			}
		}

		/// <summary>
		/// Installation type.
		/// </summary>
		public int? InstallType {
			get {
				return GetTypedColumnValue<int>("InstallType");
			}
			set {
				SetColumnValue("InstallType", value);
			}
		}

		/// <summary>
		/// Storage revision current number.
		/// </summary>
		public int RepositoryRevisionNumber {
			get {
				return GetTypedColumnValue<int>("RepositoryRevisionNumber");
			}
			set {
				SetColumnValue("RepositoryRevisionNumber", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		/// <remarks>
		/// 0 - General, 1 - Assembly.
		/// </remarks>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Path to project file.
		/// </summary>
		/// <remarks>
		/// Path relative to location of package descriptor.
		/// </remarks>
		public string ProjectPath {
			get {
				return GetTypedColumnValue<string>("ProjectPath");
			}
			set {
				SetColumnValue("ProjectPath", value);
			}
		}

		/// <summary>
		/// Install behavior.
		/// </summary>
		/// <remarks>
		/// Install behavior.
		/// </remarks>
		public int InstallBehavior {
			get {
				return GetTypedColumnValue<int>("InstallBehavior");
			}
			set {
				SetColumnValue("InstallBehavior", value);
			}
		}

		/// <summary>
		/// License operations.
		/// </summary>
		public string LicOperations {
			get {
				return GetTypedColumnValue<string>("LicOperations");
			}
			set {
				SetColumnValue("LicOperations", value);
			}
		}

		/// <summary>
		/// Hierarchy level.
		/// </summary>
		public int HierarchyLevel {
			get {
				return GetTypedColumnValue<int>("HierarchyLevel");
			}
			set {
				SetColumnValue("HierarchyLevel", value);
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
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// Workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = new SysWorkspace(LookupColumnEntities.GetEntity("SysWorkspace")));
			}
		}

		/// <exclude/>
		public Guid SysRepositoryId {
			get {
				return GetTypedColumnValue<Guid>("SysRepositoryId");
			}
			set {
				SetColumnValue("SysRepositoryId", value);
				_sysRepository = null;
			}
		}

		/// <exclude/>
		public string SysRepositoryName {
			get {
				return GetTypedColumnValue<string>("SysRepositoryName");
			}
			set {
				SetColumnValue("SysRepositoryName", value);
				if (_sysRepository != null) {
					_sysRepository.Name = value;
				}
			}
		}

		private SysRepository _sysRepository;
		/// <summary>
		/// Versions control storage.
		/// </summary>
		public SysRepository SysRepository {
			get {
				return _sysRepository ??
					(_sysRepository = new SysRepository(LookupColumnEntities.GetEntity("SysRepository")));
			}
		}

		#endregion

	}

	#endregion

}

