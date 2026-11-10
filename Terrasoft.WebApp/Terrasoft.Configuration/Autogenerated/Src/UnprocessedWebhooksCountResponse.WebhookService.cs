namespace Terrasoft.Configuration
{
	using System.Runtime.Serialization;
	using Terrasoft.Nui.ServiceModel.DataContract;

	/// <summary>
	/// Response class for getting unprocessed webhooks count.
	/// </summary>
	[DataContract]
	public class UnprocessedWebhooksCountResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Webhooks Count.
		/// </summary>
		[DataMember(Name = "webhooksCount")]
		public long WebhooksCount { get; set; }

		#endregion

	}

}

