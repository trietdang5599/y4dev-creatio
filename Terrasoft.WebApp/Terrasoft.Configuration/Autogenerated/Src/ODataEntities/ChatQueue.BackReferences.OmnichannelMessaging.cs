namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: ChatQueue

	/// <exclude/>
	public class ChatQueue : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ChatQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatQueue";
		}

		public ChatQueue(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ChatQueue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Channel> ChannelCollectionByChatQueue {
			get;
			set;
		}

		public IEnumerable<ChatQueueOperator> ChatQueueOperatorCollectionByChatQueue {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<OmniChatAction> OmniChatActionCollectionByChatQueue {
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
		/// Simultaneous Chats.
		/// </summary>
		public int SimultaneousChats {
			get {
				return GetTypedColumnValue<int>("SimultaneousChats");
			}
			set {
				SetColumnValue("SimultaneousChats", value);
			}
		}

		/// <summary>
		/// Chat timeout, minutes.
		/// </summary>
		public int ChatTimeout {
			get {
				return GetTypedColumnValue<int>("ChatTimeout");
			}
			set {
				SetColumnValue("ChatTimeout", value);
			}
		}

		/// <summary>
		/// Time to wait in queue.
		/// </summary>
		public int TimeToWaitInQueue {
			get {
				return GetTypedColumnValue<int>("TimeToWaitInQueue");
			}
			set {
				SetColumnValue("TimeToWaitInQueue", value);
			}
		}

		/// <summary>
		/// Ongoing response time, minutes.
		/// </summary>
		/// <remarks>
		/// Maximum time allowed for the agent to reply to customer messages during an active chat before it becomes overdue.
		/// </remarks>
		public int OngoingResponseTime {
			get {
				return GetTypedColumnValue<int>("OngoingResponseTime");
			}
			set {
				SetColumnValue("OngoingResponseTime", value);
			}
		}

		/// <summary>
		/// First response time, minutes.
		/// </summary>
		/// <remarks>
		/// Maximum time allowed for the agent to send the first reply before the chat becomes overdue.
		/// </remarks>
		public int FirstResponseTime {
			get {
				return GetTypedColumnValue<int>("FirstResponseTime");
			}
			set {
				SetColumnValue("FirstResponseTime", value);
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
		public Guid OperatorRoutingRuleId {
			get {
				return GetTypedColumnValue<Guid>("OperatorRoutingRuleId");
			}
			set {
				SetColumnValue("OperatorRoutingRuleId", value);
				_operatorRoutingRule = null;
			}
		}

		/// <exclude/>
		public string OperatorRoutingRuleName {
			get {
				return GetTypedColumnValue<string>("OperatorRoutingRuleName");
			}
			set {
				SetColumnValue("OperatorRoutingRuleName", value);
				if (_operatorRoutingRule != null) {
					_operatorRoutingRule.Name = value;
				}
			}
		}

		private OperatorRoutingRules _operatorRoutingRule;
		/// <summary>
		/// Routing rule.
		/// </summary>
		public OperatorRoutingRules OperatorRoutingRule {
			get {
				return _operatorRoutingRule ??
					(_operatorRoutingRule = new OperatorRoutingRules(LookupColumnEntities.GetEntity("OperatorRoutingRule")));
			}
		}

		#endregion

	}

	#endregion

}

