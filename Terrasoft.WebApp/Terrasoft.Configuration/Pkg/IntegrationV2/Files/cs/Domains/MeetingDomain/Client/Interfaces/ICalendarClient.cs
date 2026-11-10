namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client.Interfaces
	{
	using System.Collections.Generic;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Client;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.DTO;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;

	#region Interface: ICalendarClient

	/// <summary>
	/// Calendar client interface.
	/// </summary>
	public interface ICalendarClient
	{

		#region Methods: Public

		/// <summary>
		/// Save <see cref="Meeting"/> in <see cref="CalendarModel"/>.
		/// </summary>
		/// <param name="meeting"><see cref="Meeting"/> model instance.</param>
		/// <param name="calendar"><see cref="CalendarModel"/> model instance.</param>
		/// <returns><see cref="Meeting"/> unique identifier in the external store.</returns>
		IntegrationId SaveMeeting(Meeting meeting, CalendarModel calendar);

		/// <summary>
		/// Removes <paramref name="meeting"/> from <paramref name="calendar"/>.
		/// </summary>
		/// <param name="meeting"><see cref="Meeting"/> instance.</param>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		void RemoveMeeting(Meeting meeting, CalendarModel calendar);

		/// <summary>
		/// Sends <paramref name="meeting"/> invites in <paramref name="calendar"/>.
		/// </summary>
		/// <param name="meeting"><see cref="Meeting"/> instance.</param>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		/// <param name="isOnlineMeeting">Is online meeting flag.</param>
		void SendInvitations(Meeting meeting, CalendarModel calendar, bool isOnlineMeeting);

		/// <summary>
		/// Requests appointments from external calendar and converts them to meetings.
		/// </summary>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		/// <param name="isAllMeetingsLoaded">Flag indicating whether all meetings have been loaded.</param>
		/// <returns>List of <see cref="MeetingDto"/> instances.</returns>
		List<MeetingDto> GetSyncPeriodMeetings(CalendarModel calendar, out bool isAllMeetingsLoaded);

		/// <summary>
		/// Returns meeings that were deleted in <paramref name="calendar"/> 
		/// from <see cref="CalendarSettings.LastSyncDateUtc"/> date.
		/// </summary>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		/// <returns>List of deleted meetings.</returns>
		List<MeetingDto> GetDeletedMeetings(CalendarModel calendar);

		/// <summary>
		/// Set extended property to external calendar item.
		/// </summary>
		/// <param name="meeting"><see cref="Meeting"/> instance.</param>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		/// <param name="extendedPropetyName">Extended property name.</param>
		/// <param name="extendedPropetyValue">Extended property value.</param>
		void SetExtendedProperty(Meeting meeting, CalendarModel calendar, string extendedPropetyName, object extendedPropetyValue);

		#endregion

	}

	#endregion

}
