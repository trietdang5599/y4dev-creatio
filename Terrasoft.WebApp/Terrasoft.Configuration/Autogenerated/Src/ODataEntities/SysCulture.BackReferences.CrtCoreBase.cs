namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysCulture

	/// <exclude/>
	public class SysCulture : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysCulture(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCulture";
		}

		public SysCulture(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysCulture";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MainParamLczOld> MainParamLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysClientUnitSchemaSource> SysClientUnitSchemaSourceCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysDataLocalizableValue> SysDataLocalizableValueCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysDataLocalizableValueChecksum> SysDataLocalizableValueChecksumCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysLocalizableValue> SysLocalizableValueCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleActionLczOld> SysModuleActionLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleAnalyticsReportLczOld> SysModuleAnalyticsReportLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleDetailLczOld> SysModuleDetailLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleEditLczOld> SysModuleEditLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleFolderLczOld> SysModuleFolderLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleLczOld> SysModuleLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysModuleReportLczOld> SysModuleReportLczOldCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysPackageDataLcz> SysPackageDataLczCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysPackageResourceChecksum> SysPackageResourceChecksumCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysProfileData> SysProfileDataCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysUserLevelLocalizableValue> SysUserLevelLocalizableValueCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<SysUserLevelSchemaClientSource> SysUserLevelSchemaClientSourceCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<TranslationStatus> TranslationStatusCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<VwSSPSysAdminUnit> VwSSPSysAdminUnitCollectionBySysCulture {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionBySysCulture {
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
		/// Code.
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

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Index.
		/// </summary>
		public int Index {
			get {
				return GetTypedColumnValue<int>("Index");
			}
			set {
				SetColumnValue("Index", value);
			}
		}

		/// <summary>
		/// Use by default.
		/// </summary>
		public bool Default {
			get {
				return GetTypedColumnValue<bool>("Default");
			}
			set {
				SetColumnValue("Default", value);
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
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Name.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = new SysLanguage(LookupColumnEntities.GetEntity("Language")));
			}
		}

		#endregion

	}

	#endregion

}

