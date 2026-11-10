 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using CoreSysSettings = Core.Configuration.SysSettings;
	using System.Threading;
	using global::Common.Logging;
	using Terrasoft.Core.Entities;

	#region Class: FilesGarbageCollectorJob

	/// <summary>
	/// Provides methods to collect and remove unlinked entities etc.
	/// </summary>
	public class FilesGarbageCollectorJob : IJobExecutor
	{

		#region Properties: Protected

		private ILog _logger;
		protected ILog FileLogger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger("FilesGarbageCollectorJob"));
			}
		}

		#endregion

		#region Methods: Private

		private Guid GetFileId(UserConnection userConnection, DateTime modifiedOn) {
			return (new Select(userConnection)
				.Column("Id")
				.From("SysFile")
				.Where("ToDelete").IsEqual(Column.Parameter(true)) 
				.And("ModifiedOn").IsLess(Column.Parameter(modifiedOn))
				as Select).ExecuteScalar<Guid>();
		}
		private void DeleteFiles(UserConnection userConnection) {
			try {
				var currentDateTime = userConnection.CurrentUser.GetCurrentDateTime();
				var delayPeriod = CoreSysSettings.GetValue(userConnection, "FileDeletionDelayPeriod", 2);
				var modifiedOn = currentDateTime.AddDays(-delayPeriod).ToUniversalTime();
				var fileId = GetFileId(userConnection, modifiedOn);
				while (fileId != Guid.Empty) {
					EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByName("SysFile");
					Entity fileEntity = schema.CreateEntity(userConnection);
					var fileFound = fileEntity.FetchFromDB(fileId);
					try {
						if (fileFound) {
							fileEntity.Delete();
						}
					} catch (Exception ex) {
						fileEntity.SetColumnValue("LastError", ex.ToString());
						fileEntity.SetColumnValue("ToDelete", false);
						fileEntity.Save(false);
					}
					delayPeriod = CoreSysSettings.GetValue(userConnection, "FileDeletionDelayPeriod", 2);
					currentDateTime = userConnection.CurrentUser.GetCurrentDateTime();
					modifiedOn = currentDateTime.AddDays(-delayPeriod).ToUniversalTime();
					fileId = GetFileId(userConnection, modifiedOn);
					Thread.Sleep(10);
				}
			} catch (Exception ex) {
				FileLogger.ErrorFormat("Exception has occured while attempting to delete file entries ", ex);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Collect files garbage.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			DeleteFiles(userConnection);
		}

		#endregion
		
	}

	#endregion

}
