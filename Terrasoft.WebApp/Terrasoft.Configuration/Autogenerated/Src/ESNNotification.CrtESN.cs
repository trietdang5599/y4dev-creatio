namespace Terrasoft.Configuration
{

	using Core.Store;
	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Messaging.Common;
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
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: ESNNotification_CrtESNEventsProcess

	public partial class ESNNotification_CrtESNEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void PublishClientNotificationInfo(string operation) {
			var contactId = Entity.OwnerId;
			var sysAdminUnit = NotificationUtilities.GetSysAdminUnitId(UserConnection, contactId);
			var message = new {
				recordId = Entity.Id,
				operation,
				notificationGroup = "ESNNotification",
				markAsRead = Entity.IsRead
			};
			var simpleMessage = new SimpleMessage {
				Body = JsonConvert.SerializeObject(message),
				Id = sysAdminUnit
			};
			simpleMessage.Header.Sender = "UpdateReminding";
			var manager = MsgChannelManager.Instance;
			var channel = manager.FindItemByUId(sysAdminUnit);
			channel?.PostMessage(simpleMessage);
		}

		#endregion

	}

	#endregion

}

