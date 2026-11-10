namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: TagType

	/// <exclude/>
	public class TagType : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TagType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagType";
		}

		public TagType(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TagType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountTag> AccountTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ActivityTag> ActivityTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<CallTag> CallTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContactTag> ContactTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContentBlockTag> ContentBlockTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<DuplicatesRuleTag> DuplicatesRuleTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateTag> EmailTemplateTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmployeeTag> EmployeeTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ExternalAccessTag> ExternalAccessTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormTag> GeneratedWebFormTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseTagV2> KnowledgeBaseTagV2CollectionByType {
			get;
			set;
		}

		public IEnumerable<LookupTag> LookupTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<MLModelTag> MLModelTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OAuth20AppTag> OAuth20AppTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OmniChatTag> OmniChatTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProductTag> ProductTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<SocialChannelTag> SocialChannelTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<SysTranslationTag> SysTranslationTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<WebServiceV2Tag> WebServiceV2TagCollectionByType {
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

