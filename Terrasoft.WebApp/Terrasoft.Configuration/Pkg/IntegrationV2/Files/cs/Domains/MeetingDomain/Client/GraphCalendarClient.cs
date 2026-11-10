namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client
{
	using System.Collections.Generic;
	using IntegrationApi.Interfaces;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Client.Interfaces;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.DTO;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Logger;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: GraphCalendarClient

	[DefaultBinding(typeof(ICalendarClient), Name = "Graph")]
	public class GraphCalendarClient : ICalendarClient
	{

		#region Fields: Private

		private readonly ICalendarLogger _log;

		private readonly IGraphCalendarTransportAdapter _transportAdapter;

		#endregion

		#region Constructors: Public

		public GraphCalendarClient() { }

		public GraphCalendarClient(string sessionId, ISynchronizationErrorHelper synchronizationErrorHelper,
				UserConnection userConnection,
				IGraphCalendarTransportAdapter transportAdapter = null) {
			_transportAdapter = transportAdapter ?? ClassFactory.Get<IGraphCalendarTransportAdapter>(
				new ConstructorArgument("userConnection", userConnection));
			_log = ClassFactory.Get<ICalendarLogger>(new ConstructorArgument("sessionId", sessionId),
				new ConstructorArgument("modelName", GetType().Name));
		}

		#endregion

		#region Methods: Private

		private IntegrationId SaveMeetingInternal(Meeting meeting, CalendarModel calendar, bool isOnlineMeeting) {
			if (!calendar.Settings.SyncEnabled) {
				_log?.LogInfo($"Export disabled when save graph meeting. {meeting} {calendar}.");
				return null;
			}
			_log?.LogInfo($"Save graph meeting started. {meeting} {calendar}.");
			IntegrationId integrationId = _transportAdapter.SaveMeeting(meeting, calendar, isOnlineMeeting);
			_log?.LogInfo($"Save graph meeting ended. {meeting} {calendar}.");
			return integrationId;
		}

		#endregion

		#region Methods: Public

		public IntegrationId SaveMeeting(Meeting meeting, CalendarModel calendar) {
			return SaveMeetingInternal(meeting, calendar, false);
		}

		public void RemoveMeeting(Meeting meeting, CalendarModel calendar) {
			if (!calendar.Settings.SyncEnabled) {
				_log?.LogWarn($"Export disabled when deleting graph meeting {meeting} {calendar}.");
				return;
			}
			_log?.LogInfo($"Delete graph meeting started. {meeting} {calendar}.");
			_transportAdapter.RemoveMeeting(meeting, calendar);
			_log?.LogInfo($"Delete graph meeting ended. {meeting} {calendar}.");
		}

		public void SendInvitations(Meeting meeting, CalendarModel calendar, bool isOnlineMeeting) {
			if (!calendar.Settings.SyncEnabled) {
				_log?.LogWarn($"Export disabled when sending invitations for graph meeting {meeting} {calendar}.");
				return;
			}
			if (string.IsNullOrEmpty(meeting.RemoteId) && !meeting.NeedInitialExport(calendar)) {
				return;
			}
			meeting.InvitesSent = true;
			if (string.IsNullOrEmpty(meeting.RemoteId) || meeting.NeedInitialExport(calendar)) {
				SaveMeetingInternal(meeting, calendar, isOnlineMeeting);
				return;
			}
			var integrationId = _transportAdapter.SendInvitations(meeting, calendar);
			if (integrationId != null) {
				meeting.SetIntegrationsId(integrationId);
			}
		}

		public List<MeetingDto> GetSyncPeriodMeetings(CalendarModel calendar, out bool isAllMeetingsLoaded) {
			var result = new List<MeetingDto>();
			if (!calendar.Settings.SyncEnabled) {
				_log?.LogWarn($"Import disabled when sync graph meetings. {calendar}.");
				isAllMeetingsLoaded = true;
				return result;
			}
			result.AddRange(_transportAdapter.GetSyncPeriodMeetings(calendar));
			isAllMeetingsLoaded = !calendar.HasGraphMeetingsNextPage;
			_log?.LogDebug($"Graph external repository loaded {result.Count} meetings for import.");
			return result;
		}

		public List<MeetingDto> GetDeletedMeetings(CalendarModel calendar) {
			if (!calendar.Settings.SyncEnabled) {
				return new List<MeetingDto>();
			}
			var result = _transportAdapter.GetDeletedMeetings(calendar);
			_log?.LogDebug($"Graph external repository loaded {result.Count} deleted meetings for import.");
			return result;
		}

		public void SetExtendedProperty(Meeting meeting, CalendarModel calendar, string extendedPropetyName,
				object extendedPropetyValue) {
			if (!calendar.Settings.SyncEnabled || extendedPropetyValue == null || string.IsNullOrEmpty(meeting.RemoteId)) {
				_log?.LogWarn($"Set graph extended property is skipped {meeting} {calendar}.");
				return;
			}
			_transportAdapter.SetExtendedProperty(meeting, calendar, extendedPropetyName, extendedPropetyValue);
		}

		#endregion

	}

	#endregion

}
