namespace Terrasoft.Configuration
{
	using System.Runtime.Serialization;
	using Terrasoft.Nui.ServiceModel.DataContract;

	/// <summary>
	/// Response class for getting unprocessed webhooks count filtered by reasons.
	/// </summary>
	[DataContract]
	public class UnprocessedWebhooksCountByReasonAggregatedResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Restricted Webhooks Count.
		/// </summary>
		[DataMember(Name = "restrictedWebhooksCount")]
		public long RestrictedWebhooksCount { get; set; }

		/// <summary>
		/// Undelivered because of Integration issues Count.
		/// </summary>
		[DataMember(Name = "integrationProblemWebhooksCount")]
		public long IntegrationProblemWebhooksCount { get; set; }

		/// <summary>
		/// Undelivered because of Identity unavailability issues Count.
		/// </summary>
		[DataMember(Name = "identityUnavailableProblemWebhooksCount")]
		public long IdentityUnavailableProblemWebhooksCount { get; set; }

		/// <summary>
		/// Undelivered because of lack of permissions Count.
		/// </summary>
		[DataMember(Name = "noPermissionsProblemWebhooksCount")]
		public long NoPermissionsProblemWebhooksCount { get; set; }

		/// <summary>
		/// Undelivered because of Creatio unavailability issues Count.
		/// </summary>
		[DataMember(Name = "creatioUnavailableProblemWebhooksCount")]
		public long CreatioUnavailableProblemWebhooksCount { get; set; }

		/// <summary>
		/// Other Creatio issues Count.
		/// </summary>
		[DataMember(Name = "otherCreatioIssuesWebhooksCount")]
		public long OtherCreatioIssuesWebhooksCount { get; set; }

		#endregion

	}
}

