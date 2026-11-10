namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysInstalledApp

	/// <exclude/>
	public class SysInstalledApp : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysInstalledApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledApp";
		}

		public SysInstalledApp(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysInstalledApp";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysAppDependency> SysAppDependencyCollectionByDependOnApplication {
			get;
			set;
		}

		public IEnumerable<SysAppDependency> SysAppDependencyCollectionBySysInstalledApp {
			get;
			set;
		}

		public IEnumerable<SysInactivePackageInApp> SysInactivePackageInAppCollectionBySysInstalledApp {
			get;
			set;
		}

		public IEnumerable<SysPackageInInstalledApp> SysPackageInInstalledAppCollectionBySysInstalledApp {
			get;
			set;
		}

		public IEnumerable<SysPluginPackageInApp> SysPluginPackageInAppCollectionBySysInstalledApp {
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
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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
		/// Install date.
		/// </summary>
		public DateTime InstallDate {
			get {
				return GetTypedColumnValue<DateTime>("InstallDate");
			}
			set {
				SetColumnValue("InstallDate", value);
			}
		}

		/// <summary>
		/// Date last updated.
		/// </summary>
		public DateTime LastUpdate {
			get {
				return GetTypedColumnValue<DateTime>("LastUpdate");
			}
			set {
				SetColumnValue("LastUpdate", value);
			}
		}

		/// <summary>
		/// Marketplace link.
		/// </summary>
		public string MarketplaceLink {
			get {
				return GetTypedColumnValue<string>("MarketplaceLink");
			}
			set {
				SetColumnValue("MarketplaceLink", value);
			}
		}

		/// <summary>
		/// Help link.
		/// </summary>
		public string HelpLink {
			get {
				return GetTypedColumnValue<string>("HelpLink");
			}
			set {
				SetColumnValue("HelpLink", value);
			}
		}

		/// <summary>
		/// File link.
		/// </summary>
		public string FileLink {
			get {
				return GetTypedColumnValue<string>("FileLink");
			}
			set {
				SetColumnValue("FileLink", value);
			}
		}

		/// <summary>
		/// Support email.
		/// </summary>
		public string SupportEmail {
			get {
				return GetTypedColumnValue<string>("SupportEmail");
			}
			set {
				SetColumnValue("SupportEmail", value);
			}
		}

		/// <summary>
		/// Order link.
		/// </summary>
		public string OrderLink {
			get {
				return GetTypedColumnValue<string>("OrderLink");
			}
			set {
				SetColumnValue("OrderLink", value);
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppStatusId");
			}
			set {
				SetColumnValue("SysInstalledAppStatusId", value);
				_sysInstalledAppStatus = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppStatusName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppStatusName");
			}
			set {
				SetColumnValue("SysInstalledAppStatusName", value);
				if (_sysInstalledAppStatus != null) {
					_sysInstalledAppStatus.Name = value;
				}
			}
		}

		private SysInstalledAppStatus _sysInstalledAppStatus;
		/// <summary>
		/// Application status.
		/// </summary>
		public SysInstalledAppStatus SysInstalledAppStatus {
			get {
				return _sysInstalledAppStatus ??
					(_sysInstalledAppStatus = new SysInstalledAppStatus(LookupColumnEntities.GetEntity("SysInstalledAppStatus")));
			}
		}

		/// <summary>
		/// Icon background color.
		/// </summary>
		/// <remarks>
		/// Code of the application icon background color.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		/// <exclude/>
		public Guid SysAppIconId {
			get {
				return GetTypedColumnValue<Guid>("SysAppIconId");
			}
			set {
				SetColumnValue("SysAppIconId", value);
				_sysAppIcon = null;
			}
		}

		/// <exclude/>
		public string SysAppIconName {
			get {
				return GetTypedColumnValue<string>("SysAppIconName");
			}
			set {
				SetColumnValue("SysAppIconName", value);
				if (_sysAppIcon != null) {
					_sysAppIcon.Name = value;
				}
			}
		}

		private SysAppIcons _sysAppIcon;
		/// <summary>
		/// App icon.
		/// </summary>
		public SysAppIcons SysAppIcon {
			get {
				return _sysAppIcon ??
					(_sysAppIcon = new SysAppIcons(LookupColumnEntities.GetEntity("SysAppIcon")));
			}
		}

		/// <summary>
		/// Is delete deny.
		/// </summary>
		public bool IsDeleteDeny {
			get {
				return GetTypedColumnValue<bool>("IsDeleteDeny");
			}
			set {
				SetColumnValue("IsDeleteDeny", value);
			}
		}

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Update available.
		/// </summary>
		public bool NeedUpdate {
			get {
				return GetTypedColumnValue<bool>("NeedUpdate");
			}
			set {
				SetColumnValue("NeedUpdate", value);
			}
		}

		/// <summary>
		/// Latest available version.
		/// </summary>
		public string VersionForUpdate {
			get {
				return GetTypedColumnValue<string>("VersionForUpdate");
			}
			set {
				SetColumnValue("VersionForUpdate", value);
			}
		}

		/// <summary>
		/// Current version.
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
		/// Marketplace application ID.
		/// </summary>
		public string MarketplaceAppId {
			get {
				return GetTypedColumnValue<string>("MarketplaceAppId");
			}
			set {
				SetColumnValue("MarketplaceAppId", value);
			}
		}

		/// <summary>
		/// Run parameters.
		/// </summary>
		public string RunParams {
			get {
				return GetTypedColumnValue<string>("RunParams");
			}
			set {
				SetColumnValue("RunParams", value);
			}
		}

		/// <exclude/>
		public Guid RunTypeId {
			get {
				return GetTypedColumnValue<Guid>("RunTypeId");
			}
			set {
				SetColumnValue("RunTypeId", value);
				_runType = null;
			}
		}

		/// <exclude/>
		public string RunTypeName {
			get {
				return GetTypedColumnValue<string>("RunTypeName");
			}
			set {
				SetColumnValue("RunTypeName", value);
				if (_runType != null) {
					_runType.Name = value;
				}
			}
		}

		private SysInstalledAppRunType _runType;
		/// <summary>
		/// Run type.
		/// </summary>
		public SysInstalledAppRunType RunType {
			get {
				return _runType ??
					(_runType = new SysInstalledAppRunType(LookupColumnEntities.GetEntity("RunType")));
			}
		}

		/// <summary>
		/// Hidden in the Application Hub.
		/// </summary>
		public bool IsHidden {
			get {
				return GetTypedColumnValue<bool>("IsHidden");
			}
			set {
				SetColumnValue("IsHidden", value);
			}
		}

		/// <summary>
		/// Required platform version.
		/// </summary>
		public string RequiredPlatformVersion {
			get {
				return GetTypedColumnValue<string>("RequiredPlatformVersion");
			}
			set {
				SetColumnValue("RequiredPlatformVersion", value);
			}
		}

		#endregion

	}

	#endregion

}

