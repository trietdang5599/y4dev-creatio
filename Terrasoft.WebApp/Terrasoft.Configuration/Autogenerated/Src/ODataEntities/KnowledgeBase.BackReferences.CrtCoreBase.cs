namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: KnowledgeBase

	/// <exclude/>
	public class KnowledgeBase : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnowledgeBase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBase";
		}

		public KnowledgeBase(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "KnowledgeBase";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Comment> CommentCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<Favorites> FavoritesCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFile> KnowledgeBaseFileCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseInFolder> KnowledgeBaseInFolderCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseInTagV2> KnowledgeBaseInTagV2CollectionByEntity {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseTagDecoupling> KnowledgeBaseTagDecouplingCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<Like> LikeCollectionByKnowledgeBase {
			get;
			set;
		}

		public IEnumerable<Playbook> PlaybookCollectionByKnowledgeBase {
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
		/// Resolution.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
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
		/// Tags.
		/// </summary>
		public string Keywords {
			get {
				return GetTypedColumnValue<string>("Keywords");
			}
			set {
				SetColumnValue("Keywords", value);
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
		/// Views.
		/// </summary>
		public int ViewsCount {
			get {
				return GetTypedColumnValue<int>("ViewsCount");
			}
			set {
				SetColumnValue("ViewsCount", value);
			}
		}

		/// <summary>
		/// Solution without HTML tags.
		/// </summary>
		public string NotHtmlNote {
			get {
				return GetTypedColumnValue<string>("NotHtmlNote");
			}
			set {
				SetColumnValue("NotHtmlNote", value);
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
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private KnowledgeBaseType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public KnowledgeBaseType Type {
			get {
				return _type ??
					(_type = new KnowledgeBaseType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		#endregion

	}

	#endregion

}

