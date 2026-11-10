namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: Channel

	/// <exclude/>
	public class Channel : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Channel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Channel";
		}

		public Channel(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Channel";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ChatMessages> ChatMessagesCollectionByChannel {
			get;
			set;
		}

		public IEnumerable<ContactIdentity> ContactIdentityCollectionByChannel {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByChannel {
			get;
			set;
		}

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
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Messenger settings record Id.
		/// </summary>
		public Guid MsgSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MsgSettingsId");
			}
			set {
				SetColumnValue("MsgSettingsId", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Channel error code.
		/// </summary>
		public string ErrorCode {
			get {
				return GetTypedColumnValue<string>("ErrorCode");
			}
			set {
				SetColumnValue("ErrorCode", value);
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
		public Guid ProviderId {
			get {
				return GetTypedColumnValue<Guid>("ProviderId");
			}
			set {
				SetColumnValue("ProviderId", value);
				_provider = null;
			}
		}

		/// <exclude/>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
				if (_provider != null) {
					_provider.Name = value;
				}
			}
		}

		private ChannelProvider _provider;
		/// <summary>
		/// Provider.
		/// </summary>
		public ChannelProvider Provider {
			get {
				return _provider ??
					(_provider = new ChannelProvider(LookupColumnEntities.GetEntity("Provider")));
			}
		}

		/// <exclude/>
		public Guid ChatQueueId {
			get {
				return GetTypedColumnValue<Guid>("ChatQueueId");
			}
			set {
				SetColumnValue("ChatQueueId", value);
				_chatQueue = null;
			}
		}

		/// <exclude/>
		public string ChatQueueName {
			get {
				return GetTypedColumnValue<string>("ChatQueueName");
			}
			set {
				SetColumnValue("ChatQueueName", value);
				if (_chatQueue != null) {
					_chatQueue.Name = value;
				}
			}
		}

		private ChatQueue _chatQueue;
		/// <summary>
		/// Queue.
		/// </summary>
		public ChatQueue ChatQueue {
			get {
				return _chatQueue ??
					(_chatQueue = new ChatQueue(LookupColumnEntities.GetEntity("ChatQueue")));
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = new SysLanguage(LookupColumnEntities.GetEntity("Language")));
			}
		}

		#endregion

	}

	#endregion

}

