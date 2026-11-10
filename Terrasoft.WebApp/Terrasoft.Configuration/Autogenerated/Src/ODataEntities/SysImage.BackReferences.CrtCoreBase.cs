namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysImage

	/// <exclude/>
	public class SysImage : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysImage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysImage";
		}

		public SysImage(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysImage";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByAccountLogo {
			get;
			set;
		}

		public IEnumerable<CallDirection> CallDirectionCollectionByImage {
			get;
			set;
		}

		public IEnumerable<ChannelProvider> ChannelProviderCollectionByIcon {
			get;
			set;
		}

		public IEnumerable<Communication> CommunicationCollectionByImageLink {
			get;
			set;
		}

		public IEnumerable<CommunicationType> CommunicationTypeCollectionByImageLink {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByPhoto {
			get;
			set;
		}

		public IEnumerable<ContentBlock> ContentBlockCollectionByImage {
			get;
			set;
		}

		public IEnumerable<ContentUserBlock> ContentUserBlockCollectionByImage {
			get;
			set;
		}

		public IEnumerable<EmailTemplate> EmailTemplateCollectionByPreviewImage {
			get;
			set;
		}

		public IEnumerable<ESNNotificationType> ESNNotificationTypeCollectionByIcon {
			get;
			set;
		}

		public IEnumerable<FolderType> FolderTypeCollectionByImage {
			get;
			set;
		}

		public IEnumerable<MailServer> MailServerCollectionByLogo {
			get;
			set;
		}

		public IEnumerable<MessagePublisher> MessagePublisherCollectionByImage {
			get;
			set;
		}

		public IEnumerable<MultiLookupImage> MultiLookupImageCollectionByLookupImage {
			get;
			set;
		}

		public IEnumerable<NotificationsSettings> NotificationsSettingsCollectionBySysImage {
			get;
			set;
		}

		public IEnumerable<OAuthApplications> OAuthApplicationsCollectionByImage {
			get;
			set;
		}

		public IEnumerable<OAuthClientApp> OAuthClientAppCollectionByLogo {
			get;
			set;
		}

		public IEnumerable<PageTemplate> PageTemplateCollectionByPreviewImage {
			get;
			set;
		}

		public IEnumerable<Portal_SysModule> Portal_SysModuleCollectionByImage32 {
			get;
			set;
		}

		public IEnumerable<Portal_SysModule> Portal_SysModuleCollectionByLogo {
			get;
			set;
		}

		public IEnumerable<SocialChannel> SocialChannelCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysAppTemplate> SysAppTemplateCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysAppTemplateInfoItem> SysAppTemplateInfoItemCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysChartSeriesKind> SysChartSeriesKindCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysCulture> SysCultureCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysImageInTag> SysImageInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<SysModule> SysModuleCollectionByImage32 {
			get;
			set;
		}

		public IEnumerable<SysModule> SysModuleCollectionByLogo {
			get;
			set;
		}

		public IEnumerable<SysModuleAnalyticsReport> SysModuleAnalyticsReportCollectionByLogo {
			get;
			set;
		}

		public IEnumerable<SysMsgUserState> SysMsgUserStateCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysMsgUserStateReason> SysMsgUserStateReasonCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysOperationResult> SysOperationResultCollectionByImage {
			get;
			set;
		}

		public IEnumerable<SysProcessUserTask> SysProcessUserTaskCollectionBySysImage {
			get;
			set;
		}

		public IEnumerable<VwPageTemplate> VwPageTemplateCollectionByPreviewImage {
			get;
			set;
		}

		public IEnumerable<VwProcessLib> VwProcessLibCollectionByStartOptionsImage {
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
		/// Uploaded on.
		/// </summary>
		public DateTime UploadedOn {
			get {
				return GetTypedColumnValue<DateTime>("UploadedOn");
			}
			set {
				SetColumnValue("UploadedOn", value);
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
		/// MimeType.
		/// </summary>
		public string MimeType {
			get {
				return GetTypedColumnValue<string>("MimeType");
			}
			set {
				SetColumnValue("MimeType", value);
			}
		}

		/// <summary>
		/// Reference saved.
		/// </summary>
		public bool HasRef {
			get {
				return GetTypedColumnValue<bool>("HasRef");
			}
			set {
				SetColumnValue("HasRef", value);
			}
		}

		/// <summary>
		/// Hash.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
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

		#endregion

	}

	#endregion

}

