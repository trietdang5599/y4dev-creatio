namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Repository.Interfaces
{
	using System;
	using System.Collections.Generic;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;

	#region Interface: ICalendarRepository

	/// <summary>
	/// Calendar repository interface.
	/// </summary>
	public interface ICalendarRepository
	{

		#region Methods: Public

		/// <summary>
		/// Get all users <see cref="CalendarModel"/>`s.
		/// </summary>
		/// <returns>List of all users <see cref="CalendarModel"/>`s.</returns>
		List<CalendarModel> GetAllCalendars();

		/// <summary>
		/// Get all users enabled <see cref="CalendarModel"/>`s.
		/// </summary>
		/// <returns>List of enabled users <see cref="CalendarModel"/>`s.</returns>
		List<CalendarModel> GetEnabledCalendars();

		/// <summary>
		/// Gets <see cref="CalendarModel"/> instance filtered by email.
		/// </summary>
		/// <param name="email">Email address.</param>
		/// <returns><see cref="CalendarModel"/> instance filtered by email.</returns>
		CalendarModel GetOwnerCalendar(string email);

		/// <summary>
		/// Gets <see cref="CalendarModel"/> instance filtered by owner identifier.
		/// </summary>
		/// <param name="ownerId">Owner identifier.</param>
		/// <returns><see cref="CalendarModel"/> instance filtered by owner identifier.</returns>
		CalendarModel GetOwnerCalendar(Guid ownerId);

		/// <summary>
		/// Gets all <see cref="CalendarModel"/> instances filtered by owner identifier.
		/// </summary>
		/// <param name="ownerId">Owner identifier.</param>
		/// <returns>see cref="Calendar"/> instances filtered by owner identifier.</returns>
		List<CalendarModel> GetOwnerCalendars(Guid ownerId);

		/// <summary>
		/// Saves calendar to database.
		/// </summary>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		void Save(CalendarModel calendar);

		/// <summary>
		/// Saves Graph meetings delta link state for calendar sync-period synchronization.
		/// </summary>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		void SaveGraphMeetingsDeltaLink(CalendarModel calendar);

		/// <summary>
		/// Deletes Graph meetings delta link state for affected calendars.
		/// </summary>
		/// <param name="calendarSettingsIds">Affected <c>ActivitySyncSettings</c> identifiers.</param>
		void DeleteGraphMeetingsDeltaLinkStates(IEnumerable<Guid> calendarSettingsIds);

		#endregion

	}

	#endregion

}
