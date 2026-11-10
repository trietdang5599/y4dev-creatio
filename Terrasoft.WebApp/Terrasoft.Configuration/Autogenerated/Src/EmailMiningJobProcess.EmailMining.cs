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
	using Terrasoft.Configuration.EmailMining;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: EmailMiningJobProcessMethodsWrapper

	/// <exclude/>
	public class EmailMiningJobProcessMethodsWrapper : ProcessModel
	{

		public EmailMiningJobProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ExecEmailMiningJobScriptTaskExecute", ExecEmailMiningJobScriptTaskExecute);
		}

		#region Methods: Private

		private bool ExecEmailMiningJobScriptTaskExecute(ProcessExecutingContext context) {
			EmailMiningJob job = new EmailMiningJob();
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			job.Execute(userConnection, null);
			return true;
		}

		#endregion

	}

	#endregion

}

