namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: FileGroup

	/// <exclude/>
	public class FileGroup : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public FileGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileGroup";
		}

		public FileGroup(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "FileGroup";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountFile> AccountFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<ActivityFile> ActivityFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<CallFile> CallFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<ContactFile> ContactFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<CreatioAIIntentFile> CreatioAIIntentFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<CreatioAISessionFile> CreatioAISessionFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFile> EmailTemplateFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<EmployeeFile> EmployeeFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<FeedFile> FeedFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<File> FileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFile> GeneratedWebFormFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFile> KnowledgeBaseFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<KnwSourceFile> KnwSourceFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<MailboxSettingsFile> MailboxSettingsFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<OmnichannelMessageFile> OmnichannelMessageFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<OmniChatFile> OmniChatFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<ProductFile> ProductFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<SysFile> SysFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<SysProcessFile> SysProcessFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<VwProcessLibFile> VwProcessLibFileCollectionByFileGroup {
			get;
			set;
		}

		public IEnumerable<VwSysProcessFile> VwSysProcessFileCollectionByFileGroup {
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

		#endregion

	}

	#endregion

}

