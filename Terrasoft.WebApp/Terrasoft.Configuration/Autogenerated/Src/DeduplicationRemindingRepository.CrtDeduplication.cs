namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	/// <summary>
	/// Default implementation of <see cref="IDeduplicationRemindingRepository"/>
	/// </summary>
	[DefaultBinding(typeof(IDeduplicationRemindingRepository))]
	public class DeduplicationRemindingRepository : IDeduplicationRemindingRepository
	{

		#region Fields: Private

		private const int DescriptionTypeStringLength = 250;
		private const int SubjectCaptionTypeStringLength = 500;

		#endregion

		#region Methods: Private

		private static string GetRemindingHash(Dictionary<string, object> dictionary) {
			var str = new StringBuilder();
			foreach (object value in dictionary.Values) {
				str.Append(value);
			}
			return FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
		}

		private static string TruncateString(string source, int length) {
			return source.Length > length ? source.Substring(0, length) : source;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDeduplicationRemindingRepository.CreateReminding"/>>
		public void CreateReminding(UserConnection userConnection, string remindingDescription,
				string remindingSubject, string schemaName) {
			Reminding remindingEntity = new Reminding(userConnection);
			var manager = userConnection.GetSchemaManager("EntitySchemaManager");
			IManagerItem targetSchema = manager.GetItemByName(schemaName);
			manager = userConnection.GetSchemaManager("ClientUnitSchemaManager");
			IManagerItem loaderSchema = manager.GetItemByName("DuplicatesSearchNotificationTargetLoader");
			var subject = schemaName;
			DateTime userDateTime = userConnection.CurrentUser.GetCurrentDateTime();
			Guid userContactId = userConnection.CurrentUser.ContactId;
			var condition = new Dictionary<string, object> {
				{
					"Author", userContactId
				}, {
					"Contact", userContactId
				}, {
					"Source", RemindingConsts.RemindingSourceAuthorId
				}, {
					"SubjectCaption", subject
				}, {
					"SysEntitySchema", targetSchema.UId
				},
			};
			string hash = GetRemindingHash(condition);
			subject = remindingSubject;
			if (!remindingEntity.FetchFromDB(new Dictionary<string, object> { { "Hash", hash } }, false)) {
				remindingEntity.SetDefColumnValues();
			}
			subject = TruncateString(subject, SubjectCaptionTypeStringLength);
			remindingEntity.SetColumnValue("ModifiedOn", userDateTime);
			remindingEntity.SetColumnValue("AuthorId", userContactId);
			remindingEntity.SetColumnValue("ContactId", userContactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userDateTime);
			remindingEntity.SetColumnValue("Description", remindingDescription);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("NotificationTypeId", RemindingConsts.NotificationTypeNotificationId);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.SetColumnValue("SysEntitySchemaId", targetSchema.UId);
			remindingEntity.SetColumnValue("LoaderId", loaderSchema.UId);
			remindingEntity.SetColumnValue("IsRead", false);
			remindingEntity.Save();
		}

		#endregion

	}

}
