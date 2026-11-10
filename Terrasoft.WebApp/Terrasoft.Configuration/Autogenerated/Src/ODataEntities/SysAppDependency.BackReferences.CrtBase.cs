namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysAppDependency

	/// <exclude/>
	public class SysAppDependency : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysAppDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppDependency";
		}

		public SysAppDependency(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysAppDependency";
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
		public Guid DependOnApplicationId {
			get {
				return GetTypedColumnValue<Guid>("DependOnApplicationId");
			}
			set {
				SetColumnValue("DependOnApplicationId", value);
				_dependOnApplication = null;
			}
		}

		/// <exclude/>
		public string DependOnApplicationName {
			get {
				return GetTypedColumnValue<string>("DependOnApplicationName");
			}
			set {
				SetColumnValue("DependOnApplicationName", value);
				if (_dependOnApplication != null) {
					_dependOnApplication.Name = value;
				}
			}
		}

		private SysInstalledApp _dependOnApplication;
		/// <summary>
		/// Depends on application.
		/// </summary>
		/// <remarks>
		/// Depends on application.
		/// </remarks>
		public SysInstalledApp DependOnApplication {
			get {
				return _dependOnApplication ??
					(_dependOnApplication = new SysInstalledApp(LookupColumnEntities.GetEntity("DependOnApplication")));
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppId");
			}
			set {
				SetColumnValue("SysInstalledAppId", value);
				_sysInstalledApp = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppName");
			}
			set {
				SetColumnValue("SysInstalledAppName", value);
				if (_sysInstalledApp != null) {
					_sysInstalledApp.Name = value;
				}
			}
		}

		private SysInstalledApp _sysInstalledApp;
		/// <summary>
		/// Application.
		/// </summary>
		public SysInstalledApp SysInstalledApp {
			get {
				return _sysInstalledApp ??
					(_sysInstalledApp = new SysInstalledApp(LookupColumnEntities.GetEntity("SysInstalledApp")));
			}
		}

		/// <exclude/>
		public Guid DependOnPackageId {
			get {
				return GetTypedColumnValue<Guid>("DependOnPackageId");
			}
			set {
				SetColumnValue("DependOnPackageId", value);
				_dependOnPackage = null;
			}
		}

		/// <exclude/>
		public string DependOnPackageName {
			get {
				return GetTypedColumnValue<string>("DependOnPackageName");
			}
			set {
				SetColumnValue("DependOnPackageName", value);
				if (_dependOnPackage != null) {
					_dependOnPackage.Name = value;
				}
			}
		}

		private SysPackage _dependOnPackage;
		/// <summary>
		/// Depends on package.
		/// </summary>
		/// <remarks>
		/// Depends on package.
		/// </remarks>
		public SysPackage DependOnPackage {
			get {
				return _dependOnPackage ??
					(_dependOnPackage = new SysPackage(LookupColumnEntities.GetEntity("DependOnPackage")));
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

		#endregion

	}

	#endregion

}

