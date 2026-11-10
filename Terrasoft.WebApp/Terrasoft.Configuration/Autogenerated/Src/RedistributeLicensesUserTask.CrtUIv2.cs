namespace Terrasoft.Core.Process.Configuration
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Configuration.CrtUIv2;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.Core.Factories;

	#region Class: RedistributeLicensesUserTask

	/// <exclude/>
	public partial class RedistributeLicensesUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var licenseRedistributionService = ClassFactory.Get<ILicenseRedistributionService>();
			if(RedistributeLicencesForSpecificRole) {
				licenseRedistributionService.RedistributeLicencesForRole(RedistributeManuallyAssignedLicences, RoleId);
			} else {
				licenseRedistributionService.RedistributeLicences(RedistributeManuallyAssignedLicences);
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}