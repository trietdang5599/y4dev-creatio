namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: MobileSyncSett

	/// <exclude/>
	public class MobileSyncSett : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MobileSyncSett(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobileSyncSett";
		}

		public MobileSyncSett(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MobileSyncSett";
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
		/// Workplace code.
		/// </summary>
		public string WorkplaceCode {
			get {
				return GetTypedColumnValue<string>("WorkplaceCode");
			}
			set {
				SetColumnValue("WorkplaceCode", value);
			}
		}

		/// <summary>
		/// Enabled.
		/// </summary>
		public bool IsEnabled {
			get {
				return GetTypedColumnValue<bool>("IsEnabled");
			}
			set {
				SetColumnValue("IsEnabled", value);
			}
		}

		/// <summary>
		/// Filtered records count.
		/// </summary>
		public int Count {
			get {
				return GetTypedColumnValue<int>("Count");
			}
			set {
				SetColumnValue("Count", value);
			}
		}

		/// <summary>
		/// Total records count.
		/// </summary>
		public int TotalCount {
			get {
				return GetTypedColumnValue<int>("TotalCount");
			}
			set {
				SetColumnValue("TotalCount", value);
			}
		}

		/// <summary>
		/// Object name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// Object caption.
		/// </summary>
		public string EntityCaption {
			get {
				return GetTypedColumnValue<string>("EntityCaption");
			}
			set {
				SetColumnValue("EntityCaption", value);
			}
		}

		/// <summary>
		/// FilterData.
		/// </summary>
		public string FilterData {
			get {
				return GetTypedColumnValue<string>("FilterData");
			}
			set {
				SetColumnValue("FilterData", value);
			}
		}

		/// <summary>
		/// Workplace name.
		/// </summary>
		public string WorkplaceName {
			get {
				return GetTypedColumnValue<string>("WorkplaceName");
			}
			set {
				SetColumnValue("WorkplaceName", value);
			}
		}

		#endregion

	}

	#endregion

}

