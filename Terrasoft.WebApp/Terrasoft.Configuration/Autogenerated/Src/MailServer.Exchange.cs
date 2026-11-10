namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: MailServer_ExchangeEventsProcess

	public partial class MailServer_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void RemoveMailboxSyncSettingsJob() {
			Select allowEmailDownloadingSelect = new Select(UserConnection)
				.Column("SenderEmailAddress")
			.From("MailboxSyncSettings")
			.Where("MailServerId").IsEqual(Column.Parameter(Entity.Id)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = allowEmailDownloadingSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						string senderEmailAddress = reader.GetColumnValue<string>("SenderEmailAddress");
						if (Entity.GetTypedColumnValue<Guid>("TypeId") == ExchangeConsts.ExchangeMailServerTypeId) {
							ExchangeUtility.RemoveSyncJob(UserConnection, senderEmailAddress,
								ExchangeUtility.MailSyncProcessName);
						} else if (Entity.GetTypedColumnValue<Guid>("TypeId") == ExchangeConsts.ImapMailServerTypeId) {
							var parameters = new Dictionary<string, object> {
								{ "SenderEmailAddress", senderEmailAddress },
								{ "CurrentUserId", UserConnection.CurrentUser.Id }
							};
							var scheduler = ClassFactory.Get<Terrasoft.Mail.IImapSyncJobScheduler>();
							scheduler.RemoveSyncJob(UserConnection, parameters);
						}
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

