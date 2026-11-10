namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: TagInRecordListener

	/// <summary>
	/// Listener for 'TagInRecord' entity events.
	/// </summary>
	[EntityEventListener(SchemaName = "TagInRecord")]
	public class TagInRecordListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void SetTagRecordIdIfNeed(Entity entity) {
			var tagId = entity.GetTypedColumnValue<Guid>("TagId");
			if (!tagId.Equals(Guid.Empty)) {
				entity.SetColumnValue("TagRecordId", tagId);
			}
		}

		private bool IsCurrentUserHasOperationGrantee(Entity entity) {
			if (!entity.UseAdminRights) {
				return true;
			}
			Guid tagId = entity.GetTypedColumnValue<Guid>("TagId");
			ITagRightsHelper tagRightsHelper = ClassFactory.Get<ITagRightsHelper>(
					new ConstructorArgument("userConnection", entity.UserConnection));
			return tagRightsHelper.CanTag(tagId, entity.UserConnection.CurrentUser.Id);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			if (!IsCurrentUserHasOperationGrantee(entity)) {
				e.IsCanceled = true;
				return;
			}
			SetTagRecordIdIfNeed(entity);
			entity.UseAdminRights = false;
			base.OnInserting(sender, e);
		}

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			SetTagRecordIdIfNeed(entity);
			base.OnUpdating(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			if (!IsCurrentUserHasOperationGrantee(entity)) {
				e.IsCanceled = true;
				return;
			}
			entity.UseAdminRights = false;
			base.OnDeleting(sender, e);
		}

		#endregion
	}

	#endregion
}
