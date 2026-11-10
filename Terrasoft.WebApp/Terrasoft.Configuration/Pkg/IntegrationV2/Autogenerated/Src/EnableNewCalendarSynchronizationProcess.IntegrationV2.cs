namespace Terrasoft.Core.Process
{

	using global::Common.Logging;
	using IntegrationApi.Interfaces;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: EnableNewCalendarSynchronizationProcessMethodsWrapper

	/// <exclude/>
	public class EnableNewCalendarSynchronizationProcessMethodsWrapper : ProcessModel
	{

		public EnableNewCalendarSynchronizationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var uc = Get<UserConnection>("UserConnection");
			var syncPeriod = Get<int>("SyncPeriod");
			var mailboxesStrings = Get<string>("Emails");
			var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", uc));
			var mailboxes = mailboxService.GetAllMailboxes().Where(m => mailboxesStrings.Contains(m.SenderEmailAddress.ToLower()));
			foreach (var mailbox in mailboxes) {
				EnableCalendarSync(uc, mailbox.Id);
				ReCreateCalendarSyncJob(mailbox, "SyncExchangeActivitiesProcess", syncPeriod);
			}
			return true;
		}

			private void ReCreateCalendarSyncJob(Mailbox mailbox, string processName, int syncPeriod) {
				var _logger = LogManager.GetLogger("Calendar");
				var uc = Get<UserConnection>("UserConnection");
				try {
					var parameters = new Dictionary<string, object> {
						{ "SenderEmailAddress", mailbox.SenderEmailAddress },
						{ "MailboxType", mailbox.TypeId },
						{ "PeriodInMinutes", syncPeriod }
					};
					var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
					_logger.Info($"Re-create calendar {mailbox.SenderEmailAddress} synchronization job by process.");
					syncJobScheduler.CreateSyncJob(uc, syncPeriod, processName, parameters);
				} catch (Exception ex) {
					_logger.Error($"Error re-creating calendar {mailbox.SenderEmailAddress} " +
						$"synchronization job by process.", ex);
				}
			}
			
			private void EnableCalendarSync(UserConnection uc, Guid mailboxId) {
				var update = new Update(uc, "ActivitySyncSettings")
					.Set("ImportAppointments", Column.Parameter(true))
					.Set("ExportActivities", Column.Parameter(true))
					.Where("MailboxSyncSettingsId")
						.IsEqual(Column.Parameter(mailboxId));
				update.Execute();
			}

		#endregion

	}

	#endregion

}

