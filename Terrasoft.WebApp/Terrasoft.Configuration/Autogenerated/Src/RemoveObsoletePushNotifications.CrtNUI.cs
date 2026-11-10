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
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: RemoveObsoletePushNotificationsMethodsWrapper

	/// <exclude/>
	public class RemoveObsoletePushNotificationsMethodsWrapper : ProcessModel
	{

		public RemoveObsoletePushNotificationsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var currentUtcDate = DateTime.UtcNow;
			var utc30DaysAgo = currentUtcDate.AddDays(-30);
			new Delete(UserConnection)
				.From("MobileNotificationLog")
				.Where("CreatedOn").IsLess(Column.Parameter(utc30DaysAgo))
			.Execute();
			return true;
		}

		#endregion

	}

	#endregion

}

