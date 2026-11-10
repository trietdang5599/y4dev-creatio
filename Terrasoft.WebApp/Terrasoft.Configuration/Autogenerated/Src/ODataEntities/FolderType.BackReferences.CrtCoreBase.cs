namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: FolderType

	/// <exclude/>
	public class FolderType : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public FolderType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderType";
		}

		public FolderType(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "FolderType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountFolder> AccountFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ActivityFolder> ActivityFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<CallFolder> CallFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ContactFolder> ContactFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<DuplicatesRuleFolder> DuplicatesRuleFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFolder> EmailTemplateFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<EmployeeFolder> EmployeeFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ExternalAccessFolder> ExternalAccessFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<FileFolder> FileFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFolder> GeneratedWebFormFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFolder> KnowledgeBaseFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<LookupFolder> LookupFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<MLModelFolder> MLModelFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFolder> OAuth20AppFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OmniChatFolder> OmniChatFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ProductFolder> ProductFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ReportFolder> ReportFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SocialChannelFolder> SocialChannelFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysAdminOperationFolder> SysAdminOperationFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitFolder> SysAdminUnitFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysLookupFolder> SysLookupFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysProcessLogFolder> SysProcessLogFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysProcessUserTaskFolder> SysProcessUserTaskFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysSettingsFolder> SysSettingsFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysTranslationFolder> SysTranslationFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwProcessLibFolder> VwProcessLibFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwSysDcmLibFolder> VwSysDcmLibFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwSysProcessFolder> VwSysProcessFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<WebServiceV2Folder> WebServiceV2FolderCollectionByFolderType {
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
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Order.
		/// </summary>
		public int Order {
			get {
				return GetTypedColumnValue<int>("Order");
			}
			set {
				SetColumnValue("Order", value);
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
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		#endregion

	}

	#endregion

}

