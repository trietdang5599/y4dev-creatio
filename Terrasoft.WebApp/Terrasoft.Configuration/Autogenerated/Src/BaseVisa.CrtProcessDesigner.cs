namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Mail;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: BaseVisa_CrtProcessDesignerEventsProcess

	public partial class BaseVisa_CrtProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public
		
		public override bool BaseVisaSaved(ProcessExecutingContext context) {
			var visaOwnerId = Entity.VisaOwnerId;
			if (visaOwnerId.IsNotEmpty() && oldVisaOwnerId.IsNotEmpty() && visaOwnerId != oldVisaOwnerId) {
				var userConnection = context.UserConnection;
				var userTask = (ApprovalUserTask)userConnection.ProcessEngine.FindProcessElementByUId(Entity.Id);
				userTask?.SendEmailToApprovers(visaOwnerId);
			}
			return base.BaseVisaSaved(context);
		}

		#endregion

	}

	#endregion

}

