namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SenderDomainsInfo

	/// <exclude/>
	public class SenderDomainsInfo : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SenderDomainsInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SenderDomainsInfo";
		}

		public SenderDomainsInfo(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SenderDomainsInfo";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SenderDomain> SenderDomainCollectionBySenderDomainsInfo {
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
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Status.
		/// </summary>
		public string Status {
			get {
				return GetTypedColumnValue<string>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		/// <summary>
		/// Domain validation record.
		/// </summary>
		public string DomainValidationRecord {
			get {
				return GetTypedColumnValue<string>("DomainValidationRecord");
			}
			set {
				SetColumnValue("DomainValidationRecord", value);
			}
		}

		/// <summary>
		/// Dmark value.
		/// </summary>
		public string DmarkValue {
			get {
				return GetTypedColumnValue<string>("DmarkValue");
			}
			set {
				SetColumnValue("DmarkValue", value);
			}
		}

		/// <summary>
		/// SPF value.
		/// </summary>
		public string SpfValue {
			get {
				return GetTypedColumnValue<string>("SpfValue");
			}
			set {
				SetColumnValue("SpfValue", value);
			}
		}

		/// <summary>
		/// DKIM record.
		/// </summary>
		public string DKIMRecord {
			get {
				return GetTypedColumnValue<string>("DKIMRecord");
			}
			set {
				SetColumnValue("DKIMRecord", value);
			}
		}

		/// <summary>
		/// Default DKIM key.
		/// </summary>
		public string DefaultDKIMKey {
			get {
				return GetTypedColumnValue<string>("DefaultDKIMKey");
			}
			set {
				SetColumnValue("DefaultDKIMKey", value);
			}
		}

		/// <summary>
		/// Cache key.
		/// </summary>
		public string CacheKey {
			get {
				return GetTypedColumnValue<string>("CacheKey");
			}
			set {
				SetColumnValue("CacheKey", value);
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

