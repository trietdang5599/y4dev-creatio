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

	#region Class: RefreshSenderDomainsMethodsWrapper

	/// <exclude/>
	public class RefreshSenderDomainsMethodsWrapper : ProcessModel
	{

		public RefreshSenderDomainsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("RefreshSenderDomainsTaskExecute", RefreshSenderDomainsTaskExecute);
		}

		#region Methods: Private

		private bool RefreshSenderDomainsTaskExecute(ProcessExecutingContext context) {
			var engine = Factories.ClassFactory.Get<Terrasoft.Configuration.BpmonlineCloudEngine>(
									new Factories.ConstructorArgument("userConnection", context.UserConnection));
						engine.RefreshSenderDomains(new Terrasoft.Configuration.CESModels.SenderDomainsInfoRequest());
			return true;
		}

		#endregion

	}

	#endregion

}

