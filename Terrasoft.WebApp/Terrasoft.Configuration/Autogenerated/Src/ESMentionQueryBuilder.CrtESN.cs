namespace Terrasoft.Configuration.GlobalSearch
{
	using System.Collections.Generic;
	using Terrasoft.Core.Factories;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Class: ESMentionQueryBuilder

	/// <summary>
	/// Elastic search mention query builder.
	/// </summary>
	[DefaultBinding(typeof(IESMentionQueryBuilder))]
	public class ESMentionQueryBuilder: IESMentionQueryBuilder
	{
		#region Methods: Public

		public SearchRequest BuildQuery(MentionQuery query) {
			return new SearchRequest {
				Offset = query.Offset,
				Count = query.Count,
				Filter = new Filter {
					Columns = new Dictionary<string, object> { { "contact_sysadminunit_active", true } },
					Entities = new string[] { "Contact" },
					Clause = Clause.Must
				},
				Should = new List<MatchingRule> {
					new MatchingRule {
						Conditions = new List<MatchingCondition>() {
							new MatchingCondition {
								ColumnName = "details.ContactCommunication_text.text",
								ColumnValues = new List<string> { query.Query }
							}
						}
					},
					new MatchingRule {
						Conditions = new List<MatchingCondition>() {
							new MatchingCondition {
								ColumnName = "_mention_contact_name_globalsearch_primary_",
								ColumnValues = new List<string> { query.Query }
							}
						}
					},
					new MatchingRule {
						Conditions = new List<MatchingCondition>() {
							new MatchingCondition {
								ColumnName = "_mention_contact_email_",
								ColumnValues = new List<string> { query.Query }
							}
						}
					}
				},
				Source = new Source {
					Includes = new string[] { "_entity", "id", "contact_email" }
				},
				MinimumShouldMatch = 1
			};
		}

		#endregion

	}

	#endregion

}
