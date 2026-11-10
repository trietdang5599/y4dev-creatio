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

	#region Class: BufferedImportEntitySchema

	/// <exclude/>
	public class BufferedImportEntitySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BufferedImportEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BufferedImportEntitySchema(BufferedImportEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BufferedImportEntitySchema(BufferedImportEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			RealUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			Name = "BufferedImportEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6149dc4a-0845-4f34-953b-8d2d6cd2b2bf")) == null) {
				Columns.Add(CreateColumn1Column());
			}
			if (Columns.FindByUId(new Guid("c1caf677-8c20-4d9b-ae1b-d530d80d9dda")) == null) {
				Columns.Add(CreateColumn2Column());
			}
			if (Columns.FindByUId(new Guid("9b306515-52a1-4326-ac81-3e1fcd1259ef")) == null) {
				Columns.Add(CreateColumn3Column());
			}
			if (Columns.FindByUId(new Guid("9c1aeb37-b5e1-4d88-b81e-8a73c987401a")) == null) {
				Columns.Add(CreateColumn4Column());
			}
			if (Columns.FindByUId(new Guid("341a68ab-0028-47a2-b875-d5bd6f1f8e17")) == null) {
				Columns.Add(CreateColumn5Column());
			}
			if (Columns.FindByUId(new Guid("945a5535-76fc-4361-b88f-20fb03a3d076")) == null) {
				Columns.Add(CreateColumn6Column());
			}
			if (Columns.FindByUId(new Guid("97f7ae9f-4612-4b96-a281-d3810e63b017")) == null) {
				Columns.Add(CreateColumn7Column());
			}
			if (Columns.FindByUId(new Guid("81dda907-db24-4528-96b8-50aa77718b4b")) == null) {
				Columns.Add(CreateColumn8Column());
			}
			if (Columns.FindByUId(new Guid("27a24011-3332-4f58-b15d-0c4c66d0e94f")) == null) {
				Columns.Add(CreateColumn9Column());
			}
			if (Columns.FindByUId(new Guid("afeb8b8b-a9ef-43df-8bde-769736564275")) == null) {
				Columns.Add(CreateColumn10Column());
			}
			if (Columns.FindByUId(new Guid("29144d77-05b4-44f1-a831-58fa92c40e96")) == null) {
				Columns.Add(CreateColumn11Column());
			}
			if (Columns.FindByUId(new Guid("f7eb5b8b-fa3a-47d4-a892-48e2833d5f56")) == null) {
				Columns.Add(CreateColumn12Column());
			}
			if (Columns.FindByUId(new Guid("7480ccaa-a86e-431a-872c-04e5783a73ff")) == null) {
				Columns.Add(CreateColumn13Column());
			}
			if (Columns.FindByUId(new Guid("404debdd-63e9-443e-ba68-79f1f9a6f618")) == null) {
				Columns.Add(CreateColumn14Column());
			}
			if (Columns.FindByUId(new Guid("3e840f4e-d535-4de1-aefd-fb27de340351")) == null) {
				Columns.Add(CreateColumn15Column());
			}
			if (Columns.FindByUId(new Guid("ca14eb42-8293-4cd8-bc1f-cca215d4e714")) == null) {
				Columns.Add(CreateColumn16Column());
			}
			if (Columns.FindByUId(new Guid("1109c8f6-71eb-4ba2-9a55-44cd3b771362")) == null) {
				Columns.Add(CreateColumn17Column());
			}
			if (Columns.FindByUId(new Guid("0fe0e83c-065b-4cae-8ab2-84b6ceaad46c")) == null) {
				Columns.Add(CreateColumn18Column());
			}
			if (Columns.FindByUId(new Guid("4677c6f5-e7aa-49e0-8deb-45632210accf")) == null) {
				Columns.Add(CreateColumn19Column());
			}
			if (Columns.FindByUId(new Guid("d736a88e-2dbf-49aa-8396-d294d4fd26f3")) == null) {
				Columns.Add(CreateColumn20Column());
			}
			if (Columns.FindByUId(new Guid("6a9dee03-a868-4587-8354-adbf17016479")) == null) {
				Columns.Add(CreateColumn21Column());
			}
			if (Columns.FindByUId(new Guid("d070955a-9438-437e-94f1-a78a6e0200d7")) == null) {
				Columns.Add(CreateColumn22Column());
			}
			if (Columns.FindByUId(new Guid("6232e346-617d-4789-897b-25855150f4dd")) == null) {
				Columns.Add(CreateColumn23Column());
			}
			if (Columns.FindByUId(new Guid("aa99a304-2fab-46e4-8814-4cb9921a2966")) == null) {
				Columns.Add(CreateColumn24Column());
			}
			if (Columns.FindByUId(new Guid("0af5415a-2122-480d-b539-1f64c63f041d")) == null) {
				Columns.Add(CreateColumn25Column());
			}
			if (Columns.FindByUId(new Guid("61fc2063-f068-49f3-ae52-f4bd3e3eb50d")) == null) {
				Columns.Add(CreateColumn26Column());
			}
			if (Columns.FindByUId(new Guid("2e303ce3-5a20-490c-af5c-14859a174bd0")) == null) {
				Columns.Add(CreateColumn27Column());
			}
			if (Columns.FindByUId(new Guid("88b73402-bb44-4139-ac1e-caa674458c6a")) == null) {
				Columns.Add(CreateColumn28Column());
			}
			if (Columns.FindByUId(new Guid("345f4800-2617-4f3e-b89d-3df86fc8ba7e")) == null) {
				Columns.Add(CreateColumn29Column());
			}
			if (Columns.FindByUId(new Guid("20750bc4-6d0c-4e08-8c63-d5aa7b2d7f60")) == null) {
				Columns.Add(CreateColumn30Column());
			}
			if (Columns.FindByUId(new Guid("3e3d4919-7fb7-46fb-b3cd-d8da39f241ee")) == null) {
				Columns.Add(CreateImportSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("e9305713-9ddc-41f8-a8c7-c8f46de4dcee")) == null) {
				Columns.Add(CreateColumn31Column());
			}
			if (Columns.FindByUId(new Guid("a3fe5bee-395d-4269-9203-558334d3e3bd")) == null) {
				Columns.Add(CreateColumn32Column());
			}
			if (Columns.FindByUId(new Guid("187e2f98-fb20-4ee2-8f84-449c4552c714")) == null) {
				Columns.Add(CreateColumn33Column());
			}
			if (Columns.FindByUId(new Guid("ebb6fb5c-12bb-4831-8bf9-b8de6798692a")) == null) {
				Columns.Add(CreateColumn34Column());
			}
			if (Columns.FindByUId(new Guid("a224199e-5bd1-4e6d-9527-3650d3e7575a")) == null) {
				Columns.Add(CreateColumn35Column());
			}
			if (Columns.FindByUId(new Guid("eebec8ab-58f1-4ee8-b52f-315712a389f9")) == null) {
				Columns.Add(CreateColumn36Column());
			}
			if (Columns.FindByUId(new Guid("c3b22dea-773f-4422-9282-9588b19146ea")) == null) {
				Columns.Add(CreateColumn37Column());
			}
			if (Columns.FindByUId(new Guid("23041f9c-3792-44a4-9e03-52767c40e9c5")) == null) {
				Columns.Add(CreateColumn38Column());
			}
			if (Columns.FindByUId(new Guid("a2f8630f-cfe6-4c3f-bb26-e1b4ac4d31b2")) == null) {
				Columns.Add(CreateColumn39Column());
			}
			if (Columns.FindByUId(new Guid("26ec786c-bee1-4684-8d85-8c646b81b8b2")) == null) {
				Columns.Add(CreateColumn40Column());
			}
			if (Columns.FindByUId(new Guid("7f22b64b-4a32-4941-9fab-549e7f25135e")) == null) {
				Columns.Add(CreateColumn41Column());
			}
			if (Columns.FindByUId(new Guid("a92961e1-2df9-437f-be2b-da3afacbaa5d")) == null) {
				Columns.Add(CreateColumn42Column());
			}
			if (Columns.FindByUId(new Guid("688d76b7-ffad-4ec1-9f06-e9379fe6969f")) == null) {
				Columns.Add(CreateColumn43Column());
			}
			if (Columns.FindByUId(new Guid("5b41ae17-1aae-4984-9c03-df6ae655268e")) == null) {
				Columns.Add(CreateColumn44Column());
			}
			if (Columns.FindByUId(new Guid("e40130a6-74c8-4a39-89d8-b4bb8e0ca78f")) == null) {
				Columns.Add(CreateColumn45Column());
			}
			if (Columns.FindByUId(new Guid("c4bebcc1-df91-4906-9ab7-a496021e530f")) == null) {
				Columns.Add(CreateColumn46Column());
			}
			if (Columns.FindByUId(new Guid("9b88e1ac-6e0e-472d-82d0-91e56c5cb460")) == null) {
				Columns.Add(CreateColumn47Column());
			}
			if (Columns.FindByUId(new Guid("0573c7d3-277f-4886-9b68-e9ada0662661")) == null) {
				Columns.Add(CreateColumn48Column());
			}
			if (Columns.FindByUId(new Guid("176ce0d6-266c-44c6-8e63-3d8dc199dc4c")) == null) {
				Columns.Add(CreateColumn49Column());
			}
			if (Columns.FindByUId(new Guid("d57e2c55-0e2a-4e1a-9a8a-2e007e4d50fb")) == null) {
				Columns.Add(CreateColumn50Column());
			}
			if (Columns.FindByUId(new Guid("e44c9c6b-43d2-401c-9e41-b6dc1ad3d6f9")) == null) {
				Columns.Add(CreateImportExcelRowIndexColumn());
			}
			if (Columns.FindByUId(new Guid("4d395f5b-1472-d300-83c0-6447d510ebe1")) == null) {
				Columns.Add(CreateColumnGuid10Column());
			}
			if (Columns.FindByUId(new Guid("bc43acae-a04b-1e1f-596e-cfcc9010a1d9")) == null) {
				Columns.Add(CreateColumnGuid9Column());
			}
			if (Columns.FindByUId(new Guid("563b5a41-784f-7d85-3ac0-12cfcd45b834")) == null) {
				Columns.Add(CreateColumnGuid8Column());
			}
			if (Columns.FindByUId(new Guid("5dfbd8e5-deea-2aa9-18c2-e0f3da840c44")) == null) {
				Columns.Add(CreateColumnGuid7Column());
			}
			if (Columns.FindByUId(new Guid("f3565fbd-dce9-4952-d9a4-2a05298f7554")) == null) {
				Columns.Add(CreateColumnGuid6Column());
			}
			if (Columns.FindByUId(new Guid("bdbfdc80-041c-2a7c-3eda-45b0a2c8515e")) == null) {
				Columns.Add(CreateColumnGuid5Column());
			}
			if (Columns.FindByUId(new Guid("d0be04da-0edd-06fd-6518-7e65e4a41c85")) == null) {
				Columns.Add(CreateColumnGuid4Column());
			}
			if (Columns.FindByUId(new Guid("3983bfa5-20ff-59e7-2ee5-9bf735e4be32")) == null) {
				Columns.Add(CreateColumnGuid3Column());
			}
			if (Columns.FindByUId(new Guid("86e3477e-cc48-c9bf-e596-370ddef0b746")) == null) {
				Columns.Add(CreateColumnGuid2Column());
			}
			if (Columns.FindByUId(new Guid("95f0ecf5-5455-b5b2-d857-e94529443fd9")) == null) {
				Columns.Add(CreateColumnGuid1Column());
			}
			if (Columns.FindByUId(new Guid("f3348cc0-cffc-6fa7-58b4-cfaeaf6795a0")) == null) {
				Columns.Add(CreateColumnDecimal10Column());
			}
			if (Columns.FindByUId(new Guid("3e153fc5-c413-b45d-d4b9-256ee4ffb010")) == null) {
				Columns.Add(CreateColumnDecimal9Column());
			}
			if (Columns.FindByUId(new Guid("520d0d8d-ec9e-a332-62cc-9ea491e63673")) == null) {
				Columns.Add(CreateColumnDecimal8Column());
			}
			if (Columns.FindByUId(new Guid("49c612c8-8cdc-46c7-9098-22d42fe81500")) == null) {
				Columns.Add(CreateColumnDecimal7Column());
			}
			if (Columns.FindByUId(new Guid("53416118-312a-c408-a06f-ade423ec0949")) == null) {
				Columns.Add(CreateColumnDecimal6Column());
			}
			if (Columns.FindByUId(new Guid("087267a7-20f1-6ebe-4bf9-e0fb247c36a1")) == null) {
				Columns.Add(CreateColumnDecimal5Column());
			}
			if (Columns.FindByUId(new Guid("6fa86301-fa55-a7a1-22b0-8ba722052c22")) == null) {
				Columns.Add(CreateColumnDecimal4Column());
			}
			if (Columns.FindByUId(new Guid("472b9ce6-b994-f96b-8cf9-8bb20b78d6fc")) == null) {
				Columns.Add(CreateColumnDecimal3Column());
			}
			if (Columns.FindByUId(new Guid("e1dd5b44-f6da-4b06-6d45-f4eebbddfb45")) == null) {
				Columns.Add(CreateColumnDecimal2Column());
			}
			if (Columns.FindByUId(new Guid("ddb4c552-8797-1ce9-845e-771579cf74f2")) == null) {
				Columns.Add(CreateColumnDecimal1Column());
			}
			if (Columns.FindByUId(new Guid("f0611f6e-98e6-7441-f2bc-9270517085e0")) == null) {
				Columns.Add(CreateColumnBoolean10Column());
			}
			if (Columns.FindByUId(new Guid("d1349221-45fd-16d5-0edc-e4b5e4e6818e")) == null) {
				Columns.Add(CreateColumnBoolean9Column());
			}
			if (Columns.FindByUId(new Guid("474af652-5810-be8e-c0c1-ef64039c16b1")) == null) {
				Columns.Add(CreateColumnBoolean8Column());
			}
			if (Columns.FindByUId(new Guid("f43b08f2-d936-d7d1-48af-d6a8ffd32ca8")) == null) {
				Columns.Add(CreateColumnBoolean7Column());
			}
			if (Columns.FindByUId(new Guid("691d2467-0723-8aad-e2e9-a9916a8aa34e")) == null) {
				Columns.Add(CreateColumnBoolean6Column());
			}
			if (Columns.FindByUId(new Guid("35055d52-fc01-b749-442b-5332c1b3b21e")) == null) {
				Columns.Add(CreateColumnBoolean5Column());
			}
			if (Columns.FindByUId(new Guid("635afd93-31da-023d-0485-75d87ca3c3f0")) == null) {
				Columns.Add(CreateColumnBoolean4Column());
			}
			if (Columns.FindByUId(new Guid("f60bdc67-e41b-15d1-6478-721c16a2f6fb")) == null) {
				Columns.Add(CreateColumnBoolean3Column());
			}
			if (Columns.FindByUId(new Guid("f80b3ec2-4ce8-f659-1745-7de47dca7645")) == null) {
				Columns.Add(CreateColumnBoolean2Column());
			}
			if (Columns.FindByUId(new Guid("2ea3de05-6847-76b1-1724-31652fe11fd2")) == null) {
				Columns.Add(CreateColumnBoolean1Column());
			}
			if (Columns.FindByUId(new Guid("d412d7f8-4feb-9201-fc04-a182bf84af46")) == null) {
				Columns.Add(CreateColumnInteger10Column());
			}
			if (Columns.FindByUId(new Guid("0fcc9f50-674b-2994-cad1-293e004fe851")) == null) {
				Columns.Add(CreateColumnInteger9Column());
			}
			if (Columns.FindByUId(new Guid("95708b99-8e08-94d7-ef44-e4fa68c22dcb")) == null) {
				Columns.Add(CreateColumnInteger8Column());
			}
			if (Columns.FindByUId(new Guid("53854b52-c93a-c83c-0531-baabdd9d1c1e")) == null) {
				Columns.Add(CreateColumnInteger7Column());
			}
			if (Columns.FindByUId(new Guid("02c17141-f3f9-5525-63cd-63d64777a019")) == null) {
				Columns.Add(CreateColumnInteger6Column());
			}
			if (Columns.FindByUId(new Guid("1514619b-3758-08c5-768f-59d34ef660f8")) == null) {
				Columns.Add(CreateColumnInteger5Column());
			}
			if (Columns.FindByUId(new Guid("cb6238f0-3593-1c8c-cd92-3028da46a973")) == null) {
				Columns.Add(CreateColumnInteger4Column());
			}
			if (Columns.FindByUId(new Guid("2742004a-827b-cb16-ef61-0988d4cf6df7")) == null) {
				Columns.Add(CreateColumnInteger3Column());
			}
			if (Columns.FindByUId(new Guid("3f57234c-f644-ec46-6781-6b87c03685c7")) == null) {
				Columns.Add(CreateColumnInteger2Column());
			}
			if (Columns.FindByUId(new Guid("a5566aec-424b-70e9-806c-1c4bb37c5605")) == null) {
				Columns.Add(CreateColumnInteger1Column());
			}
			if (Columns.FindByUId(new Guid("b10bed74-c507-e9bb-7c74-f831f768ca36")) == null) {
				Columns.Add(CreateColumnTime10Column());
			}
			if (Columns.FindByUId(new Guid("1b1ef311-15ff-180e-cc6a-1200588fe302")) == null) {
				Columns.Add(CreateColumnTime9Column());
			}
			if (Columns.FindByUId(new Guid("43ad6c78-0f19-c9ab-c264-cfb8109122e6")) == null) {
				Columns.Add(CreateColumnTime8Column());
			}
			if (Columns.FindByUId(new Guid("ee40c3e5-1fca-9aa9-7c0f-0a89a6f4c900")) == null) {
				Columns.Add(CreateColumnTime7Column());
			}
			if (Columns.FindByUId(new Guid("e0fdd184-f160-aa78-33a8-4b08c937a14c")) == null) {
				Columns.Add(CreateColumnTime6Column());
			}
			if (Columns.FindByUId(new Guid("2a86a37e-b338-8783-72ee-079e5722c7ee")) == null) {
				Columns.Add(CreateColumnTime5Column());
			}
			if (Columns.FindByUId(new Guid("e4f8e5fb-d976-53fc-dbcc-162e79cd4914")) == null) {
				Columns.Add(CreateColumnTime4Column());
			}
			if (Columns.FindByUId(new Guid("6a089d50-1238-5864-0ed9-8f8b5a27877e")) == null) {
				Columns.Add(CreateColumnTime3Column());
			}
			if (Columns.FindByUId(new Guid("5ce4ffad-ee94-a8de-7bf8-75f656b19afa")) == null) {
				Columns.Add(CreateColumnTime2Column());
			}
			if (Columns.FindByUId(new Guid("85ebcadc-f1bd-c5b3-87b2-bea6e9b3600c")) == null) {
				Columns.Add(CreateColumnTime1Column());
			}
			if (Columns.FindByUId(new Guid("7df1d7bf-58d8-0d66-c6bb-12bb871b3ed6")) == null) {
				Columns.Add(CreateColumnCurrency10Column());
			}
			if (Columns.FindByUId(new Guid("60211434-28ae-8093-b53b-d708074e5734")) == null) {
				Columns.Add(CreateColumnCurrency9Column());
			}
			if (Columns.FindByUId(new Guid("f6512085-52fc-9533-b93a-3a5d51f4247f")) == null) {
				Columns.Add(CreateColumnCurrency8Column());
			}
			if (Columns.FindByUId(new Guid("a4141e05-f3ab-2e89-b147-3b61552854d3")) == null) {
				Columns.Add(CreateColumnCurrency7Column());
			}
			if (Columns.FindByUId(new Guid("148112b6-f3a7-32b1-de3b-4916893c7cb9")) == null) {
				Columns.Add(CreateColumnCurrency6Column());
			}
			if (Columns.FindByUId(new Guid("daf64dd3-e368-0771-f0b7-6afc723d2df7")) == null) {
				Columns.Add(CreateColumnCurrency5Column());
			}
			if (Columns.FindByUId(new Guid("e3b5d125-63d0-2ad5-d92e-a906b3248f38")) == null) {
				Columns.Add(CreateColumnCurrency4Column());
			}
			if (Columns.FindByUId(new Guid("62cea889-b6fc-fbae-3e47-a41888528b99")) == null) {
				Columns.Add(CreateColumnCurrency3Column());
			}
			if (Columns.FindByUId(new Guid("316608f7-6641-9b4b-a7b6-29c044b11201")) == null) {
				Columns.Add(CreateColumnCurrency2Column());
			}
			if (Columns.FindByUId(new Guid("e2e40ead-a8ae-08db-a509-89907ce01d14")) == null) {
				Columns.Add(CreateColumnCurrency1Column());
			}
			if (Columns.FindByUId(new Guid("8b01b071-cfa5-e1e2-9b52-6b431bc4d291")) == null) {
				Columns.Add(CreateColumnDateTime1Column());
			}
			if (Columns.FindByUId(new Guid("b56e469a-6447-9672-0a8d-543155e1bdce")) == null) {
				Columns.Add(CreateColumnDate10Column());
			}
			if (Columns.FindByUId(new Guid("cb6a3333-910f-9593-86eb-533fa2026b31")) == null) {
				Columns.Add(CreateColumnDate9Column());
			}
			if (Columns.FindByUId(new Guid("eaf9dd8f-fc60-4a12-00a3-1a993fded027")) == null) {
				Columns.Add(CreateColumnDate8Column());
			}
			if (Columns.FindByUId(new Guid("ab88b6b9-d876-ff23-e245-9fbc98a01f9f")) == null) {
				Columns.Add(CreateColumnDate7Column());
			}
			if (Columns.FindByUId(new Guid("8e54e491-78b2-b145-f08e-04cdaab337c4")) == null) {
				Columns.Add(CreateColumnDate6Column());
			}
			if (Columns.FindByUId(new Guid("fb73e7c8-5342-d42b-064e-a5dcc05c33bd")) == null) {
				Columns.Add(CreateColumnDate5Column());
			}
			if (Columns.FindByUId(new Guid("b89503c0-be84-0b55-0840-cd9edfb0f81c")) == null) {
				Columns.Add(CreateColumnDate4Column());
			}
			if (Columns.FindByUId(new Guid("2ed00509-1326-82de-6af4-5cc472fa9c1e")) == null) {
				Columns.Add(CreateColumnDate3Column());
			}
			if (Columns.FindByUId(new Guid("684fbae2-73c0-163d-408c-77a025293790")) == null) {
				Columns.Add(CreateColumnDate2Column());
			}
			if (Columns.FindByUId(new Guid("be03dad6-a6c1-fb63-1b84-b641c7220e84")) == null) {
				Columns.Add(CreateColumnDate1Column());
			}
			if (Columns.FindByUId(new Guid("79b0c4b7-7602-49c5-3c6b-679afd5c1f10")) == null) {
				Columns.Add(CreateColumnDateTime10Column());
			}
			if (Columns.FindByUId(new Guid("16d7cb28-b3a6-67fe-c4c7-3cc05ce91724")) == null) {
				Columns.Add(CreateColumnDateTime9Column());
			}
			if (Columns.FindByUId(new Guid("f8a30c95-a0f6-961c-3901-e99af8124582")) == null) {
				Columns.Add(CreateColumnDateTime8Column());
			}
			if (Columns.FindByUId(new Guid("be0c6272-4f72-cd21-8c39-f9d8387589eb")) == null) {
				Columns.Add(CreateColumnDateTime7Column());
			}
			if (Columns.FindByUId(new Guid("e95645a6-1df4-5efc-404c-dab09fa5e7c8")) == null) {
				Columns.Add(CreateColumnDateTime6Column());
			}
			if (Columns.FindByUId(new Guid("5c081a19-1aa3-37fd-7e70-097fc87a894c")) == null) {
				Columns.Add(CreateColumnDateTime5Column());
			}
			if (Columns.FindByUId(new Guid("3f59978e-e1c8-83fc-e60f-77e58749c234")) == null) {
				Columns.Add(CreateColumnDateTime4Column());
			}
			if (Columns.FindByUId(new Guid("ea16b9e6-87b8-ab15-8c51-7c274858ac8c")) == null) {
				Columns.Add(CreateColumnDateTime3Column());
			}
			if (Columns.FindByUId(new Guid("29f35a77-8cbf-365d-f888-7d4f2028dbee")) == null) {
				Columns.Add(CreateColumnDateTime2Column());
			}
		}

		protected virtual EntitySchemaColumn CreateColumn1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6149dc4a-0845-4f34-953b-8d2d6cd2b2bf"),
				Name = @"Column1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c1caf677-8c20-4d9b-ae1b-d530d80d9dda"),
				Name = @"Column2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9b306515-52a1-4326-ac81-3e1fcd1259ef"),
				Name = @"Column3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9c1aeb37-b5e1-4d88-b81e-8a73c987401a"),
				Name = @"Column4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("341a68ab-0028-47a2-b875-d5bd6f1f8e17"),
				Name = @"Column5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("945a5535-76fc-4361-b88f-20fb03a3d076"),
				Name = @"Column6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("97f7ae9f-4612-4b96-a281-d3810e63b017"),
				Name = @"Column7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("81dda907-db24-4528-96b8-50aa77718b4b"),
				Name = @"Column8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("27a24011-3332-4f58-b15d-0c4c66d0e94f"),
				Name = @"Column9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("afeb8b8b-a9ef-43df-8bde-769736564275"),
				Name = @"Column10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn11Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("29144d77-05b4-44f1-a831-58fa92c40e96"),
				Name = @"Column11",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn12Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f7eb5b8b-fa3a-47d4-a892-48e2833d5f56"),
				Name = @"Column12",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn13Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7480ccaa-a86e-431a-872c-04e5783a73ff"),
				Name = @"Column13",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn14Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("404debdd-63e9-443e-ba68-79f1f9a6f618"),
				Name = @"Column14",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn15Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3e840f4e-d535-4de1-aefd-fb27de340351"),
				Name = @"Column15",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn16Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ca14eb42-8293-4cd8-bc1f-cca215d4e714"),
				Name = @"Column16",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn17Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1109c8f6-71eb-4ba2-9a55-44cd3b771362"),
				Name = @"Column17",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn18Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0fe0e83c-065b-4cae-8ab2-84b6ceaad46c"),
				Name = @"Column18",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn19Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4677c6f5-e7aa-49e0-8deb-45632210accf"),
				Name = @"Column19",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn20Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d736a88e-2dbf-49aa-8396-d294d4fd26f3"),
				Name = @"Column20",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn21Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6a9dee03-a868-4587-8354-adbf17016479"),
				Name = @"Column21",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn22Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d070955a-9438-437e-94f1-a78a6e0200d7"),
				Name = @"Column22",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn23Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6232e346-617d-4789-897b-25855150f4dd"),
				Name = @"Column23",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn24Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aa99a304-2fab-46e4-8814-4cb9921a2966"),
				Name = @"Column24",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn25Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0af5415a-2122-480d-b539-1f64c63f041d"),
				Name = @"Column25",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn26Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("61fc2063-f068-49f3-ae52-f4bd3e3eb50d"),
				Name = @"Column26",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn27Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2e303ce3-5a20-490c-af5c-14859a174bd0"),
				Name = @"Column27",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn28Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("88b73402-bb44-4139-ac1e-caa674458c6a"),
				Name = @"Column28",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn29Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("345f4800-2617-4f3e-b89d-3df86fc8ba7e"),
				Name = @"Column29",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn30Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("20750bc4-6d0c-4e08-8c63-d5aa7b2d7f60"),
				Name = @"Column30",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3e3d4919-7fb7-46fb-b3cd-d8da39f241ee"),
				Name = @"ImportSessionId",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn31Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e9305713-9ddc-41f8-a8c7-c8f46de4dcee"),
				Name = @"Column31",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn32Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a3fe5bee-395d-4269-9203-558334d3e3bd"),
				Name = @"Column32",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn33Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("187e2f98-fb20-4ee2-8f84-449c4552c714"),
				Name = @"Column33",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn34Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ebb6fb5c-12bb-4831-8bf9-b8de6798692a"),
				Name = @"Column34",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn35Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a224199e-5bd1-4e6d-9527-3650d3e7575a"),
				Name = @"Column35",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn36Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("eebec8ab-58f1-4ee8-b52f-315712a389f9"),
				Name = @"Column36",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn37Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c3b22dea-773f-4422-9282-9588b19146ea"),
				Name = @"Column37",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn38Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("23041f9c-3792-44a4-9e03-52767c40e9c5"),
				Name = @"Column38",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn39Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a2f8630f-cfe6-4c3f-bb26-e1b4ac4d31b2"),
				Name = @"Column39",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn40Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("26ec786c-bee1-4684-8d85-8c646b81b8b2"),
				Name = @"Column40",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn41Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7f22b64b-4a32-4941-9fab-549e7f25135e"),
				Name = @"Column41",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn42Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a92961e1-2df9-437f-be2b-da3afacbaa5d"),
				Name = @"Column42",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn43Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("688d76b7-ffad-4ec1-9f06-e9379fe6969f"),
				Name = @"Column43",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn44Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5b41ae17-1aae-4984-9c03-df6ae655268e"),
				Name = @"Column44",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn45Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e40130a6-74c8-4a39-89d8-b4bb8e0ca78f"),
				Name = @"Column45",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn46Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c4bebcc1-df91-4906-9ab7-a496021e530f"),
				Name = @"Column46",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn47Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9b88e1ac-6e0e-472d-82d0-91e56c5cb460"),
				Name = @"Column47",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn48Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0573c7d3-277f-4886-9b68-e9ada0662661"),
				Name = @"Column48",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn49Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("176ce0d6-266c-44c6-8e63-3d8dc199dc4c"),
				Name = @"Column49",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn50Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d57e2c55-0e2a-4e1a-9a8a-2e007e4d50fb"),
				Name = @"Column50",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("199dafaa-35e0-4d6d-974d-1232875790d8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportExcelRowIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e44c9c6b-43d2-401c-9e41-b6dc1ad3d6f9"),
				Name = @"ImportExcelRowIndex",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4d395f5b-1472-d300-83c0-6447d510ebe1"),
				Name = @"ColumnGuid10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("bc43acae-a04b-1e1f-596e-cfcc9010a1d9"),
				Name = @"ColumnGuid9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("563b5a41-784f-7d85-3ac0-12cfcd45b834"),
				Name = @"ColumnGuid8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5dfbd8e5-deea-2aa9-18c2-e0f3da840c44"),
				Name = @"ColumnGuid7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f3565fbd-dce9-4952-d9a4-2a05298f7554"),
				Name = @"ColumnGuid6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("bdbfdc80-041c-2a7c-3eda-45b0a2c8515e"),
				Name = @"ColumnGuid5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d0be04da-0edd-06fd-6518-7e65e4a41c85"),
				Name = @"ColumnGuid4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3983bfa5-20ff-59e7-2ee5-9bf735e4be32"),
				Name = @"ColumnGuid3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("86e3477e-cc48-c9bf-e596-370ddef0b746"),
				Name = @"ColumnGuid2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnGuid1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("95f0ecf5-5455-b5b2-d857-e94529443fd9"),
				Name = @"ColumnGuid1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("f3348cc0-cffc-6fa7-58b4-cfaeaf6795a0"),
				Name = @"ColumnDecimal10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("3e153fc5-c413-b45d-d4b9-256ee4ffb010"),
				Name = @"ColumnDecimal9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("520d0d8d-ec9e-a332-62cc-9ea491e63673"),
				Name = @"ColumnDecimal8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("49c612c8-8cdc-46c7-9098-22d42fe81500"),
				Name = @"ColumnDecimal7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("53416118-312a-c408-a06f-ade423ec0949"),
				Name = @"ColumnDecimal6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("087267a7-20f1-6ebe-4bf9-e0fb247c36a1"),
				Name = @"ColumnDecimal5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("6fa86301-fa55-a7a1-22b0-8ba722052c22"),
				Name = @"ColumnDecimal4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("472b9ce6-b994-f96b-8cf9-8bb20b78d6fc"),
				Name = @"ColumnDecimal3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("e1dd5b44-f6da-4b06-6d45-f4eebbddfb45"),
				Name = @"ColumnDecimal2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDecimal1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("ddb4c552-8797-1ce9-845e-771579cf74f2"),
				Name = @"ColumnDecimal1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f0611f6e-98e6-7441-f2bc-9270517085e0"),
				Name = @"ColumnBoolean10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d1349221-45fd-16d5-0edc-e4b5e4e6818e"),
				Name = @"ColumnBoolean9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("474af652-5810-be8e-c0c1-ef64039c16b1"),
				Name = @"ColumnBoolean8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f43b08f2-d936-d7d1-48af-d6a8ffd32ca8"),
				Name = @"ColumnBoolean7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("691d2467-0723-8aad-e2e9-a9916a8aa34e"),
				Name = @"ColumnBoolean6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("35055d52-fc01-b749-442b-5332c1b3b21e"),
				Name = @"ColumnBoolean5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("635afd93-31da-023d-0485-75d87ca3c3f0"),
				Name = @"ColumnBoolean4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f60bdc67-e41b-15d1-6478-721c16a2f6fb"),
				Name = @"ColumnBoolean3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f80b3ec2-4ce8-f659-1745-7de47dca7645"),
				Name = @"ColumnBoolean2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnBoolean1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2ea3de05-6847-76b1-1724-31652fe11fd2"),
				Name = @"ColumnBoolean1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d412d7f8-4feb-9201-fc04-a182bf84af46"),
				Name = @"ColumnInteger10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0fcc9f50-674b-2994-cad1-293e004fe851"),
				Name = @"ColumnInteger9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("95708b99-8e08-94d7-ef44-e4fa68c22dcb"),
				Name = @"ColumnInteger8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("53854b52-c93a-c83c-0531-baabdd9d1c1e"),
				Name = @"ColumnInteger7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("02c17141-f3f9-5525-63cd-63d64777a019"),
				Name = @"ColumnInteger6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1514619b-3758-08c5-768f-59d34ef660f8"),
				Name = @"ColumnInteger5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("cb6238f0-3593-1c8c-cd92-3028da46a973"),
				Name = @"ColumnInteger4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2742004a-827b-cb16-ef61-0988d4cf6df7"),
				Name = @"ColumnInteger3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3f57234c-f644-ec46-6781-6b87c03685c7"),
				Name = @"ColumnInteger2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnInteger1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a5566aec-424b-70e9-806c-1c4bb37c5605"),
				Name = @"ColumnInteger1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("b10bed74-c507-e9bb-7c74-f831f768ca36"),
				Name = @"ColumnTime10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("1b1ef311-15ff-180e-cc6a-1200588fe302"),
				Name = @"ColumnTime9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("43ad6c78-0f19-c9ab-c264-cfb8109122e6"),
				Name = @"ColumnTime8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("ee40c3e5-1fca-9aa9-7c0f-0a89a6f4c900"),
				Name = @"ColumnTime7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("e0fdd184-f160-aa78-33a8-4b08c937a14c"),
				Name = @"ColumnTime6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("2a86a37e-b338-8783-72ee-079e5722c7ee"),
				Name = @"ColumnTime5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("e4f8e5fb-d976-53fc-dbcc-162e79cd4914"),
				Name = @"ColumnTime4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("6a089d50-1238-5864-0ed9-8f8b5a27877e"),
				Name = @"ColumnTime3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("5ce4ffad-ee94-a8de-7bf8-75f656b19afa"),
				Name = @"ColumnTime2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTime1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("85ebcadc-f1bd-c5b3-87b2-bea6e9b3600c"),
				Name = @"ColumnTime1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("7df1d7bf-58d8-0d66-c6bb-12bb871b3ed6"),
				Name = @"ColumnCurrency10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("60211434-28ae-8093-b53b-d708074e5734"),
				Name = @"ColumnCurrency9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("f6512085-52fc-9533-b93a-3a5d51f4247f"),
				Name = @"ColumnCurrency8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("a4141e05-f3ab-2e89-b147-3b61552854d3"),
				Name = @"ColumnCurrency7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("148112b6-f3a7-32b1-de3b-4916893c7cb9"),
				Name = @"ColumnCurrency6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("daf64dd3-e368-0771-f0b7-6afc723d2df7"),
				Name = @"ColumnCurrency5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("e3b5d125-63d0-2ad5-d92e-a906b3248f38"),
				Name = @"ColumnCurrency4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("62cea889-b6fc-fbae-3e47-a41888528b99"),
				Name = @"ColumnCurrency3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("316608f7-6641-9b4b-a7b6-29c044b11201"),
				Name = @"ColumnCurrency2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCurrency1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money3")) {
				UId = new Guid("e2e40ead-a8ae-08db-a509-89907ce01d14"),
				Name = @"ColumnCurrency1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("8b01b071-cfa5-e1e2-9b52-6b431bc4d291"),
				Name = @"ColumnDateTime1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("b56e469a-6447-9672-0a8d-543155e1bdce"),
				Name = @"ColumnDate10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("cb6a3333-910f-9593-86eb-533fa2026b31"),
				Name = @"ColumnDate9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("eaf9dd8f-fc60-4a12-00a3-1a993fded027"),
				Name = @"ColumnDate8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ab88b6b9-d876-ff23-e245-9fbc98a01f9f"),
				Name = @"ColumnDate7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("8e54e491-78b2-b145-f08e-04cdaab337c4"),
				Name = @"ColumnDate6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("fb73e7c8-5342-d42b-064e-a5dcc05c33bd"),
				Name = @"ColumnDate5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("b89503c0-be84-0b55-0840-cd9edfb0f81c"),
				Name = @"ColumnDate4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("2ed00509-1326-82de-6af4-5cc472fa9c1e"),
				Name = @"ColumnDate3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("684fbae2-73c0-163d-408c-77a025293790"),
				Name = @"ColumnDate2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDate1Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("be03dad6-a6c1-fb63-1b84-b641c7220e84"),
				Name = @"ColumnDate1",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime10Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("79b0c4b7-7602-49c5-3c6b-679afd5c1f10"),
				Name = @"ColumnDateTime10",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime9Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("16d7cb28-b3a6-67fe-c4c7-3cc05ce91724"),
				Name = @"ColumnDateTime9",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime8Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f8a30c95-a0f6-961c-3901-e99af8124582"),
				Name = @"ColumnDateTime8",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime7Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("be0c6272-4f72-cd21-8c39-f9d8387589eb"),
				Name = @"ColumnDateTime7",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime6Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e95645a6-1df4-5efc-404c-dab09fa5e7c8"),
				Name = @"ColumnDateTime6",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime5Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5c081a19-1aa3-37fd-7e70-097fc87a894c"),
				Name = @"ColumnDateTime5",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("3f59978e-e1c8-83fc-e60f-77e58749c234"),
				Name = @"ColumnDateTime4",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime3Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ea16b9e6-87b8-ab15-8c51-7c274858ac8c"),
				Name = @"ColumnDateTime3",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDateTime2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("29f35a77-8cbf-365d-f888-7d4f2028dbee"),
				Name = @"ColumnDateTime2",
				CreatedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				ModifiedInSchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BufferedImportEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BufferedImportEntity_CrtFileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BufferedImportEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BufferedImportEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3"));
		}

		#endregion

	}

	#endregion

	#region Class: BufferedImportEntity

	/// <summary>
	/// Buffer data store for file import.
	/// </summary>
	public class BufferedImportEntity : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BufferedImportEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BufferedImportEntity";
		}

		public BufferedImportEntity(BufferedImportEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Column1.
		/// </summary>
		public string Column1 {
			get {
				return GetTypedColumnValue<string>("Column1");
			}
			set {
				SetColumnValue("Column1", value);
			}
		}

		/// <summary>
		/// Column2.
		/// </summary>
		public string Column2 {
			get {
				return GetTypedColumnValue<string>("Column2");
			}
			set {
				SetColumnValue("Column2", value);
			}
		}

		/// <summary>
		/// Column3.
		/// </summary>
		public string Column3 {
			get {
				return GetTypedColumnValue<string>("Column3");
			}
			set {
				SetColumnValue("Column3", value);
			}
		}

		/// <summary>
		/// Column4.
		/// </summary>
		public string Column4 {
			get {
				return GetTypedColumnValue<string>("Column4");
			}
			set {
				SetColumnValue("Column4", value);
			}
		}

		/// <summary>
		/// Column5.
		/// </summary>
		public string Column5 {
			get {
				return GetTypedColumnValue<string>("Column5");
			}
			set {
				SetColumnValue("Column5", value);
			}
		}

		/// <summary>
		/// Column6.
		/// </summary>
		public string Column6 {
			get {
				return GetTypedColumnValue<string>("Column6");
			}
			set {
				SetColumnValue("Column6", value);
			}
		}

		/// <summary>
		/// Column7.
		/// </summary>
		public string Column7 {
			get {
				return GetTypedColumnValue<string>("Column7");
			}
			set {
				SetColumnValue("Column7", value);
			}
		}

		/// <summary>
		/// Column8.
		/// </summary>
		public string Column8 {
			get {
				return GetTypedColumnValue<string>("Column8");
			}
			set {
				SetColumnValue("Column8", value);
			}
		}

		/// <summary>
		/// Column9.
		/// </summary>
		public string Column9 {
			get {
				return GetTypedColumnValue<string>("Column9");
			}
			set {
				SetColumnValue("Column9", value);
			}
		}

		/// <summary>
		/// Column10.
		/// </summary>
		public string Column10 {
			get {
				return GetTypedColumnValue<string>("Column10");
			}
			set {
				SetColumnValue("Column10", value);
			}
		}

		/// <summary>
		/// Column11.
		/// </summary>
		public string Column11 {
			get {
				return GetTypedColumnValue<string>("Column11");
			}
			set {
				SetColumnValue("Column11", value);
			}
		}

		/// <summary>
		/// Column12.
		/// </summary>
		public string Column12 {
			get {
				return GetTypedColumnValue<string>("Column12");
			}
			set {
				SetColumnValue("Column12", value);
			}
		}

		/// <summary>
		/// Column13.
		/// </summary>
		public string Column13 {
			get {
				return GetTypedColumnValue<string>("Column13");
			}
			set {
				SetColumnValue("Column13", value);
			}
		}

		/// <summary>
		/// Column14.
		/// </summary>
		public string Column14 {
			get {
				return GetTypedColumnValue<string>("Column14");
			}
			set {
				SetColumnValue("Column14", value);
			}
		}

		/// <summary>
		/// Column15.
		/// </summary>
		public string Column15 {
			get {
				return GetTypedColumnValue<string>("Column15");
			}
			set {
				SetColumnValue("Column15", value);
			}
		}

		/// <summary>
		/// Column16.
		/// </summary>
		public string Column16 {
			get {
				return GetTypedColumnValue<string>("Column16");
			}
			set {
				SetColumnValue("Column16", value);
			}
		}

		/// <summary>
		/// Column17.
		/// </summary>
		public string Column17 {
			get {
				return GetTypedColumnValue<string>("Column17");
			}
			set {
				SetColumnValue("Column17", value);
			}
		}

		/// <summary>
		/// Column18.
		/// </summary>
		public string Column18 {
			get {
				return GetTypedColumnValue<string>("Column18");
			}
			set {
				SetColumnValue("Column18", value);
			}
		}

		/// <summary>
		/// Column19.
		/// </summary>
		public string Column19 {
			get {
				return GetTypedColumnValue<string>("Column19");
			}
			set {
				SetColumnValue("Column19", value);
			}
		}

		/// <summary>
		/// Column20.
		/// </summary>
		public string Column20 {
			get {
				return GetTypedColumnValue<string>("Column20");
			}
			set {
				SetColumnValue("Column20", value);
			}
		}

		/// <summary>
		/// Column21.
		/// </summary>
		public string Column21 {
			get {
				return GetTypedColumnValue<string>("Column21");
			}
			set {
				SetColumnValue("Column21", value);
			}
		}

		/// <summary>
		/// Column22.
		/// </summary>
		public string Column22 {
			get {
				return GetTypedColumnValue<string>("Column22");
			}
			set {
				SetColumnValue("Column22", value);
			}
		}

		/// <summary>
		/// Column23.
		/// </summary>
		public string Column23 {
			get {
				return GetTypedColumnValue<string>("Column23");
			}
			set {
				SetColumnValue("Column23", value);
			}
		}

		/// <summary>
		/// Column24.
		/// </summary>
		public string Column24 {
			get {
				return GetTypedColumnValue<string>("Column24");
			}
			set {
				SetColumnValue("Column24", value);
			}
		}

		/// <summary>
		/// Column25.
		/// </summary>
		public string Column25 {
			get {
				return GetTypedColumnValue<string>("Column25");
			}
			set {
				SetColumnValue("Column25", value);
			}
		}

		/// <summary>
		/// Column26.
		/// </summary>
		public string Column26 {
			get {
				return GetTypedColumnValue<string>("Column26");
			}
			set {
				SetColumnValue("Column26", value);
			}
		}

		/// <summary>
		/// Column27.
		/// </summary>
		public string Column27 {
			get {
				return GetTypedColumnValue<string>("Column27");
			}
			set {
				SetColumnValue("Column27", value);
			}
		}

		/// <summary>
		/// Column28.
		/// </summary>
		public string Column28 {
			get {
				return GetTypedColumnValue<string>("Column28");
			}
			set {
				SetColumnValue("Column28", value);
			}
		}

		/// <summary>
		/// Column29.
		/// </summary>
		public string Column29 {
			get {
				return GetTypedColumnValue<string>("Column29");
			}
			set {
				SetColumnValue("Column29", value);
			}
		}

		/// <summary>
		/// Column30.
		/// </summary>
		public string Column30 {
			get {
				return GetTypedColumnValue<string>("Column30");
			}
			set {
				SetColumnValue("Column30", value);
			}
		}

		/// <summary>
		/// ImportSessionId.
		/// </summary>
		public Guid ImportSessionId {
			get {
				return GetTypedColumnValue<Guid>("ImportSessionId");
			}
			set {
				SetColumnValue("ImportSessionId", value);
			}
		}

		/// <summary>
		/// Column31.
		/// </summary>
		public string Column31 {
			get {
				return GetTypedColumnValue<string>("Column31");
			}
			set {
				SetColumnValue("Column31", value);
			}
		}

		/// <summary>
		/// Column32.
		/// </summary>
		public string Column32 {
			get {
				return GetTypedColumnValue<string>("Column32");
			}
			set {
				SetColumnValue("Column32", value);
			}
		}

		/// <summary>
		/// Column33.
		/// </summary>
		public string Column33 {
			get {
				return GetTypedColumnValue<string>("Column33");
			}
			set {
				SetColumnValue("Column33", value);
			}
		}

		/// <summary>
		/// Column34.
		/// </summary>
		public string Column34 {
			get {
				return GetTypedColumnValue<string>("Column34");
			}
			set {
				SetColumnValue("Column34", value);
			}
		}

		/// <summary>
		/// Column35.
		/// </summary>
		public string Column35 {
			get {
				return GetTypedColumnValue<string>("Column35");
			}
			set {
				SetColumnValue("Column35", value);
			}
		}

		/// <summary>
		/// Column36.
		/// </summary>
		public string Column36 {
			get {
				return GetTypedColumnValue<string>("Column36");
			}
			set {
				SetColumnValue("Column36", value);
			}
		}

		/// <summary>
		/// Column37.
		/// </summary>
		public string Column37 {
			get {
				return GetTypedColumnValue<string>("Column37");
			}
			set {
				SetColumnValue("Column37", value);
			}
		}

		/// <summary>
		/// Column38.
		/// </summary>
		public string Column38 {
			get {
				return GetTypedColumnValue<string>("Column38");
			}
			set {
				SetColumnValue("Column38", value);
			}
		}

		/// <summary>
		/// Column39.
		/// </summary>
		public string Column39 {
			get {
				return GetTypedColumnValue<string>("Column39");
			}
			set {
				SetColumnValue("Column39", value);
			}
		}

		/// <summary>
		/// Column40.
		/// </summary>
		public string Column40 {
			get {
				return GetTypedColumnValue<string>("Column40");
			}
			set {
				SetColumnValue("Column40", value);
			}
		}

		/// <summary>
		/// Column41.
		/// </summary>
		public string Column41 {
			get {
				return GetTypedColumnValue<string>("Column41");
			}
			set {
				SetColumnValue("Column41", value);
			}
		}

		/// <summary>
		/// Column42.
		/// </summary>
		public string Column42 {
			get {
				return GetTypedColumnValue<string>("Column42");
			}
			set {
				SetColumnValue("Column42", value);
			}
		}

		/// <summary>
		/// Column43.
		/// </summary>
		public string Column43 {
			get {
				return GetTypedColumnValue<string>("Column43");
			}
			set {
				SetColumnValue("Column43", value);
			}
		}

		/// <summary>
		/// Column44.
		/// </summary>
		public string Column44 {
			get {
				return GetTypedColumnValue<string>("Column44");
			}
			set {
				SetColumnValue("Column44", value);
			}
		}

		/// <summary>
		/// Column45.
		/// </summary>
		public string Column45 {
			get {
				return GetTypedColumnValue<string>("Column45");
			}
			set {
				SetColumnValue("Column45", value);
			}
		}

		/// <summary>
		/// Column46.
		/// </summary>
		public string Column46 {
			get {
				return GetTypedColumnValue<string>("Column46");
			}
			set {
				SetColumnValue("Column46", value);
			}
		}

		/// <summary>
		/// Column47.
		/// </summary>
		public string Column47 {
			get {
				return GetTypedColumnValue<string>("Column47");
			}
			set {
				SetColumnValue("Column47", value);
			}
		}

		/// <summary>
		/// Column48.
		/// </summary>
		public string Column48 {
			get {
				return GetTypedColumnValue<string>("Column48");
			}
			set {
				SetColumnValue("Column48", value);
			}
		}

		/// <summary>
		/// Column49.
		/// </summary>
		public string Column49 {
			get {
				return GetTypedColumnValue<string>("Column49");
			}
			set {
				SetColumnValue("Column49", value);
			}
		}

		/// <summary>
		/// Column50.
		/// </summary>
		public string Column50 {
			get {
				return GetTypedColumnValue<string>("Column50");
			}
			set {
				SetColumnValue("Column50", value);
			}
		}

		/// <summary>
		/// ImportExcelRowIndex.
		/// </summary>
		public int ImportExcelRowIndex {
			get {
				return GetTypedColumnValue<int>("ImportExcelRowIndex");
			}
			set {
				SetColumnValue("ImportExcelRowIndex", value);
			}
		}

		/// <summary>
		/// ColumnGuid10.
		/// </summary>
		public Guid ColumnGuid10 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid10");
			}
			set {
				SetColumnValue("ColumnGuid10", value);
			}
		}

		/// <summary>
		/// ColumnGuid9.
		/// </summary>
		public Guid ColumnGuid9 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid9");
			}
			set {
				SetColumnValue("ColumnGuid9", value);
			}
		}

		/// <summary>
		/// ColumnGuid8.
		/// </summary>
		public Guid ColumnGuid8 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid8");
			}
			set {
				SetColumnValue("ColumnGuid8", value);
			}
		}

		/// <summary>
		/// ColumnGuid7.
		/// </summary>
		public Guid ColumnGuid7 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid7");
			}
			set {
				SetColumnValue("ColumnGuid7", value);
			}
		}

		/// <summary>
		/// ColumnGuid6.
		/// </summary>
		public Guid ColumnGuid6 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid6");
			}
			set {
				SetColumnValue("ColumnGuid6", value);
			}
		}

		/// <summary>
		/// ColumnGuid5.
		/// </summary>
		public Guid ColumnGuid5 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid5");
			}
			set {
				SetColumnValue("ColumnGuid5", value);
			}
		}

		/// <summary>
		/// ColumnGuid4.
		/// </summary>
		public Guid ColumnGuid4 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid4");
			}
			set {
				SetColumnValue("ColumnGuid4", value);
			}
		}

		/// <summary>
		/// ColumnGuid3.
		/// </summary>
		public Guid ColumnGuid3 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid3");
			}
			set {
				SetColumnValue("ColumnGuid3", value);
			}
		}

		/// <summary>
		/// ColumnGuid2.
		/// </summary>
		public Guid ColumnGuid2 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid2");
			}
			set {
				SetColumnValue("ColumnGuid2", value);
			}
		}

		/// <summary>
		/// ColumnGuid1.
		/// </summary>
		public Guid ColumnGuid1 {
			get {
				return GetTypedColumnValue<Guid>("ColumnGuid1");
			}
			set {
				SetColumnValue("ColumnGuid1", value);
			}
		}

		/// <summary>
		/// ColumnDecimal10.
		/// </summary>
		public Decimal ColumnDecimal10 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal10");
			}
			set {
				SetColumnValue("ColumnDecimal10", value);
			}
		}

		/// <summary>
		/// ColumnDecimal9.
		/// </summary>
		public Decimal ColumnDecimal9 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal9");
			}
			set {
				SetColumnValue("ColumnDecimal9", value);
			}
		}

		/// <summary>
		/// ColumnDecimal8.
		/// </summary>
		public Decimal ColumnDecimal8 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal8");
			}
			set {
				SetColumnValue("ColumnDecimal8", value);
			}
		}

		/// <summary>
		/// ColumnDecimal7.
		/// </summary>
		public Decimal ColumnDecimal7 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal7");
			}
			set {
				SetColumnValue("ColumnDecimal7", value);
			}
		}

		/// <summary>
		/// ColumnDecimal6.
		/// </summary>
		public Decimal ColumnDecimal6 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal6");
			}
			set {
				SetColumnValue("ColumnDecimal6", value);
			}
		}

		/// <summary>
		/// ColumnDecimal5.
		/// </summary>
		public Decimal ColumnDecimal5 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal5");
			}
			set {
				SetColumnValue("ColumnDecimal5", value);
			}
		}

		/// <summary>
		/// ColumnDecimal4.
		/// </summary>
		public Decimal ColumnDecimal4 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal4");
			}
			set {
				SetColumnValue("ColumnDecimal4", value);
			}
		}

		/// <summary>
		/// ColumnDecimal3.
		/// </summary>
		public Decimal ColumnDecimal3 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal3");
			}
			set {
				SetColumnValue("ColumnDecimal3", value);
			}
		}

		/// <summary>
		/// ColumnDecimal2.
		/// </summary>
		public Decimal ColumnDecimal2 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal2");
			}
			set {
				SetColumnValue("ColumnDecimal2", value);
			}
		}

		/// <summary>
		/// ColumnDecimal1.
		/// </summary>
		public Decimal ColumnDecimal1 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnDecimal1");
			}
			set {
				SetColumnValue("ColumnDecimal1", value);
			}
		}

		/// <summary>
		/// ColumnBoolean10.
		/// </summary>
		public bool ColumnBoolean10 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean10");
			}
			set {
				SetColumnValue("ColumnBoolean10", value);
			}
		}

		/// <summary>
		/// ColumnBoolean9.
		/// </summary>
		public bool ColumnBoolean9 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean9");
			}
			set {
				SetColumnValue("ColumnBoolean9", value);
			}
		}

		/// <summary>
		/// ColumnBoolean8.
		/// </summary>
		public bool ColumnBoolean8 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean8");
			}
			set {
				SetColumnValue("ColumnBoolean8", value);
			}
		}

		/// <summary>
		/// ColumnBoolean7.
		/// </summary>
		public bool ColumnBoolean7 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean7");
			}
			set {
				SetColumnValue("ColumnBoolean7", value);
			}
		}

		/// <summary>
		/// ColumnBoolean6.
		/// </summary>
		public bool ColumnBoolean6 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean6");
			}
			set {
				SetColumnValue("ColumnBoolean6", value);
			}
		}

		/// <summary>
		/// ColumnBoolean5.
		/// </summary>
		public bool ColumnBoolean5 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean5");
			}
			set {
				SetColumnValue("ColumnBoolean5", value);
			}
		}

		/// <summary>
		/// ColumnBoolean4.
		/// </summary>
		public bool ColumnBoolean4 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean4");
			}
			set {
				SetColumnValue("ColumnBoolean4", value);
			}
		}

		/// <summary>
		/// ColumnBoolean3.
		/// </summary>
		public bool ColumnBoolean3 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean3");
			}
			set {
				SetColumnValue("ColumnBoolean3", value);
			}
		}

		/// <summary>
		/// ColumnBoolean2.
		/// </summary>
		public bool ColumnBoolean2 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean2");
			}
			set {
				SetColumnValue("ColumnBoolean2", value);
			}
		}

		/// <summary>
		/// ColumnBoolean1.
		/// </summary>
		public bool ColumnBoolean1 {
			get {
				return GetTypedColumnValue<bool>("ColumnBoolean1");
			}
			set {
				SetColumnValue("ColumnBoolean1", value);
			}
		}

		/// <summary>
		/// ColumnInteger10.
		/// </summary>
		public int ColumnInteger10 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger10");
			}
			set {
				SetColumnValue("ColumnInteger10", value);
			}
		}

		/// <summary>
		/// ColumnInteger9.
		/// </summary>
		public int ColumnInteger9 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger9");
			}
			set {
				SetColumnValue("ColumnInteger9", value);
			}
		}

		/// <summary>
		/// ColumnInteger8.
		/// </summary>
		public int ColumnInteger8 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger8");
			}
			set {
				SetColumnValue("ColumnInteger8", value);
			}
		}

		/// <summary>
		/// ColumnInteger7.
		/// </summary>
		public int ColumnInteger7 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger7");
			}
			set {
				SetColumnValue("ColumnInteger7", value);
			}
		}

		/// <summary>
		/// ColumnInteger6.
		/// </summary>
		public int ColumnInteger6 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger6");
			}
			set {
				SetColumnValue("ColumnInteger6", value);
			}
		}

		/// <summary>
		/// ColumnInteger5.
		/// </summary>
		public int ColumnInteger5 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger5");
			}
			set {
				SetColumnValue("ColumnInteger5", value);
			}
		}

		/// <summary>
		/// ColumnInteger4.
		/// </summary>
		public int ColumnInteger4 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger4");
			}
			set {
				SetColumnValue("ColumnInteger4", value);
			}
		}

		/// <summary>
		/// ColumnInteger3.
		/// </summary>
		public int ColumnInteger3 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger3");
			}
			set {
				SetColumnValue("ColumnInteger3", value);
			}
		}

		/// <summary>
		/// ColumnInteger2.
		/// </summary>
		public int ColumnInteger2 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger2");
			}
			set {
				SetColumnValue("ColumnInteger2", value);
			}
		}

		/// <summary>
		/// ColumnInteger1.
		/// </summary>
		public int ColumnInteger1 {
			get {
				return GetTypedColumnValue<int>("ColumnInteger1");
			}
			set {
				SetColumnValue("ColumnInteger1", value);
			}
		}

		/// <summary>
		/// ColumnTime10.
		/// </summary>
		public DateTime ColumnTime10 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime10");
			}
			set {
				SetColumnValue("ColumnTime10", value);
			}
		}

		/// <summary>
		/// ColumnTime9.
		/// </summary>
		public DateTime ColumnTime9 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime9");
			}
			set {
				SetColumnValue("ColumnTime9", value);
			}
		}

		/// <summary>
		/// ColumnTime8.
		/// </summary>
		public DateTime ColumnTime8 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime8");
			}
			set {
				SetColumnValue("ColumnTime8", value);
			}
		}

		/// <summary>
		/// ColumnTime7.
		/// </summary>
		public DateTime ColumnTime7 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime7");
			}
			set {
				SetColumnValue("ColumnTime7", value);
			}
		}

		/// <summary>
		/// ColumnTime6.
		/// </summary>
		public DateTime ColumnTime6 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime6");
			}
			set {
				SetColumnValue("ColumnTime6", value);
			}
		}

		/// <summary>
		/// ColumnTime5.
		/// </summary>
		public DateTime ColumnTime5 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime5");
			}
			set {
				SetColumnValue("ColumnTime5", value);
			}
		}

		/// <summary>
		/// ColumnTime4.
		/// </summary>
		public DateTime ColumnTime4 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime4");
			}
			set {
				SetColumnValue("ColumnTime4", value);
			}
		}

		/// <summary>
		/// ColumnTime3.
		/// </summary>
		public DateTime ColumnTime3 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime3");
			}
			set {
				SetColumnValue("ColumnTime3", value);
			}
		}

		/// <summary>
		/// ColumnTime2.
		/// </summary>
		public DateTime ColumnTime2 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime2");
			}
			set {
				SetColumnValue("ColumnTime2", value);
			}
		}

		/// <summary>
		/// ColumnTime1.
		/// </summary>
		public DateTime ColumnTime1 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnTime1");
			}
			set {
				SetColumnValue("ColumnTime1", value);
			}
		}

		/// <summary>
		/// ColumnCurrency10.
		/// </summary>
		public Decimal ColumnCurrency10 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency10");
			}
			set {
				SetColumnValue("ColumnCurrency10", value);
			}
		}

		/// <summary>
		/// ColumnCurrency9.
		/// </summary>
		public Decimal ColumnCurrency9 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency9");
			}
			set {
				SetColumnValue("ColumnCurrency9", value);
			}
		}

		/// <summary>
		/// ColumnCurrency8.
		/// </summary>
		public Decimal ColumnCurrency8 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency8");
			}
			set {
				SetColumnValue("ColumnCurrency8", value);
			}
		}

		/// <summary>
		/// ColumnCurrency7.
		/// </summary>
		public Decimal ColumnCurrency7 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency7");
			}
			set {
				SetColumnValue("ColumnCurrency7", value);
			}
		}

		/// <summary>
		/// ColumnCurrency6.
		/// </summary>
		public Decimal ColumnCurrency6 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency6");
			}
			set {
				SetColumnValue("ColumnCurrency6", value);
			}
		}

		/// <summary>
		/// ColumnCurrency5.
		/// </summary>
		public Decimal ColumnCurrency5 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency5");
			}
			set {
				SetColumnValue("ColumnCurrency5", value);
			}
		}

		/// <summary>
		/// ColumnCurrency4.
		/// </summary>
		public Decimal ColumnCurrency4 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency4");
			}
			set {
				SetColumnValue("ColumnCurrency4", value);
			}
		}

		/// <summary>
		/// ColumnCurrency3.
		/// </summary>
		public Decimal ColumnCurrency3 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency3");
			}
			set {
				SetColumnValue("ColumnCurrency3", value);
			}
		}

		/// <summary>
		/// ColumnCurrency2.
		/// </summary>
		public Decimal ColumnCurrency2 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency2");
			}
			set {
				SetColumnValue("ColumnCurrency2", value);
			}
		}

		/// <summary>
		/// ColumnCurrency1.
		/// </summary>
		public Decimal ColumnCurrency1 {
			get {
				return GetTypedColumnValue<Decimal>("ColumnCurrency1");
			}
			set {
				SetColumnValue("ColumnCurrency1", value);
			}
		}

		/// <summary>
		/// ColumnDateTime1.
		/// </summary>
		public DateTime ColumnDateTime1 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime1");
			}
			set {
				SetColumnValue("ColumnDateTime1", value);
			}
		}

		/// <summary>
		/// ColumnDate10.
		/// </summary>
		public DateTime ColumnDate10 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate10");
			}
			set {
				SetColumnValue("ColumnDate10", value);
			}
		}

		/// <summary>
		/// ColumnDate9.
		/// </summary>
		public DateTime ColumnDate9 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate9");
			}
			set {
				SetColumnValue("ColumnDate9", value);
			}
		}

		/// <summary>
		/// ColumnDate8.
		/// </summary>
		public DateTime ColumnDate8 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate8");
			}
			set {
				SetColumnValue("ColumnDate8", value);
			}
		}

		/// <summary>
		/// ColumnDate7.
		/// </summary>
		public DateTime ColumnDate7 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate7");
			}
			set {
				SetColumnValue("ColumnDate7", value);
			}
		}

		/// <summary>
		/// ColumnDate6.
		/// </summary>
		public DateTime ColumnDate6 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate6");
			}
			set {
				SetColumnValue("ColumnDate6", value);
			}
		}

		/// <summary>
		/// ColumnDate5.
		/// </summary>
		public DateTime ColumnDate5 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate5");
			}
			set {
				SetColumnValue("ColumnDate5", value);
			}
		}

		/// <summary>
		/// ColumnDate4.
		/// </summary>
		public DateTime ColumnDate4 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate4");
			}
			set {
				SetColumnValue("ColumnDate4", value);
			}
		}

		/// <summary>
		/// ColumnDate3.
		/// </summary>
		public DateTime ColumnDate3 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate3");
			}
			set {
				SetColumnValue("ColumnDate3", value);
			}
		}

		/// <summary>
		/// ColumnDate2.
		/// </summary>
		public DateTime ColumnDate2 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate2");
			}
			set {
				SetColumnValue("ColumnDate2", value);
			}
		}

		/// <summary>
		/// ColumnDate1.
		/// </summary>
		public DateTime ColumnDate1 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDate1");
			}
			set {
				SetColumnValue("ColumnDate1", value);
			}
		}

		/// <summary>
		/// ColumnDateTime10.
		/// </summary>
		public DateTime ColumnDateTime10 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime10");
			}
			set {
				SetColumnValue("ColumnDateTime10", value);
			}
		}

		/// <summary>
		/// ColumnDateTime9.
		/// </summary>
		public DateTime ColumnDateTime9 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime9");
			}
			set {
				SetColumnValue("ColumnDateTime9", value);
			}
		}

		/// <summary>
		/// ColumnDateTime8.
		/// </summary>
		public DateTime ColumnDateTime8 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime8");
			}
			set {
				SetColumnValue("ColumnDateTime8", value);
			}
		}

		/// <summary>
		/// ColumnDateTime7.
		/// </summary>
		public DateTime ColumnDateTime7 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime7");
			}
			set {
				SetColumnValue("ColumnDateTime7", value);
			}
		}

		/// <summary>
		/// ColumnDateTime6.
		/// </summary>
		public DateTime ColumnDateTime6 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime6");
			}
			set {
				SetColumnValue("ColumnDateTime6", value);
			}
		}

		/// <summary>
		/// ColumnDateTime5.
		/// </summary>
		public DateTime ColumnDateTime5 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime5");
			}
			set {
				SetColumnValue("ColumnDateTime5", value);
			}
		}

		/// <summary>
		/// ColumnDateTime4.
		/// </summary>
		public DateTime ColumnDateTime4 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime4");
			}
			set {
				SetColumnValue("ColumnDateTime4", value);
			}
		}

		/// <summary>
		/// ColumnDateTime3.
		/// </summary>
		public DateTime ColumnDateTime3 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime3");
			}
			set {
				SetColumnValue("ColumnDateTime3", value);
			}
		}

		/// <summary>
		/// ColumnDateTime2.
		/// </summary>
		public DateTime ColumnDateTime2 {
			get {
				return GetTypedColumnValue<DateTime>("ColumnDateTime2");
			}
			set {
				SetColumnValue("ColumnDateTime2", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BufferedImportEntity_CrtFileImportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BufferedImportEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: BufferedImportEntity_CrtFileImportEventsProcess

	/// <exclude/>
	public partial class BufferedImportEntity_CrtFileImportEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : BufferedImportEntity
	{

		public BufferedImportEntity_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BufferedImportEntity_CrtFileImportEventsProcess";
			SchemaUId = new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f1f7cd2-97ec-4b87-913d-c9b2fc6561f3");
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

	#region Class: BufferedImportEntity_CrtFileImportEventsProcess

	/// <exclude/>
	public class BufferedImportEntity_CrtFileImportEventsProcess : BufferedImportEntity_CrtFileImportEventsProcess<BufferedImportEntity>
	{

		public BufferedImportEntity_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BufferedImportEntity_CrtFileImportEventsProcess

	public partial class BufferedImportEntity_CrtFileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BufferedImportEntityEventsProcess

	/// <exclude/>
	public class BufferedImportEntityEventsProcess : BufferedImportEntity_CrtFileImportEventsProcess
	{

		public BufferedImportEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

