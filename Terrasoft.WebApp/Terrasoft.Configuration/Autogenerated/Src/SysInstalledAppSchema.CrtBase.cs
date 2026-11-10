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
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: SysInstalledAppSchema

	/// <exclude/>
	public class SysInstalledAppSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysInstalledAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledAppSchema(SysInstalledAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledAppSchema(SysInstalledAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSysInstalledApp_CodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("adbee7d0-8b5a-421c-9b2e-2cbc3a14f50e");
			index.Name = "SysInstalledApp_Code";
			index.CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("24b02828-3f5f-41e4-b49b-ac9d9454e18b"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			RealUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			Name = "SysInstalledApp";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5420bb26-d1bc-4732-8c82-372e1e870cdc")) == null) {
				Columns.Add(CreateMaintainerColumn());
			}
			if (Columns.FindByUId(new Guid("aad2b3b4-a300-4468-bca3-ce64c6308a76")) == null) {
				Columns.Add(CreateInstallDateColumn());
			}
			if (Columns.FindByUId(new Guid("934b7730-1761-4b06-9429-dcf70712663c")) == null) {
				Columns.Add(CreateLastUpdateColumn());
			}
			if (Columns.FindByUId(new Guid("9b0af75c-6cb3-4826-9244-ce4f82f760d7")) == null) {
				Columns.Add(CreateMarketplaceLinkColumn());
			}
			if (Columns.FindByUId(new Guid("b4fcdf44-2fd7-4144-a7ac-f0499af1f29c")) == null) {
				Columns.Add(CreateHelpLinkColumn());
			}
			if (Columns.FindByUId(new Guid("9b1eb4c0-e32e-4a5d-8345-a4cd2eb79ea6")) == null) {
				Columns.Add(CreateFileLinkColumn());
			}
			if (Columns.FindByUId(new Guid("95b9bde0-84ef-4a32-93d7-a18b08cb93f9")) == null) {
				Columns.Add(CreateSupportEmailColumn());
			}
			if (Columns.FindByUId(new Guid("2b224027-2933-49e7-b508-3adbeac9f399")) == null) {
				Columns.Add(CreateOrderLinkColumn());
			}
			if (Columns.FindByUId(new Guid("9c9e5d69-f096-4e6c-833c-5296db9d68b4")) == null) {
				Columns.Add(CreateSysInstalledAppStatusColumn());
			}
			if (Columns.FindByUId(new Guid("5f10bf59-890d-51c1-9bd3-63b1c6f1fe52")) == null) {
				Columns.Add(CreateIconBackgroundColumn());
			}
			if (Columns.FindByUId(new Guid("d4bad5e8-9a59-399a-0f1e-1c80ebc4f075")) == null) {
				Columns.Add(CreateSysAppIconColumn());
			}
			if (Columns.FindByUId(new Guid("1f2718fc-2d34-d61e-d542-227e6bca9605")) == null) {
				Columns.Add(CreateIsDeleteDenyColumn());
			}
			if (Columns.FindByUId(new Guid("7cb6351b-6acc-e834-0c7a-88abf422bfd1")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("be0cdfa6-c4f4-aecd-0d55-76b4d410453f")) == null) {
				Columns.Add(CreateNeedUpdateColumn());
			}
			if (Columns.FindByUId(new Guid("d8249844-d703-06e8-f401-3fbde82715e2")) == null) {
				Columns.Add(CreateVersionForUpdateColumn());
			}
			if (Columns.FindByUId(new Guid("ebf523f3-ef86-11c1-9062-533e155fdd78")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("5dd7f89c-0d6c-41ac-9932-9c778e931701")) == null) {
				Columns.Add(CreateMarketplaceAppIdColumn());
			}
			if (Columns.FindByUId(new Guid("2add1918-6c17-ee72-310b-09268428a17b")) == null) {
				Columns.Add(CreateRunParamsColumn());
			}
			if (Columns.FindByUId(new Guid("cf9a68be-abff-380b-708b-442b38faa647")) == null) {
				Columns.Add(CreateRunTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0d8a3206-0f71-fc96-3347-881569f948e3")) == null) {
				Columns.Add(CreateIsHiddenColumn());
			}
			if (Columns.FindByUId(new Guid("3e4ece6d-8ca7-dbcb-a13f-a425646eb323")) == null) {
				Columns.Add(CreateRequiredPlatformVersionColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MediumText");
			column.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMaintainerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5420bb26-d1bc-4732-8c82-372e1e870cdc"),
				Name = @"Maintainer",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("aad2b3b4-a300-4468-bca3-ce64c6308a76"),
				Name = @"InstallDate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateLastUpdateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("934b7730-1761-4b06-9429-dcf70712663c"),
				Name = @"LastUpdate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMarketplaceLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b0af75c-6cb3-4826-9244-ce4f82f760d7"),
				Name = @"MarketplaceLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b4fcdf44-2fd7-4144-a7ac-f0499af1f29c"),
				Name = @"HelpLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateFileLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b1eb4c0-e32e-4a5d-8345-a4cd2eb79ea6"),
				Name = @"FileLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateSupportEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("95b9bde0-84ef-4a32-93d7-a18b08cb93f9"),
				Name = @"SupportEmail",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2b224027-2933-49e7-b508-3adbeac9f399"),
				Name = @"OrderLink",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("1f1bea1e-5005-484f-a57c-44d5e8e89d17")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c9e5d69-f096-4e6c-833c-5296db9d68b4"),
				Name = @"SysInstalledAppStatus",
				ReferenceSchemaUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIconBackgroundColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5f10bf59-890d-51c1-9bd3-63b1c6f1fe52"),
				Name = @"IconBackground",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"#FF4013"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysAppIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d4bad5e8-9a59-399a-0f1e-1c80ebc4f075"),
				Name = @"SysAppIcon",
				ReferenceSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1a1ee397-d500-4dff-9006-98626855b7e9"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeleteDenyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1f2718fc-2d34-d61e-d542-227e6bca9605"),
				Name = @"IsDeleteDeny",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7cb6351b-6acc-e834-0c7a-88abf422bfd1"),
				Name = @"Checksum",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedUpdateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("be0cdfa6-c4f4-aecd-0d55-76b4d410453f"),
				Name = @"NeedUpdate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionForUpdateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d8249844-d703-06e8-f401-3fbde82715e2"),
				Name = @"VersionForUpdate",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ebf523f3-ef86-11c1-9062-533e155fdd78"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1.0.0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMarketplaceAppIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5dd7f89c-0d6c-41ac-9932-9c778e931701"),
				Name = @"MarketplaceAppId",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateRunParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2add1918-6c17-ee72-310b-09268428a17b"),
				Name = @"RunParams",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateRunTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf9a68be-abff-380b-708b-442b38faa647"),
				Name = @"RunType",
				ReferenceSchemaUId = new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateIsHiddenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0d8a3206-0f71-fc96-3347-881569f948e3"),
				Name = @"IsHidden",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRequiredPlatformVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3e4ece6d-8ca7-dbcb-a13f-a425646eb323"),
				Name = @"RequiredPlatformVersion",
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ConfigurationVersion"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSysInstalledApp_CodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysInstalledApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledApp_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp

	/// <summary>
	/// Installed application.
	/// </summary>
	public class SysInstalledApp : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysInstalledApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledApp";
		}

		public SysInstalledApp(SysInstalledApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Maintainer.
		/// </summary>
		public string Maintainer {
			get {
				return GetTypedColumnValue<string>("Maintainer");
			}
			set {
				SetColumnValue("Maintainer", value);
			}
		}

		/// <summary>
		/// Install date.
		/// </summary>
		public DateTime InstallDate {
			get {
				return GetTypedColumnValue<DateTime>("InstallDate");
			}
			set {
				SetColumnValue("InstallDate", value);
			}
		}

		/// <summary>
		/// Date last updated.
		/// </summary>
		public DateTime LastUpdate {
			get {
				return GetTypedColumnValue<DateTime>("LastUpdate");
			}
			set {
				SetColumnValue("LastUpdate", value);
			}
		}

		/// <summary>
		/// Marketplace link.
		/// </summary>
		public string MarketplaceLink {
			get {
				return GetTypedColumnValue<string>("MarketplaceLink");
			}
			set {
				SetColumnValue("MarketplaceLink", value);
			}
		}

		/// <summary>
		/// Help link.
		/// </summary>
		public string HelpLink {
			get {
				return GetTypedColumnValue<string>("HelpLink");
			}
			set {
				SetColumnValue("HelpLink", value);
			}
		}

		/// <summary>
		/// File link.
		/// </summary>
		public string FileLink {
			get {
				return GetTypedColumnValue<string>("FileLink");
			}
			set {
				SetColumnValue("FileLink", value);
			}
		}

		/// <summary>
		/// Support email.
		/// </summary>
		public string SupportEmail {
			get {
				return GetTypedColumnValue<string>("SupportEmail");
			}
			set {
				SetColumnValue("SupportEmail", value);
			}
		}

		/// <summary>
		/// Order link.
		/// </summary>
		public string OrderLink {
			get {
				return GetTypedColumnValue<string>("OrderLink");
			}
			set {
				SetColumnValue("OrderLink", value);
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppStatusId");
			}
			set {
				SetColumnValue("SysInstalledAppStatusId", value);
				_sysInstalledAppStatus = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppStatusName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppStatusName");
			}
			set {
				SetColumnValue("SysInstalledAppStatusName", value);
				if (_sysInstalledAppStatus != null) {
					_sysInstalledAppStatus.Name = value;
				}
			}
		}

		private SysInstalledAppStatus _sysInstalledAppStatus;
		/// <summary>
		/// Application status.
		/// </summary>
		public SysInstalledAppStatus SysInstalledAppStatus {
			get {
				return _sysInstalledAppStatus ??
					(_sysInstalledAppStatus = LookupColumnEntities.GetEntity("SysInstalledAppStatus") as SysInstalledAppStatus);
			}
		}

		/// <summary>
		/// Icon background color.
		/// </summary>
		/// <remarks>
		/// Code of the application icon background color.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		/// <exclude/>
		public Guid SysAppIconId {
			get {
				return GetTypedColumnValue<Guid>("SysAppIconId");
			}
			set {
				SetColumnValue("SysAppIconId", value);
				_sysAppIcon = null;
			}
		}

		/// <exclude/>
		public string SysAppIconName {
			get {
				return GetTypedColumnValue<string>("SysAppIconName");
			}
			set {
				SetColumnValue("SysAppIconName", value);
				if (_sysAppIcon != null) {
					_sysAppIcon.Name = value;
				}
			}
		}

		private SysAppIcons _sysAppIcon;
		/// <summary>
		/// App icon.
		/// </summary>
		public SysAppIcons SysAppIcon {
			get {
				return _sysAppIcon ??
					(_sysAppIcon = LookupColumnEntities.GetEntity("SysAppIcon") as SysAppIcons);
			}
		}

		/// <summary>
		/// Is delete deny.
		/// </summary>
		public bool IsDeleteDeny {
			get {
				return GetTypedColumnValue<bool>("IsDeleteDeny");
			}
			set {
				SetColumnValue("IsDeleteDeny", value);
			}
		}

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Update available.
		/// </summary>
		public bool NeedUpdate {
			get {
				return GetTypedColumnValue<bool>("NeedUpdate");
			}
			set {
				SetColumnValue("NeedUpdate", value);
			}
		}

		/// <summary>
		/// Latest available version.
		/// </summary>
		public string VersionForUpdate {
			get {
				return GetTypedColumnValue<string>("VersionForUpdate");
			}
			set {
				SetColumnValue("VersionForUpdate", value);
			}
		}

		/// <summary>
		/// Current version.
		/// </summary>
		public string Version {
			get {
				return GetTypedColumnValue<string>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Marketplace application ID.
		/// </summary>
		public string MarketplaceAppId {
			get {
				return GetTypedColumnValue<string>("MarketplaceAppId");
			}
			set {
				SetColumnValue("MarketplaceAppId", value);
			}
		}

		/// <summary>
		/// Run parameters.
		/// </summary>
		public string RunParams {
			get {
				return GetTypedColumnValue<string>("RunParams");
			}
			set {
				SetColumnValue("RunParams", value);
			}
		}

		/// <exclude/>
		public Guid RunTypeId {
			get {
				return GetTypedColumnValue<Guid>("RunTypeId");
			}
			set {
				SetColumnValue("RunTypeId", value);
				_runType = null;
			}
		}

		/// <exclude/>
		public string RunTypeName {
			get {
				return GetTypedColumnValue<string>("RunTypeName");
			}
			set {
				SetColumnValue("RunTypeName", value);
				if (_runType != null) {
					_runType.Name = value;
				}
			}
		}

		private SysInstalledAppRunType _runType;
		/// <summary>
		/// Run type.
		/// </summary>
		public SysInstalledAppRunType RunType {
			get {
				return _runType ??
					(_runType = LookupColumnEntities.GetEntity("RunType") as SysInstalledAppRunType);
			}
		}

		/// <summary>
		/// Hidden in the Application Hub.
		/// </summary>
		public bool IsHidden {
			get {
				return GetTypedColumnValue<bool>("IsHidden");
			}
			set {
				SetColumnValue("IsHidden", value);
			}
		}

		/// <summary>
		/// Required platform version.
		/// </summary>
		public string RequiredPlatformVersion {
			get {
				return GetTypedColumnValue<string>("RequiredPlatformVersion");
			}
			set {
				SetColumnValue("RequiredPlatformVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledApp_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysInstalledAppDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInstalledApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledApp_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysInstalledApp
	{

		public SysInstalledApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledApp_CrtBaseEventsProcess";
			SchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp_CrtBaseEventsProcess

	/// <exclude/>
	public class SysInstalledApp_CrtBaseEventsProcess : SysInstalledApp_CrtBaseEventsProcess<SysInstalledApp>
	{

		public SysInstalledApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: SysInstalledAppEventsProcess

	/// <exclude/>
	public class SysInstalledAppEventsProcess : SysInstalledApp_CrtBaseEventsProcess
	{

		public SysInstalledAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

