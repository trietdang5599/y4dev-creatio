namespace Terrasoft.Core.Process
{

	using IntegrationApi.Interfaces;
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
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: LoadMissedEmailMethodsWrapper

	/// <exclude/>
	public class LoadMissedEmailMethodsWrapper : ProcessModel
	{

		public LoadMissedEmailMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var fetchEmailsJob = ClassFactory.Get<IFetchEmailsJob>();
			fetchEmailsJob.ScheduleJob(UserConnection);
			return true;
		}

		#endregion

	}

	#endregion

}

