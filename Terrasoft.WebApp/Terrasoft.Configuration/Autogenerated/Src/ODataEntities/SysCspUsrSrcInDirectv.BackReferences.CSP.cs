namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysCspUsrSrcInDirectv

	/// <exclude/>
	public class SysCspUsrSrcInDirectv : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysCspUsrSrcInDirectv(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspUsrSrcInDirectv";
		}

		public SysCspUsrSrcInDirectv(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysCspUsrSrcInDirectv";
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
		public Guid CspUserTrustedSourceId {
			get {
				return GetTypedColumnValue<Guid>("CspUserTrustedSourceId");
			}
			set {
				SetColumnValue("CspUserTrustedSourceId", value);
				_cspUserTrustedSource = null;
			}
		}

		/// <exclude/>
		public string CspUserTrustedSourceSource {
			get {
				return GetTypedColumnValue<string>("CspUserTrustedSourceSource");
			}
			set {
				SetColumnValue("CspUserTrustedSourceSource", value);
				if (_cspUserTrustedSource != null) {
					_cspUserTrustedSource.Source = value;
				}
			}
		}

		private SysCspUserTrustedSrc _cspUserTrustedSource;
		/// <summary>
		/// Trusted source.
		/// </summary>
		public SysCspUserTrustedSrc CspUserTrustedSource {
			get {
				return _cspUserTrustedSource ??
					(_cspUserTrustedSource = new SysCspUserTrustedSrc(LookupColumnEntities.GetEntity("CspUserTrustedSource")));
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
		/// Directive.
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

