namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: TemplateHintService

	/// <summary>
	/// Service for getting hint during template choosing.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class TemplateHintService : BaseService
	{
		#region Class:TemplateHintServiceResponse

		/// <summary>
		/// Represents template hint response.
		/// </summary>
		[DataContract]
		public class TemplateHintServiceResponse : ConfigurationServiceResponse
		{
			[DataMember]
			public List<TemplateHint> TemplateHints {
				get; set;
			}

			[DataMember]
			public List<TemplateHintGroup> TemplateGroups {
				get; set;
			}
		}

		#endregion

		#region Class: TemplateHintGroup

		/// <summary>
		/// Represents a group of template hints.
		/// </summary>
		[DataContract]
		public class TemplateHintGroup
		{
			[DataMember(Name = "groupName")]
			public string GroupName { get; set; }

			[DataMember(Name = "templates")]
			public List<TemplateHint> Templates { get; set; }
		}

		#endregion

		#region Class: TemplateHint

		/// <summary>
		/// Represents template hint data.
		/// </summary>
		[DataContract]
		public class TemplateHint
		{
			[DataMember(Name = "id")]
			public Guid Id {
				get; set;
			}
			[DataMember(Name = "name")]
			public string Name {
				get; set;
			}
			[DataMember(Name = "text")]
			public string Text {
				get; set;
			}
		}

		#endregion

		#region Fields: Private

		private readonly string _templateSchemaName = "EmailTemplate";
		private Guid _chatTemplateType = Guid.Parse("62215DE1-23E0-4037-88C9-65CCF72904A4");
		private int _templateLength = 100;
		private const string RecentlyUsedGroupName = "RecentlyUsed";
		private const string OthersGroupName = "Others";
		private const string Ellipsis = "...";

		#endregion

		#region Methods: Private

		private void AddHintFilterToHintQuery(EntitySchemaQuery hintQuery, string hintText) {
			var filterGroup = new EntitySchemaQueryFilterCollection(hintQuery, LogicalOperationStrict.And);
			if (!string.IsNullOrEmpty(hintText)) {
				filterGroup.Add(new EntitySchemaQueryFilterCollection(hintQuery, LogicalOperationStrict.Or) {
					hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Contain,
						"Name",
						hintText
					),
					hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Contain,
						"Body",
						hintText
					)
				});
			}
			filterGroup.Add(hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						"TemplateType",
						_chatTemplateType
					));
			hintQuery.Filters.Add(filterGroup);
		}

		private EntityCollection GetTemplates(string text, int rowsOffset = 0, int elementsCount = 5) {
			var hintQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, _templateSchemaName);
			hintQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			hintQuery.AddColumn("Name").OrderByAsc();
			hintQuery.AddColumn("Body");
			AddHintFilterToHintQuery(hintQuery, text);
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = elementsCount,
				RowsOffset = rowsOffset,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var entityCollection = hintQuery.GetEntityCollection(UserConnection, options);
			return entityCollection;
		}

		/// <summary>
		/// Formats body text for display, showing context around search text if found outside initial length limit.
		/// </summary>
		/// <param name="body">Full body text.</param>
		/// <param name="searchText">Text to search for.</param>
		/// <returns>Formatted text with ellipsis if needed.</returns>
		private string FormatBodyWithSearchContext(string body, string searchText) {
			if (string.IsNullOrEmpty(body)) {
				return body;
			}
			int searchIndex = string.IsNullOrEmpty(searchText) 
				? -1 
				: body.ToLower().IndexOf(searchText.ToLower());
			if (searchIndex < 0 || searchIndex < _templateLength) {
				if (body.Length <= _templateLength) {
					return body;
				}
				return body.Substring(0, _templateLength) + Ellipsis;
			}
			int remainingLength = body.Length - searchIndex;
			if (remainingLength <= _templateLength) {
				return Ellipsis + body.Substring(searchIndex);
			}
			return Ellipsis + body.Substring(searchIndex, _templateLength) + Ellipsis;
		}

		private TemplateHint GetTemplateHintWithoutHtml(Entity entity) {
			var body = entity.GetTypedColumnValue<string>("Body");
			body = StringUtilities.GetPlainTextFromHtml(body, Int32.MaxValue);
			return new TemplateHint {
				Id = entity.GetTypedColumnValue<Guid>("Id"),
				Name = entity.GetTypedColumnValue<string>("Name"),
				Text = body.Length > _templateLength ? body.Substring(0, _templateLength) : body
			};
		}
		
		private List<TemplateHint> GetTemplateHintsFromEntityCollection(EntityCollection entityCollection, string text) {
			return GetTemplateHintsFromEntityCollection(entityCollection, text, useSearchContext: false);
		}

		private List<TemplateHint> GetTemplateHintsFromEntityCollection(EntityCollection entityCollection, string text, 
				bool useSearchContext) {
			var hints = new List<TemplateHint>();
			foreach (var entity in entityCollection) {
				var body = entity.GetTypedColumnValue<string>("Body");
				body = StringUtilities.GetPlainTextFromHtml(body, Int32.MaxValue);
				var name = entity.GetTypedColumnValue<string>("Name");
				string displayText;
				if (useSearchContext) {
					displayText = FormatBodyWithSearchContext(body, text);
				} else {
					displayText = body.Length > _templateLength 
						? body.Substring(0, _templateLength) 
						: body;
				}
				hints.Add(new TemplateHint {
					Id = entity.GetTypedColumnValue<Guid>("Id"),
					Name = name,
					Text = displayText
				});
			}
			return hints;
		}

		private EntitySchemaQuery CreateRecentlyUsedTemplatesQuery(string text) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OperatorTemplateUsage");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("UsageCount").OrderByDesc();
			esq.AddColumn("Template.Id");
			esq.AddColumn("Template.Name");
			esq.AddColumn("Template.Body");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Operator", UserConnection.CurrentUser.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Template.TemplateType", _chatTemplateType));
			if (!string.IsNullOrEmpty(text)) {
				var textFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or) {
					esq.CreateFilterWithParameters(FilterComparisonType.Contain, "Template.Name", text),
					esq.CreateFilterWithParameters(FilterComparisonType.Contain, "Template.Body", text)
				};
				esq.Filters.Add(textFilterGroup);
			}
			return esq;
		}

		private List<TemplateHint> ProcessRecentlyUsedTemplatesCollection(EntityCollection collection, string text) {
			var result = new List<TemplateHint>();
			foreach (var entity in collection) {
				var templateId = entity.GetTypedColumnValue<Guid>("Template_Id");
				var templateName = entity.GetTypedColumnValue<string>("Template_Name");
				var body = entity.GetTypedColumnValue<string>("Template_Body") ?? string.Empty;
				body = StringUtilities.GetPlainTextFromHtml(body, Int32.MaxValue);
				var hint = new TemplateHint {
					Id = templateId,
					Name = templateName,
					Text = FormatBodyWithSearchContext(body, text)
				};
				result.Add(hint);
			}
			return result;
		}

		/// <summary>
		/// Gets recently used templates for the current agent.
		/// </summary>
		/// <param name="text">Search text filter.</param>
		/// <param name="count">Maximum number of templates to return.</param>
		/// <returns>List of recently used template hints.</returns>
		private List<TemplateHint> GetRecentlyUsedTemplates(string text, int count) {
			var esq = CreateRecentlyUsedTemplatesQuery(text);
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = count,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var collection = esq.GetEntityCollection(UserConnection, options);
			return ProcessRecentlyUsedTemplatesCollection(collection, text);
		}

		/// <summary>
		/// Gets templates excluding the specified IDs.
		/// </summary>
		/// <param name="text">Search text filter.</param>
		/// <param name="excludeIds">Template IDs to exclude.</param>
		/// <param name="rowsCount">Maximum number of templates to return.</param>
		/// <returns>List of template hints sorted alphabetically.</returns>
		private List<TemplateHint> GetOtherTemplates(string text, HashSet<Guid> excludeIds, int rowsCount) {
			var hintQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, _templateSchemaName);
			hintQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			hintQuery.AddColumn("Name").OrderByAsc();
			hintQuery.AddColumn("Body");
			AddHintFilterToHintQuery(hintQuery, text);
			if (excludeIds.Any()) {
				hintQuery.Filters.Add(hintQuery.CreateFilterWithParameters(
					FilterComparisonType.NotEqual, 
					"Id", 
					excludeIds.Cast<object>().ToArray()));
			}
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = rowsCount,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var entityCollection = hintQuery.GetEntityCollection(UserConnection, options);
			return GetTemplateHintsFromEntityCollection(entityCollection, text ?? string.Empty, useSearchContext: true);
		}

		private void AddTemplateGroupIfNotEmpty(List<TemplateHintGroup> groups, string groupName, 
				List<TemplateHint> templates) {
			if (templates.Any()) {
				groups.Add(new TemplateHintGroup {
					GroupName = groupName,
					Templates = templates
				});
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Getting template hints by text.
		/// </summary>
		/// <returns><see cref="TemplateHintServiceResponse"/>Template hints.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TemplateHintServiceResponse GetTemplateHints(string text, int rowsCount) {
			EntityCollection entityCollection = GetTemplates(text, 0, rowsCount);
			var response = new TemplateHintServiceResponse {
				TemplateHints = GetTemplateHintsFromEntityCollection(entityCollection, text)
			};
			return response;
		}

		/// <summary>
		/// Getting template hints by text with records skipping.
		/// </summary>
		/// <returns><see cref="TemplateHintServiceResponse"/>Template hints.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public TemplateHintServiceResponse GetNextTemplateHints(string text, int skipRows, int rowsCount) {
			EntityCollection entityCollection = GetTemplates(text, skipRows, rowsCount);
			var response = new TemplateHintServiceResponse {
				TemplateHints = GetTemplateHintsFromEntityCollection(entityCollection, text)
			};
			return response;
		}

		/// <summary>
		/// Getting grouped template hints with recently used templates at top.
		/// </summary>
		/// <param name="text">Search text filter.</param>
		/// <param name="rowsCount">Maximum number of templates to return in Others group.</param>
		/// <param name="recentlyUsedCount">Number of recently used templates to show (default: 5).</param>
		/// <returns><see cref="TemplateHintServiceResponse"/>Grouped template hints.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public TemplateHintServiceResponse GetGroupedTemplateHints(string text, int rowsCount, int recentlyUsedCount = 5) {
			var templateGroups = new List<TemplateHintGroup>();
			var recentlyUsedTemplates = GetRecentlyUsedTemplates(text, recentlyUsedCount);
			AddTemplateGroupIfNotEmpty(templateGroups, RecentlyUsedGroupName, recentlyUsedTemplates);
			var recentlyUsedIds = new HashSet<Guid>(recentlyUsedTemplates.Select(t => t.Id));
			var otherTemplates = GetOtherTemplates(text, recentlyUsedIds, rowsCount);
			AddTemplateGroupIfNotEmpty(templateGroups, OthersGroupName, otherTemplates);
			return new TemplateHintServiceResponse {
				TemplateGroups = templateGroups
			};
		}

		#endregion

	}

	#endregion

}
