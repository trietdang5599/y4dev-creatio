namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using IntegrationApi.Calendar.DTO;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Web.Common;
	using static Terrasoft.EmailDomain.IntegrationConsts.Calendar;

	#region Class: MeetingService

	/// <summary>
	/// Service for working with calendar meetings.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MeetingService : BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string GoogleMultiDomainFeatureName = "GoogleMultidomain";

		#endregion

		#region Properties: Private

		/// <summary>
		/// Current user contact identifier.
		/// </summary>
		private Guid CurrentUserContactId {
			get {
				return UserConnection.CurrentUser.ContactId;
			}
		}

		/// <summary>
		/// Current user contact name.
		/// </summary>
		private string CurrentUserContactName {
			get {
				return UserConnection.CurrentUser.ContactName;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Send invitations for <see cref="Activity"/> identifier.
		/// </summary>
		/// <param name="meetingId"><see cref="Activity"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse SendInvitations(Guid meetingId) {
			var response = new BaseResponse {
				Success = true
			};
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				meetingService.SendInvitations(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo = new ErrorInfo() {
					Message = e.Message,
					StackTrace = e.StackTrace
				};
				var logger = LogManager.GetLogger("Calendar");
				logger.Error("Failed to send invitations.", e);
			}
			return response;
		}

		/// <summary>
		/// Get meeting invitation info for <see cref="Activity"/> identifier.
		/// </summary>
		/// <param name="meetingId"><see cref="Activity"/> identifier.</param>
		/// <returns><see cref="MeetingInvitationInfo"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public MeetingInvitationInfo GetMeetingInvitationInfo(Guid meetingId) {
			MeetingInvitationInfo response;
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				response = meetingService.GetMeetingInvitationInfo(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error("Failed to GetMeetingIntegrationInfo.", e);
				throw;
			}
			return response;
		}

		/// <summary>
		/// Get meetings invitation info for <see cref="Activity"/> identifiers.
		/// </summary>
		/// <param name="meetingIds">List of <see cref="Activity"/> identifiers.</param>
		/// <returns><see cref="MeetingInvitationInfo"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public MeetingInvitationInfo GetMeetingsInvitationInfo(List<Guid> meetingIds) {
			var invitationInfos = meetingIds.Select(m => GetMeetingInvitationInfo(m)).ToList();
			var response = new MeetingInvitationInfo {
				HasCalendarIntegration = invitationInfos.Any(x => x.HasCalendarIntegration),
				IsOutdatedMeeting = invitationInfos.Any(x => x.IsOutdatedMeeting),
				IsParticipantsExist = invitationInfos.Any(x => x.IsParticipantsExist),
				IsSynchronized = invitationInfos.Any(x => x.IsSynchronized),
				IsParticipantsInvited = invitationInfos.Any(x => x.IsParticipantsInvited),
				CalendarSyncSinceDate = invitationInfos.FirstOrDefault()?.CalendarSyncSinceDate
			};
			return response;
		}

		/// <summary>
		/// Get meetings identifiers where current user contact is organizer.
		/// </summary>
		/// <param name="meetingIds">List of <see cref="Activity"/> identifiers.</param>
		/// <param name="filtersConfig">Filter string.</param>
		/// <returns>Meetings identifiers where current user contact is organizer.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> GetCurrentContactOrganizerMeetingIds(List<Guid> meetingIds, string filtersConfig = "") {
			List<Guid> resultIds;
			try { 
				if (!filtersConfig.IsNullOrEmpty()) {
					var utilities = ClassFactory.Get<GridUtilitiesServiceHandler>();
					var filteredItems = utilities.GetPrimaryColumnValuesFromFilters("Activity", filtersConfig);
					filteredItems.ForEach(fi => meetingIds.AddIfNotExists(new Guid(fi)));
				}
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				resultIds = meetingIds.Where(m => CanUserChangeMeeting(m) != ChangeMeetingResponse.No).ToList();
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error("Failed to GetMeetingsOrganizerInfo.", e);
				throw;
			}
			return resultIds;
		}

		/// <summary>
		/// Check if the appointment is available for editing under the user.
		/// </summary>
		/// <param name="meetingId">Meeting unique identifier.</param>
		/// <returns><see cref="ChangeMeetingResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ChangeMeetingResponse CanUserChangeMeeting(Guid meetingId) {
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				return meetingService.CanUserChangeMeeting(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while checking for meeting changes by the current user '{CurrentUserContactName}'.", e);
			}
			return ChangeMeetingResponse.No;
		}

		/// <summary>
		/// Check if the appointment is available for editing under the user.
		/// </summary>
		/// <param name="senderEmailAddress">Sender Email address.</param>
		/// <returns><see cref="ChangeMeetingResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public bool CanUserChangeCalendar(string senderEmailAddress) {
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				return meetingService.CanUserChangeCalendar(senderEmailAddress, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while checking for calendar changes by the current user '{CurrentUserContactName}'.", e);
			}
			return true;
		}

		/// <summary>
		/// Check if the user can add a calendar.
		/// </summary>
		/// <returns>A boolean value indicating whether the user can add a calendar.</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		public bool HasUserActiveCalendarAccount() {
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				var oldGoogleAccountExists = false;
				var calendarAccountExists = meetingService.HasActiveCalendar(CurrentUserContactId);
				if (Features.GetIsDisabled(GoogleMultiDomainFeatureName)) {
					var oldGoogleIntegrationService = ClassFactory.Get<GoogleIntegrationHelper>(
						new ConstructorArgument("userConnection", UserConnection));
					oldGoogleAccountExists = oldGoogleIntegrationService.HasGoogleSocialAccount();
				}
				return calendarAccountExists || oldGoogleAccountExists;
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while checking for existing calendar by the current user '{CurrentUserContactName}'.", e);
			}
			return true;
		}

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		public List<CalendarAccountInfo> GetUserCalendarsInfo() {
			var result = new List<CalendarAccountInfo>();
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				var calendars = meetingService.GetUserCalendarsInfo(CurrentUserContactId);
				result.AddRange(calendars);
				if (Features.GetIsDisabled(GoogleMultiDomainFeatureName)) {
					var oldGoogleIntegrationService = ClassFactory.Get<GoogleIntegrationHelper>(
						new ConstructorArgument("userConnection", UserConnection));
					var oldGoogleCalendars = oldGoogleIntegrationService.GetGoogleSocialAccounts();
					result.AddRange(oldGoogleCalendars);
				}
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while getting existing calendars by the current user '{CurrentUserContactName}'.", e);
			}
			return result;
		}

		/// <summary>
		/// Recreates calendar failover job.
		/// </summary>
		/// <returns><see cref="BaseResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse RecreateCalendarFailJob() {
			var response = new BaseResponse {
				Success = true
			};
			try {
				var failJobFactory = ClassFactory.Get<IListenerServiceFailJobFactory>();
				failJobFactory.ScheduleCalendarFailJob(UserConnection);
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo = new ErrorInfo() {
					Message = e.Message,
					StackTrace = e.StackTrace
				};
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while recreating calendar failover job.", e);
			}
			return response;
		}

		#endregion

	}

	#endregion
}

