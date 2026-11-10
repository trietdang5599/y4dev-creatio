namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using global::Common.Logging;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using System.Data;

	#region Class: VwRecepientEmailQueryExecutor
	/// <summary>
	/// Implementation <see cref="IEntityQueryExecutor"/> for 'VwRecepientEmail' entity.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "VwRecepientEmailQueryExecutor")]
	internal class VwRecepientEmailQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly string _contactSchemaName = "Contact";
		private readonly Guid _emailCommunicationType = new Guid("EE1C85C3-CFCB-DF11-9B2A-001D60E938C6");
		private readonly Dictionary<string, string> _contactColumnNames = new Dictionary<string, string>() {
			{ "ContactCommunication", "Contact." },
			{ "AccountCommunication", "Account.PrimaryContact." },
			{ "Lead", "Lead" }
		};

		#endregion

		#region Properties: Private

		private string ContactDisplayColumnName {
			get {
				if (_contactDisplayColumnName.IsNullOrEmpty()) {
					var contactEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, _contactSchemaName);
					_contactDisplayColumnName = contactEsq.RootSchema.PrimaryDisplayColumn.Name;
				}
				return _contactDisplayColumnName;
			}
		}

		private string _contactDisplayColumnName;

		#endregion

		#region Constructors: Public

		public VwRecepientEmailQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private EntityCollection ConvertToVwRecepientEmailEntityCollection(List<Entity> collection) {
			var result = new EntityCollection(_userConnection, "VwRecepientEmail");
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("VwRecepientEmail");
			collection.ForEach(e => result.Add(ConvertToEntity(schema, e)));
			return result;
		}

		private Entity ConvertToEntity(EntitySchema schema, Entity recipientEmailModel) {
			var number = recipientEmailModel.GetTypedColumnValue<string>("Number");
			var name = recipientEmailModel.GetTypedColumnValue<string>("RecipientName");
			Entity recipientEmail = schema.CreateEntity(_userConnection);
			recipientEmail.SetColumnValue("Id",
				recipientEmailModel.Schema.Name != "Lead" ? recipientEmailModel.PrimaryColumnValue : Guid.NewGuid());
			recipientEmail.SetColumnValue("Email", $"{name} <{number}>");
			recipientEmail.SetColumnValue("Number", number);
			recipientEmail.SetColumnValue("UseEmail", recipientEmailModel.GetTypedColumnValue<bool>("UseEmail"));
			recipientEmail.SetColumnValue("ContactId", recipientEmailModel.GetTypedColumnValue<Guid>("ContactId"));
			recipientEmail.SetColumnValue("ContactName", recipientEmailModel.GetTypedColumnValue<string>("ContactName"));
			return recipientEmail;
		}

		private void TryGetFilter<T>(EntitySchemaQueryFilterCollection filters,
				string columnName, out T value) {
			value = default;
			EntitySchemaQueryFilterCollection filterCollection = filters[0] is EntitySchemaQueryFilterCollection
				? (EntitySchemaQueryFilterCollection)filters[0]
				: filters;
			var filter = filterCollection.Select(f => f as EntitySchemaQueryFilter)
				.FirstOrDefault(f => f?.LeftExpression.Path == columnName);
			if (filter != null) {
				value = (T)filter.RightExpressions[0].ParameterValue;
			}
		}

		private void TryGetIdFilters(EntitySchemaQueryFilterCollection filters, out IEnumerable<object> value) {
			value = null;
			EntitySchemaQueryFilterCollection filterCollection = filters[0] is EntitySchemaQueryFilterCollection
				? (EntitySchemaQueryFilterCollection)filters[0]
				: filters;
			var filter = filterCollection.Select(f => f as EntitySchemaQueryFilter)
				.FirstOrDefault(f => f?.LeftExpression.Path == "Id");
			if (filter == null) {
				return;
			}
			value = filter.RightExpressions.Select(re => re.ParameterValue);
		}

		private void AddEsqParameters(EntitySchemaQuery entitySchemaQuery, EntitySchemaQuery esq) {
			var filters = esq.Filters;
			TryGetFilter(filters, "ContactName", out string contactName);
			TryGetFilter(filters, "Email", out string email);
			TryGetIdFilters(filters, out IEnumerable<object> ids);
			var emailColumnName = entitySchemaQuery.RootSchema.Name != "Lead" ? "Number" : "Email";
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.IsNotNull,
				emailColumnName));
			var searchFilters = new EntitySchemaQueryFilterCollection(entitySchemaQuery, LogicalOperationStrict.Or);
			if (email.IsNotNullOrEmpty()) {
				searchFilters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Contain,
					emailColumnName, email));
			}
			if (contactName.IsNotNullOrEmpty()) {
				var columnName = _contactColumnNames[entitySchemaQuery.RootSchema.Name] + "Name";
				searchFilters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Contain, columnName, contactName));
			}
			if (ids != null && ids.IsNotEmpty()) {
				searchFilters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", ids.ToArray()));
			}
			entitySchemaQuery.Filters.Add(searchFilters);
			if (entitySchemaQuery.RootSchema.Name != "Lead") {
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.IsNotNull,
					_contactColumnNames[entitySchemaQuery.RootSchema.Name] + "Id"));
				entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"CommunicationType", _emailCommunicationType));
			}
		}

		private EntitySchemaQueryOptions GetEsqPagableOptions(int rowCount, int skipRowCount) {
			return new EntitySchemaQueryOptions() {
				RowsOffset = skipRowCount,
				PageableRowCount = rowCount,
				PageableConditionValues = new Dictionary<string, object>()
			};
		}

		/// <summary>
		/// Executes the communication query, using pageable options only for a positive page size.
		/// A negative <paramref name="rowCount"/> means "no row limit" (for example, when the lookup
		/// re-reads selected records that were filtered out of the visible page); passing it as
		/// <see cref="EntitySchemaQueryOptions.PageableRowCount"/> produces invalid pageable SQL, so the
		/// query is executed without pageable options in that case.
		/// </summary>
		private EntityCollection GetCommunicationEntityCollection(EntitySchemaQuery entitySchemaQuery,
				int rowCount, int skipRowCount) {
			return rowCount < 0
				? entitySchemaQuery.GetEntityCollection(_userConnection)
				: entitySchemaQuery.GetEntityCollection(_userConnection, GetEsqPagableOptions(rowCount, skipRowCount));
		}

		private EntityCollection GetAccountCommunicationEntityCollection(EntitySchemaQuery esq) {
			var entitySchemaQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "AccountCommunication");
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.AddColumn("Account.Name").Name = "RecipientName";
			entitySchemaQuery.AddColumn("Number");
			entitySchemaQuery.AddColumn(false, new BooleanDataValueType(_userConnection.DataValueTypeManager)).Name = "UseEmail";
			entitySchemaQuery.AddColumn("Account.PrimaryContact.Id").Name = "ContactId";
			entitySchemaQuery.AddColumn($"Account.PrimaryContact.{ContactDisplayColumnName}").Name = "ContactName";
			AddEsqParameters(entitySchemaQuery, esq);
			EntityCollection entityCollection = GetCommunicationEntityCollection(entitySchemaQuery, esq.RowCount, esq.SkipRowCount);
			return entityCollection;
		}

		private EntityCollection GetContactCommunicationEntityCollection(EntitySchemaQuery esq, int rowCount, int skipRowCount) {
			var entitySchemaQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ContactCommunication");
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.AddColumn($"Contact.{ContactDisplayColumnName}").Name = "RecipientName";
			entitySchemaQuery.AddColumn("Number");
			entitySchemaQuery.AddColumn("Contact.DoNotUseEmail").Name = "UseEmail";
			entitySchemaQuery.AddColumn($"Contact.{ContactDisplayColumnName}").Name = "ContactName";
			entitySchemaQuery.AddColumn("Contact.Id").Name = "ContactId";
			AddEsqParameters(entitySchemaQuery, esq);
			EntityCollection entityCollection = GetCommunicationEntityCollection(entitySchemaQuery, rowCount, skipRowCount);
			return entityCollection;
		}

		private EntityCollection GetLeadCommunicationEntityCollection(EntitySchemaQuery esq, int rowCount, int skipRowCount) {
			var entitySchemaQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Lead");
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.AddColumn("LeadName").Name = "RecipientName";
			entitySchemaQuery.AddColumn("Email").Name = "Number";
			entitySchemaQuery.AddColumn("DoNotUseEmail").Name = "UseEmail";
			entitySchemaQuery.AddColumn("Id").Name = "ContactId";
			entitySchemaQuery.AddColumn("LeadName").Name = "ContactName";
			AddEsqParameters(entitySchemaQuery, esq);
			EntityCollection entityCollection = GetCommunicationEntityCollection(entitySchemaQuery, rowCount, skipRowCount);
			return entityCollection;
		}

		private int GetAccountCommunicationsCount(EntitySchemaQuery originalEsq) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "AccountCommunication");
			esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count, "Number")).Name = "Count";
			AddEsqParameters(esq, originalEsq);
			var result = esq.GetEntityCollection(_userConnection);
			var count = result.First().GetTypedColumnValue<int>("Count");
			return count;
		}

		private int GetLeadsSkip(EntitySchemaQuery originalEsq, int processedAccountsCount) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ContactCommunication");
			esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count, "Number")).Name = "Count";
			AddEsqParameters(esq, originalEsq);
			var result = esq.GetEntityCollection(_userConnection);
			var processedContactsCount = result.First().GetTypedColumnValue<int>("Count");
			return originalEsq.SkipRowCount - processedContactsCount - processedAccountsCount;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns recipient email entity collection.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> instance.</param>
		/// <returns>Recipient email entity collection.</returns>
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var result = new EntityCollection(_userConnection, "VwRecepientEmail");
			var accountCommunicationEntities = GetAccountCommunicationEntityCollection(esq);
			result.AddRange(ConvertToVwRecepientEmailEntityCollection(accountCommunicationEntities.ToList()));
			//if page size not reached OR skip not long enough go to contact communications
			if (result.Count < esq.RowCount || esq.RowCount < 0) {
				//skip for ContactCommunications should be initial skip - processed account communications
				//we can assume that initial skip less than processed account communications if any records are loaded
				var skipRowCount = 0;
				var processedAccountsCount = 0;
				if (accountCommunicationEntities.Count <= 0) {
					processedAccountsCount = GetAccountCommunicationsCount(esq);
					skipRowCount = esq.SkipRowCount - processedAccountsCount;
				}
				//we take enough records to fill in page size, skiping X records we get on prev pages.
				var contactCommunicationEntities = GetContactCommunicationEntityCollection(esq, esq.RowCount - result.Count, skipRowCount);
				result.AddRange(ConvertToVwRecepientEmailEntityCollection(contactCommunicationEntities.ToList()));
				if (_userConnection.EntitySchemaManager.FindItemByName("Lead") != null) {
					//if page size not reached OR skip not long enough go to lead
					if (result.Count < esq.RowCount || esq.RowCount < 0) {
						//skip for Lead should be initial skip - processed account communications - processed contact communications
						//we can assume that initial skip less than processed account communications + contact communications
						// if any records from contactCommunicationEntities are loaded
						skipRowCount = contactCommunicationEntities.Count > 0 ? 0 : GetLeadsSkip(esq, processedAccountsCount);
						var leadCommunicationEntities = GetLeadCommunicationEntityCollection(esq, esq.RowCount - result.Count, skipRowCount);
						result.AddRange(ConvertToVwRecepientEmailEntityCollection(leadCommunicationEntities.ToList()));
					}
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}

