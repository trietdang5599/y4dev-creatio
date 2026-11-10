namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using DCEntityCollection = Nui.ServiceModel.DataContract.EntityCollection;

	#region EmailTimelineDataLoader

	/// <summary>
	/// Timeline data loader for email entities.
	/// </summary>
	[DefaultBinding(typeof(ITimelineDataLoader), Name = "Email")]
	public class EmailTimelineDataLoader : EsqTimelineDataLoader
	{

		#region Constants: Private

		private const string _emailMetadataColumn = "[EmailMetadata:Activity:Id].Preview";
		private const string _emailBodyColumn = "Body";
		private const string _isHtmlBodyColumn = "IsHtmlBody";
		private const string _emailIsReadMoreColumn = "IsReadMoreVisible";
		private int _maxSizeColumnValue;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailTimelineDataLoader"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public EmailTimelineDataLoader(UserConnection userConnection) : base(userConnection) {
			_maxSizeColumnValue = TimelineUtilities.GetEmailMaxSizeColumnValue(userConnection);
		}

		public EmailTimelineDataLoader(UserConnection userConnection, IEmailTimelinePreviewCreator timelinePreviewCreator,
			IEmailContentProcessor emailContentProcesso) : this(userConnection) {
			_emailTimelinePreviewCreator = timelinePreviewCreator;
			_emailContentProcessor = emailContentProcesso;
		}

		#endregion

		#region Properties: Protected

		private IEmailContentProcessor _emailContentProcessor;
		protected IEmailContentProcessor EmailContentProcessor =>
			_emailContentProcessor ?? (_emailContentProcessor = ClassFactory.Get<IEmailContentProcessor>());

		private IEmailTimelinePreviewCreator _emailTimelinePreviewCreator;
		protected IEmailTimelinePreviewCreator EmailTimelinePreviewCreator =>
			_emailTimelinePreviewCreator ?? (_emailTimelinePreviewCreator =
				ClassFactory.Get<IEmailTimelinePreviewCreator>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private Dictionary<string, string> GetLatestEmailMetadataPreviews(DCEntityCollection mappedItems) {
			var result = new Dictionary<string, string>();
			var activityIds = new HashSet<Guid>();
			foreach (var record in mappedItems) {
				if (Guid.TryParse(record.GetValue<string>(_idColumnName, string.Empty), out Guid activityId)) {
					activityIds.Add(activityId);
				}
			}
			if (!activityIds.Any()) {
				return result;
			}
			var metadataSelect = new Select(UserConnection)
				.Column("ActivityId")
				.Column("Preview")
				.From("EmailMetadata")
				.Where("ActivityId").In(Column.Parameters(activityIds))
				.OrderByAsc("ActivityId")
				.OrderByDesc("ModifiedOn") as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = metadataSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var activityId = dataReader.GetColumnValue<Guid>("ActivityId").ToString();
						if (!result.ContainsKey(activityId)) {
							result[activityId] = dataReader.GetColumnValue<string>("Preview") ?? string.Empty;
						}
					}
				}
			}
			return result;
		}

		private string ConvertPlainToHtml(string message) {
			return message?
				.Replace("&", "&amp;")
				.Replace("<", "&lt;")
				.Replace(">", "&gt;")
				.Replace("\"", "&quot;")
				.Replace("'", "&#039;")
				.Replace("\r\n", "<br>")
				.Replace("\n", "<br>")
				.Replace("\r", "<br>");
		}

		#endregion

		#region Methods: Protected

		protected override DCEntityCollection ModifyMappedItems(Dictionary<string, string> columnAliases,
			DCEntityCollection mappedItems, TimelineRequestConfig config) {
				var baseCollection = base.ModifyMappedItems(columnAliases, mappedItems, config);
				var emailMetadataPreviews = GetLatestEmailMetadataPreviews(baseCollection);
				foreach (var record in baseCollection) {
					emailMetadataPreviews.TryGetValue(record.GetValue<string>(_idColumnName, string.Empty), out string emailMetadataColumnValue);
					emailMetadataColumnValue = emailMetadataColumnValue ?? string.Empty;
					if (string.IsNullOrEmpty(emailMetadataColumnValue))  {
						var bodyColumnValue = record.GetValue<string>(_emailBodyColumn, string.Empty);
						var sizeValue = ASCIIEncoding.ASCII.GetByteCount(bodyColumnValue);
						int substrSizeValue; 
						if (sizeValue >= _maxSizeColumnValue && EmailQuoteChecker.ShouldTrimEmail(bodyColumnValue, _maxSizeColumnValue, out substrSizeValue)) {
							record.Add(_emailIsReadMoreColumn, true);
							if (!record.ContainsKey(_isHtmlBodyColumn)) {
								record.Add(_isHtmlBodyColumn, true);
							}
							var substrBody = bodyColumnValue.Substring(0, substrSizeValue);
							var largeEmailsInTimelineFeature = UserConnection.GetIsFeatureEnabled("LargeEmailsInTimeline.GetLastEmailSynchronously");
							record[_emailBodyColumn] = largeEmailsInTimelineFeature ?
								EmailContentProcessor.GetPreview(substrBody) : string.Empty;
							var previewForCreator = largeEmailsInTimelineFeature ?
								record[_emailBodyColumn].ToString() : substrBody;
							if (!record.GetValue<bool>(_isHtmlBodyColumn, true)) {
								previewForCreator = ConvertPlainToHtml(previewForCreator);
							}
							EmailTimelinePreviewCreator.GetAndSavePreview(record[_idColumnName].ToString(), config.MasterRecordId, previewForCreator);
						}
						if (!record.GetValue<bool>(_isHtmlBodyColumn, true)) {
							record[_emailBodyColumn] = ConvertPlainToHtml(record[_emailBodyColumn] as string);
						}
				} else if (record.ContainsKey(_emailBodyColumn)) {
						record.Add(_emailIsReadMoreColumn, true);
						record[_emailBodyColumn] = emailMetadataColumnValue;
					}
				}
				return baseCollection;				
			}


		protected override void AddQueryColumns(TimelineBoundEntity entity, TimelineRequestConfig config, EntitySchemaQuery esq,
			Dictionary<string, string> columnAliases) {
			base.AddQueryColumns(entity, config, esq, columnAliases);
			var isHtmlBoundColumn = esq.AddColumn(_isHtmlBodyColumn);
			columnAliases.Add(isHtmlBoundColumn.Name, _isHtmlBodyColumn);
		}

		#endregion

	}

	#endregion

} 
