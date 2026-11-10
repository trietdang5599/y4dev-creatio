namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: TaggingProcessMethodsWrapper

	/// <exclude/>
	public class TaggingProcessMethodsWrapper : ProcessModel
	{

		public TaggingProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("SendSuccessfulNotificationScriptTaskExecute", SendSuccessfulNotificationScriptTaskExecute);
			AddScriptTaskMethod("SendFailureNotificationScriptTaskExecute", SendFailureNotificationScriptTaskExecute);
		}

		#region Methods: Private

		private bool SendSuccessfulNotificationScriptTaskExecute(ProcessExecutingContext context) {
			int processedRecordsCount = this.Get<int>("TaggingUserTask.ProcessedRecordsCount");
			string notificationMessageText = GetSuccessfulNotificationMessage(processedRecordsCount);
			SendReminding(notificationMessageText);
			return true;
		}

		private bool SendFailureNotificationScriptTaskExecute(ProcessExecutingContext context) {
			string processedExceptionMessage = this.Get<string>("TaggingUserTask.ProcessedExceptionMessage");
			string notificationMessageText = GetFailureNotificationMessage(processedExceptionMessage);
			SendReminding(notificationMessageText);
			return true;
		}

			private string GetSuccessfulNotificationMessage(int processedRecordsCount) {
				string taggingAction = this.Get<string>("TaggingAction");
				string notificationMessageText = this.Get<string>($"FinishSuccessful{taggingAction}NotificationText");
				return string.Format(notificationMessageText, processedRecordsCount);
			}
			
			private string GetFailureNotificationMessage(string processedExceptionMessage) {
				string taggingAction = this.Get<string>("TaggingAction");
				if (string.IsNullOrWhiteSpace(taggingAction)) {
					return this.Get<string>("DefaultFailureNotificationText") +
						(!string.IsNullOrWhiteSpace(processedExceptionMessage) ? $". {processedExceptionMessage}" : "");
				}
				string notificationMessageText = this.Get<string>($"FinishFailure{taggingAction}NotificationText");
				return string.Format(notificationMessageText, processedExceptionMessage);
			}
			
			private void SendReminding(string message) {
				var remindEntity = RemindingServerUtilities.GetRemindingByProcess(UserConnection, "TaggingProcess", message);
				remindEntity.Save();
			}

		#endregion

	}

	#endregion

}

