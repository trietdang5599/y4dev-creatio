namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysCspDefSrcInDirectv

	/// <exclude/>
	public class SysCspDefSrcInDirectv : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysCspDefSrcInDirectv(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspDefSrcInDirectv";
		}

		public SysCspDefSrcInDirectv(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysCspDefSrcInDirectv";
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
		public Guid CspDefaultSourceId {
			get {
				return GetTypedColumnValue<Guid>("CspDefaultSourceId");
			}
			set {
				SetColumnValue("CspDefaultSourceId", value);
				_cspDefaultSource = null;
			}
		}

		/// <exclude/>
		public string CspDefaultSourceSource {
			get {
				return GetTypedColumnValue<string>("CspDefaultSourceSource");
			}
			set {
				SetColumnValue("CspDefaultSourceSource", value);
				if (_cspDefaultSource != null) {
					_cspDefaultSource.Source = value;
				}
			}
		}

		private SysCspDefaultSrc _cspDefaultSource;
		/// <summary>
		/// Default source.
		/// </summary>
		public SysCspDefaultSrc CspDefaultSource {
			get {
				return _cspDefaultSource ??
					(_cspDefaultSource = new SysCspDefaultSrc(LookupColumnEntities.GetEntity("CspDefaultSource")));
			}
		}

		/// <exclude/>
		public Guid CspDirectiveNameId {
			get {
				return GetTypedColumnValue<Guid>("CspDirectiveNameId");
			}
			set {
				SetColumnValue("CspDirectiveNameId", value);
				_cspDirectiveName = null;
			}
		}

		/// <exclude/>
		public string CspDirectiveNameName {
			get {
				return GetTypedColumnValue<string>("CspDirectiveNameName");
			}
			set {
				SetColumnValue("CspDirectiveNameName", value);
				if (_cspDirectiveName != null) {
					_cspDirectiveName.Name = value;
				}
			}
		}

		private SysCspDirectiveName _cspDirectiveName;
		/// <summary>
		/// Directive name.
		/// </summary>
		public SysCspDirectiveName CspDirectiveName {
			get {
				return _cspDirectiveName ??
					(_cspDirectiveName = new SysCspDirectiveName(LookupColumnEntities.GetEntity("CspDirectiveName")));
			}
		}

		#endregion

	}

	#endregion

}

