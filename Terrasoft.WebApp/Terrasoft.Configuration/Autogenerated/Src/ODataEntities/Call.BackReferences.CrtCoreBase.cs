namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: Call

	/// <exclude/>
	public class Call : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Call(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call";
		}

		public Call(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Call";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CallEventInbox> CallEventInboxCollectionByCall {
			get;
			set;
		}

		public IEnumerable<CallFile> CallFileCollectionByCall {
			get;
			set;
		}

		public IEnumerable<CallInFolder> CallInFolderCollectionByCall {
			get;
			set;
		}

		public IEnumerable<CallInTag> CallInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<SysActiveCall> SysActiveCallCollectionByCall {
			get;
			set;
		}

		public IEnumerable<SysActiveCall> SysActiveCallCollectionByParentCall {
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
		/// Call Id.
		/// </summary>
		/// <remarks>
		/// Connects the call to its telephony source to verify call authenticity and origin.
		/// </remarks>
		public string IntegrationId {
			get {
				return GetTypedColumnValue<string>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <summary>
		/// Source call Id.
		/// </summary>
		/// <remarks>
		/// Links related calls, such as transfers or escalations, to show the full customer conversation path.
		/// </remarks>
		public string ParentCallId {
			get {
				return GetTypedColumnValue<string>("ParentCallId");
			}
			set {
				SetColumnValue("ParentCallId", value);
			}
		}

		/// <summary>
		/// From.
		/// </summary>
		/// <remarks>
		/// Represents the person or agent who initiated the call for engagement tracking.
		/// </remarks>
		public string CallerId {
			get {
				return GetTypedColumnValue<string>("CallerId");
			}
			set {
				SetColumnValue("CallerId", value);
			}
		}

		/// <summary>
		/// To.
		/// </summary>
		/// <remarks>
		/// Represents the person or customer who received the call for interaction analysis.
		/// </remarks>
		public string CalledId {
			get {
				return GetTypedColumnValue<string>("CalledId");
			}
			set {
				SetColumnValue("CalledId", value);
			}
		}

		/// <summary>
		/// Redirecting extension.
		/// </summary>
		/// <remarks>
		/// The subscriber extension, which transferred the call.
		/// </remarks>
		public string RedirectingId {
			get {
				return GetTypedColumnValue<string>("RedirectingId");
			}
			set {
				SetColumnValue("RedirectingId", value);
			}
		}

		/// <summary>
		/// Redirecting to extension.
		/// </summary>
		/// <remarks>
		/// The subscriber extension at which the call was transferred.
		/// </remarks>
		public string RedirectionId {
			get {
				return GetTypedColumnValue<string>("RedirectionId");
			}
			set {
				SetColumnValue("RedirectionId", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		/// <remarks>
		/// Marks when the customer conversation began for scheduling and service metrics.
		/// </remarks>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		/// <remarks>
		/// Marks when the call ended to measure total interaction time.
		/// </remarks>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Duration.
		/// </summary>
		/// <remarks>
		/// Reflects full call length in seconds to gauge responsiveness and customer engagement.
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
		/// Time to connect.
		/// </summary>
		/// <remarks>
		/// Shows how long the caller waited before speaking to an agent to assess service speed.
		/// </remarks>
		public int BeforeConnectionTime {
			get {
				return GetTypedColumnValue<int>("BeforeConnectionTime");
			}
			set {
				SetColumnValue("BeforeConnectionTime", value);
			}
		}

		/// <summary>
		/// Conversation time.
		/// </summary>
		/// <remarks>
		/// Captures active conversation time in seconds to measure customer engagement quality.
		/// </remarks>
		public int TalkTime {
			get {
				return GetTypedColumnValue<int>("TalkTime");
			}
			set {
				SetColumnValue("TalkTime", value);
			}
		}

		/// <summary>
		/// On hold time.
		/// </summary>
		/// <remarks>
		/// Tracks how long the customer was on hold to monitor experience and satisfaction.
		/// </remarks>
		public int HoldTime {
			get {
				return GetTypedColumnValue<int>("HoldTime");
			}
			set {
				SetColumnValue("HoldTime", value);
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
		/// Title.
		/// </summary>
		/// <remarks>
		/// Provides a brief title or summary describing the purpose or subject of the call.
		/// </remarks>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Comment.
		/// </summary>
		/// <remarks>
		/// Captures short notes or key highlights from the customer conversation.
		/// </remarks>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		/// <remarks>
		/// Stores detailed observations or context from the call for deeper understanding. Usually it is filled in by the agent.
		/// </remarks>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Globally unique call linkage Id.
		/// </summary>
		/// <remarks>
		/// Ensures consistent tracking of the same call across telephony systems for complete interaction history.
		/// </remarks>
		public string GloballyUniqueCallLinkageId {
			get {
				return GetTypedColumnValue<string>("GloballyUniqueCallLinkageId");
			}
			set {
				SetColumnValue("GloballyUniqueCallLinkageId", value);
			}
		}

		/// <summary>
		/// Correlation key.
		/// </summary>
		/// <remarks>
		/// Deterministic string IntegrationId|CallerId|CalledId|yyyy-MM-dd, used by UpdateCall to deduplicate concurrent create requests. Sized 500 chars: holds realistic concatenations of the contributing telephony id columns. Pathological inputs at the 250-char source limit can truncate beyond 500.
		/// </remarks>
		public string CorrelationKey {
			get {
				return GetTypedColumnValue<string>("CorrelationKey");
			}
			set {
				SetColumnValue("CorrelationKey", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
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
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private CallDirection _direction;
		/// <summary>
		/// Call direction.
		/// </summary>
		/// <remarks>
		/// Specifies whether the call was inbound or outbound to analyze engagement patterns.
		/// </remarks>
		public CallDirection Direction {
			get {
				return _direction ??
					(_direction = new CallDirection(LookupColumnEntities.GetEntity("Direction")));
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		/// <remarks>
		/// Connects the call to the customer contact to build a complete communication history.
		/// </remarks>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		/// <remarks>
		/// Associates the call with the customer’s organization (Account) for account-level insights.
		/// </remarks>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private ActivityResult _result;
		/// <summary>
		/// Result.
		/// </summary>
		/// <remarks>
		/// Summarizes the call outcome to evaluate success, resolution, or next steps. Usually it is filled in by the agent.
		/// </remarks>
		public ActivityResult Result {
			get {
				return _result ??
					(_result = new ActivityResult(LookupColumnEntities.GetEntity("Result")));
			}
		}

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		/// <remarks>
		/// Links the call to a related customer activity to view the broader relationship context.
		/// </remarks>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
			}
		}

		#endregion

	}

	#endregion

}

