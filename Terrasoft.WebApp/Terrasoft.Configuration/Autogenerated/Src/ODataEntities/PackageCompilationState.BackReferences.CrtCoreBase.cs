namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: PackageCompilationState

	/// <exclude/>
	public class PackageCompilationState : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public PackageCompilationState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PackageCompilationState";
		}

		public PackageCompilationState(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "PackageCompilationState";
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
		/// RequiresRestore.
		/// </summary>
		public bool RequiresRestore {
			get {
				return GetTypedColumnValue<bool>("RequiresRestore");
			}
			set {
				SetColumnValue("RequiresRestore", value);
			}
		}

		/// <summary>
		/// NeedCompile.
		/// </summary>
		public bool NeedCompile {
			get {
				return GetTypedColumnValue<bool>("NeedCompile");
			}
			set {
				SetColumnValue("NeedCompile", value);
			}
		}

		/// <summary>
		/// NeedCompileDependentPackages.
		/// </summary>
		public bool NeedCompileDependentPackages {
			get {
				return GetTypedColumnValue<bool>("NeedCompileDependentPackages");
			}
			set {
				SetColumnValue("NeedCompileDependentPackages", value);
			}
		}

		/// <summary>
		/// NeedDownloadPackageSourceCode.
		/// </summary>
		public bool NeedDownloadPackageSourceCode {
			get {
				return GetTypedColumnValue<bool>("NeedDownloadPackageSourceCode");
			}
			set {
				SetColumnValue("NeedDownloadPackageSourceCode", value);
			}
		}

		/// <summary>
		/// NeedRegeneratePackagesCsproj.
		/// </summary>
		public bool NeedRegeneratePackagesCsproj {
			get {
				return GetTypedColumnValue<bool>("NeedRegeneratePackagesCsproj");
			}
			set {
				SetColumnValue("NeedRegeneratePackagesCsproj", value);
			}
		}

		/// <summary>
		/// NeedCompileOData.
		/// </summary>
		public bool NeedCompileOData {
			get {
				return GetTypedColumnValue<bool>("NeedCompileOData");
			}
			set {
				SetColumnValue("NeedCompileOData", value);
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

		#endregion

	}

	#endregion

}

