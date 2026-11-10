namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: EmailSyncQueue

	/// <exclude/>
	public class EmailSyncQueue : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmailSyncQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailSyncQueue";
		}

		public EmailSyncQueue(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmailSyncQueue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// MessageId.
		/// </summary>
		public string MessageId {
			get {
				return GetTypedColumnValue<string>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid MailboxId {
			get {
				return GetTypedColumnValue<Guid>("MailboxId");
			}
			set {
				SetColumnValue("MailboxId", value);
				_mailbox = null;
			}
		}

		/// <exclude/>
		public string MailboxSenderEmailAddress {
			get {
				return GetTypedColumnValue<string>("MailboxSenderEmailAddress");
			}
			set {
				SetColumnValue("MailboxSenderEmailAddress", value);
				if (_mailbox != null) {
					_mailbox.SenderEmailAddress = value;
				}
			}
		}

		private MailboxSyncSettings _mailbox;
		/// <summary>
		/// Mailbox.
		/// </summary>
		public MailboxSyncSettings Mailbox {
			get {
				return _mailbox ??
					(_mailbox = new MailboxSyncSettings(LookupColumnEntities.GetEntity("Mailbox")));
			}
		}

		#endregion

	}

	#endregion

}

