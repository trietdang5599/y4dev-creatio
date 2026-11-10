namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: EmailTemplate

	/// <exclude/>
	public class EmailTemplate : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmailTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplate";
		}

		public EmailTemplate(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmailTemplate";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<EmailTemplateActivity> EmailTemplateActivityCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFile> EmailTemplateFileCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateInFolder> EmailTemplateInFolderCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateInTag> EmailTemplateInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<EmailTemplateLang> EmailTemplateLangCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<OperatorTemplateUsage> OperatorTemplateUsageCollectionByTemplate {
			get;
			set;
		}

		public IEnumerable<SocialFeedFavoriteTpl> SocialFeedFavoriteTplCollectionByEmailTemplate {
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
		/// Template name.
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
		/// Email subject.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Body.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <summary>
		/// HTML-formatted body.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Save as activity.
		/// </summary>
		public bool SaveAsActivity {
			get {
				return GetTypedColumnValue<bool>("SaveAsActivity");
			}
			set {
				SetColumnValue("SaveAsActivity", value);
			}
		}

		/// <summary>
		/// Object connection field.
		/// </summary>
		public Guid ObjectFieldInActivity {
			get {
				return GetTypedColumnValue<Guid>("ObjectFieldInActivity");
			}
			set {
				SetColumnValue("ObjectFieldInActivity", value);
			}
		}

		/// <summary>
		/// Open activity card before sending.
		/// </summary>
		public bool ShowBeforeSending {
			get {
				return GetTypedColumnValue<bool>("ShowBeforeSending");
			}
			set {
				SetColumnValue("ShowBeforeSending", value);
			}
		}

		/// <summary>
		/// TemplateConfig.
		/// </summary>
		public string TemplateConfig {
			get {
				return GetTypedColumnValue<string>("TemplateConfig");
			}
			set {
				SetColumnValue("TemplateConfig", value);
			}
		}

		/// <summary>
		/// Config type.
		/// </summary>
		public int ConfigType {
			get {
				return GetTypedColumnValue<int>("ConfigType");
			}
			set {
				SetColumnValue("ConfigType", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
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
		public Guid ObjectId {
			get {
				return GetTypedColumnValue<Guid>("ObjectId");
			}
			set {
				SetColumnValue("ObjectId", value);
				_object = null;
			}
		}

		/// <exclude/>
		public string ObjectCaption {
			get {
				return GetTypedColumnValue<string>("ObjectCaption");
			}
			set {
				SetColumnValue("ObjectCaption", value);
				if (_object != null) {
					_object.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _object;
		/// <summary>
		/// Macro source.
		/// </summary>
		public VwSysSchemaInfo Object {
			get {
				return _object ??
					(_object = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("Object")));
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ActivityPriority _priority;
		/// <summary>
		/// Priority.
		/// </summary>
		public ActivityPriority Priority {
			get {
				return _priority ??
					(_priority = new ActivityPriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <exclude/>
		public Guid SendIndividualEmailId {
			get {
				return GetTypedColumnValue<Guid>("SendIndividualEmailId");
			}
			set {
				SetColumnValue("SendIndividualEmailId", value);
				_sendIndividualEmail = null;
			}
		}

		/// <exclude/>
		public string SendIndividualEmailName {
			get {
				return GetTypedColumnValue<string>("SendIndividualEmailName");
			}
			set {
				SetColumnValue("SendIndividualEmailName", value);
				if (_sendIndividualEmail != null) {
					_sendIndividualEmail.Name = value;
				}
			}
		}

		private EmailTemplateSendFlag _sendIndividualEmail;
		/// <summary>
		/// Send personal email message to each recipient.
		/// </summary>
		public EmailTemplateSendFlag SendIndividualEmail {
			get {
				return _sendIndividualEmail ??
					(_sendIndividualEmail = new EmailTemplateSendFlag(LookupColumnEntities.GetEntity("SendIndividualEmail")));
			}
		}

		/// <exclude/>
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// Preview image.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = new SysImage(LookupColumnEntities.GetEntity("PreviewImage")));
			}
		}

		/// <exclude/>
		public Guid TemplateTypeId {
			get {
				return GetTypedColumnValue<Guid>("TemplateTypeId");
			}
			set {
				SetColumnValue("TemplateTypeId", value);
				_templateType = null;
			}
		}

		/// <exclude/>
		public string TemplateTypeName {
			get {
				return GetTypedColumnValue<string>("TemplateTypeName");
			}
			set {
				SetColumnValue("TemplateTypeName", value);
				if (_templateType != null) {
					_templateType.Name = value;
				}
			}
		}

		private MessageTemplateType _templateType;
		/// <summary>
		/// Template type.
		/// </summary>
		public MessageTemplateType TemplateType {
			get {
				return _templateType ??
					(_templateType = new MessageTemplateType(LookupColumnEntities.GetEntity("TemplateType")));
			}
		}

		#endregion

	}

	#endregion

}

