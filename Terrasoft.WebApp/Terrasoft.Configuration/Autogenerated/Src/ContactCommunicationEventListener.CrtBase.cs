namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.ExternalUsers;
	using Terrasoft.Core.Factories;

	#region Class: ContactCommunicationEventListener

	[EntityEventListener(SchemaName = "ContactCommunication")]
	public class ContactCommunicationEventListener: BaseEntityEventListener
	{

		#region Methods: Private

		private bool GetIsExternalUserCommunication(Guid contactId, UserConnection userConnection) {
			var select = new Select(userConnection)
					.Count("Id")
				.From("SysAdminUnit")
				.Where("ContactId").IsEqual(Column.Parameter(contactId))
				.And("ConnectionType").IsEqual(Column.Parameter(UserType.SSP)) as Select;
			var externalUsersCount = select.ExecuteScalar<int>();
			return externalUsersCount != 0;
		}

		#endregion

		#region Methods: Public

		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			var communicationTypeId = entity.GetTypedColumnValue<Guid>("CommunicationTypeId");
			if (communicationTypeId != Guid.Parse(CommunicationTypeConsts.EmailId)) {
				return;
			}
			var contactId = entity.GetTypedColumnValue<Guid>("ContactId");
			var userConnection = entity.UserConnection;
			if (!GetIsExternalUserCommunication(contactId, userConnection)) {
				return;
			}
			var email = entity.GetTypedColumnValue<string>("Number");
			var emailValidator = ClassFactory.Get<IExternalUserEmailDomainValidator>();
			var isEmailValid = emailValidator.IsValidEmailDomainForExternalUser(email);
			if (!isEmailValid) {
				string message = new LocalizableString(userConnection.ResourceStorage,
					"ContactCommunicationEventListener", "LocalizableStrings.ErrorMessage.Value");
				throw new SSPRestrictedEmailDomainException(message);
			}
		}

		#endregion

	}

	#endregion

}
