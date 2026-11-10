namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: OmniChatAction

	/// <exclude/>
	public class OmniChatAction : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OmniChatAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChatAction";
		}

		public OmniChatAction(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OmniChatAction";
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
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Process schema id.
		/// </summary>
		public Guid ProcessSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaId");
			}
			set {
				SetColumnValue("ProcessSchemaId", value);
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
		public Guid ChatQueueId {
			get {
				return GetTypedColumnValue<Guid>("ChatQueueId");
			}
			set {
				SetColumnValue("ChatQueueId", value);
				_chatQueue = null;
			}
		}

		/// <exclude/>
		public string ChatQueueName {
			get {
				return GetTypedColumnValue<string>("ChatQueueName");
			}
			set {
				SetColumnValue("ChatQueueName", value);
				if (_chatQueue != null) {
					_chatQueue.Name = value;
				}
			}
		}

		private ChatQueue _chatQueue;
		/// <summary>
		/// Chat queue.
		/// </summary>
		public ChatQueue ChatQueue {
			get {
				return _chatQueue ??
					(_chatQueue = new ChatQueue(LookupColumnEntities.GetEntity("ChatQueue")));
			}
		}

		/// <exclude/>
		public Guid BusinessProcessId {
			get {
				return GetTypedColumnValue<Guid>("BusinessProcessId");
			}
			set {
				SetColumnValue("BusinessProcessId", value);
				_businessProcess = null;
			}
		}

		/// <exclude/>
		public string BusinessProcessCaption {
			get {
				return GetTypedColumnValue<string>("BusinessProcessCaption");
			}
			set {
				SetColumnValue("BusinessProcessCaption", value);
				if (_businessProcess != null) {
					_businessProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _businessProcess;
		/// <summary>
		/// Business process.
		/// </summary>
		public VwProcessLib BusinessProcess {
			get {
				return _businessProcess ??
					(_businessProcess = new VwProcessLib(LookupColumnEntities.GetEntity("BusinessProcess")));
			}
		}

		#endregion

	}

	#endregion

}

