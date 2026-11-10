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

	#region Class: SysAdminUnit_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class SysAdminUnit_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysAdminUnit_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnit_CrtCoreBase_CreatioSchema(SysAdminUnit_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnit_CrtCoreBase_CreatioSchema(SysAdminUnit_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysAdminUnitNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a09035f6-13ab-41d9-af1c-c095e5cf9ac1");
			index.Name = "IUSysAdminUnitName";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c950219-374c-425c-8082-7e7de785ba20"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			EntitySchemaIndexColumn parentRoleIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3c1b73d7-6adf-4567-88c8-8b95952dc03c"),
				ColumnUId = new Guid("fa4483b3-a2db-4651-a462-689be18351e7"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("81adfa8e-1f43-43a3-9652-1b782e1a0cf1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(parentRoleIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISAULoggedInActiveIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("cf9e2407-d54a-4930-bdfc-ce9bc64ddfb4");
			index.Name = "ISAULoggedInActive";
			index.CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn loggedInIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d9c799ef-023d-492c-879d-52d11308d0e8"),
				ColumnUId = new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(loggedInIndexColumn);
			EntitySchemaIndexColumn activeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("670a80ef-4ebe-4c5d-a5d1-e03f9edc4367"),
				ColumnUId = new Guid("48f37442-a2da-4407-9178-72073ba6b09f"),
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			RealUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			Name = "SysAdminUnit_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
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
			if (Columns.FindByUId(new Guid("9fe61fde-536b-4cef-9be7-d44a23ca6dfd")) == null) {
				Columns.Add(CreateSysAdminUnitTypeValueColumn());
			}
			if (Columns.FindByUId(new Guid("14f78dc8-e6ef-48a4-b5e1-0fe3360ee7b3")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("c7d4cc94-ccea-4c6d-a600-0be32fb246e9")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("e51e9d6c-a0ac-4821-8a9d-2eb60a7fb0af")) == null) {
				Columns.Add(CreateIsDirectoryEntryColumn());
			}
			if (Columns.FindByUId(new Guid("f55f68c3-6fa7-4f18-9fa7-cbd290313d6f")) == null) {
				Columns.Add(CreateTimeZoneIdColumn());
			}
			if (Columns.FindByUId(new Guid("ac9e4b9c-ee3c-49de-b850-640e6e5027a6")) == null) {
				Columns.Add(CreateUserPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("48f37442-a2da-4407-9178-72073ba6b09f")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("45170632-a64e-4639-bdd4-a260e339e3a6")) == null) {
				Columns.Add(CreateSynchronizeWithLDAPColumn());
			}
			if (Columns.FindByUId(new Guid("6bc5084a-56d6-40a1-a796-db979322ee81")) == null) {
				Columns.Add(CreateLDAPEntryColumn());
			}
			if (Columns.FindByUId(new Guid("a059e7cc-2a06-4b03-96ac-473b705515ad")) == null) {
				Columns.Add(CreateLDAPEntryIdColumn());
			}
			if (Columns.FindByUId(new Guid("afee2179-455d-4836-b29f-b2f136918669")) == null) {
				Columns.Add(CreateLDAPEntryDNColumn());
			}
			if (Columns.FindByUId(new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161")) == null) {
				Columns.Add(CreateLoggedInColumn());
			}
			if (Columns.FindByUId(new Guid("939bf64d-89a5-4613-9240-d0abc127dff5")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("1a8cff58-add0-4390-b00c-f6f0da971c52")) == null) {
				Columns.Add(CreateLoginAttemptCountColumn());
			}
			if (Columns.FindByUId(new Guid("d05ec764-2e70-4238-b972-b5194cd493e7")) == null) {
				Columns.Add(CreateSourceControlLoginColumn());
			}
			if (Columns.FindByUId(new Guid("2bcf9b58-9cd3-48ed-892e-c57dd8c6eede")) == null) {
				Columns.Add(CreateSourceControlPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("4d03eb04-195b-43e5-9238-c9864b08b44b")) == null) {
				Columns.Add(CreatePasswordExpireDateColumn());
			}
			if (Columns.FindByUId(new Guid("b06d0431-a020-469f-b929-77cb3e6d6170")) == null) {
				Columns.Add(CreateHomePageColumn());
			}
			if (Columns.FindByUId(new Guid("61e854be-0394-4c7c-b703-cd1ded0aab45")) == null) {
				Columns.Add(CreateConnectionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("b9e2d8e5-55b7-4b81-adb3-19796d751140")) == null) {
				Columns.Add(CreateUnblockTimeColumn());
			}
			if (Columns.FindByUId(new Guid("7e132411-1beb-453b-9ed4-30141fcc0894")) == null) {
				Columns.Add(CreateForceChangePasswordColumn());
			}
			if (Columns.FindByUId(new Guid("d95527e7-b728-4142-8559-e9af9ee8d22d")) == null) {
				Columns.Add(CreateDateTimeFormatColumn());
			}
			if (Columns.FindByUId(new Guid("c619e945-1ea9-40ab-af0c-7e6f71f92ce7")) == null) {
				Columns.Add(CreateSessionTimeoutColumn());
			}
			if (Columns.FindByUId(new Guid("083c3536-988b-7e52-29fc-fb146209611f")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("05285753-233b-1ead-c796-b94edb80dd9a")) == null) {
				Columns.Add(CreateOpenIDSubColumn());
			}
			if (Columns.FindByUId(new Guid("66f943e0-29ef-4bc5-01db-c00b04a5a4cb")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("e27b5ec1-6d1b-db21-f883-9fff6231f106")) == null) {
				Columns.Add(CreateWeekFirstDayColumn());
			}
			if (Columns.FindByUId(new Guid("138395e7-8528-67d3-bf4b-21cb6bd7ffb1")) == null) {
				Columns.Add(CreateNumberFormatColumn());
			}
			if (Columns.FindByUId(new Guid("06c49adf-a2ce-ab86-d935-e1f446c0a0cf")) == null) {
				Columns.Add(CreateMobileHomePageColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitTypeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9fe61fde-536b-4cef-9be7-d44a23ca6dfd"),
				Name = @"SysAdminUnitTypeValue",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fa4483b3-a2db-4651-a462-689be18351e7"),
				Name = @"ParentRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("14f78dc8-e6ef-48a4-b5e1-0fe3360ee7b3"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7d4cc94-ccea-4c6d-a600-0be32fb246e9"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDirectoryEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e51e9d6c-a0ac-4821-8a9d-2eb60a7fb0af"),
				Name = @"IsDirectoryEntry",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("f55f68c3-6fa7-4f18-9fa7-cbd290313d6f"),
				Name = @"TimeZoneId",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUserPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("HashText")) {
				UId = new Guid("ac9e4b9c-ee3c-49de-b850-640e6e5027a6"),
				Name = @"UserPassword",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("48f37442-a2da-4407-9178-72073ba6b09f"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSynchronizeWithLDAPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("45170632-a64e-4639-bdd4-a260e339e3a6"),
				Name = @"SynchronizeWithLDAP",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6bc5084a-56d6-40a1-a796-db979322ee81"),
				Name = @"LDAPEntry",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a059e7cc-2a06-4b03-96ac-473b705515ad"),
				Name = @"LDAPEntryId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryDNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("afee2179-455d-4836-b29f-b2f136918669"),
				Name = @"LDAPEntryDN",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLoggedInColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b0cc6131-e034-4562-9526-3f3a81f0a161"),
				Name = @"LoggedIn",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("939bf64d-89a5-4613-9240-d0abc127dff5"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLoginAttemptCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1a8cff58-add0-4390-b00c-f6f0da971c52"),
				Name = @"LoginAttemptCount",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceControlLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d05ec764-2e70-4238-b972-b5194cd493e7"),
				Name = @"SourceControlLogin",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceControlPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("2bcf9b58-9cd3-48ed-892e-c57dd8c6eede"),
				Name = @"SourceControlPassword",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordExpireDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4d03eb04-195b-43e5-9238-c9864b08b44b"),
				Name = @"PasswordExpireDate",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("37aefb40-6ad6-4c1f-86e0-69ea7c717376")
			};
		}

		protected virtual EntitySchemaColumn CreateHomePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b06d0431-a020-469f-b929-77cb3e6d6170"),
				Name = @"HomePage",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("61e854be-0394-4c7c-b703-cd1ded0aab45"),
				Name = @"ConnectionType",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866")
			};
		}

		protected virtual EntitySchemaColumn CreateUnblockTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b9e2d8e5-55b7-4b81-adb3-19796d751140"),
				Name = @"UnblockTime",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateForceChangePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7e132411-1beb-453b-9ed4-30141fcc0894"),
				Name = @"ForceChangePassword",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("0e850392-6b68-4c42-8cac-7764bc62a6bb")
			};
		}

		protected virtual EntitySchemaColumn CreateDateTimeFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d95527e7-b728-4142-8559-e9af9ee8d22d"),
				Name = @"DateTimeFormat",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("387d653a-7f45-49ea-a9e5-1ab1b4fdb1de")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionTimeoutColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c619e945-1ea9-40ab-af0c-7e6f71f92ce7"),
				Name = @"SessionTimeout",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("083c3536-988b-7e52-29fc-fb146209611f"),
				Name = @"Email",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateOpenIDSubColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("05285753-233b-1ead-c796-b94edb80dd9a"),
				Name = @"OpenIDSub",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("PhoneText")) {
				UId = new Guid("66f943e0-29ef-4bc5-01db-c00b04a5a4cb"),
				Name = @"Phone",
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateWeekFirstDayColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e27b5ec1-6d1b-db21-f883-9fff6231f106"),
				Name = @"WeekFirstDay",
				ReferenceSchemaUId = new Guid("268b91f8-f520-4a48-9864-f2350d841216"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("138395e7-8528-67d3-bf4b-21cb6bd7ffb1"),
				Name = @"NumberFormat",
				ReferenceSchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateMobileHomePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("06c49adf-a2ce-ab86-d935-e1f446c0a0cf"),
				Name = @"MobileHomePage",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				ModifiedInSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysAdminUnitNameIndex());
			Indexes.Add(CreateISAULoggedInActiveIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnit_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnit_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnit_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnit_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_CrtCoreBase_Creatio

	/// <summary>
	/// System administration object.
	/// </summary>
	public class SysAdminUnit_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysAdminUnit_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnit_CrtCoreBase_Creatio";
		}

		public SysAdminUnit_CrtCoreBase_Creatio(SysAdminUnit_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type.
		/// </summary>
		public int SysAdminUnitTypeValue {
			get {
				return GetTypedColumnValue<int>("SysAdminUnitTypeValue");
			}
			set {
				SetColumnValue("SysAdminUnitTypeValue", value);
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

		private SysAdminUnit _parentRole;
		/// <summary>
		/// Inherited from.
		/// </summary>
		public SysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = LookupColumnEntities.GetEntity("ParentRole") as SysAdminUnit);
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

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
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
		/// LDAP element unique name.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Logged in.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
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
		/// Number of logon attempts.
		/// </summary>
		public int LoginAttemptCount {
			get {
				return GetTypedColumnValue<int>("LoginAttemptCount");
			}
			set {
				SetColumnValue("LoginAttemptCount", value);
			}
		}

		/// <summary>
		/// Repository login.
		/// </summary>
		public string SourceControlLogin {
			get {
				return GetTypedColumnValue<string>("SourceControlLogin");
			}
			set {
				SetColumnValue("SourceControlLogin", value);
			}
		}

		/// <summary>
		/// Repository password.
		/// </summary>
		public string SourceControlPassword {
			get {
				return GetTypedColumnValue<string>("SourceControlPassword");
			}
			set {
				SetColumnValue("SourceControlPassword", value);
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

		/// <summary>
		/// Unlocking time.
		/// </summary>
		public DateTime UnblockTime {
			get {
				return GetTypedColumnValue<DateTime>("UnblockTime");
			}
			set {
				SetColumnValue("UnblockTime", value);
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
		/// Display date and time format.
		/// </summary>
		public SysLanguage DateTimeFormat {
			get {
				return _dateTimeFormat ??
					(_dateTimeFormat = LookupColumnEntities.GetEntity("DateTimeFormat") as SysLanguage);
			}
		}

		/// <summary>
		/// Session timeout (minutes).
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
		/// OpenID sub claim.
		/// </summary>
		public string OpenIDSub {
			get {
				return GetTypedColumnValue<string>("OpenIDSub");
			}
			set {
				SetColumnValue("OpenIDSub", value);
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
		public Guid NumberFormatId {
			get {
				return GetTypedColumnValue<Guid>("NumberFormatId");
			}
			set {
				SetColumnValue("NumberFormatId", value);
				_numberFormat = null;
			}
		}

		/// <exclude/>
		public string NumberFormatName {
			get {
				return GetTypedColumnValue<string>("NumberFormatName");
			}
			set {
				SetColumnValue("NumberFormatName", value);
				if (_numberFormat != null) {
					_numberFormat.Name = value;
				}
			}
		}

		private SysNumberFormat _numberFormat;
		/// <summary>
		/// Number format.
		/// </summary>
		public SysNumberFormat NumberFormat {
			get {
				return _numberFormat ??
					(_numberFormat = LookupColumnEntities.GetEntity("NumberFormat") as SysNumberFormat);
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
			var process = new SysAdminUnit_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioSaving", e);
			Updated += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioUpdated", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnit_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnit_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnit_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAdminUnit_CrtCoreBase_Creatio
	{

		public SysAdminUnit_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnit_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_sSPUserTypeId = () => {{ return new Guid("F4044C41-DF2B-E111-851E-00155D04C01D"); }};
			_userTypeId = () => {{ return new Guid("472E97C7-6BD7-DF11-9B2A-001D60E938C6"); }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<Guid> _sSPUserTypeId;
		public virtual Guid SSPUserTypeId {
			get {
				return (_sSPUserTypeId ?? (_sSPUserTypeId = () => Guid.Empty)).Invoke();
			}
			set {
				_sSPUserTypeId = () => { return value; };
			}
		}

		private Func<Guid> _userTypeId;
		public virtual Guid UserTypeId {
			get {
				return (_userTypeId ?? (_userTypeId = () => Guid.Empty)).Invoke();
			}
			set {
				_userTypeId = () => { return value; };
			}
		}

		private ProcessFlowElement _eventSubProcess932740;
		public ProcessFlowElement EventSubProcess932740 {
			get {
				return _eventSubProcess932740 ?? (_eventSubProcess932740 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess932740",
					SchemaElementUId = new Guid("fce84846-b48b-4e67-8252-fe857f8ca425"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitSaved;
		public ProcessFlowElement SysAdminUnitSaved {
			get {
				return _sysAdminUnitSaved ?? (_sysAdminUnitSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitSaved",
					SchemaElementUId = new Guid("20987e1c-f233-4bf9-b989-c2861e102451"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask125763056;
		public ProcessScriptTask ScriptTask125763056 {
			get {
				return _scriptTask125763056 ?? (_scriptTask125763056 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask125763056",
					SchemaElementUId = new Guid("54220b82-3313-4f1d-a03a-0828b66a4111"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask125763056Execute,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitDeleted;
		public ProcessFlowElement SysAdminUnitDeleted {
			get {
				return _sysAdminUnitDeleted ?? (_sysAdminUnitDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitDeleted",
					SchemaElementUId = new Guid("a67398c4-f8ed-4600-a5e3-f39c973e003e"),
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
					SchemaElementUId = new Guid("a2e358c5-d873-40bb-8e2b-bbddbd63ce62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogDelete_ScriptTaskExecute,
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
					SchemaElementUId = new Guid("37a00e18-c28c-4539-9974-010bb7ec07cc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemovePersonalUserSessionTimeoutExecute,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitInserted;
		public ProcessFlowElement SysAdminUnitInserted {
			get {
				return _sysAdminUnitInserted ?? (_sysAdminUnitInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitInserted",
					SchemaElementUId = new Guid("610fd78f-317c-4910-807e-b4ed17f2fc74"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _insertPersonalSessionTimeout;
		public ProcessScriptTask InsertPersonalSessionTimeout {
			get {
				return _insertPersonalSessionTimeout ?? (_insertPersonalSessionTimeout = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InsertPersonalSessionTimeout",
					SchemaElementUId = new Guid("52b031c6-fe86-4e33-bc1b-9a1ea581ffc5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InsertPersonalSessionTimeoutExecute,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitUpdated;
		public ProcessFlowElement SysAdminUnitUpdated {
			get {
				return _sysAdminUnitUpdated ?? (_sysAdminUnitUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitUpdated",
					SchemaElementUId = new Guid("c658b72a-3d51-4237-92d9-912437696368"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updatePersonalSessionTimeout;
		public ProcessScriptTask UpdatePersonalSessionTimeout {
			get {
				return _updatePersonalSessionTimeout ?? (_updatePersonalSessionTimeout = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdatePersonalSessionTimeout",
					SchemaElementUId = new Guid("516b32ab-ef63-46e0-ad20-f2f4a2792a89"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdatePersonalSessionTimeoutExecute,
				});
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
					SchemaElementUId = new Guid("f5e8f47f-14d8-4c2c-8be8-a6107e0d2420"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _validateCanChangeRecord;
		public ProcessScriptTask ValidateCanChangeRecord {
			get {
				return _validateCanChangeRecord ?? (_validateCanChangeRecord = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ValidateCanChangeRecord",
					SchemaElementUId = new Guid("8430682a-7728-492f-a57f-3e855a70de24"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ValidateCanChangeRecordExecute,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitDeleting;
		public ProcessFlowElement SysAdminUnitDeleting {
			get {
				return _sysAdminUnitDeleting ?? (_sysAdminUnitDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitDeleting",
					SchemaElementUId = new Guid("949da708-5e6d-4553-9d7c-7ffea318e55b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitSaving;
		public ProcessFlowElement SysAdminUnitSaving {
			get {
				return _sysAdminUnitSaving ?? (_sysAdminUnitSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitSaving",
					SchemaElementUId = new Guid("f6b52288-d021-4042-ba1d-9fdf2782b2c8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitInserting;
		public ProcessFlowElement SysAdminUnitInserting {
			get {
				return _sysAdminUnitInserting ?? (_sysAdminUnitInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitInserting",
					SchemaElementUId = new Guid("34d62e7b-9c4c-4cac-b0c2-4c5a3dd6325e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess932740.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess932740 };
			FlowElements[SysAdminUnitSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitSaved };
			FlowElements[ScriptTask125763056.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask125763056 };
			FlowElements[SysAdminUnitDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitDeleted };
			FlowElements[LogDelete_ScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogDelete_ScriptTask };
			FlowElements[RemovePersonalUserSessionTimeout.SchemaElementUId] = new Collection<ProcessFlowElement> { RemovePersonalUserSessionTimeout };
			FlowElements[SysAdminUnitInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitInserted };
			FlowElements[InsertPersonalSessionTimeout.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertPersonalSessionTimeout };
			FlowElements[SysAdminUnitUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitUpdated };
			FlowElements[UpdatePersonalSessionTimeout.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdatePersonalSessionTimeout };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ValidateCanChangeRecord.SchemaElementUId] = new Collection<ProcessFlowElement> { ValidateCanChangeRecord };
			FlowElements[SysAdminUnitDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitDeleting };
			FlowElements[SysAdminUnitSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitSaving };
			FlowElements[SysAdminUnitInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitInserting };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess932740":
						break;
					case "SysAdminUnitSaved":
						e.Context.QueueTasks.Enqueue("ScriptTask125763056");
						break;
					case "ScriptTask125763056":
						break;
					case "SysAdminUnitDeleted":
						e.Context.QueueTasks.Enqueue("LogDelete_ScriptTask");
						break;
					case "LogDelete_ScriptTask":
						e.Context.QueueTasks.Enqueue("RemovePersonalUserSessionTimeout");
						break;
					case "RemovePersonalUserSessionTimeout":
						e.Context.QueueTasks.Enqueue("ScriptTask125763056");
						break;
					case "SysAdminUnitInserted":
						e.Context.QueueTasks.Enqueue("InsertPersonalSessionTimeout");
						break;
					case "InsertPersonalSessionTimeout":
						break;
					case "SysAdminUnitUpdated":
						e.Context.QueueTasks.Enqueue("UpdatePersonalSessionTimeout");
						break;
					case "UpdatePersonalSessionTimeout":
						break;
					case "EventSubProcess1":
						break;
					case "ValidateCanChangeRecord":
						break;
					case "SysAdminUnitDeleting":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
					case "SysAdminUnitSaving":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
					case "SysAdminUnitInserting":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysAdminUnitSaved");
			ActivatedEventElements.Add("SysAdminUnitDeleted");
			ActivatedEventElements.Add("SysAdminUnitInserted");
			ActivatedEventElements.Add("SysAdminUnitUpdated");
			ActivatedEventElements.Add("SysAdminUnitDeleting");
			ActivatedEventElements.Add("SysAdminUnitSaving");
			ActivatedEventElements.Add("SysAdminUnitInserting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess932740":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitSaved";
					result = SysAdminUnitSaved.Execute(context);
					break;
				case "ScriptTask125763056":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask125763056";
					result = ScriptTask125763056.Execute(context, ScriptTask125763056Execute);
					break;
				case "SysAdminUnitDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitDeleted";
					result = SysAdminUnitDeleted.Execute(context);
					break;
				case "LogDelete_ScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogDelete_ScriptTask";
					result = LogDelete_ScriptTask.Execute(context, LogDelete_ScriptTaskExecute);
					break;
				case "RemovePersonalUserSessionTimeout":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemovePersonalUserSessionTimeout";
					result = RemovePersonalUserSessionTimeout.Execute(context, RemovePersonalUserSessionTimeoutExecute);
					break;
				case "SysAdminUnitInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitInserted";
					result = SysAdminUnitInserted.Execute(context);
					break;
				case "InsertPersonalSessionTimeout":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertPersonalSessionTimeout";
					result = InsertPersonalSessionTimeout.Execute(context, InsertPersonalSessionTimeoutExecute);
					break;
				case "SysAdminUnitUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitUpdated";
					result = SysAdminUnitUpdated.Execute(context);
					break;
				case "UpdatePersonalSessionTimeout":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdatePersonalSessionTimeout";
					result = UpdatePersonalSessionTimeout.Execute(context, UpdatePersonalSessionTimeoutExecute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ValidateCanChangeRecord":
					context.QueueTasks.Dequeue();
					context.SenderName = "ValidateCanChangeRecord";
					result = ValidateCanChangeRecord.Execute(context, ValidateCanChangeRecordExecute);
					break;
				case "SysAdminUnitDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitDeleting";
					result = SysAdminUnitDeleting.Execute(context);
					break;
				case "SysAdminUnitSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitSaving";
					result = SysAdminUnitSaving.Execute(context);
					break;
				case "SysAdminUnitInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitInserting";
					result = SysAdminUnitInserting.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask125763056Execute(ProcessExecutingContext context) {
			Terrasoft.Web.Http.Abstractions.HttpContext httpContext = Terrasoft.Web.Http.Abstractions.HttpContext.Current;
			if (httpContext == null) {
				return true;
			}
			var contactId = Entity.ContactId;
			if (contactId == Guid.Empty) {
				var key = string.Format("SysAdminUnit_{0}", contactId.ToString());
				RemoveItemFromCache(key);
			}
			return true;
		}

		public virtual bool LogDelete_ScriptTaskExecute(ProcessExecutingContext context) {
			OperationLogger.Instance.LogAdminUnitDelete(UserConnection, Entity.Name);
			return true;
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

		public virtual bool InsertPersonalSessionTimeoutExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO CRM-44388
			if (!GetIsAdminUnitNotUser()) {
				SessionHelper sessionHelper = new SessionHelper();
				sessionHelper.UpdatePersonalUserSessionTimeoutInCache(Entity.Name, Entity.SessionTimeout);
			}
			#endif
			return true;
		}

		public virtual bool UpdatePersonalSessionTimeoutExecute(ProcessExecutingContext context) {
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

		public virtual bool ValidateCanChangeRecordExecute(ProcessExecutingContext context) {
			if (Entity.Id != UserConnection.CurrentUser.Id) {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminUnit_CrtCoreBase_CreatioSaved":
							if (ActivatedEventElements.Contains("SysAdminUnitSaved")) {
							context.QueueTasks.Enqueue("SysAdminUnitSaved");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioDeleted":
							if (ActivatedEventElements.Contains("SysAdminUnitDeleted")) {
							context.QueueTasks.Enqueue("SysAdminUnitDeleted");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioInserted":
							if (ActivatedEventElements.Contains("SysAdminUnitInserted")) {
							context.QueueTasks.Enqueue("SysAdminUnitInserted");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioUpdated":
							if (ActivatedEventElements.Contains("SysAdminUnitUpdated")) {
							context.QueueTasks.Enqueue("SysAdminUnitUpdated");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioDeleting":
							if (ActivatedEventElements.Contains("SysAdminUnitDeleting")) {
							context.QueueTasks.Enqueue("SysAdminUnitDeleting");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioSaving":
							if (ActivatedEventElements.Contains("SysAdminUnitSaving")) {
							context.QueueTasks.Enqueue("SysAdminUnitSaving");
						}
						break;
					case "SysAdminUnit_CrtCoreBase_CreatioInserting":
							if (ActivatedEventElements.Contains("SysAdminUnitInserting")) {
							context.QueueTasks.Enqueue("SysAdminUnitInserting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnit_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysAdminUnit_CrtCoreBaseEventsProcess : SysAdminUnit_CrtCoreBaseEventsProcess<SysAdminUnit_CrtCoreBase_Creatio>
	{

		public SysAdminUnit_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

