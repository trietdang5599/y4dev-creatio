namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: VwSysAdminUnitHierarchy

	/// <exclude/>
	public class VwSysAdminUnitHierarchy : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysAdminUnitHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminUnitHierarchy";
		}

		public VwSysAdminUnitHierarchy(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysAdminUnitHierarchy";
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

		#endregion

	}

	#endregion

}

