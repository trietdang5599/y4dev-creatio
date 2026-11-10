namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client
{
	using System;
	using System.Text.RegularExpressions;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GraphCalendarExchangeListenerActions

	internal static class GraphCalendarExchangeListenerActions
	{
		private static readonly string GraphCalendarControllerPath = "/api/graph/calendar/";

		private static string GetListenerControllerUri(UserConnection userConnection, string controllerPath) {
			string serviceUri = SysSettings.GetValue<string>(userConnection, "ExchangeListenerServiceUri", "");
			var uri = new Uri(serviceUri);
			string servicePath = Regex.Replace(uri.OriginalString, @"/api/listeners/{0,1}.*", string.Empty);
			return string.Concat(servicePath.TrimEnd('/'), controllerPath);
		}

		public static string GetCreateMeetingUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "save");
		}

		public static string GetUpdateMeetingUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "save");
		}

		public static string GetDeleteMeetingUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "remove");
		}

		public static string GetSendInvitationsUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "send-invitations");
		}

		public static string GetSyncMeetingsUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "sync-period");
		}

		public static string GetExtendedPropertyUrl(UserConnection userConnection) {
			return string.Concat(GetListenerControllerUri(userConnection, GraphCalendarControllerPath), "extended-property");
		}
	}

	#endregion

}
