namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: KnwIndexingSession

	/// <exclude/>
	public class KnwIndexingSession : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnwIndexingSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwIndexingSession";
		}

		public KnwIndexingSession(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "KnwIndexingSession";
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
		/// Completed on.
		/// </summary>
		public DateTime CompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("CompletedOn");
			}
			set {
				SetColumnValue("CompletedOn", value);
			}
		}

		/// <summary>
		/// Transferred on.
		/// </summary>
		public DateTime TransferredOn {
			get {
				return GetTypedColumnValue<DateTime>("TransferredOn");
			}
			set {
				SetColumnValue("TransferredOn", value);
			}
		}

		/// <summary>
		/// Started on.
		/// </summary>
		public DateTime StartedOn {
			get {
				return GetTypedColumnValue<DateTime>("StartedOn");
			}
			set {
				SetColumnValue("StartedOn", value);
			}
		}

		/// <summary>
		/// Index identifier.
		/// </summary>
		/// <remarks>
		/// Index on microservice side.
		/// </remarks>
		public string IndexId {
			get {
				return GetTypedColumnValue<string>("IndexId");
			}
			set {
				SetColumnValue("IndexId", value);
			}
		}

		/// <summary>
		/// Session Identifier.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Completed.
		/// </summary>
		public bool IsCompleted {
			get {
				return GetTypedColumnValue<bool>("IsCompleted");
			}
			set {
				SetColumnValue("IsCompleted", value);
			}
		}

		/// <summary>
		/// Details.
		/// </summary>
		public string Details {
			get {
				return GetTypedColumnValue<string>("Details");
			}
			set {
				SetColumnValue("Details", value);
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
		public Guid KnwIndexingStatusId {
			get {
				return GetTypedColumnValue<Guid>("KnwIndexingStatusId");
			}
			set {
				SetColumnValue("KnwIndexingStatusId", value);
				_knwIndexingStatus = null;
			}
		}

		/// <exclude/>
		public string KnwIndexingStatusName {
			get {
				return GetTypedColumnValue<string>("KnwIndexingStatusName");
			}
			set {
				SetColumnValue("KnwIndexingStatusName", value);
				if (_knwIndexingStatus != null) {
					_knwIndexingStatus.Name = value;
				}
			}
		}

		private KnwIndexingStatus _knwIndexingStatus;
		/// <summary>
		/// Status.
		/// </summary>
		public KnwIndexingStatus KnwIndexingStatus {
			get {
				return _knwIndexingStatus ??
					(_knwIndexingStatus = new KnwIndexingStatus(LookupColumnEntities.GetEntity("KnwIndexingStatus")));
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
		/// Knowledge Source.
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

