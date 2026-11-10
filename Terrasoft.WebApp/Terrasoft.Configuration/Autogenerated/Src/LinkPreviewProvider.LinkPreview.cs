using System;
using Terrasoft.Core;

namespace Terrasoft.Configuration
{
	#region Class: LinkPreviewProvider

	/// <summary>
	/// Class for provide link preview data.
	/// </summary>
	public class LinkPreviewProvider
	{

		#region Constructors: Public

		/// <summary>
		/// Creates new LinkPreviewProvider instance.
		/// </summary>
		/// <param name="userConnection">UserConnection instance.</param>
		/// <returns>LinkPreviewProvider instance.</returns>
		public LinkPreviewProvider(UserConnection userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Save link preview info by entity record id.
		/// </summary>
		/// <param name="linkPreviewInfo">Link preview info.</param>
		/// <param name="entityRecordId">Entity record id.</param>
		/// <returns>New link preview info record id.</returns>
		public Guid SaveLinkPreviewInfo(LinkPreviewInfo linkPreviewInfo, Guid entityRecordId) {
			return Guid.Empty;
		}

		/// <summary>
		/// Delete link preview info by entity record id.
		/// </summary>
		/// <param name="entityRecordId">Entity record id.</param>
		public void DeleteLinkPreviewInfo(Guid entityRecordId) {
		}

		#endregion
	}

	#endregion
}
