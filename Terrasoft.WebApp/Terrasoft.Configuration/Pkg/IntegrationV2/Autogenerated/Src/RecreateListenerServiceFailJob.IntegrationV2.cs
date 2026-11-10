namespace Terrasoft.Core.Process
{

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
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: RecreateListenerServiceFailJobMethodsWrapper

	/// <exclude/>
	public class RecreateListenerServiceFailJobMethodsWrapper : ProcessModel
	{

		public RecreateListenerServiceFailJobMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var userConnection = Get<UserConnection>("UserConnection");
			var failJobFactory = ClassFactory.Get<IListenerServiceFailJobFactory>();
			failJobFactory.ScheduleListenerServiceFailJob(userConnection);
			failJobFactory.ScheduleCalendarFailJob(userConnection);
			return true;
		}

		#endregion

	}

	#endregion

}

