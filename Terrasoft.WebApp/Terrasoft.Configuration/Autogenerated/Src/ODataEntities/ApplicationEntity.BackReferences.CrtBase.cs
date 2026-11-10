namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: ApplicationEntity

	/// <exclude/>
	public class ApplicationEntity : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ApplicationEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationEntity";
		}

		public ApplicationEntity(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ApplicationEntity";
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
		/// PackageUId.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
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
		/// ModifiedOn.
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
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
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

		/// <exclude/>
		public Guid ApplicationId {
			get {
				return GetTypedColumnValue<Guid>("ApplicationId");
			}
			set {
				SetColumnValue("ApplicationId", value);
				_application = null;
			}
		}

		/// <exclude/>
		public string ApplicationName {
			get {
				return GetTypedColumnValue<string>("ApplicationName");
			}
			set {
				SetColumnValue("ApplicationName", value);
				if (_application != null) {
					_application.Name = value;
				}
			}
		}

		private SysInstalledApp _application;
		/// <summary>
		/// Application.
		/// </summary>
		public SysInstalledApp Application {
			get {
				return _application ??
					(_application = new SysInstalledApp(LookupColumnEntities.GetEntity("Application")));
			}
		}

		#endregion

	}

	#endregion

}

