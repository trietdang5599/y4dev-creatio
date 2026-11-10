namespace Terrasoft.Configuration {
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: RecordDeleter

	public class RecordDeleter : BaseRecordExecutor
	{

		#region Constructors: Public

		public RecordDeleter(UserConnection userConnection, IDictionary<string, object> parameters)
				: base(userConnection, parameters) {
			RecordRightOperation = SchemaRecordRightLevels.CanDelete;
			RightExceptionMessage = "EntitySchema.Exception.NoRightFor.Delete";
		}

		#endregion

		#region Methods: Public
		
		protected override void DeleteOperation() {
			Entity.DeleteWithCancelProcess();
		}

		#endregion
		
	}

	#endregion
	
}
