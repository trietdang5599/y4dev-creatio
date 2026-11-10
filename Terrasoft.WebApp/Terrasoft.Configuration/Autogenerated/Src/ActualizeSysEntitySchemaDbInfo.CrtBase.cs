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

	#region Class: ActualizeSysEntitySchemaDbInfoMethodsWrapper

	/// <exclude/>
	public class ActualizeSysEntitySchemaDbInfoMethodsWrapper : ProcessModel
	{

		public ActualizeSysEntitySchemaDbInfoMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var actualizer = new EntitySchemaDbInfoActualizer(UserConnection);
			actualizer.Actualize();
			return true;
		}

		#endregion

	}

	#endregion

}

