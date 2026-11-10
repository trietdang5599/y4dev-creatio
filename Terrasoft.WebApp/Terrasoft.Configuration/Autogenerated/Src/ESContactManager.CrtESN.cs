namespace Terrasoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using global::Common.Logging;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.GlobalSearch;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region class: ESEmailManager

	[DefaultBinding(typeof(IESContactManager))]
	public class ESContactManager: IESContactManager
	{
		#region Constants: Private

		private readonly ILog _gsLog = LogManager.GetLogger("GlobalSearch");

		#endregion

		private readonly UserConnection _uc;
		private readonly IMentionRepository _mentionRepository;
		private readonly IESMentionQueryBuilder _queryBuilder;

		#region Constructors: Public

		public ESContactManager() { }

		public ESContactManager(IMentionRepository elasticSearchRepository,
			IESMentionQueryBuilder queryBuilder, UserConnection userConnection) {
			_uc = userConnection;
			_queryBuilder = queryBuilder;
			_mentionRepository = elasticSearchRepository;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<ContactForMention> FilterByRecordRight(List<ContactForMention> contactsForMention) {
			var contactSchema = _uc.EntitySchemaManager.GetInstanceByName("Contact");
			var esq = new EntitySchemaQuery(_uc.EntitySchemaManager, "Contact");
			var primaryColumn = esq.AddColumn(contactSchema.PrimaryColumn.Name);
			var primaryDisplayColum = esq.AddColumn(contactSchema.PrimaryDisplayColumn.Name);
			var primaryImageColumn = esq.AddColumn(contactSchema.PrimaryImageColumn.Name);
			var connectionTypeColumn = esq.AddColumn("[SysAdminUnit:Contact].ConnectionType");
			esq.Filters.Add(esq.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					contactSchema.PrimaryColumn.Name,
					contactsForMention.Select(c => (object)c.Id).ToArray()
				)
			);
			var filteredEntities = esq.GetEntityCollection(_uc)
				.ToDictionary(
					e => e.GetTypedColumnValue<Guid>(primaryColumn.Name),
					e => e
				);
			foreach (var filteredEntity in filteredEntities) {
				var contactForMention = contactsForMention.FirstOrDefault(c => c.Id == filteredEntity.Key);
				var entity = filteredEntity.Value;
				contactForMention.ConnectionType = entity.GetTypedColumnValue<int>(connectionTypeColumn.Name).ToString();
				contactForMention.Name = entity.GetTypedColumnValue<string>(primaryDisplayColum.Name);
				contactForMention.ImageId = entity.GetTypedColumnValue<Guid>(primaryImageColumn.ValueQueryAlias);
			}
			return contactsForMention.Where(c => filteredEntities.ContainsKey(c.Id));
		}

		#endregion

		#region Methods: Protected


		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IESContactManager.SearchContacts(List{string}, int, int)"/>
		public async Task<IEnumerable<ContactForMention>> SearchContactsAsync(List<string> queries,
				int rowCount = default, int rowsOffset = default) {
			try {
				var elasticQuery = _queryBuilder.BuildQuery(new MentionQuery {
					Count = rowCount,
					Offset = rowsOffset,
					Query = string.Join(" ", queries),
				});
				var elasticResponse = await _mentionRepository.GetAsync<Mention>(elasticQuery);
				var contactsForMention = elasticResponse.Documents.Select(d => new ContactForMention {
					Email = d.Object.Email,
					Id= d.Object.Id,
					ImageId = d.Object.PhotoId ?? Guid.Empty,
					Name = d.Object.DisplayValue
				}).ToList();
				if (contactsForMention.Count == 0) {
					return new List<ContactForMention>();
				}
				return FilterByRecordRight(contactsForMention);
			} catch (Exception e) {
				_gsLog.Error("Error occurred, when search contacts in elasticsearch.", e);
				throw;
			}
		}

		#endregion

	}

	#endregion

}
