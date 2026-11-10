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
	using System.Security;
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
	using TSConfiguration = Terrasoft.Configuration;

	#region Class: BaseTag_CrtBaseEventsProcess

	public partial class BaseTag_CrtCoreBaseEventsProcess<TEntity>
	{
		#region Methods: Public

		public virtual void CheckCanManageTags() {
			Guid typeOldId = Entity.GetTypedOldColumnValue<Guid>("TypeId");
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (typeOldId != Guid.Empty && typeOldId != TSConfiguration.TagConsts.PrivateTagTypeUId && typeOldId != typeId) {
				throw new SecurityException(ChangeTypeFailMsg);
			}
			if (typeId == TSConfiguration.TagConsts.CorporateTagTypeUId) {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageCorporateTags");
			}
			if (typeId == TSConfiguration.TagConsts.PublicTagTypeUId) {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManagePublicTags");
			}
		}

		public virtual void CheckTagTypeAndGrantAdditionalRights() {
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (typeId == TSConfiguration.TagConsts.CorporateTagTypeUId) {
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(TSConfiguration.BaseConsts.AllEmployersSysAdminUnitUId,
						Entity.Schema, Entity.PrimaryColumnValue, SchemaRecordRightLevels.All);
			}
			if (typeId == TSConfiguration.TagConsts.PublicTagTypeUId) {
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(TSConfiguration.BaseConsts.AllEmployersSysAdminUnitUId,
						Entity.Schema, Entity.PrimaryColumnValue, SchemaRecordRightLevels.All);
			}
		}

		#endregion

	}

	#endregion

}

