namespace Terrasoft.Configuration.ExternalAccessPackage
{
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: DataIsolationEntitiesListener

	/// <summary>
	/// Helps to actualize data isolation entity schema list.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysModule")]
	[EntityEventListener(SchemaName = "SysDetail")]
	public class DataIsolationEntitiesListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void FlushDataIsolationHelperCache(UserConnection userConnection) {
			if (!ClassFactory.HasBinding<IDataIsolationHelper>()) {
				return;
			}
			var dataIsolationHelper = ClassFactory.Get<IDataIsolationHelper>();
			dataIsolationHelper.ClearIsolatedEntitiesCache(userConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			FlushDataIsolationHelperCache(entity.UserConnection);
			base.OnSaving(sender, e);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			var entity = (Entity)sender;
			FlushDataIsolationHelperCache(entity.UserConnection);
			base.OnDeleted(sender, e);
		}

		#endregion

	}

	#endregion

}

