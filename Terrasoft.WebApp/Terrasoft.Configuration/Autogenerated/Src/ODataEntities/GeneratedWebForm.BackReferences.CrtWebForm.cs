namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: GeneratedWebForm

	/// <exclude/>
	public class GeneratedWebForm : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public GeneratedWebForm(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebForm";
		}

		public GeneratedWebForm(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "GeneratedWebForm";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<GeneratedWebFormFile> GeneratedWebFormFileCollectionByGeneratedWebForm {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormInFolder> GeneratedWebFormInFolderCollectionByGeneratedWebForm {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormInTag> GeneratedWebFormInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<LandingObjectDefaults> LandingObjectDefaultsCollectionByLanding {
			get;
			set;
		}

		public IEnumerable<WebFormData> WebFormDataCollectionByWebForm {
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
		/// Website domains.
		/// </summary>
		public string ExternalURL {
			get {
				return GetTypedColumnValue<string>("ExternalURL");
			}
			set {
				SetColumnValue("ExternalURL", value);
			}
		}

		/// <summary>
		/// Redirection URL.
		/// </summary>
		public string ReturnURL {
			get {
				return GetTypedColumnValue<string>("ReturnURL");
			}
			set {
				SetColumnValue("ReturnURL", value);
			}
		}

		/// <summary>
		/// Object fields filled in by default.
		/// </summary>
		public string EntityDefaultValues {
			get {
				return GetTypedColumnValue<string>("EntityDefaultValues");
			}
			set {
				SetColumnValue("EntityDefaultValues", value);
			}
		}

		/// <summary>
		/// Landing page fields.
		/// </summary>
		public string FormFields {
			get {
				return GetTypedColumnValue<string>("FormFields");
			}
			set {
				SetColumnValue("FormFields", value);
			}
		}

		/// <summary>
		/// Generated landing page.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Create contact.
		/// </summary>
		public bool CreateContact {
			get {
				return GetTypedColumnValue<bool>("CreateContact");
			}
			set {
				SetColumnValue("CreateContact", value);
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

		private LendingState _state;
		/// <summary>
		/// Status.
		/// </summary>
		public LendingState State {
			get {
				return _state ??
					(_state = new LendingState(LookupColumnEntities.GetEntity("State")));
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

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private LandingType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public LandingType Type {
			get {
				return _type ??
					(_type = new LandingType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid IdentificationProcessId {
			get {
				return GetTypedColumnValue<Guid>("IdentificationProcessId");
			}
			set {
				SetColumnValue("IdentificationProcessId", value);
				_identificationProcess = null;
			}
		}

		/// <exclude/>
		public string IdentificationProcessName {
			get {
				return GetTypedColumnValue<string>("IdentificationProcessName");
			}
			set {
				SetColumnValue("IdentificationProcessName", value);
				if (_identificationProcess != null) {
					_identificationProcess.Name = value;
				}
			}
		}

		private WebFormContactIdentifier _identificationProcess;
		/// <summary>
		/// Contact search process.
		/// </summary>
		public WebFormContactIdentifier IdentificationProcess {
			get {
				return _identificationProcess ??
					(_identificationProcess = new WebFormContactIdentifier(LookupColumnEntities.GetEntity("IdentificationProcess")));
			}
		}

		#endregion

	}

	#endregion

}

