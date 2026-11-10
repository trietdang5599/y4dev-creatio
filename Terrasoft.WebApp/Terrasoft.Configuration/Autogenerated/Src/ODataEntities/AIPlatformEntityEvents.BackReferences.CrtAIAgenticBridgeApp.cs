namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: AIPlatformEntityEvents

	/// <exclude/>
	public class AIPlatformEntityEvents : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AIPlatformEntityEvents(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AIPlatformEntityEvents";
		}

		public AIPlatformEntityEvents(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AIPlatformEntityEvents";
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
		/// Object filter.
		/// </summary>
		public string EntitySchemaFilters {
			get {
				return GetTypedColumnValue<string>("EntitySchemaFilters");
			}
			set {
				SetColumnValue("EntitySchemaFilters", value);
			}
		}

		/// <summary>
		/// AI Platform Trigger Code.
		/// </summary>
		public string AIPlatformTriggerCode {
			get {
				return GetTypedColumnValue<string>("AIPlatformTriggerCode");
			}
			set {
				SetColumnValue("AIPlatformTriggerCode", value);
			}
		}

		/// <summary>
		/// Event start conditions by changed columns.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
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
		public Guid EntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaId");
			}
			set {
				SetColumnValue("EntitySchemaId", value);
				_entitySchema = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaTitle {
			get {
				return GetTypedColumnValue<string>("EntitySchemaTitle");
			}
			set {
				SetColumnValue("EntitySchemaTitle", value);
				if (_entitySchema != null) {
					_entitySchema.Title = value;
				}
			}
		}

		private VwEntityObjects _entitySchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwEntityObjects EntitySchema {
			get {
				return _entitySchema ??
					(_entitySchema = new VwEntityObjects(LookupColumnEntities.GetEntity("EntitySchema")));
			}
		}

		/// <exclude/>
		public Guid EntitySchemaChangeTypeId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaChangeTypeId");
			}
			set {
				SetColumnValue("EntitySchemaChangeTypeId", value);
				_entitySchemaChangeType = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaChangeTypeName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaChangeTypeName");
			}
			set {
				SetColumnValue("EntitySchemaChangeTypeName", value);
				if (_entitySchemaChangeType != null) {
					_entitySchemaChangeType.Name = value;
				}
			}
		}

		private SysEntityChangeType _entitySchemaChangeType;
		/// <summary>
		/// Event type.
		/// </summary>
		public SysEntityChangeType EntitySchemaChangeType {
			get {
				return _entitySchemaChangeType ??
					(_entitySchemaChangeType = new SysEntityChangeType(LookupColumnEntities.GetEntity("EntitySchemaChangeType")));
			}
		}

		#endregion

	}

	#endregion

}

