namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: Activity

	/// <exclude/>
	public class Activity : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Activity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity";
		}

		public Activity(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Activity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByActivityConnection {
			get;
			set;
		}

		public IEnumerable<ActivityCorrespondence> ActivityCorrespondenceCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityFile> ActivityFileCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityInFolder> ActivityInFolderCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityInTag> ActivityInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<ActivityParticipant> ActivityParticipantCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<EmailMessageData> EmailMessageDataCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<EmailMetadata> EmailMetadataCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<EmailRelation> EmailRelationCollectionByEmail {
			get;
			set;
		}

		public IEnumerable<EmailTemplateActivity> EmailTemplateActivityCollectionByActivity {
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
		/// Subject.
		/// </summary>
		/// <remarks>
		/// Summarizes the activity’s subject to clarify purpose at a glance.
		/// </remarks>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
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
		/// Start.
		/// </summary>
		/// <remarks>
		/// Marks when the activity is planned to begin.
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
		/// Due.
		/// </summary>
		/// <remarks>
		/// Indicates the planned end time or deadline.
		/// </remarks>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Remind reporter.
		/// </summary>
		/// <remarks>
		/// Controls whether the author receives a reminder.
		/// </remarks>
		public bool RemindToAuthor {
			get {
				return GetTypedColumnValue<bool>("RemindToAuthor");
			}
			set {
				SetColumnValue("RemindToAuthor", value);
			}
		}

		/// <summary>
		/// Remind author on.
		/// </summary>
		/// <remarks>
		/// Specifies when to remind the author.
		/// </remarks>
		public DateTime RemindToAuthorDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToAuthorDate");
			}
			set {
				SetColumnValue("RemindToAuthorDate", value);
			}
		}

		/// <summary>
		/// Remind owner.
		/// </summary>
		/// <remarks>
		/// Controls whether the owner receives a reminder.
		/// </remarks>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <summary>
		/// Remind owner on.
		/// </summary>
		/// <remarks>
		/// Specifies when to remind the owner.
		/// </remarks>
		public DateTime RemindToOwnerDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			}
			set {
				SetColumnValue("RemindToOwnerDate", value);
			}
		}

		/// <summary>
		/// Show in calendar.
		/// </summary>
		/// <remarks>
		/// Defines if the activity should be shown in the calendar.
		/// </remarks>
		public bool ShowInScheduler {
			get {
				return GetTypedColumnValue<bool>("ShowInScheduler");
			}
			set {
				SetColumnValue("ShowInScheduler", value);
			}
		}

		/// <summary>
		/// Result details.
		/// </summary>
		/// <remarks>
		/// Provides additional outcome details for context.
		/// </remarks>
		public string DetailedResult {
			get {
				return GetTypedColumnValue<string>("DetailedResult");
			}
			set {
				SetColumnValue("DetailedResult", value);
			}
		}

		/// <summary>
		/// From.
		/// </summary>
		/// <remarks>
		/// Shows who sent the email message.
		/// </remarks>
		public string Sender {
			get {
				return GetTypedColumnValue<string>("Sender");
			}
			set {
				SetColumnValue("Sender", value);
			}
		}

		/// <summary>
		/// To.
		/// </summary>
		/// <remarks>
		/// Lists primary recipients of the message.
		/// </remarks>
		public string Recepient {
			get {
				return GetTypedColumnValue<string>("Recepient");
			}
			set {
				SetColumnValue("Recepient", value);
			}
		}

		/// <summary>
		/// Cc.
		/// </summary>
		/// <remarks>
		/// Lists copied recipients for visibility.
		/// </remarks>
		public string CopyRecepient {
			get {
				return GetTypedColumnValue<string>("CopyRecepient");
			}
			set {
				SetColumnValue("CopyRecepient", value);
			}
		}

		/// <summary>
		/// Bcc.
		/// </summary>
		/// <remarks>
		/// Lists hidden recipients for discreet sharing (email BCC).
		/// </remarks>
		public string BlindCopyRecepient {
			get {
				return GetTypedColumnValue<string>("BlindCopyRecepient");
			}
			set {
				SetColumnValue("BlindCopyRecepient", value);
			}
		}

		/// <summary>
		/// Body.
		/// </summary>
		/// <remarks>
		/// Contains the message content or meeting description.
		/// </remarks>
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
		/// <remarks>
		/// Holds internal notes or description relevant to the activity.
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
		/// Color.
		/// </summary>
		/// <remarks>
		/// Color of task.
		/// </remarks>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Sent on.
		/// </summary>
		/// <remarks>
		/// Records when the email message was sent.
		/// </remarks>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		/// <summary>
		/// Duration (minutes).
		/// </summary>
		/// <remarks>
		/// Shows planned or actual length in minutes to guide time tracking.
		/// </remarks>
		public int DurationInMinutes {
			get {
				return GetTypedColumnValue<int>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Email status details.
		/// </summary>
		/// <remarks>
		/// Captures email send errors to support troubleshooting.
		/// </remarks>
		public string ErrorOnSend {
			get {
				return GetTypedColumnValue<string>("ErrorOnSend");
			}
			set {
				SetColumnValue("ErrorOnSend", value);
			}
		}

		/// <summary>
		/// Duration (hours, minutes).
		/// </summary>
		/// <remarks>
		/// Provides a human-readable duration in minutes and hours for quick review.
		/// </remarks>
		public string DurationInMnutesAndHours {
			get {
				return GetTypedColumnValue<string>("DurationInMnutesAndHours");
			}
			set {
				SetColumnValue("DurationInMnutesAndHours", value);
			}
		}

		/// <summary>
		/// Possible results.
		/// </summary>
		/// <remarks>
		/// Limits which outcomes can be selected for this activity.
		/// </remarks>
		public string AllowedResult {
			get {
				return GetTypedColumnValue<string>("AllowedResult");
			}
			set {
				SetColumnValue("AllowedResult", value);
			}
		}

		/// <summary>
		/// Created in InvisibleCRM.
		/// </summary>
		public bool CreatedByInvCRM {
			get {
				return GetTypedColumnValue<bool>("CreatedByInvCRM");
			}
			set {
				SetColumnValue("CreatedByInvCRM", value);
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
		/// IsHtmlBody.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Hash code.
		/// </summary>
		/// <remarks>
		/// Helps group related messages into a conversation.
		/// </remarks>
		public string MailHash {
			get {
				return GetTypedColumnValue<string>("MailHash");
			}
			set {
				SetColumnValue("MailHash", value);
			}
		}

		/// <summary>
		/// Process item.
		/// </summary>
		/// <remarks>
		/// Links the activity to a workflow step for context.
		/// </remarks>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
			}
		}

		/// <summary>
		/// Outlook activity global identifier.
		/// </summary>
		/// <remarks>
		/// Supports cross-system identification of the same activity.
		/// </remarks>
		public string GlobalActivityID {
			get {
				return GetTypedColumnValue<string>("GlobalActivityID");
			}
			set {
				SetColumnValue("GlobalActivityID", value);
			}
		}

		/// <summary>
		/// Needs processing.
		/// </summary>
		/// <remarks>
		/// Marks processed email messages.
		/// </remarks>
		public bool IsNeedProcess {
			get {
				return GetTypedColumnValue<bool>("IsNeedProcess");
			}
			set {
				SetColumnValue("IsNeedProcess", value);
			}
		}

		/// <summary>
		/// Header Properties.
		/// </summary>
		/// <remarks>
		/// Stores email message header details used for routing and traceability.
		/// </remarks>
		public string HeaderProperties {
			get {
				return GetTypedColumnValue<string>("HeaderProperties");
			}
			set {
				SetColumnValue("HeaderProperties", value);
			}
		}

		/// <summary>
		/// Is auto submitted.
		/// </summary>
		/// <remarks>
		/// Flags activities captured automatically from external sources.
		/// </remarks>
		public bool IsAutoSubmitted {
			get {
				return GetTypedColumnValue<bool>("IsAutoSubmitted");
			}
			set {
				SetColumnValue("IsAutoSubmitted", value);
			}
		}

		/// <summary>
		/// Preview.
		/// </summary>
		/// <remarks>
		/// Shows a short snippet of the message content.
		/// </remarks>
		public string Preview {
			get {
				return GetTypedColumnValue<string>("Preview");
			}
			set {
				SetColumnValue("Preview", value);
			}
		}

		/// <summary>
		/// Enrichment status.
		/// </summary>
		public string EnrichStatus {
			get {
				return GetTypedColumnValue<string>("EnrichStatus");
			}
			set {
				SetColumnValue("EnrichStatus", value);
			}
		}

		/// <summary>
		/// User email.
		/// </summary>
		public string UserEmailAddress {
			get {
				return GetTypedColumnValue<string>("UserEmailAddress");
			}
			set {
				SetColumnValue("UserEmailAddress", value);
			}
		}

		/// <summary>
		/// Location.
		/// </summary>
		public string Location {
			get {
				return GetTypedColumnValue<string>("Location");
			}
			set {
				SetColumnValue("Location", value);
			}
		}

		/// <summary>
		/// Remote calendar created on.
		/// </summary>
		public DateTime RemoteCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("RemoteCreatedOn");
			}
			set {
				SetColumnValue("RemoteCreatedOn", value);
			}
		}

		/// <summary>
		/// Is AI generated.
		/// </summary>
		/// <remarks>
		/// Indicates that the reply was generated by AI.
		/// </remarks>
		public bool IsAiGenerated {
			get {
				return GetTypedColumnValue<bool>("IsAiGenerated");
			}
			set {
				SetColumnValue("IsAiGenerated", value);
			}
		}

		/// <summary>
		/// Is AI generated unchanged.
		/// </summary>
		/// <remarks>
		/// Indicates the email body is still the unmodified AI-generated text; cleared on the first body change.
		/// </remarks>
		public bool IsAiGeneratedUnchanged {
			get {
				return GetTypedColumnValue<bool>("IsAiGeneratedUnchanged");
			}
			set {
				SetColumnValue("IsAiGeneratedUnchanged", value);
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
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ActivityPriority _priority;
		/// <summary>
		/// Priority.
		/// </summary>
		/// <remarks>
		/// Sets the activity’s urgency to guide scheduling.
		/// </remarks>
		public ActivityPriority Priority {
			get {
				return _priority ??
					(_priority = new ActivityPriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Reporter.
		/// </summary>
		/// <remarks>
		/// Shows the originator or author of the activity content.
		/// </remarks>
		public Contact Author {
			get {
				return _author ??
					(_author = new Contact(LookupColumnEntities.GetEntity("Author")));
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
		/// <remarks>
		/// Assigns the person responsible for the activity.
		/// </remarks>
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

		private ActivityType _type;
		/// <summary>
		/// Type.
		/// </summary>
		/// <remarks>
		/// Defines the activity type, such as meeting, email, task, or call.
		/// </remarks>
		public ActivityType Type {
			get {
				return _type ??
					(_type = new ActivityType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid ActivityCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ActivityCategoryId");
			}
			set {
				SetColumnValue("ActivityCategoryId", value);
				_activityCategory = null;
			}
		}

		/// <exclude/>
		public string ActivityCategoryName {
			get {
				return GetTypedColumnValue<string>("ActivityCategoryName");
			}
			set {
				SetColumnValue("ActivityCategoryName", value);
				if (_activityCategory != null) {
					_activityCategory.Name = value;
				}
			}
		}

		private ActivityCategory _activityCategory;
		/// <summary>
		/// Category.
		/// </summary>
		/// <remarks>
		/// Groups the activity for reporting and planning.
		/// </remarks>
		public ActivityCategory ActivityCategory {
			get {
				return _activityCategory ??
					(_activityCategory = new ActivityCategory(LookupColumnEntities.GetEntity("ActivityCategory")));
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

		private ActivityStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		/// <remarks>
		/// Shows the current state, such as planned, completed, or canceled.
		/// </remarks>
		public ActivityStatus Status {
			get {
				return _status ??
					(_status = new ActivityStatus(LookupColumnEntities.GetEntity("Status")));
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
		/// Captures the outcome to evaluate success and next steps.
		/// </remarks>
		public ActivityResult Result {
			get {
				return _result ??
					(_result = new ActivityResult(LookupColumnEntities.GetEntity("Result")));
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Time zone.
		/// </summary>
		/// <remarks>
		/// Specifies the time zone for correct scheduling.
		/// </remarks>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = new TimeZone(LookupColumnEntities.GetEntity("TimeZone")));
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
		/// Links the activity to the related organization (Account).
		/// </remarks>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
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
		/// Links the activity to the related person (Contact).
		/// </remarks>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid EmailSendStatusId {
			get {
				return GetTypedColumnValue<Guid>("EmailSendStatusId");
			}
			set {
				SetColumnValue("EmailSendStatusId", value);
				_emailSendStatus = null;
			}
		}

		/// <exclude/>
		public string EmailSendStatusName {
			get {
				return GetTypedColumnValue<string>("EmailSendStatusName");
			}
			set {
				SetColumnValue("EmailSendStatusName", value);
				if (_emailSendStatus != null) {
					_emailSendStatus.Name = value;
				}
			}
		}

		private EmailSendStatus _emailSendStatus;
		/// <summary>
		/// Email status.
		/// </summary>
		/// <remarks>
		/// Indicates whether the email was sent successfully.
		/// </remarks>
		public EmailSendStatus EmailSendStatus {
			get {
				return _emailSendStatus ??
					(_emailSendStatus = new EmailSendStatus(LookupColumnEntities.GetEntity("EmailSendStatus")));
			}
		}

		/// <exclude/>
		public Guid MessageTypeId {
			get {
				return GetTypedColumnValue<Guid>("MessageTypeId");
			}
			set {
				SetColumnValue("MessageTypeId", value);
				_messageType = null;
			}
		}

		/// <exclude/>
		public string MessageTypeName {
			get {
				return GetTypedColumnValue<string>("MessageTypeName");
			}
			set {
				SetColumnValue("MessageTypeName", value);
				if (_messageType != null) {
					_messageType.Name = value;
				}
			}
		}

		private EmailType _messageType;
		/// <summary>
		/// Message type.
		/// </summary>
		/// <remarks>
		/// Specifies the communication medium, such as email or message.
		/// </remarks>
		public EmailType MessageType {
			get {
				return _messageType ??
					(_messageType = new EmailType(LookupColumnEntities.GetEntity("MessageType")));
			}
		}

		/// <exclude/>
		public Guid ActivityConnectionId {
			get {
				return GetTypedColumnValue<Guid>("ActivityConnectionId");
			}
			set {
				SetColumnValue("ActivityConnectionId", value);
				_activityConnection = null;
			}
		}

		/// <exclude/>
		public string ActivityConnectionTitle {
			get {
				return GetTypedColumnValue<string>("ActivityConnectionTitle");
			}
			set {
				SetColumnValue("ActivityConnectionTitle", value);
				if (_activityConnection != null) {
					_activityConnection.Title = value;
				}
			}
		}

		private Activity _activityConnection;
		/// <summary>
		/// Activity.
		/// </summary>
		/// <remarks>
		/// Associates the activity with a related business context.
		/// </remarks>
		public Activity ActivityConnection {
			get {
				return _activityConnection ??
					(_activityConnection = new Activity(LookupColumnEntities.GetEntity("ActivityConnection")));
			}
		}

		/// <exclude/>
		public Guid OrganizerId {
			get {
				return GetTypedColumnValue<Guid>("OrganizerId");
			}
			set {
				SetColumnValue("OrganizerId", value);
				_organizer = null;
			}
		}

		/// <exclude/>
		public string OrganizerName {
			get {
				return GetTypedColumnValue<string>("OrganizerName");
			}
			set {
				SetColumnValue("OrganizerName", value);
				if (_organizer != null) {
					_organizer.Name = value;
				}
			}
		}

		private Contact _organizer;
		/// <summary>
		/// Organizer.
		/// </summary>
		/// <remarks>
		/// Identifies the meeting organizer.
		/// </remarks>
		public Contact Organizer {
			get {
				return _organizer ??
					(_organizer = new Contact(LookupColumnEntities.GetEntity("Organizer")));
			}
		}

		/// <exclude/>
		public Guid CallDirectionId {
			get {
				return GetTypedColumnValue<Guid>("CallDirectionId");
			}
			set {
				SetColumnValue("CallDirectionId", value);
				_callDirection = null;
			}
		}

		/// <exclude/>
		public string CallDirectionName {
			get {
				return GetTypedColumnValue<string>("CallDirectionName");
			}
			set {
				SetColumnValue("CallDirectionName", value);
				if (_callDirection != null) {
					_callDirection.Name = value;
				}
			}
		}

		private CallDirection _callDirection;
		/// <summary>
		/// Call direction.
		/// </summary>
		public CallDirection CallDirection {
			get {
				return _callDirection ??
					(_callDirection = new CallDirection(LookupColumnEntities.GetEntity("CallDirection")));
			}
		}

		/// <exclude/>
		public Guid SenderContactId {
			get {
				return GetTypedColumnValue<Guid>("SenderContactId");
			}
			set {
				SetColumnValue("SenderContactId", value);
				_senderContact = null;
			}
		}

		/// <exclude/>
		public string SenderContactName {
			get {
				return GetTypedColumnValue<string>("SenderContactName");
			}
			set {
				SetColumnValue("SenderContactName", value);
				if (_senderContact != null) {
					_senderContact.Name = value;
				}
			}
		}

		private Contact _senderContact;
		/// <summary>
		/// Sender contact.
		/// </summary>
		/// <remarks>
		/// Links the sender to a known contact.
		/// </remarks>
		public Contact SenderContact {
			get {
				return _senderContact ??
					(_senderContact = new Contact(LookupColumnEntities.GetEntity("SenderContact")));
			}
		}

		/// <exclude/>
		public Guid OmniChatId {
			get {
				return GetTypedColumnValue<Guid>("OmniChatId");
			}
			set {
				SetColumnValue("OmniChatId", value);
				_omniChat = null;
			}
		}

		/// <exclude/>
		public string OmniChatName {
			get {
				return GetTypedColumnValue<string>("OmniChatName");
			}
			set {
				SetColumnValue("OmniChatName", value);
				if (_omniChat != null) {
					_omniChat.Name = value;
				}
			}
		}

		private OmniChat _omniChat;
		/// <summary>
		/// Chat.
		/// </summary>
		public OmniChat OmniChat {
			get {
				return _omniChat ??
					(_omniChat = new OmniChat(LookupColumnEntities.GetEntity("OmniChat")));
			}
		}

		/// <exclude/>
		public Guid EnrchEmailDataId {
			get {
				return GetTypedColumnValue<Guid>("EnrchEmailDataId");
			}
			set {
				SetColumnValue("EnrchEmailDataId", value);
				_enrchEmailData = null;
			}
		}

		/// <exclude/>
		public string EnrchEmailDataHash {
			get {
				return GetTypedColumnValue<string>("EnrchEmailDataHash");
			}
			set {
				SetColumnValue("EnrchEmailDataHash", value);
				if (_enrchEmailData != null) {
					_enrchEmailData.Hash = value;
				}
			}
		}

		private EnrchEmailData _enrchEmailData;
		/// <summary>
		/// Parsed e-mail.
		/// </summary>
		public EnrchEmailData EnrchEmailData {
			get {
				return _enrchEmailData ??
					(_enrchEmailData = new EnrchEmailData(LookupColumnEntities.GetEntity("EnrchEmailData")));
			}
		}

		/// <exclude/>
		public Guid OwnerRoleId {
			get {
				return GetTypedColumnValue<Guid>("OwnerRoleId");
			}
			set {
				SetColumnValue("OwnerRoleId", value);
				_ownerRole = null;
			}
		}

		/// <exclude/>
		public string OwnerRoleName {
			get {
				return GetTypedColumnValue<string>("OwnerRoleName");
			}
			set {
				SetColumnValue("OwnerRoleName", value);
				if (_ownerRole != null) {
					_ownerRole.Name = value;
				}
			}
		}

		private VwSysRole _ownerRole;
		/// <summary>
		/// Role.
		/// </summary>
		/// <remarks>
		/// Captures the role of the activity owner for routing.
		/// </remarks>
		public VwSysRole OwnerRole {
			get {
				return _ownerRole ??
					(_ownerRole = new VwSysRole(LookupColumnEntities.GetEntity("OwnerRole")));
			}
		}

		/// <exclude/>
		public Guid MeetingPlatformId {
			get {
				return GetTypedColumnValue<Guid>("MeetingPlatformId");
			}
			set {
				SetColumnValue("MeetingPlatformId", value);
				_meetingPlatform = null;
			}
		}

		/// <exclude/>
		public string MeetingPlatformName {
			get {
				return GetTypedColumnValue<string>("MeetingPlatformName");
			}
			set {
				SetColumnValue("MeetingPlatformName", value);
				if (_meetingPlatform != null) {
					_meetingPlatform.Name = value;
				}
			}
		}

		private MeetingPlatform _meetingPlatform;
		/// <summary>
		/// Meeting platform.
		/// </summary>
		public MeetingPlatform MeetingPlatform {
			get {
				return _meetingPlatform ??
					(_meetingPlatform = new MeetingPlatform(LookupColumnEntities.GetEntity("MeetingPlatform")));
			}
		}

		/// <exclude/>
		public Guid MeetingTranscriptId {
			get {
				return GetTypedColumnValue<Guid>("MeetingTranscriptId");
			}
			set {
				SetColumnValue("MeetingTranscriptId", value);
				_meetingTranscript = null;
			}
		}

		/// <exclude/>
		public string MeetingTranscriptMeetingSummary {
			get {
				return GetTypedColumnValue<string>("MeetingTranscriptMeetingSummary");
			}
			set {
				SetColumnValue("MeetingTranscriptMeetingSummary", value);
				if (_meetingTranscript != null) {
					_meetingTranscript.MeetingSummary = value;
				}
			}
		}

		private MeetingTranscript _meetingTranscript;
		/// <summary>
		/// Meeting transcript.
		/// </summary>
		public MeetingTranscript MeetingTranscript {
			get {
				return _meetingTranscript ??
					(_meetingTranscript = new MeetingTranscript(LookupColumnEntities.GetEntity("MeetingTranscript")));
			}
		}

		#endregion

	}

	#endregion

}

