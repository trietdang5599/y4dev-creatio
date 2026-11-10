namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.OperationLog;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;
	using Terrasoft.Web.Common;

	#region Class: VwSysAdminUnit_CrtBase_CreatioSchema

	/// <exclude/>
	public class VwSysAdminUnit_CrtBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwSysAdminUnit_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysAdminUnit_CrtBase_CreatioSchema(VwSysAdminUnit_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysAdminUnit_CrtBase_CreatioSchema(VwSysAdminUnit_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			RealUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			Name = "VwSysAdminUnit_CrtBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = true;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentRoleColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3b1b6e4c-aa09-413c-9ded-a6ad81bb93c1")) == null) {
				Columns.Add(CreateSysAdminUnitTypeColumn());
			}
			if (Columns.FindByUId(new Guid("328f73e7-ebde-432f-9052-a0365b3105e8")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("45d5d808-1ad8-42bf-aaf2-177dcd2079c7")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("72a7351e-36cf-40f9-b334-0a7563bd60fb")) == null) {
				Columns.Add(CreateIsDirectoryEntryColumn());
			}
			if (Columns.FindByUId(new Guid("8280981b-5189-40a1-b700-6a35c572dba2")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("a07a30ff-b3df-45db-a83c-bf89027250d8")) == null) {
				Columns.Add(CreateUserPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("a986b074-459c-40b1-b4b6-0e286b3ef123")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("937f2044-f446-4975-9caf-de9e7c972fb9")) == null) {
				Columns.Add(CreateLoggedInColumn());
			}
			if (Columns.FindByUId(new Guid("2e25fe29-ea38-4db2-84d5-03a8db9b2491")) == null) {
				Columns.Add(CreateLDAPEntryColumn());
			}
			if (Columns.FindByUId(new Guid("184336ef-e07a-4f5a-9850-8d4ccaff520f")) == null) {
				Columns.Add(CreateSynchronizeWithLDAPColumn());
			}
			if (Columns.FindByUId(new Guid("c2748d54-0f48-4251-bfc0-ff6e2478348d")) == null) {
				Columns.Add(CreateLDAPEntryIdColumn());
			}
			if (Columns.FindByUId(new Guid("e161e2fc-4fac-4ae0-ba3c-e9f70d52ecb4")) == null) {
				Columns.Add(CreateLDAPEntryDNColumn());
			}
			if (Columns.FindByUId(new Guid("9eb0071c-72bd-48e1-b9e7-36c81e6aa232")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("088ae956-eb2f-4df7-ad9c-1fb9a6596a9f")) == null) {
				Columns.Add(CreatePasswordExpireDateColumn());
			}
			if (Columns.FindByUId(new Guid("5f009f32-31e0-41c2-9506-a9aa73ed64ae")) == null) {
				Columns.Add(CreateHomePageColumn());
			}
			if (Columns.FindByUId(new Guid("4acc2d13-7573-41ec-9a30-e20696bf0314")) == null) {
				Columns.Add(CreateConnectionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("57235d0d-5e90-4767-89dd-6ca3f1ba24c6")) == null) {
				Columns.Add(CreateUserConnectionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("a3c751b9-544a-420b-8df0-dc3a0e3bc147")) == null) {
				Columns.Add(CreateForceChangePasswordColumn());
			}
			if (Columns.FindByUId(new Guid("057c3dcc-44e5-4f9d-ae7f-a78e24f255bf")) == null) {
				Columns.Add(CreateDateTimeFormatColumn());
			}
			if (Columns.FindByUId(new Guid("812c55bd-f398-4747-af46-3fa83c335c9d")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("2e74086a-2d4c-48d1-80da-b0d2467597fb")) == null) {
				Columns.Add(CreateSessionTimeoutColumn());
			}
			if (Columns.FindByUId(new Guid("6ffb6aff-9cb5-f458-bb83-3be15ab10845")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("510c0a4c-93f4-b8c9-b5f2-7bb3f2510f00")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("73166daf-76bb-b80d-6441-b5c6072a2dd9")) == null) {
				Columns.Add(CreateWeekFirstDayColumn());
			}
			if (Columns.FindByUId(new Guid("3d3c831e-e4f9-ccf0-5b7a-07c2b7b7ffa4")) == null) {
				Columns.Add(CreateMobileHomePageColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3b1b6e4c-aa09-413c-9ded-a6ad81bb93c1"),
				Name = @"SysAdminUnitType",
				ReferenceSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3678b2d1-343e-4e0c-8a93-f082143be510"),
				Name = @"ParentRole",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("328f73e7-ebde-432f-9052-a0365b3105e8"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("45d5d808-1ad8-42bf-aaf2-177dcd2079c7"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDirectoryEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("72a7351e-36cf-40f9-b334-0a7563bd60fb"),
				Name = @"IsDirectoryEntry",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8280981b-5189-40a1-b700-6a35c572dba2"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"DefaultTimeZone"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUserPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("HashText")) {
				UId = new Guid("a07a30ff-b3df-45db-a83c-bf89027250d8"),
				Name = @"UserPassword",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a986b074-459c-40b1-b4b6-0e286b3ef123"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLoggedInColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("937f2044-f446-4975-9caf-de9e7c972fb9"),
				Name = @"LoggedIn",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2e25fe29-ea38-4db2-84d5-03a8db9b2491"),
				Name = @"LDAPEntry",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSynchronizeWithLDAPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("184336ef-e07a-4f5a-9850-8d4ccaff520f"),
				Name = @"SynchronizeWithLDAP",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c2748d54-0f48-4251-bfc0-ff6e2478348d"),
				Name = @"LDAPEntryId",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryDNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("e161e2fc-4fac-4ae0-ba3c-e9f70d52ecb4"),
				Name = @"LDAPEntryDN",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9eb0071c-72bd-48e1-b9e7-36c81e6aa232"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordExpireDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("088ae956-eb2f-4df7-ad9c-1fb9a6596a9f"),
				Name = @"PasswordExpireDate",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376")
			};
		}

		protected virtual EntitySchemaColumn CreateHomePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5f009f32-31e0-41c2-9506-a9aa73ed64ae"),
				Name = @"HomePage",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4acc2d13-7573-41ec-9a30-e20696bf0314"),
				Name = @"ConnectionType",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866")
			};
		}

		protected virtual EntitySchemaColumn CreateUserConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("57235d0d-5e90-4767-89dd-6ca3f1ba24c6"),
				Name = @"UserConnectionType",
				ReferenceSchemaUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateForceChangePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a3c751b9-544a-420b-8df0-dc3a0e3bc147"),
				Name = @"ForceChangePassword",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("0e850392-6b68-4c42-8cac-7764bc62a6bb")
			};
		}

		protected virtual EntitySchemaColumn CreateDateTimeFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("057c3dcc-44e5-4f9d-ae7f-a78e24f255bf"),
				Name = @"DateTimeFormat",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("99cdc391-b063-4233-bdba-da67108d1d1e")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("812c55bd-f398-4747-af46-3fa83c335c9d"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionTimeoutColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2e74086a-2d4c-48d1-80da-b0d2467597fb"),
				Name = @"SessionTimeout",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6ffb6aff-9cb5-f458-bb83-3be15ab10845"),
				Name = @"Email",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("PhoneText")) {
				UId = new Guid("510c0a4c-93f4-b8c9-b5f2-7bb3f2510f00"),
				Name = @"Phone",
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateWeekFirstDayColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("73166daf-76bb-b80d-6441-b5c6072a2dd9"),
				Name = @"WeekFirstDay",
				ReferenceSchemaUId = new Guid("268b91f8-f520-4a48-9864-f2350d841216"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateMobileHomePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3d3c831e-e4f9-ccf0-5b7a-07c2b7b7ffa4"),
				Name = @"MobileHomePage",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				ModifiedInSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysAdminUnit_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysAdminUnit_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysAdminUnit_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysAdminUnit_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnit_CrtBase_Creatio

	/// <summary>
	/// Users/roles (view).
	/// </summary>
	public class VwSysAdminUnit_CrtBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwSysAdminUnit_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminUnit_CrtBase_Creatio";
		}

		public VwSysAdminUnit_CrtBase_Creatio(VwSysAdminUnit_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitTypeId");
			}
			set {
				SetColumnValue("SysAdminUnitTypeId", value);
				_sysAdminUnitType = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitTypeName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitTypeName");
			}
			set {
				SetColumnValue("SysAdminUnitTypeName", value);
				if (_sysAdminUnitType != null) {
					_sysAdminUnitType.Name = value;
				}
			}
		}

		private SysAdminUnitType _sysAdminUnitType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysAdminUnitType SysAdminUnitType {
			get {
				return _sysAdminUnitType ??
					(_sysAdminUnitType = LookupColumnEntities.GetEntity("SysAdminUnitType") as SysAdminUnitType);
			}
		}

		/// <exclude/>
		public Guid ParentRoleId {
			get {
				return GetTypedColumnValue<Guid>("ParentRoleId");
			}
			set {
				SetColumnValue("ParentRoleId", value);
				_parentRole = null;
			}
		}

		/// <exclude/>
		public string ParentRoleName {
			get {
				return GetTypedColumnValue<string>("ParentRoleName");
			}
			set {
				SetColumnValue("ParentRoleName", value);
				if (_parentRole != null) {
					_parentRole.Name = value;
				}
			}
		}

		private VwSysAdminUnit _parentRole;
		/// <summary>
		/// Inherited from.
		/// </summary>
		public VwSysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = LookupColumnEntities.GetEntity("ParentRole") as VwSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <summary>
		/// Domain user.
		/// </summary>
		public bool IsDirectoryEntry {
			get {
				return GetTypedColumnValue<bool>("IsDirectoryEntry");
			}
			set {
				SetColumnValue("IsDirectoryEntry", value);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Time zone.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
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
		/// Logged in now.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
			}
		}

		/// <summary>
		/// LDAP element.
		/// </summary>
		public string LDAPEntry {
			get {
				return GetTypedColumnValue<string>("LDAPEntry");
			}
			set {
				SetColumnValue("LDAPEntry", value);
			}
		}

		/// <summary>
		/// Synchronize with LDAP.
		/// </summary>
		public bool SynchronizeWithLDAP {
			get {
				return GetTypedColumnValue<bool>("SynchronizeWithLDAP");
			}
			set {
				SetColumnValue("SynchronizeWithLDAP", value);
			}
		}

		/// <summary>
		/// LDAP element Id.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// LDAP element unique name .
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Password expiration date.
		/// </summary>
		public DateTime PasswordExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("PasswordExpireDate");
			}
			set {
				SetColumnValue("PasswordExpireDate", value);
			}
		}

		/// <exclude/>
		public Guid HomePageId {
			get {
				return GetTypedColumnValue<Guid>("HomePageId");
			}
			set {
				SetColumnValue("HomePageId", value);
				_homePage = null;
			}
		}

		/// <exclude/>
		public string HomePageCaption {
			get {
				return GetTypedColumnValue<string>("HomePageCaption");
			}
			set {
				SetColumnValue("HomePageCaption", value);
				if (_homePage != null) {
					_homePage.Caption = value;
				}
			}
		}

		private SysModule _homePage;
		/// <summary>
		/// Home page.
		/// </summary>
		public SysModule HomePage {
			get {
				return _homePage ??
					(_homePage = LookupColumnEntities.GetEntity("HomePage") as SysModule);
			}
		}

		/// <summary>
		/// Connection type.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		/// <exclude/>
		public Guid UserConnectionTypeId {
			get {
				return GetTypedColumnValue<Guid>("UserConnectionTypeId");
			}
			set {
				SetColumnValue("UserConnectionTypeId", value);
				_userConnectionType = null;
			}
		}

		/// <exclude/>
		public string UserConnectionTypeName {
			get {
				return GetTypedColumnValue<string>("UserConnectionTypeName");
			}
			set {
				SetColumnValue("UserConnectionTypeName", value);
				if (_userConnectionType != null) {
					_userConnectionType.Name = value;
				}
			}
		}

		private ConnectionType _userConnectionType;
		/// <summary>
		/// User Connection Type.
		/// </summary>
		public ConnectionType UserConnectionType {
			get {
				return _userConnectionType ??
					(_userConnectionType = LookupColumnEntities.GetEntity("UserConnectionType") as ConnectionType);
			}
		}

		/// <summary>
		/// Reset password.
		/// </summary>
		public bool ForceChangePassword {
			get {
				return GetTypedColumnValue<bool>("ForceChangePassword");
			}
			set {
				SetColumnValue("ForceChangePassword", value);
			}
		}

		/// <exclude/>
		public Guid DateTimeFormatId {
			get {
				return GetTypedColumnValue<Guid>("DateTimeFormatId");
			}
			set {
				SetColumnValue("DateTimeFormatId", value);
				_dateTimeFormat = null;
			}
		}

		/// <exclude/>
		public string DateTimeFormatName {
			get {
				return GetTypedColumnValue<string>("DateTimeFormatName");
			}
			set {
				SetColumnValue("DateTimeFormatName", value);
				if (_dateTimeFormat != null) {
					_dateTimeFormat.Name = value;
				}
			}
		}

		private SysLanguage _dateTimeFormat;
		/// <summary>
		/// Date and time format.
		/// </summary>
		public SysLanguage DateTimeFormat {
			get {
				return _dateTimeFormat ??
					(_dateTimeFormat = LookupColumnEntities.GetEntity("DateTimeFormat") as SysLanguage);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Session timeout.
		/// </summary>
		public int SessionTimeout {
			get {
				return GetTypedColumnValue<int>("SessionTimeout");
			}
			set {
				SetColumnValue("SessionTimeout", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <exclude/>
		public Guid WeekFirstDayId {
			get {
				return GetTypedColumnValue<Guid>("WeekFirstDayId");
			}
			set {
				SetColumnValue("WeekFirstDayId", value);
				_weekFirstDay = null;
			}
		}

		/// <exclude/>
		public string WeekFirstDayName {
			get {
				return GetTypedColumnValue<string>("WeekFirstDayName");
			}
			set {
				SetColumnValue("WeekFirstDayName", value);
				if (_weekFirstDay != null) {
					_weekFirstDay.Name = value;
				}
			}
		}

		private WeekFirstDay _weekFirstDay;
		/// <summary>
		/// First day of week.
		/// </summary>
		public WeekFirstDay WeekFirstDay {
			get {
				return _weekFirstDay ??
					(_weekFirstDay = LookupColumnEntities.GetEntity("WeekFirstDay") as WeekFirstDay);
			}
		}

		/// <exclude/>
		public Guid MobileHomePageId {
			get {
				return GetTypedColumnValue<Guid>("MobileHomePageId");
			}
			set {
				SetColumnValue("MobileHomePageId", value);
				_mobileHomePage = null;
			}
		}

		/// <exclude/>
		public string MobileHomePageCaption {
			get {
				return GetTypedColumnValue<string>("MobileHomePageCaption");
			}
			set {
				SetColumnValue("MobileHomePageCaption", value);
				if (_mobileHomePage != null) {
					_mobileHomePage.Caption = value;
				}
			}
		}

		private SysSchema _mobileHomePage;
		/// <summary>
		/// Mobile home page.
		/// </summary>
		public SysSchema MobileHomePage {
			get {
				return _mobileHomePage ??
					(_mobileHomePage = LookupColumnEntities.GetEntity("MobileHomePage") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysAdminUnit_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioSaving", e);
			Updated += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioUpdated", e);
			Validating += (s, e) => ThrowEvent("VwSysAdminUnit_CrtBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysAdminUnit_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnit_CrtBaseEventsProcess

	/// <exclude/>
	public partial class VwSysAdminUnit_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwSysAdminUnit_CrtBase_Creatio
	{

		public VwSysAdminUnit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysAdminUnit_CrtBaseEventsProcess";
			SchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Guid _userTypeId = new Guid("472E97C7-6BD7-DF11-9B2A-001D60E938C6");
		public Guid UserTypeId {
			get {
				return _userTypeId;
			}
			set {
				_userTypeId = value;
			}
		}

		private Guid _sSPUserTypeId = new Guid("F4044C41-DF2B-E111-851E-00155D04C01D");
		public Guid SSPUserTypeId {
			get {
				return _sSPUserTypeId;
			}
			set {
				_sSPUserTypeId = value;
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("c1d3a6df-d9ef-443d-9491-d7d8f810d9b0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysAdminUnitUpdated_StartMessage;
		public ProcessFlowElement VwSysAdminUnitUpdated_StartMessage {
			get {
				return _vwSysAdminUnitUpdated_StartMessage ?? (_vwSysAdminUnitUpdated_StartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysAdminUnitUpdated_StartMessage",
					SchemaElementUId = new Guid("9e74411c-5510-4baa-8e91-4ccc903a1566"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _logUpdate_ScriptTask;
		public ProcessScriptTask LogUpdate_ScriptTask {
			get {
				return _logUpdate_ScriptTask ?? (_logUpdate_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogUpdate_ScriptTask",
					SchemaElementUId = new Guid("ba71e6e4-5861-4c7a-b5f8-1bf026ab2b29"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogUpdate_ScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _vwSysAdminUnitUpdated_IntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent VwSysAdminUnitUpdated_IntermediateThrowMessageEvent {
			get {
				return _vwSysAdminUnitUpdated_IntermediateThrowMessageEvent ?? (_vwSysAdminUnitUpdated_IntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "VwSysAdminUnitUpdated_IntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("c5d63d9b-ca86-45bd-b10d-883ffc70c77c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "VwSysAdminUnitUpdated",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _updatePersonalSessionTimeouts;
		public ProcessScriptTask UpdatePersonalSessionTimeouts {
			get {
				return _updatePersonalSessionTimeouts ?? (_updatePersonalSessionTimeouts = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdatePersonalSessionTimeouts",
					SchemaElementUId = new Guid("6e4c059d-a258-4019-bc47-303f122c13a1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdatePersonalSessionTimeoutsExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("f3c0248d-0dca-48ac-9a01-fb51c132df08"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysAdminUnitInsertedMessage;
		public ProcessFlowElement VwSysAdminUnitInsertedMessage {
			get {
				return _vwSysAdminUnitInsertedMessage ?? (_vwSysAdminUnitInsertedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysAdminUnitInsertedMessage",
					SchemaElementUId = new Guid("d4567378-dd77-438e-a7f5-11a484ddc247"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptVwSysAdminUnitInserted;
		public ProcessScriptTask ScriptVwSysAdminUnitInserted {
			get {
				return _scriptVwSysAdminUnitInserted ?? (_scriptVwSysAdminUnitInserted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptVwSysAdminUnitInserted",
					SchemaElementUId = new Guid("a7c19b39-2437-4822-a248-ef50bf96c8a8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptVwSysAdminUnitInsertedExecute,
				});
			}
		}

		private ProcessScriptTask _logInsert_ScriptTask;
		public ProcessScriptTask LogInsert_ScriptTask {
			get {
				return _logInsert_ScriptTask ?? (_logInsert_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogInsert_ScriptTask",
					SchemaElementUId = new Guid("9f67ae88-4ef9-4578-9174-65bce94b91ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogInsert_ScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _checkCanChangeBeforeInsertScriptTask;
		public ProcessScriptTask CheckCanChangeBeforeInsertScriptTask {
			get {
				return _checkCanChangeBeforeInsertScriptTask ?? (_checkCanChangeBeforeInsertScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanChangeBeforeInsertScriptTask",
					SchemaElementUId = new Guid("8f66879a-a664-49b1-bc0b-8ed5c177c591"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanChangeBeforeInsertScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _insertPersonalTimeouts;
		public ProcessScriptTask InsertPersonalTimeouts {
			get {
				return _insertPersonalTimeouts ?? (_insertPersonalTimeouts = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InsertPersonalTimeouts",
					SchemaElementUId = new Guid("1dfe094f-eaad-4acc-9f31-bc1b463a60c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InsertPersonalTimeoutsExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcessVwSysAdminUnitDeleted;
		public ProcessFlowElement EventSubProcessVwSysAdminUnitDeleted {
			get {
				return _eventSubProcessVwSysAdminUnitDeleted ?? (_eventSubProcessVwSysAdminUnitDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessVwSysAdminUnitDeleted",
					SchemaElementUId = new Guid("790bf442-6d7b-439b-b68e-c0144ba8a625"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysAdminUnitSaved;
		public ProcessFlowElement VwSysAdminUnitSaved {
			get {
				return _vwSysAdminUnitSaved ?? (_vwSysAdminUnitSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysAdminUnitSaved",
					SchemaElementUId = new Guid("c321a464-5ba2-45ab-8263-73617977ccb2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _vwSysAdminUnitDeleted;
		public ProcessFlowElement VwSysAdminUnitDeleted {
			get {
				return _vwSysAdminUnitDeleted ?? (_vwSysAdminUnitDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysAdminUnitDeleted",
					SchemaElementUId = new Guid("07af8d7f-31ab-47f5-92d9-9e4a83d6b66e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _logDelete_ScriptTask;
		public ProcessScriptTask LogDelete_ScriptTask {
			get {
				return _logDelete_ScriptTask ?? (_logDelete_ScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogDelete_ScriptTask",
					SchemaElementUId = new Guid("694eafe5-6474-4ee2-8861-e21318f77d29"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogDelete_ScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _scriptTaskVwSysAdminUnitDeleted;
		public ProcessScriptTask ScriptTaskVwSysAdminUnitDeleted {
			get {
				return _scriptTaskVwSysAdminUnitDeleted ?? (_scriptTaskVwSysAdminUnitDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskVwSysAdminUnitDeleted",
					SchemaElementUId = new Guid("e615cb4a-53c7-4822-a32b-aa87e44f8d93"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskVwSysAdminUnitDeletedExecute,
				});
			}
		}

		private ProcessScriptTask _checkCanChangeBeforeSaveScriptTask;
		public ProcessScriptTask CheckCanChangeBeforeSaveScriptTask {
			get {
				return _checkCanChangeBeforeSaveScriptTask ?? (_checkCanChangeBeforeSaveScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanChangeBeforeSaveScriptTask",
					SchemaElementUId = new Guid("9c8daa2b-2fb5-45c6-a66f-74962a05945c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanChangeBeforeSaveScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _checkCanChangeBeforeDeleteScriptTask;
		public ProcessScriptTask CheckCanChangeBeforeDeleteScriptTask {
			get {
				return _checkCanChangeBeforeDeleteScriptTask ?? (_checkCanChangeBeforeDeleteScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanChangeBeforeDeleteScriptTask",
					SchemaElementUId = new Guid("0bfb173f-9eeb-41bd-b2a4-26f2fd9ce0b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanChangeBeforeDeleteScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _removePersonalUserSessionTimeout;
		public ProcessScriptTask RemovePersonalUserSessionTimeout {
			get {
				return _removePersonalUserSessionTimeout ?? (_removePersonalUserSessionTimeout = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemovePersonalUserSessionTimeout",
					SchemaElementUId = new Guid("193cc7d6-1344-486f-b0bd-797644eb81e5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemovePersonalUserSessionTimeoutExecute,
				});
			}
		}

		private ProcessFlowElement _vwSysAdminUnitSaving;
		public ProcessFlowElement VwSysAdminUnitSaving {
			get {
				return _vwSysAdminUnitSaving ?? (_vwSysAdminUnitSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "VwSysAdminUnitSaving",
					SchemaElementUId = new Guid("a1561e7e-fec3-4e8a-949c-4074c9b529f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("c51669ff-65da-4bb7-98e0-1d1e3399a259"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkCanManageUsers;
		public ProcessScriptTask checkCanManageUsers {
			get {
				return _checkCanManageUsers ?? (_checkCanManageUsers = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "checkCanManageUsers",
					SchemaElementUId = new Guid("140b62d5-8948-4aa5-862d-2a3a4581a855"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = checkCanManageUsersExecute,
				});
			}
		}

		private LocalizableString _chiefCaption;
		public LocalizableString ChiefCaption {
			get {
				return _chiefCaption ?? (_chiefCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.ChiefCaption.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[VwSysAdminUnitUpdated_StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitUpdated_StartMessage };
			FlowElements[LogUpdate_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogUpdate_ScriptTask };
			FlowElements[VwSysAdminUnitUpdated_IntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitUpdated_IntermediateThrowMessageEvent };
			FlowElements[UpdatePersonalSessionTimeouts.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdatePersonalSessionTimeouts };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[VwSysAdminUnitInsertedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitInsertedMessage };
			FlowElements[ScriptVwSysAdminUnitInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptVwSysAdminUnitInserted };
			FlowElements[LogInsert_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogInsert_ScriptTask };
			FlowElements[CheckCanChangeBeforeInsertScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanChangeBeforeInsertScriptTask };
			FlowElements[InsertPersonalTimeouts.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertPersonalTimeouts };
			FlowElements[EventSubProcessVwSysAdminUnitDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessVwSysAdminUnitDeleted };
			FlowElements[VwSysAdminUnitSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitSaved };
			FlowElements[VwSysAdminUnitDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitDeleted };
			FlowElements[LogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogDelete_ScriptTask };
			FlowElements[ScriptTaskVwSysAdminUnitDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskVwSysAdminUnitDeleted };
			FlowElements[CheckCanChangeBeforeSaveScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanChangeBeforeSaveScriptTask };
			FlowElements[CheckCanChangeBeforeDeleteScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanChangeBeforeDeleteScriptTask };
			FlowElements[RemovePersonalUserSessionTimeout.SchemaElementUId] = new Collection<ProcessFlowElement> { RemovePersonalUserSessionTimeout };
			FlowElements[VwSysAdminUnitSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysAdminUnitSaving };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[checkCanManageUsers.SchemaElementUId] = new Collection<ProcessFlowElement> { checkCanManageUsers };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "VwSysAdminUnitUpdated_StartMessage":
						e.Context.QueueTasks.Enqueue("LogUpdate_ScriptTask");
						break;
					case "LogUpdate_ScriptTask":
						e.Context.QueueTasks.Enqueue("UpdatePersonalSessionTimeouts");
						break;
					case "VwSysAdminUnitUpdated_IntermediateThrowMessageEvent":
						break;
					case "UpdatePersonalSessionTimeouts":
						e.Context.QueueTasks.Enqueue("VwSysAdminUnitUpdated_IntermediateThrowMessageEvent");
						break;
					case "SubProcess1":
						break;
					case "VwSysAdminUnitInsertedMessage":
						e.Context.QueueTasks.Enqueue("CheckCanChangeBeforeInsertScriptTask");
						break;
					case "ScriptVwSysAdminUnitInserted":
						e.Context.QueueTasks.Enqueue("InsertPersonalTimeouts");
						break;
					case "LogInsert_ScriptTask":
						e.Context.QueueTasks.Enqueue("ScriptVwSysAdminUnitInserted");
						break;
					case "CheckCanChangeBeforeInsertScriptTask":
						e.Context.QueueTasks.Enqueue("LogInsert_ScriptTask");
						break;
					case "InsertPersonalTimeouts":
						break;
					case "EventSubProcessVwSysAdminUnitDeleted":
						break;
					case "VwSysAdminUnitSaved":
						e.Context.QueueTasks.Enqueue("CheckCanChangeBeforeSaveScriptTask");
						break;
					case "VwSysAdminUnitDeleted":
						e.Context.QueueTasks.Enqueue("CheckCanChangeBeforeDeleteScriptTask");
						break;
					case "LogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("ScriptTaskVwSysAdminUnitDeleted");
						break;
					case "ScriptTaskVwSysAdminUnitDeleted":
						break;
					case "CheckCanChangeBeforeSaveScriptTask":
						e.Context.QueueTasks.Enqueue("ScriptTaskVwSysAdminUnitDeleted");
						break;
					case "CheckCanChangeBeforeDeleteScriptTask":
						e.Context.QueueTasks.Enqueue("RemovePersonalUserSessionTimeout");
						break;
					case "RemovePersonalUserSessionTimeout":
						e.Context.QueueTasks.Enqueue("LogDelete_ScriptTask");
						break;
					case "VwSysAdminUnitSaving":
						break;
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("checkCanManageUsers");
						break;
					case "checkCanManageUsers":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("VwSysAdminUnitUpdated_StartMessage");
			ActivatedEventElements.Add("VwSysAdminUnitInsertedMessage");
			ActivatedEventElements.Add("VwSysAdminUnitSaved");
			ActivatedEventElements.Add("VwSysAdminUnitDeleted");
			ActivatedEventElements.Add("StartMessage1");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysAdminUnitUpdated_StartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysAdminUnitUpdated_StartMessage";
					result = VwSysAdminUnitUpdated_StartMessage.Execute(context);
					break;
				case "LogUpdate_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogUpdate_ScriptTask";
					result = LogUpdate_ScriptTask.Execute(context, LogUpdate_ScriptTaskExecute);
					break;
				case "VwSysAdminUnitUpdated_IntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "VwSysAdminUnitUpdated");
					result = VwSysAdminUnitUpdated_IntermediateThrowMessageEvent.Execute(context);
					break;
				case "UpdatePersonalSessionTimeouts":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdatePersonalSessionTimeouts";
					result = UpdatePersonalSessionTimeouts.Execute(context, UpdatePersonalSessionTimeoutsExecute);
					break;
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysAdminUnitInsertedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysAdminUnitInsertedMessage";
					result = VwSysAdminUnitInsertedMessage.Execute(context);
					break;
				case "ScriptVwSysAdminUnitInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptVwSysAdminUnitInserted";
					result = ScriptVwSysAdminUnitInserted.Execute(context, ScriptVwSysAdminUnitInsertedExecute);
					break;
				case "LogInsert_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogInsert_ScriptTask";
					result = LogInsert_ScriptTask.Execute(context, LogInsert_ScriptTaskExecute);
					break;
				case "CheckCanChangeBeforeInsertScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanChangeBeforeInsertScriptTask";
					result = CheckCanChangeBeforeInsertScriptTask.Execute(context, CheckCanChangeBeforeInsertScriptTaskExecute);
					break;
				case "InsertPersonalTimeouts":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertPersonalTimeouts";
					result = InsertPersonalTimeouts.Execute(context, InsertPersonalTimeoutsExecute);
					break;
				case "EventSubProcessVwSysAdminUnitDeleted":
					context.QueueTasks.Dequeue();
					break;
				case "VwSysAdminUnitSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysAdminUnitSaved";
					result = VwSysAdminUnitSaved.Execute(context);
					break;
				case "VwSysAdminUnitDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysAdminUnitDeleted";
					result = VwSysAdminUnitDeleted.Execute(context);
					break;
				case "LogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogDelete_ScriptTask";
					result = LogDelete_ScriptTask.Execute(context, LogDelete_ScriptTaskExecute);
					break;
				case "ScriptTaskVwSysAdminUnitDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskVwSysAdminUnitDeleted";
					result = ScriptTaskVwSysAdminUnitDeleted.Execute(context, ScriptTaskVwSysAdminUnitDeletedExecute);
					break;
				case "CheckCanChangeBeforeSaveScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanChangeBeforeSaveScriptTask";
					result = CheckCanChangeBeforeSaveScriptTask.Execute(context, CheckCanChangeBeforeSaveScriptTaskExecute);
					break;
				case "CheckCanChangeBeforeDeleteScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanChangeBeforeDeleteScriptTask";
					result = CheckCanChangeBeforeDeleteScriptTask.Execute(context, CheckCanChangeBeforeDeleteScriptTaskExecute);
					break;
				case "RemovePersonalUserSessionTimeout":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemovePersonalUserSessionTimeout";
					result = RemovePersonalUserSessionTimeout.Execute(context, RemovePersonalUserSessionTimeoutExecute);
					break;
				case "VwSysAdminUnitSaving":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "checkCanManageUsers":
					context.QueueTasks.Dequeue();
					context.SenderName = "checkCanManageUsers";
					result = checkCanManageUsers.Execute(context, checkCanManageUsersExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool LogUpdate_ScriptTaskExecute(ProcessExecutingContext context) {
			if (GetIsAdminUnitNotUser()) {
				OperationLogger.Instance.LogAdminUnitEdit(UserConnection, Entity.Name, Entity.GetChangedColumnValues().Where(c => c.Column.UsageType != Terrasoft.Core.Entities.EntitySchemaColumnUsageType.Advanced));
			}
			else {
				OperationLogger.Instance.LogUserEdit(UserConnection, Entity.Name, Entity.GetChangedColumnValues().Where(c => c.Column.UsageType != Terrasoft.Core.Entities.EntitySchemaColumnUsageType.Advanced));
			}
			return true;
		}

		public virtual bool UpdatePersonalSessionTimeoutsExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO CRM-44388
			SessionHelper sessionHelper = new SessionHelper();
			var changedSessionTimeoutColumn = Entity.GetChangedColumnValues().Where(changedColumn => changedColumn.Name == "SessionTimeout");
			if (changedSessionTimeoutColumn.Count() == 0) {
				return true;
			}
			var sessionTimeoutColumn = changedSessionTimeoutColumn.First();
			if (GetIsAdminUnitNotUser()) {
				sessionHelper.SetPersonalUserSessionTimeouts(UserConnection.AppConnection.SystemUserConnection);
			} else {
				object newValue = sessionTimeoutColumn.Value;
				if (newValue.ToString() == string.Empty) {
					sessionHelper.UpdatePersonalUserSessionTimeoutFromDB(UserConnection.AppConnection.SystemUserConnection, Entity.Id);
				} else {
					sessionHelper.UpdatePersonalUserSessionTimeoutInCache(Entity.Name, Entity.SessionTimeout);
				}
			}
			#endif
			return true;
		}

		public virtual bool ScriptVwSysAdminUnitInsertedExecute(ProcessExecutingContext context) {
			if (Entity.SysAdminUnitTypeId == new Guid("DF93DCB9-6BD7-DF11-9B2A-001D60E938C6") || Entity.SysAdminUnitTypeId == new Guid("B659F1C0-6BD7-DF11-9B2A-001D60E938C6")) {
				var selectCount = new Terrasoft.Core.DB.Select(Entity.UserConnection)
						.Column(Terrasoft.Core.DB.Func.Count(Terrasoft.Core.DB.Column.Asterisk()))
					.From("SysAdminUnit")
					.Where("SysAdminUnitTypeValue").IsEqual(Terrasoft.Core.DB.Column.Parameter(2))
					.And("ParentRoleId").IsEqual(Terrasoft.Core.DB.Column.Parameter(Entity.Id)) as Terrasoft.Core.DB.Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {	
					using (var reader = selectCount.ExecuteReader(dbExecutor)) {
						if (reader.Read()) {
							if (UserConnection.DBTypeConverter.DBValueToInt(reader[0]) > 0) {
							return true;
							}
						}
					}
				}
				Guid acountId = Entity.AccountId;
				string adminUnitName = string.Concat(Entity.Name, ". ", ChiefCaption);
				var nullParameter = Terrasoft.Core.DB.Column.Parameter(DBNull.Value, new GuidDataValueType(UserConnection.DataValueTypeManager));
				var insert = new Terrasoft.Core.DB.Insert(Entity.UserConnection).Into("SysAdminUnit")
					.Set("Id", Terrasoft.Core.DB.Column.Parameter(Guid.NewGuid()))
					.Set("CreatedOn", Terrasoft.Core.DB.Column.Parameter(DateTime.UtcNow))
					.Set("CreatedById", Terrasoft.Core.DB.Column.Parameter(Entity.UserConnection.CurrentUser.ContactId))
					.Set("ModifiedOn", Terrasoft.Core.DB.Column.Parameter(DateTime.UtcNow))
					.Set("ModifiedById", Terrasoft.Core.DB.Column.Parameter(Entity.UserConnection.CurrentUser.ContactId))
					.Set("Name", Terrasoft.Core.DB.Column.Parameter(adminUnitName))
					.Set("SysAdminUnitTypeValue", Terrasoft.Core.DB.Column.Parameter(2))
					.Set("ParentRoleId", Terrasoft.Core.DB.Column.Parameter(Entity.Id))
					.Set("AccountId", acountId.Equals(Guid.Empty) ? nullParameter : Terrasoft.Core.DB.Column.Parameter(acountId))
					.Set("ConnectionType",
						new Select(Entity.UserConnection)
							.Column("ConnectionType")
						.From("SysAdminUnit")
						.Where("Id").IsEqual(Terrasoft.Core.DB.Column.Parameter(Entity.Id)) as Select);
				insert.Execute();
				OperationLogger.Instance.LogAdminUnitAdd(UserConnection, adminUnitName);
			}
			return true;
		}

		public virtual bool LogInsert_ScriptTaskExecute(ProcessExecutingContext context) {
			if (GetIsAdminUnitNotUser()) {
				OperationLogger.Instance.LogAdminUnitAdd(UserConnection, Entity.Name);
			}
			else {
				OperationLogger.Instance.LogUserAdd(UserConnection, Entity.Name);
			}
			return true;
		}

		public virtual bool CheckCanChangeBeforeInsertScriptTaskExecute(ProcessExecutingContext context) {
			return ValidateCanChangeRecord();
		}

		public virtual bool InsertPersonalTimeoutsExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO CRM-44388
			if (!GetIsAdminUnitNotUser()) {
				SessionHelper sessionHelper = new SessionHelper();
				sessionHelper.UpdatePersonalUserSessionTimeoutInCache(Entity.Name, Entity.SessionTimeout);
			}
			#endif
			return true;
		}

		public virtual bool LogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			if (GetIsAdminUnitNotUser()) {
				OperationLogger.Instance.LogAdminUnitDelete(UserConnection, Entity.Name);
			}
			else {
				OperationLogger.Instance.LogUserDelete(UserConnection, Entity.Name);
			}
			return true;
		}

		public virtual bool ScriptTaskVwSysAdminUnitDeletedExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool CheckCanChangeBeforeSaveScriptTaskExecute(ProcessExecutingContext context) {
			return ValidateCanChangeRecord();
		}

		public virtual bool CheckCanChangeBeforeDeleteScriptTaskExecute(ProcessExecutingContext context) {
			return ValidateCanChangeRecord();
		}

		public virtual bool RemovePersonalUserSessionTimeoutExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO CRM-44388
			if (!GetIsAdminUnitNotUser()) {
				SessionHelper sessionHelper = new SessionHelper();
				sessionHelper.RemovePersonalUserSessionTimeoutFromCache(Entity.Name);
			}
			#endif
			return true;
		}

		public virtual bool checkCanManageUsersExecute(ProcessExecutingContext context) {
			return ValidateCanChangeRecord();
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwSysAdminUnit_CrtBase_CreatioUpdated":
							if (ActivatedEventElements.Contains("VwSysAdminUnitUpdated_StartMessage")) {
							context.QueueTasks.Enqueue("VwSysAdminUnitUpdated_StartMessage");
						}
						break;
					case "VwSysAdminUnit_CrtBase_CreatioInserted":
							if (ActivatedEventElements.Contains("VwSysAdminUnitInsertedMessage")) {
							context.QueueTasks.Enqueue("VwSysAdminUnitInsertedMessage");
						}
						break;
					case "VwSysAdminUnit_CrtBase_CreatioSaved":
							if (ActivatedEventElements.Contains("VwSysAdminUnitSaved")) {
							context.QueueTasks.Enqueue("VwSysAdminUnitSaved");
						}
						break;
					case "VwSysAdminUnit_CrtBase_CreatioDeleted":
							if (ActivatedEventElements.Contains("VwSysAdminUnitDeleted")) {
							context.QueueTasks.Enqueue("VwSysAdminUnitDeleted");
						}
						break;
					case "VwSysAdminUnit_CrtBase_CreatioSaving":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasks.Enqueue("StartMessage1");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnit_CrtBaseEventsProcess

	/// <exclude/>
	public class VwSysAdminUnit_CrtBaseEventsProcess : VwSysAdminUnit_CrtBaseEventsProcess<VwSysAdminUnit_CrtBase_Creatio>
	{

		public VwSysAdminUnit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

