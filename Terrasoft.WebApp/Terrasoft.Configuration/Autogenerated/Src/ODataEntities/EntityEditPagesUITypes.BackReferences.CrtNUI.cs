namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: EntityEditPagesUITypes

	/// <exclude/>
	public class EntityEditPagesUITypes : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EntityEditPagesUITypes(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityEditPagesUITypes";
		}

		public EntityEditPagesUITypes(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EntityEditPagesUITypes";
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
		public Guid EXTId {
			get {
				return GetTypedColumnValue<Guid>("EXTId");
			}
			set {
				SetColumnValue("EXTId", value);
				_eXT = null;
			}
		}

		/// <exclude/>
		public string EXTName {
			get {
				return GetTypedColumnValue<string>("EXTName");
			}
			set {
				SetColumnValue("EXTName", value);
				if (_eXT != null) {
					_eXT.Name = value;
				}
			}
		}

		private UIType _eXT;
		/// <summary>
		/// Classic UI shell.
		/// </summary>
		public UIType EXT {
			get {
				return _eXT ??
					(_eXT = new UIType(LookupColumnEntities.GetEntity("EXT")));
			}
		}

		/// <exclude/>
		public Guid FreedomId {
			get {
				return GetTypedColumnValue<Guid>("FreedomId");
			}
			set {
				SetColumnValue("FreedomId", value);
				_freedom = null;
			}
		}

		/// <exclude/>
		public string FreedomName {
			get {
				return GetTypedColumnValue<string>("FreedomName");
			}
			set {
				SetColumnValue("FreedomName", value);
				if (_freedom != null) {
					_freedom.Name = value;
				}
			}
		}

		private UIType _freedom;
		/// <summary>
		/// Freedom UI shell.
		/// </summary>
		public UIType Freedom {
			get {
				return _freedom ??
					(_freedom = new UIType(LookupColumnEntities.GetEntity("Freedom")));
			}
		}

		#endregion

	}

	#endregion

}

