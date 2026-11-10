namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.UsageContext;

	#region Class: MultiDeleteWorker

	public class MultiDeleteWorker : BaseRecordsOperationWorker
	{

		#region Constructors: Public

		public MultiDeleteWorker(UserConnection userConnection, IDictionary<string, object> parameters)
				: base(userConnection, parameters) {
			if (parameters.ContainsKey("IsCascade") && (bool)parameters["IsCascade"] == true) {
				OperationExecutor = new RecordDeleterWithStopProcess(userConnection, parameters);
			} else {
				OperationExecutor = new RecordDeleter(userConnection, parameters);
			}
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override void InitializeEsq(EntitySchemaQuery entitySchemaQuery) {
			entitySchemaQuery.SetUsageContext(UsageContext, CrudOperationType.Delete);
			base.InitializeEsq(entitySchemaQuery);
		}

		protected override Entity GetPreparedEntity(Entity entity) {
			return entity;
		}
		
		protected override Exception GetOperationException() {
			RecordDeleter recordDeleter = (RecordDeleter)OperationExecutor;
			return recordDeleter.OperationException;
		}
		
		#endregion
		
	}

	#endregion
	
}

