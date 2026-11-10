namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SenderDomain

	/// <exclude/>
	public class SenderDomain : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SenderDomain(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SenderDomain";
		}

		public SenderDomain(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SenderDomain";
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

		/// <summary>
		/// Domain.
		/// </summary>
		public string Domain {
			get {
				return GetTypedColumnValue<string>("Domain");
			}
			set {
				SetColumnValue("Domain", value);
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
		/// SPF key.
		/// </summary>
		public string SpfKey {
			get {
				return GetTypedColumnValue<string>("SpfKey");
			}
			set {
				SetColumnValue("SpfKey", value);
			}
		}

		/// <summary>
		/// Mx key.
		/// </summary>
		public string Mx {
			get {
				return GetTypedColumnValue<string>("Mx");
			}
			set {
				SetColumnValue("Mx", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Error.
		/// </summary>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// SenderProvider.
		/// </summary>
		public string SenderProvider {
			get {
				return GetTypedColumnValue<string>("SenderProvider");
			}
			set {
				SetColumnValue("SenderProvider", value);
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
		public Guid SenderDomainsInfoId {
			get {
				return GetTypedColumnValue<Guid>("SenderDomainsInfoId");
			}
			set {
				SetColumnValue("SenderDomainsInfoId", value);
				_senderDomainsInfo = null;
			}
		}

		private SenderDomainsInfo _senderDomainsInfo;
		/// <summary>
		/// Sender domains info.
		/// </summary>
		public SenderDomainsInfo SenderDomainsInfo {
			get {
				return _senderDomainsInfo ??
					(_senderDomainsInfo = new SenderDomainsInfo(LookupColumnEntities.GetEntity("SenderDomainsInfo")));
			}
		}

		/// <exclude/>
		public Guid SenderDomainStatusId {
			get {
				return GetTypedColumnValue<Guid>("SenderDomainStatusId");
			}
			set {
				SetColumnValue("SenderDomainStatusId", value);
				_senderDomainStatus = null;
			}
		}

		/// <exclude/>
		public string SenderDomainStatusName {
			get {
				return GetTypedColumnValue<string>("SenderDomainStatusName");
			}
			set {
				SetColumnValue("SenderDomainStatusName", value);
				if (_senderDomainStatus != null) {
					_senderDomainStatus.Name = value;
				}
			}
		}

		private SenderDomainStatus _senderDomainStatus;
		/// <summary>
		/// SenderDomainStatus.
		/// </summary>
		public SenderDomainStatus SenderDomainStatus {
			get {
				return _senderDomainStatus ??
					(_senderDomainStatus = new SenderDomainStatus(LookupColumnEntities.GetEntity("SenderDomainStatus")));
			}
		}

		#endregion

	}

	#endregion

}

