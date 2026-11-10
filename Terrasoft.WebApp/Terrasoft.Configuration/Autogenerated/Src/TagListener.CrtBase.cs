namespace Terrasoft.Configuration
{
	using System;
	using System.Security;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: TagListener

	/// <summary>
	/// Listener for 'Tag' entity events.
	/// </summary>
	[EntityEventListener(SchemaName = "Tag")]
	public class TagListener : BaseEntityEventListener
	{
		#region Methods: Private

		private bool IsCurrentUserHasOperationGrantee(Entity entity) {
			if (!entity.UseAdminRights) {
				return true;
			}
			Guid tagAccessId = entity.GetTypedColumnValue<Guid>("TagAccessId");
			ITagRightsHelper tagRightsHelper = ClassFactory.Get<ITagRightsHelper>(
					new ConstructorArgument("userConnection", entity.UserConnection));
			return tagRightsHelper.CanCreate(tagAccessId, entity.UserConnection.CurrentUser.Id);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles on inserting entity event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			if (!IsCurrentUserHasOperationGrantee(entity)) {
				throw new SecurityException(string.Format(new LocalizableString("Terrasoft.Core", "Entity.Exception.NoRightFor.Insert"), "Tag"));
			}
			base.OnInserting(sender, e);
		}

		#endregion

	}

	#endregion

}
