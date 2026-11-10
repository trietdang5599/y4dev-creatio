namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client.Interfaces
{
	using System.Collections.Generic;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.DTO;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;

	#region Interface: IGraphCalendarTransportAdapter

	public interface IGraphCalendarTransportAdapter
	{

		#region Methods: Public

		IntegrationId SaveMeeting(Meeting meeting, CalendarModel calendar, bool isOnlineMeeting);

		IntegrationId SendInvitations(Meeting meeting, CalendarModel calendar);

		void RemoveMeeting(Meeting meeting, CalendarModel calendar);

		List<MeetingDto> GetSyncPeriodMeetings(CalendarModel calendar);

		List<MeetingDto> GetDeletedMeetings(CalendarModel calendar);

		void SetExtendedProperty(Meeting meeting, CalendarModel calendar, string extendedPropetyName, object extendedPropetyValue);

		#endregion

	}

	#endregion

}
