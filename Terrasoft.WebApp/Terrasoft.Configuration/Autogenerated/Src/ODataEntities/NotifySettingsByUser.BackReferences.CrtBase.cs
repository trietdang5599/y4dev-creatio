namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: NotifySettingsByUser

	/// <exclude/>
	public class NotifySettingsByUser : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public NotifySettingsByUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotifySettingsByUser";
		}

		public NotifySettingsByUser(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "NotifySettingsByUser";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enabled.
		/// </summary>
		public bool State {
			get {
				return GetTypedColumnValue<bool>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// Notifications category.
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
		/// Notification setting code.
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

