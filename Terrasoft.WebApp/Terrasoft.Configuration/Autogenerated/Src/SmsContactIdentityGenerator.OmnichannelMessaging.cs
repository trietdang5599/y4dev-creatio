namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: SmsContactIdentityGenerator

	/// <summary>
	/// Generates contact identity for SMS channels.
	/// </summary>
	public class SmsContactIdentityGenerator : IGenerateContactIdentity
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private ILog _log;

		#endregion

		#region Properties: Private

		private ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessaging"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SmsContactIdentityGenerator"/> class.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public SmsContactIdentityGenerator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets primary mobile phone number from ContactCommunication.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Mobile phone number in E.164 format or null if not found.</returns>
		private string GetPrimaryMobilePhone(Guid contactId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ContactCommunication");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var numberColumn = esq.AddColumn("Number");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"CommunicationType", Guid.Parse(CommunicationTypeConsts.MobilePhoneId)));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Primary", true));
			var collection = esq.GetEntityCollection(_userConnection);
			if (collection.Count == 0) {
				return null;
			}
			string phoneNumber = collection[0].GetTypedColumnValue<string>(numberColumn.Name);
			if (string.IsNullOrWhiteSpace(phoneNumber)) {
				return null;
			}
			return NormalizePhoneNumber(phoneNumber);
		}

		/// <summary>
		/// Normalizes phone number to E.164 format (+18777804236).
		/// </summary>
		/// <param name="phoneNumber">Raw phone number.</param>
		/// <returns>Normalized phone number in E.164 format.</returns>
		private string NormalizePhoneNumber(string phoneNumber) {
			if (string.IsNullOrWhiteSpace(phoneNumber)) {
				return phoneNumber;
			}

			string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

			if (digitsOnly.Length == 0) {
				return null;
			}

			return "+" + digitsOnly;
		}

		/// <summary>
		/// Checks if ContactIdentity already exists and returns its value.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="channelIdentity">Existing channel identity value.</param>
		/// <returns>True if ContactIdentity exists, otherwise false.</returns>
		private bool TryGetExistingContactIdentity(Guid channelId, Guid contactId, out string channelIdentity) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ContactIdentity");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var identityColumn = esq.AddColumn("ChannelIdentity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Channel", channelId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Contact", contactId));
			var collection = esq.GetEntityCollection(_userConnection);
			if (collection.Count > 0) {
				channelIdentity = collection[0].GetTypedColumnValue<string>(identityColumn.Name);
				return !string.IsNullOrEmpty(channelIdentity);
			}
			channelIdentity = null;
			return false;
		}

		/// <summary>
		/// Creates ContactIdentity record.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="mobilePhone">Mobile phone number.</param>
		/// <returns>True if created successfully, otherwise false.</returns>
		private bool CreateContactIdentityRecord(Guid channelId, Guid contactId, string mobilePhone) {
			try {
				EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("ContactIdentity");
				Entity contactIdentity = schema.CreateEntity(_userConnection);

				contactIdentity.SetDefColumnValues();
				contactIdentity.SetColumnValue("Id", Guid.NewGuid());
				contactIdentity.SetColumnValue("ContactId", contactId);
				contactIdentity.SetColumnValue("ChannelId", channelId);
				contactIdentity.SetColumnValue("ChannelIdentity", mobilePhone);
				contactIdentity.SetColumnValue("IsGuestUser", false);

				contactIdentity.Save(false);
				Log.Debug($"ContactIdentity created for ContactId={contactId}, ChannelId={channelId}");
				return true;
			} catch (Exception ex) {
				Log.Error($"Error creating ContactIdentity for ContactId={contactId}, ChannelId={channelId}", ex);
				return false;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Tries to get existing or create new contact identity for SMS channel.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="channelIdentity">Output channel identity value.</param>
		/// <returns>True if identity was retrieved or created, otherwise false.</returns>
		public bool TryGetOrCreateIdentity(Guid channelId, Guid contactId, out string channelIdentity) {
			channelIdentity = null;

			if (channelId == Guid.Empty) {
				Log.Warn("ChannelId is empty");
				return false;
			}

			if (contactId == Guid.Empty) {
				Log.Warn("ContactId is empty");
				return false;
			}

			if (TryGetExistingContactIdentity(channelId, contactId, out channelIdentity)) {
				Log.Debug($"ContactIdentity found for ContactId={contactId}, ChannelId={channelId}, Identity={channelIdentity}");
				return true;
			}

			string mobilePhone = GetPrimaryMobilePhone(contactId);
			if (string.IsNullOrWhiteSpace(mobilePhone)) {
				Log.Warn($"Primary mobile phone not found for ContactId={contactId}");
				return false;
			}

			if (CreateContactIdentityRecord(channelId, contactId, mobilePhone)) {
				channelIdentity = mobilePhone;
				return true;
			}

			return false;
		}

		#endregion

	}

	#endregion

}

