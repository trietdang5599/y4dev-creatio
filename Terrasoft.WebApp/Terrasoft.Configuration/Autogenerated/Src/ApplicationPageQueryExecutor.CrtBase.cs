namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: ApplicationPageQueryExecutor

	/// <summary>
	/// Query executor for pages of application.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ApplicationPageQueryExecutor")]
	public class ApplicationPageQueryExecutor : BaseApplicationSchemaQueryExecutor<ClientUnitSchema>
	{

		#region Fields: Private

		private static readonly Guid _pageWithTabsTemplateUId = new Guid("05477cbd-1ca8-4658-b427-971fc58bbc08");
		private static readonly Guid _pageWithTabsFreedomTemplateUId = new Guid("3b2e117f-8c6b-4ca5-80a2-7ebb497cddf9");
		private static readonly Guid _pageWithTabsTemplateImageId = new Guid("bb9cbd6d-3b98-4002-a41f-7b70fc9762e5");
		private static readonly Guid _pageWithRightAreaAndTabsTemplateUId = new Guid("98ca84c1-5f6a-4a55-9c3f-d668ce12378c");
		private static readonly Guid _pageWithRightAreaAndTabsFreedomTemplateUId = new Guid("5f8dd430-acf2-4e1a-80c8-77cf57e245ce");
		private static readonly Guid _pageWithRightAreaAndTabsTemplateImageId = new Guid("bdb1be8f-c4e3-41e0-a44b-bd8947a08b7c");
		private static readonly Guid _pageWithTopAreaAndTabsTemplateUId = new Guid("3176536a-77ac-403a-932e-28dd4b50e4e6");
		private static readonly Guid _pageWithTopAreaAndTabsFreedomTemplateUId = new Guid("27e1b215-163a-4b82-b0a6-9872a8dde6e4");
		private static readonly Guid _pageWithTopAreaAndTabsTemplateImageId = new Guid("78b0d4c5-891d-49a3-a364-0afc10f2a93a");
		private static readonly Guid _pageWithLeftAreaTemplateUId = new Guid("0f8eb896-7b62-4dfa-bd55-a414f50932a7");
		private static readonly Guid _pageWithLeftAreaTemplateImageId = new Guid("db72ade9-dd9a-4492-bf4f-415c6e8c4dca");
		private static readonly Guid _pageWithAreaTemplateUId = new Guid("e4b45c7b-cfe3-4ee4-b56b-502f690db0d5");
		private static readonly Guid _pageWithAreaFreedomTemplateUId = new Guid("97e48060-149c-408f-9f17-8ba82c400249");
		private static readonly Guid _pageWithAreaTemplateImageId = new Guid("4839a18f-637a-4189-be5c-85f20a65cfe9");
		private static readonly Guid _pageWithActionDashboardTemplateUId = new Guid("126f25c9-1c1d-43b3-9372-ac1903348ef4");
		private static readonly Guid _pageWithActionDashboardFreedomTemplateUId = new Guid("f3600f35-4e3d-4dd3-882e-3404ab515e38");
		private static readonly Guid _pageWithActionDashboardTemplateImageId = new Guid("4826a502-3cd6-4454-a8bf-4679b7ffde2c");
		private static readonly Guid _baseHomePageUId = new Guid("0c5cfb7a-1ed9-41b8-905e-9a38c6915550");
		private static readonly Guid _baseHomePageImageId = new Guid("318d1004-01dc-4bfa-912d-6cf85f73535b");
		private static readonly Guid _baseSectionTemplateUId = new Guid("9d0fd8cc-431b-455a-beeb-3bb93c64cb38");
		private static readonly Guid _baseSectionTemplateImageId = new Guid("54590275-d5f0-401e-9e33-d2fbbc496100");
		private static readonly Guid _blankPageTemplateUId = new Guid("f691e828-0b36-42a7-898f-c337e9af67d0");
		private static readonly Guid _blankPageTemplateImageId = new Guid("f9813cc3-2843-4819-982b-61c9f9ec1da9");
		private static readonly Guid _listPageV2TemplateUId = new Guid("3334b6c0-c8ab-4b59-a367-0c9182102552");
		private static readonly Guid _listPageV3TemplateUId = new Guid("b7b898d0-8c77-4953-c097-23fa6800da02");
		private static readonly Guid _listPageTemplateImageId = new Guid("54590275-d5f0-401e-9e33-d2fbbc496100");
		private static readonly Guid _baseMiniPageTemplatePageUId = new Guid("ecdcc8ff-272c-4957-9381-7d74ce17e140");
		private static readonly Guid _baseMiniPageTemplateImageId = new Guid("461bc8f5-b353-3632-9c0d-c5f1bae967ac");
		private static readonly Guid _centralAreaDesktopTemplateUId = new Guid("fbc98c89-0691-479c-bc25-59c11ac2365f");
		private static readonly Guid _centralAreaDesktopTemplateImageId = new Guid("e9dab120-5c68-11ee-8c99-0242ac120002");
		private static readonly Guid _pageWithTabsAndProgressBarTemplateUId = new Guid("7ed23be6-71df-4ad3-b56a-caa77b9881ce");
		private static readonly Guid _pageWithTabsAndProgressBarTemplateImageId = new Guid("b61606bf-c802-1e81-ea59-842e9be3f452");
		private static readonly Guid _baseSidebarTemplateUId = new Guid("b11e72c4-3787-407e-9415-9d499413d5b8");
		private static readonly Guid _baseSidebarTemplateImageId = new Guid("f2770b0b-adaf-4e34-89dd-d3abd50e4bbc");
		private static readonly Guid _baseDashboardPageUId = new Guid("eb4d4a67-25d8-fcfa-7851-c4c91efb7b9c");
		private static readonly Guid _baseDashboardPageImageId = new Guid("a3cb156a-20e6-4fb5-b6e5-5e7a48a26278");
		private static readonly Guid _blankMobileTemplateUId = new Guid("478ab83b-527b-4830-b2b8-2206bb9bf283");
		private static readonly Guid _mobileListTemplateUId = new Guid("011e7dda-a763-4535-9b9a-e09eddd047be");
		private static readonly Guid _mobilePageTemplateUId = new Guid("a6a776d7-4415-4726-bf63-a1f19edef6e7");
		private static readonly Guid _mobilePageWithTabsTemplateUId = new Guid("019c694a-1a3b-4812-b2e5-219b326061ae");
		private static readonly Guid _mobileTemplateImageId = new Guid("d09bfa76-b8bd-4266-96df-f634693b9648");
		private static readonly Guid _mobileListTemplateImageId = new Guid("66facfc5-cbca-4106-a7af-956984964db7");
		private static readonly Guid _mobilePageWithTabsTemplateImageId = new Guid("2a89050a-cb76-4ec1-8e58-6c3e2a349cb5");
		private static readonly Guid _mobilePageTemplateImageId = new Guid("7eec4a70-4111-19a9-e353-626c779a41df");
		private static readonly Dictionary<Guid, Guid> _pageImageDictionary = new Dictionary<Guid, Guid> {
			{ _pageWithTabsTemplateUId, _pageWithTabsTemplateImageId },
			{ _pageWithActionDashboardFreedomTemplateUId, _pageWithActionDashboardTemplateImageId },
			{ _pageWithTabsAndProgressBarTemplateUId, _pageWithTabsAndProgressBarTemplateImageId },
			{ _pageWithTabsFreedomTemplateUId, _pageWithTabsTemplateImageId },
			{ _pageWithRightAreaAndTabsTemplateUId, _pageWithRightAreaAndTabsTemplateImageId },
			{ _pageWithRightAreaAndTabsFreedomTemplateUId, _pageWithRightAreaAndTabsTemplateImageId },
			{ _pageWithTopAreaAndTabsTemplateUId, _pageWithTopAreaAndTabsTemplateImageId },
			{ _pageWithTopAreaAndTabsFreedomTemplateUId, _pageWithTopAreaAndTabsTemplateImageId },
			{ _pageWithLeftAreaTemplateUId, _pageWithLeftAreaTemplateImageId },
			{ _pageWithAreaTemplateUId, _pageWithAreaTemplateImageId },
			{ _pageWithAreaFreedomTemplateUId, _pageWithAreaTemplateImageId },
			{ _pageWithActionDashboardTemplateUId, _pageWithActionDashboardTemplateImageId },
			{ _baseHomePageUId, _baseHomePageImageId },
			{ _baseSectionTemplateUId, _baseSectionTemplateImageId },
			{ _blankPageTemplateUId, _blankPageTemplateImageId },
			{ _listPageV2TemplateUId, _listPageTemplateImageId },
			{ _listPageV3TemplateUId, _listPageTemplateImageId },
			{ _baseMiniPageTemplatePageUId, _baseMiniPageTemplateImageId },
			{ _centralAreaDesktopTemplateUId, _centralAreaDesktopTemplateImageId },
			{ _baseSidebarTemplateUId, _baseSidebarTemplateImageId },
			{ _baseDashboardPageUId, _baseDashboardPageImageId },
			{ _blankMobileTemplateUId, _mobileTemplateImageId },
			{ _mobileListTemplateUId, _mobileListTemplateImageId },
			{ _mobilePageTemplateUId, _mobilePageTemplateImageId },
			{ _mobilePageWithTabsTemplateUId, _mobilePageWithTabsTemplateImageId }
		};

		#endregion

		#region Constructors: Public

		public ApplicationPageQueryExecutor(UserConnection userConnection, IAppManager appManager)
			: base(userConnection, appManager) {
		}

		#endregion

		#region Methods: Private

		private void SetImageForEntityItem(IEntity entity, ISchemaManagerItem<ClientUnitSchema> schemaManagerItem) {
			Guid? previewImageId = GetPreviewImageId(schemaManagerItem.UId)
				?? GetPreviewImageIdByParentSchemas(schemaManagerItem);
			SetPreviewImage(entity, previewImageId);
		}

		private Guid? GetPreviewImageIdByParentSchemas(ISchemaManagerItem<ClientUnitSchema> schemaManagerItem) {
			foreach (ISchemaManagerItem<ClientUnitSchema> parentSchemaManagerItem in 
					UserConnection.ClientUnitSchemaManager.GetAllParents(schemaManagerItem)) {
				Guid? imageId = GetPreviewImageId(parentSchemaManagerItem.UId);
				if (imageId.HasValue) {
					return imageId;
				}
			}
			return null;
		}

		private static Guid? GetPreviewImageId(Guid schemaUId) {
			return _pageImageDictionary.TryGetValue(schemaUId, out Guid imageId) ? imageId : (Guid?)null;
		}

		private static void SetPreviewImage(IEntity entity, Guid? previewImageId) {
			if (previewImageId.IsNullOrEmpty()) {
				return;
			}
			entity.SetColumnValue("PreviewImageId", previewImageId);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override string ResultEntitySchemaName => "ApplicationPage";

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override SchemaManager<ClientUnitSchema> GetSchemaManager() => UserConnection.ClientUnitSchemaManager;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override Func<ISchemaManagerItem<ClientUnitSchema>, bool>
				GetManagerItemsFilter(EntitySchemaQueryFilterCollection filters) {
			Func<ISchemaManagerItem<ClientUnitSchema>, bool> baseFilter = base.GetManagerItemsFilter(filters);
			List<ClientUnitSchemaType> schemaTypes = GetRequiredColumnFilterList<ClientUnitSchemaType>(filters, "SchemaType");
			return schemaManagerItem => {
				ExtraProperty property = schemaManagerItem.ExtraProperties.FindByName("SchemaType");
				bool isSameSchemaType;
				if (Features.GetIsEnabled("UseMobilePageDesigner")) {
					isSameSchemaType = schemaTypes.Select(type => (int)type).Contains(Convert.ToInt32(property.Value));
				} else { 
					isSameSchemaType = Convert.ToInt32(property.Value) == (int)schemaTypes[0];
				}
				return isSameSchemaType && baseFilter?.Invoke(schemaManagerItem) != false;
			};
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override void MapAdditionalColumns(Entity entity, ISchemaManagerItem<ClientUnitSchema> schemaManagerItem) {
			SetImageForEntityItem(entity, schemaManagerItem);
		}

		#endregion

	}

	#endregion

}

