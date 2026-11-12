namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: Account

	/// <exclude/>
	public class Account : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Account(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account";
		}

		public Account(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Account";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByParent {
			get;
			set;
		}

		public IEnumerable<AccountAddress> AccountAddressCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountAlternativeName> AccountAlternativeNameCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountAnniversary> AccountAnniversaryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountBillingInfo> AccountBillingInfoCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountCommunication> AccountCommunicationCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountCompetitor> AccountCompetitorCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountDuplicate> AccountDuplicateCollectionByEntity1 {
			get;
			set;
		}

		public IEnumerable<AccountDuplicate> AccountDuplicateCollectionByEntity2 {
			get;
			set;
		}

		public IEnumerable<AccountEnrichedData> AccountEnrichedDataCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountFile> AccountFileCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountInFolder> AccountInFolderCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AccountInTag> AccountInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<AccountOrganizationChart> AccountOrganizationChartCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Activity> ActivityCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<AIInsight> AIInsightCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<CompetitorProduct> CompetitorProductCollectionByCompetitor {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<ContactCareer> ContactCareerCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<CTISearchResult> CTISearchResultCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EmailFolderColumnValuesSetting> EmailFolderColumnValuesSettingCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Employee> EmployeeCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EmployeeCareer> EmployeeCareerCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<EnrchFoundAccount> EnrchFoundAccountCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<NewsInsightsSchedule> NewsInsightsScheduleCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<QuickDialUserSettings> QuickDialUserSettingsCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<Relationship> RelationshipCollectionByAccountA {
			get;
			set;
		}

		public IEnumerable<Relationship> RelationshipCollectionByAccountB {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByPortalAccount {
			get;
			set;
		}

		public IEnumerable<VwAccountDuplicate> VwAccountDuplicateCollectionByEntity1 {
			get;
			set;
		}

		public IEnumerable<VwAccountDuplicate> VwAccountDuplicateCollectionByEntity2 {
			get;
			set;
		}

		public IEnumerable<VwAccountModuleHistory> VwAccountModuleHistoryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByRelatedAccount {
			get;
			set;
		}

		public IEnumerable<VwAnniversary> VwAnniversaryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwContactRelationship> VwContactRelationshipCollectionByRelatedAccount {
			get;
			set;
		}

		public IEnumerable<VwModuleHistory> VwModuleHistoryCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwRelationship> VwRelationshipCollectionByAccountA {
			get;
			set;
		}

		public IEnumerable<VwRelationship> VwRelationshipCollectionByAccountB {
			get;
			set;
		}

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionByPortalAccount {
			get;
			set;
		}

		public IEnumerable<VwSSPSysAdminUnit> VwSSPSysAdminUnitCollectionByAccount {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionByAccount {
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
		/// Primary phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Alternate phone.
		/// </summary>
		public string AdditionalPhone {
			get {
				return GetTypedColumnValue<string>("AdditionalPhone");
			}
			set {
				SetColumnValue("AdditionalPhone", value);
			}
		}

		/// <summary>
		/// Fax.
		/// </summary>
		public string Fax {
			get {
				return GetTypedColumnValue<string>("Fax");
			}
			set {
				SetColumnValue("Fax", value);
			}
		}

		/// <summary>
		/// Web.
		/// </summary>
		public string Web {
			get {
				return GetTypedColumnValue<string>("Web");
			}
			set {
				SetColumnValue("Web", value);
			}
		}

		/// <summary>
		/// Address.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// ZIP/postal code.
		/// </summary>
		public string Zip {
			get {
				return GetTypedColumnValue<string>("Zip");
			}
			set {
				SetColumnValue("Zip", value);
			}
		}

		/// <summary>
		/// Notes.
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
		/// Also known as.
		/// </summary>
		public string AlternativeName {
			get {
				return GetTypedColumnValue<string>("AlternativeName");
			}
			set {
				SetColumnValue("AlternativeName", value);
			}
		}

		/// <summary>
		/// GPS N.
		/// </summary>
		public string GPSN {
			get {
				return GetTypedColumnValue<string>("GPSN");
			}
			set {
				SetColumnValue("GPSN", value);
			}
		}

		/// <summary>
		/// GPS E.
		/// </summary>
		public string GPSE {
			get {
				return GetTypedColumnValue<string>("GPSE");
			}
			set {
				SetColumnValue("GPSE", value);
			}
		}

		/// <summary>
		/// Data entry compliance.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		/// <summary>
		/// AUM.
		/// </summary>
		public string AUM {
			get {
				return GetTypedColumnValue<string>("AUM");
			}
			set {
				SetColumnValue("AUM", value);
			}
		}

		/// <summary>
		/// How they make money.
		/// </summary>
		public string HowTheyMakeMoney {
			get {
				return GetTypedColumnValue<string>("HowTheyMakeMoney");
			}
			set {
				SetColumnValue("HowTheyMakeMoney", value);
			}
		}

		/// <summary>
		/// Products offered.
		/// </summary>
		public string ProductsOffered {
			get {
				return GetTypedColumnValue<string>("ProductsOffered");
			}
			set {
				SetColumnValue("ProductsOffered", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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
		public Guid OwnershipId {
			get {
				return GetTypedColumnValue<Guid>("OwnershipId");
			}
			set {
				SetColumnValue("OwnershipId", value);
				_ownership = null;
			}
		}

		/// <exclude/>
		public string OwnershipName {
			get {
				return GetTypedColumnValue<string>("OwnershipName");
			}
			set {
				SetColumnValue("OwnershipName", value);
				if (_ownership != null) {
					_ownership.Name = value;
				}
			}
		}

		private AccountOwnership _ownership;
		/// <summary>
		/// Business entity.
		/// </summary>
		public AccountOwnership Ownership {
			get {
				return _ownership ??
					(_ownership = new AccountOwnership(LookupColumnEntities.GetEntity("Ownership")));
			}
		}

		/// <exclude/>
		public Guid PrimaryContactId {
			get {
				return GetTypedColumnValue<Guid>("PrimaryContactId");
			}
			set {
				SetColumnValue("PrimaryContactId", value);
				_primaryContact = null;
			}
		}

		/// <exclude/>
		public string PrimaryContactName {
			get {
				return GetTypedColumnValue<string>("PrimaryContactName");
			}
			set {
				SetColumnValue("PrimaryContactName", value);
				if (_primaryContact != null) {
					_primaryContact.Name = value;
				}
			}
		}

		private Contact _primaryContact;
		/// <summary>
		/// Primary contact.
		/// </summary>
		public Contact PrimaryContact {
			get {
				return _primaryContact ??
					(_primaryContact = new Contact(LookupColumnEntities.GetEntity("PrimaryContact")));
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Account _parent;
		/// <summary>
		/// Parent account.
		/// </summary>
		public Account Parent {
			get {
				return _parent ??
					(_parent = new Account(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid IndustryId {
			get {
				return GetTypedColumnValue<Guid>("IndustryId");
			}
			set {
				SetColumnValue("IndustryId", value);
				_industry = null;
			}
		}

		/// <exclude/>
		public string IndustryName {
			get {
				return GetTypedColumnValue<string>("IndustryName");
			}
			set {
				SetColumnValue("IndustryName", value);
				if (_industry != null) {
					_industry.Name = value;
				}
			}
		}

		private AccountIndustry _industry;
		/// <summary>
		/// Industry.
		/// </summary>
		public AccountIndustry Industry {
			get {
				return _industry ??
					(_industry = new AccountIndustry(LookupColumnEntities.GetEntity("Industry")));
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

		private AccountType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public AccountType Type {
			get {
				return _type ??
					(_type = new AccountType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid AddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("AddressTypeId");
			}
			set {
				SetColumnValue("AddressTypeId", value);
				_addressType = null;
			}
		}

		/// <exclude/>
		public string AddressTypeName {
			get {
				return GetTypedColumnValue<string>("AddressTypeName");
			}
			set {
				SetColumnValue("AddressTypeName", value);
				if (_addressType != null) {
					_addressType.Name = value;
				}
			}
		}

		private AddressType _addressType;
		/// <summary>
		/// Address type.
		/// </summary>
		public AddressType AddressType {
			get {
				return _addressType ??
					(_addressType = new AddressType(LookupColumnEntities.GetEntity("AddressType")));
			}
		}

		/// <exclude/>
		public Guid CityId {
			get {
				return GetTypedColumnValue<Guid>("CityId");
			}
			set {
				SetColumnValue("CityId", value);
				_city = null;
			}
		}

		/// <exclude/>
		public string CityName {
			get {
				return GetTypedColumnValue<string>("CityName");
			}
			set {
				SetColumnValue("CityName", value);
				if (_city != null) {
					_city.Name = value;
				}
			}
		}

		private City _city;
		/// <summary>
		/// City.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = new City(LookupColumnEntities.GetEntity("City")));
			}
		}

		/// <exclude/>
		public Guid RegionId {
			get {
				return GetTypedColumnValue<Guid>("RegionId");
			}
			set {
				SetColumnValue("RegionId", value);
				_region = null;
			}
		}

		/// <exclude/>
		public string RegionName {
			get {
				return GetTypedColumnValue<string>("RegionName");
			}
			set {
				SetColumnValue("RegionName", value);
				if (_region != null) {
					_region.Name = value;
				}
			}
		}

		private Region _region;
		/// <summary>
		/// State/province.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = new Region(LookupColumnEntities.GetEntity("Region")));
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
		public Guid AccountCategoryId {
			get {
				return GetTypedColumnValue<Guid>("AccountCategoryId");
			}
			set {
				SetColumnValue("AccountCategoryId", value);
				_accountCategory = null;
			}
		}

		/// <exclude/>
		public string AccountCategoryName {
			get {
				return GetTypedColumnValue<string>("AccountCategoryName");
			}
			set {
				SetColumnValue("AccountCategoryName", value);
				if (_accountCategory != null) {
					_accountCategory.Name = value;
				}
			}
		}

		private AccountCategory _accountCategory;
		/// <summary>
		/// Category.
		/// </summary>
		public AccountCategory AccountCategory {
			get {
				return _accountCategory ??
					(_accountCategory = new AccountCategory(LookupColumnEntities.GetEntity("AccountCategory")));
			}
		}

		/// <exclude/>
		public Guid EmployeesNumberId {
			get {
				return GetTypedColumnValue<Guid>("EmployeesNumberId");
			}
			set {
				SetColumnValue("EmployeesNumberId", value);
				_employeesNumber = null;
			}
		}

		/// <exclude/>
		public string EmployeesNumberName {
			get {
				return GetTypedColumnValue<string>("EmployeesNumberName");
			}
			set {
				SetColumnValue("EmployeesNumberName", value);
				if (_employeesNumber != null) {
					_employeesNumber.Name = value;
				}
			}
		}

		private AccountEmployeesNumber _employeesNumber;
		/// <summary>
		/// No. of employees.
		/// </summary>
		public AccountEmployeesNumber EmployeesNumber {
			get {
				return _employeesNumber ??
					(_employeesNumber = new AccountEmployeesNumber(LookupColumnEntities.GetEntity("EmployeesNumber")));
			}
		}

		/// <exclude/>
		public Guid AnnualRevenueId {
			get {
				return GetTypedColumnValue<Guid>("AnnualRevenueId");
			}
			set {
				SetColumnValue("AnnualRevenueId", value);
				_annualRevenue = null;
			}
		}

		/// <exclude/>
		public string AnnualRevenueName {
			get {
				return GetTypedColumnValue<string>("AnnualRevenueName");
			}
			set {
				SetColumnValue("AnnualRevenueName", value);
				if (_annualRevenue != null) {
					_annualRevenue.Name = value;
				}
			}
		}

		private AccountAnnualRevenue _annualRevenue;
		/// <summary>
		/// Annual revenue.
		/// </summary>
		public AccountAnnualRevenue AnnualRevenue {
			get {
				return _annualRevenue ??
					(_annualRevenue = new AccountAnnualRevenue(LookupColumnEntities.GetEntity("AnnualRevenue")));
			}
		}

		/// <exclude/>
		public Guid AccountLogoId {
			get {
				return GetTypedColumnValue<Guid>("AccountLogoId");
			}
			set {
				SetColumnValue("AccountLogoId", value);
				_accountLogo = null;
			}
		}

		/// <exclude/>
		public string AccountLogoName {
			get {
				return GetTypedColumnValue<string>("AccountLogoName");
			}
			set {
				SetColumnValue("AccountLogoName", value);
				if (_accountLogo != null) {
					_accountLogo.Name = value;
				}
			}
		}

		private SysImage _accountLogo;
		/// <summary>
		/// Account logo.
		/// </summary>
		public SysImage AccountLogo {
			get {
				return _accountLogo ??
					(_accountLogo = new SysImage(LookupColumnEntities.GetEntity("AccountLogo")));
			}
		}

		#endregion

	}

	#endregion

}

