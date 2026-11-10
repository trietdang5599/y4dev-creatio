namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Runtime.Serialization;

	#region Class: GetDuplicateEntitiesByGroupParams

	
	/// <summary>
	/// Parameters model for GetDuplicateEntitiesByGroupParams.
	/// </summary>
	[DataContract]
	public class GetDuplicateEntitiesByGroupParams
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

		[DataMember(Name = "groupId")]
		public Guid GroupId { get; set; }

		[DataMember(Name = "filters")]
		public string Filters { get; set; }

		#endregion

	}

	#endregion

}
