namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.Interfaces;
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Store;

	#region Class: OmnichannelContactIdentifier

	/// <summary>
	/// Class that identifies contact by messenger identifier.
	/// </summary>
	public class OmnichannelContactIdentifier
	{

		#region Constants: Public

		public static string ContactsByIdentifierCacheKey = "OmnichannelContactsByChannelAndIdentifierV2";

		#endregion

		#region Class: ContactIdentityCacheItem

		[Serializable]
		private class ContactIdentityCacheItem
		{
			public Guid ContactId {
				get;
				set;
			}

			public bool HasChannelIdentity {
				get;
				set;
			}

			public bool HasAlternateChannelIdentity {
				get;
				set;
			}
		}

		#endregion

		#region Properties: Private

		private static readonly string[] _contactColumnWhiteList = new string[] { "Name", "Email" };

		private readonly string _newContactName = "NewContactNameLocalizableString";

		private const string DisableContactIdentityRaceFixFeatureName = "DisableOmniContactIdentityRaceFix";

		private static bool _isNeedToUpdateCacheInstance;

		ConcurrentDictionary<string, ContactIdentityCacheItem> _contactsByChannelAndIdentifier;
		private ConcurrentDictionary<string, ContactIdentityCacheItem> ContactsByChannelAndIdentifier {
			get {
				if (_isNeedToUpdateCacheInstance) {
					_contactsByChannelAndIdentifier =
						UserConnection.ApplicationCache.GetValue<ConcurrentDictionary<string, ContactIdentityCacheItem>>(ContactsByIdentifierCacheKey);
					_isNeedToUpdateCacheInstance = false;
				} else {
					_contactsByChannelAndIdentifier = _contactsByChannelAndIdentifier ?? UserConnection.ApplicationCache
						.GetValue<ConcurrentDictionary<string, ContactIdentityCacheItem>>(ContactsByIdentifierCacheKey);
				}
				if (_contactsByChannelAndIdentifier == null) {
					InitializeContactsByIdentifier();
				}
				return _contactsByChannelAndIdentifier;
			}
		}

		private readonly MessageWorkerFactory<IProfileDataProvider> _profileDataProviderFactory;
		private readonly ProfileImageLoader _profileImageLoader;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection	{
			get;
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private static ILog _log;
		protected static ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelContactIdentifier"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="OmnichannelContactIdentifier"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public OmnichannelContactIdentifier(UserConnection userConnection) {
			UserConnection = userConnection;
			_profileDataProviderFactory = new MessageWorkerFactory<IProfileDataProvider>(userConnection);
			_profileImageLoader = new ProfileImageLoader(UserConnection);
		}

		#endregion

		#region Methods: Private

		private void InitializeContactsByIdentifier() {
			_contactsByChannelAndIdentifier = new ConcurrentDictionary<string, ContactIdentityCacheItem>();
			UserConnection.ApplicationCache
				.SetOrRemoveValue(ContactsByIdentifierCacheKey, _contactsByChannelAndIdentifier);
		}

		private ContactIdentityCacheItem CreateCacheItem(Guid contactId, MessagingMessage message) {
			return new ContactIdentityCacheItem {
				ContactId = contactId,
				HasChannelIdentity = GetChannelIdentity(message).IsNotNullOrEmpty(),
				HasAlternateChannelIdentity = GetAlternateChannelIdentity(message).IsNotNullOrEmpty()
			};
		}
		
		private Guid GetPhotoId(ProfileData contactData, string contactName) {
			var photoId = Guid.Empty;
			if (contactData?.ProfilePhoto != null) {
				photoId = _profileImageLoader.SaveImage(contactData.ProfilePhoto, contactName);
			} else if (!string.IsNullOrEmpty(contactData?.ProfilePhotoUrl)) {
				photoId = _profileImageLoader.GetProfilePhotoIdByUrl(contactData.ProfilePhotoUrl, contactName);
			}
			return photoId;
		}

		private void DeleteCreatedContact(Guid contactId) {
			new Delete(UserConnection)
				.From("Contact")
				.Where("Id").IsEqual(Column.Parameter(contactId))
				.Execute();
		}

		private Guid InsertIdentityContactInfo(Guid contactId, MessagingMessage message) {
			Entity contactIdentity = UserConnection.EntitySchemaManager
				.GetInstanceByName("ContactIdentity")
				.CreateEntity(UserConnection);
			contactIdentity.SetColumnValue("ContactId", contactId);
			string channelIdentity = GetChannelIdentity(message);
			if (channelIdentity.IsNotNullOrEmpty()) {
				contactIdentity.SetColumnValue("ChannelIdentity", channelIdentity);
			}
			string alternateChannelIdentity = GetAlternateChannelIdentity(message);
			if (alternateChannelIdentity.IsNotNullOrEmpty()) {
				contactIdentity.SetColumnValue("AlternateChannelIdentity", alternateChannelIdentity);
			}
			contactIdentity.SetColumnValue("ChannelId", message.ChannelId);
			contactIdentity.SetColumnValue("IsGuestUser", message.IsGuestUser);
			try {
				contactIdentity.Save(false);
			} catch (Exception e) {
				if (UserConnection.GetIsFeatureEnabled(DisableContactIdentityRaceFixFeatureName)) {
					Log.ErrorFormat("ContactIdentity insert failed for ContactId={0} on ChannelId={1};" +
						" the race fix is disabled ({2}), rethrowing. Reason: {3}",
						contactId, message.ChannelId, DisableContactIdentityRaceFixFeatureName, e.Message);
					throw;
				}
				Guid existingOwnerId = GetContactByIdentityKey(message);
				if (existingOwnerId != default(Guid)) {
					Log.WarnFormat("ContactIdentity for ChannelId={0} was already created by a parallel message;" +
						" linking to the existing ContactId={1} instead of creating a duplicate.",
						message.ChannelId, existingOwnerId);
					return existingOwnerId;
				}
				Log.ErrorFormat("Could not create ContactIdentity for ContactId={0} on ChannelId={1} and found no" +
					" existing identity to reuse; keeping ContactId={0} without a new identity. Reason: {2}",
					contactId, message.ChannelId, e.Message);
				return contactId;
			}
			Log.DebugFormat("ContactIdentity was created: ContactId={0}, ChannelIdentity={1}," +
				" AlternateChannelIdentity={2}, ChannelId={3}", contactId, channelIdentity, alternateChannelIdentity,
				message.ChannelId);
			return contactId;
		}

		private Guid GetContactByIdentityKey(MessagingMessage message) {
			if (message == null || !Guid.TryParse(message.ChannelId, out Guid channelId)) {
				return default(Guid);
			}
			string channelIdentity = GetChannelIdentity(message) ?? string.Empty;
			string alternateChannelIdentity = GetAlternateChannelIdentity(message) ?? string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.AddColumn("ChannelIdentity");
			esq.AddColumn("AlternateChannelIdentity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Channel", channelId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ChannelIdentity", channelIdentity));
			Entity match = esq.GetEntityCollection(UserConnection).FirstOrDefault(item =>
				string.Equals(item.GetTypedColumnValue<string>("AlternateChannelIdentity") ?? string.Empty,
					alternateChannelIdentity, StringComparison.OrdinalIgnoreCase));
			return match != null ? match.GetTypedColumnValue<Guid>("ContactId") : default(Guid);
		}

		private string GetAlternateChannelIdentity(MessagingMessage message) {
			if (message?.ExternalUserId.IsNotNullOrEmpty() == true) {
				return message.ExternalUserId;
			}
			return null;
		}

		private string GetPhoneNumber(MessagingMessage message) {
			if (message?.ContactIdentification != null
					&& message.ContactIdentification.TryGetValue(ContactIdentificationType.Phone, out string phoneNumber)
					&& phoneNumber.IsNotNullOrEmpty()) {
				return phoneNumber;
			}
			return null;
		}

		private string GetChannelIdentity(MessagingMessage message) {
			string phoneNumber = GetPhoneNumber(message);
			if (phoneNumber.IsNullOrEmpty()) {
				return GetAlternateChannelIdentity(message).IsNullOrEmpty()
					? message?.SenderIfEcho
					: null;
			}
			return message.SenderIfEcho?.EndsWith(phoneNumber, StringComparison.OrdinalIgnoreCase) == true
				? message.SenderIfEcho
				: null;
		}

		private Entity GetContactIdentityEntity(Guid contactId, string channelId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("ChannelIdentity");
			esq.AddColumn("AlternateChannelIdentity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Channel", Guid.Parse(channelId)));
			return esq.GetEntityCollection(UserConnection).FirstOrDefault();
		}

		private void UpdateMissingIdentityFields(Guid contactId, MessagingMessage message) {
			Entity contactIdentity = GetContactIdentityEntity(contactId, message.ChannelId);
			if (contactIdentity == null) {
				return;
			}
			bool isChanged = false;
			string channelIdentity = GetChannelIdentity(message);
			if (channelIdentity.IsNotNullOrEmpty()
					&& contactIdentity.GetTypedColumnValue<string>("ChannelIdentity").IsNullOrEmpty()) {
				contactIdentity.SetColumnValue("ChannelIdentity", channelIdentity);
				isChanged = true;
			}
			string alternateChannelIdentity = GetAlternateChannelIdentity(message);
			if (alternateChannelIdentity.IsNotNullOrEmpty()
					&& contactIdentity.GetTypedColumnValue<string>("AlternateChannelIdentity").IsNullOrEmpty()) {
				contactIdentity.SetColumnValue("AlternateChannelIdentity", alternateChannelIdentity);
				isChanged = true;
			}
			if (isChanged && contactIdentity.Save(false)) {
				Log.DebugFormat("Missing contact identities were updated for ContactId={0}, ChannelId={1}. " +
					"ChannelIdentity={2}, AlternateChannelIdentity={3}",
					contactId, message.ChannelId, channelIdentity, alternateChannelIdentity);
			}
		}

		private string GetContactName(string channelName, string contactIdentifier)		{
			return string.Format("{0} ({1} - {2})", new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"OmnichannelContactIdentifier", "LocalizableStrings." + _newContactName + ".Value").ToString(), 
				channelName, contactIdentifier);
		}

		private Guid GetExistingContact(MessagingMessage message) {
			Guid contactId = GetContactByAlternateChannelIdentity(message, out bool isNeedToCreateContactIdentity);
			if (contactId == default(Guid)) {
				contactId = GetContactByChannelIdentity(message, out isNeedToCreateContactIdentity);
			}
			if (contactId == default(Guid) && message.ContactIdentification != null) {
				contactId = GetContactByIdentification(message.ContactIdentification);
				isNeedToCreateContactIdentity = true;
			}
			if (contactId != default && isNeedToCreateContactIdentity) {
				contactId = InsertIdentityContactInfo(contactId, message);
			} else if (contactId != default) {
				UpdateMissingIdentityFields(contactId, message);
			}
			return contactId;
		}

		private Guid GetContactByAlternateChannelIdentity(MessagingMessage message, out bool isNeedToCreateContactIdentity) {
			string alternateChannelIdentity = GetAlternateChannelIdentity(message);
			if (alternateChannelIdentity.IsNullOrEmpty()) {
				isNeedToCreateContactIdentity = false;
				return default(Guid);
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"AlternateChannelIdentity", alternateChannelIdentity));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Channel", Guid.Parse(message.ChannelId)));
			var contactIdentityCollection = esq.GetEntityCollection(UserConnection);
			isNeedToCreateContactIdentity = contactIdentityCollection.IsEmpty();
			return contactIdentityCollection.Any()
				? contactIdentityCollection.First().GetTypedColumnValue<Guid>("ContactId")
				: default(Guid);
		}

		private Guid GetContactByChannelIdentity(MessagingMessage message, out bool IsContactIdentityByChannelExists) {
			string channelIdentity = GetChannelIdentity(message);
			if (channelIdentity.IsNullOrEmpty()) {
				IsContactIdentityByChannelExists = false;
				return default(Guid);
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.AddColumn("Channel");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ChannelIdentity", channelIdentity));
			var contactCollection = esq.GetEntityCollection(UserConnection);
			var contactIdentityCollection = contactCollection.Where((item) => item.GetTypedColumnValue<Guid>("ChannelId").ToString() == message.ChannelId);
			IsContactIdentityByChannelExists = contactIdentityCollection.IsEmpty();
			return contactIdentityCollection.Any()
				? contactIdentityCollection.First().GetTypedColumnValue<Guid>("ContactId")
				: default(Guid);
		}

		private Guid GetContactByIdentification(Dictionary<ContactIdentificationType, string> identification) {
			Guid contactId = default(Guid);
			if (identification.TryGetValue(ContactIdentificationType.Phone, out string phoneNumber) 
					&& phoneNumber.IsNotNullOrEmpty()) {
				contactId = GetContactByPhoneNumber(phoneNumber);
				if (contactId != default(Guid)) {
					return contactId;
				}
			}
			return contactId;
		}

		private Guid GetContactByPhoneNumber(string phoneNumber) {
			return ContactUtilities.GetContactsByPhone(UserConnection, phoneNumber).FirstOrDefault();
		}

		private void PushContactIdToCache(string cacheKey, ContactIdentityCacheItem cacheItem)	{
			ContactsByChannelAndIdentifier[cacheKey] = cacheItem;
			UserConnection.ApplicationCache
				.SetOrRemoveValue(ContactsByIdentifierCacheKey, ContactsByChannelAndIdentifier);
		}

		private bool TryGetContactIdFromCache(string cacheKey, out ContactIdentityCacheItem cacheItem)	{
			return ContactsByChannelAndIdentifier.TryGetValue(cacheKey, out cacheItem);
		}

		private bool NeedsIdentitySync(ContactIdentityCacheItem cacheItem, MessagingMessage message) {
			return (GetChannelIdentity(message).IsNotNullOrEmpty() && !cacheItem.HasChannelIdentity)
				|| (GetAlternateChannelIdentity(message).IsNotNullOrEmpty() && !cacheItem.HasAlternateChannelIdentity);
		}

		private void UpdateCacheItemIdentityState(ContactIdentityCacheItem cacheItem, MessagingMessage message) {
			if (GetChannelIdentity(message).IsNotNullOrEmpty()) {
				cacheItem.HasChannelIdentity = true;
			}
			if (GetAlternateChannelIdentity(message).IsNotNullOrEmpty()) {
				cacheItem.HasAlternateChannelIdentity = true;
			}
		}
		
		private void UpdateGuestMode(Guid contactId) {
			var update = new Update(UserConnection, "ContactIdentity")
				.Set("IsGuestUser", Column.Parameter(true))						
				.Where("ContactId").IsEqual(Column.Const(contactId)) as Update;
			update.Execute();
		}

		private void SetColumnsIfNotEmpty(Entity entity, IDictionary<string, object> updateData) {
			foreach (var updatedDataItem in updateData) {
				if (_contactColumnWhiteList.Contains(updatedDataItem.Key) && updatedDataItem.Value != null && !string.IsNullOrEmpty(updatedDataItem.Value.ToString())) {
					entity.SetColumnValue(updatedDataItem.Key, updatedDataItem.Value);
				}
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual ProfileData GetContactData(MessagingMessage message)	{
			if (message.ContactIdentification != null
					&& message.ContactIdentification.TryGetValue(ContactIdentificationType.Name, out string name)
					&& name.IsNotNullOrEmpty()) {
				return new ProfileData() {
					Id = message.SenderIfEcho,
					FirstName = name
				};
			}
			if (message.IsGuestUser) {
				return null;
			}
			var provider = _profileDataProviderFactory.GetWorkerByMessenger(message.ChannelName);
			return provider.GetProfileDataByProfileId(message.SenderIfEcho, message.ChannelId);
		}

		#endregion

		#region Methods: Public

		public Guid CreateNewContact(MessagingMessage message)	{
			var contactData = GetContactData(message);
			if (contactData != null) {
				Log.DebugFormat("Got contact data: first_name={0}, id={1}," +
					" picture_url={2}", contactData.FirstName, contactData.Id, contactData.ProfilePhotoUrl);
			} else {
				Log.DebugFormat("No contact data found");
			}
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			var contactId = Guid.NewGuid();
			contact.SetDefColumnValues();
			contact.SetColumnValue("Id", contactId);
			if (message.ContactIdentification != null && message.ContactIdentification.TryGetValue(ContactIdentificationType.Phone, out string phoneNumber)
					&& phoneNumber.IsNotNullOrEmpty()) {
				contact.SetColumnValue("MobilePhone", phoneNumber);
			}
			var contactName = (contactData != null) && (contactData.FirstName.IsNotNullOrEmpty() || contactData.LastName.IsNotNullOrEmpty()) ?
				contactData.FirstName + " " + contactData.LastName : GetContactName(message.ChannelName, message.SenderIfEcho);
			var photoId = GetPhotoId(contactData, contactName);
			if (photoId != Guid.Empty) {
				contact.SetColumnValue("PhotoId", photoId);
			}
			contact.SetColumnValue("Name", contactName);
			contact.Save(false);
			Log.InfoFormat("Contact with Name {0} and Id {1} was created", contactName, contactId);
			Guid createdContactId = contactId;
			try {
				contactId = InsertIdentityContactInfo(createdContactId, message);
			} catch (Exception e) {
				Log.ErrorFormat("Failed to create ContactIdentity for ContactId={0}, ChannelId={1}: {2}",
					createdContactId, message.ChannelId, e.Message);
				DeleteCreatedContact(createdContactId);
				return GetExistingContact(message);
			}
			if (contactId != createdContactId) {
				DeleteCreatedContact(createdContactId);
				Log.WarnFormat("Removed duplicate contact {0} created during a concurrent race;" +
					" using existing ContactId={1}", createdContactId, contactId);
			}
			return contactId;
		}

		/// <summary>
		/// Updates existing contact by additional data
		/// <param name="message">Incoming message.</param>
		/// <param name="updateData">Update data.</param>
		/// </summary>
		public bool UpdateContact(MessagingMessage message, IDictionary<string, object> updateColumnData) {
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			var contactId = GetContactId(message);
			if (contact.FetchFromDB(contactId)) {
				Log.DebugFormat("Contact with Id {1} is going to be updated", contactId);
				SetColumnsIfNotEmpty(contact, updateColumnData);
				return contact.Save();
			}
			Log.DebugFormat("Contact with Id {1} was not found", contactId);
			return false;
		}

		/// <summary>
		/// Creates ContactIdentity with flag isGuestUser = true
		/// <param name="message">Incoming message.</param>
		/// </summary>
		public void CreateGuestContactIdentity(MessagingMessage message) {
			Guid contactId = GetContactId(message);
			UpdateGuestMode(contactId);
			Log.Debug($"Set guest mode to true for contact {contactId}");
		}

		/// <summary>
		/// Finds an existing contact by sender identity without creating a new one.
		/// </summary>
		/// <param name="senderIdentity">Sender identity string.</param>
		/// <param name="channelId">Channel identifier string.</param>
		/// <returns>Contact identifier, or <see cref="Guid.Empty"/> if not found.</returns>
		public Guid FindExistingContactBySenderIdentity(string senderIdentity, string channelId) {
			if (string.IsNullOrEmpty(senderIdentity) || string.IsNullOrEmpty(channelId)) {
				return Guid.Empty;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactIdentity") {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Contact");
			esq.AddColumn("Channel");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ChannelIdentity", senderIdentity));
			var contactCollection = esq.GetEntityCollection(UserConnection);
			var match = contactCollection.FirstOrDefault(item =>
				item.GetTypedColumnValue<Guid>("ChannelId").ToString() == channelId);
			return match?.GetTypedColumnValue<Guid>("ContactId") ?? Guid.Empty;
		}

		/// <summary>
		/// Gets contact via its messenger identifier.
		/// <param name="message">Message from contact.</param>
		/// <returns>Contact identifier.</returns>
		/// </summary>
		public Guid GetContactId(MessagingMessage message)	{
			string contactSender = message.SenderIfEcho;
			var contactId = default(Guid);
			ContactIdentityCacheItem cacheItem = null;
			var cacheKey = message.ChannelId + contactSender;
			Log.DebugFormat("Got message parameters: Sender={0}, ChannelId={1}," +
							" Source={2}", contactSender, message.ChannelId, message.Source);
			if (!string.IsNullOrEmpty(message.ChannelId)) {
				if (!TryGetContactIdFromCache(cacheKey, out cacheItem))	{
					contactId = GetExistingContact(message);
					if (contactId == default(Guid)) {
						Log.InfoFormat("Contact with Sender {0} wasn't found", contactSender, message.ChannelId);
						contactId = CreateNewContact(message);
					}
					cacheItem = CreateCacheItem(contactId, message);
					PushContactIdToCache(cacheKey, cacheItem);
				} else {
					contactId = cacheItem.ContactId;
					if (NeedsIdentitySync(cacheItem, message)) {
						UpdateMissingIdentityFields(contactId, message);
						UpdateCacheItemIdentityState(cacheItem, message);
						PushContactIdToCache(cacheKey, cacheItem);
					}
					Log.DebugFormat("Contact with Id {0} was found in cache by key {1}", contactId, cacheKey);
				}
			} else {
				Log.DebugFormat("Contact couldn't be found in cache because ChannelId is empty. Sender={0}", contactSender);
			}
			return contactId;
		}

		/// <summary>
		/// Gets contact display value via its creatio identifier.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Contact display value.</returns>
		public string GetContactDisplayValue(Guid contactId) {
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			return contact.FetchPrimaryInfoFromDB(contactSchema.PrimaryColumn, contactId) ? contact.PrimaryDisplayColumnValue : string.Empty;
		}

		/// <summary>
		/// Removes contact identity from cache.
		/// </summary>
		/// <param name="id">Contact identifier.</param>
		/// <param name="userConnection">User connection.</param>
		public static void RemoveIdentityFromCache(Guid id, UserConnection userConnection) {
			if (id == null || userConnection == null) {
				return;
			}
			var contacts = userConnection.ApplicationCache
				.GetValue<ConcurrentDictionary<string, ContactIdentityCacheItem>>(ContactsByIdentifierCacheKey);
			if (contacts != null) {
				var keys = contacts.Where(c => c.Value.ContactId == id).Select(c => c.Key);
				Log.DebugFormat("Removed contact (id={0}) identity cache by keys: {1}",
					id, string.Join(", ", keys));
				keys.ForEach(k => contacts.TryRemove(k, out var deleted));
				userConnection.ApplicationCache.SetOrRemoveValue(ContactsByIdentifierCacheKey, contacts);
				_isNeedToUpdateCacheInstance = true;
			}
		}

		/// <summary>
		/// Flush contacts cache.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public static void FlushContactsCache(UserConnection userConnection) {
			userConnection.ApplicationCache.SetOrRemoveValue(ContactsByIdentifierCacheKey, null);
			_isNeedToUpdateCacheInstance = true;
		}

		#endregion

	}

	#endregion

}

