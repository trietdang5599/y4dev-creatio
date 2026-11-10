 namespace Terrasoft.Configuration.ESN
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EsnFileDTO

	[DataContract]
	public class EsnFileDTO
	{
		#region Properties: Public

		[DataMember(Name = "Id")]
		public Guid Id { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "Size")]
		public int Size { get; set; }

		[DataMember(Name = "CreatedOn")]
		public string CreatedOn { get; set; }

		#endregion
	}

	#endregion
}
