namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: KnwSrcEventsOutbox

	/// <exclude/>
	public class KnwSrcEventsOutbox : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnwSrcEventsOutbox(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSrcEventsOutbox";
		}

		public KnwSrcEventsOutbox(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "KnwSrcEventsOutbox";
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
		/// ProcessingToken.
		/// </summary>
		public string ProcessingToken {
			get {
				return GetTypedColumnValue<string>("ProcessingToken");
			}
			set {
				SetColumnValue("ProcessingToken", value);
			}
		}

		/// <summary>
		/// LeaseUntil.
		/// </summary>
		public DateTime LeaseUntil {
			get {
				return GetTypedColumnValue<DateTime>("LeaseUntil");
			}
			set {
				SetColumnValue("LeaseUntil", value);
			}
		}

		/// <summary>
		/// NextAttemptOn.
		/// </summary>
		public DateTime NextAttemptOn {
			get {
				return GetTypedColumnValue<DateTime>("NextAttemptOn");
			}
			set {
				SetColumnValue("NextAttemptOn", value);
			}
		}

		/// <summary>
		/// LastError.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Attempts.
		/// </summary>
		public int Attempts {
			get {
				return GetTypedColumnValue<int>("Attempts");
			}
			set {
				SetColumnValue("Attempts", value);
			}
		}

		/// <summary>
		/// ProcessedOn.
		/// </summary>
		public DateTime ProcessedOn {
			get {
				return GetTypedColumnValue<DateTime>("ProcessedOn");
			}
			set {
				SetColumnValue("ProcessedOn", value);
			}
		}

		/// <summary>
		/// DeadLetteredOn.
		/// </summary>
		public DateTime DeadLetteredOn {
			get {
				return GetTypedColumnValue<DateTime>("DeadLetteredOn");
			}
			set {
				SetColumnValue("DeadLetteredOn", value);
			}
		}

		/// <summary>
		/// IsProcessed.
		/// </summary>
		public bool IsProcessed {
			get {
				return GetTypedColumnValue<bool>("IsProcessed");
			}
			set {
				SetColumnValue("IsProcessed", value);
			}
		}

		/// <summary>
		/// EventOn.
		/// </summary>
		public DateTime EventOn {
			get {
				return GetTypedColumnValue<DateTime>("EventOn");
			}
			set {
				SetColumnValue("EventOn", value);
			}
		}

		/// <summary>
		/// ChangedColumns.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		/// <summary>
		/// EventType.
		/// </summary>
		public int EventType {
			get {
				return GetTypedColumnValue<int>("EventType");
			}
			set {
				SetColumnValue("EventType", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
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
		public Guid KnwSourceId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
				_knwSource = null;
			}
		}

		/// <exclude/>
		public string KnwSourceName {
			get {
				return GetTypedColumnValue<string>("KnwSourceName");
			}
			set {
				SetColumnValue("KnwSourceName", value);
				if (_knwSource != null) {
					_knwSource.Name = value;
				}
			}
		}

		private KnwSource _knwSource;
		/// <summary>
		/// KnwSource.
		/// </summary>
		public KnwSource KnwSource {
			get {
				return _knwSource ??
					(_knwSource = new KnwSource(LookupColumnEntities.GetEntity("KnwSource")));
			}
		}

		#endregion

	}

	#endregion

}

