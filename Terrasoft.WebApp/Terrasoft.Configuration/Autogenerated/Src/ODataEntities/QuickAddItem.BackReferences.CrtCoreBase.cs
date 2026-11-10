namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: QuickAddItem

	/// <exclude/>
	public class QuickAddItem : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public QuickAddItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddItem";
		}

		public QuickAddItem(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "QuickAddItem";
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
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Object code.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
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

		/// <exclude/>
		public Guid QuickAddMenuSettingsId {
			get {
				return GetTypedColumnValue<Guid>("QuickAddMenuSettingsId");
			}
			set {
				SetColumnValue("QuickAddMenuSettingsId", value);
				_quickAddMenuSettings = null;
			}
		}

		/// <exclude/>
		public string QuickAddMenuSettingsName {
			get {
				return GetTypedColumnValue<string>("QuickAddMenuSettingsName");
			}
			set {
				SetColumnValue("QuickAddMenuSettingsName", value);
				if (_quickAddMenuSettings != null) {
					_quickAddMenuSettings.Name = value;
				}
			}
		}

		private QuickAddMenuSettings _quickAddMenuSettings;
		/// <summary>
		/// Group of quick add menu.
		/// </summary>
		public QuickAddMenuSettings QuickAddMenuSettings {
			get {
				return _quickAddMenuSettings ??
					(_quickAddMenuSettings = new QuickAddMenuSettings(LookupColumnEntities.GetEntity("QuickAddMenuSettings")));
			}
		}

		#endregion

	}

	#endregion

}

