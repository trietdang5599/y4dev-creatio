namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Process;
	using Terrasoft.Common;
	using System.Linq;
	using Terrasoft.Core.Configuration;

	#region Class: RecordDeleterWithStopProcess

	public class RecordDeleterWithStopProcess : RecordDeleter {

		#region Constructors: Public

		public RecordDeleterWithStopProcess(UserConnection userConnection,
				IDictionary<string, object> parameters) : base(userConnection, parameters) {
		}

		#endregion

		#region Methods: Private
		
		private void DeleteWithCancelExecutionProcess(Collection<ProcessListener> processListeners) {
			ProcessEngineUtilities.CancelParentProcess(_userConnection, processListeners);
			base.DeleteOperation();
		}
		
		#endregion

		#region Methods: Public
		
		protected override void DeleteOperation() {
			try {
				base.DeleteOperation();
			} catch (EntityUsedByProcessException exception) {
				DeleteWithCancelExecutionProcess(exception.ProcessListeners);
			}
		}

		#endregion
		
	}

	#endregion
	
}
