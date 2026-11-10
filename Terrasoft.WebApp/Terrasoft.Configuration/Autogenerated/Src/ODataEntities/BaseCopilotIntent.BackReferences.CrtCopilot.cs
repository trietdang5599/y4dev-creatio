namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: BaseCopilotIntent

	/// <exclude/>
	public class BaseCopilotIntent : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BaseCopilotIntent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCopilotIntent";
		}

		public BaseCopilotIntent(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BaseCopilotIntent";
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
		/// Title.
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
		/// Prompt.
		/// </summary>
		public string Prompt {
			get {
				return GetTypedColumnValue<string>("Prompt");
			}
			set {
				SetColumnValue("Prompt", value);
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
		/// Use page context.
		/// </summary>
		public bool UsePageContext {
			get {
				return GetTypedColumnValue<bool>("UsePageContext");
			}
			set {
				SetColumnValue("UsePageContext", value);
			}
		}

		/// <summary>
		/// Is intent available only in workflow.
		/// </summary>
		public bool WorkflowOnly {
			get {
				return GetTypedColumnValue<bool>("WorkflowOnly");
			}
			set {
				SetColumnValue("WorkflowOnly", value);
			}
		}

		/// <summary>
		/// Use chat history.
		/// </summary>
		/// <remarks>
		/// Uses chat history when the skill is executed as part of a Workflow agent.
		/// </remarks>
		public bool UseChatHistory {
			get {
				return GetTypedColumnValue<bool>("UseChatHistory");
			}
			set {
				SetColumnValue("UseChatHistory", value);
			}
		}

		/// <summary>
		/// Use default system prompt.
		/// </summary>
		public bool UseDefaultSystemPrompt {
			get {
				return GetTypedColumnValue<bool>("UseDefaultSystemPrompt");
			}
			set {
				SetColumnValue("UseDefaultSystemPrompt", value);
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

		private CopilotIntentType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public CopilotIntentType Type {
			get {
				return _type ??
					(_type = new CopilotIntentType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CopilotIntentStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public CopilotIntentStatus Status {
			get {
				return _status ??
					(_status = new CopilotIntentStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <exclude/>
		public Guid LlmModelId {
			get {
				return GetTypedColumnValue<Guid>("LlmModelId");
			}
			set {
				SetColumnValue("LlmModelId", value);
				_llmModel = null;
			}
		}

		/// <exclude/>
		public string LlmModelName {
			get {
				return GetTypedColumnValue<string>("LlmModelName");
			}
			set {
				SetColumnValue("LlmModelName", value);
				if (_llmModel != null) {
					_llmModel.Name = value;
				}
			}
		}

		private LlmModel _llmModel;
		/// <summary>
		/// LLM Model.
		/// </summary>
		public LlmModel LlmModel {
			get {
				return _llmModel ??
					(_llmModel = new LlmModel(LookupColumnEntities.GetEntity("LlmModel")));
			}
		}

		#endregion

	}

	#endregion

}

