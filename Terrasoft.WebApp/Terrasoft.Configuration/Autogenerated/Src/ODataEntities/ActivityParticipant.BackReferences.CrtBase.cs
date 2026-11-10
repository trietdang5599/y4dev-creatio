namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: ActivityParticipant

	/// <exclude/>
	public class ActivityParticipant : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActivityParticipant(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityParticipant";
		}

		public ActivityParticipant(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActivityParticipant";
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
		/// Description.
		/// </summary>
		/// <remarks>
		/// Holds optional notes describing the participant’s role or contribution.
		/// </remarks>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Email opened mark.
		/// </summary>
		/// <remarks>
		/// Indicates whether the participant has viewed or acknowledged the meeting invitation.
		/// </remarks>
		public bool ReadMark {
			get {
				return GetTypedColumnValue<bool>("ReadMark");
			}
			set {
				SetColumnValue("ReadMark", value);
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
		/// Send invite to participant.
		/// </summary>
		/// <remarks>
		/// Shows whether an invitation was sent to this participant through a connected calendar.
		/// </remarks>
		public bool InviteParticipant {
			get {
				return GetTypedColumnValue<bool>("InviteParticipant");
			}
			set {
				SetColumnValue("InviteParticipant", value);
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
		/// Links the participant to the related meeting or calendar event.
		/// </remarks>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
			}
		}

		/// <exclude/>
		public Guid ParticipantId {
			get {
				return GetTypedColumnValue<Guid>("ParticipantId");
			}
			set {
				SetColumnValue("ParticipantId", value);
				_participant = null;
			}
		}

		/// <exclude/>
		public string ParticipantName {
			get {
				return GetTypedColumnValue<string>("ParticipantName");
			}
			set {
				SetColumnValue("ParticipantName", value);
				if (_participant != null) {
					_participant.Name = value;
				}
			}
		}

		private Contact _participant;
		/// <summary>
		/// Participant.
		/// </summary>
		/// <remarks>
		/// Specifies the contact invited or included in the meeting.
		/// </remarks>
		public Contact Participant {
			get {
				return _participant ??
					(_participant = new Contact(LookupColumnEntities.GetEntity("Participant")));
			}
		}

		/// <exclude/>
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private ActivityParticipantRole _role;
		/// <summary>
		/// Role.
		/// </summary>
		/// <remarks>
		/// Defines the participant’s role in the meeting, such as organizer, required, or optional attendee.
		/// </remarks>
		public ActivityParticipantRole Role {
			get {
				return _role ??
					(_role = new ActivityParticipantRole(LookupColumnEntities.GetEntity("Role")));
			}
		}

		/// <exclude/>
		public Guid InviteResponseId {
			get {
				return GetTypedColumnValue<Guid>("InviteResponseId");
			}
			set {
				SetColumnValue("InviteResponseId", value);
				_inviteResponse = null;
			}
		}

		/// <exclude/>
		public string InviteResponseName {
			get {
				return GetTypedColumnValue<string>("InviteResponseName");
			}
			set {
				SetColumnValue("InviteResponseName", value);
				if (_inviteResponse != null) {
					_inviteResponse.Name = value;
				}
			}
		}

		private ParticipantResponse _inviteResponse;
		/// <summary>
		/// Invite response.
		/// </summary>
		/// <remarks>
		/// Captures the participant’s response to the invitation, such as accepted, declined, or tentative.
		/// </remarks>
		public ParticipantResponse InviteResponse {
			get {
				return _inviteResponse ??
					(_inviteResponse = new ParticipantResponse(LookupColumnEntities.GetEntity("InviteResponse")));
			}
		}

		#endregion

	}

	#endregion

}

