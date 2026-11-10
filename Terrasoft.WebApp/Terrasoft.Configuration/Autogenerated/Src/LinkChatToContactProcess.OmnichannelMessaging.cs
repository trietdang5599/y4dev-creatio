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
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: LinkChatToContactProcessMethodsWrapper

	/// <exclude/>
	public class LinkChatToContactProcessMethodsWrapper : ProcessModel
	{

		public LinkChatToContactProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
			AddScriptTaskMethod("ScriptTask3Execute", ScriptTask3Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			Guid oldContactId = Get<Guid>("OldContactId");
			OmnichannelContactIdentifier.RemoveIdentityFromCache(oldContactId, UserConnection);
			return true;
		}

		private bool ScriptTask3Execute(ProcessExecutingContext context) {
			new ChatOperatorNotifier(UserConnection).LinkChatToContactNotify(UserConnection.CurrentUser.Id, Get<Guid>("ChatId"));
			return true;
		}

		#endregion

	}

	#endregion

}

