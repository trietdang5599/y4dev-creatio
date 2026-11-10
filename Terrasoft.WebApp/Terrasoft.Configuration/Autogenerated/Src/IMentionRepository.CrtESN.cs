namespace Terrasoft.Configuration
{
	using System.Threading.Tasks;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Interface: IESMentionQueryBuilder

	/// <summary>
	/// Mention repository interface, represent API for getting objects for mention.
	/// </summary>
	public interface IMentionRepository
	{

		#region Methods: Public

		/// <summary>
		/// Get list of T instances from elastic search.
		/// </summary>
		/// <typeparam name="T">Type of object for maping.</typeparam>
		/// <param name="query"><see cref="ElasticQuery"/> instance.</param>
		/// <returns><see cref="ElasticResponse"/> instance.</returns>
		Task<SearchResponse<T>> GetAsync<T>(SearchRequest query) where T : class;

		#endregion


	}

	#endregion

}
