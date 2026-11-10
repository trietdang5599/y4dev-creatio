namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: UserConsentHistory

	/// <exclude/>
	public class UserConsentHistory : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public UserConsentHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UserConsentHistory";
		}

		public UserConsentHistory(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "UserConsentHistory";
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
		/// Acceptance date.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
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
		/// Accepted by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
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
		/// Consent expiration date.
		/// </summary>
		public DateTime ExpirationDate {
			get {
				return GetTypedColumnValue<DateTime>("ExpirationDate");
			}
			set {
				SetColumnValue("ExpirationDate", value);
			}
		}

		/// <exclude/>
		public Guid ConsentCodeId {
			get {
				return GetTypedColumnValue<Guid>("ConsentCodeId");
			}
			set {
				SetColumnValue("ConsentCodeId", value);
				_consentCode = null;
			}
		}

		/// <exclude/>
		public string ConsentCodeName {
			get {
				return GetTypedColumnValue<string>("ConsentCodeName");
			}
			set {
				SetColumnValue("ConsentCodeName", value);
				if (_consentCode != null) {
					_consentCode.Name = value;
				}
			}
		}

		private Consent _consentCode;
		/// <summary>
		/// Consent code.
		/// </summary>
		public Consent ConsentCode {
			get {
				return _consentCode ??
					(_consentCode = new Consent(LookupColumnEntities.GetEntity("ConsentCode")));
			}
		}

		#endregion

	}

	#endregion

}

