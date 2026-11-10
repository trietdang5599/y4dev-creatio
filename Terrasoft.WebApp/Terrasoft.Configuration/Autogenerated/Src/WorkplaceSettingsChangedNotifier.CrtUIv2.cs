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
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: WorkplaceSettingsChangedNotifierMethodsWrapper

	/// <exclude/>
	public class WorkplaceSettingsChangedNotifierMethodsWrapper : ProcessModel
	{

		public WorkplaceSettingsChangedNotifierMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var workplaceContentChangedNotifier = ClassFactory.Get<IWorkplaceContentChangedNotifier>();
			var userIds = new[] { Get<Guid>("CurrentUserId") };
			workplaceContentChangedNotifier.Notify(userIds);
			return true;
		}

		#endregion

	}

	#endregion

}

