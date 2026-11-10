namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: VwSysSetting

	/// <exclude/>
	public class VwSysSetting : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSetting";
		}

		public VwSysSetting(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysSetting";
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
		/// Type.
		/// </summary>
		public string ValueTypeName {
			get {
				return GetTypedColumnValue<string>("ValueTypeName");
			}
			set {
				SetColumnValue("ValueTypeName", value);
			}
		}

		/// <summary>
		/// Identifier of system setting lookup.
		/// </summary>
		public Guid ReferenceSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaUId");
			}
			set {
				SetColumnValue("ReferenceSchemaUId", value);
			}
		}

		/// <summary>
		/// Personal.
		/// </summary>
		public bool IsPersonal {
			get {
				return GetTypedColumnValue<bool>("IsPersonal");
			}
			set {
				SetColumnValue("IsPersonal", value);
			}
		}

		/// <summary>
		/// Cached.
		/// </summary>
		public bool IsCacheable {
			get {
				return GetTypedColumnValue<bool>("IsCacheable");
			}
			set {
				SetColumnValue("IsCacheable", value);
			}
		}

		/// <summary>
		/// Allow for portal users.
		/// </summary>
		public bool IsSSPAvailable {
			get {
				return GetTypedColumnValue<bool>("IsSSPAvailable");
			}
			set {
				SetColumnValue("IsSSPAvailable", value);
			}
		}

		#endregion

	}

	#endregion

}

