namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: AccountBillingInfo

	/// <exclude/>
	public class AccountBillingInfo : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AccountBillingInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountBillingInfo";
		}

		public AccountBillingInfo(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AccountBillingInfo";
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
		/// Banking details.
		/// </summary>
		public string BillingInfo {
			get {
				return GetTypedColumnValue<string>("BillingInfo");
			}
			set {
				SetColumnValue("BillingInfo", value);
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
		/// Legal entity.
		/// </summary>
		public string LegalUnit {
			get {
				return GetTypedColumnValue<string>("LegalUnit");
			}
			set {
				SetColumnValue("LegalUnit", value);
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
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid CountryId {
			get {
				return GetTypedColumnValue<Guid>("CountryId");
			}
			set {
				SetColumnValue("CountryId", value);
				_country = null;
			}
		}

		/// <exclude/>
		public string CountryName {
			get {
				return GetTypedColumnValue<string>("CountryName");
			}
			set {
				SetColumnValue("CountryName", value);
				if (_country != null) {
					_country.Name = value;
				}
			}
		}

		private Country _country;
		/// <summary>
		/// Country.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = new Country(LookupColumnEntities.GetEntity("Country")));
			}
		}

		/// <exclude/>
		public Guid AccountManagerId {
			get {
				return GetTypedColumnValue<Guid>("AccountManagerId");
			}
			set {
				SetColumnValue("AccountManagerId", value);
				_accountManager = null;
			}
		}

		/// <exclude/>
		public string AccountManagerName {
			get {
				return GetTypedColumnValue<string>("AccountManagerName");
			}
			set {
				SetColumnValue("AccountManagerName", value);
				if (_accountManager != null) {
					_accountManager.Name = value;
				}
			}
		}

		private Contact _accountManager;
		/// <summary>
		/// Manager.
		/// </summary>
		public Contact AccountManager {
			get {
				return _accountManager ??
					(_accountManager = new Contact(LookupColumnEntities.GetEntity("AccountManager")));
			}
		}

		/// <exclude/>
		public Guid ChiefAccountantId {
			get {
				return GetTypedColumnValue<Guid>("ChiefAccountantId");
			}
			set {
				SetColumnValue("ChiefAccountantId", value);
				_chiefAccountant = null;
			}
		}

		/// <exclude/>
		public string ChiefAccountantName {
			get {
				return GetTypedColumnValue<string>("ChiefAccountantName");
			}
			set {
				SetColumnValue("ChiefAccountantName", value);
				if (_chiefAccountant != null) {
					_chiefAccountant.Name = value;
				}
			}
		}

		private Contact _chiefAccountant;
		/// <summary>
		/// Chief accountant.
		/// </summary>
		public Contact ChiefAccountant {
			get {
				return _chiefAccountant ??
					(_chiefAccountant = new Contact(LookupColumnEntities.GetEntity("ChiefAccountant")));
			}
		}

		#endregion

	}

	#endregion

}

