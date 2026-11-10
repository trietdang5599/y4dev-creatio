namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: OmniChat

	/// <exclude/>
	public class OmniChat : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OmniChat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChat";
		}

		public OmniChat(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OmniChat";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByOmniChat {
			get;
			set;
		}

		public IEnumerable<ChatMessages> ChatMessagesCollectionByOmniChat {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByParent {
			get;
			set;
		}

		public IEnumerable<OmniChatFile> OmniChatFileCollectionByOmniChat {
			get;
			set;
		}

		public IEnumerable<OmniChatInFolder> OmniChatInFolderCollectionByOmniChat {
			get;
			set;
		}

		public IEnumerable<OmniChatInTag> OmniChatInTagCollectionByEntity {
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
		/// Chat timeout completion date.
		/// </summary>
		public DateTime CloseDate {
			get {
				return GetTypedColumnValue<DateTime>("CloseDate");
			}
			set {
				SetColumnValue("CloseDate", value);
			}
		}

		/// <summary>
		/// Chat preview.
		/// </summary>
		public string ChatPreview {
			get {
				return GetTypedColumnValue<string>("ChatPreview");
			}
			set {
				SetColumnValue("ChatPreview", value);
			}
		}

		/// <summary>
		/// Chat conversation.
		/// </summary>
		public string Conversation {
			get {
				return GetTypedColumnValue<string>("Conversation");
			}
			set {
				SetColumnValue("Conversation", value);
			}
		}

		/// <summary>
		/// Unprocessed messages count.
		/// </summary>
		public int UnprocessedMsgCount {
			get {
				return GetTypedColumnValue<int>("UnprocessedMsgCount");
			}
			set {
				SetColumnValue("UnprocessedMsgCount", value);
			}
		}

		/// <summary>
		/// Chat start date.
		/// </summary>
		public DateTime ChatStartDate {
			get {
				return GetTypedColumnValue<DateTime>("ChatStartDate");
			}
			set {
				SetColumnValue("ChatStartDate", value);
			}
		}

		/// <summary>
		/// Chat last message date.
		/// </summary>
		public DateTime ChatEndDate {
			get {
				return GetTypedColumnValue<DateTime>("ChatEndDate");
			}
			set {
				SetColumnValue("ChatEndDate", value);
			}
		}

		/// <summary>
		/// Chat first reply time, sec.
		/// </summary>
		public int FirstReplyTime {
			get {
				return GetTypedColumnValue<int>("FirstReplyTime");
			}
			set {
				SetColumnValue("FirstReplyTime", value);
			}
		}

		/// <summary>
		/// Accept date.
		/// </summary>
		public DateTime AcceptDate {
			get {
				return GetTypedColumnValue<DateTime>("AcceptDate");
			}
			set {
				SetColumnValue("AcceptDate", value);
			}
		}

		/// <summary>
		/// Chat duration, min.
		/// </summary>
		public int ChatDuration {
			get {
				return GetTypedColumnValue<int>("ChatDuration");
			}
			set {
				SetColumnValue("ChatDuration", value);
			}
		}

		/// <summary>
		/// Chat actual completion date.
		/// </summary>
		public DateTime CompletionDate {
			get {
				return GetTypedColumnValue<DateTime>("CompletionDate");
			}
			set {
				SetColumnValue("CompletionDate", value);
			}
		}

		/// <summary>
		/// Last message direction.
		/// </summary>
		public int LastMessageDirection {
			get {
				return GetTypedColumnValue<int>("LastMessageDirection");
			}
			set {
				SetColumnValue("LastMessageDirection", value);
			}
		}

		/// <summary>
		/// Needs translation.
		/// </summary>
		/// <remarks>
		/// Indicates whether the chat requires translation.
		/// </remarks>
		public bool NeedsTranslation {
			get {
				return GetTypedColumnValue<bool>("NeedsTranslation");
			}
			set {
				SetColumnValue("NeedsTranslation", value);
			}
		}

		/// <summary>
		/// Last message date.
		/// </summary>
		public DateTime LastMessageDate {
			get {
				return GetTypedColumnValue<DateTime>("LastMessageDate");
			}
			set {
				SetColumnValue("LastMessageDate", value);
			}
		}

		/// <summary>
		/// Sender identity.
		/// </summary>
		/// <remarks>
		/// External sender identifier (e.g. WebChat visitorId) used for anonymous chat matching.
		/// </remarks>
		public string SenderIdentity {
			get {
				return GetTypedColumnValue<string>("SenderIdentity");
			}
			set {
				SetColumnValue("SenderIdentity", value);
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

		private OmnichannelChatStatus _status;
		/// <summary>
		/// Chat status.
		/// </summary>
		public OmnichannelChatStatus Status {
			get {
				return _status ??
					(_status = new OmnichannelChatStatus(LookupColumnEntities.GetEntity("Status")));
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
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private Channel _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public Channel Channel {
			get {
				return _channel ??
					(_channel = new Channel(LookupColumnEntities.GetEntity("Channel")));
			}
		}

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private SysAdminUnit _operator;
		/// <summary>
		/// Agent.
		/// </summary>
		public SysAdminUnit Operator {
			get {
				return _operator ??
					(_operator = new SysAdminUnit(LookupColumnEntities.GetEntity("Operator")));
			}
		}

		/// <exclude/>
		public Guid DirectedOperatorId {
			get {
				return GetTypedColumnValue<Guid>("DirectedOperatorId");
			}
			set {
				SetColumnValue("DirectedOperatorId", value);
				_directedOperator = null;
			}
		}

		/// <exclude/>
		public string DirectedOperatorName {
			get {
				return GetTypedColumnValue<string>("DirectedOperatorName");
			}
			set {
				SetColumnValue("DirectedOperatorName", value);
				if (_directedOperator != null) {
					_directedOperator.Name = value;
				}
			}
		}

		private SysAdminUnit _directedOperator;
		/// <summary>
		/// The operator who was directed.
		/// </summary>
		public SysAdminUnit DirectedOperator {
			get {
				return _directedOperator ??
					(_directedOperator = new SysAdminUnit(LookupColumnEntities.GetEntity("DirectedOperator")));
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private OmniChat _parent;
		/// <summary>
		/// Parent chat.
		/// </summary>
		/// <remarks>
		/// Parent chat for current chat.
		/// </remarks>
		public OmniChat Parent {
			get {
				return _parent ??
					(_parent = new OmniChat(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid QueueId {
			get {
				return GetTypedColumnValue<Guid>("QueueId");
			}
			set {
				SetColumnValue("QueueId", value);
				_queue = null;
			}
		}

		/// <exclude/>
		public string QueueName {
			get {
				return GetTypedColumnValue<string>("QueueName");
			}
			set {
				SetColumnValue("QueueName", value);
				if (_queue != null) {
					_queue.Name = value;
				}
			}
		}

		private ChatQueue _queue;
		/// <summary>
		/// Queue.
		/// </summary>
		/// <remarks>
		/// Queue of the Chat.
		/// </remarks>
		public ChatQueue Queue {
			get {
				return _queue ??
					(_queue = new ChatQueue(LookupColumnEntities.GetEntity("Queue")));
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Language.
		/// </summary>
		/// <remarks>
		/// The language in which the contact from this chat communicates.
		/// </remarks>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = new SysLanguage(LookupColumnEntities.GetEntity("Language")));
			}
		}

		/// <exclude/>
		public Guid TranslatedLangId {
			get {
				return GetTypedColumnValue<Guid>("TranslatedLangId");
			}
			set {
				SetColumnValue("TranslatedLangId", value);
				_translatedLang = null;
			}
		}

		/// <exclude/>
		public string TranslatedLangName {
			get {
				return GetTypedColumnValue<string>("TranslatedLangName");
			}
			set {
				SetColumnValue("TranslatedLangName", value);
				if (_translatedLang != null) {
					_translatedLang.Name = value;
				}
			}
		}

		private SysLanguage _translatedLang;
		/// <summary>
		/// The language the chat is translated into.
		/// </summary>
		/// <remarks>
		/// The language the chat was translated into at that time.
		/// </remarks>
		public SysLanguage TranslatedLang {
			get {
				return _translatedLang ??
					(_translatedLang = new SysLanguage(LookupColumnEntities.GetEntity("TranslatedLang")));
			}
		}

		/// <exclude/>
		public Guid ClosureReasonId {
			get {
				return GetTypedColumnValue<Guid>("ClosureReasonId");
			}
			set {
				SetColumnValue("ClosureReasonId", value);
				_closureReason = null;
			}
		}

		/// <exclude/>
		public string ClosureReasonName {
			get {
				return GetTypedColumnValue<string>("ClosureReasonName");
			}
			set {
				SetColumnValue("ClosureReasonName", value);
				if (_closureReason != null) {
					_closureReason.Name = value;
				}
			}
		}

		private ChatClosureReason _closureReason;
		/// <summary>
		/// Closure reason.
		/// </summary>
		public ChatClosureReason ClosureReason {
			get {
				return _closureReason ??
					(_closureReason = new ChatClosureReason(LookupColumnEntities.GetEntity("ClosureReason")));
			}
		}

		#endregion

	}

	#endregion

}

