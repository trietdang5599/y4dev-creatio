namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CopilotSessionEnt

	/// <exclude/>
	public class CopilotSessionEnt : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CopilotSessionEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotSessionEnt";
		}

		public CopilotSessionEnt(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CopilotSessionEnt";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CopilotMessageEnt> CopilotMessageEntCollectionByCopilotSession {
			get;
			set;
		}

		public IEnumerable<CopilotSessionEnt> CopilotSessionEntCollectionByRootSession {
			get;
			set;
		}

		public IEnumerable<VwCopilotSessionEx> VwCopilotSessionExCollectionByRootSession {
			get;
			set;
		}

		public IEnumerable<VwCopilotSessionIntent> VwCopilotSessionIntentCollectionByCopilotSession {
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
		/// End.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Start.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		public string FilterDescriptors {
			get {
				return GetTypedColumnValue<string>("FilterDescriptors");
			}
			set {
				SetColumnValue("FilterDescriptors", value);
			}
		}

		/// <summary>
		/// Max output tokens.
		/// </summary>
		public int MaxOutputTokens {
			get {
				return GetTypedColumnValue<int>("MaxOutputTokens");
			}
			set {
				SetColumnValue("MaxOutputTokens", value);
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
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = new SysAdminUnit(LookupColumnEntities.GetEntity("User")));
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private CopilotSessionStateEnt _state;
		/// <summary>
		/// State.
		/// </summary>
		public CopilotSessionStateEnt State {
			get {
				return _state ??
					(_state = new CopilotSessionStateEnt(LookupColumnEntities.GetEntity("State")));
			}
		}

		/// <exclude/>
		public Guid CurrentIntentId {
			get {
				return GetTypedColumnValue<Guid>("CurrentIntentId");
			}
			set {
				SetColumnValue("CurrentIntentId", value);
				_currentIntent = null;
			}
		}

		/// <exclude/>
		public string CurrentIntentCaption {
			get {
				return GetTypedColumnValue<string>("CurrentIntentCaption");
			}
			set {
				SetColumnValue("CurrentIntentCaption", value);
				if (_currentIntent != null) {
					_currentIntent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _currentIntent;
		/// <summary>
		/// Current skill.
		/// </summary>
		public VwSysSchemaInfo CurrentIntent {
			get {
				return _currentIntent ??
					(_currentIntent = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("CurrentIntent")));
			}
		}

		/// <exclude/>
		public Guid RootIntentId {
			get {
				return GetTypedColumnValue<Guid>("RootIntentId");
			}
			set {
				SetColumnValue("RootIntentId", value);
				_rootIntent = null;
			}
		}

		/// <exclude/>
		public string RootIntentCaption {
			get {
				return GetTypedColumnValue<string>("RootIntentCaption");
			}
			set {
				SetColumnValue("RootIntentCaption", value);
				if (_rootIntent != null) {
					_rootIntent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _rootIntent;
		/// <summary>
		/// Root Agent.
		/// </summary>
		public VwSysSchemaInfo RootIntent {
			get {
				return _rootIntent ??
					(_rootIntent = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("RootIntent")));
			}
		}

		/// <exclude/>
		public Guid BoundedIntentId {
			get {
				return GetTypedColumnValue<Guid>("BoundedIntentId");
			}
			set {
				SetColumnValue("BoundedIntentId", value);
				_boundedIntent = null;
			}
		}

		/// <exclude/>
		public string BoundedIntentCaption {
			get {
				return GetTypedColumnValue<string>("BoundedIntentCaption");
			}
			set {
				SetColumnValue("BoundedIntentCaption", value);
				if (_boundedIntent != null) {
					_boundedIntent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _boundedIntent;
		/// <summary>
		/// Bounded intent.
		/// </summary>
		public VwSysSchemaInfo BoundedIntent {
			get {
				return _boundedIntent ??
					(_boundedIntent = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("BoundedIntent")));
			}
		}

		/// <exclude/>
		public Guid RootSessionId {
			get {
				return GetTypedColumnValue<Guid>("RootSessionId");
			}
			set {
				SetColumnValue("RootSessionId", value);
				_rootSession = null;
			}
		}

		/// <exclude/>
		public string RootSessionTitle {
			get {
				return GetTypedColumnValue<string>("RootSessionTitle");
			}
			set {
				SetColumnValue("RootSessionTitle", value);
				if (_rootSession != null) {
					_rootSession.Title = value;
				}
			}
		}

		private CopilotSessionEnt _rootSession;
		/// <summary>
		/// Root Session.
		/// </summary>
		public CopilotSessionEnt RootSession {
			get {
				return _rootSession ??
					(_rootSession = new CopilotSessionEnt(LookupColumnEntities.GetEntity("RootSession")));
			}
		}

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// ProcessElement.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = new SysProcessElementData(LookupColumnEntities.GetEntity("ProcessElement")));
			}
		}

		#endregion

	}

	#endregion

}

