namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: VwCopilotRequest

	/// <exclude/>
	public class VwCopilotRequest : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwCopilotRequest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCopilotRequest";
		}

		public VwCopilotRequest(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwCopilotRequest";
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
		/// Total Tokens.
		/// </summary>
		/// <remarks>
		/// Total number of tokens used in the request (prompt + completion).
		/// </remarks>
		public int TotalTokens {
			get {
				return GetTypedColumnValue<int>("TotalTokens");
			}
			set {
				SetColumnValue("TotalTokens", value);
			}
		}

		/// <summary>
		/// Completion Tokens.
		/// </summary>
		/// <remarks>
		/// Number of tokens in the generated completion.
		/// </remarks>
		public int CompletionTokens {
			get {
				return GetTypedColumnValue<int>("CompletionTokens");
			}
			set {
				SetColumnValue("CompletionTokens", value);
			}
		}

		/// <summary>
		/// Prompt Tokens.
		/// </summary>
		/// <remarks>
		/// Number of tokens in the prompt.
		/// </remarks>
		public int PromptTokens {
			get {
				return GetTypedColumnValue<int>("PromptTokens");
			}
			set {
				SetColumnValue("PromptTokens", value);
			}
		}

		/// <summary>
		/// Duration (ms).
		/// </summary>
		/// <remarks>
		/// Duration of request in milliseconds.
		/// </remarks>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Error.
		/// </summary>
		/// <remarks>
		/// Error message.
		/// </remarks>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// Is Failed.
		/// </summary>
		/// <remarks>
		/// Request success indicator.
		/// </remarks>
		public bool IsFailed {
			get {
				return GetTypedColumnValue<bool>("IsFailed");
			}
			set {
				SetColumnValue("IsFailed", value);
			}
		}

		/// <summary>
		/// Total Actions.
		/// </summary>
		/// <remarks>
		/// Total number of actions used in the request.
		/// </remarks>
		public int TotalActions {
			get {
				return GetTypedColumnValue<int>("TotalActions");
			}
			set {
				SetColumnValue("TotalActions", value);
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
		public string IntentCaption {
			get {
				return GetTypedColumnValue<string>("IntentCaption");
			}
			set {
				SetColumnValue("IntentCaption", value);
				if (_intent != null) {
					_intent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public VwSysSchemaInfo Intent {
			get {
				return _intent ??
					(_intent = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("Intent")));
			}
		}

		#endregion

	}

	#endregion

}

