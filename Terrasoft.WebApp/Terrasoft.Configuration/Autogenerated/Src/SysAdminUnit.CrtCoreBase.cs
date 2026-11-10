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
	using Terrasoft.Core.OperationLog;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;
	using Terrasoft.Web.Common;

	#region Class: SysAdminUnit_CrtBaseEventsProcess

	public partial class SysAdminUnit_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void RemoveItemFromCache(string key) {
			ActivityUtils.SetOrRemoveItemInActivityCache(UserConnection, key);
		}

		public override void CheckCanManageLookups() {
		}

		public virtual bool GetIsAdminUnitNotUser() {
			return (Entity.SysAdminUnitTypeValue != 4) && (Entity.SysAdminUnitTypeValue != 5);
		}

		#endregion

	}

	#endregion

}

