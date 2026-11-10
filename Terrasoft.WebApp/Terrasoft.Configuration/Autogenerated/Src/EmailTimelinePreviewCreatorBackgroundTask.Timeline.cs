namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Tasks;
	using Terrasoft.Nui.ServiceModel.DataContract;

	#region Class : EmailTimelinePreviewCreatorBackgroundTaskDto

	/// <summary>
	///Represents a Dto for EmailTimelinePreviewCreatorExecutor.
	/// </summary>
	public class EmailTimelinePreviewCreatorBackgroundTaskDto {
		/// <summary>
		/// Activity identifier of email.
		/// </summary>
		public Guid EmailId { get; set; }
		/// <summary>
		/// The master record for which the preview is creating.
		/// </summary>
		public Guid RecordId { get; set; }
		/// <summary>
		/// TContent of email body.
		/// </summary>
		public string Content { get; set; }
	}

	#endregion

	#region Class : EmailTimelinePreviewCreatorBackgroundTask

	/// <summary>
	///Represents a asynchronous Email preview creator.
	/// </summary>
	public class EmailTimelinePreviewCreatorBackgroundTask : IBackgroundTask<EmailTimelinePreviewCreatorBackgroundTaskDto>,
		IUserConnectionRequired
	{

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Properties: Public

		private IEmailContentProcessor _emailContentProcessor;
		/// <summary>
		/// Class responsible for processing email content.
		/// Implements the <see cref="IEmailContentProcessor"/> interface.
		/// </summary>
		public IEmailContentProcessor EmailContentProcessor {
			get	{
				return _emailContentProcessor ?? (_emailContentProcessor = ClassFactory.Get<IEmailContentProcessor>());
			}
			set { 
				_emailContentProcessor = value;
			}
		}
			

		private TimelineDataCacheRepository _cacheRepository;
		/// <summary>
		/// Timeline cache repository.
		/// </summary>
		public TimelineDataCacheRepository CacheRepository => _cacheRepository ??
			(_cacheRepository = new TimelineDataCacheRepository(UserConnection));

		private EmailPreviewNotifier _previewNotifier;
		/// <summary>
		/// Class responsible for sending email content to client via WS.
		/// </summary>
		public EmailPreviewNotifier PreviewNotifier { 
			get {
				return _previewNotifier ?? (_previewNotifier = new EmailPreviewNotifier());
			}
			set {
				_previewNotifier = value;
			} 
		}

		#endregion

		#region Methods : Private

		private void UpdateTimelineCache(string preview, Guid recordId, Guid emailId) {
			// Update cache for both order directions since we don't know which one is currently used
			foreach (OrderDirection orderDirection in new[] { OrderDirection.Ascending, OrderDirection.Descending }) {
				if (CacheRepository.TryGetTimelineDataFromCache(recordId.ToString(), orderDirection, out var entitiesFromCache)) {
					var entity = entitiesFromCache.FirstOrDefault(e => e.EntityId == emailId);
					if (entity != null)	{
						var column = entity.ColumnValues.FirstOrDefault(c => c.ColumnName == "Body");
						if (column != null)	{
							column.ColumnValue = new LookupColumnValue { Value = preview };
						}
					}
					CacheRepository.SetTimelineDataCache(recordId.ToString(), orderDirection, entitiesFromCache);
				}
			}
		}

		#endregion

		#region Methods : Protected

		protected virtual void SavePreview(string preview, Guid emailId) {
			var schema = UserConnection.EntitySchemaManager.FindInstanceByName("EmailMetadata");
			var existingMetadataSelect = new Select(UserConnection)
				.Top(1)
				.Column("Id")
				.From("EmailMetadata")
				.Where("ActivityId").IsEqual(Column.Parameter(emailId))
				.OrderByDesc("ModifiedOn") as Select;
			var existingMetadataId = existingMetadataSelect.ExecuteScalar<Guid>();
			var emailMetadataEntity = schema.CreateEntity(UserConnection);
			if (existingMetadataId != Guid.Empty && emailMetadataEntity.FetchFromDB(existingMetadataId)) {
				emailMetadataEntity.SetColumnValue("Preview", preview);
				emailMetadataEntity.Save();
				return;
			}
			emailMetadataEntity.SetDefColumnValues();
			emailMetadataEntity.SetColumnValue("ActivityId", emailId);
			emailMetadataEntity.SetColumnValue("Preview", preview);
			emailMetadataEntity.Save();
		}

		#endregion

		#region Methods : Public

		/// <inheritdoc cref="IBackgroundTask.Run(TParameters)"/>
		public void Run(EmailTimelinePreviewCreatorBackgroundTaskDto parameters) {
			if (parameters == null) {
				throw new ArgumentNullOrEmptyException("parameters(EmailTimelinePreviewCreatorBackgroundTaskDto) can't be null");
			}
			string preview = parameters.Content;
			if (parameters.EmailId != Guid.Empty && parameters.RecordId != Guid.Empty) {
				if (!UserConnection.GetIsFeatureEnabled("LargeEmailsInTimeline.GetLastEmailSynchronously")) {
					preview = EmailContentProcessor.GetPreview(preview);
					PreviewNotifier.SendEmailPreview(new EmailPreview { EmailId = parameters.EmailId, PreviewBody = preview }, UserConnection.CurrentUser.Id);
					UpdateTimelineCache(preview, parameters.RecordId, parameters.EmailId);
				}
				SavePreview(preview, parameters.EmailId);
			} else {
				throw new ArgumentException($"parameters must be specified EmailId = {parameters.EmailId}, RecordId = {parameters.RecordId}");
			}
		}

		/// <inheritdoc cref="IUserConnectionRequired.SetUserConnection(UserConnection)"/>
		public void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

	}

	#endregion

}
