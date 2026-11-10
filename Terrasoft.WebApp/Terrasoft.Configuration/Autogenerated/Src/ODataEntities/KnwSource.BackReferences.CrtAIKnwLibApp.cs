namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: KnwSource

	/// <exclude/>
	public class KnwSource : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnwSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSource";
		}

		public KnwSource(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "KnwSource";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<KnwIndexingSession> KnwIndexingSessionCollectionByKnwSource {
			get;
			set;
		}

		public IEnumerable<KnwSourceFile> KnwSourceFileCollectionByKnwSource {
			get;
			set;
		}

		public IEnumerable<KnwSourceInSkill> KnwSourceInSkillCollectionByKnwSource {
			get;
			set;
		}

		public IEnumerable<KnwSrcEventsOutbox> KnwSrcEventsOutboxCollectionByKnwSource {
			get;
			set;
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
		/// Last Indexed On.
		/// </summary>
		public DateTime LastIndexedOn {
			get {
				return GetTypedColumnValue<DateTime>("LastIndexedOn");
			}
			set {
				SetColumnValue("LastIndexedOn", value);
			}
		}

		/// <summary>
		/// Config.
		/// </summary>
		public string KnwSourceConfig {
			get {
				return GetTypedColumnValue<string>("KnwSourceConfig");
			}
			set {
				SetColumnValue("KnwSourceConfig", value);
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
		public Guid KnwProviderConnectionId {
			get {
				return GetTypedColumnValue<Guid>("KnwProviderConnectionId");
			}
			set {
				SetColumnValue("KnwProviderConnectionId", value);
				_knwProviderConnection = null;
			}
		}

		/// <exclude/>
		public string KnwProviderConnectionName {
			get {
				return GetTypedColumnValue<string>("KnwProviderConnectionName");
			}
			set {
				SetColumnValue("KnwProviderConnectionName", value);
				if (_knwProviderConnection != null) {
					_knwProviderConnection.Name = value;
				}
			}
		}

		private KnwProviderConnection _knwProviderConnection;
		/// <summary>
		/// Сonnection.
		/// </summary>
		public KnwProviderConnection KnwProviderConnection {
			get {
				return _knwProviderConnection ??
					(_knwProviderConnection = new KnwProviderConnection(LookupColumnEntities.GetEntity("KnwProviderConnection")));
			}
		}

		/// <exclude/>
		public Guid KnwProviderId {
			get {
				return GetTypedColumnValue<Guid>("KnwProviderId");
			}
			set {
				SetColumnValue("KnwProviderId", value);
				_knwProvider = null;
			}
		}

		/// <exclude/>
		public string KnwProviderName {
			get {
				return GetTypedColumnValue<string>("KnwProviderName");
			}
			set {
				SetColumnValue("KnwProviderName", value);
				if (_knwProvider != null) {
					_knwProvider.Name = value;
				}
			}
		}

		private KnwProvider _knwProvider;
		/// <summary>
		/// Provider.
		/// </summary>
		public KnwProvider KnwProvider {
			get {
				return _knwProvider ??
					(_knwProvider = new KnwProvider(LookupColumnEntities.GetEntity("KnwProvider")));
			}
		}

		/// <exclude/>
		public Guid KnwSourceStatusId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceStatusId");
			}
			set {
				SetColumnValue("KnwSourceStatusId", value);
				_knwSourceStatus = null;
			}
		}

		/// <exclude/>
		public string KnwSourceStatusName {
			get {
				return GetTypedColumnValue<string>("KnwSourceStatusName");
			}
			set {
				SetColumnValue("KnwSourceStatusName", value);
				if (_knwSourceStatus != null) {
					_knwSourceStatus.Name = value;
				}
			}
		}

		private KnwSourceStatus _knwSourceStatus;
		/// <summary>
		/// Status.
		/// </summary>
		public KnwSourceStatus KnwSourceStatus {
			get {
				return _knwSourceStatus ??
					(_knwSourceStatus = new KnwSourceStatus(LookupColumnEntities.GetEntity("KnwSourceStatus")));
			}
		}

		#endregion

	}

	#endregion

}

