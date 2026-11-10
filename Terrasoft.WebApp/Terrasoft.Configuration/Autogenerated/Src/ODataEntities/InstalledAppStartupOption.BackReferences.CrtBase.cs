namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: InstalledAppStartupOption

	/// <exclude/>
	public class InstalledAppStartupOption : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public InstalledAppStartupOption(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InstalledAppStartupOption";
		}

		public InstalledAppStartupOption(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "InstalledAppStartupOption";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid InstalledAppId {
			get {
				return GetTypedColumnValue<Guid>("InstalledAppId");
			}
			set {
				SetColumnValue("InstalledAppId", value);
				_installedApp = null;
			}
		}

		/// <exclude/>
		public string InstalledAppName {
			get {
				return GetTypedColumnValue<string>("InstalledAppName");
			}
			set {
				SetColumnValue("InstalledAppName", value);
				if (_installedApp != null) {
					_installedApp.Name = value;
				}
			}
		}

		private SysInstalledApp _installedApp;
		/// <summary>
		/// Installed application.
		/// </summary>
		public SysInstalledApp InstalledApp {
			get {
				return _installedApp ??
					(_installedApp = new SysInstalledApp(LookupColumnEntities.GetEntity("InstalledApp")));
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

		#endregion

	}

	#endregion

}

