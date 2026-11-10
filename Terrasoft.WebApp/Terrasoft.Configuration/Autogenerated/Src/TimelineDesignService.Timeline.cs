namespace Terrasoft.Configuration.Timeline
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: TimelineSourcesResponse

	[DataContract]

	public class TimelineSourcesResponse : ConfigurationServiceResponse
	{
		[DataMember(Name = "sources")]
		public List<TimelineTileSource> Sources { get; set; }
	}

	#endregion

	#region Class: TimelineDesignService

	/// <summary>
	/// Service of timeline in designer.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TimelineDesignService : BaseService
	{
		#region Properties: Protected

		private ITimelineRepository _timelineRepository;
		protected ITimelineRepository TimelineRepository {
			get {
				if (_timelineRepository == null) {
					return _timelineRepository = ClassFactory.Get<ITimelineRepository>(new ConstructorArgument("uc", UserConnection));
				}
				return _timelineRepository;
			}

		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns all timeline sources <see cref="TimelineTileSource"/>.
		/// </summary>
		/// <param name="referenceSchemaName">Name of reference schema.</param>
		/// <returns>List of sources.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
		   ResponseFormat = WebMessageFormat.Json)]
		public TimelineSourcesResponse GetSources(string referenceSchemaName) {
			var sources = TimelineRepository.GetTimelineSources(referenceSchemaName);
			return new TimelineSourcesResponse { Sources = sources };
		}

		#endregion

	}

	#endregion
}
