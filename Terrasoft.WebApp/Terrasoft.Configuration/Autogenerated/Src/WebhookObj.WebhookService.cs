namespace Terrasoft.Configuration
{
	using System;

	/// <summary>
	/// Represents a webhook object for use in code.
	/// </summary>
	public class WebhookObj
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the type of the content.
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// Gets or sets the headers.
		/// </summary>
		public string Headers { get; set; }

		/// <summary>
		/// Gets or sets the query parameters.
		/// </summary>
		public string QueryParameters { get; set; }

		/// <summary>
		/// Gets or sets the request body.
		/// </summary>
		public string RequestBody { get; set; }

		/// <summary>
		/// Gets or sets the u identifier.
		/// </summary>
		public Guid UId { get; set; }

		/// <summary>
		/// Gets or sets the webhook source.
		/// </summary>
		public string WebhookSource { get; set; }

		/// <summary>
		/// Gets or sets the webhook source url.
		/// </summary>
		public string SourceUrl { get; set; }

		#endregion

	}
}
