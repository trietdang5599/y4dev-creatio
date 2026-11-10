namespace Terrasoft.Configuration
{
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.FileSecurity;

	#region Class: FileSecurityExcludedUriEventListener

	/// <summary>
	/// Listener for 'FileSecurityExcludedUri' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "FileSecurityExcludedUri")]
	public class FileSecurityExcludedUriEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		private readonly IFileSecurityExcludedUrisProvider _provider;

		#endregion

		#region Constructors: Internal

		internal FileSecurityExcludedUriEventListener(IFileSecurityExcludedUrisProvider provider) {
			provider.CheckArgumentNull(nameof(provider));
			_provider = provider;
		}

		#endregion

		#region Constructors: Public

		public FileSecurityExcludedUriEventListener() : this(ClassFactory.Get<IFileSecurityExcludedUrisProvider>()) {
		}

		#endregion

		#region Methods: Private

		private void ResetCache() {
			_provider.ResetCache();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			ResetCache();
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ResetCache();
		}

		#endregion

	}

	#endregion

}

