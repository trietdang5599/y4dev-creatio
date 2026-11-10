namespace IntegrationV2.MailboxDomain.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Common.Logging;
	using IntegrationApi.MailboxDomain.Model;
	using IntegrationV2.MailboxDomain.Interfaces;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.IntegrationV2.Utils;

	#region Class: MailboxRepository

	/// <summary>
	/// Mailbox repository implementation.
	/// </summary>
	[DefaultBinding(typeof(IMailboxRepository))]
	internal class MailboxRepository : BaseRepository, IMailboxRepository
	{

		#region Fields: Private

		private readonly IMailServerRepository _mailServerRepository;

		private readonly IMailboxFolderRepository _mailboxFolderRepository;

		private readonly ILog _log = LogManager.GetLogger("EmailListener");

		private const string _sharedMaiboxesCacheKey = "SharedMaiboxesCacheKey";

		#endregion

		#region Constructors: Public

		public MailboxRepository(UserConnection uc) {
			UserConnection = uc;
			CacheName = "MailboxList";
			_mailServerRepository = ClassFactory.Get<IMailServerRepository>(new ConstructorArgument("uc", uc));
			_mailboxFolderRepository = ClassFactory.Get<IMailboxFolderRepository>(new ConstructorArgument("uc", uc));
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates mailbox data query.
		/// </summary>
		/// <param name="isUserMailboxesOnly">Select only user mailboxes flag.</param>
		/// <returns><see cref="EntitySchemaQuery"/> instance.</returns>
		private EntitySchemaQuery GetMailboxesQuery(bool isUserMailboxesOnly) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings");
			esq.UseAdminRights = isUserMailboxesOnly;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("SenderEmailAddress");
			esq.AddColumn("SenderDisplayValue");
			esq.AddColumn("UserName");
			esq.AddColumn("UserPassword");
			esq.AddColumn("OAuthTokenStorage");
			esq.AddColumn("SysAdminUnit");
			esq.AddColumn("CreatedBy");
			esq.AddColumn("IsShared");
			esq.AddColumn("MailServer");
			esq.AddColumn("EnableMailSynhronization");
			esq.AddColumn("SendEmailsViaThisAccount");
			esq.AddColumn("SynchronizationStopped");
			esq.AddColumn("PersonalMetrics");
			esq.AddColumn("MailSyncPeriod");
			esq.AddColumn("AutomaticallyAddNewEmails");
			esq.AddColumn("ExchangeAutoSyncActivity");
			esq.AddColumn("ExchangeAutoSynchronization");
			esq.AddColumn("EmailsCyclicallyAddingInterval");
			esq.AddColumn("LoadAllEmailsFromMailBox");
			esq.AddColumn("ErrorCode");
			esq.AddColumn("WarningCode");
			esq.AddColumn("MarkEmailsAsSynchronized");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit.Active", true));
			return esq;
		}

		/// <summary>
		/// Creates mailbox model instance.
		/// </summary>
		/// <param name="entity">Mailbox entity.</param>
		/// <param name="mailServers">Mail servers models collection.</param>
		/// <param name="folders">Mail folders collection.</param>
		/// <returns><see cref="Mailbox"/> instance.</returns>
		private Mailbox CreateMailbox(Entity entity, IEnumerable<MailServer> mailServers, IEnumerable<MailboxFolder> folders) {
			var mailServerId = entity.GetTypedColumnValue<Guid>("MailServerId");
			var mailboxFolders = folders.Where(f => f.MailboxId.Equals(entity.PrimaryColumnValue));
			var mailServer = mailServers.First(ms => ms.Id.Equals(mailServerId));
			return CreateMailbox(entity, mailServer, mailboxFolders);
		}

		/// <summary>
		/// Creates mailbox model instance.
		/// </summary>
		/// <param name="entity">Mailbox entity.</param>
		/// <param name="mailServer">Mail server entity.</param>
		/// <param name="mailboxFolders">Mailbox folders collection.</param>
		/// <returns><see cref="Mailbox"/> instance.</returns>
		private Mailbox CreateMailbox(Entity entity, MailServer mailServer, IEnumerable<MailboxFolder> mailboxFolders) {
			var mailbox = new Mailbox(entity, mailServer);
			mailbox.AddFolders(mailboxFolders);
			return mailbox;
		}

		private Mailbox GetByIdFromDb(Guid mailboxId, bool isUserMailboxesOnly = true) {
			var mailboxesQuery = GetMailboxesQuery(isUserMailboxesOnly);
			var mailboxEntity = mailboxesQuery.GetEntity(UserConnection, mailboxId);
			if (mailboxEntity == null) {
				return null;
			}
			var mailServerId = mailboxEntity.GetTypedColumnValue<Guid>("MailServerId");
			var mailServer = _mailServerRepository.GetById(mailServerId);
			var mailboxFolders = _mailboxFolderRepository.GetByMailboxId(mailboxId);
			var mailbox = CreateMailbox(mailboxEntity, mailServer, mailboxFolders);
			return mailbox;
		}

		private IEnumerable<Mailbox> GetAllFromCache() {
			object store = GetCache();
			IEnumerable<Mailbox> mailboxList = null;
			if (store != null) {
				mailboxList = store as IEnumerable<Mailbox>;
			}
			if (mailboxList == null) {
				mailboxList = new List<Mailbox>();
			}
			return mailboxList;
		}

		private IEnumerable<Mailbox> GetAccessableForUserMailboxes(IEnumerable<Mailbox> mailboxes) {
			var sharedMaiboxesIds = mailboxes.Where(m => m.IsShared).Select(m => (object)m.Id);
			if (sharedMaiboxesIds.Any()) {
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings");
				esq.PrimaryQueryColumn.IsAlwaysSelect = true;
				esq.CacheItemName = $"{_sharedMaiboxesCacheKey}_{UserConnection.CurrentUser.Id}";
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", sharedMaiboxesIds));
				var accesableSharedMailboxes = esq.GetEntityCollection(UserConnection).Select(e => e.PrimaryColumnValue);
				return mailboxes.Where(m =>
					m.OwnerId.Equals(UserConnection.CurrentUser.Id) || (m.IsShared && accesableSharedMailboxes.Contains(m.Id))
				);
			} else {
				return mailboxes.Where(m => m.OwnerId.Equals(UserConnection.CurrentUser.Id));
			}
		}

		private Mailbox GetBySenderEmailAddressFromDb(string senderEmailAddress, bool isUserMailboxesOnly) {
			var mailboxesQuery = GetMailboxesQuery(isUserMailboxesOnly);
			mailboxesQuery.Filters.Add(mailboxesQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SenderEmailAddress", senderEmailAddress));
			var mailboxEntity = mailboxesQuery.GetEntityCollection(UserConnection).FirstOrDefault();
			if (mailboxEntity == null) {
				return null;
			}
			var entityMailboxId = (Guid)mailboxEntity.PrimaryColumnValue;
			var mailServerId = mailboxEntity.GetTypedColumnValue<Guid>("MailServerId");
			var mailServer = _mailServerRepository.GetById(mailServerId);
			var mailboxFolders = _mailboxFolderRepository.GetByMailboxId(entityMailboxId);
			var mailbox = CreateMailbox(mailboxEntity, mailServer, mailboxFolders);
			return isUserMailboxesOnly ? GetAccessableForUserMailboxes(new[] { mailbox }).FirstOrDefault() : mailbox;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IMailboxRepository.GetAll(bool, bool)"/>
		public IEnumerable<Mailbox> GetAll(bool isUserMailboxesOnly = true, bool useForSynchronization = true) {
			IEnumerable<Mailbox> mailboxList = GetAllFromCache();
			if (ListenerUtils.GetIsFeatureEnabled("IsMailboxSyncSettingsCached") && mailboxList.IsNotEmpty()) {
				return isUserMailboxesOnly ? GetAccessableForUserMailboxes(mailboxList) : mailboxList;
			} else {
				var mailServers = _mailServerRepository.GetAll(useForSynchronization);
				var folders = _mailboxFolderRepository.GetAll();
				var allMailboxesQuery = GetMailboxesQuery(false);
				var mailboxes = new List<Mailbox>();
				foreach (var mailbox in allMailboxesQuery.GetEntityCollection(UserConnection)) {
					mailboxes.Add(CreateMailbox(mailbox, mailServers, folders));
				}
				if (ListenerUtils.GetIsFeatureEnabled("IsMailboxSyncSettingsCached")) {
					SetCache(mailboxes);
				}
				return isUserMailboxesOnly ? GetAccessableForUserMailboxes(mailboxes) : mailboxes;
			}
		}

		/// <inheritdoc cref="IMailboxRepository.GetById(Guid, bool)"/>
		public Mailbox GetById(Guid mailboxId, bool isUserMailboxesOnly = true) {
			if (ListenerUtils.GetIsFeatureEnabled("IsMailboxSyncSettingsCached")) {
				var mailboxList = GetAllFromCache();
				var cachedMailbox = mailboxList.FirstOrDefault(x => x.Id == mailboxId);
				if (cachedMailbox != null) {
					return cachedMailbox;
				}
				_log.Warn($"Mailbox {mailboxId} not found in local cache snapshot; loading from DB.");
				var mailbox = GetByIdFromDb(mailboxId, isUserMailboxesOnly);
				if (mailbox != null) {
					_log.Warn($"Mailbox {mailboxId} found in DB after stale cache; invalidating '{CacheName}' cache.");
					InvalidateCache();
				}
				return mailbox;
			}
			return GetByIdFromDb(mailboxId, isUserMailboxesOnly);
		}

		/// <inheritdoc cref="IMailboxRepository.GetBySenderEmailAddress(string, bool, bool)"/>
		public Mailbox GetBySenderEmailAddress(string senderEmailAddress, bool isUserMailboxesOnly = true,
				bool useForSynchronization = true) {
			if (senderEmailAddress.IsNullOrWhiteSpace()) {
				return null;
			}
			var trimmed = senderEmailAddress.Trim();
			if (ListenerUtils.GetIsFeatureEnabled("IsMailboxSyncSettingsCached")) {
				var allMailboxes = GetAll(isUserMailboxesOnly, useForSynchronization);
				var cachedMailbox = isUserMailboxesOnly
					? allMailboxes.FirstOrDefault(m =>
						m.SenderEmailAddress.Equals(trimmed, StringComparison.OrdinalIgnoreCase) &&
						(m.OwnerId.Equals(UserConnection.CurrentUser.Id) || m.IsShared))
					: allMailboxes.FirstOrDefault(m =>
						m.SenderEmailAddress.Equals(trimmed, StringComparison.OrdinalIgnoreCase));
				if (cachedMailbox != null) {
					return cachedMailbox;
				}
				_log.Warn($"Mailbox '{trimmed}' not found in cached mailbox list; falling back to DB.");
				var mailbox = GetBySenderEmailAddressFromDb(trimmed, isUserMailboxesOnly);
				if (mailbox != null) {
					_log.Warn($"Mailbox '{trimmed}' found in DB after stale cache; invalidating '{CacheName}' cache.");
					InvalidateCache();
				}
				return mailbox;
			}
			return GetBySenderEmailAddressFromDb(trimmed, isUserMailboxesOnly);
		}

		/// <inheritdoc cref="IMailboxRepository.GetEmails(Guid)"/>
		public IEnumerable<string> GetEmails(Guid mailboxId) {
			var select = new Select(UserConnection)
					.Column("mss", "SenderEmailAddress")
					.Column("msd", "Domain")
				.From("MailboxSyncSettings").As("mss")
				.LeftOuterJoin("MailServerDomain").As("msd").On("mss", "MailServerId").IsEqual("msd", "MailServerId")
				.Where("mss", "Id").IsEqual(Column.Parameter(mailboxId)) as Select;
			var result = new HashSet<string>();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var email = reader.GetColumnValue<string>("SenderEmailAddress");
						result.Add(email.ToLower().Trim());
						var domain = reader.GetColumnValue<string>("Domain");
						if (domain.IsNotNullOrEmpty()) {
							var emailWithDomain = $"{email.Split('@')[0]}@{domain}";
							result.Add(emailWithDomain.ToLower().Trim());
						}
					}
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}
