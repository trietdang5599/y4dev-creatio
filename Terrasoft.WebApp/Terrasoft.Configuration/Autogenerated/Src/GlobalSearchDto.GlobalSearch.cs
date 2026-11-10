namespace Terrasoft.Configuration.GlobalSearchDto
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using Terrasoft.Nui.ServiceModel.DataContract;

	/// <summary>
	/// Represents search response to bpm.
	/// </summary>
	[DataContract]
	public class BpmSearchResponse : BaseResponse
	{

		/// <summary>
		/// Search time taken.
		/// </summary>
		[DataMember(Name = "took")]
		public int Took {
			get;
			set;
		}

		/// <summary>
		/// Total found records.
		/// </summary>
		[DataMember(Name = "total")]
		public int Total {
			get;
			set;
		}

		/// <summary>
		/// First item index for next search query.
		/// </summary>
		[DataMember(Name = "nextFrom")]
		public int NextFrom {
			get;
			set;
		}

		/// <summary>
		/// List of <see cref="BpmSearchResponseEntity"/> instances.
		/// </summary>
		[DataMember(Name = "data")]
		public List<BpmSearchResponseEntity> Data {
			get;
			set;
		}
	}

	/// <summary>
	/// Represents search response bpm entity.
	/// </summary>
	[DataContract, Serializable]
	public class BpmSearchResponseEntity
	{
		[DataMember(Name = "entityName")]
		public string EntityName {
			get;
			set;
		}

		[DataMember(Name = "id")]
		public string Id {
			get;
			set;
		}

		[DataMember(Name = "columnValues")]
		public Dictionary<string, object> ColumnValues {
			get;
			set;
		}

		[DataMember(Name = "foundColumns")]
		public Dictionary<string, string[]> FoundColumns {
			get;
			set;
		}
	}

	/// <summary>
	/// Represents aggregation search response bpm entity.
	/// </summary>
	[DataContract, Serializable]
	public class BpmSearchAggregation
	{

		/// <summary>
		/// Type for search.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type {
			get;
			set;
		}

		/// <summary>
		/// Type alias.
		/// </summary>
		[DataMember(Name = "typeAlias")]
		public string TypeAlias {
			get;
			set;
		}

		/// <summary>
		/// Type count.
		/// </summary>
		[DataMember(Name = "count")]
		public int Count {
			get;
			set;
		}
	}
}
