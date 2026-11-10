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
	using Terrasoft.Configuration.Deduplication;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: BulkDuplicatesSearchProcessMethodsWrapper

	/// <exclude/>
	public class BulkDuplicatesSearchProcessMethodsWrapper : ProcessModel
	{

		public BulkDuplicatesSearchProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var constructorArgument = new ConstructorArgument("userConnection", UserConnection);
			var bulkDeduplicationTaskStarter = ClassFactory.Get<IBulkDeduplicationTaskStarter>(constructorArgument);
			var value = Get<string>("SchemaName");
			return bulkDeduplicationTaskStarter.StartDeduplicationTask(value);
		}

		#endregion

	}

	#endregion

}

