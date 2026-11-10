namespace Terrasoft.Configuration.Tagging
{
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ITaggingManager

	/// <summary>
	/// Interface of tagging manager.
	/// </summary>
	public interface ITaggingManager : IRelatedRecordsManager
	{ }

	#endregion

	#region Class: TaggingManager

	/// <summary>
	/// Tagging manager.
	/// </summary>
	[DefaultBinding(typeof(ITaggingManager), Name = "TaggingManager")]
	public class TaggingManager : RelatedRecordsManager, ITaggingManager
	{
		#region Fields: Private

		private ITagRightsHelper _tagRightsHelper;
		private ITagUtils _tagUtils;

		#endregion

		#region Properties: Private

		private ITagRightsHelper TagRightsHelper =>
			_tagRightsHelper ??
			(_tagRightsHelper =
				ClassFactory.Get<ITagRightsHelper>(new ConstructorArgument("userConnection", UserConnection)));
		private ITagUtils TagUtils => _tagUtils ?? (_tagUtils = ClassFactory.Get<ITagUtils>());

		#endregion

		#region Constructors: Public

		public TaggingManager(UserConnection userConnection, IRelatedRecordsProvider relatedRecordsProvider)
			: base(userConnection, relatedRecordsProvider) { }

		#endregion

		#region Methods: Private

		private void AddAllowedTagFilter(EntitySchemaQuery tagsSchemaQuery) {
			var allowedTagAccesses = TagRightsHelper.GetTaggingTagAccessesForUser(UserConnection.CurrentUser.Id);
			var tagFilter = new EntitySchemaQueryFilterCollection(tagsSchemaQuery, LogicalOperationStrict.Or);
			tagFilter.Add(tagsSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "TagAccess",
				allowedTagAccesses.Cast<object>()));
			tagFilter.Add(tagsSchemaQuery.CreateNotExistsFilter("[TagAccessGrantee:TagAccess:TagAccess].Id"));
			tagsSchemaQuery.Filters.Add(tagFilter);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override EntitySchemaQuery GetMainRecordsEntitySchemaQuery(RelatedRecordsManagerData managerData) {
			var tagsSchemaQuery = base.GetMainRecordsEntitySchemaQuery(managerData);
			if (!TagUtils.IsOldStructure(managerData.RelatedInMainRecordsSchemaName)) {
				AddAllowedTagFilter(tagsSchemaQuery);
			}
			return tagsSchemaQuery;
		}

		/// <inheritdoc />
		protected override void SetDefaultValuesToAddRelatedRecordsProviderData(
			AddRelatedRecordsProviderData providerData, RelatedRecordsManagerData managerData) {
			base.SetDefaultValuesToAddRelatedRecordsProviderData(providerData, managerData);
			if (!TagUtils.IsOldStructure(managerData.RelatedInMainRecordsSchemaName) &&
				!providerData.DefaultValues.ContainsKey("RecordSchemaName")) {
				providerData.DefaultValues.Add(new KeyValuePair<string, string>("RecordSchemaName",
					providerData.RelatedRecordsSchemaQuery.RootSchema.Name));
			}
		}

		#endregion

	}

	#endregion

}

