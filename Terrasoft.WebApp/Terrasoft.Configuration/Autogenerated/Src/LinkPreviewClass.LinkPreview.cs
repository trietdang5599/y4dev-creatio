using System;
using System.Runtime.Serialization;

namespace Terrasoft.Configuration
{

	#region Class: LinkPreviewInfo

	/// <summary>
	/// Class of link preview info.
	/// </summary>
	[DataContract]
	public class LinkPreviewInfo
	{
		#region Properties: Public

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "image")]
		public string Image { get; set; }

		[DataMember(Name = "host")]
		public string Host { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		#endregion
	}

	#endregion

	#region Class: LinkPreview

	/// <summary>
	/// Class for generate link preview info.
	/// </summary>
	public class LinkPreview
	{

		#region Methods: Public

		/// <summary>
		/// Generates link preview info by url.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Link preview info.</returns>
		public LinkPreviewInfo GetWebPageLinkPreview(string url) {
			return new LinkPreviewInfo();
		}

		#endregion
	}

	#endregion
}
