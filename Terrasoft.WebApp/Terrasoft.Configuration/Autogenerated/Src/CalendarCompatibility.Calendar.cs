namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: DayInCalendarObject

	/// <summary>
	/// ######### ############# ######## ### # #########.
	/// </summary>
	[Serializable]
	public class DayInCalendarObject : DayInCalendarObjectV2
	{

		#region Constructors: Public

		public DayInCalendarObject(DayInCalendar dayInCalendarEntity): base(dayInCalendarEntity) {}

		#endregion
		
	}

	#endregion 
	
	#region Class: DayInCalendarExtended

	/// <summary>
	/// ########### ########### ####. ###### ############# # ######, #### ########## ##### ##### ####### ### #######
	/// ####: #### ### #### ## ####### ######, #### ############# ########### ####.
	/// </summary>
	public class DayInCalendarExtended : DayInCalendarExtendedV2
	{
		#region Constructors: Public

		public DayInCalendarExtended() { }

		public DayInCalendarExtended(DayInCalendar dayInCalendar, bool isCalendarValue) {
			IsCalendarValue = isCalendarValue;
			DayInCalendarEntity = dayInCalendar;
		}

		#endregion

		#region Properties: Public

		public DayInCalendar DayInCalendar {
			get => DayInCalendarEntity as DayInCalendar;
			set => DayInCalendarEntity = value;
		}

		#endregion

	}

	#endregion

	#region Class: WorkingTimeIntervalObject

	/// <summary>
	/// ######### ############# ######## ######### ######## #######.
	/// </summary>
	[Serializable]
	public class WorkingTimeIntervalObject : WorkingTimeIntervalObjectV2
	{

		#region Constructors: Public

		public WorkingTimeIntervalObject() { }

		public WorkingTimeIntervalObject(WorkingTimeInterval workingTimeIntervalEntity)
			: base(workingTimeIntervalEntity) {
		}

		#endregion

	}

	#endregion

	#region Class: CalendarUtils

	[Obsolete("The class is left only for the backward compatibility. Use CalendarUtilsBase in the new code")]
	public class CalendarUtils : CalendarUtilsBase
	{

		#region Constructors: Public

		public CalendarUtils(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		public new DayInCalendar GetWeekDay(IEnumerable<Guid> calendarIds, int dayOfWeekNumber,
			IEnumerable<Guid> ignoredIds = null) {
			return base.GetWeekDay(calendarIds, dayOfWeekNumber, ignoredIds) as DayInCalendar;
		}

		public new DayInCalendar GetCalendarDay(IEnumerable<Guid> calendarIds, DateTime date,
			IEnumerable<Guid> ignoredIds = null) {
			return base.GetCalendarDay(calendarIds, date, ignoredIds) as DayInCalendar;
		}

		public new DayInCalendarExtended GetCalendarDayExtended(IEnumerable<Guid> calendarIds,
			DateTime date, IEnumerable<Guid> ignoredIds = null) {
			var result = base.GetCalendarDayExtended(calendarIds, date, ignoredIds);
			return new DayInCalendarExtended {
				DayInCalendar = result.DayInCalendarEntity as DayInCalendar,
				IsCalendarValue = result.IsCalendarValue
			};
		}

		public new IEnumerable<DayInCalendar> GetWeekDays(IEnumerable<Guid> calendarIds,
			IEnumerable<Guid> ignoredIds = null) {
			return base.GetWeekDays(calendarIds, ignoredIds).Select(e => e as DayInCalendar);
		}

		public new IEnumerable<DayInCalendar> GetCalendarDays(IEnumerable<Guid> calendarIds, DateTime fromDate,
			DateTime toDate, IEnumerable<Guid> ignoredIds = null) {
			return base.GetCalendarDays(calendarIds, fromDate, toDate, ignoredIds).Select(e => e as DayInCalendar);
		}

		public new IEnumerable<DayInCalendarExtended> GetCalendarDaysExtended(IEnumerable<Guid> calendarIds,
			DateTime fromDate, DateTime toDate, IEnumerable<Guid> ignoredIds = null) {
			return base.GetCalendarDaysExtended(calendarIds, fromDate, toDate, ignoredIds)
				.Select(e => new DayInCalendarExtended {
					DayInCalendar = e.DayInCalendarEntity as DayInCalendar,
					IsCalendarValue = e.IsCalendarValue,
					DayInCalendarEntity = e.DayInCalendarEntity
				});
		}

		public new IEnumerable<WorkingTimeInterval> GetWorkingTimeIntervals(Guid dayInCalendarId) {
			return base.GetWorkingTimeIntervals(dayInCalendarId).Select(e => e as WorkingTimeInterval);
		}

		#endregion

	}

	#endregion

}
