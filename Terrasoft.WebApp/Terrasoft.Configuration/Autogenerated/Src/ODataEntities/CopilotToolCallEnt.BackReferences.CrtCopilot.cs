namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CopilotToolCallEnt

	/// <exclude/>
	public class CopilotToolCallEnt : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CopilotToolCallEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotToolCallEnt";
		}

		public CopilotToolCallEnt(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CopilotToolCallEnt";
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
		/// Arguments.
		/// </summary>
		public string Arguments {
			get {
				return GetTypedColumnValue<string>("Arguments");
			}
			set {
				SetColumnValue("Arguments", value);
			}
		}

		/// <summary>
		/// Function name.
		/// </summary>
		public string FunctionName {
			get {
				return GetTypedColumnValue<string>("FunctionName");
			}
			set {
				SetColumnValue("FunctionName", value);
			}
		}

		/// <summary>
		/// ToolCallId.
		/// </summary>
		public string ToolCallId {
			get {
				return GetTypedColumnValue<string>("ToolCallId");
			}
			set {
				SetColumnValue("ToolCallId", value);
			}
		}

		/// <summary>
		/// Confirmation result.
		/// </summary>
		public string ConfirmationResult {
			get {
				return GetTypedColumnValue<string>("ConfirmationResult");
			}
			set {
				SetColumnValue("ConfirmationResult", value);
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
		public Guid CopilotMessageId {
			get {
				return GetTypedColumnValue<Guid>("CopilotMessageId");
			}
			set {
				SetColumnValue("CopilotMessageId", value);
				_copilotMessage = null;
			}
		}

		private CopilotMessageEnt _copilotMessage;
		/// <summary>
		/// Creatio.ai Message.
		/// </summary>
		public CopilotMessageEnt CopilotMessage {
			get {
				return _copilotMessage ??
					(_copilotMessage = new CopilotMessageEnt(LookupColumnEntities.GetEntity("CopilotMessage")));
			}
		}

		#endregion

	}

	#endregion

}

