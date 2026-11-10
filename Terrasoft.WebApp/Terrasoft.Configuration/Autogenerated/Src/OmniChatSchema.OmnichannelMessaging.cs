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

	#region Class: OmniChat_OmnichannelMessaging_CreatioSchema

	/// <exclude/>
	public class OmniChat_OmnichannelMessaging_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OmniChat_OmnichannelMessaging_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChat_OmnichannelMessaging_CreatioSchema(OmniChat_OmnichannelMessaging_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChat_OmnichannelMessaging_CreatioSchema(OmniChat_OmnichannelMessaging_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_OmniChat_ModifiedOn_DESCIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("7743e95f-27d2-45c1-a986-01ef6e06157d");
			index.Name = "IX_OmniChat_ModifiedOn_DESC";
			index.CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			index.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			index.CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			EntitySchemaIndexColumn modifiedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8b94bc86-9c8f-3b4b-a07d-069c04711bdf"),
				ColumnUId = new Guid("9928edec-4272-425a-93bb-48743fee4b04"),
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(modifiedOnIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_OmniChat_CreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("0a96b90f-b92d-4b84-abef-7abc160b40f5");
			index.Name = "IX_OmniChat_CreatedOn";
			index.CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			index.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			index.CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1a21e225-d777-369e-ab4d-6cba32070fb8"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			RealUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			Name = "OmniChat_OmnichannelMessaging_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateContactColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8be12635-e9dd-4630-ad28-074d9672a4c3")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("43ef8c52-8676-4017-a487-8581d0ea9324")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("f890ff68-8d2b-477e-b0f7-240fab4fd0ad")) == null) {
				Columns.Add(CreateCloseDateColumn());
			}
			if (Columns.FindByUId(new Guid("d55b14b1-cb05-4579-9d83-853531befffe")) == null) {
				Columns.Add(CreateChatPreviewColumn());
			}
			if (Columns.FindByUId(new Guid("af6b40ee-b2ee-41fa-b33d-5c76dce95647")) == null) {
				Columns.Add(CreateConversationColumn());
			}
			if (Columns.FindByUId(new Guid("23bfa443-4d1e-4860-b7fc-dee0383b1ea0")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("fa37d391-2c0c-44b6-ba1c-3a50d64a884f")) == null) {
				Columns.Add(CreateOperatorColumn());
			}
			if (Columns.FindByUId(new Guid("bb0e997b-f55c-45fd-a149-5984673e1adc")) == null) {
				Columns.Add(CreateUnprocessedMsgCountColumn());
			}
			if (Columns.FindByUId(new Guid("cc93e303-6f66-4cdd-983f-8d629403fd48")) == null) {
				Columns.Add(CreateChatStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("901df6c9-420f-4ec1-a174-a8954bd062c7")) == null) {
				Columns.Add(CreateChatEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("944e05ae-5ef0-4167-98e1-882b0b7a7eb9")) == null) {
				Columns.Add(CreateFirstReplyTimeColumn());
			}
			if (Columns.FindByUId(new Guid("f2fe4a2d-10b4-4952-8606-38b15b52fd9f")) == null) {
				Columns.Add(CreateAcceptDateColumn());
			}
			if (Columns.FindByUId(new Guid("d6561ed7-fb7d-4e02-ba1a-c1bd600c2b65")) == null) {
				Columns.Add(CreateDirectedOperatorColumn());
			}
			if (Columns.FindByUId(new Guid("b00e71bf-99b3-4724-bf44-f698c0c6664f")) == null) {
				Columns.Add(CreateChatDurationColumn());
			}
			if (Columns.FindByUId(new Guid("ef2f4850-268a-478b-8471-7694fb959a1a")) == null) {
				Columns.Add(CreateCompletionDateColumn());
			}
			if (Columns.FindByUId(new Guid("d3c3aba2-4968-2a93-a1e7-aa323e526679")) == null) {
				Columns.Add(CreateLastMessageDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("da57acfd-0dc2-2b58-82f8-37c6f5f9c567")) == null) {
				Columns.Add(CreateQueueColumn());
			}
			if (Columns.FindByUId(new Guid("437b29d9-293b-8f8d-0696-28a4869a3f1b")) == null) {
				Columns.Add(CreateNeedsTranslationColumn());
			}
			if (Columns.FindByUId(new Guid("415636cd-39d2-f40a-8add-b92e67a50f71")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
			if (Columns.FindByUId(new Guid("60189c1d-43f8-8a91-ecb7-3275f369f508")) == null) {
				Columns.Add(CreateTranslatedLangColumn());
			}
			if (Columns.FindByUId(new Guid("48b27073-bc5f-6fa1-8c96-0d603fd8c0c3")) == null) {
				Columns.Add(CreateLastMessageDateColumn());
			}
			if (Columns.FindByUId(new Guid("91f0d944-a639-fdf4-b72f-5e022ec254ec")) == null) {
				Columns.Add(CreateSenderIdentityColumn());
			}
			if (Columns.FindByUId(new Guid("03f2230f-2449-4583-ab37-f12dbe8c3696")) == null) {
				Columns.Add(CreateClosureReasonColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("67848ab7-5076-4042-8d04-d453e8594f70"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8be12635-e9dd-4630-ad28-074d9672a4c3"),
				Name = @"Notes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("43ef8c52-8676-4017-a487-8581d0ea9324"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateCloseDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f890ff68-8d2b-477e-b0f7-240fab4fd0ad"),
				Name = @"CloseDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateChatPreviewColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d55b14b1-cb05-4579-9d83-853531befffe"),
				Name = @"ChatPreview",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateConversationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("af6b40ee-b2ee-41fa-b33d-5c76dce95647"),
				Name = @"Conversation",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb75ff5f-90ad-4019-ae63-2b2cf692b178"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("23bfa443-4d1e-4860-b7fc-dee0383b1ea0"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fa37d391-2c0c-44b6-ba1c-3a50d64a884f"),
				Name = @"Operator",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateUnprocessedMsgCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bb0e997b-f55c-45fd-a149-5984673e1adc"),
				Name = @"UnprocessedMsgCount",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateChatStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("cc93e303-6f66-4cdd-983f-8d629403fd48"),
				Name = @"ChatStartDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateChatEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("901df6c9-420f-4ec1-a174-a8954bd062c7"),
				Name = @"ChatEndDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateFirstReplyTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("944e05ae-5ef0-4167-98e1-882b0b7a7eb9"),
				Name = @"FirstReplyTime",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateAcceptDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f2fe4a2d-10b4-4952-8606-38b15b52fd9f"),
				Name = @"AcceptDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("e4f7a9b6-58b1-45d5-9bbc-68954d2de669")
			};
		}

		protected virtual EntitySchemaColumn CreateDirectedOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d6561ed7-fb7d-4e02-ba1a-c1bd600c2b65"),
				Name = @"DirectedOperator",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("e4f7a9b6-58b1-45d5-9bbc-68954d2de669")
			};
		}

		protected virtual EntitySchemaColumn CreateChatDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b00e71bf-99b3-4724-bf44-f698c0c6664f"),
				Name = @"ChatDuration",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateCompletionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ef2f4850-268a-478b-8471-7694fb959a1a"),
				Name = @"CompletionDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("48b8e671-53f7-4eae-6b3f-cca16452276c"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateLastMessageDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d3c3aba2-4968-2a93-a1e7-aa323e526679"),
				Name = @"LastMessageDirection",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("da57acfd-0dc2-2b58-82f8-37c6f5f9c567"),
				Name = @"Queue",
				ReferenceSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedsTranslationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("437b29d9-293b-8f8d-0696-28a4869a3f1b"),
				Name = @"NeedsTranslation",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("415636cd-39d2-f40a-8add-b92e67a50f71"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateTranslatedLangColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("60189c1d-43f8-8a91-ecb7-3275f369f508"),
				Name = @"TranslatedLang",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateLastMessageDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("48b27073-bc5f-6fa1-8c96-0d603fd8c0c3"),
				Name = @"LastMessageDate",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderIdentityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("91f0d944-a639-fdf4-b72f-5e022ec254ec"),
				Name = @"SenderIdentity",
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateClosureReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("03f2230f-2449-4583-ab37-f12dbe8c3696"),
				Name = @"ClosureReason",
				ReferenceSchemaUId = new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				ModifiedInSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_OmniChat_ModifiedOn_DESCIndex());
			Indexes.Add(CreateIX_OmniChat_CreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniChat_OmnichannelMessaging_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChat_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChat_OmnichannelMessaging_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChat_OmnichannelMessaging_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af1f685c-315b-4b44-a957-c5094417a57a"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_OmnichannelMessaging_Creatio

	/// <summary>
	/// Chat.
	/// </summary>
	/// <remarks>
	/// Represents chat conversations between customers and support agents across integrated channels to manage real-time communication and issue resolution.
	/// </remarks>
	public class OmniChat_OmnichannelMessaging_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OmniChat_OmnichannelMessaging_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChat_OmnichannelMessaging_Creatio";
		}

		public OmniChat_OmnichannelMessaging_Creatio(OmniChat_OmnichannelMessaging_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private OmnichannelChatStatus _status;
		/// <summary>
		/// Chat status.
		/// </summary>
		public OmnichannelChatStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as OmnichannelChatStatus);
			}
		}

		/// <summary>
		/// Chat timeout completion date.
		/// </summary>
		public DateTime CloseDate {
			get {
				return GetTypedColumnValue<DateTime>("CloseDate");
			}
			set {
				SetColumnValue("CloseDate", value);
			}
		}

		/// <summary>
		/// Chat preview.
		/// </summary>
		public string ChatPreview {
			get {
				return GetTypedColumnValue<string>("ChatPreview");
			}
			set {
				SetColumnValue("ChatPreview", value);
			}
		}

		/// <summary>
		/// Chat conversation.
		/// </summary>
		public string Conversation {
			get {
				return GetTypedColumnValue<string>("Conversation");
			}
			set {
				SetColumnValue("Conversation", value);
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
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private Channel _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public Channel Channel {
			get {
				return _channel ??
					(_channel = LookupColumnEntities.GetEntity("Channel") as Channel);
			}
		}

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private SysAdminUnit _operator;
		/// <summary>
		/// Operator.
		/// </summary>
		public SysAdminUnit Operator {
			get {
				return _operator ??
					(_operator = LookupColumnEntities.GetEntity("Operator") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Unprocessed messages count.
		/// </summary>
		public int UnprocessedMsgCount {
			get {
				return GetTypedColumnValue<int>("UnprocessedMsgCount");
			}
			set {
				SetColumnValue("UnprocessedMsgCount", value);
			}
		}

		/// <summary>
		/// Chat start date.
		/// </summary>
		public DateTime ChatStartDate {
			get {
				return GetTypedColumnValue<DateTime>("ChatStartDate");
			}
			set {
				SetColumnValue("ChatStartDate", value);
			}
		}

		/// <summary>
		/// Chat last message date.
		/// </summary>
		public DateTime ChatEndDate {
			get {
				return GetTypedColumnValue<DateTime>("ChatEndDate");
			}
			set {
				SetColumnValue("ChatEndDate", value);
			}
		}

		/// <summary>
		/// Chat first reply time, sec.
		/// </summary>
		public int FirstReplyTime {
			get {
				return GetTypedColumnValue<int>("FirstReplyTime");
			}
			set {
				SetColumnValue("FirstReplyTime", value);
			}
		}

		/// <summary>
		/// Accept date.
		/// </summary>
		public DateTime AcceptDate {
			get {
				return GetTypedColumnValue<DateTime>("AcceptDate");
			}
			set {
				SetColumnValue("AcceptDate", value);
			}
		}

		/// <exclude/>
		public Guid DirectedOperatorId {
			get {
				return GetTypedColumnValue<Guid>("DirectedOperatorId");
			}
			set {
				SetColumnValue("DirectedOperatorId", value);
				_directedOperator = null;
			}
		}

		/// <exclude/>
		public string DirectedOperatorName {
			get {
				return GetTypedColumnValue<string>("DirectedOperatorName");
			}
			set {
				SetColumnValue("DirectedOperatorName", value);
				if (_directedOperator != null) {
					_directedOperator.Name = value;
				}
			}
		}

		private SysAdminUnit _directedOperator;
		/// <summary>
		/// The operator who was directed.
		/// </summary>
		public SysAdminUnit DirectedOperator {
			get {
				return _directedOperator ??
					(_directedOperator = LookupColumnEntities.GetEntity("DirectedOperator") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Chat duration, min.
		/// </summary>
		public int ChatDuration {
			get {
				return GetTypedColumnValue<int>("ChatDuration");
			}
			set {
				SetColumnValue("ChatDuration", value);
			}
		}

		/// <summary>
		/// Chat actual completion date.
		/// </summary>
		public DateTime CompletionDate {
			get {
				return GetTypedColumnValue<DateTime>("CompletionDate");
			}
			set {
				SetColumnValue("CompletionDate", value);
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

		private OmniChat _parent;
		/// <summary>
		/// Parent chat.
		/// </summary>
		/// <remarks>
		/// Parent chat for current chat.
		/// </remarks>
		public OmniChat Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as OmniChat);
			}
		}

		/// <summary>
		/// Last message direction.
		/// </summary>
		public int LastMessageDirection {
			get {
				return GetTypedColumnValue<int>("LastMessageDirection");
			}
			set {
				SetColumnValue("LastMessageDirection", value);
			}
		}

		/// <exclude/>
		public Guid QueueId {
			get {
				return GetTypedColumnValue<Guid>("QueueId");
			}
			set {
				SetColumnValue("QueueId", value);
				_queue = null;
			}
		}

		/// <exclude/>
		public string QueueName {
			get {
				return GetTypedColumnValue<string>("QueueName");
			}
			set {
				SetColumnValue("QueueName", value);
				if (_queue != null) {
					_queue.Name = value;
				}
			}
		}

		private ChatQueue _queue;
		/// <summary>
		/// Queue.
		/// </summary>
		/// <remarks>
		/// Queue of the Chat.
		/// </remarks>
		public ChatQueue Queue {
			get {
				return _queue ??
					(_queue = LookupColumnEntities.GetEntity("Queue") as ChatQueue);
			}
		}

		/// <summary>
		/// Needs translation.
		/// </summary>
		/// <remarks>
		/// Indicates whether the chat requires translation.
		/// </remarks>
		public bool NeedsTranslation {
			get {
				return GetTypedColumnValue<bool>("NeedsTranslation");
			}
			set {
				SetColumnValue("NeedsTranslation", value);
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
		/// Language.
		/// </summary>
		/// <remarks>
		/// The language in which the contact from this chat communicates.
		/// </remarks>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		/// <exclude/>
		public Guid TranslatedLangId {
			get {
				return GetTypedColumnValue<Guid>("TranslatedLangId");
			}
			set {
				SetColumnValue("TranslatedLangId", value);
				_translatedLang = null;
			}
		}

		/// <exclude/>
		public string TranslatedLangName {
			get {
				return GetTypedColumnValue<string>("TranslatedLangName");
			}
			set {
				SetColumnValue("TranslatedLangName", value);
				if (_translatedLang != null) {
					_translatedLang.Name = value;
				}
			}
		}

		private SysLanguage _translatedLang;
		/// <summary>
		/// The language the chat is translated into.
		/// </summary>
		/// <remarks>
		/// The language the chat was translated into at that time.
		/// </remarks>
		public SysLanguage TranslatedLang {
			get {
				return _translatedLang ??
					(_translatedLang = LookupColumnEntities.GetEntity("TranslatedLang") as SysLanguage);
			}
		}

		/// <summary>
		/// Last message date.
		/// </summary>
		public DateTime LastMessageDate {
			get {
				return GetTypedColumnValue<DateTime>("LastMessageDate");
			}
			set {
				SetColumnValue("LastMessageDate", value);
			}
		}

		/// <summary>
		/// Sender identity.
		/// </summary>
		/// <remarks>
		/// External sender identifier (e.g. WebChat visitorId) used for anonymous chat matching.
		/// </remarks>
		public string SenderIdentity {
			get {
				return GetTypedColumnValue<string>("SenderIdentity");
			}
			set {
				SetColumnValue("SenderIdentity", value);
			}
		}

		/// <exclude/>
		public Guid ClosureReasonId {
			get {
				return GetTypedColumnValue<Guid>("ClosureReasonId");
			}
			set {
				SetColumnValue("ClosureReasonId", value);
				_closureReason = null;
			}
		}

		/// <exclude/>
		public string ClosureReasonName {
			get {
				return GetTypedColumnValue<string>("ClosureReasonName");
			}
			set {
				SetColumnValue("ClosureReasonName", value);
				if (_closureReason != null) {
					_closureReason.Name = value;
				}
			}
		}

		private ChatClosureReason _closureReason;
		/// <summary>
		/// Closure reason.
		/// </summary>
		public ChatClosureReason ClosureReason {
			get {
				return _closureReason ??
					(_closureReason = LookupColumnEntities.GetEntity("ClosureReason") as ChatClosureReason);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChat_OmnichannelMessagingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Saving += (s, e) => ThrowEvent("OmniChat_OmnichannelMessaging_CreatioSaving", e);
			Updating += (s, e) => ThrowEvent("OmniChat_OmnichannelMessaging_CreatioUpdating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OmniChat_OmnichannelMessaging_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniChat_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OmniChat_OmnichannelMessaging_Creatio
	{

		public OmniChat_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChat_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_948b30ab03564bed9ff55329ebff9d9e;
		public ProcessFlowElement EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e {
			get {
				return _eventSubProcess3_948b30ab03564bed9ff55329ebff9d9e ?? (_eventSubProcess3_948b30ab03564bed9ff55329ebff9d9e = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e",
					SchemaElementUId = new Guid("948b30ab-0356-4bed-9ff5-5329ebff9d9e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_6ca2c3a669f54bd18ba4f15e7af325ed;
		public ProcessFlowElement StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed {
			get {
				return _startMessage3_6ca2c3a669f54bd18ba4f15e7af325ed ?? (_startMessage3_6ca2c3a669f54bd18ba4f15e7af325ed = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed",
					SchemaElementUId = new Guid("6ca2c3a6-69f5-4bd1-8ba4-f15e7af325ed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_d21b80f375ee4b6db204df5859234ed8;
		public ProcessScriptTask ScriptTask3_d21b80f375ee4b6db204df5859234ed8 {
			get {
				return _scriptTask3_d21b80f375ee4b6db204df5859234ed8 ?? (_scriptTask3_d21b80f375ee4b6db204df5859234ed8 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_d21b80f375ee4b6db204df5859234ed8",
					SchemaElementUId = new Guid("d21b80f3-75ee-4b6d-b204-df5859234ed8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_d21b80f375ee4b6db204df5859234ed8Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e };
			FlowElements[StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed };
			FlowElements[ScriptTask3_d21b80f375ee4b6db204df5859234ed8.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_d21b80f375ee4b6db204df5859234ed8 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e":
						break;
					case "StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed":
						e.Context.QueueTasks.Enqueue("ScriptTask3_d21b80f375ee4b6db204df5859234ed8");
						break;
					case "ScriptTask3_d21b80f375ee4b6db204df5859234ed8":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_948b30ab03564bed9ff55329ebff9d9e":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed";
					result = StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed.Execute(context);
					break;
				case "ScriptTask3_d21b80f375ee4b6db204df5859234ed8":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_d21b80f375ee4b6db204df5859234ed8";
					result = ScriptTask3_d21b80f375ee4b6db204df5859234ed8.Execute(context, ScriptTask3_d21b80f375ee4b6db204df5859234ed8Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_d21b80f375ee4b6db204df5859234ed8Execute(ProcessExecutingContext context) {
			CheckAndFillName();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OmniChat_OmnichannelMessaging_CreatioSaving":
							if (ActivatedEventElements.Contains("StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed")) {
							context.QueueTasks.Enqueue("StartMessage3_6ca2c3a669f54bd18ba4f15e7af325ed");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniChat_OmnichannelMessagingEventsProcess : OmniChat_OmnichannelMessagingEventsProcess<OmniChat_OmnichannelMessaging_Creatio>
	{

		public OmniChat_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

