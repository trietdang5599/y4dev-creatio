namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: NextStep

	/// <exclude/>
	public class NextStep : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public NextStep(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NextStep";
		}

		public NextStep(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "NextStep";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
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
		/// Master record identifier.
		/// </summary>
		public Guid MasterEntityId {
			get {
				return GetTypedColumnValue<Guid>("MasterEntityId");
			}
			set {
				SetColumnValue("MasterEntityId", value);
			}
		}

		/// <summary>
		/// Entity name.
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
		/// Master record name.
		/// </summary>
		public string MasterEntityName {
			get {
				return GetTypedColumnValue<string>("MasterEntityName");
			}
			set {
				SetColumnValue("MasterEntityName", value);
			}
		}

		/// <summary>
		/// IsRequired.
		/// </summary>
		public bool IsRequired {
			get {
				return GetTypedColumnValue<bool>("IsRequired");
			}
			set {
				SetColumnValue("IsRequired", value);
			}
		}

		/// <summary>
		/// Process element identifier.
		/// </summary>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
			}
		}

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <summary>
		/// Column with additional info.
		/// </summary>
		public string AdditionalInfo {
			get {
				return GetTypedColumnValue<string>("AdditionalInfo");
			}
			set {
				SetColumnValue("AdditionalInfo", value);
			}
		}

		/// <summary>
		/// Is owner role.
		/// </summary>
		public bool IsOwnerRole {
			get {
				return GetTypedColumnValue<bool>("IsOwnerRole");
			}
			set {
				SetColumnValue("IsOwnerRole", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		#endregion

	}

	#endregion

}

