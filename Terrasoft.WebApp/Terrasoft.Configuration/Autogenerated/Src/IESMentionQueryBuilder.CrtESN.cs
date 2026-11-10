namespace Terrasoft.Configuration.GlobalSearch
{
	using Terrasoft.Core.Entities;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Interface: IESMentionQueryBuilder

	/// <summary>
	/// Elastic search mention query builder.
	/// </summary>
	public interface IESMentionQueryBuilder {

		#region Methods: Public

		/// <summary>
		/// Build <see cref="MentionQuery"/> for searching datas in elastic search.
		/// </summary>
		/// <param name="query"><see cref="MentionQuery"/> instance.</param>
		/// <returns><see cref="ElasticQuery"/> instance.</returns>
		SearchRequest BuildQuery(MentionQuery query);

		#endregion


	}

	#endregion

}
