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
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.FileImport;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: UpdateSsoContactMethodsWrapper

	/// <exclude/>
	public class UpdateSsoContactMethodsWrapper : ProcessModel
	{

		public UpdateSsoContactMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ActualizeContactScriptTaskExecute", ActualizeContactScriptTaskExecute);
		}

		#region Methods: Private

		private bool ActualizeContactScriptTaskExecute(ProcessExecutingContext context) {
			var ssoContactUpdater = ClassFactory.Get<ISsoContactUpdater>(new ConstructorArgument("userConnection", Get<UserConnection>("UserConnection")));
			ssoContactUpdater.UpdateContact(Json.Deserialize<Dictionary<string, string>>(Get<string>("ClaimData")));
			return true;
		}

		#endregion

	}

	#endregion

}

