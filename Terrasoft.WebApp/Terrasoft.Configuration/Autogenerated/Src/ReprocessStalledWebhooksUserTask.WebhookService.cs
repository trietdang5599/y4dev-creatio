namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: ReprocessStalledWebhooksUserTask

	/// <exclude/>
	public partial class ReprocessStalledWebhooksUserTask
	{

		#region Fields: Private

		private const int StalledWebhookMaxRowCount = 50;
		private const int StalledWebhookThresholdMinutes = 15;

		#endregion

		#region Properties: Private

		private IWebhookJobDispatcher _webhookJobDispatcher;
		private IWebhookJobDispatcher WebhookJobDispatcher =>
			_webhookJobDispatcher ?? (_webhookJobDispatcher = ClassFactory.Get<IWebhookJobDispatcher>(
				new ConstructorArgument("userConnection", UserConnection)
			));

		#endregion

		#region Methods: Private

		private List<Guid> GetStalledWebhookBatchIds() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Webhook") {
				RowCount = StalledWebhookMaxRowCount,
				IsDistinct = true
			};
			var batchIdColumn = esq.AddColumn("BatchId");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status",
				new Guid(WebhookServiceConstants.NewWebhookStatus)));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Less, "CreatedOn",
				GetStalledWebhookThresholdTime()));
			esq.Filters.Add(esq.CreateIsNotNullFilter("BatchId"));
			var entities = esq.GetEntityCollection(UserConnection);
			var batchIds = new List<Guid>();
			foreach (var entity in entities) {
				batchIds.Add(entity.GetTypedColumnValue<Guid>(batchIdColumn.Name));
			}
			return batchIds;
		}

		private DateTime GetStalledWebhookThresholdTime() {
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.AddMinutes(-StalledWebhookThresholdMinutes),UserConnection.CurrentUser.TimeZone);
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var batchIds = GetStalledWebhookBatchIds();
			if (batchIds.Count > 0) {
				WebhookJobDispatcher.ScheduleJobs(batchIds);
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

