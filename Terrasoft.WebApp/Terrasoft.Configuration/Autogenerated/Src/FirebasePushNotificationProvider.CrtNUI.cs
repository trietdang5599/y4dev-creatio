namespace Terrasoft.Configuration
{
	using System;
	using System.Net;
	using System.Text;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Mobile;

	#region Class: FirebasePushNotificationProvider

	/// <summary>
	/// Firebase push notification provider.
	/// </summary>
	public class FirebasePushNotificationProvider : IPushNotificationProvider
	{

		#region Constructors: Public

		public FirebasePushNotificationProvider(string settings) {
			_userConnection = ClassFactory.Get<UserConnection>();
		}

		#endregion

		#region Properties: Private

		private readonly UserConnection _userConnection;

		private static readonly ILog _log = LogManager.GetLogger("PushNotification.Firebase");
		private static readonly Guid _firebaseServiceId = new Guid("24B535DE-3424-4294-BEBB-C5E4F8E48D75");

		#endregion

		#region Methods: Private

		private string[] GetTokens(Guid sysAdminUnitId) {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("PushNotificationToken");
			var esq = new EntitySchemaQuery(schema);
			EntitySchemaQueryColumn tokenColumn = esq.AddColumn("Token");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Service", _firebaseServiceId));
			if (IsUser(sysAdminUnitId)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit.Id", sysAdminUnitId));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"[SysAdminUnitInRole:SysAdminUnit:SysAdminUnit].SysAdminUnitRoleId", sysAdminUnitId));
			}
			esq.IsDistinct = true;
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			string[] tokens = new string[entityCollection.Count];
			for (int i = 0; i < entityCollection.Count; i++) {
				Entity item = entityCollection[i];
				var token = item.GetTypedColumnValue<string>(tokenColumn.Name);
				tokens[i] = token;
			}
			_log.DebugFormat("Received {0} tokens for SysAdminUnitId", tokens.Length.ToString(), sysAdminUnitId);
			return tokens;
		}

		private bool IsUser(Guid sysAdminUnitId) {
			var sysAdminUnitSelect = new Select(_userConnection).Column("SAU", "Id")
				.From("SysAdminUnit").As("SAU")
				.Where("Id").IsEqual(Column.Const(sysAdminUnitId))
				.And()
				.OpenBlock("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)Terrasoft.Core.DB.SysAdminUnitType.User))
				.Or("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)Terrasoft.Core.DB.SysAdminUnitType.SelfServicePortalUser))
				.CloseBlock() as Select;
			return sysAdminUnitSelect.ExecuteScalar<Guid>().IsNotEmpty();
		}

		private void PostData(string[] tokens, string title, string message, Dictionary<string, string> additionalData) {
			IFirebaseCloudMessaging fcm;
			try {
				fcm = ClassFactory.Get<IFirebaseCloudMessaging>();
			} catch (Exception e) {
				_log.Error("Can't create an instance of IFirebaseCloudMessaging", e);
				return;
			}
			if (fcm == null) {
				_log.ErrorFormat("Can't send push({0}). Instance of IFirebaseCloudMessaging is null", title);
				return;
			}
			IReadOnlyList<PushNotificationResponse> responses = fcm.Send(tokens, title, message, additionalData);
			for (var i = 0; i < responses.Count; i++) {
				PushNotificationResponse item = responses[i];
				if (item.IsUnregisteredToken && tokens.Length > i) {
					string badToken = tokens[i];
					var deleteQuery = new Delete(_userConnection).From("PushNotificationToken").Where("Token")
						.IsEqual(Column.Parameter(badToken));
					deleteQuery.Execute();
					_log.InfoFormat("Deleting a token({0}) due to its inactivity", AnonymizeToken(badToken));
				} else if (item.Error != null) {
					string badToken = tokens.Length > i ? tokens[i] : i.ToString();
					_log.ErrorFormat("Can't deliver push notification message to token ({0})." + " Error: {1}",
						AnonymizeToken(badToken), item.Error);
				}
			}
		}

		private string AnonymizeToken(string token) {
			return token.Substring(0, token.Length > 20 ? 20 : token.Length);
		}

		#endregion

		#region Methods: Protected

		[Obsolete("8.1.4 | Method is deprecated. Use Send instead")]
		protected virtual string PostRequest(Uri uriAddress, string apiKey, string postData) {
			using (var webClient = new WebClient()) {
				webClient.Encoding = Encoding.UTF8;
				webClient.Headers.Add("Authorization", "key=" + apiKey);
				webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
				try {
					return webClient.UploadString(uriAddress, "POST", postData);
				} catch (Exception e) {
					_log.Debug("Can't send push notification:" + e.Message, e);
					throw;
				}
			}
		}

		protected Task SendPushAsync(PushNotificationData data) {
			if (_userConnection == null) {
				_log.ErrorFormat("Can't send push({0}). UserConnection is null", data.Title);
				return Task.CompletedTask;
			}
			string[] tokens;
			if (data.SysAdminUnitId == null) {
				_log.Warn("Sending messages directly through the FirebasePushNotificationProvider is not allowed." +
					" Please use the Push Notification.Send method instead.");
#pragma warning disable CS0618
				_log.DebugFormat("Sending push({0}) for Token:{1}", data.Title, AnonymizeToken(data.Token));
				tokens = new[] { data.Token };
#pragma warning restore CS0618
			} else {
				_log.DebugFormat("Sending push({0}) for SysAdminUnitId:{1}", data.Title,
					data.SysAdminUnitId.ToString());
				tokens = GetTokens((Guid)data.SysAdminUnitId);
			}
			return Task.Run(() => PostData(tokens, data.Title, data.Message, data.AdditionalData));
		}

		#endregion

		#region Methods: Public

		public void Send(PushNotificationData data) {
			SendPushAsync(data);
		}

		#endregion

	}

	#endregion

}

