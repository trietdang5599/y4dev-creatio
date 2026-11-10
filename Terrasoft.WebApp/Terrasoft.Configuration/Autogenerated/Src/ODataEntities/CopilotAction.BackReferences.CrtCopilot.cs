namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CopilotAction

	/// <exclude/>
	public class CopilotAction : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CopilotAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotAction";
		}

		public CopilotAction(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CopilotAction";
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
		/// Params.
		/// </summary>
		public string Params {
			get {
				return GetTypedColumnValue<string>("Params");
			}
			set {
				SetColumnValue("Params", value);
			}
		}

		/// <summary>
		/// Package unique identifier.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <summary>
		/// Require confirmation before start.
		/// </summary>
		public bool IsConfirmRequired {
			get {
				return GetTypedColumnValue<bool>("IsConfirmRequired");
			}
			set {
				SetColumnValue("IsConfirmRequired", value);
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
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentName {
			get {
				return GetTypedColumnValue<string>("IntentName");
			}
			set {
				SetColumnValue("IntentName", value);
				if (_intent != null) {
					_intent.Name = value;
				}
			}
		}

		private CopilotIntent _intent;
		/// <summary>
		/// Creatio.ai skills.
		/// </summary>
		public CopilotIntent Intent {
			get {
				return _intent ??
					(_intent = new CopilotIntent(LookupColumnEntities.GetEntity("Intent")));
			}
		}

		/// <exclude/>
		public Guid ActionTypeId {
			get {
				return GetTypedColumnValue<Guid>("ActionTypeId");
			}
			set {
				SetColumnValue("ActionTypeId", value);
				_actionType = null;
			}
		}

		/// <exclude/>
		public string ActionTypeName {
			get {
				return GetTypedColumnValue<string>("ActionTypeName");
			}
			set {
				SetColumnValue("ActionTypeName", value);
				if (_actionType != null) {
					_actionType.Name = value;
				}
			}
		}

		private CopilotActionType _actionType;
		/// <summary>
		/// Action type.
		/// </summary>
		public CopilotActionType ActionType {
			get {
				return _actionType ??
					(_actionType = new CopilotActionType(LookupColumnEntities.GetEntity("ActionType")));
			}
		}

		#endregion

	}

	#endregion

}

