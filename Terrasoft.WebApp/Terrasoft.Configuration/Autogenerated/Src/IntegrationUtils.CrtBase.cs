using System;
using Terrasoft.Core;
using Terrasoft.Core.DB;
using System.Data;

namespace Terrasoft.Configuration
{
	public class IntegrationUtils
	{
		public static void WriteSyncResult(UserConnection userConnection, Guid system, Guid direction, Guid result, Guid operation, string description)
		{
			var IntegrationLogSchema = userConnection.EntitySchemaManager.FindInstanceByName("IntegrationLog");
			var IntegrationLog = IntegrationLogSchema.CreateEntity(userConnection);
			IntegrationLog.SetDefColumnValues();
			IntegrationLog.SetColumnValue("IntegrationSystemId", system);
			IntegrationLog.SetColumnValue("DirectionId", direction);
			IntegrationLog.SetColumnValue("ResultId", result);
			IntegrationLog.SetColumnValue("OperationId", operation);
			IntegrationLog.SetColumnValue("ErrorDescription", description);
			IntegrationLog.SetColumnValue("Date", DateTime.UtcNow);
			IntegrationLog.Save();
		}
	}	
}
