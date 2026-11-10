namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Text;
	using EmailContract;
	using EmailContract.Commands;
	using EmailContract.DTO;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Client.Interfaces;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.DTO;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Repository.Interfaces;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.IntegrationV2.Utils;

	#region Class: GraphCalendarTransportAdapter

	[DefaultBinding(typeof(IGraphCalendarTransportAdapter))]
	internal class GraphCalendarTransportAdapter : IGraphCalendarTransportAdapter
	{

		#region Fields: Private

		private static readonly Guid ActivityLowPriorityId = new Guid("AC96FA02-7FE6-DF11-971B-001D60E938C6");

		private static readonly Guid ActivityNormalPriorityId = new Guid("AB96FA02-7FE6-DF11-971B-001D60E938C6");

		private static readonly Guid ActivityHighPriorityId = new Guid("D625A9FC-7EE6-DF11-971B-001D60E938C6");

		private readonly UserConnection _userConnection;

		private readonly IHttpWebRequestFactory _requestFactory;

		private readonly IMailboxService _mailboxService;

		private readonly ICalendarRepository _calendarRepository;

		private Guid _lastSyncPeriodCalendarId;

		private List<MeetingDto> _lastSyncPeriodDeletedMeetings = new List<MeetingDto>();

		#endregion

		#region Constructors: Public

		public GraphCalendarTransportAdapter(UserConnection userConnection, IHttpWebRequestFactory requestFactory = null,
				IMailboxService mailboxService = null)
				: this(userConnection, requestFactory, mailboxService, null) {
		}

		internal GraphCalendarTransportAdapter(UserConnection userConnection, IHttpWebRequestFactory requestFactory,
				IMailboxService mailboxService, ICalendarRepository calendarRepository) {
			_userConnection = userConnection;
			_requestFactory = requestFactory ?? ClassFactory.Get<IHttpWebRequestFactory>();
			_mailboxService = mailboxService ?? ClassFactory.Get<IMailboxService>(
				new ConstructorArgument("uc", userConnection));
			_calendarRepository = calendarRepository ?? ClassFactory.Get<ICalendarRepository>("CalendarRepository",
				new ConstructorArgument("uc", userConnection),
				new ConstructorArgument("sessionId", string.Empty));
		}

		#endregion

		#region Methods: Private

		private const string GraphCalendarExtensionName = "CreatioSync";

		private static byte[] Serialize(object command) {
			var json = Json.Serialize(command, true);
			return Encoding.UTF8.GetBytes(json);
		}

		private T SendCommand<T>(object command, string commandHandlerUri) {
			var rawResponse = SendCommand(Serialize(command), commandHandlerUri);
			return string.IsNullOrWhiteSpace(rawResponse)
				? default
				: Json.Deserialize<T>(rawResponse);
		}

		protected virtual string SendCommand(byte[] data, string commandHandlerUri) {
			WebRequest request = _requestFactory.Create(commandHandlerUri);
			request.Method = "POST";
			request.ContentType = "application/json; charset=utf-8";
			request.ContentLength = data.Length;
			request.Timeout = 5 * 60 * 1000;
			using (Stream stream = request.GetRequestStream()) {
				stream.Write(data, 0, data.Length);
			}
			using (WebResponse response = request.GetResponse()) {
				using (Stream dataStream = response.GetResponseStream()) {
					using (StreamReader reader = new StreamReader(dataStream)) {
						return reader.ReadToEnd();
					}
				}
			}
		}

		private SynchronizationCredentials GetSynchronizationCredentials(CalendarModel calendar) {
			Mailbox mailbox = _mailboxService.GetMailbox(calendar.Settings.Id);
			if (mailbox == null) {
				throw new InvalidOperationException($"Mailbox '{calendar.Settings.Id}' not found for graph calendar request.");
			}
			return mailbox.ConvertToSynchronizationCredentials(_userConnection);
		}

		private GraphCalendarSaveMeetingCommand CreateMeetingRequest(Meeting meeting, CalendarModel calendar,
				bool isOnlineMeeting) {
			var request = new GraphCalendarSaveMeetingCommand {
				Credentials = GetSynchronizationCredentials(calendar),
				Meeting = CreateMeetingDto(meeting, calendar),
				InvitesSent = meeting.InvitesSent
			};
			request.Meeting.IsOnlineMeeting = isOnlineMeeting;
			return request;
		}

		private GraphCalendarMeeting CreateMeetingDto(Meeting meeting, CalendarModel calendar) {
			var dto = new GraphCalendarMeeting {
				Id = meeting.RemoteId,
				ICalUId = meeting.ICalUid,
				Subject = meeting.Title,
				Body = meeting.Body,
				IsHtmlBody = true,
				StartDateUtc = new DateTimeOffset(meeting.StartDate.ToUniversalTime()),
				EndDateUtc = new DateTimeOffset(meeting.DueDate.ToUniversalTime()),
				OriginalStartTimeZone = meeting.StartTimeZone?.Id,
				OriginalEndTimeZone = meeting.EndTimeZone?.Id,
				Location = meeting.Location,
				PriorityId = GetEmailImportance(meeting.PriorityId),
				RemindToOwner = meeting.RemindToOwner,
				RemindToOwnerDateUtc = meeting.RemindToOwner
					? new DateTimeOffset(meeting.RemindToOwnerDate.ToUniversalTime())
					: default,
				RemoteCreatedOn = meeting.RemoteCreatedOn == DateTime.MinValue
					? default
					: new DateTimeOffset(meeting.RemoteCreatedOn.ToUniversalTime())
			};
			if (ShouldIncludeParticipants(meeting, calendar)) {
				dto.Attendees = CreateAttendees(meeting.Participants, calendar.Settings?.SenderEmailAddress);
			}
			return dto;
		}

		private string NormalizeEmailAddress(string emailAddress) {
			if (emailAddress.IsNullOrWhiteSpace()) {
				return string.Empty;
			}
			return emailAddress.ExtractEmailAddress().Trim().ToLowerInvariant();
		}

		private List<GraphCalendarAttendee> CreateAttendees(IEnumerable<Participant> participants, string organizerEmail) {
			string normalizedOrganizerEmail = NormalizeEmailAddress(organizerEmail);
			return participants
				.Select(participant => new {
					Participant = participant,
					EmailAddress = NormalizeEmailAddress(participant.EmailAddress)
				})
				.Where(item => item.EmailAddress.IsNotNullOrWhiteSpace() &&
					!item.EmailAddress.Equals(normalizedOrganizerEmail, StringComparison.InvariantCultureIgnoreCase))
				.GroupBy(item => item.EmailAddress, StringComparer.InvariantCultureIgnoreCase)
				.Select(group => new GraphCalendarAttendee {
					Address = group.Key,
					Name = group.Key,
					Type = group.First().Participant.IsRequired ? "required" : "optional"
				})
				.ToList();
		}

		private bool ShouldIncludeParticipants(Meeting meeting, CalendarModel calendar) {
			return !ListenerUtils.GetIsFeatureEnabled("GraphCalendarSkipAttendeesWhenInvitesNotSent")
				|| calendar.Type != IntegrationApi.Calendar.CalendarType.Graph
				|| meeting.InvitesSent;
		}

		private GraphCalendarGetSyncPeriodMeetingsCommand CreatePeriodRequest(CalendarModel calendar) {
			return new GraphCalendarGetSyncPeriodMeetingsCommand {
				Credentials = GetSynchronizationCredentials(calendar),
				StartDateUtc = new DateTimeOffset(calendar.SyncSinceDate.ToUniversalTime()),
				EndDateUtc = new DateTimeOffset(calendar.SyncTillDate.ToUniversalTime()),
				DeltaLink = calendar.GraphMeetingsDeltaLink
			};
		}

		private InvitationState ConvertInvitationState(string status) {
			switch ((status ?? string.Empty).Trim().ToLowerInvariant()) {
				case "accepted":
					return InvitationState.Confirmed;
				case "declined":
					return InvitationState.Declined;
				case "tentativelyaccepted":
					return InvitationState.InDoubt;
				default:
					return InvitationState.Empty;
			}
		}

		private InvitationState ConvertInvitationState(GraphCalendarInvitationState state) {
			switch (state) {
				case GraphCalendarInvitationState.Confirmed:
					return InvitationState.Confirmed;
				case GraphCalendarInvitationState.Declined:
					return InvitationState.Declined;
				case GraphCalendarInvitationState.InDoubt:
					return InvitationState.InDoubt;
				default:
					return InvitationState.Empty;
			}
		}

		private bool IsNonOrganizerEmail(string emailAddress, string organizerEmailAddress) {
			return emailAddress.IsNotNullOrWhiteSpace() &&
				(organizerEmailAddress.IsNullOrWhiteSpace() ||
					!emailAddress.Equals(organizerEmailAddress, StringComparison.InvariantCultureIgnoreCase));
		}

		private bool GetInvitesSent(GraphCalendarMeeting meeting) {
			if (meeting?.InvitesSent == true) {
				return true;
			}
			string organizerEmailAddress = NormalizeEmailAddress(meeting?.OrganizerEmail);
			var hasParticipants = meeting?.Participants?
				.Keys
				.Any(participantEmailAddress =>
					IsNonOrganizerEmail(NormalizeEmailAddress(participantEmailAddress), organizerEmailAddress)) == true;
			if (hasParticipants) {
				return true;
			}
			return meeting?.Attendees?
				.Any(attendee =>
					IsNonOrganizerEmail(NormalizeEmailAddress(attendee?.Address), organizerEmailAddress)) == true;
		}

		private void FillParticipants(GraphCalendarMeeting meeting, MeetingDto dto) {
			if (meeting?.Participants != null) {
				foreach (var participant in meeting.Participants
					.Where(participant => participant.Key.IsNotNullOrWhiteSpace())) {
					string emailAddress = NormalizeEmailAddress(participant.Key);
					if (emailAddress.IsNotNullOrWhiteSpace()) {
						dto.Participants[emailAddress] = ConvertInvitationState(participant.Value);
					}
				}
			}
			if (meeting?.Attendees == null) {
				return;
			}
			foreach (var attendee in meeting.Attendees.Where(a => a?.Address.IsNotNullOrWhiteSpace() == true)) {
				string emailAddress = NormalizeEmailAddress(attendee.Address);
				if (emailAddress.IsNullOrWhiteSpace()) {
					continue;
				}
				var invitationState = ConvertInvitationState(attendee.Status);
				if (!dto.Participants.TryGetValue(emailAddress, out var participantState) ||
						participantState == InvitationState.Empty) {
					dto.Participants[emailAddress] = invitationState;
				}
			}
		}

		private static EmailImportance GetEmailImportance(Guid activityPriorityId) {
			if (activityPriorityId == ActivityHighPriorityId) {
				return EmailImportance.High;
			} else if (activityPriorityId == ActivityLowPriorityId) {
				return EmailImportance.Low;
			}
			return EmailImportance.Normal;
		}

		private static Guid GetActivityPriorityId(EmailImportance importance) {
			switch (importance) {
				case EmailImportance.High:
					return ActivityHighPriorityId;
				case EmailImportance.Low:
					return ActivityLowPriorityId;
				default:
					return ActivityNormalPriorityId;
			}
		}

		private MeetingDto ConvertMeeting(GraphCalendarMeeting meeting) {
			var dto = new MeetingDto {
				RemoteId = meeting.Id ?? string.Empty,
				ICalUid = meeting.ICalUId ?? string.Empty,
				Title = meeting.Subject ?? string.Empty,
				Body = meeting.Body ?? string.Empty,
				Location = meeting.Location ?? string.Empty,
				StartDateUtc = meeting.StartDateUtc.UtcDateTime,
				DueDateUtc = meeting.EndDateUtc.UtcDateTime,
				PriorityId = GetActivityPriorityId(meeting.PriorityId),
				InvitesSent = GetInvitesSent(meeting),
				RemindToOwner = meeting.RemindToOwner,
				RemindToOwnerDateUtc = meeting.RemindToOwnerDateUtc.UtcDateTime,
				OrganizerEmail = meeting.OrganizerEmail ?? string.Empty,
				IsPrivate = meeting.IsPrivate,
				IsRecurent = meeting.IsRecurent || meeting.SeriesMasterId.IsNotNullOrWhiteSpace(),
				RemoteCreatedOn = meeting.RemoteCreatedOn.UtcDateTime,
				IsCancelled = meeting.IsCancelled
			};
			FillParticipants(meeting, dto);
			return dto;
		}

		private MeetingDto ConvertDeletedMeeting(GraphCalendarDeletedMeeting meeting) {
			return new MeetingDto {
				RemoteId = meeting?.Id ?? string.Empty
			};
		}

		private static bool IsHardDeletedMeeting(GraphCalendarDeletedMeeting meeting) {
			return string.Equals(meeting?.Reason, "deleted", StringComparison.OrdinalIgnoreCase);
		}

		private void ResetSyncPeriodState() {
			_lastSyncPeriodCalendarId = Guid.Empty;
			_lastSyncPeriodDeletedMeetings = new List<MeetingDto>();
		}

		private void RememberSyncPeriodState(CalendarModel calendar, GraphCalendarMeetingQueryResult result) {
			_lastSyncPeriodCalendarId = calendar?.Id ?? Guid.Empty;
			_lastSyncPeriodDeletedMeetings = result?.DeletedMeetings?
				.Where(IsHardDeletedMeeting)
				.Select(ConvertDeletedMeeting)
				.ToList() ?? new List<MeetingDto>();
			calendar?.SetHasGraphMeetingsNextPage(result?.NextLink.IsNotNullOrWhiteSpace() == true);
			if (calendar == null || result == null) {
				return;
			}
			string nextOpaqueLink = result.DeltaLink.IsNotNullOrWhiteSpace()
				? result.DeltaLink
				: result.NextLink;
			if (nextOpaqueLink != calendar.GraphMeetingsDeltaLink) {
				calendar.SetGraphMeetingsDeltaLink(nextOpaqueLink);
				_calendarRepository.SaveGraphMeetingsDeltaLink(calendar);
			}
		}

		private GraphCalendarSendInvitationsCommand CreateSendInvitationsRequest(Meeting meeting, CalendarModel calendar) {
			return new GraphCalendarSendInvitationsCommand {
				Credentials = GetSynchronizationCredentials(calendar),
				EventId = meeting.RemoteId,
				Attendees = CreateAttendees(meeting.Participants, calendar.Settings?.SenderEmailAddress)
			};
		}

		#endregion

		#region Methods: Public

		public IntegrationId SaveMeeting(Meeting meeting, CalendarModel calendar, bool isOnlineMeeting) {
			var actionUrl = string.IsNullOrEmpty(meeting.RemoteId) || meeting.NeedInitialExport(calendar)
				? GraphCalendarExchangeListenerActions.GetCreateMeetingUrl(_userConnection)
				: GraphCalendarExchangeListenerActions.GetUpdateMeetingUrl(_userConnection);
			var result = SendCommand<GraphCalendarSaveMeetingResult>(
				CreateMeetingRequest(meeting, calendar, isOnlineMeeting), actionUrl);
			return result == null
				? null
				: new IntegrationId(result.Id, result.ICalUId.IsNotNullOrWhiteSpace() ? result.ICalUId : meeting.ICalUid);
		}

		public IntegrationId SendInvitations(Meeting meeting, CalendarModel calendar) {
			var result = SendCommand<GraphCalendarSaveMeetingResult>(CreateSendInvitationsRequest(meeting, calendar),
				GraphCalendarExchangeListenerActions.GetSendInvitationsUrl(_userConnection));
			return result == null
				? null
				: new IntegrationId(result.Id, result.ICalUId.IsNotNullOrWhiteSpace() ? result.ICalUId : meeting.ICalUid);
		}

		public void RemoveMeeting(Meeting meeting, CalendarModel calendar) {
			var request = new GraphCalendarRemoveMeetingCommand {
				Credentials = GetSynchronizationCredentials(calendar),
				EventId = meeting.RemoteId,
				IsNeedSendCancellation = meeting.IsNeedSendInvitations
			};
			SendCommand(Serialize(request),
				GraphCalendarExchangeListenerActions.GetDeleteMeetingUrl(_userConnection));
		}

		public List<MeetingDto> GetSyncPeriodMeetings(CalendarModel calendar) {
			ResetSyncPeriodState();
			var meetings = new List<MeetingDto>();
			var deletedMeetings = new List<MeetingDto>();
			var request = CreatePeriodRequest(calendar);
			// Capture intent before paging: a non-empty delta link means Graph returns only the changed
			// slice; an empty one means the full sync window is (re)loaded. RememberSyncPeriodState below
			// overwrites the stored link with the response link, so this must be read here, not later.
			calendar.SetIsGraphMeetingsDeltaFetch(request.DeltaLink.IsNotNullOrWhiteSpace());
			string continuationLink = request.DeltaLink;
			GraphCalendarMeetingQueryResult result;
			do {
				request.DeltaLink = continuationLink;
				result = SendCommand<GraphCalendarMeetingQueryResult>(request,
					GraphCalendarExchangeListenerActions.GetSyncMeetingsUrl(_userConnection));
				meetings.AddRange(result?.Meetings?.Select(ConvertMeeting) ?? Enumerable.Empty<MeetingDto>());
				deletedMeetings.AddRange(
					result?.DeletedMeetings?
						.Where(IsHardDeletedMeeting)
						.Select(ConvertDeletedMeeting) ?? Enumerable.Empty<MeetingDto>());
				continuationLink = result?.NextLink;
			} while (continuationLink.IsNotNullOrWhiteSpace());
			RememberSyncPeriodState(calendar, new GraphCalendarMeetingQueryResult {
				DeletedMeetings = deletedMeetings.Select(meeting => new GraphCalendarDeletedMeeting {
					Id = meeting.RemoteId,
					Reason = "deleted"
				}).ToList(),
				DeltaLink = result?.DeltaLink,
				NextLink = continuationLink
			});
			return meetings;
		}

		public List<MeetingDto> GetDeletedMeetings(CalendarModel calendar) {
			if (calendar == null || calendar.Id != _lastSyncPeriodCalendarId) {
				return new List<MeetingDto>();
			}
			var deletedMeetings = _lastSyncPeriodDeletedMeetings.ToList();
			ResetSyncPeriodState();
			return deletedMeetings;
		}

		public void SetExtendedProperty(Meeting meeting, CalendarModel calendar, string extendedPropetyName,
				object extendedPropetyValue) {
			var request = new GraphCalendarSetExtendedPropertyCommand {
				Credentials = GetSynchronizationCredentials(calendar),
				EventId = meeting.RemoteId,
				ExtensionName = GraphCalendarExtensionName,
				Values = new Dictionary<string, string> {
					[extendedPropetyName] = extendedPropetyValue?.ToString()
				}
			};
			SendCommand(Serialize(request), GraphCalendarExchangeListenerActions.GetExtendedPropertyUrl(_userConnection));
		}

		#endregion

	}

	#endregion

}
