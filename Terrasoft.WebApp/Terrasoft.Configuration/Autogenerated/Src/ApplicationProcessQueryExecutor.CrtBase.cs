namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class

	/// <summary>
	/// Query executor for business processes.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ApplicationProcessQueryExecutor")]
	public class ApplicationProcessQueryExecutor : BaseApplicationSchemaQueryExecutor<ProcessSchema>
	{

		#region Constructors: Public

		public ApplicationProcessQueryExecutor(UserConnection userConnection, IAppManager appManager)
			: base(userConnection, appManager) { }

		#endregion

		#region Methods: Private

		private static string GetTag(ISchemaManagerItem<ProcessSchema> schemaManagerItem) {
			var tag = schemaManagerItem.ExtraProperties.FindByName("Tag");
			return tag?.Value?.ToString();
		}

		private List<ISchemaManagerItem<ProcessSchema>> GetActualProcesses(
		List<ISchemaManagerItem<ProcessSchema>> notHandledProcesses) {
			var actualProcesses = new List<ISchemaManagerItem<ProcessSchema>>();
			while (notHandledProcesses.Count > 0) {
				var process = notHandledProcesses.First();
				var versionsOfProcess = GetVersionsOfProcess(process.UId, notHandledProcesses);
				RemoveHandledVersions(notHandledProcesses, versionsOfProcess);
				var activeItem = GetActiveVersion(versionsOfProcess);
				if (activeItem != null) {
					actualProcesses.Add(activeItem);
					continue;
				}
				var latestItem = GetLatestVersion(versionsOfProcess);
				actualProcesses.Add(latestItem);
			}
			return actualProcesses;
		}

		private List<ISchemaManagerItem<ProcessSchema>> GetVersionsOfProcess(
				Guid processUId, List<ISchemaManagerItem<ProcessSchema>> notHandledProcesses) {
			return ((IEnumerable<ISchemaManagerItem<ProcessSchema>>)
				UserConnection.ProcessSchemaManager.GetAllVersionItems(processUId))
				.Where(p => notHandledProcesses.Select(a => a.UId).Contains(p.UId)).ToList();
		}

		private void RemoveHandledVersions(
			List<ISchemaManagerItem<ProcessSchema>> notHandledProcesses,
			List<ISchemaManagerItem<ProcessSchema>> versionsOfProcess) {
			notHandledProcesses.RemoveAll(p => versionsOfProcess.Select(a => a.UId).Contains(p.UId));
		}

		private ISchemaManagerItem<ProcessSchema> GetActiveVersion(
				List<ISchemaManagerItem<ProcessSchema>> versionsOfProcess) {
			return versionsOfProcess
					.FirstOrDefault(a => UserConnection.ProcessSchemaManager.GetIsActiveVersion(a.Id));
		}

		private ISchemaManagerItem<ProcessSchema> GetLatestVersion(
				List<ISchemaManagerItem<ProcessSchema>> versionsOfProcess) {
			var maxVersion = versionsOfProcess.Max(p => UserConnection.ProcessSchemaManager.GetVersion(p));
			var maxVersionItems = versionsOfProcess.Where(p => UserConnection.ProcessSchemaManager.GetVersion(p) == maxVersion);
			return maxVersionItems.OrderByDescending(m => m.ModifiedOn).First();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override string ResultEntitySchemaName => "ApplicationProcess";

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override SchemaManager<ProcessSchema> GetSchemaManager() => UserConnection.ProcessSchemaManager;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override IEnumerable<ISchemaManagerItem<ProcessSchema>> GetSchemaManagerItems(IEnumerable<Guid> appIds, 
				IEnumerable<Guid> pkgIds) {
			var notHandledProcesses = base.GetSchemaManagerItems(appIds, pkgIds)
				.Where(item => !string.IsNullOrWhiteSpace(GetTag(item))).ToList();
			if (notHandledProcesses.Count == 0) {
				return notHandledProcesses;
			}
			return GetActualProcesses(notHandledProcesses);
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override void MapAdditionalColumns(Entity entity,
				ISchemaManagerItem<ProcessSchema> schemaManagerItem) {
			entity.SetColumnValue("IsEnabled",
				UserConnection.ProcessSchemaManager.GetIsProcessEnabled(schemaManagerItem.Id));
			entity.SetColumnValue("Version", UserConnection.ProcessSchemaManager.GetVersion(schemaManagerItem));
			entity.SetColumnValue("IsActual", UserConnection.ProcessSchemaManager.GetIsActiveVersion(schemaManagerItem.Id));
		}

		#endregion

	}

	#endregion

}

