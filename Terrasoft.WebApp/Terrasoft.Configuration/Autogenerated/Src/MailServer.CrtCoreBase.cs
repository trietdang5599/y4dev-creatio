namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: MailServer_CrtBaseEventsProcess

	public partial class MailServer_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SendMessage(string operation) {
			string messageTpl = "{{\"Id\":\"{0}\"}}";
			string messageBody = String.Format(messageTpl, Entity.Id);
			Guid sysAdminUnitId = UserConnection.CurrentUser.Id;
			IMsgChannel channel = MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage {
				Id = sysAdminUnitId,
				Body = messageBody
			};
			simpleMessage.Header.Sender = operation;
			channel.PostMessage(simpleMessage);
		}

		#endregion

	}

	#endregion

}

