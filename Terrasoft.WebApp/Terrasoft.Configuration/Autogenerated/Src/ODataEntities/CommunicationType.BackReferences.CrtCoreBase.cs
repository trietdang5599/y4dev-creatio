namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CommunicationType

	/// <exclude/>
	public class CommunicationType : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CommunicationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommunicationType";
		}

		public CommunicationType(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CommunicationType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountCommunication> AccountCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ComTypebyCommunication> ComTypebyCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ContactCommunication> ContactCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ContactCorrespondence> ContactCorrespondenceCollectionBySource {
			get;
			set;
		}

		public IEnumerable<CTISearchResult> CTISearchResultCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateMacros> EmailTemplateMacrosCollectionByAccountCommunicationType {
			get;
			set;
		}

		public IEnumerable<EnrchTypeMapping> EnrchTypeMappingCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<SocialAccount> SocialAccountCollectionByType {
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
		/// Template for creating a hyperlink in text.
		/// </summary>
		public string HyperlinkTemplate {
			get {
				return GetTypedColumnValue<string>("HyperlinkTemplate");
			}
			set {
				SetColumnValue("HyperlinkTemplate", value);
			}
		}

		/// <summary>
		/// Use for accounts.
		/// </summary>
		public bool UseforAccounts {
			get {
				return GetTypedColumnValue<bool>("UseforAccounts");
			}
			set {
				SetColumnValue("UseforAccounts", value);
			}
		}

		/// <summary>
		/// Use for contacts.
		/// </summary>
		public bool UseforContacts {
			get {
				return GetTypedColumnValue<bool>("UseforContacts");
			}
			set {
				SetColumnValue("UseforContacts", value);
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
		/// Display format.
		/// </summary>
		public string DisplayFormat {
			get {
				return GetTypedColumnValue<string>("DisplayFormat");
			}
			set {
				SetColumnValue("DisplayFormat", value);
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
		public Guid ImageLinkId {
			get {
				return GetTypedColumnValue<Guid>("ImageLinkId");
			}
			set {
				SetColumnValue("ImageLinkId", value);
				_imageLink = null;
			}
		}

		/// <exclude/>
		public string ImageLinkName {
			get {
				return GetTypedColumnValue<string>("ImageLinkName");
			}
			set {
				SetColumnValue("ImageLinkName", value);
				if (_imageLink != null) {
					_imageLink.Name = value;
				}
			}
		}

		private SysImage _imageLink;
		/// <summary>
		/// Image.
		/// </summary>
		/// <remarks>
		/// Only .svg images allowed.
		/// </remarks>
		public SysImage ImageLink {
			get {
				return _imageLink ??
					(_imageLink = new SysImage(LookupColumnEntities.GetEntity("ImageLink")));
			}
		}

		#endregion

	}

	#endregion

}

