namespace Terrasoft.Configuration.Deduplication
{
	using System.Runtime.Serialization;

	#region Class: GetGroupsOfDuplicatesParams

	
	/// <summary>
	/// Parameters model for GetGroupsOfDuplicatesParams.
	/// </summary>
	[DataContract]
	public class GetGroupsOfDuplicatesParams
	{

		#region Properties: Public

		[DataMember(Name = "entityName")]
		public string EntityName { get; set; }

		[DataMember(Name = "columns")]
		public string[] Columns { get; set; }

		[DataMember(Name = "offset")]
		public int Offset { get; set; }

		[DataMember(Name = "count")]
		public int Count { get; set; }

		[DataMember(Name = "topDuplicatesPerGroup")]
		public int TopDuplicatesPerGroup { get; set; }

		[DataMember(Name = "filters")]
		public string Filters { get; set; }

		#endregion

	}

	#endregion

}
